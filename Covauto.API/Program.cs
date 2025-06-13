using Covauto.Infrastructure;
using Covauto.Domain;
using Covauto.Applicatie.Interfaces;
using Covauto.Application.Services;
using Covauto.Applicatie.Repositories;
using Covauto.Infrastructure.Repositories;


namespace Covauto.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Voeg CORS toe zodat Blazor WebAssembly toegang heeft tot deze API
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowBlazorClient", policy =>
                {
                    policy.WithOrigins("https://localhost:7146") // <-- pas aan als je Blazor op andere poort draait
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            // 2. Voeg je services toe
            ServicesConfiguration.RegisterServices(
                builder.Services,
                builder.Configuration.GetConnectionString("DefaultConnection")
            );
            builder.Services.AddScoped<IAutoService, AutoService>();
            builder.Services.AddScoped<IGebruikerService, GebruikerService>();
            builder.Services.AddScoped<IAutosRepository, AutosRepository>();
            builder.Services.AddScoped<IGebruikerRepository, GebruikersRepository>();
           

            // 3. Controllers en Swagger
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // 4. Gebruik CORS (moet vóór controllers)
            app.UseCors("AllowBlazorClient");

            // 5. Swagger alleen in development
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // 6. Standaard middleware
            app.UseHttpsRedirection();
            app.UseAuthorization();

            // 7. Map routes naar controllers
            app.MapControllers();

            // 8. Start app
            app.Run();
        }
    }
}
