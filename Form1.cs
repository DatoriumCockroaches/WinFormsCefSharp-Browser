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
using System.Reflection;
using System.Drawing.Printing;

namespace ChromiumBrowser
{

    public partial class Browser : Form
    {
        ChromiumWebBrowser chromiumBrowser = null;

        List<Tuple<string, string>> visitedPagesList = new List<Tuple<string, string>>();
        List<TabPage> mainPages = new List<TabPage>();

        ImageList imgList = new ImageList();

        TabPage PlusPage = new TabPage();
        int TabNum = 1;

        string mainDir = null;
        string bgPath = null;

        public Browser()
        {
            InitializeComponent();
            mainDir = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName((new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath)));
            bgPath = Path.Combine(mainDir, "\\Resources\\Bg1.jpg");

            Bitmap resizedImage = new Bitmap(mainDir + bgPath);
            image = new Bitmap(resizedImage, resizedImage.Width, resizedImage.Height);

            InitializeBrowser();
            panel.Width = 0;

            BrowserTabs.ImageList = imgList;
            BrowserTabs.ImageList.Images.Add(Resources.chromium.ToBitmap());
            imgList.ImageSize = new Size(30, 30);

            this.Text = "Cockroach Browser";
            this.Icon = Resources.chromium;
            this.Update();

            InitializeControlProperties();
            this.DoubleBuffered = true;
        }

        private void InitializeControlProperties()
        {
            color = System.Drawing.Color.White;
            txtColor = System.Drawing.Color.Black;
            borderColor = System.Drawing.Color.White;

            backBrush = new SolidBrush(color);
            borderBrush = new SolidBrush(borderColor);
            txtBrush = new SolidBrush(txtColor);

            splitContainer1.SplitterDistance = 75;
            webPanel.Controls.Add(sideBrowser);
            webPanel.Location = new Point(75, 0);

            foreach (PictureBox img in sidePanel.Controls.OfType<PictureBox>())
            {
                img.Size = new Size(50, 50);
                img.Location = new Point(15, img.Location.Y);
            }

            sideBrowser.AddressChanged += SideBrowser_AddressChanged;
        }

        string address;
        private void SideBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            address = e.Address;
        }

        public void InitializeBrowser()
        { 
            var settings = new CefSettings();
            Cef.Initialize(settings);

            BrowserTabs.SizeMode = TabSizeMode.Fixed;
            BrowserTabs.ItemSize = new Size(200, 28);

            CreateMainPage();
            PlusPage.Text = "+";
            BrowserTabs.Controls.Add(PlusPage);
            BrowserTabs.Click += BrowserTabs_Click;
        }

        private void BrowserTabs_Click(object sender, EventArgs e)
        {
            if (BrowserTabs.SelectedTab == PlusPage)
            {
                CreateMainPage();
            }
        }

        int totalWidth = 0;

        List<Panel> panels = new List<Panel>();
        private void BrowserResize(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = distance;
            totalWidth = 0;

            foreach (ToolStripItem item in ToolStrip.Items)
            {
                if (item is ToolStripButton)
                {
                    totalWidth += item.Width;
                }
            }
            Address.Width = ToolStrip.Width - totalWidth - 50;
            webPanel.Size = new Size(sidePanel.Width - 75, sidePanel.Height);
            splitContainer1.SplitterDistance = distance;
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
                    chromiumBrowser.TitleChanged += ChromiumBrowser_TitleChanged;
                    chromiumBrowser.FrameLoadEnd += browser_FrameLoadEnd;

                    chromiumBrowser.Dock = DockStyle.Fill;

                    while (tabPage.Controls.Count > 0)
                    {
                        Control control = tabPage.Controls[0];
                        tabPage.Controls.Remove(control);
                    }
                    tabPage.Controls.Add(chromiumBrowser);
                    tabPage.BackgroundImage = null;
                    return;
                }

                chromiumBrowser = new ChromiumWebBrowser();
                chromiumBrowser.FrameLoadEnd += browser_FrameLoadEnd;
                chromiumBrowser.TitleChanged += ChromiumBrowser_TitleChanged;
                chromiumBrowser.Dock = DockStyle.Fill;
                SearchAdress(chromiumBrowser, Address.Text);

                while (tabPage.Controls.Count > 0)
                {
                    Control control = tabPage.Controls[0];
                    tabPage.Controls.Remove(control);
                }
                tabPage.Controls.Add(chromiumBrowser);

                if (Rgx.IsMatch(Address.Text))
                {
                    chromiumBrowser.Load(Address.Text);
                }
                else
                {
                    chromiumBrowser.Load("https://www.google.com/search?q=" + Address.Text.Replace(" ", "+"));
                }
            }
        }

        TabPage page;
        ChromiumWebBrowser chromiumWebBrowser;
        private void CreateNewTab(string url)
        {
            page = new TabPage();
            BrowserTabs.SelectedTab = page;

            chromiumWebBrowser = new ChromiumWebBrowser();

            if (url != null) { chromiumWebBrowser.Load(url); }
            else { chromiumWebBrowser.Load("google.com"); }

            chromiumWebBrowser.FrameLoadEnd += browser_FrameLoadEnd;
            chromiumWebBrowser.TitleChanged += ChromiumBrowser_TitleChanged;
            chromiumWebBrowser.Dock = DockStyle.Fill;

            page.Text = $"Tab {TabNum}";

            TabNum = TabNum += 1;

            page.Controls.Add(chromiumWebBrowser);

            int pos = BrowserTabs.TabCount > 0 ? BrowserTabs.TabCount - 1 : 0;

            if (pos > 0) { BrowserTabs.TabPages.Insert(pos, page); } else { BrowserTabs.TabPages.Add(page); }
            chromiumWebBrowser.Focus();
        }

        string title;
        private void ChromiumBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            title = e.Title;
            var browser = (ChromiumWebBrowser)sender;
            var tuple = new Tuple<string, string>(e.Title, browser.Address);

            if (visitedPagesList.Count < 2) { visitedPagesList.Add(tuple); return; }

            if (visitedPagesList.Last().Item1 != tuple.Item1 && !incognitoModeOn)
            {
                visitedPagesList.Add(tuple);
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
                visitedPagesList.Clear();
                while (page.Controls.Count > 0)
                {
                    Control control = page.Controls[0];
                    page.Controls.Remove(control);
                }
                GenerateHistory(labelY, page);
            };

            removeSelected.Click += (s, args) =>
            {
                while (controlsToRemove.Count > 0)
                {
                    page.Controls.Remove(controlsToRemove[0]);
                    controlsToRemove.RemoveAt(0);
                }
                while (page.Controls.Count > 0)
                {
                    Control control = page.Controls[0];
                    page.Controls.Remove(control);
                }
                GenerateHistory(labelY, page);
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
        Bitmap img;
        private int GenerateHistory(int labelY, TabPage page)
        {
            labelY = 5;
            foreach (var tuple in visitedPagesList)
            {
                System.Windows.Forms.Label urlLabel = new System.Windows.Forms.Label();
                PictureBox pictureBox = new PictureBox();

                CheckBox btn = new CheckBox();
                btn.AutoSize = true;
                btn.Text = "X";
                btn.Font = new Font("Arial", 10, FontStyle.Regular);

                urlLabel.Text = tuple.Item1.ToString();
                urlLabel.Font = new Font("Arial", 10, FontStyle.Regular);
                urlLabel.AutoSize = true;
                urlLabel.Location = new Point(100, labelY);
                urlLabel.ForeColor = System.Drawing.Color.Blue;
                urlLabel.Cursor = System.Windows.Forms.Cursors.Hand;

                try
                {
                    iconUrl = new Uri("https://" + new Uri(tuple.Item2).Host + "/favicon.ico");
                    stream = client.OpenRead(iconUrl);
                    img = new Bitmap(stream);
                }
                catch (Exception)
                {
                    img = Resources.chromium.ToBitmap();
                }
                pictureBox.Image = img;
                pictureBox.Size = new Size(25, 25);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                try
                {
                    iconUrl = new Uri("https://" + new Uri(tuple.Item2).Host + "/favicon.ico");
                    stream = client.OpenRead(iconUrl);
                    img = new Bitmap(stream);
                } catch (Exception)
                {
                    img = Resources.chromium.ToBitmap();
                }
                pictureBox.Image = img;
                pictureBox.Size = new Size(25, 25);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                btn.Location = new Point(10, labelY);

                pictureBox.Location = new Point(60, labelY);

                urlLabel.Click += (s, args) => {
                    CreateNewTab(tuple.Item2);
                };

                btn.CheckedChanged += (s, args) =>
                {
                    if (btn.Checked)
                    {
                        controlsToRemove.Add(btn);
                        controlsToRemove.Add(urlLabel);
                        visitedPagesList.Remove(tuple);
                    }
                    else
                    {
                        controlsToRemove.Remove(btn);
                        controlsToRemove.Remove(urlLabel);
                        visitedPagesList.Add(tuple);
                    }
                };

                BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(urlLabel);
                BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(btn);
                BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(pictureBox);



                labelY = urlLabel.Bottom + 5;
            }

            BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(removeAll);
            BrowserTabs.TabPages[BrowserTabs.TabPages.IndexOf(page)].Controls.Add(removeSelected);

            removeSelected.Location = new Point(10, labelY + 35);
            removeAll.Location = new Point(10, labelY);
            return labelY;
        }

        Image image;
        List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>();
        private void CreateMainPage()
        {
            TabPage page = new TabPage();
            mainPages.Add(page);

            BrowserTabs.SelectedTab = page;

            ChromiumWebBrowser crWebBrowser = new ChromiumWebBrowser();
            crWebBrowser.TitleChanged += ChromiumBrowser_TitleChanged;
            crWebBrowser.FrameLoadEnd += browser_FrameLoadEnd;
            crWebBrowser.Dock = DockStyle.Fill;

            drawBackground(page);

            drawBackground(page);

            page.Text = $"Tab {TabNum}";

            TabNum = TabNum += 1;

            System.Windows.Forms.TextBox txtbox = new System.Windows.Forms.TextBox();
            textBoxes.Add(txtbox);

            txtbox.Name = "MainSearch";
            txtbox.Text = "Search";
            txtbox.Font = new Font("Arial", 50);

            int pos = BrowserTabs.TabCount > 0 ? BrowserTabs.TabCount - 1 : 0;

            if (pos > 0) { BrowserTabs.TabPages.Insert(pos, page); } else { BrowserTabs.TabPages.Add(page); }
            crWebBrowser.Focus();

            txtbox.Width = Convert.ToInt32(0.6*Screen.PrimaryScreen.Bounds.Width);
            txtbox.Height = 70;

            txtbox.AutoSize = false;

            createShortcuts(page, txtbox);

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
                    chromiumWebBrowser = crWebBrowser;
                    SearchAdress(crWebBrowser, txtbox.Text);
                    page.Controls.Add(crWebBrowser);

                    page.BackgroundImage = null;
                    page.Controls.Remove(txtbox);
                    page.Controls.Remove(page.Controls.OfType<Panel>().First());
                    mainPages.Remove(page);
                    textBoxes.Remove(txtbox);
                }
            };
            page.Controls.Add(txtbox);
        }

        Dictionary<string, Bitmap> websiteIcons = new Dictionary<string, Bitmap>()
        {
            { "youtube", new Bitmap(Resources.youtube) },
            { "twitter", new Bitmap(Resources.twitter) },
            { "facebook", new Bitmap(Resources.facebook) },
            { "instagram", new Bitmap(Resources.instagram) },
            { "linkedin", new Bitmap(Resources.linkedin) },
            { "reddit", new Bitmap(Resources.reddit) },
            { "pinterest", new Bitmap(Resources.pinterest) },
            { "twitch", new Bitmap(Resources.twitch) }
        };

        private void createShortcuts(TabPage page, System.Windows.Forms.TextBox txtbox)
        {
            Panel panel = new Panel();
            panel.BackColor = Color.Transparent;
            panels.Add(panel);

            panel.Width = Convert.ToInt32(0.6 * txtbox.Width);

            int gapWidth = 30;
            int iconWidth = (panel.Width - gapWidth*3) / 4;

            panel.Height = Convert.ToInt32(iconWidth*1.5)+gapWidth;

            int row = 0;
            int col = 0;
            foreach (var websiteIcon in websiteIcons)
            {
                PictureBox img = new PictureBox();
                img.SizeMode = PictureBoxSizeMode.StretchImage;
                img.Size = new Size(iconWidth, Convert.ToInt32(iconWidth*0.75));
                img.Image = websiteIcon.Value;

                img.Location = new Point(col * (iconWidth + gapWidth), row * (img.Size.Height + gapWidth));

                string websiteUrl = $"https://www.{websiteIcon.Key}.com";
                img.MouseClick += (sender, e) =>
                {
                    ChromiumWebBrowser crWebBrowser = new ChromiumWebBrowser();
                    crWebBrowser.TitleChanged += ChromiumBrowser_TitleChanged;
                    crWebBrowser.FrameLoadEnd += browser_FrameLoadEnd;
                    crWebBrowser.Dock = DockStyle.Fill;
                    chromiumWebBrowser = crWebBrowser;
                    SearchAdress(crWebBrowser, websiteUrl);
                    page.Controls.Add(crWebBrowser);
                    page.BackgroundImage = null;

                    page.Controls.Remove(txtbox);
                    page.Controls.Remove(panel);
                    mainPages.Remove(page);
                    textBoxes.Remove(txtbox);
                    panels.Remove(panel);
                };

                panel.Controls.Add(img);

                col++;
                if (col == 4)
                {
                    col = 0;
                    row++;
                }
            }
            panel.Location = new Point((Width - panel.Width) / 2, (Height + panel.Height) / 2);
            page.Controls.Add(panel);
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

                this.Invoke(new Action(() =>
                {
                    if (BrowserTabs.SelectedTab.Text == "History") { return; }
                    BrowserTabs.SelectedTab.Text = title;
                    chromiumWebBrowser = browser;
                    try
                    {
                        iconUrl = new Uri("https://" + new Uri(url).Host + "/favicon.ico");

                        stream = client.OpenRead(iconUrl);
                        Bitmap bmp = new Bitmap(stream);

                        BrowserTabs.ImageList.Images.Add(bmp);
                        int imageIndex = BrowserTabs.ImageList.Images.Count - 1;
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


        bool incognitoModeOn = false;

        private void button1_Click(object sender, EventArgs e)
        {
            incognitoModeOn = !incognitoModeOn;
            if (incognitoModeOn)
            {
                button1.BackColor = System.Drawing.Color.Green;
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

        private void backGroundNumericChange(object sender, EventArgs e)
        {
            redVal = (byte)redUpDown.Value;
            greenVal = (byte)greenUpDown.Value;
            blueVal = (byte)blueUpDown.Value;

            changeControlColors();
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
                        TabPage pg = BrowserTabs.TabPages[i];

                        BrowserTabs.TabPages.Remove(pg);
                        pg.Dispose();

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



        SolidBrush backBrush, borderBrush, txtBrush;
        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0 && e.Index < BrowserTabs.TabCount)
            {
                // Get the bounds of the tab page
                Rectangle tabPageBounds = BrowserTabs.GetTabRect(e.Index);

                // Fill the background of the tab page with the desired color
                e.Graphics.FillRectangle(backBrush, tabPageBounds);

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
                Rectangle textBounds = new Rectangle(e.Bounds.X + 20, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

                // Draw the tab text
                try
                {
                    string text = BrowserTabs.TabPages[e.Index].Text;
                    if (text.Length > 13)//cut off after 13 chars
                    {
                        text = text.Substring(0, 13);
                    }
                    e.Graphics.DrawString(text, e.Font, txtBrush, textBounds);
                }
                catch (Exception)
                {
                    e.Graphics.DrawString($"Tab {TabNum}", e.Font, txtBrush, textBounds);
                }


                if (e.Index < this.BrowserTabs.TabCount - 1)
                {
                    // Draw the rectangle behind the X
                    Rectangle rect = new Rectangle(e.Bounds.Right - 30, e.Bounds.Y / 2, 30, tabPageBounds.Height);
                    e.Graphics.FillRectangle(backBrush, rect);

                    // Draw the X
                    Rectangle xBounds = new Rectangle(e.Bounds.Right - 30, e.Bounds.Y / 2, 30, e.Bounds.Height);
                    e.Graphics.DrawString("x", e.Font, txtBrush, xBounds);
                }

                e.Graphics.DrawRectangle(new System.Drawing.Pen(borderColor, 5), e.Bounds);
            }
        }

        byte redVal, greenVal, blueVal;
        byte borderRed, borderGreen, borderBlue;
        byte txtRed, txtGreen, txtBlue;

        private void txtValChanged(object sender, EventArgs e)
        {
            txtRed = (byte)txtUpDownRed.Value;
            txtGreen = (byte)txtUpDownGreen.Value;
            txtBlue = (byte)txtUpDownBlue.Value;

            changeTextColor();
        }

        private void borderValChanged(object sender, EventArgs e)
        {
            borderRed = (byte)borderRedUpDown.Value;
            borderGreen = (byte)borderGreenUpDown.Value;
            borderBlue = (byte)borderBlueUpDown.Value;

            changeBorderColor();
        }

        bool sidePanelOpened = false;
        int distance = 75;
        PictureBox prev;
        ChromiumWebBrowser sideBrowser = new ChromiumWebBrowser();
        private void SidePanel_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PictureBox pcBox = (PictureBox)sender;

            if (!sidePanelOpened || prev != pcBox)
            {
                if (prev == pcBox)
                {
                    sideBrowser.Load(address);
                } 
                else
                {
                    if (pcBox != whatsapp) { sideBrowser.Load($"{pcBox.Name}.com"); }
                    else { sideBrowser.Load($"web.{pcBox.Name}.com"); }
                }
                prev = pcBox;

                sideBrowser.Dock = DockStyle.Fill;

                sidePanelOpened = true;
                distance = 750;
                webPanel.Size = new Size(distance-75, sidePanel.Height);

                splitContainer1.IsSplitterFixed = false;
            }
            else
            {
                distance = 75;
                sidePanel.Width = distance;
                sidePanelOpened = false;
                splitContainer1.IsSplitterFixed = true;
            }

            splitContainer1.SplitterDistance = distance;
        }

        private void BrowserTabs_Resize(object sender, EventArgs e)
        {
            this.SuspendLayout();
            foreach (System.Windows.Forms.TextBox txtBox in textBoxes)
            {
                txtBox.Location = new Point((Width - txtBox.Width) / 2, (Height - txtBox.Height) / 2);
            }

            foreach (Panel panel in panels)
            {
                panel.Location = new Point((Width - panel.Width) / 2, (Height + panel.Height) / 2);
            }
            this.ResumeLayout();
        }

        private void SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!splitContainer1.IsSplitterFixed) { distance = splitContainer1.SplitterDistance; }
            webPanel.Width = distance - 75;
        }

        OpenFileDialog dialog = new OpenFileDialog();
        private void changeBg_BtnClick(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap resizedImage = new Bitmap(dialog.FileName);
                image = new Bitmap(resizedImage, resizedImage.Width / 2, resizedImage.Height / 2);
                foreach (TabPage page in mainPages)
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
            toggleBg.Checked = repeatingBg;

            foreach (TabPage page in mainPages)
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

        System.Drawing.Color color, txtColor, borderColor = new System.Drawing.Color();
        private void changeControlColors()
        {
            color = System.Drawing.Color.FromArgb(redVal, greenVal, blueVal);

            panel.BackColor = color;
            ToolStrip.BackColor = color;
            Address.BackColor = color;
            BrowserTabs.BackColor = color;
            colorBox.BackColor = color;
            sidePanel.BackColor = color;

            backBrush = new SolidBrush(color);

            BrowserTabs.Invalidate();
        }

        private void changeTextColor()
        {
            txtColor = System.Drawing.Color.FromArgb(txtRed, txtGreen, txtBlue);

            settingsBtn.ForeColor = txtColor;
            toolStripButton1.ForeColor = txtColor;
            toolStripButton2.ForeColor = txtColor;
            toolStripButton3.ForeColor = txtColor;
            label1.ForeColor = txtColor;
            label2.ForeColor = txtColor;
            label3.ForeColor = txtColor;
            Address.ForeColor = txtColor;
            pictureBox2.BackColor = txtColor;

            txtBrush = new SolidBrush(txtColor);

            BrowserTabs.Invalidate();
        }

        private void changeBorderColor()
        {
            borderColor = System.Drawing.Color.FromArgb(borderRed, borderGreen, borderBlue);

            pictureBox1.BackColor = borderColor;
            BrowserTabs.ForeColor = borderColor;

            BrowserTabs.Invalidate();
        }

    }
}
