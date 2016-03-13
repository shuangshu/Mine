using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Windows.SystemControl;

namespace Mine
{
    public partial class MineMain : Form
    {
        private Rebar rebar = null;
        private RebarBand band = null;
        private MenuBox menuBox = null;
        private MenuBoxItem menuItemGame = null;
        private MenuBoxItem menuItemHelp = null;

        private ContextMenu contextMenuHelp = null;
        private MenuItem useHelp = null;
        private MenuItem aboutMine = null;

        private ContextMenu contextMenuGame = null;
        private MenuItem menuItemBegin = null;
        private MenuItem menuItemCustom = null;
        private MenuItem menuItemVoice = null;
        private MenuItem menuItemColor = null;
        private MenuItem menuItemExit = null;
        private MenuItemRender render = null;
        private MinePalette minePalette = null;
        private MineSetting mineSetting = null;
        private Setting setting = null;

        public MineMain()
        {
            InitializeComponent();
            LoadControls();
        }

        private void LoadControls()
        {
            HandleDestroyed+=new EventHandler(MineMain_HandleDestroyed);

            mineSetting = new MineSetting();
            mineSetting.HandleCreated += new EventHandler(mineSetting_HandleCreated);

            minePalette = new MinePalette();
            minePalette.MessageSize += new MessageSizeEventHandler(minePalette_MessageSize);
            minePalette.Location = new Point(0, 20);
            this.Controls.Add(minePalette);
            setting = minePalette.Setting;
            render = new MenuItemRender();
            render.ImageList = new ImageList();
            render.ImageList.ColorDepth = ColorDepth.Depth32Bit;
            render.ImageList.ImageSize = new System.Drawing.Size(32, 32);
            render.ImageList.Images.Add(Properties.Resources.help);
            render.ImageList.Images.Add(Properties.Resources.about);
            render.ImageList.Images.Add(Properties.Resources.begin);
            render.ImageList.Images.Add(Properties.Resources.sound);
            render.ImageList.Images.Add(Properties.Resources.soundGray);
            render.ImageList.Images.Add(Properties.Resources.color);
            render.ImageList.Images.Add(Properties.Resources.colorGray);
            render.ImageList.Images.Add(Properties.Resources.customer);
            render.ImageList.Images.Add(Properties.Resources.exit);
            contextMenuHelp = new ContextMenu();
            useHelp = new MenuItem("使用帮助");
            render.SetEnable(useHelp, true);
            render.SetImageIndex(useHelp, 0);
            useHelp.Click += new EventHandler(useHelp_Click);
            contextMenuHelp.MenuItems.Add(useHelp);
            aboutMine = new MenuItem("关于扫雷");
            render.SetEnable(aboutMine, true);
            render.SetImageIndex(aboutMine, 1);
            aboutMine.Click += new EventHandler(aboutMine_Click);
            contextMenuHelp.MenuItems.Add(aboutMine);

            contextMenuGame = new ContextMenu();
            menuItemBegin = new MenuItem("开局");
            render.SetEnable(menuItemBegin, true);
            render.SetImageIndex(menuItemBegin, 2);
            menuItemBegin.Click += new EventHandler(menuItemBegin_Click);
            contextMenuGame.MenuItems.Add(menuItemBegin);
            menuItemVoice = new MenuItem("声音");
            render.SetEnable(menuItemVoice, true);
            if (minePalette.Setting.AllowVoice)
            {
                render.SetImageIndex(menuItemVoice, 3);
            }
            else
            {
                render.SetImageIndex(menuItemVoice, 4);
            }
            menuItemVoice.Click += new EventHandler(menuItemVoice_Click);
            contextMenuGame.MenuItems.Add(menuItemVoice);
            menuItemColor = new MenuItem("颜色");
            render.SetEnable(menuItemColor, true);
            if (minePalette.Setting.AllowColor)
            {
                render.SetImageIndex(menuItemColor, 5);
            }
            else
            {
                render.SetImageIndex(menuItemColor, 6);
            }
            menuItemColor.Click += new EventHandler(menuItemColor_Click);
            contextMenuGame.MenuItems.Add(menuItemColor);
            menuItemCustom = new MenuItem("设置");
            render.SetEnable(menuItemCustom, true);
            render.SetImageIndex(menuItemCustom, 7);
            menuItemCustom.Click += new EventHandler(menuItemCustom_Click);
            contextMenuGame.MenuItems.Add(menuItemCustom);
            menuItemExit = new MenuItem("退出");
            render.SetEnable(menuItemExit, true);
            render.SetImageIndex(menuItemExit, 8);
            menuItemExit.Click += new EventHandler(menuItemExit_Click);
            contextMenuGame.MenuItems.Add(menuItemExit);

            menuBox = new MenuBox();
            menuItemGame = new MenuBoxItem();
            menuItemGame.Text = "游戏";
            menuItemGame.DropDownMenu = contextMenuGame;
            menuItemHelp = new MenuBoxItem();
            menuItemHelp.Text = "帮助";
            menuItemHelp.DropDownMenu = contextMenuHelp;
            menuBox.Items.Add(menuItemGame);
            menuBox.Items.Add(menuItemHelp);

            rebar = new Rebar();
            rebar.Dock = DockStyle.Top;
            rebar.Height = 20;
            band = new RebarBand("扫雷 1.0", menuBox);
            rebar.Bands.Add(band);
            this.Controls.Add(rebar);
        }

        private void MineMain_HandleDestroyed(object sender, EventArgs e)
        {
            setting.Save();
        }

        private void mineSetting_HandleCreated(object sender, EventArgs e)
        {
            mineSetting.Row = setting.Row;
            mineSetting.Column = setting.Column;
            mineSetting.MineNumber = setting.MineNumber;
        }

        private void menuItemCustom_Click(object sender, EventArgs e)
        {
            if (mineSetting.ShowDialog() == DialogResult.OK)
            {
                setting.Row = mineSetting.Row;
                setting.Column = mineSetting.Column;
                setting.MineNumber = mineSetting.MineNumber;
                setting.Save();
                minePalette.LoadSetting();
                minePalette.InitializeGame();
            }
        }

        private void minePalette_MessageSize(object sender, int cx, int cy)
        {
            this.Size = new Size(cx + 6, cy + 52);
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemColor_Click(object sender, EventArgs e)
        {
            int index = render.GetImageIndex(menuItemColor);
            if (index == 5)
            {
                setting.AllowColor = false;
                index += 1;
            }
            else
            {
                setting.AllowColor = true;
                index -= 1;
            }
            render.SetImageIndex(menuItemColor, index);
            MineCommon.LoadBitmap(setting);
            minePalette.Invalidate();
        }

        private void menuItemVoice_Click(object sender, EventArgs e)
        {
            int index = render.GetImageIndex(menuItemVoice);
            if (index == 3)
            {
                setting.AllowVoice = false;
                index += 1;
            }
            else
            {
                setting.AllowVoice = true;
                index -= 1;
            }
            render.SetImageIndex(menuItemVoice, index);
        }

        private void menuItemBegin_Click(object sender, EventArgs e)
        {
            minePalette.InitializeGame();
            minePalette.Invalidate();
        }

        private void aboutMine_Click(object sender, EventArgs e)
        {
            MineCommon.MineAbout("2012");
        }

        private void useHelp_Click(object sender, EventArgs e)
        {
            MineCommon.ShowHelp();
        }
    }
}
