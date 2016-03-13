using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Mine
{
    public class Mine
    {
        private int row;
        /// <summary>
        /// 所在雷区二维数组的行
        /// </summary>
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        private int column;
        /// <summary>
        /// 所在雷区二位数组的列
        /// </summary>
        public int Column
        {
            get { return column; }
            set { column = value; }
        }
        private int previousState = -1;
        /// <summary>
        /// 先前的状态
        /// </summary>
        public int PreviousState
        {
            get { return previousState; }
            set { previousState = value; }
        }
        private int currentState = -1;
        /// <summary>
        /// 当前的状态
        /// </summary>
        public int CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
        private int attribute = -1;
        public int Attribute
        {
            get { return attribute; }
            set { attribute = value; }
        }

        public Mine(int row, int column)
        {
            this.row = row;
            this.column = column;
        }

        public Mine()
        {
            this.row = 0;
            this.column = 0;
        }
    }
}
