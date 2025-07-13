using HealthApp.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthApp.Api;

public sealed class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<HealthAppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(HealthAppDbContext)));
        });

        var app = builder.Build();

        app.MapControllers();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.Run();       
    }
}