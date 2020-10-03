using AppIndustrial.Models.SupplyDTO;
using AppIndustrial.Services.SupplyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppIndustrial.Views.SuppliesPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoSupplyView : ContentPage
    {
        SupplyRestService supplyRest;
        MeasureRestService measureRest;
        public InfoSupplyView(int id)
        {
            supplyRest = new SupplyRestService();
            measureRest = new MeasureRestService();
            InitializeComponent();
            init(id);
        }

        private async void init(int idSupply)
        {
            Supply supply = await supplyRest.getSupplies(idSupply);
            measure measure = await measureRest.getMeasure(supply.measureID);
            internalCodeLabel.Text = supply.internalCode;
            nameLabel.Text = supply.name;
            expirationDateLabel.Text = supply.expirationDate;
            dateAdmissionLabel.Text = supply.dateOfAdmission;
            costLabel.Text = Convert.ToString(supply.cost);
            quatityLabel.Text = (Convert.ToString(supply.quantity) + " " + measure.name);
            descriptionLabel.Text = supply.description;
        }
    }
}