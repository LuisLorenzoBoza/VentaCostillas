using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VentasCostillas.Tests
{
    [TestClass]
    public class UnitTestEntradas
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
            Entradas entradas = new Entradas();
            bool paso = false;

            entradas.EntradaId = 2;
            entradas.Fecha = DateTime.Now;
            entradas.ProductoId = 1;
            entradas.Cantidad = 20;
           

            paso = repositorio.Guardar(entradas);
            Assert.AreEqual(true, paso);
        }


        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
            Entradas entradas = new Entradas();
            entradas = repositorio.Buscar(1);
            bool paso = false;
            entradas.ProductoId = 2;
            paso = repositorio.Modificar(entradas);
            Assert.AreEqual(true, paso);
        }


        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
            Entradas entradas = new Entradas();
            entradas = repositorio.Buscar(2);
            Assert.IsNotNull(entradas);
        }


        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
            List<Entradas> lista = new List<Entradas>();
            Expression<Func<Entradas, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }


        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
            int id = 2;
            bool paso = false;
            paso = repositorio.Eliminar(id);
            Assert.AreEqual(true, paso);
        }

    }
}
