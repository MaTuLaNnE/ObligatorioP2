<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebTecnicos.aspx.cs" Inherits="ObligatorioP2.WebTecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="titulo" runat="server" class="titulo">Creación de Técnicos</h1>

    <!-- Formulario para la creación o actualización de técnico -->
    <div class="form-container">
        <div class="form-group">
            <asp:Label ID="lblNombre" runat="server" Text="Nombre: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input-custom"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre" ForeColor="Red" Text="El nombre es requerido"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblApellido" runat="server" Text="Apellido: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="input-custom"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvApellido" ControlToValidate="txtApellido" ForeColor="Red" Text="El Apellido es requerido"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblCI" runat="server" Text="CI: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtCI" runat="server" CssClass="input-custom"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfcCI" ControlToValidate="txtCI" ForeColor="Red" Text="La Cedula de Identidad es requerida"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblClave" runat="server" Text="Clave: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" CssClass="input-custom" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfcClave" ControlToValidate="txtClave" ForeColor="Red" Text="La Clave de acceso es requerida"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: " CssClass="label-custom"></asp:Label>
            <asp:DropDownList ID="ddlTipoServicio" runat="server" CssClass="dropdown-custom">
                <asp:ListItem runat="server" Enabled="true" Text="Seleccione una Especialidad" Value=""></asp:ListItem>
                <asp:ListItem Value="Montaje">Montaje</asp:ListItem>
                <asp:ListItem Value="Sistemas">Sistemas</asp:ListItem>
                <asp:ListItem Value="Reparacion">Reparación</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-actions">
            <asp:Button ID="btnCrearTecnico" runat="server" Text="Crear Técnico" CssClass="btn-primary" OnClick="CmdCrear" />
            <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" Visible="false" OnClick="BtnActualizar_Click" CssClass="btn-secondary" />
        </div>

        <!-- Mensajes de error o confirmación -->
        <div class="form-group">
            <asp:Label ID="lblError" runat="server" Visible="false" CssClass="message-error"></asp:Label>
        </div>
    </div>

    <!-- Tabla de técnicos -->
    <asp:GridView ID="TablaTecnico1" runat="server" AutoGenerateColumns="False" CssClass="table-custom" OnRowDeleting="TeBorroALaMierda" OnRowCommand="TablaTecnico1_RowCommand">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
            <asp:BoundField DataField="CI" HeaderText="CI" SortExpression="CI" />
            <asp:BoundField DataField="Especialidad" HeaderText="Especialidad" SortExpression="Especialidad" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" Text="Editar" CausesValidation="false" CssClass="btn-secondary" />
                    <asp:Button ID="btnCancel" runat="server" CommandName="CancelEdit" Visible="false" CommandArgument="<%# Container.DataItemIndex %>" Text="Cancelar" CausesValidation="false" CssClass="btn-danger" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn-danger" ShowDeleteButton="true" DeleteText="Eliminar" />
        </Columns>
    </asp:GridView>

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
            flex-direction: column;
            margin-bottom: 20px;
        }

        .label-custom {
            font-size: 16px;
            font-weight: bold;
            color: #333;
            margin-bottom: 5px;
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
            text-align: left;
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
    </style>
</asp:Content>
