<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebOrdenes.aspx.cs" Inherits="ObligatorioP2.WebOrdenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="titulo" runat="server" class="titulo">Creación y Modificación de Órdenes</h1>

    <main>
        <!-- Creación/modificación de ordenes-->
        <div class="form-container">
            <div class="form-group">
                <asp:Label ID="lblNombreCliente" runat="server" Text="Nombre del Cliente: " CssClass="label-custom"></asp:Label>
                <asp:DropDownList ID="DDClientes" runat="server" CssClass="dropdown-custom">
                    <asp:ListItem ID="ListItem1" runat="server" Enabled="true" Text="Seleccione un Cliente" Value="-1"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblNombreTecnico" runat="server" Visible="false" Text="Nombre del Técnico: " CssClass="label-custom"></asp:Label>
                <asp:DropDownList ID="DDTecnicos" runat="server" Visible="false" CssClass="dropdown-custom">
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Label ID="lblTipoServicio" runat="server" Text="Servicio Deseado: " CssClass="label-custom"></asp:Label>
                <asp:DropDownList ID="ddlTipoServicio" runat="server" CssClass="dropdown-custom">
                    <asp:ListItem ID="mostradoPrimero" runat="server" Enabled="true" Text="Seleccione un Servicio" Value=""></asp:ListItem>
                    <asp:ListItem Value="General">General</asp:ListItem>
                    <asp:ListItem Value="Montaje">Montaje</asp:ListItem>
                    <asp:ListItem Value="Sistemas">Sistemas</asp:ListItem>
                    <asp:ListItem Value="Reparacion">Reparación</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="ddlTipoServicio" ForeColor="Red" Text="El tipo de servicio es requerido"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="lblDesc" runat="server" Text="Descripción: " CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Columns="20" Rows="2" Width="200px" CssClass="textarea"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvDesc" ControlToValidate="txtDesc" ForeColor="Red" Text="La descripción es requerida"></asp:RequiredFieldValidator>
            </div>

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


            <div class="form-actions">
                <asp:Button ID="btnCrearOrden" runat="server" Text="Crear Orden" CssClass="btn-primary" Width="151px" OnClick="CmdCrearOrden" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" Visible="false" OnClick="BtnActualizar_Click" CssClass="btn-secondary" />
            </div>

            <div class="form-group">

                <asp:Label ID="lblCreadoCorrectamente" runat="server" Visible="false" ForeColor="Green" CssClass="message-confirmation"></asp:Label>
                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red" CssClass="message-error"></asp:Label>
                <asp:Label ID="lblConfirmacion" runat="server" Visible="false" ForeColor="Green" CssClass="message-confirmation"></asp:Label>

            </div>

        </div>

        <asp:GridView ID="TablaOrdenes" runat="server" AutoGenerateColumns="False" CssClass="table-custom" OnRowDeleting="TeBorroALaMierda" OnRowCommand="TablaOrdenes_RowCommand">
            <Columns>
                <asp:BoundField DataField="NroOrden" HeaderText="Número de Orden" SortExpression="NroOrden" />
                <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" SortExpression="NombreCliente" />
                <asp:BoundField DataField="NombreTecnico" HeaderText="Técnico" SortExpression="NombreTecnico" />
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

    </main>

    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f9f9f9;
            color: #333;
        }

        .titulo {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            margin-bottom: 25px;
            color: #007bff;
        }

        .form-container {
            background-color: #fff;
            padding: 25px;
            margin: 0 auto;
            border-radius: 10px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            width: 60%;
            margin-top: 30px;
        }

        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }

        .dropdown-custom {
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
            width: 100%;
            transition: border-color 0.3s;
        }

        .label-custom {
            font-size: 16px;
            font-weight: bold;
            color: #333;
            margin-bottom: 5px;
        }

        .input-custom {
            width: 100%;
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
            margin-left: 10px;
            margin-right: 10px;
            transition: border-color 0.3s;
        }

        .input-custom,
        .dropdown-custom {
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
            width: 100%;
            transition: border-color 0.3s;
        }

            .input-custom:focus,
            .dropdown-custom:focus {
                border-color: #007bff;
                outline: none;
            }

        .textarea {
            width: 100%;
        }

        .form-actions {
            text-align: center;
        }

        .btn-primary,
        .btn-secondary,
        .btn-danger {
            padding: 10px 20px;
            border: none;
            color: #fff;
            cursor: pointer;
            border-radius: 5px;
            width: 100%;
        }

        .btn-primary {
            background-color: #007bff;
        }

        .btn-secondary {
            background-color: #28a745;
        }

        .btn-danger {
            background-color: #dc3545;
        }

        .btn-primary:hover {
            background-color: #0056b3;
        }

        .btn-secondary:hover {
            background-color: #218838;
        }

        .btn-danger:hover {
            background-color: #c82333;
        }

        .table-custom {
            width: 100%;
            margin-top: 20px;
            border-collapse: collapse;
            text-align: center;
            border: 1px solid #ddd;
        }

            .table-custom th,
            .table-custom td {
                padding: 10px;
                border-bottom: 1px solid #ddd;
            }

            .table-custom th {
                background-color: #ddd;
                font-weight: bold;
            }

        .message-error {
            text-align: center;
            font-weight: bold;
            color: red;
        }

        .message-confirmation {
            text-align: center;
            font-weight: bold;
            color: green;
        }
    </style>
</asp:Content>
