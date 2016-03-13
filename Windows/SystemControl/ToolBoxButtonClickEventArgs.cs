using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows.SystemControl
{
    public delegate void TToolBarButtonClickEventHandle(object sender, ToolBoxButtonClickEventArgs e);
    public class ToolBoxButtonClickEventArgs : EventArgs
    {
        private ToolBoxButton button;
        public ToolBoxButtonClickEventArgs(ToolBoxButton button)
        {
            this.button = button;
        }
        public ToolBoxButton Button
        {
            get { return button; }
            set { button = value; }
        }
    }
}
