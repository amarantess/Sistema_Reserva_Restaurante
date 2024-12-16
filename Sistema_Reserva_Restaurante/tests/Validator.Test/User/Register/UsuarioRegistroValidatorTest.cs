using CommonTestUtilities.Requests;
using FluentAssertions;
using Sistema_Reserva_Restaurante.Exceptions;
using Sistema_Reserva_Restaurante.Validations;

namespace Validator.Test.User.Register
{
	public class UsuarioRegistroValidatorTest
	{
		[Fact]
		public void Success()
		{
			// Arrange
			var validator = new UsuarioRegistroValidator();

			var request = UsuarioRegistroDtoBuilder.Build();

			// Act
			var result = validator.Validate(request);

			// Assert
			result.IsValid.Should().BeTrue();
		}

		[Fact]
		public void Error_Name_Empty()
		{
			// Arrange
			var validator = new UsuarioRegistroValidator();

			var request = UsuarioRegistroDtoBuilder.Build();
			request.Nome = string.Empty;

			// Act
			var result = validator.Validate(request);

			// Assert
			result.IsValid.Should().BeFalse();
			result.Errors.Should().ContainSingle()
				.And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.NOME_VAZIO));
		}

		[Fact]
		public void Error_Email_Empty()
		{
			// Arrange
			var validator = new UsuarioRegistroValidator();

			var request = UsuarioRegistroDtoBuilder.Build();
			request.Email = string.Empty;

			// Act
			var result = validator.Validate(request);

			// Assert
			result.IsValid.Should().BeFalse();
			result.Errors.Should().ContainSingle()
				.And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.EMAIL_VAZIO));
		}

		[Fact]
		public void Error_Email_Invalid()
		{
			// Arrange
			var validator = new UsuarioRegistroValidator();

			var request = UsuarioRegistroDtoBuilder.Build();
			request.Email = "email.com";

			// Act
			var result = validator.Validate(request);

			// Assert
			result.IsValid.Should().BeFalse();
			result.Errors.Should().ContainSingle()
				.And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.EMAIL_INVALIDO));
		}

		[Theory]
		[InlineData(1)]
		[InlineData(2)]
		[InlineData(3)]
		[InlineData(4)]
		[InlineData(5)]
		public void Error_Password_Invalid(int passwordLength)
		{
			// Arrange
			var validator = new UsuarioRegistroValidator();

			var request = UsuarioRegistroDtoBuilder.Build(passwordLength);

			// Act
			var result = validator.Validate(request);

			// Assert
			result.IsValid.Should().BeFalse();
			result.Errors.Should().ContainSingle()
				.And.Contain(e => e.ErrorMessage.Equals(ResourceMessagesException.SENHA_INVALIDA));
		}
	}
}
