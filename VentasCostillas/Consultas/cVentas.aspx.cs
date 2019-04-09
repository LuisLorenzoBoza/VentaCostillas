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

namespace VentasCostillas.Consultas
{
    public partial class cVentas : System.Web.UI.Page
    {
        DateTime desde;
        DateTime hasta;
        Expression<Func<Ventas, bool>> filtrar = f => true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                VentasReportViewer.ProcessingMode = ProcessingMode.Local;
                VentasReportViewer.Reset();
                VentasReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListVentas.rdlc");
                VentasReportViewer.LocalReport.DataSources.Clear();
                VentasReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Ventas", Funciones.Ventas(filtrar)));
                VentasReportViewer.LocalReport.Refresh();
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
            Expression<Func<Ventas, bool>> filtro = p => true;
            RepositorioBase<Ventas> repositorio = new RepositorioBase<Ventas>();
            List<Ventas> list = new List<Ventas>();
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            switch (index)
            {
                case 0:
                    break;

                case 1:
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2:
                    filtro = p => p.VentaId.Equals(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;
            }

            list = repositorio.GetList(filtro);

            ProductoGridView.DataSource = list;
            ProductoGridView.DataBind();
        }
    }
}