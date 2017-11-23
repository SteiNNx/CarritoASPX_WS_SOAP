<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/WebPage.Master" AutoEventWireup="true" CodeBehind="ListadoPersonal.aspx.cs" Inherits="WebASPNET.Vistas.ListadoPersonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=obtenerDatos() %>);

            var options = {
                title: 'Grafico Personal',
                pieHole: 0.4,
            };

            var chart = new google.visualization.PieChart(document.getElementById('donutchart'));
            chart.draw(data, options);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <h1>Listado Personal</h1>
        <br />
            <asp:GridView ID="gv_personal" runat="server"></asp:GridView>  
            <div id="donutchart" style="width: 900px; height: 500px;"></div>
    </center>
</asp:Content>
