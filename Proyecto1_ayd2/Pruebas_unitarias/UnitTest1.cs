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
        public void Prueba_Login()
        {
            bool prueba =Clase_Controladora.Login("1","12345");
            bool respuesta = true;
            Console.WriteLine(prueba);
            Assert.AreEqual(prueba, respuesta);

        }
        [TestMethod]
        public void Prueba_Saldo()
        {
            String prueba = Clase_Controladora.Retornar_saldo("1");
            String respuesta = "500";
            Console.WriteLine(prueba);
            Assert.AreEqual(prueba, respuesta);
        }
        [TestMethod]
        public void Prueba_Nombre()
        {
            String prueba = Clase_Controladora.Retornar_nombre("1");
            String respuesta = "Sergio De Los Rios";
            Console.WriteLine(prueba);
            
            Assert.AreEqual(prueba.Trim().ToLower(), respuesta.Trim().ToLower());
        }
    }
}
