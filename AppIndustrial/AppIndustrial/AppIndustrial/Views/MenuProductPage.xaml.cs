using AppIndustrial.Views.Production.PagesProduct;
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
    public partial class MenuProductPage : ContentPage
    {
        public MenuProductPage()
        {
            InitializeComponent();
            viewProductButton.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ViewProductPage());
            };

            createProductButton.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new CreateProductPage());
            };
        }
    }
}