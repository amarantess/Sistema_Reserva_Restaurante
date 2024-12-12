using AutoMapper;
using Sistema_Reserva_Restaurante.DTOs;
using Sistema_Reserva_Restaurante.Models;
using Sistema_Reserva_Restaurante.Service.Usuario;

namespace Sistema_Reserva_Restaurante.AutoMapper
{
	public class AutoMapping : Profile
	{
		public AutoMapping()
		{
			Request();
		}

		private void Request()
		{
			CreateMap<UsuarioRegistroDto, Usuario>()
				.ForMember(dest => dest.Senha, opt => opt.Ignore());
		}
	}
}
