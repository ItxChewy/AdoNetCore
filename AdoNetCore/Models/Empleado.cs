using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetCore.Models
{
    public class Empleado
    {
        public int IdEmpleado { get; set; }
        public string Apellido { get; set; }
        public string Oficio { get; set; }
        public int Cod_Director { get; set; }
        public DateTime Fecha_Alta { get; set; }
        public int Salario { get; set; }
        public int Comision { get; set; }
        public int Cod_Departamento { get; set; }
    }
}
