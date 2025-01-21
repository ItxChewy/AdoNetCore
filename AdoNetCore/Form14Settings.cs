using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Configuration;

namespace AdoNetCore
{
    public partial class Form14Settings : Form
    {
        public Form14Settings()
        {
            InitializeComponent();
        }

        private void btnLeerSettings_Click(object sender, EventArgs e)
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();

            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);
            IConfigurationRoot configuration = builder.Build();
            string connectionString =
                configuration.GetConnectionString("SqlTajamar");
            this.lblCadenaConexion.Text = connectionString;
            string imagen1 =
                configuration.GetSection("Imagenes:imagen1").Value;
            string imagen2 =
                configuration.GetSection("Imagenes:imagen2").Value;
            string colorFondo =
                configuration.GetSection("Colores:fondo").Value;
            string colorLetra =
                configuration.GetSection("Colores:letra").Value;

            this.pictureBox1.Load(imagen1);
            this.pictureBox2.Load(imagen2);
            this.btnLeerSettings.BackColor = Color.FromName(colorFondo);
            this.btnLeerSettings.ForeColor = Color.FromName(colorLetra);

        }
    }
}
