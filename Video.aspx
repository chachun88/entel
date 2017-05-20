<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="Video" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Video</title>
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
        <br />
        <asp:Button ID="Eliminar" runat="server" OnClick="eliminar_Click" Text="Eliminar Video" />
        </div>
    </div>
    <div style="position: absolute; z-index: 100">
        <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="400" height="350"
            id="flvplayer" align="middle">
            <param name="movie" value="as/flvplayer.swf?enlace=<asp:Literal ID="nombreArchivo" Text="" runat="server" />" />
            <param name="quality" value="high" />
            <param name="bgcolor" value="#ffffff" />
            <param name="play" value="true" />
            <param name="loop" value="true" />
            <param name="wmode" value="window" />
            <param name="scale" value="showall" />
            <param name="menu" value="true" />
            <param name="devicefont" value="false" />
            <param name="salign" value="" />
            <param name="allowScriptAccess" value="sameDomain" />
            <!--[if !IE]>-->
            <object type="application/x-shockwave-flash" data="as/flvplayer.swf?enlace=<asp:Literal ID="nombreArchivoUno" Text="frutillar.mp4" runat="server" />"
                width="400" height="350">
                <param name="movie" value="as/flvplayer.swf?enlace=<asp:Literal ID="nombreArchivoDos" Text="frutillar.mp4" runat="server" />" />
                <param name="quality" value="high" />
                <param name="bgcolor" value="#ffffff" />
                <param name="play" value="true" />
                <param name="loop" value="true" />
                <param name="wmode" value="window" />
                <param name="scale" value="showall" />
                <param name="menu" value="true" />
                <param name="devicefont" value="false" />
                <param name="salign" value="" />
                <param name="allowScriptAccess" value="sameDomain" />
                <!--<![endif]-->
                <a href="http://www.adobe.com/go/getflash">
                    <img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif"
                        alt="Obtener Adobe Flash Player" />
                </a>
                <!--[if !IE]>-->
            </object>
            <!--<![endif]-->
        </object>
    </div>
    </form>
</body>
</html>
