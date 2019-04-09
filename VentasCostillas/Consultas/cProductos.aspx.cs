using BLL;
using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VentasCostillas.Utilitarios;

namespace VentasCostillas.Consultas
{
    public partial class cProductos : System.Web.UI.Page
    {
        DateTime desde;
        DateTime hasta;
        Expression<Func<Productos, bool>> filtrar = f => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                ProductosReportViewer.ProcessingMode = ProcessingMode.Local;
                ProductosReportViewer.Reset();
                ProductosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListProductos.rdlc");
                ProductosReportViewer.LocalReport.DataSources.Clear();
                ProductosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Productos", Funciones.Productos(filtrar)));
                ProductosReportViewer.LocalReport.Refresh();
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
            Expression<Func<Productos, bool>> filtro = p => true;
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>();
            List<Productos> list = new List<Productos>();
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            switch (index)
            {
                case 0:
                    break;

                case 1:
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2:
                    filtro = p => p.Descripcion.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            ProductoGridView.DataSource = list;
            ProductoGridView.DataBind();
        }
    }
}