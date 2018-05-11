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
        /* Pruebas unitarias para Registro */
        [TestMethod]
        public void Prueba_Correo()
        {
            String correo = "@yahoo.com";
            Assert.IsFalse(Clase_Controladora.validarCorreo(correo));
            correo = "usuario@.com";
            Assert.IsFalse(Clase_Controladora.validarCorreo(correo));
            correo = "usuario.com";
            Assert.IsFalse(Clase_Controladora.validarCorreo(correo));
            correo = "usuario@correo.com";
            Assert.IsTrue(Clase_Controladora.validarCorreo(correo));
        }

        [TestMethod]
        public void Prueba_Ingresar_Saldo()
        {
            String saldo = "hola jeje";
            Assert.IsFalse(Clase_Controladora.validarSaldo(saldo));
            saldo = "1000";
            Assert.IsTrue(Clase_Controladora.validarSaldo(saldo));
        }

        [TestMethod]
        public void Prueba_Registro()
        {
            String nombre = "Usuario";
            String apellido = "Apellido";
            String DPI = "123456";
            String contra = "123456";
            String correo = "a@b.com";
            String saldo = "saldo";
            Object respuesta = Clase_Controladora.registrarse(nombre,apellido,contra,DPI,correo,saldo);
            Assert.IsNull(respuesta);
        }
    }
}
