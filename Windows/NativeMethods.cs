using System.Runtime.InteropServices;
using System;
using System.Security.Permissions;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;
using Microsoft.Win32;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;

namespace Windows
{
    public static class NativeMethods
    {
        public const int MaxTextLengthInWin9x = 8192;
        public static IntPtr InvalidIntPtr = (IntPtr)(-1);
        public static IntPtr LPSTR_TEXTCALLBACK = (IntPtr)(-1);
        public static HandleRef NullHandleRef = new HandleRef(null, IntPtr.Zero);

        public const int BITMAPINFO_MAX_COLORSIZE = 256;
        public const int BI_BITFIELDS = 3;

        public const int
        TVSIL_NORMAL = 0,
        TVSIL_SMALL = 1;

        public static Guid IID_DesktopGUID = new Guid("{00021400-0000-0000-C000-000000000046}");
        public static Guid IID_IShellFolder = new Guid("{000214E6-0000-0000-C000-000000000046}");
        public static Guid IID_IContextMenu = new Guid("{000214e4-0000-0000-c000-000000000046}");
        public static Guid IID_IContextMenu2 = new Guid("{000214f4-0000-0000-c000-000000000046}");
        public static Guid IID_IContextMenu3 = new Guid("{bcfce0a0-ec17-11d0-8d10-00a0c90f2719}");
        public static Guid IID_IDropTarget = new Guid("{00000122-0000-0000-C000-000000000046}");
        public static Guid IID_IDataObject = new Guid("{0000010e-0000-0000-C000-000000000046}");
        public static Guid IID_IQueryInfo = new Guid("{00021500-0000-0000-C000-000000000046}");
        public static Guid IID_IPersistFile = new Guid("{0000010b-0000-0000-C000-000000000046}");
        public static Guid CLSID_DragDropHelper = new Guid("{4657278A-411B-11d2-839A-00C04FD918D0}");
        public static Guid CLSID_NewMenu = new Guid("{D969A300-E7FF-11d0-A93B-00A0C90F2719}");
        public static Guid IID_IDragSourceHelper = new Guid("{DE5BF786-477A-11d2-839D-00C04FD918D0}");
        public static Guid IID_IDropTargetHelper = new Guid("{4657278B-411B-11d2-839A-00C04FD918D0}");
        public static Guid IID_IShellExtInit = new Guid("{000214e8-0000-0000-c000-000000000046}");
        public static Guid IID_IStream = new Guid("{0000000c-0000-0000-c000-000000000046}");
        public static Guid IID_IStorage = new Guid("{0000000B-0000-0000-C000-000000000046}");

        public const int ID_TIMER_EVENT = WM_USER + 1;

        public const int
        OBJ_PEN = 1,
        OBJ_BRUSH = 2,
        OBJ_DC = 3,
        OBJ_METADC = 4,
        OBJ_PAL = 5,
        OBJ_FONT = 6,
        OBJ_BITMAP = 7,
        OBJ_REGION = 8,
        OBJ_METAFILE = 9,
        OBJ_MEMDC = 10,
        OBJ_EXTPEN = 11,
        OBJ_ENHMETADC = 12;

        public enum RegionFlags
        {
            ERROR = 0,
            NULLREGION = 1,
            SIMPLEREGION = 2,
            COMPLEXREGION = 3,
        }

        public const int
        GCS_VERBA = 0,
        GCS_HELPTEXTA = 1,
        GCS_VALIDATEA = 2,
         GCS_VERBW = 4,
        GCS_HELPTEXTW = 5,
        GCS_VALIDATEW = 6,
        GCS_UNICODE = 4;

        public const int
        SEE_MASK_CLASSNAME = 1,
        SEE_MASK_CLASSKEY = 3,
        SEE_MASK_IDLIST = 4,
        SEE_MASK_INVOKEIDLIST = 12,
        SEE_MASK_ICON = 0x10,
        SEE_MASK_HOTKEY = 0x20,
        SEE_MASK_NOCLOSEPROCESS = 0x40,
        SEE_MASK_CONNECTNETDRV = 0x80,
        SEE_MASK_FLAG_DDEWAIT = 0x100,
        SEE_MASK_DOENVSUBST = 0x200,
        SEE_MASK_FLAG_NO_UI = 0x400,
        SEE_MASK_NO_CONSOLE = 0x8000,
        SEE_MASK_UNICODE = 0x10000,
        SEE_MASK_ASYNCOK = 0x100000,
        SEE_MASK_HMONITOR = 0x200000;

        public const int
        TBCDRF_NOEDGES = 0x00010000,  // Don't draw button edges
        TBCDRF_HILITEHOTTRACK = 0x00020000, // Use color of the button bk when hottracked
        TBCDRF_NOOFFSET = 0x00040000, // Don't offset button if pressed
        TBCDRF_NOMARK = 0x00080000, // Don't draw default highlight of image/text for TBSTATE_MARKED
        TBCDRF_NOETCHEDEFFECT = 0x00100000; // Don't draw etched effect for disabled items

        public const int
        CMIC_MASK_PTINVOKE = 0x20000000,
        CMIC_MASK_HOTKEY = SEE_MASK_HOTKEY,
        CMIC_MASK_ICON = SEE_MASK_ICON,
        CMIC_MASK_FLAG_NO_UI = SEE_MASK_FLAG_NO_UI,
        CMIC_MASK_UNICODE = SEE_MASK_UNICODE,
        CMIC_MASK_MODAL = unchecked((int)0x80000000);			/* ; Internal */

        public const int
        CMF_NORMAL = 0,
        CMF_DEFAULTONLY = 1,
        CMF_VERBSONLY = 2,
        CMF_EXPLORE = 4,
        CMF_NOVERBS = 8,
        CMF_CANRENAME = 16,
        CMF_NODEFAULT = 32,
        CMF_INCLUDESTATIC = 64,
        CMF_RESERVED = unchecked((int)0xffff0000);


        public const int
        SS_LEFT = 0x00000000,
        SS_CENTER = 0x00000001,
        SS_RIGHT = 0x00000002,
        SS_ICON = 0x00000003,
        SS_BLACKRECT = 0x00000004,
        SS_GRAYRECT = 0x00000005,
        SS_WHITERECT = 0x00000006,
        SS_BLACKFRAME = 0x00000007,
        SS_GRAYFRAME = 0x00000008,
        SS_WHITEFRAME = 0x00000009,
        SS_USERITEM = 0x0000000A,
        SS_SIMPLE = 0x0000000B,
        SS_LEFTNOWORDWRAP = 0x0000000C,
        SS_OWNERDRAW = 0x0000000D,
        SS_BITMAP = 0x0000000E,
        SS_ENHMETAFILE = 0x0000000F,
        SS_ETCHEDHORZ = 0x00000010,
        SS_ETCHEDVERT = 0x00000011,
        SS_ETCHEDFRAME = 0x00000012,
        SS_TYPEMASK = 0x0000001F,
        SS_REALSIZECONTROL = 0x00000040,
        SS_NOPREFIX = 0x00000080, /* Don't do "&" character translation */
        SS_NOTIFY = 0x00000100,
        SS_CENTERIMAGE = 0x00000200,
        SS_RIGHTJUST = 0x00000400,
        SS_REALSIZEIMAGE = 0x00000800,
        SS_SUNKEN = 0x00001000,
        SS_EDITCONTROL = 0x00002000,
        SS_ENDELLIPSIS = 0x00004000,
        SS_PATHELLIPSIS = 0x00008000,
        SS_WORDELLIPSIS = 0x0000C000,
        SS_ELLIPSISMASK = 0x0000C000,
        STM_SETICON = 0x0170,
        STM_GETICON = 0x0171,
        STM_SETIMAGE = 0x0172,
        STM_GETIMAGE = 0x0173,
        STN_CLICKED = 0,
        STN_DBLCLK = 1,
        STN_ENABLE = 2,
        STN_DISABLE = 3,
        STM_MSGMAX = 0x0174;

        public const int
        UDN_FIRST = unchecked((int)(0U - 721)),
        UDN_LAST = unchecked((int)(0U - 740)),
        UDN_DELTAPOS = (UDN_FIRST - 1);

        public const int
        UD_MAXVAL = 0x7fff,
        UD_MINVAL = (-UD_MAXVAL),
            // begin_r_commctrl

        UDS_WRAP = 0x0001,
        UDS_SETBUDDYINT = 0x0002,
        UDS_ALIGNRIGHT = 0x0004,
        UDS_ALIGNLEFT = 0x0008,
        UDS_AUTOBUDDY = 0x0010,
        UDS_ARROWKEYS = 0x0020,
        UDS_HORZ = 0x0040,
        UDS_NOTHOUSANDS = 0x0080,
        UDS_HOTTRACK = 0x0100,

        // end_r_commctrl

        UDM_SETRANGE = (WM_USER + 101),
        UDM_GETRANGE = (WM_USER + 102),
        UDM_SETPOS = (WM_USER + 103),
        UDM_GETPOS = (WM_USER + 104),
        UDM_SETBUDDY = (WM_USER + 105),
        UDM_GETBUDDY = (WM_USER + 106),
        UDM_SETACCEL = (WM_USER + 107),
        UDM_GETACCEL = (WM_USER + 108),
        UDM_SETBASE = (WM_USER + 109),
        UDM_GETBASE = (WM_USER + 110),
        UDM_SETRANGE32 = (WM_USER + 111),
        UDM_GETRANGE32 = (WM_USER + 112),// wParam & lParam are LPINT
        UDM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT,
        UDM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT,
        UDM_SETPOS32 = (WM_USER + 113),
        UDM_GETPOS32 = (WM_USER + 114);

        public const int
        TMT_STRING = 201,
        TMT_INT = 202,
        TMT_BOOL = 203,
        TMT_COLOR = 204,
        TMT_MARGINS = 205,
        TMT_FILENAME = 206,
        TMT_SIZE = 207,
        TMT_POSITION = 208,
        TMT_RECT = 209,
        TMT_FONT = 210,
        TMT_INTLIST = 211,
        TMT_COLORSCHEMES = 401,
        TMT_SIZES = 402,
        TMT_CHARSET = 403,
        TMT_DISPLAYNAME = 601,
        TMT_TOOLTIP = 602,
        TMT_COMPANY = 603,
        TMT_AUTHOR = 604,
        TMT_COPYRIGHT = 605,
        TMT_URL = 606,
        TMT_VERSION = 607,
        TMT_DESCRIPTION = 608,
        TMT_FIRST_RCSTRING_NAME = TMT_DISPLAYNAME,
        TMT_LAST_RCSTRING_NAME = TMT_DESCRIPTION,
        TMT_CAPTIONFONT = 801,
        TMT_SMALLCAPTIONFONT = 802,
        TMT_MENUFONT = 803,
        TMT_STATUSFONT = 804,
        TMT_MSGBOXFONT = 805,
        TMT_ICONTITLEFONT = 806,
        TMT_FIRSTFONT = TMT_CAPTIONFONT,
        TMT_LASTFONT = TMT_ICONTITLEFONT,
        TMT_SIZINGBORDERWIDTH = 1201,
        TMT_SCROLLBARWIDTH = 1202,
        TMT_SCROLLBARHEIGHT = 1203,
        TMT_CAPTIONBARWIDTH = 1204,
        TMT_CAPTIONBARHEIGHT = 1205,
        TMT_SMCAPTIONBARWIDTH = 1206,
        TMT_SMCAPTIONBARHEIGHT = 1207,
        TMT_MENUBARWIDTH = 1208,
        TMT_MENUBARHEIGHT = 1209,
        TMT_FIRSTSIZE = TMT_SIZINGBORDERWIDTH,
        TMT_LASTSIZE = TMT_MENUBARHEIGHT,
        TMT_MINCOLORDEPTH = 1301,
        TMT_FIRSTINT = TMT_MINCOLORDEPTH,
        TMT_LASTINT = TMT_MINCOLORDEPTH,
            /* String theme metric properties */
        TMT_CSSNAME = 1401,
        TMT_XMLNAME = 1402,
        TMT_FIRSTSTRING = TMT_CSSNAME,
        TMT_LASTSTRING = TMT_XMLNAME,

        /* Color theme metric properties */
         TMT_SCROLLBAR = 1601,
         TMT_BACKGROUND = 1602,
         TMT_ACTIVECAPTION = 1603,
         TMT_INACTIVECAPTION = 1604,
         TMT_MENU = 1605,
         TMT_WINDOW = 1606,
         TMT_WINDOWFRAME = 1607,
         TMT_MENUTEXT = 1608,
         TMT_WINDOWTEXT = 1609,
         TMT_CAPTIONTEXT = 1610,
         TMT_ACTIVEBORDER = 1611,
         TMT_INACTIVEBORDER = 1612,
         TMT_APPWORKSPACE = 1613,
         TMT_HIGHLIGHT = 1614,
         TMT_HIGHLIGHTTEXT = 1615,
         TMT_BTNFACE = 1616,
         TMT_BTNSHADOW = 1617,
         TMT_GRAYTEXT = 1618,
         TMT_BTNTEXT = 1619,
         TMT_INACTIVECAPTIONTEXT = 1620,
         TMT_BTNHIGHLIGHT = 1621,
         TMT_DKSHADOW3D = 1622,
         TMT_LIGHT3D = 1623,
         TMT_INFOTEXT = 1624,
         TMT_INFOBK = 1625,
         TMT_BUTTONALTERNATEFACE = 1626,
         TMT_HOTTRACKING = 1627,
         TMT_GRADIENTACTIVECAPTION = 1628,
         TMT_GRADIENTINACTIVECAPTION = 1629,
         TMT_MENUHILIGHT = 1630,
         TMT_MENUBAR = 1631,
         TMT_FIRSTCOLOR = TMT_SCROLLBAR,
         TMT_LASTCOLOR = TMT_MENUBAR,


        /* hue substitutions */
         TMT_FROMHUE1 = 1801,
         TMT_FROMHUE2 = 1802,
         TMT_FROMHUE3 = 1803,
         TMT_FROMHUE4 = 1804,
         TMT_FROMHUE5 = 1805,
         TMT_TOHUE1 = 1806,
         TMT_TOHUE2 = 1807,
         TMT_TOHUE3 = 1808,
         TMT_TOHUE4 = 1809,
         TMT_TOHUE5 = 1810,

        /* color substitutions */
         TMT_FROMCOLOR1 = 2001,
         TMT_FROMCOLOR2 = 2002,
         TMT_FROMCOLOR3 = 2003,
         TMT_FROMCOLOR4 = 2004,
         TMT_FROMCOLOR5 = 2005,
         TMT_TOCOLOR1 = 2006,
         TMT_TOCOLOR2 = 2007,
         TMT_TOCOLOR3 = 2008,
         TMT_TOCOLOR4 = 2009,
         TMT_TOCOLOR5 = 2010,


        /* Bool rendering properties */
         TMT_TRANSPARENT = 2201,
         TMT_AUTOSIZE = 2202,
         TMT_BORDERONLY = 2203,
         TMT_COMPOSITED = 2204,
         TMT_BGFILL = 2205,
         TMT_GLYPHTRANSPARENT = 2206,
         TMT_GLYPHONLY = 2207,
         TMT_ALWAYSSHOWSIZINGBAR = 2208,
         TMT_MIRRORIMAGE = 2209,
         TMT_UNIFORMSIZING = 2210,
         TMT_INTEGRALSIZING = 2211,
         TMT_SOURCEGROW = 2212,
         TMT_SOURCESHRINK = 2213,

        /* Int rendering properties */
         TMT_IMAGECOUNT = 2401,
         TMT_ALPHALEVEL = 2402,
         TMT_BORDERSIZE = 2403,
         TMT_ROUNDCORNERWIDTH = 2404,
         TMT_ROUNDCORNERHEIGHT = 2405,
         TMT_GRADIENTRATIO1 = 2406,
         TMT_GRADIENTRATIO2 = 2407,
         TMT_GRADIENTRATIO3 = 2408,
         TMT_GRADIENTRATIO4 = 2409,
         TMT_GRADIENTRATIO5 = 2410,
         TMT_PROGRESSCHUNKSIZE = 2411,
         TMT_PROGRESSSPACESIZE = 2412,
         TMT_SATURATION = 2413,
         TMT_TEXTBORDERSIZE = 2414,
         TMT_ALPHATHRESHOLD = 2415,
         TMT_WIDTH = 2416,
         TMT_HEIGHT = 2417,
         TMT_GLYPHINDEX = 2418,
         TMT_TRUESIZESTRETCHMARK = 2419,
         TMT_MINDPI1 = 2420,
         TMT_MINDPI2 = 2421,
         TMT_MINDPI3 = 2422,
         TMT_MINDPI4 = 2423,
         TMT_MINDPI5 = 2424,

        /* Font rendering properties */
         TMT_GLYPHFONT = 2601,

        /* Filename rendering properties */
         TMT_IMAGEFILE = 3001,
         TMT_IMAGEFILE1 = 3002,
         TMT_IMAGEFILE2 = 3003,
         TMT_IMAGEFILE3 = 3004,
         TMT_IMAGEFILE4 = 3005,
         TMT_IMAGEFILE5 = 3006,
         TMT_STOCKIMAGEFILE = 3007,
         TMT_GLYPHIMAGEFILE = 3008,

        /* String rendering properties */
         TMT_TEXT = 3201,

        /* Position rendering properties */
         TMT_OFFSET = 3401,
         TMT_TEXTSHADOWOFFSET = 3402,
         TMT_MINSIZE = 3403,
         TMT_MINSIZE1 = 3404,
         TMT_MINSIZE2 = 3405,
         TMT_MINSIZE3 = 3406,
         TMT_MINSIZE4 = 3407,
         TMT_MINSIZE5 = 3408,
         TMT_NORMALSIZE = 3409,

        /* Margin rendering properties */
         TMT_SIZINGMARGINS = 3601,
         TMT_CONTENTMARGINS = 3602,
         TMT_CAPTIONMARGINS = 3603,

        /* Color rendering properties */
         TMT_BORDERCOLOR = 3801,
         TMT_FILLCOLOR = 3802,
         TMT_TEXTCOLOR = 3803,
         TMT_EDGELIGHTCOLOR = 3804,
         TMT_EDGEHIGHLIGHTCOLOR = 3805,
         TMT_EDGESHADOWCOLOR = 3806,
         TMT_EDGEDKSHADOWCOLOR = 3807,
         TMT_EDGEFILLCOLOR = 3808,
         TMT_TRANSPARENTCOLOR = 3809,
         TMT_GRADIENTCOLOR1 = 3810,
         TMT_GRADIENTCOLOR2 = 3811,
         TMT_GRADIENTCOLOR3 = 3812,
         TMT_GRADIENTCOLOR4 = 3813,
         TMT_GRADIENTCOLOR5 = 3814,
         TMT_SHADOWCOLOR = 3815,
         TMT_GLOWCOLOR = 3816,
         TMT_TEXTBORDERCOLOR = 3817,
         TMT_TEXTSHADOWCOLOR = 3818,
         TMT_GLYPHTEXTCOLOR = 3819,
         TMT_GLYPHTRANSPARENTCOLOR = 3820,
         TMT_FILLCOLORHINT = 3821,
         TMT_BORDERCOLORHINT = 3822,
         TMT_ACCENTCOLORHINT = 3823,

        /* Enum rendering properties */
         TMT_BGTYPE = 4001,
         TMT_BORDERTYPE = 4002,
         TMT_FILLTYPE = 4003,
         TMT_SIZINGTYPE = 4004,
         TMT_HALIGN = 4005,
         TMT_CONTENTALIGNMENT = 4006,
         TMT_VALIGN = 4007,
         TMT_OFFSETTYPE = 4008,
         TMT_ICONEFFECT = 4009,
         TMT_TEXTSHADOWTYPE = 4010,
         TMT_IMAGELAYOUT = 4011,
         TMT_GLYPHTYPE = 4012,
         TMT_IMAGESELECTTYPE = 4013,
         TMT_GLYPHFONTSIZINGTYPE = 4014,
         TMT_TRUESIZESCALINGTYPE = 4015,

        /* custom properties */
         TMT_USERPICTURE = 5001,
         TMT_DEFAULTPANESIZE = 5002,
         TMT_BLENDCOLOR = 5003;

        public const int
        BTNS_WHOLEDROPDOWN = 0x0080;

        public const int
        DWL_MSGRESULT = 0,
        DWL_DLGPROC = 4,
        DWL_USER = 8;

        public const int
        MSGF_DIALOGBOX = 0,
        MSGF_MESSAGEBOX = 1,
        MSGF_MENU = 2,
        MSGF_SCROLLBAR = 5,
        MSGF_NEXTWINDOW = 6,
        MSGF_MAX = 8,
        MSGF_USER = 4096;

        public const int
        WH_MIN = (-1),
        WH_MSGFILTER = (-1),
        WH_JOURNALRECORD = 0,
        WH_JOURNALPLAYBACK = 1,
        WH_KEYBOARD = 2,
        WH_GETMESSAGE = 3,
        WH_CALLWNDPROC = 4,
        WH_CBT = 5,
        WH_SYSMSGFILTER = 6,
        WH_MOUSE = 7,
        WH_HARDWARE = 8,
        WH_DEBUG = 9,
        WH_SHELL = 10,
        WH_FOREGROUNDIDLE = 11,
        WH_CALLWNDPROCRET = 12,
        WH_KEYBOARD_LL = 13,
        WH_MOUSE_LL = 14,
        WH_MINHOOK = WH_MIN,
            /*
             * Hook Codes
             */
        HC_ACTION = 0,
        HC_GETNEXT = 1,
        HC_SKIP = 2,
        HC_NOREMOVE = 3,
        HC_NOREM = HC_NOREMOVE,
        HC_SYSMODALON = 4,
        HC_SYSMODALOFF = 5,
            /*
             * CBT Hook Codes
             */
        HCBT_MOVESIZE = 0,
        HCBT_MINMAX = 1,
        HCBT_QS = 2,
        HCBT_CREATEWND = 3,
        HCBT_DESTROYWND = 4,
        HCBT_ACTIVATE = 5,
        HCBT_CLICKSKIPPED = 6,
        HCBT_KEYSKIPPED = 7,
        HCBT_SYSCOMMAND = 8,
        HCBT_SETFOCUS = 9;

        public const int
         CTLCOLOR_MSGBOX = 0,
         CTLCOLOR_EDIT = 1,
         CTLCOLOR_LISTBOX = 2,
         CTLCOLOR_BTN = 3,
         CTLCOLOR_DLG = 4,
         CTLCOLOR_SCROLLBAR = 5,
         CTLCOLOR_STATIC = 6,
         CTLCOLOR_MAX = 7,
         COLOR_SCROLLBAR = 0,
         COLOR_BACKGROUND = 1,
         COLOR_ACTIVECAPTION = 2,
         COLOR_INACTIVECAPTION = 3,
         COLOR_MENU = 4,
         COLOR_WINDOW = 5,
         COLOR_WINDOWFRAME = 6,
         COLOR_MENUTEXT = 7,
         COLOR_WINDOWTEXT = 8,
         COLOR_CAPTIONTEXT = 9,
         COLOR_ACTIVEBORDER = 10,
         COLOR_INACTIVEBORDER = 11,
         COLOR_APPWORKSPACE = 12,
         COLOR_HIGHLIGHT = 13,
         COLOR_HIGHLIGHTTEXT = 14,
         COLOR_BTNFACE = 15,
         COLOR_BTNSHADOW = 16,
         COLOR_GRAYTEXT = 17,
         COLOR_BTNTEXT = 18,
         COLOR_INACTIVECAPTIONTEXT = 19,
         COLOR_BTNHIGHLIGHT = 20,
         COLOR_3DDKSHADOW = 21,
         COLOR_3DLIGHT = 22,
         COLOR_INFOTEXT = 23,
         COLOR_INFOBK = 24,
         COLOR_HOTLIGHT = 26,
         COLOR_GRADIENTACTIVECAPTION = 27,
         COLOR_GRADIENTINACTIVECAPTION = 28,
         COLOR_MENUHILIGHT = 29,
         COLOR_MENUBAR = 30,
         COLOR_DESKTOP = COLOR_BACKGROUND,
         COLOR_3DFACE = COLOR_BTNFACE,
         COLOR_3DSHADOW = COLOR_BTNSHADOW,
         COLOR_3DHIGHLIGHT = COLOR_BTNHIGHLIGHT,
         COLOR_3DHILIGHT = COLOR_BTNHIGHLIGHT,
         COLOR_BTNHILIGHT = COLOR_BTNHIGHLIGHT;

        public const int
            /* WM_PRINT flags */
        PRF_CHECKVISIBLE = 0x00000001,
        PRF_NONCLIENT = 0x00000002,
        PRF_CLIENT = 0x00000004,
        PRF_ERASEBKGND = 0x00000008,
        PRF_CHILDREN = 0x00000010,
        PRF_OWNED = 0x00000020,
            /* 3D border styles */
        BDR_RAISEDOUTER = 0x0001,
        BDR_SUNKENOUTER = 0x0002,
        BDR_RAISEDINNER = 0x0004,
        BDR_SUNKENINNER = 0x0008,
        BDR_OUTER = (BDR_RAISEDOUTER | BDR_SUNKENOUTER),
        BDR_INNER = (BDR_RAISEDINNER | BDR_SUNKENINNER),
        BDR_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER),
        BDR_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER),
        EDGE_RAISED = (BDR_RAISEDOUTER | BDR_RAISEDINNER),
        EDGE_SUNKEN = (BDR_SUNKENOUTER | BDR_SUNKENINNER),
        EDGE_ETCHED = (BDR_SUNKENOUTER | BDR_RAISEDINNER),
        EDGE_BUMP = (BDR_RAISEDOUTER | BDR_SUNKENINNER),
            /* Border flags */
        BF_LEFT = 0x0001,
        BF_TOP = 0x0002,
        BF_RIGHT = 0x0004,
        BF_BOTTOM = 0x0008,
        BF_TOPLEFT = (BF_TOP | BF_LEFT),
        BF_TOPRIGHT = (BF_TOP | BF_RIGHT),
        BF_BOTTOMLEFT = (BF_BOTTOM | BF_LEFT),
        BF_BOTTOMRIGHT = (BF_BOTTOM | BF_RIGHT),
        BF_RECT = (BF_LEFT | BF_TOP | BF_RIGHT | BF_BOTTOM),
        BF_DIAGONAL = 0x0010,
            // For diagonal lines, the BF_RECT flags specify the end point of the
            // vector bounded by the rectangle parameter.
        BF_DIAGONAL_ENDTOPRIGHT = (BF_DIAGONAL | BF_TOP | BF_RIGHT),
        BF_DIAGONAL_ENDTOPLEFT = (BF_DIAGONAL | BF_TOP | BF_LEFT),
        BF_DIAGONAL_ENDBOTTOMLEFT = (BF_DIAGONAL | BF_BOTTOM | BF_LEFT),
        BF_DIAGONAL_ENDBOTTOMRIGHT = (BF_DIAGONAL | BF_BOTTOM | BF_RIGHT),
        BF_MIDDLE = 0x0800, /* Fill in the middle */
        BF_SOFT = 0x1000,  /* For softer buttons */
        BF_ADJUST = 0x2000, /* Calculate the space left over */
        BF_FLAT = 0x4000,  /* For flat rather than 3D borders */
        BF_MONO = 0x8000;  /* For monochrome borders */

        public const int
        LWS_TRANSPARENT = 0x0001,
        LWS_IGNORERETURN = 0x0002,
        LIF_ITEMINDEX = 0x00000001,
        LIF_STATE = 0x00000002,
        LIF_ITEMID = 0x00000004,
        LIF_URL = 0x00000008,
        LIS_FOCUSED = 0x00000001,
        LIS_ENABLED = 0x00000002,
        LIS_VISITED = 0x00000004,
        LM_HITTEST = (WM_USER + 0x300),
        LM_GETIDEALHEIGHT = (WM_USER + 0x301),
        LM_SETITEM = (WM_USER + 0x302),
        LM_GETITEM = (WM_USER + 0x303);


        public const int
        DL_BEGINDRAG = (WM_USER + 133),
        DL_DRAGGING = (WM_USER + 134),
        DL_DROPPED = (WM_USER + 135),
        DL_CANCELDRAG = (WM_USER + 136),
        DL_CURSORSET = 0,
        DL_STOPCURSOR = 1,
        DL_COPYCURSOR = 2,
        DL_MOVECURSOR = 3;

        public const int
        HOTKEYF_SHIFT = 0x01,
        HOTKEYF_CONTROL = 0x02,
        HOTKEYF_ALT = 0x04,
        HKCOMB_NONE = 0x0001,
        HKCOMB_S = 0x0002,
        HKCOMB_C = 0x0004,
        HKCOMB_A = 0x0008,
        HKCOMB_SC = 0x0010,
        HKCOMB_SA = 0x0020,
        HKCOMB_CA = 0x0040,
        HKCOMB_SCA = 0x0080,
        HKM_SETHOTKEY = (WM_USER + 1),
        HKM_GETHOTKEY = (WM_USER + 2),
        HKM_SETRULES = (WM_USER + 3);
        //Pager
        public const int
        PGN_CALCSIZE = ((0 - 900) - 2),
        PGN_HOTITEMCHANGE = ((0 - 900) - 3),
        PGF_CALCWIDTH = 1,
        PGF_CALCHEIGHT = 2,
        PGM_FIRST = 0x1400,
        PGS_VERT = 0x00000000,
        PGS_HORZ = 0x00000001,
        PGS_AUTOSCROLL = 0x00000002,
        PGS_DRAGNDROP = 0x00000004,
        PGF_INVISIBLE = 0,   // Scroll button is not visible
        PGF_NORMAL = 1,     // Scroll button is in normal state
        PGF_GRAYED = 2,     // Scroll button is in grayed state
        PGF_DEPRESSED = 4,   // Scroll button is in depressed state
        PGF_HOT = 8,      // Scroll button is in hot state


// The following identifiers specifies the button control
        PGB_TOPORLEFT = 0,
        PGB_BOTTOMORRIGHT = 1,

//---------------------------------------------------------------------------------------
            // Pager Control  Messages
            //---------------------------------------------------------------------------------------
        PGM_SETCHILD = (PGM_FIRST + 1), // lParam == hwnd
        PGM_RECALCSIZE = (PGM_FIRST + 2),
        PGM_FORWARDMOUSE = (PGM_FIRST + 3),
        PGM_SETBKCOLOR = (PGM_FIRST + 4),
        PGM_GETBKCOLOR = (PGM_FIRST + 5),
        PGM_SETBORDER = (PGM_FIRST + 6),
        PGM_GETBORDER = (PGM_FIRST + 7),
        PGM_SETPOS = (PGM_FIRST + 8),
        PGM_GETPOS = (PGM_FIRST + 9),
        PGM_SETBUTTONSIZE = (PGM_FIRST + 10),
        PGM_GETBUTTONSIZE = (PGM_FIRST + 11),
        PGM_GETBUTTONSTATE = (PGM_FIRST + 12),
        PGM_GETDROPTARGET = CCM_GETDROPTARGET,
        PGN_SCROLL = ((0 - 900) - 1),
        PGF_SCROLLUP = 1,
        PGF_SCROLLDOWN = 2,
        PGF_SCROLLLEFT = 4,
        PGF_SCROLLRIGHT = 8,
        PGK_SHIFT = 1,
        PGK_CONTROL = 2,
        PGK_MENU = 4;
        //IP Address
        public const int
        IPN_FIRST = (0 - 860),
        IPN_FIELDCHANGED = (IPN_FIRST - 0),
        IPM_CLEARADDRESS = (WM_USER + 100), // no parameters
        IPM_SETADDRESS = (WM_USER + 101), // lparam = TCP/IP address
        IPM_GETADDRESS = (WM_USER + 102), // lresult = # of non black fields.  lparam = LPDWORD for TCP/IP address
        IPM_SETRANGE = (WM_USER + 103),// wparam = field, lparam = range
        IPM_SETFOCUS = (WM_USER + 104), // wparam = field
        IPM_ISBLANK = (WM_USER + 105); // no parameters
        //ComboBox
        public const int
        CBEN_DRAGBEGINA = (CBEN_FIRST - 8),
        CBEN_DRAGBEGINW = (CBEN_FIRST - 9),
        CBEN_FIRST = (0 - 800),
        CBEN_INSERTITEM = (CBEN_FIRST - 1),
        CBEN_DELETEITEM = (CBEN_FIRST - 2),
        CBEN_BEGINEDIT = (CBEN_FIRST - 4),
        CBEN_ENDEDITA = (CBEN_FIRST - 5),
        CBEN_ENDEDITW = (CBEN_FIRST - 6),
        CBEIF_TEXT = 0x00000001,
        CBEIF_IMAGE = 0x00000002,
        CBEIF_SELECTEDIMAGE = 0x00000004,
        CBEIF_OVERLAY = 0x00000008,
        CBEIF_INDENT = 0x00000010,
        CBEIF_LPARAM = 0x00000020,
        CBEIF_DI_SETITEM = 0x10000000,
        CBS_SIMPLE = 0x0001,
        CBS_DROPDOWN = 0x0002,
        CBS_DROPDOWNLIST = 0x0003,
        CBS_OWNERDRAWFIXED = 0x0010,
        CBS_OWNERDRAWVARIABLE = 0x0020,
        CBS_AUTOHSCROLL = 0x0040,
        CBS_OEMCONVERT = 0x0080,
        CBS_SORT = 0x0100,
        CBS_HASSTRINGS = 0x0200,
        CBS_NOINTEGRALHEIGHT = 0x0400,
        CBS_DISABLENOSCROLL = 0x0800,
        CBS_UPPERCASE = 0x2000,
        CBS_LOWERCASE = 0x4000,
        CBEM_INSERTITEMA = (WM_USER + 1),
        CBEM_SETIMAGELIST = (WM_USER + 2),
        CBEM_GETIMAGELIST = (WM_USER + 3),
        CBEM_GETITEMA = (WM_USER + 4),
        CBEM_SETITEMA = (WM_USER + 5),
        CBEM_DELETEITEM = CB_DELETESTRING,
        CBEM_GETCOMBOCONTROL = (WM_USER + 6),
        CBEM_GETEDITCONTROL = (WM_USER + 7),
        CBEM_SETEXSTYLE = (WM_USER + 8), // use  SETEXTENDEDSTYLE instead
        CBEM_SETEXTENDEDSTYLE = (WM_USER + 14),  // lparam == new style, wParam (optional) == mask
        CBEM_GETEXSTYLE = (WM_USER + 9), // use GETEXTENDEDSTYLE instead
        CBEM_GETEXTENDEDSTYLE = (WM_USER + 9),
        CBEM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT,
        CBEM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT,
        CBEM_HASEDITCHANGED = (WM_USER + 10),
        CBEM_INSERTITEMW = (WM_USER + 11),
        CBEM_SETITEMW = (WM_USER + 12),
        CBEM_GETITEMW = (WM_USER + 13),
        CBEM_SETWINDOWTHEME = CCM_SETWINDOWTHEME,
        CBES_EX_NOEDITIMAGE = 0x00000001,
        CBES_EX_NOEDITIMAGEINDENT = 0x00000002,
        CBES_EX_PATHWORDBREAKPROC = 0x00000004,
        CBES_EX_NOSIZELIMIT = 0x00000008,
        CBES_EX_CASESENSITIVE = 0x00000010;

        public const int
        CCS_TOP = 0x00000001,
        CCS_NOMOVEY = 0x00000002,
        CCS_BOTTOM = 0x00000003,
        CCS_NORESIZE = 0x00000004,
        CCS_NOPARENTALIGN = 0x00000008,
        CCS_ADJUSTABLE = 0x00000020,
        CCS_NODIVIDER = 0x00000040,
        CCS_VERT = 0x00000080,
        CCS_LEFT = (CCS_VERT | CCS_TOP),
        CCS_RIGHT = (CCS_VERT | CCS_BOTTOM),
        CCS_NOMOVEX = (CCS_VERT | CCS_NOMOVEY);

        public const int
        ACS_CENTER = 0x0001,
        ACS_TRANSPARENT = 0x0002,
        ACS_AUTOPLAY = 0x0004,
        ACS_TIMER = 0x0008,
        ACM_OPENA = (WM_USER + 100),
        ACM_OPENW = (WM_USER + 103),
        ACM_PLAY = (WM_USER + 101),
        ACM_STOP = (WM_USER + 102),
        ACN_START = 1,
        ACN_STOP = 2;

        public const int
        HDI_WIDTH = 0x0001,
        HDI_HEIGHT = HDI_WIDTH,
        HDI_TEXT = 0x0002,
        HDI_FORMAT = 0x0004,
        HDI_LPARAM = 0x0008,
        HDI_BITMAP = 0x0010,
        HDI_IMAGE = 0x0020,
        HDI_DI_SETITEM = 0x0040,
        HDI_ORDER = 0x0080,
        HDI_FILTER = 0x0100,
        HDF_LEFT = 0x0000,
        HDF_RIGHT = 0x0001,
        HDF_CENTER = 0x0002,
        HDF_JUSTIFYMASK = 0x0003,
        HDF_RTLREADING = 0x0004,
        HDF_OWNERDRAW = 0x8000,
        HDF_STRING = 0x4000,
        HDF_BITMAP = 0x2000,
        HDF_BITMAP_ON_RIGHT = 0x1000,
        HDF_IMAGE = 0x0800,
        HDF_SORTUP = 0x0400,
        HDF_SORTDOWN = 0x0200;

        public const int
        CCM_SETUNICODEFORMAT = (CCM_FIRST + 5),
        CCM_GETUNICODEFORMAT = (CCM_FIRST + 6),
        HDM_FIRST = 0x1200,
        HDM_LAYOUT = (HDM_FIRST + 5),
        HDM_GETITEMCOUNT = (HDM_FIRST + 0),
        HDM_INSERTITEMA = (HDM_FIRST + 1),
        HDM_INSERTITEMW = (HDM_FIRST + 10),
        HDM_DELETEITEM = (HDM_FIRST + 2),
        HDM_GETITEMA = (HDM_FIRST + 3),
        HDM_GETITEMW = (HDM_FIRST + 11),
        HDM_SETITEMA = (HDM_FIRST + 4),
        HDM_SETITEMW = (HDM_FIRST + 12),
        HDM_HITTEST = (HDM_FIRST + 6),
        HDM_GETITEMRECT = (HDM_FIRST + 7),
        HDM_SETIMAGELIST = (HDM_FIRST + 8),
        HDM_GETIMAGELIST = (HDM_FIRST + 9),
        HDM_ORDERTOINDEX = (HDM_FIRST + 15),
        HDM_CREATEDRAGIMAGE = (HDM_FIRST + 16),
        HDM_GETORDERARRAY = (HDM_FIRST + 17),
        HDM_SETORDERARRAY = (HDM_FIRST + 18),
        HDM_SETHOTDIVIDER = (HDM_FIRST + 19),
        HDM_SETBITMAPMARGIN = (HDM_FIRST + 20),
        HDM_GETBITMAPMARGIN = (HDM_FIRST + 21),
        HDM_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT,
        HDM_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT,
        HDM_SETFILTERCHANGETIMEOUT = (HDM_FIRST + 22),
        HDM_EDITFILTER = (HDM_FIRST + 23),
        HDM_CLEARFILTER = (HDM_FIRST + 24);

        public const int HDN_FIRST = unchecked((int)(0u - 300u));

        public const int
        HDN_ITEMCHANGINGA = (HDN_FIRST - 0),
        HDN_ITEMCHANGINGW = (HDN_FIRST - 20),
        HDN_ITEMCHANGEDA = (HDN_FIRST - 1),
        HDN_ITEMCHANGEDW = (HDN_FIRST - 21),
        HDN_ITEMCLICKA = (HDN_FIRST - 2),
        HDN_ITEMCLICKW = (HDN_FIRST - 22),
        HDN_ITEMDBLCLICKA = (HDN_FIRST - 3),
        HDN_ITEMDBLCLICKW = (HDN_FIRST - 23),
        HDN_DIVIDERDBLCLICKA = (HDN_FIRST - 5),
        HDN_DIVIDERDBLCLICKW = (HDN_FIRST - 25),
        HDN_BEGINTRACKA = (HDN_FIRST - 6),
        HDN_BEGINTRACKW = (HDN_FIRST - 26),
        HDN_ENDTRACKA = (HDN_FIRST - 7),
        HDN_ENDTRACKW = (HDN_FIRST - 27),
        HDN_TRACKA = (HDN_FIRST - 8),
        HDN_TRACKW = (HDN_FIRST - 28),
        HDN_GETDISPINFOA = (HDN_FIRST - 9),
        HDN_GETDISPINFOW = (HDN_FIRST - 29),
        HDN_BEGINDRAG = (HDN_FIRST - 10),
        HDN_ENDDRAG = (HDN_FIRST - 11),
        HDN_FILTERCHANGE = (HDN_FIRST - 12),
        HDN_FILTERBTNCLICK = (HDN_FIRST - 13);

        public const int
        CS_VREDRAW = 0x0001,
        CS_HREDRAW = 0x0002,
        CS_DBLCLKS = 0x0008,
        CS_OWNDC = 0x0020,
        CS_CLASSDC = 0x0040,
        CS_PARENTDC = 0x0080,
        CS_NOCLOSE = 0x0200,
        CS_SAVEBITS = 0x0800,
        CS_BYTEALIGNCLIENT = 0x1000,
        CS_BYTEALIGNWINDOW = 0x2000,
        CS_GLOBALCLASS = 0x4000;

        public const int
        TBMF_PAD = 0x00000001,
        TBMF_BARPAD = 0x00000002,
        TBMF_BUTTONSPACING = 0x00000004;

        public const int
            /*
             * DrawText() Format Flags
            */
        DT_TOP = 0x00000000,
        DT_LEFT = 0x00000000,
        DT_CENTER = 0x00000001,
        DT_RIGHT = 0x00000002,
        DT_VCENTER = 0x00000004,
        DT_BOTTOM = 0x00000008,
        DT_WORDBREAK = 0x00000010,
        DT_SINGLELINE = 0x00000020,
        DT_EXPANDTABS = 0x00000040,
        DT_TABSTOP = 0x00000080,
        DT_NOCLIP = 0x00000100,
        DT_EXTERNALLEADING = 0x00000200,
        DT_CALCRECT = 0x00000400,
        DT_NOPREFIX = 0x00000800,
        DT_INTERNAL = 0x00001000,
        DT_EDITCONTROL = 0x00002000,
        DT_PATH_ELLIPSIS = 0x00004000,
        DT_END_ELLIPSIS = 0x00008000,
        DT_MODIFYSTRING = 0x00010000,
        DT_RTLREADING = 0x00020000,
        DT_WORD_ELLIPSIS = 0x00040000,
        DT_NOFULLWIDTHCHARBREAK = 0x00080000,
        DT_HIDEPREFIX = 0x00100000,
        DT_PREFIXONLY = 0x00200000;

        /*
         * Class field offsets for GetClassLong()
        */
        public const int GCL_MENUNAME = (-8),
        GCL_HBRBACKGROUND = (-10),
        GCL_HCURSOR = (-12),
        GCL_HICON = (-14),
        GCL_HMODULE = (-16),
        GCL_CBWNDEXTRA = (-18),
        GCL_CBCLSEXTRA = (-20),
        GCL_WNDPROC = (-24),
        GCL_STYLE = (-26),
        GCW_ATOM = (-32),
        GCL_HICONSM = (-34),
        GCLP_MENUNAME = (-8),
        GCLP_HBRBACKGROUND = (-10),
        GCLP_HCURSOR = (-12),
        GCLP_HICON = (-14),
        GCLP_HMODULE = (-16),
        GCLP_WNDPROC = (-24),
        GCLP_HICONSM = (-34);

        public const int STATUS_PENDING = 0x103; //259 = STILL_ALIVE 

        public const int
        RBN_FIRST = (0 - 831),
        RBN_HEIGHTCHANGE = (RBN_FIRST - 0),
        RBN_LAST = (0 - 859),
        RBN_CHILDSIZE = RBN_FIRST - 8,
        RBN_GETOBJECT = (RBN_FIRST - 1),
        RBN_LAYOUTCHANGED = (RBN_FIRST - 2),
        RBN_AUTOSIZE = (RBN_FIRST - 3),
        RBN_BEGINDRAG = (RBN_FIRST - 4),
        RBN_ENDDRAG = (RBN_FIRST - 5),
        RBN_DELETINGBAND = (RBN_FIRST - 6),     // Uses NMREBAR
        RBN_DELETEDBAND = (RBN_FIRST - 7),     // Uses NMREBAR
        RBN_CHEVRONPUSHED = (RBN_FIRST - 10),
        RBN_MINMAX = (RBN_FIRST - 21),
        RBN_AUTOBREAK = (RBN_FIRST - 22);

        //RB_GETBANDMARGINS = (WM_USER + 40),
        //RB_BEGINDRAG = (WM_USER + 24),
        //RB_ENDDRAG = (WM_USER + 25),
        //RB_DRAGMOVE = (WM_USER + 26),
        //RB_GETBARHEIGHT = (WM_USER + 27),
        //RB_GETBANDINFOW = (WM_USER + 28),
        //RB_GETBANDINFOA = (WM_USER + 29),
        //RB_MAXIMIZEBAND = (WM_USER + 31),
        //RB_GETDROPTARGET = (CCM_GETDROPTARGET),
        //RB_GETBANDBORDERS = (WM_USER + 34),
        //RB_SHOWBAND = (WM_USER + 35),      // show/hide band
        //RB_SETPALETTE = (WM_USER + 37),
        //RB_GETPALETTE = (WM_USER + 38),
        //RB_MOVEBAND = (WM_USER + 39),
        //RB_SETUNICODEFORMAT = CCM_SETUNICODEFORMAT,
        //RB_GETUNICODEFORMAT = CCM_GETUNICODEFORMAT;

        public const int RBHT_NOWHERE = 0x0001,
        RBHT_CAPTION = 0x0002,
        RBHT_CLIENT = 0x0003,
        RBHT_GRABBER = 0x0004,
        RBHT_CHEVRON = 0x0008;

        public const int
        RBIM_IMAGELIST = 0x00000001,
            /* FONT WEIGHT (BOLD) VALUES */
        FW_DONTCARE = 0,
        FW_NORMAL = 400,
        FW_BOLD = 700,
            // some others... 

        /* FONT CHARACTER SET */
        ANSI_CHARSET = 0,
        DEFAULT_CHARSET = 1,
            // plus others ....

        /* Font OutPrecision */
        OUT_DEFAULT_PRECIS = 0,
        OUT_TT_PRECIS = 4,
        OUT_TT_ONLY_PRECIS = 7,

        /* polygon fill mode */
        ALTERNATE = 1,
        WINDING = 2,

        // text align
        TA_DEFAULT = 0,

        // brush
        BS_SOLID = 0,
        HOLLOW_BRUSH = 5,

        // Binary raster operations.
        R2_BLACK = 1,  /*  0       */
        R2_NOTMERGEPEN = 2,  /* DPon     */
        R2_MASKNOTPEN = 3,  /* DPna     */
        R2_NOTCOPYPEN = 4,  /* PN       */
        R2_MASKPENNOT = 5,  /* PDna     */
        R2_NOT = 6,  /* Dn       */
        R2_XORPEN = 7,  /* DPx      */
        R2_NOTMASKPEN = 8,  /* DPan     */
        R2_MASKPEN = 9,  /* DPa      */
        R2_NOTXORPEN = 10, /* DPxn     */
        R2_NOP = 11, /* D        */
        R2_MERGENOTPEN = 12, /* DPno     */
        R2_COPYPEN = 13, /* P        */
        R2_MERGEPENNOT = 14, /* PDno     */
        R2_MERGEPEN = 15, /* DPo      */
        R2_WHITE = 16 /*  1       */;


        public const int
            /* SetGraphicsMode(hdc, iMode ) */
        GM_COMPATIBLE = 1,
        GM_ADVANCED = 2,
        MWT_IDENTITY = 1;

        public const int
        PAGE_READONLY = 0x02,
        PAGE_READWRITE = 0x04,
        PAGE_WRITECOPY = 0x08,
        FILE_MAP_COPY = 0x0001,
        FILE_MAP_WRITE = 0x0002,
        FILE_MAP_READ = 0x0004;

        public const int SHGFI_ICON = 0x000000100,   // get icon 
        SHGFI_DISPLAYNAME = 0x000000200,     // get display name
        SHGFI_TYPENAME = 0x000000400,     // get type name
        SHGFI_ATTRIBUTES = 0x000000800,     // get attributes
        SHGFI_ICONLOCATION = 0x000001000,     // get icon location 
        SHGFI_EXETYPE = 0x000002000,     // return exe type
        SHGFI_SYSICONINDEX = 0x000004000,     // get system icon index 
        SHGFI_LINKOVERLAY = 0x000008000,     // put a link overlay on icon 
        SHGFI_SELECTED = 0x000010000,     // show icon in selected state
        SHGFI_ATTR_SPECIFIED = 0x000020000,     // get only specified attributes 
        SHGFI_LARGEICON = 0x000000000,     // get large icon
        SHGFI_SMALLICON = 0x000000001,     // get small icon
        SHGFI_OPENICON = 0x000000002,     // get open icon
        SHGFI_SHELLICONSIZE = 0x000000004,     // get shell size icon 
        SHGFI_PIDL = 0x000000008,     // pszPath is a pidl
        SHGFI_USEFILEATTRIBUTES = 0x000000010,     // use passed dwFileAttribute 
        SHGFI_ADDOVERLAYS = 0x000000020,     // apply the appropriate overlays 
        SHGFI_OVERLAYINDEX = 0x000000040;     // Get the index of the overlay

        public const int DM_DISPLAYORIENTATION = 0x00000080;

        public const int AUTOSUGGEST = 0x10000000,
        AUTOSUGGEST_OFF = 0x20000000,
        AUTOAPPEND = 0x40000000,
        AUTOAPPEND_OFF = (unchecked((int)0x80000000));

        public const int ARW_BOTTOMLEFT = 0x0000,
        ARW_BOTTOMRIGHT = 0x0001,
        ARW_TOPLEFT = 0x0002,
        ARW_TOPRIGHT = 0x0003,
        ARW_LEFT = 0x0000,
        ARW_RIGHT = 0x0000,
        ARW_UP = 0x0004,
        ARW_DOWN = 0x0004,
        ARW_HIDE = 0x0008,
        ADVF_NODATA = 1,
        ADVF_ONLYONCE = 4,
        ADVF_PRIMEFIRST = 2;

        public const int
            /* Brush Styles */
            //BS_SOLID = 0,
         BS_NULL = 1,
         BS_HOLLOW = BS_NULL,
         BS_HATCHED = 2,
         BS_PATTERN = 3,
         BS_INDEXED = 4,
         BS_DIBPATTERN = 5,
         BS_DIBPATTERNPT = 6,
         BS_PATTERN8X8 = 7,
         BS_DIBPATTERN8X8 = 8,
         BS_MONOPATTERN = 9,

         /* Hatch Styles */
         HS_HORIZONTAL = 0,   /* ----- */
         HS_VERTICAL = 1,    /* ||||| */
         HS_FDIAGONAL = 2,     /* \\\\\ */
         HS_BDIAGONAL = 3,     /* ///// */
         HS_CROSS = 4,     /* +++++ */
         HS_DIAGCROSS = 5,    /* xxxxx */

         /* Pen Styles */
         PS_SOLID = 0,
         PS_DASH = 1,      /* -------  */
         PS_DOT = 2,     /* .......  */
         PS_DASHDOT = 3,    /* _._._._  */
         PS_DASHDOTDOT = 4,   /* _.._.._  */
         PS_NULL = 5,
         PS_INSIDEFRAME = 6,
         PS_USERSTYLE = 7,
         PS_ALTERNATE = 8,
         PS_STYLE_MASK = 0x0000000F,
         PS_ENDCAP_ROUND = 0x00000000,
         PS_ENDCAP_SQUARE = 0x00000100,
         PS_ENDCAP_FLAT = 0x00000200,
         PS_ENDCAP_MASK = 0x00000F00,
         PS_JOIN_ROUND = 0x00000000,
         PS_JOIN_BEVEL = 0x00001000,
         PS_JOIN_MITER = 0x00002000,
         PS_JOIN_MASK = 0x0000F000,
         PS_COSMETIC = 0x00000000,
         PS_GEOMETRIC = 0x00010000,
         PS_TYPE_MASK = 0x000F0000,

         /* Background Modes */
         TRANSPARENT = 1,
         OPAQUE = 2,
         BKMODE_LAST = 2,

        /* Graphics Modes */
         GM_LAST = 2,

        /* PolyDraw and GetPath point types */
         PT_CLOSEFIGURE = 0x01,
         PT_LINETO = 0x02,
         PT_BEZIERTO = 0x04,
         PT_MOVETO = 0x06,

        /* Mapping Modes */
         MM_TEXT = 1,
         MM_LOMETRIC = 2,
         MM_HIMETRIC = 3,
         MM_LOENGLISH = 4,
         MM_HIENGLISH = 5,
         MM_TWIPS = 6,
         MM_ISOTROPIC = 7,
         MM_ANISOTROPIC = 8,

        /* Min and Max Mapping Mode values */
         MM_MIN = MM_TEXT,
         MM_MAX = MM_ANISOTROPIC,
         MM_MAX_FIXEDSCALE = MM_TWIPS,

        /* Coordinate Modes */
         ABSOLUTE = 1,
         RELATIVE = 2,

        /* Stock Logical Objects */
         WHITE_BRUSH = 0,
         LTGRAY_BRUSH = 1,
         GRAY_BRUSH = 2,
         DKGRAY_BRUSH = 3,
         BLACK_BRUSH = 4,
         NULL_BRUSH = 5,
            //HOLLOW_BRUSH = NULL_BRUSH,
         WHITE_PEN = 6,
         BLACK_PEN = 7,
         NULL_PEN = 8,
         OEM_FIXED_FONT = 10,
         ANSI_FIXED_FONT = 11,
         ANSI_VAR_FONT = 12,
         SYSTEM_FONT = 13,
         DEVICE_DEFAULT_FONT = 14,
         DEFAULT_PALETTE = 15,
         SYSTEM_FIXED_FONT = 16;

        public const int BCM_GETIDEALSIZE = 0x1601,
        BI_RGB = 0,
        BI_RLE8 = 1,
        BI_RLE4 = 2,
        BI_JPEG = 4,
        BI_PNG = 5,
        BITSPIXEL = 12,
        BFFM_INITIALIZED = 1,
        BFFM_SELCHANGED = 2,
        BFFM_SETSELECTIONA = 0x400 + 102,
        BFFM_SETSELECTIONW = 0x400 + 103,
        BFFM_ENABLEOK = 0x400 + 101,
        BS_BITMAP = 0x00000080,
        BS_ICON = 0x00000040,
        BS_PUSHBUTTON = 0x00000000,
        BS_DEFPUSHBUTTON = 0x00000001,
        BS_MULTILINE = 0x00002000,
        BS_PUSHLIKE = 0x00001000,
        BS_OWNERDRAW = 0x0000000B,
        BS_RADIOBUTTON = 0x00000004,
        BS_3STATE = 0x00000005,
        BS_GROUPBOX = 0x00000007,
        BS_LEFT = 0x00000100,
        BS_RIGHT = 0x00000200,
        BS_CENTER = 0x00000300,
        BS_TOP = 0x00000400,
        BS_BOTTOM = 0x00000800,
        BS_VCENTER = 0x00000C00,
        BS_RIGHTBUTTON = 0x00000020,
        BN_CLICKED = 0,
        BM_GETIMAGE = 0x00F6,
        BM_SETIMAGE = 0x00F7,
        BM_SETCHECK = 0x00F1,
        BM_SETSTATE = 0x00F3,
        BM_CLICK = 0x00F5;

        public const int CDERR_DIALOGFAILURE = 0xFFFF,
        CDERR_STRUCTSIZE = 0x0001,
        CDERR_INITIALIZATION = 0x0002,
        CDERR_NOTEMPLATE = 0x0003,
        CDERR_NOHINSTANCE = 0x0004,
        CDERR_LOADSTRFAILURE = 0x0005,
        CDERR_FINDRESFAILURE = 0x0006,
        CDERR_LOADRESFAILURE = 0x0007,
        CDERR_LOCKRESFAILURE = 0x0008,
        CDERR_MEMALLOCFAILURE = 0x0009,
        CDERR_MEMLOCKFAILURE = 0x000A,
        CDERR_NOHOOK = 0x000B,
        CDERR_REGISTERMSGFAIL = 0x000C,
        CFERR_NOFONTS = 0x2001,
        CFERR_MAXLESSTHANMIN = 0x2002,
        CC_RGBINIT = 0x00000001,
        CC_FULLOPEN = 0x00000002,
        CC_PREVENTFULLOPEN = 0x00000004,
        CC_SHOWHELP = 0x00000008,
        CC_ENABLEHOOK = 0x00000010,
        CC_SOLIDCOLOR = 0x00000080,
        CC_ANYCOLOR = 0x00000100,
        CF_SCREENFONTS = 0x00000001,
        CF_SHOWHELP = 0x00000004,
        CF_ENABLEHOOK = 0x00000008,
        CF_INITTOLOGFONTSTRUCT = 0x00000040,
        CF_EFFECTS = 0x00000100,
        CF_APPLY = 0x00000200,
        CF_SCRIPTSONLY = 0x00000400,
        CF_NOVECTORFONTS = 0x00000800,
        CF_NOSIMULATIONS = 0x00001000,
        CF_LIMITSIZE = 0x00002000,
        CF_FIXEDPITCHONLY = 0x00004000,
        CF_FORCEFONTEXIST = 0x00010000,
        CF_TTONLY = 0x00040000,
        CF_SELECTSCRIPT = 0x00400000,
        CF_NOVERTFONTS = 0x01000000,
        CP_WINANSI = 1004;

        public const int
        REO_GETOBJ_ALL_INTERFACES = 7,
        REO_GETOBJ_NO_INTERFACES = 0,
        REO_GETOBJ_POLEOBJ = 1,
        REO_GETOBJ_POLESITE = 4,
        REO_IOB_USE_CP = -2,
        REO_CP_SELECTION = -1,
        REO_IOB_SELECTION = -1,
        REO_GETOBJ_PSTG = 2;

        public const int cmb4 = 0x0473,
        CS_DROPSHADOW = 0x00020000,
        CF_TEXT = 1,
        CF_BITMAP = 2,
        CF_METAFILEPICT = 3,
        CF_SYLK = 4,
        CF_DIF = 5,
        CF_TIFF = 6,
        CF_OEMTEXT = 7,
        CF_DIB = 8,
        CF_PALETTE = 9,
        CF_PENDATA = 10,
        CF_RIFF = 11,
        CF_WAVE = 12,
        CF_UNICODETEXT = 13,
        CF_ENHMETAFILE = 14,
        CF_HDROP = 15,
        CF_LOCALE = 16,
        CLSCTX_INPROC_SERVER = 0x1,
        CLSCTX_LOCAL_SERVER = 0x4,
        CW_USEDEFAULT = (unchecked((int)0x80000000)),
        CWP_SKIPINVISIBLE = 0x0001,
        CB_GETCOMBOBOXINFO = 0x0164,
        CB_ERR = (-1),
        CBN_SELCHANGE = 1,
        CBN_DBLCLK = 2,
        CBN_EDITCHANGE = 5,
        CBN_EDITUPDATE = 6,
        CBN_DROPDOWN = 7,
        CBN_CLOSEUP = 8,
        CBN_SELENDOK = 9,
        CB_GETDROPPEDCONTROLRECT = 0x0152,
        CB_GETEDITSEL = 0x0140,
        CB_LIMITTEXT = 0x0141,
        CB_SETEDITSEL = 0x0142,
        CB_ADDSTRING = 0x0143,
        CB_DELETESTRING = 0x0144,
        CB_GETCURSEL = 0x0147,
        CB_GETLBTEXT = 0x0148,
        CB_GETLBTEXTLEN = 0x0149,
        CB_INSERTSTRING = 0x014A,
        CB_RESETCONTENT = 0x014B,
        CB_FINDSTRING = 0x014C,
        CB_SETCURSEL = 0x014E,
        CB_SHOWDROPDOWN = 0x014F,
        CB_GETITEMDATA = 0x0150,
        CB_SETITEMHEIGHT = 0x0153,
        CB_GETITEMHEIGHT = 0x0154,
        CB_GETDROPPEDSTATE = 0x0157,
        CB_FINDSTRINGEXACT = 0x0158,
        CB_GETDROPPEDWIDTH = 0x015F,
        CB_SETDROPPEDWIDTH = 0x0160,
        CDRF_DODEFAULT = 0x00000000,
        CDRF_NEWFONT = 0x00000002,
        CDRF_SKIPDEFAULT = 0x00000004,
        CDRF_NOTIFYPOSTPAINT = 0x00000010,
        CDRF_NOTIFYITEMDRAW = 0x00000020,
        CDRF_NOTIFYSUBITEMDRAW = CDRF_NOTIFYITEMDRAW,
        CDDS_PREPAINT = 0x00000001,
        CDDS_POSTPAINT = 0x00000002,
        CDDS_ITEM = 0x00010000,
        CDDS_SUBITEM = 0x00020000,
        CDDS_ITEMPREPAINT = (0x00010000 | 0x00000001),
        CDDS_ITEMPOSTPAINT = (0x00010000 | 0x00000002),
        CDIS_SELECTED = 0x0001,
        CDIS_GRAYED = 0x0002,
        CDIS_DISABLED = 0x0004,
        CDIS_CHECKED = 0x0008,
        CDIS_FOCUS = 0x0010,
        CDIS_DEFAULT = 0x0020,
        CDIS_HOT = 0x0040,
        CDIS_MARKED = 0x0080,
        CDIS_INDETERMINATE = 0x0100,
        CDIS_SHOWKEYBOARDCUES = 0x0200,
        CLR_NONE = unchecked((int)0xFFFFFFFF),
        CLR_DEFAULT = unchecked((int)0xFF000000),
        CCM_SETVERSION = (0x2000 + 0x7),
        CCM_GETVERSION = (0x2000 + 0x8),
        CONNECT_E_NOCONNECTION = unchecked((int)0x80040200),
        CONNECT_E_CANNOTCONNECT = unchecked((int)0x80040202),
        CTRLINFO_EATS_RETURN = 1,
        CTRLINFO_EATS_ESCAPE = 2,
        CSIDL_DESKTOP = 0x0000,        // <desktop>
        CSIDL_INTERNET = 0x0001,        // Internet Explorer (icon on desktop) 
        CSIDL_PROGRAMS = 0x0002,        // Start Menu\Programs
        CSIDL_PERSONAL = 0x0005,        // My Documents 
        CSIDL_FAVORITES = 0x0006,        // <user name>\Favorites 
        CSIDL_STARTUP = 0x0007,        // Start Menu\Programs\Startup
        CSIDL_RECENT = 0x0008,        // <user name>\Recent 
        CSIDL_SENDTO = 0x0009,        // <user name>\SendTo
        CSIDL_STARTMENU = 0x000b,        // <user name>\Start Menu
        CSIDL_DESKTOPDIRECTORY = 0x0010,        // <user name>\Desktop
        CSIDL_TEMPLATES = 0x0015,
        CSIDL_APPDATA = 0x001a,        // <user name>\Application Data
        CSIDL_LOCAL_APPDATA = 0x001c,        // <user name>\Local Settings\Applicaiton Data (non roaming) 
        CSIDL_INTERNET_CACHE = 0x0020,
        CSIDL_COOKIES = 0x0021,
        CSIDL_HISTORY = 0x0022,
        CSIDL_COMMON_APPDATA = 0x0023,        // All Users\Application Data
        CSIDL_SYSTEM = 0x0025,        // GetSystemDirectory()
        CSIDL_PROGRAM_FILES = 0x0026,        // C:\Program Files
        CSIDL_PROGRAM_FILES_COMMON = 0x002b;        // C:\Program Files\Common 

        public const int DUPLICATE = 0x06,
        DISPID_UNKNOWN = (-1),
        DISPID_PROPERTYPUT = (-3),
        DISPATCH_METHOD = 0x1,
        DISPATCH_PROPERTYGET = 0x2,
        DISPATCH_PROPERTYPUT = 0x4,
        DV_E_DVASPECT = unchecked((int)0x8004006B),
        DISP_E_MEMBERNOTFOUND = unchecked((int)0x80020003),
        DISP_E_PARAMNOTFOUND = unchecked((int)0x80020004),
        DISP_E_EXCEPTION = unchecked((int)0x80020009),
        DEFAULT_GUI_FONT = 17,
        DIB_RGB_COLORS = 0,
        DRAGDROP_E_NOTREGISTERED = unchecked((int)0x80040100),
        DRAGDROP_E_ALREADYREGISTERED = unchecked((int)0x80040101),
        DUPLICATE_SAME_ACCESS = 0x00000002,
        DFC_CAPTION = 1,
        DFC_MENU = 2,
        DFC_SCROLL = 3,
        DFC_BUTTON = 4,
        DFCS_CAPTIONCLOSE = 0x0000,
        DFCS_CAPTIONMIN = 0x0001,
        DFCS_CAPTIONMAX = 0x0002,
        DFCS_CAPTIONRESTORE = 0x0003,
        DFCS_CAPTIONHELP = 0x0004,
        DFCS_MENUARROW = 0x0000,
        DFCS_MENUCHECK = 0x0001,
        DFCS_MENUBULLET = 0x0002,
        DFCS_SCROLLUP = 0x0000,
        DFCS_SCROLLDOWN = 0x0001,
        DFCS_SCROLLLEFT = 0x0002,
        DFCS_SCROLLRIGHT = 0x0003,
        DFCS_SCROLLCOMBOBOX = 0x0005,
        DFCS_BUTTONCHECK = 0x0000,
        DFCS_BUTTONRADIO = 0x0004,
        DFCS_BUTTON3STATE = 0x0008,
        DFCS_BUTTONPUSH = 0x0010,
        DFCS_INACTIVE = 0x0100,
        DFCS_PUSHED = 0x0200,
        DFCS_CHECKED = 0x0400,
        DFCS_FLAT = 0x4000,
        DCX_WINDOW = 0x00000001,
        DCX_CACHE = 0x00000002,
        DCX_LOCKWINDOWUPDATE = 0x00000400,
        DCX_INTERSECTRGN = 0x00000080,
        DI_NORMAL = 0x0003,
        DLGC_WANTARROWS = 0x0001,
        DLGC_WANTTAB = 0x0002,
        DLGC_WANTALLKEYS = 0x0004,
        DLGC_WANTCHARS = 0x0080,
        DLGC_WANTMESSAGE = 0x0004,      /* Pass message to control          */
        DLGC_HASSETSEL = 0x0008,      /* Understands EM_SETSEL message    */
        DTM_GETSYSTEMTIME = (0x1000 + 1),
        DTM_SETSYSTEMTIME = (0x1000 + 2),
        DTM_SETRANGE = (0x1000 + 4),
        DTM_SETFORMATA = (0x1000 + 5),
        DTM_SETFORMATW = (0x1000 + 50),
        DTM_SETMCCOLOR = (0x1000 + 6),
        DTM_GETMONTHCAL = (0x1000 + 8),
        DTM_SETMCFONT = (0x1000 + 9),
        DTS_UPDOWN = 0x0001,
        DTS_SHOWNONE = 0x0002,
        DTS_LONGDATEFORMAT = 0x0004,
        DTS_TIMEFORMAT = 0x0009,
        DTS_RIGHTALIGN = 0x0020,
        DTN_DATETIMECHANGE = ((0 - 760) + 1),
        DTN_USERSTRINGA = ((0 - 760) + 2),
        DTN_USERSTRINGW = ((0 - 760) + 15),
        DTN_WMKEYDOWNA = ((0 - 760) + 3),
        DTN_WMKEYDOWNW = ((0 - 760) + 16),
        DTN_FORMATA = ((0 - 760) + 4),
        DTN_FORMATW = ((0 - 760) + 17),
        DTN_FORMATQUERYA = ((0 - 760) + 5),
        DTN_FORMATQUERYW = ((0 - 760) + 18),
        DTN_DROPDOWN = ((0 - 760) + 6),
        DTN_CLOSEUP = ((0 - 760) + 7),
        DVASPECT_CONTENT = 1,
        DVASPECT_TRANSPARENT = 32,
        DVASPECT_OPAQUE = 16;

        public const int E_NOTIMPL = unchecked((int)0x80004001),
        E_OUTOFMEMORY = unchecked((int)0x8007000E),
        E_INVALIDARG = unchecked((int)0x80070057),
        E_NOINTERFACE = unchecked((int)0x80004002),
        E_FAIL = unchecked((int)0x80004005),
        E_ABORT = unchecked((int)0x80004004),
        E_UNEXPECTED = unchecked((int)0x8000FFFF),
        INET_E_DEFAULT_ACTION = unchecked((int)0x800C0011),
        ETO_OPAQUE = 0x0002,
        ETO_CLIPPED = 0x0004,
        EMR_POLYTEXTOUTA = 96,
        EMR_POLYTEXTOUTW = 97,
        ES_LEFT = 0x0000,
        ES_CENTER = 0x0001,
        ES_RIGHT = 0x0002,
        ES_MULTILINE = 0x0004,
        ES_UPPERCASE = 0x0008,
        ES_LOWERCASE = 0x0010,
        ES_AUTOVSCROLL = 0x0040,
        ES_AUTOHSCROLL = 0x0080,
        ES_NOHIDESEL = 0x0100,
        ES_READONLY = 0x0800,
        ES_PASSWORD = 0x0020,
        EN_SETFOCUS = 0x0100,
        EN_KILLFOCUS = 0x0200,
        EN_CHANGE = 0x0300,
        EN_UPDATE = 0x0400,
        EN_HSCROLL = 0x0601,
        EN_VSCROLL = 0x0602,
        EN_ALIGN_LTR_EC = 0x0700,
        EN_ALIGN_RTL_EC = 0x0701,
        EC_LEFTMARGIN = 0x0001,
        EC_RIGHTMARGIN = 0x0002,
        EM_GETSEL = 0x00B0,
        EM_SETSEL = 0x00B1,
        EM_SCROLL = 0x00B5,
        EM_SCROLLCARET = 0x00B7,
        EM_GETMODIFY = 0x00B8,
        EM_SETMODIFY = 0x00B9,
        EM_GETLINECOUNT = 0x00BA,
        EM_REPLACESEL = 0x00C2,
        EM_GETLINE = 0x00C4,
        EM_LIMITTEXT = 0x00C5,
        EM_CANUNDO = 0x00C6,
        EM_UNDO = 0x00C7,
        EM_SETPASSWORDCHAR = 0x00CC,
        EM_GETPASSWORDCHAR = 0x00D2,
        EM_EMPTYUNDOBUFFER = 0x00CD,
        EM_SETREADONLY = 0x00CF,
        EM_SETMARGINS = 0x00D3,
        EM_POSFROMCHAR = 0x00D6,
        EM_CHARFROMPOS = 0x00D7,
        EM_LINEFROMCHAR = 0x00C9,
        EM_GETFIRSTVISIBLELINE = 0x00CE,
        EM_LINEINDEX = 0x00BB;

        public const int ERROR_INVALID_HANDLE = 6;
        public const int ERROR_CLASS_ALREADY_EXISTS = 1410;

        public const int FNERR_SUBCLASSFAILURE = 0x3001,
        FNERR_INVALIDFILENAME = 0x3002,
        FNERR_BUFFERTOOSMALL = 0x3003,
        FRERR_BUFFERLENGTHZERO = 0x4001,
        FADF_BSTR = (0x100),
        FADF_UNKNOWN = (0x200),
        FADF_DISPATCH = (0x400),
        FADF_VARIANT = (unchecked((int)0x800)),
        FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000,
        FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200,
        FVIRTKEY = 0x01,
        FSHIFT = 0x04,
        FALT = 0x10;


        public const int GMEM_FIXED = 0x0000,
        GMEM_MOVEABLE = 0x0002,
        GMEM_NOCOMPACT = 0x0010,
        GMEM_NODISCARD = 0x0020,
        GMEM_ZEROINIT = 0x0040,
        GMEM_MODIFY = 0x0080,
        GMEM_DISCARDABLE = 0x0100,
        GMEM_NOT_BANKED = 0x1000,
        GMEM_SHARE = 0x2000,
        GMEM_DDESHARE = 0x2000,
        GMEM_NOTIFY = 0x4000,
        GMEM_LOWER = GMEM_NOT_BANKED,
        GMEM_VALID_FLAGS = 0x7F72,
        GMEM_INVALID_HANDLE = 0x8000,
        GHND = (GMEM_MOVEABLE | GMEM_ZEROINIT),
        GPTR = (GMEM_FIXED | GMEM_ZEROINIT),
        GWL_HWNDPARENT = (-8),
        GWL_STYLE = (-16),
        GWL_EXSTYLE = (-20),
        GWL_ID = (-12),
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_CHILD = 5,
        GMR_VISIBLE = 0,
        GMR_DAYSTATE = 1,
        GDI_ERROR = (unchecked((int)0xFFFFFFFF)),
        GDTR_MIN = 0x0001,
        GDTR_MAX = 0x0002,
        GDT_VALID = 0,
        GDT_NONE = 1,
        GA_PARENT = 1,
        GA_ROOT = 2;

        // ImmGetCompostionString index. 
        public const int
        GCS_COMPSTR = 0x0008,
        GCS_COMPATTR = 0x0010,
        GCS_RESULTSTR = 0x0800,

        // attribute for COMPOSITIONSTRING Structure 
        ATTR_INPUT = 0x00,
        ATTR_TARGET_CONVERTED = 0x01,
        ATTR_CONVERTED = 0x02,
        ATTR_TARGET_NOTCONVERTED = 0x03,
        ATTR_INPUT_ERROR = 0x04,
        ATTR_FIXEDCONVERTED = 0x05,

        // dwAction for ImmNotifyIME
        NI_COMPOSITIONSTR = 0x0015,

        // dwIndex for ImmNotifyIME/NI_COMPOSITIONSTR
        CPS_COMPLETE = 0x01,
        CPS_CANCEL = 0x04;

        public const int
        HTTRANSPARENT = (-1),
        HTNOWHERE = 0,
        HTCLIENT = 1,
        HTLEFT = 10,
        HTBOTTOM = 15,
        HTBOTTOMLEFT = 16,
        HTBOTTOMRIGHT = 17,
        HTBORDER = 18,
        HELPINFO_WINDOW = 0x0001,
        HCF_HIGHCONTRASTON = 0x00000001;

        // Corresponds to bitmaps in MENUITEMINFO 
        public const int HBMMENU_CALLBACK = -1,
        HBMMENU_SYSTEM = 1,
        HBMMENU_MBAR_RESTORE = 2,
        HBMMENU_MBAR_MINIMIZE = 3,
        HBMMENU_MBAR_CLOSE = 5,
        HBMMENU_MBAR_CLOSE_D = 6,
        HBMMENU_MBAR_MINIMIZE_D = 7,
        HBMMENU_POPUP_CLOSE = 8,
        HBMMENU_POPUP_RESTORE = 9,
        HBMMENU_POPUP_MAXIMIZE = 10,
        HBMMENU_POPUP_MINIMIZE = 11;



        public static HandleRef HWND_TOP = new HandleRef(null, (IntPtr)0);

        public static HandleRef HWND_BOTTOM = new HandleRef(null, (IntPtr)1);

        public static HandleRef HWND_TOPMOST = new HandleRef(null, new IntPtr(-1));

        public static HandleRef HWND_NOTOPMOST = new HandleRef(null, new IntPtr(-2));

        public static HandleRef HWND_MESSAGE = new HandleRef(null, new IntPtr(-3));

        public const int
        IME_CMODE_NATIVE = 0x0001,
        IME_CMODE_KATAKANA = 0x0002,
        IME_CMODE_FULLSHAPE = 0x0008,
        INPLACE_E_NOTOOLSPACE = unchecked((int)0x800401A1),
        ICON_SMALL = 0,
        ICON_BIG = 1,
        IDC_ARROW = 32512,
        IDC_IBEAM = 32513,
        IDC_WAIT = 32514,
        IDC_CROSS = 32515,
        IDC_SIZEALL = 32646,
        IDC_SIZENWSE = 32642,
        IDC_SIZENESW = 32643,
        IDC_SIZEWE = 32644,
        IDC_SIZENS = 32645,
        IDC_UPARROW = 32516,
        IDC_NO = 32648,
        IDC_APPSTARTING = 32650,
        IDC_HELP = 32651,
        IMAGE_ICON = 1,
        IMAGE_CURSOR = 2,
        ICC_UPDOWN_CLASS = 0x00000010,
        ICC_LINK_CLASS = 0x00008000,
        ICC_STANDARD_CLASSES = 0x00004000,
        ICC_PAGESCROLLER_CLASS = 0x00001000,
        ICC_USEREX_CLASSES = 0x00000200,
        ICC_HOTKEY_CLASS = 0x00000040,
        ICC_INTERNET_CLASSES = 0x00000800,
        ICC_NATIVEFNTCTL_CLASS = 0x00002000,   // native font control
        ICC_COOL_CLASSES = 0x00000400,
        ICC_ANIMATE_CLASS = 0x00000080,
        ICC_LISTVIEW_CLASSES = 0x00000001,
        ICC_TREEVIEW_CLASSES = 0x00000002,
        ICC_BAR_CLASSES = 0x00000004,
        ICC_TAB_CLASSES = 0x00000008,
        ICC_PROGRESS_CLASS = 0x00000020,
        ICC_DATE_CLASSES = 0x00000100,
        ILC_MASK = 0x0001,
        ILC_COLOR = 0x0000,
        ILC_COLOR4 = 0x0004,
        ILC_COLOR8 = 0x0008,
        ILC_COLOR16 = 0x0010,
        ILC_COLOR24 = 0x0018,
        ILC_COLOR32 = 0x0020,
        ILC_MIRROR = 0x00002000,
        ILD_NORMAL = 0x0000,
        ILD_TRANSPARENT = 0x0001,
        ILD_MASK = 0x0010,
        ILD_ROP = 0x0040,
        ILP_NORMAL = 0,
        ILP_DOWNLEVEL = 1,
        ILS_NORMAL = 0x0,
        ILS_GLOW = 0x1,
        ILS_SHADOW = 0x2,
        ILS_SATURATE = 0x4,
        ILS_ALPHA = 0x8;

        public const int IDM_PRINT = 27,
        IDM_PAGESETUP = 2004,
        IDM_PRINTPREVIEW = 2003,
        IDM_PROPERTIES = 28,
        IDM_SAVEAS = 71;

        public const int CSC_NAVIGATEFORWARD = 0x00000001,
        CSC_NAVIGATEBACK = 0x00000002;

        public const int STG_E_INVALIDFUNCTION = unchecked((int)0x80030001);
        public const int STG_E_FILENOTFOUND = unchecked((int)0x80030002);
        public const int STG_E_PATHNOTFOUND = unchecked((int)0x80030003);
        public const int STG_E_TOOMANYOPENFILES = unchecked((int)0x80030004);
        public const int STG_E_ACCESSDENIED = unchecked((int)0x80030005);
        public const int STG_E_INVALIDHANDLE = unchecked((int)0x80030006);
        public const int STG_E_INSUFFICIENTMEMORY = unchecked((int)0x80030008);
        public const int STG_E_INVALIDPOINTER = unchecked((int)0x80030009);
        public const int STG_E_NOMOREFILES = unchecked((int)0x80030012);
        public const int STG_E_DISKISWRITEPROTECTED = unchecked((int)0x80030013);
        public const int STG_E_SEEKERROR = unchecked((int)0x80030019);
        public const int STG_E_WRITEFAULT = unchecked((int)0x8003001D);
        public const int STG_E_READFAULT = unchecked((int)0x8003001E);
        public const int STG_E_SHAREVIOLATION = unchecked((int)0x80030020);
        public const int STG_E_LOCKVIOLATION = unchecked((int)0x80030021);

        public const int INPUT_KEYBOARD = 1;

        public const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        public const int KEYEVENTF_KEYUP = 0x0002;
        public const int KEYEVENTF_UNICODE = 0x0004;

        // Object flags
        public const int
         REO_NULL = 0x00000000,
         REO_READWRITEMASK = 0x0000003F,
         REO_DONTNEEDPALETTE = 0x00000020,
         REO_BLANK = 0x00000010,
         REO_DYNAMICSIZE = 0x00000008,
         REO_INVERTEDSELECT = 0x00000004,
         REO_BELOWBASELINE = 0x00000002,
         REO_RESIZABLE = 0x00000001,
         REO_LINK = unchecked((int)0x80000000),
         REO_STATIC = 0x40000000,
         REO_SELECTED = 0x08000000,
         REO_OPEN = 0x04000000,
         REO_INPLACEACTIVE = 0x02000000,
         REO_HILITED = 0x01000000,
         REO_LINKAVAILABLE = 0x00800000,
         REO_GETMETAFILE = 0x00400000;

        public const int LOGPIXELSX = 88,
        LOGPIXELSY = 90,
        LB_ERR = (-1),
        LB_ERRSPACE = (-2),
        LBN_SELCHANGE = 1,
        LBN_DBLCLK = 2,
        LB_ADDSTRING = 0x0180,
        LB_INSERTSTRING = 0x0181,
        LB_DELETESTRING = 0x0182,
        LB_RESETCONTENT = 0x0184,
        LB_SETSEL = 0x0185,
        LB_SETCURSEL = 0x0186,
        LB_GETSEL = 0x0187,
        LB_GETCARETINDEX = 0x019F,
        LB_GETCURSEL = 0x0188,
        LB_GETTEXT = 0x0189,
        LB_GETTEXTLEN = 0x018A,
        LB_GETTOPINDEX = 0x018E,
        LB_FINDSTRING = 0x018F,
        LB_GETSELCOUNT = 0x0190,
        LB_GETSELITEMS = 0x0191,
        LB_SETTABSTOPS = 0x0192,
        LB_SETHORIZONTALEXTENT = 0x0194,
        LB_SETCOLUMNWIDTH = 0x0195,
        LB_SETTOPINDEX = 0x0197,
        LB_GETITEMRECT = 0x0198,
        LB_SETITEMHEIGHT = 0x01A0,
        LB_GETITEMHEIGHT = 0x01A1,
        LB_FINDSTRINGEXACT = 0x01A2,
        LB_ITEMFROMPOINT = 0x01A9,
        LB_SETLOCALE = 0x01A5;

        public const int LBS_NOTIFY = 0x0001,
        LBS_MULTIPLESEL = 0x0008,
        LBS_OWNERDRAWFIXED = 0x0010,
        LBS_OWNERDRAWVARIABLE = 0x0020,
        LBS_HASSTRINGS = 0x0040,
        LBS_USETABSTOPS = 0x0080,
        LBS_NOINTEGRALHEIGHT = 0x0100,
        LBS_MULTICOLUMN = 0x0200,
        LBS_WANTKEYBOARDINPUT = 0x0400,
        LBS_EXTENDEDSEL = 0x0800,
        LBS_DISABLENOSCROLL = 0x1000,
        LBS_NOSEL = 0x4000,
        LOCK_WRITE = 0x1,
        LOCK_EXCLUSIVE = 0x2,
        LOCK_ONLYONCE = 0x4,
        LV_VIEW_TILE = 0x0004,
        LVBKIF_SOURCE_NONE = 0x0000,
        LVBKIF_SOURCE_URL = 0x0002,
        LVBKIF_STYLE_NORMAL = 0x0000,
        LVBKIF_STYLE_TILE = 0x0010,
        LVS_ICON = 0x0000,
        LVS_REPORT = 0x0001,
        LVS_SMALLICON = 0x0002,
        LVS_LIST = 0x0003,
        LVS_SINGLESEL = 0x0004,
        LVS_SHOWSELALWAYS = 0x0008,
        LVS_SORTASCENDING = 0x0010,
        LVS_SORTDESCENDING = 0x0020,
        LVS_SHAREIMAGELISTS = 0x0040,
        LVS_NOLABELWRAP = 0x0080,
        LVS_AUTOARRANGE = 0x0100,
        LVS_EDITLABELS = 0x0200,
        LVS_NOSCROLL = 0x2000,
        LVS_ALIGNTOP = 0x0000,
        LVS_ALIGNLEFT = 0x0800,
        LVS_NOCOLUMNHEADER = 0x4000,
        LVS_NOSORTHEADER = unchecked((int)0x8000),
        LVS_OWNERDATA = 0x1000,
        LVSCW_AUTOSIZE = -1,
        LVSCW_AUTOSIZE_USEHEADER = -2,
        LVM_REDRAWITEMS = (0x1000 + 21),
        LVM_SCROLL = (0x1000 + 20),
        LVM_SETBKCOLOR = (0x1000 + 1),
        LVM_SETBKIMAGEA = (0x1000 + 68),
        LVM_SETBKIMAGEW = (0x1000 + 138),
        LVM_SETCALLBACKMASK = (0x1000 + 11),
        LVM_GETCALLBACKMASK = (0x1000 + 10),
        LVM_GETCOLUMNORDERARRAY = (0x1000 + 59),
        LVM_GETITEMCOUNT = (0x1000 + 4),
        LVM_SETCOLUMNORDERARRAY = (0x1000 + 58),
        LVM_SETINFOTIP = (0x1000 + 173),
        LVSIL_NORMAL = 0,
        LVSIL_SMALL = 1,
        LVSIL_STATE = 2,
        LVM_SETIMAGELIST = (0x1000 + 3),
        LVM_SETSELECTIONMARK = (0x1000 + 67),
        LVM_SETTOOLTIPS = (0x1000 + 74),
        LVIF_TEXT = 0x0001,
        LVIF_IMAGE = 0x0002,
        LVIF_INDENT = 0x0010,
        LVIF_PARAM = 0x0004,
        LVIF_STATE = 0x0008,
        LVIF_GROUPID = 0x0100,
        LVIF_COLUMNS = 0x0200,
        LVIS_FOCUSED = 0x0001,
        LVIS_SELECTED = 0x0002,
        LVIS_CUT = 0x0004,
        LVIS_DROPHILITED = 0x0008,
        LVIS_OVERLAYMASK = 0x0F00,
        LVIS_STATEIMAGEMASK = 0xF000,
        LVM_GETITEMA = (0x1000 + 5),
        LVM_GETITEMW = (0x1000 + 75),
        LVM_SETITEMA = (0x1000 + 6),
        LVM_SETITEMW = (0x1000 + 76),
        LVM_SETITEMPOSITION32 = (0x01000 + 49),
        LVM_INSERTITEMA = (0x1000 + 7),
        LVM_INSERTITEMW = (0x1000 + 77),
        LVM_DELETEITEM = (0x1000 + 8),
        LVM_DELETECOLUMN = (0x1000 + 28),
        LVM_DELETEALLITEMS = (0x1000 + 9),
        LVM_UPDATE = (0x1000 + 42),
        LVNI_FOCUSED = 0x0001,
        LVNI_SELECTED = 0x0002,
        LVM_GETNEXTITEM = (0x1000 + 12),
        LVFI_PARAM = 0x0001,
        LVFI_NEARESTXY = 0x0040,
        LVFI_PARTIAL = 0x0008,
        LVFI_STRING = 0x0002,
        LVM_FINDITEMA = (0x1000 + 13),
        LVM_FINDITEMW = (0x1000 + 83),
        LVIR_BOUNDS = 0,
        LVIR_ICON = 1,
        LVIR_LABEL = 2,
        LVIR_SELECTBOUNDS = 3,
        LVM_GETSELECTEDCOLUMN = (0x1000 + 174),
        LVM_GETITEMSPACING = (0x1000 + 51),
        LVM_GETITEMPOSITION = (0x1000 + 16),
        LVM_GETITEMRECT = (0x1000 + 14),
        LVM_GETSUBITEMRECT = (0x1000 + 56),
        LVM_GETSTRINGWIDTHA = (0x1000 + 17),
        LVM_GETSTRINGWIDTHW = (0x1000 + 87),
        LVHT_NOWHERE = 0x0001,
        LVHT_ONITEMICON = 0x0002,
        LVHT_ONITEMLABEL = 0x0004,
        LVHT_ABOVE = 0x0008,
        LVHT_BELOW = 0x0010,
        LVHT_RIGHT = 0x0020,
        LVHT_LEFT = 0x0040,
        LVHT_ONITEM = (0x0002 | 0x0004 | 0x0008),
        LVHT_ONITEMSTATEICON = 0x0008,
        LVM_SUBITEMHITTEST = (0x1000 + 57),
        LVM_HITTEST = (0x1000 + 18),
        LVM_ENSUREVISIBLE = (0x1000 + 19),
        LVA_DEFAULT = 0x0000,
        LVA_ALIGNLEFT = 0x0001,
        LVA_ALIGNTOP = 0x0002,
        LVA_SNAPTOGRID = 0x0005,
        LVM_ARRANGE = (0x1000 + 22),
        LVM_EDITLABELA = (0x1000 + 23),
        LVM_EDITLABELW = (0x1000 + 118),
        LVCDI_ITEM = 0x0000,
        LVCDI_GROUP = 0x00000001,
        LVCF_FMT = 0x0001,
        LVCF_WIDTH = 0x0002,
        LVCF_TEXT = 0x0004,
        LVCF_SUBITEM = 0x0008,
        LVCF_IMAGE = 0x0010,
        LVCF_ORDER = 0x0020,
        LVCFMT_LEFT = 0x0000,
        LVCFMT_RIGHT = 0x0001,
        LVCFMT_CENTER = 0x0002,
        LVCFMT_JUSTIFYMASK = 0x0003,
        LVCFMT_IMAGE = 0x0800,
        LVCFMT_BITMAP_ON_RIGHT = 0x1000,
        LVCFMT_COL_HAS_IMAGES = 0x8000,
        LVGA_HEADER_LEFT = 0x00000001,
        LVGA_HEADER_CENTER = 0x00000002,
        LVGA_HEADER_RIGHT = 0x00000004,
        LVGA_FOOTER_LEFT = 0x00000008,
        LVGA_FOOTER_CENTER = 0x00000010,
        LVGA_FOOTER_RIGHT = 0x00000020,
        LVGF_NONE = 0x00000000,
        LVGF_HEADER = 0x00000001,
        LVGF_FOOTER = 0x00000002,
        LVGF_STATE = 0x00000004,
        LVGF_ALIGN = 0x00000008,
        LVGF_GROUPID = 0x00000010,
        LVGS_NORMAL = 0x00000000,
        LVGS_COLLAPSED = 0x00000001,
        LVGS_HIDDEN = 0x00000002,
        LVIM_AFTER = 0x00000001,
        LVTVIF_FIXEDSIZE = 0x00000003,
        LVTVIM_TILESIZE = 0x00000001,
        LVTVIM_COLUMNS = 0x00000002,
        LVM_GETBKCOLOR = (0x1000 + 0),
        LVM_GETBKIMAGEA = (0x1000 + 69),
        LVM_GETEDITCONTROL = (0x1000 + 24),
        LVM_GETIMAGELIST = (0x1000 + 2),
        LVM_ENABLEGROUPVIEW = (0x1000 + 157),
        LVM_MOVEITEMTOGROUP = (0x1000 + 154),
        LVM_GETCOLUMNA = (0x1000 + 25),
        LVM_GETCOLUMNW = (0x1000 + 95),
        LVM_SETCOLUMNA = (0x1000 + 26),
        LVM_SETCOLUMNW = (0x1000 + 96),
        LVM_INSERTCOLUMNA = (0x1000 + 27),
        LVM_INSERTCOLUMNW = (0x1000 + 97),
        LVM_INSERTGROUP = (0x1000 + 145),
        LVM_REMOVEGROUP = (0x1000 + 150),
        LVM_INSERTMARKHITTEST = (0x1000 + 168),
        LVM_REMOVEALLGROUPS = (0x1000 + 160),
        LVM_GETCOLUMNWIDTH = (0x1000 + 29),
        LVM_SETCOLUMNWIDTH = (0x1000 + 30),
        LVM_SETINSERTMARK = (0x1000 + 166),
        LVM_GETHEADER = (0x1000 + 31),
        LVM_GETTEXTCOLOR = (0x1000 + 35),
        LVM_SETTEXTCOLOR = (0x1000 + 36),
        LVM_SETTEXTBKCOLOR = (0x1000 + 38),
        LVM_GETTOPINDEX = (0x1000 + 39),
        LVM_SETITEMPOSITION = (0x1000 + 15),
        LVM_SETITEMSTATE = (0x1000 + 43),
        LVM_GETITEMSTATE = (0x1000 + 44),
        LVM_GETITEMTEXTA = (0x1000 + 45),
        LVM_GETITEMTEXTW = (0x1000 + 115),
        LVM_GETHOTITEM = (0x1000 + 61),
        LVM_SETITEMTEXTA = (0x1000 + 46),
        LVM_SETITEMTEXTW = (0x1000 + 116),
        LVM_SETITEMCOUNT = (0x1000 + 47),
        LVM_SORTITEMS = (0x1000 + 48),
        LVM_GETSELECTEDCOUNT = (0x1000 + 50),
        LVM_GETISEARCHSTRINGA = (0x1000 + 52),
        LVM_GETISEARCHSTRINGW = (0x1000 + 117),
        LVM_SETEXTENDEDLISTVIEWSTYLE = (0x1000 + 54),
        LVM_SETVIEW = (0x1000 + 142),
        LVM_GETGROUPINFO = (0x1000 + 149),
        LVM_SETGROUPINFO = (0x1000 + 147),
        LVM_HASGROUP = (0x1000 + 161),
        LVM_SETTILEVIEWINFO = (0x1000 + 162),
        LVM_GETTILEVIEWINFO = (0x1000 + 163),
        LVM_GETINSERTMARK = (0x1000 + 167),
        LVM_GETINSERTMARKRECT = (0x1000 + 169),
        LVM_SETINSERTMARKCOLOR = (0x1000 + 170),
        LVM_GETINSERTMARKCOLOR = (0x1000 + 171),
        LVM_ISGROUPVIEWENABLED = (0x1000 + 175),
        LVS_EX_GRIDLINES = 0x00000001,
        LVS_EX_CHECKBOXES = 0x00000004,
        LVS_EX_TRACKSELECT = 0x00000008,
        LVS_EX_HEADERDRAGDROP = 0x00000010,
        LVS_EX_FULLROWSELECT = 0x00000020,
        LVS_EX_ONECLICKACTIVATE = 0x00000040,
        LVS_EX_TWOCLICKACTIVATE = 0x00000080,
        LVS_EX_INFOTIP = 0x00000400,
        LVS_EX_UNDERLINECOLD = 0x00001000,
        LVS_EX_SIMPLESELECT = 0x00100000,
        LVS_EX_HIDELABELS = 0x00020000,
        LVS_EX_SINGLEROW = 0x00040000,
        LVS_EX_SNAPTOGRID = 0x00080000,
        LVS_EX_UNDERLINEHOT = 0x00000800,
        LVS_EX_DOUBLEBUFFER = 0x00010000,
        LVN_ITEMCHANGING = ((0 - 100) - 0),
        LVN_ITEMCHANGED = ((0 - 100) - 1),
        LVN_BEGINLABELEDITA = ((0 - 100) - 5),
        LVN_BEGINLABELEDITW = ((0 - 100) - 75),
        LVN_ENDLABELEDITA = ((0 - 100) - 6),
        LVN_ENDLABELEDITW = ((0 - 100) - 76),
        LVN_COLUMNCLICK = ((0 - 100) - 8),
        LVN_BEGINDRAG = ((0 - 100) - 9),
        LVN_BEGINRDRAG = ((0 - 100) - 11),
        LVN_ODFINDITEMA = ((0 - 100) - 52),
        LVN_ODFINDITEMW = ((0 - 100) - 79),
        LVN_ITEMACTIVATE = ((0 - 100) - 14),
        LVN_GETDISPINFOA = ((0 - 100) - 50),
        LVN_GETDISPINFOW = ((0 - 100) - 77),
        LVN_ODCACHEHINT = ((0 - 100) - 13),
        LVN_ODSTATECHANGED = ((0 - 100) - 15),
        LVN_SETDISPINFOA = ((0 - 100) - 51),
        LVN_SETDISPINFOW = ((0 - 100) - 78),
        LVN_GETINFOTIPA = ((0 - 100) - 57),
        LVN_GETINFOTIPW = ((0 - 100) - 58),
        LVN_KEYDOWN = ((0 - 100) - 55),

        LWA_COLORKEY = 0x00000001,
        LWA_ALPHA = 0x00000002;

        public const int LANG_NEUTRAL = 0x00,
                         LOCALE_IFIRSTDAYOFWEEK = 0x0000100C;   /* first day of week specifier */

        public const int LOCALE_IMEASURE = 0x0000000D;   // 0 = metric, 1 = US

        public static readonly int LOCALE_USER_DEFAULT = MAKELCID(LANG_USER_DEFAULT);
        public static readonly int LANG_USER_DEFAULT = MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT);

        public static int MAKELANGID(int primary, int sub)
        {
            return ((((ushort)(sub)) << 10) | (ushort)(primary));
        }

        public static int MAKELCID(int lgid)
        {
            return MAKELCID(lgid, SORT_DEFAULT);
        }

        public static int MAKELCID(int lgid, int sort)
        {
            return ((0xFFFF & lgid) | (((0x000f) & sort) << 16));
        }


        public const int SHCNF_IDLIST = 0x0000,     // LPITEMIDLIST
        SHCNF_PATHA = 0x0001,    // path name
        SHCNF_PRINTERA = 0x0002,     // printer friendly name
        SHCNF_DWORD = 0x0003,     // DWORD
        SHCNF_PATHW = 0x0005,     // path name
        SHCNF_PRINTERW = 0x0006,      // printer friendly name
        SHCNF_TYPE = 0x00FF,
        SHCNF_FLUSH = 0x1000,
        SHCNF_FLUSHNOWAIT = 0x2000,
        SHCNF_PATH = SHCNF_PATHW,
        SHCNF_PRINTER = SHCNF_PRINTERW;

        public const int MEMBERID_NIL = (-1),
        MAX_PATH = 260,
        MA_ACTIVATE = 0x0001,
        MA_ACTIVATEANDEAT = 0x0002,
        MA_NOACTIVATE = 0x0003,
        MA_NOACTIVATEANDEAT = 0x0004,
        MK_LBUTTON = 0x0001,
        MK_RBUTTON = 0x0002,
        MK_SHIFT = 0x0004,
        MK_CONTROL = 0x0008,
        MK_MBUTTON = 0x0010,
        MNC_EXECUTE = 2,
        MNC_SELECT = 3,
        MIIM_STATE = 0x00000001,
        MIIM_ID = 0x00000002,
        MIIM_SUBMENU = 0x00000004,
        MIIM_CHECKMARKS = 0x00000008,
        MIIM_TYPE = 0x00000010,
        MIIM_STRING = 0x00000040,
        MIIM_BITMAP = 0x00000080,
        MIIM_FTYPE = 0x00000100,
        MIIM_DATA = 0x00000020,
        MB_OK = 0x00000000,
        MF_STRING = 0x00000000,
        MF_BYCOMMAND = 0x00000000,
        MF_BYPOSITION = 0x00000400,
        MF_ENABLED = 0x00000000,
        MF_GRAYED = 0x00000001,
        MF_POPUP = 0x00000010,
        MF_SYSMENU = 0x00002000,

        MF_INSERT = 0x00000000,
        MF_CHANGE = 0x00000080,
        MF_APPEND = 0x00000100,
        MF_DELETE = 0x00000200,
        MF_REMOVE = 0x00001000,
        MF_SEPARATOR = 0x00000800,
        MF_DISABLED = 0x00000002,
        MF_CHECKED = 0x00000008,
        MF_USECHECKBITMAPS = 0x00000200,
        MF_BITMAP = 0x00000004,
        MF_OWNERDRAW = 0x00000100,
        MF_MENUBARBREAK = 0x00000020,
        MF_MENUBREAK = 0x00000040,

        MFS_GRAYED = 0x00000003,
        MFS_DISABLED = MFS_GRAYED,
        MFS_CHECKED = 0x00000008,
        MFS_HILITE = 0x00000080,
        MFS_ENABLED = 0x00000000,
        MFS_UNCHECKED = 0x00000000,
        MFS_UNHILITE = 0x00000000,
        MFS_DEFAULT = 0x00001000,
        MFT_RADIOCHECK = 0x00000200,
        MFT_BITMAP = 0x00000004,
        MFT_OWNERDRAW = 0x00000100,
        MFT_MENUBARBREAK = 0x00000020,
        MFT_MENUBREAK = 0x00000040,
        MFT_SEPARATOR = 0x00000800,
        MFT_RIGHTORDER = 0x00002000,
        MFT_RIGHTJUSTIFY = 0x00004000,
        MDIS_ALLCHILDSTYLES = 0x0001,
        MDITILE_VERTICAL = 0x0000,
        MDITILE_HORIZONTAL = 0x0001,
        MDITILE_SKIPDISABLED = 0x0002,
        MCM_SETMAXSELCOUNT = (0x1000 + 4),
        MCM_SETSELRANGE = (0x1000 + 6),
        MCM_GETMONTHRANGE = (0x1000 + 7),
        MCM_GETMINREQRECT = (0x1000 + 9),
        MCM_SETCOLOR = (0x1000 + 10),
        MCM_SETTODAY = (0x1000 + 12),
        MCM_GETTODAY = (0x1000 + 13),
        MCM_HITTEST = (0x1000 + 14),
        MCM_SETFIRSTDAYOFWEEK = (0x1000 + 15),
        MCM_SETRANGE = (0x1000 + 18),
        MCM_SETMONTHDELTA = (0x1000 + 20),
        MCM_GETMAXTODAYWIDTH = (0x1000 + 21),
        MCHT_TITLE = 0x00010000,
        MCHT_CALENDAR = 0x00020000,
        MCHT_TODAYLINK = 0x00030000,
        MCHT_TITLEBK = (0x00010000),
        MCHT_TITLEMONTH = (0x00010000 | 0x0001),
        MCHT_TITLEYEAR = (0x00010000 | 0x0002),
        MCHT_TITLEBTNNEXT = (0x00010000 | 0x01000000 | 0x0003),
        MCHT_TITLEBTNPREV = (0x00010000 | 0x02000000 | 0x0003),
        MCHT_CALENDARBK = (0x00020000),
        MCHT_CALENDARDATE = (0x00020000 | 0x0001),
        MCHT_CALENDARDATENEXT = ((0x00020000 | 0x0001) | 0x01000000),
        MCHT_CALENDARDATEPREV = ((0x00020000 | 0x0001) | 0x02000000),
        MCHT_CALENDARDAY = (0x00020000 | 0x0002),
        MCHT_CALENDARWEEKNUM = (0x00020000 | 0x0003),
        MCSC_TEXT = 1,
        MCSC_TITLEBK = 2,
        MCSC_TITLETEXT = 3,
        MCSC_MONTHBK = 4,
        MCSC_TRAILINGTEXT = 5,
        MCN_SELCHANGE = ((0 - 750) + 1),
        MCN_GETDAYSTATE = ((0 - 750) + 3),
        MCN_SELECT = ((0 - 750) + 4),
        MCS_DAYSTATE = 0x0001,
        MCS_MULTISELECT = 0x0002,
        MCS_WEEKNUMBERS = 0x0004,
        MCS_NOTODAYCIRCLE = 0x0008,
        MCS_NOTODAY = 0x0010,
        MSAA_MENU_SIG = (unchecked((int)0xAA0DF00D));

        public const int NIM_ADD = 0x00000000,
        NIM_MODIFY = 0x00000001,
        NIM_DELETE = 0x00000002,
        NIF_MESSAGE = 0x00000001,
        NIM_SETVERSION = 0x00000004,
        NIF_ICON = 0x00000002,
        NIF_INFO = 0x00000010,
        NIF_TIP = 0x00000004,
        NIIF_NONE = 0x00000000,
        NIIF_INFO = 0x00000001,
        NIIF_WARNING = 0x00000002,
        NIIF_ERROR = 0x00000003,
        NIN_BALLOONSHOW = (WM_USER + 2),
        NIN_BALLOONHIDE = (WM_USER + 3),
        NIN_BALLOONTIMEOUT = (WM_USER + 4),
        NIN_BALLOONUSERCLICK = (WM_USER + 5),
        NFR_ANSI = 1,
        NFR_UNICODE = 2,
        NM_SETCURSOR = ((0 - 0) - 17),
        NM_KILLFOCUS = ((0 - 0) - 8),
        NM_CLICK = ((0 - 0) - 2),
        NM_DBLCLK = ((0 - 0) - 3),
        NM_RCLICK = ((0 - 0) - 5),
        NM_RDBLCLK = ((0 - 0) - 6),
        NM_CUSTOMDRAW = ((0 - 0) - 12),
        NM_RELEASEDCAPTURE = ((0 - 0) - 16),
        NONANTIALIASED_QUALITY = 3;

        public const int OFN_READONLY = 0x00000001,
        OFN_OVERWRITEPROMPT = 0x00000002,
        OFN_HIDEREADONLY = 0x00000004,
        OFN_NOCHANGEDIR = 0x00000008,
        OFN_SHOWHELP = 0x00000010,
        OFN_ENABLEHOOK = 0x00000020,
        OFN_NOVALIDATE = 0x00000100,
        OFN_ALLOWMULTISELECT = 0x00000200,
        OFN_PATHMUSTEXIST = 0x00000800,
        OFN_FILEMUSTEXIST = 0x00001000,
        OFN_CREATEPROMPT = 0x00002000,
        OFN_EXPLORER = 0x00080000,
        OFN_NODEREFERENCELINKS = 0x00100000,
        OFN_ENABLESIZING = 0x00800000,
        OFN_USESHELLITEM = 0x01000000,
        OLEIVERB_PRIMARY = 0,
        OLEIVERB_SHOW = -1,
        OLEIVERB_HIDE = -3,
        OLEIVERB_UIACTIVATE = -4,
        OLEIVERB_INPLACEACTIVATE = -5,
        OLEIVERB_DISCARDUNDOSTATE = -6,
        OLEIVERB_PROPERTIES = -7,
        OLE_E_INVALIDRECT = unchecked((int)0x8004000D),
        OLE_E_NOCONNECTION = unchecked((int)0x80040004),
        OLE_E_PROMPTSAVECANCELLED = unchecked((int)0x8004000C),
        OLEMISC_RECOMPOSEONRESIZE = 0x00000001,
        OLEMISC_INSIDEOUT = 0x00000080,
        OLEMISC_ACTIVATEWHENVISIBLE = 0x0000100,
        OLEMISC_ACTSLIKEBUTTON = 0x00001000,
        OLEMISC_SETCLIENTSITEFIRST = 0x00020000,
        ODS_CHECKED = 0x0008,
        ODS_COMBOBOXEDIT = 0x1000,
        ODS_DEFAULT = 0x0020,
        ODS_DISABLED = 0x0004,
        ODS_FOCUS = 0x0010,
        ODS_GRAYED = 0x0002,
        ODS_HOTLIGHT = 0x0040,
        ODS_INACTIVE = 0x0080,
        ODS_NOACCEL = 0x0100,
        ODS_NOFOCUSRECT = 0x0200,
        ODS_SELECTED = 0x0001,
        OLECLOSE_SAVEIFDIRTY = 0,
        OLECLOSE_PROMPTSAVE = 2;

        public const int PDERR_SETUPFAILURE = 0x1001,
        PDERR_PARSEFAILURE = 0x1002,
        PDERR_RETDEFFAILURE = 0x1003,
        PDERR_LOADDRVFAILURE = 0x1004,
        PDERR_GETDEVMODEFAIL = 0x1005,
        PDERR_INITFAILURE = 0x1006,
        PDERR_NODEVICES = 0x1007,
        PDERR_NODEFAULTPRN = 0x1008,
        PDERR_DNDMMISMATCH = 0x1009,
        PDERR_CREATEICFAILURE = 0x100A,
        PDERR_PRINTERNOTFOUND = 0x100B,
        PDERR_DEFAULTDIFFERENT = 0x100C,
        PD_ALLPAGES = 0x00000000,
        PD_SELECTION = 0x00000001,
        PD_PAGENUMS = 0x00000002,
        PD_NOSELECTION = 0x00000004,
        PD_NOPAGENUMS = 0x00000008,
        PD_COLLATE = 0x00000010,
        PD_PRINTTOFILE = 0x00000020,
        PD_PRINTSETUP = 0x00000040,
        PD_NOWARNING = 0x00000080,
        PD_RETURNDC = 0x00000100,
        PD_RETURNIC = 0x00000200,
        PD_RETURNDEFAULT = 0x00000400,
        PD_SHOWHELP = 0x00000800,
        PD_ENABLEPRINTHOOK = 0x00001000,
        PD_ENABLESETUPHOOK = 0x00002000,
        PD_ENABLEPRINTTEMPLATE = 0x00004000,
        PD_ENABLESETUPTEMPLATE = 0x00008000,
        PD_ENABLEPRINTTEMPLATEHANDLE = 0x00010000,
        PD_ENABLESETUPTEMPLATEHANDLE = 0x00020000,
        PD_USEDEVMODECOPIES = 0x00040000,
        PD_USEDEVMODECOPIESANDCOLLATE = 0x00040000,
        PD_DISABLEPRINTTOFILE = 0x00080000,
        PD_HIDEPRINTTOFILE = 0x00100000,
        PD_NONETWORKBUTTON = 0x00200000,
        PD_CURRENTPAGE = 0x00400000,
        PD_NOCURRENTPAGE = 0x00800000,
        PD_EXCLUSIONFLAGS = 0x01000000,
        PD_USELARGETEMPLATE = 0x10000000,
        PSD_MINMARGINS = 0x00000001,
        PSD_MARGINS = 0x00000002,
        PSD_INHUNDREDTHSOFMILLIMETERS = 0x00000008,
        PSD_DISABLEMARGINS = 0x00000010,
        PSD_DISABLEPRINTER = 0x00000020,
        PSD_DISABLEORIENTATION = 0x00000100,
        PSD_DISABLEPAPER = 0x00000200,
        PSD_SHOWHELP = 0x00000800,
        PSD_ENABLEPAGESETUPHOOK = 0x00002000,
        PSD_NONETWORKBUTTON = 0x00200000,
            //PS_SOLID = 0,
            //PS_DOT = 2,
        PLANES = 14,
        PM_NOREMOVE = 0x0000,
        PM_REMOVE = 0x0001,
        PM_NOYIELD = 0x0002,
        PBM_SETRANGE = (0x0400 + 1),
        PBM_SETPOS = (0x0400 + 2),
        PBM_SETSTEP = (0x0400 + 4),
        PBM_SETRANGE32 = (0x0400 + 6),
        PBM_SETBARCOLOR = (0x0400 + 9),
        PBM_SETMARQUEE = (0x0400 + 10),
        PBM_SETBKCOLOR = (0x2000 + 1),
        PSM_SETTITLEA = (0x0400 + 111),
        PSM_SETTITLEW = (0x0400 + 120),
        PSM_SETFINISHTEXTA = (0x0400 + 115),
        PSM_SETFINISHTEXTW = (0x0400 + 121),
        PATCOPY = 0x00F00021,
        PATINVERT = 0x005A0049;

        public const int PBS_SMOOTH = 0x01,
        PBS_MARQUEE = 0x08;

        public const int QS_KEY = 0x0001,
        QS_MOUSEMOVE = 0x0002,
        QS_MOUSEBUTTON = 0x0004,
        QS_POSTMESSAGE = 0x0008,
        QS_TIMER = 0x0010,
        QS_PAINT = 0x0020,
        QS_SENDMESSAGE = 0x0040,
        QS_HOTKEY = 0x0080,
        QS_ALLPOSTMESSAGE = 0x0100,
        QS_MOUSE = QS_MOUSEMOVE | QS_MOUSEBUTTON,
        QS_INPUT = QS_MOUSE | QS_KEY,
        QS_ALLEVENTS = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY,
        QS_ALLINPUT = QS_INPUT | QS_POSTMESSAGE | QS_TIMER | QS_PAINT | QS_HOTKEY | QS_SENDMESSAGE;

        public const int RECO_PASTE = 0x00000000;   // paste from clipboard 
        public const int RECO_DROP = 0x00000001;    // drop
        public const int RECO_COPY = 0x00000002;    // copy to the clipboard 
        public const int RECO_CUT = 0x00000003; // cut to the clipboard 
        public const int RECO_DRAG = 0x00000004;    // drag

        public const int RPC_E_CHANGED_MODE = unchecked((int)0x80010106),
        RPC_E_CANTCALLOUT_ININPUTSYNCCALL = unchecked((int)0x8001010D),
        RGN_AND = 1,
        RGN_XOR = 3,
        RGN_DIFF = 4,
        RDW_INVALIDATE = 0x0001,
        RDW_ERASE = 0x0004,
        RDW_ALLCHILDREN = 0x0080,
        RDW_ERASENOW = 0x0200,
        RDW_UPDATENOW = 0x0100,
        RDW_FRAME = 0x0400;

        public const int stc4 = 0x0443,
        SHGFP_TYPE_CURRENT = 0,
        STGM_READ = 0x00000000,
        STGM_WRITE = 0x00000001,
        STGM_READWRITE = 0x00000002,
        STGM_SHARE_EXCLUSIVE = 0x00000010,
        STGM_CREATE = 0x00001000,
        STGM_TRANSACTED = 0x00010000,
        STGM_CONVERT = 0x00020000,
        STGM_DELETEONRELEASE = 0x04000000,
        STARTF_USESHOWWINDOW = 0x00000001,
        SB_HORZ = 0,
        SB_VERT = 1,
        SB_CTL = 2,
        SB_LINEUP = 0,
        SB_LINELEFT = 0,
        SB_LINEDOWN = 1,
        SB_LINERIGHT = 1,
        SB_PAGEUP = 2,
        SB_PAGELEFT = 2,
        SB_PAGEDOWN = 3,
        SB_PAGERIGHT = 3,
        SB_THUMBPOSITION = 4,
        SB_THUMBTRACK = 5,
        SB_LEFT = 6,
        SB_RIGHT = 7,
        SB_ENDSCROLL = 8,
        SB_TOP = 6,
        SB_BOTTOM = 7,
        SIZE_RESTORED = 0,
        SIZE_MAXIMIZED = 2,
        ESB_ENABLE_BOTH = 0x0000,
        ESB_DISABLE_BOTH = 0x0003,
        SORT_DEFAULT = 0x0,
        SUBLANG_DEFAULT = 0x01,
        SW_HIDE = 0,
        SW_NORMAL = 1,
        SW_SHOWMINIMIZED = 2,
        SW_SHOWMAXIMIZED = 3,
        SW_MAXIMIZE = 3,
        SW_SHOWNOACTIVATE = 4,
        SW_SHOW = 5,
        SW_MINIMIZE = 6,
        SW_SHOWMINNOACTIVE = 7,
        SW_SHOWNA = 8,
        SW_RESTORE = 9,
        SW_MAX = 10,
        SWP_FRAMECHANGED = 0x0020,
        SWP_NOSIZE = 0x0001,
        SWP_NOMOVE = 0x0002,
        SWP_NOZORDER = 0x0004,
        SWP_NOACTIVATE = 0x0010,
        SWP_NOCOPYBITS = 0x0100,
        SWP_SHOWWINDOW = 0x0040,
        SWP_HIDEWINDOW = 0x0080,
        SWP_DRAWFRAME = 0x0020,
        SWP_NOOWNERZORDER = 0x0200,
        SM_CXSCREEN = 0,
        SM_CYSCREEN = 1,
        SM_CXVSCROLL = 2,
        SM_CYHSCROLL = 3,
        SM_CYCAPTION = 4,
        SM_CXBORDER = 5,
        SM_CYBORDER = 6,
        SM_CYVTHUMB = 9,
        SM_CXHTHUMB = 10,
        SM_CXICON = 11,
        SM_CYICON = 12,
        SM_CXCURSOR = 13,
        SM_CYCURSOR = 14,
        SM_CYMENU = 15,
        SM_CYKANJIWINDOW = 18,
        SM_MOUSEPRESENT = 19,
        SM_CYVSCROLL = 20,
        SM_CXHSCROLL = 21,
        SM_DEBUG = 22,
        SM_SWAPBUTTON = 23,
        SM_CXMIN = 28,
        SM_CYMIN = 29,
        SM_CXSIZE = 30,
        SM_CYSIZE = 31,
        SM_CXFRAME = 32,
        SM_CYFRAME = 33,
        SM_CXMINTRACK = 34,
        SM_CYMINTRACK = 35,
        SM_CXDOUBLECLK = 36,
        SM_CYDOUBLECLK = 37,
        SM_CXICONSPACING = 38,
        SM_CYICONSPACING = 39,
        SM_MENUDROPALIGNMENT = 40,
        SM_PENWINDOWS = 41,
        SM_DBCSENABLED = 42,
        SM_CMOUSEBUTTONS = 43,
        SM_CXFIXEDFRAME = 7,
        SM_CYFIXEDFRAME = 8,
        SM_SECURE = 44,
        SM_CXEDGE = 45,
        SM_CYEDGE = 46,
        SM_CXMINSPACING = 47,
        SM_CYMINSPACING = 48,
        SM_CXSMICON = 49,
        SM_CYSMICON = 50,
        SM_CYSMCAPTION = 51,
        SM_CXSMSIZE = 52,
        SM_CYSMSIZE = 53,
        SM_CXMENUSIZE = 54,
        SM_CYMENUSIZE = 55,
        SM_ARRANGE = 56,
        SM_CXMINIMIZED = 57,
        SM_CYMINIMIZED = 58,
        SM_CXMAXTRACK = 59,
        SM_CYMAXTRACK = 60,
        SM_CXMAXIMIZED = 61,
        SM_CYMAXIMIZED = 62,
        SM_NETWORK = 63,
        SM_CLEANBOOT = 67,
        SM_CXDRAG = 68,
        SM_CYDRAG = 69,
        SM_SHOWSOUNDS = 70,
        SM_CXMENUCHECK = 71,
        SM_CYMENUCHECK = 72,
        SM_MIDEASTENABLED = 74,
        SM_MOUSEWHEELPRESENT = 75,
        SM_XVIRTUALSCREEN = 76,
        SM_YVIRTUALSCREEN = 77,
        SM_CXVIRTUALSCREEN = 78,
        SM_CYVIRTUALSCREEN = 79,
        SM_CMONITORS = 80,
        SM_SAMEDISPLAYFORMAT = 81,
        SM_REMOTESESSION = 0x1000;

        public const int
        HDS_HORZ = 0x0000,
        HDS_BUTTONS = 0x0002,
        HDS_HOTTRACK = 0x0004,
        HDS_HIDDEN = 0x0008,
        HDS_DRAGDROP = 0x0040,
        HDS_FULLDRAG = 0x0080,
        HDS_FILTERBAR = 0x0100,
        HDS_FLAT = 0x0200,
        HDFT_ISSTRING = 0x0000,
        HDFT_ISNUMBER = 0x0001,
        HDFT_HASNOVALUE = 0x8000;

        public const int HLP_FILE = 1,
        HLP_KEYWORD = 2,
        HLP_NAVIGATOR = 3,
        HLP_OBJECT = 4;

        public const int SW_SCROLLCHILDREN = 0x0001,
        SW_INVALIDATE = 0x0002,
        SW_ERASE = 0x0004,
        SW_SMOOTHSCROLL = 0x0010,
        SC_SIZE = 0xF000,
        SC_MINIMIZE = 0xF020,
        SC_MAXIMIZE = 0xF030,
        SC_CLOSE = 0xF060,
        SC_KEYMENU = 0xF100,
        SC_RESTORE = 0xF120,
        SC_MOVE = 0xF010,
        SC_CONTEXTHELP = 0xF180,
        SBS_HORZ = 0x0000,
        SBS_VERT = 0x0001,
        SIF_RANGE = 0x0001,
        SIF_PAGE = 0x0002,
        SIF_POS = 0x0004,
        SIF_TRACKPOS = 0x0010,
        SIF_ALL = (0x0001 | 0x0002 | 0x0004 | 0x0010),
        SPI_GETFONTSMOOTHING = 0x004A,
        SPI_GETDROPSHADOW = 0x1024,
        SPI_GETFLATMENU = 0x1022,
        SPI_GETFONTSMOOTHINGTYPE = 0x200A,
        SPI_GETFONTSMOOTHINGCONTRAST = 0x200C,
        SPI_ICONHORIZONTALSPACING = 0x000D,
        SPI_ICONVERTICALSPACING = 0x0018,
        SPI_GETICONMETRICS = 0x002D,
        SPI_GETICONTITLEWRAP = 0x0019,
        SPI_GETICONTITLELOGFONT = 0x001F,
        SPI_GETKEYBOARDCUES = 0x100A,
        SPI_GETKEYBOARDDELAY = 0x0016,
        SPI_GETKEYBOARDPREF = 0x0044,
        SPI_GETKEYBOARDSPEED = 0x000A,
        SPI_GETMOUSEHOVERWIDTH = 0x0062,
        SPI_GETMOUSEHOVERHEIGHT = 0x0064,
        SPI_GETMOUSEHOVERTIME = 0x0066,
        SPI_GETMOUSESPEED = 0x0070,
        SPI_GETMENUDROPALIGNMENT = 0x001B,
        SPI_GETMENUFADE = 0x1012,
        SPI_GETMENUSHOWDELAY = 0x006A,
        SPI_GETCOMBOBOXANIMATION = 0x1004,
        SPI_GETGRADIENTCAPTIONS = 0x1008,
        SPI_GETHOTTRACKING = 0x100E,
        SPI_GETLISTBOXSMOOTHSCROLLING = 0x1006,
        SPI_GETMENUANIMATION = 0x1002,
        SPI_GETSELECTIONFADE = 0x1014,
        SPI_GETTOOLTIPANIMATION = 0x1016,
        SPI_GETUIEFFECTS = 0x103E,
        SPI_GETACTIVEWINDOWTRACKING = 0x1000,
        SPI_GETACTIVEWNDTRKTIMEOUT = 0x2002,
        SPI_GETANIMATION = 0x0048,
        SPI_GETBORDER = 0x0005,
        SPI_GETCARETWIDTH = 0x2006,
        SM_CYFOCUSBORDER = 84,
        SM_CXFOCUSBORDER = 83,
        SM_CYSIZEFRAME = SM_CYFRAME,
        SM_CXSIZEFRAME = SM_CXFRAME,
        SPI_GETDRAGFULLWINDOWS = 38,
        SPI_GETNONCLIENTMETRICS = 41,
        SPI_GETWORKAREA = 48,
        SPI_GETHIGHCONTRAST = 66,
        SPI_GETDEFAULTINPUTLANG = 89,
        SPI_GETSNAPTODEFBUTTON = 95,
        SPI_GETWHEELSCROLLLINES = 104,
        SBARS_SIZEGRIP = 0x0100,
        SB_SETTEXTA = (0x0400 + 1),
        SB_SETTEXTW = (0x0400 + 11),
        SB_GETTEXTA = (0x0400 + 2),
        SB_GETTEXTW = (0x0400 + 13),
        SB_GETTEXTLENGTHA = (0x0400 + 3),
        SB_GETTEXTLENGTHW = (0x0400 + 12),
        SB_SETPARTS = (0x0400 + 4),
        SB_SIMPLE = (0x0400 + 9),
        SB_GETRECT = (0x0400 + 10),
        SB_SETICON = (0x0400 + 15),
        SB_SETTIPTEXTA = (0x0400 + 16),
        SB_SETTIPTEXTW = (0x0400 + 17),
        SB_GETTIPTEXTA = (0x0400 + 18),
        SB_GETTIPTEXTW = (0x0400 + 19),
        SBT_OWNERDRAW = 0x1000,
        SBT_NOBORDERS = 0x0100,
        SBT_POPOUT = 0x0200,
        SBT_RTLREADING = 0x0400,
        SRCCOPY = 0x00CC0020,
        SRCAND = 0x008800C6, /* dest = source AND dest          */
        SRCPAINT = 0x00EE0086, /* dest = source OR dest           */
        NOTSRCCOPY = 0x00330008, /* dest = (NOT source)             */
        STATFLAG_DEFAULT = 0x0,
        STATFLAG_NONAME = 0x1,
        STATFLAG_NOOPEN = 0x2,
        STGC_DEFAULT = 0x0,
        STGC_OVERWRITE = 0x1,
        STGC_ONLYIFCURRENT = 0x2,
        STGC_DANGEROUSLYCOMMITMERELYTODISKCACHE = 0x4,
        STREAM_SEEK_SET = 0x0,
        STREAM_SEEK_CUR = 0x1,
        STREAM_SEEK_END = 0x2;

        public const int S_OK = 0x00000000;
        public const int S_FALSE = 0x00000001;

        public static bool Succeeded(int hr)
        {
            return (hr >= 0);
        }

        public static bool Failed(int hr)
        {
            return (hr < 0);
        }

        public const int
            //TRANSPARENT = 1,
            //OPAQUE = 2,
        TME_HOVER = 0x00000001,
        TME_LEAVE = 0x00000002,
        TPM_LEFTBUTTON = 0x0000,
        TPM_RIGHTBUTTON = 0x0002,
        TPM_LEFTALIGN = 0x0000,
        TPM_RIGHTALIGN = 0x0008,
        TPM_VERTICAL = 0x0040,
        TPM_RETURNCMD = 0x0100,
        TV_FIRST = 0x1100,
        TBSTATE_ELLIPSES = 0x40,
        TBSTATE_MARKED = 0x80,
        TBSTATE_PRESSED = 0x02,
        TBSTATE_WRAP = 0x20,
        TBSTATE_CHECKED = 0x01,
        TBSTATE_ENABLED = 0x04,
        TBSTATE_HIDDEN = 0x08,
        TBSTATE_INDETERMINATE = 0x10,
        TBSTYLE_EX_DOUBLEBUFFER = 0x00000080,
        TBSTYLE_EX_HIDECLIPPEDBUTTONS = 0x00000010,
        TBSTYLE_EX_MIXEDBUTTONS = 0x00000008,
        TBSTYLE_BUTTON = 0x00,
        TBSTYLE_GROUP = 0x0004,
        TBSTYLE_CHECKGROUP = TBSTYLE_GROUP | TBSTYLE_CHECK,
        TBSTYLE_AUTOSIZE = 0x0010,
        TBSTYLE_NOPREFIX = 0x0020,
        TBSTYLE_REGISTERDROP = 0x4000,
        TBSTYLE_TRANSPARENT = 0x8000,
        TBSTYLE_ALTDRAG = 0x0400,
        TBSTYLE_SEP = 0x01,
        TBSTYLE_CHECK = 0x02,
        TBSTYLE_DROPDOWN = 0x08,
        TBSTYLE_TOOLTIPS = 0x0100,
        TBSTYLE_FLAT = 0x0800,
        TBSTYLE_LIST = 0x1000,
        TBSTYLE_EX_DRAWDDARROWS = 0x00000001,
        TB_GETMETRICS = (WM_USER + 101),
        TB_SETMETRICS = (WM_USER + 102),
        TB_SAVERESTOREA = (0x0400 + 26),
        TB_SAVERESTOREW = (0x0400 + 76),
        TB_CUSTOMIZE = (0x0400 + 27),
        TB_ADDSTRINGA = (0x0400 + 28),
        TB_ADDSTRINGW = (0x0400 + 77),
        TB_GETITEMRECT = (0x0400 + 29),
        TB_BUTTONSTRUCTSIZE = (0x0400 + 30),
        TB_SETBUTTONSIZE = (0x0400 + 31),
        TB_SETBITMAPSIZE = (0x0400 + 32),
        TB_AUTOSIZE = (0x0400 + 33),
        TB_GETTOOLTIPS = (0x0400 + 35),
        TB_SETTOOLTIPS = (0x0400 + 36),
        TB_SETPARENT = (0x0400 + 37),
        TB_SETROWS = (0x0400 + 39),
        TB_GETROWS = (0x0400 + 40),
        TB_SETCMDID = (0x0400 + 42),
        TB_CHANGEBITMAP = (0x0400 + 43),
        TB_GETBITMAP = (0x0400 + 44),
        TB_GETBUTTONTEXTA = (0x0400 + 45),
        TB_GETBUTTONTEXTW = (0x0400 + 75),
        TB_REPLACEBITMAP = (0x0400 + 46),
        TB_SETINDENT = (0x0400 + 47),
        TB_SETIMAGELIST = (0x0400 + 48),
        TB_GETIMAGELIST = (0x0400 + 49),
        TB_LOADIMAGES = (0x0400 + 50),
        TB_GETRECT = (0x0400 + 51),
        TB_SETHOTIMAGELIST = (0x0400 + 52),
        TB_GETHOTIMAGELIST = (0x0400 + 53),
        TB_SETDISABLEDIMAGELIST = (0x0400 + 54),
        TB_GETDISABLEDIMAGELIST = (0x0400 + 55),
        TB_SETSTYLE = (0x0400 + 56),
        TB_GETSTYLE = (0x0400 + 57),
        TB_GETBUTTONSIZE = (0x0400 + 58),
        TB_SETBUTTONWIDTH = (0x0400 + 59),
        TB_SETMAXTEXTROWS = (0x0400 + 60),
        TB_GETTEXTROWS = (0x0400 + 61),

        TB_GETINSERTMARK = (0x0400 + 79),
        TB_SETINSERTMARK = (0x0400 + 80),
        TB_INSERTMARKHITTEST = (0x0400 + 81),
        TB_MOVEBUTTON = (0x0400 + 82),
        TB_GETMAXSIZE = (0x0400 + 83),
        TB_SETEXTENDEDSTYLE = (0x0400 + 84),
        TB_GETEXTENDEDSTYLE = (0x0400 + 85),
        TB_GETPADDING = (0x0400 + 86),
        TB_SETPADDING = (0x0400 + 87),
        TB_SETINSERTMARKCOLOR = (0x0400 + 88),
        TB_GETINSERTMARKCOLOR = (0x0400 + 89),
        TB_GETOBJECT = (0x0400 + 62),
        TB_GETHOTITEM = (0x0400 + 71),
        TB_SETHOTITEM = (0x0400 + 72),
        TB_SETANCHORHIGHLIGHT = (0x0400 + 73),
        TB_GETANCHORHIGHLIGHT = (0x0400 + 74),
        TB_MAPACCELERATORA = (0x0400 + 78),
        TB_SETSTATE = (0x0400 + 17),
        TB_GETSTRINGW = (0x0400 + 91),
        TB_GETSTRINGA = (0x0400 + 92),
        TB_ADDBUTTONSA = (0x0400 + 20),
        TB_ADDBUTTONSW = (0x0400 + 68),
        TB_INSERTBUTTONA = (0x0400 + 21),
        TB_INSERTBUTTONW = (0x0400 + 67),
        TB_DELETEBUTTON = (0x0400 + 22),
        TB_GETBUTTON = (0x0400 + 23),
        TB_BUTTONCOUNT = (0x0400 + 24),
        TB_GETBUTTONINFOW = (0x0400 + 63),
        TB_SETBUTTONINFOW = (0x0400 + 64),
        TB_GETBUTTONINFOA = (0x0400 + 65),
        TB_SETBUTTONINFOA = (0x0400 + 66),
        TB_HITTEST = (0x0400 + 69),
        TB_MAPACCELERATORW = (0x0400 + 90),
        TB_ENABLEBUTTON = (0x0400 + 1),
        TB_CHECKBUTTON = (0x0400 + 2),
        TB_PRESSBUTTON = (0x0400 + 3),
        TB_HIDEBUTTON = (0x0400 + 4),
        TB_INDETERMINATE = (0x0400 + 5),
        TB_MARKBUTTON = (0x0400 + 6),
        TB_ISBUTTONENABLED = (0x0400 + 9),
        TB_ISBUTTONCHECKED = (0x0400 + 10),
        TB_ISBUTTONPRESSED = (0x0400 + 11),
        TB_ISBUTTONHIDDEN = (0x0400 + 12),
        TB_ISBUTTONINDETERMINATE = (0x0400 + 13),
        TB_ISBUTTONHIGHLIGHTED = (0x0400 + 14),
        TBIF_IMAGE = 0x00000001,
        TBIF_TEXT = 0x00000002,
        TBIF_STATE = 0x00000004,
        TBIF_STYLE = 0x00000008,
        TBIF_COMMAND = 0x00000020,
        TBIF_SIZE = 0x00000040,
        TBN_GETOBJECT = ((0 - 700) - 12),
        TBN_BEGINDRAG = ((0 - 700) - 1),
        TBN_ENDDRAG = ((0 - 700) - 2),
        TBN_DRAGOUT = ((0 - 700) - 14),
        TBN_GETBUTTONINFOA = ((0 - 700) - 0),
        TBN_GETBUTTONINFOW = ((0 - 700) - 20),
        TBN_QUERYINSERT = ((0 - 700) - 6),
        TBN_DROPDOWN = ((0 - 700) - 10),
        TBN_HOTITEMCHANGE = ((0 - 700) - 13),
        TBN_GETDISPINFOA = ((0 - 700) - 16),
        TBN_GETDISPINFOW = ((0 - 700) - 17),
        TBN_GETINFOTIPA = ((0 - 700) - 18),
        TBN_GETINFOTIPW = ((0 - 700) - 19),
        TTS_ALWAYSTIP = 0x01,
        TTS_NOPREFIX = 0x02,
        TTS_NOANIMATE = 0x10,
        TTS_NOFADE = 0x20,
        TTS_BALLOON = 0x40,
        TTI_NONE = 0,
        TTI_INFO = 1,
        TTI_WARNING = 2,
        TTI_ERROR = 3,
        TTF_PARSELINKS = 0x1000,
        TTF_IDISHWND = 0x0001,
        TTF_RTLREADING = 0x0004,
        TTF_TRACK = 0x0020,
        TTF_CENTERTIP = 0x0002,
        TTF_SUBCLASS = 0x0010,
        TTF_TRANSPARENT = 0x0100,
        TTF_ABSOLUTE = 0x0080,
        TTDT_AUTOMATIC = 0,
        TTDT_RESHOW = 1,
        TTDT_AUTOPOP = 2,
        TTDT_INITIAL = 3,
        TTM_SETMARGIN = (0x0400 + 26),
        TTM_POPUP = (0x0400 + 34),
        TTM_TRACKACTIVATE = (0x0400 + 17),
        TTM_TRACKPOSITION = (0x0400 + 18),
        TTM_ACTIVATE = (0x0400 + 1),
        TTM_POP = (0x0400 + 28),
        TTM_ADJUSTRECT = (0x400 + 31),
        TTM_SETDELAYTIME = (0x0400 + 3),
        TTM_SETTITLEA = (WM_USER + 32),  // wParam = TTI_*, lParam = char* szTitle
        TTM_SETTITLEW = (WM_USER + 33), // wParam = TTI_*, lParam = wchar* szTitle 
        TTM_ADDTOOLA = (0x0400 + 4),
        TTM_ADDTOOLW = (0x0400 + 50),
        TTM_DELTOOLA = (0x0400 + 5),
        TTM_DELTOOLW = (0x0400 + 51),
        TTM_NEWTOOLRECTA = (0x0400 + 6),
        TTM_NEWTOOLRECTW = (0x0400 + 52),
        TTM_RELAYEVENT = (0x0400 + 7),
        TTM_GETTIPBKCOLOR = (0x0400 + 22),
        TTM_SETTIPBKCOLOR = (0x0400 + 19),
        TTM_SETTIPTEXTCOLOR = (0x0400 + 20),
        TTM_GETTIPTEXTCOLOR = (0x0400 + 23),
        TTM_GETTOOLINFOA = (0x0400 + 8),
        TTM_GETTOOLINFOW = (0x0400 + 53),
        TTM_SETTOOLINFOA = (0x0400 + 9),
        TTM_SETTOOLINFOW = (0x0400 + 54),
        TTM_HITTESTA = (0x0400 + 10),
        TTM_HITTESTW = (0x0400 + 55),
        TTM_GETTEXTA = (0x0400 + 11),
        TTM_GETTEXTW = (0x0400 + 56),
        TTM_UPDATE = (0x0400 + 29),
        TTM_UPDATETIPTEXTA = (0x0400 + 12),
        TTM_UPDATETIPTEXTW = (0x0400 + 57),
        TTM_ENUMTOOLSA = (0x0400 + 14),
        TTM_ENUMTOOLSW = (0x0400 + 58),
        TTM_GETCURRENTTOOLA = (0x0400 + 15),
        TTM_GETCURRENTTOOLW = (0x0400 + 59),
        TTM_WINDOWFROMPOINT = (0x0400 + 16),
        TTM_GETDELAYTIME = (0x0400 + 21),
        TTM_SETMAXTIPWIDTH = (0x0400 + 24),
        TTN_GETDISPINFOA = ((0 - 520) - 0),
        TTN_GETDISPINFOW = ((0 - 520) - 10),
        TTN_SHOW = ((0 - 520) - 1),
        TTN_POP = ((0 - 520) - 2),
        TTN_NEEDTEXTA = ((0 - 520) - 0),
        TTN_NEEDTEXTW = ((0 - 520) - 10),
        TBS_AUTOTICKS = 0x0001,
        TBS_VERT = 0x0002,
        TBS_TOP = 0x0004,
        TBS_BOTTOM = 0x0000,
        TBS_BOTH = 0x0008,
        TBS_NOTICKS = 0x0010,
        TBM_GETPOS = (0x0400),
        TBM_SETTIC = (0x0400 + 4),
        TBM_SETPOS = (0x0400 + 5),
        TBM_SETRANGE = (0x0400 + 6),
        TBM_SETRANGEMIN = (0x0400 + 7),
        TBM_SETRANGEMAX = (0x0400 + 8),
        TBM_SETTICFREQ = (0x0400 + 20),
        TBM_SETPAGESIZE = (0x0400 + 21),
        TBM_SETLINESIZE = (0x0400 + 23),
        TB_LINEUP = 0,
        TB_LINEDOWN = 1,
        TB_PAGEUP = 2,
        TB_PAGEDOWN = 3,
        TB_THUMBPOSITION = 4,
        TB_THUMBTRACK = 5,
        TB_TOP = 6,
        TB_BOTTOM = 7,
        TB_ENDTRACK = 8,
        TVS_SINGLEEXPAND = 0x0400,
        TVS_DISABLEDRAGDROP = 0x0010,
        TVS_HASBUTTONS = 0x0001,
        TVS_HASLINES = 0x0002,
        TVS_LINESATROOT = 0x0004,
        TVS_EDITLABELS = 0x0008,
        TVS_SHOWSELALWAYS = 0x0020,
        TVS_RTLREADING = 0x0040,
        TVS_CHECKBOXES = 0x0100,
        TVS_TRACKSELECT = 0x0200,
        TVS_FULLROWSELECT = 0x1000,
        TVS_NONEVENHEIGHT = 0x4000,
        TVS_INFOTIP = 0x0800,
        TVS_NOTOOLTIPS = 0x0080,
        TVIF_CHILDREN = 0x0040,
        TVIF_TEXT = 0x0001,
        TVIF_IMAGE = 0x0002,
        TVIF_PARAM = 0x0004,
        TVIF_STATE = 0x0008,
        TVIF_HANDLE = 0x0010,
        TVIF_SELECTEDIMAGE = 0x0020,
        TVIS_CUT = 0x0004,
        TVIS_DROPHILITED = 0x0008,
        TVIS_BOLD = 0x0010,
        TVIS_EXPANDPARTIAL = 0x0080,
        TVIS_OVERLAYMASK = 0x0F00,
        TVIS_SELECTED = 0x0002,
        TVIS_EXPANDED = 0x0020,
        TVIS_EXPANDEDONCE = 0x0040,
        TVIS_STATEIMAGEMASK = 0xF000,
        TVIS_USERMASK = 0xF000,
        TVI_ROOT = (unchecked((int)0xFFFF0000)),
        TVI_FIRST = (unchecked((int)0xFFFF0001)),
        TVI_LAST = (unchecked((int)0xFFFF0002)),
        TVI_SORT = (unchecked((int)0xFFFF0003)),
        TVM_CREATEDRAGIMAGE = (0x1100 + 18),
        TVM_INSERTITEMA = (0x1100 + 0),
        TVM_INSERTITEMW = (0x1100 + 50),
        TVM_DELETEITEM = (0x1100 + 1),
        TVM_EXPAND = (0x1100 + 2),
        TVE_COLLAPSE = 0x0001,
        TVE_EXPAND = 0x0002,
        TVM_GETCOUNT = (0x1100 + 5),
        TVM_GETITEMRECT = (0x1100 + 4),
        TVM_GETINDENT = (0x1100 + 6),
        TVM_GETINSERTMARKCOLOR = (0x1100 + 38),
        TVM_SETINSERTMARKCOLOR = (0x1100 + 37),
        TVM_SETITEMHEIGHT = (0x1100 + 27),
        TVM_GETITEMHEIGHT = (0x1100 + 28),
        TVM_SETINDENT = (0x1100 + 7),
        TVM_SETIMAGELIST = (0x1100 + 9),
        TVM_GETNEXTITEM = (0x1100 + 10),
        TVGN_ROOT = 0x0000,
        TVGN_NEXT = 0x0001,
        TVGN_PREVIOUS = 0x0002,
        TVGN_FIRSTVISIBLE = 0x0005,
        TVGN_NEXTVISIBLE = 0x0006,
        TVGN_PREVIOUSVISIBLE = 0x0007,
        TVGN_DROPHILITE = 0x0008,
        TVGN_CARET = 0x0009,
        TVGN_PARENT = 0x0003,
        TVGN_CHILD = 0x0004,
        TVGN_LASTVISIBLE = 0x000A,
        TVM_SETBKCOLOR = (0x1100 + 29),
        TVM_SETTEXTCOLOR = (0x1100 + 30),
        TVM_GETBKCOLOR = (0x1100 + 31),
        TVM_GETTEXTCOLOR = (0x1100 + 32),
        TVM_GETITEMSTATE = (0x1100 + 39),
        TVM_SELECTITEM = (0x1100 + 11),
        TVM_GETITEMA = (0x1100 + 12),
        TVM_GETITEMW = (0x1100 + 62),
        TVM_SETITEMA = (0x1100 + 13),
        TVM_SETITEMW = (0x1100 + 63),
        TVM_EDITLABELA = (0x1100 + 14),
        TVM_EDITLABELW = (0x1100 + 65),
        TVM_GETEDITCONTROL = (0x1100 + 15),
        TVM_GETVISIBLECOUNT = (0x1100 + 16),
        TVM_HITTEST = (0x1100 + 17),
        TVM_ENSUREVISIBLE = (0x1100 + 20),
        TVM_ENDEDITLABELNOW = (0x1100 + 22),
        TVM_GETISEARCHSTRINGA = (0x1100 + 23),
        TVM_GETISEARCHSTRINGW = (0x1100 + 64),
        TVN_SELCHANGINGA = ((0 - 400) - 1),
        TVN_SELCHANGINGW = ((0 - 400) - 50),
        TVN_GETINFOTIPA = ((0 - 400) - 13),
        TVN_GETINFOTIPW = ((0 - 400) - 14),
        TVN_SELCHANGEDA = ((0 - 400) - 2),
        TVN_SELCHANGEDW = ((0 - 400) - 51),
        TVC_UNKNOWN = 0x0000,
        TVC_BYMOUSE = 0x0001,
        TVC_BYKEYBOARD = 0x0002,
        TVN_GETDISPINFOA = ((0 - 400) - 3),
        TVN_GETDISPINFOW = ((0 - 400) - 52),
        TVN_SETDISPINFOA = ((0 - 400) - 4),
        TVN_SETDISPINFOW = ((0 - 400) - 53),
        TVN_ITEMEXPANDINGA = ((0 - 400) - 5),
        TVN_ITEMEXPANDINGW = ((0 - 400) - 54),
        TVN_ITEMEXPANDEDA = ((0 - 400) - 6),
        TVN_ITEMEXPANDEDW = ((0 - 400) - 55),
        TVN_BEGINDRAGA = ((0 - 400) - 7),
        TVN_BEGINDRAGW = ((0 - 400) - 56),
        TVN_BEGINRDRAGA = ((0 - 400) - 8),
        TVN_BEGINRDRAGW = ((0 - 400) - 57),
        TVN_BEGINLABELEDITA = ((0 - 400) - 10),
        TVN_BEGINLABELEDITW = ((0 - 400) - 59),
        TVN_ENDLABELEDITA = ((0 - 400) - 11),
        TVN_ENDLABELEDITW = ((0 - 400) - 60),

        TCS_SCROLLOPPOSITE = 0x0001,  // assumes multiline tab
        TCS_BOTTOM = 0x0002,
        TCS_RIGHT = 0x0002,
        TCS_MULTISELECT = 0x0004, // allow multi-select in button mode
        TCS_FLATBUTTONS = 0x0008,
        TCS_FORCEICONLEFT = 0x0010,
        TCS_FORCELABELLEFT = 0x0020,
        TCS_HOTTRACK = 0x0040,
        TCS_VERTICAL = 0x0080,
        TCS_TABS = 0x0000,
        TCS_BUTTONS = 0x0100,
        TCS_SINGLELINE = 0x0000,
        TCS_MULTILINE = 0x0200,
        TCS_RIGHTJUSTIFY = 0x0000,
        TCS_FIXEDWIDTH = 0x0400,
        TCS_RAGGEDRIGHT = 0x0800,
        TCS_FOCUSONBUTTONDOWN = 0x1000,
        TCS_OWNERDRAWFIXED = 0x2000,
        TCS_TOOLTIPS = 0x4000,
        TCS_FOCUSNEVER = 0x8000,
            // EX styles for use with TCM_SETEXTENDEDSTYLE
         TCS_EX_FLATSEPARATORS = 0x00000001,
         TCS_EX_REGISTERDROP = 0x00000002,
        TCM_SETIMAGELIST = (0x1300 + 3),
        TCIF_TEXT = 0x0001,
        TCIF_IMAGE = 0x0002,
        TCM_GETITEMA = (0x1300 + 5),
        TCM_GETITEMW = (0x1300 + 60),
        TCM_SETITEMA = (0x1300 + 6),
        TCM_SETITEMW = (0x1300 + 61),
        TCM_INSERTITEMA = (0x1300 + 7),
        TCM_INSERTITEMW = (0x1300 + 62),
        TCM_DELETEITEM = (0x1300 + 8),
        TCM_DELETEALLITEMS = (0x1300 + 9),
        TCM_GETITEMRECT = (0x1300 + 10),
        TCM_GETCURSEL = (0x1300 + 11),
        TCM_SETCURSEL = (0x1300 + 12),
        TCM_ADJUSTRECT = (0x1300 + 40),
        TCM_SETITEMSIZE = (0x1300 + 41),
        TCM_SETPADDING = (0x1300 + 43),
        TCM_GETROWCOUNT = (0x1300 + 44),
        TCM_GETTOOLTIPS = (0x1300 + 45),
        TCM_SETTOOLTIPS = (0x1300 + 46),
        TCN_SELCHANGE = ((0 - 550) - 1),
        TCN_SELCHANGING = ((0 - 550) - 2),
        TBSTYLE_WRAPPABLE = 0x0200,
        TYMED_NULL = 0,
        TVM_GETLINECOLOR = (TV_FIRST + 41),
        TVM_SETLINECOLOR = (TV_FIRST + 40),
        TVM_SETTOOLTIPS = (TV_FIRST + 24),
        TVSIL_STATE = 2,
        TVM_SORTCHILDRENCB = (TV_FIRST + 21),
        TMPF_FIXED_PITCH = 0x01;

        public const int TVHT_NOWHERE = 0x0001,
        TVHT_ONITEMICON = 0x0002,
        TVHT_ONITEMLABEL = 0x0004,
        TVHT_ONITEM = (TVHT_ONITEMICON | TVHT_ONITEMLABEL | TVHT_ONITEMSTATEICON),
        TVHT_ONITEMINDENT = 0x0008,
        TVHT_ONITEMBUTTON = 0x0010,
        TVHT_ONITEMRIGHT = 0x0020,
        TVHT_ONITEMSTATEICON = 0x0040,
        TVHT_ABOVE = 0x0100,
        TVHT_BELOW = 0x0200,
        TVHT_TORIGHT = 0x0400,
        TVHT_TOLEFT = 0x0800;

        public const int
        RB_INSERTBANDA = (WM_USER + 1),
        RB_DELETEBAND = (WM_USER + 2),
        RB_GETBARINFO = (WM_USER + 3),
        RB_SETBARINFO = (WM_USER + 4),
        RB_GETBARHEIGHT = (WM_USER + 27),
        RB_SETBANDINFOA = (WM_USER + 6),
        RB_SETPARENT = (WM_USER + 7),
        RB_HITTEST = (WM_USER + 8),
        RB_GETRECT = (WM_USER + 9),
        RB_INSERTBANDW = (WM_USER + 10),
        RB_SETBANDINFOW = (WM_USER + 11),
        RB_GETBANDCOUNT = (WM_USER + 12),
        RB_GETROWCOUNT = (WM_USER + 13),
        RB_GETROWHEIGHT = (WM_USER + 14),
        RB_IDTOINDEX = (WM_USER + 16), // wParam == id
        RB_GETTOOLTIPS = (WM_USER + 17),
        RB_SETTOOLTIPS = (WM_USER + 18),
        RB_SETBKCOLOR = (WM_USER + 19),// sets the default BK color
        RB_GETBKCOLOR = (WM_USER + 20), // defaults to CLR_NONE
        RB_SETTEXTCOLOR = (WM_USER + 21),
        RB_GETTEXTCOLOR = (WM_USER + 22), // defaults to 0x00000000
        RB_SIZETORECT = (WM_USER + 23),
        RB_GETBANDINFOW = (WM_USER + 28),
        RB_GETBANDINFOA = (WM_USER + 29),
        CCM_FIRST = 0x2000,     // Common control shared messages
        CCM_LAST = (CCM_FIRST + 0x200),
        CCM_SETCOLORSCHEME = (CCM_FIRST + 2), // lParam is color scheme
        CCM_GETCOLORSCHEME = (CCM_FIRST + 3), // fills in COLORSCHEME pointed to by lParam
        CCM_GETDROPTARGET = (CCM_FIRST + 4),
        CCM_SETWINDOWTHEME = (CCM_FIRST + 0xb);

        public const int
        RBBIM_STYLE = 0x00000001,
        RBBIM_COLORS = 0x00000002,
        RBBIM_TEXT = 0x00000004,
        RBBIM_IMAGE = 0x00000008,
        RBBIM_CHILD = 0x00000010,
        RBBIM_CHILDSIZE = 0x00000020,
        RBBIM_SIZE = 0x00000040,
        RBBIM_BACKGROUND = 0x00000080,
        RBBIM_ID = 0x00000100,
        RBBIM_IDEALSIZE = 0x00000200,
        RBBIM_LPARAM = 0x00000400,
        RBBIM_HEADERSIZE = 0x00000800;

        public const int
        RBBS_BREAK = 0x00000001,  // break to new line
        RBBS_FIXEDSIZE = 0x00000002, // band can't be sized
        RBBS_CHILDEDGE = 0x00000004,  // edge around top & bottom of child window
        RBBS_HIDDEN = 0x00000008, // don't show
        RBBS_NOVERT = 0x00000010,  // don't show when vertical
        RBBS_FIXEDBMP = 0x00000020,  // bitmap doesn't move during band resize             //
        RBBS_VARIABLEHEIGHT = 0x00000040, // allow autosizing of this child vertically
        RBBS_GRIPPERALWAYS = 0x00000080, // always show the gripper
        RBBS_NOGRIPPER = 0x00000100, // never show the gripper              //
        RBBS_USECHEVRON = 0x00000200, // display drop-down button for this band if it's sized smaller than ideal width             //
        RBBS_HIDETITLE = 0x00000400,  // keep band title hidden
        RBBS_TOPALIGN = 0x00000800; // keep band

        public const int RBS_REGISTERDROP = 0x1000,
        RBS_AUTOSIZE = 0x2000,
        RBS_VERTICALGRIPPER = 0x4000,
        RBS_DBLCLKTOGGLE = 0x8000,
        RBS_TOOLTIPS = 0x0100,
        RBS_VARHEIGHT = 0x0200,
        RBS_BANDBORDERS = 0x0400,
        RBS_FIXEDORDER = 0x0800;

        public const int UIS_SET = 1,
        UIS_CLEAR = 2,
        UIS_INITIALIZE = 3,
        UISF_HIDEFOCUS = 0x1,
        UISF_HIDEACCEL = 0x2,
        USERCLASSTYPE_FULL = 1,
        USERCLASSTYPE_SHORT = 2,
        USERCLASSTYPE_APPNAME = 3,
        UOI_FLAGS = 1;


        public const int VIEW_E_DRAW = unchecked((int)0x80040140),
        VK_PRIOR = 0x21,
        VK_NEXT = 0x22,
        VK_LEFT = 0x25,
        VK_UP = 0x26,
        VK_RIGHT = 0x27,
        VK_DOWN = 0x28,
        VK_TAB = 0x09,
        VK_SHIFT = 0x10,
        VK_CONTROL = 0x11,
        VK_MENU = 0x12,
        VK_CAPITAL = 0x14,
        VK_KANA = 0x15,
        VK_SNAPSHOT = 0x2C,
        VK_ESCAPE = 0x1B,
        VK_END = 0x23,
        VK_HOME = 0x24,
        VK_NUMLOCK = 0x90,
        VK_SCROLL = 0x91,
        VK_INSERT = 0x002D,
        VK_DELETE = 0x002E;

        public const int
        WSF_VISIBLE = 0x0001,
        WM_NULL = 0x0000,
        WM_CREATE = 0x0001,
        WM_DELETEITEM = 0x002D,
        WM_DESTROY = 0x0002,
        WM_MOVE = 0x0003,
        WM_SIZE = 0x0005,
        WM_ACTIVATE = 0x0006,
        WA_INACTIVE = 0,
        WA_ACTIVE = 1,
        WA_CLICKACTIVE = 2,
        WM_SETFOCUS = 0x0007,
        WM_KILLFOCUS = 0x0008,
        WM_ENABLE = 0x000A,
        WM_SETREDRAW = 0x000B,
        WM_SETTEXT = 0x000C,
        WM_GETTEXT = 0x000D,
        WM_GETTEXTLENGTH = 0x000E,
        WM_PAINT = 0x000F,
        WM_CLOSE = 0x0010,
        WM_QUERYENDSESSION = 0x0011,
        WM_QUIT = 0x0012,
        WM_QUERYOPEN = 0x0013,
        WM_ERASEBKGND = 0x0014,
        WM_SYSCOLORCHANGE = 0x0015,
        WM_ENDSESSION = 0x0016,
        WM_SHOWWINDOW = 0x0018,
        WM_WININICHANGE = 0x001A,
        WM_SETTINGCHANGE = 0x001A,
        WM_DEVMODECHANGE = 0x001B,
        WM_ACTIVATEAPP = 0x001C,
        WM_FONTCHANGE = 0x001D,
        WM_TIMECHANGE = 0x001E,
        WM_CANCELMODE = 0x001F,
        WM_SETCURSOR = 0x0020,
        WM_MOUSEACTIVATE = 0x0021,
        WM_CHILDACTIVATE = 0x0022,
        WM_QUEUESYNC = 0x0023,
        WM_GETMINMAXINFO = 0x0024,
        WM_PAINTICON = 0x0026,
        WM_ICONERASEBKGND = 0x0027,
        WM_NEXTDLGCTL = 0x0028,
        WM_SPOOLERSTATUS = 0x002A,
        WM_DRAWITEM = 0x002B,
        WM_MEASUREITEM = 0x002C,
        WM_VKEYTOITEM = 0x002E,
        WM_CHARTOITEM = 0x002F,
        WM_SETFONT = 0x0030,
        WM_GETFONT = 0x0031,
        WM_SETHOTKEY = 0x0032,
        WM_GETHOTKEY = 0x0033,
        WM_QUERYDRAGICON = 0x0037,
        WM_COMPAREITEM = 0x0039,
        WM_GETOBJECT = 0x003D,
        WM_COMPACTING = 0x0041,
        WM_COMMNOTIFY = 0x0044,
        WM_WINDOWPOSCHANGING = 0x0046,
        WM_WINDOWPOSCHANGED = 0x0047,
        WM_POWER = 0x0048,
        WM_COPYDATA = 0x004A,
        WM_CANCELJOURNAL = 0x004B,
        WM_NOTIFY = 0x004E,
        WM_INPUTLANGCHANGEREQUEST = 0x0050,
        WM_INPUTLANGCHANGE = 0x0051,
        WM_TCARD = 0x0052,
        WM_HELP = 0x0053,
        WM_USERCHANGED = 0x0054,
        WM_NOTIFYFORMAT = 0x0055,
        WM_CONTEXTMENU = 0x007B,
        WM_STYLECHANGING = 0x007C,
        WM_STYLECHANGED = 0x007D,
        WM_DISPLAYCHANGE = 0x007E,
        WM_GETICON = 0x007F,
        WM_SETICON = 0x0080,
        WM_NCCREATE = 0x0081,
        WM_NCDESTROY = 0x0082,
        WM_NCCALCSIZE = 0x0083,
        WM_NCHITTEST = 0x0084,
        WM_NCPAINT = 0x0085,
        WM_NCACTIVATE = 0x0086,
        WM_GETDLGCODE = 0x0087,
        WM_NCMOUSEMOVE = 0x00A0,
        WM_NCMOUSELEAVE = 0x02A2,
        WM_NCLBUTTONDOWN = 0x00A1,
        WM_NCLBUTTONUP = 0x00A2,
        WM_NCLBUTTONDBLCLK = 0x00A3,
        WM_NCRBUTTONDOWN = 0x00A4,
        WM_NCRBUTTONUP = 0x00A5,
        WM_NCRBUTTONDBLCLK = 0x00A6,
        WM_NCMBUTTONDOWN = 0x00A7,
        WM_NCMBUTTONUP = 0x00A8,
        WM_NCMBUTTONDBLCLK = 0x00A9,
        WM_NCXBUTTONDOWN = 0x00AB,
        WM_NCXBUTTONUP = 0x00AC,
        WM_NCXBUTTONDBLCLK = 0x00AD,
        WM_KEYFIRST = 0x0100,
        WM_KEYDOWN = 0x0100,
        WM_KEYUP = 0x0101,
        WM_CHAR = 0x0102,
        WM_DEADCHAR = 0x0103,
        WM_CTLCOLOR = 0x0019,
        WM_SYSKEYDOWN = 0x0104,
        WM_SYSKEYUP = 0x0105,
        WM_SYSCHAR = 0x0106,
        WM_SYSDEADCHAR = 0x0107,
        WM_KEYLAST = 0x0108,
        WM_IME_STARTCOMPOSITION = 0x010D,
        WM_IME_ENDCOMPOSITION = 0x010E,
        WM_IME_COMPOSITION = 0x010F,
        WM_IME_KEYLAST = 0x010F,
        WM_INITDIALOG = 0x0110,
        WM_COMMAND = 0x0111,
        WM_SYSCOMMAND = 0x0112,
        WM_TIMER = 0x0113,
        WM_HSCROLL = 0x0114,
        WM_VSCROLL = 0x0115,
        WM_INITMENU = 0x0116,
        WM_INITMENUPOPUP = 0x0117,
        WM_MENUSELECT = 0x011F,
        WM_MENUCHAR = 0x0120,
        WM_ENTERIDLE = 0x0121,
        WM_UNINITMENUPOPUP = 0x0125,
        WM_CHANGEUISTATE = 0x0127,
        WM_UPDATEUISTATE = 0x0128,
        WM_QUERYUISTATE = 0x0129,
        WM_CTLCOLORMSGBOX = 0x0132,
        WM_CTLCOLOREDIT = 0x0133,
        WM_CTLCOLORLISTBOX = 0x0134,
        WM_CTLCOLORBTN = 0x0135,
        WM_CTLCOLORDLG = 0x0136,
        WM_CTLCOLORSCROLLBAR = 0x0137,
        WM_CTLCOLORSTATIC = 0x0138,
        WM_MOUSEFIRST = 0x0200,
        WM_MOUSEMOVE = 0x0200,
        WM_LBUTTONDOWN = 0x0201,
        WM_LBUTTONUP = 0x0202,
        WM_LBUTTONDBLCLK = 0x0203,
        WM_RBUTTONDOWN = 0x0204,
        WM_RBUTTONUP = 0x0205,
        WM_RBUTTONDBLCLK = 0x0206,
        WM_MBUTTONDOWN = 0x0207,
        WM_MBUTTONUP = 0x0208,
        WM_MBUTTONDBLCLK = 0x0209,
        WM_XBUTTONDOWN = 0x020B,
        WM_XBUTTONUP = 0x020C,
        WM_XBUTTONDBLCLK = 0x020D,
        WM_MOUSEWHEEL = 0x020A,
        WM_MOUSELAST = 0x020A;



        public const int WHEEL_DELTA = 120,
        WM_PARENTNOTIFY = 0x0210,
        WM_ENTERMENULOOP = 0x0211,
        WM_EXITMENULOOP = 0x0212,
        WM_NEXTMENU = 0x0213,
        WM_SIZING = 0x0214,
        WM_CAPTURECHANGED = 0x0215,
        WM_MOVING = 0x0216,
        WM_POWERBROADCAST = 0x0218,
        WM_DEVICECHANGE = 0x0219,
        WM_IME_SETCONTEXT = 0x0281,
        WM_IME_NOTIFY = 0x0282,
        WM_IME_CONTROL = 0x0283,
        WM_IME_COMPOSITIONFULL = 0x0284,
        WM_IME_SELECT = 0x0285,
        WM_IME_CHAR = 0x0286,
        WM_IME_KEYDOWN = 0x0290,
        WM_IME_KEYUP = 0x0291,
        WM_MDICREATE = 0x0220,
        WM_MDIDESTROY = 0x0221,
        WM_MDIACTIVATE = 0x0222,
        WM_MDIRESTORE = 0x0223,
        WM_MDINEXT = 0x0224,
        WM_MDIMAXIMIZE = 0x0225,
        WM_MDITILE = 0x0226,
        WM_MDICASCADE = 0x0227,
        WM_MDIICONARRANGE = 0x0228,
        WM_MDIGETACTIVE = 0x0229,
        WM_MDISETMENU = 0x0230,
        WM_ENTERSIZEMOVE = 0x0231,
        WM_EXITSIZEMOVE = 0x0232,
        WM_DROPFILES = 0x0233,
        WM_MDIREFRESHMENU = 0x0234,
        WM_MOUSEHOVER = 0x02A1,
        WM_MOUSELEAVE = 0x02A3,
        WM_CUT = 0x0300,
        WM_COPY = 0x0301,
        WM_PASTE = 0x0302,
        WM_CLEAR = 0x0303,
        WM_UNDO = 0x0304,
        WM_RENDERFORMAT = 0x0305,
        WM_RENDERALLFORMATS = 0x0306,
        WM_DESTROYCLIPBOARD = 0x0307,
        WM_DRAWCLIPBOARD = 0x0308,
        WM_PAINTCLIPBOARD = 0x0309,
        WM_VSCROLLCLIPBOARD = 0x030A,
        WM_SIZECLIPBOARD = 0x030B,
        WM_ASKCBFORMATNAME = 0x030C,
        WM_CHANGECBCHAIN = 0x030D,
        WM_HSCROLLCLIPBOARD = 0x030E,
        WM_QUERYNEWPALETTE = 0x030F,
        WM_PALETTEISCHANGING = 0x0310,
        WM_PALETTECHANGED = 0x0311,
        WM_HOTKEY = 0x0312,
        WM_PRINT = 0x0317,
        WM_PRINTCLIENT = 0x0318,
        WM_THEMECHANGED = 0x031A,
        WM_HANDHELDFIRST = 0x0358,
        WM_HANDHELDLAST = 0x035F,
        WM_AFXFIRST = 0x0360,
        WM_AFXLAST = 0x037F,
        WM_PENWINFIRST = 0x0380,
        WM_PENWINLAST = 0x038F,
        WM_APP = unchecked((int)0x8000),
        WM_USER = 0x0400,
        WM_REFLECT = NativeMethods.WM_USER + 0x1C00,
        WS_OVERLAPPED = 0x00000000,
        WS_POPUP = unchecked((int)0x80000000),
        WS_CHILD = 0x40000000,
        WS_MINIMIZE = 0x20000000,
        WS_VISIBLE = 0x10000000,
        WS_DISABLED = 0x08000000,
        WS_CLIPSIBLINGS = 0x04000000,
        WS_CLIPCHILDREN = 0x02000000,
        WS_MAXIMIZE = 0x01000000,
        WS_CAPTION = 0x00C00000,
        WS_BORDER = 0x00800000,
        WS_DLGFRAME = 0x00400000,
        WS_VSCROLL = 0x00200000,
        WS_HSCROLL = 0x00100000,
        WS_SYSMENU = 0x00080000,
        WS_THICKFRAME = 0x00040000,
        WS_TABSTOP = 0x00010000,
        WS_MINIMIZEBOX = 0x00020000,
        WS_MAXIMIZEBOX = 0x00010000,
        WS_EX_DLGMODALFRAME = 0x00000001,
        WS_EX_MDICHILD = 0x00000040,
        WS_EX_TOOLWINDOW = 0x00000080,
        WS_EX_CLIENTEDGE = 0x00000200,
        WS_EX_CONTEXTHELP = 0x00000400,
        WS_EX_RIGHT = 0x00001000,
        WS_EX_LEFT = 0x00000000,
        WS_EX_LTRREADING = 0x00000000,
        WS_EX_RTLREADING = 0x00002000,
        WS_EX_LEFTSCROLLBAR = 0x00004000,
        WS_EX_RIGHTSCROLLBAR = 0x00000000,
        WS_EX_CONTROLPARENT = 0x00010000,
        WS_EX_STATICEDGE = 0x00020000,
        WS_EX_APPWINDOW = 0x00040000,
        WS_EX_LAYERED = 0x00080000,
        WS_EX_TOPMOST = 0x00000008,
        WS_EX_LAYOUTRTL = 0x00400000,
        WS_EX_NOINHERITLAYOUT = 0x00100000,
        WPF_SETMINPOSITION = 0x0001,
        WM_CHOOSEFONT_GETLOGFONT = (0x0400 + 1);

        public const int
        IMN_CLOSESTATUSWINDOW = 0x0001,
        IMN_OPENSTATUSWINDOW = 0x0002,
        IMN_CHANGECANDIDATE = 0x0003,
        IMN_CLOSECANDIDATE = 0x0004,
        IMN_OPENCANDIDATE = 0x0005,
        IMN_SETCONVERSIONMODE = 0x0006,
        IMN_SETSENTENCEMODE = 0x0007,
        IMN_SETOPENSTATUS = 0x0008,
        IMN_SETCANDIDATEPOS = 0x0009,
        IMN_SETCOMPOSITIONFONT = 0x000A,
        IMN_SETCOMPOSITIONWINDOW = 0x000B,
        IMN_SETSTATUSWINDOWPOS = 0x000C,
        IMN_GUIDELINE = 0x000D,
        IMN_PRIVATE = 0x000E;

        public const int
         EM_CANPASTE = (WM_USER + 50),
         EM_DISPLAYBAND = (WM_USER + 51),
         EM_EXGETSEL = (WM_USER + 52),
         EM_EXLIMITTEXT = (WM_USER + 53),
         EM_EXLINEFROMCHAR = (WM_USER + 54),
         EM_EXSETSEL = (WM_USER + 55),
         EM_FINDTEXT = (WM_USER + 56),
         EM_FORMATRANGE = (WM_USER + 57),
         EM_GETCHARFORMAT = (WM_USER + 58),
         EM_GETEVENTMASK = (WM_USER + 59),
         EM_GETOLEINTERFACE = (WM_USER + 60),
         EM_GETPARAFORMAT = (WM_USER + 61),
         EM_GETSELTEXT = (WM_USER + 62),
         EM_HIDESELECTION = (WM_USER + 63),
         EM_PASTESPECIAL = (WM_USER + 64),
         EM_REQUESTRESIZE = (WM_USER + 65),
         EM_SELECTIONTYPE = (WM_USER + 66),
         EM_SETBKGNDCOLOR = (WM_USER + 67),
         EM_SETCHARFORMAT = (WM_USER + 68),
         EM_SETEVENTMASK = (WM_USER + 69),
         EM_SETOLECALLBACK = (WM_USER + 70),
         EM_SETPARAFORMAT = (WM_USER + 71),
         EM_SETTARGETDEVICE = (WM_USER + 72),
         EM_STREAMIN = (WM_USER + 73),
         EM_STREAMOUT = (WM_USER + 74),
         EM_GETTEXTRANGE = (WM_USER + 75),
         EM_FINDWORDBREAK = (WM_USER + 76),
         EM_SETOPTIONS = (WM_USER + 77),
         EM_GETOPTIONS = (WM_USER + 78),
         EM_FINDTEXTEX = (WM_USER + 79),
         EM_GETWORDBREAKPROCEX = (WM_USER + 80),
         EM_SETWORDBREAKPROCEX = (WM_USER + 81),
         EM_SETUNDOLIMIT = (WM_USER + 82),
         EM_REDO = (WM_USER + 84),
         EM_CANREDO = (WM_USER + 85),
         EM_GETUNDONAME = (WM_USER + 86),
         EM_GETREDONAME = (WM_USER + 87),
         EM_STOPGROUPTYPING = (WM_USER + 88),
         EM_SETTEXTMODE = (WM_USER + 89),
         EM_GETTEXTMODE = (WM_USER + 90);

        public static int START_PAGE_GENERAL = unchecked((int)0xffffffff);

        //  Result action ids for PrintDlgEx.
        public const int PD_RESULT_CANCEL = 0;
        public const int PD_RESULT_PRINT = 1;
        public const int PD_RESULT_APPLY = 2;

        private static int wmMouseEnterMessage = -1;
        public static int WM_MOUSEENTER
        {
            get
            {
                if (wmMouseEnterMessage == -1)
                {
                    wmMouseEnterMessage = UnsafeNativeMethods.RegisterWindowMessage("WinFormsMouseEnter");
                }
                return wmMouseEnterMessage;
            }
        }

        private static int wmUnSubclass = -1;
        public static int WM_UIUNSUBCLASS
        {
            get
            {
                if (wmUnSubclass == -1)
                {
                    wmUnSubclass = UnsafeNativeMethods.RegisterWindowMessage("WinFormsUnSubclass");
                }
                return wmUnSubclass;
            }
        }

        public const int XBUTTON1 = 0x0001;
        public const int XBUTTON2 = 0x0002;



        public static readonly int BFFM_SETSELECTION;

        public static readonly int CBEM_GETITEM;

        public static readonly int CBEM_SETITEM;

        public static readonly int CBEN_ENDEDIT;

        public static readonly int CBEM_INSERTITEM;

        public static readonly int LVM_GETITEMTEXT;

        public static readonly int LVM_SETITEMTEXT;

        public static readonly int ACM_OPEN;

        public static readonly int DTM_SETFORMAT;

        public static readonly int DTN_USERSTRING;

        public static readonly int DTN_WMKEYDOWN;

        public static readonly int DTN_FORMAT;

        public static readonly int DTN_FORMATQUERY;

        public static readonly int EMR_POLYTEXTOUT;

        public static readonly int HDM_INSERTITEM;

        public static readonly int HDM_GETITEM;

        public static readonly int HDM_SETITEM;

        public static readonly int HDN_ITEMCHANGING;

        public static readonly int HDN_ITEMCHANGED;

        public static readonly int HDN_ITEMCLICK;

        public static readonly int HDN_ITEMDBLCLICK;

        public static readonly int HDN_DIVIDERDBLCLICK;

        public static readonly int HDN_BEGINTRACK;

        public static readonly int HDN_ENDTRACK;

        public static readonly int HDN_TRACK;

        public static readonly int HDN_GETDISPINFO;

        public static readonly int LVM_GETITEM;

        public static readonly int LVM_SETBKIMAGE;

        public static readonly int LVM_SETITEM;

        public static readonly int LVM_INSERTITEM;

        public static readonly int LVM_FINDITEM;

        public static readonly int LVM_GETSTRINGWIDTH;

        public static readonly int LVM_EDITLABEL;

        public static readonly int LVM_GETCOLUMN;

        public static readonly int LVM_SETCOLUMN;

        public static readonly int LVM_GETISEARCHSTRING;

        public static readonly int LVM_INSERTCOLUMN;

        public static readonly int LVN_BEGINLABELEDIT;

        public static readonly int LVN_ENDLABELEDIT;

        public static readonly int LVN_ODFINDITEM;

        public static readonly int LVN_GETDISPINFO;

        public static readonly int LVN_GETINFOTIP;

        public static readonly int LVN_SETDISPINFO;

        public static readonly int PSM_SETTITLE;

        public static readonly int PSM_SETFINISHTEXT;

        public static readonly int RB_INSERTBAND;

        public static readonly int SB_SETTEXT;

        public static readonly int SB_GETTEXT;

        public static readonly int SB_GETTEXTLENGTH;

        public static readonly int SB_SETTIPTEXT;

        public static readonly int SB_GETTIPTEXT;

        public static readonly int TB_SAVERESTORE;

        public static readonly int TB_ADDSTRING;

        public static readonly int TB_GETBUTTONTEXT;

        public static readonly int TB_MAPACCELERATOR;

        public static readonly int TB_GETBUTTONINFO;

        public static readonly int TB_SETBUTTONINFO;

        public static readonly int TB_INSERTBUTTON;

        public static readonly int TB_ADDBUTTONS;

        public static readonly int TBN_GETBUTTONINFO;

        public static readonly int TBN_GETINFOTIP;

        public static readonly int TBN_GETDISPINFO;

        public static readonly int TTM_ADDTOOL;

        public static readonly int TTM_SETTITLE;

        public static readonly int TTM_DELTOOL;

        public static readonly int TTM_NEWTOOLRECT;

        public static readonly int TTM_GETTOOLINFO;

        public static readonly int TTM_SETTOOLINFO;

        public static readonly int TTM_HITTEST;

        public static readonly int TTM_GETTEXT;

        public static readonly int TTM_UPDATETIPTEXT;

        public static readonly int TTM_ENUMTOOLS;

        public static readonly int TTM_GETCURRENTTOOL;

        public static readonly int TTN_GETDISPINFO;

        public static readonly int TTN_NEEDTEXT;

        public static readonly int TVM_INSERTITEM;

        public static readonly int TVM_GETITEM;

        public static readonly int TVM_SETITEM;

        public static readonly int TVM_EDITLABEL;

        public static readonly int TVM_GETISEARCHSTRING;

        public static readonly int TVN_SELCHANGING;

        public static readonly int TVN_SELCHANGED;

        public static readonly int TVN_GETDISPINFO;

        public static readonly int TVN_SETDISPINFO;

        public static readonly int TVN_ITEMEXPANDING;

        public static readonly int TVN_ITEMEXPANDED;

        public static readonly int TVN_BEGINDRAG;

        public static readonly int TVN_BEGINRDRAG;

        public static readonly int TVN_BEGINLABELEDIT;

        public static readonly int TVN_ENDLABELEDIT;

        public static readonly int TCM_GETITEM;

        public static readonly int TCM_SETITEM;

        public static readonly int TCM_INSERTITEM;

        public const string TOOLTIPS_CLASS = "tooltips_class32";

        public const string
        UPDOWN_CLASS = "msctls_updown32",
        WC_LINK = "SysLink",
        ANIMATE_CLASS = "SysAnimate32",
        HOTKEY_CLASS = "msctls_hotkey32",
        WC_IPADDRESS = "SysIPAddress32",
        WC_PAGESCROLLER = "SysPager",
        WC_COMBOBOXEX = "ComboBoxEx32",
        WC_DATETIMEPICK = "SysDateTimePick32",
        WC_LISTVIEW = "SysListView32",
        WC_HEADER = "SysHeader32",
        WC_MONTHCAL = "SysMonthCal32",
        WC_PROGRESS = "msctls_progress32",
        WC_STATUSBAR = "msctls_statusbar32",
        WC_TOOLBAR = "ToolbarWindow32",
        WC_REBAR = "ReBarWindow32",
        WC_TRACKBAR = "msctls_trackbar32",
        WC_TREEVIEW = "SysTreeView32",
        WC_TABCONTROL = "SysTabControl32",
        MSH_MOUSEWHEEL = "MSWHEEL_ROLLMSG",
        MSH_SCROLL_LINES = "MSH_SCROLL_LINES_MSG",
        MOUSEZ_CLASSNAME = "MouseZ",
        MOUSEZ_TITLE = "Magellan MSWHEEL";

        public const int CHILDID_SELF = 0;

        public const int OBJID_QUERYCLASSNAMEIDX = unchecked(unchecked((int)0xFFFFFFF4));
        public const int OBJID_CLIENT = unchecked(unchecked((int)0xFFFFFFFC));
        public const int OBJID_WINDOW = unchecked(unchecked((int)0x00000000));

        public const string uuid_IAccessible = "{618736E0-3C3D-11CF-810C-00AA00389B71}";
        public const string uuid_IEnumVariant = "{00020404-0000-0000-C000-000000000046}";


        static NativeMethods()
        {
            if (Marshal.SystemDefaultCharSize == 1)
            {
                BFFM_SETSELECTION = NativeMethods.BFFM_SETSELECTIONA;
                CBEM_GETITEM = NativeMethods.CBEM_GETITEMA;
                CBEM_SETITEM = NativeMethods.CBEM_SETITEMA;
                CBEN_ENDEDIT = NativeMethods.CBEN_ENDEDITA;
                CBEM_INSERTITEM = NativeMethods.CBEM_INSERTITEMA;
                LVM_GETITEMTEXT = NativeMethods.LVM_GETITEMTEXTA;
                LVM_SETITEMTEXT = NativeMethods.LVM_SETITEMTEXTA;
                ACM_OPEN = NativeMethods.ACM_OPENA;
                DTM_SETFORMAT = NativeMethods.DTM_SETFORMATA;
                DTN_USERSTRING = NativeMethods.DTN_USERSTRINGA;
                DTN_WMKEYDOWN = NativeMethods.DTN_WMKEYDOWNA;
                DTN_FORMAT = NativeMethods.DTN_FORMATA;
                DTN_FORMATQUERY = NativeMethods.DTN_FORMATQUERYA;
                EMR_POLYTEXTOUT = NativeMethods.EMR_POLYTEXTOUTA;
                HDM_INSERTITEM = NativeMethods.HDM_INSERTITEMA;
                HDM_GETITEM = NativeMethods.HDM_GETITEMA;
                HDM_SETITEM = NativeMethods.HDM_SETITEMA;
                HDN_ITEMCHANGING = NativeMethods.HDN_ITEMCHANGINGA;
                HDN_ITEMCHANGED = NativeMethods.HDN_ITEMCHANGEDA;
                HDN_ITEMCLICK = NativeMethods.HDN_ITEMCLICKA;
                HDN_ITEMDBLCLICK = NativeMethods.HDN_ITEMDBLCLICKA;
                HDN_DIVIDERDBLCLICK = NativeMethods.HDN_DIVIDERDBLCLICKA;
                HDN_BEGINTRACK = NativeMethods.HDN_BEGINTRACKA;
                HDN_ENDTRACK = NativeMethods.HDN_ENDTRACKA;
                HDN_TRACK = NativeMethods.HDN_TRACKA;
                HDN_GETDISPINFO = NativeMethods.HDN_GETDISPINFOA;
                LVM_SETBKIMAGE = NativeMethods.LVM_SETBKIMAGEA;
                LVM_GETITEM = NativeMethods.LVM_GETITEMA;
                LVM_SETITEM = NativeMethods.LVM_SETITEMA;
                LVM_INSERTITEM = NativeMethods.LVM_INSERTITEMA;
                LVM_FINDITEM = NativeMethods.LVM_FINDITEMA;
                LVM_GETSTRINGWIDTH = NativeMethods.LVM_GETSTRINGWIDTHA;
                LVM_EDITLABEL = NativeMethods.LVM_EDITLABELA;
                LVM_GETCOLUMN = NativeMethods.LVM_GETCOLUMNA;
                LVM_SETCOLUMN = NativeMethods.LVM_SETCOLUMNA;
                LVM_GETISEARCHSTRING = NativeMethods.LVM_GETISEARCHSTRINGA;
                LVM_INSERTCOLUMN = NativeMethods.LVM_INSERTCOLUMNA;
                LVN_BEGINLABELEDIT = NativeMethods.LVN_BEGINLABELEDITA;
                LVN_ENDLABELEDIT = NativeMethods.LVN_ENDLABELEDITA;
                LVN_ODFINDITEM = NativeMethods.LVN_ODFINDITEMA;
                LVN_GETDISPINFO = NativeMethods.LVN_GETDISPINFOA;
                LVN_GETINFOTIP = NativeMethods.LVN_GETINFOTIPA;
                LVN_SETDISPINFO = NativeMethods.LVN_SETDISPINFOA;
                PSM_SETTITLE = NativeMethods.PSM_SETTITLEA;
                PSM_SETFINISHTEXT = NativeMethods.PSM_SETFINISHTEXTA;
                RB_INSERTBAND = NativeMethods.RB_INSERTBANDA;
                SB_SETTEXT = NativeMethods.SB_SETTEXTA;
                SB_GETTEXT = NativeMethods.SB_GETTEXTA;
                SB_GETTEXTLENGTH = NativeMethods.SB_GETTEXTLENGTHA;
                SB_SETTIPTEXT = NativeMethods.SB_SETTIPTEXTA;
                SB_GETTIPTEXT = NativeMethods.SB_GETTIPTEXTA;
                TB_SAVERESTORE = NativeMethods.TB_SAVERESTOREA;
                TB_ADDSTRING = NativeMethods.TB_ADDSTRINGA;
                TB_GETBUTTONTEXT = NativeMethods.TB_GETBUTTONTEXTA;
                TB_MAPACCELERATOR = NativeMethods.TB_MAPACCELERATORA;
                TB_GETBUTTONINFO = NativeMethods.TB_GETBUTTONINFOA;
                TB_SETBUTTONINFO = NativeMethods.TB_SETBUTTONINFOA;
                TB_INSERTBUTTON = NativeMethods.TB_INSERTBUTTONA;
                TB_ADDBUTTONS = NativeMethods.TB_ADDBUTTONSA;
                TBN_GETBUTTONINFO = NativeMethods.TBN_GETBUTTONINFOA;
                TBN_GETINFOTIP = NativeMethods.TBN_GETINFOTIPA;
                TBN_GETDISPINFO = NativeMethods.TBN_GETDISPINFOA;
                TTM_ADDTOOL = NativeMethods.TTM_ADDTOOLA;
                TTM_SETTITLE = NativeMethods.TTM_SETTITLEA;
                TTM_DELTOOL = NativeMethods.TTM_DELTOOLA;
                TTM_NEWTOOLRECT = NativeMethods.TTM_NEWTOOLRECTA;
                TTM_GETTOOLINFO = NativeMethods.TTM_GETTOOLINFOA;
                TTM_SETTOOLINFO = NativeMethods.TTM_SETTOOLINFOA;
                TTM_HITTEST = NativeMethods.TTM_HITTESTA;
                TTM_GETTEXT = NativeMethods.TTM_GETTEXTA;
                TTM_UPDATETIPTEXT = NativeMethods.TTM_UPDATETIPTEXTA;
                TTM_ENUMTOOLS = NativeMethods.TTM_ENUMTOOLSA;
                TTM_GETCURRENTTOOL = NativeMethods.TTM_GETCURRENTTOOLA;
                TTN_GETDISPINFO = NativeMethods.TTN_GETDISPINFOA;
                TTN_NEEDTEXT = NativeMethods.TTN_NEEDTEXTA;
                TVM_INSERTITEM = NativeMethods.TVM_INSERTITEMA;
                TVM_GETITEM = NativeMethods.TVM_GETITEMA;
                TVM_SETITEM = NativeMethods.TVM_SETITEMA;
                TVM_EDITLABEL = NativeMethods.TVM_EDITLABELA;
                TVM_GETISEARCHSTRING = NativeMethods.TVM_GETISEARCHSTRINGA;
                TVN_SELCHANGING = NativeMethods.TVN_SELCHANGINGA;
                TVN_SELCHANGED = NativeMethods.TVN_SELCHANGEDA;
                TVN_GETDISPINFO = NativeMethods.TVN_GETDISPINFOA;
                TVN_SETDISPINFO = NativeMethods.TVN_SETDISPINFOA;
                TVN_ITEMEXPANDING = NativeMethods.TVN_ITEMEXPANDINGA;
                TVN_ITEMEXPANDED = NativeMethods.TVN_ITEMEXPANDEDA;
                TVN_BEGINDRAG = NativeMethods.TVN_BEGINDRAGA;
                TVN_BEGINRDRAG = NativeMethods.TVN_BEGINRDRAGA;
                TVN_BEGINLABELEDIT = NativeMethods.TVN_BEGINLABELEDITA;
                TVN_ENDLABELEDIT = NativeMethods.TVN_ENDLABELEDITA;
                TCM_GETITEM = NativeMethods.TCM_GETITEMA;
                TCM_SETITEM = NativeMethods.TCM_SETITEMA;
                TCM_INSERTITEM = NativeMethods.TCM_INSERTITEMA;
            }
            else
            {
                BFFM_SETSELECTION = NativeMethods.BFFM_SETSELECTIONW;
                CBEM_GETITEM = NativeMethods.CBEM_GETITEMW;
                CBEM_SETITEM = NativeMethods.CBEM_SETITEMW;
                CBEN_ENDEDIT = NativeMethods.CBEN_ENDEDITW;
                CBEM_INSERTITEM = NativeMethods.CBEM_INSERTITEMW;
                LVM_GETITEMTEXT = NativeMethods.LVM_GETITEMTEXTW;
                LVM_SETITEMTEXT = NativeMethods.LVM_SETITEMTEXTW;
                ACM_OPEN = NativeMethods.ACM_OPENW;
                DTM_SETFORMAT = NativeMethods.DTM_SETFORMATW;
                DTN_USERSTRING = NativeMethods.DTN_USERSTRINGW;
                DTN_WMKEYDOWN = NativeMethods.DTN_WMKEYDOWNW;
                DTN_FORMAT = NativeMethods.DTN_FORMATW;
                DTN_FORMATQUERY = NativeMethods.DTN_FORMATQUERYW;
                EMR_POLYTEXTOUT = NativeMethods.EMR_POLYTEXTOUTW;
                HDM_INSERTITEM = NativeMethods.HDM_INSERTITEMW;
                HDM_GETITEM = NativeMethods.HDM_GETITEMW;
                HDM_SETITEM = NativeMethods.HDM_SETITEMW;
                HDN_ITEMCHANGING = NativeMethods.HDN_ITEMCHANGINGW;
                HDN_ITEMCHANGED = NativeMethods.HDN_ITEMCHANGEDW;
                HDN_ITEMCLICK = NativeMethods.HDN_ITEMCLICKW;
                HDN_ITEMDBLCLICK = NativeMethods.HDN_ITEMDBLCLICKW;
                HDN_DIVIDERDBLCLICK = NativeMethods.HDN_DIVIDERDBLCLICKW;
                HDN_BEGINTRACK = NativeMethods.HDN_BEGINTRACKW;
                HDN_ENDTRACK = NativeMethods.HDN_ENDTRACKW;
                HDN_TRACK = NativeMethods.HDN_TRACKW;
                HDN_GETDISPINFO = NativeMethods.HDN_GETDISPINFOW;
                LVM_SETBKIMAGE = NativeMethods.LVM_SETBKIMAGEW;
                LVM_GETITEM = NativeMethods.LVM_GETITEMW;
                LVM_SETITEM = NativeMethods.LVM_SETITEMW;
                LVM_INSERTITEM = NativeMethods.LVM_INSERTITEMW;
                LVM_FINDITEM = NativeMethods.LVM_FINDITEMW;
                LVM_GETSTRINGWIDTH = NativeMethods.LVM_GETSTRINGWIDTHW;
                LVM_EDITLABEL = NativeMethods.LVM_EDITLABELW;
                LVM_GETCOLUMN = NativeMethods.LVM_GETCOLUMNW;
                LVM_SETCOLUMN = NativeMethods.LVM_SETCOLUMNW;
                LVM_GETISEARCHSTRING = NativeMethods.LVM_GETISEARCHSTRINGW;
                LVM_INSERTCOLUMN = NativeMethods.LVM_INSERTCOLUMNW;
                LVN_BEGINLABELEDIT = NativeMethods.LVN_BEGINLABELEDITW;
                LVN_ENDLABELEDIT = NativeMethods.LVN_ENDLABELEDITW;
                LVN_ODFINDITEM = NativeMethods.LVN_ODFINDITEMW;
                LVN_GETDISPINFO = NativeMethods.LVN_GETDISPINFOW;
                LVN_GETINFOTIP = NativeMethods.LVN_GETINFOTIPW;
                LVN_SETDISPINFO = NativeMethods.LVN_SETDISPINFOW;
                PSM_SETTITLE = NativeMethods.PSM_SETTITLEW;
                PSM_SETFINISHTEXT = NativeMethods.PSM_SETFINISHTEXTW;
                RB_INSERTBAND = NativeMethods.RB_INSERTBANDW;
                SB_SETTEXT = NativeMethods.SB_SETTEXTW;
                SB_GETTEXT = NativeMethods.SB_GETTEXTW;
                SB_GETTEXTLENGTH = NativeMethods.SB_GETTEXTLENGTHW;
                SB_SETTIPTEXT = NativeMethods.SB_SETTIPTEXTW;
                SB_GETTIPTEXT = NativeMethods.SB_GETTIPTEXTW;
                TB_SAVERESTORE = NativeMethods.TB_SAVERESTOREW;
                TB_ADDSTRING = NativeMethods.TB_ADDSTRINGW;
                TB_GETBUTTONTEXT = NativeMethods.TB_GETBUTTONTEXTW;
                TB_MAPACCELERATOR = NativeMethods.TB_MAPACCELERATORW;
                TB_GETBUTTONINFO = NativeMethods.TB_GETBUTTONINFOW;
                TB_SETBUTTONINFO = NativeMethods.TB_SETBUTTONINFOW;
                TB_INSERTBUTTON = NativeMethods.TB_INSERTBUTTONW;
                TB_ADDBUTTONS = NativeMethods.TB_ADDBUTTONSW;
                TBN_GETBUTTONINFO = NativeMethods.TBN_GETBUTTONINFOW;
                TBN_GETINFOTIP = NativeMethods.TBN_GETINFOTIPW;
                TBN_GETDISPINFO = NativeMethods.TBN_GETDISPINFOW;
                TTM_ADDTOOL = NativeMethods.TTM_ADDTOOLW;
                TTM_SETTITLE = NativeMethods.TTM_SETTITLEW;
                TTM_DELTOOL = NativeMethods.TTM_DELTOOLW;
                TTM_NEWTOOLRECT = NativeMethods.TTM_NEWTOOLRECTW;
                TTM_GETTOOLINFO = NativeMethods.TTM_GETTOOLINFOW;
                TTM_SETTOOLINFO = NativeMethods.TTM_SETTOOLINFOW;
                TTM_HITTEST = NativeMethods.TTM_HITTESTW;
                TTM_GETTEXT = NativeMethods.TTM_GETTEXTW;
                TTM_UPDATETIPTEXT = NativeMethods.TTM_UPDATETIPTEXTW;
                TTM_ENUMTOOLS = NativeMethods.TTM_ENUMTOOLSW;
                TTM_GETCURRENTTOOL = NativeMethods.TTM_GETCURRENTTOOLW;
                TTN_GETDISPINFO = NativeMethods.TTN_GETDISPINFOW;
                TTN_NEEDTEXT = NativeMethods.TTN_NEEDTEXTW;
                TVM_INSERTITEM = NativeMethods.TVM_INSERTITEMW;
                TVM_GETITEM = NativeMethods.TVM_GETITEMW;
                TVM_SETITEM = NativeMethods.TVM_SETITEMW;
                TVM_EDITLABEL = NativeMethods.TVM_EDITLABELW;
                TVM_GETISEARCHSTRING = NativeMethods.TVM_GETISEARCHSTRINGW;
                TVN_SELCHANGING = NativeMethods.TVN_SELCHANGINGW;
                TVN_SELCHANGED = NativeMethods.TVN_SELCHANGEDW;
                TVN_GETDISPINFO = NativeMethods.TVN_GETDISPINFOW;
                TVN_SETDISPINFO = NativeMethods.TVN_SETDISPINFOW;
                TVN_ITEMEXPANDING = NativeMethods.TVN_ITEMEXPANDINGW;
                TVN_ITEMEXPANDED = NativeMethods.TVN_ITEMEXPANDEDW;
                TVN_BEGINDRAG = NativeMethods.TVN_BEGINDRAGW;
                TVN_BEGINRDRAG = NativeMethods.TVN_BEGINRDRAGW;
                TVN_BEGINLABELEDIT = NativeMethods.TVN_BEGINLABELEDITW;
                TVN_ENDLABELEDIT = NativeMethods.TVN_ENDLABELEDITW;
                TCM_GETITEM = NativeMethods.TCM_GETITEMW;
                TCM_SETITEM = NativeMethods.TCM_SETITEMW;
                TCM_INSERTITEM = NativeMethods.TCM_INSERTITEMW;
            }
        }

        public enum RegionCombineMode
        {
            AND = 1,
            COPY = 5,
            DIFF = 4,
            MAX = 5,
            MIN = 1,
            OR = 2,
            XOR = 3
        }

        [StructLayout(LayoutKind.Sequential)]
        public class OLECMD
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cmdID = 0;
            [MarshalAs(UnmanagedType.U4)]
            public int cmdf = 0;

        }


        [ComVisible(true), ComImport(), Guid("B722BCCB-4E68-101B-A2BC-00AA00404770"),
        InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IOleCommandTarget
        {

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int QueryStatus(
                ref Guid pguidCmdGroup,
                int cCmds,
                [In, Out] 
                OLECMD prgCmds,
                [In, Out]
                IntPtr pCmdText);

            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int Exec(
                ref Guid pguidCmdGroup,
                int nCmdID,
                int nCmdexecopt,

                [In, MarshalAs(UnmanagedType.LPArray)] 
                Object[] pvaIn,
                int pvaOut);
        }


        public static int SignedHIWORD(int n)
        {
            int i = (int)(short)((n >> 16) & 0xffff);

            return i;
        }

        public static int SignedLOWORD(int n)
        {
            int i = (int)(short)(n & 0xFFFF);

            return i;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class FONTDESC
        {
            public int cbSizeOfStruct = Marshal.SizeOf(typeof(FONTDESC));
            public string lpstrName;
            public long cySize;
            public short sWeight;
            public short sCharset;
            public bool fItalic;
            public bool fUnderline;
            public bool fStrikethrough;
        }



        [StructLayout(LayoutKind.Sequential)]
        public class PICTDESCbmp
        {
            internal int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESCbmp));
            internal int picType = Ole.PICTYPE_BITMAP;
            internal IntPtr hbitmap = IntPtr.Zero;
            internal IntPtr hpalette = IntPtr.Zero;
            internal int unused = 0;

            public PICTDESCbmp(System.Drawing.Bitmap bitmap)
            {
                hbitmap = bitmap.GetHbitmap();
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class PICTDESCicon
        {
            internal int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESCicon));
            internal int picType = Ole.PICTYPE_ICON;
            internal IntPtr hicon = IntPtr.Zero;
            internal int unused1 = 0;
            internal int unused2 = 0;

            public PICTDESCicon(System.Drawing.Icon icon)
            {
                hicon = UnsafeNativeMethods.CopyImage(new HandleRef(icon, icon.Handle), NativeMethods.IMAGE_ICON, icon.Size.Width, icon.Size.Height, 0);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class PICTDESCemf
        {
            internal int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESCemf));
            internal int picType = Ole.PICTYPE_ENHMETAFILE;
            internal IntPtr hemf = IntPtr.Zero;
            internal int unused1 = 0;
            internal int unused2 = 0;

            public PICTDESCemf(System.Drawing.Imaging.Metafile metafile)
            {
                //gpr                hemf = metafile.CopyHandle(); 
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class USEROBJECTFLAGS
        {
            public int fInherit = 0;
            public int fReserved = 0;
            public int dwFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class SYSTEMTIMEARRAY
        {
            public short wYear1;
            public short wMonth1;
            public short wDayOfWeek1;
            public short wDay1;
            public short wHour1;
            public short wMinute1;
            public short wSecond1;
            public short wMilliseconds1;
            public short wYear2;
            public short wMonth2;
            public short wDayOfWeek2;
            public short wDay2;
            public short wHour2;
            public short wMinute2;
            public short wSecond2;
            public short wMilliseconds2;
        }

        public delegate bool EnumChildrenCallback(IntPtr hwnd, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class HH_AKLINK
        {
            internal int cbStruct = Marshal.SizeOf(typeof(HH_AKLINK));
            internal bool fReserved = false;
            internal string pszKeywords = null;
            internal string pszUrl = null;
            internal string pszMsgText = null;
            internal string pszMsgTitle = null;
            internal string pszWindow = null;
            internal bool fIndexOnFail = false;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class HH_POPUP
        {
            internal int cbStruct = Marshal.SizeOf(typeof(HH_POPUP));
            internal IntPtr hinst = IntPtr.Zero;
            internal int idString = 0;
            internal IntPtr pszText;
            internal POINT pt;
            internal int clrForeground = -1;
            internal int clrBackground = -1;
            internal RECT rcMargins = RECT.FromXYWH(-1, -1, -1, -1);
            internal string pszFont = null;
        }


        public const int HH_FTS_DEFAULT_PROXIMITY = -1;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class HH_FTS_QUERY
        {
            internal int cbStruct = Marshal.SizeOf(typeof(HH_FTS_QUERY));
            internal bool fUniCodeStrings = false;
            [MarshalAs(UnmanagedType.LPStr)]
            internal string pszSearchQuery = null;
            internal int iProximity = NativeMethods.HH_FTS_DEFAULT_PROXIMITY;
            internal bool fStemmedSearch = false;
            internal bool fTitleOnly = false;
            internal bool fExecute = true;
            [MarshalAs(UnmanagedType.LPStr)]
            internal string pszWindow = null;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        public class MONITORINFOEX
        {
            internal int cbSize = Marshal.SizeOf(typeof(MONITORINFOEX));
            internal RECT rcMonitor = new RECT();
            internal RECT rcWork = new RECT();
            internal int dwFlags = 0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            internal char[] szDevice = new char[32];
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
        public class MONITORINFO
        {
            internal int cbSize = Marshal.SizeOf(typeof(MONITORINFO));
            internal RECT rcMonitor = new RECT();
            internal RECT rcWork = new RECT();
            internal int dwFlags = 0;
        }

        public delegate int EditStreamCallback(IntPtr dwCookie, IntPtr buf, int cb, out int transferred);

        [StructLayout(LayoutKind.Sequential)]
        public class EDITSTREAM
        {
            public IntPtr dwCookie = IntPtr.Zero;
            public int dwError = 0;
            public EditStreamCallback pfnCallback = null;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class EDITSTREAM64
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] contents = new byte[20];
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct DEVMODE
        {
            private const int CCHDEVICENAME = 32;
            private const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        [ComImport(), Guid("0FF510A3-5FA5-49F1-8CCC-190D71083F3E"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IVsPerPropertyBrowsing
        {

            [PreserveSig]
            int HideProperty(int dispid, ref bool pfHide);

            [PreserveSig]
            int DisplayChildProperties(int dispid,
                                       ref bool pfDisplay);


            [PreserveSig]
            int GetLocalizedPropertyInfo(int dispid, int localeID,
                                         [Out, MarshalAs(UnmanagedType.LPArray)] 
                                         string[] pbstrLocalizedName,
                                         [Out, MarshalAs(UnmanagedType.LPArray)] 
                                         string[] pbstrLocalizeDescription);



            [PreserveSig]
            int HasDefaultValue(int dispid,
                               ref bool fDefault);


            [PreserveSig]
            int IsPropertyReadOnly(int dispid,
                                   ref bool fReadOnly);

            [PreserveSig]
            int GetClassName([In, Out]ref string pbstrClassName);

            [PreserveSig]
            int CanResetPropertyValue(int dispid, [In, Out]ref bool pfCanReset);

            [PreserveSig]
            int ResetPropertyValue(int dispid);
        }

        [ComImport(), Guid("7494683C-37A0-11d2-A273-00C04F8EF4FF"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IManagedPerPropertyBrowsing
        {


            [PreserveSig]
            int GetPropertyAttributes(int dispid,
                                      ref int pcAttributes,
                                      ref IntPtr pbstrAttrNames,
                                      ref IntPtr pvariantInitValues);
        }

        [ComImport(), Guid("33C0C1D8-33CF-11d3-BFF2-00C04F990235"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IProvidePropertyBuilder
        {

            [PreserveSig]
            int MapPropertyToBuilder(
               int dispid,
               [In, Out, MarshalAs(UnmanagedType.LPArray)]
                int[] pdwCtlBldType,
               [In, Out, MarshalAs(UnmanagedType.LPArray)] 
                string[] pbstrGuidBldr,

           [In, Out, MarshalAs(UnmanagedType.Bool)]
                ref bool builderAvailable);

            [PreserveSig]
            int ExecuteBuilder(
                int dispid,
                [In, MarshalAs(UnmanagedType.BStr)] 
                string bstrGuidBldr,
                [In, MarshalAs(UnmanagedType.Interface)] 
                object pdispApp,

                HandleRef hwndBldrOwner,
                [Out, In, MarshalAs(UnmanagedType.Struct)] 
                ref object pvarValue,
                [In, Out, MarshalAs(UnmanagedType.Bool)] 
                ref bool actionCommitted);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public class INITCOMMONCONTROLSEX
        {
            public int dwSize = 8;
            public int dwICC;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class IMAGELISTDRAWPARAMS
        {
            public int cbSize = Marshal.SizeOf(typeof(IMAGELISTDRAWPARAMS));
            public IntPtr himl = IntPtr.Zero;
            public int i = 0;
            public IntPtr hdcDst = IntPtr.Zero;
            public int x = 0;
            public int y = 0;
            public int cx = 0;
            public int cy = 0;
            public int xBitmap = 0;
            public int yBitmap = 0;
            public int rgbBk = 0;
            public int rgbFg = 0;
            public int fStyle = 0;
            public int dwRop = 0;
            public int fState = 0;
            public int Frame = 0;
            public int crEffect = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class IMAGEINFO
        {
            public IntPtr hbmImage = IntPtr.Zero;
            public IntPtr hbmMask = IntPtr.Zero;
            public int Unused1 = 0;
            public int Unused2 = 0;

            public int rcImage_left = 0;
            public int rcImage_top = 0;
            public int rcImage_right = 0;
            public int rcImage_bottom = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class TRACKMOUSEEVENT
        {
            public int cbSize = Marshal.SizeOf(typeof(TRACKMOUSEEVENT));
            public int dwFlags;
            public IntPtr hwndTrack;
            public int dwHoverTime = 100;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;

            public POINT()
            {
            }

            public POINT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public System.Drawing.Point ToPoint()
            {
                return new System.Drawing.Point(this.x, this.y);
            }
            public override string ToString()
            {
                return "{x=" + x + ", y=" + y + "}";
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct POINTSTRUCT
        {
            public int x;
            public int y;
            public POINTSTRUCT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        public delegate IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);



        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(Point point, Size size)
            {
                this.left = point.X;
                this.top = point.Y;
                this.right = point.X + size.Width;
                this.bottom = point.Y + size.Height;
            }

            public RECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public RECT(System.Drawing.Rectangle r)
            {
                this.left = r.Left;
                this.top = r.Top;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }

            public static RECT FromXYWH(int x, int y, int width, int height)
            {
                return new RECT(x, y, x + width, y + height);
            }

            public System.Drawing.Point Point
            {
                get
                {
                    return new System.Drawing.Point(this.left, this.top);
                }
            }

            public System.Drawing.Size Size
            {
                get
                {
                    return new System.Drawing.Size(this.right - this.left, this.bottom - this.top);
                }
            }

            public System.Drawing.Rectangle Rectangle
            {
                get
                {
                    return new System.Drawing.Rectangle(left, top, right - left, bottom - top);
                }
            }

            public static RECT FromRectangle(Rectangle rect)
            {
                return new RECT(rect.Left, rect.Top, rect.Right, rect.Bottom);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class RECT_CLASS
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT_CLASS(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int cxLeftWidth;
            public int cxRightWidth;
            public int cyTopHeight;
            public int cyBottomHeight;
        }

        public delegate int ListViewCompareCallback(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);

        public delegate int TreeViewCompareCallback(IntPtr lParam1, IntPtr lParam2, IntPtr lParamSort);


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class WNDCLASS_I
        {
            public int style = 0;
            public IntPtr lpfnWndProc = IntPtr.Zero;
            public int cbClsExtra = 0;
            public int cbWndExtra = 0;
            public IntPtr hInstance = IntPtr.Zero;
            public IntPtr hIcon = IntPtr.Zero;
            public IntPtr hCursor = IntPtr.Zero;
            public IntPtr hbrBackground = IntPtr.Zero;
            public IntPtr lpszMenuName = IntPtr.Zero;
            public IntPtr lpszClassName = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class NONCLIENTMETRICS
        {
            public int cbSize = Marshal.SizeOf(typeof(NONCLIENTMETRICS));
            public int iBorderWidth = 0;
            public int iScrollWidth = 0;
            public int iScrollHeight = 0;
            public int iCaptionWidth = 0;
            public int iCaptionHeight = 0;
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT lfCaptionFont = null;
            public int iSmCaptionWidth = 0;
            public int iSmCaptionHeight = 0;
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT lfSmCaptionFont = null;
            public int iMenuWidth = 0;
            public int iMenuHeight = 0;
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT lfMenuFont = null;
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT lfStatusFont = null;
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT lfMessageFont = null;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ICONMETRICS
        {
            public int cbSize = Marshal.SizeOf(typeof(ICONMETRICS));
            public int iHorzSpacing;
            public int iVertSpacing;
            public int iTitleWrap;
            [MarshalAs(UnmanagedType.Struct)]
            public LOGFONT lfFont;
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public struct MSG
        {
            public IntPtr hwnd;
            public int message;
            public IntPtr wParam;
            public IntPtr lParam;
            public int time;

            public int pt_x;
            public int pt_y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PAINTSTRUCT
        {
            public IntPtr hdc;
            public bool fErase;

            public int rcPaint_left;
            public int rcPaint_top;
            public int rcPaint_right;
            public int rcPaint_bottom;
            public bool fRestore;
            public bool fIncUpdate;
            public int reserved1;
            public int reserved2;
            public int reserved3;
            public int reserved4;
            public int reserved5;
            public int reserved6;
            public int reserved7;
            public int reserved8;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class SCROLLINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(SCROLLINFO));
            public int fMask;
            public int nMin;
            public int nMax;
            public int nPage;
            public int nPos;
            public int nTrackPos;

            public SCROLLINFO()
            {
            }

            public SCROLLINFO(int mask, int min, int max, int page, int pos)
            {
                fMask = mask;
                nMin = min;
                nMax = max;
                nPage = page;
                nPos = pos;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class TPMPARAMS
        {
            public int cbSize = Marshal.SizeOf(typeof(TPMPARAMS));

            public int rcExclude_left;
            public int rcExclude_top;
            public int rcExclude_right;
            public int rcExclude_bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class SIZE
        {
            public int cx;
            public int cy;

            public SIZE(int cx, int cy)
            {
                this.cx = cx;
                this.cy = cy;
            }
            public SIZE()
            {
            }

            public System.Drawing.Size ToSize()
            {
                return new System.Drawing.Size(cx, cy);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            // ptMinPosition was a by-value POINT structure
            public int ptMinPosition_x;
            public int ptMinPosition_y;
            // ptMaxPosition was a by-value POINT structure
            public int ptMaxPosition_x;
            public int ptMaxPosition_y;
            // rcNormalPosition was a by-value RECT structure
            public int rcNormalPosition_left;
            public int rcNormalPosition_top;
            public int rcNormalPosition_right;
            public int rcNormalPosition_bottom;
        }



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class STARTUPINFO_I
        {
            public int cb = 0;
            public IntPtr lpReserved = IntPtr.Zero;
            public IntPtr lpDesktop = IntPtr.Zero;
            public IntPtr lpTitle = IntPtr.Zero;
            public int dwX = 0;
            public int dwY = 0;
            public int dwXSize = 0;
            public int dwYSize = 0;
            public int dwXCountChars = 0;
            public int dwYCountChars = 0;
            public int dwFillAttribute = 0;
            public int dwFlags = 0;
            public short wShowWindow = 0;
            public short cbReserved2 = 0;
            public IntPtr lpReserved2 = IntPtr.Zero;
            public IntPtr hStdInput = IntPtr.Zero;
            public IntPtr hStdOutput = IntPtr.Zero;
            public IntPtr hStdError = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class PAGESETUPDLG
        {
            public int lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hDevMode;
            public IntPtr hDevNames;
            public int Flags;

            //POINT           ptPaperSize;
            public int paperSizeX = 0;
            public int paperSizeY = 0;

            // RECT            rtMinMargin;
            public int minMarginLeft;
            public int minMarginTop;
            public int minMarginRight;
            public int minMarginBottom;

            // RECT            rtMargin; 
            public int marginLeft;
            public int marginTop;
            public int marginRight;
            public int marginBottom;

            public IntPtr hInstance = IntPtr.Zero;
            public IntPtr lCustData = IntPtr.Zero;
            public WndProc lpfnPageSetupHook = null;
            public WndProc lpfnPagePaintHook = null;
            public string lpPageSetupTemplateName = null;
            public IntPtr hPageSetupTemplate = IntPtr.Zero;
        }

        // x86 requires EXPLICIT packing of 1.
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public class PRINTDLG
        {
            public int lStructSize;

            public IntPtr hwndOwner;
            public IntPtr hDevMode;
            public IntPtr hDevNames;
            public IntPtr hDC;

            public int Flags;

            public short nFromPage;
            public short nToPage;
            public short nMinPage;
            public short nMaxPage;
            public short nCopies;

            public IntPtr hInstance;
            public IntPtr lCustData;

            public WndProc lpfnPrintHook;
            public WndProc lpfnSetupHook;

            public string lpPrintTemplateName;
            public string lpSetupTemplateName;

            public IntPtr hPrintTemplate;
            public IntPtr hSetupTemplate;

        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class PRINTDLGEX
        {
            public int lStructSize;

            public IntPtr hwndOwner;
            public IntPtr hDevMode;
            public IntPtr hDevNames;
            public IntPtr hDC;

            public int Flags;
            public int Flags2;

            public int ExclusionFlags;

            public int nPageRanges;
            public int nMaxPageRanges;

            public IntPtr pageRanges;

            public int nMinPage;
            public int nMaxPage;
            public int nCopies;

            public IntPtr hInstance;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpPrintTemplateName;

            public WndProc lpCallback = null;

            public int nPropertyPages;

            public IntPtr lphPropertyPages;

            public int nStartPage;
            public int dwResultAction;

        }

        // x86 requires EXPLICIT packing of 1.
        [StructLayout(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto)]
        public class PRINTPAGERANGE
        {
            public int nFromPage = 0;
            public int nToPage = 0;
        }



        [StructLayout(LayoutKind.Sequential)]
        public class PICTDESC
        {
            internal int cbSizeOfStruct;
            public int picType;
            internal IntPtr union1;
            internal int union2;
            internal int union3;

            public static PICTDESC CreateBitmapPICTDESC(IntPtr hbitmap, IntPtr hpal)
            {
                PICTDESC pictdesc = new PICTDESC();
                pictdesc.cbSizeOfStruct = 16;
                pictdesc.picType = Ole.PICTYPE_BITMAP;
                pictdesc.union1 = hbitmap;
                pictdesc.union2 = (int)(((long)hpal) & 0xffffffff);
                pictdesc.union3 = (int)(((long)hpal) >> 32);
                return pictdesc;
            }

            public static PICTDESC CreateIconPICTDESC(IntPtr hicon)
            {
                PICTDESC pictdesc = new PICTDESC();
                pictdesc.cbSizeOfStruct = 12;
                pictdesc.picType = Ole.PICTYPE_ICON;
                pictdesc.union1 = hicon;
                return pictdesc;
            }


            public static PICTDESC CreateEnhMetafilePICTDESC(IntPtr hEMF)
            {
                PICTDESC pictdesc = new PICTDESC();
                pictdesc.cbSizeOfStruct = 12;
                pictdesc.picType = Ole.PICTYPE_ENHMETAFILE;
                pictdesc.union1 = hEMF;
                return pictdesc;
            }

            public static PICTDESC CreateWinMetafilePICTDESC(IntPtr hmetafile, int x, int y)
            {
                PICTDESC pictdesc = new PICTDESC();
                pictdesc.cbSizeOfStruct = 20;
                pictdesc.picType = Ole.PICTYPE_METAFILE;
                pictdesc.union1 = hmetafile;
                pictdesc.union2 = x;
                pictdesc.union3 = y;
                return pictdesc;
            }


            public virtual IntPtr GetHandle()
            {
                return union1;
            }

            public virtual IntPtr GetHPal()
            {
                if (picType == Ole.PICTYPE_BITMAP)
                    return (IntPtr)((uint)union2 | (((long)union3) << 32));
                else
                    return IntPtr.Zero;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagFONTDESC
        {
            public int cbSizeofstruct = Marshal.SizeOf(typeof(tagFONTDESC));

            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpstrName;

            [MarshalAs(UnmanagedType.U8)]
            public long cySize;

            [MarshalAs(UnmanagedType.U2)]
            public short sWeight;

            [MarshalAs(UnmanagedType.U2)]
            public short sCharset;

            [MarshalAs(UnmanagedType.Bool)]
            public bool fItalic;

            [MarshalAs(UnmanagedType.Bool)]
            public bool fUnderline;

            [MarshalAs(UnmanagedType.Bool)]
            public bool fStrikethrough;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class CHOOSECOLOR
        {
            public int lStructSize = Marshal.SizeOf(typeof(CHOOSECOLOR)); //ndirect.DllLib.sizeOf(this); 
            public IntPtr hwndOwner;
            public IntPtr hInstance;
            public int rgbResult;
            public IntPtr lpCustColors;
            public int Flags;
            public IntPtr lCustData = IntPtr.Zero;
            public WndProc lpfnHook;
            public string lpTemplateName = null;
        }

        public delegate IntPtr WindowsHookProc(int nCode, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public class BITMAP_CLASS
        {
            public int bmType = 0;
            public int bmWidth = 0;
            public int bmHeight = 0;
            public int bmWidthBytes = 0;
            public short bmPlanes = 0;
            public short bmBitsPixel = 0;
            public IntPtr bmBits = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAP_STRUCT
        {
            public int bmType;
            public int bmWidth;
            public int bmHeight;
            public int bmWidthBytes;
            public short bmPlanes;
            public short bmBitsPixel;
            public IntPtr bmBits;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ICONINFO
        {
            public int fIcon = 0;
            public int xHotspot = 0;
            public int yHotspot = 0;
            public IntPtr hbmMask = IntPtr.Zero;
            public IntPtr hbmColor = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class LOGPEN
        {
            public int lopnStyle = 0;
            // lopnWidth was a by-value POINT structure
            public int lopnWidth_x = 0;
            public int lopnWidth_y = 0;
            public int lopnColor = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class LOGBRUSH
        {
            public int lbStyle;
            public int lbColor;
            public int lbHatch;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LOGFONT
        {
            public LOGFONT()
            {
            }
            public LOGFONT(LOGFONT lf)
            {
                Debug.Assert(lf != null, "lf is null");

                this.lfHeight = lf.lfHeight;
                this.lfWidth = lf.lfWidth;
                this.lfEscapement = lf.lfEscapement;
                this.lfOrientation = lf.lfOrientation;
                this.lfWeight = lf.lfWeight;
                this.lfItalic = lf.lfItalic;
                this.lfUnderline = lf.lfUnderline;
                this.lfStrikeOut = lf.lfStrikeOut;
                this.lfCharSet = lf.lfCharSet;
                this.lfOutPrecision = lf.lfOutPrecision;
                this.lfClipPrecision = lf.lfClipPrecision;
                this.lfQuality = lf.lfQuality;
                this.lfPitchAndFamily = lf.lfPitchAndFamily;
                this.lfFaceName = lf.lfFaceName;
            }
            public int lfHeight;
            public int lfWidth;
            public int lfEscapement;
            public int lfOrientation;
            public int lfWeight;
            public byte lfItalic;
            public byte lfUnderline;
            public byte lfStrikeOut;
            public byte lfCharSet;
            public byte lfOutPrecision;
            public byte lfClipPrecision;
            public byte lfQuality;
            public byte lfPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string lfFaceName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct TEXTMETRIC
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
            public char tmFirstChar;
            public char tmLastChar;
            public char tmDefaultChar;
            public char tmBreakChar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct TEXTMETRICA
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
            public byte tmFirstChar;
            public byte tmLastChar;
            public byte tmDefaultChar;
            public byte tmBreakChar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NOTIFYICONDATA
        {
            public int cbSize = Marshal.SizeOf(typeof(NOTIFYICONDATA));
            public IntPtr hWnd;
            public int uID;
            public int uFlags;
            public int uCallbackMessage;
            public IntPtr hIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szTip;
            public int dwState = 0;
            public int dwStateMask = 0;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
            public string szInfo;
            public int uTimeoutOrVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string szInfoTitle;
            public int dwInfoFlags;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MENUITEMINFO_T
        {
            public int cbSize = Marshal.SizeOf(typeof(MENUITEMINFO_T));
            public int fMask;
            public int fType;
            public int fState;
            public int wID;
            public IntPtr hSubMenu = IntPtr.Zero;
            public IntPtr hbmpChecked = IntPtr.Zero;
            public IntPtr hbmpUnchecked = IntPtr.Zero;
            public IntPtr dwItemData = IntPtr.Zero;
            public string dwTypeData;
            public int cch;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct MENUITEMINFO
        {
            public int cbSize;
            public int fMask;
            public int fType;
            public int fState;
            public int wID;
            public IntPtr hSubMenu;
            public IntPtr hbmpChecked;
            public IntPtr hbmpUnchecked;
            public int dwItemData;
            public IntPtr dwTypeData;
            public int cch;
            public IntPtr hbmpItem;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MENUITEMINFO_T_RW
        {
            public int cbSize = Marshal.SizeOf(typeof(MENUITEMINFO_T_RW));
            public int fMask = 0;
            public int fType = 0;
            public int fState = 0;
            public int wID = 0;
            public IntPtr hSubMenu = IntPtr.Zero;
            public IntPtr hbmpChecked = IntPtr.Zero;
            public IntPtr hbmpUnchecked = IntPtr.Zero;
            public IntPtr dwItemData = IntPtr.Zero;
            public IntPtr dwTypeData = IntPtr.Zero;
            public int cch = 0;
            public IntPtr hbmpItem = IntPtr.Zero;
        }



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MSAAMENUINFO
        {
            public int dwMSAASignature;
            public int cchWText;
            public string pszWText;

            public MSAAMENUINFO(string text)
            {
                dwMSAASignature = unchecked((int)MSAA_MENU_SIG);
                cchWText = text.Length;
                pszWText = text;
            }
        }

        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class OPENFILENAME_I
        {
            public int lStructSize = Marshal.SizeOf(typeof(OPENFILENAME_I));
            public IntPtr hwndOwner;
            public IntPtr hInstance;
            public string lpstrFilter;
            public IntPtr lpstrCustomFilter = IntPtr.Zero;
            public int nMaxCustFilter = 0;
            public int nFilterIndex;
            public IntPtr lpstrFile;
            public int nMaxFile = NativeMethods.MAX_PATH;
            public IntPtr lpstrFileTitle = IntPtr.Zero;
            public int nMaxFileTitle = NativeMethods.MAX_PATH;
            public string lpstrInitialDir;
            public string lpstrTitle;
            public int Flags;
            public short nFileOffset = 0;
            public short nFileExtension = 0;
            public string lpstrDefExt;
            public IntPtr lCustData = IntPtr.Zero;
            public WndProc lpfnHook;
            public string lpTemplateName = null;
            public IntPtr pvReserved = IntPtr.Zero;
            public int dwReserved = 0;
            public int FlagsEx;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class CHOOSEFONT
        {
            public int lStructSize = Marshal.SizeOf(typeof(CHOOSEFONT));
            public IntPtr hwndOwner;
            public IntPtr hDC;
            public IntPtr lpLogFont;
            public int iPointSize = 0;
            public int Flags;
            public int rgbColors;
            public IntPtr lCustData = IntPtr.Zero;
            public WndProc lpfnHook;
            public string lpTemplateName = null;
            public IntPtr hInstance;
            public string lpszStyle = null;
            public short nFontType = 0;
            public short ___MISSING_ALIGNMENT__ = 0;
            public int nSizeMin;
            public int nSizeMax;
        }


        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFO
        {
            // bmiHeader was a by-value BITMAPINFOHEADER structure 
            public int bmiHeader_biSize = 40;  // ndirect.DllLib.sizeOf( BITMAPINFOHEADER.class ); 
            public int bmiHeader_biWidth = 0;
            public int bmiHeader_biHeight = 0;
            public short bmiHeader_biPlanes = 0;
            public short bmiHeader_biBitCount = 0;
            public int bmiHeader_biCompression = 0;
            public int bmiHeader_biSizeImage = 0;
            public int bmiHeader_biXPelsPerMeter = 0;
            public int bmiHeader_biYPelsPerMeter = 0;
            public int bmiHeader_biClrUsed = 0;
            public int bmiHeader_biClrImportant = 0;

            // bmiColors was an embedded array of RGBQUAD structures
            public byte bmiColors_rgbBlue = 0;
            public byte bmiColors_rgbGreen = 0;
            public byte bmiColors_rgbRed = 0;
            public byte bmiColors_rgbReserved = 0;

            public BITMAPINFO()
            {
                //Added to make FxCop happy: doesn't really matter since it's internal... 
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class BITMAPINFOHEADER
        {
            public int biSize = 40;    // ndirect.DllLib.sizeOf( this ); 
            public int biWidth;
            public int biHeight;
            public short biPlanes;
            public short biBitCount;
            public int biCompression;
            public int biSizeImage = 0;
            public int biXPelsPerMeter = 0;
            public int biYPelsPerMeter = 0;
            public int biClrUsed = 0;
            public int biClrImportant = 0;
        }

        public class Ole
        {
            public const int PICTYPE_UNINITIALIZED = -1;
            public const int PICTYPE_NONE = 0;
            public const int PICTYPE_BITMAP = 1;
            public const int PICTYPE_METAFILE = 2;
            public const int PICTYPE_ICON = 3;
            public const int PICTYPE_ENHMETAFILE = 4;
            public const int STATFLAG_DEFAULT = 0;
            public const int STATFLAG_NONAME = 1;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class STATSTG
        {

            [MarshalAs(UnmanagedType.LPWStr)]
            public string pwcsName = null;

            public int type;
            [MarshalAs(UnmanagedType.I8)]
            public long cbSize;
            [MarshalAs(UnmanagedType.I8)]
            public long mtime = 0;
            [MarshalAs(UnmanagedType.I8)]
            public long ctime = 0;
            [MarshalAs(UnmanagedType.I8)]
            public long atime = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int grfMode = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int grfLocksSupported;

            public int clsid_data1 = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short clsid_data2 = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short clsid_data3 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public byte clsid_b0 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public byte clsid_b1 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public byte clsid_b2 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public byte clsid_b3 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public byte clsid_b4 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public byte clsid_b5 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public byte clsid_b6 = 0;
            [MarshalAs(UnmanagedType.U1)]
            public byte clsid_b7 = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int grfStateBits = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int reserved = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class FILETIME
        {
            public int dwLowDateTime = 0;
            public int dwHighDateTime = 0;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct NMREBAR
        {
            public NMHDR hdr;
            public uint dwMask;
            public uint uBand;
            public uint fStyle;
            public uint wID;
            public int lParam;
        }


        [StructLayout(LayoutKind.Sequential)]
        public class SYSTEMTIME
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;

            public override string ToString()
            {
                return "[SYSTEMTIME: "
                + wDay.ToString(CultureInfo.InvariantCulture) + "/" + wMonth.ToString(CultureInfo.InvariantCulture) + "/" + wYear.ToString(CultureInfo.InvariantCulture)
                + " " + wHour.ToString(CultureInfo.InvariantCulture) + ":" + wMinute.ToString(CultureInfo.InvariantCulture) + ":" + wSecond.ToString(CultureInfo.InvariantCulture)
                + "]";
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class _POINTL
        {
            public int x;
            public int y;

        }


        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagSIZE
        {
            public int cx = 0;
            public int cy = 0;

        }

        [StructLayout(LayoutKind.Sequential)]
        public class COMRECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public COMRECT()
            {
            }

            public COMRECT(System.Drawing.Rectangle r)
            {
                this.left = r.X;
                this.top = r.Y;
                this.right = r.Right;
                this.bottom = r.Bottom;
            }


            public COMRECT(int left, int top, int right, int bottom)
            {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }

            public RECT ToRECT()
            {
                return new RECT(left, top, right, bottom);
            }

            public static COMRECT FromXYWH(int x, int y, int width, int height)
            {
                return new COMRECT(x, y, x + width, y + height);
            }

            public override string ToString()
            {
                return "Left = " + left + " Top " + top + " Right = " + right + " Bottom = " + bottom;
            }
        }


        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagOleMenuGroupWidths
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)/*leftover(offset=0, widths)*/]
            public int[] widths = new int[6];
        }

        [StructLayout(LayoutKind.Sequential)]
        [Serializable]
        public class MSOCRINFOSTRUCT
        {
            public int cbSize = Marshal.SizeOf(typeof(MSOCRINFOSTRUCT));              // size of MSOCRINFO structure in bytes.
            public int uIdleTimeInterval;   // If olecrfNeedPeriodicIdleTime is registered
            // in grfcrf, component needs to perform 
            // periodic idle time tasks during an idle phase
            // every uIdleTimeInterval milliseconds. 
            public int grfcrf;              // bit flags taken from olecrf values (above) 
            public int grfcadvf;            // bit flags taken from olecadvf values (above)
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMLISTVIEW
        {
            public NMHDR hdr;
            public int iItem;
            public int iSubItem;
            public int uNewState;
            public int uOldState;
            public int uChanged;
            public IntPtr lParam;
        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagPOINTF
        {
            [MarshalAs(UnmanagedType.R4)/*leftover(offset=0, x)*/]
            public float x;

            [MarshalAs(UnmanagedType.R4)/*leftover(offset=4, y)*/]
            public float y;

        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagOIFI
        {
            [MarshalAs(UnmanagedType.U4)/*leftover(offset=0, cb)*/]
            public int cb;

            public bool fMDIApp;
            public IntPtr hwndFrame;
            public IntPtr hAccel;

            [MarshalAs(UnmanagedType.U4)/*leftover(offset=16, cAccelEntries)*/]
            public int cAccelEntries;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMLVFINDITEM
        {
            public NMHDR hdr;
            public int iStart;
            public LVFINDINFO lvfi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR
        {
            public IntPtr hwndFrom;
            public IntPtr idFrom; //This is declared as UINT_PTR in winuser.h 
            public int code;
        }

        [ComVisible(true), Guid("626FC520-A41E-11CF-A731-00A0C9082637"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsDual)]
        internal interface IHTMLDocument
        {

            [return: MarshalAs(UnmanagedType.Interface)]
            object GetScript();

        }

        [ComImport(), Guid("376BD3AA-3845-101B-84ED-08002B2EC713"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IPerPropertyBrowsing
        {
            [PreserveSig]
            int GetDisplayString(
               int dispID,
               [Out, MarshalAs(UnmanagedType.LPArray)] 
                string[] pBstr);

            [PreserveSig]
            int MapPropertyToPage(
               int dispID,
               [Out]
                out Guid pGuid);

            [PreserveSig]
            int GetPredefinedStrings(
               int dispID,
               [Out] 
                CA_STRUCT pCaStringsOut,
               [Out]
                CA_STRUCT pCaCookiesOut);

            [PreserveSig]
            int GetPredefinedValue(
               int dispID,
               [In, MarshalAs(UnmanagedType.U4)]
                int dwCookie,
               [Out]
                VARIANT pVarOut);
        }

        [ComImport(), Guid("4D07FC10-F931-11CE-B001-00AA006884E5"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICategorizeProperties
        {

            [PreserveSig]
            int MapPropertyToCategory(
               int dispID,
               ref int categoryID);

            [PreserveSig]
            int GetCategoryName(
               int propcat,
               [In, MarshalAs(UnmanagedType.U4)] 
                int lcid,
               out string categoryName);
        }



        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagSIZEL
        {
            public int cx;
            public int cy;
        }


        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagOLEVERB
        {
            public int lVerb;

            [MarshalAs(UnmanagedType.LPWStr)/*leftover(offset=4, customMarshal="UniStringMarshaller", lpszVerbName)*/]
            public string lpszVerbName;

            [MarshalAs(UnmanagedType.U4)/*leftover(offset=8, fuFlags)*/]
            public int fuFlags;

            [MarshalAs(UnmanagedType.U4)/*leftover(offset=12, grfAttribs)*/]
            public int grfAttribs;
        }



        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagLOGPALETTE
        {
            [MarshalAs(UnmanagedType.U2)/*leftover(offset=0, palVersion)*/]
            public short palVersion = 0;

            [MarshalAs(UnmanagedType.U2)/*leftover(offset=2, palNumEntries)*/]
            public short palNumEntries = 0;
        }


        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagCONTROLINFO
        {
            [MarshalAs(UnmanagedType.U4)/*leftover(offset=0, cb)*/]
            public int cb = Marshal.SizeOf(typeof(tagCONTROLINFO));

            public IntPtr hAccel;

            [MarshalAs(UnmanagedType.U2)/*leftover(offset=8, cAccel)*/]
            public short cAccel;

            [MarshalAs(UnmanagedType.U4)/*leftover(offset=10, dwFlags)*/]
            public int dwFlags;
        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class CA_STRUCT
        {
            public int cElems = 0;
            public IntPtr pElems = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class VARIANT
        {
            [MarshalAs(UnmanagedType.I2)]
            public short vt;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved1 = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved2 = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short reserved3 = 0;

            public IntPtr data1;

            public IntPtr data2;


            public bool Byref
            {
                get
                {
                    return 0 != (vt & (int)tagVT.VT_BYREF);
                }
            }

            public void Clear()
            {
                if ((this.vt == (int)tagVT.VT_UNKNOWN || this.vt == (int)tagVT.VT_DISPATCH) && this.data1 != IntPtr.Zero)
                {
                    Marshal.Release(this.data1);
                }

                if (this.vt == (int)tagVT.VT_BSTR && this.data1 != IntPtr.Zero)
                {
                    SysFreeString(this.data1);
                }

                this.data1 = this.data2 = IntPtr.Zero;
                this.vt = (int)tagVT.VT_EMPTY;
            }

            ~VARIANT()
            {
                Clear();
            }

            public static VARIANT FromObject(Object var)
            {
                VARIANT v = new VARIANT();

                if (var == null)
                {
                    v.vt = (int)tagVT.VT_EMPTY;
                }
                else if (Convert.IsDBNull(var))
                {
                }
                else
                {
                    Type t = var.GetType();

                    if (t == typeof(bool))
                    {
                        v.vt = (int)tagVT.VT_BOOL;
                    }
                    else if (t == typeof(byte))
                    {
                        v.vt = (int)tagVT.VT_UI1;
                        v.data1 = (IntPtr)Convert.ToByte(var, CultureInfo.InvariantCulture);
                    }
                    else if (t == typeof(char))
                    {
                        v.vt = (int)tagVT.VT_UI2;
                        v.data1 = (IntPtr)Convert.ToChar(var, CultureInfo.InvariantCulture);
                    }
                    else if (t == typeof(string))
                    {
                        v.vt = (int)tagVT.VT_BSTR;
                        v.data1 = SysAllocString(Convert.ToString(var, CultureInfo.InvariantCulture));
                    }
                    else if (t == typeof(short))
                    {
                        v.vt = (int)tagVT.VT_I2;
                        v.data1 = (IntPtr)Convert.ToInt16(var, CultureInfo.InvariantCulture);
                    }
                    else if (t == typeof(int))
                    {
                        v.vt = (int)tagVT.VT_I4;
                        v.data1 = (IntPtr)Convert.ToInt32(var, CultureInfo.InvariantCulture);
                    }
                    else if (t == typeof(long))
                    {
                        v.vt = (int)tagVT.VT_I8;
                        v.SetLong(Convert.ToInt64(var, CultureInfo.InvariantCulture));
                    }
                    else if (t == typeof(Decimal))
                    {
                        v.vt = (int)tagVT.VT_CY;
                        Decimal c = (Decimal)var;
                        // [....], it's bizzare that we need to call this as a static!
                        v.SetLong(Decimal.ToInt64(c));
                    }
                    else if (t == typeof(decimal))
                    {
                        v.vt = (int)tagVT.VT_DECIMAL;
                        Decimal d = Convert.ToDecimal(var, CultureInfo.InvariantCulture);
                        v.SetLong(Decimal.ToInt64(d));
                    }
                    else if (t == typeof(double))
                    {
                        v.vt = (int)tagVT.VT_R8;
                        // how do we handle double? 
                    }
                    else if (t == typeof(float) || t == typeof(Single))
                    {
                        v.vt = (int)tagVT.VT_R4;
                        // how do we handle float? 
                    }
                    else if (t == typeof(DateTime))
                    {
                        v.vt = (int)tagVT.VT_DATE;
                        v.SetLong(Convert.ToDateTime(var, CultureInfo.InvariantCulture).ToFileTime());
                    }
                    else if (t == typeof(SByte))
                    {
                        v.vt = (int)tagVT.VT_I1;
                        v.data1 = (IntPtr)Convert.ToSByte(var, CultureInfo.InvariantCulture);
                    }
                    else if (t == typeof(UInt16))
                    {
                        v.vt = (int)tagVT.VT_UI2;
                        v.data1 = (IntPtr)Convert.ToUInt16(var, CultureInfo.InvariantCulture);
                    }
                    else if (t == typeof(UInt32))
                    {
                        v.vt = (int)tagVT.VT_UI4;
                        v.data1 = (IntPtr)Convert.ToUInt32(var, CultureInfo.InvariantCulture);
                    }
                    else if (t == typeof(UInt64))
                    {
                        v.vt = (int)tagVT.VT_UI8;
                        v.SetLong((long)Convert.ToUInt64(var, CultureInfo.InvariantCulture));
                    }
                    else if (t == typeof(object) || t == typeof(NativeCOM.IDispatch) || t.IsCOMObject)
                    {
                        v.vt = (t == typeof(NativeCOM.IDispatch) ? (short)tagVT.VT_DISPATCH : (short)tagVT.VT_UNKNOWN);
                        v.data1 = Marshal.GetIUnknownForObject(var);
                    }
                    else
                    {
                        throw new ArgumentException("ConnPointUnhandledType");
                    }
                }
                return v;
            }

            [DllImport(ExternDll.Oleaut32, CharSet = CharSet.Auto)]
            private static extern IntPtr SysAllocString([In, MarshalAs(UnmanagedType.LPWStr)]string s);

            [DllImport(ExternDll.Oleaut32, CharSet = CharSet.Auto)]
            private static extern void SysFreeString(IntPtr pbstr);

            public void SetLong(long lVal)
            {
                data1 = (IntPtr)(lVal & 0xFFFFFFFF);
                data2 = (IntPtr)((lVal >> 32) & 0xFFFFFFFF);
            }

            public IntPtr ToCoTaskMemPtr()
            {
                IntPtr mem = Marshal.AllocCoTaskMem(16);
                Marshal.WriteInt16(mem, vt);
                Marshal.WriteInt16(mem, 2, reserved1);
                Marshal.WriteInt16(mem, 4, reserved2);
                Marshal.WriteInt16(mem, 6, reserved3);
                Marshal.WriteInt32(mem, 8, (int)data1);
                Marshal.WriteInt32(mem, 12, (int)data2);
                return mem;
            }

            public object ToObject()
            {
                IntPtr val = data1;
                long longVal;

                int vtType = (int)(this.vt & (short)tagVT.VT_TYPEMASK);

                switch (vtType)
                {
                    case (int)tagVT.VT_EMPTY:
                        return null;
                    case (int)tagVT.VT_NULL:
                        return Convert.DBNull;

                    case (int)tagVT.VT_I1:
                        if (Byref)
                        {
                            val = (IntPtr)Marshal.ReadByte(val);
                        }
                        return (SByte)(0xFF & (SByte)val);

                    case (int)tagVT.VT_UI1:
                        if (Byref)
                        {
                            val = (IntPtr)Marshal.ReadByte(val);
                        }

                        return (byte)(0xFF & (byte)val);

                    case (int)tagVT.VT_I2:
                        if (Byref)
                        {
                            val = (IntPtr)Marshal.ReadInt16(val);
                        }
                        return (short)(0xFFFF & (short)val);

                    case (int)tagVT.VT_UI2:
                        if (Byref)
                        {
                            val = (IntPtr)Marshal.ReadInt16(val);
                        }
                        return (UInt16)(0xFFFF & (UInt16)val);

                    case (int)tagVT.VT_I4:
                    case (int)tagVT.VT_INT:
                        if (Byref)
                        {
                            val = (IntPtr)Marshal.ReadInt32(val);
                        }
                        return (int)val;

                    case (int)tagVT.VT_UI4:
                    case (int)tagVT.VT_UINT:
                        if (Byref)
                        {
                            val = (IntPtr)Marshal.ReadInt32(val);
                        }
                        return (UInt32)val;

                    case (int)tagVT.VT_I8:
                    case (int)tagVT.VT_UI8:
                        if (Byref)
                        {
                            longVal = Marshal.ReadInt64(val);
                        }
                        else
                        {
                            longVal = ((uint)data1 & 0xffffffff) | ((uint)data2 << 32);
                        }

                        if (vt == (int)tagVT.VT_I8)
                        {
                            return (long)longVal;
                        }
                        else
                        {
                            return (UInt64)longVal;
                        }
                }

                if (Byref)
                {
                    val = GetRefInt(val);
                }

                switch (vtType)
                {
                    case (int)tagVT.VT_R4:
                    case (int)tagVT.VT_R8:
                        throw new FormatException("CannotConvertIntToFloat");
                    case (int)tagVT.VT_CY:
                        longVal = ((uint)data1 & 0xffffffff) | ((uint)data2 << 32);
                        return new Decimal(longVal);
                    case (int)tagVT.VT_DATE:
                        throw new FormatException("CannotConvertDoubleToDate");
                    case (int)tagVT.VT_BSTR:
                    case (int)tagVT.VT_LPWSTR:
                        return Marshal.PtrToStringUni(val);
                    case (int)tagVT.VT_LPSTR:
                        return Marshal.PtrToStringAnsi(val);
                    case (int)tagVT.VT_DISPATCH:
                    case (int)tagVT.VT_UNKNOWN:
                        {
                            return Marshal.GetObjectForIUnknown(val);
                        }
                    case (int)tagVT.VT_HRESULT:
                        return val;
                    case (int)tagVT.VT_DECIMAL:
                        longVal = ((uint)data1 & 0xffffffff) | ((uint)data2 << 32);
                        return new Decimal(longVal);
                    case (int)tagVT.VT_BOOL:
                        return (val != IntPtr.Zero);
                    case (int)tagVT.VT_VARIANT:
                        VARIANT varStruct = (VARIANT)NativeCOM.PtrToStructure(val, typeof(VARIANT));
                        return varStruct.ToObject();
                    case (int)tagVT.VT_CLSID:
                        Guid guid = (Guid)NativeCOM.PtrToStructure(val, typeof(Guid));
                        return guid;
                    case (int)tagVT.VT_FILETIME:
                        longVal = ((uint)data1 & 0xffffffff) | ((uint)data2 << 32);
                        return new DateTime(longVal);
                    case (int)tagVT.VT_USERDEFINED:
                        throw new ArgumentException("COM2UnhandledVT");
                    case (int)tagVT.VT_ARRAY:
                    case (int)tagVT.VT_VOID:
                    case (int)tagVT.VT_PTR:
                    case (int)tagVT.VT_SAFEARRAY:
                    case (int)tagVT.VT_CARRAY:
                    case (int)tagVT.VT_RECORD:
                    case (int)tagVT.VT_BLOB:
                    case (int)tagVT.VT_STREAM:
                    case (int)tagVT.VT_STORAGE:
                    case (int)tagVT.VT_STREAMED_OBJECT:
                    case (int)tagVT.VT_STORED_OBJECT:
                    case (int)tagVT.VT_BLOB_OBJECT:
                    case (int)tagVT.VT_CF:
                    case (int)tagVT.VT_BSTR_BLOB:
                    case (int)tagVT.VT_VECTOR:
                    case (int)tagVT.VT_BYREF:
                    case (int)tagVT.VT_RESERVED:
                    default:
                        int iVt = this.vt;
                        throw new ArgumentException("COM2UnhandledVT");
                }
            }

            private static IntPtr GetRefInt(IntPtr value)
            {
                return Marshal.ReadIntPtr(value);
            }
        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagLICINFO
        {
            [MarshalAs(UnmanagedType.U4)/*leftover(offset=0, cb)*/]
            public int cbLicInfo = Marshal.SizeOf(typeof(tagLICINFO));

            public int fRuntimeAvailable = 0;
            public int fLicVerified = 0;
        }

        public enum tagVT
        {
            VT_EMPTY = 0,
            VT_NULL = 1,
            VT_I2 = 2,
            VT_I4 = 3,
            VT_R4 = 4,
            VT_R8 = 5,
            VT_CY = 6,
            VT_DATE = 7,
            VT_BSTR = 8,
            VT_DISPATCH = 9,
            VT_ERROR = 10,
            VT_BOOL = 11,
            VT_VARIANT = 12,
            VT_UNKNOWN = 13,
            VT_DECIMAL = 14,
            VT_I1 = 16,
            VT_UI1 = 17,
            VT_UI2 = 18,
            VT_UI4 = 19,
            VT_I8 = 20,
            VT_UI8 = 21,
            VT_INT = 22,
            VT_UINT = 23,
            VT_VOID = 24,
            VT_HRESULT = 25,
            VT_PTR = 26,
            VT_SAFEARRAY = 27,
            VT_CARRAY = 28,
            VT_USERDEFINED = 29,
            VT_LPSTR = 30,
            VT_LPWSTR = 31,
            VT_RECORD = 36,
            VT_FILETIME = 64,
            VT_BLOB = 65,
            VT_STREAM = 66,
            VT_STORAGE = 67,
            VT_STREAMED_OBJECT = 68,
            VT_STORED_OBJECT = 69,
            VT_BLOB_OBJECT = 70,
            VT_CF = 71,
            VT_CLSID = 72,
            VT_BSTR_BLOB = 4095,
            VT_VECTOR = 4096,
            VT_ARRAY = 8192,
            VT_BYREF = 16384,
            VT_RESERVED = 32768,
            VT_ILLEGAL = 65535,
            VT_ILLEGALMASKED = 4095,
            VT_TYPEMASK = 4095
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class WNDCLASS_D
        {
            public int style;
            public WndProc lpfnWndProc;
            public int cbClsExtra = 0;
            public int cbWndExtra = 0;
            public IntPtr hInstance = IntPtr.Zero;
            public IntPtr hIcon = IntPtr.Zero;
            public IntPtr hCursor = IntPtr.Zero;
            public IntPtr hbrBackground = IntPtr.Zero;
            public string lpszMenuName = null;
            public string lpszClassName = null;
        }

        public class MSOCM
        {
            // MSO Component registration flags
            public const int msocrfNeedIdleTime = 1;
            public const int msocrfNeedPeriodicIdleTime = 2;
            public const int msocrfPreTranslateKeys = 4;
            public const int msocrfPreTranslateAll = 8;
            public const int msocrfNeedSpecActiveNotifs = 16;
            public const int msocrfNeedAllActiveNotifs = 32;
            public const int msocrfExclusiveBorderSpace = 64;
            public const int msocrfExclusiveActivation = 128;
            public const int msocrfNeedAllMacEvents = 256;
            public const int msocrfMaster = 512;
            public const int msocadvfModal = 1;
            public const int msocadvfRedrawOff = 2;
            public const int msocadvfWarningsOff = 4;
            public const int msocadvfRecording = 8;
            public const int msochostfExclusiveBorderSpace = 1;
            public const int msoidlefPeriodic = 1;
            public const int msoidlefNonPeriodic = 2;
            public const int msoidlefPriority = 4;
            public const int msoidlefAll = -1;
            public const int msoloopDoEventsModal = -2;
            public const int msoloopMain = -1;
            public const int msoloopFocusWait = 1;
            public const int msoloopDoEvents = 2;
            public const int msoloopDebug = 3;
            public const int msoloopModalForm = 4;
            public const int msoloopModalAlert = 5;



            public const int msocstateModal = 1;
            public const int msocstateRedrawOff = 2;
            public const int msocstateWarningsOff = 3;
            public const int msocstateRecording = 4;



            public const int msoccontextAll = 0;
            public const int msoccontextMine = 1;
            public const int msoccontextOthers = 2;


            public const int msogacActive = 0;
            public const int msogacTracking = 1;
            public const int msogacTrackingOrActive = 2;


            public const int msocWindowFrameToplevel = 0;
            public const int msocWindowFrameOwner = 1;
            public const int msocWindowComponent = 2;
            public const int msocWindowDlgOwner = 3;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class TOOLINFO_T
        {
            public int cbSize = Marshal.SizeOf(typeof(TOOLINFO_T));
            public int uFlags;
            public IntPtr hwnd;
            public IntPtr uId;
            public RECT rect;
            public IntPtr hinst = IntPtr.Zero;
            public string lpszText;
            public IntPtr lParam = IntPtr.Zero;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class TOOLINFO_TOOLTIP
        {
            public int cbSize = Marshal.SizeOf(typeof(TOOLINFO_TOOLTIP));
            public int uFlags;
            public IntPtr hwnd;
            public IntPtr uId;
            public RECT rect;
            public IntPtr hinst = IntPtr.Zero;
            public IntPtr lpszText;
            public IntPtr lParam = IntPtr.Zero;
        }


        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagDVTARGETDEVICE
        {
            [MarshalAs(UnmanagedType.U4)]
            public int tdSize = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short tdDriverNameOffset = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short tdDeviceNameOffset = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short tdPortNameOffset = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short tdExtDevmodeOffset = 0;
        }



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TV_ITEM
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            public IntPtr /* LPTSTR */ pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TVSORTCB
        {
            public IntPtr hParent;
            public NativeMethods.TreeViewCompareCallback lpfnCompare;
            public IntPtr lParam;
        }



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TV_INSERTSTRUCT
        {
            public IntPtr hParent;
            public IntPtr hInsertAfter;
            public int item_mask;
            public IntPtr item_hItem;
            public int item_state;
            public int item_stateMask;
            public IntPtr item_pszText;
            public int item_cchTextMax;
            public int item_iImage;
            public int item_iSelectedImage;
            public int item_cChildren;
            public IntPtr item_lParam;
            public int item_iIntegral;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TVINSERTSTRUCT
        {
            public IntPtr hParent;
            public IntPtr hInsertAfter;
            public TVITEMEX item;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TVITEMEX
        {
            public int mask;
            public IntPtr hItem;
            public int state;
            public int stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int cChildren;
            public IntPtr lParam;
            public int iIntegral;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMTREEVIEW
        {
            public NMHDR nmhdr;
            public int action;
            public TV_ITEM itemOld;
            public TV_ITEM itemNew;
            public int ptDrag_X;
            public int ptDrag_Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMTVGETINFOTIP
        {
            public NMHDR nmhdr;
            public string pszText;
            public int cchTextMax;
            public IntPtr item;
            public IntPtr lParam;

        }

        [StructLayout(LayoutKind.Sequential)]
        public class NMTVDISPINFO
        {
            public NMHDR hdr;
            public TV_ITEM item;
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class POINTL
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct HIGHCONTRAST
        {
            public int cbSize;
            public int dwFlags;
            public string lpszDefaultScheme;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct HIGHCONTRAST_I
        {
            public int cbSize;
            public int dwFlags;
            public IntPtr lpszDefaultScheme;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TCITEM
        {
            public int mask;
            public int dwState;
            public int dwStateMask;
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class TCITEM_T
        {
            public int mask;
            public int dwState = 0;
            public int dwStateMask = 0;
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagDISPPARAMS
        {
            public IntPtr rgvarg;
            public IntPtr rgdispidNamedArgs;
            [MarshalAs(UnmanagedType.U4)/*leftover(offset=8, cArgs)*/]
            public int cArgs;
            [MarshalAs(UnmanagedType.U4)/*leftover(offset=12, cNamedArgs)*/]
            public int cNamedArgs;
        }

        public enum tagINVOKEKIND
        {
            INVOKE_FUNC = 1,
            INVOKE_PROPERTYGET = 2,
            INVOKE_PROPERTYPUT = 4,
            INVOKE_PROPERTYPUTREF = 8
        }

        [StructLayout(LayoutKind.Sequential)]
        public class tagEXCEPINFO
        {
            [MarshalAs(UnmanagedType.U2)]
            public short wCode = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short wReserved = 0;
            [MarshalAs(UnmanagedType.BStr)]
            public string bstrSource = null;
            [MarshalAs(UnmanagedType.BStr)]
            public string bstrDescription = null;
            [MarshalAs(UnmanagedType.BStr)]
            public string bstrHelpFile = null;
            [MarshalAs(UnmanagedType.U4)]
            public int dwHelpContext = 0;

            public IntPtr pvReserved = IntPtr.Zero;

            public IntPtr pfnDeferredFillIn = IntPtr.Zero;
            [MarshalAs(UnmanagedType.U4)]
            public int scode = 0;
        }

        public enum tagDESCKIND
        {
            DESCKIND_NONE = 0,
            DESCKIND_FUNCDESC = 1,
            DESCKIND_VARDESC = 2,
            DESCKIND_TYPECOMP = 3,
            DESCKIND_IMPLICITAPPOBJ = 4,
            DESCKIND_MAX = 5
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagFUNCDESC
        {
            public int memid = 0;

            public IntPtr lprgscode = IntPtr.Zero;



            public    /*NativeMethods.tagELEMDESC*/ IntPtr lprgelemdescParam = IntPtr.Zero;

            // cpb, [....], the EE chokes on Enums in structs

            public    /*NativeMethods.tagFUNCKIND*/ int funckind = 0;

            public    /*NativeMethods.tagINVOKEKIND*/ int invkind = 0;

            public    /*NativeMethods.tagCALLCONV*/ int callconv = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short cParams = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short cParamsOpt = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short oVft = 0;
            [MarshalAs(UnmanagedType.I2)]
            public short cScodesi = 0;
            public NativeMethods.value_tagELEMDESC elemdescFunc;
            [MarshalAs(UnmanagedType.U2)]
            public short wFuncFlags = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagVARDESC
        {
            public int memid = 0;
            public IntPtr lpstrSchema = IntPtr.Zero;
            public IntPtr unionMember = IntPtr.Zero;
            public NativeMethods.value_tagELEMDESC elemdescVar;
            [MarshalAs(UnmanagedType.U2)]
            public short wVarFlags = 0;
            public    /*NativeMethods.tagVARKIND*/ int varkind = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct value_tagELEMDESC
        {
            public NativeMethods.tagTYPEDESC tdesc;
            public NativeMethods.tagPARAMDESC paramdesc;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPOS
        {
            public IntPtr hwnd;
            public IntPtr hwndInsertAfter;
            public int x;
            public int y;
            public int cx;
            public int cy;
            public int flags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public unsafe struct HDLAYOUT
        {
            public IntPtr prc;        // pointer to a RECT
            public IntPtr pwpos;      // pointer to a WINDOWPOS 
        }

        [StructLayout(LayoutKind.Sequential)]
        public class DRAWITEMSTRUCT
        {
            public int CtlType = 0;
            public int CtlID = 0;
            public int itemID = 0;
            public int itemAction = 0;
            public int itemState = 0;
            public IntPtr hwndItem = IntPtr.Zero;
            public IntPtr hDC = IntPtr.Zero;
            public RECT rcItem;
            public IntPtr itemData = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MEASUREITEMSTRUCT
        {
            public int CtlType = 0;
            public int CtlID = 0;
            public int itemID = 0;
            public int itemWidth = 0;
            public int itemHeight = 0;
            public IntPtr itemData = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class HELPINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(HELPINFO));
            public int iContextType = 0;
            public int iCtrlId = 0;
            public IntPtr hItemHandle = IntPtr.Zero;
            public int dwContextId = 0;
            public POINT MousePos = null;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ACCEL
        {
            public byte fVirt;
            public short key;
            public short cmd;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MINMAXINFO
        {
            public POINT ptReserved = null;
            public POINT ptMaxSize = null;
            public POINT ptMaxPosition = null;
            public POINT ptMinTrackSize = null;
            public POINT ptMaxTrackSize = null;
        }



        [ComImport(), Guid("B196B28B-BAB4-101A-B69C-00AA00341D07"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ISpecifyPropertyPages
        {
            void GetPages(
               [Out]
                NativeMethods.tagCAUUID pPages);

        }

        [StructLayout(LayoutKind.Sequential)/*leftover(noAutoOffset)*/]
        public sealed class tagCAUUID
        {
            [MarshalAs(UnmanagedType.U4)/*leftover(offset=0, cElems)*/]
            public int cElems = 0;
            public IntPtr pElems = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMTOOLBAR
        {
            public NMHDR hdr;
            public int iItem;
            public TBBUTTON tbButton;
            public int cchText;
            public IntPtr pszText;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TBBUTTON
        {
            public int iBitmap;
            public int idCommand;
            public byte fsState;
            public byte fsStyle;
            public byte bReserved0;
            public byte bReserved1;
            public IntPtr dwData;
            public IntPtr iString;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class TOOLTIPTEXT
        {
            public NMHDR hdr;
            public string lpszText;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szText = null;

            public IntPtr hinst;
            public int uFlags;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class TOOLTIPTEXTA
        {
            public NMHDR hdr;
            public string lpszText;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szText = null;

            public IntPtr hinst;
            public int uFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMTBHOTITEM
        {
            public NMHDR hdr;
            public int idOld;
            public int idNew;
            public int dwFlags;
        }

        public const int HICF_OTHER = 0x00000000;
        public const int HICF_MOUSE = 0x00000001;          // Triggered by mouse
        public const int HICF_ARROWKEYS = 0x00000002;          // Triggered by arrow keys
        public const int HICF_ACCELERATOR = 0x00000004;          // Triggered by accelerator 
        public const int HICF_DUPACCEL = 0x00000008;          // This accelerator is not unique
        public const int HICF_ENTERING = 0x00000010;          // idOld is invalid 
        public const int HICF_LEAVING = 0x00000020;          // idNew is invalid 
        public const int HICF_RESELECT = 0x00000040;          // hot item reselected
        public const int HICF_LMOUSE = 0x00000080;          // left mouse button selected 
        public const int HICF_TOGGLEDROPDOWN = 0x00000100;          // Toggle button's dropdown state


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class HDITEM
        {
            public int mask = 0;
            public int cxy = 0;
            public string pszText = null;
            public IntPtr hbm = IntPtr.Zero;
            public int cchTextMax = 0;
            public int fmt = 0;
            public IntPtr lParam = IntPtr.Zero;
            public int iImage = 0;
            public int iOrder = 0;
            public int type = 0;
            public IntPtr pvFilter = IntPtr.Zero;
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class HDITEM2
        {
            public int mask = 0;
            public int cxy = 0;
            public IntPtr pszText_notUsed = IntPtr.Zero;
            public IntPtr hbm = IntPtr.Zero;
            public int cchTextMax = 0;
            public int fmt = 0;
            public IntPtr lParam = IntPtr.Zero;
            public int iImage = 0;
            public int iOrder = 0;
            public int type = 0;
            public IntPtr pvFilter = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct TBBUTTONINFO
        {
            public int cbSize;
            public int dwMask;
            public int idCommand;
            public int iImage;
            public byte fsState;
            public byte fsStyle;
            public short cx;
            public IntPtr lParam;
            public IntPtr pszText;
            public int cchTest;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class TV_HITTESTINFO
        {
            public int pt_x;
            public int pt_y;
            public int flags = 0;
            public IntPtr hItem = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class NMTVCUSTOMDRAW
        {
            public NMCUSTOMDRAW nmcd;
            public int clrText;
            public int clrTextBk;
            public int iLevel = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMCUSTOMDRAW
        {
            public NMHDR nmcd;
            public int dwDrawStage;
            public IntPtr hdc;
            public RECT rc;
            public IntPtr dwItemSpec;
            public int uItemState;
            public IntPtr lItemlParam;
        }



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class MCHITTESTINFO
        {
            public int cbSize = Marshal.SizeOf(typeof(MCHITTESTINFO));
            public int pt_x = 0;
            public int pt_y = 0;
            public int uHit = 0;
            public short st_wYear = 0;
            public short st_wMonth = 0;
            public short st_wDayOfWeek = 0;
            public short st_wDay = 0;
            public short st_wHour = 0;
            public short st_wMinute = 0;
            public short st_wSecond = 0;
            public short st_wMilliseconds = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NMSELCHANGE
        {
            public NMHDR nmhdr;
            public SYSTEMTIME stSelStart = null;
            public SYSTEMTIME stSelEnd = null;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NMDAYSTATE
        {
            public NMHDR nmhdr;
            public SYSTEMTIME stStart = null;
            public int cDayState = 0;
            public IntPtr prgDayState;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMLVCUSTOMDRAW
        {
            public NMCUSTOMDRAW nmcd;
            public int clrText;
            public int clrTextBk;
            public int iSubItem;
            public int dwItemType;
            // Item Custom Draw
            public int clrFace;
            public int iIconEffect;
            public int iIconPhase;
            public int iPartId;
            public int iStateId;
            // Group Custom Draw
            public RECT rcText;
            public uint uAlign;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NMLVGETINFOTIP
        {
            public NMHDR nmhdr;
            public int flags = 0;
            public IntPtr lpszText = IntPtr.Zero;
            public int cchTextMax = 0;
            public int item = 0;
            public int subItem = 0;
            public IntPtr lParam = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class NMLVKEYDOWN
        {
            public NMHDR hdr;
            public short wVKey = 0;
            public uint flags = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LVHITTESTINFO
        {
            public int pt_x;
            public int pt_y;
            public int flags = 0;
            public int iItem = 0;
            public int iSubItem = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LVBKIMAGE
        {
            public int ulFlags;
            public IntPtr hBmp = IntPtr.Zero; // not used
            public string pszImage;
            public int cchImageMax;
            public int xOffset;
            public int yOffset;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LVCOLUMN_T
        {
            public int mask = 0;
            public int fmt = 0;
            public int cx = 0;
            public string pszText = null;
            public int cchTextMax = 0;
            public int iSubItem = 0;
            public int iImage = 0;
            public int iOrder = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LVFINDINFO
        {
            public int flags;
            public string psz;
            public IntPtr lParam;
            public int ptX; // was POINT pt
            public int ptY;
            public int vkDirection;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LVITEM
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
            public int iIndent;
            public int iGroupId;
            public int cColumns; // tile view columns
            public IntPtr puColumns;

            public unsafe void Reset()
            {
                pszText = null;
                mask = 0;
                iItem = 0;
                iSubItem = 0;
                stateMask = 0;
                state = 0;
                cchTextMax = 0;
                iImage = 0;
                lParam = IntPtr.Zero;
                iIndent = 0;
                iGroupId = 0;
                cColumns = 0;
                puColumns = IntPtr.Zero;
            }

            public override string ToString()
            {
                return "LVITEM: pszText = " + pszText
                     + ", iItem = " + iItem.ToString(CultureInfo.InvariantCulture)
                     + ", iSubItem = " + iSubItem.ToString(CultureInfo.InvariantCulture)
                     + ", state = " + state.ToString(CultureInfo.InvariantCulture)
                     + ", iGroupId = " + iGroupId.ToString(CultureInfo.InvariantCulture)
                     + ", cColumns = " + cColumns.ToString(CultureInfo.InvariantCulture);
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct LVITEM_NOTEXT
        {
            public int mask;
            public int iItem;
            public int iSubItem;
            public int state;
            public int stateMask;
            public IntPtr /*string*/   pszText;
            public int cchTextMax;
            public int iImage;
            public IntPtr lParam;
            public int iIndent;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LVCOLUMN
        {
            public int mask;
            public int fmt;
            public int cx = 0;
            public IntPtr /* LPWSTR */ pszText;
            public int cchTextMax = 0;
            public int iSubItem = 0;
            public int iImage;
            public int iOrder = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class LVGROUP
        {
            public uint cbSize = (uint)Marshal.SizeOf(typeof(LVGROUP));
            public uint mask;
            public IntPtr pszHeader;
            public int cchHeader;
            public IntPtr pszFooter = IntPtr.Zero;
            public int cchFooter = 0;
            public int iGroupId;
            public uint stateMask = 0;
            public uint state = 0;
            public uint uAlign;

            public override string ToString()
            {
                return "LVGROUP: header = " + pszHeader.ToString() + ", iGroupId = " + iGroupId.ToString(CultureInfo.InvariantCulture);
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LVINSERTMARK
        {
            public uint cbSize = (uint)Marshal.SizeOf(typeof(LVINSERTMARK));
            public int dwFlags;
            public int iItem;
            public int dwReserved = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class LVTILEVIEWINFO
        {
            public uint cbSize = (uint)Marshal.SizeOf(typeof(LVTILEVIEWINFO));
            public int dwMask;
            public int dwFlags;
            public SIZE sizeTile;
            public int cLines;
            public RECT rcLabelMargin;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NMLVCACHEHINT
        {
            public NMHDR hdr;
            public int iFrom = 0;
            public int iTo = 0;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NMLVDISPINFO
        {
            public NMHDR hdr;
            public LVITEM item;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NMLVDISPINFO_NOTEXT
        {
            public NMHDR hdr;
            public LVITEM_NOTEXT item;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class NMLVODSTATECHANGE
        {
            public NMHDR hdr;
            public int iFrom = 0;
            public int iTo = 0;
            public int uNewState = 0;
            public int uOldState = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class CLIENTCREATESTRUCT
        {
            public IntPtr hWindowMenu;
            public int idFirstChild;

            public CLIENTCREATESTRUCT(IntPtr hmenu, int idFirst)
            {
                hWindowMenu = hmenu;
                idFirstChild = idFirst;
            }
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class NMDATETIMECHANGE
        {
            public NMHDR nmhdr;
            public int dwFlags = 0;
            public SYSTEMTIME st = null;
        }


        [StructLayout(LayoutKind.Sequential)]
        public class COPYDATASTRUCT
        {
            public int dwData = 0;
            public int cbData = 0;
            public IntPtr lpData = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class NMHEADER
        {
            public NMHDR nmhdr;
            public int iItem = 0;
            public int iButton = 0;
            public IntPtr pItem = IntPtr.Zero;    // HDITEM*
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MOUSEHOOKSTRUCT
        {
            // pt was a by-value POINT structure 
            public int pt_x = 0;
            public int pt_y = 0;
            public IntPtr hWnd = IntPtr.Zero;
            public int wHitTestCode = 0;
            public int dwExtraInfo = 0;
        }

        #region SendKeys SendInput functionality

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public int mouseData;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public short wVk;
            public short wScan;
            public int dwFlags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public int uMsg;
            public short wParamL;
            public short wParamH;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public int type;
            public INPUTUNION inputUnion;
        }


        [StructLayout(LayoutKind.Explicit)]
        public struct INPUTUNION
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public class CHARRANGE
        {
            public int cpMin;
            public int cpMax;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public class CHARFORMATW
        {
            public int cbSize = Marshal.SizeOf(typeof(CHARFORMATW));
            public int dwMask;
            public int dwEffects;
            public int yHeight;
            public int yOffset = 0;
            public int crTextColor = 0;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] szFaceName = new byte[64];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public class CHARFORMATA
        {
            public int cbSize = Marshal.SizeOf(typeof(CHARFORMATA));
            public int dwMask;
            public int dwEffects;
            public int yHeight;
            public int yOffset;
            public int crTextColor;
            public byte bCharSet;
            public byte bPitchAndFamily;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] szFaceName = new byte[32];
        }

        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public class CHARFORMAT2A
        {
            public int cbSize = Marshal.SizeOf(typeof(CHARFORMAT2A));
            public int dwMask = 0;
            public int dwEffects = 0;
            public int yHeight = 0;
            public int yOffset = 0;
            public int crTextColor = 0;
            public byte bCharSet = 0;
            public byte bPitchAndFamily = 0;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] szFaceName = new byte[32];
            public short wWeight = 0;
            public short sSpacing = 0;
            public int crBackColor = 0;
            public int lcid = 0;
            public int dwReserved = 0;
            public short sStyle = 0;
            public short wKerning = 0;
            public byte bUnderlineType = 0;
            public byte bAnimation = 0;
            public byte bRevAuthor = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class TEXTRANGE
        {
            public CHARRANGE chrg;
            public IntPtr lpstrText; /* allocated by caller, zero terminated by RichEdit */
        }

        [StructLayout(LayoutKind.Sequential)]
        public class GETTEXTLENGTHEX
        {                               // Taken from richedit.h:
            public uint flags;          // Flags (see GTL_XXX defines)
            public uint codepage;       // Code page for translation (CP_ACP for default, 1200 for Unicode)
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public class SELCHANGE
        {
            public NMHDR nmhdr;
            public CHARRANGE chrg = null;
            public int seltyp = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class PARAFORMAT
        {
            public int cbSize = Marshal.SizeOf(typeof(PARAFORMAT));
            public int dwMask;
            public short wNumbering;
            public short wReserved = 0;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public int[] rgxTabs;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class FINDTEXT
        {
            public CHARRANGE chrg;
            public string lpstrText;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class REPASTESPECIAL
        {
            public int dwAspect;
            public int dwParam;
        }

        [SuppressMessage("Microsoft.Design", "CA1049:TypesThatOwnNativeResourcesShouldBeDisposable")]
        [StructLayout(LayoutKind.Sequential)]
        public class ENLINK
        {
            public NMHDR nmhdr;
            public int msg = 0;
            public IntPtr wParam = IntPtr.Zero;
            public IntPtr lParam = IntPtr.Zero;
            public CHARRANGE charrange = null;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ENLINK64
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
            public byte[] contents = new byte[56];
        }

        // GetRegionData structures
        [StructLayout(LayoutKind.Sequential)]
        public struct RGNDATAHEADER
        {
            public int cbSizeOfStruct;
            public int iType;
            public int nCount;
            public int nRgnSize;
            // public NativeMethods.RECT rcBound; // Note that we don't define this field as part of the marshaling 
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class OCPFIPARAMS
        {
            public int cbSizeOfStruct = Marshal.SizeOf(typeof(OCPFIPARAMS));
            public IntPtr hwndOwner;
            public int x = 0;
            public int y = 0;
            public string lpszCaption;
            public int cObjects = 1;
            public IntPtr ppUnk;
            public int pageCount = 1;
            public IntPtr uuid;
            public int lcid = Application.CurrentCulture.LCID;
            public int dispidInitial;
        }

        [StructLayout(LayoutKind.Sequential), ComVisible(false)]
        public struct STGMEDIUM
        {
            public int tymed;
            public IntPtr unionmember;
            public IntPtr pUnkForRelease;
        }

        [StructLayout(LayoutKind.Sequential), ComVisible(false)]
        public struct FORMATETC
        {
            public CLIPFORMAT cfFormat;
            public IntPtr ptd;
            public DVASPECT dwAspect;
            public int lindex;
            public TYMED tymed;
        }

        [ComVisible(true), StructLayout(LayoutKind.Sequential)]
        public class DOCHOSTUIINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize = Marshal.SizeOf(typeof(DOCHOSTUIINFO));
            [MarshalAs(UnmanagedType.I4)]
            public int dwFlags;
            [MarshalAs(UnmanagedType.I4)]
            public int dwDoubleClick;
            [MarshalAs(UnmanagedType.I4)]
            public int dwReserved1 = 0;
            [MarshalAs(UnmanagedType.I4)]
            public int dwReserved2 = 0;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }


        [ComVisible(false)]
        public enum CLIPFORMAT
        {
            CF_ZERO = 0,
            CF_BITMAP = 2,
            CF_DIB = 8,
            CF_DIF = 5,
            CF_DSPBITMAP = 130,
            CF_DSPENHMETAFILE = 0x8e,
            CF_DSPMETAFILEPICT = 0x83,
            CF_DSPTEXT = 0x81,
            CF_ENHMETAFILE = 14,
            CF_HDROP = 15,
            CF_LOCALE = 0x10,
            CF_MAX = 0x11,
            CF_METAFILEPICT = 3,
            CF_OEMTEXT = 7,
            CF_OWNERDISPLAY = 0x80,
            CF_PALETTE = 9,
            CF_PENDATA = 10,
            CF_RIFF = 11,
            CF_SYLK = 4,
            CF_TEXT = 1,
            CF_TIFF = 6,
            CF_UNICODETEXT = 13,
            CF_WAVE = 12
        }

        [Flags, ComVisible(false)]
        public enum TYMED
        {
            TYMED_ENHMF = 0x40,
            TYMED_FILE = 2,
            TYMED_GDI = 0x10,
            TYMED_HGLOBAL = 1,
            TYMED_ISTORAGE = 8,
            TYMED_ISTREAM = 4,
            TYMED_MFPICT = 0x20,
            TYMED_NULL = 0
        }

        [ComVisible(false), Flags]
        public enum DVASPECT
        {
            DVASPECT_CONTENT = 1,
            DVASPECT_DOCPRINT = 8,
            DVASPECT_ICON = 4,
            DVASPECT_OPAQUE = 0x10,
            DVASPECT_THUMBNAIL = 2,
            DVASPECT_TRANSPARENT = 0x20
        }

        [ComVisible(false), Flags]
        public enum DOCHOSTUIFLAG
        {
            DIALOG = 0x1,
            DISABLE_HELP_MENU = 0x2,
            NO3DBORDER = 0x4,
            SCROLL_NO = 0x8,
            DISABLE_SCRIPT_INACTIVE = 0x10,
            OPENNEWWIN = 0x20,
            DISABLE_OFFSCREEN = 0x40,
            FLAT_SCROLLBAR = 0x80,
            DIV_BLOCKDEFAULT = 0x100,
            ACTIVATE_CLIENTHIT_ONLY = 0x200,
            NO3DOUTERBORDER = 0x00200000,
            THEME = 0x00040000,
            NOTHEME = 0x80000,
            DISABLE_COOKIE = 0x400
        }

        public enum DOCHOSTUIDBLCLICK
        {
            DEFAULT = 0x0,
            SHOWPROPERTIES = 0x1,
            SHOWCODE = 0x2
        }

        public enum OLECMDID
        {
            OLECMDID_SAVEAS = 4,
            OLECMDID_PRINT = 6,
            OLECMDID_PRINTPREVIEW = 7,
            OLECMDID_PAGESETUP = 8,
            OLECMDID_PROPERTIES = 10
        }

        public enum OLECMDEXECOPT
        {
            OLECMDEXECOPT_DODEFAULT = 0,
            OLECMDEXECOPT_PROMPTUSER = 1,
            OLECMDEXECOPT_DONTPROMPTUSER = 2,
            OLECMDEXECOPT_SHOWHELP = 3
        }

        public enum OLECMDF
        {
            OLECMDF_SUPPORTED = 0x00000001,
            OLECMDF_ENABLED = 0x00000002,
            OLECMDF_LATCHED = 0x00000004,
            OLECMDF_NINCHED = 0x00000008,
            OLECMDF_INVISIBLE = 0x00000010,
            OLECMDF_DEFHIDEONCTXTMENU = 0x00000020
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ENDROPFILES
        {
            public NMHDR nmhdr;
            public IntPtr hDrop = IntPtr.Zero;
            public int cp = 0;
            public bool fProtected = false;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class REQRESIZE
        {
            public NMHDR nmhdr;
            public RECT rc;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class ENPROTECTED
        {
            public NMHDR nmhdr;
            public int msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public CHARRANGE chrg;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class ENPROTECTED64
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 56)]
            public byte[] contents = new byte[56];
        }

        public class ActiveX
        {
            public const int OCM__BASE = 0x2000;
            public const int DISPID_VALUE = unchecked((int)0x0);
            public const int DISPID_UNKNOWN = unchecked((int)0xFFFFFFFF);
            public const int DISPID_AUTOSIZE = unchecked((int)0xFFFFFE0C);
            public const int DISPID_BACKCOLOR = unchecked((int)0xFFFFFE0B);
            public const int DISPID_BACKSTYLE = unchecked((int)0xFFFFFE0A);
            public const int DISPID_BORDERCOLOR = unchecked((int)0xFFFFFE09);
            public const int DISPID_BORDERSTYLE = unchecked((int)0xFFFFFE08);
            public const int DISPID_BORDERWIDTH = unchecked((int)0xFFFFFE07);
            public const int DISPID_DRAWMODE = unchecked((int)0xFFFFFE05);
            public const int DISPID_DRAWSTYLE = unchecked((int)0xFFFFFE04);
            public const int DISPID_DRAWWIDTH = unchecked((int)0xFFFFFE03);
            public const int DISPID_FILLCOLOR = unchecked((int)0xFFFFFE02);
            public const int DISPID_FILLSTYLE = unchecked((int)0xFFFFFE01);
            public const int DISPID_FONT = unchecked((int)0xFFFFFE00);
            public const int DISPID_FORECOLOR = unchecked((int)0xFFFFFDFF);
            public const int DISPID_ENABLED = unchecked((int)0xFFFFFDFE);
            public const int DISPID_HWND = unchecked((int)0xFFFFFDFD);
            public const int DISPID_TABSTOP = unchecked((int)0xFFFFFDFC);
            public const int DISPID_TEXT = unchecked((int)0xFFFFFDFB);
            public const int DISPID_CAPTION = unchecked((int)0xFFFFFDFA);
            public const int DISPID_BORDERVISIBLE = unchecked((int)0xFFFFFDF9);
            public const int DISPID_APPEARANCE = unchecked((int)0xFFFFFDF8);
            public const int DISPID_MOUSEPOINTER = unchecked((int)0xFFFFFDF7);
            public const int DISPID_MOUSEICON = unchecked((int)0xFFFFFDF6);
            public const int DISPID_PICTURE = unchecked((int)0xFFFFFDF5);
            public const int DISPID_VALID = unchecked((int)0xFFFFFDF4);
            public const int DISPID_READYSTATE = unchecked((int)0xFFFFFDF3);
            public const int DISPID_REFRESH = unchecked((int)0xFFFFFDDA);
            public const int DISPID_DOCLICK = unchecked((int)0xFFFFFDD9);
            public const int DISPID_ABOUTBOX = unchecked((int)0xFFFFFDD8);
            public const int DISPID_CLICK = unchecked((int)0xFFFFFDA8);
            public const int DISPID_DBLCLICK = unchecked((int)0xFFFFFDA7);
            public const int DISPID_KEYDOWN = unchecked((int)0xFFFFFDA6);
            public const int DISPID_KEYPRESS = unchecked((int)0xFFFFFDA5);
            public const int DISPID_KEYUP = unchecked((int)0xFFFFFDA4);
            public const int DISPID_MOUSEDOWN = unchecked((int)0xFFFFFDA3);
            public const int DISPID_MOUSEMOVE = unchecked((int)0xFFFFFDA2);
            public const int DISPID_MOUSEUP = unchecked((int)0xFFFFFDA1);
            public const int DISPID_ERROREVENT = unchecked((int)0xFFFFFDA0);
            public const int DISPID_RIGHTTOLEFT = unchecked((int)0xFFFFFD9D);
            public const int DISPID_READYSTATECHANGE = unchecked((int)0xFFFFFD9F);
            public const int DISPID_AMBIENT_BACKCOLOR = unchecked((int)0xFFFFFD43);
            public const int DISPID_AMBIENT_DISPLAYNAME = unchecked((int)0xFFFFFD42);
            public const int DISPID_AMBIENT_FONT = unchecked((int)0xFFFFFD41);
            public const int DISPID_AMBIENT_FORECOLOR = unchecked((int)0xFFFFFD40);
            public const int DISPID_AMBIENT_LOCALEID = unchecked((int)0xFFFFFD3F);
            public const int DISPID_AMBIENT_MESSAGEREFLECT = unchecked((int)0xFFFFFD3E);
            public const int DISPID_AMBIENT_SCALEUNITS = unchecked((int)0xFFFFFD3D);
            public const int DISPID_AMBIENT_TEXTALIGN = unchecked((int)0xFFFFFD3C);
            public const int DISPID_AMBIENT_USERMODE = unchecked((int)0xFFFFFD3B);
            public const int DISPID_AMBIENT_UIDEAD = unchecked((int)0xFFFFFD3A);
            public const int DISPID_AMBIENT_SHOWGRABHANDLES = unchecked((int)0xFFFFFD39);
            public const int DISPID_AMBIENT_SHOWHATCHING = unchecked((int)0xFFFFFD38);
            public const int DISPID_AMBIENT_DISPLAYASDEFAULT = unchecked((int)0xFFFFFD37);
            public const int DISPID_AMBIENT_SUPPORTSMNEMONICS = unchecked((int)0xFFFFFD36);
            public const int DISPID_AMBIENT_AUTOCLIP = unchecked((int)0xFFFFFD35);
            public const int DISPID_AMBIENT_APPEARANCE = unchecked((int)0xFFFFFD34);
            public const int DISPID_AMBIENT_PALETTE = unchecked((int)0xFFFFFD2A);
            public const int DISPID_AMBIENT_TRANSFERPRIORITY = unchecked((int)0xFFFFFD28);
            public const int DISPID_AMBIENT_RIGHTTOLEFT = unchecked((int)0xFFFFFD24);
            public const int DISPID_Name = unchecked((int)0xFFFFFCE0);
            public const int DISPID_Delete = unchecked((int)0xFFFFFCDF);
            public const int DISPID_Object = unchecked((int)0xFFFFFCDE);
            public const int DISPID_Parent = unchecked((int)0xFFFFFCDD);
            public const int DVASPECT_CONTENT = 0x1;
            public const int DVASPECT_THUMBNAIL = 0x2;
            public const int DVASPECT_ICON = 0x4;
            public const int DVASPECT_DOCPRINT = 0x8;
            public const int OLEMISC_RECOMPOSEONRESIZE = 0x1;
            public const int OLEMISC_ONLYICONIC = 0x2;
            public const int OLEMISC_INSERTNOTREPLACE = 0x4;
            public const int OLEMISC_STATIC = 0x8;
            public const int OLEMISC_CANTLINKINSIDE = 0x10;
            public const int OLEMISC_CANLINKBYOLE1 = 0x20;
            public const int OLEMISC_ISLINKOBJECT = 0x40;
            public const int OLEMISC_INSIDEOUT = 0x80;
            public const int OLEMISC_ACTIVATEWHENVISIBLE = 0x100;
            public const int OLEMISC_RENDERINGISDEVICEINDEPENDENT = 0x200;
            public const int OLEMISC_INVISIBLEATRUNTIME = 0x400;
            public const int OLEMISC_ALWAYSRUN = 0x800;
            public const int OLEMISC_ACTSLIKEBUTTON = 0x1000;
            public const int OLEMISC_ACTSLIKELABEL = 0x2000;
            public const int OLEMISC_NOUIACTIVATE = 0x4000;
            public const int OLEMISC_ALIGNABLE = 0x8000;
            public const int OLEMISC_SIMPLEFRAME = 0x10000;
            public const int OLEMISC_SETCLIENTSITEFIRST = 0x20000;
            public const int OLEMISC_IMEMODE = 0x40000;
            public const int OLEMISC_IGNOREACTIVATEWHENVISIBLE = 0x80000;
            public const int OLEMISC_WANTSTOMENUMERGE = 0x100000;
            public const int OLEMISC_SUPPORTSMULTILEVELUNDO = 0x200000;
            public const int QACONTAINER_SHOWHATCHING = 0x1;
            public const int QACONTAINER_SHOWGRABHANDLES = 0x2;
            public const int QACONTAINER_USERMODE = 0x4;
            public const int QACONTAINER_DISPLAYASDEFAULT = 0x8;
            public const int QACONTAINER_UIDEAD = 0x10;
            public const int QACONTAINER_AUTOCLIP = 0x20;
            public const int QACONTAINER_MESSAGEREFLECT = 0x40;
            public const int QACONTAINER_SUPPORTSMNEMONICS = 0x80;
            public const int XFORMCOORDS_POSITION = 0x1;
            public const int XFORMCOORDS_SIZE = 0x2;
            public const int XFORMCOORDS_HIMETRICTOCONTAINER = 0x4;
            public const int XFORMCOORDS_CONTAINERTOHIMETRIC = 0x8;
            public const int PROPCAT_Nil = unchecked((int)0xFFFFFFFF);
            public const int PROPCAT_Misc = unchecked((int)0xFFFFFFFE);
            public const int PROPCAT_Font = unchecked((int)0xFFFFFFFD);
            public const int PROPCAT_Position = unchecked((int)0xFFFFFFFC);
            public const int PROPCAT_Appearance = unchecked((int)0xFFFFFFFB);
            public const int PROPCAT_Behavior = unchecked((int)0xFFFFFFFA);
            public const int PROPCAT_Data = unchecked((int)0xFFFFFFF9);
            public const int PROPCAT_List = unchecked((int)0xFFFFFFF8);
            public const int PROPCAT_Text = unchecked((int)0xFFFFFFF7);
            public const int PROPCAT_Scale = unchecked((int)0xFFFFFFF6);
            public const int PROPCAT_DDE = unchecked((int)0xFFFFFFF5);
            public const int GC_WCH_SIBLING = 0x1;
            public const int GC_WCH_CONTAINER = 0x2;
            public const int GC_WCH_CONTAINED = 0x3;
            public const int GC_WCH_ALL = 0x4;
            public const int GC_WCH_FREVERSEDIR = 0x8000000;
            public const int GC_WCH_FONLYNEXT = 0x10000000;
            public const int GC_WCH_FONLYPREV = 0x20000000;
            public const int GC_WCH_FSELECTED = 0x40000000;
            public const int OLECONTF_EMBEDDINGS = 0x1;
            public const int OLECONTF_LINKS = 0x2;
            public const int OLECONTF_OTHERS = 0x4;
            public const int OLECONTF_ONLYUSER = 0x8;
            public const int OLECONTF_ONLYIFRUNNING = 0x10;
            public const int ALIGN_MIN = 0x0;
            public const int ALIGN_NO_CHANGE = 0x0;
            public const int ALIGN_TOP = 0x1;
            public const int ALIGN_BOTTOM = 0x2;
            public const int ALIGN_LEFT = 0x3;
            public const int ALIGN_RIGHT = 0x4;
            public const int ALIGN_MAX = 0x4;
            public const int OLEVERBATTRIB_NEVERDIRTIES = 0x1;
            public const int OLEVERBATTRIB_ONCONTAINERMENU = 0x2;

            public static Guid IID_IUnknown = new Guid("{00000000-0000-0000-C000-000000000046}");

            private ActiveX()
            {
            }
        }

        public static class Util
        {
            public static int MAKEIPADDRESS(byte b1, byte b2, byte b3, byte b4)
            {
                return (((int)(b1) << 24) + ((int)(b2) << 16) + ((int)(b3) << 8) + ((int)(b4)));
            }

            public static ushort MAKEIPRANGE(byte low, byte high)
            {
                return (ushort)(((byte)(high) << 8) + (byte)(low));
            }

            public static int MAKELONG(int low, int high)
            {
                return (high << 16) | (low & 0xffff);
            }

            public static IntPtr MAKELPARAM(int low, int high)
            {
                return (IntPtr)((high << 16) | (low & 0xffff));
            }

            public static IntPtr MAKEWPARAM(int low, int high)
            {
                return (IntPtr)((high << 16) | (low & 0xffff));
            }

            public static int HIWORD(int n)
            {
                return (n >> 16) & 0xffff;
            }

            public static int HIWORD(IntPtr n)
            {
                return HIWORD(unchecked((int)(long)n));
            }

            public static int LOWORD(int n)
            {
                return n & 0xffff;
            }

            public static int LOWORD(IntPtr n)
            {
                return LOWORD(unchecked((int)(long)n));
            }

            public static int SignedHIWORD(IntPtr n)
            {
                return SignedHIWORD(unchecked((int)(long)n));
            }
            public static int SignedLOWORD(IntPtr n)
            {
                return SignedLOWORD(unchecked((int)(long)n));
            }

            public static int SignedHIWORD(int n)
            {
                int i = (int)(short)((n >> 16) & 0xffff);

                return i;
            }

            public static int SignedLOWORD(int n)
            {
                int i = (int)(short)(n & 0xFFFF);

                return i;
            }

            public static int GetPInvokeStringLength(String s)
            {
                if (s == null)
                {
                    return 0;
                }

                if (Marshal.SystemDefaultCharSize == 2)
                {
                    return s.Length;
                }
                else
                {
                    if (s.Length == 0)
                    {
                        return 0;
                    }
                    if (s.IndexOf('\0') > -1)
                    {
                        return GetEmbeddedNullStringLengthAnsi(s);
                    }
                    else
                    {
                        return lstrlen(s);
                    }
                }
            }

            public static byte FIRST_IPADDRESS(int x)
            {
                return (byte)((x >> 24) & 0xff);
            }

            public static byte SECOND_IPADDRESS(int x)
            {
                return (byte)((x >> 16) & 0xff);
            }

            public static byte THIRD_IPADDRESS(int x)
            {
                return (byte)((x >> 8) & 0xff);
            }
            public static byte FOURTH_IPADDRESS(int x)
            {
                return (byte)((x & 0xff));
            }

            private static int GetEmbeddedNullStringLengthAnsi(String s)
            {
                int n = s.IndexOf('\0');
                if (n > -1)
                {
                    String left = s.Substring(0, n);
                    String right = s.Substring(n + 1);
                    return GetPInvokeStringLength(left) + GetEmbeddedNullStringLengthAnsi(right) + 1;
                }
                else
                {
                    return GetPInvokeStringLength(s);
                }
            }

            [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
            private static extern int lstrlen(String s);

            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            internal static extern int RegisterWindowMessage(string msg);
        }

        public enum tagTYPEKIND
        {
            TKIND_ENUM = 0,
            TKIND_RECORD = 1,
            TKIND_MODULE = 2,
            TKIND_INTERFACE = 3,
            TKIND_DISPATCH = 4,
            TKIND_COCLASS = 5,
            TKIND_ALIAS = 6,
            TKIND_UNION = 7,
            TKIND_MAX = 8
        }



        [StructLayout(LayoutKind.Sequential)]
        public class tagTYPEDESC
        {
            public IntPtr unionMember;
            public short vt;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct tagPARAMDESC
        {
            public IntPtr pparamdescex;

            [MarshalAs(UnmanagedType.U2)]
            public short wParamFlags;
        }

        public sealed class CommonHandles
        {
            public static readonly int Accelerator = HandleCollector.RegisterType("Accelerator", 80, 50);
            public static readonly int Cursor = HandleCollector.RegisterType("Cursor", 20, 500);
            public static readonly int EMF = HandleCollector.RegisterType("EnhancedMetaFile", 20, 500);
            public static readonly int Find = HandleCollector.RegisterType("Find", 0, 1000);
            public static readonly int GDI = HandleCollector.RegisterType("GDI", 50, 500);
            public static readonly int HDC = HandleCollector.RegisterType("HDC", 100, 2);
            public static readonly int CompatibleHDC = HandleCollector.RegisterType("ComptibleHDC", 50, 50);
            public static readonly int Icon = HandleCollector.RegisterType("Icon", 20, 500);
            public static readonly int Kernel = HandleCollector.RegisterType("Kernel", 0, 1000);
            public static readonly int Menu = HandleCollector.RegisterType("Menu", 30, 1000);
            public static readonly int Window = HandleCollector.RegisterType("Window", 5, 1000);
        }

        public enum tagSYSKIND
        {
            SYS_WIN16 = 0,
            SYS_MAC = 2
        }

        public delegate bool MonitorEnumProc(IntPtr monitor, IntPtr hdc, IntPtr lprcMonitor, IntPtr lParam);

        [ComImport(), Guid("A7ABA9C1-8983-11cf-8F20-00805F2CD064"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IProvideMultipleClassInfo
        {
            [PreserveSig]
            NativeCOM.ITypeInfo GetClassInfo();

            [PreserveSig]
            int GetGUID(int dwGuidKind, [In, Out] ref Guid pGuid);

            [PreserveSig]
            int GetMultiTypeInfoCount([In, Out] ref int pcti);

            [PreserveSig]
            int GetInfoOfIndex(int iti, int dwFlags,
                               [In, Out]
                                ref NativeCOM.ITypeInfo pTypeInfo,
                               int pTIFlags,
                               int pcdispidReserved,
                               IntPtr piidPrimary,
                               IntPtr piidSource);
        }

        [StructLayout(LayoutKind.Sequential)]
        public class DRAWTEXTPARAMS
        {
            private int cbSize = Marshal.SizeOf(typeof(DRAWTEXTPARAMS));
            public int iTabLength;
            public int iLeftMargin;
            public int iRightMargin;
            public int uiLengthDrawn;

            public DRAWTEXTPARAMS()
            {
            }
            public DRAWTEXTPARAMS(DRAWTEXTPARAMS original)
            {
                this.iLeftMargin = original.iLeftMargin;
                this.iRightMargin = original.iRightMargin;
                this.iTabLength = original.iTabLength;
            }

            public DRAWTEXTPARAMS(int leftMargin, int rightMargin)
            {
                this.iLeftMargin = leftMargin;
                this.iRightMargin = rightMargin;
            }
            public override string ToString()
            {
                return string.Format("{0}=[tabLength={1}, leftMargin={2}, rightMargin={3}, lengthDrawn={4}]", this.GetType().Name, iTabLength, iLeftMargin, iRightMargin, uiLengthDrawn);
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public class EVENTMSG
        {
            public int message;
            public int paramL;
            public int paramH;
            public int time;
            public IntPtr hwnd;
        }

        [ComImport(), Guid("B196B283-BAB4-101A-B69C-00AA00341D07"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IProvideClassInfo
        {
            [return: MarshalAs(UnmanagedType.Interface)]
            NativeCOM.ITypeInfo GetClassInfo();
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagTYPEATTR
        {
            public Guid guid;
            [MarshalAs(UnmanagedType.U4)]
            public int lcid = 0;
            [MarshalAs(UnmanagedType.U4)]
            public int dwReserved = 0;
            public int memidConstructor = 0;
            public int memidDestructor = 0;
            public IntPtr lpstrSchema = IntPtr.Zero;
            [MarshalAs(UnmanagedType.U4)]
            public int cbSizeInstance = 0;
            public    /*NativeMethods.tagTYPEKIND*/ int typekind = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short cFuncs = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short cVars = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short cImplTypes = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short cbSizeVft = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short cbAlignment = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short wTypeFlags = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short wMajorVerNum = 0;
            [MarshalAs(UnmanagedType.U2)]
            public short wMinorVerNum = 0;

            [MarshalAs(UnmanagedType.U4)]
            public int tdescAlias_unionMember = 0;

            [MarshalAs(UnmanagedType.U2)]
            public short tdescAlias_vt = 0;

            [MarshalAs(UnmanagedType.U4)]
            public int idldescType_dwReserved = 0;

            [MarshalAs(UnmanagedType.U2)]
            public short idldescType_wIDLFlags = 0;


            public tagTYPEDESC Get_tdescAlias()
            {
                tagTYPEDESC td = new tagTYPEDESC();
                td.unionMember = (IntPtr)this.tdescAlias_unionMember;
                td.vt = this.tdescAlias_vt;
                return td;
            }

            public tagIDLDESC Get_idldescType()
            {
                tagIDLDESC id = new tagIDLDESC();
                id.dwReserved = this.idldescType_dwReserved;
                id.wIDLFlags = this.idldescType_wIDLFlags;
                return id;
            }
        }

        public enum tagVARFLAGS
        {
            VARFLAG_FREADONLY = 1,
            VARFLAG_FSOURCE = 0x2,
            VARFLAG_FBINDABLE = 0x4,
            VARFLAG_FREQUESTEDIT = 0x8,
            VARFLAG_FDISPLAYBIND = 0x10,
            VARFLAG_FDEFAULTBIND = 0x20,
            VARFLAG_FHIDDEN = 0x40,
            VARFLAG_FDEFAULTCOLLELEM = 0x100,
            VARFLAG_FUIDEFAULT = 0x200,
            VARFLAG_FNONBROWSABLE = 0x400,
            VARFLAG_FREPLACEABLE = 0x800,
            VARFLAG_FIMMEDIATEBIND = 0x1000
        }

        [StructLayout(LayoutKind.Sequential)]
        public sealed class tagELEMDESC
        {
            public NativeMethods.tagTYPEDESC tdesc = null;
            public NativeMethods.tagPARAMDESC paramdesc;
        }

        public enum tagVARKIND
        {
            VAR_PERINSTANCE = 0,
            VAR_STATIC = 1,
            VAR_CONST = 2,
            VAR_DISPATCH = 3
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct tagIDLDESC
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwReserved;
            [MarshalAs(UnmanagedType.U2)]
            public short wIDLFlags;
        }

        public struct RGBQUAD
        {
            public byte rgbBlue;
            public byte rgbGreen;
            public byte rgbRed;
            public byte rgbReserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PALETTEENTRY
        {
            public byte peRed;
            public byte peGreen;
            public byte peBlue;
            public byte peFlags;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPINFO_FLAT
        {
            public int bmiHeader_biSize;// = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
            public int bmiHeader_biWidth;
            public int bmiHeader_biHeight;
            public short bmiHeader_biPlanes;
            public short bmiHeader_biBitCount;
            public int bmiHeader_biCompression;
            public int bmiHeader_biSizeImage;
            public int bmiHeader_biXPelsPerMeter;
            public int bmiHeader_biYPelsPerMeter;
            public int bmiHeader_biClrUsed;
            public int bmiHeader_biClrImportant;

            [MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = BITMAPINFO_MAX_COLORSIZE * 4)]
            public byte[] bmiColors; // RGBQUAD structs... Blue-Green-Red-Reserved, repeat...
        }

        internal static string GetLocalPath(string fileName)
        {
            Debug.Assert(fileName != null && fileName.Length > 0, "Cannot get local path, fileName is not valid");
            Uri uri = new Uri(fileName);
            return uri.LocalPath + uri.Fragment;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class DLLVERSIONINFO
        {
            internal uint cbSize = 0;
            internal uint dwMajorVersion = 0;
            internal uint dwMinorVersion = 0;
            internal uint dwBuildNumber = 0;
            internal uint dwPlatformID = 0;
        }

        public enum OLERENDER
        {
            OLERENDER_NONE = 0,
            OLERENDER_DRAW = 1,
            OLERENDER_FORMAT = 2,
            OLERENDER_ASIS = 3
        }

        // Theming/Visual Styles stuff
        public const int STAP_ALLOW_NONCLIENT = (1 << 0);
        public const int STAP_ALLOW_CONTROLS = (1 << 1);
        public const int STAP_ALLOW_WEBCONTENT = (1 << 2);

        //public const int PS_NULL = 5;
        //public const int PS_INSIDEFRAME = 6;

        //public const int PS_GEOMETRIC = 0x00010000;
        //public const int PS_ENDCAP_SQUARE = 0x00000100;

        //public const int NULL_BRUSH = 5;
        //public const int MM_HIMETRIC = 3;

        // Threading stuff
        public const uint STILL_ACTIVE = 259;

        //SHell32
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public SFGAOF dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            public SHITEMID mkid;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHITEMID
        {
            public ushort cb;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
            public byte[] abID;
        }

        public const int SHCNE_RENAMEITEM = 0x00000001,
        SHCNE_CREATE = 0x00000002,
        SHCNE_DELETE = 0x00000004,
        SHCNE_MKDIR = 0x00000008,
        SHCNE_RMDIR = 0x00000010,
        SHCNE_MEDIAINSERTED = 0x00000020,
        SHCNE_MEDIAREMOVED = 0x00000040,
        SHCNE_DRIVEREMOVED = 0x00000080,
        SHCNE_DRIVEADD = 0x00000100,
        SHCNE_NETSHARE = 0x00000200,
        SHCNE_NETUNSHARE = 0x00000400,
        SHCNE_ATTRIBUTES = 0x00000800,
        SHCNE_UPDATEDIR = 0x00001000,
        SHCNE_UPDATEITEM = 0x00002000,
        SHCNE_SERVERDISCONNECT = 0x00004000,
        SHCNE_UPDATEIMAGE = 0x00008000,
        SHCNE_DRIVEADDGUI = 0x00010000,
        SHCNE_RENAMEFOLDER = 0x00020000,
        SHCNE_FREESPACE = 0x00040000,
        SHCNE_EXTENDED_EVENT = 0x04000000,
        SHCNE_ASSOCCHANGED = 0x08000000,
        SHCNE_DISKEVENTS = 0x0002381F,
        SHCNE_GLOBALEVENTS = 0x0C0581E0,
        SHCNE_ALLEVENTS = 0x7FFFFFFF,
        SHCNE_INTERRUPT = unchecked((int)0x80000000),
        SHCNEE_ORDERCHANGED = 2,
        SHCNEE_MSI_CHANGE = 4,
        SHCNEE_MSI_UNINSTALL = 5;

        [Flags]
        public enum SHGFI : int
        {
            SHGFI_ICON = 0x000000100,   // get icon 
            SHGFI_DISPLAYNAME = 0x000000200,     // get display name
            SHGFI_TYPENAME = 0x000000400,     // get type name
            SHGFI_ATTRIBUTES = 0x000000800,     // get attributes
            SHGFI_ICONLOCATION = 0x000001000,     // get icon location 
            SHGFI_EXETYPE = 0x000002000,     // return exe type
            SHGFI_SYSICONINDEX = 0x000004000,     // get system icon index 
            SHGFI_LINKOVERLAY = 0x000008000,     // put a link overlay on icon 
            SHGFI_SELECTED = 0x000010000,     // show icon in selected state
            SHGFI_ATTR_SPECIFIED = 0x000020000,     // get only specified attributes 
            SHGFI_LARGEICON = 0x000000000,     // get large icon
            SHGFI_SMALLICON = 0x000000001,     // get small icon
            SHGFI_OPENICON = 0x000000002,     // get open icon
            SHGFI_SHELLICONSIZE = 0x000000004,     // get shell size icon 
            SHGFI_PIDL = 0x000000008,     // pszPath is a pidl
            SHGFI_USEFILEATTRIBUTES = 0x000000010,     // use passed dwFileAttribute 
            SHGFI_ADDOVERLAYS = 0x000000020,     // apply the appropriate overlays 
            SHGFI_OVERLAYINDEX = 0x000000040    // Get the index of the overlay
        }

        [Flags]
        public enum SHCONTF
        {
            SHCONTF_FOLDERS = 32,
            SHCONTF_NONFOLDERS = 64,
            SHCONTF_INCLUDEHIDDEN = 128
        }

        [Flags]
        public enum SFGAOF : int
        {
            SFGAO_NONE = 0,
            SFGAO_CANCOPY = 1, // Objects can be copied
            SFGAO_CANMOVE = 2, // Objects can be moved
            SFGAO_CANLINK = 4, // Objects can be linked
            SFGAO_CANRENAME = 0x00000010,   // Objects can be renamed
            SFGAO_CANDELETE = 0x00000020,  // Objects can be deleted
            SFGAO_HASPROPSHEET = 0x00000040,  // Objects have property sheets
            SFGAO_DROPTARGET = 0x00000100,   // Objects are drop target
            SFGAO_CAPABILITYMASK = 0x00000177,
            SFGAO_LINK = 0x00010000,    // Shortcut (link)
            SFGAO_SHARE = 0x00020000,    // shared
            SFGAO_READONLY = 0x00040000,    // read-only
            SFGAO_GHOSTED = 0x00080000,    // ghosted icon
            SFGAO_HIDDEN = 0x00080000,    // hidden object
            SFGAO_DISPLAYATTRMASK = 0x000F0000,
            SFGAO_FILESYSANCESTOR = 0x10000000,   // It contains file system folder
            SFGAO_FOLDER = 0x20000000,    // It's a folder.
            SFGAO_FILESYSTEM = 0x40000000,    // is a file system thing (file/folder/root)
            SFGAO_HASSUBFOLDER = unchecked((int)0x80000000),    // Expandable in the map pane
            SFGAO_CONTENTSMASK = unchecked((int)0x80000000),
            SFGAO_VALIDATE = 0x01000000,     // invalidate cached information
            SFGAO_REMOVABLE = 0x02000000,     // is this removeable media?
            SFGAO_COMPRESSED = 0x04000000,     // Object is compressed (use alt color)
            SFGAO_BROWSABLE = 0x08000000,     // is in-place browsable
            SFGAO_NONENUMERATED = 0x00100000,     // is a non-enumerated object
            SFGAO_NEWCONTENT = 0x00200000,   // should show bold in explorer tree
            SFGAO_STORAGE = 8,
            SFGAO_STREAM = 0x400000
        }

        [Flags]
        public enum SHGNO : int
        {
            SHGDN_NORMAL = 0x0000,
            SHGDN_INFOLDER = 0x0001,
            SHGDN_FOREDITING = 0x1000,
            SHGDN_FORADDRESSBAR = 0x4000,
            SHGDN_FORPARSING = 0x8000
        }

        [StructLayout(LayoutKind.Sequential)]
        public class REOBJECT
        {
            public int cbStruct = Marshal.SizeOf(typeof(REOBJECT));
            public int cp;
            public Guid clsid;
            public IntPtr poleobj;
            public NativeCOM.IStorage pstg;
            public NativeCOM.IOleClientSite polesite;
            public Size sizel;
            public uint dvAspect;
            public uint dwFlags;
            public uint dwUser;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CMINVOKECOMMANDINFO
        {
            public int cbSize;
            public int fMask;
            public IntPtr hwnd;
            public IntPtr lpVerb;
            public IntPtr lpParameters;
            public IntPtr lpDirectory;
            public int nShow;
            public int dwHotKey;
            public IntPtr hIcon;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct CMINVOKECOMMANDINFOEX
        {
            public int cbSize;
            public CMIC fMask;
            public IntPtr hwnd;
            public IntPtr lpVerb;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpParameters;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpDirectory;
            public int nShow;
            public int dwHotKey;
            public IntPtr hIcon;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpTitle;
            public IntPtr lpVerbW;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpParametersW;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpDirectoryW;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpTitleW;
            public POINT ptInvoke;
        }

        [Flags]
        public enum CMIC : int
        {
            CMIC_MASK_HOTKEY = 0x00000020,
            CMIC_MASK_ICON = 0x00000010,
            CMIC_MASK_FLAG_NO_UI = 0x00000400,
            CMIC_MASK_UNICODE = 0x00004000,
            CMIC_MASK_NO_CONSOLE = 0x00008000,
            CMIC_MASK_ASYNCOK = 0x00100000,
            CMIC_MASK_NOZONECHECKS = 0x00800000,
            CMIC_MASK_SHIFT_DOWN = 0x10000000,
            CMIC_MASK_CONTROL_DOWN = 0x40000000,
            CMIC_MASK_FLAG_LOG_USAGE = 0x04000000,
            CMIC_MASK_PTINVOKE = 0x20000000
        }

        [Flags]
        public enum CMF : int
        {
            CMF_NORMAL = 0x00000000,
            CMF_DEFAULTONLY = 0x00000001,
            CMF_VERBSONLY = 0x00000002,
            CMF_EXPLORE = 0x00000004,
            CMF_NOVERBS = 0x00000008,
            CMF_CANRENAME = 0x00000010,
            CMF_NODEFAULT = 0x00000020,
            CMF_INCLUDESTATIC = 0x00000040,
            CMF_EXTENDEDVERBS = 0x00000100,
            CMF_RESERVED = (unchecked((int)0xffff0000)),
        }

        [Flags]
        public enum GCS : int
        {
            GCS_VERBA = 0,
            GCS_HELPTEXTA = 1,
            GCS_VALIDATEA = 2,
            GCS_VERBW = 4,
            GCS_HELPTEXTW = 5,
            GCS_VALIDATEW = 6
        }

        [Flags]
        public enum MF : int
        {
            MF_GRAYED = 0x00000003,
            MF_DISABLED = 0x00000003,
            MF_CHECKED = 0x00000008,
            MF_SEPARATOR = 0x00000800,
            MF_RADIOCHECK = 0x00000200,
            MF_BITMAP = 0x00000004,
            MF_OWNERDRAW = 0x00000100,
            MF_MENUBARBREAK = 0x00000020,
            MF_MENUBREAK = 0x00000040,
            MF_RIGHTORDER = 0x00002000,
            MF_BYCOMMAND = 0x00000000,
            MF_BYPOSITION = 0x00000400,
            MF_POPUP = 0x00000010
        }


        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct COMBOBOXEXITEM
        {
            public int mask;
            public int iItem;
            public string pszText;
            public int cchTextMax;
            public int iImage;
            public int iSelectedImage;
            public int iOverlay;
            public int iIndent;
            public int lParam;
        }

        public static int MAKEINTRESOURCE(int res)
        {
            return (0xffff & res);
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct REBARINFO
        {
            public int cbSize;
            public int fMask;
            public IntPtr himl;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct NMPGSCROLL
        {
            public NMHDR hdr;
            public bool fwKeys;
            public RECT rcParent;
            public int iDir;
            public int iXpos;
            public int iYpos;
            public int iScroll;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMPGCALCSIZE
        {
            public NMHDR hdr;
            public int dwFlag;
            public int iWidth;
            public int iHeight;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMPGHOTITEM
        {
            public NMHDR hdr;
            public int idOld;
            public int idNew;
            public int dwFlags;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct REBARBANDINFO
        {
            public int cbSize;
            public int fMask;
            public int fStyle;
            public int clrFore;
            public int clrBack;
            public IntPtr lpText;
            public int cch;
            public int iImage;
            public IntPtr hwndChild;
            public int cxMinChild;
            public int cyMinChild;
            public int cx;
            public IntPtr hbmBack;
            public int wID;
            public int cyChild;
            public int cyMaxChild;
            public int cyIntegral;
            public int cxIdeal;
            public int lParam;
            public int cxHeader;
        }


        [StructLayout(LayoutKind.Sequential)]
        public class REBARBANDINFO_T
        {
            public int cbSize = Marshal.SizeOf(typeof(NativeMethods.REBARBANDINFO_T));
            public int fMask = 0;
            public int fStyle = 0;
            public int clrFore;
            public int clrBack;
            public IntPtr lpText = IntPtr.Zero;
            public int cch;
            public int iImage;
            public IntPtr hwndChild = IntPtr.Zero;
            public int cxMinChild;
            public int cyMinChild;
            public int cx;
            public IntPtr hbmBack = IntPtr.Zero;
            public int wID;
            public int cyChild;
            public int cyMaxChild;
            public int cyIntegral;
            public int cxIdeal;
            public int lParam;
            public int cxHeader;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct NMRBAUTOSIZE
        {
            public NMHDR hdr;
            public bool fChanged;
            public RECT rcTarget;
            public RECT rcActual;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BITMAPFILEHEADER
        {
            public ushort bfType;
            public uint bfSize;
            public ushort bfReserved1;
            public ushort bfReserved2;
            public uint bfOffBits;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct TBMETRICS
        {
            public int cbSize;
            public int dwMask;
            public int cxPad;
            public int cyPad;
            public int cxBarPad;
            public int cyBarPad;
            public int cxButtonSpacing;
            public int cyButtonSpacing;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HDTEXTFILTER
        {
            public IntPtr pszText;
            public int cchTextMax;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HDHITTESTINFO
        {
            public Point pt;
            public int flags;
            public int iItem;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMIPADDRESS
        {
            public NMHDR hdr;
            public int iField;
            public int iValue;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct COMBOBOXINFO
        {
            public int cbSize;
            public RECT rcItem;
            public RECT rcButton;
            public int stateButton;
            public IntPtr hwndCombo;
            public IntPtr hwndItem;
            public IntPtr hwndList;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RBHITTESTINFO
        {
            public Point pt;
            public int flags;
            public int iBand;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DRAGLISTINFO
        {
            public int uNotification;
            public IntPtr hWnd;
            public Point ptCursor;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMTBCUSTOMDRAW
        {
            public NMCUSTOMDRAW nmcd;
            public IntPtr hbrMonoDither;
            public IntPtr hbrLines;
            public IntPtr hpenLines;
            public int clrText;
            public int clrMark;
            public int clrTextHighlight;
            public int clrBtnFace;
            public int clrBtnHighlight;
            public int clrHighlightHotTrack;
            public RECT rcText;
            public int nStringBkMode;
            public int nHLStringBkMode;
            public int iListGap;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LITEM
        {
            public int mask;
            public int iLink;
            public int state;
            public int stateMask;
            public IntPtr szID;
            public IntPtr szUrl;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TEXTMETRICW
        {
            public int tmHeight;
            public int tmAscent;
            public int tmDescent;
            public int tmInternalLeading;
            public int tmExternalLeading;
            public int tmAveCharWidth;
            public int tmMaxCharWidth;
            public int tmWeight;
            public int tmOverhang;
            public int tmDigitizedAspectX;
            public int tmDigitizedAspectY;
            public ushort tmFirstChar;
            public ushort tmLastChar;
            public ushort tmDefaultChar;
            public ushort tmBreakChar;
            public byte tmItalic;
            public byte tmUnderlined;
            public byte tmStruckOut;
            public byte tmPitchAndFamily;
            public byte tmCharSet;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct NCCALCSIZE_PARAMS
        {
            public RECT rgrc1;
            public RECT rgrc2;
            public RECT rgrc3;
            public IntPtr lppos;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMREBARCHEVRON
        {
            public NMHDR hdr;
            public int uBand;
            public int wID;
            public int lParam;
            public RECT rc;
            public int lParamNM;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LHITTESTINFO
        {
            Point pt;
            LITEM item;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NMLINK
        {
            NMHDR hdr;
            LITEM item;
        }

        public enum RectangleStyle
        {
            Solid,
            Dash,
            Dot,
            DashDot,
            DashDotDot,
            InsideFrame
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct UDACCEL
        {
            public int nSec;
            public int nInc;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct NMUPDOWN
        {
            public NMHDR hdr;
            public int iPos;
            public int iDelta;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CWPSTRUCT
        {
            public int lParam;
            public int wParam;
            public int message;
            public IntPtr hwnd;
        }

        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
        public struct STRRET
        {
            [FieldOffset(0)]
            public int uType;
            [FieldOffset(4)]
            public IntPtr pOleStr;
            [FieldOffset(4)]
            public IntPtr pStr;
            [FieldOffset(4)]
            public uint uOffset;
            [FieldOffset(4)]
            public IntPtr cStr;
        }

        public static int RGB(int r, int g, int b)
        {
            return ((int)(((byte)(r) | ((ushort)((byte)(g)) << 8)) | (((ushort)(byte)(b)) << 16)));
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct GdiplusStartupInput
        {
            public int GdiplusVersion;
            public IntPtr DebugEventCallback;
            public bool SuppressBackgroundThread;
            public bool SuppressExternalCodecs;

            public static GdiplusStartupInput StartupInput()
            {
                GdiplusStartupInput result = new GdiplusStartupInput();
                result.GdiplusVersion = 1;
                result.DebugEventCallback = IntPtr.Zero;
                result.SuppressBackgroundThread = false;
                result.SuppressExternalCodecs = false;
                return result;
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct GdiplusStartupOutput
        {
            public IntPtr NotificationHook;
            public IntPtr NotificationUnhook;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;
            public IntPtr pidlRoot;
            public IntPtr pszDisplayName;
            public IntPtr lpszTitle;
            public Int32 ulFlags;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public BrowseCallbackProc lpfn;
            public Int32 lParam;
            public Int32 iImage;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHChangeNotifyEntry
        {
            public IntPtr pIdl;
            public bool Recursively;
        }
    }
    public sealed class HandleCollector
    {
        private static HandleType[] handleTypes;
        private static int handleTypeCount;
        private static int suspendCount;

        internal static event HandleChangeEventHandler HandleAdded;
        internal static event HandleChangeEventHandler HandleRemoved;

        private static object internalSyncObject = new object();
        internal static IntPtr Add(IntPtr handle, int type)
        {
            handleTypes[type - 1].Add(handle);
            return handle;
        }

        internal static void SuspendCollect()
        {
            lock (internalSyncObject)
            {
                suspendCount++;
            }
        }

        internal static void ResumeCollect()
        {
            bool performCollect = false;
            lock (internalSyncObject)
            {
                if (suspendCount > 0)
                {
                    suspendCount--;
                }

                if (suspendCount == 0)
                {
                    for (int i = 0; i < handleTypeCount; i++)
                    {
                        lock (handleTypes[i])
                        {
                            if (handleTypes[i].NeedCollection())
                            {
                                performCollect = true;
                            }
                        }
                    }
                }
            }

            if (performCollect)
            {
                GC.Collect();
            }
        }

        internal static int RegisterType(string typeName, int expense, int initialThreshold)
        {
            lock (internalSyncObject)
            {
                if (handleTypeCount == 0 || handleTypeCount == handleTypes.Length)
                {
                    HandleType[] newTypes = new HandleType[handleTypeCount + 10];
                    if (handleTypes != null)
                    {
                        Array.Copy(handleTypes, 0, newTypes, 0, handleTypeCount);
                    }
                    handleTypes = newTypes;
                }

                handleTypes[handleTypeCount++] = new HandleType(typeName, expense, initialThreshold);
                return handleTypeCount;
            }
        }

        internal static IntPtr Remove(IntPtr handle, int type)
        {
            return handleTypes[type - 1].Remove(handle);
        }

        private class HandleType
        {
            internal readonly string name;

            private int initialThreshHold;
            private int threshHold;
            private int handleCount;
            private readonly int deltaPercent;
            internal HandleType(string name, int expense, int initialThreshHold)
            {
                this.name = name;
                this.initialThreshHold = initialThreshHold;
                this.threshHold = initialThreshHold;
                this.deltaPercent = 100 - expense;
            }

            internal void Add(IntPtr handle)
            {
                if (handle == IntPtr.Zero)
                {
                    return;
                }

                bool performCollect = false;
                int currentCount = 0;

                lock (this)
                {
                    handleCount++;
                    performCollect = NeedCollection();
                    currentCount = handleCount;
                }
                lock (internalSyncObject)
                {
                    if (HandleCollector.HandleAdded != null)
                    {
                        HandleCollector.HandleAdded(name, handle, currentCount);
                    }
                }
                if (!performCollect)
                {
                    return;
                }
                if (performCollect)
                {
                    GC.Collect();
                    int sleep = (100 - deltaPercent) / 4;
                    System.Threading.Thread.Sleep(sleep);
                }
            }

            internal int GetHandleCount()
            {
                lock (this)
                {
                    return handleCount;
                }
            }

            internal bool NeedCollection()
            {

                if (suspendCount > 0)
                {
                    return false;
                }
                if (handleCount > threshHold)
                {
                    threshHold = handleCount + ((handleCount * deltaPercent) / 100);
                    return true;
                }

                int oldThreshHold = (100 * threshHold) / (100 + deltaPercent);
                if (oldThreshHold >= initialThreshHold && handleCount < (int)(oldThreshHold * .9F))
                {
                    threshHold = oldThreshHold;
                }

                return false;
            }

            internal IntPtr Remove(IntPtr handle)
            {
                if (handle == IntPtr.Zero)
                {
                    return handle;
                }
                int currentCount = 0;
                lock (this)
                {
                    handleCount--;
                    if (handleCount < 0)
                    {
                        System.Diagnostics.Debug.Fail("Handle collector underflow for type '" + name + "'");
                        handleCount = 0;
                    }
                    currentCount = handleCount;
                }
                lock (internalSyncObject)
                {
                    if (HandleCollector.HandleRemoved != null)
                    {
                        HandleCollector.HandleRemoved(name, handle, currentCount);
                    }
                }
                return handle;

            }
        }
    }
    public delegate void HandleChangeEventHandler(string handleType, IntPtr handleValue, int currentHandleCount);
    public delegate int BrowseCallbackProc(IntPtr hwnd, int uMsg, IntPtr lParam, IntPtr lpData);
}
