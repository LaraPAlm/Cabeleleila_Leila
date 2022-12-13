using Models.Agendamento;
using Repository.Agendamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo.Services
{
    public class AgendamentoServices
    {
        private AgendamentoRepository _repository
        {
            get { return new AgendamentoRepository(); }
        }
        public AgendamentoModel Cadastrar(AgendamentoModel agendamento)
        {
            try
            {
                agendamento = _repository.Cadastrar(agendamento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return agendamento;
        }
    }
}
