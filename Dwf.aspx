<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dwf.aspx.cs" Inherits="Dwf" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="upload">
            <input id="flimage" runat="server" type="file" />
            <asp:Button ID="subir" runat="server" OnClick="subir_Click" Text="Subir" />
            <div id="estado_subida">
                <asp:Label ID="lblmessage" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="Lugar" runat="server" />
                <asp:HiddenField ID="nombreArchivo" runat="server" />
                <asp:Literal ID="script" runat="server"></asp:Literal>
            </div>
        </div>
        <asp:Label ID="d" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
