using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using EvolucionTA2;

namespace NUnitTestProject
{
    [TestFixture]
    public class NUnitTest
    {
        [Test]
        public void TestMultiplicar()
        {
            TestClass objeto = new TestClass();
            Assert.AreEqual(12, objeto.Multiplicar(3, 4));
        }

        [Test]
        public void TestParOImpar()
        {
            TestClass objeto = new TestClass();
            Assert.AreEqual("par", objeto.ParOImpar(2));
        }

        [Test]
        public void TestRestar()
        {
            TestClass objeto = new TestClass();
            Assert.AreNotEqual(5, objeto.Restar(8, 2));
        }

        [Test]
        public void TestGetLetra()
        {
            TestClass objeto = new TestClass();
            Assert.AreNotEqual("a", objeto.GetLetra("Hola", 2));
        }

        [Test]
        public void TestGetDato()
        {
            TestClass objeto = new TestClass();
            Assert.IsNull(objeto.GetDato("hola"));
        }

        [Test]
        public void TestNumeroEncontrado()
        {
            TestClass objeto = new TestClass();
            Assert.IsTrue(objeto.NumeroEncontrado(3));
        }

        [Test]
        public void TestGetLista()
        {
            TestClass objeto = new TestClass();
            List<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);

            CollectionAssert.AreEqual(lista, objeto.GetLista());
        }

        [Test]
        public void TestGetPersonas()
        {
            TestClass objeto = new TestClass();
            List<string> esperado = new List<string>();
            esperado.Add("uno");
            esperado.Add("dos");
            esperado.Add("tres");

            List<string> actual = objeto.GetPalabras();

            CollectionAssert.AreEqual(esperado, actual);
        }

        [Test]
        public void TestGetPersonaByCodigo()
        {
            TestClass objeto = new TestClass();
            Persona esperado = new Persona();
            esperado.Codigo = 1; esperado.Nombre = "Ulices"; esperado.Apellido = "Melendez";

            Persona actual = objeto.GetPersonaByCodigo(1);

            Assert.AreEqual(esperado.Codigo, actual.Codigo);
            Assert.AreEqual(esperado.Nombre, actual.Nombre);
            Assert.AreEqual(esperado.Apellido, actual.Apellido);
        }

        [Test]
        public void TestGetPersonaByNombre()
        {
            TestClass objeto = new TestClass();
            Persona esperado = new Persona();
            esperado.Codigo = 1; esperado.Nombre = "Ulices"; esperado.Apellido = "Melendez";

            Persona actual = objeto.GetPersonaByNombre("Ulices");

            Assert.AreEqual(esperado.Codigo, actual.Codigo);
            Assert.AreEqual(esperado.Nombre, actual.Nombre);
            Assert.AreEqual(esperado.Apellido, actual.Apellido);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestIngresoDato()
        {
            TestClass objeto = new TestClass();
            Persona persona = new Persona();
            persona.Codigo = 2;
            persona.Nombre = null;
            persona.Apellido = "dsadas";
            try
            {
                objeto.IngresoDatos(persona);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Nombre no existe", ex.Message);
                throw;
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDivision()
        {
            try
            {
                TestClass objeto = new TestClass();
                decimal resultado = objeto.Division(5, 0);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No se puede dividir entre cero", ex.Message);
                throw;
            }
        }

        [Test]
        public void TestGetPersonaPorCodigo()
        {
            TestClass objeto = new TestClass();
            Persona persona = objeto.GetPersonaPorCodigo(1);

            Assert.AreEqual(1, persona.Codigo);
            Assert.AreEqual("Ulices", persona.Nombre);
            Assert.AreEqual("Melendez", persona.Apellido);
        }

        [Test]
        public void TestGetCantidadPersonas()
        {
            TestClass objeto = new TestClass();
            int cantidad = objeto.GetCantidadPersonas();
            Assert.AreEqual(5, cantidad);
        }

        [Test]
        public void TestPersonaExiste()
        {
            TestClass objeto = new TestClass();
            List<Persona> personas = objeto.GetPersonasPorNombre("sdfsd");
            Assert.IsEmpty(personas);
        }

        [Test]
        public void TestValidarNombre()
        {
            try
            {
                TestClass objeto = new TestClass();
                objeto.AgregarPersona(null, "Veliz");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No existe nombre", ex.Message);
            }
            
        }

        [Test]
        public void TestValidarApellido()
        {
            try
            {
                TestClass objeto = new TestClass();
                objeto.AgregarPersona("Luis", null);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No existe apellido", ex.Message);
            }
        }

        [Test]
        public void TestSeAgregoPersona()
        {
            try
            {
                TestClass objeto = new TestClass();
                objeto.AgregarPersona("Luis", "Veliz");
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Persona agregada", ex.Message);
            }
        }


    }
}
