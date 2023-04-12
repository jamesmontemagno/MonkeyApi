using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using MonkeyApp1.Data;
using MonkeyApp1.Models;
namespace MonkeyApp1;

public static class MonkeyEndpoints
{
    public static void MapMonkeyEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Monkey").WithTags(nameof(Monkey));

        group.MapGet("/", async (MonkeyApp1Context db) =>
        {
            return await db.Monkey.ToListAsync();
        })
        .WithName("GetAllMonkeys")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Monkey>, NotFound>> (int id, MonkeyApp1Context db) =>
        {
            return await db.Monkey.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Monkey model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMonkeyById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Monkey monkey, MonkeyApp1Context db) =>
        {
            var affected = await db.Monkey
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, monkey.Id)
                  .SetProperty(m => m.Name, monkey.Name)
                  .SetProperty(m => m.Details, monkey.Details)
                  .SetProperty(m => m.Image, monkey.Image)
                  .SetProperty(m => m.Location, monkey.Location)
                  .SetProperty(m => m.Population, monkey.Population)
                  .SetProperty(m => m.Latitude, monkey.Latitude)
                  .SetProperty(m => m.Longitude, monkey.Longitude)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMonkey")
        .WithOpenApi();

        group.MapPost("/", async (Monkey monkey, MonkeyApp1Context db) =>
        {
            db.Monkey.Add(monkey);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Monkey/{monkey.Id}",monkey);
        })
        .WithName("CreateMonkey")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, MonkeyApp1Context db) =>
        {
            var affected = await db.Monkey
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMonkey")
        .WithOpenApi();
    }
}
