using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VentasCostillas.Tests
{
    [TestClass]
    public class UnitTestUsuarios
    {
        [TestMethod]
        public void Guardar()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            bool paso = false;

            usuario.UsuarioId = 5;
            usuario.Fecha = DateTime.Now;
            usuario.Nombres = "Luis";
            usuario.Email = "luis@hotmail.com";
            usuario.Contraseña = "0000";
            usuario.TotalVendido = 1000;

            paso = repositorio.Guardar(usuario);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Modificar()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            usuario = repositorio.Buscar(5);
            bool paso = false;
            usuario.Nombres = "Pedro";
            paso = repositorio.Modificar(usuario);
            Assert.AreEqual(true, paso);
        }

        [TestMethod]
        public void Buscar()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            usuario = repositorio.Buscar(5);
            Assert.IsNotNull(usuario);
        }

        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> lista = new List<Usuarios>();
            Expression<Func<Usuarios, bool>> resultados = p => true;
            lista = repositorio.GetList(resultados);
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void Eliminar()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            bool paso = false;
            paso = repositorio.Eliminar(5);
            Assert.AreEqual(true, paso);
        }
    }

}

