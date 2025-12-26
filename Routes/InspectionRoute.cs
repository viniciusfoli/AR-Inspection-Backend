using ARinspection.Models;
using ARinspection.Data;
using Microsoft.EntityFrameworkCore;

namespace ARinspection.Routes;

public static class InspectionRoute
{
    public static void InspectionRoutes(this WebApplication app) {
        var route = app.MapGroup(prefix:"AR");
        route.MapPost("", 
            async (PecaRequest req, PecaContext context) =>
        {
            var peca = new PecaModel(req.nome);
            await context.AddAsync(peca);
            await context.SaveChangesAsync();
        });
        route.MapGet("", async (PecaContext context) =>
        {
            var people = await context.people.ToListAsync();
            return Results.Ok(people);
        });
        route.MapPut("{id:guid}", 
            async (Guid id, PecaRequest req, PecaContext context) =>
            {
                var peca = await context.people.FirstOrDefaultAsync(x => x.Id == id);

                if (peca == null)
                    return Results.NotFound();
                

                peca.changeName(req.nome);
                await context.SaveChangesAsync();

                return Results.Ok(peca);
            });
        route.MapDelete("{id:guid}",
            async (Guid id, PecaContext context) =>
            {
                var peca = await context.people.FirstOrDefaultAsync(x => x.Id == id);

                if (peca == null)
                    return Results.NotFound();
                
                peca.SetInactive();
                await context.SaveChangesAsync();
                return Results.Ok(peca);
            });
    }
}
