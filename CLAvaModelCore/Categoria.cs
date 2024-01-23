using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAvaModelCore
{
    public class Categoria
    {
        public Categoria() { }
        
        public string Id { get; set; }  
        public string Nombre { get; set; }
        public string Descripcion {  get; set; }
        public double sueldoMinimo {  get; set; }
         
        public double sueldoMaximo {  get; set; }
        public ECategoria CategoriaTipo { get; set; }//Esta la hacemos para posteriormente poder comparar

        

        public Categoria Clone()
        {
            //Metodo que devuelve el mismo objeto porque queremos clonarlo

            Categoria res = new Categoria();
            res.Nombre = this.Nombre;
            res.Descripcion = this.Descripcion;
            res.sueldoMinimo = this.sueldoMinimo;
            res.sueldoMaximo = this.sueldoMaximo;
            res.CategoriaTipo = this.CategoriaTipo;

            return res;
        }
    }
}
