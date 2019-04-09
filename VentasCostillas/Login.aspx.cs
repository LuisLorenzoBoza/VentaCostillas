using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using VentasCostillas.Utilitarios;

namespace VentasCostillas
{
    public partial class Login : System.Web.UI.Page
    {
        RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
        Expression<Func<Usuarios, bool>> filtrar = x => true;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();

            filtrar = t => t.Email.Equals(emailTextBox.Text) && t.Contraseña.Equals(passwordTextBox.Text);

            if (repositorio.GetList(filtrar).Count() != 0)
            {
                FormsAuthentication.RedirectFromLoginPage(usuario.Email, true);
                Utils.ShowToastr(this, "Bienvenido", "Sesióón Iniciada", "success");
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(Page), "toastr_message", script: "toastr['error'] ('Usuario o Contraseña Incorrecto');", addScriptTags: true);

        }
    }
}