using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Security.Permissions;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Windows.SystemControl
{
    public class MenuBox : Control
    {
        private int hotItem = -1;
        private IntPtr messageHookHandle = IntPtr.Zero;
        private IntPtr hFont = IntPtr.Zero;
        private MenuBoxItemCollection itemsCollection = null;
        public MenuBoxItemCollection Items
        {
            get
            {
                if (itemsCollection == null)
                    return new MenuBoxItemCollection(this);
                else
                    return itemsCollection;
            }
        }

        internal int itemsCount = 0;
        internal MenuBoxItem[] items = null;

        private int hightLightColor = 0;
        private int hightLightTextColor = 0;

        private int cpopupIndex = -1;//当前弹出项
        private int npopupIndex = -1;//下一个弹出项

        private Point point = Point.Empty;

        public MenuBox()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, false);
            this.Dock = DockStyle.Top;
            this.Height = 20;
            this.itemsCollection = new MenuBoxItemCollection(this);
            this.hightLightColor = UnsafeNativeMethods.GetSysColor(NativeMethods.COLOR_HIGHLIGHT);
            this.hightLightTextColor = UnsafeNativeMethods.GetSysColor(NativeMethods.COLOR_HIGHLIGHTTEXT);
        }

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

        protected override void CreateHandle()
        {
            if (!this.RecreatingHandle)
            {
                NativeMethods.INITCOMMONCONTROLSEX icc = new NativeMethods.INITCOMMONCONTROLSEX();
                icc.dwICC = NativeMethods.ICC_BAR_CLASSES | NativeMethods.ICC_COOL_CLASSES;
                UnsafeNativeMethods.InitCommonControlsEx(icc);
            }
            base.CreateHandle();
        }
        protected override CreateParams CreateParams
        {
            [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassName = NativeMethods.WC_TOOLBAR;
                cp.Style = NativeMethods.WS_CHILD | NativeMethods.WS_VISIBLE | NativeMethods.WS_CLIPCHILDREN | NativeMethods.WS_CLIPSIBLINGS;
                cp.Style |= NativeMethods.CCS_NODIVIDER | NativeMethods.CCS_NORESIZE | NativeMethods.CCS_NOPARENTALIGN;
                cp.Style |= NativeMethods.TBSTYLE_TOOLTIPS | NativeMethods.TBSTYLE_FLAT | NativeMethods.TBSTYLE_LIST | NativeMethods.TBSTYLE_TRANSPARENT;
                return cp;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (IsHandleCreated)
            {
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_BUTTONSTRUCTSIZE, Marshal.SizeOf(typeof(NativeMethods.TBBUTTON)), 0);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETEXTENDEDSTYLE, 0, NativeMethods.TBSTYLE_EX_HIDECLIPPEDBUTTONS);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETEXTENDEDSTYLE, 0, NativeMethods.TBSTYLE_EX_DOUBLEBUFFER);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETIMAGELIST, 0, IntPtr.Zero);
                hFont = UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.WM_GETFONT, IntPtr.Zero, IntPtr.Zero);
                if (items != null)
                {
                    int count = itemsCount;
                    for (int i = 0; i < count; i++)
                        NativeInsert(items[i], i);
                }
            }
        }
        protected virtual object[] GetItems()
        {
            MenuBoxItem[] result = new MenuBoxItem[itemsCount];
            if (itemsCount > 0)
                Array.Copy(items, 0, result, 0, itemsCount);
            return result;
        }
        protected virtual object[] GetItems(Type baseType)
        {
            object[] result = (object[])Array.CreateInstance(baseType, itemsCount);
            if (itemsCount > 0) Array.Copy(items, 0, result, 0, itemsCount);
            return result;
        }
        public MenuBoxItem[] GetTIEMenuBarItems()
        {
            return (MenuBoxItem[])GetItems();
        }

        protected new void RecreateHandle()
        {
            MenuBoxItem[] btns = GetTIEMenuBarItems();
            Items.Clear();
            items = null;
            itemsCount = 0;

            base.RecreateHandle();

            for (int i = 0; i < btns.Length; i++)
                Items.Add(btns[i]);
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

        internal void NativeInsert(MenuBoxItem value, int index)
        {

            if (value == null) throw new ArgumentNullException("value");
            if (IsHandleCreated)
            {
                NativeMethods.TBBUTTON tbbutton = value.GetTBBUTTON(index);
                int result = (int)UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_INSERTBUTTON, index, ref tbbutton);
                if (result != 1)
                    throw new Win32Exception("insert button fault");
                NativeMethods.TBBUTTONINFO tbbuttonINFO = value.GetTBBUTTONINFO(index);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETBUTTONINFO, index, ref tbbuttonINFO);
            }
        }
        internal void NativeUpdateButtonAt(MenuBoxItem value, int index)
        {
            value.owner = this;
            items[index] = value;
            NativeMethods.TBBUTTONINFO btnINFO = value.GetTBBUTTONINFO(index);
            UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_SETBUTTONINFO, index, ref btnINFO);
        }
        internal void NativeRemoveAt(int index)
        {
            if (IsHandleCreated)
            {
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_DELETEBUTTON, index, IntPtr.Zero);
            }
        }

        public MenuBoxItem GetItemAt(Point point)
        {
            int index = -1;
            if (IsHandleCreated)
                index = UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_HITTEST, IntPtr.Zero, ref point);
            if (index < 0) return null;
            else return Items[index];
        }
        public int GetIndexAt(Point point)
        {
            int index = -1;
            if (IsHandleCreated)
                index = UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_HITTEST, IntPtr.Zero, ref point);
            return index;
        }
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
                if (value < 0) throw new ArgumentException("value");
                if (IsHandleCreated)
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_SETHOTITEM, value, IntPtr.Zero);
            }
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_COMMAND + NativeMethods.WM_REFLECT:
                    WmReflectCommand(ref m);
                    return;
                case NativeMethods.WM_NOTIFY:
                case NativeMethods.WM_NOTIFY + NativeMethods.WM_REFLECT:
                    WmReflectNotify(ref m);
                    return;
            }
            base.WndProc(ref m);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            point = e.Location;
            base.OnMouseMove(e);
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            int index = GetIndexAt(e.Location);
            if (index >= 0 && index < itemsCount)
            {
                point = e.Location;
                TrackPopupMenu(index);
            }
            point = e.Location;
            base.OnMouseDown(e);
        }

        private void WmReflectCommand(ref Message m)
        {
            base.WndProc(ref m);
            ResetMouseEventArgs();
        }
        private void WmReflectNotify(ref Message m)
        {
            NativeMethods.NMHDR note = (NativeMethods.NMHDR)m.GetLParam(typeof(NativeMethods.NMHDR));
            switch (note.code)
            {
                case NativeMethods.TBN_HOTITEMCHANGE:
                    WmNotifyHotItemChange(ref m);
                    break;
                case NativeMethods.NM_CUSTOMDRAW:
                    WmCustomDraw(ref m);
                    break;
                case NativeMethods.TBN_QUERYINSERT:
                    m.Result = (IntPtr)1;
                    break;
            }
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
        private void WmCustomDraw(ref Message m)
        {
            m.Result = (IntPtr)NativeMethods.CDRF_DODEFAULT;//在列表项绘制循环过程不再发送
            NativeMethods.NMTBCUSTOMDRAW tbcd = (NativeMethods.NMTBCUSTOMDRAW)m.GetLParam(typeof(NativeMethods.NMTBCUSTOMDRAW));
            switch (tbcd.nmcd.dwDrawStage)
            {
                case NativeMethods.CDDS_PREPAINT://开始画之前通知项
                    m.Result = (IntPtr)NativeMethods.CDRF_NOTIFYITEMDRAW;//列表项绘制前后发送消息
                    break;
                case NativeMethods.CDDS_ITEMPREPAINT:
                    WmPrepaint(ref m);
                    break;
            }
        }
        private void WmPrepaint(ref Message m)
        {
            m.Result = (IntPtr)NativeMethods.CDRF_DODEFAULT;
            NativeMethods.NMTBCUSTOMDRAW tbcd = (NativeMethods.NMTBCUSTOMDRAW)m.GetLParam(typeof(NativeMethods.NMTBCUSTOMDRAW));

            MenuBoxItem item = this.items[(int)tbcd.nmcd.dwItemSpec];

            bool hot = ((tbcd.nmcd.uItemState & NativeMethods.CDIS_HOT) != 0);
            bool selected = ((tbcd.nmcd.uItemState & NativeMethods.CDIS_SELECTED) != 0);
            bool mchecked = ((tbcd.nmcd.uItemState & NativeMethods.CDIS_CHECKED) != 0);
            bool disabled = ((tbcd.nmcd.uItemState & NativeMethods.CDIS_DISABLED) != 0);
            bool focus = ((tbcd.nmcd.uItemState & NativeMethods.CDIS_FOCUS) != 0);
            bool grayed = ((tbcd.nmcd.uItemState & NativeMethods.CDIS_GRAYED) != 0);

            if (hot || selected)
            {
                DrawIEMenuBarItem(item, ref tbcd);
                m.Result = (IntPtr)NativeMethods.CDRF_SKIPDEFAULT;
            }
        }
        private void DrawIEMenuBarItem(MenuBoxItem item, ref NativeMethods.NMTBCUSTOMDRAW tbcd)
        {
            NativeMethods.RECT rect = tbcd.nmcd.rc;
            rect.top += 1;
            IntPtr hDC = tbcd.nmcd.hdc;
            string text = item.Text;

            ///FillRect
            IntPtr hBrush = UnsafeNativeMethods.CreateSolidBrush(hightLightColor);
            UnsafeNativeMethods.FillRect(hDC, ref rect, hBrush);

            ///MeasureText
            NativeMethods.RECT lprt = new NativeMethods.RECT();
            UnsafeNativeMethods.DrawText(hDC, text, text.Length, ref lprt, NativeMethods.DT_SINGLELINE | NativeMethods.DT_LEFT | NativeMethods.DT_CALCRECT);//获得文字高度

            ///Drawtext
            IntPtr hOldFont = UnsafeNativeMethods.SelectObject(hDC, hFont);
            int oldBkMode = UnsafeNativeMethods.SetBkMode(hDC, NativeMethods.TRANSPARENT);
            int oldTextColor = UnsafeNativeMethods.SetTextColor(hDC, hightLightTextColor);
            NativeMethods.RECT clip = new NativeMethods.RECT();
            clip.left = rect.left + ((rect.right - rect.left - lprt.right) / 2) + 2;
            clip.top = rect.top + ((rect.bottom - rect.top - lprt.bottom) / 2) + 2;
            clip.right = clip.left + lprt.right;
            clip.bottom = clip.top + lprt.bottom;
            UnsafeNativeMethods.DrawText(hDC, text, text.Length, ref clip, NativeMethods.DT_SINGLELINE | NativeMethods.DT_LEFT);

            ///Free
            UnsafeNativeMethods.SetTextColor(hDC, oldTextColor);
            UnsafeNativeMethods.SetBkMode(hDC, oldBkMode);
            UnsafeNativeMethods.SelectObject(hDC, hOldFont);
            if (hBrush != IntPtr.Zero)
                UnsafeNativeMethods.DeleteObject(hBrush);
        }
        private void TrackPopupMenu(int index)
        {
            while (index >= 0)
            {
                npopupIndex = -1;
                cpopupIndex = index;

                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_PRESSBUTTON, index, 1);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_SETHOTITEM, index, IntPtr.Zero);
                MenuBoxItem tbb = items[index];
                tbb.mpressed = true;
                //安装钩子
                NativeMethods.WindowsHookProc hookProc = new NativeMethods.WindowsHookProc(MessageHook);
                messageHookHandle = UnsafeNativeMethods.SetWindowsHookEx(NativeMethods.WH_MSGFILTER, hookProc, NativeMethods.NullHandleRef, UnsafeNativeMethods.GetCurrentThreadId());
                if (messageHookHandle == IntPtr.Zero) throw new Win32Exception("SetWindowsHookEx Failt");

                Menu menu = tbb.DropDownMenu;
                if (menu != null)
                {
                    NativeMethods.RECT rc = new NativeMethods.RECT();
                    NativeMethods.TPMPARAMS tpm = new NativeMethods.TPMPARAMS();
                    UnsafeNativeMethods.SendMessage(new HandleRef(this, Handle), NativeMethods.TB_GETRECT, index, ref rc);
                    if ((menu.GetType()).IsAssignableFrom(typeof(ContextMenu))) ((ContextMenu)menu).Show(this, new Point(rc.left, rc.bottom));
                }
                base.Update();

                //卸载钩子
                UnsafeNativeMethods.UnhookWindowsHookEx(new HandleRef(null, messageHookHandle));
                messageHookHandle = IntPtr.Zero;
                if (menu != null) UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_PRESSBUTTON, index, 0);
                index = npopupIndex;
            }
            UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_SETHOTITEM, -1, IntPtr.Zero);

        }

        private IntPtr MessageHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode == NativeMethods.MSGF_MENU)//截获Menu消息
            {
                NativeMethods.MSG msg = (NativeMethods.MSG)Marshal.PtrToStructure(lParam, typeof(NativeMethods.MSG));
                Message m = Message.Create(msg.hwnd, msg.message, msg.wParam, msg.lParam);
                if (MessageFilter(ref m)) return (IntPtr)1;
            }
            return UnsafeNativeMethods.CallNextHookEx(new HandleRef(this, messageHookHandle), nCode, wParam, lParam);
        }
        private bool MessageFilter(ref Message m)
        {
            if (IsHandleCreated)
            {
                UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_PRESSBUTTON, cpopupIndex, 1);
                UnsafeNativeMethods.SendMessage(new HandleRef(this, this.Handle), NativeMethods.TB_SETHOTITEM, cpopupIndex, IntPtr.Zero);
                MenuBoxItem tbb = Items[cpopupIndex];
                tbb.mpressed = true;
                switch (m.Msg)
                {
                    case NativeMethods.WM_KEYDOWN:
                        return HandleKeyMessage(ref m);
                    case NativeMethods.WM_LBUTTONDOWN:
                    case NativeMethods.WM_MOUSEMOVE:
                        return HandleMouseMessage(ref m);
                    default:
                        break;
                }
            }
            return false;
        }
        private bool HandleKeyMessage(ref Message m)
        {
            Keys key = (Keys)(unchecked((int)(long)m.WParam)) | ModifierKeys;
            if (IsHandleCreated)
            {
                switch (key)
                {
                    case Keys.Escape:
                        {
                            UnsafeNativeMethods.PostMessage(new HandleRef(this, Handle), NativeMethods.WM_CANCELMODE, 0, 0);//关闭ContextMenu
                            npopupIndex = -1;
                            return true;
                        }
                    case Keys.Right:
                        {
                            int index = cpopupIndex;
                            index++;
                            if (index >= itemsCount) index = 0;
                            UnsafeNativeMethods.PostMessage(new HandleRef(this, Handle), NativeMethods.WM_CANCELMODE, 0, 0);//关闭ContextMenu
                            npopupIndex = index;
                            return true;
                        }
                    case Keys.Left:
                        {
                            int index = cpopupIndex;
                            index--;
                            if (index < 0) index = itemsCount - 1;
                            UnsafeNativeMethods.PostMessage(new HandleRef(this, Handle), NativeMethods.WM_CANCELMODE, 0, 0);//关闭ContextMenu
                            npopupIndex = index;
                            return true;
                        }
                    default:
                        return false;
                }
            }
            return false;
        }
        private bool HandleMouseMessage(ref Message m)
        {
            if (IsHandleCreated)
            {
                Point p = new Point(NativeMethods.Util.LOWORD(m.LParam), NativeMethods.Util.HIWORD(m.LParam));
                p = PointToClient(p);
                int index = GetIndexAt(p);
                switch (m.Msg)
                {
                    case NativeMethods.WM_MOUSEMOVE:
                        {
                            if (index != cpopupIndex && index >= 0 && index < itemsCount)
                            {
                                if (p != point)
                                {
                                    UnsafeNativeMethods.PostMessage(new HandleRef(this, Handle), NativeMethods.WM_CANCELMODE, 0, 0);//关闭ContextMenu
                                    npopupIndex = index;
                                    point = p;
                                    return true;
                                }
                            }
                        }
                        break;
                    case NativeMethods.WM_LBUTTONDOWN:
                        {
                            if (index == cpopupIndex)
                            {
                                UnsafeNativeMethods.PostMessage(new HandleRef(this, Handle), NativeMethods.WM_CANCELMODE, 0, 0);//关闭ContextMenu
                                npopupIndex = -1;
                                return true;
                            }
                        }
                        break;
                }
            }
            return false;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (messageHookHandle != IntPtr.Zero)
            {
                UnsafeNativeMethods.UnhookWindowsHookEx(new HandleRef(null, messageHookHandle));
                messageHookHandle = IntPtr.Zero;
            }
        }
    }
}
