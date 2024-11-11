<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebClientes.aspx.cs" Inherits="ObligatorioP2.WebClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h1 class="titulo">Creación de Cliente</h1>
        </div>

        <br />

        <div class="form-group">
            <asp:Label ID="Label" runat="server" Text="Nombre: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input-custom"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre" ForeColor="Red" Text="El nombre es requerido"></asp:RequiredFieldValidator>
        </div>

        <br />

        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="Apellido: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="input-custom"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvApellido" ControlToValidate="txtApellido" ForeColor="Red" Text="El Apellido es requerido"></asp:RequiredFieldValidator>
        </div>

        <br />

        <div class="form-group">
            <asp:Label ID="Label3" runat="server" Text="CI:" CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtCI" runat="server" CssClass="input-custom"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfcCI" ControlToValidate="txtCI" ForeColor="Red" Text="La Cedula de Identidad es requerida"></asp:RequiredFieldValidator>
        </div>

        <br />

        <div class="form-group">
            <asp:Label ID="Label4" runat="server" Text="Dirección: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="input-custom"></asp:TextBox>
        </div>

        <br />

        <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Teléfono: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtTelefono" runat="server" TextMode="Number" CssClass="input-custom"></asp:TextBox>
        </div>

        <br />

        <div class="form-group">
            <asp:Label ID="Label6" runat="server" Text="Email: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="input-custom"></asp:TextBox>
        </div>

        <br />

        <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
        <br />

        <div class="form-group">
            <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear Usuario" CssClass="btn-primary" Width="151px" OnClick="CmdCrear" />
        </div>
        <br />
        <br />

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
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Eliminar" />
            </Columns>
        </asp:GridView>

        <br />

        <div class="form-group">
            <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" Visible="false" OnClick="BtnActualizar_Click" CssClass="btn-secondary" />
        </div>

        <asp:Label ID="lblCreadoCorrectamente" runat="server" Visible="false" ForeColor="Green"></asp:Label>
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
            width: 100px;
            text-align: left;
            margin-right: 10px;
            font-weight: bold;
        }

        .input-custom {
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
            text-align: left;
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