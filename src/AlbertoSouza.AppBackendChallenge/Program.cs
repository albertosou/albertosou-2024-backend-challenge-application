using AlbertoSouza.AppBackendChallenge.Infrastructure.HealtCheck;
using AlbertoSouza.AppBackendChallenge.Infrastructure.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.UseHealthChecksServices();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHealthChecks();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }