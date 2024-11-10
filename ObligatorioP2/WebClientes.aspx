<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebClientes.aspx.cs" Inherits="ObligatorioP2.WebClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <main>
      <div>
          <h1 class="titulo">Creacion de Cliente</h1>
      </div>
      
      <br />

      <asp:Label ID="Label" runat="server" Text="Nombre: " CssClass="label-custom"></asp:Label>
      <asp:TextBox ID="txtNombre" runat="server" CssClass="text-box"></asp:TextBox>
      <asp:RequiredFieldValidator runat="server" ID="rfvNombre" ControlToValidate="txtNombre" ForeColor="Red" Text="El nombre es requerido"></asp:RequiredFieldValidator>
      <br />

      <asp:Label ID="Label1" runat="server" Text="Apellido: " CssClass="label-custom"></asp:Label>
      <asp:TextBox ID="txtApellido" runat="server" CssClass="text-box"></asp:TextBox>
      <asp:RequiredFieldValidator runat="server" ID="rfvApellido" ControlToValidate="txtApellido" ForeColor="Red" Text="El Apellido es requerido"></asp:RequiredFieldValidator>
      <br />

      <asp:Label ID="Label3" runat="server" Text="CI:" CssClass="label-custom"></asp:Label>
      <asp:TextBox ID="txtCI" runat="server" CssClass="text-box"></asp:TextBox>
      <asp:RequiredFieldValidator runat="server" ID="rfcCI" ControlToValidate="txtCI" ForeColor="Red" Text="La Cedula de Identidad es requerida"></asp:RequiredFieldValidator>
      <br />

      <asp:Label ID="Label4" runat="server" Text="Direccion: " CssClass="label-custom"></asp:Label>
      <asp:TextBox ID="txtDireccion" runat="server" CssClass="text-box"></asp:TextBox>
      <br />

      <asp:Label ID="Label5" runat="server" Text="Telefono: " CssClass="label-custom"></asp:Label>
      <asp:TextBox ID="txtTelefono" runat="server" TextMode="Number" CssClass="text-box"></asp:TextBox>
      <br />

      <asp:Label ID="Label6" runat="server" Text="Email: " CssClass="label-custom"></asp:Label>
      <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="text-box"></asp:TextBox>
      <br />

      <asp:Label ID="lblError" runat="server" Visible="false" ForeColor="Red"></asp:Label>
      <br />

      <asp:Button ID="btnCrearUsuario" runat="server" Text="Crear Usuario" Width="151px" OnClick="CmdCrear" />
      <br />
      <br />

      <asp:GridView ID="TablaClientes1" runat="server" AutoGenerateColumns="False" OnRowDeleting="TeBorroALaMierda" OnRowCommand="TablaClientes1_RowCommand">
          <Columns>
              <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
              <asp:BoundField DataField="Apellido" HeaderText="Apellido" SortExpression="Apellido" />
              <asp:BoundField DataField="CI" HeaderText="CI" SortExpression="CI" />
              <asp:BoundField DataField="Direccion" HeaderText="Dirección" SortExpression="Direccion" />
              <asp:BoundField DataField="Telefono" HeaderText="Teléfono" SortExpression="Telefono" />
              <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="btnEditar" runat="server" CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" Text="Editar" CausesValidation="false" />
                  </ItemTemplate>
              </asp:TemplateField>
              <asp:CommandField ButtonType="Button" ShowDeleteButton="true" DeleteText="Eliminar" />
          </Columns>
      </asp:GridView>
      <br />
      <div>
          <asp:Button ID="BtnActualizar" runat="server" Text="Actualizar" Visible="false" OnClick="BtnActualizar_Click" />
      </div>
      <asp:Label ID="lblCreadoCorrectamente" runat="server" Visible="false" ForeColor="Green"></asp:Label>
  </main>
</asp:Content>
