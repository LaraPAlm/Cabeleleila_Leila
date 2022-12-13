using Models.Usuario;
using Repository.usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo.Services
{
    public class UsuarioServices
    {
        private UsuarioRepository _repository
        {
            get
            {
                return new UsuarioRepository();
            }
        }
        public UsuarioModel Login(string login, string senha)
        {
            UsuarioModel usuario= new UsuarioModel();
            try
            {
                usuario=_repository.Login(login, senha);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            return usuario;
        }
        public UsuarioModel Cadastrar(UsuarioModel usuario)
        {
            
            try
            {
                usuario = _repository.Cadastrar(usuario);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return usuario;
        }
    }
}
