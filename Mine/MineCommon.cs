using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using Windows;

namespace Mine
{
    public class MineCommon
    {
        //游戏状态
        public const int GAMESTATE_WAIT = 0;//等待
        public const int GAMESTATE_RUN = 1;//运行
        public const int GAMESTATE_FAIL = 2;//失败
        public const int GAMESTATE_SUCCESS = 3;//成功
        //雷的状态
        public const int STATE_NORMAL = 0;//正常
        public const int STATE_MARKING = 1;//标识为雷
        public const int STATE_UNKNOW = 2;//未知
        public const int STATE_HOTMINE = 3;//选中的雷
        public const int STATE_NOTMINE = 4;//雷
        public const int STATE_MINE = 5;//雷
        public const int STATE_NUMBER_UNKNOW = 6;//未知数字
        public const int STATE_NUMBER_EIGHT = 7;//数字8
        public const int STATE_NUMBER_SEVEN = 8;//数字8
        public const int STATE_NUMBER_SIT = 9;//数字7
        public const int STATE_NUMBER_FIVE = 10;//数字6
        public const int STATE_NUMBER_FOUR = 11;//数字5
        public const int STATE_NUMBER_THREE = 12;//数字4
        public const int STATE_NUMBER_TWO = 13;//数字3
        public const int STATE_NUMBER_ONE = 14;//数字2
        public const int STATE_NUMBER_EMPTY = 15;//数字空
        //雷的属性
        public const int ATTRIBUTE_EMPTY = 0;
        public const int ATTRIBUTE_MINE = 1;
        //表情状态
        public const int EMOTION_DOWN = 0;//按钮按下
        public const int EMOTION_SUCCESS = 1;//胜利
        public const int EMOTION_FAIL = 2;//死亡
        public const int EMOTION_CLICK = 3;//鼠标点击表情
        public const int EMOTION_NORMAL = 4;//正常表情
        //计时器数字
        public const int NUMBER_LINE = 0;
        public const int NUMBER_EMPTY = 1;
        public const int NUMBER_NINE = 2;
        public const int NUMBER_EIGHT = 3;
        public const int NUMBER_SEVEN = 4;
        public const int NUMBER_SIX = 5;
        public const int NUMBER_FIVE = 6;
        public const int NUMBER_FOUR = 7;
        public const int NUMBER_THREE = 8;
        public const int NUMBER_TWO = 9;
        public const int NUMBER_ONE = 10;
        public const int NUMBER_ZERO = 11;
        //颜色
        public static int COLOR_BACK = -1;
        public static int COLOR_DARKGRAY = -1;
        public static int COLOR_GRAY = -1;
        public static int COLOR_WHITE = -1;
        //图片
        public static IntPtr FaceHBitmap = IntPtr.Zero;
        public static IntPtr NumberHBitmap = IntPtr.Zero;
        public static IntPtr MineHBitmap = IntPtr.Zero;

        static MineCommon()
        {
            COLOR_BACK = NativeMethods.RGB(0, 0, 0);
            COLOR_DARKGRAY = NativeMethods.RGB(128, 128, 128);
            COLOR_GRAY = NativeMethods.RGB(192, 192, 192);
            COLOR_WHITE = NativeMethods.RGB(255, 255, 255);
        }

        public static void LoadBitmap(Setting setting)
        {
            if (setting.AllowColor)
            {

                FaceHBitmap = Properties.Resources.Face4Bit.GetHbitmap();
                NumberHBitmap = Properties.Resources.Number4Bit.GetHbitmap();
                MineHBitmap = Properties.Resources.Mine4Bit.GetHbitmap();
            }
            else
            {
                FaceHBitmap = Properties.Resources.Face4BitGray.GetHbitmap();
                NumberHBitmap = Properties.Resources.Number4BitGray.GetHbitmap();
                MineHBitmap = Properties.Resources.Mine4BitGray.GetHbitmap();
            }
        }

        public static void MineAbout(string value)
        {
            UnsafeNativeMethods.ShellAbout(IntPtr.Zero, "扫雷", value, IntPtr.Zero);
        }
        public static void ShowHelp()
        {
            UnsafeNativeMethods.WinExec("HH NTHelp.CHM", NativeMethods.SW_SHOW);
        }
        public static void Draw3DRectangle(IntPtr hDC, int x, int y, int cx, int cy, int colorLT, int colorRB)
        {
            FillRectangle(hDC, x, y, cx - 1, 1, colorLT);
            FillRectangle(hDC, x, y, 1, cy - 1, colorLT);
            FillRectangle(hDC, x + cx, y, -1, cy, colorRB);
            FillRectangle(hDC, x, y + cy, cx, -1, colorRB);
        }
        public static void FillRectangle(IntPtr hDC, int x, int y, int cx, int cy, int color)
        {
            UnsafeNativeMethods.SetBkColor(hDC, color);
            NativeMethods.RECT rect = new NativeMethods.RECT(x, y, x + cx, y + cy);
            UnsafeNativeMethods.ExtTextOut(hDC, 0, 0, NativeMethods.ETO_OPAQUE, ref rect, IntPtr.Zero, 0, IntPtr.Zero);
        }
    }

    public delegate void MessageSizeEventHandler(object sender, int cx, int cy);
}
