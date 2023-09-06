using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



//Adiciona o serviço de controllers
builder.Services.AddControllers();

//Adicione o serviço Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informações sobre a API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API InLock",
        Description = "API para resolução de um caso fictício - Projeto InLock - Backend API",

        TermsOfService = new Uri("https://help.habbo.com.br/hc/pt-br/articles/360011504000-Termos-e-Condi%C3%A7%C3%B5es"),
        Contact = new OpenApiContact
        {
            Name = "Senai Informática - Turma Manhã André",
            Url = new Uri("https://github.com/BrizidoAndre/2Semestre1Sprint/tree/main/API")
        }
    });

    //// Configura o Swagger para usar o arquivo XML gerado
    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//Adiciona o serviço Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Começa a configuração do Swagger
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
//Finaliza a configuração Swagger


//Adiciona mapeamento dos Controllers
app.MapControllers();


app.UseHttpsRedirection();

app.Run();
