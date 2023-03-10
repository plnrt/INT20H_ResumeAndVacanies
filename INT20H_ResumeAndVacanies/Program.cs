using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SqlLiteManager;
using SqlLiteManager.Impl;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISqliteRepositoryManager, SqliteRepositoryManager>();

//builder.WebHost.UseUrls("http://localhost:80");
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;

                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = builder.Configuration["Tokens:Issuer"],
                        ValidAudience = builder.Configuration["Tokens:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Tokens:Key"]))
                    };

                });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//using IHost host = Host.CreateDefaultBuilder(args)
//    .ConfigureServices((_, services) =>
//        services.AddSingleton<ISqliteRepositoryManager, SqliteRepositoryManager>())
//    .Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
