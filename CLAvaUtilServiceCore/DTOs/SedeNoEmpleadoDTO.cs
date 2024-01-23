using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAvaUtilService.DTOs
{
    public class SedeNoEmpleadoDTO
    {
        public SedeNoEmpleadoDTO(string nombre, int sueldo)
        {
            this.Nombre = nombre;
            this.nEmp = sueldo;
        }

        public string Nombre { get; set; }
        public int nEmp { get; set; }
    }
}
