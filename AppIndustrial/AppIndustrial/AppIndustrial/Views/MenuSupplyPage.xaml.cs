using AppIndustrial.Views.SuppliesPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppIndustrial.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuSupplyPage : ContentPage
    {
        public MenuSupplyPage()
        {
            InitializeComponent();
            viewSupplyAvailableButton.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ViewSuppliesPage());
            };
            createSupplyButton.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new CreateSupplyPage());
            };
        }
    }
}