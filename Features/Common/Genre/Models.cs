using FastEndpoints;

namespace Genres;

public class Request
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

sealed class Validator : Validator<Request>
{
    public Validator()
    {
        
    }
}

public class Response
{
    public string Message { get; set; }
}
