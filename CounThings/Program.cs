using CounThings.Application.Commands.Handlers;
using CounThings.Application.Commands.Handlers.Interfaces;
using CounThings.Application.Commands.Handlers.Interfaces.Payment;
using CounThings.Application.Commands.Handlers.PaymentHandler;
using CounThings.Infra.Context;
using CounThings.Infra.Repositories;
using CounThings.Infra.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["dbContextSettings:ConnectionString"];
builder.Services.AddDbContext<ActivityContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ICreateActivityHandler, CreateActivityHandler>();
builder.Services.AddScoped<IUpdateQuantityInActivityHandler, UpdateQuantityInActivityHandler>();
builder.Services.AddScoped<IActivityQueryHandler, ActivityQueryHandler>();
builder.Services.AddScoped<ICreatePaymentHandler, CreatePaymentHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
