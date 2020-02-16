using Microsoft.VisualStudio.TestTools.UnitTesting;
using test.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using test.Entidades;

namespace test.BLL.Tests
{
    [TestClass()]
    public class InscripcionesBLLTests
    {
        [TestMethod()]
        public void GuardarInscripcionTest()
        {
            bool paso;
            Inscripciones inscripciones = new Inscripciones();
            inscripciones.InscripcionId = 0;
            inscripciones.Fecha = DateTime.Now;
            inscripciones.PersonaId = 1;
            inscripciones.Comentarios = "Prueba del Test de Inscripcion";
            inscripciones.Monto = 0;
            inscripciones.Balance = 1000;
            inscripciones.Deposito = 0;
            paso = InscripcionesBLL.GuardarInscripcion(inscripciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarInscripcionTest()
        {
            bool paso;
            Inscripciones inscripciones = new Inscripciones();
            inscripciones.InscripcionId = 1;
            inscripciones.Fecha = DateTime.Now;
            inscripciones.PersonaId = 1;
            inscripciones.Comentarios = "Prueba del Test de Inscripcion";
            inscripciones.Monto = 0;
            inscripciones.Balance = 700;
            inscripciones.Deposito = 0;
            paso = InscripcionesBLL.ModificarInscripcion(inscripciones);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarInscripcionTest()
        {
            bool paso;
            paso = InscripcionesBLL.EliminarInscripcion(2, 1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscripciones;
            inscripciones = InscripcionesBLL.Buscar(1);
            Assert.AreEqual(inscripciones, inscripciones);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Inscripciones>();
            listado = InscripcionesBLL.GetList(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}