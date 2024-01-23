using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CLAvaUtilService.DTOs

{

    public class ClienteDTO

    {

        public ClienteDTO(string nombre)

        {

            this.Nombre = nombre;

        }

        public string Nombre { get; set; }

    }

}
