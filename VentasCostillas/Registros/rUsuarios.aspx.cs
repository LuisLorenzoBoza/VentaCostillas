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
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                totalTextBox.Text = "0";
            }
        }

        private void Limpiar()
        {
            usuarioIdTextBox.Text = "0";
            fechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            nombreTextBox.Text = " ";
            emailTextBox.Text = "";
            ContraseñaTextBox.Text = "";
            ConfirmarTextBox.Text = "";
            totalTextBox.Text = "0";
        }

        private Usuarios LlenaClase()
        {
            Usuarios usuario = new Usuarios();

            usuario.UsuarioId = ToInt(usuarioIdTextBox.Text);
            bool resultado = DateTime.TryParse(fechaTextBox.Text, out DateTime fecha);
            usuario.Fecha = fecha;
            usuario.Nombres = nombreTextBox.Text;
            usuario.Email = emailTextBox.Text;
            usuario.Contraseña = ContraseñaTextBox.Text;
            usuario.TotalVendido = ToInt(totalTextBox.Text);

            return usuario;

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

            string s = ContraseñaTextBox.Text;
            string ss = ConfirmarTextBox.Text;
            int comparacion = 0;
            comparacion = String.Compare(s, ss);
            if (comparacion != 0)
            {
                Utils.ShowToastr(this, "Las Contraseñas no coinciden", "Error", "error");
                paso = true;
            }

            return paso;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = repositorio.Buscar(ToInt(usuarioIdTextBox.Text));
            if (usuario != null)
            {
                nombreTextBox.Text = usuario.Nombres;
                fechaTextBox.Text = usuario.Fecha.ToString("yyyy/MM/dd");
                emailTextBox.Text = usuario.Email;
                ContraseñaTextBox.Text = usuario.Contraseña;
                ConfirmarTextBox.Text = usuario.Contraseña;
                totalTextBox.Text = usuario.TotalVendido.ToString();
                Utils.ShowToastr(this, "Encontrado", "Correcto", "success");
            }
            else
            {
                Utils.ShowToastr(this, "No encontrado", "Error", "error");
            }
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            bool paso = false;

            if (Validar())
                return;
            else
            {
                //todo: validaciones adicionales
                usuario = LlenaClase();

                if (Utils.ToInt(usuarioIdTextBox.Text) == 0)
                {
                    paso = repositorio.Guardar(usuario);
                    Utils.ShowToastr(this, "Guardado", "Correcto", "success");
                    Limpiar();
                }
                else
                {
                    Usuarios user = new Usuarios();
                    int id = ToInt(usuarioIdTextBox.Text);
                    RepositorioBase<Usuarios> repository = new RepositorioBase<Usuarios>();
                    usuario = repository.Buscar(id);

                    if (user != null)
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

        protected void nuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void eliminarutton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new BLL.RepositorioBase<Usuarios>();
            int id = ToInt(usuarioIdTextBox.Text);

            var usuario = repositorio.Buscar(id);

            if (usuario != null)
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