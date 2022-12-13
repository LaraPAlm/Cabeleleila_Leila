using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Repository
{
    public class BaseRepository:IDisposable
    {
        private const string _connectionString = "server=cabele_leila.mysql.dbaas.com.br; uid=cabele_leila ; pwd=CABE_leila@123;database=cabele_leila";
        private MySqlConnection _con;

        public void Conectar()
        {
            try
            {
                _con = new MySqlConnection(_connectionString);
                _con.Open();
            }
            catch (MySqlException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void Dispose()
        {
            try
            {
                _con.Close();
            }
            catch (MySqlException e)
            {
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MySqlCommand PrepareSql(string SQL)
        {
            try
            {
                MySqlCommand command = new MySqlCommand(SQL, _con);
                command.CommandTimeout = 0;
                command.CommandType = System.Data.CommandType.Text;
                return command;

            }
            catch (MySqlException e)
            {
                Dispose();
                throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
