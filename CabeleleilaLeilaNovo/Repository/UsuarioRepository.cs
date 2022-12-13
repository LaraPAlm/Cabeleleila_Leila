using Base.Repository;
using Models.Usuario;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.usuario
{

	public class UsuarioRepository: BaseRepository
	{
		public List<UsuarioModel> ListarUsuario()
		{
			List<UsuarioModel> retorno = new List<UsuarioModel>();

			Conectar();
			string SQL = "SELEC * FROM usuarios;";
			using(var cmd = PrepareSql(SQL))
            {
			
				using(var idr=cmd.ExecuteReader())
                {
					while(idr.Read())
                    {
						UsuarioModel usuario = new UsuarioModel();
						usuario.Id = Convert.ToInt32(idr["id"]);
						usuario.IdTipo= Convert.ToInt32(idr["id_tipo"]);
						usuario.Nome=idr["nome"].ToString();
						usuario.Telefone = idr["telefone"].ToString();
						usuario.Endereco = idr["endereco"].ToString();
						retorno.Add(usuario);
					}
					
                }
            }
			return retorno;
            
		}
		public UsuarioModel Login(string login, string senha)
        {
			UsuarioModel retorno = new UsuarioModel();
			Conectar();
			string SQL = "SELECT * FROM USUARIOS where login=@pLOGIN and senha=@pSENHA;";
			using (var cmd = PrepareSql(SQL))
			{
				cmd.Parameters.Add(new MySqlParameter("pLOGIN", login));
				cmd.Parameters.Add(new MySqlParameter("pSENHA", senha));
				using (var idr = cmd.ExecuteReader())
				{
					while (idr.Read())
					{
						retorno.Id = Convert.ToInt32(idr["id"]);
						retorno.IdTipo = Convert.ToInt32(idr["id_tipo"]);
						retorno.Nome = idr["nome"].ToString();
						retorno.Telefone = idr["telefone"].ToString();
						retorno.Endereco = idr["endereco"].ToString();
						retorno.Login = idr["login"].ToString();
						retorno.Senha = idr["senha"].ToString();

						
					}

				}
			}
			return retorno;
        }
		public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
			UsuarioModel retorno = new UsuarioModel();
			Conectar();
			string SQL = "INSERT INTO USUARIOS (NOME, ENDERECO, TELEFONE, LOGIN, SENHA, ID_TIPO)" +
				"VALUES(@pNOME,@pENDERECO,@pTELEFONE,@pLOGIN, @pSENHA , @pID_TIPO) returning id";
			using (var cmd = PrepareSql(SQL))
			{
				cmd.Parameters.Add(new MySqlParameter("pNOME", usuario.Nome));
				cmd.Parameters.Add(new MySqlParameter("pENDERECO", usuario.Endereco));
				cmd.Parameters.Add(new MySqlParameter("pTELEFONE", usuario.Telefone));
				cmd.Parameters.Add(new MySqlParameter("pLOGIN", usuario.Login));
				cmd.Parameters.Add(new MySqlParameter("pSENHA", usuario.Senha));
				cmd.Parameters.Add(new MySqlParameter("pID_TIPO", usuario.IdTipo));
				
				retorno.Id= Convert.ToInt32(cmd.ExecuteScalar());
			}
			return retorno;
		}
	}
}
