<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="VentasCostillas.Registros.rProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="UsuarioId"></asp:Label>
                <asp:Button class="btn btn-outline-info btn-md" ID="BuscarButton" runat="server" Text="Buscar" />
                <asp:TextBox class="form-control" ID="productoIdTextBox" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                <asp:TextBox class="form-control" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox class="form-control" ID="DescripcionTextBox" placeholder="Descripcion" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox class="form-control" ID="CantidadTextBox" text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Total Vendido"></asp:Label>
                <asp:TextBox class="form-control" ID="totalTextBox" text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button class="btn btn-outline-primary btn-md" ID="nuevoButton" runat="server" Text="Nuevo" />
                <asp:Button class="btn btn-outline-success btn-md" ID="guardarButton" runat="server" Text="Guardar" />
                <asp:Button class="btn btn-outline-danger btn-md" ID="eliminarutton" runat="server" Text="Eliminar" />
            </div>
        </div>
    </div>
</asp:Content>
