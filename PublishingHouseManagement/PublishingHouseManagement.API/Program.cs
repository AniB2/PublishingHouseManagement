using Microsoft.EntityFrameworkCore;
using PublishingHouseManagement.API.Infrastrcture.AuthHandlers.JWT;
using PublishingHouseManagement.API.Infrastrcture.AuthHandlers;
using PublishingHouseManagement.Persistence;
using PublishingHouseManagement.Persistence.Context;
using System.Reflection;
using FluentValidation.AspNetCore;
using FluentValidation;
using PublishingHouseManagement.Domain.Abstractions;
using PublishingHouseManagement.Persistence.UnitOfWork;
using PublishingHouseManagement.API.Infrastructure.SwaggerDocumentation;
using PublishingHouseManagement.API.Infrastrcture.Middlewares;

var builder = WebApplication.CreateBuilder(args);
Assembly applicationAssembly = typeof(PublishingHouseManagement.Application.AssemblyReference).Assembly;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerDocumentation();

builder.Services.AddAutoMapper(applicationAssembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddValidatorsFromAssembly(applicationAssembly);
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddTokenAuthentication(builder.Configuration.GetSection(nameof(JWTConfiguration)).GetSection(nameof(JWTConfiguration.Secret)).Value);
builder.Services.Configure<JWTConfiguration>(builder.Configuration.GetSection(nameof(JWTConfiguration)));

builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(applicationAssembly));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("manager", policy => policy.RequireClaim("manager"));
    options.AddPolicy("operator", policy => policy.RequireClaim("operator"));
    options.AddPolicy("senioroperator", policy => policy.RequireClaim("senioroperator"));
});

builder.Services.AddDbContext<PublishingHouseManagementContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionStrings.DefaultConnection))));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection(nameof(ConnectionStrings)));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();