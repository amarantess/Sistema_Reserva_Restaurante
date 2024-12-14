namespace Sistema_Reserva_Restaurante.Models
{
	public class Usuario
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string Role { get; set; } = "Cliente"; // "Cliente" ou "Administrador"
	}
}
