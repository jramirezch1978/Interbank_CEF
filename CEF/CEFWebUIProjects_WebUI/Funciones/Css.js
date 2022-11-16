var boolEsIExplorer=navigator.userAgent.indexOf("MSIE")!=-1;function fCambiarValorDisplayEstilo(pstrNombreHoja,pstrNombreRegla)
{var intRpta=0;var oStyleSheet=fRetornaHojaDeEstilos(pstrNombreHoja);if(oStyleSheet!=null)
{var oReglaCSS=fRetornaReglaCSS(oStyleSheet,pstrNombreRegla)
if(oReglaCSS!=null)
{if(oReglaCSS.style.display.length>0)
{oReglaCSS.style.display='';}
else
{oReglaCSS.style.display='none';}
intRpta=1;}}
fCrearReglaOculto(pstrNombreHoja,'.ClaseCSSPrueba');return(intRpta);}
function fRetornaHojaDeEstilos(pstrNombreHoja)
{var oHoja_Rpta=null;var oStyleSheets=document.styleSheets;for(var i=0;i<oStyleSheets.length;i++)
{if(oStyleSheets[i].href.toUpperCase().indexOf('/'+pstrNombreHoja.toUpperCase())>0)
{oHoja_Rpta=oStyleSheets[i];break;}}
return(oHoja_Rpta);}
function fRetornaReglaCSS(oStyleSheet,pstrNombreRegla)
{var oReglaCSS_Rpta=null;var intTotalReglas=fRetornaTotalReglasCSS(oStyleSheet);for(var i=0;i<=intTotalReglas;i++)
{var oReglaCSS=fRetornaReglasStyleSheet(oStyleSheet)[i];if(oReglaCSS!=null)
{var strSelectorText=oReglaCSS.selectorText.replace('.','').toUpperCase();if(strSelectorText==pstrNombreRegla.toUpperCase())
{oReglaCSS_Rpta=oReglaCSS;break;}}}
return(oReglaCSS_Rpta);}
function fRetornaTotalReglasCSS(oStyleSheet)
{return(fRetornaReglasStyleSheet(oStyleSheet).length-1);}
function fRetornaReglasStyleSheet(oStyleSheet)
{var arrReglas=null;try
{if(boolEsIExplorer)
{arrReglas=oStyleSheet.rules;}
else
{arrReglas=oStyleSheet.cssRules;}}
catch(e){}
return(arrReglas);}
function fCrearRegla(pstrNombreHoja,pstrNombreRegla)
{var intRpta=0;var oStyleSheet=fRetornaHojaDeEstilos(pstrNombreHoja);if(oStyleSheet!=null)
{var oReglaCSS=fRetornaReglaCSS(oStyleSheet,pstrNombreRegla)
if(oReglaCSS==null)
{if(boolEsIExplorer)
{oStyleSheet.addRule(pstrNombreRegla,'',fRetornaTotalReglasCSS(oStyleSheet)+1);}
else
{oStyleSheet.insertRule(pstrNombreRegla+'{}',fRetornaTotalReglasCSS(oStyleSheet)+1);}
intRpta=1;}}
return(intRpta);}
function fCrearReglaOculto(pstrNombreHoja,pstrNombreRegla,boolOculto)
{var intRpta=0;if(boolOculto==null)
{boolOculto=true;}
var oStyleSheet=fRetornaHojaDeEstilos(pstrNombreHoja);if(oStyleSheet!=null)
{var oReglaCSS=fRetornaReglaCSS(oStyleSheet,pstrNombreRegla)
var strContenidoRegla='display:'+((boolOculto)?'none;':"'';")
if(oReglaCSS==null)
{if(boolEsIExplorer)
{oStyleSheet.addRule(pstrNombreRegla,strContenidoRegla,fRetornaTotalReglasCSS(oStyleSheet)+1);}
else
{oStyleSheet.insertRule(pstrNombreRegla+'{'+strContenidoRegla+'}',fRetornaTotalReglasCSS(oStyleSheet)+1);}
intRpta=1;}}
return(intRpta);}
function fBuscarReglaCSS(strNombreRegla,odocument)
{if(odocument==null)
{odocument=document;}
var oRegla_Rpta=null;var oStyleSheets=odocument.styleSheets;for(var i=0;i<oStyleSheets.length;i++)
{var oRegla=fRetornaReglaCSS(oStyleSheets[i],strNombreRegla)
if(oRegla!=null)
{oRegla_Rpta=oRegla;break;}}
return(oRegla_Rpta);}
function fInsertarReglaCSS(oStyleSheet,strNombreRegla,oRegla)
{var intPosRegla=fRetornaTotalReglasCSS(oStyleSheet)+1;var strContenidoRegla=fRetornaContenidoRegla(oRegla);if(boolEsIExplorer)
{oStyleSheet.addRule(strNombreRegla,strContenidoRegla,intPosRegla);}
else
{oStyleSheet.insertRule(strNombreRegla+'{'+strContenidoRegla+'}',intPosRegla);}}
function fRetornaContenidoRegla(oRegla)
{var strRpta='';var oStyle=oRegla.style;if(oStyle!=null)
{try
{strRpta+=oStyle.cssText;}
catch(e){}}
return strRpta;}
function fVerificarInsertarClaseCSS(strNombreRegla,oReglaCSS,odocument)
{var bool_Rpta=false;if(odocument==null)
{odocument=document;}
var oReglaEncontrada=fBuscarReglaCSS(strNombreRegla,odocument);if(oReglaEncontrada==null)
{var oStyleSheets=odocument.styleSheets;if(oStyleSheets.length>0)
{fInsertarReglaCSS(oStyleSheets[0],strNombreRegla,oReglaCSS)
bool_Rpta=true;}}
return(bool_Rpta);}