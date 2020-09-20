using AppIndustrial.Views.Group;
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
    public partial class MenuGroupPage : ContentPage
    {
        public MenuGroupPage()
        {
            InitializeComponent();
            viewGroupsButton.Clicked += (sender, e) =>
            {
                Navigation.PushAsync(new ViewGroup());
            };
        }
    }
}