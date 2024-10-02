using Todo.Data;

var builder = WebApplication.CreateBuilder(args); //Cria o builder 

builder.Services.AddControllers(); //Adiciona os controllers
builder.Services.AddDbContext<AppDbContext>(); //Adiciona o contexto

var app = builder.Build(); //Constrói a aplicação

app.MapControllers(); //Mapeia os controllers

app.Run(); //Roda a aplicação
