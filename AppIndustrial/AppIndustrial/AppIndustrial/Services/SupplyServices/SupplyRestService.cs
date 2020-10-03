using AppIndustrial.Models.Resouces;
using AppIndustrial.Models.SupplyDTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppIndustrial.Services.SupplyServices
{
    class SupplyRestService
    {
        private const string SUPPLY_REST = Constants.PRINCIPAL_URI + "/supplies";
        private const string AVAILABLE = SUPPLY_REST + "/available";
        private const string FIND_BY_NAME = SUPPLY_REST + "/search";
        private const string SERVICE_SUPPLY = SUPPLY_REST + "/";

        HttpClient client;

        public SupplyRestService()
        {
            client = new HttpClient();
        }

        public async Task<List<Supply>> availableSupply()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(AVAILABLE);
            request.Method = HttpMethod.Get;
            
            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == HttpStatusCode.Found)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Supply>>(content);
            }
            return null;
        }

        public async Task<List<Supply>> findSupplies(string name = null)
        {
            string URI = FIND_BY_NAME;

            if (!string.IsNullOrEmpty(name))
            {
                URI += ("?supplyname=" + name);
            }
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(URI);
            request.Method = HttpMethod.Get;

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Found)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Supply>>(content);
            }
            return null;
        }

        public async Task<Supply> getSupplies(int id)
        {
            string URI = SERVICE_SUPPLY + id;

            
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(URI);
            request.Method = HttpMethod.Get;

            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Found)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Supply>(content);
            }
            return null;
        }

        public async Task<HttpStatusCode> createSupply(Supply supply)
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(SERVICE_SUPPLY);
                request.Method = HttpMethod.Post;

                string json = JsonConvert.SerializeObject(supply);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                request.Content = content;

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Console.WriteLine("|||||||||||||\nExito Creando: " + supply.name + "\n|||||||||||||||||");
                } else
                {
                    Console.WriteLine("<<<<<<<<<<<<<\nError Creando: " + supply.name + "\n<<<<<<<<<<<<<<<");
                }
                return response.StatusCode;
            } catch (Exception ex)
            {
                Console.WriteLine("Error:\n" + ex.Message);
            }
            return HttpStatusCode.NotFound;

        }

        public async Task<HttpStatusCode> updateSupply(Supply supply)
        {
            try
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(SERVICE_SUPPLY);
                request.Method = HttpMethod.Put;

                string json = JsonConvert.SerializeObject(supply);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                request.Content = content;

                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.Created)
                {
                    Console.WriteLine("|||||||||||||\nExito Actualizando: " + supply.name + "\n|||||||||||||||||");
                }
                else
                {
                    Console.WriteLine("<<<<<<<<<<<<<\nError Actualizando: " + supply.name + "\n<<<<<<<<<<<<<<<");
                }
                return response.StatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:\n" + ex.Message);
            }
            return HttpStatusCode.NotFound;

        }
    }
}

