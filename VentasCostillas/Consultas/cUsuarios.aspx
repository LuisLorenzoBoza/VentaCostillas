﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cUsuarios.aspx.cs" Inherits="VentasCostillas.Consultas.cUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 align="center" style="font-weight: bold">Consulta de Usuarios</h3>
    <div class="form-row">
        <div class="form-group col-md-2">
            <asp:Label Text="Filtro" class="text-success" runat="server" />
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem>Todo</asp:ListItem>
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>Nombre</asp:ListItem>
                <asp:ListItem>UsuarioId</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-3">
            <asp:Label ID="Label1" runat="server" class="text-success" Text="Criterio">Criterio</asp:Label>
            <asp:TextBox ID="CriterioTextBox" AutoCompleteType="Disabled" class="form-control input-group" runat="server"></asp:TextBox>
        </div>
        <div class="col-lg-1 p-0">
            <asp:LinkButton ID="buscarLinkButton" CssClass="btn btn-outline-primary mt-4" runat="server" OnClick="buscarLinkButton_Click">
                <span class="fas fa-search"></span>
                 Buscar
            </asp:LinkButton>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group col-md-2">
            <asp:Label Text="Desde" class="text-success" runat="server" />
            <asp:TextBox ID="DesdeTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
        <div class="form-group col-md-2">
            <asp:Label Text="Hasta" class="text-success" runat="server" />
            <asp:TextBox ID="HastaTextBox" class="form-control input-group" TextMode="Date" runat="server" />
        </div>
    </div>
    <div class="form-row justify-content-center">
        <asp:GridView ID="UsuarioGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#0066FF" GridLines="None">
            <AlternatingRowStyle BackColor="#999999" />
            <Columns>
                <asp:BoundField DataField="UsuarioId" HeaderText="UsuarioId" />
                <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="TotalVendido" HeaderText="Total Vendido" />
            </Columns>
            <HeaderStyle BackColor="003366" Font-Bold="True" />
        </asp:GridView>
    </div>    
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:LinkButton ID="ImprimirLinkButton" CssClass="btn btn-outline-info mt-4" runat="server" OnClick="ImprimirLinkButton_Click">
                            <span class="fas fa-print"></span>
                            Imprimir
                </asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
