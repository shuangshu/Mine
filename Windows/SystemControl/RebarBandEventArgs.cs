using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Windows.SystemControl
{
    public class RebarBandEventArgs : EventArgs
    {
        private RebarBand value;
        public RebarBand TRebarBand
        {
            get { return value; }
        }
        public RebarBandEventArgs(RebarBand value)
        {
            this.value = value;
        }
    }
    public delegate void DeletedBandeEventHandler(object sender, RebarBandEventArgs e);
    public delegate void DeletingBandeEventHandler(object sender, RebarBandEventArgs e);
}
