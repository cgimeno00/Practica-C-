using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAvaModelCore
{
    public class Modelo
    {
        private static Modelo instancia;

        public static Modelo Instancia 
        { 
            get 
            { 
                if(instancia == null) 
                    instancia = new Modelo();

                return instancia; 
            } 
        }

        public Modelo() { 
            this.Proyectos = new List<Proyecto>();
            this.Sedes = new List<Sede>();
            this.Categorias = new List<Categoria>();
            this.Talents = new List<Talent>();
            this.Empleados = new List<Empleado>();
            this.Clientes = new List<Cliente>();
        }
        public IList<Empleado> Empleados { get; set; }
        public IList<Sede> Sedes { get; set; }
        public IList<Categoria> Categorias { get; set; }
        public IList<Proyecto> Proyectos { get; set; }
        public IList<Talent> Talents { get; set; }
        public IList<Cliente> Clientes { get; set; }

    }
}
