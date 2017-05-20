$(document).ready(function() {
	
	$('input.inputBox').each(function() {
		if(!$(this).parent().is('td')) {
			$(this).inputBox();
		}
	});
	
	//Manejo de tabs
	$(".tab_1").click(function(){
		$(this).addClass("tab_seleccionado");
		$(".tab_2").removeClass("tab_seleccionado");
		$('#globoError, #globoErrorAlternativo').fadeOut();
		
		if (!$(".contenido_tab_1").hasClass("tab_desplegado")){
			$(".contenido_tab_1").show();
			$(".contenido_tab_1").addClass("tab_desplegado");
			
			$(".contenido_tab_2").removeClass("tab_desplegado");
			$(".contenido_tab_2").hide();
		}
		else {
			return false;
		}
	});

	$(".tab_2").click(function(){
		$(this).addClass("tab_seleccionado");
		$(".tab_1").removeClass("tab_seleccionado");
		$('#globoError, #globoErrorAlternativo').fadeOut();
		
		if (!$(".contenido_tab_2").hasClass("tab_desplegado")){
			$(".contenido_tab_2").show();
			$(".contenido_tab_2").addClass("tab_desplegado");
			
			$(".contenido_tab_1").removeClass("tab_desplegado");
			$(".contenido_tab_1").hide();
		}
		else {
			return false;
		}
	});
	
	//Manejo de INPUTS en HOME
	$("input[name=Movil]").val("N\xB0 M\u00f3vil");
	$("input[name=Rut]").val("RUT Usuario");
	$("input[name=RutSA]").val("RUT");
	
	$("input[name=Movil]").focus(function(){
		if ($(this).val() == "N\xB0 M\u00f3vil") {
			$(this).val("");
		}
	});
	$("input[name=Movil]").blur(function(){
		if ($(this).val() == "" ){
			$(this).val("N\xB0 M\u00f3vil");
		}
	});
	
	$("input[name=Rut]").focus(function(){
		if ($(this).val() == "RUT Usuario") {
			$(this).val("");
		}
	});
	$("input[name=Rut]").blur(function(){
		if ($(this).val() == "" ){
			$(this).val("RUT Usuario");
		}
	});
	
	$("input[name=RutSA]").focus(function(){
		if ($(this).val() == "RUT") {
			$(this).val("");
		}
	});
	$("input[name=RutSA]").blur(function(){
		if ($(this).val() == "" ){
			$(this).val("RUT");
		}
	});
	
	$("input[name=PIN]").focus(function(){
		$(".clave_texto").hide();
	});
	$("input[name=PIN]").blur(function(){
		if ($(this).val() == "" ){
			$(".clave_texto").show();
		}
	});
	$(".clave_texto").click(function(){
		$(this).hide();
		$("input[name=PIN]").focus();
	});
	

});