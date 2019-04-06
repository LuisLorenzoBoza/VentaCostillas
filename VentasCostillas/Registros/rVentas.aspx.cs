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
    public partial class rVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                totalTextBox.Text = "0";
                LlenaCombo();
                ViewState["Detalle"] = new Ventas().Detalle;
            }
        }

        private void LlenaCombo()
        {
            RepositorioBase<Usuarios> repositoriu = new RepositorioBase<Usuarios>();
            RepositorioBase<Productos> repository = new RepositorioBase<Productos>();

            UsuarioDropDownList.DataSource = repositoriu.GetList(t => true);
            UsuarioDropDownList.DataValueField = "UsuarioId";
            UsuarioDropDownList.DataTextField = "Nombres";
            UsuarioDropDownList.DataBind();

            ProductoDropDownList.DataSource = repository.GetList(t => true);
            ProductoDropDownList.DataValueField = "ProductoId";
            ProductoDropDownList.DataTextField = "Descripcion";
            ProductoDropDownList.DataBind();
        }

        public Ventas LlenarClase()
        {
            Ventas venta = new Ventas();

            venta.VentaId = Utils.ToInt(IdTextBox.Text);
            venta.Fecha = DateTime.Now;
            venta.UsuarioId = Utils.ToIntObjetos(UsuarioDropDownList.SelectedValue);
            venta.TotalAPagar = Utils.ToDecimal(totalTextBox.Text);
            venta.Efectivo = Utils.ToDecimal(totalTextBox.Text);
            venta.Devuelta = Utils.ToDecimal(totalTextBox.Text);

            venta.Detalle = (List<VentasDetalle>)ViewState["Detalle"];

            return venta;
        }

        public List<VentasDetalle> Detalle(int id)
        {
            RepositorioBase<VentasDetalle> repositorio = new RepositorioBase<VentasDetalle>();
            List<VentasDetalle> list = new List<VentasDetalle>();
            list = repositorio.GetList(c => c.VentaId == id);

            return list;
        }

        public void LlenarCampos(Ventas venta)
        {
            List<VentasDetalle> detalles = Detalle(Utils.ToInt(IdTextBox.Text));
            ViewState["Detalle"] = detalles;
            UsuarioDropDownList.SelectedValue = venta.UsuarioId.ToString();
            DetalleGridView.DataSource = ViewState["Detalle"];
            DetalleGridView.DataBind();
            totalTextBox.Text = venta.TotalAPagar.ToString();
            EfectivoTextBox.Text = venta.Efectivo.ToString();
            DevueltaTextBox.Text = venta.Devuelta.ToString();
        }

        protected void Limpiar()
        {
            IdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            UsuarioDropDownList.SelectedIndex = 0;
            ProductoDropDownList.SelectedIndex = 0;
            CantidadTextBox.Text = "";
            PrecioTextBox.Text = "";
            ImporteTextBox.Text = "";
            totalTextBox.Text = "";
            EfectivoTextBox.Text = "";
            DevueltaTextBox.Text = "";
            DetalleGridView.DataSource = null;
            DetalleGridView.DataBind();
        }

        public bool Producto()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            Productos producto = new Productos();
            int id = Utils.ToIntObjetos(ProductoDropDownList.SelectedValue);
            int cant = 0;
            producto = repositorio.Buscar(id);
            cant = producto.Cantidad;
            bool paso = false;

            if (cant <= 0)
            {
                Utils.ShowToastr(this, "Producto agotado.", "Error", "error");
                paso = true;
            }

            return paso;
        }

        private bool Validar()
        {
            bool paso = false;

            if (DetalleGridView.Rows.Count == 0)
            {
                Utils.ShowToastr(this, "Debe agregar.", "Error", "error");
                paso = true;
            }
            if (Utils.ToIntObjetos(UsuarioDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "No hay Usuarios guardado.", "Error", "error");
                paso = true;
            }
            if (Utils.ToIntObjetos(ProductoDropDownList.SelectedValue) < 1)
            {
                Utils.ShowToastr(this, "No  hay Productos guardado.", "Error", "error");
                paso = true;
            }
            if (String.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                Utils.ShowToastr(this, "Debe tener un Id para guardar", "Error", "error");
                paso = true;
            }
            if (String.IsNullOrWhiteSpace(CantidadTextBox.Text))
            {
                Utils.ShowToastr(this, "Cantidad Incorrecta", "Error", "error");
                paso = true;
            }
            if (String.IsNullOrWhiteSpace(EfectivoTextBox.Text) || Utils.ToInt(EfectivoTextBox.Text) == 0)
            {
                Utils.ShowToastr(this, "Debe Pagar", "Error", "error");
                paso = true;
            }
            return paso;
        }

        private void Precio()
        {
            int id = Utils.ToInt(ProductoDropDownList.SelectedValue);
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            List<Productos> ListProductos = repositorio.GetList(c => c.ProductoId == id);
            foreach (var item in ListProductos)
            {
                PrecioTextBox.Text = item.Precio.ToString();
            }
        }

        private void Importe()
        {
            int cantidad = 0;
            decimal precio = 0;
            decimal importe = 0;
            cantidad = Utils.ToInt(CantidadTextBox.Text);
            precio = Utils.ToDecimal(PrecioTextBox.Text);
            importe = Convert.ToDecimal(cantidad) * precio;

            ImporteTextBox.Text = importe.ToString();
        }

        protected void ProductoDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Precio();
            ImporteTextBox.Text = "";
        }

        protected void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            PrecioTextBox.Text = "";
            Precio();
            Importe();
        }

        private void Total()
        {
            decimal total = 0;
            List<VentasDetalle> lista = (List<VentasDetalle>)ViewState["Detalle"];
            foreach (var item in lista)
            {
                total += item.Importe;
            }
            totalTextBox.Text = total.ToString();
        }

        protected void agregarButton_Click(object sender, EventArgs e)
        {
            List<VentasDetalle> detalles = new List<VentasDetalle>();
            if (IsValid)
            {
                RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
                Productos producto = new Productos();
                int id = Utils.ToIntObjetos(ProductoDropDownList.SelectedValue);
                string descripcion = string.Empty; ;
                producto = repositorio.Buscar(id);
                descripcion = producto.Descripcion;

                DateTime date = DateTime.Now.Date;
                int cantidad = Utils.ToInt(CantidadTextBox.Text);
                decimal precio = Utils.ToDecimal(PrecioTextBox.Text);
                decimal importe = Utils.ToDecimal(ImporteTextBox.Text);

                if (Producto())
                {
                    return;
                }

                Ventas venta = new Ventas();
                if (DetalleGridView.Rows.Count != 0)
                {
                    venta.Detalle = (List<VentasDetalle>)ViewState["Detalle"];
                }
                if (Utils.ToIntObjetos(UsuarioDropDownList.SelectedValue) < 1)
                {
                    Utils.ShowToastr(this, "No hay Usuarios guardado.", "Error", "error");
                    return;
                }
                if (Utils.ToIntObjetos(ProductoDropDownList.SelectedValue) < 1)
                {
                    Utils.ShowToastr(this, "No  hay Productos guardado.", "Error", "error");
                    return;
                }
                if (Utils.ToInt(IdTextBox.Text) == 0)
                {
                    VentasDetalle detalle = new VentasDetalle();
                    venta.Detalle.Add(new VentasDetalle(0, detalle.VentaId, Utils.ToInt(ProductoDropDownList.SelectedValue), descripcion, cantidad, precio, importe));
                }
                else
                {
                    VentasDetalle detalle = new VentasDetalle();
                    venta.Detalle.Add(new VentasDetalle(0, Utils.ToInt(IdTextBox.Text), Utils.ToInt(ProductoDropDownList.SelectedValue), descripcion, cantidad, precio, importe));
                }
                ViewState["Detalle"] = venta.Detalle;
                DetalleGridView.DataSource = ViewState["Detalle"];
                DetalleGridView.DataBind();
                Total();
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            VentasBLL repositorio = new VentasBLL();

            var venta = repositorio.Buscar(Utils.ToInt(IdTextBox.Text));
            
            if (venta != null)
            {
                Utils.ShowToastr(this, "Encontrado", "Exito", "success");
                LlenarCampos(venta);
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
            VentasBLL repositorio = new VentasBLL();
            Ventas venta = new Ventas();
            bool paso = false;

            if (Validar())
                return;
            else
            {
                //todo: validaciones adicionales
                venta = LlenarClase();

                if (Utils.ToInt(IdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(venta);
                    Utils.ShowToastr(this, "Guardado", "Correcto", "success");
                    Limpiar();
                }
                else
                {
                    Ventas vent = new Ventas();
                    int id = Utils.ToInt(IdTextBox.Text);
                    VentasBLL repository = new VentasBLL();
                    vent = repository.Buscar(id);

                    if (vent != null)
                    {
                        paso = repositorio.Modificar(LlenarClase());
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
            VentasBLL repositorio = new VentasBLL();
            int id = Utils.ToInt(IdTextBox.Text);

            var venta = repositorio.Buscar(id);

            if (venta != null)
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

        protected void DetalleGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                Expression<Func<Productos, bool>> filtro = x => true;
                RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
                var lista = repositorio.GetList(c => true);
                var combos = repositorio.Buscar(lista[index].ProductoId);
                ((List<VentasDetalle>)ViewState["Detalle"]).RemoveAt(index);
                DetalleGridView.DataSource = ViewState["Detalle"];
                DetalleGridView.DataBind();
            }
        }

        protected void DetalleGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DetalleGridView.DataSource = ViewState["Detalle"];
            DetalleGridView.PageIndex = e.NewPageIndex;
            DetalleGridView.DataBind();
        }

        protected void EfectivoTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal efectivo = Utils.ToDecimal(EfectivoTextBox.Text);
            decimal total = Utils.ToDecimal(totalTextBox.Text);

            decimal devuelta = efectivo - total;

            if (efectivo < total)
            {
                Utils.ShowToastr(this, "Efectivo no suficiente", "Error", "error");
                DevueltaTextBox.Text = "0";
                return;
            }
            else
                DevueltaTextBox.Text = devuelta.ToString();
        }
    }
}