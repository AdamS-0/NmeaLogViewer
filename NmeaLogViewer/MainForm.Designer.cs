/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 03.10.2026
 * Time: 08:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace NmeaLogViewer
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox grpBxInput;
        private System.Windows.Forms.GroupBox grpBxStats;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBxLogFilename;
        private System.Windows.Forms.Label lblLogfile;
        private System.Windows.Forms.Button btnNewView;
        private System.Windows.Forms.Button btnLoadlog;
        private System.Windows.Forms.GroupBox grpBxRgxs;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox grpBxDataSelector;
        private System.Windows.Forms.TreeView trVwData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.RichTextBox rtbRegexes;
        private System.Windows.Forms.Button btnParseLog;
        private System.Windows.Forms.ProgressBar prgBr1;
        private System.Windows.Forms.RichTextBox rtbStatus;
        private System.Windows.Forms.ToolTip toolTip1;
        
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grpBxInput = new System.Windows.Forms.GroupBox();
            this.btnNewView = new System.Windows.Forms.Button();
            this.btnParseLog = new System.Windows.Forms.Button();
            this.btnLoadlog = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBxLogFilename = new System.Windows.Forms.TextBox();
            this.lblLogfile = new System.Windows.Forms.Label();
            this.grpBxStats = new System.Windows.Forms.GroupBox();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.prgBr1 = new System.Windows.Forms.ProgressBar();
            this.grpBxRgxs = new System.Windows.Forms.GroupBox();
            this.rtbRegexes = new System.Windows.Forms.RichTextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.grpBxDataSelector = new System.Windows.Forms.GroupBox();
            this.trVwData = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpBxInput.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpBxStats.SuspendLayout();
            this.grpBxRgxs.SuspendLayout();
            this.grpBxDataSelector.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxInput
            // 
            this.grpBxInput.Controls.Add(this.btnNewView);
            this.grpBxInput.Controls.Add(this.btnParseLog);
            this.grpBxInput.Controls.Add(this.btnLoadlog);
            this.grpBxInput.Controls.Add(this.panel1);
            this.grpBxInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBxInput.Location = new System.Drawing.Point(3, 3);
            this.grpBxInput.Name = "grpBxInput";
            this.grpBxInput.Size = new System.Drawing.Size(378, 69);
            this.grpBxInput.TabIndex = 0;
            this.grpBxInput.TabStop = false;
            this.grpBxInput.Text = "Log";
            // 
            // btnNewView
            // 
            this.btnNewView.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNewView.Location = new System.Drawing.Point(153, 41);
            this.btnNewView.Name = "btnNewView";
            this.btnNewView.Size = new System.Drawing.Size(75, 25);
            this.btnNewView.TabIndex = 2;
            this.btnNewView.Text = "New view";
            this.toolTip1.SetToolTip(this.btnNewView, "Open new LogView with decoded by regexes datasets");
            this.btnNewView.UseVisualStyleBackColor = true;
            this.btnNewView.Click += new System.EventHandler(this.BtnNewViewClick);
            // 
            // btnParseLog
            // 
            this.btnParseLog.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnParseLog.Location = new System.Drawing.Point(78, 41);
            this.btnParseLog.Name = "btnParseLog";
            this.btnParseLog.Size = new System.Drawing.Size(75, 25);
            this.btnParseLog.TabIndex = 3;
            this.btnParseLog.Text = "Parse log";
            this.toolTip1.SetToolTip(this.btnParseLog, "Process previously Loaded log file.\r\nWill use list of regexes");
            this.btnParseLog.UseVisualStyleBackColor = true;
            this.btnParseLog.Click += new System.EventHandler(this.BtnParseLogClick);
            // 
            // btnLoadlog
            // 
            this.btnLoadlog.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoadlog.Location = new System.Drawing.Point(3, 41);
            this.btnLoadlog.Name = "btnLoadlog";
            this.btnLoadlog.Size = new System.Drawing.Size(75, 25);
            this.btnLoadlog.TabIndex = 1;
            this.btnLoadlog.Text = "Load log";
            this.toolTip1.SetToolTip(this.btnLoadlog, "Load log file and get only correct NMEA messages. Just a first step");
            this.btnLoadlog.UseVisualStyleBackColor = true;
            this.btnLoadlog.Click += new System.EventHandler(this.BtnLoadlogClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBxLogFilename);
            this.panel1.Controls.Add(this.lblLogfile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(372, 25);
            this.panel1.TabIndex = 0;
            // 
            // txtBxLogFilename
            // 
            this.txtBxLogFilename.AllowDrop = true;
            this.txtBxLogFilename.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBxLogFilename.Location = new System.Drawing.Point(47, 3);
            this.txtBxLogFilename.Name = "txtBxLogFilename";
            this.txtBxLogFilename.Size = new System.Drawing.Size(322, 20);
            this.txtBxLogFilename.TabIndex = 1;
            this.toolTip1.SetToolTip(this.txtBxLogFilename, "Path to a log file; drag&drop enabled");
            this.txtBxLogFilename.DragDrop += new System.Windows.Forms.DragEventHandler(this.TxtBxLogFilenameDragDrop);
            this.txtBxLogFilename.DragEnter += new System.Windows.Forms.DragEventHandler(this.TxtBxLogFilenameDragEnter);
            // 
            // lblLogfile
            // 
            this.lblLogfile.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLogfile.Location = new System.Drawing.Point(3, 3);
            this.lblLogfile.Name = "lblLogfile";
            this.lblLogfile.Size = new System.Drawing.Size(44, 19);
            this.lblLogfile.TabIndex = 0;
            this.lblLogfile.Text = "Log file:";
            this.lblLogfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBxStats
            // 
            this.grpBxStats.Controls.Add(this.rtbStatus);
            this.grpBxStats.Controls.Add(this.prgBr1);
            this.grpBxStats.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBxStats.Location = new System.Drawing.Point(3, 264);
            this.grpBxStats.Name = "grpBxStats";
            this.grpBxStats.Size = new System.Drawing.Size(378, 162);
            this.grpBxStats.TabIndex = 1;
            this.grpBxStats.TabStop = false;
            this.grpBxStats.Text = "Status";
            // 
            // rtbStatus
            // 
            this.rtbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.rtbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbStatus.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbStatus.Location = new System.Drawing.Point(3, 39);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.Size = new System.Drawing.Size(372, 120);
            this.rtbStatus.TabIndex = 2;
            this.rtbStatus.Text = "";
            // 
            // prgBr1
            // 
            this.prgBr1.Dock = System.Windows.Forms.DockStyle.Top;
            this.prgBr1.Location = new System.Drawing.Point(3, 16);
            this.prgBr1.Name = "prgBr1";
            this.prgBr1.Size = new System.Drawing.Size(372, 23);
            this.prgBr1.TabIndex = 1;
            // 
            // grpBxRgxs
            // 
            this.grpBxRgxs.Controls.Add(this.rtbRegexes);
            this.grpBxRgxs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBxRgxs.Location = new System.Drawing.Point(136, 0);
            this.grpBxRgxs.Name = "grpBxRgxs";
            this.grpBxRgxs.Size = new System.Drawing.Size(242, 189);
            this.grpBxRgxs.TabIndex = 2;
            this.grpBxRgxs.TabStop = false;
            this.grpBxRgxs.Text = "Regexes";
            // 
            // rtbRegexes
            // 
            this.rtbRegexes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRegexes.Location = new System.Drawing.Point(3, 16);
            this.rtbRegexes.Name = "rtbRegexes";
            this.rtbRegexes.Size = new System.Drawing.Size(236, 170);
            this.rtbRegexes.TabIndex = 0;
            this.rtbRegexes.Text = "$GPGGA<=\\$GPGGA,(?<Utc>.*?),(?<Lat>.*?),N,(?<Lon>.*?),E,(?<Fix>.*?),(?<Sat>.*?),(" +
    "?<Dop>.*?),(?<Height>.*?),M,(?<Geo>.*?),.*?\\*\n";
            this.toolTip1.SetToolTip(this.rtbRegexes, resources.GetString("rtbRegexes.ToolTip"));
            this.rtbRegexes.TextChanged += new System.EventHandler(this.RtbRegexesTextChanged);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 261);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(378, 3);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // grpBxDataSelector
            // 
            this.grpBxDataSelector.Controls.Add(this.trVwData);
            this.grpBxDataSelector.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpBxDataSelector.Location = new System.Drawing.Point(0, 0);
            this.grpBxDataSelector.Name = "grpBxDataSelector";
            this.grpBxDataSelector.Size = new System.Drawing.Size(133, 189);
            this.grpBxDataSelector.TabIndex = 4;
            this.grpBxDataSelector.TabStop = false;
            this.grpBxDataSelector.Text = "Preview";
            // 
            // trVwData
            // 
            this.trVwData.CheckBoxes = true;
            this.trVwData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trVwData.Location = new System.Drawing.Point(3, 16);
            this.trVwData.Name = "trVwData";
            this.trVwData.Size = new System.Drawing.Size(127, 170);
            this.trVwData.TabIndex = 0;
            this.toolTip1.SetToolTip(this.trVwData, "Just a preview of correctly detected regexes, with fields");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpBxRgxs);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Controls.Add(this.grpBxDataSelector);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(378, 189);
            this.panel2.TabIndex = 5;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(133, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 189);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 429);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grpBxStats);
            this.Controls.Add(this.grpBxInput);
            this.Icon = global::NmeaLogViewer.Resource1.icon1;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "NmeaLogViewer";
            this.grpBxInput.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.grpBxStats.ResumeLayout(false);
            this.grpBxRgxs.ResumeLayout(false);
            this.grpBxDataSelector.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
