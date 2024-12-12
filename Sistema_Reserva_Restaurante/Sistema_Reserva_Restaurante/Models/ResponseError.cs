namespace Sistema_Reserva_Restaurante.Models
{
	public class ResponseError
	{
		public IList<string> Errors { get; set; }

		// Este construtor receberá uma lista de erros
		public ResponseError(IList<string> errors)
		{
			Errors = errors;
		}

		// Este construtor receberá um erro e adicionará na lista
		public ResponseError(string error)
		{
			Errors = new List<string>
			{
				error,
			};
		}
	}
}
