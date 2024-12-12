namespace Sistema_Reserva_Restaurante.DTOs
{
	public class UsuarioRegistroDto
	{
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string Role { get; set; } = "Cliente"; // Padrão: Cliente
	}
}
