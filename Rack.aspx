<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rack.aspx.cs" Inherits="prueba" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Página sin título</title>
    <link href="css/Default.css" type="text/css" rel="Stylesheet" />
    <link href="css/jquery.treeview.css" type="text/css" rel="Stylesheet" />
    <link type="image/x-icon" rel="icon" href="img/entelpcs.ico" />

    <script src="js/lib/jquery.js" type="text/javascript"></script>

    <script src="js/lib/jquery.cookie.js" type="text/javascript"></script>

    <script src="js/jquery.treeview.js" type="text/javascript"></script>

    <script src="js/jquery.treeview.edit.js" type="text/javascript"></script>

    <script src="js/jquery.treeview.async.js" type="text/javascript"></script>

    <script type="text/javascript">

	$(document).ready(function(){

		$("#black").treeview({
			url: "Contenedor.aspx?IdLugar="+$("#Lugar").val()
		});
		
		$("#cerrar").click(function(){
		    $("#contenedor_formulario").fadeOut("slow");
		    //return false;
		});
	});

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="Lugar" runat="server" />
    <div>
        <ul id="black">
            <li id="1" class="hasChildren"><span>Equipamiento</span>
                <ul>
                    <li><span class="placeholder">&nbsp;</span></li>
                </ul>
            </li>
        </ul>
    </div>
    <div id="botones_formulario">
        <asp:Button ID="AgregarHijo" runat="server" Class="boton" Text="Agregar" OnClick="Agregar_Click" />
        <asp:Button ID="Eliminar" runat="server" Class="boton" Text="Eliminar" OnClick="Eliminar_Click" />
        <asp:Button ID="Editar" runat="server" Class="boton" Text="Editar" OnClick="Editar_Click" />
    </div>
    <div id="contenedor_formulario">
        <div id="cerrar">
            <asp:Label ID="lbl_cerrar" runat="server" Text="Cerrar"></asp:Label>
        </div>
        <div id="formulario_arbol">
            <asp:Label ID="lbl_ddnivel" runat="server" Text="Seleccione el equipo:"></asp:Label>
            <br />
            <asp:DropDownList ID="ddnivel" runat="server" OnSelectedIndexChanged="ddnivel_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Literal ID="lista" runat="server"></asp:Literal>
            <br />
            <asp:DropDownList ID="dd" runat="server" OnSelectedIndexChanged="dd_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <asp:Label ID="alerta" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lbl_nombre" runat="server" Text="Nombre: "></asp:Label><asp:TextBox
                ID="txt_nombre" runat="server" Visible="false"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="lbl_tipo" runat="server" Text="Tipo"></asp:Label>
            <asp:DropDownList ID="ddtipo" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lbl_voltaje" runat="server" Text="Voltaje"></asp:Label>
            <asp:DropDownList ID="ddvoltaje" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lbl_ctos" runat="server" Text="Circuitos"></asp:Label>
            <asp:DropDownList ID="ddctos" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="lbl_capacidad" runat="server" Text="Capacidad"></asp:Label>
            <asp:DropDownList ID="ddcapacidad" runat="server">
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <asp:Button ID="ok" runat="server" Text="OK" OnClick="Ok_Click" Class="ok" />
            <asp:Button ID="EliminarOk" runat="server" Text="OK" OnClick="EliminarOk_Click" Class="ok" />
            <asp:Button ID="EditarOk" runat="server" Text="Ok" OnClick="EditarOk_Click" Class="ok" />
        </div>
    </div>
    </form>
</body>
</html>
