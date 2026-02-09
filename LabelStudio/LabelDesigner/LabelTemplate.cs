using LabelStudio.Printing;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabelStudio.LabelDesigner
{
    public class LabelTemplate
    {
        public float LabelWidth { get; set; }
        public float LabelHeight { get; set; }
        public List<LabelElement> Elements { get; set; } = new();

        // Label sheet properties
        //public float PageWidthMM { get; set; } = 210f;
        //public float PageHeightMM { get; set; } = 297f;

        public int Columns { get; set; }
        public int Rows { get; set; }

        public float GapX { get; set; }
        public float GapY { get; set; }

        public float MarginLeft { get; set; }
        public float MarginTop { get; set; }
    }
}
