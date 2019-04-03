<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="VentasCostillas.Registros.rVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                <asp:Button class="btn btn-outline-info btn-md" ID="BuscarButton" runat="server" Text="Buscar"/>
                <asp:TextBox class="form-control" ID="egresoIdTextBox" Text="0" runat="server"></asp:TextBox>
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
                <asp:Label ID="Label7" runat="server" Text="Usuario"></asp:Label>
                <asp:DropDownList class="form-control" ID="UsuarioDropDownList" runat="server">
                </asp:DropDownList>
            </div>
        </div>
    </div>    
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label5" runat="server"Text="Producto"></asp:Label>
                <asp:DropDownList class="form-control" ID="ProductoDropDownList" runat="server">
                </asp:DropDownList>
                <asp:Button class="btn btn-outline-warning btn-md" ID="agregarButton" runat="server" Text="Agregar"/>  
            </div>
        </div>
    </div>
    <asp:GridView ID="DetalleGridView" runat="server" class="table table-condensed table-bordered table-responsive" AutoGenerateColumns="False" CellPadding="4" ForeColor="#0066FF" GridLines="None">
        <AlternatingRowStyle BackColor="#999999" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="RemoverButton" runat="server" CausesValidation="False" CommandName="Select" Text="Remover"></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#003366" Font-Bold="True" />
    </asp:GridView>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Total"></asp:Label>
                <asp:TextBox class="form-control" ID="totalTextBox" ReadOnly="true" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>    
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Efectivo"></asp:Label>
                <asp:TextBox class="form-control" ID="EfectivoTextBox" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>    
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Devuelta"></asp:Label>
                <asp:TextBox class="form-control" ID="DevueltaTextBox" ReadOnly="true" Text="0" runat="server"></asp:TextBox>
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
