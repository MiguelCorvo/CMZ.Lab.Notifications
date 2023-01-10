using CMZ.Lab.Application.DTO;
using CMZ.Lab.Application.Interface;
using CMZ.Lab.Application.Main;
using CMZ.Lab.Application.Main.Validations;
using CMZ.Lab.Domain.Interface.UnitOrWork;
using CMZ.Lab.Infrastructure.Data;
using CMZ.Lab.Services.Helpers;
using CMZ.Lab.Vertical.Mapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions
(
    options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Lab DDD EF",
        Description = "Simple Lab to check a DDD arqui with EF",
        TermsOfService = new Uri("http://localhost"),
        Contact = new OpenApiContact
        {
            Name = "...",
            Email = "",
            Url = new Uri("http://localhost")
        },
        License = new OpenApiLicense
        {
            Name = "...",
            Url = new Uri("http://localhost")
        }
    });
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));

    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearerAuth"
                }
            },
            new string[]{ }
        }
    }); ;
});

// Injection for services.
builder.Services.AddScoped<IValidator<CreateSubscriptionDTO>, SubscriptionDTOValidator>();
builder.Services.AddScoped<IValidator<CreateSubscriptionsDTO>, SubscriptionsDTOValidator>();
builder.Services.AddScoped(typeof(IUsersService), typeof(UsersService));
builder.Services.AddScoped(typeof(ISubscriptionsService), typeof(SubscriptionsService));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Add dbcontext for application.
builder.Services.AddDbContext<ApplicationDbContext>
(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Get config
var appSettingsSection = builder.Configuration.GetSection("Config");
builder.Services.Configure<AppSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<AppSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var Issuer = appSettings.Issuer;
var Audience = appSettings.Audience;

builder.Services.AddAutoMapper(x => x.AddProfile(new AutoMapperProfile()));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultScheme= JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userId = context.Principal.Identity.Name;
            return Task.CompletedTask;
        },
        OnAuthenticationFailed = context =>
        {
            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
            {
               context.Response.Headers.Add("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = Issuer,
        ValidateAudience = true,
        ValidAudience = Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();    
app.UseAuthorization();


app.MapControllers();

app.Run();
