<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebInicio.aspx.cs" Inherits="ObligatorioP2.WebInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
    <html>

    <body>

        <asp:Label ID="titulo" runat="server" class="titulo"></asp:Label>
        <div>
            <asp:Panel ID="ContenedorOrdenes" runat="server"></asp:Panel>
        </div>

    </body>
    </html>

    <style>
        .titulo {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            margin-bottom: 25px;
            color: #007bff;
        }

        .panel-orden {
            border: 1px solid #ccc;
            margin: 15px 0;
            padding: 15px;
            border-radius: 8px;
            box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.1);
        }

        .orden-info h3 {
            margin: 0 0 10px;
            font-size: 18px;
            color: #333;
        }

        .orden-info p {
            margin: 5px 0;
            font-size: 14px;
            color: #555;
        }

        .orden-info strong {
            color: #000;
        }
    </style>

</asp:Content>
