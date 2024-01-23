using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAvaModelCore
{
    public class Sede
    {
        public Sede() { 
            this.Empleados = new List<Empleado>();
            this.Proyectos = new List<Proyecto>();
        }

        public Sede(string nombre, Localizacion localizacion)
        {
            this.Empleados = new List<Empleado>();
            this.Proyectos = new List<Proyecto>();
            this.Nombre = nombre;
            this.Localizacion = localizacion;
        }
        public string Nombre {  get; set; }
        public IList<Empleado> Empleados { get; set; }
        public IList<Proyecto> Proyectos { get; set; }
        public Localizacion Localizacion { get; set; }

        public Sede CloneSede()
        {
            //Metodo que devuelve el mismo objeto porque queremos clonarlo

            Sede res = new Sede();
            res.Empleados = this.Empleados;
            res.Proyectos = this.Proyectos;
            res.Nombre = this.Nombre;
            res.Localizacion = this.Localizacion;

            return res;
        }

    }
}
