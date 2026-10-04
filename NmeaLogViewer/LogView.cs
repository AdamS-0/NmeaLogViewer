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
using System.Windows.Forms;

namespace NmeaLogViewer {
    /// <summary>
    /// Description of LogView.
    /// </summary>
    public partial class LogView : Form {
        List<RegexOption> _rgxs = new List<RegexOption>();
        
        VisBox.AxisLimits _axisLimitsX = new VisBox.AxisLimits();
        
        public LogView() {
            InitializeComponent();
            nudLineStart.Value = 0;
            nudLineStop.Value = 10;
        }
        
        public void BindRegexes( ref List<RegexOption> rgxs, int linesNo ) {
            _rgxs = rgxs;
            MainForm.FillTreeViewWithRegexes( ref trVwData, ref _rgxs );
            
            nudLineStart.Maximum = linesNo;
            nudLineStop.Maximum = linesNo;
            
            nudLineStart.Value = 0;
            nudLineStop.Value = linesNo;
        }
        
        void NudLineStartValueChanged ( object sender, EventArgs e ) {
            _axisLimitsX.Min = (float)(nudLineStart.Value);
            RefreshPlots();
        }
        
        void NudLineStopValueChanged ( object sender, EventArgs e ) {
            _axisLimitsX.Max = (float)(nudLineStop.Value);
            RefreshPlots();
        }
        
        void TrVwDataAfterSelect ( object sender, TreeViewEventArgs e ) {
            
        }
        
        private void TryAddDataWhenChecked( ref TreeNode node ) {
            if ( node.Nodes.Count > 0 ) {
                for ( int idx = 0; idx < node.Nodes.Count; idx++ ) {
                    TreeNode nodeChild = node.Nodes[idx];
                    TryAddDataWhenChecked( ref nodeChild );
                }
            } else {
                if ( node.Checked ) {
                    if ( node.Tag != null ) {
                        NodeSeries nodeSer = node.Tag as NodeSeries;
                        AddNewPlot( ref nodeSer.DataX, ref nodeSer.DataY );
                    }
                }
            }
        }
        private void WhenCheckedChanged() {
            pCharts.Controls.Clear();
            
            for ( int idx = 0; idx < trVwData.Nodes.Count; idx++ ) {
                TreeNode nodeChild = trVwData.Nodes[idx];
                TryAddDataWhenChecked( ref nodeChild );
            }
            
            RefreshPlots();
        }
        
        private void AddNewPlot( ref List<float> dataX, ref List<float> dataY ) {
            VisBox.Plot plot = new VisBox.Plot();
            VisBox.Series s1 = new VisBox.Series( ref dataX, ref dataY, new VisBox.Marker(Color.Yellow, ' '), new Pen( Color.Blue ) );
            
            plot.AxisLimitsX = _axisLimitsX;
            plot.gridX.Autoscale = true;
            
            plot.gridY.ShowLables = true;
            plot.gridY.Autoscale = true;
            plot.AxisLimitsY.Autoscale = true;
            
            float fMin = dataY.Min();
            float fMax = dataY.Max();
            float deltaY = Math.Abs( fMax - fMin );
            fMin -= 0.1f*deltaY;
            fMax += 0.1f*deltaY;
            
            plot.AxisLimitsY.Min = fMin;
            plot.AxisLimitsY.Max = fMax;
            
            plot.AddSeries( ref s1 );
            plot.Dock = DockStyle.Top;
            pCharts.Controls.Add( plot );
            plot.BringToFront();
            plot.Resize += Plot_SizeChanged;
//            plot1.Draw();
        }
        
        private void RefreshPlots() {
            foreach (Control control in pCharts.Controls) {
                if ( control.GetType() != typeof(VisBox.Plot) ) { continue; }
                VisBox.Plot plot = control as VisBox.Plot;
                try {
                    plot.Draw();
                } catch {}
            }
        }
        
        void BtnRefreshClick ( object sender, EventArgs e ) {
            WhenCheckedChanged();
        }
        
        void PChartsSizeChanged ( object sender, EventArgs e ) {
            RefreshPlots();
        }
        
        void Plot_SizeChanged ( object sender, EventArgs e ) {
            
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
