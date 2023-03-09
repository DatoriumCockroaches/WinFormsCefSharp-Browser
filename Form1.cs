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
using System.Security.Cryptography;
using System.Reflection.Emit;
using CefSharp.DevTools.DOMSnapshot;
using CefSharp.DevTools.Browser;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ChromiumBrowser
{

    public partial class Browser : Form
    {
        ChromiumWebBrowser chromiumBrowser = null;
        List<TabPage> mainPages = new List<TabPage>();
      
        List<string> visitedPages = new List<string>();
        int TabNum = 1;

        string mainDir = null;
        string bgPath = null;

        public Browser()
        {
            mainDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName((new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath)));
            bgPath = Path.Combine(mainDir, "\\Resources\\bg5.jfif");

            image = Image.FromFile(mainDir + bgPath);

            InitializeComponent();
            InitializeBrowser();
            panel.Width = 0;

            this.Text = "Cockroach Browser";
            this.Icon = Resources.chromium;
            this.Update();
        }

        public void InitializeBrowser()
        { 
            var settings = new CefSettings();
            Cef.Initialize(settings);

            CreateNewTab("google.com");
        }

        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            if (!incognitoModeOn) { visitedPages.Add(e.Address); }
        }
        int totalWidth = 0;

        private void BrowserResize(object sender, EventArgs e)
        {
            totalWidth = 0;
            foreach (ToolStripItem item in ToolStrip.Items)
            {
                if (item is ToolStripButton) { continue; }
                totalWidth += item.Width;
            }
            foreach(System.Windows.Forms.TextBox txtBox in textBoxes)
            {
                txtBox.Location = new Point((Width - txtBox.Width)/2, (Height-txtBox.Height)/2);
            }

        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            chromiumBrowser = BrowserTabs.SelectedTab.Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();
            if (chromiumBrowser != null)
            {
                if (chromiumBrowser.CanGoBack)
                {
                    chromiumBrowser.Back();
                }
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            chromiumBrowser = BrowserTabs.SelectedTab.Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();
            if (chromiumBrowser != null)
            {
                if (chromiumBrowser.CanGoForward)
                {
                    chromiumBrowser.Forward();
                }
            }
        }
        private void SearchBarKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var tabPage = BrowserTabs.SelectedTab;
                e.SuppressKeyPress = true;

                // Get the ChromiumWebBrowser control from the tab page
                chromiumBrowser = tabPage.Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();

                string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
                Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (tabPage.Text == "History")
                {
                    chromiumBrowser = new ChromiumWebBrowser();
                    chromiumBrowser.AddressChanged += OnBrowserAddressChanged;
                    chromiumBrowser.FrameLoadEnd += browser_FrameLoadEnd;
                    chromiumBrowser.Dock = DockStyle.Fill;

                    while (tabPage.Controls.Count > 0)
                    {
                        Control control = tabPage.Controls[0];
                        tabPage.Controls.Remove(control);
                    }
                    tabPage.Controls.Add(chromiumBrowser);
                }
                if (tabPage.Text.StartsWith("Tab"))
                {
                    chromiumBrowser = new ChromiumWebBrowser();
                    chromiumBrowser.AddressChanged += OnBrowserAddressChanged;
                    chromiumBrowser.FrameLoadEnd += browser_FrameLoadEnd;
                    chromiumBrowser.Dock = DockStyle.Fill;

                    while (tabPage.Controls.Count > 0)
                    {
                        Control control = tabPage.Controls[0];
                        tabPage.Controls.Remove(control);
                    }
                    tabPage.Controls.Add(chromiumBrowser);
                }

                SearchAdress(chromiumBrowser, Address.Text);            
            }
        }

        private void SearchAdress(ChromiumWebBrowser browser, string url)
        {
            if (url == null) { return; } 

            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);


            if (Rgx.IsMatch(url))
            {
                browser.Load(url);
            }
            else
            {
                browser.Load("https://www.google.com/search?q=" + url.Replace(" ", "+"));
            }
        }

        private void AddBrowserTab_Click(object sender, EventArgs e)
        {
            CreateNewTab("google.com");
        }

        private void removeBrowserTab_Click(object sender, EventArgs e)
        {
            TabNum -= 1;
            if (BrowserTabs.SelectedTab != null)
            {
                if (BrowserTabs.TabCount == 1)
                {
                    this.Close();
                }
                else
                {
                    BrowserTabs.TabPages.Remove(BrowserTabs.SelectedTab);
                }
            }
        }

        private void reloadButton_Click(object sender, EventArgs e)
        {
            TabPage page = BrowserTabs.SelectedTab;
            bool containsInstanceOfChromium = page.Controls.OfType<ChromiumWebBrowser>().Any();
            chromiumBrowser = BrowserTabs.SelectedTab.Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();

            if (containsInstanceOfChromium)
            {
                chromiumBrowser.Reload();
            } 
            else if(page.Text == "History")
            {
                while (page.Controls.Count > 0)
                {
                    Control control = page.Controls[0];
                    page.Controls.Remove(control);
                }
                GenerateHistory(labelY, page);
            }
        }

        bool isClosed = true;
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (isClosed)
            {
                panel.Width = 400;
            }
            else
            {
                panel.Width = 0;
            }
            isClosed = !isClosed;
        }

        int labelY;
 
        System.Windows.Forms.Button removeAll;
        System.Windows.Forms.Button removeSelected;
        private void historyBtn_Click(object sender, EventArgs e)
        {
            TabPage page = new TabPage();
            page.Text = "History";

            ChromiumWebBrowser browser = new ChromiumWebBrowser();
            browser.Dock = DockStyle.Fill;

            labelY = 5;
            BrowserTabs.TabPages.Add(page);

            removeAll = new System.Windows.Forms.Button();
            removeAll.AutoSize = true;
            removeAll.Font = new Font("Arial", 10, FontStyle.Regular);

            removeSelected = new System.Windows.Forms.Button();
            removeSelected.AutoSize = true;
            removeSelected.Font = new Font("Arial", 10, FontStyle.Regular);

            removeAll.Click += (s, args) =>
            {
                while (page.Controls.Count > 0)
                {
                    Control control = page.Controls[0];
                    page.Controls.Remove(control);
                }
                visitedPages.Clear();
            };

            removeSelected.Click += (s, args) =>
            {
                while (controlsToRemove.Count > 0)
                {
                    page.Controls.Remove(controlsToRemove[0]);
                    controlsToRemove.RemoveAt(0);
                }
            };

            removeAll.Text = "Clear history";
            removeSelected.Text = "Clear selected";

            labelY = GenerateHistory(labelY, page);

            removeAll.Location = new Point(10, labelY);
            removeSelected.Location = new Point(10, labelY+35);

            BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(removeAll);
            BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(removeSelected);
        }

        List<Control> controlsToRemove = new List<Control>();
        private int GenerateHistory(int labelY, TabPage page)
        {
            labelY = 5;
            foreach (var url in visitedPages)
            {
                System.Windows.Forms.Label urlLabel = new System.Windows.Forms.Label();

                CheckBox btn = new CheckBox();
                btn.AutoSize = true;
                btn.Text = "X";
                btn.Font = new Font("Arial", 10, FontStyle.Regular);

                urlLabel.Text = url.ToString();
                urlLabel.Font = new Font("Arial", 10, FontStyle.Regular);
                urlLabel.AutoSize = true;
                urlLabel.Location = new Point(30, labelY);
                urlLabel.ForeColor = Color.Blue;
                urlLabel.Cursor = Cursors.Hand;

                btn.Location = new Point(10, labelY);

                urlLabel.Click += (s, args) => {
                    CreateNewTab(url);
                };

                btn.CheckedChanged += (s, args) =>
                {
                    if (btn.Checked)
                    {
                        controlsToRemove.Add(btn);
                        controlsToRemove.Add(urlLabel);
                        visitedPages.Remove(urlLabel.Text);
                    }
                    else
                    {
                        controlsToRemove.Remove(btn);
                        controlsToRemove.Remove(urlLabel); 
                        visitedPages.Add(urlLabel.Text);
                    }
                };

                BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(urlLabel);
                BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(btn);

                labelY = urlLabel.Bottom + 5;
            }

            BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(removeAll);
            BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(removeSelected);

            removeSelected.Location = new Point(10, labelY+35);
            removeAll.Location = new Point(10, labelY);
            return labelY;
        }

        TabPage page;
        Image image;
        List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>();
        private void CreateNewTab(string url)
        {
            page = new TabPage();
            mainPages.Add(page);

            ChromiumWebBrowser chromiumWebBrowser = new ChromiumWebBrowser();

            chromiumWebBrowser.Dock = DockStyle.Fill;

            drawBackground(page);

            page.Text = $"Tab {TabNum}";

            TabNum = TabNum+=1;
            
            System.Windows.Forms.TextBox txtbox = new System.Windows.Forms.TextBox();
            textBoxes.Add(txtbox);

            txtbox.Name = "MainSearch";
            txtbox.Text = "Search";
            txtbox.Font = new Font("Arial", 50);

            BrowserTabs.TabPages.Add(page);

            txtbox.Width = 1500;
            txtbox.Height = 70;

            txtbox.AutoSize = false;

            int x = (page.Size.Width - txtbox.Size.Width) / 2;
            int y = (page.Size.Height - txtbox.Size.Height) / 2;

            txtbox.Location = new Point(x, y);
            this.Controls.Add(txtbox);

            txtbox.Click += (s, args) =>
            {
                txtbox.Text = "";
            };
            txtbox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    page.Controls.Add(chromiumWebBrowser);
                    SearchAdress(chromiumWebBrowser, txtbox.Text);
                    page.Controls.Remove(txtbox);
                    mainPages.Remove(page);
                    textBoxes.Remove(txtbox);
                }
            };
            page.Controls.Add(txtbox);
        }

        private void drawBackground(TabPage page)
        {
            page.BackgroundImage = image;
            if (repeatingBg) 
            {
                page.BackgroundImageLayout = ImageLayout.Tile; 
            } 
            else 
            { 
                page.BackgroundImageLayout = ImageLayout.Stretch; 
            }
        }

        private void MainSearchBarKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var tabPage = BrowserTabs.SelectedTab;
                e.SuppressKeyPress = true;

                // Get the ChromiumWebBrowser control from the tab page
                chromiumBrowser = tabPage.Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();

                string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
                Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (tabPage.Text == "History")
                {
                    chromiumBrowser = new ChromiumWebBrowser();
                    chromiumBrowser.AddressChanged += OnBrowserAddressChanged;
                    chromiumBrowser.FrameLoadEnd += browser_FrameLoadEnd;
                    chromiumBrowser.Dock = DockStyle.Fill;

                    while (tabPage.Controls.Count > 0)
                    {
                        Control control = tabPage.Controls[0];
                        tabPage.Controls.Remove(control);
                    }
                    tabPage.Controls.Add(chromiumBrowser);
                }
                if (tabPage.Text.StartsWith("Tab"))
                {
                    chromiumBrowser = new ChromiumWebBrowser();
                    chromiumBrowser.AddressChanged += OnBrowserAddressChanged;
                    chromiumBrowser.FrameLoadEnd += browser_FrameLoadEnd;
                    chromiumBrowser.Dock = DockStyle.Fill;

                    while (tabPage.Controls.Count > 0)
                    {
                        Control control = tabPage.Controls[0];
                        tabPage.Controls.Remove(control);
                    }
                    tabPage.Controls.Add(chromiumBrowser);
                }

                SearchAdress(chromiumBrowser, Address.Text);
            }
        }

        private void browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                ChromiumWebBrowser browser = (ChromiumWebBrowser)sender;
                string url = browser.Address;
                string domainName = GetDomainName(url);

                this.Invoke(new Action(() =>
                {
                    BrowserTabs.SelectedTab.Text = domainName;
                }));

            }
        }

        private string GetDomainName(string url)
        {
            bool page_safe = url.Contains("https:");
            bool page_unsafe = url.Contains("http:");
            string domain_name = null;
            if (page_safe)
            {
                domain_name = url.Substring(12); //this is how many characters are in "https://www."
                domain_name = domain_name.Substring(0, domain_name.IndexOf("/")); //cuts the end off
            }
            else if (page_unsafe)
            {
                domain_name = url.Substring(11); //this is how many characters are in "http://www."
                domain_name = domain_name.Substring(0, domain_name.IndexOf("/")); //cuts the end off
            }
            return domain_name;
        }


        bool incognitoModeOn = false;

        private void button1_Click(object sender, EventArgs e)
        {
            incognitoModeOn = !incognitoModeOn;
            if (incognitoModeOn == true)
            {
                button1.BackColor = Color.Green;
            }
            else
            {
                button1.BackColor = DefaultBackColor;
            }
        }

        private void Address_Click(object sender, EventArgs e)
        {
           Address.Text = "";
        }

        byte redVal, greenVal, blueVal;
        private void redUpDown_ValueChanged(object sender, EventArgs e)
        {
            redVal = (byte)redUpDown.Value;
            changeControlColors();
        }

        private void greenUpDown_ValueChanged(object sender, EventArgs e)
        {
            greenVal = (byte)greenUpDown.Value;
            changeControlColors();
        }

        OpenFileDialog dialog = new OpenFileDialog();
        private void changeBg_BtnClick(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                foreach(TabPage page in mainPages)
                {
                    drawBackground(page);
                }
            }
            else
            {
                MessageBox.Show("Error getting image");
            }

        }

        bool repeatingBg = true;
        private void ToggleRepeatingBg(object sender, EventArgs e)
        {
            repeatingBg = !repeatingBg;
            toggleRepeat.Checked = repeatingBg;

            foreach(TabPage page in mainPages)
            {
                page.BackgroundImage = image;
                if (repeatingBg) 
                { 
                    page.BackgroundImageLayout = ImageLayout.Tile; 
                } 
                else 
                { 
                    page.BackgroundImageLayout = ImageLayout.Stretch; 
                }
            }
        }

        private void blueUpDown_ValueChanged(object sender, EventArgs e)
        {
            blueVal = (byte)blueUpDown.Value;
            changeControlColors();
        }

        private void changeControlColors()
        {
            Color color = Color.FromArgb(redVal, greenVal, blueVal);
            panel.BackColor = color;
            ToolStrip.BackColor = color;
            Address.BackColor = color;
            BrowserTabs.BackColor = color;
        }

    }

    public static class ControlHelper
    {
        #region Redraw Suspend/Resume
        [DllImport("user32.dll", EntryPoint = "SendMessageA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        private const int WM_SETREDRAW = 0xB;

        public static void SuspendDrawing(this Control target)
        {
            SendMessage(target.Handle, WM_SETREDRAW, 0, 0);
        }

        public static void ResumeDrawing(this Control target) { ResumeDrawing(target, true); }
        public static void ResumeDrawing(this Control target, bool redraw)
        {
            SendMessage(target.Handle, WM_SETREDRAW, 1, 0);

            if (redraw)
            {
                target.Refresh();
            }
        }
        #endregion
    }
}

