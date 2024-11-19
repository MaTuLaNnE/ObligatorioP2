<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="WebClientes.aspx.cs" Inherits="ObligatorioP2.WebClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h1 class="titulo">Creación de Cliente</h1>
        </div>

        <div class="form-container">

            <div class="form-group">
                <asp:Label ID="Label" runat="server" Text="Nombre: " CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="input-custom"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre" ForeColor="Red" Text="El nombre es requerido"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Apellido: " CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="input-custom"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvApellido" ControlToValidate="txtApellido" ForeColor="Red" Text="El Apellido es requerido"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="CI:" CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtCI" runat="server" CssClass="input-custom"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfcCI" ControlToValidate="txtCI" ForeColor="Red" Text="La Cedula de Identidad es requerida"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Dirección: " CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="input-custom"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="Teléfono: " CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtTelefono" runat="server" TextMode="Number" CssClass="input-custom"></asp:TextBox>
            </div>

            <div class="form-group">
                <asp:Label ID="Label6" runat="server" Text="Email: " CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="input-custom"></asp:TextBox>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear Usuario" CssClass="btn-primary" Width="151px" OnClick="CmdCrear" />
                <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" Visible="false" OnClick="BtnActualizar_Click" CssClass="btn-secondary" />
            </div>
        </div>

        <div class="feedback">
            <asp:Label ID="lblCreadoCorrectamente" runat="server" Visible="false" ForeColor="Green"></asp:Label>
            <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
        </div>

        <asp:GridView ID="TablaClientes1" runat="server" AutoGenerateColumns="False" CssClass="table-custom" OnRowDeleting="TeBorroALaMierda" OnRowCommand="TablaClientes1_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
                <asp:BoundField DataField="CI" HeaderText="CI" SortExpression="CI" />
                <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion" />
                <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" Text="Editar" CausesValidation="false" CssClass="btn-secondary" />
                        <asp:Button ID="btnCancel" runat="server" CommandName="CancelEdit" Visible="false" CommandArgument="<%# Container.DataItemIndex %>" Text="Cancelar" CausesValidation="false" CssClass="btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn-danger" ShowDeleteButton="true" DeleteText="Eliminar" />
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
            color: #007bff;
            margin-bottom: 25px;
        }

        .form-container {
            background-color: #fff;
            padding: 25px;
            margin: 0 auto;
            border-radius: 10px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            width: 50%;
            margin-top: 30px;
        }

        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }

        .label-custom {
            width: 120px;
            font-size: 16px;
            font-weight: bold;
            color: #333;
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

            .input-custom:focus {
                border-color: #007bff;
                outline: none;
            }

        .form-actions {
            text-align: center;
            margin-top: 20px;
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
                background-color: #878787;
                font-weight: bold;
            }


        .feedback {
            text-align: center;
            margin-top: 20px;
        }

            .feedback label {
                font-size: 16px;
                font-weight: bold;
            }

            .feedback .green {
                color: green;
            }

            .feedback .red {
                color: red;
            }
    </style>
</asp:Content>
