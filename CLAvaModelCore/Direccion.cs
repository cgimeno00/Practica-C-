namespace CLAvaModelCore
{
    /// <summary>
    /// Permite obtener los valores de la direccion
    /// </summary>
    public class Direccion
    {
        public Direccion(string calle, string numero, string localidad, EProvincia provincia, string codigo) { 
            this.Calle = calle;
            this.Numero = numero;
            this.Localidad = localidad;
            this.Provincia = provincia;
            this.CodigoPostal = codigo;
        }
        /// <summary>
        /// Asigna u obtiene el nombre de la calle
        /// </summary>
        public string Calle {  get; set; }

        /// <summary>
        /// Asigna u obtiene el numero de la calle
        /// </summary>
        public string Numero {  get; set; }

        /// <summary>
        /// Asigna u obtiene el Codigo postal
        /// </summary>
        public string CodigoPostal {  get; set; }

        /// <summary>
        /// Asigna u obtiene la localidad
        /// </summary>
        public string Localidad {  get; set; }

        /// <summary>
        /// Asigna u obtiene la provincia
        /// </summary>
        public EProvincia Provincia { get; set; }
    }
}
