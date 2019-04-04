<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rEntradas.aspx.cs" Inherits="VentasCostillas.Registros.rEntradas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label3" runat="server" text="EntradaId"></asp:label>
                <asp:button class="btn btn-outline-info btn-md" id="BuscarButton" runat="server" text="Buscar"/>
                <asp:textbox class="form-control" id="EntradaIdTextBox" text="0" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-3 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label10" runat="server" text="Fecha"></asp:label>
                <asp:textbox class="form-control" id="fechaTextBox" type="date" runat="server"></asp:textbox>
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
                <asp:Button class="btn btn-outline-primary btn-md" ID="nuevoButton" runat="server" Text="Nuevo"/>
                <asp:Button class="btn btn-outline-success btn-md" ID="guardarButton" runat="server" Text="Guardar"/>
                <asp:Button class="btn btn-outline-danger btn-md" ID="eliminarutton" runat="server" Text="Eliminar"/>
            </div>
        </div>
    </div>
</asp:Content>
