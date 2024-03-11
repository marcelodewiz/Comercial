using Comercial.API.Endpoints;
using Comercial.Shared.Dados.Banco;
using Comercial.Shared.Modelos.Modelos;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ComercialContext>();
builder.Services.AddTransient<DAL<Cliente>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

app.AddEndpointsClientes();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();
