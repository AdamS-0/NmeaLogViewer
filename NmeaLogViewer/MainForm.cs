/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 03.10.2026
 * Time: 08:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;

namespace NmeaLogViewer {
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form {
        
        List<NmeaLine> _lines = new List<NmeaLine>();
        NmeaCntr _cntrs = new NmeaCntr();
        
        List<RegexOption> _rgxs = new List<RegexOption>();
        
        
        BackgroundWorker bgwrk1 = new BackgroundWorker();
        
        public MainForm() {
            InitializeComponent();
            prgBr1.Maximum = 10000;
            bgwrk1.DoWork += bgwrk1_DoWork;
            bgwrk1.ProgressChanged += bgwrk1_ProgressChanged;
        }
        
        private void writeStatus(string strStatus, bool clear = true) {
            if ( clear ) { rtbStatus.Text = ""; }
            
            rtbStatus.Text += strStatus;
        }
        
        void BtnLoadlogClick ( object sender, EventArgs e ) {
            _cntrs = new NmeaCntr();
            if ( _lines != null ) { _lines.Clear(); }
            
            _lines = ParseLogFile(txtBxLogFilename.Text, ref _cntrs);
            
            Dictionary<string, int> counts = new Dictionary<string, int>();
            int count = 0;
            foreach ( NmeaLine nmeaLine in _lines ) {
                if ( counts.TryGetValue( nmeaLine.NmeId, out count ) ) {
                    counts[nmeaLine.NmeId] = count + 1;
                } else {
                    counts.Add(nmeaLine.NmeId, 1 );
                }
            }
            
            string strStatus = "";
            foreach ( KeyValuePair<string, int> item in counts ) {
                strStatus += string.Format( "{0}: {1}\r\n", item.Key, item.Value );
            }
            writeStatus( "===== Nme counts =====\r\n", clear: false );
            writeStatus( strStatus, clear: false );
        }
        
        void BtnNewViewClick ( object sender, EventArgs e ) {
            LogView logViewWindow = new LogView();
            logViewWindow.BindRegexes( ref _rgxs, _lines.Count );
            logViewWindow.Show();
        }
        
        void RtbRegexesTextChanged ( object sender, EventArgs e ) {
            _rgxs = ProcessRegexes( rtbRegexes.Text );
        }
        
        void BtnParseLogClick ( object sender, EventArgs e ) {
            ProcessLogfileWithRegexs( ref _lines, ref _rgxs );
//            bgwrk1.RunWorkerAsync();
        }
        
        void TxtBxLogFilenameDragEnter ( object sender, DragEventArgs e ) {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop ) ) { e.Effect = DragDropEffects.Copy; }
            else { e.Effect = DragDropEffects.None; }
        }
        
        void TxtBxLogFilenameDragDrop ( object sender, DragEventArgs e ) {
            string[] files = (string[])e.Data.GetData( DataFormats.FileDrop );
            if ( files.Length > 0 ) { txtBxLogFilename.Text = files [ 0 ]; }
        }
        
        
        
        private List<RegexOption> ProcessRegexes(string strRgxs) {
            string[] rgxsLines = strRgxs.Split('\n');
            
            List<RegexOption> rgxs = new List<RegexOption>();
            foreach ( string line in rgxsLines ) {
                RegexOption rgo = RegexOption.parseLine( line );
                if ( rgo == null ) {
                    /* Error during parsing */
                    writeStatus( "Error during parsing regex: '" + line + "'.\r\n", clear: false );
                } else {
                    rgxs.Add( rgo );
                }
            }
            
            FillTreeViewWithRegexes( ref trVwData, ref rgxs );
            return rgxs;
        }
        
        
        public static void FillTreeViewWithRegexes( ref TreeView trvw, ref List<RegexOption> rgxs ) {
            trvw.Nodes.Clear();
            
            foreach ( RegexOption rgx in rgxs ) {
                TreeNode node = new TreeNode( rgx.NmeName );
                string[] grNames = rgx.rx.GetGroupNames();
                node.Tag = rgx.LineIds;
                for ( int idx = 1; idx < grNames.Length; idx++ ) {
                    TreeNode nodeI = node.Nodes.Add( grNames[idx] );
                    try {
                        List<float> dataY = rgx.Values[idx - 1];
                        nodeI.Text = grNames[idx] + " [" + dataY.Count + "]";
                        NodeSeries nodeSer = new NodeSeries( ref rgx.LineIds, ref dataY );
                        nodeI.Tag = nodeSer;
                    } catch {}
                }
                trvw.Nodes.Add( node );
            }
        }
        
        
        
        List<NmeaLine> ParseLogFile(string filePath, ref NmeaCntr cntrs) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<NmeaLine> lines = new List<NmeaLine>();
            if ( !File.Exists( filePath ) ) {
                writeStatus( "File doe snot exists!\r\n" );
                return lines;
            }
            
            int idxLine = 0;
            string line = "";
            
            int idxSOL =  0;
            int idxEOL = -1;
            int maxLineSize = 3*80;
            int cntrLineOverflow = 0;
            long numBytes = 0;
            
            byte[] buffer = new byte[64 * 1024];
            StringBuilder sbLine = new StringBuilder();
            int readBytes = -1;
            using ( FileStream fs = new FileStream( filePath, FileMode.Open, FileAccess.Read ) ) {
                numBytes = fs.Length;
                while ((readBytes = fs.Read(buffer, 0, buffer.Length)) > 0) {
                    char c = ' ';
                    for ( int idx = 0; idx < readBytes; idx++ ) {
                        c = (char)(buffer[idx]);
                        sbLine.Append( c );
                        if ( c == '\n' ) {
                            idxLine += 1;
                            try {
                                lines.Add( new NmeaLine( idxLine, sbLine.ToString(), ref cntrs ) );
                            } catch {}
                            sbLine.Clear();
                        }
                        
                        if ( sbLine.Length >= maxLineSize ) {
                            cntrLineOverflow++;
                            string strRet = sbLine.ToString();
                            sbLine.Clear();
                            int idxLastDollar = strRet.LastIndexOf('$');
                            if ( idxLastDollar > 0 ) {
                                sbLine.Append( strRet.Substring( idxLastDollar ) );
                            }
                        }
                    }
                }
            }
            
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string strTElapsed = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                (int)ts.TotalHours,
                                ts.Minutes,
                                ts.Seconds,
                                ts.Milliseconds);
            
            string strNumBytes = numBytes.ToString("#,##0", System.Globalization.CultureInfo.InvariantCulture).Replace(",", " ") + " B";
            
            string strStatus =
                "         Size: " + strNumBytes + ".\r\n" +
                "        Lines: " + idxLine + ".\r\n" +
                "Lines ovrflow: " + cntrLineOverflow + ".\r\n" +
                "       CHK ok: " + cntrs.ChkOk + ".\r\n" +
                "      CHK nok: " + cntrs.ChkNok + ".\r\n" +
                "Incorrect syntax: " + cntrs.IncorrectSyntax + ".\r\n" +
                "  Missing '$': " + cntrs.MissingDollar + ".\r\n" +
                "  Missing '*': " + cntrs.MissingAsterix + ".\r\n" +
                "  Missing CHK: " + cntrs.MissingChk + ".\r\n" +
                "    Read time: " + strTElapsed + ".\r\n";
            
            writeStatus( strStatus );
            return lines;
        }
        
        
        private void ProcessLogfileWithRegexs( ref List<NmeaLine> nmeaLines, ref List<RegexOption> rgxs ) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            foreach ( RegexOption rgx in rgxs ) {
                rgx.LineIds = new List<float>();
                rgx.Values = new List<List<float>>();
                
                int groupsNumber = rgx.rx.GetGroupNames().Length;
                for ( int idx = 1; idx < groupsNumber; idx++ ) {
                    rgx.Values.Add( new List<float>() );
                }
            }
            
            int lienCntr = 0;
            int linesTotal = nmeaLines.Count;
            int progressLast = 0;
            string strVal = "";
            foreach ( NmeaLine nmeaLine in nmeaLines ) {
                if ( nmeaLine.LineLength == 0 ) { continue; }
                
                foreach ( RegexOption rgx in rgxs ) {
//                    if ( !nmeaLine.Nmea.Contains( rgx.NmeName ) ) { continue; }
                    if ( !nmeaLine.Nmea.StartsWith( rgx.NmeName, StringComparison.Ordinal ) ) { continue; }
                    
                    Match m = rgx.rx.Match( nmeaLine.Nmea );
                    
                    if ( !m.Success ) { continue; }
                    /* Success! */
                    float valGrp = 0;
                    rgx.LineIds.Add( nmeaLine.LineId );
                    
                    for ( int idGrp = 1; ( idGrp < m.Groups.Count ) && ( ( idGrp - 1 ) < rgx.Values.Count ); idGrp++ ) {
                        valGrp = 0;
                        try {
                            strVal = m.Groups[idGrp].ToString();
                            strVal = strVal.Replace('.', ',');
                            valGrp = Convert.ToSingle( strVal );
                        } catch {}
                        rgx.Values[idGrp - 1].Add( valGrp );
                    }
                    
                    break;
                }
                
                lienCntr++;
                long progress = ( (long)lienCntr * (long)prgBr1.Maximum ) / (long)linesTotal;

                if ( progress != progressLast ) {
                    progressLast = (int)progress;
                    prgBr1.Value = (int)progress;
//                    bgwrk1.ReportProgress( progress );
                }
                
            }
            prgBr1.Value = prgBr1.Maximum;
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            string strTElapsed = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
                                (int)ts.TotalHours,
                                ts.Minutes,
                                ts.Seconds,
                                ts.Milliseconds);
            writeStatus( "Proceeded in time: " + strTElapsed + ".\r\n", clear: false );
        }
        
        
        private void bgwrk1_DoWork ( object sender, DoWorkEventArgs e ) {
            prgBr1.Value = 0;
//            ProcessLogfileWithRegexs( ref _lines, ref _rgxs );
            
        }
        
        private void bgwrk1_ProgressChanged ( object sender, ProgressChangedEventArgs e ) {
            prgBr1.Value = e.ProgressPercentage;
        }


        
    }
}
