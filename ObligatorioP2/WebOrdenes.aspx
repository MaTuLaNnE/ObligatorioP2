<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebOrdenes.aspx.cs" Inherits="ObligatorioP2.WebOrdenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="titulo" runat="server" class="titulo">Creación y Modificación de Ordenes</h1>
    <div>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
       
    </div>

    <main>
        <div class="form-group">
            <asp:Label ID="lblNombreCliente" runat="server" Text="Nombre del Cliente: " CssClass="label-custom"></asp:Label>
            <asp:DropDownList ID="DDClientes" runat="server" CssClass="dropdown-custom">
                <asp:ListItem ID="ListItem1" runat="server" Enabled="true" Text="Seleccione un Cliente" Value="-1"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblNombreTecnico" runat="server" Text="Nombre del Tecnico: " CssClass="label-custom"></asp:Label>
            <asp:DropDownList ID="DDTecnicos" runat="server" CssClass="dropdown-custom">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <asp:Label ID="lblTipoServicio" runat="server" Text="Servicio Deseado: " CssClass="label-custom"></asp:Label>
            <asp:DropDownList ID="ddlTipoServicio" runat="server" CssClass="dropdown-custom">
                <asp:ListItem ID="mostradoPrimero" runat="server" Enabled="true" Text="Seleccione un Servicio" Value=""></asp:ListItem>
                <asp:ListItem Value="General">General</asp:ListItem>
                <asp:ListItem Value="Montaje">Montaje</asp:ListItem>
                <asp:ListItem Value="Sistemas">Sistemas</asp:ListItem>
                <asp:ListItem Value="Reparacion">Reparacion</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddlTipoServicio" ForeColor="Red" Text="El tipo de servicio es requerido"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <asp:Label ID="lblDesc" runat="server" Text="Descripción: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Columns="20" Rows="2" Width="200px" CssClass="textarea"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvDesc" ControlToValidate="txtDesc" ForeColor="Red" Text="La descripción es requerida"></asp:RequiredFieldValidator>
        </div>
  <%--      <div class="form-group">

        </div>--%>

        <div class="form-group">
            <asp:Label ID="lblEstado" runat="server" Text="Estado de la Orden: " CssClass="label-custom" Visible="false"></asp:Label>
            <asp:DropDownList ID="DDEstado" runat="server" Visible="false" CssClass="dropdown-custom">
                <asp:ListItem ID="mostradoPrimero2" runat="server" Enabled="true" Text="Seleccione un Estado" Value=""></asp:ListItem>
                <asp:ListItem Value="PENDIENTE">Pendiente</asp:ListItem>
                <asp:ListItem Value="EN PROGRESO">En Progreso</asp:ListItem>
                <asp:ListItem Value="COMPLETADO">Completado</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <asp:Label ID="lblComentario" runat="server" CssClass="label-custom" Text="Agregar Comentario:"></asp:Label>
            <asp:TextBox ID="txtComentario" CssClass="input-custom" runat="server"></asp:TextBox>
        </div>

        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblConfirmacion" runat="server" Visible="false" ForeColor="Green"></asp:Label>
        <br />

        <div class="form-group">
            <asp:Button ID="btnCrearOrden" runat="server" Text="Crear Orden" CssClass="btn-primary" Width="151px" OnClick="CmdCrearOrden" />
            <asp:Button ID="btnAgregarComments" runat="server" Text="Agregar Comentario" CssClass="btn-secondary" Visible="false" OnClick="btnAgregarComments_Click" />
            <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" Visible="false" OnClick="BtnActualizar_Click" CssClass="btn-secondary" />
        </div>
        <div class="form-group">
            <asp:Label ID="lblCreadoCorrectamente" runat="server" Visible="false" ForeColor="Green"></asp:Label>
        </div>

        <asp:GridView ID="TablaOrdenes" runat="server" AutoGenerateColumns="False" CssClass="table-custom" OnRowDeleting="TeBorroALaMierda" OnRowCommand="TablaOrdenes_RowCommand">
            <Columns>
                <asp:BoundField DataField="NroOrden" HeaderText="Número de Orden" SortExpression="NroOrden" />
                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" SortExpression="NombreCliente" />
                <asp:BoundField DataField="NombreTecnico" HeaderText="Tecnico" SortExpression="NombreTecnico" />
                <asp:BoundField DataField="TipoDeServicio" HeaderText="Tipo de Servicio" SortExpression="Direccion" />
                <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de la Orden" SortExpression="FechaCreacion" />
                <asp:BoundField DataField="Estado" HeaderText="Progreso" SortExpression="Progreso" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" Text="Editar" CausesValidation="false" CssClass="btn-secondary" />
                        <asp:Button ID="btnCancel" runat="server" CommandName="CancelEdit" Visible="false" CommandArgument="<%# Container.DataItemIndex %>" Text="Cancelar" CausesValidation="false" CssClass="btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn-danger" ShowDeleteButton="true" DeleteText="Eliminar" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnMostrarComments" runat="server" CommandName="MostrarComments" CommandArgument="<%# Container.DataItemIndex %>" Text="Mostrar Comentarios" CausesValidation="false" CssClass="btn-secondary" />
                        <asp:Button ID="btnOcultarComments" runat="server" Visible="false" CommandName="OcultarComments" CommandArgument="<%# Container.DataItemIndex %>" Text="Ocultar Comentarios" CausesValidation="false" CssClass="btn-secondary" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="form-group">
            <asp:Label ID="ListComents" CssClass="label-custom" Visible="false" runat="server">Lista de Comentarios</asp:Label>

        </div>
        <div class="form-group">
            <asp:BulletedList ID="BLComentarios" runat="server">
            </asp:BulletedList>
            <asp:Label ID="Nocoments" CssClass="label-custom" Visible="false" runat="server">No se agregaron comentarios.</asp:Label>
        </div>

    </main>

    <style>
        .titulo {
            text-align: center;
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
            margin-top: 15px;
            display: flex;
            align-items: center;
        }

        .label-custom {
            width: 200px;
            text-align: left;
            margin-right: 10px;
            font-weight: bold;
        }

        .textarea{
            width:200px;
        }

        #MainContent_lblCIerror {
            justify-content: left;
        }

        .input-custom,
        .dropdown-custom {
            width: 200px;
            padding: 5px;
        }

        .btn-primary,
        .btn-secondary,
        .btn-danger {
            padding: 8px 15px;
            border: none;
            color: #fff;
            cursor: pointer;
        }

        .btn-primary {
            background-color: #007bff;
        }

        .btn-secondary {
            background-color: #007bff;
        }

        .btn-danger {
            background-color: #dc3545;
        }

        .table-custom {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
            text-align: center;
            border: solid black;
        }

            .table-custom th,
            .table-custom td {
                padding: 10px;
                border-bottom: 1px solid #ddd;
            }

            .table-custom th {
                background-color: #f2f2f2;
                font-weight: bold;
            }
    </style>
</asp:Content>
