<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebNoAdmin.aspx.cs" Inherits="ObligatorioP2.WebNoAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Error de Confirmación de Datos de Login</title>
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f9f9f9;
            color: #333;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            text-align: center;
        }

        #error-container {
            background-color: #ffffff;
            padding: 40px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            max-width: 500px;
            width: 100%;
        }

        #titulo-error {
            background-color: #e74c3c;
            color: white;
            font-size: 24px;
            font-weight: bold;
            padding: 10px;
            border-radius: 4px;
            margin-bottom: 20px;
        }

        #subtitulo-error {
            font-size: 18px;
            margin-bottom: 20px;
        }

        .volver {
            display: inline-block;
            padding: 10px 20px;
            font-size: 16px;
            color: white;
            background-color: #3498db;
            text-decoration: none;
            border-radius: 4px;
            transition: background-color 0.3s ease;
        }

        .volver:hover {
            background-color: #2980b9;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="error-container">
            <div id="titulo-error">
                ERROR DE CONFIRMACIÓN DE DATOS DE LOGIN
            </div>
            <div id="subtitulo-error">
                Por favor, intente nuevamente hacer el login. Si el problema persiste, comuníquese con sistemas.
            </div>
            <a href="Login.aspx" class="volver">Volver a acceder a la página de Login</a>
        </div>
    </form>
</body>
</html>
