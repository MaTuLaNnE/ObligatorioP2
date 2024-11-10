<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebOrdenes.aspx.cs" Inherits="ObligatorioP2.WebOrdenes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</div>

<main>
    <div>
        <asp:Label ID="lblNombreCliente" runat="server" Text="Nombre del Cliente: "></asp:Label>
        <asp:DropDownList ID="DDClientes" runat="server"></asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="lblNombreTecnico" runat="server" Text="Nombre del Tecnico: "></asp:Label>
        <asp:DropDownList ID="DDTecnicos" runat="server"></asp:DropDownList>

    </div>
    <div>
        <asp:Label ID="lblTipoServicio" runat="server" Text="Servicio Deseado: "></asp:Label>

        <%-- Hacer un dropdown --%>
        <asp:DropDownList ID="ddlTipoServicio" runat="server">
            <asp:ListItem ID="mostradoPrimero" runat="server" Enabled="true" Text="Seleccione un Servicio" Value=""></asp:ListItem>
            <asp:ListItem Value="Montaje">Montaje</asp:ListItem>
            <asp:ListItem Value="Sistemas">Sistemas</asp:ListItem>
            <asp:ListItem Value="Reparacion">Reparacion</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:Label ID="lblDesc" runat="server" Text="Descripción del problema: "></asp:Label>
    </div>
    <div>
        <asp:TextBox ID="TextArea1" runat="server" TextMode="MultiLine" Columns="20" Rows="2" Width="300px"></asp:TextBox>
        <asp:RequiredFieldValidator runat="server" ID="rfvDesc" ControlToValidate="TextArea1" ForeColor="Red" Text="La descripción es requerida"></asp:RequiredFieldValidator>

    </div>

    <div>
        <asp:Label ID="lblEstado" runat="server" Text="Estado de la Orden: "></asp:Label>
        <asp:DropDownList ID="DDEstado" runat="server">
            <asp:ListItem ID="mostradoPrimero2" runat="server" Enabled="true" Text="Seleccione un Estado" Value=""></asp:ListItem>
            <asp:ListItem Value="Pendiente">Pendiente</asp:ListItem>
            <asp:ListItem Value="Progeso">Progreso</asp:ListItem>
            <asp:ListItem Value="Completado">Completado</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:BulletedList ID="ListaComentarios" runat="server" OnClick="BulletedList1_Click"></asp:BulletedList>
    </div>

</main>
</asp:Content>
