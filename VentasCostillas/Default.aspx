<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VentasCostillas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="5"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="6"></li>
        </ol>
        <div class="carousel-inner">
            <div class="carousel-item active">
                <asp:image runat="server" imageurl="~/Resources/CostillasPapas.png"></asp:image>
            </div>
            <div class="carousel-item">
                <asp:image runat="server" imageurl="~/Resources/costilla-horno.jpg"></asp:image>
            </div>
            <div class="carousel-item">
                <asp:image runat="server" imageurl="~/Resources/PcJ_Buffet.jpg"></asp:image>
            </div>
            <div class="carousel-item">
                <asp:image runat="server" imageurl="~/Resources/costilla de cerdo con pimenton y miel 3.jpg"></asp:image>
            </div>
            <div class="carousel-item">
                <asp:image runat="server" imageurl="~/Resources/COSTILLAS DE CERDO EN SALSA.jpg"></asp:image>
            </div>
            <div class="carousel-item">
                <asp:image runat="server" imageurl="~/Resources/costilla-horno.jpg"></asp:image>
            </div>
            <div class="carousel-item">
                <asp:image runat="server" imageurl="~/Resources/PcJ_Buffet.jpg"></asp:image>
            </div>
        </div>
        <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
</asp:Content>
