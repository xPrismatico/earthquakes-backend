using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class DbInitializer
{
    // Esta clase se encarga de inicializar la base de datos
    public static void InitDb(WebApplication app)
    {
        // Creamos la Scope para poder acceder al contexto de la base de datos
        // la obtenemos del contenedor de Servicios de la app
        using var scope = app.Services.CreateScope();

        // Obtenemos el contexto de la base de datos desde la Scope
        var context = scope.ServiceProvider.GetRequiredService<DataContext>()
            ?? throw new InvalidOperationException("No se pudo obtener el contexto de la base de datos.");

        SeedData(context);
    }

    private static void SeedData(DataContext context)
    {

        context.Database.Migrate();

        if (context.Earthquakes.Any()) return;

        var earthquakes = new List<Earthquake>
        {
            new Earthquake
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Latitude = 0.0,
                Longitude = 0.0,
                Depth = 0.0,
                Magnitude = 0.0
            },
            new Earthquake
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Latitude = 1.0,
                Longitude = 1.0,
                Depth = 1.0,
                Magnitude = 1.0
            }
        };

        context.Earthquakes.AddRange(earthquakes);
        context.SaveChanges();
    }
}
