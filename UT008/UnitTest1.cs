namespace UT008
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            CLAvaPersistCore.PersistServiceCore persistService = new CLAvaPersistCore.PersistServiceCore();
            CLAvaModelCore.Categoria grabada = new CLAvaModelCore.Categoria();

            grabada.Nombre = "Sergio Core";
            grabada.sueldoMaximo = 150;
            grabada.sueldoMinimo = 0;
     
            var a = persistService.GrabarCategoria(grabada);
            var u = persistService.ObtenerCategorias();
        }
    }
}