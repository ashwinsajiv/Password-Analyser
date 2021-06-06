using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace PasswordAnalyser.Controllers
{
    public class PasswordControllerAPITest
    {
        [Fact]
        public async Task TestPOSTSuccess()
        {
            using (var client = new TestClientProvider().Client)
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(new HttpMethod("POST"), "/Password");
                requestMessage.Content = new StringContent(JsonConvert.SerializeObject("password"), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/Password", requestMessage.Content);
                response.EnsureSuccessStatusCode();
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}