using Base.Repository;
using CabeleleilaLeilaNovo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabeleleilaLeilaNovo.Repository
{
    public class ProcedimentoRepository:BaseRepository
    {
        public List<ProcedimentoModel> Listar()
        {
            List<ProcedimentoModel> retorno = new List<ProcedimentoModel>();
            Conectar();
            string SQL = "SELECT * FROM PROCEDIMENTOS;";
            using (var cmd = PrepareSql(SQL))
            {

                using (var idr = cmd.ExecuteReader())
                {
                    while (idr.Read())
                    {
                        ProcedimentoModel procedimento = new ProcedimentoModel();

                        procedimento.Id = Convert.ToInt32(idr["id"]);
                        procedimento.Procedimento = idr["procedimento"].ToString();
                        procedimento.Valor = Convert.ToDecimal(idr["valor"]);
                        retorno.Add(procedimento);
                    }

                }
            }
            return retorno;
        }
    }
}
