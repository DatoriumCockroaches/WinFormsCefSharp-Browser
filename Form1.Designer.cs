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
            this.Address = new System.Windows.Forms.ToolStripTextBox();
            this.AddBrowserTab = new System.Windows.Forms.ToolStripButton();
            this.removeBrowserTab = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BrowserTabs = new System.Windows.Forms.TabControl();
            this.panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.advancedSettings = new System.Windows.Forms.Button();
            this.historyBtn = new System.Windows.Forms.Button();
            this.blueUpDown = new System.Windows.Forms.NumericUpDown();
            this.greenUpDown = new System.Windows.Forms.NumericUpDown();
            this.redUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.changeBGG = new System.Windows.Forms.Button();
            this.ToolStrip.SuspendLayout();
            this.panel.SuspendLayout();
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
            this.AddBrowserTab,
            this.removeBrowserTab,
            this.settingsBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ToolStrip.Size = new System.Drawing.Size(800, 55);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // Address
            // 
            this.Address.AutoSize = false;
            this.Address.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.Address.Margin = new System.Windows.Forms.Padding(0);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(400, 50);
            this.Address.Text = "Search";
            this.Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBarKeyDown);
            this.Address.Click += new System.EventHandler(this.Address_Click);
            // 
            // AddBrowserTab
            // 
            this.AddBrowserTab.AutoSize = false;
            this.AddBrowserTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddBrowserTab.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.AddBrowserTab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddBrowserTab.Image = ((System.Drawing.Image)(resources.GetObject("AddBrowserTab.Image")));
            this.AddBrowserTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddBrowserTab.Name = "AddBrowserTab";
            this.AddBrowserTab.Size = new System.Drawing.Size(40, 45);
            this.AddBrowserTab.Text = "+";
            this.AddBrowserTab.Click += new System.EventHandler(this.AddBrowserTab_Click);
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
            this.BrowserTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.BrowserTabs.Location = new System.Drawing.Point(0, 55);
            this.BrowserTabs.Name = "BrowserTabs";
            this.BrowserTabs.SelectedIndex = 0;
            this.BrowserTabs.Size = new System.Drawing.Size(800, 1408);
            this.BrowserTabs.TabIndex = 2;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.changeBGG);
            this.panel.Controls.Add(this.radioButton1);
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
            this.panel.Controls.Add(this.advancedSettings);
            this.panel.Controls.Add(this.historyBtn);
            this.panel.Controls.Add(this.blueUpDown);
            this.panel.Controls.Add(this.greenUpDown);
            this.panel.Controls.Add(this.redUpDown);
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.colorBox);
            this.panel.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel.Location = new System.Drawing.Point(400, 55);
            this.panel.MaximumSize = new System.Drawing.Size(400, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(400, 1408);
            this.panel.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button1.Location = new System.Drawing.Point(10, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(378, 65);
            this.button1.TabIndex = 7;
            this.button1.Text = "Incognito";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // advancedSettings
            // 
            this.advancedSettings.Location = new System.Drawing.Point(10, 440);
            this.advancedSettings.Name = "advancedSettings";
            this.advancedSettings.Size = new System.Drawing.Size(380, 54);
            this.advancedSettings.TabIndex = 6;
            this.advancedSettings.Text = "Advanced settings";
            this.advancedSettings.UseVisualStyleBackColor = true;
            this.advancedSettings.Click += new System.EventHandler(this.advancedSettings_Click);
            // 
            // historyBtn
            // 
            this.historyBtn.Location = new System.Drawing.Point(10, 322);
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
            this.blueUpDown.ValueChanged += new System.EventHandler(this.blueUpDown_ValueChanged);
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
            this.greenUpDown.ValueChanged += new System.EventHandler(this.greenUpDown_ValueChanged);
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
            this.redUpDown.ValueChanged += new System.EventHandler(this.redUpDown_ValueChanged);
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
            this.colorBox.Location = new System.Drawing.Point(10, 66);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(380, 165);
            this.colorBox.TabIndex = 0;
            this.colorBox.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.radioButton1.Location = new System.Drawing.Point(10, 877);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(326, 36);
            this.radioButton1.TabIndex = 18;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Repeating background";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.ToggleRepeatingBg);
            // 
            // changeBGG
            // 
            this.changeBGG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.changeBGG.Location = new System.Drawing.Point(10, 1038);
            this.changeBGG.Name = "changeBGG";
            this.changeBGG.Size = new System.Drawing.Size(378, 65);
            this.changeBGG.TabIndex = 19;
            this.changeBGG.Text = "Change background";
            this.changeBGG.UseVisualStyleBackColor = true;
            this.changeBGG.Click += new System.EventHandler(this.changeBg_BtnClick);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 749);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.BrowserTabs);
            this.Controls.Add(this.ToolStrip);
            this.Name = "Browser";
            this.Text = "Browser";
            this.Resize += new System.EventHandler(this.BrowserResize);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton AddBrowserTab;
        private System.Windows.Forms.TabControl BrowserTabs;
        private System.Windows.Forms.ToolStripButton removeBrowserTab;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown blueUpDown;
        private System.Windows.Forms.NumericUpDown greenUpDown;
        private System.Windows.Forms.NumericUpDown redUpDown;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button historyBtn;
        private System.Windows.Forms.Button advancedSettings;
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
        private System.Windows.Forms.RadioButton toggleRepeat;
        private System.Windows.Forms.Button changeBGG;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}

