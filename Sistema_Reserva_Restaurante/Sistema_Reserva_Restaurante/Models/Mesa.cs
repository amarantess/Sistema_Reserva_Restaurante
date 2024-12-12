namespace Sistema_Reserva_Restaurante.Models
{
	public class Mesa
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public int Capacidade { get; set; }
		public string Status { get; set; } // "Disponível", "Reservada", "Inativa"
	}
}
