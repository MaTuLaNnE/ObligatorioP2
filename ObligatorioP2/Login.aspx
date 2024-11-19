<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ObligatorioP2.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-group">
            <h1 id="titulo" runat="server" class="titulo">inicio de sesion</h1>
        </div>
        <div class="form-group">
            <asp:Label ID="lblCI" runat="server" Text="Cedula de Tecnico: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtCI" runat="server" CssClass="input-custom"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvCI" ControlToValidate="txtCI" ForeColor="Red" Text="Ingrese su Documento"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblClave" runat="server" Text="Clave de acceso: " CssClass="label-custom"></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" type="password" CssClass="input-custom"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="rfvClave" ControlToValidate="txtClave" ForeColor="Red" Text="Debe ingresar una clave para acceder"></asp:RequiredFieldValidator>
        </div>
     

        <div class="form-group">
            <asp:Label ID="lblError" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Button ID="btnLogIn" runat="server" Text="Iniciar Sesion" CssClass="btn-primary" Width="151px" OnClick="CmdLogIn" />

        </div>
    </form>
</body>
</html>
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

    .textarea {
        width: 200px;
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
