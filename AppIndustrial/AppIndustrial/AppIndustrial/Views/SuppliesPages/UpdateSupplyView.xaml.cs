using AppIndustrial.Models.SupplyDTO;
using AppIndustrial.Services.SupplyServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppIndustrial.Views.SuppliesPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateSupplyView : ContentPage
    {
        SupplyRestService supplyRest;
        MeasureRestService measureRest;
        Supply supply;
        public UpdateSupplyView(int idSupply)
        {
            supplyRest = new SupplyRestService();
            measureRest = new MeasureRestService();
            InitializeComponent();
            init(idSupply);
        }

        private async void init(int idSupply)
        {
            supply = await supplyRest.getSupplies(idSupply);
            measure measure = await measureRest.getMeasure(supply.measureID);
            internalCodeLabel.Text = supply.internalCode;
            nameEntry.Text = supply.name;
            expirationDateDP.Date = Convert.ToDateTime(supply.expirationDate);
            dateAdmissionLabel.Text = supply.dateOfAdmission;
            costEntry.Text = Convert.ToString(supply.cost);
            quatityLabel.Text = (Convert.ToString(supply.quantity) + " " + measure.name);
            descriptionEditor.Text = supply.description;
        }

        private void costEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lets the Entry be empty
            if (string.IsNullOrEmpty(e.NewTextValue)) return;

            if (!double.TryParse(e.NewTextValue, out double value))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }
        private async void updateButton_Clicked(object sender, EventArgs e)
        {

            if(expirationDateDP.Date != Convert.ToDateTime(supply.expirationDate))
            {
                supply.expirationDate = expirationDateDP.Date.ToString("yyyy-MM-dd");
            }

            if (nameEntry.Text.Length > 0 && !nameEntry.Text.Equals(supply.name))
            {
                supply.name = nameEntry.Text;
            }

            if(Convert.ToDouble(costEntry.Text) != supply.cost && Convert.ToDouble(costEntry.Text) >= 0)
            {
                supply.cost = Convert.ToDouble(costEntry.Text);
            }

            if(descriptionEditor.Text.Length > 0 && !descriptionEditor.Text.Equals(supply.description))
            {
                supply.description = descriptionEditor.Text;
            }

            HttpStatusCode status = await supplyRest.updateSupply(supply);
            await DisplayAlert("Respuesta",
                "Actualizacion: " + status.ToString()
                , "Aceptar");
        }
    }
}