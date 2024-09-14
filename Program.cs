using APIAnime.Context;
using APIAnime.EndPoint;
using APIAnime.Model;
using APIAnime.Repository;
using APIAnime.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AnimeContext>();
builder.Services.AddTransient<GeneroRepository>();
builder.Services.AddTransient<DesenhoRepository>();
builder.Services.AddTransient <PersonagemRepository> ();
builder.Services.AddAuthorization();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services
        .AddIdentityApiEndpoints<PessoaComAcesso>()
        .AddEntityFrameworkStores<AnimeContext>();

var app = builder.Build();


app.AddEndPointGenero();
app.AddEndPointDesenho();
app.AddEndPointPersonagem();
app.MapGroup("auth").MapIdentityApi<PessoaComAcesso>().WithTags("Autorização");
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
