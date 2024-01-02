using Database;
using Entities;
using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;
using ramielsharp.Auth;


namespace Login;

sealed class Endpoint : Endpoint<Request, Response, Mapper>
{
    private readonly AppDbContext _context;
    
    public Endpoint(AppDbContext context)
    {
        _context = context;
    }
    
    public override void Configure()
    {
        Post("/login");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request req, CancellationToken ct)
    {

        var user = await _context.Users.Where(u => u.Email.Equals(req.Email)).FirstOrDefaultAsync();

        var key = Config["JwtSigningKey"];
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(req.Password,11);
        
        // if (user?.Password is null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
        //     ThrowError("Invalid login credentials!");
        bool testpass = BCrypt.Net.BCrypt.Verify(req.Password, user.Password);
        
        IEnumerable<string> roles = new List<string>() { "writer" };
        
        var token69 = JWTBearer.CreateToken(
            signingKey: Config["JwtSigningKey"]!,
            expireAt: DateTime.UtcNow.AddHours(4)!,
            roles: roles,
            permissions: roles,
            claims: ("idrole", user.IdRole+""));
        
        await SendAsync(new()
        {
            Message = "Login "+testpass+" "+token69,
            User = ""+hashedPassword,
            Token = "token: "+user.Email
        });
    }
}