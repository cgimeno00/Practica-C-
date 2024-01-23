using System.Collections.Generic;

namespace CLAvaModelCore
{
    public class Localizacion
    {
        public Localizacion(Direccion direccion) {
            this.Telefonos = new List<string>();
            this.Correos = new List<string>();
            this.Direccion = direccion;
        }
        public Direccion Direccion { get; set; }
        public IList<string> Telefonos { get; set; }
        public IList<string> Correos { get; set; }
    }
}
