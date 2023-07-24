using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Marlin.sqlite.Data;
using Marlin.sqlite.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
var origins = "_origins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_origins",
                      policy =>
                      {
                          policy.WithOrigins("*").AllowAnyHeader()
                              .AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddHttpContextAccessor();

// Generate a random secure secret key
byte[] GenerateRandomSecretKey()
{
    var secretKey = new byte[32]; // 32 bytes = 256 bits
    using (var rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(secretKey);
    }
    return secretKey;
}

// Retrieve the secret key
var secretKey = GenerateRandomSecretKey();

// Update the appsettings.json file with the actual secret key
var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
var appSettingsJson = File.ReadAllText(appSettingsPath);
dynamic appSettings = Newtonsoft.Json.JsonConvert.DeserializeObject(appSettingsJson);
appSettings["Jwt"]["SecretKey"] = Convert.ToBase64String(secretKey);
File.WriteAllText(appSettingsPath, Newtonsoft.Json.JsonConvert.SerializeObject(appSettings));

// JWT authentication configuration
var issuer = appSettings["Jwt"]["Issuer"].Value;
var audience = appSettings["Jwt"]["Audience"].Value;

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey)
    };
});

builder.Services.AddSingleton<IUriService>(o =>
{
    var accessor = o.GetRequiredService<IHttpContextAccessor>();
    var request = accessor.HttpContext.Request;
    var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
    return new UriService(uri);
});
builder.Services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.Converters.Add(new NullableDateTimeConverter());
                        options.JsonSerializerOptions.Converters.Add(new NullableDecimalConverter());
                        options.JsonSerializerOptions.IgnoreNullValues = true;
                    });

var app = builder.Build();
app.UseCors(origins);

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



// Configure Swagger
app.UseSwagger();
app.UseSwaggerUI();

/*app.UseKestrel(options =>
{
    options.ListenAnyIP(80); // HTTP port 80

    // HTTPS port 443 with SSL certificate
    var certificatePath = Path.Combine(Directory.GetCurrentDirectory(), "certificate.pfx");
    var certificatePassword = "your_certificate_password"; // Replace this with the actual password for your certificate
    options.ListenAnyIP(443, listenOptions =>
    {
        listenOptions.UseHttps(certificatePath, certificatePassword);
    });
});*/

app.Run();
