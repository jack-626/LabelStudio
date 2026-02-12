using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace LabelStudio.LabelDesigner
{
    public abstract class LabelElement
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float RotationDeg { get; set; }
        public string DataType { get; set; }
    }

    public class LabelTextElement : LabelElement
    {
        public string Data { get; set; }
        public float FontSize { get; set; }
        public string FontName { get; set; }
        public bool Bold { get; set; }
        public bool Italics { get; set; }
        public string GetTextFromData(DataRow row)
        {
            if(!string.IsNullOrEmpty(Data) && row != null && row.Table.Columns.Contains(Data))
            {
                return row[Data]?.ToString();
            }
            return string.Empty;
        }
    }

    public class LabelImageElement : LabelElement
    {
        public string ImagePath { get; set; }
    }
}