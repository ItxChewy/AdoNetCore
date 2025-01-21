using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.comboBox1.SelectedIndex != -1)
            {

            }
        }
    }
}
