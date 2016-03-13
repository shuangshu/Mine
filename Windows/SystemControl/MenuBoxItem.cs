using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Windows.SystemControl
{
    public class MenuBoxItem
    {
        public MenuBoxItem()
        { }

        private string text = string.Empty;
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                }
            }
        }

        internal MenuBox owner;
        public MenuBoxItem(string text)
            : this()
        {
            this.text = text;
        }

        private ContextMenu menu = null;
        public ContextMenu DropDownMenu
        {
            get { return menu; }
            set { menu = value; }
        }

        internal bool mchecked = false;
        public bool Checked
        {
            get { return mchecked; }
            set
            {
                if (mchecked != value)
                {
                    mchecked = value;
                    if (owner != null && owner.IsHandleCreated)
                    {
                        UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_CHECKBUTTON, FindIndex(this), mchecked ? 1 : 0);
                    }
                }
            }
        }

        internal bool menable = true;
        public bool Enable
        {
            get { return menable; }
            set
            {
                if (menable != value)
                {
                    menable = value;
                    if (owner != null && owner.IsHandleCreated)
                    {
                        UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_ENABLEBUTTON, FindIndex(this), menable ? 1 : 0);
                    }
                }
            }
        }

        internal bool mhidden = false;
        public bool Hidden
        {
            get { return mhidden; }
            set
            {
                if (mhidden != value)
                {
                    mhidden = value;
                    if (owner != null && owner.IsHandleCreated)
                    {
                        UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_HIDEBUTTON, FindIndex(this), mhidden ? 1 : 0);
                    }
                }
            }
        }

        internal bool mpressed = false;
        public bool Pressed
        {
            get { return mpressed; }
            set
            {
                if (mpressed != value)
                {
                    mpressed = value;
                    if (owner != null && owner.IsHandleCreated)
                    {
                        UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_PRESSBUTTON, FindIndex(this), mpressed ? 1 : 0);
                    }
                }
            }
        }

        public int FindIndex(MenuBoxItem value)
        {
            for (int x = 0; x < owner.Items.Count; x++)
            {
                if (owner.Items[x] == this)
                {
                    return x;
                }
            }
            return -1;
        }

        public NativeMethods.TBBUTTON GetTBBUTTON(int command)
        {
            NativeMethods.TBBUTTON btn = new NativeMethods.TBBUTTON();
            btn.fsStyle = NativeMethods.TBSTYLE_BUTTON | NativeMethods.TBSTYLE_AUTOSIZE;//| NativeMethods.TBSTYLE_DROPDOWN;
            btn.dwData = (IntPtr)0;
            btn.idCommand = command;
            btn.iString = (IntPtr)(-1);
            if (!string.IsNullOrEmpty(text)) btn.iString = Marshal.StringToHGlobalAuto(text + "\0\0");
            if (mchecked) btn.fsState |= NativeMethods.TBSTATE_CHECKED;
            if (menable) btn.fsState |= NativeMethods.TBSTATE_ENABLED;
            if (mpressed) btn.fsState |= NativeMethods.TBSTATE_PRESSED;
            if (mhidden) btn.fsState |= NativeMethods.TBSTATE_HIDDEN;
            return btn;
        }

        public NativeMethods.TBBUTTONINFO GetTBBUTTONINFO(int command)
        {
            NativeMethods.TBBUTTONINFO btn = new NativeMethods.TBBUTTONINFO();
            btn.cbSize = Marshal.SizeOf(typeof(NativeMethods.TBBUTTONINFO));
            btn.dwMask = NativeMethods.TBIF_STATE | NativeMethods.TBIF_STYLE;
            btn.fsStyle = NativeMethods.TBSTYLE_BUTTON | NativeMethods.TBSTYLE_AUTOSIZE;// | NativeMethods.TBSTYLE_DROPDOWN;
            if (command != -1)
            {
                btn.dwMask |= NativeMethods.TBIF_COMMAND;
                btn.idCommand = command;
            }
            if (!string.IsNullOrEmpty(text))
            {
                btn.dwMask |= NativeMethods.TBIF_TEXT;
                btn.pszText = Marshal.StringToHGlobalAuto(text + "\0\0");
            }
            if (mchecked) btn.fsState |= NativeMethods.TBSTATE_CHECKED;
            if (menable) btn.fsState |= NativeMethods.TBSTATE_ENABLED;
            if (mpressed) btn.fsState |= NativeMethods.TBSTATE_PRESSED;
            if (mhidden) btn.fsState |= NativeMethods.TBSTATE_HIDDEN;
            return btn;
        }
    }
}
