<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebTecnicos.aspx.cs" Inherits="ObligatorioP2.WebTecnicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1 id="titulo" runat="server" class="titulo">Creación de Técnicos</h1>

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
        <asp:Label ID="lblEspecialidad" runat="server" Text="Especialidad: " CssClass="label-custom"></asp:Label>
        <asp:DropDownList ID="ddlTipoServicio" runat="server" CssClass="dropdown-custom">
            <asp:ListItem runat="server" Enabled="true" Text="Seleccione un Servicio" Value=""></asp:ListItem>
            <asp:ListItem Value="Montaje">Montaje</asp:ListItem>
            <asp:ListItem Value="Sistemas">Sistemas</asp:ListItem>
            <asp:ListItem Value="Reparacion">Reparación</asp:ListItem>
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Button ID="btnCrearTecnico" runat="server" Text="Crear Técnico" CssClass="btn-primary" OnClick="CmdCrear" />
        <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" Visible="false" OnClick="BtnActualizar_Click" CssClass="btn-secondary" />
    </div>

    <div class="form-group">
        <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
    </div>

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
            text-align: left;
        }

            .table-custom th, .table-custom td {
                padding: 10px;
                border-bottom: 1px solid #ddd;
            }

            .table-custom th {
                background-color: #f2f2f2;
                font-weight: bold;
            }
    </style>
</asp:Content>
