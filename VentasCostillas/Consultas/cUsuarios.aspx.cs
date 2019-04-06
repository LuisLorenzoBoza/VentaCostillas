using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VentasCostillas.Consultas
{
    public partial class cUsuarios : System.Web.UI.Page
    {
        DateTime desde;
        DateTime hasta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public static int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);

            return retorno;
        }

        protected void buscarLinkButton_Click(object sender, EventArgs e)
        {
            bool resultado = DateTime.TryParse(DesdeTextBox.Text, out DateTime date);
            if (resultado)
                desde = date;
            bool resultad = DateTime.TryParse(HastaTextBox.Text, out DateTime date1);
            if (resultad)
                hasta = date1;
            Expression<Func<Usuarios, bool>> filtro = p => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            List<Usuarios> list = new List<Usuarios>();
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            switch (index)
            {
                case 0:
                    break;

                case 1:
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2:
                    filtro = p => p.Nombres.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            UsuarioGridView.DataSource = list;
            UsuarioGridView.DataBind();
        }
    }
}