strServidor = "http://127.0.0.1/elecnorchile/intranet";
//strServidor = "http://www.elecnorchile.cl/intranet";

function cerrarsesion()
{
	location.href = ( strServidor +'/asp/cerrarsesion.asp');
}
function irUrl( url )
{
	location.href = url;
}
function cerrar_ventana (div)
{
	var output = document.getElementById( div );
	output.style.display="none";
}
function layers()
{
    var win = window.open('utilidades/layers.asp', "newwin", "toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=yes,width=300,height=350");
}
function layers2(menu)
{
	var output = document.getElementById( 'utilidades' );
	output.style.display="block";
}
// Apagar o Encender Layers
function LayerOnOff(strLayer)
{
	if (top.opener.document.forms.frmwhip.whip.BeginLayerSearch(strLayer))
		top.opener.document.forms.frmwhip.whip.SetLayerVisibility(document.forms.frmwhip[strLayer].checked);
}
// Apagar o Encender Layers
function LayerOnOff2(strLayer)
{
	if (document.forms.frmwhip.whip.BeginLayerSearch(strLayer))
		document.forms.frmwhip.whip.SetLayerVisibility(document.forms.frmdatos[strLayer].checked);
}

function list_planos(menu)
{
    var output = document.getElementById( 'utilidades' );
    var menu = document.getElementById( 'menu' ).value;	

    ajax=nuevoAjax();
	ajax.open("POST", "utilidades/planos.asp",true);
    ajax.setRequestHeader('Content-Type','application/x-www-form-urlencoded');
    ajax.send('menu='+menu);
    ajax.onreadystatechange=function()
    {
        if (ajax.readyState==4)
        {
            //alert (ajax.responseText);
			output.style.display="block";
            output.innerHTML = ajax.responseText;
        }
    }
}

// Hace un Zoom en el plano para visualizar el objeto en cuestión.
function Ver_En_Plano (Tipo_Elem, Codigo_Elem, CodPlano, Nivel_Zoom, menu, id_zona)
{
    var LnkLeft, LnkRight, LnkBottom, LnkTop
	if (CodPlano == -1)
		alert('Objeto no está asociado a ningún plano.');
		else
	{
		if (document.forms.frmwhip){
			if (document.forms.frmwhip.hidcodplano){
				if (document.forms.frmwhip.hidcodplano.value != CodPlano) {
					location.href = strServidor + "/asp/principal.asp?p=" + CodPlano+ "&menu=" + menu + "&z=" + id_zona + "&nzoom=" + Nivel_Zoom + "&b=1&h=" + "Javascript:" + Tipo_Elem + "('" + Codigo_Elem + "')";
				} else {
		    			if (document.forms.frmwhip.whip.BeginLinksSearch ("Javascript:" + Tipo_Elem + "('" + Codigo_Elem + "')")){
						LnkLeft = document.forms.frmwhip.whip.GetLinkLeft();
		     			LnkRight = document.forms.frmwhip.whip.GetLinkRight();
		     			LnkBottom = document.forms.frmwhip.whip.GetLinkBottom();
						LnkTop = document.forms.frmwhip.whip.GetLinkTop();
						document.forms.frmwhip.whip.DrawView (LnkLeft - Nivel_Zoom, LnkRight + Nivel_Zoom, LnkBottom, LnkTop);
					} else {
						alert('Objeto ' + Codigo_Elem + ' no encontrado.');
					}
				}
			} else {
				location.href = strServidor + "/asp/principal.asp?p="+CodPlano+"&menu=inbox&nzoom=" + Nivel_Zoom + "&b=1&h=" + "Javascript:" + Tipo_Elem + "('" + Codigo_Elem + "')";
			}
		} else {
			//top.opener.parent.frames.alumpub_plano.focus();
			location.href = strServidor + "/asp/principal.asp?p="+CodPlano+"&menu=inbox&nzoom=" + Nivel_Zoom + "&b=1&h=" + "Javascript:" + Tipo_Elem + "('" + Codigo_Elem + "')";
		}
	}
}
// VALIDAR SI ES NUMERO
function validarSiNumero(dato)
{
    if (!/^([0-9])*$/.test(dato.value))
	{
    	alert("El valor " + dato.value + " no es un número");
      	dato.focus();
      	return false;	  
	} 
	return true;	  	 
}
// SELECCIONAR PAGINA
function selpag()
{
	var id_plano = document.getElementById('hidcodplano').value;
	var id_zona = document.getElementById('selzona').value;	
	var id_opfiltro = document.getElementById('selopcion_filtro').value;	
	var texto = document.getElementById('texto').value;		
	if (document.getElementById('rpp') != null)
		var rpp = document.getElementById('rpp').value;
	else
		var rpp = 15;
		
	if (document.getElementById('pag_actual') != null)
		var pag_actual = document.getElementById('pag_actual').value;	

	if (document.getElementById('selpagina') != null)	
		var pag = document.getElementById('selpagina').value;
	else
		var pag = 1;	

	var r = 1;

	if (pag_actual < pag)
	{
		if (document.getElementById('mas_r') != null)	
		{
			var mas_r = document.getElementById('mas_r').value;	
			r = mas_r;
		}
	}	
	else
	{
		if (document.getElementById('menos_r') != null)	
		{
			var menos_r = document.getElementById('menos_r').value;
			r = menos_r;
		}

	}	
	if (validarSiNumero (document.getElementById('rpp')))
		irUrl('?p=' + id_plano + '&menu=inbox&idZ=' + id_zona + '&opfiltro=' + id_opfiltro + '&texto=' + texto + '&r=' + r + '&pag=' + pag + '&rpp='+ rpp);
}

// PANEO - ZOOM WINDOW - ZOOM DYNAMIC
function Herramienta(num_herramienta)
{
//	document.forms.frmwhip.whip.cursormode = num_herramienta
	document.forms.frmwhip.whip.cursormode = num_herramienta	
}

// ZOOM EXTEND
function ZoomExtend()
{
	var Bottom = document.forms.frmwhip.whip.GetDrawingExtentsBottom;
	var Left = document.forms.frmwhip.whip.GetDrawingExtentsLeft;
	var Right = document.forms.frmwhip.whip.GetDrawingExtentsRight;
	var Top = document.forms.frmwhip.whip.GetDrawingExtentsTop;
	document.forms.frmwhip.whip.DrawView (Left, Right, Bottom, Top);
}

// IMPRIMIR
function Imprimir()
{
	if (document.forms.frmwhip.whip.PrintSetup(true, true, true, 1)) {
   		document.forms.frmwhip.whip.PrintCurrentView()
	}
}	

/*   AUTOSUGERENCIA DEL SOLICITANTE DE LA ORDEN DE TRABAJO */
function auto_solicitante (obj, div)
{
	var solicitante = obj.value;
	var ele = obj.name;	
	var id_ele = "id_" + obj.name;
	var output = document.getElementById( div );
	
	if (solicitante.length>4)
	{
	    ajax=nuevoAjax();
	    ajax.open("POST", "mantencion/auto_solicitante.asp",true);
	    ajax.setRequestHeader("Content-Type","application/x-www-form-urlencoded");
	    ajax.send('div=' + div + '&obj=' + ele + '&solicitante=' + escape(solicitante) + '&id_ele=' + id_ele);
		ajax.onreadystatechange=function()
	    {
	        if (ajax.readyState==4)
	        {
				output.style.display="block";
	            output.innerHTML = ajax.responseText;
				if (ajax.responseText == "")
					output.style.display="none";
			}
	    }
	}	
}	

// Selecciona solicitante sugerido
function selsolicitante (div, obj, id, nombre, nom_id, telefono)
{
//	alert (div);
	var output = document.getElementById( div );
	
	document.getElementById(nom_id).value = id;
	document.getElementById(obj).value = nombre;
	document.getElementById('solicitante_fono').value = telefono;	
	output.style.display="none";
}

/*VALIDAR CALLE*/
function validar_frm_calles()
{
var tipo 	= document.getElementById("seltipo");
var nombre	= document.getElementById("nombre_calle");
	if (tipo.value=="" || tipo.value==" ")
    {
        alert ("Debe seleccionar el tipo Calle");
        tipo.focus();
        return false;
    }
	if (nombre.value=="" || nombre.value==" ")
    {
        alert ("Debe ingresar el nombre de Calle");
        nombre.focus();
        return false;
    }
return true;
}
/* INSERTAR CALLE*/
function guardar_calles()
{
	if (validar_frm_calles())
    {
	   var id_calle		= document.getElementById("id").value;
	   var tipo 		= document.getElementById("seltipo").value;
	   var nombre_calle	= document.getElementById("nombre_calle").value;
	   var accion 		= document.getElementById("accion").value;
   
	   var output = document.getElementById("datos");	   

		ajax=nuevoAjax();
        ajax.open("POST", "catastro/calles_guardar.asp",true);
        ajax.setRequestHeader('Content-Type','application/x-www-form-urlencoded');
        ajax.send('accion=' + accion + '&id_calle=' + id_calle + '&id_tipo=' + tipo + '&nombre_calle=' + escape(nombre_calle));		
        ajax.onreadystatechange=function()
        {
            if (ajax.readyState==4)
            {
				output.innerHTML = ajax.responseText;
	        }
        }
    }

}
	
/*ELIMINAR CALLE*/	
function eliminar_calles(id)
{
    var output = document.getElementById( 'datos' );
    var menu = document.getElementById( 'menu' ).value;	

    ajax=nuevoAjax();
	ajax.open("POST", "catastro/calles_eliminar.asp",true);
    ajax.setRequestHeader('Content-Type','application/x-www-form-urlencoded');
    ajax.send('id='+id);
    ajax.onreadystatechange=function()
    {
        if (ajax.readyState==4)
        {
            //alert (ajax.responseText);
//			output.style.display="block";
            output.innerHTML = ajax.responseText;
        }
    }
}