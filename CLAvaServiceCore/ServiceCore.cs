using CLAvaModelCore;
using CLAvaPersistCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CLAvaServiceCore
{
    public class ServiceCore
    {
        public ServiceCore()
        {
            this.llenarON();
        }

        #region Métodos públicos

        public IList<Categoria> ObtenerCategoriasON()
        {
            IList<Categoria> res = null;

            if (Modelo.Instancia.Categorias == null || Modelo.Instancia.Categorias.Count == 0) return res;

            res = new List<Categoria>();

            foreach (Categoria cat in Modelo.Instancia.Categorias)
            {
                res.Add(cat.Clone());//Crea una nueva lista de Categorias con los objetos clonados
            }

            return res;//Devuelve la lista
        }

        public IList<Sede> ObtenerSedesON()
        {
            IList<Sede> res = null;

            if (Modelo.Instancia.Sedes == null || Modelo.Instancia.Sedes.Count == 0) return res;

            res = new List<Sede>();

            foreach (Sede sed in Modelo.Instancia.Sedes)
            {
                res.Add(sed.CloneSede());//Crea una nueva lista de Sedes con los objetos clonados
            }

            return res;//Devuelve la lista
        }

        public IList<Cliente> ObtenerClientesON()
        {
            IList<Cliente> res = null;

            if (Modelo.Instancia.Clientes == null || Modelo.Instancia.Clientes.Count == 0)
                return res;

            res = new List<Cliente>();

            foreach (Cliente cliente in Modelo.Instancia.Clientes)
            {
                res.Add(cliente.CloneCliente());
            }

            return res;
        }

        public IList<Talent> ObtenerTalentsON()
        {
            IList<Talent> res = null;

            if (Modelo.Instancia.Talents == null || Modelo.Instancia.Talents.Count == 0) return res;

            res = new List<Talent>();

            foreach (Talent talent in Modelo.Instancia.Talents)
            {
                res.Add(talent.CloneTalent());
            }

            return res;
        }

        public IList<Empleado> ObtenerEmpleadosON()

        {

            IList<Empleado> res = null;

            if (Modelo.Instancia.Categorias == null || Modelo.Instancia.Categorias.Count == 0)
                return res;

            res = new List<Empleado>();

            foreach (Empleado cat in Modelo.Instancia.Empleados)
            {
                res.Add(cat.Clone()); //Crea una nueva lista de Empleados con los objetos clonados
            }

            return res;//Devuelve la lista
        }

        public bool AgregarCategoria(string nombre, double sueldoMinimo, double sueldoMaximo, ECategoria categoria)
        {
            bool res = true;

            if (!this.ValidarCadena(nombre))
            {
                res = false;
                return res;
            }

            if (sueldoMinimo < 0 || sueldoMaximo < 0 || sueldoMinimo > sueldoMaximo)
            {
                res = false;
                return res;
            }

            Categoria categoria1 = new Categoria();
            categoria1.sueldoMinimo = sueldoMinimo;
            categoria1.sueldoMaximo = sueldoMaximo;
            categoria1.CategoriaTipo = categoria;

            return res;
        }

        public int ObtenerNoEmpleados(Talent talent)
        {
            int res = 0;

            if (talent == null || Modelo.Instancia.Talents.Count == 0)
                return res;

            res = Modelo.Instancia.Empleados.Where(e => e.Talent.Nombre.Equals(talent.Nombre)).Count();

            return res;
        }

        public bool EliminarCategoria(string nombre)
        {
            bool res = false;

            if (string.IsNullOrEmpty(nombre)) return res;

            string auxNombre = this.ajustarNombre(nombre);

            Categoria cat = Modelo.Instancia.Categorias.FirstOrDefault(c => this.ajustarNombre(c.Nombre) == auxNombre);

            if (cat != null)
            {
                Modelo.Instancia.Categorias.Remove(cat);
                res = true;
            }

            return res;
        }

        #endregion

        #region Métodos privados

        private string ajustarNombre(string nombre)
        {
            return nombre.Replace(" ", "").ToUpper();
        }

        private void llenarON()
        {
            if (this.estaLlenoOn()) return;//Si esta lleno no continua con el resto y por tanto no lo llena

            //Sede
            Direccion direccionBar = crearDireccion("Avenida direccion de Barcelona", "2", "Barcelona", EProvincia.Barcelona, "28476");
            Localizacion localizacionBar = crearLocalizacion(direccionBar, "correo.barcelona@avanade.com", "657483657");
            Sede sedeBarcelona = crearSede(localizacionBar, "Sede Barcelona");

            Direccion direccionMal = crearDireccion("Avenida direccion de Malaga", "45", "Malaga", EProvincia.Malaga, "28567");
            Localizacion localizacionMal = crearLocalizacion(direccionMal, "correo.malaga@avanade.com", "657483657");
            Sede sedeMalaga = crearSede(localizacionMal, "Sede Malaga");

            Direccion direccionMad = crearDireccion("Avenida direccion de Madrid", "23", "Madrid", EProvincia.Madrid, "28889");
            Localizacion localizacionMad = crearLocalizacion(direccionMad, "correo.madrid@avanade.com", "645372857");
            Sede sedeMadrid = crearSede(localizacionMad, "Sede Madrid");

            //Categorias
            /*Categoria programador = crearCat("Programador", ECategoria.Programador, 15000, 18000, "Programador junior");
            //Categoria programadorSr = crearCat("ProgramadorSr", ECategoria.ProgramadorSr, 17000, 21000, "Programador senior");
            //Categoria analista = crearCat("Analista", ECategoria.Analista, 20000, 25000, "Analista");
            //Categoria analistaSr = crearCat("AnalistaSr", ECategoria.AnalistaSr, 24000, 27000, "Analista senior");
            //Categoria consultor = crearCat("Consultor", ECategoria.Consultor, 27000, 37000, "Consultor");
            //Categoria consultorSr = crearCat("ConsultorSr", ECategoria.ConsultorSr, 36000, 48000, "Consultor con experiencia");
            //Categoria gerente = crearCat("Gerente", ECategoria.Gerente, 47000, 57000, "Gerente");
            //Categoria groupManager = crearCat("GroupManager", ECategoria.GroupManager, 60000, 90000, "Gerente con experiencia");
            //Categoria director = crearCat("Director", ECategoria.Director, 87000, 130000, "Director");
            //Categoria directorSr = crearCat("DirectorSr", ECategoria.DirectorSr, 120000, 300000, "Director con experiencia");*/
            
            PersistServiceCore entities = new PersistServiceCore();
            IList<Categoria> categorias = entities.ObtenerCategorias();

            foreach (var item in categorias)
            {
                Categoria categoria = this.crearCat(item.Nombre, item.CategoriaTipo, (int)item.sueldoMinimo, (int)item.sueldoMaximo, item.Descripcion);

                Modelo.Instancia.Categorias.Add(categoria);
            }
            //empleados
            Empleado e1 = crearEmpleado("Juan", Modelo.Instancia.Categorias[0], 17, sedeBarcelona);
            Empleado e2 = crearEmpleado("Pedro", Modelo.Instancia.Categorias[2], 17, sedeMadrid);
            Empleado e3 = crearEmpleado("Manolo", Modelo.Instancia.Categorias[3], 17, sedeMadrid);
            Empleado e4 = crearEmpleado("Marcos", Modelo.Instancia.Categorias[4], 17, sedeMadrid);
            Empleado e5 = crearEmpleado("Alberto", Modelo.Instancia.Categorias[5], 17, sedeMadrid);
            Empleado e6 = crearEmpleado("Pepe", Modelo.Instancia.Categorias[6], 17, sedeMadrid);

            //proyecto
            Contacto c1 = crearContacto("Persona", localizacionMad);
            Proyecto proyecto_mrtt = this.crearProyecto("MRTT", e2, c1);
            Proyecto proyecto_am = this.crearProyecto("A400M", e5, c1);
            Proyecto proyecto_sh = this.crearProyecto("Migracion sharepoint", e3, c1);
            proyecto_mrtt.Tecnologias.Add(ETecnologia.Net);
            proyecto_am.Tecnologias.Add(ETecnologia.Net);
            proyecto_sh.Tecnologias.Add(ETecnologia.Net);

            //Talent
            Talent t1 = crearTalent("CRM", e1);
            Talent t2 = crearTalent("SE", e2);


            //Clientes
            Cliente airbus = crearCliente("Airbus", localizacionBar, e1);
            Cliente repsol = crearCliente("Repsol", localizacionMad, e1);

            sedeBarcelona.Proyectos.Add(proyecto_mrtt);
            sedeMadrid.Proyectos.Add(proyecto_am);
            sedeMalaga.Proyectos.Add(proyecto_sh);

            sedeBarcelona.Empleados.Add(e1);
            sedeBarcelona.Empleados.Add(e2);
            sedeBarcelona.Empleados.Add(e4);
            sedeMadrid.Empleados.Add(e3);
            sedeMadrid.Empleados.Add(e5);
            sedeMalaga.Empleados.Add(e6);

            t1.Champions.Add(ETecnologia.Net, e3);
            t2.Champions.Add(ETecnologia.Net, e4);

            t1.Tecnologias.Add(ETecnologia.Angular);
            t1.Tecnologias.Add(ETecnologia.SQL);
            t2.Tecnologias.Add(ETecnologia.Net);
            t2.Tecnologias.Add(ETecnologia.Azure);

            airbus.Proyectos.Add(proyecto_mrtt);
            airbus.Proyectos.Add(proyecto_am);
            repsol.Proyectos.Add(proyecto_sh);

            e1.Talent = t2;
            e2.Talent = t2;
            e3.Talent = t1;
            e4.Talent = t2;
            e5.Talent = t1;
            e6.Talent = t2;

            e1.Localizacion = localizacionMad;
            e2.Localizacion = localizacionMad;
            e3.Localizacion = localizacionBar;
            e4.Localizacion = localizacionBar;
            e5.Localizacion = localizacionMal;
            e6.Localizacion = localizacionMal;

            Modelo.Instancia.Proyectos.Add(proyecto_am);
            Modelo.Instancia.Proyectos.Add(proyecto_mrtt);
            Modelo.Instancia.Proyectos.Add(proyecto_sh);

            Modelo.Instancia.Sedes.Add(sedeBarcelona);
            Modelo.Instancia.Sedes.Add(sedeMadrid);
            Modelo.Instancia.Sedes.Add(sedeMalaga);

            Modelo.Instancia.Talents.Add(t1);
            Modelo.Instancia.Talents.Add(t2);

            Modelo.Instancia.Empleados.Add(e1);
            Modelo.Instancia.Empleados.Add(e2);
            Modelo.Instancia.Empleados.Add(e3);
            Modelo.Instancia.Empleados.Add(e4);
            Modelo.Instancia.Empleados.Add(e5);
            Modelo.Instancia.Empleados.Add(e6);

            //Modelo.Instancia.Categorias.Add(programador);
            //Modelo.Instancia.Categorias.Add(programadorSr);
            //Modelo.Instancia.Categorias.Add(analista);
            //Modelo.Instancia.Categorias.Add(analistaSr);
            //Modelo.Instancia.Categorias.Add(consultor);
            //Modelo.Instancia.Categorias.Add(consultorSr);
            //Modelo.Instancia.Categorias.Add(gerente);
            //Modelo.Instancia.Categorias.Add(groupManager);
            //Modelo.Instancia.Categorias.Add(director);
            //Modelo.Instancia.Categorias.Add(directorSr);

            Modelo.Instancia.Clientes.Add(airbus);
            Modelo.Instancia.Clientes.Add(repsol);
        }

        private bool estaLlenoOn()
        {
            if (Modelo.Instancia.Categorias != null & Modelo.Instancia.Categorias.Count > 0)
                return true;
            else
                return false;
        }

        private bool ValidarCadena(string cadena)
        {
            // Definir una expresión regular para validar la cadena
            string patron = @"^[A-Z][a-z]+$|^[A-Z][a-z]+ [A-Z][a-z]+$";
            // Usar Regex.IsMatch para verificar si la cadena cumple con el patrón
            return Regex.IsMatch(cadena, patron);
        }

        private Talent crearTalent(string nombre, Empleado responsable)
        {
            Talent talent = new Talent();

            talent.Nombre = nombre;
            talent.Responsable = responsable;

            return talent;
        }

        private Empleado crearEmpleado(string nombre, Categoria cat, double sueldo, Sede sede)
        {
            Empleado emp = new Empleado();

            emp.Nombre = nombre;
            emp.Categoria = cat;
            sueldo = verificarSueldo(sueldo, cat);
            emp.Sueldo = sueldo;
            emp.Sede = sede;

            return emp;
        }

        private Cliente crearCliente(string nombre, Localizacion localizacion, Empleado responsable)
        {
            Cliente cliente = new Cliente(nombre, localizacion, responsable);

            return cliente;
        }

        private double verificarSueldo(double sueldo, Categoria cat)
        {
            //si el sueldo es mayor que el maximo se ajusta al maximo y si es menor que el minimo se ajusta al minimo
            if (sueldo < cat.sueldoMinimo)
                return cat.sueldoMinimo;

            if (sueldo > cat.sueldoMaximo)
                return cat.sueldoMaximo;

            return sueldo;
        }

        private Categoria crearCat(string nombre, ECategoria categoria, int sMin, int sMax, string descripcion)
        {
            Categoria cat = new Categoria();

            cat.CategoriaTipo = categoria;
            cat.sueldoMinimo = sMin;
            cat.sueldoMaximo = sMax;
            cat.Nombre = nombre;
            cat.Descripcion = descripcion;

            return cat;
        }

        private Sede crearSede(Localizacion localizacion, string nombre)
        {
            Sede sede = new Sede();
            sede.Nombre = nombre;
            sede.Localizacion = localizacion;
            return sede;
        }

        private Direccion crearDireccion(string calle, string numero, string localidad, EProvincia provincia, string codigo)
        {
            Direccion direccion1 = new Direccion(calle, numero, localidad, provincia, codigo);
            return direccion1;
        }

        private Localizacion crearLocalizacion(Direccion direccion, string correos, string telefonos)
        {
            Localizacion localizacion = new Localizacion(direccion);
            localizacion.Correos.Add(correos);
            localizacion.Telefonos.Add(telefonos);
            return localizacion;
        }

        private Proyecto crearProyecto(string nombre, Empleado responsable, Contacto contacto)
        {
            Proyecto proyecto = new Proyecto(nombre, responsable, contacto);

            return proyecto;
        }

        private Contacto crearContacto(string nombre, Localizacion localizacion)
        {
            Contacto contacto = new Contacto(nombre, localizacion);

            return contacto;
        }

        #endregion
    }
}
