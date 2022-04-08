using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using projetoAgenda.eazyDiary.model;
using projetoAgenda.eazyDiary.dao;

namespace projetoAgenda.eazyDiary.view
{
    public partial class createTask : Form
    {
        public createTask()
        {
            InitializeComponent();
        }

        private void fecharForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtDesc.Text == "" || txtIncr.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para criar tarefa!");
            }
            else {
                try
                {
                    Tasks task = new Tasks();
                    task.nome = txtNome.Text;
                    task.desc = txtDesc.Text;
                    task.incr = txtIncr.Text;
                    task.dateInit = DateTime.Now;
                    task.dateEnd = dateEndPicker.Value;

                    taskDAO dao = new taskDAO();
                    dao.insertTask(task);

                    MessageBox.Show("Inserido com sucesso!");
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }


        }
    }
}
