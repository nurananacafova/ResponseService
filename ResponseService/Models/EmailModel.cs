namespace ResponseService.Models;

public class EmailModel
{
    public string To { get; set; }
    public string From { get; set; }
    public string Password { get; set; }

    public string Content { get; set; }
}