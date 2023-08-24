var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Hello World!");

builder.Services.AddControllers();

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
