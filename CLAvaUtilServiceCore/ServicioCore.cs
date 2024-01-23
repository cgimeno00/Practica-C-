
using CLAvaModelCore;
using CLAvaServiceCore;
using CLAvaUtilService.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace CLAvaUtilServiceCore
{
    public class ServicioCore
    {
        private ServiceCore serviceCore;

        public ServicioCore()
        {
            serviceCore = new ServiceCore();
        }

        #region Métodos públicos

        public IList<CategoriaDTO> ObtenerCategorias()
        {
            ///Obtenemos la lista de categorias
            ///Si no hay catogrias devuelve null

            IList<CategoriaDTO> res = null;

            //CLAvaService.Service service = new CLAvaService.Service();//Se instancia de esta forma porque al llamarse igual que la del otro proyecto tenemos que especificar cual queremos
            //Si no lo hiciesemos por defecto instancia la del proyecto donde se encuentra
            IList<Categoria> CategoriasOn = serviceCore.ObtenerCategoriasON();

            if (CategoriasOn == null) return res;


            res = new List<CategoriaDTO>();

            foreach (var item in CategoriasOn)
            {
                //Instancia objetos de tipo CategoriaDTO con las propiedades de los objetos de tipo Categoria y los agrega a la lista
                res.Add(new CategoriaDTO(item.Nombre, this.obtenerSueldoAVisualizar(item)));
            }

            return res;
        }

        public EmpleadoDTO ObtenerEmpleadoConSueldoMaximo()
        {
            EmpleadoDTO empleado = null;

            IList<EmpleadoDTO> empleados = this.ObtenerEmpleados();

            if (empleados == null || empleados.Count == 0) { return empleado; }

            #region Código antiguo
            //double sueldoMaximo = 0.0;
            //foreach (var item in empleados)
            //{
            //    if (item.Sueldo > sueldoMaximo)
            //    {
            //        sueldoMaximo = item.Sueldo;
            //        empleado = (EmpleadoDTO)item;
            //    }
            //}
            #endregion

            empleado = empleados.OrderByDescending(e => e.Sueldo).FirstOrDefault();

            return empleado;
        }

        public IList<SedeNoEmpleadoDTO> ObtenerNoEmpleadoSede()
        {
            IList<SedeNoEmpleadoDTO> res = null;

            IList<Sede> sedes = serviceCore.ObtenerSedesON();

            if (sedes == null) return res;

            res = new List<SedeNoEmpleadoDTO>();

            foreach (var item in sedes)
            {
                if (item.Empleados == null) continue;

                res.Add(new SedeNoEmpleadoDTO(item.Nombre, item.Empleados.Count/* this.ObtenerNumeroDeEmpleadosPorSedeRecibida(item)*/));
            }

            return res;
        }

        public IList<EmpleadoDTO> ObtenerEmpleados()
        {
            IList<EmpleadoDTO> res = null;
            IList<Empleado> empleados = serviceCore.ObtenerEmpleadosON();//Obtiene la lista de empleados

            if (empleados == null) return res;

            res = new List<EmpleadoDTO>();

            foreach (var item in empleados)
            {
                res.Add(new EmpleadoDTO(item.Nombre, item.Sueldo));//En la lista de EmpleadosDTO, meto los objetos instanciados con los datos de la lista principal 
            }

            return res;
        }

        public IList<TalentDTO> ObtenerTalents()
        {
            IList<TalentDTO> res = null;

            ServiceCore service = new ServiceCore();
            IList<Talent> talents = service.ObtenerTalentsON();

            if (talents == null)
                return res;

            res = new List<TalentDTO>();

            foreach (var item in talents)
            {
                // Calcular el número de empleados asociados a este talent
                int numEmpleados = service.ObtenerNoEmpleados(item);

                res.Add(new TalentDTO(item.Nombre, item.Responsable.Nombre, numEmpleados));
            }

            return res;
        }

        public void EliminarCategoria(string nombre)
        {
            if (string.IsNullOrEmpty(nombre)) return;

            this.serviceCore.EliminarCategoria(nombre);
        }

        public IList<ClienteDTO> ObtenerClientes()

        {

            IList<ClienteDTO> res = null;

            IList<Cliente> Clientes = serviceCore.ObtenerClientesON();

            if (Clientes == null) return res;

            res = new List<ClienteDTO>();

            foreach (var item in Clientes)
            {
                res.Add(new ClienteDTO(item.Nombre));
            }

            return res;
        }

        public TalentDTO ObtenerTalentConMasEmpleados()
        {
            IList<TalentDTO> talents = this.ObtenerTalents();

            TalentDTO talentConMasEmpleados = null;

            int maxEmpleados = 0;

            foreach (var talent in talents)
            {
                if (talent.NumEmpleados > maxEmpleados)
                {
                    maxEmpleados = talent.NumEmpleados;
                    talentConMasEmpleados = talent;
                }
            }

            return talentConMasEmpleados;
        }

        #endregion

        #region Métodos privados

        private double obtenerSueldoAVisualizar(Categoria item)
        {
            double res = 0.0;

            if (item == null) return res;

            res = (item.sueldoMinimo + item.sueldoMaximo) / 2;

            return res;
        }

        private int ObtenerNumeroDeEmpleadosPorSedeRecibida(Sede item)
        {
            int res = 0;
            if (item == null) { return res; }

            res = item.Empleados.Count;
            return res;
        }

        #endregion
    }
}