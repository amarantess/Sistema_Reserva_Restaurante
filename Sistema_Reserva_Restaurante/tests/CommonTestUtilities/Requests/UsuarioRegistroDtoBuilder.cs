using Bogus;
using Sistema_Reserva_Restaurante.DTOs;

namespace CommonTestUtilities.Requests
{
	public class UsuarioRegistroDtoBuilder
	{
		public static UsuarioRegistroDto Build(int passwordLength = 10)
		{
			return new Faker<UsuarioRegistroDto>()
				.RuleFor(user => user.Nome, (f) => f.Person.FirstName)
				.RuleFor(user => user.Email, (f, user) => f.Internet.Email(user.Nome))
				.RuleFor(user => user.Senha, (f) => f.Internet.Password(passwordLength));
		}
	}
}
