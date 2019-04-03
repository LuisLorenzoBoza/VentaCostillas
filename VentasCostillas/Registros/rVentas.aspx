<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="VentasCostillas.Registros.rVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br>
    <h3 align="center" style="font-weight: bold">Registro de Ventas</h3>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Id"></asp:Label>
                <asp:Button class="btn btn-outline-info btn-md" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click"/>
                <asp:TextBox class="form-control" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Fecha"></asp:Label>
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
                <asp:Label ID="Label5" runat="server" Text="Producto"></asp:Label>
                <asp:DropDownList class="form-control" ID="ProductoDropDownList" runat="server" OnSelectedIndexChanged="ProductoDropDownList_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label8" runat="server" Text="Cantidad"></asp:Label>
                <asp:TextBox class="form-control" ID="CantidadTextBox" AutoPostBack="true" Text="0" runat="server" OnTextChanged="CantidadTextBox_TextChanged"></asp:TextBox>
            </div>
        </div>
    </div>    
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label9" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox class="form-control" ID="PrecioTextBox" AutoPostBack="true" ReadOnly="true" Text="0" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>    
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:Label ID="Label10" runat="server" Text="Importe"></asp:Label>
                <asp:TextBox class="form-control" ID="ImporteTextBox" AutoPostBack="true" ReadOnly="true" Text="0" runat="server"></asp:TextBox>
                <asp:Button class="btn btn-outline-info btn-md" ID="agregarButton" runat="server" Text="Agregar" OnClick="agregarButton_Click"/>  
            </div>
        </div>
    </div>
    <asp:GridView ID="DetalleGridView" runat="server" class="table table-condensed table-bordered table-responsive" 
        CellPadding="6" PageSize="7" ForeColor="#0066FF" GridLines="None" OnRowCommand="DetalleGridView_RowCommand" OnPageIndexChanging="DetalleGridView_PageIndexChanging">
        <AlternatingRowStyle BackColor="#999999" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="RemoverButton" class="btn btn-outline-danger btn-sm" runat="server" 
                        CausesValidation="False" CommandName="Select" CommandArgument="<%#((GridViewRow) Container).DataItemIndex %>" Text="Remover"></asp:Button>
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
                <asp:TextBox class="form-control" ID="EfectivoTextBox" AutoPostBack="true" Text="0" runat="server" OnTextChanged="EfectivoTextBox_TextChanged"></asp:TextBox>
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
                <asp:Button class="btn btn-outline-primary btn-md" ID="nuevoButton" runat="server" Text="Nuevo" OnClick="nuevoButton_Click" />
                <asp:Button class="btn btn-outline-success btn-md" ID="guardarButton" runat="server" Text="Guardar" OnClick="guardarButton_Click" />
                <asp:Button class="btn btn-outline-danger btn-md" ID="eliminarutton" runat="server" Text="Eliminar" OnClick="eliminarutton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
