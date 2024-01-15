using RestWithASP_NET.Business.Implementations;
using RestWithASP_NET.Business;
using RestWithASP_NET.Repository;
using RestWithASP_NET.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using RestWithASP_NET.Model;
using MySqlConnector;
using Serilog;
using EvolveDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 1, 0)))
);

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

// Versioning API
builder.Services.AddApiVersioning();

//Dependency Injection
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();
builder.Services.AddScoped<IBookBusiness, BookBusinessImplementation>();
builder.Services.AddScoped<IBookRepository, BookRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void MigrateDatabase(string connection)
{
    try {
        var evolveConncetion = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConncetion, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}
