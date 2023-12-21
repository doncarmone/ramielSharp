using FastEndpoints;
using System.Globalization;
using Entities;
using Org.BouncyCastle.Crypto.Generators;

namespace Signup;

sealed class Mapper : Mapper<Request, Response, object>
{
    static readonly CultureInfo _culture = new("es-mx");

    public override Users ToEntity(Request r)
        => new()
        {
            Email = r.Email.ToLower(),
            Name = _culture.TextInfo.ToTitleCase(r.Name),
            // PasswordHash = BCrypt.Net.BCrypt.HashPassword(r.Password),
            Password = "adasdasd",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            IdRole = 2,
            Banned = false, 
        };
}