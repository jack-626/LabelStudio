using System;
using System.Collections.Generic;
using System.Text;

namespace LabelStudio.LabelDesigner
{
    public abstract class LabelElement
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }

    public class LabelTextElement : LabelElement
    {
        
        public string Text { get; set; }
        public float FontSize { get; set; }
        public string FontName { get; set; }
        public bool Bold { get; set; }
        public bool Italics { get; set; }
    }

    public class LabelImageElement : LabelElement
    {
        public string ImagePath { get; set; }
    }
}
