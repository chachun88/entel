<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lugar.aspx.cs" Inherits="lugar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
    <link type="image/x-icon" rel="icon" href="img/entelpcs.ico" />

    <script type="text/javascript" src="js/JScript.js"></script>

    <title>Entel - 
        <asp:Literal ID="Titulo" runat="server"></asp:Literal></title>
</head>
<body link="#CCCCCC" vlink="#66CCFF" leftmargin="0" topmargin="0" marginwidth="0"
    marginheight="0" onload="MM_preloadImages('img/a_boton_dtecnicos1.gif','img/a_boton_inicio.gif','img/a_boton_pdiseno1.gif','img/a_boton_cnt.gif')">
    <div id="contenedor">
        <form id="form_lugar" runat="server">
        <!-- #INCLUDE FILE="cabecera.htm" -->
        <div id="contenido" style="height: auto;">
            <div id="cont_lugar">
                <div id="proyecto">
                    <table cellspacing="0" cellpadding="0" border="0" align="center" width="576">
                        <tbody>
                            <tr>
                                <td height="0" align="right" width="14">
                                    &nbsp;
                                </td>
                                <td align="left" width="206" valign="bottom">
                                    <h2 class="titulo_cajas">
                                        Proyecto</h2>
                                    <select name="menu1" onchange="MM_jumpMenu('aqui',this,0)">
                                        <asp:Literal ID="opciones" runat="server"></asp:Literal>
                                    </select>
                                </td>
                                <td align="left" width="272" valign="bottom">
                                    &nbsp;
                                </td>
                                <td height="0" align="right" width="100" valign="bottom">
                                    <div align="right">
                                        <img height="18" width="23" src="img/a_boton_correo.gif"><a href="X_Region/CorteAlto2/Diagrama Unilineal RE Corte Alto 2 PM-074.rar"><img
                                            height="17" border="0" width="31" src="img/a_boton_bajarcd.gif"></a><a href="javascript:window.print()"><img
                                                height="17" border="0" width="20" src="img/ico_imprimir.gif"></a></div>
                                </td>
                                <td align="right" width="16" valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td height="290" colspan="5">
                                    <table cellspacing="1" cellpadding="0" border="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td height="111" bgcolor="#ffffff" valign="top">
                                                    <table cellspacing="2" cellpadding="0" border="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td width="0" valign="top">
                                                                    <span>
                                                                        <iframe src="<asp:Literal ID='primerdwf' runat='server'></asp:Literal>"
                                                                            name="aqui" width="100%" height="470" frameborder="0" id="aqui"></iframe>
                                                                    </span><a href="#"></a><a href="Planta R-E Bari.zip"></a><a href="#"></a>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="3">
                                    &nbsp;
                                </td>
                                <td align="right" width="16" valign="top">
                                    <div align="right">
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="info_estacion">
                    <div id="info_est_top">
                        <h2 class="titulo_cajas">
                            Nombre 
                            <asp:Literal ID="Nombre" runat="server"></asp:Literal></h2>
                        <table cellspacing="1" cellpadding="0" bgcolor="#b9c5d7" width="100%" class="tbl_info_estacion">
                            <tbody>
                                <tr>
                                    <td height="17" bgcolor="#f3f5f8" width="124">
                                        Dirección
                                    </td>
                                    <td bgcolor="#f3f5f8" width="297" colspan="3">
                                        <asp:Literal ID="Direccion" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="17" bgcolor="#ffffff">
                                        Referencia
                                    </td>
                                    <td bgcolor="#ffffff" colspan="3">
                                        <asp:Literal ID="Referencia" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="17" bgcolor="#f3f5f8">
                                        Sigla Redes
                                    </td>
                                    <td bgcolor="#f3f5f8" colspan="3">
                                        <asp:Literal ID="SiglaRedes" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="17" bgcolor="#ffffff">
                                        Alias / IdMdf
                                    </td>
                                    <td bgcolor="#ffffff" colspan="3">
                                        <asp:Literal ID="Alias" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="17" bgcolor="#f3f5f8">
                                        Tipo Radio Estación
                                    </td>
                                    <td bgcolor="#f3f5f8" colspan="3">
                                        <asp:Literal ID="RadioEstacion" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="17" bgcolor="#f3f5f8">
                                        Tipo Infraestructura
                                    </td>
                                    <td bgcolor="#f3f5f8" colspan="3">
                                        <asp:Literal ID="Infraestructura" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div id="info_est_down">
                        <table cellspacing="0" cellpadding="0" border="0" width="100%">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <img height="17" width="21" src="img/ico_imprimir.gif"><a href="X_Region/Los Muermo LA-968/Fotos y Planilla/Los  Muermos.xls"><img
                                            height="17" border="0" width="49" src="img/boton_excel.png"></a></td>
                                </tr>
                                <tr>
                                    <td width="100%" valign="bottom">
                                        <div id="enlaces">
                                            <ul>
                                                <li><a href="info_equipos.aspx?IdLugar=<asp:Literal ID="IdLugarInfo" runat="server"></asp:Literal>"" target="aqui1"><span>Equipos</span> </a></li>
                                                <li><a href="datos_tecnicos.aspx" target="aqui1"><span>Datos Técnicos</span> </a>
                                                </li>
                                                <li><a href="fotos.aspx?IdLugar=<asp:Literal ID="IdLugar" runat="server"></asp:Literal>" target="aqui1"><span>Fotos</span> </a></li>
                                                <li><a href="video.aspx?IdLugar=<asp:Literal ID="IdLugarV" runat="server"></asp:Literal>"" target="aqui1"><span>Video</span> </a></li>
                                                <li><a href="Dwf.aspx?IdLugar=<asp:Literal ID="IdLugarDwf" runat="server"></asp:Literal>"" target="aqui1"><span>DWF</span> </a></li>
                                                <li><a href="Rack.aspx?IdLugar=<asp:Literal ID="IdLugarR" runat="server"></asp:Literal>" target="aqui1"><span>Mantención</span> </a>
                                                </li>
                                            </ul>
                                        </div>
                                    </td>
                                    <td valign="bottom">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <iframe scrolling="Auto" height="360" frameborder="0" width="100%" id="aqui1" name="aqui1"
                            src="info_equipos.aspx?IdLugar=<asp:Literal ID="IdLugarInfo_" runat="server"></asp:Literal>"></iframe>
                    </div>
                </div>
            </div>
        </div>
        </form>
        <!-- #INCLUDE FILE="footer.htm" -->
    </div>
    <!-- fondo transparente IExplorer //-->
</body>
</html>
