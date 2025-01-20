using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdoNetCore.Models;
using Microsoft.Data.SqlClient;

#region PROCEDURES
//CREATE PROCEDURE SP_ALL_DEPARTAMENTOS
//AS
//	SELECT * FROM DEPT
//GO
//ALTER PROCEDURE SP_INSERT_DEPARTAMENTO
//(@NUMERO INT, @NOMBRE NVARCHAR(50), @LOCALIDAD NVARCHAR(50))
//AS
//	IF(@LOCALIDAD = 'TERUEL')
//	BEGIN 
//		PRINT 'TERUEL NO ES ACEPTADO'
//	END
//	ELSE
//	BEGIN
//		INSERT INTO DEPT VALUES(@NUMERO, @NOMBRE, @LOCALIDAD)
//		PRINT 'INSERTADO'
//	END
	
//GO
#endregion
namespace AdoNetCore
{
    public partial class Fomr12MensajeServidor : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Fomr12MensajeServidor()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;

            this.cn.InfoMessage += Cn_InfoMessage;

            this.LoadDepartamentos();
        }

        private void Cn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            this.lblMensaje.Text =  e.Message;
        }

        public async void LoadDepartamentos()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();

            List<Departamento> departamentos = new List<Departamento>();

            this.lstDepartamentos.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string dept = this.reader["DEPT_NO"].ToString();
                string nombre = this.reader["DNOMBRE"].ToString();
                string localidad = this.reader["LOC"].ToString();

                Departamento departamento = new Departamento
                {
                    IdDepartamento = int.Parse(dept),
                    Nombre = nombre,
                    Localidad = localidad
                };

                departamentos.Add(departamento);
                this.lstDepartamentos.Items.Add(departamento.IdDepartamento + " - " + departamento.Nombre);
            }
            
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
        }

        private  void btnInsertar_Click(object sender, EventArgs e)
        {
            this.lblMensaje.Text = "";
            string nombre = this.txtNombre.Text;
            int numero = int.Parse(this.txtNumero.Text);
            string loc = this.txtLocalidad.Text;

            string sql = "SP_INSERT_DEPARTAMENTO";

            this.com.Parameters.AddWithValue("@NUMERO", numero);
            this.com.Parameters.AddWithValue("@NOMBRE", nombre);
            this.com.Parameters.AddWithValue("@LOCALIDAD", loc);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            this.LoadDepartamentos();
        }
    }
}
