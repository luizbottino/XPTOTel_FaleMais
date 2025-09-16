using XPTOTel_FaleMais.Application.Interfaces;
using XPTOTel_FaleMais.Application.Services;
using XPTOTel_FaleMais.Infrastructure.Repositories;
using XPTOTel_FaleMais.Application.Commands.Usuarios;
using System.Text.Json.Serialization;
using XPTOTel_FaleMais.Infrastructure.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using XPTOTel_FaleMais.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IPlanoRepository, PlanoRepository>();

builder.Services.AddScoped<ITarifaRepository, TarifaRepository>();

builder.Services.AddScoped<ICalculadoraService, CalculadoraService>();

builder.Services.AddScoped<ISenhaHashingService, SenhaHashingService>();

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CriarUsuarioCommand).Assembly));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JwtSettings:SecretKey"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidateLifetime = true,
        RoleClaimType = System.Security.Claims.ClaimTypes.Role
    };
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
