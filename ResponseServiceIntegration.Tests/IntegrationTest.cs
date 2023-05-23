using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ResponseService.Models;
using WireMock.Server;

namespace ResponseServiceIntegration.Tests;

public class IntegrationTest
{
    [Fact]
    public async void SendEmailAsync()
    {
        var data = new EmailModel()
        {
            To = "newmailfortests1@gmail.com",
            Content = "Hello World"
        };

        var server = WireMockServer.Start();
        var httpClient = server.CreateClient();
        httpClient.BaseAddress = new Uri($"https://nurananacafova-responseservice.nativeci.app");

        var response = await httpClient.PostAsJsonAsync("/api/Mail/SendMail", data);
        var body = await response.Content.ReadAsStringAsync();
        var actualResult = JsonConvert.DeserializeObject<Task>(body);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(response);
    }
}