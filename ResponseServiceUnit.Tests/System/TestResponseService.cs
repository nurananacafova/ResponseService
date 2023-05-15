using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using ResponseService;
using ResponseService.Models;

namespace ResponseServiceUnit.Tests.System;

public class TestResponseService
{
    [Fact]
    public async Task SendEmailAsync()
    {
        var data = new EmailModel()
        {
            To = "newmailfortests1@gmail.com",
            From = "newmailfortests1@gmail.com",
            Password = "ngrtheilnrcfzroz",
            Content = "Hello World"
        };
        var mockLogger = new Mock<ILogger<EmailService>>();
        var sut = new EmailService(mockLogger.Object);
        await sut.SendEmailAsync(data);
    }
}