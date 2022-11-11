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
            return await db.Monkey.FindAsync(id)
                is Monkey model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMonkeyById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<NotFound, NoContent>> (int id, Monkey monkey, MonkeyApp1Context db) =>
        {
            var foundModel = await db.Monkey.FindAsync(id);

            if (foundModel is null)
            {
                return TypedResults.NotFound();
            }
            
            db.Update(monkey);
            await db.SaveChangesAsync();

            return TypedResults.NoContent();
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

        group.MapDelete("/{id}", async Task<Results<Ok<Monkey>, NotFound>> (int id, MonkeyApp1Context db) =>
        {
            if (await db.Monkey.FindAsync(id) is Monkey monkey)
            {
                db.Monkey.Remove(monkey);
                await db.SaveChangesAsync();
                return TypedResults.Ok(monkey);
            }

            return TypedResults.NotFound();
        })
        .WithName("DeleteMonkey")
        .WithOpenApi();
    }
}
