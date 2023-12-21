using Dapper;
using Database;
using Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;

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
        
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(req.Password);
        
        // if (user?.Password is null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
        //     ThrowError("Invalid login credentials!");
        
        await SendAsync(new()
        {
            Message = "Login",
            User = ""+hashedPassword,
            Token = "token"+user.Email
        });
    }
}