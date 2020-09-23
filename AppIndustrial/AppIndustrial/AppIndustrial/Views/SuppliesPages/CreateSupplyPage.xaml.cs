using AppIndustrial.Models.SupplyDTO;
using AppIndustrial.Services.SupplyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppIndustrial.Views.SuppliesPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateSupplyPage : ContentPage
    {
        MeasureRestService measureREST;
        SupplyRestService supplyREST;

        measure selectedMeasure;
        public CreateSupplyPage()
        {
            measureREST = new MeasureRestService();
            supplyREST = new SupplyRestService();
            InitializeComponent();
            initMeasure();
            measurePicker.SelectedIndexChanged += (sender, args) =>
            {
                if (measurePicker.SelectedIndex == -1)
                {
                    DisplayAlert("Medida", "Debe seleccionar una Medida", "Aceptar");
                }
                else
                {
                    selectedMeasure = (measure)measurePicker.ItemsSource[measurePicker.SelectedIndex];
                }
            };

        }

        private async void initMeasure()
        {
            measurePicker.ItemsSource = await measureREST.getMeasures();
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

        private void quantityEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lets the Entry be empty
            if (string.IsNullOrEmpty(e.NewTextValue)) return;

            if (!double.TryParse(e.NewTextValue, out double value))
            {
                ((Entry)sender).Text = e.OldTextValue;
            }
        }

        private async void createSupply_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Insumo",
                "Codigo Interno: " + internalCodeEntry.Text
                + "\nNombre: " + nameEntry.Text
                + "\nFecha de Caducidad: " + expirationDateDP.Date.ToString()
                + "\nFecha de Admision: " + dateAdmissionDP.Date.ToString()
                + "\nCosto: " + costEntry.Text
                + "\nMedida: " + selectedMeasure.name
                + "\nCantidad: " + quantityEntry.Text
                + "\nDescripcion: " + descriptionEditor.Text
                + "\nMedicion: " + selectedMeasure.name
                , "Aceptar");
            HttpStatusCode status = await supplyREST.createSupply(new Supply(0, internalCodeEntry.Text, nameEntry.Text, expirationDateDP.Date, dateAdmissionDP.Date, Convert.ToDouble(costEntry.Text),Convert.ToDouble(quantityEntry.Text),true,descriptionEditor.Text,selectedMeasure.idMeasure));
            await DisplayAlert("Respuesta",
                "Codigo Interno: " + status.ToString()
                , "Aceptar");
        }
    }
}