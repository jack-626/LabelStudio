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
        public float PageWidthMM = 210f;
        public float PageHeightMM = 297f;

        public int Columns;
        public int Rows;

        public float GapXmm;
        public float GapYmm;

        public float MarginLeftMM;
        public float MarginTopMM;
    }
}
