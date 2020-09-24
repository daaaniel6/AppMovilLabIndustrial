using System;

namespace AppIndustrial.Models.SupplyDTO
{
    public class Supply
    {
        public int code { get; set; }
        public string internalCode { get; set; }
        public string name { get; set; }
        public string expirationDate { get; set; }
        public string dateAdmission { get; set; }
        public double cost { get; set; }
        public double quantity { get; set; }
        public bool availability { get; set; }
        public string description { get; set; }
        public int measureID { get; set; }

        public Supply() { }

        public Supply(
            int code, string internalCode, string name, DateTime expirationDate, DateTime dateAdmission, 
            double cost, double quantity, bool availability, string description, int measureID)
        {
            this.code = code;
            this.internalCode = internalCode;
            this.name = name;
            this.expirationDate = expirationDate.ToString("yyyy-MM-dd");
            this.dateAdmission = dateAdmission.ToString("yyyy-MM-dd");
            this.cost = cost;
            this.quantity = quantity;
            this.availability = availability;
            this.description = description;
            this.measureID = measureID;
        }
    }
}
