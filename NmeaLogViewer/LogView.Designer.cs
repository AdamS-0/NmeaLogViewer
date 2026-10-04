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
        private System.Windows.Forms.HScrollBar hjScrlBrView;
        private System.Windows.Forms.NumericUpDown nudLineStop;
        private System.Windows.Forms.Label lblLogStop;
        private System.Windows.Forms.Label lblLogStart;
        private System.Windows.Forms.NumericUpDown nudLineStart;
        private System.Windows.Forms.TreeView trVwData;
        private System.Windows.Forms.Panel pCharts;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("$GPGGA");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("$GPTXT");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("$GPGLL");
            this.grpBxDataSelector = new System.Windows.Forms.GroupBox();
            this.trVwData = new System.Windows.Forms.TreeView();
            this.grpBxOptions = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.nudLineStop = new System.Windows.Forms.NumericUpDown();
            this.lblLogStop = new System.Windows.Forms.Label();
            this.lblLogStart = new System.Windows.Forms.Label();
            this.nudLineStart = new System.Windows.Forms.NumericUpDown();
            this.hjScrlBrView = new System.Windows.Forms.HScrollBar();
            this.grpBxCharts = new System.Windows.Forms.GroupBox();
            this.pCharts = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpBxDataSelector.SuspendLayout();
            this.grpBxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineStop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineStart)).BeginInit();
            this.grpBxCharts.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            treeNode1.Name = "Node0";
            treeNode1.Text = "$GPGGA";
            treeNode2.Name = "Node1";
            treeNode2.Text = "$GPTXT";
            treeNode3.Name = "Node2";
            treeNode3.Text = "$GPGLL";
            this.trVwData.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.trVwData.Size = new System.Drawing.Size(104, 336);
            this.trVwData.TabIndex = 0;
            this.trVwData.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrVwDataAfterSelect);
            // 
            // grpBxOptions
            // 
            this.grpBxOptions.Controls.Add(this.hjScrlBrView);
            this.grpBxOptions.Controls.Add(this.panel3);
            this.grpBxOptions.Controls.Add(this.panel2);
            this.grpBxOptions.Controls.Add(this.panel1);
            this.grpBxOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBxOptions.Location = new System.Drawing.Point(113, 295);
            this.grpBxOptions.Name = "grpBxOptions";
            this.grpBxOptions.Size = new System.Drawing.Size(468, 63);
            this.grpBxOptions.TabIndex = 1;
            this.grpBxOptions.TabStop = false;
            this.grpBxOptions.Text = "Options";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(3, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefreshClick);
            // 
            // nudLineStop
            // 
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
            // lblLogStop
            // 
            this.lblLogStop.Location = new System.Drawing.Point(0, -3);
            this.lblLogStop.Name = "lblLogStop";
            this.lblLogStop.Size = new System.Drawing.Size(65, 23);
            this.lblLogStop.TabIndex = 3;
            this.lblLogStop.Text = "Stop line:";
            this.lblLogStop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLogStart
            // 
            this.lblLogStart.Location = new System.Drawing.Point(0, -3);
            this.lblLogStart.Name = "lblLogStart";
            this.lblLogStart.Size = new System.Drawing.Size(65, 23);
            this.lblLogStart.TabIndex = 2;
            this.lblLogStart.Text = "Start line:";
            this.lblLogStart.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudLineStart
            // 
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
            // hjScrlBrView
            // 
            this.hjScrlBrView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hjScrlBrView.Location = new System.Drawing.Point(71, 39);
            this.hjScrlBrView.Name = "hjScrlBrView";
            this.hjScrlBrView.Size = new System.Drawing.Size(326, 21);
            this.hjScrlBrView.TabIndex = 0;
            // 
            // grpBxCharts
            // 
            this.grpBxCharts.Controls.Add(this.pCharts);
            this.grpBxCharts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBxCharts.Location = new System.Drawing.Point(113, 3);
            this.grpBxCharts.Name = "grpBxCharts";
            this.grpBxCharts.Size = new System.Drawing.Size(468, 292);
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
            this.pCharts.Size = new System.Drawing.Size(462, 273);
            this.pCharts.TabIndex = 0;
            this.pCharts.SizeChanged += new System.EventHandler(this.PChartsSizeChanged);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.lblLogStop);
            this.panel2.Controls.Add(this.nudLineStop);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(397, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(68, 44);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(71, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(326, 23);
            this.panel3.TabIndex = 8;
            // 
            // LogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.grpBxCharts);
            this.Controls.Add(this.grpBxOptions);
            this.Controls.Add(this.grpBxDataSelector);
            this.Name = "LogView";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "LogView";
            this.grpBxDataSelector.ResumeLayout(false);
            this.grpBxOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLineStop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineStart)).EndInit();
            this.grpBxCharts.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
