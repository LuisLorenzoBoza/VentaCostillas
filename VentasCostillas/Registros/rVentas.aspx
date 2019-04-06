<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rVentas.aspx.cs" Inherits="VentasCostillas.Registros.rVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr>
    <h3 align="center" style="font-weight: bold">Registro de Ventas</h3>
    <hr>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label3" runat="server" text="Id"></asp:label>
                <asp:button class="btn btn-outline-info btn-md" id="BuscarButton" runat="server" text="Buscar" onclick="BuscarButton_Click" />
                <asp:textbox class="form-control" type="number" id="IdTextBox" text="0" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-2 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label6" runat="server" text="Fecha"></asp:label>
                <asp:textbox class="form-control" readonly="true" id="fechaTextBox" type="date" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label7" runat="server" text="Usuario"></asp:label>
                <asp:dropdownlist class="form-control" id="UsuarioDropDownList" runat="server">
                </asp:dropdownlist>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label5" runat="server" text="Producto"></asp:label>
                <asp:dropdownlist class="form-control" id="ProductoDropDownList" runat="server" onselectedindexchanged="ProductoDropDownList_SelectedIndexChanged">
                </asp:dropdownlist>
            </div>
        </div>
    </div>

    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label8" runat="server" text="Cantidad"></asp:label>
                <asp:textbox class="form-control" id="CantidadTextBox" autopostback="true" text="0" runat="server" ontextchanged="CantidadTextBox_TextChanged"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label9" runat="server" text="Precio"></asp:label>
                <asp:textbox class="form-control" id="PrecioTextBox" autopostback="true" readonly="true" text="0" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label10" runat="server" text="Importe"></asp:label>
                <asp:textbox class="form-control" id="ImporteTextBox" autopostback="true" readonly="true" text="0" runat="server"></asp:textbox>
                <asp:button class="btn btn-outline-info btn-md" id="agregarButton" runat="server" text="Agregar" onclick="agregarButton_Click" />
            </div>
        </div>
    </div>
    <hr>
    <asp:gridview id="DetalleGridView" runat="server" class="table table-condensed table-bordered table-responsive"
        cellpadding="6" pagesize="7" forecolor="#0066FF" gridlines="None" onrowcommand="DetalleGridView_RowCommand" onpageindexchanging="DetalleGridView_PageIndexChanging">
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
    </asp:gridview>
    <hr>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label1" runat="server" text="Total"></asp:label>
                <asp:textbox class="form-control" id="totalTextBox" readonly="true" text="0" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label2" runat="server" text="Efectivo"></asp:label>
                <asp:textbox class="form-control" id="EfectivoTextBox" autopostback="true" text="0" runat="server" ontextchanged="EfectivoTextBox_TextChanged"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="col-md-4 col-md-offset-3">
        <div class="container">
            <div class="form-group">
                <asp:label id="Label4" runat="server" text="Devuelta"></asp:label>
                <asp:textbox class="form-control" id="DevueltaTextBox" readonly="true" text="0" runat="server"></asp:textbox>
            </div>
        </div>
    </div>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:button class="btn btn-outline-primary btn-md" id="nuevoButton" runat="server" text="Nuevo" onclick="nuevoButton_Click" />
                <asp:button class="btn btn-outline-success btn-md" id="guardarButton" runat="server" text="Guardar" onclick="guardarButton_Click" />
                <asp:button class="btn btn-outline-danger btn-md" id="eliminarutton" runat="server" text="Eliminar" onclick="eliminarutton_Click" />
            </div>
        </div>
    </div>
    <hr>
</asp:Content>
