using Microsoft.EntityFrameworkCore;
using webApi.Features.Company.Models;
using webApi.Features.ParkingSpot.Models;
using webApi.Features.Payment.Models;
using webApi.Features.Ticket.Models;
using webApi.Features.User.Models;
using webApi.Features.Vehicle.Models;

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
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<ParkingSpot> Parking_Spot { get; set; }
        public DbSet<Payment> Payment { get; set; }
    }
}
