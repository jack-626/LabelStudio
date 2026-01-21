using System;
using System.Collections.Generic;
using System.Text;

namespace LabelStudio.Database
{
    public class Plant
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Family { get; set; }
        public string Species { get; set; }
        public string Variety { get; set; }
        public string CommonName { get; set; }
        public string Description { get; set; }
        public string PlantCode { get; set; }
    }
}
