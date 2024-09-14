using APIAnime.Model;
using APIAnime.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIAnime.EndPoint;
public static class DesenhoEndPoint
{
    public static void AddEndPointDesenho(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("desenhos")
                                .RequireAuthorization()
                                .WithTags("Desenhos");

        groupBuilder.MapGet("", async ([FromServices] DesenhoRepository desenhoRepository) =>
        {
            var list = await desenhoRepository.GetAsync();
            return (list.Any() ) ? Results.Ok(list) : Results.NotFound("Ainda não há desenho cadastro!");
        });


        groupBuilder.MapGet("{id}", async ([FromServices] DesenhoRepository desenhoRepository, int id) =>
        {
            var desenho = await desenhoRepository.GetByIdAsync(id);

            return (desenho is not null) ? Results.Ok(desenho) : Results.NotFound($"OPSS! Não encontramos nenhum desenho com o id {id}");
        });


        groupBuilder.MapPost("", ([FromServices] DesenhoRepository desenhoRepository, [FromBody] Desenho desenhoPost) =>
        {
            var created = desenhoRepository.Create(desenhoPost);

            return (created) ? Results.Ok("Criado com sucesso!") :Results.NotFound("houve um problema na criação do anime!");
        });


        app.MapPut("", ([FromServices] DesenhoRepository desenhoRepository, [FromBody] Desenho desenhoPost) =>
        {
            var find = desenhoRepository.GetById(desenhoPost.DesenhoId);

            if (desenhoPost is not null)
            {
                find.Nome = desenhoPost.Nome;
                find.AnoDeLancamento = desenhoPost.AnoDeLancamento;
                find.GeneroId = desenhoPost.GeneroId;

                desenhoRepository.Put(find);
                return Results.Ok("Desenho atualizado com sucesso!");
            }

            return Results.NotFound($"Desenho com o id {desenhoPost.DesenhoId} não encontrado");


        });

        groupBuilder.MapDelete("{id}", ([FromServices] DesenhoRepository desenhoRepository, int id) =>
        {
            var find = desenhoRepository.GetById(id);

            if(find is not null)
            {
                desenhoRepository.Delete(id);
                return Results.Ok("Removido com sucesso!");
            }

            return Results.NotFound("Não encontramos o id");
        });

    }
}

