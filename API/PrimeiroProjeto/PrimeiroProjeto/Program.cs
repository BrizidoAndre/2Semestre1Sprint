var builder = WebApplication.CreateBuilder(args);

//app.MapGet("/", () => "Hello World!");

builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

var app = builder.Build();

//Adiciona mapeamento dos Controllers
app.MapControllers();

app.UseHttpsRedirection();

app.Run();
