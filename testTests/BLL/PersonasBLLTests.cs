using Microsoft.VisualStudio.TestTools.UnitTesting;
using test.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using test.Entidades;

namespace test.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Personas personas = new Personas();
            personas.PersonaID = 0;
            personas.Nombre = "Prueba Test";
            personas.Telefono = "45127893";
            personas.Direccion = "Tenares";
            personas.Cedula = "541258731";
            personas.Balance = 5000;
            personas.FechaNacimiento = DateTime.Now;
            paso = PersonasBLL.Guardar(personas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Personas personas = new Personas();
            personas.PersonaID = 1;
            personas.Nombre = "Prueba Test";
            personas.Telefono = "123456";
            personas.Direccion = "Salcedo";
            personas.Cedula = "123456";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 300;
            paso = PersonasBLL.Modificar(personas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PersonasBLL.Eliminar(3);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Personas personas;
            personas = PersonasBLL.Buscar(2);
            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Personas>();
            listado = PersonasBLL.GetList(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}