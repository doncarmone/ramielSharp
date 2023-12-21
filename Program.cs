global using FastEndpoints;
global using FluentValidation;
using Database;
using FastEndpoints.Swagger;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
    // .AddJWTBearerAuth("TokenSigningKey")
    // .AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

var app = builder.Build();


// .UseAuthentication() 
// .UseAuthorization()

app.UseFastEndpoints(c =>
    { 
        c.Endpoints.RoutePrefix = "api";
    });
app.UseSwaggerGen();

app.Run();

