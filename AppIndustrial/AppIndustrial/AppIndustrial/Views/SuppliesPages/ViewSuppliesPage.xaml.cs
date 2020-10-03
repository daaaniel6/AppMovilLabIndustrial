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
    public partial class ViewSuppliesPage : ContentPage
    {
        private const string VER = "Ver";
        private const string EDITAR = "Editar";

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

        private void goToUpdate(int id)
        {
            Navigation.PushAsync(new UpdateSupplyView(id));
        }

        private void goToInfo(int id)
        {
            Navigation.PushAsync(new InfoSupplyView(id));
        }

        private void SuppliesList_Refreshing(object sender, EventArgs e)
        {
            viewSupplies();
            SuppliesList.IsRefreshing = false;
        }

        private async void SuppliesList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Supply selected = (Supply)SuppliesList.SelectedItem;
            string action = await DisplayActionSheet("Supply"+ selected.internalCode, "Cancel", null, VER, EDITAR);
            switch (action)
            {
                case VER:
                    goToInfo(selected.code);
                    break;
                case EDITAR:
                    goToUpdate(selected.code);
                    break;
            }
        }
    }
}