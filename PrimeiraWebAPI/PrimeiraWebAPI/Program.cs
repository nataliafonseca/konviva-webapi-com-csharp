using PrimeiraWebAPI.Services;
using Microsoft.EntityFrameworkCore;
using PrimeiraWebAPI.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AddTransient registra nossa classe para inserção, com o tempo de vida "Transitório". Assim, para cada solicitação, uma nova instância é criada.
builder.Services.AddTransient<AlbunsService>();


string connectionString = "Server=localhost;Database=PrimeiraAPI;User Id=sa;Password=SQLServer2019;";
// se não estiver usando o SQLExpress tente
// Server=localhost;Database=PrimeiraAPI;Trusted_Connection=True;
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
