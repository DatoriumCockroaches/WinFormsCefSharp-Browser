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
            this.Back = new System.Windows.Forms.ToolStripButton();
            this.Forward = new System.Windows.Forms.ToolStripButton();
            this.reloadButton = new System.Windows.Forms.ToolStripButton();
            this.Address = new System.Windows.Forms.ToolStripTextBox();
            this.AddBrowserTab = new System.Windows.Forms.ToolStripButton();
            this.removeBrowserTab = new System.Windows.Forms.ToolStripButton();
            this.settingsBtn = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BrowserTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.Label();
            this.numericBlue = new System.Windows.Forms.NumericUpDown();
            this.numericGreen = new System.Windows.Forms.NumericUpDown();
            this.numericRed = new System.Windows.Forms.NumericUpDown();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.ToolStrip.SuspendLayout();
            this.BrowserTabs.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.White;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Back,
            this.Forward,
            this.reloadButton,
            this.Address,
            this.AddBrowserTab,
            this.removeBrowserTab,
            this.settingsBtn});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.ToolStrip.Size = new System.Drawing.Size(800, 65);
            this.ToolStrip.TabIndex = 1;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // Back
            // 
            this.Back.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Back.Image = global::ChromiumBrowser.Properties.Resources.backButton;
            this.Back.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(34, 60);
            this.Back.Text = "Back";
            this.Back.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Forward
            // 
            this.Forward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Forward.Image = global::ChromiumBrowser.Properties.Resources.forwardButton;
            this.Forward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Forward.Margin = new System.Windows.Forms.Padding(10, 2, 0, 3);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(34, 60);
            this.Forward.Text = "Forward";
            this.Forward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // reloadButton
            // 
            this.reloadButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.reloadButton.Image = global::ChromiumBrowser.Properties.Resources.refresh;
            this.reloadButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.reloadButton.Name = "reloadButton";
            this.reloadButton.Size = new System.Drawing.Size(34, 60);
            this.reloadButton.Text = "toolStripButton1";
            this.reloadButton.Click += new System.EventHandler(this.reloadButton_Click);
            // 
            // Address
            // 
            this.Address.AutoSize = false;
            this.Address.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.Address.Margin = new System.Windows.Forms.Padding(0);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(400, 55);
            this.Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SearchBarKeyDown);
            // 
            // AddBrowserTab
            // 
            this.AddBrowserTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddBrowserTab.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.AddBrowserTab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AddBrowserTab.Image = ((System.Drawing.Image)(resources.GetObject("AddBrowserTab.Image")));
            this.AddBrowserTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddBrowserTab.Name = "AddBrowserTab";
            this.AddBrowserTab.Size = new System.Drawing.Size(47, 60);
            this.AddBrowserTab.Text = "+";
            this.AddBrowserTab.Click += new System.EventHandler(this.AddBrowserTab_Click);
            // 
            // removeBrowserTab
            // 
            this.removeBrowserTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeBrowserTab.Font = new System.Drawing.Font("Segoe UI", 17F);
            this.removeBrowserTab.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.removeBrowserTab.Image = ((System.Drawing.Image)(resources.GetObject("removeBrowserTab.Image")));
            this.removeBrowserTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeBrowserTab.Name = "removeBrowserTab";
            this.removeBrowserTab.Size = new System.Drawing.Size(38, 60);
            this.removeBrowserTab.Text = "-";
            this.removeBrowserTab.Click += new System.EventHandler(this.removeBrowserTab_Click);
            // 
            // settingsBtn
            // 
            this.settingsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.settingsBtn.Image = global::ChromiumBrowser.Properties.Resources.settings;
            this.settingsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Size = new System.Drawing.Size(34, 60);
            this.settingsBtn.Text = "toolStripButton1";
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
            this.BrowserTabs.Controls.Add(this.tabPage1);
            this.BrowserTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserTabs.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.BrowserTabs.Location = new System.Drawing.Point(0, 65);
            this.BrowserTabs.Name = "BrowserTabs";
            this.BrowserTabs.SelectedIndex = 0;
            this.BrowserTabs.Size = new System.Drawing.Size(800, 1126);
            this.BrowserTabs.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 48);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 1074);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "New Tab";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.numericBlue);
            this.panel1.Controls.Add(this.numericGreen);
            this.panel1.Controls.Add(this.numericRed);
            this.panel1.Controls.Add(this.colorBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(400, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 1126);
            this.panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.textBox1.Location = new System.Drawing.Point(10, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(268, 37);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Background color";
            // 
            // numericBlue
            // 
            this.numericBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.numericBlue.Location = new System.Drawing.Point(268, 188);
            this.numericBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericBlue.Name = "numericBlue";
            this.numericBlue.Size = new System.Drawing.Size(120, 41);
            this.numericBlue.TabIndex = 3;
            this.numericBlue.ValueChanged += new System.EventHandler(this.numericBlue_ValueChanged);
            // 
            // numericGreen
            // 
            this.numericGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.numericGreen.Location = new System.Drawing.Point(143, 188);
            this.numericGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericGreen.Name = "numericGreen";
            this.numericGreen.Size = new System.Drawing.Size(120, 41);
            this.numericGreen.TabIndex = 2;
            this.numericGreen.ValueChanged += new System.EventHandler(this.numericGreen_ValueChanged);
            // 
            // numericRed
            // 
            this.numericRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.numericRed.Location = new System.Drawing.Point(17, 188);
            this.numericRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericRed.Name = "numericRed";
            this.numericRed.Size = new System.Drawing.Size(120, 41);
            this.numericRed.TabIndex = 1;
            this.numericRed.ValueChanged += new System.EventHandler(this.numericRed_ValueChanged);
            // 
            // colorBox
            // 
            this.colorBox.BackColor = System.Drawing.Color.White;
            this.colorBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorBox.Location = new System.Drawing.Point(17, 63);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(371, 119);
            this.colorBox.TabIndex = 0;
            this.colorBox.TabStop = false;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1191);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BrowserTabs);
            this.Controls.Add(this.ToolStrip);
            this.Name = "Browser";
            this.Text = "Browser";
            this.Resize += new System.EventHandler(this.BrowserResize);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.BrowserTabs.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripTextBox Address;
        private System.Windows.Forms.ToolStripButton Back;
        private System.Windows.Forms.ToolStripButton Forward;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripButton AddBrowserTab;
        private System.Windows.Forms.TabControl BrowserTabs;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripButton removeBrowserTab;
        private System.Windows.Forms.ToolStripButton reloadButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton settingsBtn;
        private System.Windows.Forms.NumericUpDown numericBlue;
        private System.Windows.Forms.NumericUpDown numericGreen;
        private System.Windows.Forms.NumericUpDown numericRed;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.Label textBox1;
    }
}

