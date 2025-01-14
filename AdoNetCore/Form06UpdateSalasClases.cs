using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetCore.Repositories;

namespace AdoNetCore
{
    public partial class Form06UpdateSalasClases : Form
    {
        RepositorySalas repo;
        public Form06UpdateSalasClases()
        {
            InitializeComponent();
            this.repo = new RepositorySalas();
            this.LoadSalas();
           
        }

        private async void LoadSalas()
        {
            List<string> salas = 
            await this.repo.GetNombresSalaAsync();
            this.lstSalas.Items.Clear();
            foreach (string nombre in salas)
            {
                this.lstSalas.Items.Add(nombre);
            }
        }
        private async void btnModificar_Click(object sender, EventArgs e)
        {
            string oldName = this.lstSalas.SelectedItem.ToString();
            string newName = this.txtSala.Text;
            await this.repo.UpdateNombreSalas(oldName,newName);
            this.LoadSalas();
        }
    }
}
