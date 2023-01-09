using CMZ.Lab.Application.DTO;
using CMZ.Lab.Application.Interface;
using CMZ.Lab.Application.Main;
using CMZ.Lab.Application.Main.Validations;
using CMZ.Lab.Domain.Interface.UnitOrWork;
using CMZ.Lab.Infrastructure.Data;
using CMZ.Lab.Vertical.Mapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
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
    var xmlFileName =$"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));     
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

builder.Services.AddAutoMapper(x=>x.AddProfile(new AutoMapperProfile()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
