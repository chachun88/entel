<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entel</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
    <link type="image/x-icon" rel="icon" href="img/entelpcs.ico" />

    <script type="text/javascript" src="js/Jquery.js"></script>

    <script type="text/javascript" src="js/JScript.js"></script>

    <script type="text/javascript" src="js/entel.login.home.js"></script>



</head>
<body>
    <div id="contenedor">
        <form id="formBusqueda" runat="server">
        <!-- #INCLUDE FILE="cabecera.htm" -->
        <div id="contenido">
            <div class="banner_home_destacado clearfix">
                <!-- Caja de formulario de ingreso Mi Entel -->
                <div class="caja_mi_entel" id="caja_mi_entel">
                    <div class="caja_destacada_mi_entel">
                        <div class=" clearfix">
                            <h2 class="titulo_mientel">
                                Buscar</h2>
                        </div>
                        <div class="contenedor_tabs clearfix">
                            <div class=" tab tab_seleccionado">
                                Lugares
                            </div>
                        </div>
                        <div class=" contenido_tab tab_desplegado clearfix">
                            <div id="cont_busquedas">
                                <div id="Buscador">
                                    <asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="Buscar" runat="server" OnClick="Buscar_Click" 
                                         ImageUrl="img/buscar.png" />
                                </div>
                                <div id="Busqueda">
                                    <form action="" method="post" id="form1">
                                    <label>
                                        <span class="tituloazul">Region:</span></label>
                                    <select onchange="MM_jumpMenu('parent',this,0)" name="menu1">
                                        <option selected="selected">------------------------</option>
                                        <option value="regiones.aspx?region=707">Metropolitana</option>
                                        <option value="regiones.aspx?region=708">I Region</option>
                                        <option value="regiones.aspx?region=709">II Region</option>
                                        <option value="regiones.aspx?region=710">III Región</option>
                                        <option value="regiones.aspx?region=711">IV Región</option>
                                        <option value="regiones.aspx?region=713">V Región</option>
                                        <option value="regiones.aspx?region=714">VI Región</option>
                                        <option value="regiones.aspx?region=715">VII Región</option>
                                        <option value="regiones.aspx?region=716">VIII Región</option>
                                        <option value="regiones.aspx?region=717">IX Región</option>
                                        <option value="regiones.aspx?region=712">X Región</option>
                                        <option value="regiones.aspx?region=725">XI Región</option>
                                        <option value="regiones.aspx?region=8620">XII Región</option>
                                        <option value="regiones.aspx?region=717">XIV Región</option>
                                        <option value="regiones.aspx?region=708">XV Región</option>
                                    </select>
                                    </form>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="caja_destacada_abajo_mi_entel">
                        <span></span>
                    </div>
                </div>
                <!-- fin Caja de formulario de ingreso Mi Entel -->
                <div id="flashContent">
                    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="786" height="480"
                        id="chile" align="middle">
                        <param name="movie" value="chile.swf" />
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
                        <object type="application/x-shockwave-flash" data="chile.swf" width="786" height="480">
                            <param name="movie" value="chile.swf" />
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
            </div>
        </div>
        <!-- #INCLUDE FILE="footer.htm" -->
        </form>
    </div>
    
</body>
</html>
