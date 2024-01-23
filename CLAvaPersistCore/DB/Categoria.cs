using System;
using System.Collections.Generic;

namespace CLAvaPersistCore.DB;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal SueldoMin { get; set; }

    public decimal SueldoMax { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
