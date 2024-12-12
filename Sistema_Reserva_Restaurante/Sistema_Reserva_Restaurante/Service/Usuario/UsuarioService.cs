
using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Sistema_Reserva_Restaurante.AutoMapper;
using Sistema_Reserva_Restaurante.DTOs;
using Sistema_Reserva_Restaurante.Exceptions;
using Sistema_Reserva_Restaurante.Exceptions.ExceptionsBase;
using Sistema_Reserva_Restaurante.Models;
using Sistema_Reserva_Restaurante.Validations;

namespace Sistema_Reserva_Restaurante.Service.Usuario
{
	public class UsuarioService : IUsuarioService
	{
		private readonly AppDbContext _context;
		public UsuarioService(AppDbContext context)
		{
			_context = context;
		}

		public async Task<ResponseRegistered> CriarUsuario(UsuarioRegistroDto usuarioRegistroDto)
		{
			// Validar
			await Validate(usuarioRegistroDto);

			// Mapear
			var autoMapper = new MapperConfiguration(opt =>
			{
				opt.AddProfile(new AutoMapping());
			}).CreateMapper();

			var usuario = autoMapper.Map<Models.Usuario>(usuarioRegistroDto);

			// Criptografar Senha
			usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioRegistroDto.Senha);

			// Salvar no banco de dados
			_context.Add(usuario);
			await _context.SaveChangesAsync();

			return new ResponseRegistered
			{
				Nome = usuarioRegistroDto.Nome
			};
		}

		private async Task Validate(UsuarioRegistroDto usuarioRegistroDto)
		{
			var validator = new UsuarioRegistroValidator();
			var result = validator.Validate(usuarioRegistroDto);

			var emailExist = await _context.Usuarios.AnyAsync(u => u.Email == usuarioRegistroDto.Email);
			if (emailExist)
			{
				// Adicionando o erro de email já registrado na lista de erros
				result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessagesException.EMAIL_REGISTRADO));
			}

			if(result.IsValid == false)
			{
				var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

				throw new ErrorOnValidationException(errorMessages);
			}
		}


	}
}
