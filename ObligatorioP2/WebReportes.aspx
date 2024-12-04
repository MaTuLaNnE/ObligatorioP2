<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebReportes.aspx.cs" Inherits="ObligatorioP2.WebReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div>
            <h1 class="titulo">Página de Reportes</h1>
        </div>

        <div class="form-container">
            <div class="form-group">
                <asp:Label ID="lblNombreTecnico" runat="server" Text="Nombre del Tecnico: " CssClass="label-custom"></asp:Label>
                <asp:DropDownList ID="DDTecnicos" runat="server" CssClass="dropdown-custom" AutoPostBack="true">
                    <asp:ListItem ID="ListItem1" runat="server" Enabled="true" Text="Seleccione un Tecnico" Value="-1"></asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <asp:Button runat="server" Text="Mostrar Reportes" CssClass="btn-primary" OnClick="Confirmar_Click" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblPendientes" CssClass="label-custom">Ordenes Pendientes: </asp:Label>
                <asp:Label runat="server" ID="lblCuantasPendientes" CssClass="value-custom"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblEnProgreso" CssClass="label-custom">Ordenes En Progreso: </asp:Label>
                <asp:Label runat="server" ID="lblCuantasEnProgreso" CssClass="value-custom"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblCompletadas" CssClass="label-custom">Ordenes Completadas: </asp:Label>
                <asp:Label runat="server" ID="lblCuantasCompletadas" CssClass="value-custom"></asp:Label>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblTotal" CssClass="label-custom">Ordenes Totales: </asp:Label>
                <asp:Label runat="server" ID="lblCuantasTotal" CssClass="value-custom"></asp:Label>
            </div>
        </div>
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

        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
            justify-content: center;
        }

        .label-custom {
            font-size: 16px;
            font-weight: bold;
            color: #333;
        }

        .value-custom {
            font-size: 16px;
            color: #28a745;
            font-weight: bold;
            margin-left: 10px;
        }

        /* Responsive layout */
        @media (max-width: 768px) {
            .form-container {
                width: 90%;
                padding: 15px;
            }

            .titulo {
                font-size: 24px;
            }
        }
    </style>

</asp:Content>
