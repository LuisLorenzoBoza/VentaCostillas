<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="VentasCostillas.Registros.rProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr>
    <h3 align="center" style="font-weight: bold">Registro de Productos</h3>
    <hr>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="ProductoId"></asp:Label>
                <asp:Button class="btn btn-outline-info btn-md" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                <asp:TextBox class="form-control" type="number" ID="productoIdTextBox" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label10" runat="server" Text="Fecha"></asp:Label>
                <asp:TextBox class="form-control" ReadOnly="true" ID="fechaTextBox" type="date" runat="server"></asp:TextBox>
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
                <asp:Label ID="Label5" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox class="form-control" ID="PrecioTextBox" text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox class="form-control" ID="CantidadTextBox" ReadOnly="true" text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button class="btn btn-outline-primary btn-md" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" />
                <asp:Button class="btn btn-outline-success btn-md" ID="guardarButton" runat="server" Text="Guardar" OnClick="guardarButton_Click" />
                <asp:Button class="btn btn-outline-danger btn-md" ID="eliminarutton" runat="server" Text="Eliminar" OnClick="eliminarutton_Click" />
            </div>
        </div>
    </div>
    <hr>
</asp:Content>
