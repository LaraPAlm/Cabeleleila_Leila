using CabeleleilaLeilaNovo.Models;
using CabeleleilaLeilaNovo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo.Controllers
{
    public class ProcedimentoController
    {
        private ProcedimentoServices _services
        {
            get { return new ProcedimentoServices(); }
        }
        public List<ProcedimentoModel> Listar()
        {
            List<ProcedimentoModel> retorno = new List<ProcedimentoModel>();
            retorno = _services.Listar();
            return retorno;
        }
    }
}
