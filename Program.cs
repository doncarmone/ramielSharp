global using FastEndpoints;
global using FluentValidation;
using Database;
using FastEndpoints.Swagger;
using FastEndpoints.Security;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument();
builder.Services.AddJWTBearerAuth("TokenSigningKey");
builder.Services.AddAuthorization();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

var app = builder.Build();


app.UseAuthentication(); 
app.UseAuthorization();

app.UseFastEndpoints(c =>
    { 
        c.Endpoints.RoutePrefix = "api";
    });
app.UseSwaggerGen();

app.Run();

