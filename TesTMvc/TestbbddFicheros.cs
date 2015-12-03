using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubidaFicheros.Models;

namespace TesTMvc
{
    /// <summary>
    /// Summary description for TestbbddFicheros
    /// </summary>
    [TestClass]
    public class TestbbddFicheros : BasePruebas
    {
        public TestbbddFicheros()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void PruebaConsultaFicherosAzure()
        {
            int esperados = 2;
            var recibidos = db.Fichero.Count(o => o.tipo == "azure");
            Assert.AreEqual(esperados,recibidos);
        }

        [TestMethod]
        public void PruebaConsultaFicherosBinarios()
        {
            int n = 0;
            var f = new Fichero()
            {
                datos = "",
                datosb = new byte[] {},
                nombre = "borrar",
                tipoFichero = 1,
                tipo = "azure",
            };

            db.Fichero.Add(f);
            try
            {
                n = db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Assert.IsFalse(n==0);
        }
    }
}
