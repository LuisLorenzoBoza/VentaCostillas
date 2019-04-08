using Entities;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VentasCostillas.Reportes
{
    public partial class ReporteUsuarios : System.Web.UI.Page
    {
        Expression<Func<Usuarios, bool>> filtro = p => true;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                UsuariosReportViewer.ProcessingMode = ProcessingMode.Local;
                UsuariosReportViewer.Reset();
                UsuariosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListUsuarios.rdlc");
                UsuariosReportViewer.LocalReport.DataSources.Clear();
                UsuariosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", BLL.Funciones.FUsuarios(filtro)));
                UsuariosReportViewer.LocalReport.Refresh();
            }
        }
    }
}