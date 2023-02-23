using CefSharp.WinForms;
using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using ChromiumBrowser.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Policy;
using System.Text.RegularExpressions;

namespace ChromiumBrowser
{
    public partial class Browser : Form
    {
        ChromiumWebBrowser chromiumBrowser = null;
        List<ChromiumWebBrowser> chromiumBrowsers = new List<ChromiumWebBrowser>();

        public Browser()
        {
            InitializeComponent();
            InitializeBrowser();
            panel1.Width = 50;
            Address.BackColor = ToolStrip.BackColor;


            InitializePanelElements(false);

            this.Text = "My browser";
            this.Icon = Resources.chromium;
            this.Update();
        }

        private void InitializePanelElements(bool val)
        {
            foreach (Control control in panel1.Controls)
            {
                control.Visible = val;
            }
        }

        public void InitializeBrowser()
        {
            var settings = new CefSettings();
            Cef.Initialize(settings);

            chromiumBrowser = new ChromiumWebBrowser("https://google.com");
            BrowserTabs.TabPages[0].Controls.Add(chromiumBrowser);
            chromiumBrowser.Dock = DockStyle.Fill;
        }

        private void BrowserResize(object sender, EventArgs e)
        {
            Address.Width = this.ClientSize.Width - (Back.Width * 7) - 15;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (chromiumBrowser.CanGoBack)
            {
                chromiumBrowser.Back();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (chromiumBrowser.CanGoForward)
            {
                chromiumBrowser.Forward();
            }
        }
        private void SearchBarKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Uri uriResult;
                if (Uri.TryCreate(Address.Text, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    chromiumBrowser.LoadUrl(Address.Text);
                }
                else
                {
                    chromiumBrowser.LoadUrl("https://www.google.com/search?q=" + Address.Text.Replace(" ", "+"));
                }
            }
        }

        private void AddBrowserTab_Click(object sender, EventArgs e)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = "New Tab";

            chromiumBrowser = new ChromiumWebBrowser("https://google.com");
            tabPage.Controls.Add(chromiumBrowser);
            chromiumBrowser.Dock = DockStyle.Fill;

            BrowserTabs.TabPages.Add(tabPage);
        }

        private void removeBrowserTab_Click(object sender, EventArgs e)
        {
            if (BrowserTabs.SelectedTab!=null)
            {
                if (BrowserTabs.TabCount == 1)
                {
                    this.Close();
                }
                BrowserTabs.TabPages.Remove(BrowserTabs.SelectedTab);
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            chromiumBrowser.Reload();
        }
        bool isClosed = true;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (isClosed)
            {
                panel1.Width = 400;
                InitializePanelElements(true);
                MessageBox.Show(colorBox.Width.ToString());
            }
            else
            {
                panel1.Width = 50;
                InitializePanelElements(false);
            }
            isClosed = !isClosed;
        }

        byte redVal, greenVal, blueVal = 0;

        private void numericRed_ValueChanged(object sender, EventArgs e)
        {
            redVal = (byte)numericRed.Value;
            controlColorChange();
        }

        private void numericGreen_ValueChanged(object sender, EventArgs e)
        {
            greenVal = (byte)numericGreen.Value;
            controlColorChange();
        }

        private void numericBlue_ValueChanged(object sender, EventArgs e)
        {
            blueVal = (byte)numericBlue.Value;
            controlColorChange();
        }

        private void controlColorChange()
        {
            colorBox.BackColor = Color.FromArgb(redVal, greenVal, blueVal);

            ToolStrip.BackColor = colorBox.BackColor;
            Address.BackColor = ToolStrip.BackColor;
            panel1.BackColor = colorBox.BackColor;
        }
    }
}
