<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebBusquedaOrdenes.aspx.cs" Inherits="ObligatorioP2.WebBusquedaOrdenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1 id="titulo" runat="server" class="titulo">Búsqueda de Ordenes</h1>

    <div class="form-container">
        <div class="form-group">
            <asp:Label runat="server" ID="lblOrden" Text="Coloque el número de Orden: " CssClass="label-custom"></asp:Label>
            <asp:TextBox runat="server" ID="txtOrden" TextMode="Number" CssClass="input-custom"></asp:TextBox>
            <asp:Button runat="server" ID="btnBuscar" Text="Buscar Orden" OnClick="btnBuscar_Click" CssClass="btn-primary" />
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="lblCli" CssClass="label-custom">Nombre del Cliente: </asp:Label>
            <asp:Label runat="server" ID="lblInfoCliente" CssClass="label-custom"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblTec" CssClass="label-custom">Nombre del Tecnico: </asp:Label>
            <asp:Label runat="server" ID="lblInfoTecnico" CssClass="label-custom"></asp:Label>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="lblEst" CssClass="label-custom">Estado actual: </asp:Label>
            <asp:Label runat="server" ID="lblEstado" CssClass="label-custom"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label runat="server" ID="lblComentarios" CssClass="label-custom">Comentarios: </asp:Label>
        </div>
        <div class="form-group">
            <asp:BulletedList ID="BLComentarios" runat="server" CssClass="input-custom">
            </asp:BulletedList>
            <asp:Label ID="Nocoments" CssClass="label-custom" Visible="false" runat="server">No se agregaron comentarios.</asp:Label>
        </div>
    </div>


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

        .input-custom {
            padding: 10px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 5px;
            width: 100%;
            transition: border-color 0.3s;
        }

            .input-custom:focus {
                border-color: #007bff;
                outline: none;
            }

        .form-actions {
            text-align: center;
        }

        .btn-primary {
            padding: 10px 20px;
            border: none;
            color: #fff;
            cursor: pointer;
            border-radius: 5px;
            width: 100%;
            background-color: #007bff;
        }

            .btn-primary:hover {
                background-color: #0056b3;
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

        .COMPLETADO {
            color: green;
            font-weight: bold;
        }

        .ENPROGRESO {
            color: #e3a217;
            font-weight: bold;
        }

        .PENDIENTE {
            color: #a80000;
            font-weight: bold;
        }
    </style>

</asp:Content>

