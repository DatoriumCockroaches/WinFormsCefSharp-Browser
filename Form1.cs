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
using System.Net;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Input;
using System.Runtime.CompilerServices;

namespace ChromiumBrowser
{

    public partial class Browser : Form
    {
        ChromiumWebBrowser chromiumBrowser = null;
        List<ChromiumWebBrowser> chromiumBrowsers = new List<ChromiumWebBrowser>();
        ImageList imgList = new ImageList();

        TabPage PlusPage = new TabPage();

        List<string> visitedPages = new List<string>();
        int TabNum = 1;

        public Browser()
        {
            InitializeComponent();
            InitializeBrowser();
            panel.Width = 0;

            BrowserTabs.ImageList = imgList;
            imgList.Images.Add(Properties.Resources.settings);
            imgList.ImageSize = new Size(32, 32);

            this.Text = "Cockroach Browser";
            this.Icon = Resources.chromium;
            this.Update();
            this.KeyPreview = true;
            this.Focus();
        }

        public void InitializeBrowser()
        {
            var settings = new CefSettings();
            Cef.Initialize(settings);

            BrowserTabs.SizeMode = TabSizeMode.Fixed;
            BrowserTabs.ItemSize = new Size(200, 30);

            CreateNewTab("google.com");
            PlusPage.Text = "+";
            BrowserTabs.Controls.Add(PlusPage);
            BrowserTabs.Click += BrowserTabs_Click;
        }

        private void BrowserTabs_Click(object sender, EventArgs e)
        {
            if (BrowserTabs.SelectedTab == PlusPage)
            {
                CreateNewTab("google.com");
            }
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
            Address.Width = this.ClientSize.Width - totalWidth;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            chromiumBrowser = BrowserTabs.SelectedTab.Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();
            if (chromiumBrowser.CanGoBack)
            {
                chromiumBrowser.Back();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            chromiumBrowser = BrowserTabs.SelectedTab.Controls.OfType<ChromiumWebBrowser>().FirstOrDefault();
            if (chromiumBrowser.CanGoForward)
            {
                chromiumBrowser.Forward();
            }
        }
        private void SearchBarKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
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

                SearchAdress(chromiumBrowser);
            }
        }

        private void SearchAdress(ChromiumWebBrowser browser)
        {
            if (Address.Text == null) { return; }

            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);


            if (Rgx.IsMatch(Address.Text))
            {
                browser.Load(Address.Text);
            }
            else
            {
                browser.Load("https://www.google.com/search?q=" + Address.Text.Replace(" ", "+"));
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
            else if (page.Text == "History")
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
            BrowserTabs.SelectedTab = page;
            page.Text = "History";

            ChromiumWebBrowser browser = new ChromiumWebBrowser();
            browser.Dock = DockStyle.Fill;

            labelY = 5;
            int pos = BrowserTabs.TabCount - 1;
            BrowserTabs.TabPages.Insert(pos, page);

            removeAll = new System.Windows.Forms.Button();
            removeAll.AutoSize = true;
            removeAll.Font = new Font("Arial", 10, FontStyle.Regular);

            removeSelected = new System.Windows.Forms.Button();
            removeSelected.AutoSize = true;
            removeSelected.Font = new Font("Arial", 10, FontStyle.Regular);

            removeAll.Click += (s, args) =>
            {
                foreach (var control in page.Controls.OfType<System.Windows.Forms.Label>())
                {
                    page.Controls.Remove(control);
                    control.Dispose();
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
            removeSelected.Location = new Point(10, labelY + 35);

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
                urlLabel.Cursor = System.Windows.Forms.Cursors.Hand;

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

            removeSelected.Location = new Point(10, labelY + 35);
            removeAll.Location = new Point(10, labelY);
            return labelY;
        }

        TabPage page;
        private void CreateNewTab(string url)
        {
            page = new TabPage();
            BrowserTabs.SelectedTab = page;

            ChromiumWebBrowser chromiumWebBrowser = new ChromiumWebBrowser();

            if (url != null) { chromiumWebBrowser.Load(url); }
            else { chromiumWebBrowser.Load("google.com"); }

            chromiumWebBrowser.FrameLoadEnd += browser_FrameLoadEnd;
            chromiumWebBrowser.AddressChanged += OnBrowserAddressChanged;
            chromiumWebBrowser.Dock = DockStyle.Fill;

            page.Text = $"Tab {TabNum}";

            TabNum = TabNum += 1;

            page.Controls.Add(chromiumWebBrowser);

            int pos = BrowserTabs.TabCount > 0 ? BrowserTabs.TabCount - 1 : 0;

            if (pos > 0) { BrowserTabs.TabPages.Insert(pos, page); } else { BrowserTabs.TabPages.Add(page); }
            chromiumWebBrowser.Focus();
        }

        WebClient client = new WebClient();
        Stream stream;

        Uri iconUrl = new Uri("https://google.com");
        Dictionary<TabPage, int> tabImageIndex = new Dictionary<TabPage, int>();
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

                    try
                    {
                        iconUrl = new Uri("https://" + new Uri(url).Host + "/favicon.ico");

                        stream = client.OpenRead(iconUrl);
                        Bitmap bmp = new Bitmap(stream);

                        BrowserTabs.ImageList.Images.Add(bmp);
                        int imageIndex = BrowserTabs.ImageList.Images.Count-1;
                        BrowserTabs.SelectedTab.ImageIndex = BrowserTabs.ImageList.Images.Count - 1;
                        tabImageIndex[BrowserTabs.SelectedTab] = imageIndex;

                        BrowserTabs.Invalidate();
                    }
                    catch (Exception)
                    {
                        tabImageIndex[BrowserTabs.SelectedTab] = 0;
                        BrowserTabs.SelectedTab.ImageIndex = 0;
                    }
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
                //s.Substring(url + 2)
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

        private void BrowserTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BrowserTabs.SelectedIndex == BrowserTabs.TabPages.Count - 1)
            {
                CreateNewTab("google.com");
            }
        }

        TabPage GetPageByPoint(TabControl tabControl, Point point)
        {
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                TabPage page = tabControl.TabPages[i];
                if (tabControl.GetTabRect(i).Contains(point))
                    return page;
            }
            return null;
        }

        private bool isOverCloseButton = false;
        TabPage selectedPage;

        private void TabControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            for (int i = 0; i < BrowserTabs.TabPages.Count; i++)
            {
                Rectangle r = BrowserTabs.GetTabRect(i);
                Rectangle closeButton = new Rectangle(r.Right - 30, r.Top / 2, 30, 15);
                if (closeButton.Contains(e.Location))
                {
                    isOverCloseButton = true;
                    return;
                }
            }

            // If the mouse is not over the close button, handle tab dragging
            isOverCloseButton = false;
            selectedPage = GetPageByPoint(BrowserTabs, e.Location);
        }

        private void TabControl_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (isOverCloseButton)
            {
                for (int i = 0; i < BrowserTabs.TabPages.Count; i++)
                {
                    Rectangle r = BrowserTabs.GetTabRect(i);
                    Rectangle closeButton = new Rectangle(r.Right - 30, r.Top / 2, 30, 15);
                    if (closeButton.Contains(e.Location))
                    {
                        BrowserTabs.TabPages.RemoveAt(i);
                        selectedPage = null;
                        if (BrowserTabs.TabCount == 1) { this.Close(); }

                        return;
                    }
                }
            }

            if (selectedPage != null && selectedPage != PlusPage)
            {
                TabPage swappedPage = GetPageByPoint(BrowserTabs, e.Location);
                if (swappedPage != null && swappedPage != selectedPage)
                {
                    BrowserTabs.TabPages.Remove(selectedPage);
                    BrowserTabs.TabPages.Insert(BrowserTabs.TabPages.IndexOf(swappedPage), selectedPage);
                    BrowserTabs.SelectedTab = selectedPage;
                }
                else
                {
                    selectedPage = null;
                }
            }
        }



        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < BrowserTabs.TabCount)
            { 
                // Set up the image bounds and size
                Rectangle imageBounds = new Rectangle(e.Bounds.Left, e.Bounds.Top, 25, 25);

                // Draw the image for all tabs except the last one
                try
                {
                    if (e.Index < BrowserTabs.TabCount - 1)
                    {
                        // Draw the image for the tab, if there is one
                        if (tabImageIndex.TryGetValue(BrowserTabs.TabPages[e.Index], out int imageIndex))
                        {
                            e.Graphics.DrawImage(BrowserTabs.ImageList.Images[imageIndex], imageBounds);
                        }
                    }
                } 
                catch (Exception)
                {
                    BrowserTabs.ImageList.Images.Add(Resources.chromium);
                }

                // Set up the text bounds
                Rectangle textBounds = new Rectangle(e.Bounds.X + 20, e.Bounds.Y, e.Bounds.Width - 20, e.Bounds.Height);

                // Draw the tab text
                try
                {
                    e.Graphics.DrawString(BrowserTabs.TabPages[e.Index].Text, e.Font, Brushes.Black, textBounds);
                }
                catch (Exception)
                {
                    e.Graphics.DrawString($"Tab {TabNum}", e.Font, Brushes.Black, textBounds);
                }

                if (e.Index < this.BrowserTabs.TabCount - 1)
                {
                    // Draw the rectangle behind the X
                    Rectangle rect = new Rectangle(e.Bounds.Right - 30, e.Bounds.Y/2, 30, 30);
                    e.Graphics.FillRectangle(SystemBrushes.Control, rect);

                    // Draw the X
                    Rectangle xBounds = new Rectangle(e.Bounds.Right - 30, e.Bounds.Y / 2, 30, e.Bounds.Height);
                    e.Graphics.DrawString("x", e.Font, Brushes.Black, xBounds);
                }

                //e.DrawFocusRectangle();
            }
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

            BrowserTabs.Invalidate();
        }

    }
}

