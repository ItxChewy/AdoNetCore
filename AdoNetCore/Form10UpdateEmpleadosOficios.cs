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
    public partial class Form10UpdateEmpleadosOficios : Form
    {
        private RepositoryUpdateEmpleados repo;
        public Form10UpdateEmpleadosOficios()
        {
            InitializeComponent();
            this.repo = new RepositoryUpdateEmpleados();
            this.LoadOficios();
        }

        private async void LoadOficios()
        {
            List<string> oficios = await this.repo.GetOficiosAsync();
            this.lstOficios.Items.Clear();
            foreach (string ofi in oficios)
            {
                this.lstOficios.Items.Add(ofi);
            }
        }

        private async void LoadEmpleados(string oficio)
        {
            List<string> empleados = await this.repo.GetEmpleadosOficioAsync(oficio);
            this.lstEmpleados.Items.Clear();
            foreach (string emp in empleados)
            {
                this.lstEmpleados.Items.Add(emp);
            }
        }

        private async void btnIncrementarSalario_Click(object sender, EventArgs e)
        {
            int incremento = int.Parse(this.txtIncremento.Text);
            string oficio = this.lstOficios.SelectedItem.ToString();
            string nuevoOficio = this.txtOficio.Text;
            await this.repo.UpdateOficio(nuevoOficio, oficio,incremento);
            //int modificados = await this.repo.UpdateSalarioEmpleadosOficio(oficio, incremento);
            
            string suma = await this.repo.CalcularSumaPorOficio(nuevoOficio);
            string avg = await this.repo.CalcularMediaPorOficio(nuevoOficio);
            string max = await this.repo.MaximoPorOficio(nuevoOficio);
            this.lblSumaSalarial.Text = "La suma de salarios es :" + suma;
            this.lblMediaSalarial.Text = "La media de salarios es :" + avg;
            this.lblMaximoSalario.Text = "El salarios mas alto es :" + max;
            this.LoadOficios();
            //MessageBox.Show("Salarios modificados " + modificados);

        }

        private  void lstOficios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstOficios.SelectedIndex != -1)
            {
                string oficio = this.lstOficios.SelectedItem.ToString();
                this.LoadEmpleados(oficio);
            }
        }
    }
}
