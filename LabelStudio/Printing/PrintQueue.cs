using LabelStudio.LabelDesigner;
using System;
using System.Collections.Generic;
using System.Text;
using LabelStudio.Databases;

namespace LabelStudio.Printing
{
    public class PrintQueue
    {
        public LabelTemplate Template { get; set; }
        public List<Plant> Plants { get; set; } = new();
    }
}
