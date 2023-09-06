using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

//
var builder = WebApplication.CreateBuilder(args);

//Adiciona o serviço de controllers
builder.Services.AddControllers();

//PARA OS TOKENS------------------------------------------------------

//Não esquecer de adicionar os 2 nuggets seguintes
//System.IdentityModel.Tokens.Jwt
//Microsoft.AspNetCore.Authentication.JwtBearer


//Adiciona serviço de Jwt Bearer (forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        //Valida quem está solicitando
        ValidateIssuer = true,

        //Valida quem está recebendo
        ValidateAudience = true,

        //Define se o tempo de expiração será validado
        ValidateLifetime = true,

        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expiração do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //Nome do issuer (de onde está vindo)
        ValidIssuer = "PrimeiroProjeto",

        //Nome do audience (para onde está indo)
        ValidAudience = "PrimeiroProjeto"

    };
});



//Adicione o serviço Swagger à coleção de serviços
builder.Services.AddSwaggerGen(options =>
{
    //Adiciona informações sobre a API no Swagger
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes Manhã",
        Description = "API para gerenciamento de filmes - Introdução da sprint 2 - Backend API",

        TermsOfService = new Uri("https://help.habbo.com.br/hc/pt-br/articles/360011504000-Termos-e-Condi%C3%A7%C3%B5es"),
        Contact = new OpenApiContact
        {
            Name = "Senai Informática - Turma Manhã André",
            Url = new Uri("https://github.com/BrizidoAndre/2Semestre1Sprint/tree/main/API")
        }
    });

    // Configura o Swagger para usar o arquivo XML gerado
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    //BLOCO DE CÓDIGO PARA APARECER UM INPUT DE AUTENTICAÇÃO NO SWAGGER
    //NESSE INPUT NÓS DEVEMOS SEMPRE COLOCAR UM "Bearer" ANTES DE COLOCAR UM TOKEN

    //Usando a autenticaçao no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT ",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });

    // FIM DO BLOCO DE CÓDIGO PARA AUTENTICAÇÃO DO SWAGGER

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

//Adiciona autenticação
app.UseAuthentication();

//Adiciona autorização
app.UseAuthorization();

app.UseHttpsRedirection();

app.Run();
