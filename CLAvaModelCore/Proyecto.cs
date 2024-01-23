using System.Collections;
using System.Collections.Generic;

namespace CLAvaModelCore
{
    public class Proyecto
    {

        public Proyecto(string nombre, Empleado responsable, Contacto contacto) { 
            this.Nombre = nombre;
            this.ResponsableEmpresa = responsable;
            this.ContactoCLiente = contacto;
            this.Tecnologias = new List<ETecnologia>();
        }
        public string Nombre {  get; set; }
        public Empleado ResponsableEmpresa { get; set; }
        public Contacto ContactoCLiente { get; set; }
        public IList<ETecnologia> Tecnologias { get; set; }
    }
}
