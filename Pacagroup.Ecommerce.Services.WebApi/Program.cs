﻿using HealthChecks.UI.Client;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Authentication;
using Pacagroup.Ecommerce.Services.WebApi.Modules.HealthCheck;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Injection;

using Pacagroup.Ecommerce.Services.WebApi.Modules.RateLimiter;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Versioning;
using Pacagroup.Ecommerce.Persistence;
using Pacagroup.Ecommerce.Application.UseCases;
using Pacagroup.Ecommerce.Services.WebApi.Modules.Feature;

var builder = WebApplication.CreateBuilder(args);

//Agregar servicios a contenedor de dependencias

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddFeature(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddInjection(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddVersioning();
builder.Services.AddHealthCheck(builder.Configuration);
//builder.Services.AddWatchDog(builder.Configuration);
builder.Services.AddRateLimiting(builder.Configuration);

var app = builder.Build();

//var logger = new LoggerConfiguration()
//                    .ReadFrom.Configuration(builder.Configuration)
//                    .Enrich.FromLogContext()
//                    .CreateLogger();

//Configura Http Request Pipeline

if (app.Environment.IsDevelopment()) 
{
    app.UseDeveloperExceptionPage();
    

};


//app.UseWatchDogExceptionLogger();
app.UseHttpsRedirection();
app.UseCors("policyApiEcommerce");
app.UseAuthentication();
app.UseAuthorization();
app.UseRateLimiter();
app.MapControllers();
app.MapHealthChecksUI();

app.MapHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    Predicate = _ => true,
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

//app.UseWatchDog(conf =>
//{
//    conf.WatchPageUsername = builder.Configuration["WatchDog:WatchPageUsername"];
//    conf.WatchPagePassword = builder.Configuration["WatchDog:WatchPagePassword"];
//});

app.Run();