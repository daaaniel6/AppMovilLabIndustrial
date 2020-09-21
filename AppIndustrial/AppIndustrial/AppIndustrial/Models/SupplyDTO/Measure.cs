using System;
using System.Collections.Generic;
using System.Text;

namespace AppIndustrial.Models.SupplyDTO
{
    public class measure
    {
        public int idMeasure { get; set; }

        public string name { get; set; }

        public measure() { }

        public measure(int idMeasure, string name)
        {
            this.idMeasure = idMeasure;
            this.name = name;
        }
    }
    
}
