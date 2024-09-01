using APIAnime.Model;
using APIAnime.Repository;
using Microsoft.AspNetCore.Mvc;

namespace APIAnime.EndPoint;
public static class GeneroEndPoint
{
    public static void AddEndPointGenero(this WebApplication app)
    {
        app.MapGet("/generos", async ([FromServices] GeneroRepository genero) =>
        {
            var generos = await genero.GetAsync();
            return (generos.Any()) ? Results.Ok(generos) : Results.NotFound("Não há generos cadastrados ainda!");
        });

        app.MapGet("/generos/{id}", async ([FromServices] GeneroRepository genero, int id) =>
        {
            var generoProcurado = await genero.GetByIdAsync(id);

            return (generoProcurado is not null) ? Results.Ok(generoProcurado) : Results.NotFound($"Não foi possivel encontrar um genero com id {id}");
        });

        app.MapPost(("/generos"), ([FromServices] GeneroRepository generoRepository, [FromBody] Genero generosPost) =>
        {

            var created = generoRepository.Create(generosPost);

            return (created) ? Results.Ok("Criado com sucesso!") : Results.NotFound("Houve um problema no camino");
        });

        app.MapPut("/generos", ([FromServices] GeneroRepository generoRepository, [FromBody] Genero generosPost) =>
        {

            var findById = generoRepository.GetById(generosPost.GeneroId);

            if (findById is not null)
            {
                findById.Nome = generosPost.Nome;
                findById.Descricao = generosPost.Descricao;

                generoRepository.Put(findById);
                return Results.Ok($"{generosPost.Nome} atualizado com sucesso!");
            }

            return Results.BadRequest("Houve um problema durante a atualização!");
        });

        app.MapDelete(("/generos/{id}"), ([FromServices] GeneroRepository generoRepository, int id) =>
        {
            var findById = generoRepository.GetById(id);

            if (findById is not null)
            {
                generoRepository.Delete(id);
                return Results.Ok("Deletado com sucesso");
            }

            return Results.NotFound($"Genero com o id {id} não f encontrado!");


        });
    }
}

