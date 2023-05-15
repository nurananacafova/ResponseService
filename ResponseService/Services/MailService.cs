using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeKit;
using ResponseService.Models;
using ResponseService.Services;

namespace ResponseService;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;

    public EmailService(ILogger<EmailService> logger)
    {
        _logger = logger;
    }


    public async Task SendEmailAsync([FromBody] EmailModel emailModel)

    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(emailModel.From));
        _logger.LogInformation($"Mail received from: {emailModel.From}");
        email.To.Add(MailboxAddress.Parse(emailModel.To));
        _logger.LogInformation($"Mail send to: {emailModel.To}");
        var builder = new BodyBuilder();
        builder.HtmlBody = emailModel.Content;
        email.Body = builder.ToMessageBody();
        _logger.LogInformation($"Mail content: {emailModel.Content}");
        using var smtp = new SmtpClient();
        smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTlsWhenAvailable);
        _logger.LogInformation("Connect to smtp.gmail.com");
        smtp.Authenticate(emailModel.From, emailModel.Password);
        await smtp.SendAsync(email);
        _logger.LogInformation("Mail sent!");
        smtp.Disconnect(true);
        _logger.LogInformation("Disconnect from smtp.gmail.com");
    }
}