using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace AdoNetCore
{
    public partial class Form05UpdateSalas : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public Form05UpdateSalas()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.CargarSalas();
        }

        private async void CargarSalas()
        {
            string sql = "select distinct NOMBRE from SALA";

            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.lstSalas.Items.Clear();

            while ( await this.reader.ReadAsync())
            {
                string nom = this.reader["NOMBRE"].ToString();
                this.lstSalas.Items.Add(nom);
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
        }

        private async void btnModificar_Click(object sender, EventArgs e)
        {
            string nombreNuevo = this.txtSala.Text;
            string nombreActual = this.lstSalas.SelectedItem.ToString();
            string sql =
                "update SALA set NOMBRE=@nombreNuevo where NOMBRE=@nombreActual"; 
            SqlParameter nomNuevo = new SqlParameter("@nombreNuevo", nombreNuevo);
            SqlParameter nomActual = new SqlParameter("@nombreActual", nombreActual);
            this.com.Parameters.Add(nomNuevo);
            this.com.Parameters.Add(nomActual);
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.OpenAsync();
            int modificados = await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            this.CargarSalas();
        }
    }
}
