using APIAnime.Context;
using APIAnime.EndPoint;
using APIAnime.Model;
using APIAnime.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AnimeContext>();
builder.Services.AddTransient<GeneroRepository>();
builder.Services.AddTransient<DesenhoRepository>();
builder.Services.AddTransient <PersonagemRepository> ();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.MapGet("/", () => "API de anime!");


app.AddEndPointGenero();
app.AddEndPointDesenho();
app.AddEndPointPersonagem();
app.Run();
