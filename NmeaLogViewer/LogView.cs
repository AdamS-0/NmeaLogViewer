/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 03.10.2026
 * Time: 18:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace NmeaLogViewer {
    /// <summary>
    /// Description of LogView.
    /// </summary>
    public partial class LogView : Form {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        
        List<RegexOption> _rgxs = new List<RegexOption>();
        
        VisBox.AxisLimits _axisLimitsX = new VisBox.AxisLimits();
        int _linesNo = 0;
        
        public LogView() {
            InitializeComponent();
            nudLineStart.Value = 0;
            nudLineStop.Value = 10;
            hScrlBrView.MouseWheel += hScrlBr_mouseWheel;
        }
        
        public void BindRegexes( ref List<RegexOption> rgxs, int linesNo ) {
            _rgxs = rgxs;
            MainForm.FillTreeViewWithRegexes( ref trVwData, ref _rgxs );
            
            nudLineStart.Maximum = linesNo;
            nudLineStop.Maximum = linesNo;
            
            nudLineStart.Value = 0;
            nudLineStop.Value = linesNo;
            
            _linesNo = linesNo;
            
            hScrlBrView.Minimum = 0;
            hScrlBrView.Maximum = linesNo;
            hScrlBrView.LargeChange = linesNo;
            _axisLimitsX.Min = hScrlBrView.Minimum;
            _axisLimitsX.Max = hScrlBrView.Maximum;
        }
        
        bool _internalChange = false;
        private void hScrlBr_mouseWheel(object sender, MouseEventArgs e) {
            OnScroll( e.Delta );
        }
        
        private void OnScroll(int MouseWheelDelta) {
            bool LCtrlPressed = false;
            if( GetAsyncKeyState( Keys.LControlKey ) != 0 ) { LCtrlPressed = true; }

            int xMin = hScrlBrView .Value;
            int xDst = hScrlBrView .LargeChange;
            
            int xMax = xMin + xDst;
            int xMid = ( xMax + xMin ) / 2;
            
            if ( LCtrlPressed ) {
                /* Zoom in/out */
                if ( MouseWheelDelta < 0 )  { xDst = ( xDst * 11 ) / 10; }
                else                        { xDst = ( xDst *  9 ) / 10; }
                if ( xDst < 10 ) { xDst = 10; }
            } else {
                /* Move */
                xMid += ( ( MouseWheelDelta > 0 ? -1 : 1 ) * hScrlBrView.LargeChange / 6 );
            }
            
            if ( xDst >= _linesNo ) { xDst = _linesNo - 1; }
            
            xMin = xMid - xDst / 2;
            if ( xMin < 0 ) { xMin = 0; }
            xMax = xMin + xDst;
            if ( xMax >= _linesNo ) {
                xMax = _linesNo;
                xMin = xMax - xDst;
            }
            
            _internalChange = true;
            hScrlBrView .Value = (int)xMin;
            hScrlBrView .LargeChange = (int)xDst;
            
            _axisLimitsX.Min = (float)( hScrlBrView.Value );
            _axisLimitsX.Max = _axisLimitsX.Min + (float)( hScrlBrView.LargeChange );
            RefreshPlots();
            nudLineStart.Value = (int)_axisLimitsX.Min;
            nudLineStop .Value = (int)_axisLimitsX.Max;
            _internalChange = false;
        }
        
        
        void NudLineStartValueChanged ( object sender, EventArgs e ) {
//            if ( !_internalChange ) {
//                _internalChange = true;
//                _axisLimitsX.Min = (float)(nudLineStart.Value);
//                hScrlBrView.Value = (int)_axisLimitsX.Min;
//                hScrlBrView.LargeChange = (int)_axisLimitsX.Max - (int)_axisLimitsX.Min;
//                RefreshPlots();
//                _internalChange = false;
//            }
        }
        
        void NudLineStopValueChanged ( object sender, EventArgs e ) {
//            if ( !_internalChange ) {
//                _internalChange = true;
//                _axisLimitsX.Max = (float)(nudLineStop.Value);
//                hScrlBrView.Value = (int)_axisLimitsX.Min;
//                hScrlBrView.LargeChange = (int)_axisLimitsX.Max - (int)_axisLimitsX.Min;
//                RefreshPlots();
//                _internalChange = false;
//            }
        }
        
        void HScrlBrViewValueChanged(object sender, EventArgs e) {
            if ( !_internalChange ) {
                _axisLimitsX.Min = (float)( hScrlBrView.Value );
                _axisLimitsX.Max = _axisLimitsX.Min + (float)( hScrlBrView.LargeChange );
                try { nudLineStart.Value = (int)_axisLimitsX.Min; } catch {}
                try { nudLineStop .Value = (int)_axisLimitsX.Max; } catch {}
                if ( !_internalChange ) { RefreshPlots(); }
            }
        }
        
        
        
        void TrVwDataAfterSelect ( object sender, TreeViewEventArgs e ) {
            
        }
        
        private void TryAddDataWhenChecked( ref TreeNode node, ref bool isFirstPlot ) {
            if ( node.Nodes.Count > 0 ) {
                for ( int idx = 0; idx < node.Nodes.Count; idx++ ) {
                    TreeNode nodeChild = node.Nodes[idx];
                    TryAddDataWhenChecked( ref nodeChild, ref isFirstPlot );
                }
            } else {
                if ( node.Checked ) {
                    if ( node.Tag != null ) {
                        NodeSeries nodeSer = node.Tag as NodeSeries;
                        AddNewPlot( ref nodeSer.DataX, ref nodeSer.DataY, ref isFirstPlot );
                    }
                }
            }
        }
        
        private void WhenCheckedChanged() {
            pCharts.Controls.Clear();
            bool isFirstPlot = true;
            
            pCharts.SuspendLayout();
            
            for ( int idx = 0; idx < trVwData.Nodes.Count; idx++ ) {
                TreeNode nodeChild = trVwData.Nodes[idx];
                TryAddDataWhenChecked( ref nodeChild, ref isFirstPlot );
            }
            
            pCharts.ResumeLayout();
            
            RefreshPlots();
        }
        
        private void AddNewPlot( ref List<float> dataX, ref List<float> dataY, ref bool isFirstPlot ) {
            VisBox.Plot plot = new VisBox.Plot();
            VisBox.Series s1 = new VisBox.Series( ref dataX, ref dataY, new VisBox.Marker(Color.Yellow, ' '), new Pen( Color.Blue ) );
            
            plot.AxisLimitsX        = _axisLimitsX;
            plot.gridX.Autoscale    = true;
            
            plot.gridY.Format       = "0.00";
            plot.gridY.ShowLables   = true;
            plot.gridY.Autoscale    = true;
//            plot.AxisLimitsY.Autoscale = true;
            
            if ( isFirstPlot ) {
                isFirstPlot = false;
                plot.gridX.GridOn           = true;
                plot.gridX.ShowLables       = true;
                plot.gridX.Format           = "0";
            }
            
            plot.gridXminor.GridOn      = true;
            plot.gridXminor.ShowLables  = false;
            plot.gridXminor.Autoscale   = true;
            plot.gridXminor.ScaleFactor = 0.25f;
            
            float fMin = dataY.Min();
            float fMax = dataY.Max();
            float deltaY = Math.Abs( fMax - fMin );
            if ( deltaY == 0.0f ) {
                deltaY = 1;
            }
            
            fMin -= 0.1f*deltaY;
            fMax += 0.1f*deltaY;
            
            plot.AxisLimitsY.Min = fMin;
            plot.AxisLimitsY.Max = fMax;
            
            plot.AddSeries( ref s1 );
            plot.Dock = DockStyle.Top;
            pCharts.Controls.Add( plot );
            plot.BringToFront();
            plot.Resize += Plot_SizeChanged;
            plot.MouseWheel += hScrlBr_mouseWheel;
            
            Splitter splitter = new Splitter();
            pCharts.Controls.Add( splitter );
            splitter.Dock = DockStyle.Top;
            splitter.Height = 5;
            splitter.BringToFront();
            
        }
        
        private void RefreshPlots() {
            pCharts.SuspendLayout();
            
            foreach (Control control in pCharts.Controls) {
                if ( control.GetType() != typeof(VisBox.Plot) ) { continue; }
                control.SuspendLayout();
            }
            
            foreach (Control control in pCharts.Controls) {
                if ( control.GetType() != typeof(VisBox.Plot) ) { continue; }
                VisBox.Plot plot = control as VisBox.Plot;
                try {
                    plot.Draw();
                } catch {}
            }
            
            foreach (Control control in pCharts.Controls) {
                if ( control.GetType() != typeof(VisBox.Plot) ) { continue; }
                control.ResumeLayout();
            }
            
            pCharts.ResumeLayout();
        }
        
        void BtnRefreshClick ( object sender, EventArgs e ) {
            WhenCheckedChanged();
        }
        
        void PChartsSizeChanged ( object sender, EventArgs e ) {
            RefreshPlots();
        }
        
        void Plot_SizeChanged ( object sender, EventArgs e ) {
            if ( sender.GetType() != typeof( VisBox.Plot ) ) { return; }
            try {
                VisBox.Plot plot = sender as VisBox.Plot;
                plot.Draw();
            } catch {}
        }
    }
    
    public class NodeSeries {
        public List<float> DataX;
        public List<float> DataY;
        
        public NodeSeries( ref List<float> dataX, ref List<float> dataY ) {
            this.DataX = dataX;
            this.DataY = dataY;
        }
    }
    
}
