using System;
using Newtonsoft.Json;
using RestSharp;

namespace PasswordAnalyserConsole.Services
{
    public class ResponseObject
    {
        public string Strength { get; set; }
        public int Breach { get; set; }
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
            var result = CheckStrength();
            Strength = result.Item1;
            Breach = result.Item2;
        }
        public (string, int) CheckStrength()
        {
            var client = new RestClient(PasswordAnalyserURL);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            string body = "\"" + _password + "\"";
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content);
            return (res.Strength, res.Breach);
        }
    }
}
