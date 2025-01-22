using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCorePractica.Helpers;
using AdoNetCorePractica.Models;
using Microsoft.Data.SqlClient;

#region PROCEDURES
//SP_ALL_HOSPITALES

//CREATE PROCEDURE SP_GET_ALL_EMPLEADOS_HOSPITAL
//(@HOSPITAL NVARCHAR(50))
//AS
//	DECLARE @COD INT
//	SELECT @COD= HOSPITAL_COD FROM HOSPITAL WHERE NOMBRE = @HOSPITAL
//	SELECT DISTINCT APELLIDO AS APELLIDO, ESPECIALIDAD AS ESPECIALIDAD , SALARIO AS SALARIO
//	FROM DOCTOR
//	WHERE HOSPITAL_COD = @COD
//	UNION
//	SELECT DISTINCT APELLIDO AS APELLIDO, FUNCION AS ESPECIALIDAD, SALARIO AS SALARIO
//	FROM PLANTILLA
//	WHERE HOSPITAL_COD = @COD;
//GO
//CREATE PROCEDURE SP_GET_ALL_OPERACIONES_EMPLEADOS_HOSPITAL
//(@HOSPITAL NVARCHAR(50))
//AS
//	DECLARE @COD INT
//	SELECT @COD= HOSPITAL_COD FROM HOSPITAL WHERE NOMBRE = @HOSPITAL
//	SELECT 
//    COUNT(*) AS NUMERO_PERSONAS,
//    AVG(SALARIO) AS MEDIA_SALARIAL,
//    SUM(SALARIO) AS SUMA_SALARIAL
//FROM (
//    SELECT DISTINCT APELLIDO AS APELLIDO, ESPECIALIDAD AS ESPECIALIDAD , SALARIO AS SALARIO
//		FROM DOCTOR
//		WHERE HOSPITAL_COD = @COD
//	UNION
//	SELECT DISTINCT APELLIDO AS APELLIDO, FUNCION AS ESPECIALIDAD, SALARIO AS SALARIO
//		FROM PLANTILLA
//		WHERE HOSPITAL_COD = @COD
//) AS COMBINADO;
//GO

//CREATE PROCEDURE SP_GET_ALL_OPERACIONES_EMPLEADOS_HOSPITAL_CON_PARAMETROS
//(@HOSPITAL NVARCHAR(50), @SUMA INT OUT, @MEDIA INT OUT, @PERSONAS INT OUT)
//AS
//	DECLARE @COD INT
//	SELECT @COD= HOSPITAL_COD FROM HOSPITAL WHERE NOMBRE = @HOSPITAL
//	SELECT 
//    @PERSONAS=COUNT(*),
//    @MEDIA = AVG(SALARIO),
//    @PERSONAS = SUM(SALARIO)
//FROM (
//    SELECT DISTINCT APELLIDO AS APELLIDO, ESPECIALIDAD AS ESPECIALIDAD , SALARIO AS SALARIO
//		FROM DOCTOR
//		WHERE HOSPITAL_COD = @COD
//	UNION
//	SELECT DISTINCT APELLIDO AS APELLIDO, FUNCION AS ESPECIALIDAD, SALARIO AS SALARIO
//		FROM PLANTILLA
//		WHERE HOSPITAL_COD = @COD
//) AS COMBINADO;
//GO
#endregion

namespace AdoNetCorePractica.Repositories
{
    public class RepositoryEmpleadoHospital
    {
        SqlConnection cn;
        SqlCommand com;
        SqlDataReader reader;

        public RepositoryEmpleadoHospital()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetHospitalesAsync()
        {
            string sql = "SP_ALL_HOSPITALES";

            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> hospitales = new List<string>();

            while(await this.reader.ReadAsync())
            {
                string nombre = this.reader["NOMBRE"].ToString();
                hospitales.Add(nombre);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return hospitales;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync(string hospital)
        {
            string sql = "SP_GET_ALL_EMPLEADOS_HOSPITAL";

            this.com.Parameters.AddWithValue("@HOSPITAL", hospital);

            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Empleado> empleados = new List<Empleado>();
            while(await this.reader.ReadAsync())
            {
                string ape = this.reader["APELLIDO"].ToString();
                string esp = this.reader["ESPECIALIDAD"].ToString();
                int sal = int.Parse(this.reader["SALARIO"].ToString());
                Empleado empleado = new Empleado
                {
                    Apellido = ape,
                    Especialidad = esp,
                    Salario = sal
                };
                empleados.Add(empleado);
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return empleados;

        }
        public async Task<Operador> GetOperadorAsync(string hospital)
        {
            string sql = "SP_GET_ALL_OPERACIONES_EMPLEADOS_HOSPITAL";

            this.com.Parameters.AddWithValue("@HOSPITAL", hospital);

            this.com.CommandType = System.Data.CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            Operador operaciones = new Operador();
            while(await this.reader.ReadAsync())
            {
                int total = int.Parse(this.reader["NUMERO_PERSONAS"].ToString());
                int media = int.Parse(this.reader["MEDIA_SALARIAL"].ToString());
                int suma = int.Parse(this.reader["SUMA_SALARIAL"].ToString());
                Operador operacion = new Operador
                {
                    Total_Personas = total,
                    Media_Salarial = media,
                    Suma_Salarial = suma

                };
                operaciones = operacion;
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return operaciones;
        }

        public async Task<Operador>GetOperadorV2Async(string hospital)
        {
            string sql = "SP_GET_ALL_OPERACIONES_EMPLEADOS_HOSPITAL_CON_PARAMETROS";
            this.com.Parameters.AddWithValue("@HOSPITAL", hospital);

            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@SUMA";
            pamSuma.Value = 0;
            pamSuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamSuma);

            SqlParameter pamMedia = new SqlParameter();
            pamMedia.ParameterName = "@MEDIA";
            pamMedia.Value = 0;
            pamMedia.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamMedia);

            SqlParameter pamPersonas = new SqlParameter();
            pamPersonas.ParameterName = "@PERSONAS";
            pamPersonas.Value = 0;
            pamPersonas.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamPersonas);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            Operador operacion = new Operador();
            await this.reader.CloseAsync();
            operacion.Total_Personas = int.Parse(pamPersonas.Value.ToString());
            operacion.Suma_Salarial = int.Parse(pamSuma.Value.ToString());
            operacion.Media_Salarial = int.Parse(pamMedia.Value.ToString());
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return operacion;
        }
    }
}
