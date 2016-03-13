using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Mine
{
    public partial class MineSetting : Form
    {
        private Setting setting = null;
        public Setting Setting
        {
            get { return setting; }
            set { setting = value; }
        }

        public int Row
        {
            get { return (int)numericUpDownRow.Value; }
            set { numericUpDownRow.Value = (decimal)value; }
        }

        public int Column
        {
            get { return (int)numericUpDownColumn.Value; }
            set { numericUpDownColumn.Value = (decimal)value; }
        }

        public int MineNumber
        {
            get { return (int)numericUpDownMineNumber.Value; }
            set { numericUpDownMineNumber.Value = (decimal)value; }
        }

        public MineSetting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
