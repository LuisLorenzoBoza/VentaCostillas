using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VentasCostillas.Utilitarios;

namespace VentasCostillas.Registros
{
    public partial class rProductos : System.Web.UI.Page
    {
        RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
        Expression<Func<Productos, bool>> filtrar = x => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void Limpiar()
        {
            productoIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            DescripcionTextBox.Text = " ";
            PrecioTextBox.Text = "";
            CantidadTextBox.Text = "0";
        }

        private Productos LlenaClase()
        {
            Productos productos = new Productos();
            
            productos.ProductoId = ToInt(productoIdTextBox.Text);
            bool resultado = DateTime.TryParse(fechaTextBox.Text, out DateTime fecha);
            productos.Fecha = fecha;
            productos.Descripcion = DescripcionTextBox.Text;
            productos.Precio = Utils.ToDecimal(PrecioTextBox.Text);
            productos.Cantidad = Utils.ToInt(CantidadTextBox.Text);

            return productos;
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        private bool Validar()
        {
            bool paso = false;

            if (String.IsNullOrWhiteSpace(productoIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Id invalido", "Error", "error");
                paso = true;
            }
            return paso;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos producto = repositorio.Buscar(ToInt(productoIdTextBox.Text));
            if (producto != null)
            {
                DescripcionTextBox.Text = producto.Descripcion;
                fechaTextBox.Text = producto.Fecha.ToString("yyyy-MM-dd");
                PrecioTextBox.Text = producto.Precio.ToString();
                CantidadTextBox.Text = producto.Cantidad.ToString();
                Utils.ShowToastr(this, "Encontrado", "Correcto", "success");
            }
            else
            {
                Utils.ShowToastr(this, "No encontrado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos producto = new Productos();
            bool paso = false;

            if (Validar())
                return;
            else
            {
                //todo: validaciones adicionales
                producto = LlenaClase();

                if (Utils.ToInt(productoIdTextBox.Text) == 0)
                {
                    filtrar = x => x.Descripcion.Equals(DescripcionTextBox.Text);
                    if (repositorio.GetList(filtrar).Count() != 0)
                    {
                        Utils.ShowToastr(this, "Ya existe", "Error", "error");
                        return;
                    }
                    else { 
                    paso = repositorio.Guardar(producto);
                    Utils.ShowToastr(this, "Guardado", "Correcto", "success");
                    Limpiar();
                    }
                }
                else
                {
                    Productos prod = new Productos();
                    int id = ToInt(productoIdTextBox.Text);
                    RepositorioBase<Productos> repository = new RepositorioBase<Productos>();
                    prod = repository.Buscar(id);

                    if (prod != null)
                    {
                        paso = repositorio.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado", "Correcto", "success");
                    }
                    else
                        Utils.ShowToastr(this, "No encontrado", "Error", "error");
                }

                if (paso)
                {
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo guardar", "Error", "error");
            }
        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            int id = ToInt(productoIdTextBox.Text);

            var producto = repositorio.Buscar(id);

            if (producto != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Correcto", "success");
                    Limpiar();
                }
                else
                    Utils.ShowToastr(this, "No se pudo eliminar", "Error", "error");
            }
            else
                Utils.ShowToastr(this, "No existe", "Error", "error");
        }
    }
}