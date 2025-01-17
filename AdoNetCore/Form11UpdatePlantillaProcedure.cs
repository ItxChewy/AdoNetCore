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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

#region STORED PROCEDURES
//CREATE PROCEDURE SP_ALL_HOSPITALES
//AS
//	SELECT * FROM HOSPITAL
//GO

//CREATE PROCEDURE SP_UPDATE_PLANTILLA_HOSPITAL
//(@NOMBRE NVARCHAR(50), @INCREMENTO INT)
//AS
//	DECLARE @HOSPITALCOD INT
//	SELECT @HOSPITALCOD = HOSPITAL_COD FROM HOSPITAL
//	WHERE NOMBRE=@NOMBRE
//	UPDATE PLANTILLA SET SALARIO=SALARIO + @INCREMENTO
//	WHERE HOSPITAL_COD=@HOSPITALCOD
//	SELECT * FROM PLANTILLA
//	WHERE HOSPITAL_COD=@HOSPITALCOD
//GO
//CREATE PROCEDURE SP_PLANTILLA_HOSPITAL
//    (@HOSPITAL NVARCHAR(50))
//AS
//	BEGIN
//		DECLARE @COD INT;
//SELECT @COD = HOSPITAL_COD
//		FROM HOSPITAL
//		WHERE NOMBRE = @HOSPITAL;
//IF @COD IS NOT NULL
//		BEGIN
//			SELECT APELLIDO
//			FROM PLANTILLA
//			WHERE HOSPITAL_COD = @COD;
//END
//END
//GO
#endregion

namespace AdoNetCore
{
    public partial class Form11UpdatePlantillaProcedure : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        public Form11UpdatePlantillaProcedure()
        {
            InitializeComponent();
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadHospitales();
        }

        private async void LoadHospitales()
        {
            string sql = "SP_ALL_HOSPITALES";

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            this.cmbHospital.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                this.cmbHospital.Items.Add(nombre);
            }

            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
        }

        private async void btnModificarSalarios_Click(object sender, EventArgs e)
        {
            string nombre = this.cmbHospital.SelectedItem.ToString();
            int incremento = int.Parse(this.txtIncremento.Text);
            string sql = "SP_UPDATE_PLANTILLA_HOSPITAL";
            this.com.Parameters.AddWithValue("@NOMBRE", nombre);
            this.com.Parameters.AddWithValue("@INCREMENTO", incremento);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();

            this.reader = await this.com.ExecuteReaderAsync();
            this.lstPlantilla.Items.Clear();
            while (await this.reader.ReadAsync())
            {
                string ape = this.reader["APELLIDO"].ToString();
                string salario = this.reader["SALARIO"].ToString();
                this.lstPlantilla.Items.Add(ape + " - " + salario);
            }

            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            this.com.Parameters.Clear();

        }

        private async void cmbHospital_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.cmbHospital.SelectedIndex != -1)
            {
                string hospital = this.cmbHospital.SelectedItem.ToString();
                string sql = "SP_PLANTILLA_HOSPITAL";
                this.com.Parameters.AddWithValue("@HOSPITAL", hospital);
                this.com.CommandType = CommandType.StoredProcedure;
                this.com.CommandText = sql;

                await this.cn.OpenAsync();
                this.reader = await this.com.ExecuteReaderAsync();
                this.lstPlantilla.Items.Clear();
                while (await this.reader.ReadAsync())
                {
                    string ape = this.reader["APELLIDO"].ToString();
                    this.lstPlantilla.Items.Add(ape + " - " + hospital);
                }

                await this.cn.CloseAsync();
                await this.reader.CloseAsync();
                this.com.Parameters.Clear();
            }
        }
    }
}
