<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/WebPage.Master" AutoEventWireup="true" CodeBehind="ActualizarInsumos.aspx.cs" Inherits="WebASPNET.Vistas.Registro_Insumos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h1>Actualizar Insumos</h1>
        <br />
                <table>
                    <tr>
                        <td>Nombre Producto: </td>
                        <td><asp:DropDownList ID="ddl_producto" AutoPostBack="true" OnSelectedIndexChanged="ddl_producto_SelectedIndexChanged"  runat="server" ></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>Precio: </td>
                        <td><asp:TextBox ID="txt_precio" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Stock</td>
                        <td><asp:TextBox ID="txt_stock" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Habilitado</td>
                        <td><asp:RadioButton ID="rb_si" Text="Habilitado" AutoPostBack="true" runat="server" GroupName="habilitado"></asp:RadioButton><asp:RadioButton ID="rb_no" Text="Deshabilitado" AutoPostBack="true" runat="server" GroupName="habilitado"></asp:RadioButton></td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btn_actualizar" runat="server" Text="Actualizar" OnClick="btn_actualizar_Click"></asp:Button></td>
                        <td><asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label></td>
                    </tr>
                    
                </table>
    </center>
</asp:Content>
