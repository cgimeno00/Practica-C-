using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAvaUtilService.DTOs
{
    public class TalentDTO
    {
        public TalentDTO(string nombre, string responsable, int numEmpleados)
        {
            this.Nombre = nombre;
            this.Responsable = responsable;
            this.NumEmpleados = numEmpleados;
        }

        public string Nombre { get; set; }
        public string Responsable { get; set; }
        public int NumEmpleados { get; set; }
    }
}
