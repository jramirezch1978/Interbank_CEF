$Ajax=new Object;

$Ajax.ReadyState=
{
	sinInicializar:0,
	Cargando:1,
	Cargado:2,
	Interactivo:3,
	Completo:4
}

$Ajax.Status=
{
	procesadaCorrectamente:200,
	noExisteServidor:404,
    errorInternoEnServidor:500,
    peticionErronea:400,
    sinPermiso:403,
    noSeAceptaMetodo:405,
    urlMuyLarga:414,
    servidorNoDisponible:503
}

$Ajax.fInstanciarXHR=function()
{
	return Try.these
    (
        function(){return new XMLHttpRequest()},
        function(){return new ActiveXObject('MSXML2.XMLHttp.7.0')},
        function(){return new ActiveXObject('MSXML2.XMLHttp.6.0')},
        function(){return new ActiveXObject('MSXML2.XMLHttp.5.0')},
        function(){return new ActiveXObject('MSXML2.XMLHttp.4.0')},
        function(){return new ActiveXObject('MSXML2.XMLHttp.3.0')},
        function(){return new ActiveXObject('MSXML2.XMLHttp')},
        function(){return new ActiveXObject('Microsoft.XMLHttp')}
    ) || false;
};
	
$Ajax.fEnviarRequerimiento=function(oXHR, strURL, arrOpciones)
{
	if (oXHR!=null)
	{
		if (strURL!=null)
		{
			strMetodo=this.fRetornaParametro(arrOpciones,"metodo", "POST");
			funcRecepcion=this.fRetornaParametro(arrOpciones,"funcRecepcion", null);
			funcMensajeProcesando=this.fRetornaParametro(arrOpciones,"funcMensajeProcesando", null);
			this.CargarHeaders(oXHR, arrOpciones);
			
			oXHR.open('POST',strURL,true);
		    oXHR.onreadystatechange=funcRecepcion;
		    if (funcMensajeProcesando!=null) funcMensajeProcesando();
		}
	}
};

$Ajax.fRetornaParametro=function(arrOpciones, strNombreParametro, oValorPorDefecto)
{
	var oRpta = oValorPorDefecto;
	
	if (arrOpciones!=null)
	{
		if(arrOpciones[strNombreParametro]!=null)
		{
			oRpta=arrOpciones[strNombreParametro]
		}
	}
	
	return oRpta;
}

$Ajax.fCargarHeaders=function(oXHR, arrOpciones)
{
	arrHeaders = this.fRetornaParametro(arrOpciones,"arrHeaders", null);
	if (arrHeaders!=null)
	{
		for(var i=0; i<arrHeaders.length; i++) 
		{
			strNombreHeader=this.fRetornaParametro(arrHeaders[i],"NombreHeader", null);
			if (strNombreHeader!=null)
			{
				strValor=this.fRetornaParametro(arrHeaders[i],"ValorHeader", null);
				if (strValor!=null)
				{
					oXHR.setRequestHeader(strNombreHeader, strValor);
				}
			}
		}		
	}
	
	return oRpta;
}

var Try = {
  these: function() {
    var returnValue;

    for (var i = 0, length = arguments.length; i < length; i++) {
      var lambda = arguments[i];
      try {
        returnValue = lambda();
        break;
      } catch (e) { }
    }

    return returnValue;
  }
};