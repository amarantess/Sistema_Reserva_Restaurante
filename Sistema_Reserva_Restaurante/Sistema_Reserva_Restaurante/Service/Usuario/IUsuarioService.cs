using Sistema_Reserva_Restaurante.DTOs;
using Sistema_Reserva_Restaurante.Models;

namespace Sistema_Reserva_Restaurante.Service.Usuario
{
	public interface IUsuarioService
	{
		Task<ResponseRegistered>  CriarUsuario(UsuarioRegistroDto usuarioRegistroDto);
	}
}
