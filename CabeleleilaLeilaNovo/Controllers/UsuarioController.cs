using CabeleleilaLeilaNovo.Services;
using Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo.Controllers
{
    public class UsuarioController
    {
        private UsuarioServices _service
        {
            get { return new UsuarioServices(); }
        }
        public UsuarioModel Login(string login, string senha)
        {
            UsuarioModel usuario = new UsuarioModel();
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(senha)) 
            {
                throw new Exception("Precisa ser informado o Login e a Senha");
            }
            usuario= _service.Login(login, senha);

            return usuario;
        }
        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
          
            if (string.IsNullOrEmpty(usuario.Nome)&& string.IsNullOrEmpty(usuario.Endereco)&& string.IsNullOrEmpty(usuario.Telefone)
                && string.IsNullOrEmpty(usuario.IdTipo.ToString()) && string.IsNullOrEmpty(usuario.Login) && string.IsNullOrEmpty(usuario.Senha))
            {
                throw new Exception("Precisa ser informado tos os campos do usuario");
            }
            usuario = _service.Cadastrar(usuario);

            return usuario;
        }

    }
}
