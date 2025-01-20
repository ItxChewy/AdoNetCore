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
using Microsoft.Data.SqlClient;


#region PROCEDURES
//CREATE PROCEDURE SP_ALL_DEPARTAMENTOS
//AS
//	SELECT * FROM DEPT
//GO

//CREATE PROCEDURE SP_EMPLEADOS_DEPT_OUT
//(@NOMBRE NVARCHAR(50), @SUMA INT OUT, @MEDIA INT OUT
//, @PERSONAS INT OUT)
//AS
//	DECLARE @ID INT
//	SELECT @ID = DEPT_NO FROM DEPT
//	WHERE DNOMBRE=@NOMBRE
//	SELECT * FROM EMP WHERE DEPT_NO=@ID
//	SELECT @SUMA = SUM(SALARIO), @MEDIA = AVG(SALARIO)
//    , @PERSONAS = COUNT(EMP_NO) FROM EMP
//	WHERE DEPT_NO=@ID
//GO
#endregion
namespace AdoNetCore
{
    public partial class Form13ParametrosSalida : Form
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;
        RepositoryParametrosOut repo;
        public Form13ParametrosSalida()
        {
            InitializeComponent();
            this.repo = new RepositoryParametrosOut();
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
            this.LoadDepartamentos();
        }

        private async Task LoadDepartamentos()
        {
            List<Departamento> departamentos =
                await this.repo.GetAllDepartamentosAsync();
            this.cmbDepartamento.Items.Clear();
            foreach(Departamento departamento in departamentos)
            {
                this.cmbDepartamento.Items.Add(departamento.Nombre);
            }
        }
        private async void btnMostarDatos_Click(object sender, EventArgs e)
        {
            this.lstEmpleados.Items.Clear();
            string departamento = this.cmbDepartamento.Text;
            List<Empleado> empleados =
                await this.repo.GetEmpleadosAsync(departamento);
            foreach(Empleado empleado in empleados)
            {
                this.lstEmpleados.Items.Add(empleado.Apellido);
            }
            int sumaSalarial = await this.repo.GetSumaSalarialAsync(departamento);

            this.txtSuma.Text = sumaSalarial.ToString();
                //this.txtMedia.Text = operacion.MediaSalarial.ToString();
                //this.txtPersonas.Text = operacion.MaximoSalario.ToString();

        }
    }
}
