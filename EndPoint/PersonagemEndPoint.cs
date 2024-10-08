﻿using APIAnime.Model;
using APIAnime.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ModelBinding;

namespace APIAnime.EndPoint;
public static class PersonagemEndPoint
{
    public static void AddEndPointPersonagem(this WebApplication app)
    {
        var groupBuilder = app.MapGroup("personagens")
                                .RequireAuthorization()
                                .WithTags("Personagens");

        groupBuilder.MapGet("", async ([FromServices] PersonagemRepository personagemRepository) =>
        {
            var list = await personagemRepository.GetAsync();

            return (list.Any()) ? Results.Ok(list) : Results.NotFound("Ainda não possuimos personagens cadastrados!");
        });

        groupBuilder.MapGet("{id}", async ([FromServices] PersonagemRepository personagemRepository, int id) =>
        {
            var personagem = await personagemRepository.GetByIdAsync(id);

            return (personagem is not null) ? Results.Ok(personagem) : Results.NotFound($"Ainda não há um personagem com o id {id}");

        });

        groupBuilder.MapPost("", ([FromServices] PersonagemRepository personagemRepository, [FromBody] Personagem personagemPost) =>
        {
            if(personagemPost is not null)
            {
                personagemRepository.Create(personagemPost);
                return Results.Ok("Criado com sucesso!");
            }

            return Results.NotFound("Não foi possivel fazer o cadastro.");

        });


        groupBuilder.MapPut("", ([FromServices] PersonagemRepository personagemRepository, [FromBody] Personagem personagemPost) =>
        {
            var find = personagemRepository.GetById(personagemPost.PersonagemId);
            if (find is not null)
            {
                find.Name = personagemPost.Name;
                find.Resumo = personagemPost.Resumo;
                find.Foto = personagemPost.Foto;
                find.DesenhoId = personagemPost.DesenhoId;

                personagemRepository.Put(find);
                return Results.Ok($"{personagemPost.Name} foi atualizado com sucesso!");
            }

            return Results.NotFound($"Não conseguimos atualizar {personagemPost.Name}");
        });

        groupBuilder.MapDelete("{id}", ([FromServices] PersonagemRepository personagemRepository, int id) =>
        {
            var find = personagemRepository.GetById(id);

            if(find is not null)
            {
                personagemRepository.Delete(id);
                return Results.Ok($"{find.Name} foi deletado!");
            }

            return Results.NotFound($"Não conseguimos encontrar o id {id}");

        });
    }
}

