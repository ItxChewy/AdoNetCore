using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetCore.Models;
using AdoNetCore.Repositories;
using static Azure.Core.HttpHeader;

namespace AdoNetCore
{
    public partial class Form09CrudHospitales : Form
    {
        RepositoryHospitales repo;
        public Form09CrudHospitales()
        {
            InitializeComponent();
            this.repo = new RepositoryHospitales();
            this.LoadHospitales();
        }

        private async void LoadHospitales()
        {
            List<Hospital> hospitales =
                await this.repo.GetHospitalsAsync();
            this.lstHospitales.Items.Clear();

            foreach (Hospital hospital in hospitales)
            {
                this.lstHospitales.Items.Add(
                    hospital.Id + " - " + hospital.Nombre + " - " + hospital.Direccion +
                    " - " + hospital.Telefono + " - " + hospital.Camas);
            }
        }
        private async void btnInsertar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int camas = int.Parse(this.txtCamas.Text);

            await this.repo.CreateHospitalAsync(id,nombre,direccion,telefono,camas);
            this.LoadHospitales();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            string nombre = this.txtNombre.Text;
            string direccion = this.txtDireccion.Text;
            string telefono = this.txtTelefono.Text;
            int camas = int.Parse(this.txtCamas.Text);

            await this.repo.UpdateHospitalAsync(id, nombre, direccion, telefono,camas);
            this.LoadHospitales();
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(this.txtId.Text);
            await this.repo.DeleteHospitalAsync(id);
            this.LoadHospitales();
        }
    }
}
