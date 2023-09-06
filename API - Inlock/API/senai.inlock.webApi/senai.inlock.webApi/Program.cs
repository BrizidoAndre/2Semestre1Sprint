using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



//Adiciona o servi�o de controllers
builder.Services.AddControllers();

//Adicione o servi�o Swagger � cole��o de servi�os
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informa��es sobre a API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API InLock",
        Description = "API para resolu��o de um caso fict�cio - Projeto InLock - Backend API",

        TermsOfService = new Uri("https://help.habbo.com.br/hc/pt-br/articles/360011504000-Termos-e-Condi%C3%A7%C3%B5es"),
        Contact = new OpenApiContact
        {
            Name = "Senai Inform�tica - Turma Manh� Andr�",
            Url = new Uri("https://github.com/BrizidoAndre/2Semestre1Sprint/tree/main/API")
        }
    });

    //// Configura o Swagger para usar o arquivo XML gerado
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//Adiciona o servi�o Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Come�a a configura��o do Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
//Finaliza a configura��o Swagger


//Adiciona mapeamento dos Controllers
app.MapControllers();


app.UseHttpsRedirection();

app.Run();
