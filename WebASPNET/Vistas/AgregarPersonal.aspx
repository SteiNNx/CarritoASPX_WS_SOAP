<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/WebPage.Master" AutoEventWireup="true" CodeBehind="AgregarPersonal.aspx.cs" Inherits="WebASPNET.Vistas.AgregarPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h1>Gestionar Personal</h1>
        <br />
                <table>
                    <tr>
                        <td>Nombre</td>
                        <td><asp:TextBox  id="txt_nombre" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Apellido</td>
                        <td><asp:TextBox  id="txt_apellido" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Local</td>
                        <td><asp:DropDownList id="ddl_local" runat="server"></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td><asp:Button id="btn_grabar" runat="server" Text="Agregar" OnClick="btn_grabar_Click"></asp:Button></td>
                        <td><asp:Label id="lbl_mensaje" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
    </center>
</asp:Content>
