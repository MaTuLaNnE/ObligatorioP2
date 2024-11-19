<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ObligatorioP2.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login - Iniciar Sesión</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1 id="titulo" runat="server" class="titulo">Inicio de Sesión</h1>

            <div class="form-group">
                <asp:Label ID="lblCI" runat="server" Text="Cédula de Técnico: " CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtCI" runat="server" CssClass="input-custom"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvCI" ControlToValidate="txtCI" ForeColor="Red" Text="Ingrese su documento"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="lblClave" runat="server" Text="Clave de acceso: " CssClass="label-custom"></asp:Label>
                <asp:TextBox ID="txtClave" runat="server" type="password" CssClass="input-custom"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvClave" ControlToValidate="txtClave" ForeColor="Red" Text="Debe ingresar una clave para acceder"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Label ID="lblError" runat="server" Visible="false" CssClass="error-message"></asp:Label>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnLogIn" runat="server" Text="Iniciar Sesión" CssClass="btn-primary" Width="151px" OnClick="CmdLogIn" />
            </div>
        </div>
    </form>
</body>
</html>

<style>

    body {
        font-family: 'Arial', sans-serif;
        background-color: #f9f9f9;
        color: #333;
        margin: 0;
        padding: 0;
    }

    .form-container {
        background-color: #fff;
        padding: 25px;
        margin: 0 auto;
        border-radius: 10px;
        box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        width: 400px;
        margin-top: 100px;
    }

    .titulo {
        text-align: center;
        font-size: 28px;
        font-weight: bold;
        color: #007bff;
        margin-bottom: 25px;
    }

    .form-group {
        display: flex;
        flex-direction: column;
        margin-bottom: 20px;
    }

    .label-custom {
        font-size: 16px;
        font-weight: bold;
        margin-bottom: 5px;
        color: #333;
    }

    .input-custom {
        padding: 10px;
        font-size: 16px;
        border: 1px solid #ccc;
        border-radius: 5px;
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

    .btn-primary {
        padding: 12px 20px;
        background-color: #007bff;
        border: none;
        color: white;
        font-size: 16px;
        cursor: pointer;
        border-radius: 5px;
        width: 100%;
    }

    .btn-primary:hover {
        background-color: #0056b3;
    }

    .error-message {
        color: red;
        font-weight: bold;
        text-align: center;
    }
</style>
