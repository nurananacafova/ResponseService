using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using ResponseService;
using ResponseService.Models;

namespace ResponseServiceUnit.Tests.System;

public class TestResponseService
{
    // [Fact]
    // public async Task SendEmailAsync()
    // {
    //     var data = new EmailModel()
    //     {
    //         To = "newmailfortests1@gmail.com",
    //         From = "newmailfortests1@gmail.com",
    //         Password = "ngrtheilnrcfzroz",
    //         Content = "Hello World"
    //     };
    //     var fixture = new Fixture().Customize(new AutoMoqCustomization());
    //
    //     var mockLogger = new Mock<ILogger<EmailService>>();
    //     var mockMailSettings =fixture.Create< Mock<IOptions<MailSettings>>>();
    //     var sut = new EmailService(mockLogger.Object,mockMailSettings.Object);
    //     await sut.SendEmailAsync(data);
    // }
}