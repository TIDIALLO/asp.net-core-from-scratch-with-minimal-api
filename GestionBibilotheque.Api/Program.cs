using GestionBibilotheque.Api.Data;
using GestionBibilotheque.Api.Enpoints;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = "Data  Souce = Bibliotheque.db";
var connectionString = builder.Configuration.GetConnectionString("Bibliotheque");
builder.Services.AddSqlite<BookDbContext>(connectionString);

builder.Services.AddAutoMapper(typeof(Program));

//Add Swagger
builder.Services.AddEndpointsApiExplorer(); // Nécessaire pour documenter les endpoints minimal API
builder.Services.AddSwaggerGen();

// Ajouter CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
/*builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "My API",
        Version = "v1",
        Description = "An example API for managing books",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Tidiane Diallo",
            Email = "diallotidiane014@gmail.com",
            Url = new Uri("https://example.com")
        }
    });
});*/


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Génère la documentation JSON
    app.UseSwaggerUI(); // Fournit l'interface utilisateur pour tester les endpoints
}

app.MapBookApis();
await app.MigrateDbAsync();

app.UseCors("AllowAll");


app.Run();
