namespace ChromiumBrowser
{
    partial class Browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Address = new System.Windows.Forms.ToolStripTextBox();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BrowserTabs = new System.Windows.Forms.TabControl();
            this.panel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.toggleBg = new System.Windows.Forms.RadioButton();
            this.txtUpDownBlue = new System.Windows.Forms.NumericUpDown();
            this.txtUpDownGreen = new System.Windows.Forms.NumericUpDown();
            this.txtUpDownRed = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.borderBlueUpDown = new System.Windows.Forms.NumericUpDown();
            this.borderGreenUpDown = new System.Windows.Forms.NumericUpDown();
            this.borderRedUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.historyBtn = new System.Windows.Forms.Button();
            this.blueUpDown = new System.Windows.Forms.NumericUpDown();
            this.greenUpDown = new System.Windows.Forms.NumericUpDown();
            this.redUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.ToolStrip.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpDownBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpDownGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpDownRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderBlueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderGreenUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderRedUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.BackColor = System.Drawing.Color.White;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton3,
            this.toolStripButton2,
            this.toolStripButton1,
            this.Address,
            this.settingsBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ToolStrip.Size = new System.Drawing.Size(800, 50);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.toolStripButton3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(40, 45);
            this.toolStripButton3.Text = "<";
            this.toolStripButton3.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.toolStripButton2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(40, 45);
            this.toolStripButton2.Text = ">";
            this.toolStripButton2.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.toolStripButton1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(38, 45);
            this.toolStripButton1.Text = "↻";
            this.toolStripButton1.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // Address
            // 
            this.Address.AutoSize = false;
            this.Address.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.Address.Margin = new System.Windows.Forms.Padding(0);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(400, 55);
            this.Address.Text = "Search";
            this.Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBarKeyDown);
            this.Address.Click += new System.EventHandler(this.Address_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.settingsBtn.AutoSize = false;
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsBtn.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.settingsBtn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.settingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("settingsBtn.Image")));
            this.settingsBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(40, 45);
            this.settingsBtn.Text = "⚙";
            this.settingsBtn.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // BrowserTabs
            // 
            this.BrowserTabs.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.BrowserTabs.AllowDrop = true;
            this.BrowserTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserTabs.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.BrowserTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.BrowserTabs.Location = new System.Drawing.Point(0, 50);
            this.BrowserTabs.Name = "BrowserTabs";
            this.BrowserTabs.SelectedIndex = 0;
            this.BrowserTabs.Size = new System.Drawing.Size(800, 1408);
            this.BrowserTabs.TabIndex = 2;
            this.BrowserTabs.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl_DrawItem);
            this.BrowserTabs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabControl_MouseDown);
            this.BrowserTabs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TabControl_MouseUp);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.button2);
            this.panel.Controls.Add(this.toggleBg);
            this.panel.Controls.Add(this.txtUpDownBlue);
            this.panel.Controls.Add(this.txtUpDownGreen);
            this.panel.Controls.Add(this.txtUpDownRed);
            this.panel.Controls.Add(this.label3);
            this.panel.Controls.Add(this.pictureBox2);
            this.panel.Controls.Add(this.borderBlueUpDown);
            this.panel.Controls.Add(this.borderGreenUpDown);
            this.panel.Controls.Add(this.borderRedUpDown);
            this.panel.Controls.Add(this.label2);
            this.panel.Controls.Add(this.pictureBox1);
            this.panel.Controls.Add(this.button1);
            this.panel.Controls.Add(this.historyBtn);
            this.panel.Controls.Add(this.blueUpDown);
            this.panel.Controls.Add(this.greenUpDown);
            this.panel.Controls.Add(this.redUpDown);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.colorBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel.Location = new System.Drawing.Point(400, 50);
            this.panel.MaximumSize = new System.Drawing.Size(400, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 1408);
            this.panel.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(10, 1038);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(378, 69);
            this.button2.TabIndex = 19;
            this.button2.Text = "Change background";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.changeBg_BtnClick);
            // 
            // toggleBg
            // 
            this.toggleBg.AutoSize = true;
            this.toggleBg.Checked = true;
            this.toggleBg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.toggleBg.Location = new System.Drawing.Point(10, 877);
            this.toggleBg.Name = "toggleBg";
            this.toggleBg.Size = new System.Drawing.Size(369, 34);
            this.toggleBg.TabIndex = 18;
            this.toggleBg.TabStop = true;
            this.toggleBg.Text = "Toggle repeating background";
            this.toggleBg.UseVisualStyleBackColor = true;
            this.toggleBg.Click += new System.EventHandler(this.ToggleRepeatingBg);
            // 
            // txtUpDownBlue
            // 
            this.txtUpDownBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtUpDownBlue.Location = new System.Drawing.Point(270, 822);
            this.txtUpDownBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtUpDownBlue.Name = "txtUpDownBlue";
            this.txtUpDownBlue.Size = new System.Drawing.Size(120, 39);
            this.txtUpDownBlue.TabIndex = 17;
            this.txtUpDownBlue.ValueChanged += new System.EventHandler(this.txtValChanged);
            // 
            // txtUpDownGreen
            // 
            this.txtUpDownGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtUpDownGreen.Location = new System.Drawing.Point(140, 822);
            this.txtUpDownGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtUpDownGreen.Name = "txtUpDownGreen";
            this.txtUpDownGreen.Size = new System.Drawing.Size(120, 39);
            this.txtUpDownGreen.TabIndex = 16;
            this.txtUpDownGreen.ValueChanged += new System.EventHandler(this.txtValChanged);
            // 
            // txtUpDownRed
            // 
            this.txtUpDownRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtUpDownRed.Location = new System.Drawing.Point(10, 822);
            this.txtUpDownRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.txtUpDownRed.Name = "txtUpDownRed";
            this.txtUpDownRed.Size = new System.Drawing.Size(120, 39);
            this.txtUpDownRed.TabIndex = 15;
            this.txtUpDownRed.ValueChanged += new System.EventHandler(this.txtValChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(4, 596);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 36);
            this.label3.TabIndex = 14;
            this.label3.Text = "Text color";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(10, 634);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(380, 165);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // borderBlueUpDown
            // 
            this.borderBlueUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.borderBlueUpDown.Location = new System.Drawing.Point(270, 542);
            this.borderBlueUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.borderBlueUpDown.Name = "borderBlueUpDown";
            this.borderBlueUpDown.Size = new System.Drawing.Size(120, 39);
            this.borderBlueUpDown.TabIndex = 12;
            this.borderBlueUpDown.ValueChanged += new System.EventHandler(this.borderValChanged);
            // 
            // borderGreenUpDown
            // 
            this.borderGreenUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.borderGreenUpDown.Location = new System.Drawing.Point(140, 542);
            this.borderGreenUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.borderGreenUpDown.Name = "borderGreenUpDown";
            this.borderGreenUpDown.Size = new System.Drawing.Size(120, 39);
            this.borderGreenUpDown.TabIndex = 11;
            this.borderGreenUpDown.ValueChanged += new System.EventHandler(this.borderValChanged);
            // 
            // borderRedUpDown
            // 
            this.borderRedUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.borderRedUpDown.Location = new System.Drawing.Point(10, 542);
            this.borderRedUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.borderRedUpDown.Name = "borderRedUpDown";
            this.borderRedUpDown.Size = new System.Drawing.Size(120, 39);
            this.borderRedUpDown.TabIndex = 10;
            this.borderRedUpDown.ValueChanged += new System.EventHandler(this.borderValChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(4, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 36);
            this.label2.TabIndex = 9;
            this.label2.Text = "Border color";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(10, 354);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 165);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.Location = new System.Drawing.Point(10, 966);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(378, 65);
            this.button1.TabIndex = 7;
            this.button1.Text = "Incognito";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // historyBtn
            // 
            this.historyBtn.Location = new System.Drawing.Point(10, 919);
            this.historyBtn.Name = "historyBtn";
            this.historyBtn.Size = new System.Drawing.Size(378, 43);
            this.historyBtn.TabIndex = 5;
            this.historyBtn.Text = "History";
            this.historyBtn.UseVisualStyleBackColor = true;
            this.historyBtn.Click += new System.EventHandler(this.historyBtn_Click);
            // 
            // blueUpDown
            // 
            this.blueUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.blueUpDown.Location = new System.Drawing.Point(270, 254);
            this.blueUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.blueUpDown.Name = "blueUpDown";
            this.blueUpDown.Size = new System.Drawing.Size(120, 39);
            this.blueUpDown.TabIndex = 4;
            this.blueUpDown.ValueChanged += new System.EventHandler(this.backGroundNumericChange);
            // 
            // greenUpDown
            // 
            this.greenUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.greenUpDown.Location = new System.Drawing.Point(140, 254);
            this.greenUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.greenUpDown.Name = "greenUpDown";
            this.greenUpDown.Size = new System.Drawing.Size(120, 39);
            this.greenUpDown.TabIndex = 3;
            this.greenUpDown.ValueChanged += new System.EventHandler(this.backGroundNumericChange);
            // 
            // redUpDown
            // 
            this.redUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.redUpDown.Location = new System.Drawing.Point(10, 254);
            this.redUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.redUpDown.Name = "redUpDown";
            this.redUpDown.Size = new System.Drawing.Size(120, 39);
            this.redUpDown.TabIndex = 2;
            this.redUpDown.ValueChanged += new System.EventHandler(this.backGroundNumericChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(4, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Background color";
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.White;
            this.colorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorBox.Location = new System.Drawing.Point(10, 66);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(380, 165);
            this.colorBox.TabIndex = 0;
            this.colorBox.TabStop = false;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1463);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.BrowserTabs);
            this.Controls.Add(this.ToolStrip);
            this.DoubleBuffered = true;
            this.Name = "Browser";
            this.Text = "Browser";
            this.Resize += new System.EventHandler(this.BrowserResize);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpDownBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpDownGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUpDownRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderBlueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderGreenUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borderRedUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripTextBox Address;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl BrowserTabs;
        private System.Windows.Forms.Panel panel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button historyBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.NumericUpDown txtUpDownBlue;
        private System.Windows.Forms.NumericUpDown txtUpDownGreen;
        private System.Windows.Forms.NumericUpDown txtUpDownRed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown borderBlueUpDown;
        private System.Windows.Forms.NumericUpDown borderGreenUpDown;
        private System.Windows.Forms.NumericUpDown borderRedUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown blueUpDown;
        private System.Windows.Forms.NumericUpDown greenUpDown;
        private System.Windows.Forms.NumericUpDown redUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.RadioButton toggleBg;
        private System.Windows.Forms.Button button2;
    }
}
