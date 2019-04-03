using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VentasBLL
    {
        public bool Guardar(Ventas venta)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Ventas.Add(venta) != null)
                {
                    foreach (var item in venta.Detalle)
                    {
                        contexto.Productos.Find(item.ProductoId).Cantidad -= item.Cantidad;
                    }

                    contexto.Usuarios.Find(venta.UsuarioId).TotalVendido += venta.TotalAPagar;

                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public bool Modificar(Ventas venta)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                Ventas VentaAnt = contexto.Ventas.Find(venta.VentaId);
                var usuario = contexto.Usuarios.Find(venta.UsuarioId);
                var usuarioAnt = contexto.Usuarios.Find(VentaAnt.UsuarioId);

                if (venta.UsuarioId != VentaAnt.UsuarioId)
                {
                    usuario.TotalVendido += venta.TotalAPagar;
                    usuarioAnt.TotalVendido -= VentaAnt.TotalAPagar;
                }
                {
                    decimal diferencia = venta.TotalAPagar - VentaAnt.TotalAPagar;
                    usuario.TotalVendido += diferencia;
                }

                contexto.Entry(venta).State = EntityState.Modified;
                contexto.SaveChanges();
                paso = true;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }


        public bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Ventas venta = contexto.Ventas.Find(id);

                foreach (var item in venta.Detalle)
                {
                    var producto = contexto.Productos.Find(item.ProductoId);
                    producto.Cantidad += item.Cantidad;
                }

                contexto.Usuarios.Find(venta.UsuarioId).TotalVendido -= venta.TotalAPagar;

                contexto.Ventas.Remove(venta);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        public Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas venta = new Ventas();
            try
            {
                venta = contexto.Ventas.Find(id);

                if (venta != null)
                {
                    venta.Detalle.Count();

                    foreach (var item in venta.Detalle)
                    {
                        string s = item.Productos.Descripcion;
                    }
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return venta;

        }


        public List<Ventas> GetList(Expression<Func<Ventas, bool>> expression)
        {
            List<Ventas> list = new List<Ventas>();
            Contexto contexto = new Contexto();
            try
            {
                list = contexto.Ventas.Where(expression).ToList();

                foreach (var item in list)
                {
                    item.Detalle.Count();
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        
    }
}
