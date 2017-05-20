<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Fotos.aspx.cs" Inherits="Fotos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fotos</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="upload">
        <input id="flimage" runat="server" type="file" />
        <asp:Button ID="subir" runat="server" OnClick="subir_Click" Text="Subir" />
        <div id="estado_subida">
            <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
            <asp:HiddenField ID="Lugar" runat="server" />
        </div>
    </div>
    <asp:Label ID="foto" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
