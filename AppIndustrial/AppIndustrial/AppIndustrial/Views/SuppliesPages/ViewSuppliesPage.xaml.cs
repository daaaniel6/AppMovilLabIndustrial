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
    public partial class ViewSuppliesPage : ContentPage
    {
        SupplyRestService supplyRest;
        public ViewSuppliesPage()
        {
            supplyRest = new SupplyRestService();
            InitializeComponent();
            viewSupplies();
        }

        private async void viewSupplies()
        {
            SuppliesList.ItemsSource = await supplyRest.availableSupply();
        }

        private void updateSupplyList_Clicked(object sender, EventArgs e)
        {
            viewSupplies();
        }
    }
}