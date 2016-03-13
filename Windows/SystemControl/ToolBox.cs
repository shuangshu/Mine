using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Diagnostics;

namespace Windows.SystemControl
{
    public class TMetrics
    {
        private int buttonWidth;
        private int buttonHeight;
        private int toolBarWidth;
        private int toolBarHeight;
        private int spaceWidth;
        private int spaceHeight;

        public TMetrics(int buttonWidth, int buttonHeight, int toolBarWidth, int toolBarHeight, int spaceWidth, int spaceHeight)
        {
            this.buttonWidth = buttonWidth;
            this.buttonHeight = buttonHeight;
            this.toolBarWidth = toolBarWidth;
            this.toolBarHeight = toolBarHeight;
            this.spaceWidth = spaceWidth;
            this.spaceHeight = spaceHeight;
        }

        public TMetrics()
        { }

        public int ButtonWidth
        {
            get { return buttonHeight; }
            set { buttonHeight = value; }
        }

        public int ButtonHeight
        {
            get { return buttonHeight; }
            set { buttonHeight = value; }
        }

        public int ToolBarWidth
        {
            get { return toolBarWidth; }
            set { toolBarWidth = value; }
        }

        public int ToolBarHeight
        {
            get { return toolBarHeight; }
            set { toolBarHeight = value; }
        }

        public int SpaceWidth
        {
            get { return spaceWidth; }
            set { spaceWidth = value; }
        }

        public int SpaceHeight
        {
            get { return spaceHeight; }
            set { spaceHeight = value; }
        }

        public override string ToString()
        {
            StringBuilder bulid = new StringBuilder();
            bulid.Append("ButtonWidth: " + ButtonWidth.ToString() + "\n");
            bulid.Append("ButtonHeight: " + ButtonHeight.ToString() + "\n");
            bulid.Append("ToolBarWidth: " + ToolBarWidth.ToString() + "\n");
            bulid.Append("ToolBarHeight: " + ToolBarHeight.ToString() + "\n");
            bulid.Append("SpaceWidth: " + SpaceWidth.ToString() + "\n");
            bulid.Append("SpaceHeight: " + SpaceHeight.ToString() + "\n");
            return bulid.ToString();
        }
    }
    [ComVisible(true), ClassInterface(ClassInterfaceType.AutoDispatch)]
    public class ToolBox : Control
    {

        private int hotItem = -1;
        public event TToolBarButtonClickEventHandle ButtonClick;
        internal ToolBoxButton[] buttons = null;
        internal int buttonsCount = 0;
        private MenuItemRender renderer = null;
        public MenuItemRender Renderer
        {
            get { return renderer; }
            set { renderer = value; }
        }
        private ToolBoxButtonCollection buttonsCollection = null;
        public ToolBoxButtonCollection Buttons
        {
            get
            {
                if (buttonsCollection == null)
                    return new ToolBoxButtonCollection(this);
                else
                    return buttonsCollection;
            }
        }
        private ImageList imageList;
        public ImageList ImageList
        {
            get { return imageList; }
            set
            {
                if (imageList != value)
                {
                    imageList = value;
                    renderer.ImageList = imageList;
                    RecreateHandle();
                }
            }
        }
        private bool ownerDraw = false;
        public bool OwnerDraw
        {
            get
            {
                return ownerDraw;
            }

            set
            {
                if (OwnerDraw != value)
                {
                    ownerDraw = value;
                    Invalidate(true);
                }
            }
        }
        private BorderStyle borderStyle = BorderStyle.None;
        public BorderStyle BorderStyle
        {
            get
            {
                return borderStyle;
            }

            set
            {
                if (borderStyle != value)
                {
                    borderStyle = value;
                    RecreateHandle();
                }
            }
        }
        public static bool IsEnumValid(Enum enumValue, int value, int minValue, int maxValue)
        {
            bool valid = (value >= minValue) && (value <= maxValue);
            return valid;
        }

        private TBAppearance appearance = TBAppearance.Transparent | TBAppearance.Flat | TBAppearance.List;
        public TBAppearance Appearance
        {
            get { return appearance; }
            set
            {
                if (value != appearance)
                {
                    appearance = value;
                    RecreateHandle();
                }
            }
        }

        private TMetrics metrics;
        public TMetrics Metrics
        {
            get
            {
                NativeMethods.TBMETRICS ptbMetrics = new NativeMethods.TBMETRICS();
                ptbMetrics.cbSize = Marshal.SizeOf(typeof(NativeMethods.TBMETRICS));
                ptbMetrics.dwMask = NativeMethods.TBMF_PAD | NativeMethods.TBMF_BARPAD | NativeMethods.TBMF_BUTTONSPACING;
                if (IsHandleCreated)
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_GETMETRICS, IntPtr.Zero, ref ptbMetrics);
                if (metrics == null)
                    metrics = new TMetrics(ptbMetrics.cxPad, ptbMetrics.cyPad, ptbMetrics.cxBarPad, ptbMetrics.cyBarPad, ptbMetrics.cxButtonSpacing, ptbMetrics.cyButtonSpacing);
                return metrics;
            }
            set
            {
                if (value == null) throw new ArgumentNullException("value");
                metrics = value;
                NativeMethods.TBMETRICS ptbMetrics = new NativeMethods.TBMETRICS();
                ptbMetrics.cbSize = Marshal.SizeOf(typeof(NativeMethods.TBMETRICS));
                ptbMetrics.dwMask = NativeMethods.TBMF_PAD | NativeMethods.TBMF_BARPAD | NativeMethods.TBMF_BUTTONSPACING;
                ptbMetrics.cxPad = metrics.ButtonWidth;
                ptbMetrics.cyPad = metrics.ButtonHeight;
                ptbMetrics.cxBarPad = metrics.ToolBarWidth;
                ptbMetrics.cyBarPad = metrics.ToolBarHeight;
                ptbMetrics.cxButtonSpacing = metrics.SpaceWidth;
                ptbMetrics.cyButtonSpacing = metrics.SpaceHeight;
                if (IsHandleCreated)
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_GETMETRICS, IntPtr.Zero, ref ptbMetrics);
            }
        }

        private Control acceptMessageWindow;
        public Control AcceptMessageWindow
        {
            get { return acceptMessageWindow; }
            set { acceptMessageWindow = value; }
        }

        public ToolBox()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, false);
            this.SetStyle(ControlStyles.StandardClick, false);
            this.SetStyle(ControlStyles.FixedWidth, false);
            this.Dock = DockStyle.None;
            this.buttonsCollection = new ToolBoxButtonCollection(this);
            this.renderer = new MenuItemRender();
        }

        private Size buttonSize = new Size(20, 22);
        public Size ButtonSize
        {
            get
            {
                if (IsHandleCreated)
                {
                    int result = (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_GETBUTTONSIZE, 0, 0);
                    if (result > 0)
                    {
                        buttonSize.Width = NativeMethods.Util.LOWORD(result);
                        buttonSize.Height = NativeMethods.Util.HIWORD(result);
                    }
                }
                return buttonSize;
            }
            set
            {
                if (value.Width < 0 || value.Height < 0)
                    throw new ArgumentOutOfRangeException("ButtonSize");
                if (IsHandleCreated)
                {
                    if (buttonSize != value)
                    {
                        buttonSize = value;
                        UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONSIZE, IntPtr.Zero, NativeMethods.Util.MAKELONG(buttonSize.Width, buttonSize.Height));
                        RecreateHandle();
                        OnResize(EventArgs.Empty);
                    }
                }
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(100, 23);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if ((appearance & TBAppearance.Wrapable) != 0)
                this.Height = this.Rows * ButtonSize.Height;
            else
                this.Height = ButtonSize.Height;
        }
        protected override void CreateHandle()
        {
            if (!RecreatingHandle)
            {
                IntPtr userCookie = NativeCOM.ThemingScope.Activate();
                try
                {
                    NativeMethods.INITCOMMONCONTROLSEX icc = new NativeMethods.INITCOMMONCONTROLSEX();
                    icc.dwICC = NativeMethods.ICC_BAR_CLASSES;
                    UnsafeNativeMethods.InitCommonControlsEx(icc);
                }
                finally
                {
                    NativeCOM.ThemingScope.Deactivate(userCookie);
                }
            }
            base.CreateHandle();
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

        private bool allowReszie = true;
        public bool AllowResize
        {
            get { return allowReszie; }
            set
            {
                if (allowReszie != value)
                {
                    allowReszie = value;
                    RecreateHandle();
                }
            }
        }

        private bool dropDownArrows = true;
        public bool DropDownArrows
        {
            get
            {
                return dropDownArrows;
            }
            set
            {
                if (dropDownArrows != value)
                {
                    dropDownArrows = value;
                    RecreateHandle();
                }
            }
        }

        private bool clippedButtons = true;
        /// <summary>
        /// 默认显示的
        /// </summary>
        public bool ShowClippedButtons
        {
            get { return clippedButtons; }
            set
            {
                if (clippedButtons != value)
                {
                    clippedButtons = value;
                    RecreateHandle();
                }
            }
        }

        public Size ImageSize
        {
            get
            {
                Size size = Size.Empty;
                if (imageList != null)
                    size = imageList.ImageSize;
                return size;
            }
        }

        private bool divider = false;
        public bool Divider
        {
            get
            {
                return divider;
            }

            set
            {
                if (divider != value)
                {
                    divider = value;
                    RecreateHandle();
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassName = NativeMethods.WC_TOOLBAR;
                cp.Style |= NativeMethods.CCS_NOPARENTALIGN | NativeMethods.CCS_NORESIZE;
                if (!AllowResize) cp.Style |= NativeMethods.CCS_NORESIZE;
                cp.ExStyle &= (~NativeMethods.WS_EX_CLIENTEDGE);
                cp.Style &= (~NativeMethods.WS_BORDER);
                cp.Style |= NativeMethods.CCS_NODIVIDER | NativeMethods.TBSTYLE_TOOLTIPS;
                if (!Divider) cp.Style |= NativeMethods.CCS_NODIVIDER;
                switch (borderStyle)
                {
                    case BorderStyle.Fixed3D:
                        cp.ExStyle |= NativeMethods.WS_EX_CLIENTEDGE;
                        break;
                    case BorderStyle.FixedSingle:
                        cp.Style |= NativeMethods.WS_BORDER;
                        break;
                }
                cp.Style &= ~NativeMethods.TBSTYLE_FLAT;
                cp.Style &= ~NativeMethods.TBSTYLE_LIST;
                cp.Style &= ~NativeMethods.TBSTYLE_TRANSPARENT;
                cp.Style &= ~NativeMethods.TBSTYLE_WRAPPABLE;
                if ((appearance & TBAppearance.Flat) != 0)
                    cp.Style |= NativeMethods.TBSTYLE_FLAT;

                if ((appearance & TBAppearance.List) != 0)
                    cp.Style |= NativeMethods.TBSTYLE_LIST;

                if ((appearance & TBAppearance.Transparent) != 0)
                    cp.Style |= NativeMethods.TBSTYLE_TRANSPARENT;

                if ((appearance & TBAppearance.Wrapable) != 0)
                    cp.Style |= NativeMethods.TBSTYLE_WRAPPABLE;

                if (allowDrag)
                    cp.Style |= NativeMethods.TBSTYLE_REGISTERDROP;
                return cp;
            }
        }
        public int Rows
        {
            get
            {
                int rows = 1;
                if (IsHandleCreated)
                    rows = (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_GETROWS, IntPtr.Zero, IntPtr.Zero);
                return rows;
            }
            set
            {
                NativeMethods.RECT rect = new NativeMethods.RECT();
                if (Rows != value)
                {
                    if (IsHandleCreated)
                    {
                        UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETROWS, NativeMethods.Util.MAKELPARAM(value, 1), ref rect);
                    }
                }
            }
        }
        internal void NativeUpdateButtonAt(ToolBoxButton button, int index)
        {
            if (IsHandleCreated)
            {
                button.owner = this;
                buttons[index] = button;
                NativeMethods.TBBUTTONINFO btnINFO = button.GetTBBUTTONINFO(index);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_SETBUTTONINFO, index, ref btnINFO);
            }
        }
        internal void NativeInsert(ToolBoxButton value, int index)
        {
            if (value == null) throw new ArgumentNullException("value");
            if (IsHandleCreated)
            {
                if ((value.Appearance & TBBAppearance.Separator) != 0)
                {
                    value.Width = 0;
                }
                else
                {
                    Size edge = SystemInformation.Border3DSize;
                    Size size = Size.Empty;
                    if (!string.IsNullOrEmpty(value.Text))
                    {
                        using (Graphics g = Graphics.FromHwnd(Handle))
                        {
                            if (!string.IsNullOrEmpty(value.Text))
                            {
                                size = Size.Ceiling(g.MeasureString(value.Text, Font));
                                size.Width += 10;
                            }
                        }
                    }
                    if ((appearance & TBAppearance.List) != 0)//如果有List属性
                        value.Width = size.Width + ImageSize.Width + edge.Width * 3;
                    else
                        value.Width = size.Width > ImageSize.Width ? size.Width + edge.Width * 4 : ImageSize.Width + edge.Width * 4;
                    if ((value.Appearance & TBBAppearance.DropDown) != 0)
                        value.Width += 16;
                    if ((value.Appearance & TBBAppearance.WholeDropDown) != 0)
                        value.Width += 8;
                }
                NativeMethods.TBBUTTON tbbutton = value.GetTBBUTTON(index);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_INSERTBUTTON, index, ref tbbutton);
                NativeMethods.TBBUTTONINFO tbbuttonINFO = value.GetTBBUTTONINFO(index);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONINFO, index, ref tbbuttonINFO);
            }
        }
        internal void NativeRemoveAt(int index)
        {
            if (IsHandleCreated)
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_DELETEBUTTON, index, IntPtr.Zero);
        }

        protected virtual object[] GetButtons()
        {
            ToolBoxButton[] result = new ToolBoxButton[buttonsCount];
            if (buttonsCount > 0)
                Array.Copy(buttons, 0, result, 0, buttonsCount);
            return result;
        }
        protected virtual object[] GetButtons(Type baseType)
        {
            object[] result = (object[])Array.CreateInstance(baseType, buttonsCount);
            if (buttonsCount > 0) Array.Copy(buttons, 0, result, 0, buttonsCount);
            return result;
        }
        public ToolBoxButton[] GetTToolBarButtons()
        {
            return (ToolBoxButton[])GetButtons();
        }

        protected new void RecreateHandle()
        {
            ToolBoxButton[] btns = GetTToolBarButtons();
            Buttons.Clear();
            buttons = null;
            buttonsCount = 0;

            base.RecreateHandle();

            for (int i = 0; i < btns.Length; i++)
                Buttons.Add(btns[i]);
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (IsHandleCreated)
            {
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_BUTTONSTRUCTSIZE, Marshal.SizeOf(typeof(NativeMethods.TBBUTTON)), 0);
                if (DropDownArrows)
                {
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETEXTENDEDSTYLE, 0, NativeMethods.TBSTYLE_EX_DRAWDDARROWS);
                }
                if (!ShowClippedButtons)
                {
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETEXTENDEDSTYLE, 0, NativeMethods.TBSTYLE_EX_HIDECLIPPEDBUTTONS);
                }
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBITMAPSIZE, IntPtr.Zero, NativeMethods.Util.MAKELONG(16, 15));
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONSIZE, IntPtr.Zero, NativeMethods.Util.MAKELONG(22, 22));
                if (ImageList != null)
                {
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETIMAGELIST, 0, ImageList.Handle);
                }
                else
                {
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETIMAGELIST, 0, IntPtr.Zero);
                }
                if (buttons != null)
                {
                    for (int i = 0; i < buttonsCount; i++)
                    {
                        NativeInsert(buttons[i], i);
                    }
                }
            }
            OnResize(EventArgs.Empty);
        }
        private int updateCount = 0;
        public bool IsUpdating()
        {
            return (this.updateCount > 0);
        }

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

        private bool handleKeyMessage = false;
        public bool HandleKeyMessage
        {
            get { return handleKeyMessage; }
            set { handleKeyMessage = value; }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_COMMAND + NativeMethods.WM_REFLECT:
                    WmReflectCommand(ref m);
                    break;
                case NativeMethods.WM_NOTIFY:
                case NativeMethods.WM_NOTIFY + NativeMethods.WM_REFLECT:
                    WmReflectNotify(ref m);
                    break;
                case NativeMethods.WM_KEYDOWN:
                    {
                        if (HandleKeyMessage) base.WndProc(ref m);
                        else
                        {
                            if (AcceptMessageWindow != null && AcceptMessageWindow.Handle != IntPtr.Zero)
                            {
                                UnsafeNativeMethods.SendMessage(new HandleRef(this, AcceptMessageWindow.Handle), NativeMethods.WM_KEYDOWN, m.WParam, m.LParam);
                            }
                        }
                    }
                    break;
                case NativeMethods.WM_KEYUP:
                    {
                        if (HandleKeyMessage) base.WndProc(ref m);
                        else
                        {
                            if (AcceptMessageWindow != null && AcceptMessageWindow.Handle != IntPtr.Zero)
                            {
                                UnsafeNativeMethods.SetFocus(new HandleRef(this, AcceptMessageWindow.Handle));
                                UnsafeNativeMethods.SendMessage(new HandleRef(this, AcceptMessageWindow.Handle), NativeMethods.WM_KEYUP, m.WParam, m.LParam);
                            }
                        }
                    }
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (imageList != null) imageList = null;
                if (buttonsCollection != null)
                {
                    ToolBoxButton[] buttonCopy = new ToolBoxButton[buttonsCollection.Count];
                    ((ICollection)buttonsCollection).CopyTo(buttonCopy, 0);
                    buttonsCollection.Clear();
                    foreach (ToolBoxButton b in buttonCopy)
                        b.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void WmReflectCommand(ref Message m)
        {
            int index = NativeMethods.Util.LOWORD(m.WParam);
            ToolBoxButton button = buttonsCollection[index];
            if (button != null)
            {
                if (ButtonClick != null)
                {
                    ButtonClick(this, new ToolBoxButtonClickEventArgs(button));
                }
            }
            base.WndProc(ref m);
            ResetMouseEventArgs();
        }
        private void WmReflectNotify(ref Message m)
        {
            NativeMethods.NMHDR note = (NativeMethods.NMHDR)m.GetLParam(typeof(NativeMethods.NMHDR));
            switch (note.code)
            {
                case NativeMethods.NM_CUSTOMDRAW:
                    WmNotifyCustomDraw(ref m);
                    break;
                case NativeMethods.TBN_BEGINDRAG:
                    WmNotifyBeginDrag(ref m);
                    break;
                case NativeMethods.TBN_ENDDRAG:
                    WmNotifyEndDrag(ref m);
                    break;
                case NativeMethods.TBN_DRAGOUT:
                    WmNotifyDragOut(ref m);
                    break;
                case NativeMethods.TBN_GETOBJECT:
                    WmNotifyGetObject(ref m);
                    break;
                case NativeMethods.TBN_DROPDOWN:
                    WmNotifyDropDown(ref m);
                    break;
                case NativeMethods.TBN_HOTITEMCHANGE:
                    WmNotifyHotItemChange(ref m);
                    break;
                case NativeMethods.TBN_QUERYINSERT:
                    m.Result = (IntPtr)1;
                    break;
                case NativeMethods.TTN_NEEDTEXTA:
                    WmNotifyNeedTextA(ref m);
                    m.Result = (IntPtr)1;
                    return;
                case NativeMethods.TTN_NEEDTEXTW:
                    WmNotifyNeedTextW(ref m);
                    m.Result = (IntPtr)1;
                    return;
            }
        }

        unsafe private void WmNotifyCustomDraw(ref Message m)
        {
            m.Result = (IntPtr)NativeMethods.CDRF_DODEFAULT;
            NativeMethods.NMTBCUSTOMDRAW* nmcd = (NativeMethods.NMTBCUSTOMDRAW*)m.LParam;
            switch (nmcd->nmcd.dwDrawStage)
            {
                case NativeMethods.CDDS_PREPAINT:
                    {
                        //Debug.WriteLine("CDDS_PREPAINT");
                        if (ownerDraw)
                        {
                            m.Result = (IntPtr)NativeMethods.CDRF_NOTIFYITEMDRAW;
                            return;
                        }
                    }
                    break;
                case NativeMethods.CDDS_ITEMPREPAINT:
                    {
                        //Debug.WriteLine("CDDS_ITEMPREPAINT");
                        //m.Result = (IntPtr)NativeMethods.CDRF_SKIPDEFAULT;
                    }
                    break;
                default:
                    break;
            }
        }

        private void WmNotifyNeedTextW(ref Message m)
        {
            NativeMethods.TOOLTIPTEXT ttt = (NativeMethods.TOOLTIPTEXT)m.GetLParam(typeof(NativeMethods.TOOLTIPTEXT));
            int commandID = (int)ttt.hdr.idFrom;
            ToolBoxButton tbb = (ToolBoxButton)buttons[commandID];
            if (tbb != null && tbb.ToolTipText != null)
                ttt.lpszText = tbb.ToolTipText;
            else
                ttt.lpszText = null;
            ttt.hinst = IntPtr.Zero;
            Marshal.StructureToPtr(ttt, m.LParam, false);
        }
        private void WmNotifyNeedTextA(ref Message m)
        {

            NativeMethods.TOOLTIPTEXTA ttt = (NativeMethods.TOOLTIPTEXTA)m.GetLParam(typeof(NativeMethods.TOOLTIPTEXTA));
            int commandID = (int)ttt.hdr.idFrom;
            ToolBoxButton tbb = (ToolBoxButton)buttons[commandID];
            if (tbb != null && tbb.ToolTipText != null)
                ttt.lpszText = tbb.ToolTipText;
            else
                ttt.lpszText = null;
            ttt.hinst = IntPtr.Zero;
            Marshal.StructureToPtr(ttt, m.LParam, false);
        }
        private void WmNotifyGetObject(ref Message m)
        {
            //Debug.WriteLine("WmNotifyGetObject");
        }
        private void WmNotifyBeginDrag(ref Message m)
        {
            NativeMethods.NMTOOLBAR nmTB = (NativeMethods.NMTOOLBAR)m.GetLParam(typeof(NativeMethods.NMTOOLBAR));
            //Debug.WriteLine("WmNotifyBeginDrag");
        }
        private void WmNotifyEndDrag(ref Message m)
        {
            NativeMethods.NMTOOLBAR nmTB = (NativeMethods.NMTOOLBAR)m.GetLParam(typeof(NativeMethods.NMTOOLBAR));
            //Debug.WriteLine("WmNotifyEndDrag");
        }
        private void WmNotifyDragOut(ref Message m)
        {
            NativeMethods.NMTOOLBAR nmTB = (NativeMethods.NMTOOLBAR)m.GetLParam(typeof(NativeMethods.NMTOOLBAR));
            //Debug.WriteLine("WmNotifyDragOut");
        }
        private void WmNotifyHotItemChange(ref Message m)
        {
            NativeMethods.NMTBHOTITEM nmTbHotItem = (NativeMethods.NMTBHOTITEM)m.GetLParam(typeof(NativeMethods.NMTBHOTITEM));
            if (NativeMethods.HICF_ENTERING == (nmTbHotItem.dwFlags & NativeMethods.HICF_ENTERING))
                this.hotItem = nmTbHotItem.idNew;
            else if (NativeMethods.HICF_LEAVING == (nmTbHotItem.dwFlags & NativeMethods.HICF_LEAVING))
                this.hotItem = -1;
            else if (NativeMethods.HICF_MOUSE == (nmTbHotItem.dwFlags & NativeMethods.HICF_MOUSE))
                this.hotItem = nmTbHotItem.idNew;
            else if (NativeMethods.HICF_ARROWKEYS == (nmTbHotItem.dwFlags & NativeMethods.HICF_ARROWKEYS))
                this.hotItem = nmTbHotItem.idNew;
            else if (NativeMethods.HICF_ACCELERATOR == (nmTbHotItem.dwFlags & NativeMethods.HICF_ACCELERATOR))
                this.hotItem = nmTbHotItem.idNew;
            else if (NativeMethods.HICF_DUPACCEL == (nmTbHotItem.dwFlags & NativeMethods.HICF_DUPACCEL))
                this.hotItem = nmTbHotItem.idNew;
            else if (NativeMethods.HICF_RESELECT == (nmTbHotItem.dwFlags & NativeMethods.HICF_RESELECT))
                this.hotItem = nmTbHotItem.idNew;
            else if (NativeMethods.HICF_LMOUSE == (nmTbHotItem.dwFlags & NativeMethods.HICF_LMOUSE))
                this.hotItem = nmTbHotItem.idNew;
            else if (NativeMethods.HICF_TOGGLEDROPDOWN == (nmTbHotItem.dwFlags & NativeMethods.HICF_TOGGLEDROPDOWN))
                this.hotItem = nmTbHotItem.idNew;
        }
        private void WmNotifyDropDown(ref Message m)
        {
            NativeMethods.NMTOOLBAR nmTB = (NativeMethods.NMTOOLBAR)m.GetLParam(typeof(NativeMethods.NMTOOLBAR));
            ToolBoxButton tbb = buttons[nmTB.iItem];
            Menu menu = tbb.DropDownMenu;
            if (menu != null)
            {
                NativeMethods.RECT rc = new NativeMethods.RECT();
                NativeMethods.TPMPARAMS tpm = new NativeMethods.TPMPARAMS();
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_GETRECT, nmTB.iItem, ref rc);

                if ((menu.GetType()).IsAssignableFrom(typeof(ContextMenu)))
                    ((ContextMenu)menu).Show(this, new Point(rc.left, rc.bottom));
                else
                {
                    UnsafeNativeMethods.MapWindowPoints(new HandleRef(nmTB.hdr, nmTB.hdr.hwndFrom), NativeMethods.NullHandleRef, ref rc, 2);
                    tpm.rcExclude_left = rc.left;
                    tpm.rcExclude_top = rc.top;
                    tpm.rcExclude_right = rc.right;
                    tpm.rcExclude_bottom = rc.bottom;
                    UnsafeNativeMethods.TrackPopupMenuEx(new HandleRef(menu, menu.Handle), NativeMethods.TPM_LEFTALIGN | NativeMethods.TPM_LEFTBUTTON | NativeMethods.TPM_VERTICAL, rc.left, rc.bottom, new HandleRef(this, Handle), tpm);
                }
            }
        }

        /// <summary>
        /// 获得所有可见或者分隔符按钮的总大小
        /// </summary>
        public Size TotalSize
        {
            get
            {
                NativeMethods.SIZE size = new NativeMethods.SIZE();
                if (Handle != IntPtr.Zero)
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_GETMAXSIZE, IntPtr.Zero, size);
                return size.ToSize();
            }
        }

        /// <summary>
        /// 设置第一个按钮的缩进
        /// </summary>
        public int Indent
        {
            set
            {
                if (IsHandleCreated)
                {
                    if (value < 0) throw new ArgumentException("value");
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETINDENT, value, IntPtr.Zero);
                }
            }
        }

        /// <summary>
        /// 获得Hot按钮索引
        /// </summary>
        public int HotIndex
        {
            get
            {
                if (IsHandleCreated)
                    return (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_GETHOTITEM, IntPtr.Zero, IntPtr.Zero);
                return -1;
            }
            set
            {
                if (IsHandleCreated)
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_SETHOTITEM, value, IntPtr.Zero);
            }
        }

        public ToolBoxButton GetButtonAt(Point point)
        {
            int index = -1;
            if (IsHandleCreated)
                index = UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_HITTEST, IntPtr.Zero, ref point);
            if (index < 0) return null;
            else return Buttons[index];
        }

        /// <summary>
        /// 跟新指定按钮状态
        /// </summary>
        /// <param name="index"></param>
        /// <param name="?"></param>
        public void UpdateState(TBBState state, int index, bool flag)
        {
            if (IsHandleCreated)
            {
                switch (state)
                {
                    case TBBState.Checked:
                        {
                            if (index < 0 && index > buttonsCount) throw new ArgumentException("Index");
                            UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_CHECKBUTTON, index, NativeMethods.Util.MAKELONG(flag ? 1 : 0, 0));
                        }
                        break;
                    case TBBState.Enabled:
                        {
                            if (index < 0 && index > buttonsCount) throw new ArgumentException("Index");
                            UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_ENABLEBUTTON, index, NativeMethods.Util.MAKELONG(flag ? 1 : 0, 0));
                        }
                        break;
                    case TBBState.Hidden:
                        {
                            if (index < 0 && index > buttonsCount) throw new ArgumentException("Index");
                            UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_HIDEBUTTON, index, NativeMethods.Util.MAKELONG(flag ? 1 : 0, 0));
                        }
                        break;
                    case TBBState.Pressed:
                        {
                            if (index < 0 && index > buttonsCount) throw new ArgumentException("Index");
                            UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_PRESSBUTTON, index, NativeMethods.Util.MAKELONG(flag ? 1 : 0, 0));
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// 设置控件Padding大小
        /// </summary>
        public new Size Padding
        {
            get
            {
                Size size = new Size();
                if (IsHandleCreated)
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETPADDING, IntPtr.Zero, NativeMethods.Util.MAKELPARAM(size.Width, size.Height));
                return size;
            }
            set
            {
                Size size = new Size();
                if (IsHandleCreated)
                {
                    int reslut = (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_GETPADDING, IntPtr.Zero, NativeMethods.Util.MAKELPARAM(size.Width, size.Height));
                    size.Width = NativeMethods.Util.LOWORD(reslut);
                    size.Height = NativeMethods.Util.HIWORD(reslut);
                }
            }
        }
    }
    [Flags]
    public enum TBAppearance
    {
        Flat = 1,
        List = 2,
        Transparent = 4,
        Wrapable = 8
    }
    [Flags]
    public enum TBBState
    {
        Checked = 1,
        Enabled = 2,
        Pressed = 4,
        Hidden = 8
    }
    [Flags]
    public enum TBBAppearance
    {
        Check = 1,
        Button = 2,
        DropDown = 4,
        Separator = 8,
        WholeDropDown = 16
    }
}
