namespace Sistema_Reserva_Restaurante.Exceptions.ExceptionsBase
{
	public class ErrorOnValidationException : ReservaRestauranteException
	{
		public IList<string> ErrorMessages { get; set; }

		// O construtor precisa receber uma lista de erros como parâmetro e depois atribui a lista na propriedade ErrorMessages
		public ErrorOnValidationException(IList<string> errorMessages)
		{
			ErrorMessages = errorMessages;
		}


	}
}
