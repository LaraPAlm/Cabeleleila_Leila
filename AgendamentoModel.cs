using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo
{

	public class AgendamentoModel
	{
		public string Data { get; set; }
		public string Hora { get; set; }
		public string NomeDoCliente { get; set; }

		public AgendamentoModel()
		{
			Data = string.Empty;
			Hora = string.Empty;
			NomeDoCliente = string.Empty;
		}
	}
}
