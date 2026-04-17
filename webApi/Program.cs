using Microsoft.EntityFrameworkCore;
using webApi.Data;
using webApi.Features.User.Repository;
using webApi.Features.User.Services;

var builder = WebApplication.CreateBuilder(args);

//Configuração do banco SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    // Cria um arquivo local chamado parkFlow.db
    options.UseSqlite("Data Source=parkFlow.db")
);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
