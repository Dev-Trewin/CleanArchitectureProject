// src/MyApp.Api/Startup.cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.UseCases;
using MyApp.Domain.Repositories;
using MyApp.Infrastructure.Repositories;
using MyApp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews()
             .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNamingPolicy = null; // Set property naming policy to null
                 options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Add converter for enum values
                 options.JsonSerializerOptions.IgnoreNullValues = true; // Ignore null values during serialization
                 options.JsonSerializerOptions.PropertyNameCaseInsensitive = true; // Make property name comparison case-insensitive
             });
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<CreateUser>();
        services.AddScoped<GetUser>();
        services.AddScoped<GetAllUsers>();
        services.AddScoped<UpdateUser>();
        services.AddScoped<DeleteUser>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
