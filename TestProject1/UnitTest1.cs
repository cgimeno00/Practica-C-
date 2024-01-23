namespace TestProject1
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
            CLAvaUtilServiceCore.ServicioCore servicio= new CLAvaUtilServiceCore.ServicioCore();

            servicio.ObtenerCategorias();
        }
    }
}