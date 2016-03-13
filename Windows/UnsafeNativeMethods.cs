using System.Diagnostics.CodeAnalysis;
using System.Runtime.Versioning;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.ConstrainedExecution;
using System;
using System.Security.Permissions;
using System.Collections;
using System.IO;
using System.Text;
using System.Security;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using IComDataObject = System.Runtime.InteropServices.ComTypes.IDataObject;

namespace Windows
{
    [SuppressUnmanagedCodeSecurity()]
    public static class UnsafeNativeMethods
    {
        [DllImport(ExternDll.Winmm, EntryPoint = "timeSetEvent")]
        public static extern uint timeSetEvent(uint uDelay, uint uResolution, ref TIMECALLBACK lpTimeProc, uint dwUser, uint fuEvent);
        [DllImport(ExternDll.Shell32)]
        public static extern IntPtr ILFindLastID(IntPtr pidl);
        [DllImport(ExternDll.Shell32)]
        public static extern IntPtr ILFindChild(IntPtr pidlParent, IntPtr pidlChild);
        [DllImport(ExternDll.Shell32)]
        public static extern void ILFree(IntPtr pidl);
        [DllImport(ExternDll.Shell32)]
        public static extern IntPtr ILGetNext(IntPtr pidl);
        [DllImport(ExternDll.Shell32)]
        public static extern uint ILGetSize(IntPtr pidl);
        [DllImport(ExternDll.Shell32)]
        public static extern IntPtr ILClone(IntPtr pidl);
        [DllImport(ExternDll.Shell32)]
        public static extern IntPtr ILCloneFirst(IntPtr pidl);
        [DllImport(ExternDll.Shell32)]
        public static extern IntPtr ILCombine(IntPtr pidl1, IntPtr pidl2);
        [DllImport(ExternDll.Shell32)]
        public static extern bool ILRemoveLastID(IntPtr pidl);
        [DllImport(ExternDll.Shell32)]
        public static extern bool ILIsParent(IntPtr pidlParent, IntPtr pidlBelow, bool fImmediate);
        [DllImport(ExternDll.Shell32)]
        public static extern bool ILIsEqual(IntPtr pidl1, IntPtr pidl2);
        [DllImport(ExternDll.Shell32)]
        public static extern IntPtr ILAppendID(IntPtr pidl, IntPtr pmkid, bool fAppend);
        [DllImport(ExternDll.Shell32, EntryPoint = "SHGetMalloc")]
        public static extern int SHGetMalloc(out IntPtr ppMalloc);
        [DllImport(ExternDll.Shlwapi)]
        public static extern Int32 StrRetToBSTR(
             ref NativeMethods.STRRET pstr,
             IntPtr pidl,
             [MarshalAs(UnmanagedType.BStr)]
             out string pbstr);
        [DllImport(ExternDll.Shell32, EntryPoint = "SHGetSpecialFolderPath")]
        public static extern bool SHGetSpecialFolderPath(IntPtr hwndOwner, StringBuilder lpszPath, int nFolder, bool fCreate);
        [DllImport(ExternDll.Ole32, EntryPoint = "CoCreateInstance")]
        public static extern uint CoCreateInstance(ref Guid rclsid, [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter, uint dwClsContext, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] object ppv);
        [DllImport(ExternDll.Ole32, EntryPoint = "CoInitialize")]
        public static extern int CoInitialize(IntPtr pvReserved);
        [DllImport(ExternDll.Ole32, EntryPoint = "CoUninitialize")]
        public static extern void CoUninitialize();

        [DllImport(ExternDll.Shell32, EntryPoint = "SHCreateDirectory")]
        public static extern int SHCreateDirectory(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszPath);
        [DllImport(ExternDll.Shell32, EntryPoint = "#4")]
        public static extern bool SHChangeNotifyUnregister(uint hNotify);
        [DllImport(ExternDll.Shell32, EntryPoint = "#2", CharSet = CharSet.Auto)]
        public static extern uint SHChangeNotifyRegister(IntPtr hwnd, int fSources, int fEvents, int wMsg, int cEntries, [MarshalAs(UnmanagedType.LPArray)]NativeMethods.SHChangeNotifyEntry[] pfsne);
        [DllImport(ExternDll.Shell32, EntryPoint = "#4", CharSet = CharSet.Auto)]
        public static extern bool SHChangeNotifyDeregister(int hNotify);
        [DllImport(ExternDll.Shell32, CharSet = CharSet.Auto)]
        public static extern bool ShellAbout(IntPtr hWnd, string szApp, string szOtherStuff, IntPtr hIcon);

        [DllImport(ExternDll.Comctl32)]
        public static extern int ImageList_GetImageCount(HandleRef himl);
        [DllImport(ExternDll.Comctl32)]
        public static extern int ImageList_Add(HandleRef himl, HandleRef hbmImage, HandleRef hbmMask);
        [DllImport(ExternDll.Comctl32)]
        public static extern int ImageList_ReplaceIcon(HandleRef himl, int index, HandleRef hicon);
        [DllImport(ExternDll.Comctl32)]
        public static extern int ImageList_SetBkColor(HandleRef himl, int clrBk);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_Draw(HandleRef himl, int i, HandleRef hdcDst, int x, int y, int fStyle);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_Replace(HandleRef himl, int i, HandleRef hbmImage, HandleRef hbmMask);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_DrawEx(HandleRef himl, int i, HandleRef hdcDst, int x, int y, int dx, int dy, int rgbBk, int rgbFg, int fStyle);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_GetIconSize(HandleRef himl, out int x, out int y);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_Remove(HandleRef himl, int i);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_GetImageInfo(HandleRef himl, int i, NativeMethods.IMAGEINFO pImageInfo);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_Write(HandleRef himl, NativeCOM.IStream pstm);
        [DllImport(ExternDll.Comctl32)]
        public static extern int ImageList_WriteEx(HandleRef himl, int dwFlags, NativeCOM.IStream pstm);

        [DllImport(ExternDll.Uxtheme, EntryPoint = "OpenThemeData", CharSet = CharSet.Auto)]
        public static extern IntPtr OpenThemeData(IntPtr hwnd, string pszClassList);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "CloseThemeData")]
        public static extern IntPtr CloseThemeData(IntPtr hTheme);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "DrawThemeBackground")]
        public static extern int DrawThemeBackground(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref NativeMethods.RECT pRect, ref NativeMethods.RECT pClipRect);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "GetThemeBackgroundContentRect")]
        public static extern int GetThemeBackgroundContentRect(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref NativeMethods.RECT pBoundingRect, out NativeMethods.RECT pContentRect);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "DrawThemeText")]
        public static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string pszText, int iCharCount, int dwTextFlags, int dwTextFlags2, ref NativeMethods.RECT pRect);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "GetThemeTextExtent")]
        public static extern int GetThemeTextExtent(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string pszText, int iCharCount, int dwTextFlags, ref NativeMethods.RECT pBoundingRect, out NativeMethods.RECT pExtentRect);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "GetThemeBackgroundExtent")]
        public static extern int GetThemeBackgroundExtent(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref NativeMethods.RECT pContentRect, out NativeMethods.RECT pExtentRect);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "DrawThemeIcon")]
        public static extern int DrawThemeIcon(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, ref NativeMethods.RECT pRect, IntPtr himl, int iImageIndex);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "DrawThemeParentBackground")]
        public static extern int DrawThemeParentBackground(IntPtr hwnd, IntPtr hdc, ref NativeMethods.RECT prc);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "GetThemeFont")]
        public static extern int GetThemeFont(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, int iPropId, IntPtr pFont);
        [DllImport(ExternDll.Uxtheme, EntryPoint = "GetThemeColor")]
        public static extern int GetThemeColor(IntPtr hTheme, int iPartId, int iStateId, int iPropId, ref int pColor);
        [DllImport(ExternDll.User32, EntryPoint = "GetClassLong", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetClassLong(IntPtr hWnd, int nIndex);
        [DllImport(ExternDll.User32, EntryPoint = "SetClassLong", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint SetClassLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport(ExternDll.User32, EntryPoint = "IsWindowVisible")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport(ExternDll.Comctl32, EntryPoint = "MakeDragList")]
        public static extern bool MakeDragList(IntPtr hLB);
        [DllImport(ExternDll.Comctl32, EntryPoint = "DrawInsert")]
        public static extern void DrawInsert(IntPtr handParent, IntPtr hLB, int nItem);
        [DllImport(ExternDll.Comctl32, EntryPoint = "LBItemFromPt")]
        public static extern int LBItemFromPt(IntPtr hLB, Point pt, bool bAutoScroll);
        [DllImport(ExternDll.Gdi32, CharSet = CharSet.Auto)]
        public static extern bool GetTextMetrics(IntPtr hdc, ref NativeMethods.TEXTMETRICW lptm);
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetBkColor")]
        public static extern uint GetBkColor(System.IntPtr hdc);
        [DllImport(ExternDll.Shell32)]
        public static extern bool Shell_GetImageLists(IntPtr phiml, IntPtr phimlSmall);
        [DllImport(ExternDll.Shell32)]
        public static extern void SHChangeNotify(int wEventId, int uFlags, IntPtr dwItem1, IntPtr dwItem2);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateHatchBrush(int fnStyle, int color);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetNearestColor(HandleRef hDC, int color);
        [DllImport(ExternDll.User32, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int DrawTextExW(HandleRef hDC, string lpszString, int nCount, ref NativeMethods.RECT lpRect, int nFormat, [In, Out] NativeMethods.DRAWTEXTPARAMS lpDTParams);
        [DllImport(ExternDll.User32, SetLastError = true, CharSet = CharSet.Ansi)]
        public static extern int DrawTextExA(HandleRef hDC, byte[] lpszString, int byteCount, ref NativeMethods.RECT lpRect, int nFormat, [In, Out] NativeMethods.DRAWTEXTPARAMS lpDTParams);
        public static int DrawTextEx(HandleRef hDC, string text, ref NativeMethods.RECT lpRect, int nFormat, [In, Out] NativeMethods.DRAWTEXTPARAMS lpDTParams)
        {
            int retVal;
            if (Marshal.SystemDefaultCharSize == 1)
            {
                lpRect.top = Math.Min(Int16.MaxValue, lpRect.top);
                lpRect.left = Math.Min(Int16.MaxValue, lpRect.left);
                lpRect.right = Math.Min(Int16.MaxValue, lpRect.right);
                lpRect.bottom = Math.Min(Int16.MaxValue, lpRect.bottom);
                int byteCount = UnsafeNativeMethods.WideCharToMultiByte(0, 0, text, text.Length, null, 0, IntPtr.Zero, IntPtr.Zero);
                byte[] textBytes = new byte[byteCount];
                UnsafeNativeMethods.WideCharToMultiByte(0, 0, text, text.Length, textBytes, textBytes.Length, IntPtr.Zero, IntPtr.Zero);
                byteCount = Math.Min(byteCount, NativeMethods.MaxTextLengthInWin9x);
                retVal = DrawTextExA(hDC, textBytes, byteCount, ref lpRect, nFormat, lpDTParams);
            }
            else
            {
                retVal = DrawTextExW(hDC, text, text.Length, ref lpRect, nFormat, lpDTParams);
            }
            return retVal;
        }
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "SetMapMode", CharSet = CharSet.Auto)]
        public static extern int SetMapMode(HandleRef hDC, int nMapMode);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "GetMapMode", CharSet = CharSet.Auto)]
        public static extern int GetMapMode(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SetTextAlign(HandleRef hDC, int nMode);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetTextAlign(HandleRef hdc);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "SetViewportExtEx", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool SetViewportExtEx(HandleRef hDC, int x, int y, [In, Out] NativeMethods.SIZE size);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true)]
        public static extern int GetROP2(HandleRef hdc);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "SetBkMode", CharSet = CharSet.Auto)]
        public static extern int SetBkMode(HandleRef hDC, int nBkMode);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "GetBkMode", CharSet = CharSet.Auto)]
        public static extern int GetBkMode(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "Ellipse", CharSet = CharSet.Auto)]
        public static extern bool Ellipse(HandleRef hDc, int x1, int y1, int x2, int y2);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "AngleArc", CharSet = CharSet.Auto)]
        public static extern bool AngleArc(HandleRef hDC, int x, int y, int radius, float startAngle, float endAngle);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "StrokePath", CharSet = CharSet.Auto)]
        public static extern bool StrokePath(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "BeginPath", CharSet = CharSet.Auto)]
        public static extern bool BeginPath(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "EndPath", CharSet = CharSet.Auto)]
        public static extern bool EndPath(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, EntryPoint = "CreateFontIndirect", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateFontIndirect([In, Out, MarshalAs(UnmanagedType.AsAny)] object lf);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreatePen", CharSet = CharSet.Auto)]
        public static extern IntPtr CreatePen(int fnStyle, int nWidth, int crColor);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateSolidBrush", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateSolidBrush(int crColor);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CombineRgn", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern NativeMethods.RegionFlags CombineRgn(HandleRef hRgnDest, HandleRef hRgnSrc1, HandleRef hRgnSrc2, Windows.NativeMethods.RegionCombineMode combineMode);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "OffsetViewportOrgEx", CharSet = CharSet.Auto)]
        public static extern bool OffsetViewportOrgEx(HandleRef hDC, int nXOffset, int nYOffset, [In, Out] NativeMethods.POINT point);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "OffsetWindowOrgEx", CharSet = CharSet.Auto)]
        public static extern bool OffsetWindowOrgEx(HandleRef hDC, int nXOffset, int nYOffset, [In, Out] NativeMethods.POINT point);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "SaveDC", CharSet = CharSet.Auto)]
        public static extern int IntSaveDC(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "RestoreDC", CharSet = CharSet.Auto)]
        public static extern bool RestoreDC(HandleRef hDC, int nSavedDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetGraphicsMode(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "SetGraphicsMode", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int SetGraphicsMode(HandleRef hDC, int iMode);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "GetCurrentObject", CharSet = CharSet.Auto)]
        public static extern IntPtr GetCurrentObject(HandleRef hDC, int uObjectType);
        [DllImport(ExternDll.User32, SetLastError = true, ExactSpelling = true, EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
        public static extern IntPtr BeginPaint([In]IntPtr hWnd, [In, Out] ref NativeMethods.PAINTSTRUCT lpPaint);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
        public static extern IntPtr EndPaint([In]IntPtr hWnd, [In, Out] ref NativeMethods.PAINTSTRUCT lpPaint);
        [DllImport(ExternDll.User32, EntryPoint = "RedrawWindow")]
        public static extern bool RedrawWindow(IntPtr hWnd, ref NativeMethods.RECT lprcUpdate, IntPtr hrgnUpdate, int flags);
        [DllImport(ExternDll.User32, EntryPoint = "RedrawWindow")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, int flags);
        [DllImport(ExternDll.User32, EntryPoint = "InvalidateRect")]
        public static extern bool InvalidateRect(IntPtr hWnd, ref NativeMethods.RECT lpRect, bool bErase);
        [DllImport(ExternDll.User32, EntryPoint = "InvalidateRect")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);
        [DllImport(ExternDll.User32, EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport(ExternDll.User32, EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport(ExternDll.User32, EntryPoint = "AnimateWindow")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        [DllImport(ExternDll.Gdi32, EntryPoint = "ExcludeClipRect")]
        public static extern int ExcludeClipRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport(ExternDll.User32, EntryPoint = "GetMenuString", CharSet = CharSet.Auto)]
        public static extern int GetMenuString(IntPtr hMenu, int uIDItem, StringBuilder lpString, int nMaxCount, int uFlag);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int DrawText(IntPtr hDC, string lpString, int nCount, ref NativeMethods.RECT lpRect, int uFormat);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GetTextExtentPoint32W(HandleRef hDC, string text, int len, [In, Out] NativeMethods.SIZE size);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "GetViewportExtEx")]
        public static extern bool GetViewportExtEx(HandleRef hdc, [In, Out] NativeMethods.SIZE lpSize);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "ExtCreatePen", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern IntPtr ExtCreatePen(int fnStyle, int dwWidth, NativeMethods.LOGBRUSH lplb, int dwStyleCount, [MarshalAs(UnmanagedType.LPArray)] int[] lpStyle);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern int GetTextExtentPoint32A(HandleRef hDC, byte[] lpszString, int byteCount, [In, Out] NativeMethods.SIZE size);
        public static int GetTextExtentPoint32(HandleRef hDC, string text, [In, Out] NativeMethods.SIZE size)
        {
            int retVal;
            int byteCount = text.Length;
            if (Marshal.SystemDefaultCharSize == 1)
            {
                byteCount = UnsafeNativeMethods.WideCharToMultiByte(0, 0, text, text.Length, null, 0, IntPtr.Zero, IntPtr.Zero);
                byte[] textBytes = new byte[byteCount];
                UnsafeNativeMethods.WideCharToMultiByte(0, 0, text, text.Length, textBytes, textBytes.Length, IntPtr.Zero, IntPtr.Zero);
                byteCount = Math.Min(text.Length, NativeMethods.MaxTextLengthInWin9x);
                retVal = GetTextExtentPoint32A(hDC, textBytes, byteCount, size);
            }
            else
            {
                retVal = GetTextExtentPoint32W(hDC, text, text.Length, size);
            }
            return retVal;
        }
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateDC", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateDC(IntPtr lpszDriver, IntPtr lpszDevice, IntPtr lpszOutput, IntPtr lpInitData);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateCompatibleDC")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateCompatibleBitmap")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);
        [DllImport(ExternDll.Gdi32, EntryPoint = "BitBlt")]
        public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
        [DllImport(ExternDll.Gdi32, EntryPoint = "BitBlt")]
        public static extern bool BitBlt(HandleRef hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
        [DllImport(ExternDll.Gdi32, EntryPoint = "BitBlt")]
        public static extern bool BitBlt(HandleRef hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, HandleRef hdcSrc, int nXSrc, int nYSrc, uint dwRop);
        [DllImport(ExternDll.Gdi32, EntryPoint = "DeleteDC")]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport(ExternDll.Gdi32, EntryPoint = "DeleteDC")]
        public static extern bool DeleteDC(HandleRef hdc);
        [DllImport(ExternDll.Gdi32, EntryPoint = "OpenClipboard")]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport(ExternDll.User32, EntryPoint = "EmptyClipboard")]
        public static extern bool EmptyClipboard();
        [DllImport(ExternDll.User32, EntryPoint = "SetClipboardData")]
        public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        [DllImport(ExternDll.User32, EntryPoint = "CloseClipboard")]
        public static extern bool CloseClipboard();
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetPixel")]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetMapMode")]
        public static extern int SetMapMode(IntPtr hdc, int fnMapMode);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SaveDC")]
        public static extern int SaveDC(IntPtr hcd);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SaveDC")]
        public static extern int SaveDC(HandleRef hcd);
        [DllImport(ExternDll.Gdi32, EntryPoint = "DeleteObject")]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport(ExternDll.User32, EntryPoint = "LoadCursor", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, string lpCursorName);
        [DllImport(ExternDll.User32, EntryPoint = "LoadCursor", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(IntPtr hInstance, int id);
        [DllImport(ExternDll.User32, EntryPoint = "LoadCursorFromFile", CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursorFromFile(string lpFileName);
        [DllImport(ExternDll.User32, EntryPoint = "SetRectEmpty")]
        public static extern bool SetRectEmpty(ref NativeMethods.RECT lprc);
        [DllImport(ExternDll.Gdi32, EntryPoint = "StretchDIBits")]
        public static extern int StretchDIBits(IntPtr hdc, int XDest, int YDest, int nDestWidth, int nDestHeight, int XSrc, int YSrc, int nSrcWidth, int nSrcHeight, IntPtr lpBits, ref NativeMethods.BITMAPINFO lpBitsInfo, int iUsage, int dwRop);
        [DllImport(ExternDll.Gdi32, EntryPoint = "MoveToEx")]
        public static extern bool MoveToEx(IntPtr hdc, int X, int Y, ref Point lpPoint);
        [DllImport(ExternDll.Gdi32, EntryPoint = "MoveToEx")]
        public static extern bool MoveToEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);
        [DllImport(ExternDll.Gdi32, EntryPoint = "LineTo")]
        public static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);
        [DllImport("MSimg32.dll", EntryPoint = "AlphaBlend")]
        public static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, NativeMethods.BLENDFUNCTION blendFunction);
        [DllImport(ExternDll.Gdi32, EntryPoint = "TextOut")]
        public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart, string lpString, int cbString);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateBitmapIndirect")]
        public static extern IntPtr CreateBitmapIndirect(ref NativeMethods.BITMAP_STRUCT lpbm);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateBitmapIndirect")]
        public static extern IntPtr CreateBitmapIndirect(NativeMethods.BITMAP_CLASS lpbm);
        [DllImport(ExternDll.User32, EntryPoint = "DrawEdge")]
        public static extern bool DrawEdge(IntPtr hdc, ref NativeMethods.RECT qrc, int edge, int grfFlags);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetViewportExtEx")]
        public static extern bool SetViewportExtEx(IntPtr hdc, int nXExtent, int nYExtent, IntPtr lpSize);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetWindowOrgEx")]
        public static extern bool SetWindowOrgEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetWindowOrgEx")]
        public static extern bool GetWindowOrgEx(IntPtr hdc, IntPtr lpPoint);
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetWindowOrgEx")]
        public static extern bool GetWindowOrgEx(HandleRef hdc, NativeMethods.POINT lpPoint);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetWindowOrgEx")]
        public static extern bool SetViewportOrgEx(IntPtr hdc, int X, int Y, IntPtr lpPoint);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetROP2")]
        public static extern int SetROP2(IntPtr hdc, int fnDrawMode);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetBkMode")]
        public static extern int SetBkMode(IntPtr hdc, int iBkMode);
        [DllImport(ExternDll.User32, EntryPoint = "FillRect")]
        public static extern int FillRect(IntPtr hDC, ref Rectangle lprc, IntPtr hbr);
        [DllImport(ExternDll.User32, EntryPoint = "FillRect")]
        public static extern int FillRect(IntPtr hDC, ref NativeMethods.RECT lprc, IntPtr hbr);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateBitmap")]
        public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateBitmap")]
        unsafe public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, ushort* lpvBits);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreatePatternBrush")]
        public static extern IntPtr CreatePatternBrush(IntPtr hbmp);
        [DllImport(ExternDll.User32)]
        public static extern IntPtr LoadBitmap(IntPtr hInstance, string lpBitmapName);
        [DllImport(ExternDll.Gdi32, EntryPoint = "UnrealizeObject")]
        public static extern bool UnrealizeObject(IntPtr hgdiobj);
        [DllImport(ExternDll.Gdi32, EntryPoint = "Rectangle")]
        public static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport(ExternDll.User32, EntryPoint = "SetCapture")]
        public static extern IntPtr SetCapture(IntPtr hWnd);
        [DllImport(ExternDll.User32, EntryPoint = "UpdateWindow")]
        public static extern bool UpdateWindow(IntPtr hWnd);
        [DllImport(ExternDll.User32, EntryPoint = "GetDCEx")]
        public static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, uint flags);
        [DllImport(ExternDll.User32, EntryPoint = "GetDC")]
        public static extern IntPtr GetDC(IntPtr hWnd);
        [DllImport(ExternDll.User32, EntryPoint = "ReleaseDC")]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport(ExternDll.Gdi32, EntryPoint = "PatBlt")]
        public static extern bool PatBlt(IntPtr hdc, int nXLeft, int nYLeft, int nWidth, int nHeight, int dwRop);
        [DllImport(ExternDll.Gdi32, EntryPoint = "RestoreDC")]
        public static extern bool RestoreDC(IntPtr hdc, int nSavedDC);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetTextColor")]
        public static extern int SetTextColor(IntPtr hdc, int crColor);
        [DllImport(ExternDll.Gdi32, EntryPoint = "StretchBlt")]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, int dwRop);
        [DllImport(ExternDll.User32, EntryPoint = "InvalidateRgn")]
        public static extern bool InvalidateRgn(IntPtr hWnd, IntPtr hRgn, bool bErase);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetStretchBltMode")]
        public static extern int SetStretchBltMode(IntPtr hdc, int iStretchMode);
        [DllImport(ExternDll.User32, EntryPoint = "SetRect")]
        public static extern bool SetRect(ref NativeMethods.RECT lprc, int xLeft, int yTop, int xRight, int yBottom);
        [DllImport(ExternDll.User32, EntryPoint = "EqualRect")]
        public static extern bool EqualRect(ref NativeMethods.RECT lprc1, ref NativeMethods.RECT lprc2);
        [DllImport(ExternDll.User32, EntryPoint = "CopyRect")]
        public static extern bool CopyRect(ref NativeMethods.RECT lprcDst, ref NativeMethods.RECT lprcSrc);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CombineRgn")]
        public static extern int CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1, IntPtr hrgnSrc2, int fnCombineMode);
        [DllImport(ExternDll.User32, EntryPoint = "PtInRect")]
        public static extern bool PtInRect(NativeMethods.RECT_CLASS lprc, Point pt);
        [DllImport(ExternDll.User32, EntryPoint = "PtInRect")]
        public static extern bool PtInRect(ref NativeMethods.RECT lprc, Point pt);
        [DllImport(ExternDll.User32, EntryPoint = "GetComboBoxInfo")]
        public static extern bool GetComboBoxInfo(IntPtr hwndCombo, ref NativeMethods.COMBOBOXINFO pcbi);
        [DllImport(ExternDll.User32, EntryPoint = "ClientToScreen")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);
        [DllImport(ExternDll.User32, EntryPoint = "ScreenToClient")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SelectClipRgn")]
        public static extern int SelectClipRgn(IntPtr hdc, IntPtr hrgn);
        [DllImport(ExternDll.User32, EntryPoint = "InflateRect")]
        public static extern bool InflateRect(NativeMethods.RECT_CLASS lprc, int dx, int dy);
        [DllImport(ExternDll.User32, EntryPoint = "InflateRect")]
        public static extern bool InflateRect(ref NativeMethods.RECT lprc, int dx, int dy);
        //[DllImport(ExternDll.Gdi32, EntryPoint = "SetStretchBltMode")]
        //public static extern int SetStretchBltMode(IntPtr hdc, int iStretchMode);
        [DllImport(ExternDll.User32, EntryPoint = "IntersectRect")]
        public static extern bool IntersectRect(NativeMethods.RECT_CLASS lprcDst, NativeMethods.RECT_CLASS lprcSrc1, NativeMethods.RECT_CLASS lprcSrc2);
        [DllImport(ExternDll.User32, EntryPoint = "IntersectRect")]
        public static extern bool IntersectRect(ref NativeMethods.RECT lprcDst, ref NativeMethods.RECT lprcSrc1, ref NativeMethods.RECT lprcSrc2);
        [DllImport(ExternDll.User32, EntryPoint = "UpdateLayeredWindow")]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, System.IntPtr hdcSrc, ref Point pptSrc, uint crKey, ref NativeMethods.BLENDFUNCTION pblend, uint dwFlags);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateRectRgnIndirect")]
        public static extern IntPtr CreateRectRgnIndirect(ref NativeMethods.RECT lprc);
        [DllImport(ExternDll.Gdi32, EntryPoint = "CreateRectRgnIndirect")]
        public static extern IntPtr CreateRectRgnIndirect(NativeMethods.RECT_CLASS lprc);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetRectRgn")]
        public static extern bool SetRectRgn(IntPtr hrgn, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetClipBox")]
        public static extern int GetClipBox(IntPtr hdc, ref NativeMethods.RECT lprc);
        [DllImport(ExternDll.Gdi32, EntryPoint = "GetClipBox")]
        public static extern int GetClipBox(IntPtr hdc, NativeMethods.RECT_CLASS lprc);
        [DllImport(ExternDll.User32, EntryPoint = "GetCursorPos")]
        public static extern bool GetCursorPos(ref Point lpPoint);
        [DllImport(ExternDll.User32, EntryPoint = "SetCursor")]
        public static extern IntPtr SetCursor(IntPtr hCursor);
        [DllImport(ExternDll.Gdi32, EntryPoint = "SetBkColor")]
        public static extern uint SetBkColor(IntPtr hdc, int crColor);
        [DllImport(ExternDll.Gdi32, EntryPoint = "ExtTextOut")]
        public static extern bool ExtTextOut(IntPtr hdc, int X, int Y, uint fuOptions, ref NativeMethods.RECT lprc, IntPtr lpString, uint cbCount, IntPtr lpDx);
        [DllImport(ExternDll.Gdi32, EntryPoint = "ExtTextOut")]
        public static extern bool ExtTextOut(IntPtr hdc, int X, int Y, uint fuOptions, NativeMethods.RECT_CLASS lprc, IntPtr lpString, uint cbCount, IntPtr lpDx);
        [DllImport(ExternDll.User32, EntryPoint = "IsRectEmpty")]
        public static extern bool IsRectEmpty(ref NativeMethods.RECT lprc);
        [DllImport(ExternDll.User32, EntryPoint = "IsRectEmpty")]
        public static extern bool IsRectEmpty(NativeMethods.RECT_CLASS lprc);
        [DllImport(ExternDll.User32, EntryPoint = "SetWindowPos")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport(ExternDll.User32, EntryPoint = "GetMessage")]
        public static extern bool GetMessage(ref NativeMethods.MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
        public static IntPtr SelectStockObject(IntPtr hdc, int nIndex)
        {
            IntPtr hObject = GetStockObject(nIndex);
            IntPtr hOldObj = IntPtr.Zero;
            if (hdc != IntPtr.Zero)
                hOldObj = SelectObject(hdc, hObject);
            return hOldObj;
        }
        public static void DrawDragRectangle(IntPtr hWnd, Rectangle rectangle, Color backColor, NativeMethods.RectangleStyle style)
        {
            int rop2;
            Color graphicsColor;
            if (backColor.GetBrightness() < .5)
            {
                rop2 = NativeMethods.R2_NOTXORPEN;
                graphicsColor = Color.White;
            }
            else
            {
                rop2 = NativeMethods.R2_XORPEN;
                graphicsColor = Color.Black;
            }
            IntPtr dc = UnsafeNativeMethods.GetDCEx(hWnd, IntPtr.Zero, NativeMethods.DCX_WINDOW | NativeMethods.DCX_LOCKWINDOWUPDATE | NativeMethods.DCX_CACHE);
            IntPtr pen = IntPtr.Zero;
            switch (style)
            {
                case NativeMethods.RectangleStyle.Dot:
                    pen = UnsafeNativeMethods.CreatePen(NativeMethods.PS_DOT, 1, ColorTranslator.ToWin32(backColor));
                    break;
                case NativeMethods.RectangleStyle.DashDot:
                    pen = UnsafeNativeMethods.CreatePen(NativeMethods.PS_DASHDOT, 1, ColorTranslator.ToWin32(backColor));
                    break;
                case NativeMethods.RectangleStyle.DashDotDot:
                    pen = UnsafeNativeMethods.CreatePen(NativeMethods.PS_DASHDOTDOT, 1, ColorTranslator.ToWin32(backColor));
                    break;
                case NativeMethods.RectangleStyle.InsideFrame:
                    pen = UnsafeNativeMethods.CreatePen(NativeMethods.PS_INSIDEFRAME, 1, ColorTranslator.ToWin32(backColor));
                    break;
                case NativeMethods.RectangleStyle.Solid:
                    pen = UnsafeNativeMethods.CreatePen(NativeMethods.PS_SOLID, 1, ColorTranslator.ToWin32(backColor));
                    break;
            }
            int prevRop2 = UnsafeNativeMethods.SetROP2(dc, rop2);
            IntPtr oldBrush = UnsafeNativeMethods.SelectObject(dc, UnsafeNativeMethods.GetStockObject(NativeMethods.HOLLOW_BRUSH));
            IntPtr oldPen = UnsafeNativeMethods.SelectObject(dc, pen);
            UnsafeNativeMethods.SetBkColor(dc, ColorTranslator.ToWin32(graphicsColor));
            UnsafeNativeMethods.Rectangle(dc, rectangle.X, rectangle.Y, rectangle.Right, rectangle.Bottom);
            UnsafeNativeMethods.SetROP2(dc, prevRop2);
            UnsafeNativeMethods.SelectObject(dc, oldBrush);
            UnsafeNativeMethods.SelectObject(dc, oldPen);
            if (pen != IntPtr.Zero)
                UnsafeNativeMethods.DeleteObject(pen);
            UnsafeNativeMethods.ReleaseDC(hWnd, dc);
        }
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool DestroyIcon(HandleRef hIcon);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool DestroyIcon(IntPtr hIcon);
        [DllImport(ExternDll.Shlwapi, CharSet = CharSet.Unicode, ExactSpelling = true)]
        public static extern uint SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, uint cchOutBuf, IntPtr ppvReserved);
        [DllImport(ExternDll.Ole32)]
        public static extern int ReadClassStg(HandleRef pStg, [In, Out] ref Guid pclsid);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int GetClassName(HandleRef hwnd, IntPtr lpClassName, int nMaxCount);
        public static IntPtr SetClassLong(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetClassLongPtr32(hWnd, nIndex, dwNewLong);
            }
            return SetClassLongPtr64(hWnd, nIndex, dwNewLong);
        }
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetClassLong")]
        public static extern IntPtr SetClassLongPtr32(HandleRef hwnd, int nIndex, IntPtr dwNewLong);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetClassLongPtr")]
        public static extern IntPtr SetClassLongPtr64(HandleRef hwnd, int nIndex, IntPtr dwNewLong);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, PreserveSig = false)]
        public static extern NativeCOM.IClassFactory2 CoGetClassObject(
            [In] 
            ref Guid clsid,
            int dwContext,
            int serverInfo,
            [In]
            ref Guid refiid);

        [return: MarshalAs(UnmanagedType.Interface)]
        [DllImport(ExternDll.Ole32, ExactSpelling = true, PreserveSig = false)]
        public static extern object CoCreateInstance(
            [In] 
            ref Guid clsid,
            [MarshalAs(UnmanagedType.Interface)] 
            object punkOuter,
            int context,
            [In]
            ref Guid iid);

        private struct POINTSTRUCT
        {
            public int x;
            public int y;

            public POINTSTRUCT(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        private static readonly Version VistaOSVersion = new Version(6, 0);

        public static bool IsVista
        {
            get
            {
                OperatingSystem os = Environment.OSVersion;
                if (os == null)
                    return false;

                return (os.Platform == PlatformID.Win32NT) &&
                       (os.Version.CompareTo(VistaOSVersion) >= 0);
            }
        }
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Ansi)]
        public static extern int WinExec(string lpCmdLine, int uCmdShow);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern int GetLocaleInfo(int Locale, int LCType, StringBuilder lpLCData, int cchData);
        [DllImport(ExternDll.Ole32)]
        public static extern int WriteClassStm(NativeCOM.IStream pStream, ref Guid clsid);
        [DllImport(ExternDll.Ole32)]
        public static extern int ReadClassStg(NativeCOM.IStorage pStorage, [Out]out Guid clsid);
        [DllImport(ExternDll.Ole32)]
        public static extern int ReadClassStm(NativeCOM.IStream pStream, [Out]out Guid clsid);
        [DllImport(ExternDll.Ole32)]
        public static extern int OleLoadFromStream(IStream pStorage, ref Guid iid, out NativeCOM.IOleObject pObject);
        [DllImport(ExternDll.Ole32)]
        public static extern int OleSaveToStream(NativeCOM.IPersistStream pPersistStream, NativeCOM.IStream pStream);
        [DllImport(ExternDll.Ole32)]
        public static extern int CoGetMalloc(int dwReserved, out NativeCOM.IMalloc pMalloc);
        [DllImport(ExternDll.Ole32)]
        public static extern int OleSetMenuDescriptor(IntPtr hOleMenu, IntPtr hWndFrame, IntPtr hWndActiveObject, NativeCOM.IOleInPlaceFrame frame, NativeCOM.IOleInPlaceActiveObject activeObject);
        [DllImport(ExternDll.Kernel32)]
        public static extern bool IsBadReadPtr(HandleRef ptr, int size);
        [DllImport(ExternDll.Comdlg32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool PageSetupDlg([In, Out] NativeMethods.PAGESETUPDLG lppsd);
        [DllImport(ExternDll.Comdlg32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool PrintDlg([In, Out] NativeMethods.PRINTDLG lppd);
        [DllImport(ExternDll.Comdlg32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int PrintDlgEx([In, Out] NativeMethods.PRINTDLGEX lppdex);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int OleGetClipboard(ref IComDataObject data);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int OleSetClipboard(IComDataObject pDataObj);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int OleFlushClipboard();
        [DllImport(ExternDll.Oleaut32, ExactSpelling = true)]
        public static extern void OleCreatePropertyFrameIndirect(NativeMethods.OCPFIPARAMS p);
        [DllImport(ExternDll.Ole32, ExactSpelling = true)]
        public static extern int CreateStreamOnHGlobal(IntPtr hGlobal, bool fDeleteOnRelease, NativeCOM.IStream ppstm);

        [DllImport(ExternDll.Oleaut32, EntryPoint = "OleCreateFontIndirect", ExactSpelling = true, PreserveSig = false)]
        public static extern NativeCOM.IFont OleCreateIFontIndirect(NativeMethods.FONTDESC fd, ref Guid iid);
        [DllImport(ExternDll.Oleaut32, EntryPoint = "OleCreatePictureIndirect", ExactSpelling = true, PreserveSig = false)]
        public static extern NativeCOM.IPicture OleCreateIPictureIndirect([MarshalAs(UnmanagedType.AsAny)]object pictdesc, ref Guid iid, bool fOwn);
        [DllImport(ExternDll.Oleaut32, EntryPoint = "OleCreatePictureIndirect", ExactSpelling = true, PreserveSig = false)]
        public static extern NativeCOM.IPictureDisp OleCreateIPictureDispIndirect([MarshalAs(UnmanagedType.AsAny)] object pictdesc, ref Guid iid, bool fOwn);
        [DllImport(ExternDll.Oleaut32, PreserveSig = false)]
        public static extern NativeCOM.IPicture OleCreatePictureIndirect(NativeMethods.PICTDESC pictdesc, [In]ref Guid refiid, bool fOwn);
        [DllImport(ExternDll.Oleaut32, PreserveSig = false)]
        public static extern NativeCOM.IFont OleCreateFontIndirect(NativeMethods.tagFONTDESC fontdesc, [In]ref Guid refiid);
        [DllImport(ExternDll.Oleaut32, ExactSpelling = true)]
        public static extern int VarFormat(ref object pvarIn, HandleRef pstrFormat, int iFirstDay, int iFirstWeek, uint dwFlags, [In, Out]ref IntPtr pbstr);
        [DllImport(ExternDll.Shell32, CharSet = CharSet.Auto)]
        public static extern int DragQueryFile(HandleRef hDrop, int iFile, StringBuilder lpszFile, int cch);
        [DllImport(ExternDll.User32, ExactSpelling = true)]
        public static extern bool EnumChildWindows(HandleRef hwndParent, NativeMethods.EnumChildrenCallback lpEnumFunc, HandleRef lParam);
        [DllImport(ExternDll.Shell32, CharSet = CharSet.Auto)]
        public static extern IntPtr ShellExecute(HandleRef hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        [DllImport(ExternDll.Shell32, CharSet = CharSet.Auto, EntryPoint = "ShellExecute", BestFitMapping = false)]
        public static extern IntPtr ShellExecute_NoBFM(HandleRef hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetScrollPos(HandleRef hWnd, int nBar, int nPos, bool bRedraw);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnableScrollBar(HandleRef hWnd, int nBar, int value);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool IsMenu(IntPtr hMenu);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool AppendMenu(IntPtr hMenu, int uFlags, IntPtr uIDNewItem, IntPtr lpNewItem);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool ModifyMenu(IntPtr hMnu, int uPosition, int uFlags, IntPtr uIDNewItem, IntPtr lpNewItem);
        [DllImport(ExternDll.Shell32, CharSet = CharSet.Auto)]
        public static extern int Shell_NotifyIcon(int message, NativeMethods.NOTIFYICONDATA pnid);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static bool InsertMenuItem(HandleRef hMenu, int uItem, bool fByPosition, NativeMethods.MENUITEMINFO_T lpmii);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static bool InsertMenuItem(HandleRef hMenu, int uItem, bool fByPosition, NativeMethods.MENUITEMINFO_T_RW lpmii);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetMenu(HandleRef hWnd);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool GetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, [In, Out] NativeMethods.MENUITEMINFO_T lpmii);
        [DllImport(ExternDll.User32)]
        public static extern bool GetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, ref NativeMethods.MENUITEMINFO lpmii);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool GetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, [In, Out] NativeMethods.MENUITEMINFO_T_RW lpmii);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static bool SetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, NativeMethods.MENUITEMINFO_T lpmii);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static bool SetMenuItemInfo(HandleRef hMenu, int uItem, bool fByPosition, NativeMethods.MENUITEMINFO_T_RW lpmii);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "CreateMenu", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateMenu();
        [DllImport(ExternDll.Comdlg32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] NativeMethods.OPENFILENAME_I ofn);
        [DllImport(ExternDll.User32, ExactSpelling = true)]
        public static extern bool EndDialog(HandleRef hWnd, IntPtr result);
        public const int MB_PRECOMPOSED = 0x00000001;
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int MultiByteToWideChar(int CodePage, int dwFlags, byte[] lpMultiByteStr, int cchMultiByte, char[] lpWideCharStr, int cchWideChar);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int WideCharToMultiByte(int codePage, int flags, [MarshalAs(UnmanagedType.LPWStr)]string wideStr, int chars, [In, Out]byte[] pOutBytes, int bufferBytes, IntPtr defaultChar, IntPtr pDefaultUsed);
        [DllImport(ExternDll.Kernel32, SetLastError = true, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Auto)]
        public static extern void CopyMemory(HandleRef destData, HandleRef srcData, int size);
        [DllImport(ExternDll.Kernel32, SetLastError = true, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Auto)]
        public static extern void CopyMemory(IntPtr destData, IntPtr srcData, int size);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, EntryPoint = "RtlMoveMemory")]
        public static extern void CopyMemory(IntPtr pdst, byte[] psrc, int cb);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Unicode)]
        public static extern void CopyMemoryW(IntPtr pdst, string psrc, int cb);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Unicode)]
        public static extern void CopyMemoryW(IntPtr pdst, char[] psrc, int cb);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi)]
        public static extern void CopyMemoryA(IntPtr pdst, string psrc, int cb);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, EntryPoint = "RtlMoveMemory", CharSet = CharSet.Ansi)]
        public static extern void CopyMemoryA(IntPtr pdst, char[] psrc, int cb);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, EntryPoint = "DuplicateHandle", SetLastError = true)]
        private static extern IntPtr IntDuplicateHandle(HandleRef processSource, HandleRef handleSource, HandleRef processTarget, ref IntPtr handleTarget, int desiredAccess, bool inheritHandle, int options);
        public static IntPtr DuplicateHandle(HandleRef processSource, HandleRef handleSource, HandleRef processTarget, ref IntPtr handleTarget, int desiredAccess, bool inheritHandle, int options)
        {
            IntPtr ret = IntDuplicateHandle(processSource, handleSource, processTarget, ref handleTarget,
                                         desiredAccess, inheritHandle, options);
            HandleCollector.Add(handleTarget, NativeMethods.CommonHandles.Kernel);
            return ret;
        }
        [DllImport(ExternDll.User32)]
        public static extern int GetSysColor(int nIndex);
        [DllImport(ExternDll.Ole32, PreserveSig = false)]
        public static extern NativeCOM.IStorage StgOpenStorageOnILockBytes(NativeCOM.ILockBytes iLockBytes, NativeCOM.IStorage pStgPriority, int grfMode, int sndExcluded, int reserved);
        [DllImport(ExternDll.Ole32, PreserveSig = false)]
        public static extern IntPtr GetHGlobalFromILockBytes(NativeCOM.ILockBytes pLkbyt);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookid, NativeMethods.WindowsHookProc pfnhook, HandleRef hinst, int threadid);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SetWindowsHookEx(int hookid, NativeMethods.WindowsHookProc pfnhook, IntPtr hinst, int threadid);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetKeyboardState(byte[] keystate);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "keybd_event", CharSet = CharSet.Auto)]
        public static extern void Keybd_event(byte vk, byte scan, int flags, int extrainfo);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SetKeyboardState(byte[] keystate);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool UnhookWindowsHookEx(HandleRef hhook);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern short GetAsyncKeyState(int vkey);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CallNextHookEx(HandleRef hhook, int code, IntPtr wparam, IntPtr lparam);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr CallNextHookEx(IntPtr hhook, int code, IntPtr wparam, IntPtr lparam);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int ScreenToClient(HandleRef hWnd, [In, Out] NativeMethods.POINT pt);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern int GetModuleFileName(HandleRef hModule, StringBuilder buffer, int length);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool IsDialogMessage(HandleRef hWndDlg, [In, Out] ref NativeMethods.MSG msg);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool TranslateMessage([In, Out] ref NativeMethods.MSG msg);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr DispatchMessage([In] ref NativeMethods.MSG msg);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr DispatchMessageA([In] ref NativeMethods.MSG msg);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr DispatchMessageW([In] ref NativeMethods.MSG msg);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int PostThreadMessage(int id, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport(ExternDll.Ole32, ExactSpelling = true)]
        public static extern int CoRegisterMessageFilter(HandleRef newFilter, ref IntPtr oldMsgFilter);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, EntryPoint = "OleInitialize", SetLastError = true)]
        private static extern int IntOleInitialize(int val);
        public static int OleInitialize()
        {
            return IntOleInitialize(0);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static bool EnumThreadWindows(int dwThreadId, NativeMethods.EnumThreadWindowsCallback lpfn, HandleRef lParam);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(ExternDll.Kernel32)]
        public extern static bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendDlgItemMessage(HandleRef hDlg, int nIDDlgItem, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int OleUninitialize();
        [DllImport(ExternDll.Comdlg32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool GetSaveFileName([In, Out] NativeMethods.OPENFILENAME_I ofn);
        [DllImport(ExternDll.User32, EntryPoint = "ChildWindowFromPointEx", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr _ChildWindowFromPointEx(HandleRef hwndParent, POINTSTRUCT pt, int uFlags);
        public static IntPtr ChildWindowFromPointEx(HandleRef hwndParent, int x, int y, int uFlags)
        {
            POINTSTRUCT ps = new POINTSTRUCT(x, y);
            return _ChildWindowFromPointEx(hwndParent, ps, uFlags);
        }
        [DllImport(ExternDll.Kernel32, EntryPoint = "CloseHandle", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool CloseHandle(HandleRef handle);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateCompatibleDC", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateCompatibleDC(HandleRef hDC);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool BlockInput([In, MarshalAs(UnmanagedType.Bool)] bool fBlockIt);
        [DllImport(ExternDll.User32, ExactSpelling = true, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern uint SendInput(uint nInputs, NativeMethods.INPUT[] pInputs, int cbSize);
        [DllImport(ExternDll.Kernel32, EntryPoint = "CreateFileMapping", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntCreateFileMapping(HandleRef hFile, IntPtr lpAttributes, int flProtect, int dwMaxSizeHi, int dwMaxSizeLow, string lpName);
        public static IntPtr CreateFileMapping(HandleRef hFile, IntPtr lpAttributes, int flProtect, int dwMaxSizeHi, int dwMaxSizeLow, string lpName)
        {
            return HandleCollector.Add(IntCreateFileMapping(hFile, lpAttributes, flProtect, dwMaxSizeHi, dwMaxSizeLow, lpName), NativeMethods.CommonHandles.Kernel);
        }
        [DllImport(ExternDll.Kernel32, EntryPoint = "OpenFileMapping", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr IntOpenFileMapping(int dwDesiredAccess, bool bInheritHandle, string lpName);
        public static IntPtr OpenFileMapping(int dwDesiredAccess, bool bInheritHandle, string lpName)
        {
            return HandleCollector.Add(IntOpenFileMapping(dwDesiredAccess, bInheritHandle, lpName), NativeMethods.CommonHandles.Kernel);
        }
        [DllImport(ExternDll.Kernel32, EntryPoint = "MapViewOfFile", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        [SuppressMessage("Microsoft.Portability", "CA1901:PInvokeDeclarationsShouldBePortable")]
        private static extern IntPtr IntMapViewOfFile(HandleRef hFileMapping, int dwDesiredAccess, int dwFileOffsetHigh, int dwFileOffsetLow, int dwNumberOfBytesToMap);
        public static IntPtr MapViewOfFile(HandleRef hFileMapping, int dwDesiredAccess, int dwFileOffsetHigh, int dwFileOffsetLow, int dwNumberOfBytesToMap)
        {
            return HandleCollector.Add(IntMapViewOfFile(hFileMapping, dwDesiredAccess, dwFileOffsetHigh, dwFileOffsetLow, dwNumberOfBytesToMap), NativeMethods.CommonHandles.Kernel);
        }
        [DllImport(ExternDll.Kernel32, EntryPoint = "UnmapViewOfFile", ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool IntUnmapViewOfFile(HandleRef pvBaseAddress);
        public static bool UnmapViewOfFile(HandleRef pvBaseAddress)
        {
            HandleCollector.Remove((IntPtr)pvBaseAddress, NativeMethods.CommonHandles.Kernel);
            return IntUnmapViewOfFile(pvBaseAddress);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "GetDCEx", CharSet = CharSet.Auto)]
        private static extern IntPtr IntGetDCEx(HandleRef hWnd, HandleRef hrgnClip, int flags);
        public static IntPtr GetDCEx(HandleRef hWnd, HandleRef hrgnClip, int flags)
        {
            return HandleCollector.Add(IntGetDCEx(hWnd, hrgnClip, flags), NativeMethods.CommonHandles.HDC);
        }
        // GetObject stuff 
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] NativeMethods.BITMAP_CLASS bm);
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(HandleRef hObject, int nSize, ref NativeMethods.BITMAP_STRUCT bm);
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(IntPtr hObject, int nSize, [In, Out] NativeMethods.BITMAP_CLASS bm);
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(IntPtr hObject, int nSize, ref NativeMethods.BITMAP_STRUCT bm);
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] NativeMethods.LOGPEN lp);
        public static int GetObject(HandleRef hObject, NativeMethods.LOGPEN lp)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(NativeMethods.LOGPEN)), lp);
        }
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] NativeMethods.LOGBRUSH lb);
        public static int GetObject(HandleRef hObject, NativeMethods.LOGBRUSH lb)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(NativeMethods.LOGBRUSH)), lb);
        }
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(HandleRef hObject, int nSize, [In, Out] NativeMethods.LOGFONT lf);
        public static int GetObject(HandleRef hObject, NativeMethods.LOGFONT lp)
        {
            return GetObject(hObject, Marshal.SizeOf(typeof(NativeMethods.LOGFONT)), lp);
        }
        //HPALETTE 
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(HandleRef hObject, int nSize, ref int nEntries);
        [DllImport(ExternDll.Gdi32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetObject(HandleRef hObject, int nSize, int[] nEntries);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetObjectType(HandleRef hObject);
        [DllImport(ExternDll.User32, EntryPoint = "CreateAcceleratorTable", CharSet = CharSet.Auto)]
        private static extern IntPtr IntCreateAcceleratorTable(/*ACCEL*/ HandleRef pentries, int cCount);
        public static IntPtr CreateAcceleratorTable(/*ACCEL*/ HandleRef pentries, int cCount)
        {
            return HandleCollector.Add(IntCreateAcceleratorTable(pentries, cCount), NativeMethods.CommonHandles.Accelerator);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "DestroyAcceleratorTable", CharSet = CharSet.Auto)]
        private static extern bool IntDestroyAcceleratorTable(HandleRef hAccel);
        public static bool DestroyAcceleratorTable(HandleRef hAccel)
        {
            HandleCollector.Remove((IntPtr)hAccel, NativeMethods.CommonHandles.Accelerator);
            return IntDestroyAcceleratorTable(hAccel);
        }

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern short VkKeyScan(char key);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetCapture();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetCapture(HandleRef hwnd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        [ResourceExposure(ResourceScope.None)]
        public static extern IntPtr GetFocus();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetCursorPos([In, Out] NativeMethods.POINT pt);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern short GetKeyState(int keyCode);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern uint GetShortPathName(string lpszLongPath, StringBuilder lpszShortPath, uint cchBuffer);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "SetWindowRgn", CharSet = CharSet.Auto)]
        private static extern int IntSetWindowRgn(HandleRef hwnd, HandleRef hrgn, bool fRedraw);
        [DllImport(ExternDll.Gdi32, CharSet = CharSet.Auto)]
        public static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public static int SetWindowRgn(HandleRef hwnd, HandleRef hrgn, bool fRedraw)
        {
            int retval = IntSetWindowRgn(hwnd, hrgn, fRedraw);
            if (retval != 0)
            {
                HandleCollector.Remove((IntPtr)hrgn, NativeMethods.CommonHandles.GDI);
            }
            return retval;
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "SetWindowRgn", CharSet = CharSet.Auto)]
        public static extern int SetWindowRgn(IntPtr hwnd, IntPtr hrgn, bool fRedraw);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(HandleRef hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern void GetTempFileName(string tempDirName, string prefixName, int unique, StringBuilder sb);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(HandleRef hWnd, string text);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SetWindowText(IntPtr hWnd, string text);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GlobalAlloc(int uFlags, int dwBytes);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GlobalReAlloc(HandleRef handle, int bytes, int flags);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GlobalLock(HandleRef handle);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GlobalUnlock(HandleRef handle);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GlobalFree(HandleRef handle);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GlobalSize(HandleRef handle);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern bool ImmSetConversionStatus(HandleRef hIMC, int conversion, int sentence);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern bool ImmGetConversionStatus(HandleRef hIMC, ref int conversion, ref int sentence);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern IntPtr ImmGetContext(HandleRef hWnd);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern bool ImmReleaseContext(HandleRef hWnd, HandleRef hIMC);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern IntPtr ImmAssociateContext(HandleRef hWnd, HandleRef hIMC);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern bool ImmDestroyContext(HandleRef hIMC);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern IntPtr ImmCreateContext();
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern bool ImmSetOpenStatus(HandleRef hIMC, bool open);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern bool ImmGetOpenStatus(HandleRef hIMC);
        [DllImport(ExternDll.Imm32, CharSet = CharSet.Auto)]
        public static extern bool ImmNotifyIME(HandleRef hIMC, int dwAction, int dwIndex, int dwValue);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetFocus(HandleRef hWnd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(HandleRef hWnd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetAncestor(HandleRef hWnd, int flags);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool IsZoomed(HandleRef hWnd);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string className, string windowName);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] ref NativeMethods.RECT rect, int cPoints);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int MapWindowPoints(HandleRef hWndFrom, HandleRef hWndTo, [In, Out] NativeMethods.POINT pt, int cPoints);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, bool wParam, int lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, IntPtr msg, int wParam, int lParam);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, bool lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, PreserveSig = false)]
        public static extern NativeCOM.IRichEditOle SendMessage(IntPtr hWnd, int message, int wParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, ref NativeMethods.TBMETRICS lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int SendMessage(HandleRef hWnd, int message, IntPtr wParam, ref NativeMethods.RBHITTESTINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int SendMessage(HandleRef hWnd, int message, IntPtr wParam, ref Point lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int[] lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int[] wParam, int[] lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, ref int wParam, ref int lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, string lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, string lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, int lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, StringBuilder lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.MARGINS lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.TOOLINFO_T lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.REBARBANDINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.REBARBANDINFO_T lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.REBARINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.TOOLINFO_TOOLTIP lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.TBBUTTON lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.TBBUTTONINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.TV_ITEM lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.TV_INSERTSTRUCT lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, ref NativeMethods.COMBOBOXINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.COMBOBOXINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.TV_HITTESTINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.LVBKIMAGE lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.LVHITTESTINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.TCITEM_T lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.TCITEM lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.HDLAYOUT hdlayout);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, ref int pdwAddr);
        //for Tooltips 
        //
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, HandleRef wParam, int lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, HandleRef lParam);
        // For RichTextBox
        // 
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] NativeMethods.PARAFORMAT lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] NativeMethods.CHARFORMATA lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] NativeMethods.CHARFORMAT2A lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out, MarshalAs(UnmanagedType.LPStruct)] NativeMethods.CHARFORMATW lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int SendMessage(HandleRef hWnd, int msg, int wParam, [Out, MarshalAs(UnmanagedType.IUnknown)]out object editOle);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.CHARRANGE lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.FINDTEXT lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.TEXTRANGE lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.POINT lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, NativeMethods.POINT wParam, int lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.REPASTESPECIAL lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.EDITSTREAM lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.EDITSTREAM64 lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, NativeMethods.GETTEXTLENGTHEX wParam, int lParam);
        // For Button
        // 
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] NativeMethods.SIZE lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, [In, Out] NativeMethods.SIZE lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, ref NativeMethods.LITEM lParam);
        // For ListView
        // 
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, NativeMethods.HDITEM lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.HDITEM lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref NativeMethods.HDHITTESTINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, ref NativeMethods.HDHITTESTINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] ref NativeMethods.LVFINDINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.LVHITTESTINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.LVCOLUMN_T lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] ref NativeMethods.LVITEM lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.LVCOLUMN lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.LVGROUP lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, NativeMethods.POINT wParam, [In, Out] NativeMethods.LVINSERTMARK lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.LVINSERTMARK lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] NativeMethods.LVTILEVIEWINFO lParam);
        // For MonthCalendar
        //
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.MCHITTESTINFO lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, bool wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.SYSTEMTIME lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.SYSTEMTIMEARRAY lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, [In, Out] NativeMethods.LOGFONT lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.MSG lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, NativeMethods.WINDOWPOS lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(HandleRef hWnd, int msg, IntPtr wParam, NativeMethods.WINDOWPOS lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(HandleRef hWnd, int Msg, IntPtr wParam, [In, Out] ref NativeMethods.RECT lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(HandleRef hWnd, int Msg, IntPtr wParam, [In, Out] ref NativeMethods.COMBOBOXEXITEM lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(HandleRef hWnd, int Msg, ref short wParam, ref short lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(HandleRef hWnd, int Msg, [In, Out, MarshalAs(UnmanagedType.Bool)] ref bool wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, [In, Out] ref NativeMethods.RECT lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(HandleRef hWnd, int Msg, int wParam, [In, Out] ref Rectangle lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public extern static IntPtr SendMessage(HandleRef hWnd, int Msg, IntPtr wParam, NativeMethods.ListViewCompareCallback pfnCompare);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam, int flags, int timeout, out IntPtr pdwResult);
        public const int SMTO_ABORTIFHUNG = 0x0002;
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetParent(HandleRef hWnd, HandleRef hWndParent);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetParent(IntPtr hWnd, IntPtr hWndParent);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref NativeMethods.RECT rect);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetWindowRect(IntPtr hWnd, [In, Out] ref NativeMethods.RECT rect);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(HandleRef hWnd, int uCmd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetDlgItem(HandleRef hWnd, int nIDDlgItem);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string modName);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr DefMDIChildProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr CallWindowProc(IntPtr wndProc, IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetProp(HandleRef hWnd, int atom);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr GetProp(HandleRef hWnd, string name);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr RemoveProp(HandleRef hWnd, short atom);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr RemoveProp(HandleRef hWnd, string propName);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern short GlobalDeleteAtom(short atom);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(HandleRef hModule, string lpProcName);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool GetClassInfo(HandleRef hInst, string lpszClass, [In, Out] NativeMethods.WNDCLASS_I wc);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool GetClassInfo(HandleRef hInst, string lpszClass, IntPtr h);
        [DllImport(ExternDll.Shfolder, CharSet = CharSet.Auto)]
        public static extern int SHGetFolderPath(HandleRef hwndOwner, int nFolder, HandleRef hToken, int dwFlags, StringBuilder lpszPath);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetSystemMetrics(int nIndex);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref NativeMethods.RECT rc, int nUpdate);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref int value, int ignore);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref bool value, int ignore);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, ref NativeMethods.HIGHCONTRAST_I rc, int nUpdate);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] NativeMethods.NONCLIENTMETRICS metrics, int nUpdate);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] NativeMethods.ICONMETRICS iconMetrics, int nUpdate);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] NativeMethods.LOGFONT font, int nUpdate);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, bool[] flag, bool nUpdate);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern bool GetComputerName(StringBuilder lpBuffer, int[] nSize);
        [DllImport(ExternDll.Advapi32, CharSet = CharSet.Auto)]
        public static extern bool GetUserName(StringBuilder lpBuffer, int[] nSize);
        [DllImport(ExternDll.User32, ExactSpelling = true)]
        public static extern IntPtr GetProcessWindowStation();
        [DllImport(ExternDll.User32, SetLastError = true)]
        public static extern bool GetUserObjectInformation(HandleRef hObj, int nIndex, [MarshalAs(UnmanagedType.LPStruct)] NativeMethods.USEROBJECTFLAGS pvBuffer, int nLength, ref int lpnLengthNeeded);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int ClientToScreen(HandleRef hWnd, [In, Out] NativeMethods.POINT pt);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int MsgWaitForMultipleObjects(int nCount, IntPtr pHandles, bool fWaitAll, int dwMilliseconds, int dwWakeMask);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport(ExternDll.Ole32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int RegisterDragDrop(HandleRef hwnd, NativeCOM.IOleDropTarget target);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int RevokeDragDrop(HandleRef hwnd);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool PeekMessage([In, Out] ref NativeMethods.MSG msg, HandleRef hwnd, int msgMin, int msgMax, int remove);
        [DllImport(ExternDll.User32, CharSet = CharSet.Unicode)]
        public static extern bool PeekMessageW([In, Out] ref NativeMethods.MSG msg, HandleRef hwnd, int msgMin, int msgMax, int remove);
        [DllImport(ExternDll.User32, CharSet = CharSet.Ansi)]
        public static extern bool PeekMessageA([In, Out] ref NativeMethods.MSG msg, HandleRef hwnd, int msgMin, int msgMax, int remove);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SetProp(HandleRef hWnd, int atom, HandleRef data);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SetProp(HandleRef hWnd, string propName, HandleRef data);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool PostMessage(HandleRef hwnd, int msg, IntPtr wparam, IntPtr lparam);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern short GlobalAddAtom(string atomName);
        [DllImport(ExternDll.Oleacc, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr LresultFromObject(ref Guid refiid, IntPtr wParam, HandleRef pAcc);
        [DllImport(ExternDll.Oleacc, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int CreateStdAccessibleObject(HandleRef hWnd, int objID, ref Guid refiid, [In, Out, MarshalAs(UnmanagedType.Interface)] ref object pAcc);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern void NotifyWinEvent(int winEvent, HandleRef hwnd, int objType, int objID);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetMenuItemID(HandleRef hMenu, int nPos);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetSubMenu(HandleRef hwnd, int index);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetMenuItemCount(HandleRef hMenu);
        [DllImport(ExternDll.Oleaut32, PreserveSig = false)]
        public static extern void GetErrorInfo(int reserved, [In, Out] ref NativeCOM.IErrorInfo errorInfo);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "BeginPaint", CharSet = CharSet.Auto)]
        private static extern IntPtr IntBeginPaint(HandleRef hWnd, [In, Out] ref NativeMethods.PAINTSTRUCT lpPaint);
        public static IntPtr BeginPaint(HandleRef hWnd, [In, Out, MarshalAs(UnmanagedType.LPStruct)] ref NativeMethods.PAINTSTRUCT lpPaint)
        {
            return HandleCollector.Add(IntBeginPaint(hWnd, ref lpPaint), NativeMethods.CommonHandles.HDC);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "EndPaint", CharSet = CharSet.Auto)]
        private static extern bool IntEndPaint(HandleRef hWnd, ref NativeMethods.PAINTSTRUCT lpPaint);
        public static bool EndPaint(HandleRef hWnd, [In, MarshalAs(UnmanagedType.LPStruct)] ref NativeMethods.PAINTSTRUCT lpPaint)
        {
            HandleCollector.Remove(lpPaint.hdc, NativeMethods.CommonHandles.HDC);
            return IntEndPaint(hWnd, ref lpPaint);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "GetDC", CharSet = CharSet.Auto)]
        private static extern IntPtr IntGetDC(HandleRef hWnd);
        public static IntPtr GetDC(HandleRef hWnd)
        {
            return HandleCollector.Add(IntGetDC(hWnd), NativeMethods.CommonHandles.HDC);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "GetWindowDC", CharSet = CharSet.Auto)]
        private static extern IntPtr IntGetWindowDC(HandleRef hWnd);
        public static IntPtr GetWindowDC(HandleRef hWnd)
        {
            return HandleCollector.Add(IntGetWindowDC(hWnd), NativeMethods.CommonHandles.HDC);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "ReleaseDC", CharSet = CharSet.Auto)]
        private static extern int IntReleaseDC(HandleRef hWnd, HandleRef hDC);
        public static int ReleaseDC(HandleRef hWnd, HandleRef hDC)
        {
            HandleCollector.Remove((IntPtr)hDC, NativeMethods.CommonHandles.HDC);
            return IntReleaseDC(hWnd, hDC);
        }

        [DllImport(ExternDll.Gdi32, SetLastError = true, EntryPoint = "CreateDC", CharSet = CharSet.Auto)]
        private static extern IntPtr IntCreateDC(string lpszDriver, string lpszDeviceName, string lpszOutput, HandleRef devMode);
        public static IntPtr CreateDC(string lpszDriver)
        {
            return HandleCollector.Add(IntCreateDC(lpszDriver, null, null, NativeMethods.NullHandleRef), NativeMethods.CommonHandles.HDC);
        }
        public static IntPtr CreateDC(string lpszDriverName, string lpszDeviceName, string lpszOutput, HandleRef /*DEVMODE*/ lpInitData)
        {
            return HandleCollector.Add(IntCreateDC(lpszDriverName, lpszDeviceName, lpszOutput, lpInitData), NativeMethods.CommonHandles.HDC);
        }
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool SystemParametersInfo(int nAction, int nParam, [In, Out] IntPtr[] rc, int nUpdate);
        [DllImport(ExternDll.User32, EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        public extern static IntPtr SendCallbackMessage(HandleRef hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.Shell32, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern void DragAcceptFiles(HandleRef hWnd, bool fAccept);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetDeviceCaps(HandleRef hDC, int nIndex);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetScrollInfo(HandleRef hWnd, int fnBar, NativeMethods.SCROLLINFO si);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SetScrollInfo(HandleRef hWnd, int fnBar, NativeMethods.SCROLLINFO si, bool redraw);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetActiveWindow();
        [DllImport(ExternDll.Mscoree, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int LoadLibraryShim(string dllName, string version, IntPtr reserved, out IntPtr dllModule);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr LoadLibrary(string libname);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern bool FreeLibrary(HandleRef hModule);
        [DllImport(ExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool LoadString(HandleRef hInstance, int uID, StringBuilder lpBuffer, int nBufferMax);
        [DllImport(ExternDll.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool SetDllDirectory(string lpPathName);
        [DllImport(ExternDll.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowsDirectory(StringBuilder lpBuffer, int uSize);
        [DllImport(ExternDll.Kernel32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetDllDirectory(int nBufferLength, StringBuilder lpPathName);
        public static IntPtr GetWindowLong(HandleRef hWnd, int nIndex)
        {
            if (IntPtr.Size == 4)
            {
                return GetWindowLong32(hWnd, nIndex);
            }
            return GetWindowLongPtr64(hWnd, nIndex);
        }
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "GetWindowLong")]
        public static extern IntPtr GetWindowLong32(HandleRef hWnd, int nIndex);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "GetWindowLongPtr")]
        public static extern IntPtr GetWindowLongPtr64(HandleRef hWnd, int nIndex);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
        public static extern IntPtr SetWindowLong(HandleRef hWnd, int nIndex, int dwNewLong);
        public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, HandleRef dwNewLong)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongPtr32(hWnd, nIndex, dwNewLong);
            }
            return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
        }
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, HandleRef dwNewLong);
        public static IntPtr SetWindowLong(HandleRef hWnd, int nIndex, NativeMethods.WndProc wndproc)
        {
            if (IntPtr.Size == 4)
            {
                return SetWindowLongPtr32(hWnd, nIndex, wndproc);
            }
            return SetWindowLongPtr64(hWnd, nIndex, wndproc);
        }
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetWindowLong")]
        public static extern IntPtr SetWindowLongPtr32(HandleRef hWnd, int nIndex, NativeMethods.WndProc wndproc);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr64(HandleRef hWnd, int nIndex, NativeMethods.WndProc wndproc);
        [DllImport(ExternDll.Ole32, PreserveSig = false)]
        public static extern NativeCOM.ILockBytes CreateILockBytesOnHGlobal(HandleRef hGlobal, bool fDeleteOnRelease);
        [DllImport(ExternDll.Ole32, PreserveSig = false)]
        public static extern NativeCOM.IStorage StgCreateDocfileOnILockBytes(NativeCOM.ILockBytes iLockBytes, int grfMode, int reserved);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "CreatePopupMenu", CharSet = CharSet.Auto)]
        public static extern IntPtr CreatePopupMenu();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool RemoveMenu(HandleRef hMenu, int uPosition, int uFlags);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "DestroyMenu", CharSet = CharSet.Auto)]
        private static extern bool IntDestroyMenu(HandleRef hMenu);
        public static bool DestroyMenu(HandleRef hMenu)
        {
            HandleCollector.Remove((IntPtr)hMenu, NativeMethods.CommonHandles.Menu);
            return IntDestroyMenu(hMenu);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetForegroundWindow(HandleRef hWnd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetSystemMenu(HandleRef hWnd, bool bRevert);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr DefFrameProc(IntPtr hWnd, IntPtr hWndClient, int msg, IntPtr wParam, IntPtr lParam);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool TranslateMDISysAccel(IntPtr hWndClient, [In, Out] ref NativeMethods.MSG msg);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetLayeredWindowAttributes(HandleRef hwnd, int crKey, byte bAlpha, int dwFlags);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static bool SetMenu(HandleRef hWnd, HandleRef hMenu);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowPlacement(HandleRef hWnd, ref NativeMethods.WINDOWPLACEMENT placement);
        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern void GetStartupInfo([In, Out] NativeMethods.STARTUPINFO_I startupinfo_i);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetMenuDefaultItem(HandleRef hwnd, int nIndex, bool pos);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool EnableMenuItem(HandleRef hMenu, int UIDEnabledItem, int uEnable);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetActiveWindow(HandleRef hWnd);
        [DllImport(ExternDll.Gdi32, SetLastError = true, EntryPoint = "CreateIC", CharSet = CharSet.Auto)]
        private static extern IntPtr IntCreateIC(string lpszDriverName, string lpszDeviceName, string lpszOutput, HandleRef /*DEVMODE*/ lpInitData);
        public static IntPtr CreateIC(string lpszDriverName, string lpszDeviceName, string lpszOutput, HandleRef /*DEVMODE*/ lpInitData)
        {
            return HandleCollector.Add(IntCreateIC(lpszDriverName, lpszDeviceName, lpszOutput, lpInitData), NativeMethods.CommonHandles.HDC);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool ClipCursor(ref NativeMethods.RECT rcClip);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool ClipCursor(NativeMethods.COMRECT rcClip);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetCursor(HandleRef hcursor);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetCursorPos(int x, int y);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static int ShowCursor(bool bShow);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "DestroyCursor", CharSet = CharSet.Auto)]
        private static extern bool IntDestroyCursor(HandleRef hCurs);
        public static bool DestroyCursor(HandleRef hCurs)
        {
            HandleCollector.Remove((IntPtr)hCurs, NativeMethods.CommonHandles.Cursor);
            return IntDestroyCursor(hCurs);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool IsWindow(HandleRef hWnd);
        public const int LAYOUT_RTL = 0x00000001;
        public const int LAYOUT_BITMAPORIENTATIONPRESERVED = 0x00000008;
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern bool GetMessageA([In, Out] ref NativeMethods.MSG msg, HandleRef hWnd, int uMsgFilterMin, int uMsgFilterMax);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern bool GetMessageW([In, Out] ref NativeMethods.MSG msg, HandleRef hWnd, int uMsgFilterMin, int uMsgFilterMax);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, int msg, int wparam, int lparam);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(HandleRef hwnd, int msg, int wparam, IntPtr lparam);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetClientRect(HandleRef hWnd, [In, Out] ref NativeMethods.RECT rect);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetClientRect(IntPtr hWnd, [In, Out] ref NativeMethods.RECT rect);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetClientRect(IntPtr hWnd, [In, Out] ref Rectangle rect);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetClientRect(HandleRef hWnd, IntPtr rect);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetClientRect(IntPtr hWnd, IntPtr rect);
        [DllImport(ExternDll.User32, EntryPoint = "OffsetRect")]
        public static extern bool OffsetRect(ref NativeMethods.RECT lprc, int dx, int dy);


        [DllImport(ExternDll.User32, EntryPoint = "WindowFromPoint", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr _WindowFromPoint(POINTSTRUCT pt);
        public static IntPtr WindowFromPoint(int x, int y)
        {
            POINTSTRUCT ps = new POINTSTRUCT(x, y);
            return _WindowFromPoint(ps);
        }
        [DllImport(ExternDll.User32, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr WindowFromDC(HandleRef hDC);
        [DllImport(ExternDll.User32, EntryPoint = "CreateWindowEx", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr IntCreateWindowEx(int dwExStyle, string lpszClassName,
                                                   string lpszWindowName, int style, int x, int y, int width, int height,
                                                   HandleRef hWndParent, HandleRef hMenu, HandleRef hInst, [MarshalAs(UnmanagedType.AsAny)] object pvParam);

        [DllImport(ExternDll.User32, EntryPoint = "CreateWindowEx", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr IntCreateWindowEx(int dwExStyle, string lpszClassName,
                                                   string lpszWindowName, int style, int x, int y, int width, int height,
                                                   IntPtr hWndParent, IntPtr hMenu, IntPtr hInst, int pvParam);
        public static IntPtr CreateWindowEx(int dwExStyle, string lpszClassName,
                                      string lpszWindowName, int style, int x, int y, int width, int height,
                                      IntPtr hWndParent, IntPtr hMenu, IntPtr hInst, int pvParam)
        {
            return IntCreateWindowEx(dwExStyle, lpszClassName,
                                         lpszWindowName, style, x, y, width, height, hWndParent, hMenu,
                                         hInst, pvParam);
        }
        public static IntPtr CreateWindowEx(int dwExStyle, string lpszClassName,
                                         string lpszWindowName, int style, int x, int y, int width, int height,
                                         HandleRef hWndParent, HandleRef hMenu, HandleRef hInst, [MarshalAs(UnmanagedType.AsAny)]object pvParam)
        {
            return IntCreateWindowEx(dwExStyle, lpszClassName,
                                         lpszWindowName, style, x, y, width, height, hWndParent, hMenu,
                                         hInst, pvParam);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "DestroyWindow", CharSet = CharSet.Auto)]
        public static extern bool IntDestroyWindow(HandleRef hWnd);
        public static bool DestroyWindow(HandleRef hWnd)
        {
            return IntDestroyWindow(hWnd);
        }
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool UnregisterClass(string className, HandleRef hInstance);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetStockObject(int nIndex);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern short RegisterClass(NativeMethods.WNDCLASS_D wc);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern void PostQuitMessage(int nExitCode);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern void WaitMessage();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowPlacement(HandleRef hWnd, [In] ref NativeMethods.WINDOWPLACEMENT placement);
        // For system power status
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetSystemPowerStatus([In, Out] ref NativeMethods.SYSTEM_POWER_STATUS systemPowerStatus);
        [DllImport(ExternDll.Powrprof, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        //for RegionData
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetRegionData(HandleRef hRgn, int size, IntPtr lpRgnData);
        [DllImport(ExternDll.Ole32)]
        private static extern int OleCreateFromData(NativeCOM.IDataObject pSrcDataObj, [In] ref Guid riid, uint renderopt, ref NativeMethods.FORMATETC pFormatEtc, NativeCOM.IOleClientSite pClientSite, NativeCOM.IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);
        [DllImport(ExternDll.Ole32)]
        public static extern int OleCreateFromFile([In] ref Guid rclsid, [MarshalAs(UnmanagedType.LPWStr)] string lpszFileName, [In] ref Guid riid, uint renderopt, ref NativeMethods.FORMATETC pFormatEtc, NativeCOM.IOleClientSite pClientSite, NativeCOM.IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);
        [DllImport(ExternDll.Ole32)]
        private static extern int OleCreateLinkFromData([MarshalAs(UnmanagedType.Interface)] NativeCOM.IDataObject pSrcDataObj, [In] ref Guid riid, uint renderopt, ref NativeMethods.FORMATETC pFormatEtc, NativeCOM.IOleClientSite pClientSite, NativeCOM.IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);
        [DllImport(ExternDll.Ole32)]
        public static extern int OleCreateStaticFromData([MarshalAs(UnmanagedType.Interface)] NativeCOM.IDataObject pSrcDataObj, [In] ref Guid riid, uint renderopt, ref NativeMethods.FORMATETC pFormatEtc, NativeCOM.IOleClientSite pClientSite, NativeCOM.IStorage pStg, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);
        [DllImport(ExternDll.Ole32)]
        private static extern int OleLoadPicturePath([MarshalAs(UnmanagedType.LPWStr)] string lpszPicturePath, [In, MarshalAs(UnmanagedType.IUnknown)] object pIUnknown, uint dwReserved, uint clrReserved, ref Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppvObj);
        [DllImport(ExternDll.Ole32)]
        public static extern int OleSetContainedObject([MarshalAs(UnmanagedType.IUnknown)] object pUnk, bool fContained);
        public unsafe static NativeMethods.RECT[] GetRectsFromRegion(IntPtr hRgn)
        {
            NativeMethods.RECT[] regionRects = null;
            IntPtr pBytes = IntPtr.Zero;
            try
            {
                int regionDataSize = GetRegionData(new HandleRef(null, hRgn), 0, IntPtr.Zero);
                if (regionDataSize != 0)
                {
                    pBytes = Marshal.AllocCoTaskMem(regionDataSize);
                    // get the data 
                    int ret = GetRegionData(new HandleRef(null, hRgn), regionDataSize, pBytes);
                    if (ret == regionDataSize)
                    {
                        // cast to the structure 
                        NativeMethods.RGNDATAHEADER* pRgnDataHeader = (NativeMethods.RGNDATAHEADER*)pBytes;
                        if (pRgnDataHeader->iType == 1)
                        {    // expecting RDH_RECTANGLES 
                            regionRects = new NativeMethods.RECT[pRgnDataHeader->nCount];

                            Debug.Assert(regionDataSize == pRgnDataHeader->cbSizeOfStruct + pRgnDataHeader->nCount * pRgnDataHeader->nRgnSize);
                            Debug.Assert(Marshal.SizeOf(typeof(NativeMethods.RECT)) == pRgnDataHeader->nRgnSize || pRgnDataHeader->nRgnSize == 0);

                            // use the header size as the offset, and cast each rect in. 
                            int rectStart = pRgnDataHeader->cbSizeOfStruct;
                            for (int i = 0; i < pRgnDataHeader->nCount; i++)
                            {
                                // use some fancy pointer math to just copy the rect bits directly into the array. 
                                regionRects[i] = *((NativeMethods.RECT*)((byte*)pBytes + rectStart + (Marshal.SizeOf(typeof(NativeMethods.RECT)) * i)));
                            }
                        }
                    }
                }
            }
            finally
            {
                if (pBytes != IntPtr.Zero)
                {
                    Marshal.FreeCoTaskMem(pBytes);
                }
            }
            return regionRects;
        }
        public static bool UseVisualStyles()
        {
            string assemblyLoc = null;
            bool useVisualStyles = false;
            FileIOPermission fiop = new FileIOPermission(PermissionState.None);
            fiop.AllFiles = FileIOPermissionAccess.PathDiscovery;
            fiop.Assert();
            try
            {
                assemblyLoc = typeof(Application).Assembly.Location;
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }

            if (assemblyLoc != null)
            {
                useVisualStyles = NativeCOM.ThemingScope.CreateActivationContext(assemblyLoc, 101);
            }
            return useVisualStyles;
        }
        public enum EXTENDED_NAME_FORMAT
        {
            NameUnknown = 0,
            NameFullyQualifiedDN = 1,
            NameSamCompatible = 2,
            NameDisplay = 3,
            NameUniqueId = 6,
            NameCanonical = 7,
            NameUserPrincipal = 8,
            NameCanonicalEx = 9,
            NameServicePrincipal = 10
        }
        [DllImport(ExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool InsertMenu(HandleRef hmenu, int uPosition, NativeMethods.MF uflags, int uIDNewItem,
            [MarshalAs(UnmanagedType.LPTStr)]
            string lpNewItem);
        //Shell32
        [DllImport(ExternDll.Shell32, EntryPoint = "SHGetFileInfo", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, ref NativeMethods.SHFILEINFO psfi, int cbFileInfo, NativeMethods.SHGFI uFlags);
        [DllImport(ExternDll.Shell32, EntryPoint = "SHGetFileInfo", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SHGetFileInfo(IntPtr pszPath, int dwFileAttributes, ref NativeMethods.SHFILEINFO psfi, int cbFileInfo, NativeMethods.SHGFI uFlags);
        [DllImport(ExternDll.Shell32)]
        public static extern bool SHGetPathFromIDList(IntPtr pidl, StringBuilder pszPath);
        [DllImport(ExternDll.Shell32)]
        public static extern Int32 SHGetFolderPath(IntPtr hwndOwner, int nFolder, IntPtr hToken, int dwFlags, StringBuilder pszPath);
        [DllImport(ExternDll.Shell32)]
        public static extern Int32 SHGetSpecialFolderLocation(IntPtr hwndOwner, int nFolder, out IntPtr ppidl);
        [DllImport(ExternDll.Shell32)]
        public static extern Int32 SHBindToParent(IntPtr pidl, ref Guid riid, out IntPtr ppv, out IntPtr ppidlLast);
        [DllImport(ExternDll.Shell32)]
        public static extern Int32 SHGetRealIDL(IntPtr psf, IntPtr pidlSimple, out IntPtr ppidlReal);
        [DllImport(ExternDll.Shell32)]
        public static extern Int32 SHGetRealIDL(NativeCOM.IShellFolder psf, IntPtr pidlSimple, out IntPtr ppidlReal);
        [DllImport(ExternDll.Shell32)]
        public static extern Int32 SHGetDesktopFolder(out IntPtr ppshf);
        [DllImport(ExternDll.Shlwapi, CharSet = CharSet.Auto)]
        public static extern Int32 StrRetToBuf(IntPtr pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);
        [DllImport(ExternDll.Shlwapi, CharSet = CharSet.Auto)]
        public static extern Int32 StrRetToBuf(ref NativeMethods.STRRET pstr, IntPtr pidl, StringBuilder pszBuf, int cchBuf);

        [DllImport("shlwapi.dll")]
        public static extern int SHAutoComplete(HandleRef hwndEdit, int flags);

        [DllImport(ExternDll.Gdi32)]
        public static extern int GetSystemPaletteEntries(HandleRef hdc, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport(ExternDll.Gdi32)]
        public static extern int GetDIBits(HandleRef hdc, HandleRef hbm, int uStartScan, int cScanLines, byte[] lpvBits, ref NativeMethods.BITMAPINFO_FLAT bmi, int uUsage);
        [DllImport(ExternDll.Gdi32)]
        public static extern int GetDIBits(HandleRef hdc, HandleRef hbm, int uStartScan, int cScanLines, IntPtr lpvBits, ref NativeMethods.BITMAPINFO_FLAT bmi, int uUsage);
        [DllImport(ExternDll.Gdi32)]
        public static extern int StretchDIBits(HandleRef hdc, int XDest, int YDest, int nDestWidth, int nDestHeight, int XSrc, int YSrc, int nSrcWidth, int nSrcHeight, byte[] lpBits, ref NativeMethods.BITMAPINFO_FLAT lpBitsInfo, int iUsage, int dwRop);

        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateCompatibleBitmap", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateCompatibleBitmap(HandleRef hDC, int width, int height);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool IsAccelerator(HandleRef hAccel, int cAccelEntries, [In] ref NativeMethods.MSG lpMsg, short[] lpwCmd);
        [DllImport(ExternDll.Comdlg32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool ChooseFont([In, Out] NativeMethods.CHOOSEFONT cf);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetBitmapBits(HandleRef hbmp, int cbBuffer, byte[] lpvBits);
        [DllImport(ExternDll.Comdlg32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int CommDlgExtendedError();
        [DllImport(ExternDll.Oleaut32, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern void SysFreeString(HandleRef bstr);

        [DllImport(ExternDll.Oleaut32, PreserveSig = false)]
        public static extern void OleCreatePropertyFrame(HandleRef hwndOwner, int x, int y, [MarshalAs(UnmanagedType.LPWStr)]string caption, int objects, [MarshalAs(UnmanagedType.Interface)] ref object pobjs, int pages, HandleRef pClsid, int locale, int reserved1, IntPtr reserved2);
        [DllImport(ExternDll.Oleaut32, PreserveSig = false)]
        public static extern void OleCreatePropertyFrame(HandleRef hwndOwner, int x, int y, [MarshalAs(UnmanagedType.LPWStr)]string caption, int objects, [MarshalAs(UnmanagedType.Interface)] ref object pobjs, int pages, Guid[] pClsid, int locale, int reserved1, IntPtr reserved2);
        [DllImport(ExternDll.Oleaut32, PreserveSig = false)]
        public static extern void OleCreatePropertyFrame(HandleRef hwndOwner, int x, int y, [MarshalAs(UnmanagedType.LPWStr)]string caption, int objects, HandleRef lplpobjs, int pages, HandleRef pClsid, int locale, int reserved1, IntPtr reserved2);
        [DllImport(ExternDll.Hhctrl, CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)]string pszFile, int uCommand, int dwData);
        [DllImport(ExternDll.Hhctrl, CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)]string pszFile, int uCommand, string dwData);
        [DllImport(ExternDll.Hhctrl, CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)]string pszFile, int uCommand, [MarshalAs(UnmanagedType.LPStruct)]NativeMethods.HH_POPUP dwData);
        [DllImport(ExternDll.Hhctrl, CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)]string pszFile, int uCommand, [MarshalAs(UnmanagedType.LPStruct)]NativeMethods.HH_FTS_QUERY dwData);
        [DllImport(ExternDll.Hhctrl, CharSet = CharSet.Auto)]
        public static extern int HtmlHelp(HandleRef hwndCaller, [MarshalAs(UnmanagedType.LPTStr)]string pszFile, int uCommand, [MarshalAs(UnmanagedType.LPStruct)]NativeMethods.HH_AKLINK dwData);
        [DllImport(ExternDll.Oleaut32, PreserveSig = false)]
        public static extern void VariantInit(HandleRef pObject);
        [DllImport(ExternDll.Oleaut32, PreserveSig = false)]
        public static extern void VariantClear(HandleRef pObject);

        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool LineTo(HandleRef hdc, int x, int y);

        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool MoveToEx(HandleRef hdc, int x, int y, NativeMethods.POINT pt);

        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool Rectangle(
                                           HandleRef hdc, int left, int top, int right, int bottom);

        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool PatBlt(HandleRef hdc, int left, int top, int width, int height, int rop);
        [DllImport(ExternDll.Kernel32, EntryPoint = "GetThreadLocale", CharSet = CharSet.Auto)]
        public static extern int GetThreadLCID();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetMessagePos();



        [DllImport(ExternDll.User32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int RegisterClipboardFormat(string format);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int GetClipboardFormatName(int format, StringBuilder lpString, int cchMax);

        [DllImport(ExternDll.Comdlg32, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool ChooseColor([In, Out] NativeMethods.CHOOSECOLOR cc);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int RegisterWindowMessage(string msg);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "DeleteObject", CharSet = CharSet.Auto)]
        public static extern bool ExternalDeleteObject(HandleRef hObject);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "DeleteObject", CharSet = CharSet.Auto)]
        public static extern bool DeleteObject(HandleRef hObject);

        [DllImport(ExternDll.Oleaut32, EntryPoint = "OleCreateFontIndirect", ExactSpelling = true, PreserveSig = false)]
        public static extern NativeCOM.IFontDisp OleCreateIFontDispIndirect(NativeMethods.FONTDESC fd, ref Guid iid);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowExtEx(HandleRef hDC, int x, int y, [In, Out] NativeMethods.SIZE size);

        [DllImport(ExternDll.Kernel32, CharSet = CharSet.Auto)]
        public static extern int FormatMessage(int dwFlags, HandleRef lpSource, int dwMessageId,
                                               int dwLanguageId, StringBuilder lpBuffer, int nSize, HandleRef arguments);


        [DllImport(ExternDll.Comctl32)]
        public static extern void InitCommonControls();

        [DllImport(ExternDll.Comctl32)]
        public static extern bool InitCommonControlsEx(NativeMethods.INITCOMMONCONTROLSEX icc);

        [DllImport(ExternDll.Comctl32)]
        public static extern IntPtr ImageList_Create(int cx, int cy, int flags, int cInitial, int cGrow);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_BeginDrag(HandleRef himlTrack, int iTrack, int dxHotspot, int dyHotspot);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_DragEnter(HandleRef hwndLock, int x, int y);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_DragLeave(HandleRef hwndLock);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_DragMove(int x, int y);
        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_EndDrag();

        [DllImport(ExternDll.Comctl32)]
        public static extern bool ImageList_Destroy(HandleRef himl);
        [DllImport(ExternDll.Comctl32)]
        public static extern IntPtr ImageList_Duplicate(HandleRef himl);
        [DllImport(ExternDll.Comctl32)]
        public static extern IntPtr ImageList_Read(NativeCOM.IStream pstm);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr TrackPopupMenuEx(HandleRef hmenu, int fuFlags, int x, int y, HandleRef hwnd, NativeMethods.TPMPARAMS tpm);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr TrackPopupMenuEx(IntPtr hmenu, int fuFlags, int x, int y, IntPtr hwnd, IntPtr tpm);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetKeyboardLayout(int dwLayout);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr ActivateKeyboardLayout(HandleRef hkl, int uFlags);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetKeyboardLayoutList(int size, [Out, MarshalAs(UnmanagedType.LPArray)] IntPtr[] hkls);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref NativeMethods.DEVMODE lpDevMode);

        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern bool GetMonitorInfo(HandleRef hmonitor, [In, Out]NativeMethods.MONITORINFOEX info);
        [DllImport(ExternDll.User32, ExactSpelling = true)]
        public static extern IntPtr MonitorFromPoint(NativeMethods.POINTSTRUCT pt, int flags);
        [DllImport(ExternDll.User32, ExactSpelling = true)]
        public static extern IntPtr MonitorFromRect(ref NativeMethods.RECT rect, int flags);
        [DllImport(ExternDll.User32, ExactSpelling = true)]
        public static extern IntPtr MonitorFromWindow(HandleRef handle, int flags);
        [DllImport(ExternDll.User32, ExactSpelling = true)]
        public static extern bool EnumDisplayMonitors(HandleRef hdc, NativeMethods.COMRECT rcClip, NativeMethods.MonitorEnumProc lpfnEnum, IntPtr dwData);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateHalftonePalette", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateHalftonePalette(HandleRef hdc);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetPaletteEntries(HandleRef hpal, int iStartIndex, int nEntries, int[] lppe);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetPaletteEntries(HandleRef hpal, int iStartIndex, int nEntries, byte[] lppe);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GetTextMetricsW(HandleRef hDC, [In, Out] ref NativeMethods.TEXTMETRIC lptm);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Ansi)]
        public static extern int GetTextMetricsA(HandleRef hDC, [In, Out] ref NativeMethods.TEXTMETRICA lptm);
        public static int GetTextMetrics(HandleRef hDC, ref NativeMethods.TEXTMETRIC lptm)
        {
            if (Marshal.SystemDefaultCharSize == 1)
            {
                // ANSI 
                NativeMethods.TEXTMETRICA lptmA = new NativeMethods.TEXTMETRICA();
                int retVal = GetTextMetricsA(hDC, ref lptmA);
                lptm.tmHeight = lptmA.tmHeight;
                lptm.tmAscent = lptmA.tmAscent;
                lptm.tmDescent = lptmA.tmDescent;
                lptm.tmInternalLeading = lptmA.tmInternalLeading;
                lptm.tmExternalLeading = lptmA.tmExternalLeading;
                lptm.tmAveCharWidth = lptmA.tmAveCharWidth;
                lptm.tmMaxCharWidth = lptmA.tmMaxCharWidth;
                lptm.tmWeight = lptmA.tmWeight;
                lptm.tmOverhang = lptmA.tmOverhang;
                lptm.tmDigitizedAspectX = lptmA.tmDigitizedAspectX;
                lptm.tmDigitizedAspectY = lptmA.tmDigitizedAspectY;
                lptm.tmFirstChar = (char)lptmA.tmFirstChar;
                lptm.tmLastChar = (char)lptmA.tmLastChar;
                lptm.tmDefaultChar = (char)lptmA.tmDefaultChar;
                lptm.tmBreakChar = (char)lptmA.tmBreakChar;
                lptm.tmItalic = lptmA.tmItalic;
                lptm.tmUnderlined = lptmA.tmUnderlined;
                lptm.tmStruckOut = lptmA.tmStruckOut;
                lptm.tmPitchAndFamily = lptmA.tmPitchAndFamily;
                lptm.tmCharSet = lptmA.tmCharSet;

                return retVal;
            }
            else
            {
                // Unicode 
                return GetTextMetricsW(hDC, ref lptm);
            }
        }
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateDIBSection", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateDIBSection(HandleRef hdc, HandleRef pbmi, int iUsage, byte[] ppvBits, IntPtr hSection, int dwOffset);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateDIBSection", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateDIBSection(HandleRef hdc, ref NativeMethods.BITMAPINFO_FLAT pbmi, int iUsage, ref IntPtr ppvBits, IntPtr hSection, int dwOffset);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateBitmap", CharSet = CharSet.Auto)]
        private static extern IntPtr /*HBITMAP*/ CreateBitmap(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, IntPtr lpvBits);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateBitmap", CharSet = CharSet.Auto)]
        private static extern IntPtr /*HBITMAP*/ CreateBitmapShort(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, short[] lpvBits);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateBitmap", CharSet = CharSet.Auto)]
        private static extern IntPtr /*HBITMAP*/ CreateBitmapByte(int nWidth, int nHeight, int nPlanes, int nBitsPerPixel, byte[] lpvBits);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreatePatternBrush", CharSet = CharSet.Auto)]
        private static extern IntPtr /*HBRUSH*/CreatePatternBrush(HandleRef hbmp);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateBrushIndirect", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateBrushIndirect(NativeMethods.LOGBRUSH lb);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursor(HandleRef hInst, int iconId);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static bool GetClipCursor([In, Out] ref NativeMethods.RECT lpRect);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetCursor();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetIconInfo(HandleRef hIcon, [In, Out] NativeMethods.ICONINFO info);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int IntersectClipRect(HandleRef hDC, int x1, int y1, int x2, int y2);
        [DllImport(ExternDll.User32, ExactSpelling = true, EntryPoint = "CopyImage", CharSet = CharSet.Auto)]
        public static extern IntPtr CopyImage(HandleRef hImage, int uType, int cxDesired, int cyDesired, int fuFlags);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool AdjustWindowRectEx(ref NativeMethods.RECT lpRect, int dwStyle, bool bMenu, int dwExStyle);
        [DllImport(ExternDll.Ole32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int DoDragDrop(IComDataObject dataObject, NativeCOM.IOleDropSource dropSource, int allowedEffects, int[] finalEffect);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetSysColorBrush(int nIndex);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool EnableWindow(HandleRef hWnd, bool enable);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetDoubleClickTime();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetUpdateRgn(HandleRef hwnd, HandleRef hrgn, bool fErase);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool ValidateRect(HandleRef hWnd, [In, Out] ref NativeMethods.RECT rect);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static int GetLastError();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int FillRect(HandleRef hdc, [In] ref NativeMethods.RECT rect, HandleRef hbrush);
        [DllImport(ExternDll.Gdi32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int /*COLORREF*/ GetTextColor(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetBkColor(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int /*COLORREF*/ SetTextColor(HandleRef hDC, int crColor);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SetBkColor(HandleRef hDC, int clr);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr /* HPALETTE */SelectPalette(HandleRef hdc, HandleRef hpal, int bForceBackground);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetViewportOrgEx(HandleRef hDC, int x, int y, [In, Out] NativeMethods.POINT point);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, EntryPoint = "CreateRectRgn", CharSet = CharSet.Auto)]
        public static extern IntPtr CreateRectRgn(int x1, int y1, int x2, int y2);
        [DllImport(ExternDll.Gdi32, EntryPoint = "RoundRect")]
        public static extern bool RoundRect(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidth, int nHeight);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int CombineRgn(HandleRef hRgn, HandleRef hRgn1, HandleRef hRgn2, int nCombineMode);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int RealizePalette(HandleRef hDC);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool LPtoDP(HandleRef hDC, [In, Out] ref NativeMethods.RECT lpRect, int nCount);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowOrgEx(HandleRef hDC, int x, int y, [In, Out] NativeMethods.POINT point);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetViewportOrgEx(HandleRef hDC, [In, Out] NativeMethods.POINT point);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool IsWindowEnabled(HandleRef hWnd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool IsWindowVisible(HandleRef hWnd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetCurrentThreadId();
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(EnumThreadWindowsCallback callback, IntPtr extraData);
        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(HandleRef hWnd, int lpdwProcessId);
        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool GetExitCodeThread(HandleRef hWnd, out int lpdwExitCode);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool ShowWindow(HandleRef hWnd, int nCmdShow);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool SetWindowPos(HandleRef hWnd, HandleRef hWndInsertAfter, int x, int y, int cx, int cy, int flags);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(HandleRef hWnd);
        [DllImport(ExternDll.Comctl32, ExactSpelling = true)]
        private static extern bool _TrackMouseEvent(NativeMethods.TRACKMOUSEEVENT tme);
        public static bool TrackMouseEvent(NativeMethods.TRACKMOUSEEVENT tme)
        {
            return _TrackMouseEvent(tme);
        }
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool RedrawWindow(HandleRef hwnd, ref NativeMethods.RECT rcUpdate, HandleRef hrgnUpdate, int flags);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool RedrawWindow(HandleRef hwnd, NativeMethods.COMRECT rcUpdate, HandleRef hrgnUpdate, int flags);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(HandleRef hWnd, ref NativeMethods.RECT rect, bool erase);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool InvalidateRect(HandleRef hWnd, NativeMethods.COMRECT rect, bool erase);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool InvalidateRgn(HandleRef hWnd, HandleRef hrgn, bool erase);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool UpdateWindow(HandleRef hWnd);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetCurrentProcessId();
        [DllImport(ExternDll.User32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int ScrollWindowEx(HandleRef hWnd, int nXAmount, int nYAmount, NativeMethods.COMRECT rectScrollRegion, ref NativeMethods.RECT rectClip, HandleRef hrgnUpdate, ref NativeMethods.RECT prcUpdate, int flags);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetThreadLocale();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool MessageBeep(int type);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool DrawMenuBar(HandleRef hWnd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static bool IsChild(HandleRef parent, HandleRef child);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SetTimer(HandleRef hWnd, int nIDEvent, int uElapse, IntPtr lpTimerFunc);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool KillTimer(HandleRef hwnd, int idEvent);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern int MessageBox(HandleRef hWnd, string text, string caption, int type);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SelectObject(HandleRef hDC, HandleRef hObject);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetTickCount();
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool ScrollWindow(HandleRef hWnd, int nXAmount, int nYAmount, ref NativeMethods.RECT rectScrollRegion, ref NativeMethods.RECT rectClip);
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetCurrentProcess();
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetCurrentThread();
        [DllImport(ExternDll.Kernel32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public extern static bool SetThreadLocale(int Locale);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool IsWindowUnicode(HandleRef hWnd);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool DrawEdge(HandleRef hDC, ref NativeMethods.RECT rect, int edge, int flags);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool DrawFrameControl(HandleRef hDC, ref NativeMethods.RECT rect, int type, int state);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetClipRgn(HandleRef hDC, HandleRef hRgn);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int GetRgnBox(HandleRef hRegion, ref NativeMethods.RECT clipRect);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SelectClipRgn(HandleRef hDC, HandleRef hRgn);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern int SetROP2(HandleRef hDC, int nDrawMode);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool DrawIcon(HandleRef hDC, int x, int y, HandleRef hIcon);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool DrawIconEx(HandleRef hDC, int x, int y, HandleRef hIcon, int width, int height, int iStepIfAniCursor, HandleRef hBrushFlickerFree, int diFlags);
        [DllImport(ExternDll.Gdi32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool BitBlt(HandleRef hDC, int x, int y, int nWidth, int nHeight, HandleRef hSrcDC, int xSrc, int ySrc, int dwRop);
        [DllImport(ExternDll.User32, ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern bool ShowCaret(HandleRef hWnd);
        [DllImport(ExternDll.User32, CharSet = CharSet.Auto)]
        public static extern uint GetCaretBlinkTime();
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern bool IsAppThemed();
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeAppProperties();
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern void SetThemeAppProperties(int Flags);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern IntPtr OpenThemeData(HandleRef hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszClassList);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int CloseThemeData(HandleRef hTheme);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetCurrentThemeName(StringBuilder pszThemeFileName, int dwMaxNameChars, StringBuilder pszColorBuff, int dwMaxColorChars, StringBuilder pszSizeBuff, int cchMaxSizeChars);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern bool IsThemePartDefined(HandleRef hTheme, int iPartId, int iStateId);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int DrawThemeBackground(HandleRef hTheme, HandleRef hdc, int partId, int stateId, [In] NativeMethods.COMRECT pRect, [In] NativeMethods.COMRECT pClipRect);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int DrawThemeEdge(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethods.COMRECT pDestRect, int uEdge, int uFlags, [Out] NativeMethods.COMRECT pContentRect);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int DrawThemeParentBackground(HandleRef hwnd, HandleRef hdc, [In] NativeMethods.COMRECT prc);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int DrawThemeText(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [MarshalAs(UnmanagedType.LPWStr)] string pszText, int iCharCount, int dwTextFlags, int dwTextFlags2, [In] NativeMethods.COMRECT pRect);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeBackgroundContentRect(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethods.COMRECT pBoundingRect, [Out] NativeMethods.COMRECT pContentRect);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeBackgroundExtent(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethods.COMRECT pContentRect, [Out] NativeMethods.COMRECT pExtentRect);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeBackgroundRegion(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethods.COMRECT pRect, ref IntPtr pRegion);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeBool(HandleRef hTheme, int iPartId, int iStateId, int iPropId, ref bool pfVal);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeColor(HandleRef hTheme, int iPartId, int iStateId, int iPropId, ref int pColor);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeEnumValue(HandleRef hTheme, int iPartId, int iStateId, int iPropId, ref int piVal);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeFilename(HandleRef hTheme, int iPartId, int iStateId, int iPropId, StringBuilder pszThemeFilename, int cchMaxBuffChars);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeFont(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, int iPropId, NativeMethods.LOGFONT pFont);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeInt(HandleRef hTheme, int iPartId, int iStateId, int iPropId, ref int piVal);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemePartSize(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [In] NativeMethods.COMRECT prc, System.Windows.Forms.VisualStyles.ThemeSizeType eSize, [Out] NativeMethods.SIZE psz);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemePosition(HandleRef hTheme, int iPartId, int iStateId, int iPropId, [Out] NativeMethods.POINT pPoint);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeMargins(HandleRef hTheme, HandleRef hDC, int iPartId, int iStateId, int iPropId, ref NativeMethods.MARGINS margins);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeString(HandleRef hTheme, int iPartId, int iStateId, int iPropId, StringBuilder pszBuff, int cchMaxBuffChars);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeDocumentationProperty([MarshalAs(UnmanagedType.LPWStr)] string pszThemeName, [MarshalAs(UnmanagedType.LPWStr)] string pszPropertyName, StringBuilder pszValueBuff, int cchMaxValChars);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeTextExtent(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, [MarshalAs(UnmanagedType.LPWStr)] string pszText, int iCharCount, int dwTextFlags, [In] NativeMethods.COMRECT pBoundingRect, [Out] NativeMethods.COMRECT pExtentRect);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeTextMetrics(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, ref System.Windows.Forms.VisualStyles.TextMetrics ptm);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int HitTestThemeBackground(HandleRef hTheme, HandleRef hdc, int iPartId, int iStateId, int dwOptions, [In] NativeMethods.COMRECT pRect, HandleRef hrgn, [In] NativeMethods.POINTSTRUCT ptTest, ref int pwHitTestCode);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern bool IsThemeBackgroundPartiallyTransparent(HandleRef hTheme, int iPartId, int iStateId);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern bool GetThemeSysBool(HandleRef hTheme, int iBoolId);
        [DllImport(ExternDll.Uxtheme, CharSet = CharSet.Auto)]
        public static extern int GetThemeSysInt(HandleRef hTheme, int iIntId, ref int piValue);
        public static int RGBToCOLORREF(int rgbValue)
        {
            int bValue = (rgbValue & 0xFF) << 16;
            rgbValue &= 0xFFFF00;
            rgbValue |= ((rgbValue >> 16) & 0xFF);
            rgbValue &= 0x00FFFF;
            rgbValue |= bValue;
            return rgbValue;
        }
        public static Color ColorFromCOLORREF(int colorref)
        {
            int r = colorref & 0xFF;
            int g = (colorref >> 8) & 0xFF;
            int b = (colorref >> 16) & 0xFF;
            return Color.FromArgb(r, g, b);
        }
        public static int ColorToCOLORREF(Color color)
        {
            return (int)color.R | ((int)color.G << 8) | ((int)color.B << 16);
        }


        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdiplusStartup(out IntPtr token, ref NativeMethods.GdiplusStartupInput input, out NativeMethods.GdiplusStartupOutput output);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern void GdiplusShutdown(HandleRef token);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipCreatePath(int brushMode, out IntPtr path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipCreatePath2(HandleRef points, HandleRef types, int count, int brushMode, out IntPtr path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipCreatePath2I(HandleRef points, HandleRef types, int count, int brushMode, out IntPtr path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipClonePath(HandleRef path, out IntPtr clonepath);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipResetPath(HandleRef path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipGetPointCount(HandleRef path, out int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipGetPathTypes(HandleRef path, byte[] types, int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipGetPathPoints(HandleRef path, HandleRef points, int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipGetPathFillMode(HandleRef path, out int fillmode);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipSetPathFillMode(HandleRef path, int fillmode);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipGetPathData(HandleRef path, IntPtr pathData);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipStartPathFigure(HandleRef path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipClosePathFigure(HandleRef path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipClosePathFigures(HandleRef path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipSetPathMarker(HandleRef path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipClearPathMarkers(HandleRef path);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipReversePath(HandleRef path);
        //[DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] 
        //public static extern int GdipGetPathLastPoint(HandleRef path, GPPOINTF lastPoint);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathLine(HandleRef path, float x1, float y1, float x2, float y2);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathLine2(HandleRef path, HandleRef memorypts, int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathArc(HandleRef path, float x, float y, float width, float height, float startAngle, float sweepAngle);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathBezier(HandleRef path, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathBeziers(HandleRef path, HandleRef memorypts, int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathCurve(HandleRef path, HandleRef memorypts, int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathCurve2(HandleRef path, HandleRef memorypts, int count, float tension);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathCurve3(HandleRef path, HandleRef memorypts, int count, int offset, int numberOfSegments, float tension);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathClosedCurve(HandleRef path, HandleRef memorypts, int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathClosedCurve2(HandleRef path, HandleRef memorypts, int count, float tension);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathRectangle(HandleRef path, float x, float y, float width, float height);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathRectangles(HandleRef path, HandleRef rects, int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathEllipse(HandleRef path, float x, float y, float width, float height);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathPie(HandleRef path, float x, float y, float width, float height, float startAngle, float sweepAngle);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathPolygon(HandleRef path, HandleRef memorypts, int count);
        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathPath(HandleRef path, HandleRef addingPath, bool connect);
        //[DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] 
        //public static extern int GdipAddPathString(HandleRef path, string s, int length,HandleRef fontFamily, int style, float emSize,
        //                                             ref GPRECTF layoutRect, HandleRef format);

        //[DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        //public static extern int GdipAddPathStringI(HandleRef path, string s, int length,
        //                                              HandleRef fontFamily, int style, float emSize,
        //                                              ref GPRECT layoutRect, HandleRef format);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathLineI(HandleRef path, int x1, int y1, int x2,
                                                    int y2);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathLine2I(HandleRef path, HandleRef memorypts, int count);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern int GdipAddPathArcI(HandleRef path, int x, int y, int width,
                                                   int height, float startAngle,
                                                   float sweepAngle);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode 
        public static extern int GdipAddPathBezierI(HandleRef path, int x1, int y1, int x2,
                                                      int y2, int x3, int y3, int x4,
                                                      int y4);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathBeziersI(HandleRef path, HandleRef memorypts, int count);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathCurveI(HandleRef path, HandleRef memorypts, int count);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathCurve2I(HandleRef path, HandleRef memorypts, int count,
                                                      float tension);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode 
        public static extern int GdipAddPathCurve3I(HandleRef path, HandleRef memorypts, int count,
                                                      int offset, int numberOfSegments,
                                                      float tension);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathClosedCurveI(HandleRef path, HandleRef memorypts,
                                                           int count);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode 
        public static extern int GdipAddPathClosedCurve2I(HandleRef path, HandleRef memorypts,
                                                            int count, float tension);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathRectangleI(HandleRef path, int x, int y, int width,
                                                         int height);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathRectanglesI(HandleRef path, HandleRef rects, int count);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathEllipseI(HandleRef path, int x, int y,
                                                       int width, int height);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathPieI(HandleRef path, int x, int y, int width,
                                                   int height, float startAngle,
                                                   float sweepAngle);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipAddPathPolygonI(HandleRef path, HandleRef memorypts, int count);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipFlattenPath(HandleRef path, HandleRef matrixfloat, float flatness);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipWidenPath(HandleRef path, HandleRef pen, HandleRef matrix, float flatness);

        //[DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        //public static extern int GdipWarpPath(HandleRef path, HandleRef matrix, HandleRef points, int count,
        //                                        float srcX, float srcY, float srcWidth, float srcHeight,
        //                                        WarpMode warpMode, float flatness);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode 
        public static extern int GdipTransformPath(HandleRef path, HandleRef matrix);

        //[DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode 
        //public static extern int GdipGetPathWorldBounds(HandleRef path, ref GPRECTF gprectf, HandleRef matrix, HandleRef pen);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipIsVisiblePathPoint(HandleRef path, float x, float y,
                                                          HandleRef graphics, out int boolean);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode
        public static extern int GdipIsVisiblePathPointI(HandleRef path, int x, int y,
                                                           HandleRef graphics, out int boolean);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode 
        public static extern int GdipIsOutlineVisiblePathPoint(HandleRef path, float x, float y, HandleRef pen,
                                                                 HandleRef graphics, out int boolean);

        [DllImport(ExternDll.Gdiplus, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)] // 3 = Unicode 
        public static extern int GdipIsOutlineVisiblePathPointI(HandleRef path, int x, int y, HandleRef pen,
                                                                  HandleRef graphics, out int boolean);
    }
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void TIMECALLBACK(uint uTimerID, uint uMsg, uint dwUser, uint dw1, uint dw2);
}
