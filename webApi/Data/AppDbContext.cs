using Microsoft.EntityFrameworkCore;

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
    }
}
