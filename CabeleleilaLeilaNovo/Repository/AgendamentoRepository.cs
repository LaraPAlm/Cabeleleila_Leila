using Base.Repository;
using Models.Agendamento;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Agendamento

{
    public class AgendamentoRepository: BaseRepository
    {
        public List<AgendamentoModel> Listar()
        {
            List<AgendamentoModel> retorno = new List<AgendamentoModel>();
            Conectar();
            string SQL = "SELECT * FROM AGENDAMENTOS;";
            using (var cmd = PrepareSql(SQL))
            {
            
                using (var idr = cmd.ExecuteReader())
                {
                    while (idr.Read())
                    {
                        AgendamentoModel agendamento = new AgendamentoModel();

                        agendamento.Id = Convert.ToInt32(idr["id"]);
                        agendamento.IdCliente = Convert.ToInt32(idr["id_cliente"]);
                        agendamento.Data = idr["data_agendamento"].ToString();
                        agendamento.Hora = idr["hora_agendamento"].ToString();
                        agendamento.IdProcedimento =Convert.ToInt32(idr["procedimento"]);
                        retorno.Add(agendamento);
                    }
                    
                }
            }
            return retorno;
        }
        public AgendamentoModel Cadastrar(AgendamentoModel agendamento)
        {
            Conectar();
            string SQL = "INSERT INTO AGENDAMENTOS (id_cliente, data, hora, id_tipo_procedimento)" +
                "VALUES(@pID_CLIENTE,@pDATA,@pHORA,@pID_PROCEDIMENTO)";
            using (var cmd = PrepareSql(SQL))
            {
                cmd.Parameters.Add(new MySqlParameter("pID_CLIENTE", agendamento.IdCliente));
                cmd.Parameters.Add(new MySqlParameter("pDATA", agendamento.Data));
                cmd.Parameters.Add(new MySqlParameter("pHORA", agendamento.Hora));
                cmd.Parameters.Add(new MySqlParameter("pID_PROCEDIMENTO", agendamento.IdProcedimento));

                
                cmd.ExecuteNonQuery();
                agendamento.Id = (int)cmd.LastInsertedId;
            }
            return agendamento;
        }
        public AgendamentoModel ConsultarAgendamentoPorCliente(int id)
        {
            AgendamentoModel retorno = new AgendamentoModel();
            Conectar();
            string SQL = "SELEC * FROM agendamentos where id_cliente=@pID_CLIENTE;";
            using (var cmd = PrepareSql(SQL))
            {
                cmd.Parameters.Add(new MySqlParameter("pID_CLIENTE", id));
                using (var idr = cmd.ExecuteReader())
                {
                    while (idr.Read())
                    {
                        retorno.IdCliente = Convert.ToInt32(idr[id]);
                        retorno.Data=idr["data_agendamento"].ToString();
                        retorno.Hora = idr["hora_agendamento"].ToString();
                        retorno.IdProcedimento = Convert.ToInt32(idr["procedimento"]);
                       
                    }

                }
            }
            return retorno;
        }
    }
}
