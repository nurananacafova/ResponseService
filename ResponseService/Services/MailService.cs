using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using ResponseService.Models;
using ResponseService.Services;

namespace ResponseService;

public class EmailService : IEmailService
{
    private readonly ILogger<EmailService> _logger;
    private readonly MailSettings _mailSettings;

    public EmailService(ILogger<EmailService> logger, IOptions<MailSettings> mailSettings)
    {
        _logger = logger;
        _mailSettings = mailSettings.Value;

    }




    public async Task SendEmailAsync([FromBody] EmailModel emailModel)

    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_mailSettings.From));
        _logger.LogInformation($"Mail received from: {_mailSettings.From}");
        email.To.Add(MailboxAddress.Parse(emailModel.To));
        _logger.LogInformation($"Mail send to: {emailModel.To}");
        var builder = new BodyBuilder();
        builder.HtmlBody = emailModel.Content;
        email.Body = builder.ToMessageBody();
        _logger.LogInformation($"Mail content: {emailModel.Content}");
        using var smtp = new SmtpClient();
        smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTlsWhenAvailable);
        _logger.LogInformation("Connect to smtp.gmail.com");
        smtp.Authenticate(_mailSettings.From, _mailSettings.Password);
        await smtp.SendAsync(email);
        _logger.LogInformation("Mail sent!");
        smtp.Disconnect(true);
        _logger.LogInformation("Disconnect from smtp.gmail.com");
    }
}