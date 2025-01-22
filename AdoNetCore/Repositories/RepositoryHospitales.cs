using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCore.Models;
using Microsoft.Data.SqlClient;

#region PRECEDURES
//CREATE PROCEDURE SP_GET_ALL_EMPLEADOS_HOSPITAL
//(@HOSPITAL NVARCHAR(50))
//AS
//	DECLARE @COD INT
//	SELECT @COD= HOSPITAL_COD FROM HOSPITAL WHERE NOMBRE = @HOSPITAL

//GO

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
#endregion
namespace AdoNetCore.Repositories
{
    public class RepositoryHospitales
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryHospitales()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<Hospital>> GetHospitalsAsync()
        {
            string sql = "select * from HOSPITAL";
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Hospital> hospitales = new List<Hospital>();
            while(await this.reader.ReadAsync())
            {
                int id = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                string nombre = this.reader["NOMBRE"].ToString();
                string direccion = this.reader["DIRECCION"].ToString();
                string telefono = this.reader["TELEFONO"].ToString();
                int camas = int.Parse(this.reader["NUM_CAMA"].ToString());
                Hospital hospital = new Hospital
                {
                    Id = id,
                    Nombre = nombre,
                    Direccion = direccion,
                    Telefono = telefono,
                    Camas = camas
                };
                hospitales.Add(hospital);
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            return hospitales;
        }

        public async Task CreateHospitalAsync(int id, string nombre, string direccion, string telefono, int camas)
        {
            string sql = "insert into HOSPITAL values (@id, @nombre, @direccion, @telefono, @camas)";

            this.com.Parameters.AddWithValue("@id", id);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@camas", camas);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task UpdateHospitalAsync(int id, string nombre, string direccion, string telefono, int camas)
        {
            string sql = " update HOSPITAL set NOMBRE=@nombre, " +
                " DIRECCION=@direccion, TELEFONO=@telefono, NUM_CAMA=@camas " +
                " where HOSPITAL_COD=@id";
            this.com.Parameters.AddWithValue("@id", id);
            this.com.Parameters.AddWithValue("@nombre", nombre);
            this.com.Parameters.AddWithValue("@direccion", direccion);
            this.com.Parameters.AddWithValue("@telefono", telefono);
            this.com.Parameters.AddWithValue("@camas", camas);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }

        public async Task DeleteHospitalAsync(int id)
        {
            string sql =
                "delete from HOSPITAL where HOSPITAL_COD=@id";

            this.com.Parameters.AddWithValue("@id", id);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

        }
    }
}
