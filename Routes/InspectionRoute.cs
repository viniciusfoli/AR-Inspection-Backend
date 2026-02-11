using ARinspection.Data;
using ARinspection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ARinspection.Routes;

public static class InspectionRoute
{
    public static void InspectionRoutes(this WebApplication app) {
        var route = app.MapGroup(prefix:"AR");
        route.MapPost("", 
            async (PecaRequest req, PecaContext context) =>
        {
            var peca = new PecaModel(req.nome, req.temperatura, req.vibracao, req.instrucao, req.historicoJson, req.id);
            await context.AddAsync(peca);
            await context.SaveChangesAsync();
            return Results.Created($"/AR/{peca.Id}", peca);
        });
        // No InspectionRoute.cs, adicione esta rota:
        route.MapPost("{id:guid}/comentario", async (Guid id, [FromBody] string texto, PecaContext context) =>
        {
            var peca = await context.people.FirstOrDefaultAsync(x => x.Id == id);
            if (peca == null) return Results.NotFound();

            // 1. Converte o texto do banco (JSON) para uma lista de objetos C#
            var historico = System.Text.Json.JsonSerializer.Deserialize<List<dynamic>>(peca.HistoricoJson) ?? new List<dynamic>();

            // 2. Cria o novo item (Pilha: insere no índice 0)
            var novoItem = new { texto = texto, data = DateTime.Now.ToString("yyyy-MM-dd HH:mm") };
            historico.Insert(0, novoItem);

            // 3. Serializa de volta para string JSON e salva no banco
            peca.HistoricoJson = System.Text.Json.JsonSerializer.Serialize(historico);

            await context.SaveChangesAsync();
            return Results.Ok(peca);
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
                

                peca.changeName(req.nome, req.temperatura, req.vibracao, req.instrucao, req.historicoJson);
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
