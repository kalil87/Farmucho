using Microsoft.EntityFrameworkCore;

namespace Farmucho.Models
{
    public class FarmaciaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer("Data Source=LAPTOP-RBHJ499K\\SQLEXPRESS;Initial catalog=Farmacia; Integrated Security=True");
        }
        public DbSet<Inventario>? Inventario { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
    }
}