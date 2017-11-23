<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/WebPage.Master" AutoEventWireup="true" CodeBehind="ActualizarPersonal.aspx.cs" Inherits="WebASPNET.Vistas.GestionarPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <center>
        <h1>Gestionar Personal</h1>
        <br />
                <table>
                    <tr>
                        <td>Seleccione Personal</td>
                        <td><asp:DropDownList ID="ddl_personal" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddl_personal_SelectedIndexChanged"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Nombre</td>
                        <td><asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox></td>
                        <td>Apellido</td>
                        <td><asp:TextBox ID="txt_apellido" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Local</td>
                        <td><asp:DropDownList ID="ddl_local" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btn_despedir" runat="server" Text="Despedir" OnClick="btn_despedir_Click"></asp:Button></td>
                        <td><asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click"></asp:Button></td>
                        <td><asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
    </center>
</asp:Content>
