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
    class MeasureRestService
    {
        private const string MEASURE_REST = Constants.PRINCIPAL_URI + "/measures";

        HttpClient client;

        public MeasureRestService()
        {
            client = new HttpClient();
        }

        public async Task<List<measure>> getMeasures()
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(MEASURE_REST);
            request.Method = HttpMethod.Get;
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Found)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<measure>>(content);
            }
            return null;
        }

        public async Task<measure> getMeasure(int id)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri((MEASURE_REST + "/" + id));
            request.Method = HttpMethod.Get;
            HttpResponseMessage response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Found)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<measure>(content);
            }
            return null;
        }
    }
}
