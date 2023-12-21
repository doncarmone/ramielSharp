using Database;
using Entities;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using ramielsharp.DTOs;

namespace Signup;

sealed class Endpoint : Endpoint<Request, Response, Mapper>
{
    private readonly AppDbContext _context;
    
    public Endpoint(AppDbContext context)
    {
        _context = context;
    }
    
    public override void Configure()
    {
        Post("/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var users = await _context.Users.ToListAsync(cancellationToken: c);

        var emails = "";
        foreach (var user in users)
        {
            emails = emails + $"{user.Email} ";
        }
        await SendAsync(new()
        {
            Message = emails
        }, cancellation: c);
    }
}