﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Funciones
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);

            return retorno;
        }

        public static List<Usuarios> Usuarios(Expression<Func<Usuarios, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> list = new List<Usuarios>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Productos> Productos(Expression<Func<Productos, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            List<Productos> list = new List<Productos>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Entradas> Entradas(Expression<Func<Entradas, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Entradas> repositorio = new RepositorioBase<Entradas>();
            List<Entradas> list = new List<Entradas>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Ventas> Ventas(Expression<Func<Ventas, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            List<Ventas> list = new List<Ventas>();

            list = repositorio.GetList(filtro);

            return list;
        }

        public static List<Usuarios> FiltrarUsuarios(int index, string criterio, DateTime desde, DateTime hasta)
        {
            Expression<Func<Usuarios, bool>> filtro = p => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> list = new List<Usuarios>();

            int id = ToInt(criterio);
            switch (index)
            {
                case 0://Todo
                    break;

                case 1://Todo por fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://Nombres
                    filtro = p => p.Nombres.Contains(criterio) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://UsuarioId
                    filtro = p => p.UsuarioId == id && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
                           
            }

            list = repositorio.GetList(filtro);

            return list;
        }
    }
}
