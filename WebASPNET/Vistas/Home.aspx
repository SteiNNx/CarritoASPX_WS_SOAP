<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/WebPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebASPNET.Vistas.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <table class="table-bordered ">
            <thead>
                <tr>
                    <th class="auto-style1">Nobre Combo</th>
                    <th class="auto-style1">Precio Combo</th>
                    <th class="auto-style1">Comprar</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (var item in listarCombos())
                    {
                        Response.Write("<form id='form1' runat='server'>");
                        Response.Write("<tr>");
                        Response.Write("<td>" + item.NombreProducto);
                        Response.Write("</td>");
                        Response.Write("<td>" + item.PrecioProducto);
                        Response.Write("</td>");
                        Response.Write("<td><a href='RegistrarVentas.aspx?dato="+item.NombreProducto+"'>Comprar</a></td>");
                        string nombre = item.NombreProducto;              
                        Response.Write("</td>");
                        Response.Write("</tr>");
                        Response.Write("</form>");
                    } %>
            </tbody>
            <tr>
                <td>
                    <asp:label id="lbl_mensaje" runat="server" text=""></asp:label>
                </td>
                <td></td>
            </tr>
        </table>
</asp:Content>
