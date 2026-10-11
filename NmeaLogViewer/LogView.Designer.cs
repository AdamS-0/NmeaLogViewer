/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 03.10.2026
 * Time: 18:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NmeaLogViewer
{
    partial class LogView
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpBxDataSelector;
        private System.Windows.Forms.GroupBox grpBxOptions;
        private System.Windows.Forms.GroupBox grpBxCharts;
        private System.Windows.Forms.HScrollBar hScrlBrView;
        private System.Windows.Forms.NumericUpDown nudLineStop;
        private System.Windows.Forms.Label lblLogStop;
        private System.Windows.Forms.Label lblLogStart;
        private System.Windows.Forms.NumericUpDown nudLineStart;
        private System.Windows.Forms.TreeView trVwData;
        private System.Windows.Forms.Panel pCharts;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBxDataSelector = new System.Windows.Forms.GroupBox();
            this.trVwData = new System.Windows.Forms.TreeView();
            this.grpBxOptions = new System.Windows.Forms.GroupBox();
            this.hScrlBrView = new System.Windows.Forms.HScrollBar();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnReload = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLogStop = new System.Windows.Forms.Label();
            this.nudLineStop = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLogStart = new System.Windows.Forms.Label();
            this.nudLineStart = new System.Windows.Forms.NumericUpDown();
            this.grpBxCharts = new System.Windows.Forms.GroupBox();
            this.pCharts = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grpBxDataSelector.SuspendLayout();
            this.grpBxOptions.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineStop)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineStart)).BeginInit();
            this.grpBxCharts.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxDataSelector
            // 
            this.grpBxDataSelector.Controls.Add(this.trVwData);
            this.grpBxDataSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpBxDataSelector.Location = new System.Drawing.Point(3, 3);
            this.grpBxDataSelector.Name = "grpBxDataSelector";
            this.grpBxDataSelector.Size = new System.Drawing.Size(110, 355);
            this.grpBxDataSelector.TabIndex = 0;
            this.grpBxDataSelector.TabStop = false;
            this.grpBxDataSelector.Text = "Data Selector";
            // 
            // trVwData
            // 
            this.trVwData.CheckBoxes = true;
            this.trVwData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trVwData.Location = new System.Drawing.Point(3, 16);
            this.trVwData.Name = "trVwData";
            this.trVwData.Size = new System.Drawing.Size(104, 336);
            this.trVwData.TabIndex = 0;
            this.trVwData.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.TrVwDataAfterCheck);
            this.trVwData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrVwDataAfterSelect);
            // 
            // grpBxOptions
            // 
            this.grpBxOptions.Controls.Add(this.hScrlBrView);
            this.grpBxOptions.Controls.Add(this.panel3);
            this.grpBxOptions.Controls.Add(this.panel2);
            this.grpBxOptions.Controls.Add(this.panel1);
            this.grpBxOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBxOptions.Location = new System.Drawing.Point(116, 295);
            this.grpBxOptions.Name = "grpBxOptions";
            this.grpBxOptions.Size = new System.Drawing.Size(465, 63);
            this.grpBxOptions.TabIndex = 1;
            this.grpBxOptions.TabStop = false;
            this.grpBxOptions.Text = "Options";
            // 
            // hScrlBrView
            // 
            this.hScrlBrView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrlBrView.Location = new System.Drawing.Point(71, 39);
            this.hScrlBrView.Name = "hScrlBrView";
            this.hScrlBrView.Size = new System.Drawing.Size(323, 21);
            this.hScrlBrView.TabIndex = 0;
            this.hScrlBrView.ValueChanged += new System.EventHandler(this.HScrlBrViewValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnReload);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(71, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(323, 23);
            this.panel3.TabIndex = 8;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(3, 0);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLogStop);
            this.panel2.Controls.Add(this.nudLineStop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(394, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(68, 44);
            this.panel2.TabIndex = 7;
            // 
            // lblLogStop
            // 
            this.lblLogStop.Location = new System.Drawing.Point(0, 0);
            this.lblLogStop.Name = "lblLogStop";
            this.lblLogStop.Size = new System.Drawing.Size(65, 23);
            this.lblLogStop.TabIndex = 3;
            this.lblLogStop.Text = "Stop line:";
            this.lblLogStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudLineStop
            // 
            this.nudLineStop.Enabled = false;
            this.nudLineStop.Location = new System.Drawing.Point(0, 23);
            this.nudLineStop.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudLineStop.Name = "nudLineStop";
            this.nudLineStop.Size = new System.Drawing.Size(65, 20);
            this.nudLineStop.TabIndex = 4;
            this.nudLineStop.Value = new decimal(new int[] {
            1234567,
            0,
            0,
            0});
            this.nudLineStop.ValueChanged += new System.EventHandler(this.NudLineStopValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLogStart);
            this.panel1.Controls.Add(this.nudLineStart);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(68, 44);
            this.panel1.TabIndex = 6;
            // 
            // lblLogStart
            // 
            this.lblLogStart.Location = new System.Drawing.Point(0, 0);
            this.lblLogStart.Name = "lblLogStart";
            this.lblLogStart.Size = new System.Drawing.Size(65, 23);
            this.lblLogStart.TabIndex = 2;
            this.lblLogStart.Text = "Start line:";
            this.lblLogStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudLineStart
            // 
            this.nudLineStart.Enabled = false;
            this.nudLineStart.Location = new System.Drawing.Point(0, 23);
            this.nudLineStart.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudLineStart.Name = "nudLineStart";
            this.nudLineStart.Size = new System.Drawing.Size(65, 20);
            this.nudLineStart.TabIndex = 1;
            this.nudLineStart.Value = new decimal(new int[] {
            1234567,
            0,
            0,
            0});
            this.nudLineStart.ValueChanged += new System.EventHandler(this.NudLineStartValueChanged);
            // 
            // grpBxCharts
            // 
            this.grpBxCharts.Controls.Add(this.pCharts);
            this.grpBxCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBxCharts.Location = new System.Drawing.Point(116, 3);
            this.grpBxCharts.Name = "grpBxCharts";
            this.grpBxCharts.Size = new System.Drawing.Size(465, 292);
            this.grpBxCharts.TabIndex = 2;
            this.grpBxCharts.TabStop = false;
            this.grpBxCharts.Text = "Chart";
            // 
            // pCharts
            // 
            this.pCharts.AutoScroll = true;
            this.pCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pCharts.Location = new System.Drawing.Point(3, 16);
            this.pCharts.Name = "pCharts";
            this.pCharts.Size = new System.Drawing.Size(459, 273);
            this.pCharts.TabIndex = 0;
            this.pCharts.SizeChanged += new System.EventHandler(this.PChartsSizeChanged);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(113, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 355);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.grpBxCharts);
            this.Controls.Add(this.grpBxOptions);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grpBxDataSelector);
            this.Icon = global::NmeaLogViewer.Resource1.icon1;
            this.Name = "LogView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "LogView";
            this.grpBxDataSelector.ResumeLayout(false);
            this.grpBxOptions.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLineStop)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLineStart)).EndInit();
            this.grpBxCharts.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
