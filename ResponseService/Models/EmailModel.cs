using Swashbuckle.AspNetCore.Annotations;

namespace ResponseService.Models;

public class EmailModel
{
    public string To { get; set; }
    public string Content { get; set; }
}