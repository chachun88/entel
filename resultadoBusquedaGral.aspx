<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resultadoBusquedaGral.aspx.cs"
    Inherits="resultadoBusquedaGral" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Entel</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
    <link type="image/x-icon" rel="icon" href="img/entelpcs.ico" />

    <script type="text/javascript" src="js/Jquery.js"></script>

    <script type="text/javascript" src="js/JScript.js"></script>

    <script type="text/javascript" src="js/entel.login.home.js"></script>

    <script type="text/javascript" src="js/entel.login.LB.js"></script>

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
                        <div class="cabecera clearfix">
                            <h2 class="titulo_mientel">
                                Buscar</h2>
                        </div>
                        <div class="contenedor_tabs clearfix">
                            <div class="tab_1 tab tab_seleccionado">
                                Lugares
                            </div>
                        </div>
                        <div class="contenido_tab_1 contenido_tab tab_desplegado clearfix">
                            <div id="Div1">
                                <div id="Div2">
                                    <asp:TextBox ID="txtBusqueda" runat="server"></asp:TextBox>
                                    <asp:ImageButton ID="Buscar" runat="server" OnClick="Buscar_Click" 
                                        Text="Buscar" ImageUrl="img/buscar.png" />
                                </div>
                                <div id="Div3">
                                    <form action="" method="post" name="form1">
                                    <label>
                                        <span class="tituloazul">Region:</span></label>
                                    <select onchange="MM_jumpMenu('parent',this,0)" name="menu1">
                                        <option selected="">------------------------</option>
                                        <option value="regiones.aspx?region=707">Metropolitana</option>
                                        <option value="regiones.aspx?region=708">I Region</option>
                                        <option value="regiones.aspx?region=709">II Region</option>
                                        <option value="regiones.aspx?region=710">III Región</option>
                                        <option value="regiones.aspx?region=711">IV Región</option>
                                        <option value="regiones.aspx?region=712">V Región</option>
                                        <option value="regiones.aspx?region=713">VI Región</option>
                                        <option value="regiones.aspx?region=714">VII Región</option>
                                        <option value="regiones.aspx?region=715">VIII Región</option>
                                        <option value="regiones.aspx?region=716">IX Región</option>
                                        <option value="regiones.aspx?region=717">X Región</option>
                                        <option value="regiones.aspx?region=725">XI Región</option>
                                        <option value="regiones.aspx?region=8620">XII Región</option>
                                        <option value="regiones.aspx?region=717">XIV Región</option>
                                        <option value="regiones.aspx?region=708">XV Región</option>
                                    </select>
                                    </form>
                                </div>
                            </div>
                        </div>
                        <div class="contenido_tab_2 contenido_tab clearfix">
                            <span class="bajada_titulo_gris clearfix">En Mi Entel, podrás administrar tu cuenta,
                                ver tu <strong>boleta</strong> o <strong>factura</strong>, detalle de <strong>llamadas</strong>,
                                <strong>cobros</strong>, <strong>pago</strong> de cuentas en línea y <strong>solicitudes</strong>
                                vía web.</span>
                            <form target="_blank" action="#" method="get" id="LB_formLoginSA">
                            <input type="hidden" value="" name="dv">
                            <input type="hidden" value="" name="rut">
                            <div class="item_formulario clearfix">
                                <div class="input">
                                    <table style="border-collapse: collapse; float: left; position: relative; height: 26px;
                                        width: 177px;">
                                        <tbody>
                                            <tr>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); width: 3px;
                                                    height: 3px; font-size: 1px; background-position: 0px 0px;">
                                                </td>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); background-position: -3px 0px;">
                                                </td>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); width: 3px;
                                                    height: 3px; font-size: 1px; background-position: right 0px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); background-position: 0px -3px;">
                                                </td>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); background-position: -3px -3px;">
                                                    <input type="text" onblur="formatearRut('RutSA')" onkeypress="return soloRUT(event);"
                                                        maxlength="12" style="width: 171px; border: medium none; background: none repeat scroll 0% 0% transparent;
                                                        text-align: left; display: block; margin: -3px 0px;" value="RUT" class="inputBox"
                                                        name="RutSA" id="RutSA">
                                                </td>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); background-position: right -3px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); width: 3px;
                                                    height: 3px; font-size: 1px; background-position: left bottom;">
                                                </td>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); background-position: -3px bottom;">
                                                </td>
                                                <td style="background-image: url(&quot;img/bg_inputLiquido.gif&quot;); width: 3px;
                                                    height: 3px; font-size: 1px; background-position: right bottom;">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                            <div class="contenedor_botones_home">
                                <div class="contenedor_boton_azul">
                                    <a id="LB_btnLoginSA" class="enlaceNaranja pngfix" href="#"><span class="pngfix">Ingresar</span></a>
                                </div>
                            </div>
                            </form>
                        </div>
                    </div>
                    <div class="caja_destacada_abajo_mi_entel">
                        <span></span>
                    </div>
                </div>
                <!-- fin Caja de formulario de ingreso Mi Entel -->
                <div id="tabla_busqueda">
                    <asp:Label ID="tblLugar" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <!-- #INCLUDE FILE="footer.htm" -->
        </form>
    </div>
</body>
</html>
