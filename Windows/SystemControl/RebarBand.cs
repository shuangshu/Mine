using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Windows.SystemControl
{
    public class RebarBand : Component
    {

        public RebarBand()
            : base()
        { }

        public RebarBand(Control child)
        {
            this.control = child;
        }

        public RebarBand(string text)
        {
            this.text = text;
        }

        public RebarBand(int imageIndex)
        {
            this.imageIndex = imageIndex;
        }

        public RebarBand(int imageIndex, Control child)
            : this(imageIndex)
        {
            this.imageIndex = imageIndex;
            this.control = child;
        }

        public RebarBand(string text, Control child)
            : this(text)
        {
            this.text = text;
            this.control = child;
        }

        public RebarBand(string text, int imageIndex)
            : this(text)
        {
            this.imageIndex = imageIndex;
        }

        public RebarBand(string text, int imageIndex, Control child)
            : this(text, imageIndex)
        {
            this.control = child;
        }

        private TRBBStyle bandStyle = TRBBStyle.UseChevron | TRBBStyle.Break | TRBBStyle.NoGripper;
        public TRBBStyle Style
        {
            get { return bandStyle; }
            set
            {
                if (bandStyle != value)
                {
                    bandStyle = value;
                    Update(NativeMethods.RBBIM_STYLE);
                }
            }
        }

        private IntPtr hbmBack = IntPtr.Zero;
        public Bitmap Bitmap
        {
            get
            {
                if (hbmBack != IntPtr.Zero)
                    return Bitmap.FromHbitmap(hbmBack);
                return null;
            }
            set
            {
                if (value != null)
                {
                    if (hbmBack != value.GetHbitmap())
                    {
                        hbmBack = value.GetHbitmap();
                        Update(NativeMethods.RBBIM_BACKGROUND);
                    }
                }
                else
                {
                    hbmBack = IntPtr.Zero;
                    Update(NativeMethods.RBBIM_BACKGROUND);
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
                    Update(NativeMethods.RBBIM_IMAGE);
                }
            }
        }

        private int width = 24;
        public int Width
        {
            get { return width; }
            set
            {
                if (width != value)
                {
                    width = value;
                    Update(NativeMethods.RBBIM_SIZE);
                }
            }
        }

        private int childWidth = 24;
        public int ChildWidth
        {
            get { return childWidth; }
            set
            {
                if (childWidth != value)
                {
                    childWidth = value;
                    if ((bandStyle & TRBBStyle.VariableHeight) != 0)
                        Update(NativeMethods.RBBIM_CHILDSIZE);
                }
            }
        }

        private Control control = null;
        public Control Control
        {
            get { return control; }
            set
            {
                if (control != value)
                {
                    control = value;
                    Update(NativeMethods.RBBIM_CHILD);
                }
            }
        }

        private int minChildWidth = 24;
        public int MinChildWidth
        {
            get { return minChildWidth; }
            set
            {
                if (minChildWidth != value)
                {
                    minChildWidth = value;
                    if ((bandStyle & TRBBStyle.VariableHeight) != 0)
                        Update(NativeMethods.RBBIM_CHILDSIZE);
                }
            }
        }

        private int minChildHeight = 24;
        public int MinChildHeight
        {
            get { return minChildHeight; }
            set
            {
                if (minChildHeight != value)
                {
                    minChildHeight = value;
                    if ((bandStyle & TRBBStyle.VariableHeight) != 0)
                        Update(NativeMethods.RBBIM_CHILDSIZE);
                }
            }
        }

        private int maxChildHeight = -1;
        public int MaxChildHeight
        {
            get { return maxChildHeight; }
            set
            {
                if (maxChildHeight != value)
                {
                    maxChildHeight = value;
                    if ((bandStyle & TRBBStyle.VariableHeight) != 0)
                        Update(NativeMethods.RBBIM_CHILDSIZE);
                }
            }
        }

        private int idealWidth = -1;
        public int IdealWidth
        {
            get { return idealWidth; }
            set
            {
                if (idealWidth != value)
                {
                    idealWidth = value;
                    Update(NativeMethods.RBBIM_IDEALSIZE);
                }
            }
        }

        private int headerWidth = -1;
        public int HeaderWidth
        {
            get { return headerWidth; }
            set
            {
                if (headerWidth != value)
                {
                    headerWidth = value;
                    Update(NativeMethods.RBBIM_HEADERSIZE);
                }
            }
        }

        internal Rebar owner = null;
        public int FindIndex(RebarBand value)
        {
            for (int x = 0; x < owner.Bands.Count; x++)
            {
                if (owner.Bands[x] == this)
                {
                    return x;
                }
            }
            return -1;
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
                    Update(NativeMethods.RBBIM_TEXT);
                }
            }
        }


        private Color backgroundColor = SystemColors.Control;
        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                if (backgroundColor != value)
                {
                    backgroundColor = value;
                    Update(NativeMethods.RBBIM_COLORS);
                }
            }
        }
        private void UpdateBackGroundColor()
        {
            if (owner != null && owner.IsHandleCreated)
                UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.RB_SETBKCOLOR, IntPtr.Zero, NativeMethods.RGB(120, 120, 120));
        }

        private Color textgroundColor = SystemColors.WindowText;
        public Color TextgroundColor
        {
            get { return textgroundColor; }
            set
            {
                if (textgroundColor != value)
                {
                    textgroundColor = value;
                    Update(NativeMethods.RBBIM_COLORS);
                }
            }
        }

        private void UpdateTextGroundColor()
        {
            if (owner != null && owner.IsHandleCreated)
                UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.RB_SETTEXTCOLOR, IntPtr.Zero, textgroundColor.ToArgb());
        }

        private void Update(int mask)
        {

            if (Marshal.SystemDefaultCharSize == 1)
            {
                if (owner != null && owner.IsHandleCreated)
                {
                    int index = FindIndex(this);
                    NativeMethods.REBARBANDINFO bandINFO = GetREBARBANDINFO(index);
                    bandINFO.fMask = mask;
                    UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.RB_SETBANDINFOA, index, ref bandINFO);
                }
            }
            else
            {

                if (owner != null && owner.IsHandleCreated)
                {
                    int index = FindIndex(this);
                    NativeMethods.REBARBANDINFO bandINFO = GetREBARBANDINFO(index);
                    bandINFO.fMask = mask;
                    UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.RB_SETBANDINFOW, index, ref bandINFO);
                }
            }
        }
        public NativeMethods.REBARBANDINFO GetREBARBANDINFO(int index)
        {
            NativeMethods.REBARBANDINFO bandINFO = new NativeMethods.REBARBANDINFO();
            bandINFO.cbSize = Marshal.SizeOf(typeof(NativeMethods.REBARBANDINFO));
            bandINFO.fMask = NativeMethods.RBBIM_STYLE | NativeMethods.RBBIM_ID;
            if ((bandStyle & TRBBStyle.Break) != 0) bandINFO.fStyle |= NativeMethods.RBBS_BREAK;
            if ((bandStyle & TRBBStyle.ChildEdge) != 0) bandINFO.fStyle |= NativeMethods.RBBS_CHILDEDGE;
            if ((bandStyle & TRBBStyle.FixedBitmap) != 0) bandINFO.fStyle |= NativeMethods.RBBS_FIXEDBMP;
            if ((bandStyle & TRBBStyle.FixedSize) != 0) bandINFO.fStyle |= NativeMethods.RBBS_FIXEDSIZE;
            if ((bandStyle & TRBBStyle.GripperAlways) != 0) bandINFO.fStyle |= NativeMethods.RBBS_GRIPPERALWAYS;
            if ((bandStyle & TRBBStyle.Hidden) != 0) bandINFO.fStyle |= NativeMethods.RBBS_HIDDEN;
            if ((bandStyle & TRBBStyle.VariableHeight) != 0) bandINFO.fStyle |= NativeMethods.RBBS_VARIABLEHEIGHT;
            if ((bandStyle & TRBBStyle.UseChevron) != 0) bandINFO.fStyle |= NativeMethods.RBBS_USECHEVRON;
            if ((bandStyle & TRBBStyle.NoGripper) != 0) bandINFO.fStyle |= NativeMethods.RBBS_NOGRIPPER;
            bandINFO.wID = index;
            if (!string.IsNullOrEmpty(text))
            {
                bandINFO.fMask |= NativeMethods.RBBIM_TEXT;
                bandINFO.lpText = Marshal.StringToHGlobalAuto(text);
                bandINFO.cch = text.Length;
            }
            if (imageIndex != -1)
            {
                bandINFO.fMask |= NativeMethods.RBBIM_IMAGE;
                bandINFO.iImage = imageIndex;
            }
            if (backgroundColor != Color.Empty)
            {
                bandINFO.fMask |= NativeMethods.RBBIM_COLORS;
                bandINFO.clrBack = NativeMethods.RGB(backgroundColor.R, backgroundColor.G, backgroundColor.B);
            }
            if (textgroundColor != Color.Empty)
            {
                bandINFO.fMask |= NativeMethods.RBBIM_COLORS;
                bandINFO.clrFore = NativeMethods.RGB(textgroundColor.R, textgroundColor.G, textgroundColor.B);
            }
            if (control != null)
            {
                childWidth = control.Width;
                bandINFO.fMask |= NativeMethods.RBBIM_CHILD;
                bandINFO.hwndChild = control.Handle;
                if (childWidth != -1)
                {
                    bandINFO.fMask |= NativeMethods.RBBIM_CHILDSIZE;
                    bandINFO.cxMinChild = control.Width;
                    bandINFO.cyMinChild = control.Height;

                    if ((bandStyle & TRBBStyle.VariableHeight) != 0)
                    {
                        bandINFO.cyChild = control.Width;
                        bandINFO.cyMaxChild = control.Height;
                        bandINFO.cyIntegral = 1;
                    }
                }

                if (control is MenuBox || control is ToolBox)
                {
                    NativeMethods.SIZE size = new NativeMethods.SIZE();
                    UnsafeNativeMethods.SendMessage(new HandleRef(control, control.Handle), NativeMethods.TB_GETMAXSIZE, IntPtr.Zero, size);
                    bandINFO.fMask |= NativeMethods.RBBIM_IDEALSIZE;
                    bandINFO.cxIdeal = size.cx;
                    idealWidth = size.cx;
                }
            }
            if (headerWidth != -1)
            {
                bandINFO.fMask |= NativeMethods.RBBIM_HEADERSIZE;
                bandINFO.cxHeader = headerWidth;
            }
            if (hbmBack != IntPtr.Zero)
            {
                bandINFO.fMask |= NativeMethods.RBBIM_BACKGROUND;
                bandINFO.hbmBack = hbmBack;
            }

            if (width != -1)
            {
                bandINFO.fMask |= NativeMethods.RBBIM_SIZE;
                bandINFO.cx = width;
            }

            return bandINFO;
        }

        public Rectangle Bounds
        {
            get
            {
                if (owner != null && owner.IsHandleCreated)
                {
                    int index = FindIndex(this);
                    NativeMethods.RECT lprc = new NativeMethods.RECT();
                    UnsafeNativeMethods.SendMessage(new HandleRef(owner, owner.Handle), NativeMethods.RB_GETRECT, index, ref lprc);
                    return lprc.Rectangle;
                }
                return Rectangle.Empty;
            }
        }
    }
}
