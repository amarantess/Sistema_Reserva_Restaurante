using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sistema_Reserva_Restaurante.DTOs;
using Sistema_Reserva_Restaurante.Service.Usuario;

namespace Sistema_Reserva_Restaurante.Controllers
{
	[Route("usuarios")]
	[ApiController]
	public class AutenticacaoController : ControllerBase
	{
		private readonly IUsuarioService _usuarioService;
		public AutenticacaoController(IUsuarioService usuarioService)
		{
			_usuarioService = usuarioService;
		}

		[HttpPost("registrar")]
		public async Task<ActionResult> Registrar(UsuarioRegistroDto usuarioRegistroDto)
		{
			var registro = await _usuarioService.CriarUsuario(usuarioRegistroDto);
			return Created(string.Empty, registro);
		}

	}
}
