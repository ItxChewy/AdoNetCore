using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdoNetCore.Repositories
{
    public class RepositoryUpdateEmpleados
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RepositoryUpdateEmpleados()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Encrypt=True;Trust Server Certificate=True";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }

        public async Task<List<string>> GetOficiosAsync()
        {
            string sql = "select distinct OFICIO from EMP";

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();

            List<string> oficios = new List<string>();
            while(await this.reader.ReadAsync())
            {
                string oficio = this.reader["OFICIO"].ToString();
                oficios.Add(oficio);
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();

            return oficios;
        }

        public async Task<List<string>> GetEmpleadosOficioAsync(string oficio)
        {
            string sql = "select APELLIDO from EMP where OFICIO=@oficio";

            this.com.Parameters.AddWithValue("@oficio", oficio);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            List<string> empleados = new List<string>();
            while(await this.reader.ReadAsync())
            {
                string ape = this.reader["APELLIDO"].ToString();
                empleados.Add(ape);
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            this.com.Parameters.Clear();
            return empleados;
        }

        public async Task<int> UpdateSalarioEmpleadosOficio(string oficio, int incremento)
        {
            string sql = "update EMP set SALARIO=SALARIO+@incremento " +
                " where OFICIO=@oficio";
            this.com.Parameters.AddWithValue("@oficio", oficio);
            this.com.Parameters.AddWithValue("@incremento", incremento);

            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;
            await this.cn.OpenAsync();
            int afectados = await this.com.ExecuteNonQueryAsync();
            
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
            return afectados;
        }
        public async Task UpdateOficio(string nuevo, string old, int incremento)
        {
            string sql = "update EMP set OFICIO=@oficio, SALARIO=SALARIO+@incremento " +
                         " where OFICIO=@old";
            this.com.Parameters.AddWithValue("@oficio", nuevo);
            this.com.Parameters.AddWithValue("@old", old);
            this.com.Parameters.AddWithValue("@incremento", incremento);

            await this.cn.OpenAsync();
            this.com.CommandText = sql;
            await this.com.ExecuteNonQueryAsync();
            await this.cn.CloseAsync();
            this.com.Parameters.Clear();
        }
        
        public async Task<string> CalcularSumaPorOficio(string oficio)
        {
            string sql = "select SUM(SALARIO) as SUMASALARIAL from EMP " +
                " where OFICIO=@oficio";

            this.com.Parameters.AddWithValue("@oficio", oficio);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            string valor ="";
            while (await this.reader.ReadAsync())
            {
                valor = this.reader["SUMASALARIAL"].ToString();
            }

            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            this.com.Parameters.Clear();
            return valor;
        }

        public async Task<string> CalcularMediaPorOficio(string oficio)
        {
            string sql = "select AVG(SALARIO) as MEDIASALARIAL from EMP " +
                " where OFICIO=@oficio";

            this.com.Parameters.AddWithValue("@oficio", oficio);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            string valor = "";
            while (await this.reader.ReadAsync())
            {
                valor = this.reader["MEDIASALARIAL"].ToString();
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            this.com.Parameters.Clear();
            return valor;
        }

        public async Task<string> MaximoPorOficio(string oficio)
        {
            string sql = "select MAX(SALARIO) as MAXSALARIAL from EMP " +
                " where OFICIO=@oficio";

            this.com.Parameters.AddWithValue("@oficio", oficio);
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = sql;

            await this.cn.OpenAsync();
            this.reader = await this.com.ExecuteReaderAsync();
            string valor = "";
            while (await this.reader.ReadAsync())
            {
                valor = this.reader["MAXSALARIAL"].ToString();
            }
            await this.cn.CloseAsync();
            await this.reader.CloseAsync();
            this.com.Parameters.Clear();
            return valor;
        }
    }
}
