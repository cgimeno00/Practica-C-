using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public class EmpleadoDTO
{
    public EmpleadoDTO(string nombre, double sueldo)
    {
        this.Nombre = nombre;
        this.Sueldo = sueldo;
    }

    public string Nombre { get; set; }
    public double Sueldo { get; set; }
}