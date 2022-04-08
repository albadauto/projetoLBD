using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace projetoAgenda.eazyDiary.conexao
{
    internal class connectionSQL
    {
        public MySqlConnection getConnection()
        {
            string connection = ConfigurationManager.ConnectionStrings["eazyDiary"].ConnectionString;
            return new MySqlConnection(connection);
        }
    }
}
