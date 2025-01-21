using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNetCorePractica.Helpers;
using Microsoft.Data.SqlClient;

#region PROCEDURES
//SP_ALL_HOSPITALES
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
    }
}
