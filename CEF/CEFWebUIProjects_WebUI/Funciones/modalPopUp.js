//*************************************************
//	Clase que implementa el manejo de una ventana modal
//	Autor		:	Javier Montes
//	Fecha		:	15/04/2008
//*************************************************

var arrModalPopUps=new Array();

function ModalPopUp(strIdElemento, strNombreClaseFondo, strNombreClasePopUp, boolPermitirMoverPopUp)
{
	this.strIdElemento=strIdElemento;
	this.oDivPopUp=document.getElementById(strIdElemento);
	this.oDivProtector=null;
	this.strNombreClaseFondo=strNombreClaseFondo;
	this.strNombreClasePopUp=strNombreClasePopUp;
	this.arrCtrlsDeshabilitados=new Array();
	this.arrDivsProtectores=new Array();
	this.arrSelects=new Array();
	this.boolPermitirMoverPopUp=(boolPermitirMoverPopUp!=null)?boolPermitirMoverPopUp:false;
}

ModalPopUp.prototype.MostrarPopUp = function ()
{
	if (this.oDivPopUp!=null)
	{	
		var odivMaster=this.CrearProtectores();
		var odocument=null;
		var obody=null;
		if(odivMaster!=null)
		{
			odocument=odivMaster.parentNode.document;
		}
		else
		{
			odocument=document;
			var oReglaCSS=null;
			if(this.strNombreClaseFondo!=null)
			{
				 oReglaCSS= fBuscarReglaCSS(this.strNombreClaseFondo);
			}
			odivMaster=this.CrearProtectorSubElemento(odocument,oReglaCSS);
		}
		
		var oAtributo=document.createAttribute('Id');
		oAtributo.value="__$__div_Master_ModalPopUp__$__" + arrModalPopUps.length.toString();
		odivMaster.attributes.setNamedItem(oAtributo);

		var oDivPopUp=this.oDivPopUp;
		
		if (oDivPopUp!=null) 
		{
			oDivPopUp.style.position='absolute';
			if (this.strNombreClasePopUp!=null)
			{
				oDivPopUp.className=this.strNombreClasePopUp;
			}
			this.PosicionarDivPopUp();
			oDivPopUp.style.display='inline';
			oDivPopUp.style.zIndex= odivMaster.style.zIndex+1; // 2000; // odiv.style.zIndex+1;
		}
		
		this.oDivProtector=odivMaster;
		arrModalPopUps.push(this);
	}
}

ModalPopUp.prototype.RedimensionarVentana=function()
{
	var oDivProtector=this.oDivProtector;
	if(oDivProtector!=null)
	{		
		this.AsignarTamanioProtector(oDivProtector.parentNode.document, oDivProtector);
	}
	this.PosicionarDivPopUp();
}

ModalPopUp.prototype.CrearProtectores=function()
{
	var odiv_Rpta=null;
	var oReglaCSS=null;
	var oFrames=null;
	
	var oFrames=top.document.getElementsByTagName("frame");
			
	if(this.strNombreClaseFondo!=null)
	{
		 oReglaCSS= fBuscarReglaCSS(this.strNombreClaseFondo);
	}
	
	if(oFrames!=null)
	{
		var intTotalFrames=oFrames.length;
		
		if(intTotalFrames>0)
		{
			for(var i=0; i<intTotalFrames; i++)
			{
				var odocument=oFrames[i].contentWindow.frames.document;
				var arrIFrames=odocument.getElementsByTagName('iframe');
				
				var boolEsPadre=false;
				for(var j=0; j<arrIFrames.length; j++)
				{
					if(arrIFrames[j].contentWindow.document===document)
					{
						boolEsPadre=true;
						break;
					}
				}
				
				if(boolEsPadre)
				{
					// Si es padre de nuestro contenido actual, creamos los divs en cada uno de los hermanos de nuestro contenido...
					for(var j=0; j<arrIFrames.length; j++)
					{
						if(arrIFrames[j].contentWindow.document)
						{
							var odocumentIFrame=arrIFrames[j].contentWindow.document;
							var odiv=this.CrearProtectorSubElemento(odocumentIFrame, oReglaCSS);
							if(arrIFrames[j].contentWindow.document===document)
							{
								odiv_Rpta=odiv;
							}
						}
					}
				}
				else
				{
					var odocument=oFrames[i].contentWindow.frames.document;
					var odiv=this.CrearProtectorSubElemento(odocument, oReglaCSS);
				}
			}
		}
		else
		{
			odiv_Rpta=this.CrearProtectorSubElemento(document, oReglaCSS)
		}
	}
	else
	{
		odiv_Rpta=this.CrearProtectorSubElemento(document, oReglaCSS)
	}
	
	return(odiv_Rpta);
}

ModalPopUp.prototype.VerificaContieneWindowActual=function(odocument, owindow)
{
	var bool_Rpta=false;
	
	if(odocument===document)
	{
		bool_Rpta=true;
	}
	else
	{
		if(owindow==null)
		{
			owindow=window;
		}
		
		if(odocument.parentWindow===owindow.parent)
		{
			bool_Rpta=true;
		}
		else
		{
			if (!(owindow.parent===owindow))
			{
				this.VerificaContieneWindowActual(odocument, owindow.parent);
			}
		}
	}
	
	return(bool_Rpta);
}

ModalPopUp.prototype.CrearProtectorSubElemento=function(odocument, oReglaCSS)
{
	var odiv_Rpta=null;
	
	if(odocument!=null)
	{
		odiv_Rpta = odocument.createElement('div');
		
		// Primero asignamos la ReglaCSS...
		if(oReglaCSS!=null)
		{
            odiv_Rpta.style.cssText=fRetornaContenidoRegla(oReglaCSS);
		}

		//Luego, asignamos los siguientes elementos del estilo...
		odiv_Rpta.style.position='absolute';
		odiv_Rpta.style.zIndex=100000;
		odiv_Rpta.style.left=0;
		odiv_Rpta.style.top=0;
		
		this.AsignarTamanioProtector(odocument, odiv_Rpta);
		
		this.DeshabilitarControles(odocument);
		
		this.arrDivsProtectores.push(odiv_Rpta);
		
		
		
		
		// var oBody=odocument.body;
		var oBody=null;
		if (odocument.getElementsByTagName('form').length>0)
		{
			oBody=odocument.getElementsByTagName('form')[0];
		}
		else
		{
			oBody=odocument.body;
		}
		
		
		
		
		if(oBody!=null)
		{
			oBody.appendChild(odiv_Rpta);
		}
	}
	
	return(odiv_Rpta);
}

ModalPopUp.prototype.AsignarTamanioProtector=function(odocument, odiv)
{
	if(odiv!=null)
	{
		var oStyle= odiv.style;
		var oBody=odocument.body;
		
		oStyle.height=oBody.clientHeight;
		oStyle.width=oBody.clientWidth;
	}
}

ModalPopUp.prototype.PosicionarDivPopUp=function()
{
	if(this.oDivPopUp!=null)
	{
		var oStyle=this.oDivPopUp.style;
		// var oBody=top.window.document.body;
		var oBody=window.document.body;
		
		// oStyle.top=(oBody.scrollTop)+(oBody.clientHeight/2)-((this.oDivPopUp.style.height.replace('px', ''))/2)-100;
		// oStyle.left=(oBody.scrollLeft)+(oBody.clientWidth/2)-((this.oDivPopUp.style.width.replace('px', ''))/2);
		
		oStyle.top= (oBody.offsetHeight/2) + (oBody.scrollTop) - ((this.oDivPopUp.style.height.replace('px', ''))/2)-100;
		oStyle.left= (oBody.offsetWidth/2) + (oBody.scrollLeft) - ((this.oDivPopUp.style.width.replace('px', ''))/2);
	}
}

ModalPopUp.prototype.OcultarPopUp=function()
{
	if (this.oDivPopUp!=null)
	{
		this.oDivPopUp.style.display='none';
		this.oDivPopUp=null;
		this.RemoverProtectores();
		this.HabilitarControles();
		arrModalPopUps.RemoverElemento(this);
	}
}

ModalPopUp.prototype.RemoverProtectores=function()
{
	if (this.arrDivsProtectores!=null)
	{
		var intTotalProtectores = this.arrDivsProtectores.length;
		
		for(var i=0; i<intTotalProtectores; i++)
		{
			var odiv=this.arrDivsProtectores[i];
			if (odiv!=null)
			{
				var oBody=odiv.parentNode;
				if (oBody!=null)
				{
					oBody.removeChild(odiv);
				}
			}
		}
	}
	this.arrDivsProtectores=new Array();
	this.oDivProtector=null;
}

ModalPopUp.prototype.HabilitarControles=function()
{
	if (this.arrCtrlsDeshabilitados!=null)
	{
		var arrCtrlsDeshabilitados=this.arrCtrlsDeshabilitados;
		
		var intTotalSelects=arrCtrlsDeshabilitados.length;
		
		for(var i=0; i<intTotalSelects; i++)
		{
			try 
			{
				arrCtrlsDeshabilitados[i].style.visibility='visible';
			} catch (e){}
		}
	}
	this.arrCtrlsDeshabilitados=new Array();
	
	if (this.arrSelects!=null)
	{
		var arrSelects=this.arrSelects;
		
		var intTotalSelects=arrSelects.length;
		
		for(var i=0; i<intTotalSelects; i++)
		{
			try 
			{
				arrSelects[i].disabled=false;
			} catch (e) {}
		}
	}
	this.arrSelects=new Array();
}

ModalPopUp.prototype.DeshabilitarControles=function(oElementoDOM)
{
	var arrCtrlsDisponibles;
	
	arrCtrlsDisponibles = oElementoDOM.getElementsByTagName('SELECT');
	this.DeshabilitarArray(arrCtrlsDisponibles);

	arrCtrlsDisponibles = oElementoDOM.getElementsByTagName('OBJECT');
	this.DeshabilitarArray(arrCtrlsDisponibles);
	
	this.DeshabilitarEnIFrames(null, 'SELECT');
	this.DeshabilitarEnIFrames(null, 'OBJECT');
}

ModalPopUp.prototype.DeshabilitarArray=function(arrCtrlsDisponibles)
{
	if(arrCtrlsDisponibles!=null)
	{
		var intTotalCtrls = arrCtrlsDisponibles.length;
		
		var arrElementosInternos = new Array();
		if (intTotalCtrls>0)
		{
		    arrElementosInternos = this.oDivPopUp.getElementsByTagName(arrCtrlsDisponibles[0].tagName);
		}
		var intTotalElementosInternos = arrElementosInternos.length;
	    
		for(var i=0; i<intTotalCtrls; i++)
		{
			if((arrCtrlsDisponibles[i].style.visibility == 'visible')||(arrCtrlsDisponibles[i].style.visibility == '') )
			{
			    var vbolElementoInterno=false;
			    if (arrCtrlsDisponibles[i].id!=null)
			    {
			        for(var j=0; j<intTotalElementosInternos;j++)
			        {
			            vbolElementoInterno=(arrElementosInternos[j].id == arrCtrlsDisponibles[i].id);
                        if(vbolElementoInterno) 
                        { break; }
                    }			            
			    }
			    
			    if (!vbolElementoInterno)
			    {
				    try 
				    {
					    arrCtrlsDisponibles[i].style.visibility='hidden';
				    } catch (e) {}
    				
				    this.arrCtrlsDeshabilitados.push(arrCtrlsDisponibles[i]);
				}
			}
		}
	}
}

ModalPopUp.prototype.DeshabilitarEnIFrames=function(arrFrms, strTagNameDeshabilitar)
{
	var boolLlevaContentWindow=false;
	
	if(arrFrms==null)
	{
		arrFrms=top.document.getElementsByTagName('frame');
		boolLlevaContentWindow=true;
	}
	
	var intTotalFrms=arrFrms.length;
	
	for(var l=0;l<intTotalFrms;l++)
	{
		var arrSelects=null;
		if (boolLlevaContentWindow)
		{
			arrSelects=arrFrms[l].contentWindow.frames.document.getElementsByTagName(strTagNameDeshabilitar);
		}
		else
		{
			arrSelects=arrFrms[l].document.getElementsByTagName(strTagNameDeshabilitar);
		}
		
		this.DeshabilitarArray(arrSelects);
		
		var arrSubFrames=null;
		if (boolLlevaContentWindow)
		{
			arrSubFrames=arrFrms[l].contentWindow.frames;
		}
		else
		{
			arrSubFrames=arrFrms[l].document.getElementsByTagName('frame');
		}
		
		if(arrSubFrames.length>0)
		{
			this.DeshabilitarEnIFrames(arrSubFrames, strTagNameDeshabilitar);
		}
	}
}

//Drag and Drop script - http://www.btinternet.com/~kurt.grigg/javascript
if (document.getElementById)
{	
	(
		function()
		{
			//Stop Opera selecting anything whilst dragging.
			if (window.opera)
			{
				document.write("<input type='hidden' id='Q' value=' '>");
			}

			var n = 500;
			var dragok = false;
			var y,x,d,dy,dx;

			function move(e)
			{
				if (!e) e = window.event;
				if (dragok)
				{
					d.style.left = dx + e.clientX - x + "px";
					d.style.top = dy + e.clientY - y + "px";
					return false;
				}
			}

		
			function down(e)
			{	
				if (!e) e = window.event;
				var temp = (typeof e.target != "undefined")?e.target:e.srcElement;
				
				if(temp!=null)
				{
					var boolElementoEsMovil=fVerificarMoverElemento(temp.id);
					if (!boolElementoEsMovil)
					{
						temp=fRetornaParentMovil(temp);
						if (temp!=null)
						{	
							boolElementoEsMovil=true
						}
					}
					if (boolElementoEsMovil)
					{
						//Guardamos el z-Index actual del elemento...
						var intzIndexOriginal=temp.style.zIndex;
						document.body.style.cursor='move'
						
						if (window.opera)
						{
							document.getElementById("Q").focus();
						}
						dragok = true;
						temp.style.zIndex = n++;
						d = temp;
						dx = parseInt(temp.style.left+0);
						dy = parseInt(temp.style.top+0);
						x = e.clientX;
						y = e.clientY;
						document.onmousemove = move;
						
						//Volvemos a aplicar el z-Index...
						temp.style.zIndex= intzIndexOriginal;
						return false;
					}
				}
			}

			function up()
			{	
				dragok = false;
				document.onmousemove = null;				
				document.body.style.cursor=''
			}
						
			function fRedimensionarPopUps()
			{
				var intTotalPopUps=arrModalPopUps.length;
				for(var i=0; i<intTotalPopUps; i++) 
				{
					try 
					{
						arrModalPopUps[i].RedimensionarVentana();
					} catch (e) {}
			
				}
			}
			
			function fRetornaParentMovil(temp)
			{					
				var oParent=null;
				if(temp!=null)
				{
					if (temp.tagName != "HTML"|"BODY")
					{
						temp = (typeof temp.parentNode != "undefined")?temp.parentNode:temp.parentElement;
						if(temp!=null)
						{
							var boolElementoEsMovil=fVerificarMoverElemento(temp.id);
							if (!boolElementoEsMovil)
							{
								oParent=fRetornaParentMovil(temp)
							}
							else
							{
								oParent=temp;
							}
						}
					}
				}
				return(oParent);
			}
			
			function fVerificarMoverElemento(strIdElemento)
			{
				var bool_Rpta=false;
				var intTotalPopUps=arrModalPopUps.length;
				for(var i=0; i<intTotalPopUps; i++) 
				{
					var _oModalPopUp=arrModalPopUps[i];
					if (_oModalPopUp.strIdElemento==strIdElemento)
					{
						bool_Rpta=_oModalPopUp.boolPermitirMoverPopUp;
						break;
					}
				}
				
				return (bool_Rpta);
			}
			
			document.onmousedown = down;
			document.onmouseup = up;
			window.onresize = fRedimensionarPopUps;
		}
	)();
}

if(typeof Array.prototype.RemoverElemento==='undefined')
{Array.prototype.RemoverElemento=function(oElemento)
{var arrClon=this.Clonar();var intContadorItems=0;for(var i=0;i<arrClon.length;i++)
{if(!(arrClon[i]===oElemento))
{this[intContadorItems]=arrClon[i];this.length--;intContadorItems++;}}}}
if(typeof Array.prototype.RemoverPosicion==='undefined')
{Array.prototype.RemoverPosicion=function(intPosElementoEliminar)
{var arrClon=this.Clonar();var intContadorItems=0;for(var i=0;i<arrClon.length;i++)
{if(i==intPosElementoEliminar)
{this.length--;}
else
{this[intContadorItems]=arrClon[i];intContadorItems++;}}}}
if(typeof Array.prototype.Clonar==='undefined')
{Array.prototype.Clonar=function()
{var arrClon=new Array();for(var i=0;i<this.length;i++)
{arrClon[i]=this[i];}
return(arrClon);}}
if(typeof Array.prototype.ContieneElemento==='undefined')
{Array.prototype.ContieneElemento=function(oElemento)
{var bolRpta=false;for(var i=0;i<this.length;i++)
{if(this[i]===oElemento)
{bolRpta=true; break;}} return bolRpta;}}