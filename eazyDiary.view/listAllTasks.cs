using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetoAgenda.eazyDiary.dao;
using projetoAgenda.eazyDiary.model;

namespace projetoAgenda.eazyDiary.view
{
    public partial class listAllTasks : Form
    {
        public listAllTasks()
        {
            InitializeComponent();
        }

        void StyleDatagridview()
        {
            dgTasks.BorderStyle = BorderStyle.None;
            dgTasks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(32, 30, 45);
            dgTasks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgTasks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(86, 54, 167);
            dgTasks.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgTasks.BackgroundColor = Color.FromArgb(32, 30, 45);
            dgTasks.EnableHeadersVisualStyles = false;
            dgTasks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgTasks.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgTasks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(18, 18, 18);
            dgTasks.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255); 
            dgTasks.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            dgTasks.DefaultCellStyle.ForeColor = Color.FromArgb(32, 30, 45);
        }

        private void listAllTasks_Load(object sender, EventArgs e)
        {
            StyleDatagridview();

            taskDAO dao = new taskDAO();
            dgTasks.DataSource = dao.listTask();
        }

        private void dgTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgTasks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgTasks.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgTasks.CurrentRow.Cells[1].Value.ToString();
            txtDesc.Text = dgTasks.CurrentRow.Cells[2].Value.ToString();
            txtIncr.Text = dgTasks.CurrentRow.Cells[3].Value.ToString();
            dateInitPicker.Value = (DateTime)dgTasks.CurrentRow.Cells[4].Value;
            dateEndPicker.Value = (DateTime)dgTasks.CurrentRow.Cells[5].Value;

            if(dateEndPicker.Value < DateTime.Now) { txtDias.Text = "Finalizou há " + (DateTime.Now - dateEndPicker.Value).Days.ToString() + " dias"; }
            else { txtDias.Text = (dateEndPicker.Value - DateTime.Now).Days.ToString(); }
            
        }

        private void btnUpdateTask_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "" || txtDesc.Text == "" || txtIncr.Text == "")
            {
                MessageBox.Show("Preencha todos os campos para atualizar tarefa!");
            }
            else
            {
                try
                {
                    Tasks task = new Tasks();
                    task.id = int.Parse(txtId.Text);
                    task.nome = txtNome.Text;
                    task.desc = txtDesc.Text;
                    task.incr = txtIncr.Text;
                    task.dateEnd = dateEndPicker.Value;

                    taskDAO dao = new taskDAO();
                    dao.updateTask(task);

                    MessageBox.Show("Alterado com sucesso!");
                    this.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message + "\n\nDica: Tente selecionar alguma célula para definir o ID");
                }
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            try
            {
                Tasks task = new Tasks();
                task.id = int.Parse(txtId.Text);

                taskDAO dao = new taskDAO();
                dao.deleteTask(task);

                MessageBox.Show("Excluído com sucesso!");
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message + "\n\nDica: Tente selecionar alguma célula para definir o ID");
            }
        }

        private void fecharForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
