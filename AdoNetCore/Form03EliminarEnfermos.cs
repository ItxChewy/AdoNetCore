using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetCore
{
    public partial class Form03EliminarEnfermos : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form03EliminarEnfermos()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.CargarEnfermos();
        }

        private void CargarEnfermos()
        {
            string sql = "select * from ENFERMO";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            this.lstEnfermos.Items.Clear();
            while (this.reader.Read())
            {
                string ins = this.reader["INSCRIPCION"].ToString();
                string ape = this.reader["APELLIDO"].ToString();
                this.lstEnfermos.Items.Add(ins + " - " + ape);
            }
            this.cn.Close();
            this.reader.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int inscripcion = int.Parse(this.txtInscripcion.Text);

            string sql =
                "delete from ENFERMO where INSCRIPCION=@inscripcion";

            SqlParameter pamInscripcion = 
                new SqlParameter("@inscripcion", inscripcion);
            //pamInscripcion.ParameterName = "@inscripcion";
            //pamInscripcion.Value = inscripcion;
            //pamInscripcion.DbType = DbType.Int32;
            //pamInscripcion.Direction = ParameterDirection.Input;
            this.com.Parameters.Add(pamInscripcion);

            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            int eliminados = this.com.ExecuteNonQuery();
            this.cn.Close();

            this.com.Parameters.Clear();

            MessageBox.Show("Enfermos eliminados " + eliminados);
            this.CargarEnfermos();
        }
    }
}
