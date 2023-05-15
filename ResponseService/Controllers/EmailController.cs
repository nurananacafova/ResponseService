using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResponseService.Models;
using ResponseService.Services;

namespace ResponseService.Controllers;

[Route(("api/[controller]"))]
[ApiController]
public class MailController : Controller
{
    private readonly IEmailService _mailService;

    public MailController(IEmailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost("SendMail")]
    public async Task<IActionResult> SendMail([FromBody] EmailModel request)
    {
        await _mailService.SendEmailAsync(request);
        return Ok();
    }
}