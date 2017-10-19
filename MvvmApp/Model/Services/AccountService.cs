using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MvvmApp.Model.Services
{
    public class AccountService
    {
        static HttpClient client;

        const string uri = "http://xamarininteligente.azurewebsites.net/";

        void InitHttpClient()
        {
            if (client == null)
                client = new HttpClient();
        }

        public async Task<bool> RegisterAccount(Account account)
        {
            bool result = false;

            string jsonAccount = Newtonsoft.Json.JsonConvert.SerializeObject(account);
            StringContent requestContent = new StringContent(
                jsonAccount,
                Encoding.UTF8,
                "application/json"
            );

            string requestUri = $"{uri}api/Account/Register";

            InitHttpClient();

            using (HttpResponseMessage response
                   = await client.PostAsync(requestUri,requestContent))
            {
                using(HttpContent responseContent = response.Content)
                {
                    if (response.IsSuccessStatusCode) //response.EnsureSuccessStatusCode() 
                        result = true;
                    else
                    {
                        string responseString = await responseContent.ReadAsStringAsync();

                        var registrationResponse
                        = Newtonsoft.Json.JsonConvert.
                                    DeserializeObject<RegistrationResponse>(responseString);
                    }
                }
            }

            return result;
        }


    }
}
