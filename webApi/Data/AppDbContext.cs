using Microsoft.EntityFrameworkCore;
using webApi.Features.Company.Models;
using webApi.Features.User.Models;

namespace webApi.Data
{
    //DbContext é a classe pricipal de EntityFramework
    //Ele representa a conexão com o BD
    public class AppDbContext : DbContext
    {
        //Contrutor recebe as configurações do Program.cs
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        //Aqui vai ficar as entidade do banco
        public DbSet<Company> Company { get; set; }
        public DbSet<User> User { get; set; }
    }
}
