<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/WebPage.Master" AutoEventWireup="true" CodeBehind="RegistrarVentas.aspx.cs" Inherits="WebASPNET.Vistas.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h1>Compra</h1>
        <br />
            <table>
                <tr>
                    <td>Nombre Producto: </td>
                    <td><asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>Precio: </td>
                    <td><asp:Label ID="lbl_precio" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Stock: </td>
                    <td><asp:Label ID="lbl_stock" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>Cantidad: </td>
                    <td><asp:DropDownList ID="DropDownList2" AutoPostBack="true" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td><asp:Button ID="btn_agregar" runat="server" Text="Agregar Producto" OnClick="btn_agregar_Click"></asp:Button></td>
                    <td><asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label></td>
                </tr> 
                <tr>                                   
                    <asp:GridView ID="gv_carro" runat="server"></asp:GridView>
                </tr>   
            </table> 
            <center>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text="Finalizar Compra" OnClick="Button1_Click"></asp:Button>
                    </td>
                </tr>
            </table>
                </center>
            <br />
    </center>
</asp:Content>
