using ResponseService.Models;

namespace ResponseService.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailModel model);
}