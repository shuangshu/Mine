using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Design;

namespace Windows.SystemControl
{
    public class ToolBoxButton : Component
    {
        public int FindIndex(ToolBoxButton value)
        {
            for (int x = 0; x < owner.Buttons.Count; x++)
            {
                if (owner.Buttons[x] == this)
                {
                    return x;
                }
            }
            return -1;
        }

        public ToolBoxButton()
        { }

        public ToolBoxButton(int imageIndex)
            : this()
        {
            this.imageIndex = imageIndex;
        }

        public ToolBoxButton(string text)
            : this()
        {
            this.text = text;
        }

        public ToolBoxButton(string text, int imageIndex)
            : this(text)
        {
            this.imageIndex = imageIndex;
        }

        private TBBAppearance appearance = TBBAppearance.Button;
        public TBBAppearance Appearance
        {
            get { return appearance; }
            set
            {
                if (appearance != value)
                {
                    appearance = value;
                    NativeMethods.TBBUTTONINFO btnINFO = new NativeMethods.TBBUTTONINFO();
                    btnINFO.cbSize = Marshal.SizeOf(typeof(NativeMethods.TBBUTTONINFO));
                    btnINFO.dwMask = NativeMethods.TBIF_STYLE;
                    btnINFO.fsStyle = 0;
                    switch (appearance)
                    {
                        case TBBAppearance.Button:
                            btnINFO.fsStyle = NativeMethods.TBSTYLE_BUTTON;
                            break;
                        case TBBAppearance.Separator:
                            btnINFO.fsStyle = NativeMethods.TBSTYLE_SEP;
                            break;
                        case TBBAppearance.DropDown:
                            btnINFO.fsStyle = NativeMethods.TBSTYLE_DROPDOWN;
                            break;
                        case TBBAppearance.Check:
                            btnINFO.fsStyle = NativeMethods.TBSTYLE_CHECK;
                            break;
                    }
                    if (owner != null && owner.IsHandleCreated)
                        UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_SETBUTTONINFO, FindIndex(this), ref btnINFO);
                }
            }
        }

        private bool mchecked = false;
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

        private bool menable = true;
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

        private bool mhidden = false;
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

        private bool mpressed = false;
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

        private int width = -1;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private Menu menu = null;
        public Menu DropDownMenu
        {
            get { return menu; }
            set { menu = value; }
        }

        internal ToolBox owner;

        private string tooltipText = string.Empty;
        public string ToolTipText
        {
            get { return tooltipText; }
            set { tooltipText = value; }
        }

        private string text = string.Empty;
        public string Text
        {
            get { return text; }
            set
            {
                if (text != value)
                {
                    text = value;
                    if (owner != null && owner.IsHandleCreated)
                        owner.NativeUpdateButtonAt(this, FindIndex(this));
                }
            }
        }

        private int imageIndex = -1;
        public int ImageIndex
        {
            get { return imageIndex; }
            set
            {
                if (imageIndex != value)
                {
                    imageIndex = value;
                    if (owner != null && owner.IsHandleCreated)
                        owner.NativeUpdateButtonAt(this, FindIndex(this));
                }
            }
        }

        private string menuText = string.Empty;
        public string MenuText
        {
            get { return menuText; }
            set { menuText = value; }
        }

        private object tag = null;
        public object Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public NativeMethods.TBBUTTON GetTBBUTTON(int command)
        {
            NativeMethods.TBBUTTON button = new NativeMethods.TBBUTTON();
            button.iBitmap = imageIndex;

            button.fsStyle = 0;
            switch (appearance)
            {
                case TBBAppearance.Button:
                    button.fsStyle = NativeMethods.TBSTYLE_BUTTON;
                    break;
                case TBBAppearance.Separator:
                    button.fsStyle = NativeMethods.TBSTYLE_SEP;
                    break;
                case TBBAppearance.DropDown:
                    button.fsStyle = NativeMethods.TBSTYLE_DROPDOWN;
                    break;
                case TBBAppearance.Check:
                    button.fsStyle = NativeMethods.TBSTYLE_CHECK;
                    break;
                case TBBAppearance.WholeDropDown:
                    button.fsStyle = NativeMethods.BTNS_WHOLEDROPDOWN;
                    break;
            }

            button.fsState = 0;
            if (mchecked) button.fsState |= NativeMethods.TBSTATE_CHECKED;
            if (menable) button.fsState |= NativeMethods.TBSTATE_ENABLED;
            if (mpressed) button.fsState |= NativeMethods.TBSTATE_PRESSED;
            if (mhidden) button.fsState |= NativeMethods.TBSTATE_HIDDEN;

            button.dwData = (IntPtr)0;
            button.idCommand = command;
            if (!string.IsNullOrEmpty(text))
                button.iString = Marshal.StringToHGlobalAuto(text + "\0\0");
            else button.iString = (IntPtr)(-1);
            return button;
        }

        private Rectangle bounds = Rectangle.Empty;
        public Rectangle Bounds
        {
            get
            {
                if (owner != null && owner.Handle != IntPtr.Zero)
                {
                    NativeMethods.RECT rect = new NativeMethods.RECT();
                    UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_GETRECT, FindIndex(this), ref rect);
                    bounds = rect.Rectangle;
                }
                return bounds;
            }
        }

        public NativeMethods.TBBUTTONINFO GetTBBUTTONINFO(int command)
        {
            NativeMethods.TBBUTTONINFO button = new NativeMethods.TBBUTTONINFO();
            button.cbSize = Marshal.SizeOf(typeof(NativeMethods.TBBUTTONINFO));
            button.dwMask = NativeMethods.TBIF_STATE | NativeMethods.TBIF_STYLE | NativeMethods.TBIF_SIZE;
            if (command != -1)
            {
                button.dwMask |= NativeMethods.TBIF_COMMAND;
                button.idCommand = command;
            }
            if (imageIndex != -1)
            {
                button.dwMask |= NativeMethods.TBIF_IMAGE;
                button.iImage = imageIndex;
            }
            if (!string.IsNullOrEmpty(text))
            {
                button.dwMask |= NativeMethods.TBIF_TEXT;
                button.pszText = Marshal.StringToHGlobalAuto(text + "\0\0");
            }
            if (width != -1)
            {
                button.dwMask |= NativeMethods.TBIF_SIZE;
                button.cx = (short)width;
            }
            button.fsStyle = 0;
            switch (appearance)
            {
                case TBBAppearance.Button:
                    button.fsStyle = NativeMethods.TBSTYLE_BUTTON;
                    break;
                case TBBAppearance.Separator:
                    button.fsStyle = NativeMethods.TBSTYLE_SEP;
                    break;
                case TBBAppearance.DropDown:
                    button.fsStyle = NativeMethods.TBSTYLE_DROPDOWN;
                    break;
                case TBBAppearance.Check:
                    button.fsStyle = NativeMethods.TBSTYLE_CHECK;
                    break;
                case TBBAppearance.WholeDropDown:
                    button.fsStyle = NativeMethods.BTNS_WHOLEDROPDOWN;
                    break;
            }

            button.fsState = 0;
            if (mchecked) button.fsState |= NativeMethods.TBSTATE_CHECKED;
            if (menable) button.fsState |= NativeMethods.TBSTATE_ENABLED;
            if (mpressed) button.fsState |= NativeMethods.TBSTATE_PRESSED;
            if (mhidden) button.fsState |= NativeMethods.TBSTATE_HIDDEN;
            return button;
        }

        /// <summary>
        /// 判断是否Checked
        /// </summary>
        public bool IsButtonChecked
        {
            get
            {
                bool mchecked = false;
                if (owner != null && owner.IsHandleCreated)
                {
                    mchecked = UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_ISBUTTONCHECKED, FindIndex(this), IntPtr.Zero) != IntPtr.Zero ? true : false;
                }
                return mchecked;
            }
        }
        /// <summary>
        /// 判断是否Enable
        /// </summary>
        public bool IsButtonEnable
        {
            get
            {
                bool menable = false;
                if (owner != null && owner.IsHandleCreated)
                {
                    menable = UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_ISBUTTONENABLED, FindIndex(this), IntPtr.Zero) != IntPtr.Zero ? true : false;
                }
                return menable;
            }
        }
        /// <summary>
        /// 判断是否Hidden
        /// </summary>
        public bool IsButtonHidden
        {
            get
            {
                bool mhidden = false;
                if (owner != null && owner.IsHandleCreated)
                {
                    mhidden = UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_ISBUTTONENABLED, FindIndex(this), IntPtr.Zero) != IntPtr.Zero ? true : false;
                }
                return mhidden;
            }
        }
        /// <summary>
        /// 判断是否HightLighted
        /// </summary>
        public bool IsButtonHightLighted
        {
            get
            {
                bool mhightLighted = false;
                if (owner != null && owner.IsHandleCreated)
                {
                    mhightLighted = UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_ISBUTTONHIGHLIGHTED, FindIndex(this), IntPtr.Zero) != IntPtr.Zero ? true : false;
                }
                return mhightLighted;
            }
        }
        /// <summary>
        /// 判断是否Pressed
        /// </summary>
        public bool IsButtonPressed
        {
            get
            {
                bool mpressed = false;
                if (owner != null && owner.IsHandleCreated)
                {
                    mpressed = UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.TB_ISBUTTONPRESSED, FindIndex(this), IntPtr.Zero) != IntPtr.Zero ? true : false;
                }
                return mpressed;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (owner != null)
                {
                    int index = FindIndex(this);
                    if (index != -1) owner.Buttons.RemoveAt(index);
                }
            }
            base.Dispose(disposing);
        }
    }
}
