<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebReportes.aspx.cs" Inherits="ObligatorioP2.WebReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div>
            <h1 class="titulo">Pagina de Reportes</h1>
        </div>
        <%-- VA A AGARRAR LAS ORDENES DEL TECNICO Y VA A MOSTRAR CUANTAS TIENE EN COMPLETADO, EN PROGRESO Y PENDIENTE --%>

        <asp:GridView ID="TablaReportes" runat="server" AutoGenerateColumns="False" CssClass="table-custom">
            
            <asp:BoundField DataField="Pendiente" HeaderText="Pendiente" SortExpression="Pendiente" />
            <asp:BoundField DataField="EnProgreso" HeaderText="En Progreso" SortExpression="EnProgreso" />
            <asp:BoundField DataField="Completado" HeaderText="Completado" SortExpression="Completado" />
        </asp:GridView>




















    </main>
</asp:Content>
