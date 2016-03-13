using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;

namespace Windows.SystemControl
{
    public class MenuHook
    {
        private IntPtr hWnd = IntPtr.Zero;
        private IntPtr hMenuHook = IntPtr.Zero;
        private NativeMethods.WindowsHookProc callHookProc = null;
        private TMenuWindow menuWindow = null;

        public MenuHook(IntPtr hWnd)
        {
            this.hWnd = hWnd;
        }

        public void BeginHook()
        {
            if (hMenuHook == IntPtr.Zero)
            {
                callHookProc = new NativeMethods.WindowsHookProc(CallHookProc);
                hMenuHook = UnsafeNativeMethods.SetWindowsHookEx(NativeMethods.WH_CALLWNDPROC, callHookProc, IntPtr.Zero, UnsafeNativeMethods.GetWindowThreadProcessId(new HandleRef(this, hWnd), 0));
            }
        }
        public void EndHook()
        {
            if (hMenuHook != IntPtr.Zero)
            {
                UnsafeNativeMethods.UnhookWindowsHookEx(new HandleRef(this, hMenuHook));
                hMenuHook = IntPtr.Zero;
            }
        }
        private IntPtr CallHookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            NativeMethods.CWPSTRUCT cwp = (NativeMethods.CWPSTRUCT)Marshal.PtrToStructure(lParam, typeof(NativeMethods.CWPSTRUCT));
            if (code == NativeMethods.HC_ACTION)
            {
                IntPtr pName = Marshal.AllocHGlobal(0x40);
                int claaNameLength = UnsafeNativeMethods.GetClassName(new HandleRef(this, cwp.hwnd), pName, 0x40);
                string className = Marshal.PtrToStringAuto(pName);
                Marshal.FreeHGlobal(pName);
                if (claaNameLength == 6 && className == "#32768")
                {
                    switch (cwp.message)
                    {
                        case NativeMethods.WM_CREATE:
                            {
                                menuWindow = new TMenuWindow();
                                menuWindow.AssignHandle(cwp.hwnd);
                            }
                            break;
                        case NativeMethods.WM_DESTROY:
                            {
                                menuWindow.ReleaseHandle();
                                menuWindow.DestroyHandle();
                            }
                            break;
                    }
                }

            }
            return UnsafeNativeMethods.CallNextHookEx(hMenuHook, code, wParam, lParam);
        }

        /// <summary>
        /// 子类化菜单窗口
        /// </summary>
        private class TMenuWindow : NativeWindow
        {
            public TMenuWindow()
            {
            }
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case NativeMethods.WM_SIZE:
                        {

                        }
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
        }
    }
}
