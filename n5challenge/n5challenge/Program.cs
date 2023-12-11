using Confluent.Kafka;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using n5challenge.Application.Middlewares.Log;
using n5challenge.Infraestructure.EntityFramework.Context;
using n5challenge.Infraestructure.UnitOfWork.Implementation;
using n5challenge.Infraestructure.UnitOfWork.Interface;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<N5ChallengeContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("N5Connection"));
    options.EnableSensitiveDataLogging();
});

builder.Services.AddElasticsearch(builder.Configuration);

// Add services to the container.
var producerConfiguration = new ProducerConfig();
builder.Configuration.Bind("producerconfiguration", producerConfiguration);

builder.Services.AddSingleton<ProducerConfig>(producerConfiguration);
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
