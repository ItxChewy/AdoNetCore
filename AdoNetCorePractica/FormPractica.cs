using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetCorePractica.Models;
using AdoNetCorePractica.Repositories;

namespace AdoNetCorePractica
{
    public partial class FormPractica : Form
    {
        RepositoryEmpleadoHospital repo;
        public FormPractica()
        {
            InitializeComponent();
            this.repo = new RepositoryEmpleadoHospital();
            this.LoadHospitales();
        }

        public async void LoadHospitales()
        {
            List<string> hospitales = await this.repo.GetHospitalesAsync();
            foreach(string hospital in hospitales)
            {
                this.comboBox1.Items.Add(hospital);
            }
        }

        public async void LoadEmpleados()
        {
            this.lstEmpleadosHospital.Items.Clear();
            string hospital = this.comboBox1.SelectedItem.ToString();
            List<Empleado> empleados = await this.repo.GetEmpleadosAsync(hospital);
            foreach(Empleado empleado in empleados)
            {
                string ape = empleado.Apellido;
                string esp = empleado.Especialidad;
                string sal = empleado.Salario.ToString();
                this.lstEmpleadosHospital.Items.Add(ape + " - " + esp + " - " + sal);
            }
            this.LoadOperaciones();
        }
        public async void LoadOperaciones()
        {
            string hospital = this.comboBox1.SelectedItem.ToString();
            Operador emp = await this.repo.GetOperadorV2Async(hospital);
            
            this.textBox1.Text = emp.Suma_Salarial.ToString();
            this.textBox2.Text = emp.Media_Salarial.ToString();
            this.textBox3.Text = emp.Total_Personas.ToString();
        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex != -1)
            {
                this.LoadEmpleados();
                
            }
        }
    }
}
