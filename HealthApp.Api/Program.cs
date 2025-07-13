using HealthApp.Application.Interfaces;
using HealthApp.Application.Services;
using HealthApp.Infrastructure.Interfaces;
using HealthApp.Infrastructure.Persistence;
using HealthApp.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HealthApp.Api;

public sealed class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        builder.Services.AddDbContext<HealthAppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(HealthAppDbContext)));
        });

        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IAssessmentService, AssessmentService>();

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