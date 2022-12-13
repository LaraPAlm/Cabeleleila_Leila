using CabeleleilaLeilaNovo.Models;
using CabeleleilaLeilaNovo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo.Services
{
    public class ProcedimentoServices
    {
        private ProcedimentoRepository _repository
        {
            get { return new ProcedimentoRepository(); }
        }
        public List<ProcedimentoModel> Listar()
        {
            List<ProcedimentoModel> retorno = new List<ProcedimentoModel>();
            try
            {
                retorno = _repository.Listar();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
    }
}
