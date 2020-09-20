using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppIndustrial.Models.ModifyDTO
{
    public class modifySupply
    {
        public int carnetUser { get; set; }
        public int codeSupply { get; set; }
        public DateTime date { get; set; }
        public int idModifySupply { get; set; }
        public string modifyType { get; set; }
        public string note { get; set; }
        public double quantity { get; set; }

        public modifySupply() { }

        public modifySupply(int carnet, int codeSupply, DateTime date, int idModifySupply, string modifyType, string note, double quantity)
        {
            this.carnetUser = carnet;
            this.codeSupply = codeSupply;
            this.date = date;
            this.idModifySupply = idModifySupply;
            this.modifyType = modifyType;
            this.note = note;
            this.quantity = quantity;
        }
    }
}
