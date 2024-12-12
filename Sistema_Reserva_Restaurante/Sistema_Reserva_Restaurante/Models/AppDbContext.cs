using Microsoft.EntityFrameworkCore;

namespace Sistema_Reserva_Restaurante.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions options) : base(options)
		{
			
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Mesa> Mesas { get; set; }
		public DbSet<Reserva> Reservas { get; set; }

	}
}
