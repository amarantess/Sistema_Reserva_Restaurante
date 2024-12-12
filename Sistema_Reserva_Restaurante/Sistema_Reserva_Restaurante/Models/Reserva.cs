namespace Sistema_Reserva_Restaurante.Models
{
	public class Reserva
	{
		public int Id { get; set; }
		public int UsuarioId { get; set; }
		public int MesaId { get; set; }
		public DateTime DataReserva { get; set; }
		public string Status { get; set; } // "Ativo", "Cancelado"

		// Navegação
		public Usuario Usuario { get; set; }
		public Mesa Mesa { get; set; }
	}
}
