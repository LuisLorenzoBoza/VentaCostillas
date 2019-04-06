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
    public class EntradasBLL
    {
        public bool Guardar(Entradas entrada)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.Entradas.Add(entrada) != null)
                {
                    contexto.Productos.Find(entrada.ProductoId).Cantidad += entrada.Cantidad;

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


        public bool Modificar(Entradas entrada)
        {
            bool paso = false;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            RepositorioBase<Productos> repositorioDos = new RepositorioBase<Productos>();
            Contexto contexto = new Contexto();

            try
            {
                Entradas EntrAnt = Buscar(entrada.EntradaId);

                var Producto = contexto.Productos.Find(entrada.ProductoId);
                var ProductosAnteriores = contexto.Productos.Find(EntrAnt.ProductoId);                

                if (EntrAnt.ProductoId != entrada.ProductoId)
                {
                    Producto.Cantidad += entrada.Cantidad;
                    ProductosAnteriores.Cantidad -= EntrAnt.Cantidad;
                    repositorio.Modificar(Producto);
                    repositorioDos.Modificar(ProductosAnteriores);
                }

                int modificado = entrada.Cantidad - EntrAnt.Cantidad;
                var Prod = contexto.Productos.Find(entrada.ProductoId);
                Prod.Cantidad += modificado;
                repositorio.Modificar(Prod);

                contexto = new Contexto();
                contexto.Entry(entrada).State = EntityState.Modified;
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


        public bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Entradas entrada = contexto.Entradas.Find(id);

                contexto.Productos.Find(entrada.ProductoId).Cantidad -= entrada.Cantidad;

                contexto.Entradas.Remove(entrada);

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


        public Entradas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Entradas entrada = new Entradas();

            try
            {
                entrada = contexto.Entradas.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return entrada;
        }


        public List<Entradas> GetList(Expression<Func<Entradas, bool>> expression)
        {
            List<Entradas> entradas = new List<Entradas>();
            Contexto contexto = new Contexto();

            try
            {
                entradas = contexto.Entradas.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            return entradas;
        }

    }
}
