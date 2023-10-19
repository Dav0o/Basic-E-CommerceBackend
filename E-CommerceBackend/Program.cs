using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using static Microsoft.AspNetCore.Builder.WebApplication;

var builder = WebApplication.CreateBuilder(args);

// Add External Dependencies
builder.Services.AddDomain(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

// Add HttpClientFactory
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    // Con este ignoramos las referencias circulares y no se muestran en el JSON
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplication();

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
