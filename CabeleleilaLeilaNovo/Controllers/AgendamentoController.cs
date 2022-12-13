using CabeleleilaLeilaNovo.Services;
using Models.Agendamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo.Controllers
{
    public class AgendamentoController
    {
        private AgendamentoServices _service
        {
            get { return new AgendamentoServices(); } 
        }
        public AgendamentoModel Cadastrar(AgendamentoModel agendamento)
        {
            if ((agendamento.IdProcedimento ==0 && string.IsNullOrEmpty(agendamento.Data) && string.IsNullOrEmpty(agendamento.Hora)
                && agendamento.IdCliente ==0))
            {
                throw new Exception("Precisa ser informado tos os campos do usuario");
            }
            agendamento = _service.Cadastrar(agendamento);

            return agendamento;
        }
    }
}
