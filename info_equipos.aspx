<%@ Page Language="C#" AutoEventWireup="true" CodeFile="info_equipos.aspx.cs" Inherits="info_equipos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
    <link type="image/x-icon" rel="icon" href="img/entelpcs.ico" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="Lugar" runat="server" />
    <div id="info_equipos">
        <h2 class="titulo_cajas">
            EQUIPOS INSTALADOS EN 
            <asp:Literal ID="ttl_pagina" runat="server"></asp:Literal>
        </h2>
        <%--<table cellspacing="0" cellpadding="2" border="0" width="200px" class="tabla_busqueda">--%>
            <asp:Literal ID="tbl_info" runat="server"></asp:Literal>
        <%--</table>--%>
    </div>
    </form>
</body>
</html>
