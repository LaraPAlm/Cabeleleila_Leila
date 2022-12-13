using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo
{
	public class ClienteModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }

		public ClienteModel()
		{
			Id = 0;
			Nome = string.Empty;
			Telefone = string.Empty;
			Endereco = string.Empty;
		}
	}
}
