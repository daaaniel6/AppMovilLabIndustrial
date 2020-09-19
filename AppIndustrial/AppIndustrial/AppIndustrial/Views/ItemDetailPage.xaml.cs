using System.ComponentModel;
using Xamarin.Forms;
using AppIndustrial.ViewModels;

namespace AppIndustrial.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}