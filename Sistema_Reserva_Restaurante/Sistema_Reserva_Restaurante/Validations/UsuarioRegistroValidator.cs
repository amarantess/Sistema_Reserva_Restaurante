using FluentValidation;
using Sistema_Reserva_Restaurante.DTOs;
using Sistema_Reserva_Restaurante.Exceptions;

namespace Sistema_Reserva_Restaurante.Validations
{
	public class UsuarioRegistroValidator : AbstractValidator<UsuarioRegistroDto>
	{
		public UsuarioRegistroValidator()
		{
			RuleFor(u => u.Nome)
				.NotEmpty().WithMessage(ResourceMessagesException.NOME_VAZIO);

			RuleFor(u => u.Email)
				.NotEmpty().WithMessage(ResourceMessagesException.EMAIL_VAZIO)
				.EmailAddress().WithMessage(ResourceMessagesException.EMAIL_INVALIDO);

			RuleFor(u => u.Senha)
				.NotEmpty().WithMessage(ResourceMessagesException.SENHA_VAZIA)
				.MinimumLength(6).WithMessage(ResourceMessagesException.SENHA_INVALIDA);
		}
	}
}
