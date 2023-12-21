using FastEndpoints;

namespace Signup;

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
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("your name is required!")
            .MinimumLength(3).WithMessage("name is too short!")
            .MaximumLength(25).WithMessage("name is too long!");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("email address is required!")
            .EmailAddress().WithMessage("the format of your email address is wrong!");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("a password is required!")
            .MinimumLength(6).WithMessage("password is too short!")
            .MaximumLength(25).WithMessage("password is too long!");
    }
}

public class Response
{
    public string Message { get; set; }
}