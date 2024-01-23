using System.Collections.Generic;

namespace CLAvaModelCore
{
    public class Cliente
    {

        public Cliente(string nombre, Localizacion localizacion, Empleado responsable) { 
            this.Nombre = nombre;
            this.Localizacion = localizacion;
            this.ResponsableEmpresa = responsable;
            this.Proyectos = new List<Proyecto>();

        }
        public Cliente() { }
        public string Nombre {  get; set; }
        public Localizacion Localizacion { get; set; }
        public Empleado ResponsableEmpresa { get; set; }
        public IList<Proyecto> Proyectos { get; set; }

        public Cliente CloneCliente()
        {
            Cliente res = new Cliente();
            res.Nombre = this.Nombre;
            res.Localizacion = this.Localizacion;
            res.ResponsableEmpresa = this.ResponsableEmpresa;
            res.Proyectos = this.Proyectos;
            return res;
        }
    }
}
