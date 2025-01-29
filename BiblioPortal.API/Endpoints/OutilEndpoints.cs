using BiblioPortal.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BiblioPortal.API.Endpoints
{
    public static class OutilEndpoints
    {
        public static WebApplication MapOutilEndpoints(this WebApplication app)
        {


            app.MapGet("/api/outil", async (BiblioDbContext context) =>
               await context.Outils.ToListAsync());

            app.MapGet("/api/outil/{id:int}", async (BiblioDbContext context, int id) =>
            {
                var outil = await context.Outils.FindAsync(id);
                return outil is not null ? Results.Ok(outil) : Results.NotFound();
            }); 

            return app;
        }
    }
}
