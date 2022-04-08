using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using projetoAgenda.eazyDiary.conexao;
using projetoAgenda.eazyDiary.model;

namespace projetoAgenda.eazyDiary.dao
{
    internal class taskDAO
    {
        private MySqlConnection connection;
        public taskDAO()
        {
            this.connection = new connectionSQL().getConnection();
        }

        #region Insert Task
        public void insertTask(Tasks task)
        {
                try
                {
                    string sql = "insert into tasks (nome, descricao, incremento, dateInit, dateEnd) values (@nome, @desc, @incr, @dateInit, @dateEnd)";

                    MySqlCommand cmd = new MySqlCommand(sql, connection);

                    cmd.Parameters.AddWithValue("@nome", task.nome);
                    cmd.Parameters.AddWithValue("@desc", task.desc);
                    cmd.Parameters.AddWithValue("@incr", task.incr);
                    cmd.Parameters.AddWithValue("@dateInit", task.dateInit);
                    cmd.Parameters.AddWithValue("@dateEnd", task.dateEnd);

                    connection.Open();
                    cmd.ExecuteNonQuery();


                connection.Close();
                }catch (Exception err)
                {
                    MessageBox.Show("Error: " + err.Message);
                }


        }
        #endregion

        #region Update Task
        public void updateTask(Tasks task)
        {
            try
            {
                string sql = "update tasks set nome=@nome, descricao=@desc, incremento=@incr, dateEnd=@dateEnd where id=@id";

                MySqlCommand cmd = new MySqlCommand(sql, connection);

                cmd.Parameters.AddWithValue("@id", task.id);
                cmd.Parameters.AddWithValue("@nome", task.nome);
                cmd.Parameters.AddWithValue("@desc", task.desc);
                cmd.Parameters.AddWithValue("@incr", task.incr);
                cmd.Parameters.AddWithValue("@dateEnd", task.dateEnd);

                connection.Open();
                cmd.ExecuteNonQuery();

                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: " + err.Message);
            }


        }

        #endregion

        #region List Task
        public DataTable listTask()
        {
            DataTable taskTable = new DataTable();
            string sql = "select id,nome, descricao, incremento, dateInit, dateEnd from tasks";

            MySqlCommand cmd = new MySqlCommand(sql, connection);

            connection.Open();
            cmd.ExecuteNonQuery();

            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(taskTable);

            connection.Close();

            return taskTable;
        }
        #endregion

        #region Delete Task
        public void deleteTask(Tasks task)
        {
            string sql = "delete from tasks where id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, connection);

            cmd.Parameters.AddWithValue("@id", task.id);

            connection.Open();
            cmd.ExecuteNonQuery();

            connection.Close();
        }
        #endregion
    }
}
