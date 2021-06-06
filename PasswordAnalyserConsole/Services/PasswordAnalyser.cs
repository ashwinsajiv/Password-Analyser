using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace PasswordAnalyserConsole.Services
{
    public class ResponseObject
    {
        public string strength { get; set; }
        public int breach { get; set; }
    }
    public class PasswordAnalyser
    {
        private string _password;
        public string Strength { get; set; }
        public int Breach { get; set; }

        private const string PasswordAnalyserURL = "https://localhost:5001/Password/";
        public PasswordAnalyser(string password)
        {
            _password = password;
        }
        public async Task CheckStrength()
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(httpClientHandler);
            client.BaseAddress = new Uri(PasswordAnalyserURL);
            HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "/Password");
            requestMessage.Content = new StringContent(JsonConvert.SerializeObject(_password), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/Password", requestMessage.Content);
            response.EnsureSuccessStatusCode();
            var contents = await response.Content.ReadAsStringAsync();
            ResponseObject res = JsonConvert.DeserializeObject<ResponseObject>(contents);
            this.Strength = res.strength;
            this.Breach = res.breach;
        }
    }
}
