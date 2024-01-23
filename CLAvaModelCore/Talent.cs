using System.Collections.Generic;

namespace CLAvaModelCore
{
    public class Talent
    {
        public Talent() {
            this.Tecnologias = new List<ETecnologia>();
            this.Champions = new Dictionary<ETecnologia, Empleado>();
            this.EmpleadosAsociados = new List<Empleado>();
        }

        public string Nombre {  get; set; }
        public Empleado Responsable { get; set; }
        public IList<ETecnologia> Tecnologias {  get; set; }//En una lista por si tiene varias
        public IDictionary<ETecnologia, Empleado> Champions { get; set; }//Permite establecer la combinacion Clave/Valor
        public List<Empleado> EmpleadosAsociados { get; set; }

        public Talent CloneTalent()
        {
            Talent res = new Talent();

            res.Nombre = this.Nombre;
            res.Responsable = this.Responsable;
            res.Tecnologias = this.Tecnologias;
            res.EmpleadosAsociados = this.EmpleadosAsociados;
            res.Champions = this.Champions;
            
            return res;
        }

    }
}
