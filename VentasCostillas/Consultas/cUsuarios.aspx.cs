﻿using BLL;
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
    public partial class cUsuarios : System.Web.UI.Page
    {
        DateTime desde;
        DateTime hasta;
        Expression<Func<Usuarios, bool>> filtrar = f => true;
        protected void Page_Load(object sender, EventArgs e)
        {           
            if (!Page.IsPostBack)
            {
                DesdeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
                HastaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");

                UsuariosReportViewer.ProcessingMode = ProcessingMode.Local;
                UsuariosReportViewer.Reset();
                UsuariosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListUsuarios.rdlc");
                UsuariosReportViewer.LocalReport.DataSources.Clear();
                UsuariosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", Funciones.Usuarios(filtrar)));
                UsuariosReportViewer.LocalReport.Refresh();
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
            RepositorioBase<Usuarios> repositorioBase = new RepositorioBase<Usuarios>();
            List<Usuarios> list = new List<Usuarios>();
            int index = ToInt(FiltroDropDownList.SelectedIndex);
            int id;
            switch (index)
            {
                case 0:
                    break;

                case 1://Fecha
                    filtro = p => p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 2://Nombres
                    filtro = p => p.Nombres.Contains(CriterioTextBox.Text) && p.Fecha >= desde && p.Fecha <= hasta;
                    break;

                case 3://ID
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = c => c.UsuarioId == id;
                    break;
            }

            list = repositorioBase.GetList(filtro);

            UsuarioGridView.DataSource = list;
            UsuarioGridView.DataBind();
        }

        protected void ImprimirLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Reportes/ReporteUsuarios.aspx");
        }
    }
}