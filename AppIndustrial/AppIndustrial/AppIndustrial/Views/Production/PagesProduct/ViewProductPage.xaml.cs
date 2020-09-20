using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using AppIndustrial.Models.Production;
using AppIndustrial.Models.Resouces;

namespace AppIndustrial.Views.Production.PagesProduct
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewProductPage : ContentPage
    {
        public ViewProductPage()
        {
            InitializeComponent();
            ViewProducts();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(Constants.URI_PRODUCTS);//192.168.1.10
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accpet", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Product>>(content);
                listaProductos.ItemsSource = resultado;

            }
        }

        public async void ViewProducts()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(Constants.URI_PRODUCTS);//192.168.1.10
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accpet", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<List<Product>>(content);
                listaProductos.ItemsSource = resultado;

            }
        }

    }
}