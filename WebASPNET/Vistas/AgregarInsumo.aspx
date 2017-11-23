<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/WebPage.Master" AutoEventWireup="true" CodeBehind="AgregarInsumo.aspx.cs" Inherits="WebASPNET.Vistas.AgregarInsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h1>Agregar Insumos</h1>
        <br />
                <table>
                    <tr>
                        <td>Nombre Producto: </td>
                        <td><asp:TextBox ID="txt_nombre" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Precio Producto: </td>
                        <td><asp:TextBox ID="txt_precio" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Combo</td>
                        <td><asp:RadioButton ID="rb_si" Text="SI" runat="server" GroupName="combo"></asp:RadioButton><asp:RadioButton ID="rb_no" Text="NO" runat="server" GroupName="combo"></asp:RadioButton></td>
                    </tr>
                    <tr>
                        <td>Stock</td>
                        <td><asp:TextBox ID="txt_stock" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btn_grabar" runat="server" Text="Guardar" OnClick="btn_grabar_Click"></asp:Button></td>
                        <td><asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label></td>
                    </tr>
                </table>
    </center>
</asp:Content>
