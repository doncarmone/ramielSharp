using FastEndpoints;

namespace Login;

public class Request
{
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
    public string User { get; set; }
    public string Token { get; set; }
    
}
