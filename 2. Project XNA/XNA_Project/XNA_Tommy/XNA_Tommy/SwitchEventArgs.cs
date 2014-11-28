using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNA_Tommy
{
    public class SwitchEventArgs : EventArgs
    {
        public int current { get; internal set; }

        public SwitchEventArgs(int current)
        {
            this.current = current;
        }
    }
}
