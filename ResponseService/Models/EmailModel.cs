using Swashbuckle.AspNetCore.Annotations;

namespace ResponseService.Models;

public class EmailModel
{
    public string To { get; set; }
    [SwaggerSchema(ReadOnly = true)] public string From { get; set; }
    [SwaggerSchema(ReadOnly = true)] public string Password { get; set; }

    public string Content { get; set; }
}