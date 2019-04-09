using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VentasCostillas.Tests
{
    [TestClass]
    public class UnitTestVentas
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            Ventas ventas = new Ventas();
            bool paso = false;

            ventas.VentaId = 2;
            ventas.Fecha = DateTime.Now;
            ventas.UsuarioId = 1;
            ventas.TotalAPagar = 1800;
            ventas.Efectivo = 2000;
            ventas.Devuelta = 200;
            ventas.Detalle.Add(new VentasDetalle(3, 2, 3, "Coca Cola", 2, 40, 80));
            ventas.Detalle.Add(new VentasDetalle(4, 2, 4, "Coca-Cola", 1, 40, 40));

            paso = repositorio.Guardar(ventas);
            Assert.AreEqual(true, paso);
        }


        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            Ventas ventas = new Ventas();
            ventas = repositorio.Buscar(2);
            Assert.IsNotNull(ventas);
        }


        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            Ventas ventas = new Ventas();
            ventas = repositorio.Buscar(2);
            Assert.IsNotNull(ventas);
        }


        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            List<Ventas> lista = new List<Ventas>();
            Expression<Func<Ventas, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }


        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            bool paso = false;
            paso = repositorio.Eliminar(2);
            Assert.AreEqual(true, paso);
        }
    }
}
