<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="VentasCostillas.Registros.rUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr>
    <h3 align="center" style="font-weight: bold">Registro de Usuarios</h3>
    <hr>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="UsuarioId"></asp:Label>
                <asp:Button class="btn btn-outline-info btn-md" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                <asp:TextBox class="form-control" type="number" ID="usuarioIdTextBox" Text="0" runat="server"></asp:TextBox>
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
                <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox class="form-control" ID="nombreTextBox" placeholder="Nombre" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Email"></asp:Label>
                <asp:TextBox class="form-control" ID="emailTextBox"  runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label7" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox class="form-control" ID="ContraseñaTextBox" type="password" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Confirmar Contraseña"></asp:Label>
                <asp:TextBox class="form-control" ID="ConfirmarTextBox" type="password" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Total Vendido"></asp:Label>
                <asp:TextBox class="form-control" ID="totalTextBox" text="0" runat="server" ReadOnly="True"></asp:TextBox>
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
