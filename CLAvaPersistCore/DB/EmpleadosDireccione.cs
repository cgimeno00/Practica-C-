using System;
using System.Collections.Generic;

namespace CLAvaPersistCore.DB;

public partial class EmpleadosDireccione
{
    public int IdEmpleado { get; set; }

    public int IdDireccion { get; set; }

    public virtual Direccione IdDireccionNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
