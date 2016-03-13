using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Media;
using Windows;

namespace Mine
{
    public class MinePalette : Control
    {
        public event MessageSizeEventHandler MessageSize;
        private IntPtr graphics = IntPtr.Zero;
        private int cx = 0;//客户端的宽度
        private int cy = 0;//客户端的高度
        private Setting setting = null;
        public Setting Setting
        {
            get
            {
                if (setting == null)
                {
                    setting = new Setting();
                    setting.Load();
                    MineCommon.LoadBitmap(setting);
                }
                return setting;
            }
            set
            {
                setting = value;
                if (setting != null)
                {
                    setting.Load();
                    MineCommon.LoadBitmap(setting);
                }
            }
        }
        //块
        private Mine[,] mines = null;
        //表情
        private int emotionState = 4;
        private Rectangle mineRectangle = Rectangle.Empty;//雷区
        private Rectangle emotionRectangle = Rectangle.Empty;//表情区域
        private Mine runningMine = null;
        private int remaindMine = 5;//剩余的雷数
        private int spendTime = 20;//花费的时间
        private int gameState = -1;//游戏状态
        private SoundPlayer soundPlayer = null;
        private int IDEvent = 0;

        public MinePalette()
        {
            LoadSetting();
            InitializeGame();
        }

        public void LoadSetting()
        {
            soundPlayer = new SoundPlayer();
            Size = new Size(Setting.Column * 16 + 20, Setting.Row * 16 + 64);
            mines = new Mine[100, 100];//最多100*100
            for (int row = 0; row < 100; row++)//行数
            {
                for (int column = 0; column < 100; column++)//列数
                {
                    if (row < Setting.Row && column < Setting.Column)
                    {
                        mines[row, column] = new Mine(row, column);
                        mines[row, column].PreviousState = MineCommon.STATE_NORMAL;
                        mines[row, column].CurrentState = MineCommon.STATE_NORMAL;
                        mines[row, column].Attribute = MineCommon.ATTRIBUTE_EMPTY;
                    }
                    else
                    {
                        mines[row, column] = new Mine();
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            graphics = UnsafeNativeMethods.GetDC(Handle);
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            UnsafeNativeMethods.ReleaseDC(Handle, graphics);
        }
        public void CreatePalette()
        {
            base.RecreateHandle();
        }

        private Rectangle clientRectangle = Rectangle.Empty;
        public new Rectangle ClientRectangle
        {
            get { return clientRectangle; }
        }

        private void DrawPalette(IntPtr hDC)//用双缓冲
        {
            IntPtr hCompatibleDC = UnsafeNativeMethods.CreateCompatibleDC(hDC);
            IntPtr hCompatibleBitmap = UnsafeNativeMethods.CreateCompatibleBitmap(hDC, cx, cy);
            UnsafeNativeMethods.SelectObject(hCompatibleDC, hCompatibleBitmap);
            MineCommon.FillRectangle(hCompatibleDC, 0, 0, cx, cy, MineCommon.COLOR_GRAY);
            DrawFace(hCompatibleDC, emotionState);
            DrawMineNumber(hCompatibleDC);
            DrawFrame(hCompatibleDC);
            DrawMineRectangle(hCompatibleDC);
            UnsafeNativeMethods.BitBlt(hDC, 0, 0, cx, cy, hCompatibleDC, 0, 0, NativeMethods.SRCCOPY);
            UnsafeNativeMethods.DeleteObject(hCompatibleBitmap);
            UnsafeNativeMethods.DeleteDC(hCompatibleDC);
        }
        private void DrawMineNumber(IntPtr hDC)
        {
            IntPtr hCompatibleDC = UnsafeNativeMethods.CreateCompatibleDC(hDC);
            UnsafeNativeMethods.SelectObject(hCompatibleDC, MineCommon.NumberHBitmap);
            MineCommon.Draw3DRectangle(hDC, 16, 15, 41, 25, MineCommon.COLOR_DARKGRAY, MineCommon.COLOR_WHITE);
            MineCommon.Draw3DRectangle(hDC, cx - 55, 15, 41, 25, MineCommon.COLOR_DARKGRAY, MineCommon.COLOR_WHITE);
            int number = 0;
            number = (remaindMine < 0) ? 11 : remaindMine / 100;
            UnsafeNativeMethods.StretchBlt(hDC, 17, 16, 13, 23, hCompatibleDC, 0, 276 - 23 * (number + 1), 13, 23, NativeMethods.SRCCOPY);
            number = (remaindMine < 0) ? -(remaindMine - number * 100) / 10 : (remaindMine - number * 100) / 10;
            UnsafeNativeMethods.StretchBlt(hDC, 30, 16, 13, 23, hCompatibleDC, 0, 276 - 23 * (number + 1), 13, 23, NativeMethods.SRCCOPY);
            number = (remaindMine < 0) ? -remaindMine % 10 : remaindMine % 10;
            UnsafeNativeMethods.StretchBlt(hDC, 43, 16, 13, 23, hCompatibleDC, 0, 276 - 23 * (number + 1), 13, 23, NativeMethods.SRCCOPY);
            number = spendTime / 100;
            UnsafeNativeMethods.StretchBlt(hDC, cx - 55, 16, 13, 23, hCompatibleDC, 0, 276 - 23 * (number + 1), 13, 23, NativeMethods.SRCCOPY);
            number = (spendTime - number * 100) / 10;
            UnsafeNativeMethods.StretchBlt(hDC, cx - 42, 16, 13, 23, hCompatibleDC, 0, 276 - 23 * (number + 1), 13, 23, NativeMethods.SRCCOPY);
            number = spendTime % 10;
            UnsafeNativeMethods.StretchBlt(hDC, cx - 29, 16, 13, 23, hCompatibleDC, 0, 276 - 23 * (number + 1), 13, 23, NativeMethods.SRCCOPY);
            UnsafeNativeMethods.DeleteDC(hCompatibleDC);
        }
        private void DrawMineRectangle(IntPtr hDC)
        {
            IntPtr hCompatibleDC = UnsafeNativeMethods.CreateCompatibleDC(hDC);
            UnsafeNativeMethods.SelectObject(hCompatibleDC, MineCommon.MineHBitmap);
            for (int row = 0; row < Setting.Row; row++)
            {
                for (int column = 0; column < Setting.Column; column++)
                {
                    UnsafeNativeMethods.StretchBlt(hDC,
                        12 + 16 * column,
                        55 + 16 * row,
                        16,
                        16,
                        hCompatibleDC,
                        0,
                        16 * mines[row, column].CurrentState,
                        16,
                        16,
                        NativeMethods.SRCCOPY);
                }
            }
            UnsafeNativeMethods.DeleteDC(hCompatibleDC);
        }
        private void DrawFace(IntPtr hDC, int state)
        {
            IntPtr hCompatibleDC = UnsafeNativeMethods.CreateCompatibleDC(hDC);
            UnsafeNativeMethods.SelectObject(hCompatibleDC, MineCommon.FaceHBitmap);
            UnsafeNativeMethods.StretchBlt(hDC, cx / 2 - 12, 16, 24, 24, hCompatibleDC, 0, 24 * state, 24, 24, NativeMethods.SRCCOPY);
            MineCommon.Draw3DRectangle(hDC, cx / 2 - 13, 15, 26, 26, MineCommon.COLOR_DARKGRAY, MineCommon.COLOR_DARKGRAY);
            UnsafeNativeMethods.DeleteDC(hCompatibleDC);
        }
        private void DrawFrame(IntPtr hDC)
        {
            MineCommon.FillRectangle(hDC, 0, 0, cx, 3, MineCommon.COLOR_WHITE);
            MineCommon.FillRectangle(hDC, 0, 0, 3, cy, MineCommon.COLOR_WHITE);
            MineCommon.Draw3DRectangle(hDC, 9, 9, cx - 14, 37, MineCommon.COLOR_DARKGRAY, MineCommon.COLOR_WHITE);
            MineCommon.Draw3DRectangle(hDC, 10, 10, cx - 16, 35, MineCommon.COLOR_DARKGRAY, MineCommon.COLOR_WHITE);
            MineCommon.Draw3DRectangle(hDC, 9, 52, cx - 14, cy - 57, MineCommon.COLOR_DARKGRAY, MineCommon.COLOR_WHITE);
            MineCommon.Draw3DRectangle(hDC, 10, 53, cx - 16, cy - 59, MineCommon.COLOR_DARKGRAY, MineCommon.COLOR_WHITE);
            MineCommon.Draw3DRectangle(hDC, 11, 54, cx - 18, cy - 61, MineCommon.COLOR_DARKGRAY, MineCommon.COLOR_WHITE);
        }
        private void DrawLED(Mine mineDate, int number)
        {
            mineDate.CurrentState = 15 - number;
            mineDate.PreviousState = 15 - number;
            Rectangle rectangle = new Rectangle(mineDate.Column * 16, mineDate.Row * 16, 16, 16);
            Invalidate(rectangle);
        }

        public void InitializeGame()
        {
            remaindMine = Setting.MineNumber;
            spendTime = 0;
            emotionState = MineCommon.EMOTION_NORMAL;
            gameState = MineCommon.GAMESTATE_WAIT;
            if (IDEvent != 0 && Handle != IntPtr.Zero)
            {
                UnsafeNativeMethods.KillTimer(new HandleRef(this, Handle), NativeMethods.ID_TIMER_EVENT);
                IDEvent = 0;
            }
            runningMine = null;
            for (int row = 0; row < Setting.Row; row++)//行数
            {
                for (int column = 0; column < Setting.Column; column++)//列数
                {
                    mines[row, column].Row = row;
                    mines[row, column].Column = column;
                    mines[row, column].PreviousState = MineCommon.STATE_NORMAL;
                    mines[row, column].CurrentState = MineCommon.STATE_NORMAL;
                    mines[row, column].Attribute = MineCommon.ATTRIBUTE_EMPTY;
                }
            }
        }

        private Mine GetMine(int x, int y)
        {
            if (x < 12 || y < 12) return null;
            int column = (x - 12) / 16;
            int row = (y - 55) / 16;
            return mines[row, column];
        }
        private void LayMines(int row, int column)
        {
            Random random = new Random();
            for (int index = 0; index < Setting.MineNumber; )
            {
                int rowNext = random.Next(0, Setting.Row);
                int columnNext = random.Next(0, Setting.Column);
                if (rowNext == row && columnNext == column) continue;
                Mine mineData = mines[rowNext, columnNext];
                if (mineData.Attribute != MineCommon.ATTRIBUTE_MINE)
                {
                    mineData.Attribute = MineCommon.ATTRIBUTE_MINE;
                    index++;
                }
            }
        }
        private void ExpandMines(int row, int column)
        {
            int minRow = (row == 0) ? 0 : row - 1;
            int maxRow = row + 1;
            int minColumn = (column == 0) ? 0 : column - 1;
            int maxColumn = column + 1;

            int aroundMine = GetAroundMine(row, column);

            mines[row, column].CurrentState = 15 - aroundMine;
            mines[row, column].PreviousState = 15 - aroundMine;
            Rectangle rectangle = new Rectangle(column * 16, row * 16, 16, 16);
            Invalidate(rectangle);
            if (aroundMine == 0)
            {
                for (int a = minRow; a <= maxRow; a++)
                {
                    for (int b = minColumn; b <= maxColumn; b++)
                    {
                        if (!(a == row && b == column) &&
                            mines[a, b].CurrentState == MineCommon.STATE_NORMAL &&
                            mines[a, b].Attribute != MineCommon.ATTRIBUTE_MINE)
                        {
                            if (!InMineRectangle(a, b)) continue;
                            ExpandMines(a, b);
                        }
                    }
                }
            }
        }
        private bool IsMine(int row, int column)
        {
            return (mines[row, column].Attribute == MineCommon.ATTRIBUTE_MINE);
        }
        private bool InMineRectangle(int row, int column)
        {
            return (row >= 0 && row < Setting.Row && column >= 0 && column < Setting.Column);
        }
        private int GetAroundMine(int row, int column)
        {
            int aroundMine = 0;
            int minRow = (row == 0) ? 0 : row - 1;
            int maxRow = row + 1;
            int minColumn = (column == 0) ? 0 : column - 1;
            int maxColumn = column + 1;
            for (int a = minRow; a <= maxRow; a++)
            {
                for (int b = minColumn; b <= maxColumn; b++)
                {
                    if (!InMineRectangle(a, b)) continue;
                    if (mines[a, b].Attribute == MineCommon.ATTRIBUTE_MINE) aroundMine++;
                }
            }
            return aroundMine;
        }
        private void ValidatorFail(int row, int column)
        {
            Debug.WriteLine("Row: " + row.ToString());
            Debug.WriteLine("Column: " + column.ToString());
            if (mines[row, column].Attribute == MineCommon.ATTRIBUTE_MINE)
            {
                mines[row, column].CurrentState = MineCommon.STATE_HOTMINE;
                mines[row, column].PreviousState = MineCommon.STATE_HOTMINE;
                for (int a = 0; a < Setting.Row; a++)
                {
                    for (int b = 0; b < Setting.Column; b++)
                    {
                        if (mines[a, b].Attribute == MineCommon.ATTRIBUTE_MINE
                            && mines[a, b].CurrentState != MineCommon.STATE_MARKING
                            && mines[a, b].CurrentState != MineCommon.STATE_HOTMINE)
                        {
                            mines[a, b].CurrentState = MineCommon.STATE_MINE;
                            mines[a, b].PreviousState = MineCommon.STATE_MINE;
                        }
                    }
                }
            }
            else
            {
                for (int a = 0; a < Setting.Row; a++)
                {
                    for (int b = 0; b < Setting.Column; b++)
                    {
                        if (mines[a, b].Attribute == MineCommon.ATTRIBUTE_MINE
                            && mines[a, b].CurrentState != MineCommon.STATE_MARKING
                            && mines[a, b].CurrentState != MineCommon.STATE_HOTMINE)
                        {
                            mines[a, b].CurrentState = MineCommon.STATE_MINE;
                            mines[a, b].PreviousState = MineCommon.STATE_MINE;
                        }
                    }
                }
            }
            Invalidate(mineRectangle);
            emotionState = MineCommon.EMOTION_FAIL;
            Invalidate(emotionRectangle);
            gameState = MineCommon.GAMESTATE_FAIL;

            if (IDEvent != 0)
            {
                UnsafeNativeMethods.KillTimer(new HandleRef(this, Handle), NativeMethods.ID_TIMER_EVENT);
                IDEvent = 0;
            }
            if (Setting.AllowVoice)
            {
                soundPlayer.Stream = Properties.Resources.FAIL;
                soundPlayer.Load();
                soundPlayer.Play();
            }
        }
        private bool ValidatorSuccess()
        {
            for (int a = 0; a < Setting.Row; a++)
            {
                for (int b = 0; b < Setting.Column; b++)
                {
                    if (mines[a, b].CurrentState == MineCommon.STATE_NORMAL) return false;
                    if (mines[a, b].CurrentState == MineCommon.STATE_UNKNOW) return false;
                }
            }
            emotionState = MineCommon.EMOTION_SUCCESS;
            gameState = MineCommon.GAMESTATE_SUCCESS;
            Invalidate();
            if (IDEvent != 0)
            {
                UnsafeNativeMethods.KillTimer(new HandleRef(this, Handle), NativeMethods.ID_TIMER_EVENT);
                IDEvent = 0;
            }
            if (Setting.AllowVoice)
            {
                soundPlayer.Stream = Properties.Resources.SUCCESS;
                soundPlayer.Load();
                soundPlayer.Play();
            }
            return true;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_LBUTTONDOWN:
                    MouseLDown(NativeMethods.Util.LOWORD(m.LParam), NativeMethods.Util.HIWORD(m.LParam));
                    break;
                case NativeMethods.WM_RBUTTONDOWN:
                    MouseRDown(NativeMethods.Util.LOWORD(m.LParam), NativeMethods.Util.HIWORD(m.LParam));
                    break;
                case NativeMethods.WM_LBUTTONUP:
                    MouseLUp(NativeMethods.Util.LOWORD(m.LParam), NativeMethods.Util.HIWORD(m.LParam));
                    break;
                case NativeMethods.WM_RBUTTONUP:
                    MouseRUp(NativeMethods.Util.LOWORD(m.LParam), NativeMethods.Util.HIWORD(m.LParam));
                    break;
                case NativeMethods.WM_TIMER:
                    TimerHandle(m.WParam.ToInt32());
                    break;
                case NativeMethods.WM_SIZE:
                    {
                        cx = NativeMethods.SignedLOWORD((int)m.LParam);
                        cy = NativeMethods.SignedHIWORD((int)m.LParam);
                        clientRectangle = new Rectangle(0, 0, cx, cy);
                        mineRectangle = new Rectangle(12, 55, Setting.Column * 16, Setting.Row * 16);
                        emotionRectangle = new Rectangle(cx / 2 - 13, 15, 25, 24);
                        if (MessageSize != null) MessageSize(this, cx, cy);
                        Invalidate();
                    }
                    break;
                case NativeMethods.WM_PAINT:
                    {
                        NativeMethods.PAINTSTRUCT ps = new NativeMethods.PAINTSTRUCT();
                        IntPtr hDC = UnsafeNativeMethods.BeginPaint(new HandleRef(this, Handle), ref ps);
                        DrawPalette(hDC);
                        UnsafeNativeMethods.EndPaint(new HandleRef(this, Handle), ref ps);
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        private void TimerHandle(int wParam)
        {
            if (wParam == NativeMethods.ID_TIMER_EVENT)
            {
                if (Setting.AllowVoice)
                {
                    soundPlayer.Stream = Properties.Resources.CLICK;
                    soundPlayer.Load();
                    soundPlayer.Play();
                }
                spendTime++;
                Invalidate();
                if (spendTime >= 99)
                {
                    UnsafeNativeMethods.KillTimer(new HandleRef(this, Handle), NativeMethods.ID_TIMER_EVENT);
                    IDEvent = 0;
                }
            }

        }
        private void MouseLDown(int x, int y)
        {
            UnsafeNativeMethods.SetCapture(Handle);
            if (emotionRectangle.Contains(new Point(x, y)))
            {
                emotionState = MineCommon.EMOTION_DOWN;
                Invalidate(emotionRectangle);
            }
            else if (mineRectangle.Contains(new Point(x, y)))
            {
                switch (gameState)
                {
                    case MineCommon.GAMESTATE_WAIT:
                    case MineCommon.GAMESTATE_RUN:
                        {
                            runningMine = GetMine(x, y);
                            if (runningMine == null) return;
                            if (runningMine.CurrentState == MineCommon.STATE_NORMAL)
                                runningMine.CurrentState = MineCommon.STATE_NUMBER_EMPTY;
                            if (runningMine.CurrentState == MineCommon.STATE_UNKNOW)
                                runningMine.CurrentState = MineCommon.STATE_NUMBER_UNKNOW;
                        }
                        break;
                    case MineCommon.GAMESTATE_FAIL:
                    case MineCommon.GAMESTATE_SUCCESS:
                        return;
                    default:
                        break;
                }
                emotionState = MineCommon.EMOTION_CLICK;
                Invalidate(emotionRectangle);
                Invalidate(mineRectangle);
            }
            else
            {
                if (gameState == MineCommon.GAMESTATE_WAIT || gameState == MineCommon.GAMESTATE_RUN)
                {
                    emotionState = MineCommon.EMOTION_CLICK;
                    Invalidate(emotionRectangle);
                }
            }
        }
        private void MouseLUp(int x, int y)
        {
            if (emotionRectangle.Contains(new Point(x, y)))
            {
                Invalidate();
                InitializeGame();
            }
            else if (mineRectangle.Contains(new Point(x, y)))
            {
                int aroundMine = 0;
                switch (gameState)
                {
                    case MineCommon.GAMESTATE_WAIT:
                    case MineCommon.GAMESTATE_RUN:
                        runningMine = GetMine(x, y);
                        if (runningMine == null)
                        {
                            UnsafeNativeMethods.ReleaseCapture();
                            return;
                        }
                        if (gameState == MineCommon.GAMESTATE_WAIT)
                        {
                            if (IDEvent != 0)
                            {
                                UnsafeNativeMethods.KillTimer(new HandleRef(this, Handle), NativeMethods.ID_TIMER_EVENT);
                                IDEvent = 0;
                            }
                            spendTime = 1;
                            Invalidate();
                            if (Setting.AllowVoice)
                            {
                                soundPlayer.Stream = Properties.Resources.CLICK;
                                soundPlayer.Load();
                                soundPlayer.Play();
                            }
                            IDEvent = (int)UnsafeNativeMethods.SetTimer(new HandleRef(this, Handle), NativeMethods.ID_TIMER_EVENT, 1000, IntPtr.Zero);
                            LayMines(runningMine.Row, runningMine.Column);
                            gameState = MineCommon.GAMESTATE_RUN;

                        }
                        if (runningMine.PreviousState == MineCommon.STATE_NORMAL)
                        {
                            if (IsMine(runningMine.Row, runningMine.Column))
                            {
                                ValidatorFail(runningMine.Row, runningMine.Column);
                                UnsafeNativeMethods.ReleaseCapture();
                                return;
                            }
                            aroundMine = GetAroundMine(runningMine.Row, runningMine.Column);
                            if (aroundMine == 0)
                            {
                                ExpandMines(runningMine.Row, runningMine.Column);
                            }
                            else
                            {
                                DrawLED(runningMine, aroundMine);
                            }
                        }
                        else if (runningMine.PreviousState == MineCommon.STATE_UNKNOW)
                        {
                            runningMine.CurrentState = MineCommon.STATE_UNKNOW;
                        }
                        if (ValidatorSuccess())
                        {
                            Invalidate();
                            UnsafeNativeMethods.ReleaseCapture();
                            return;
                        }
                        break;
                    case MineCommon.GAMESTATE_SUCCESS:
                    case MineCommon.GAMESTATE_FAIL:
                        UnsafeNativeMethods.ReleaseCapture();
                        return;
                    default:
                        break;
                }
                emotionState = MineCommon.EMOTION_NORMAL;
                Invalidate();
            }
            else
            {
                if (gameState == MineCommon.GAMESTATE_WAIT || gameState == MineCommon.GAMESTATE_RUN)
                {
                    emotionState = MineCommon.EMOTION_NORMAL;
                    Invalidate(emotionRectangle);
                }
            }
            UnsafeNativeMethods.ReleaseCapture();
        }
        private void MouseRDown(int x, int y)
        {
            if (mineRectangle.Contains(new Point(x, y)))
            {
                if (gameState == MineCommon.GAMESTATE_WAIT || gameState == MineCommon.GAMESTATE_RUN)
                {
                    runningMine = GetMine(x, y);
                    if (runningMine == null) return;
                    switch (runningMine.CurrentState)
                    {
                        case MineCommon.STATE_NORMAL:
                            runningMine.CurrentState = MineCommon.STATE_MARKING;
                            runningMine.PreviousState = MineCommon.STATE_MARKING;
                            remaindMine--;
                            break;
                        case MineCommon.STATE_MARKING:
                            runningMine.CurrentState = MineCommon.STATE_UNKNOW;
                            runningMine.PreviousState = MineCommon.STATE_UNKNOW;
                            remaindMine++;
                            break;
                        case MineCommon.STATE_UNKNOW:
                            runningMine.CurrentState = MineCommon.STATE_NORMAL;
                            runningMine.PreviousState = MineCommon.STATE_NORMAL;
                            break;
                        default:
                            break;
                    }
                    Invalidate();
                }
            }
        }
        private void MouseRUp(int x, int y)
        {
            runningMine = GetMine(x, y);
            if (runningMine == null) return;
            ValidatorSuccess();
        }
    }
}
