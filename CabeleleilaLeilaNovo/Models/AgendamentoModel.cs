using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Agendamento
{

	public class AgendamentoModel
	{
		public string Data { get; set; }
		public string Hora { get; set; }
		public int IdCliente { get; set; }
		public int Id { get; set; }

		public int IdProcedimento { get; set; }

		public AgendamentoModel()
		{
			Data = string.Empty;
			Hora = string.Empty;
			IdCliente = 0;
			Id = 0;
			IdProcedimento = 0;
		}
	}
}
