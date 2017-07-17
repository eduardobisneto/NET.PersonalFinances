using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NET.PersonalFinances.UI.WindowsForms.Util
{
    public class Request<Req, Res>
        where Req : class
        where Res : class
    {
        public Res ResponseObject { get; set; }
        public string ResponseMessage { get; set; }
        public bool IsSuccess { get; set; }

        public async Task Post(string action, Req parameters)
        {
            using (var client = new HttpClient()
            {
                BaseAddress = new Uri(Constants.Host)
            })
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpContent content = new StringContent(JsonConvert.SerializeObject(parameters));
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                HttpResponseMessage response = await client.PostAsync(action, content).ConfigureAwait(false);
                IsSuccess = response.IsSuccessStatusCode;

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    ResponseObject = JsonConvert.DeserializeObject<Res>(data);
                }
                else
                {
                    string data = await response.Content.ReadAsStringAsync();
                    ResponseMessage = JsonConvert.DeserializeObject<string>(data);
                }
            };
        }
    }
}
