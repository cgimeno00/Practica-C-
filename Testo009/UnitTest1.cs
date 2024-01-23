using CLAvaUtilServiceCore;

namespace Testo009
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
         ServicioCore servicio = new ServicioCore();

         var u =  servicio.ObtenerCategorias();

           
        }
    }
}