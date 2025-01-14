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
    public partial class Form07DepartamentosEmpleados : Form
    {
        RepositoryDepartamentosEmpleados repo;
        public Form07DepartamentosEmpleados()
        {
            InitializeComponent();
            this.repo = new RepositoryDepartamentosEmpleados();
            this.LoadDepartamentos();
        }

        private async void LoadDepartamentos()
        {
            List<string> departamentos =
             await this.repo.GetNombreDepartamentosAsync();
            foreach (string num in departamentos)
            {
                this.lstDepartamentos.Items.Add(num);
            }
        }
        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            string ape = this.lstEmpleados.SelectedItem.ToString();

            this.repo.DeleteEmpleado(ape);
            
        }

        private async void lstDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lstEmpleados.Items.Clear();
            string valor = this.lstDepartamentos.SelectedItem.ToString();
            List<string> empleados =
                await this.repo.GetEmpleadosPorDepartamentoAsync(valor);
            foreach(string emp in empleados)
            {
                this.lstEmpleados.Items.Add(emp);
            }
        }
    }
}
