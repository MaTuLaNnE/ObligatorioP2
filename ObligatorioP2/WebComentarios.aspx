<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebComentarios.aspx.cs" Inherits="ObligatorioP2.WebComentarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="form-container">
            <div class="form-actions-left">
                <asp:Button ID="BtnVolver" CausesValidation="false" runat="server"
                    Text="Volver"
                    CssClass="btn-back" Visible="true" OnClick="BtnVolver_Click" />
            </div>
            <div class="form-group">

                <asp:Label ID="lblComentario" runat="server" CssClass="label-custom" Text="Agregar Comentario:"></asp:Label>
                <asp:TextBox ID="txtComentario" CssClass="input-custom" runat="server"></asp:TextBox>

            </div>

            <div class="lbl-form">
                <asp:RequiredFieldValidator runat="server" ID="rfvComentario" ControlToValidate="txtComentario" ForeColor="Red" Text="Campo de comentario vacio"></asp:RequiredFieldValidator>
            </div>

            <div class="form-actions">
                <asp:Button ID="btnAgregarComments" runat="server" Text="Agregar Comentario" CssClass="btn-secondary" Visible="true" OnClick="btnAgregarComments_Click" />
            </div>

            <div class="form-group">

                <asp:Label ID="lblCreadoCorrectamente" runat="server" Visible="false" ForeColor="Green" CssClass="message-confirmation"></asp:Label>
                <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red" CssClass="message-error"></asp:Label>
                <asp:Label ID="lblConfirmacion" runat="server" Visible="false" ForeColor="Green" CssClass="message-confirmation"></asp:Label>
            </div>

            <div class="form-group">
                <asp:Label ID="ListComents" CssClass="label-custom" Visible="false" runat="server">Lista de Comentarios</asp:Label>
            </div>

            <div class="form-group">
                <asp:BulletedList ID="BLComentarios" runat="server">
                </asp:BulletedList>
                <asp:Label ID="Nocoments" CssClass="label-custom" Visible="false" runat="server">No se agregaron comentarios.</asp:Label>
            </div>

        </div>
    </main>

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

        .form-group {
            display: flex;
            align-items: center;
            margin-bottom: 20px;
        }


        .lbl-form {
            display: flex;
            align-items: initial;
            justify-content: center;
            margin-top: -20px;
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

        .message-confirmation {
            text-align: center;
            font-weight: bold;
            color: green;
        }

        .form-actions {
            text-align: center;
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

        .btn-secondary {
            background-color: #28a745;
        }



        .message-confirmation {
            text-align: center;
            font-weight: bold;
            color: green;
        }

        .form-actions-left {
            text-align: left; 
        }

        .btn-back {
            display: inline-flex;
            align-items: center;
            padding: 5px 15px;
            background-color: #dc3545; 
            color: #fff; 
            border: none;
            border-radius: 20px; 
            cursor: pointer;
            font-size: 14px; 
            width: auto; 
            text-align: center;
            box-shadow: 2px 2px 5px rgba(0, 0, 0, 0.1);
            margin-bottom:20px;
        }

            .btn-back:hover {
                background-color: #c82333;
            }
    </style>

</asp:Content>
