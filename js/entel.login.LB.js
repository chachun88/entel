var action = {
	loginEntelPCS: 		"http://www.entelpcs.cl/login/valida_ws.iws?origen=home",
	loginEntelSA: 		"https://atencionenlinea.entel.cl/login.aspx",
	solicitarClaveEPCS: "http://mipcs.entelpcs.com/mipcs2/comunes/solicitarClave/enviarClaveMovil.do"
}

$(document).ready(function() {
	$('input.inputBox').each(function() {
		if(!$(this).parent().is('td')) {
			$(this).inputBox();
		}
	});

	/*
	 * Ingresar
	 */
	//EPCS
	$('#LB_btnLoginEntel').click(function() {
		if ($("form#LB_formLoginEntel").valid()) {
			$("form#LB_formLoginEntel").attr('action',action.loginEntelPCS);
			$("form#LB_formLoginEntel")[0].submit();
		}
		return false;
	});
	//Entel SA
	$('#LB_btnLoginSA').click(function() {
		if ($("form#LB_formLoginSA").valid()) {	
			var TEMP = $("form#LB_formLoginSA").find('input[name=RutSA]').val().split('-');
			var RUT = TEMP[0].split(".").join("");
			
			$("form#LB_formLoginSA").find('input[name=dv]').val(TEMP[1]);
			$("form#LB_formLoginSA").find('input[name=rut]').val(RUT);
			
			$("form#LB_formLoginSA").attr('action',action.loginEntelSA);
			$("form#LB_formLoginSA")[0].submit();
		}
		return false;
	});
	
	/*
	 * Ingresar por Evento
	 */
	//EPCS
	$('form#LB_formLoginEntel input[name=Movil],form#LB_formLoginEntel input[name=Rut],form#LB_formLoginEntel input[name=PIN]').keypress(function(e) {
		if (e.keyCode == 13 && $("form#LB_formLoginEntel").valid()) {
			formatearRut('Rut');
			$("form#LB_formLoginEntel").attr('action', action.loginEntelPCS);
			$("form#LB_formLoginEntel")[0].submit();
		}
	});
	//Entel SA
	$("form#LB_formLoginSA input[name=RutSA]").keypress(function(e) {
		if (e.keyCode == 13 && $("form#LB_formLoginSA").valid()) {
			formatearRut('RutSA');
			
			var TEMP = $("form#LB_formLoginSA").find('input[name=RutSA]').val().split('-');
			var RUT = TEMP[0].split(".").join("");
			
			$("form#LB_formLoginSA").find('input[name=dv]').val(TEMP[1]);
			$("form#LB_formLoginSA").find('input[name=rut]').val(RUT);
			
			$("form#LB_formLoginSA").attr('action',action.loginEntelSA);
			$("form#LB_formLoginSA")[0].submit();
		}
	});
	
	/*
	 * Solicitar Clave Mi EPCS
	 */
	//EPCS
	$('#LB_btnSolicitarClaveEntel').click(function() {
		$("form#LB_formLoginEntel").attr('action',action.solicitarClaveEPCS);
		$("form#LB_formLoginEntel")[0].submit();
	});
	
	/*------------------------------------
			     Validacion
	------------------------------------*/
	$('input').keypress(function(e) {
		if (e.keyCode != 13) {
			$('#globoError, #globoErrorAlternativo').fadeOut();
			if ($(this).get(0).disableError) 
				$(this).get(0).disableError();
		}					 
	});
		
	//EPCS	
	$("form#LB_formLoginEntel").validate({
		onkeyup: false,
		onfocusout: false,
		rules: {
			Movil: {
				required: true,
				number: true,
				minlength:8
			},
			Rut: {
				required: true,
				rut: true,
				maxlength: 16
			},
			PIN: {
				required: true,
				minlength: 4
			}
		},
		messages: {
			Movil:{
				required:"Debes ingresar el n&uacute;mero de tu Entel.",
				number:"Debes ingresar el n&uacute;mero de tu Entel.",
				minlength:"Debes ingresar un n&uacute;mero Entel v&aacute;lido."
			},
			Rut: {
				required: "Debes ingresar tu RUT.",
				rut: "Debes ingresar un RUT v&aacute;lido.",
				maxlength: "Debes ingresar un RUT v&aacute;lido."
			},
			PIN: {
				required: "Debes ingresar la clave de tu Entel.",
				minlength: "Debes ingresar una clave Entel v&aacute;lida."
			}
		},
		errorPlacement: function(error, element) {
			var $form = element.parents('form:first');
			var firstError = $form.validate().errorList[0].message;
			var $padre = $form.parent().css('position','relative');
			
			/*---*/
			$('#globoError, #globoErrorAlternativo').remove();
			var $globo = $('<div id="globoError" class="globoError"><div>msg</div></div>')
				.css({top: "-999px", left: "-999px"}).appendTo($padre).hide();
			/*---*/
			
			$('#globoError').find('div').html(firstError);
			showGlobo($form.validate().errorList[0].element, $padre);
		}
	});
	
	//Entel SA
	$("form#LB_formLoginSA").validate({
		onkeyup: false,
		onfocusout: false,
		rules: {
			RutSA: {
				required: true,
				rut: true,
				maxlength: 16
			}
		},
		messages: {
			RutSA: {
				required: "Debes ingresar tu RUT.",
				rut: "Debes ingresar un RUT v&aacute;lido.",
				maxlength: "Debes ingresar un RUT v&aacute;lido."
			}
		},
		errorPlacement: function(error, element) {
			var $form = element.parents('form:first');
			var firstError = $form.validate().errorList[0].message;
			var $padre = $form.parent().css('position','relative');
			
			/*---*/
			$('#globoError, #globoErrorAlternativo').remove();
			var $globo = $('<div id="globoError" class="globoError"><div>msg</div></div>')
				.css({top: "-999px", left: "-999px"}).appendTo($padre).hide();
			/*---*/
			
			$('#globoError').find('div').html(firstError);
			showGlobo($form.validate().errorList[0].element, $padre);
		}
	});
});

function showGlobo(el, $padre) {
	$('.columna_lb:first').css('z-index',10);
	
	var $input = $(el);
	var $globo = $('#globoError');
	
	var punto = {};
	punto.left = (parseInt($padre.offset().left) - parseInt($input.offset().left)) + parseInt($input.width()) + 35;
	punto.top = (parseInt($input.offset().top) - parseInt($padre.offset().top)) + (parseInt($input.height())/2 - 15);
	
	if ($globo.is(':hidden')) {
		$globo.fadeIn(200, function() {
			$(el).focus();							
		});
	}
	
	$globo.css({
		'top': punto.top+'px',
		'left': punto.left+'px'
	});
	
	$('input, select').each(function() {
		if(this.disableError) {
   			this.disableError();
		}
	});
	if(el.enableError) {
		el.enableError();
	}
	
	return false;
}

function showGloboAlternativo(el, $padre) {
	$('.columna_lb:first').css('z-index',1);
	
	var $input = $(el);
	var $globo = $('#globoErrorAlternativo');
	
	var punto = {};
	punto.left = (parseInt($padre.offset().left) - parseInt($input.offset().left)) - 188;
	punto.top = (parseInt($input.offset().top) - parseInt($padre.offset().top)) + (parseInt($input.height())/2 - 15);
	
	if ($globo.is(':hidden')) {
		$globo.fadeIn(200, function() {
			$(el).focus();							
		});
	}
	
	$globo.css({
		'top': punto.top+'px',
		'left': punto.left+'px'
	});
	
	$('input, select').each(function() {
		if(this.disableError) {
   			this.disableError();
		}
	});
	if(el.enableError) {
		el.enableError();
	}
	
	return false;
}

function soloNumeros(evt){
	var key = evt.keyCode ? evt.keyCode : evt.which ;
	return (key <= 31 || (key >= 48 && key <= 57)); 
}

function soloRUT(evt) {
	var key = evt.keyCode ? evt.keyCode : evt.which ;
	return (key <= 31 || (key >= 48 && key <= 57) || key == 75 || key == 107); 
}

function formatearRut(casilla){
	function formatearMillones(nNmb){
		var sRes = "";
		for (var j, i = nNmb.length - 1, j = 0; i >= 0; i--, j++)
		 sRes = nNmb.charAt(i) + ((j > 0) && (j % 3 == 0)? ".": "") + sRes;
		return sRes;
	}
	
	var casillaRut=document.getElementById(casilla);
	
	var rut=casillaRut.value;
	var ultimoDigito=rut.substr(rut.length-1,1);
	var terminaEnK = (ultimoDigito.toLowerCase()=="k");
	rutSinFormato=rut.replace(/\W/g,"");
	rut=rut.replace(/\D/g,"");
	var dv=rut.substr(rut.length-1,1);
	if(!terminaEnK){ rut=rut.substr(0,rut.length-1); }
	else{ dv="K"; }
	if(rut && dv) {
		casillaRut.value=formatearMillones(rut)+"-"+dv;
		document.getElementById('buic_rutdv').value=rutSinFormato;
	}
}

