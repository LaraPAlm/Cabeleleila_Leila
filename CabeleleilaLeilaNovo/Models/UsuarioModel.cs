using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Usuario
{
	public class UsuarioModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Telefone { get; set; }
		public string Endereco { get; set; }
		public int IdTipo { get; set; }
		public string Login { get; set; }
		public string Senha { get; set; }

		public UsuarioModel()
		{
			Id = 0;
			IdTipo = 0;
			Nome = string.Empty;
			Telefone = string.Empty;
			Endereco = string.Empty;
			Login = string.Empty;
			Senha = string.Empty;
		}
	}
}
