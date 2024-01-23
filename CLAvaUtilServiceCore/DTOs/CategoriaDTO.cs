namespace CLAvaUtilService.DTOs
{
    public class CategoriaDTO
    {
        //Capa de acceso al modelo

        public CategoriaDTO(string nombre, double sueldo) { 
            this.Nombre = nombre;
            this.Sueldo = sueldo;
        }
        public string Nombre { get; set; }
        public double Sueldo { get; set; }
    }
}
