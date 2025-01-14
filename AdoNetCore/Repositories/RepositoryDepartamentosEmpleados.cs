using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.ComponentModel;

namespace AdoNetCore.Repositories
{
    public class RepositoryDepartamentosEmpleados
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryDepartamentosEmpleados()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
        }

        public async Task<List<string>> GetNombreDepartamentosAsync()
        {
            string sql = "select distinct DNOMBRE from DEPT";
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> departamentos = new List<string>();
            while(await this.reader.ReadAsync())
            {
                string departamento = this.reader["DNOMBRE"].ToString();
                departamentos.Add(departamento);
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            return departamentos;
        }
        public async Task<string> GetDeptNo(string departamento)
        {
            string sql = "select DEPT_NO from DEPT " +
                " where DNOMBRE=@nomDepartamento";
            SqlParameter pamDepartamento = new SqlParameter("@nomDepartamento", departamento);
            this.com.Parameters.Add(pamDepartamento);
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            string valor = "";
            while(await this.reader.ReadAsync())
            {
                valor = this.reader["DEPT_NO"].ToString();
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            this.com.Parameters.Clear();
            return valor;
           

        }
        public async Task<List<string>> GetEmpleadosPorDepartamentoAsync(string departamento)
        {
            string valor = await this.GetDeptNo(departamento);
            string sql = "select EMP.APELLIDO FROM EMP " +
                " inner JOIN DEPT ON EMP.DEPT_NO = DEPT.DEPT_NO " +
                " where EMP.DEPT_NO = @numero";
            SqlParameter pamValor = new SqlParameter("@numero", valor);
            this.com.Parameters.Add(pamValor);
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> empleados = new List<string>();
            while(await this.reader.ReadAsync())
            {
                string empleado = this.reader["APELLIDO"].ToString();
                empleados.Add(empleado);
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            this.com.Parameters.Clear();
            return empleados;

        }

        public async Task DeleteEmpleado(string apellido)
        {
            string sql = "delete from EMP where APELLIDO=@ape";
            SqlParameter pamApe = new SqlParameter("@ape", apellido);
            this.com.Parameters.Add(pamApe);
            this.com.Connection = this.cn;
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();

        }
    }
}
