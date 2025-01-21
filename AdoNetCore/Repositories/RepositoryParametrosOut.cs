using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCore.Helpers;
using AdoNetCore.Models;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdoNetCore.Repositories
{
  
    public class RepositoryParametrosOut
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;
        public RepositoryParametrosOut()
        {
            string connectionString = HelperConfiguration.GetConnectionString();
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<Departamento>> GetAllDepartamentosAsync()
        {
            string sql = "SP_ALL_DEPARTAMENTOS";
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Departamento> departamentos = new List<Departamento>();
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

            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            return departamentos;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync(string departamento)
        {
            string sql = "SP_EMPLEADOS_DEPARTAMENTO";

            this.com.Parameters.AddWithValue("@DEPARTAMENTO", departamento);
            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<Empleado> empleados = new List<Empleado>();
            while (await this.reader.ReadAsync())
            {
                Empleado empleado = new Empleado
                {
                    IdEmpleado = int.Parse(this.reader["EMP_NO"].ToString()),
                    Apellido = this.reader["APELLIDO"].ToString(),
                    Oficio = this.reader["OFICIO"].ToString(),
                    Cod_Director = int.Parse(this.reader["DIR"].ToString()),
                    Fecha_Alta = DateTime.Parse(this.reader["FECHA_ALT"].ToString()),
                    Salario = int.Parse(this.reader["SALARIO"].ToString()),
                    Comision = int.Parse(this.reader["COMISION"].ToString()),
                    Cod_Departamento = int.Parse(this.reader["DEPT_NO"].ToString())
                };

                empleados.Add(empleado);
            }
            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return empleados;
        }

        public async Task<int> GetSumaSalarialAsync(string departamento)
        {
            string sql = "SP_SUMASALARIAL_EMPLEADOS_OFICIO";
            this.com.Parameters.AddWithValue("@DEPARTAMENTO", departamento);
            SqlParameter pamSuma = new SqlParameter();
            pamSuma.ParameterName = "@SUMA";
            pamSuma.Value = 0;
            pamSuma.Direction = ParameterDirection.Output;
            this.com.Parameters.Add(pamSuma);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            int sumaSalarial = pamSuma.Value != DBNull.Value ? (int)pamSuma.Value : 0;

            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return sumaSalarial;
        }

        public async Task<DatosEmpleadosOficio> GetOperacionesAsync(string nombre)
        {
            string sql = "SP_EMPLEADOS_DEPT_OUT";

            this.com.Parameters.AddWithValue("@NOMBRE", nombre);
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
            pamPersonas.Direction = ParameterDirection.Output;
            pamPersonas.Value = 0;
            this.com.Parameters.Add(pamPersonas);

            this.com.CommandType = CommandType.StoredProcedure;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            DatosEmpleadosOficio operaciones = new DatosEmpleadosOficio();
            while (await this.reader.ReadAsync())
            {
                DatosEmpleadosOficio datos = new DatosEmpleadosOficio
                {
                    SumaSalarial = pamSuma.Value != DBNull.Value ? (int)pamSuma.Value : 0,
                    MediaSalarial = pamMedia.Value != DBNull.Value ? (int)pamMedia.Value : 0,
                    MaximoSalario = pamPersonas.Value != DBNull.Value ? (int)pamPersonas.Value : 0
                };
                operaciones = datos;
            }

            await this.reader.CloseAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return operaciones;
        }


    }
}
