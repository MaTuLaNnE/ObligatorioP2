<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebInicio.aspx.cs" Inherits="ObligatorioP2.WebInicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
    <html>

    <body>
        <div class="titulo">
            <asp:Label ID="titulo" runat="server"></asp:Label>
        </div>

        <div class="form-container">

            <div>
                <asp:Label ID="lblVacio" Visible="false" runat="server" class="label-custom"></asp:Label>
                <asp:Panel ID="ContenedorOrdenes" runat="server"></asp:Panel>
            </div>
        </div>
    </body>
    </html>

    <style>
        .form-container {
            background-color: #fff;
            padding: 25px;
            margin: 0 auto;
            border-radius: 10px;
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
            width: 50%;
            margin-top: 30px;
        }

        .titulo {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            margin-top: 25px;
            margin-bottom: 25px;
            color: #007bff;
            align-content: center;
        }

        .label-custom {
            font-size: 16px;
            font-weight: bold;
            color: #333;
            margin-bottom: 5px;
        }

        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
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
