using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proyecto1_ayd2;

namespace Pruebas_unitarias
{
    [TestClass]
    public class UnitTest1
    {
        //Clase_Controladora clase = new Clase_Controladora();

        [TestMethod]
        public void TestMethod1()
        {
            bool prueba =Clase_Controladora.Login("1","12345");
            bool respuesta = true;
            Console.WriteLine(prueba);
            Assert.AreEqual(prueba, respuesta);

        }
    }
}
