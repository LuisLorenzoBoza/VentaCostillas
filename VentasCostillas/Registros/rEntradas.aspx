<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rEntradas.aspx.cs" Inherits="VentasCostillas.Registros.rEntradas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr>
    <h3 align="center" style="font-weight: bold">Registro de Entradas</h3>
    <hr>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label3" runat="server" text="EntradaId"></asp:label>
                <asp:button class="btn btn-outline-info btn-md" id="BuscarButton" runat="server" text="Buscar" OnClick="BuscarButton_Click"/>
                <asp:textbox class="form-control" type="number" id="EntradaIdTextBox" text="0" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label10" runat="server" text="Fecha"></asp:label>
                <asp:textbox class="form-control" ReadOnly="true" id="fechaTextBox" type="date" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-3 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label7" runat="server" text="Producto"></asp:label>
                <asp:dropdownlist class="form-control" id="productoDropDownList" runat="server"></asp:dropdownlist>
            </div>
        </div>
    </div>
    <div class="col-md-3 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label4" runat="server" text="Cantidad"></asp:label>
                <asp:textbox class="form-control" id="cantidadTextBox" placeholder="0" type="number" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button class="btn btn-outline-primary btn-md" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click"/>
                <asp:Button class="btn btn-outline-success btn-md" ID="guardarButton" runat="server" Text="Guardar" OnClick="guardarButton_Click"/>
                <asp:Button class="btn btn-outline-danger btn-md" ID="eliminarutton" runat="server" Text="Eliminar" OnClick="eliminarutton_Click"/>
            </div>
        </div>
    </div>
    <hr>
</asp:Content>
