using CLAvaModelCore;
using CLAvaPersistCore.DB;

namespace CLAvaPersistCore
{
    public class PersistServiceCore
    {
        AvaBbddcloud01Context entities;

        public PersistServiceCore()
        {
            this.entities = new AvaBbddcloud01Context();
        }

        public bool GrabarCategoria(CLAvaModelCore.Categoria categoria)
        {
            bool res = false;

            if (string.IsNullOrEmpty(categoria.Nombre)) return res;

            int id;

            if (!this.obtenerCategoriaId(out id)) return res;
            else res = true;

            DB.Categoria entitiesCategorias = new DB.Categoria();

            entitiesCategorias.Nombre = categoria.Nombre;
            entitiesCategorias.SueldoMax = (decimal)categoria.sueldoMaximo;
            entitiesCategorias.SueldoMin = (decimal)categoria.sueldoMinimo;
            entitiesCategorias.IdCategoria = id;

            this.entities.Categorias.Add(entitiesCategorias);

            this.entities.SaveChanges();

            return res;
        }

        public IList<CLAvaModelCore.Categoria> ObtenerCategorias()
        {
            IList<CLAvaModelCore.Categoria> res = null;

            if (this.entities == null || this.entities.Categorias == null || this.entities.Categorias.Count() == 0)
            {
                return res;
            }

            res = new List<CLAvaModelCore.Categoria>();

            CLAvaModelCore.Categoria categoria;
            foreach (DB.Categoria persistCategoria in this.entities.Categorias)
            {
                categoria = new CLAvaModelCore.Categoria();
                categoria.Nombre = persistCategoria.Nombre;
                categoria.sueldoMaximo = (double)persistCategoria.SueldoMax;
                categoria.sueldoMinimo = (double)persistCategoria.SueldoMin;
                categoria.CategoriaTipo = this.obtenerCategoriaTipo(categoria.Nombre);

                res.Add(categoria);
            }

            return res;
        }

        private ECategoria obtenerCategoriaTipo(string nombre)
        {
            ECategoria res = ECategoria.Desconocida;

            switch (nombre.ToUpper().Replace(" ", ""))
            {
                case "ANALISTA":
                    res = ECategoria.Analista;
                    break;

                case "PROGRAMADOR":
                    res = ECategoria.Programador;
                    break;

                case "CONSULTOR":
                    res = ECategoria.Consultor;
                    break;

                case "DIRECTOR":
                    res = ECategoria.Director;
                    break;

                case "GERENTE":
                    res = ECategoria.Gerente;
                    break;

                case "GROUPMANAGER":
                    res = ECategoria.GroupManager;
                    break;

                case "PROGRAMADORSR":
                    res = ECategoria.ProgramadorSr;
                    break;

                case "ANALISTASR":
                    res = ECategoria.AnalistaSr;
                    break;

                case "CONSULTORSR":
                    res = ECategoria.ConsultorSr;
                    break;

                case "DIRECTORSR":
                    res = ECategoria.DirectorSr;
                    break;
            }

            return res;
        }

        private bool obtenerCategoriaId(out int id)
        {
            bool res = true;

            id = -1;

            if (this.entities.Categorias.Count() == 0)
            {
                return res;
            }

            id = this.entities.Categorias.Max(c => c.IdCategoria) + 1;//obtener id categoria

            return res;
        }
    }
}
