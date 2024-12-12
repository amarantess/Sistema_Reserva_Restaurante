using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Sistema_Reserva_Restaurante.Exceptions.ExceptionsBase;
using Sistema_Reserva_Restaurante.Models;
using System;
using System.Net;

namespace Sistema_Reserva_Restaurante.Exceptions
{
	public class ExceptionFilter : IExceptionFilter
	{
		public void OnException(ExceptionContext context)
		{
			// O método irá verificar se é um erro conhecido
			if(context.Exception is ReservaRestauranteException)
			{
				HandleProjectException(context);
			}
			else
			{
				ThrowUnknowException(context);
			}
		}

		// Se for um erro conhecido cairá no método de controle de erros tratados
		private void HandleProjectException(ExceptionContext context)
		{
			// O método de controle irá verificar se é um erro de validação
			if(context.Exception is ErrorOnValidationException)
			{
				var exception = context.Exception as ErrorOnValidationException;

				context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
				context.Result = new BadRequestObjectResult(new ResponseError(exception.ErrorMessages));
			}
		}

		private void ThrowUnknowException(ExceptionContext context)
		{
			context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Result = new ObjectResult(new ResponseError(ResourceMessagesException.ERRO_DESCONHECIDO));
		}
	}
}
