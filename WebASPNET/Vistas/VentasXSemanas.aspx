<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/WebPage.Master" AutoEventWireup="true" CodeBehind="VentasXSemanas.aspx.cs" Inherits="WebASPNET.Vistas.ListadoVentas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h1>Ventas Por Semana</h1>
        <br />
        <table>
            <tr>
                <td>Semana</td>
                <td>
                <asp:DropDownList ID="ddl_semana" runat="server"></asp:DropDownList>
                </td>
                <td>
<asp:Button ID="btn_seman" runat="server" Text="Filtrar" OnClick="btn_seman_Click"></asp:Button>
                </td>
            </tr>
        
            <tr><td>
            <asp:GridView ID="gv_ventas_por_semanas" runat="server"></asp:GridView>  
            </td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="lbl_mensaje" runat="server" Text=""></asp:Label>

                </td>
            </tr>
        </table>

    </center>
</asp:Content>
