using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VentasCostillas.Tests
{
    [TestClass]
    public class UnitTestProductos
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            bool paso = false;

            productos.ProductoId = 5;
            productos.Fecha = DateTime.Now;
            productos.Descripcion = "Coca Cola";
            productos.Precio = 40;
            productos.Cantidad = 0;

            paso = repositorio.Guardar(productos);
            Assert.AreEqual(true, paso);
        }


        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            productos = repositorio.Buscar(5);
            bool paso = false;
            productos.Descripcion = "Coca-Cola";
            paso = repositorio.Modificar(productos);
            Assert.AreEqual(true, paso);
        }


        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos productos = new Productos();
            productos = repositorio.Buscar(5);
            Assert.IsNotNull(productos);
        }


        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            List<Productos> lista = new List<Productos>();
            Expression<Func<Productos, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }


        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            bool paso = false;
            paso = repositorio.Eliminar(5);
            Assert.AreEqual(true, paso);
        }
    }
}
