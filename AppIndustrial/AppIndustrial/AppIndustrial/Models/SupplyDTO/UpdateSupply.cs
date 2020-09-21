using System;
using System.Collections.Generic;
using System.Text;

namespace AppIndustrial.Models.SupplyDTO
{
    public class UpdateSupply
    {
        int code { get; set; }
        string name { get; set; } 
        DateTime expirationDate { get; set; }
        double cost { get; set; }
        string description { get; set; }

        public UpdateSupply()
        {
        }

        public UpdateSupply(int code, string name, DateTime expirationDate, double cost, string description)
        {
            this.code = code;
            this.name = name;
            this.expirationDate = expirationDate;
            this.cost = cost;
            this.description = description;
        }
    }
}
