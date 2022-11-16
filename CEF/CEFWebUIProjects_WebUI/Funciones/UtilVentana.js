/*------------------------------------------------------------------------------------
* Archivo: UtilVentana.js
* Descripcion: Funciones para el control de ventanas modal y modales
* Autor: Luís A. Mascaro Jácome
* Fecha: 15/09/2005
*------------------------------------------------------------------------------------*/

function f_VtnNoDlg(pNombre, pUrl, pWidth, pHeight, pIndScrollbars, pIndResizable, pLeft, pTop)
{
	pLeft = ((pLeft==null)?((window.screen.width - pWidth) / 2):pLeft);
	pTop = ((pTop==null)?((window.screen.height - pHeight) / 2):pTop);

	var win = window.open(pUrl,
		pNombre, 
		'width=' + pWidth + ', height=' + pHeight + ', ' +
		'left=' + pLeft + ', Top=' + pTop + ', ' +
		'location=no, menubar=no, status=no, toolbar=no, ' +
		'scrollbars=' + (pIndScrollbars==true?'yes, ':'no, ') +
		'resizable=' + (pIndResizable==true?'yes':'no') );
	win.resizeTo(pWidth, pHeight);
	win.focus();
}

function f_VtnExcel(pUrl, pWidth, pHeight, pIndScrollbars, pIndResizable)
{
	pWidth += 32;
	pHeight += 96;
	var win = window.open( pUrl,
		'popup', 
		'width=' + pWidth + ', height=' + pHeight + ', ' +
		'location=no, menubar=yes, status=yes, toolbar=yes, ' +
		'scrollbars=' + (pIndScrollbars==true?'yes, ':'no, ') +
		'resizable=' + (pIndResizable==true?'yes':'no') );
	win.resizeTo(pWidth, pHeight);
	win.focus();
}

function f_MskVtnDlg(pUrl, pArgumentos, pWidth, pHeight)
{
	voUrl = new String(pUrl);
	voUrl = voUrl.replace("&amp;", "&");

	var voConfiguracionPagina = 'center:yes;resizable:no;scroll:no;help:no;status:no;dialogWidth:'+pWidth+'px;dialogHeight:'+pHeight+'px';
	var voUrl = 'MaskWindowDialogo.aspx?pvSrc=' + voUrl.toString() + '&pvWidth='+pWidth+'&pvHeight='+pHeight;
	pArgumentos = window.showModalDialog(voUrl.toString(), pArgumentos, voConfiguracionPagina);
	return (pArgumentos)
}

function f_AbrirCalendario(pTxtFecha)
{
	var voArgumentos = null;
	voArgumentos = f_MskVtnDlg('consCalendario.aspx', voArgumentos, 225, 248);

	if(voArgumentos != null)
	{
		document.getElementById(pTxtFecha).value = voArgumentos[0];
	}
}

function f_AbrirBusGen(pUrl, pTxtCodigo, pTxtDescripcion)
{
	var voParametro = null;
	var voArgumentos = new Array(voParametro);
	voArgumentos = f_MskVtnDlg(pUrl, voArgumentos, 490, 610);

	if(voArgumentos != null)
	{
		document.getElementById(pTxtCodigo).value = voArgumentos[0];
		document.getElementById(pTxtDescripcion).value = voArgumentos[1];
	}
}

function f_StrTrim(pstrValor)
{
	return pstrValor.replace(/^\s*|\s*$/g,"");
}
