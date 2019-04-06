using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VentasCostillas.Utilitarios;

namespace VentasCostillas.Registros
{
    public partial class rEntradas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                Combo();
            }
        }

        private void Combo()
        {
            RepositorioBase<Productos> repository = new RepositorioBase<Productos>();
            productoDropDownList.DataSource = repository.GetList(t => true);
            productoDropDownList.DataValueField = "ProductoId";
            productoDropDownList.DataTextField = "Descripcion";
            productoDropDownList.DataBind();
        }

        private Entradas LlenaClase()
        {
            Entradas entrada = new Entradas();

            entrada.EntradaId = Utils.ToInt(EntradaIdTextBox.Text);
            entrada.Fecha = DateTime.Now;
            entrada.ProductoId = Utils.ToIntObjetos(productoDropDownList.SelectedValue);
            entrada.Cantidad = Utils.ToInt(cantidadTextBox.Text);

            return entrada;
        }

        private void Limpiar()
        {
            EntradaIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            productoDropDownList.SelectedIndex = 0; ;
            cantidadTextBox.Text = "0";
        }

        public void Campos(Entradas entrada)
        {
            Limpiar();
            EntradaIdTextBox.Text = entrada.EntradaId.ToString();
            productoDropDownList.SelectedValue = entrada.ProductoId.ToString();
            cantidadTextBox.Text = entrada.Cantidad.ToString();
        }

        private bool Validar()
        {
            bool HayErrores = false;
            if (Utils.ToIntObjetos(productoDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "No hay Productos guardado", "Error", "error");
                HayErrores = true;
            }
            if (String.IsNullOrWhiteSpace(EntradaIdTextBox.Text))
            {
                Utils.ShowToastr(this, "Ingrese Id para guardar", "Error", "error");
                HayErrores = true;
            }
            return HayErrores;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            EntradasBLL repositorio = new EntradasBLL();

            var entrada = repositorio.Buscar(Utils.ToInt(EntradaIdTextBox.Text));
            if (entrada != null)
            {
                Campos(entrada);
                Utils.ShowToastr(this, "Encontrado", "Exito", "success");
            }
            else
            {
                Limpiar();
                Utils.ShowToastr(this, "No Encontrado", "Error", "error");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            EntradasBLL repositorio = new EntradasBLL();
            Entradas entrada = new Entradas();

            if (Validar())
            {
                return;
            }
            else
            {
                entrada = LlenaClase();

                if (EntradaIdTextBox.Text == "0")
                {
                    paso = repositorio.Guardar(entrada);
                    Utils.ShowToastr(this, "Guardado", "Exito", "success");
                    Limpiar();
                }
                else
                {
                    EntradasBLL repository = new EntradasBLL();
                    int id = Utils.ToInt(EntradaIdTextBox.Text);
                    entrada = repository.Buscar(id);

                    if (entrada != null)
                    {
                        paso = repository.Modificar(LlenaClase());
                        Utils.ShowToastr(this, "Modificado", "Exito", "success");
                    }
                    else
                        Utils.ShowToastr(this, "Id no existe", "Error", "error");
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
            EntradasBLL repositorio = new EntradasBLL();
            int id = Utils.ToInt(EntradaIdTextBox.Text);

            var entrada = repositorio.Buscar(id);

            if (entrada != null)
            {
                if (repositorio.Eliminar(id))
                {
                    Utils.ShowToastr(this, "Eliminado", "Exito", "success");
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