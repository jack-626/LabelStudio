using System;
using System.Collections.Generic;
using System.Text;

namespace LabelStudio.LabelDesigner
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
    }
}
