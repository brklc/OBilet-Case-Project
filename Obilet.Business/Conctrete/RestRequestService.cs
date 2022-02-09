using Newtonsoft.Json;
using Obilet.Business.Abstract;
using Obilet.Business.Models.General;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Obilet.Business.Conctrete
{
    public class RestRequestService : IRestRequestService
    {
        private readonly BaseUrl _baseUrl;
        public RestRequestService(BaseUrl baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public Task<T> PostRequest<T>(object model, string methodUrl)
        {

            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = new TimeSpan(0, 0, 360);

                httpClient.DefaultRequestHeaders.Add("Authorization", "Basic JEcYcEMyantZV095WVc3G2JtVjNZbWx1");

                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                HttpResponseMessage responseData = httpClient.PostAsync(_baseUrl.Url + methodUrl, content).Result;

                string returnValue = responseData.Content.ReadAsStringAsync().Result;

                var response = JsonConvert.DeserializeObject<T>(returnValue);

                if (responseData.StatusCode != HttpStatusCode.OK)
                {
                    throw new InvalidOperationException("İşlem Başarısız Oldu!");//anlamlı bişey yazılacak

                }
                return Task.FromResult(response);
            }

        }
    }
}
