using Microsoft.EntityFrameworkCore;
using webApi.Data;

var builder = WebApplication.CreateBuilder(args);

//Configuração do banco SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    // Cria um arquivo local chamado app.db
    options.UseSqlite("Data Source=app.db")
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
