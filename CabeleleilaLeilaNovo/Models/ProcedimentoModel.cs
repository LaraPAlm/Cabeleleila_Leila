using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo.Models
{
    public class ProcedimentoModel
    {
        public int Id {get;set;}
        public string Procedimento {get;set;}
        public decimal Valor { get;set;}

        public ProcedimentoModel()
        {
            Id = 0;
            Procedimento=string.Empty;
            Valor = 0;

        }

    }
}
