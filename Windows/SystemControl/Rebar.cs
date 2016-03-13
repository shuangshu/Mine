using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms.VisualStyles;
using System.Security.Permissions;
using System.Runtime.InteropServices;

namespace Windows.SystemControl
{
    [Flags]
    public enum TRBStyle : int
    {
        BandBorders = 1,
        DoubleClickToggle = 2,
        FixedOrder = 4,
        ToolTips = 8,
        VarHeight = 16,
        VerticalGripper = 32,
        Vert = 64,
        AutoSize = 128
    }
    [Flags]
    public enum TRBBStyle : int
    {
        Break = 1,
        ChildEdge = 2,
        FixedBitmap = 4,
        FixedSize = 8,
        GripperAlways = 16,
        Hidden = 32,
        NoGripper = 64,
        UseChevron = 128,
        VariableHeight = 256
    }
    [ToolboxBitmap(typeof(Rebar)), ToolboxItem(true)]
    public class Rebar : Control
    {
        private RebarBandCollection bandsCollection = null;
        public RebarBandCollection Bands
        {
            get { return bandsCollection; }
        }

        internal RebarBand[] bands = null;
        internal int bandsCount = 0;

        private TRBStyle rebarStyle = TRBStyle.VarHeight | TRBStyle.BandBorders | TRBStyle.FixedOrder | TRBStyle.AutoSize;
        public TRBStyle Style
        {
            get { return rebarStyle; }
            set
            {
                if (rebarStyle != value)
                {
                    rebarStyle = value;
                    RecreateHandle();
                }
            }
        }

        public event DeletedBandeEventHandler DeletedBande;
        public event DeletingBandeEventHandler DeletingBande;

        public event MenuItemEventHandler MenuItemClick;

        public Rebar()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, false);
            this.bandsCollection = new RebarBandCollection(this);
        }

        private bool allowDrag = false;
        public bool AllowDrag
        {
            get { return allowDrag; }
            set
            {
                if (allowDrag != value)
                {
                    allowDrag = value;
                    RecreateHandle();
                }
            }
        }

        private ImageList imageList = null;
        public ImageList ImageList
        {
            get { return imageList; }
            set
            {
                if (imageList != value)
                {
                    imageList = value;
                    RecreateHandle();
                }
            }
        }

        protected virtual object[] GetBands()
        {
            RebarBand[] result = new RebarBand[bandsCount];
            if (bandsCount > 0)
                Array.Copy(bands, 0, result, 0, bandsCount);
            return result;
        }
        protected virtual object[] GetBands(Type baseType)
        {
            object[] result = (object[])Array.CreateInstance(baseType, bandsCount);
            if (bandsCount > 0) Array.Copy(bands, 0, result, 0, bandsCount);
            return result;
        }
        public RebarBand[] GetTRebarBands()
        {
            return (RebarBand[])GetBands();
        }
        private bool noResize = true;
        public bool NoResize
        {
            get { return noResize; }
            set
            {
                if (noResize != value)
                {
                    noResize = value;
                    RecreateHandle();
                }
            }
        }
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassName = NativeMethods.WC_REBAR;
                cp.Style |= NativeMethods.WS_BORDER | NativeMethods.WS_CHILD | NativeMethods.WS_CLIPCHILDREN | NativeMethods.WS_CLIPSIBLINGS |
                    NativeMethods.WS_VISIBLE | NativeMethods.WS_OVERLAPPED | NativeMethods.CCS_NODIVIDER;
                cp.ExStyle = NativeMethods.WS_EX_LEFT | NativeMethods.WS_EX_LTRREADING | NativeMethods.WS_EX_RIGHTSCROLLBAR;

                if (NoResize) cp.Style |= NativeMethods.CCS_NORESIZE;
                else cp.Style &= ~NativeMethods.CCS_NORESIZE;

                if (AllowDrag) cp.Style |= NativeMethods.RBS_REGISTERDROP;
                else cp.Style &= ~NativeMethods.RBS_REGISTERDROP;

                if ((rebarStyle & TRBStyle.Vert) != 0) cp.Style |= NativeMethods.CCS_VERT;
                else cp.Style &= ~NativeMethods.CCS_VERT;

                if ((rebarStyle & TRBStyle.AutoSize) != 0) cp.Style |= NativeMethods.RBS_AUTOSIZE;
                else cp.Style &= ~NativeMethods.RBS_AUTOSIZE;

                if ((rebarStyle & TRBStyle.BandBorders) != 0) cp.Style |= NativeMethods.RBS_BANDBORDERS;
                else cp.Style &= ~NativeMethods.RBS_BANDBORDERS;

                if ((rebarStyle & TRBStyle.DoubleClickToggle) != 0) cp.Style |= NativeMethods.RBS_DBLCLKTOGGLE;
                else cp.Style &= ~NativeMethods.RBS_DBLCLKTOGGLE;

                if ((rebarStyle & TRBStyle.FixedOrder) != 0) cp.Style |= NativeMethods.RBS_FIXEDORDER;
                else cp.Style &= ~NativeMethods.RBS_FIXEDORDER;

                if ((rebarStyle & TRBStyle.ToolTips) != 0) cp.Style |= NativeMethods.RBS_TOOLTIPS;
                else cp.Style &= ~NativeMethods.RBS_TOOLTIPS;

                if ((rebarStyle & TRBStyle.VarHeight) != 0) cp.Style |= NativeMethods.RBS_VARHEIGHT;
                else cp.Style &= ~NativeMethods.RBS_VARHEIGHT;

                if ((rebarStyle & TRBStyle.VerticalGripper) != 0) cp.Style |= NativeMethods.RBS_VERTICALGRIPPER;
                else cp.Style &= ~NativeMethods.RBS_VERTICALGRIPPER;

                return cp;
            }
        }
        protected override void CreateHandle()
        {
            if (!RecreatingHandle)
            {
                IntPtr userCookie = NativeCOM.ThemingScope.Activate();
                try
                {
                    NativeMethods.INITCOMMONCONTROLSEX icc = new NativeMethods.INITCOMMONCONTROLSEX();
                    icc.dwICC = NativeMethods.ICC_COOL_CLASSES;
                    UnsafeNativeMethods.InitCommonControlsEx(icc);
                }
                finally
                {
                    NativeCOM.ThemingScope.Deactivate(userCookie);
                }
            }
            base.CreateHandle();
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (IsHandleCreated && imageList != null)
            {
                NativeMethods.REBARINFO rebarINFO = new NativeMethods.REBARINFO();
                rebarINFO.cbSize = Marshal.SizeOf(typeof(NativeMethods.REBARINFO));
                rebarINFO.fMask |= NativeMethods.RBIM_IMAGELIST;
                rebarINFO.himl = imageList.Handle;
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBARINFO, 0, ref rebarINFO);
            }
            int count = bandsCount;
            if (bands != null && IsHandleCreated)
            {
                for (int i = 0; i < count; i++)
                {
                    NativeMethods.REBARBANDINFO bandINFO = bands[i].GetREBARBANDINFO(i);
                    if (Marshal.SystemDefaultCharSize == 1)
                    {
                        UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_INSERTBANDA, i, ref bandINFO);
                        UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBANDINFOA, i, ref bandINFO);
                    }
                    else
                    {
                        UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_INSERTBANDW, i, ref bandINFO);
                        UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBANDINFOW, i, ref bandINFO);
                    }
                }
                UnsafeNativeMethods.UpdateWindow(Handle);
            }
        }
        public new void RecreateHandle()
        {
            RebarBand[] btns = GetTRebarBands();
            Bands.Clear();
            bands = null;
            bandsCount = 0;

            base.RecreateHandle();

            for (int i = 0; i < btns.Length; i++)
                Bands.Add(btns[i]);
        }

        private int updateCount = 0;
        public void BeginUpdate()
        {
            if (!IsHandleCreated) return;
            if (updateCount == 0)
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.WM_SETREDRAW, 0, 0);
            updateCount++;
        }
        public bool EndUpdate()
        {
            if (!IsHandleCreated) return false;
            if (updateCount > 0)
            {
                updateCount--;
                if (updateCount == 0)
                {
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.WM_SETREDRAW, -1, 0);
                    Invalidate();
                }
                return true;
            }
            else
                return false;
        }

        public void InsertRebarBand(RebarBand value, int index)
        {
            if (IsHandleCreated)
            {
                if (Marshal.SystemDefaultCharSize == 1)
                {
                    NativeMethods.REBARBANDINFO bandINFO = value.GetREBARBANDINFO(index);
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_INSERTBANDA, index, ref bandINFO);
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBANDINFOA, index, ref bandINFO);
                }
                else
                {
                    NativeMethods.REBARBANDINFO bandINFO = value.GetREBARBANDINFO(index);
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_INSERTBANDW, index, ref bandINFO);
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBANDINFOW, index, ref bandINFO);
                }
            }
        }
        public void UpdateRebarBand(RebarBand value, int index)
        {
            if (IsHandleCreated)
            {
                BeginUpdate();
                if (Marshal.SystemDefaultCharSize == 1)
                {
                    NativeMethods.REBARBANDINFO bandINFO = value.GetREBARBANDINFO(index);
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBANDINFOA, index, ref bandINFO);
                }
                else
                {
                    NativeMethods.REBARBANDINFO bandINFO = value.GetREBARBANDINFO(index);
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBANDINFOW, index, ref bandINFO);
                }
                EndUpdate();
            }
        }
        public void DeleteRebarBand(int index)
        {
            if (IsHandleCreated)
            {
                BeginUpdate();
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_DELETEBAND, index, IntPtr.Zero);
                EndUpdate();
            }
        }

        unsafe private void WmReflectNotify(ref Message m)
        {
            NativeMethods.NMHDR* nmhdr = (NativeMethods.NMHDR*)m.LParam;
            switch (nmhdr->code)
            {
                case NativeMethods.NM_CUSTOMDRAW:
                    WmCustomDraw(ref m);
                    break;
                case NativeMethods.RBN_HEIGHTCHANGE://Rebar高度改变以后发送此消息
                    break;
                case NativeMethods.RBN_CHEVRONPUSHED:
                    WmReflectNotifyChevronPushed(ref m);
                    break;
                case NativeMethods.RBN_DELETEDBAND:
                    break;
                case NativeMethods.RBN_DELETINGBAND:
                    break;
            }
            base.WndProc(ref m);
        }
        private void WmCustomDraw(ref Message m)
        {

        }
        private void WmReflectNotifyChevronPushed(ref Message m)
        {
            NativeMethods.NMREBARCHEVRON nrch = (NativeMethods.NMREBARCHEVRON)m.GetLParam(typeof(NativeMethods.NMREBARCHEVRON));
            RebarBand band = Bands[nrch.wID];
            ContextMenu childMenu = new ContextMenu();
            if (band.Control != null && band.Control is ToolBox)
            {
                ToolBox toolBar = band.Control as ToolBox;
                NativeMethods.RECT lpRect = new NativeMethods.RECT();
                UnsafeNativeMethods.GetClientRect(new HandleRef(band.Control, band.Control.Handle), ref lpRect);
                int count = (int)UnsafeNativeMethods.SendMessage(new HandleRef(band.Control, band.Control.Handle), NativeMethods.TB_BUTTONCOUNT, IntPtr.Zero, IntPtr.Zero);
                if (count != toolBar.buttonsCount) throw new ArgumentOutOfRangeException("count");
                for (int i = 0; i < count; i++)
                {
                    NativeMethods.RECT brc = new NativeMethods.RECT();
                    UnsafeNativeMethods.SendMessage(new HandleRef(band.Control, band.Control.Handle), NativeMethods.TB_GETITEMRECT, i, ref brc);
                    if (brc.right >= (lpRect.right - lpRect.left))
                    {
                        ToolBoxButton btn = toolBar.Buttons[i];
                        if ((btn.Appearance & TBBAppearance.Separator) == 0)
                        {
                            string text = string.Empty;
                            if (!string.IsNullOrEmpty(btn.Text))
                            {
                                text = btn.Text;
                            }
                            else if (!string.IsNullOrEmpty(btn.ToolTipText))
                            {
                                text = btn.ToolTipText;
                            }
                            else
                            {
                                text = btn.MenuText;
                            }
                            MenuItem menuItem = null;
                            if (btn.Enable)
                            {
                                menuItem = new MenuItem(text, OnMenuItemClick);
                                menuItem.Tag = btn;
                                toolBar.Renderer.SetEnable(menuItem, true);
                            }
                            else
                            {
                                menuItem = new MenuItem(text);
                                toolBar.Renderer.SetEnable(menuItem, false);
                            }
                            toolBar.Renderer.SetImageIndex(menuItem, btn.ImageIndex);
                            childMenu.MenuItems.Add(menuItem);
                            if (btn.DropDownMenu != null)
                            {
                                foreach (MenuItem item in btn.DropDownMenu.MenuItems)
                                {
                                    MenuItem newMenuItem = new MenuItem(item.Text, OnMenuSubItemClick);
                                    newMenuItem.Tag = item;
                                    menuItem.MenuItems.Add(newMenuItem);
                                }
                            }
                        }
                    }
                }
            }
            if (band.Control != null && band.Control is MenuBox)
            {
                MenuBox menuBar = band.Control as MenuBox;
                NativeMethods.RECT lpRect = new NativeMethods.RECT();
                UnsafeNativeMethods.GetClientRect(new HandleRef(band.Control, band.Control.Handle), ref lpRect);
                int count = (int)UnsafeNativeMethods.SendMessage(new HandleRef(band.Control, band.Control.Handle), NativeMethods.TB_BUTTONCOUNT, IntPtr.Zero, IntPtr.Zero);
                if (count != menuBar.itemsCount) throw new ArgumentOutOfRangeException("count");
                for (int i = 0; i < count; i++)
                {
                    NativeMethods.RECT brc = new NativeMethods.RECT();
                    UnsafeNativeMethods.SendMessage(new HandleRef(band.Control, band.Control.Handle), NativeMethods.TB_GETITEMRECT, i, ref brc);
                    if (brc.right >= (lpRect.right - lpRect.left))
                    {
                        MenuBoxItem menuBarItem = menuBar.Items[i];
                        MenuItem menuItem = new MenuItem(menuBarItem.Text);
                        childMenu.MenuItems.Add(menuItem);
                        if (menuBarItem.DropDownMenu != null)
                        {
                            foreach (MenuItem item in menuBarItem.DropDownMenu.MenuItems)
                            {
                                MenuItem newMenuItem = new MenuItem(item.Text, OnMenuSubItemClick);
                                newMenuItem.Tag = item;
                                menuItem.MenuItems.Add(newMenuItem);
                            }
                        }
                    }
                }
            }
            childMenu.Show(this, new Point(nrch.rc.left, nrch.rc.bottom));
        }

        private void OnMenuItemClick(object sender, EventArgs e)
        {
            if (MenuItemClick != null)
            {
                MenuItem item = (MenuItem)sender;
                MenuItemClick(this, (ToolBoxButton)item.Tag);
            }
        }

        private void OnMenuSubItemClick(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)((MenuItem)sender).Tag;
            item.PerformClick();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_NOTIFY + NativeMethods.WM_REFLECT:
                    WmReflectNotify(ref m);
                    break;
                case NativeMethods.WM_SETCURSOR:
                    DefWndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        public int RowCount
        {
            get
            {
                if (IsHandleCreated)
                    return (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_GETROWCOUNT, IntPtr.Zero, IntPtr.Zero);
                return 1;
            }
        }
        public bool Lock
        {
            set
            {
                NativeMethods.REBARBANDINFO bandINFO = new NativeMethods.REBARBANDINFO();
                bandINFO.cbSize = Marshal.SizeOf(typeof(NativeMethods.REBARBANDINFO));
                bandINFO.fMask = NativeMethods.RBBIM_STYLE;
                if (IsHandleCreated)
                {
                    if (Marshal.SystemDefaultCharSize == 1)
                    {
                        int count = (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_GETBANDCOUNT, IntPtr.Zero, IntPtr.Zero);
                        for (int i = 0; i < count; i++)
                        {
                            UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_GETBANDINFOA, i, ref bandINFO);
                            if (value)
                                bandINFO.fStyle |= NativeMethods.RBBS_NOGRIPPER;
                            else
                                bandINFO.fStyle &= ~NativeMethods.RBBS_NOGRIPPER;

                            UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBANDINFOA, i, ref bandINFO);
                        }
                    }
                    else
                    {
                        int count = (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_GETBANDCOUNT, IntPtr.Zero, IntPtr.Zero);
                        for (int i = 0; i < count; i++)
                        {
                            UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_GETBANDINFOW, i, ref bandINFO);
                            if (value)
                                bandINFO.fStyle |= NativeMethods.RBBS_NOGRIPPER;
                            else
                                bandINFO.fStyle &= ~NativeMethods.RBBS_NOGRIPPER;
                            UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBANDINFOW, i, ref bandINFO);
                        }
                    }
                }
            }
        }
        private Color backColor = SystemColors.Control;
        public new Color BackColor
        {
            get
            {
                return backColor;
            }
            set
            {
                if (backColor != value && IsHandleCreated)
                {
                    backColor = value;
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETBKCOLOR, IntPtr.Zero, ColorTranslator.ToWin32(backColor));
                }
            }
        }

        private Color foreColor = SystemColors.WindowText;
        public new Color ForeColor
        {
            get
            {
                return foreColor;
            }
            set
            {
                if (foreColor != value && IsHandleCreated)
                {
                    foreColor = value;
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_SETTEXTCOLOR, IntPtr.Zero, ColorTranslator.ToWin32(backColor));

                }
            }
        }

        public int GetRowHeight(int index)
        {
            if (IsHandleCreated)
                return (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_GETROWHEIGHT, index, 0);
            else
                return -1;
        }

        public RebarBand GetBandAt(Point point)
        {
            NativeMethods.RBHITTESTINFO hitTest = new NativeMethods.RBHITTESTINFO();
            hitTest.pt = point;
            if (IsHandleCreated)
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_HITTEST, IntPtr.Zero, ref hitTest);
            if (hitTest.iBand != -1) return Bands[hitTest.iBand];
            return null;
        }
        public int GetBandIndexAt(Point point)
        {
            NativeMethods.RBHITTESTINFO hitTest = new NativeMethods.RBHITTESTINFO();
            hitTest.pt = point;
            if (IsHandleCreated)
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_HITTEST, IntPtr.Zero, ref hitTest);
            return hitTest.iBand;
        }
        public Rectangle GetBandBounds(int index)
        {
            NativeMethods.RECT rect = new NativeMethods.RECT();
            if (IsHandleCreated)
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.RB_GETRECT, index, ref rect);
            return rect.Rectangle;
        }
    }
}
