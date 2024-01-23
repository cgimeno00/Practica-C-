using System;
using System.Collections.Generic;

namespace CLAvaPersistCore.DB;

public partial class Direccione
{
    public int IdDireccion { get; set; }

    public string Calle { get; set; } = null!;

    public string Numero { get; set; } = null!;
}
