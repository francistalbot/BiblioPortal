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
               await context.Outils.ToListAsync());

            group.MapGet("/{id:int}", async (BiblioDbContext context, int id) =>
            {
                var outil = await context.Outils.FindAsync(id);
                return outil is not null ? Results.Ok(outil) : Results.NotFound();
            }); 

            return group;
        }
    }
}
