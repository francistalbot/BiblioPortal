using BiblioPortal.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BiblioPortal.API.Endpoints
{
    public static class OutilEndpoints
    {
        public static RouteGroupBuilder MapOutilEndpoints(this RouteGroupBuilder group)
        {


            group.MapGet("/", async (BiblioDbContext context) =>
               await context.Outils.ToListAsync()).RequireAuthorization();

            group.MapGet("/{id:int}", async (BiblioDbContext context, int id) =>
            {
                var outil = await context.Outils.FindAsync(id);
                return outil is not null ? Results.Ok(outil) : Results.NotFound();
            });

            group.MapPost("/", async (BiblioDbContext context, Outil newOutil) =>
            {
                if(newOutil is null) 
                    return Results.BadRequest();
                context.Outils.Add(newOutil);
                await context.SaveChangesAsync();
                return Results.Created($"/api/Outils/{newOutil.Id}", newOutil);
            });

            group.MapPut("/{id:int}", async (BiblioDbContext context, int id, Outil updatedOutil) =>
            {
                var outil = await context.Outils.FindAsync(id);
                if (outil is null)
                    return Results.NotFound();

                outil.Name = updatedOutil.Name;
                outil.Description = updatedOutil.Description;

                await context.SaveChangesAsync();

                return Results.NoContent();
            });

            group.MapDelete ("/{id:int}", async (BiblioDbContext context, int id) =>
            {
                var outil = await context.Outils.FindAsync(id);
                if (outil is null)
                    return Results.NotFound();

                context.Outils.Remove(outil);
                await context.SaveChangesAsync();

                return Results.NoContent();
            });
            return group;
        }
    }
}
