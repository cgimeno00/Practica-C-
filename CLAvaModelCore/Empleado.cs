namespace CLAvaModelCore
{
    public class Empleado
    {
        public Empleado() 
        
        {
           
        
        }
        public string Nombre {  get; set; }
        public double Sueldo {  get; set; }
        public Localizacion Localizacion { get; set; }
        public Categoria Categoria { get; set; }
        public Talent Talent { get; set; }
        public Sede Sede { get; set; }



        public Empleado Clone()
        {
            //Metodo que devuelve el mismo objeto porque queremos clonarlo



            Empleado res = new Empleado();
            res.Nombre = this.Nombre;
            res.Sueldo = this.Sueldo;
            res.Localizacion = this.Localizacion;
            res.Categoria = this.Categoria;
            res.Talent = this.Talent;
            res.Sede = this.Sede;



            return res;
        }
    }

  

}
