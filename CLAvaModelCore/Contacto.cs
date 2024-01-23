using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAvaModelCore
{
    public class Contacto
    {
        public Contacto(string nombre, Localizacion localizacion) { 
            this.Nombre = nombre;
            this.Localizacion = localizacion;
        }
        public string Nombre {  get; set; }
        public Localizacion Localizacion { get; set; }
    }
}
