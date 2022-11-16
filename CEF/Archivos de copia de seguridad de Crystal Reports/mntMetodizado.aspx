<%@ Import Namespace="CEF.Common.Globals"%>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Register TagPrefix="Module" TagName="Pie" Src="../PagWUC/Pie.ascx" %>
<%@ Register TagPrefix="Module" TagName="Titulo" Src="../PagWUC/Titulo.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntMetodizado.aspx.vb" Inherits="CEF.WebUI.mntMetodizado"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntMetodizado</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
		<script language="JavaScript" src="../Funciones/UtilAjax.js"></script>
		<script language="JavaScript">
		<!--
			function document.onkeypress() {if (event.keyCode == 13) event.returnValue = false;}
		//-->
		</script>
		<script language="JavaScript">
		<!--	        
			function f_ActivaTab(pintTab) {
				var intTabActivo = document.Form1.hidTabActivo.value;
				if (intTabActivo != pintTab) {
					document.Form1.hidTabActivo.value = pintTab;
					document.Form1.hidTabRefrescar.value = pintTab;
					document.Form1.hidMntAccion.value = <%=Int32.Parse(ecMntPage.REFRESCAR)%>;
					document.Form1.submit();
				}
			}
		
			function f_AbrirPagMnt(pstrUrl, pintWidth, pintHeight, pintTab) {
				var objParametro = null;
				var voArgumentos = new Array(objParametro);				
				voArgumentos = f_MskVtnDlg(pstrUrl, voArgumentos, pintWidth, pintHeight);

				// if (voArgumentos == <%=Int32.Parse(ecMntPage.REFRESCAR)%>)
				// {
					document.Form1.hidTabRefrescar.value = document.Form1.hidTabActivo.value;
					document.Form1.hidMntAccion.value = <%=Int32.Parse(ecMntPage.REFRESCAR)%>;
					document.Form1.submit();
				// }
			}
			
			
			function f_AbrirPagMntSupuesto(pstrUrl, pintWidth, pintHeight, pintTab) {
				var objParametro = null;
				var voArgumentos = new Array(objParametro);
				if (f_ValidarMetodizado())
					voArgumentos = f_MskVtnDlg(pstrUrl, voArgumentos, pintWidth, pintHeight);
				else
					alert("<%=ccALERTA_ERROR_CUADRE_EEFF%>");

				if (voArgumentos == <%=Int32.Parse(ecMntPage.REFRESCAR)%>)
				{
					document.Form1.hidTabRefrescar.value = document.Form1.hidTabActivo.value;
					document.Form1.hidMntAccion.value = <%=Int32.Parse(ecMntPage.REFRESCAR)%>;
					document.Form1.submit();
				}
			}

			function f_AbrirSeleccionPeriodo(pstrUrl, pintWidth, pintHeight, pintTab) {
				
				var objParametro = null;
				var voArgumentos = new Array(objParametro);
				voArgumentos = f_MskVtnDlg(pstrUrl, voArgumentos, pintWidth, pintHeight);

				if(voArgumentos != null)
				{
					document.Form1.hidPeriodoFiltrado.value = voArgumentos;
					document.Form1.hidTabRefrescar.value = document.Form1.hidTabActivo.value;
					document.Form1.hidMntAccion.value = <%=Int32.Parse(ecMntPage.REFRESCAR)%>;
					document.Form1.submit();
				}
			}
			
			//Francisco
			
			//--31/05/2012
			function f_AbrirSeleccionProyeccion(pstrUrl,pintWidth,pintHeight,pintTab){
				//alert(pstrUrl);
				var objParametro = null;
				var voArgumentos = new Array(objParametro);
				voArgumentos = f_MskVtnDlg(pstrUrl,voArgumentos,pintWidth,pintHeight);
				
				if(voArgumentos != null){
					//alert(voArgumentos);
					document.getElementById('hidPeriodoProyeccion').value = voArgumentos;
				}
			}
			//--31/05/2012
			
			function f_AbrirMntNota(pstrUrl, pintWidth, pintHeight/*, pintTab*/) {
				
				//Alert('CLICK');
				var objParametro = null;
				var voArgumentos = new Array(objParametro);
				voArgumentos = f_MskVtnDlg(pstrUrl, voArgumentos, pintWidth, pintHeight);
					
				if(voArgumentos != null){
					var ret = voArgumentos.split('*');
					if(ret[1] == 0)
						document.getElementById(ret[0]).src = "../Imagen/iconos/ico_noteadd.png";
					else
						document.getElementById(ret[0]).src = "../Imagen/iconos/ico_note.png";
					}
			}
			
			function f_AbrirResumenEjecutivo(pstrUrl, pintWidth, pintHeight){
				//alert(pstrUrl);
				pstrUrl=pstrUrl+'&intcodmoneda=' + document.getElementById("dropMonedaImpresion").value;
				//alert(document.getElementById("dropMonedaImpresion").value);
				
				var objParametro = null;
				var voArgumentos = new Array(objParametro);
			
				arr = document.getElementById("hidPeriodoFiltrado").value;//.split(';');
				//cad = document.getElementById("hidPeriodoFiltrado").value;
					/*cad="";
					for(var i=0; i<arr.length; i++){
					cad= arr[i] + ";" + cad;
					}*/	
				//alert(cad);
				//alert(arr);				
				//var res= CEF.WebUI.mntMetodizado.validarGeneracionResEjec(cad,document.getElementById("hidCodMetodizado").value).value;	
				var res= CEF.WebUI.mntMetodizado.validarGeneracionResEjec(arr,document.getElementById("hidCodMetodizado").value).value;	
				
				var answer;
				if (res == 0)
				{
					answer=confirm("No se cuenta con el estado financiero del año anterior, el cual es necesario para presentaciones a partir del Comité Central,¿Desea Continuar?");
					if(answer){
						voArgumentos = f_MskVtnDlg(pstrUrl, voArgumentos, pintWidth, pintHeight);
					}
				}
				else{
				
				voArgumentos = f_MskVtnDlg(pstrUrl, voArgumentos, pintWidth, pintHeight);
				}
				
			}
			
			function f_testxxx(){
				alert(
					'hidMntAccion: ' + document.getElementById("hidMntAccion").value + '\n' +
					'hidTabRefrescar: ' + document.getElementById("hidTabRefrescar").value + '\n' +
					'hidTabActivo: ' + document.getElementById("hidTabActivo").value + '\n' +
					'hidCodMetodizado: ' + document.getElementById("hidCodMetodizado").value + '\n' +
					'hidCodCorridaMetodizado: ' + document.getElementById("hidCodCorridaMetodizado").value + '\n' +
					//'hidPeriodoCuenta: ' + document.getElementById("hidPeriodoCuenta").value + '\n' +
					'hidPeriodoFiltrado: ' + document.getElementById("hidPeriodoFiltrado").value + '\n' +
					'hidCuentaLibre: ' + document.getElementById("hidCuentaLibre").value + '\n' +
					'hidIdCtrlActivo: ' + document.getElementById("hidIdCtrlActivo").value + '\n' +
					'hidFormatoNumerico: ' + document.getElementById("hidFormatoNumerico").value + '\n' +
					'hidPageX: ' + document.getElementById("hidPageX").value + '\n' +
					'hidPageY: ' + document.getElementById("hidPageY").value + '\n' +
					'hidDivRecX: ' + document.getElementById("hidDivRecX").value + '\n' +
					'hidDivRecY: ' + document.getElementById("hidDivRecY").value + '\n' +
					'hidPeriodoProyeccion: ' + document.getElementById("hidPeriodoProyeccion").value);
			}
			
			//Fin Francisco

			function f_ObtImporteReconciliado() {
				var strImporteReconciliado = "";
				var e = document.getElementById("hidPeriodoCuenta");
				var arrPeriodoCuenta = e.value.split("|");
				for(var i=0;i<arrPeriodoCuenta.length;i++) {
					e = document.getElementById(arrPeriodoCuenta[i]);
					if ((e!=null) && (e.tagName=="TD")) {
						var arrCtrlInput = e.children.tags("input");
						if (arrCtrlInput != null) {
							var decImporte = parseFloat(arrCtrlInput[0].value);
							var strFuncion = arrCtrlInput[1].value;
							if (!isNaN(decImporte)) {
								strImporteReconciliado += ((strImporteReconciliado!=""?"|":"") + arrPeriodoCuenta[i] + ';' + decImporte.toString() + ';' + strFuncion);
							}
						}
					}
				}
				return (strImporteReconciliado);
			}

			function f_ObtImporteReconciliado_Individual(pintCodPeriodoValidado) {
				var strImporteReconciliado = "";
				var arrPeriodoCuenta = f_RetornaPeriodoCuenta_Individual(pintCodPeriodoValidado);
				if (arrPeriodoCuenta!=null)
				{
					for(var i=0;i<arrPeriodoCuenta.length;i++) {
						var e = document.getElementById(arrPeriodoCuenta[i]);
						if ((e!=null) && (e.tagName=="TD")) {
							var arrCtrlInput = e.children.tags("input");
							if (arrCtrlInput != null) {
								var decImporte = parseFloat(arrCtrlInput[0].value);
								var strFuncion = arrCtrlInput[1].value;
								if (!isNaN(decImporte)) {
									strImporteReconciliado += ((strImporteReconciliado!=""?"|":"") + arrPeriodoCuenta[i] + ';' + decImporte.toString() + ';' + strFuncion);
								}
							}
						}
					}
				}
				return (strImporteReconciliado);
			}

			function f_RetornaPeriodoCuenta_Individual(pintCodPeriodoValidado)
			{
				var arrRpta = new Array();
				
				var e = document.getElementById("hidPeriodoCuenta");
				var arrPeriodoCuenta = e.value.split("|");
				
				for(var i=0;i<arrPeriodoCuenta.length;i++) {
					var arrTmp = arrPeriodoCuenta[i].split(";");
					if (arrTmp[0] == pintCodPeriodoValidado)
					{
						arrRpta.push(arrPeriodoCuenta[i]);
					}
				}
				return (arrRpta);
			}
			
			function f_ObtDescripcionCuentaLibre() {
				var strDescipcionCuentaLibre = "";
				var e = document.getElementById("hidCuentaLibre");
				var arrPeriodoCuenta = e.value.split("|");
				for(var i=0;i<arrPeriodoCuenta.length;i++) {
					e = document.getElementById(arrPeriodoCuenta[i]);
					if ((e!=null) && (e.tagName=="TD")) {
						var arrCtrlInput = e.children.tags("input");
						if (arrCtrlInput != null) {
							var strDescripcion = arrCtrlInput[0].value;
							if ((strDescripcion != null) && (strDescripcion != "")) {
								strDescipcionCuentaLibre += ((strDescipcionCuentaLibre!=""?"|":"") + arrPeriodoCuenta[i] + ';' + strDescripcion);
							}
						}
					}
				}
				//if strDescipcionCuentaLibre != null
				//return (strDescipcionCuentaLibre);
				//else
				//return document.getElementById("hidCuentaLibre").value;
				
				return ( (strDescipcionCuentaLibre != null) ? strDescipcionCuentaLibre : document.getElementById("hidCuentaLibre").value);
			}
			
			function f_ActivarFrecuencia(chkCovenant){
			    
			    var dropMedicion = document.getElementById('<%=ddlMedicionCov.ClientID %>');
			    var vlblFrecuencia = document.getElementById('<%=lblfrecuencia.ClientID %>');
			    
			    if(chkCovenant.checked == true){
			        dropMedicion.style.display = "block";
			        vlblFrecuencia.style.display = "block";
			    }
			    else
			    {
			        dropMedicion.style.display = "none";
			        vlblFrecuencia.style.display = "none";
			    }
			}
					
		//-->
		</script>
		<script language="JavaScript">
		<!--
			function f_SetPosPage() {
				var lngPageX = document.getElementById("hidPageX").value;
				var lngPageY = document.getElementById("hidPageY").value
				window.scrollTo(lngPageX, lngPageY);
			}

			function f_GetPosPage() {
				var lngPageX = document.body.scrollLeft;
				var lngPageY = document.body.scrollTop;
				document.getElementById("hidPageX").value = lngPageX;
				document.getElementById("hidPageY").value = lngPageY;
			}
			
			function f_GetPosDivRec() {
				var lngDivRecX = document.getElementById("divReconciliacion").scrollLeft;
				var lngDivRecY = document.getElementById("divReconciliacion").scrollTop;
				document.getElementById("hidDivRecX").value = lngDivRecX;
				document.getElementById("hidDivRecY").value = lngDivRecY;
			}
			
			function f_SetPosDivRec() {
				var lngDivRecX = document.getElementById("hidDivRecX").value;
				var lngDivRecY = document.getElementById("hidDivRecY").value;
				document.getElementById("divReconciliacion").scrollLeft = lngDivRecX;
				document.getElementById("divReconciliacion").scrollTop = lngDivRecY;
			}
			
			//I-XT9104 - 09/03/2020
		    function f_VerificarTipoDocumento(pdropTipoDocumento)
	        {
				var intTipoDocumento = pdropTipoDocumento.options[pdropTipoDocumento.selectedIndex].value;
				var intEmpresaRelacionada = <%=Int32.Parse(ecTipoDocumentoCliente.EMPRESA_RELACIONADA) %>;
				var oVreqFecPeriodo = document.getElementById('vreqFecPeriodo');
				var oRequiredFieldValidator1 = document.getElementById('RequiredFieldValidator1');
				var oTxtCUCliente = document.getElementById('txtCUCliente');
				var oTxtRUC = document.getElementById('txtRUC');
				var oDropTipoDocComp = document.getElementById('dropTipoDocumentoComp');
				var oTxtRUCComp = document.getElementById('txtRUCComp');
				var bolReadOnly = (intTipoDocumento == intEmpresaRelacionada);
				var oTrTipoDocComp = document.getElementById('trTipoDocumentoComp');
				
					var intDNI = <%=Int32.Parse(ecTipoDocumentoCliente.DNI) %>;
				
				if (intTipoDocumento == intEmpresaRelacionada)
				{
					oVreqFecPeriodo.Enabled = false;
					oRequiredFieldValidator1.Enabled = false;
					oTxtCUCliente.value = '';
					oTxtRUC.value = '';
					oTxtCUCliente.className = 'NoActivo';
					oTxtRUC.className = 'NoActivo';
				}				
				else
				{
					oVreqFecPeriodo.Enabled = true;
					oRequiredFieldValidator1.Enabled = true;
					oTxtCUCliente.className = '';
					oTxtRUC.className = '';
				}
				
				if (intTipoDocumento == intDNI)
				{
					oTrTipoDocComp.style.display = "block";
					oDropTipoDocComp.readOnly = true;
					oTxtRUCComp.className = 'NoActivo';
				}
				else{
				    oTrTipoDocComp.style.display = "none";
				}
				
				oTxtCUCliente.readOnly = bolReadOnly;
				oTxtRUC.readOnly = bolReadOnly;
	        }
	        //F-XT9104 - 09/03/2020
	        
		//-->
		</script>
	</HEAD>
	<body onscroll="javascript:f_GetPosPage();">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> 
			<INPUT id="hidTabRefrescar" type="hidden" name="hidTabRefrescar" runat="server">
			<INPUT id="hidTabActivo" type="hidden" name="hidTabActivo" runat="server"> 
			<INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">
			<INPUT id="hidCodCorridaMetodizado" type="hidden" name="hidCodCorridaMetodizado" runat="server">
			<INPUT id="hidPeriodoCuenta" type="hidden" name="hidPeriodoCuenta" runat="server">
			<INPUT id="hidPeriodoFiltrado" type="hidden" name="hidPeriodoFiltrado" runat="server">
			<INPUT id="hidCuentaLibre" type="hidden" name="hidCuentaLibre" runat="server"> 
			<INPUT id="hidIdCtrlActivo" type="hidden" name="hidIdCtrlActivo">
			<INPUT id="hidFormatoNumerico" type="hidden" name="hidFormatoNumerico"> 
			<INPUT id="hidPageX" type="hidden" value="0" name="hidPageX" runat="server">
			<INPUT id="hidPageY" type="hidden" value="0" name="hidPageY" runat="server"> 
			<INPUT id="hidDivRecX" type="hidden" value="0" name="hidDivRecX" runat="server">
			<INPUT id="hidDivRecY" type="hidden" value="0" name="hidDivRecY" runat="server">
			<INPUT id="hidPeriodoProyeccion" type="hidden" runat="server">
			
			<%--I-XT9104 - 18/02/2020--%>
			<INPUT id="hidCuentaLibreCovenants" type="hidden" name="hidCuentaLibreCovenants" runat="server"> 
			<INPUT id="hidCuentaLibreCuenta" type="hidden" name="hidCuentaLibreCuenta" runat="server"> 
			<%--F-XT9104 - 18/02/2020--%>
			
			<TABLE cellSpacing="0" cellPadding="0" width="760" border="0">
				<TBODY>
					<TR>
						<TD width="100%" colSpan="2">&nbsp;<INPUT id="TestButton" style="VISIBILITY: hidden" onclick="f_testxxx();" type="button"
								value="Button"></TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
								<TR>
									<TD width="5" rowSpan="3"><asp:image id="Image4" runat="server" Width="5px" BorderWidth="0px" Height="51px" ImageUrl="../Imagen/bordes/brd_curva_Sup_Izq_blue.gif"></asp:image></TD>
									<TD class="lightblueborder" width="99%"><asp:image id="Image6" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
									<TD width="5" rowSpan="3"><asp:image id="Image5" runat="server" Width="5px" BorderWidth="0px" Height="51px" ImageUrl="../Imagen/bordes/brd_curva_Sup_Der_blue.gif"></asp:image></TD>
								</TR>
								<TR>
									<TD class="lightbluebg">
										<TABLE height="29" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="lightbluebg" style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; HEIGHT: 29px; PADDING-TOP: 5px"
													noWrap><SPAN class="SearchResultsHeader">Metodizado</SPAN></TD>
												<TD width="99%">&nbsp;</TD>
												<TD><asp:imagebutton id="imgCerrar" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Cerrar.gif"
														ToolTip="Cerrar" CausesValidation="False"></asp:imagebutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="lightbluebg">&nbsp;</TD>
								</TR>
							</TABLE>
							<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
								<TR>
									<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
									<TD class="lightLTbluebg">
										<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="740" align="center" border="0">
											<TR>
												<TD style="HEIGHT: 1px" align="left" colSpan="4"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
											</TR>
											<TR>
												<TD vAlign="top" align="right" colSpan="4">
												    <asp:panel id="pnlCabMetodizado" runat="server" Width="308px" Height="24px" HorizontalAlign="Right">
                                                        <asp:Button id="btnNuevo" runat="server" Width="67px" CausesValidation="False" ToolTip="Ingresar un nuevo metodizado" CssClass="Boton" Text="Nuevo"></asp:Button>&nbsp; 
                                                        <asp:Button id="btnGrabar" runat="server" Width="67px" ToolTip="Grabar cabecera de metodizado" CssClass="Boton" Text="Grabar"></asp:Button>&nbsp; 
                                                        <asp:Button id="btnBuscar" runat="server" Width="67px" CausesValidation="False" CssClass="Boton" Text="Buscar"></asp:Button>
                                                    </asp:panel>
                                                </TD>
											</TR>
											<TR>
												<TD class="Marco" style="HEIGHT: 42px" vAlign="top" width="100%" colSpan="4">
													<TABLE class="Criterio">
														<TR>
															<TD style="WIDTH: 100px">Número Metodizado:</TD>
															<TD style="WIDTH: 100px"><asp:textbox id="txtCodMetodizado" runat="server" Width="90" Height="20px" CssClass="NoActivo"
																	MaxLength="20"></asp:textbox></TD>
															<TD style="WIDTH: 80px">Fecha Ingreso:</TD>
															<TD style="WIDTH: 90px"><asp:textbox id="txtFecReg" runat="server" Width="80px" Height="20px" CssClass="NoActivo"
																	MaxLength="20"></asp:textbox></TD>
															<TD style="WIDTH: 44px">Estado:</TD>
															<TD><asp:textbox id="txtDesEstado" runat="server" Width="136px" Height="20px" CssClass="NoActivo"
																	MaxLength="20"></asp:textbox></TD>
															<TD>&nbsp;</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="Marco" style="WIDTH: 379px; HEIGHT: 1px" vAlign="top" width="379" colSpan="2">
													<TABLE class="Criterio">
														<% If CodPerfil = 1  Then %>
														<tr>
															<TD style="HEIGHT: 19px"><asp:label id="Label1" runat="server" Font-Size="Smaller">Tipo Banca:</asp:label></TD>
															<TD style="WIDTH: 147px; HEIGHT: 19px"><asp:dropdownlist id="ddlTipoBanca" runat="server" Width="120px" Height="24px" Font-Size="11px" Font-Names="tahoma,sans-serif"></asp:dropdownlist></TD>
														</tr>
														<% End If%>
														<TR>
															<TD style="HEIGHT: 19px">Código Unico:</TD>
															<TD style="WIDTH: 147px; HEIGHT: 19px"><asp:textbox id="txtCUCliente" runat="server" Width="112px" Height="20px" MaxLength="10" AutoPostBack="True"></asp:textbox>&nbsp;
																<asp:imagebutton id="ibtnBusCliCU" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Persona.gif"
																	ToolTip="Buscar Cliente" CausesValidation="False" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;
																<asp:requiredfieldvalidator id="vreqFecPeriodo" runat="server" ControlToValidate="txtCUCliente" Display="Dynamic"
																	ErrorMessage="Ingrese el Codigo Unico del cliente" Enabled="False">*</asp:requiredfieldvalidator><INPUT id="hidTipoDocIdentidad_CU" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1"
																	name="hidTipoDocIdentidad_CU" runat="server"> <INPUT id="hidRUC_CU" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hidRUC_CU"
																	runat="server">
															</TD>
														</TR>
														<% If CodPerfil = 1 Or CodPerfil = 7 Or CodPerfil = 8  Then %>
														<tr>
															<TD style="HEIGHT: 19px"><asp:label id="lblSegmento" runat="server" Font-Size="Smaller">Segmento:</asp:label></TD>
															<TD style="WIDTH: 147px; HEIGHT: 19px"><asp:dropdownlist id="ddlSegmento" runat="server" Width="120px" Height="24px" Font-Size="11px" Font-Names="tahoma,sans-serif"></asp:dropdownlist><asp:requiredfieldvalidator id="vreqSegmento" runat="server" ControlToValidate="ddlSegmento" Display="Dynamic"
																	ErrorMessage="Segmento requerido" Enabled="False">*</asp:requiredfieldvalidator></TD>
														</tr>
														<% End If%>
														<TR>
															<TD style="HEIGHT: 14px">Tipo / Documento:</TD>
															<TD style="HEIGHT: 14px">
															    <asp:dropdownlist id="dropTipoDocumento" AutoPostBack="true" runat="server" Width="111px" Height="24px" Font-Size="11px" Font-Names="tahoma,sans-serif"></asp:dropdownlist>&nbsp; /&nbsp;
																<asp:textbox id="txtRUC" runat="server" Width="107px" Height="20px" MaxLength="15" AutoPostBack="True"></asp:textbox>&nbsp;
																<asp:imagebutton id="ibtnBusCliRUC" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Persona.gif"
																	ToolTip="Buscar Cliente" CausesValidation="False" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;
																<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ControlToValidate="txtRUC" Display="Dynamic"
																	ErrorMessage="Ingrese el Numero de Documento">*</asp:requiredfieldvalidator></TD>
														</TR>
														
														<%--TIPO DE DOCUMENTO COMPLEMENTARIO INICIO - XT8442 ADR--%>
														<tr id="trTipoDocumentoComp" runat = "server">
															<td style="HEIGHT: 14px">Tipo / Documento Complementario:</td>
															<td style="HEIGHT: 14px"><asp:dropdownlist id="dropTipoDocumentoComp" runat="server" Width="111px" Height="24px" Font-Size="11px"
																	Font-Names="tahoma,sans-serif" Enabled="False"></asp:dropdownlist>&nbsp;&nbsp;
																<asp:textbox id="txtRUCComp" runat="server" Width="107px" Height="20px" MaxLength="15" AutoPostBack="True" Enabled="False"></asp:textbox></td>															
																<%--<asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ControlToValidate="txtRUCComp" Display="Dynamic"
																	ErrorMessage="Ingrese el Numero de Documento Complementario">*</asp:requiredfieldvalidator></td>--%>
														</tr>
														<%--TIPO DE DOCUMENTO COMPLEMENTARIO FIN - XT8442 ADR--%>
														
														<TR>
															<TD>Razón Social:</TD>
															<TD><asp:textbox id="txtRazonSocial" runat="server" Width="256px" Height="20px" MaxLength="100"></asp:textbox>&nbsp;
																<asp:requiredfieldvalidator id="Requiredfieldvalidator4" runat="server" ControlToValidate="txtRazonSocial" Display="Dynamic"
																	ErrorMessage="Ingrese la Razon Social del Cliente">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD>CIIU:</TD>
															<TD><asp:textbox id="txtCodCIIU" runat="server" Width="50px" Height="20px" CssClass="NoActivo"></asp:textbox>&nbsp;
																<asp:textbox id="txtNombreCIIU" runat="server" Width="160px" Height="20px" CssClass="NoActivo"></asp:textbox>&nbsp;<asp:image id="imgBusCIIU" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Lupa.gif"
																	ToolTip="Buscar CIIU" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ControlToValidate="txtCodCIIU" Display="Dynamic"
																	ErrorMessage="Ingrese el CIIU del cliente">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD>Grupo Económico:</TD>
															<TD><asp:textbox id="txtCodGrupoEconomico" runat="server" Width="50px" Height="20px" CssClass="NoActivo"></asp:textbox>&nbsp;
																<asp:textbox id="txtNombreGrupoEconomico" runat="server" Width="160px" Height="20px" CssClass="NoActivo"></asp:textbox>&nbsp;<asp:image id="imgBusGrupoEconomico" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Lupa.gif"
																	ToolTip="Buscar Grupo Económico" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:requiredfieldvalidator id="RequiredFieldValidator3" runat="server" ControlToValidate="txtCodGrupoEconomico"
																	Display="Dynamic" ErrorMessage="Ingrese el grupo economico">*</asp:requiredfieldvalidator></TD>
														</TR>
														<TR>
															<TD>SBS:</TD>
															<TD><asp:textbox id="txtCodSBS" runat="server" Width="112px" Height="20px" CssClass="NoActivo" 
																	MaxLength="20"></asp:textbox></TD>
														</TR>
														<%--ADD XT8633 17/12/2018 INICIO--%>
														<tr>
														    <td style="height: 24px">Covenants</td>
														    <td>
														        <table class="Criterio">
														            <tr>
														                <td style="height: 24px"><asp:CheckBox ID="chkcovenants" runat="server" Checked="false"></asp:CheckBox>
														                <asp:Image ID="imgRatios" runat="server" ImageAlign="AbsMiddle" CssClass="EfectoImagen" ImageUrl="~/Imagen/iconos/ico_formula_covenant.png" ToolTip="Ver Covenants" Visible = "false"/>
														                <asp:Image ID="imgAsociados" runat="server" ImageAlign="AbsMiddle" CssClass="EfectoImagen" ImageUrl="~/Imagen/iconos/ico_asociados.png" ToolTip="Razón Social Asociada"/>
														                &nbsp;&nbsp;
														                </td>
														                <td>
														                    <asp:Label ID="lblfrecuencia" runat="server" style="display:none">Frecuencia:</asp:Label>
														                </td>
														                <td>
														                    <asp:DropDownList ID="ddlMedicionCov" runat="server" Width="96px" Font-Size="11px" Font-Names="tahoma,sans-serif" style="display:none">
						                                                    </asp:DropDownList>
														                </td>
														            </tr>
														        </table>
														    </td>
														</tr>
														<%--ADD XT8633 17/12/2018 FIN--%>
													</TABLE>
												</TD>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
													<TABLE class="Criterio">
														<TR>
															<TD>Usuario:</TD>
															<TD colSpan="3"><asp:textbox id="txtCodUsuario" runat="server" Width="72px" Height="20px" CssClass="NoActivo"
																	MaxLength="20"></asp:textbox>&nbsp;
																<asp:textbox id="txtNombreUsuario" runat="server" Width="216px" Height="20px" CssClass="NoActivo"
																	></asp:textbox></TD>
														</TR>
														<TR>
															<TD>Analista:</TD>
															<TD colSpan="3"><asp:textbox id="txtCodAnalista" runat="server" Width="72px" Height="20px" CssClass="NoActivo"
																	MaxLength="20"></asp:textbox>&nbsp;
																<asp:textbox id="txtNombreAnalista" runat="server" Width="216px" Height="20px" CssClass="NoActivo"
																	></asp:textbox></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 14px">Ejecutivo:</TD>
															<TD style="HEIGHT: 14px" colSpan="3"><asp:textbox id="txtCodEjecutivo" runat="server" Width="72px" Height="20px" CssClass="NoActivo"
																	MaxLength="20"></asp:textbox>&nbsp;
																<asp:textbox id="txtNombreEjecutivo" runat="server" Width="217" Height="20px" CssClass="NoActivo"
																	></asp:textbox></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 14px">Cifras En:</TD>
															<TD style="HEIGHT: 14px">
															    
															    <asp:dropdownlist id="dropMoneda" AutoPostBack="true" runat="server" Width="96px" Font-Size="11px" Font-Names="tahoma,sans-serif"></asp:dropdownlist>
															</TD>
															<TD style="HEIGHT: 14px">Unidad:</TD>
															<TD style="HEIGHT: 14px"><asp:dropdownlist id="dropUnidad" runat="server" Width="78px" Font-Size="11px" Font-Names="tahoma,sans-serif"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 14px">Impresión:</TD>
															<TD style="HEIGHT: 14px"><asp:dropdownlist id="dropMonedaImpresion" runat="server" Width="96px" Font-Size="11px" Font-Names="tahoma,sans-serif"></asp:dropdownlist></TD>
															<TD style="HEIGHT: 14px"></TD>
															<TD style="HEIGHT: 14px"></TD>
														</TR>
													</TABLE>
													<asp:textbox id="txtMensajeImpresion" runat="server" Width="360px" Height="20px" CssClass="NoActivo"
														ForeColor="Red">Presionar bot&#243;n Grabar (Cabecera) luego de cambiar &quot;Cifras En&quot;/ &quot;Impresi&#243;n&quot;</asp:textbox></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="18" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
											</TR>
											<!-- ------------------------- Inicio Grilla Reconciliación --------------------------- -->
											<% If ( tabActivo = 2 ) Then %>
											<TR>
												<TD width="740" colSpan="4">
													<TABLE height="21" cellSpacing="0" cellPadding="0" width="740" border="0">
														<TR>
															<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
															<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
															<TD class="TabActivo" title="Ver Reconciliación" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
																height="21">&nbsp;Periodos</TD>
															<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
															<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
														</TR>
													</TABLE>
													<TABLE style="BORDER-BOTTOM: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-RIGHT: #a9cfeb 1px solid"
														height="21" cellSpacing="0" cellPadding="0" width="740">
														<TR class="TabBar">
															<TD width="20">&nbsp;</TD>
															<TD noWrap width="75">Num. Registro:</TD>
															<TD width="20"><asp:literal id="ltlNumRegRec" runat="server" Text="0"></asp:literal></TD>
															<% If CodPerfil <> 7 And CodPerfil <> 8  Then %>
															<TD noWrap width="75"><asp:image id="imgProyeccion" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Nuevo.gif"
																	ToolTip="Proyección" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image><asp:hyperlink id="lnkProyeccion" runat="server" ToolTip="Proyección">Proyección</asp:hyperlink></TD>
															<% End If %>
															<TD noWrap width="60"><asp:image id="imgFiltrarPeriodo" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Lupa.gif"
																	ToolTip="Filtrar" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;
																<asp:hyperlink id="lnkFiltrarPeriodo" runat="server" ToolTip="Filtrar">Filtrar</asp:hyperlink></TD>
															<TD noWrap width="60"><asp:image id="imgNuevoPeriodo" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Nuevo.gif"
																	ToolTip="Nuevo" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkNuevoPeriodo" runat="server" ToolTip="Nuevo">Nuevo</asp:hyperlink>
															</TD>
															<TD noWrap width="65"><asp:image id="imgGrabarRecOpe1" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Grabar.gif"
																	ToolTip="Grabar Periodo(s)" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkGrabarRecOpe1" runat="server" ToolTip="Grabar Periodo(s)">Grabar</asp:hyperlink>
															</TD>
															<TD noWrap width="65"><asp:image id="imgGrabarRecOpe2" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Enviar.gif"
																	ToolTip="Enviar" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:linkbutton id="lnkGrabarRecOpe2" runat="server">Enviar</asp:linkbutton>
															</TD>
															<% If CodPerfil <> 7 And CodPerfil <> 8  Then %>
															<TD noWrap width="85"><IMG class="EfectoImagen" id="imgResEjec" onclick="javascript:window.open('../PagRpt/rvwResumenEjecutivo.aspx?');"
																	src="../imagen/iconos/ico_impresora2.gif" align="absMiddle" runat="server">&nbsp;
																<A id="lnkImpResEjec" href="javascript:window.open('../PagRpt/rvwResumenEjecutivo.aspx?');"
																	runat="server">R.Ejecutivo</A>
															</TD>
															<% End If %>
															<TD noWrap width="80"><asp:image id="imgImpRec" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_impresora2.gif"
																	ToolTip="Metodizado" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkImpRec" runat="server" ToolTip="Imprimir">Metodizado</asp:hyperlink>
															</TD>
															<TD noWrap width="70"><asp:image id="imgExpRec" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_HojaExcel.gif"
																	ToolTip="Exportar Metodizado" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkExpRec" runat="server" ToolTip="Exportar Metodizado" NavigateUrl="javascript:window.print()">Exportar</asp:hyperlink>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
													<TABLE class="Criterio" width="100%">
														<TR class="TabBar">
															<TD>Función (<EM>fx</EM>):</TD>
															<TD width="91%"><asp:textbox id="txtFuncionFx" runat="server" Width="91%" CssClass="Activo"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<!-- ------------------------------ Inicio Grilla Reconciliación -------------------------------------- -->
											<TR>
												<TD class="Marco" vAlign="top" width="740" colSpan="4">
													<DIV class="Grid" id="divReconciliacion" style="WIDTH: 740px; HEIGHT: 600px" onscroll="javascript:f_GetPosDivRec();">
													    <asp:datagrid id="dgrdMntRec" runat="server" Width="370px" BorderWidth="1px" CssClass="GridMnt"
															BorderColor="#3366CC" BorderStyle="None" AutoGenerateColumns="False" CellPadding="1" scope="col" UseAccessibleHeader="True" EnableViewState="False">
															<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Top"></EditItemStyle>
															<ItemStyle CssClass="Registro"></ItemStyle>
															<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn HeaderText="Cuenta">
																	<ItemTemplate>
																		<IMG style="CURSOR: hand" id="imgBtnNota" src="../Imagen/iconos/ico_note.png" runat="server">
																		<asp:Label style="CURSOR: hand" id="ltlDescripcion" runat="server" ToolTip="Dar click para ingresar notas a la cuenta" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
																		</asp:Label>
																		<asp:TextBox id="txtDescripcion" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>' CssClass="Activo" MaxLength="100">
																		</asp:TextBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
															</Columns>
															<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
														</asp:datagrid>
													</DIV>
												</TD>
											</TR>
											<% End If %>
											<!-- ------------------------------ Fin Reconciliación -------------------------------------- -->
											<TR>
												<TD colSpan="4"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
								</TR>
							</TABLE>
							<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
								<tbody>
									<TR>
										<TD rowSpan="2"><asp:image id="Image9" runat="server" Width="6px" BorderWidth="0px" Height="6px" ImageUrl="../Imagen/bordes/brd_curva_Inf_Izq_blue.gif"></asp:image></TD>
										<TD class="bottombluebg" width="99%"><asp:image id="Image12" runat="server" Width="1px" Height="5px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
										<TD rowSpan="2"><asp:image id="Image10" runat="server" Width="6px" BorderWidth="0px" Height="6px" ImageUrl="../Imagen/bordes/brd_curva_Inf_Der_blue.gif"></asp:image></TD>
									</TR>
									<TR>
										<TD class="lightblueborder" width="1"><asp:image id="Image13" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
									</TR>
								</tbody>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD colSpan="2"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
					</TR>
				</TBODY>
			</TABLE>
			<asp:panel id="pnlEspera" style="DISPLAY: none" runat="server" Width="301px" Height="70px"
				CssClass="modalPopup">
				<BR>
				<DIV style="WIDTH: 290px; HEIGHT: 50px" id="divEspera">
					<CENTER style="VERTICAL-ALIGN: middle"><BR />
						<asp:Image id="imgEspera" runat="server" ImageUrl="../Imagen/Util/ajax-loader-pik.gif"></asp:Image>&nbsp; 
						Espere un momento, por favor...
						<DIV style="WIDTH: 137px; HEIGHT: 4px"></DIV>
					</CENTER>
				</DIV>
			</asp:panel></form>
		<script src="../Funciones/Css.js" type="text/javascript"></script>
		<script src="../Funciones/modalPopUp.js" type="text/javascript"></script>
		<script defer type="text/javascript">
		<!--
			function f_ValidarNumero(pobjCtrl, pbytPrecisionImporte, pbytEscalaImporte) {
				var strPatron;

				if (pbytEscalaImporte > 0) strPatron = /\-|\.|[0-9]\.?[0-9]{0,3}/;
				else strPatron = /\-|[0-9]/;

				var intCodigo = event.keyCode;
				var strCaracter = (String.fromCharCode(event.keyCode));
				var bolValido = strPatron.test(strCaracter);
				var intPosCaracter;

				if (!bolValido) {
					event.returnValue = false;
					return false;
				} else {
					if (intCodigo == 45 || intCodigo == 46)
						if ((intPosCaracter = pobjCtrl.value.indexOf(strCaracter)) != -1) {
							event.returnValue = false;
							return false;
						}
				}
				return true;
			}

			function f_ValidarIngFx(pobjCtrl) {
				var strPatron = /(|)|\*|\/|\+|\-|\.|[0-9]\.?[0-9]{0,3}/;
				var intCodigo = event.keyCode;
				var strCaracter = (String.fromCharCode(event.keyCode));
				var bolValido = strPatron.test(strCaracter);
				var intPosCaracter;

				if (!bolValido) {
					event.returnValue = false;
					return false;
				}
				return true;
			}

			function f_CalculadoraFx(ptxtFuncionFx) {
				try {
					var strIdImporte = document.getElementById("hidIdCtrlActivo").value;
					var txtImporte = document.getElementById(strIdImporte);
					if (txtImporte != null) {
						var objCellImporte = txtImporte.parentElement;
						var arrCtrlInput = objCellImporte.children.tags("input");
						var strFuncion = ptxtFuncionFx.value;
						if (strFuncion != "" && strFuncion != null) {
							var decValor = eval(strFuncion);
							if (!isNaN(decValor)) {
								var arrValor = objCellImporte.id.split(";");
								var intCodPeriodo = arrValor[0];
								var intCodCuenta = arrValor[1];
								var strFormatoNumerico = document.getElementById("hidFormatoNumerico").value;
								var bytEscala = strFormatoNumerico.split(";")[1];
								decValor = f_RedondearValor(decValor, bytEscala);
								txtImporte.value = decValor.toString();
								arrCtrlInput[1].value = strFuncion;
								txtImporte.focus();
								var intIndice = f_ObtIndicePeriodo(intCodPeriodo);
								if (intIndice >= 0)
									f_CalcularTotales(intIndice);
								return true;
							}
						}
						else {
							if (arrCtrlInput[1].value != "") {
								arrCtrlInput[1].value = "";
								txtImporte.value = "";
							}
							txtImporte.focus();
							return true;
						}
					}
				} catch(e) {
					//alert(e.message);
					return false;
				}
				return false;
			}

			function f_ObtIndicePeriodo(pintCodPeriodo) {
				for(var i=0;i<arrPeriodo.length;i++) {
					if (arrPeriodo[i] == pintCodPeriodo)
						return (i);
				}
				return (-1)
			}

			function f_AsigIdCtrlActivo(pstrIdImporte, pstrIdFuncion, pbytPrecisionImporte, pbytEscalaImporte) {
				document.Form1.hidIdCtrlActivo.value = pstrIdImporte;
				document.Form1.txtFuncionFx.value = document.getElementById(pstrIdFuncion).value;
				document.Form1.hidFormatoNumerico.value = pbytPrecisionImporte.toString() + ';' + pbytEscalaImporte.toString();
				document.getElementById("txtFuncionFx").readOnly = document.getElementById(pstrIdImporte).readOnly;


			}

			function f_ObtValorCuenta(pintCodPeriodo, pintCodCuenta) {
				if (pintCodPeriodo==null) return (0);
				var id = pintCodPeriodo.toString() + ';' + pintCodCuenta.toString();
				var e = document.getElementById(id);
				var et;
				var decValor;
				//alert(id);
				if ((e!=null) && (e.tagName=="TD")) {
					et = e.children.tags("input");
					if (et != null) {
						decValor = parseFloat(et[0].value);
						if (!isNaN(decValor))
							return (decValor);
						else {
							if (pintCodCuenta == 9000) return (-1);
							if (pintCodCuenta == 9100) return (-1);
							if (pintCodCuenta == 9200) return (-1);
							if (pintCodCuenta == 9300) return (-1);
						}
					}
				}
				return (0);
			}

			function f_AsigValorCuenta(pintCodPeriodo, pintCodCuenta, pdecValor, pbytPrecisionImporte, pbytEscalaImporte) {
				var id = pintCodPeriodo.toString() + ';' + pintCodCuenta.toString();
				var e = document.getElementById(id);
				var et;
				if ((e!=null) && (e.tagName=="TD")) {
					et = e.children.tags("input");
					if (et != null) {
						if (!isNaN(pdecValor)) {
							pdecValor = f_RedondearValor(pdecValor, pbytEscalaImporte);
							et[0].value = pdecValor.toString();
						}
					}
				}
			}

			function f_RedondearValor(pdecValor, pbytEscala) {
				return (Math.round(pdecValor*Math.pow(10,pbytEscala))/Math.pow(10,pbytEscala));
			}
		//-->
		</script>
		<script defer type="text/javascript">
			var hand = function(strResp) {
				fOcultarEspera();
				var xmlDoc = strResp.documentElement;
				var intCodError = (xmlDoc.getElementsByTagName('Mensaje')[0])? xmlDoc.getElementsByTagName('Mensaje')[0].getAttribute('CodError'):0;
				var strMensaje = (xmlDoc.getElementsByTagName('Mensaje')[0])?xmlDoc.getElementsByTagName('Mensaje')[0].getAttribute('Descripcion'):'';
				var strCodUsuario = (xmlDoc.getElementsByTagName('CodUsuario')[0])?xmlDoc.getElementsByTagName('CodUsuario')[0].childNodes[0].data:'';
				var strNombreUsuario = (xmlDoc.getElementsByTagName('NombreUsuario')[0])?xmlDoc.getElementsByTagName('NombreUsuario')[0].childNodes[0].data:'';
				var strDesEstado = (xmlDoc.getElementsByTagName('DesEstado')[0])?xmlDoc.getElementsByTagName('DesEstado')[0].childNodes[0].data:'';
				var intCodCorridaMetodizado = (xmlDoc.getElementsByTagName('CodCorridaMetodizado')[0])?xmlDoc.getElementsByTagName('CodCorridaMetodizado')[0].childNodes[0].data:'0';
				
				if (parseInt(intCodCorridaMetodizado)>0)
				{
					document.getElementById('hidCodCorridaMetodizado').value=intCodCorridaMetodizado.toString();
				}
				
				if (intCodError == 0) {
					document.getElementById("txtCodUsuario").value = strCodUsuario;
					document.getElementById("txtNombreUsuario").value = strNombreUsuario;
					document.getElementById("txtDesEstado").value = strDesEstado;
					document.getElementById("hidMntAccion").value = <%=Int32.Parse(ecMntPage.MODIFICAR)%>;
					alert(strMensaje);
				}
				else
					alert(strMensaje);
			}	

			
			function f_CallBackReconciliacion4(pbytEstado) {
				if (confirm("<%=ccALERTA_VALIDA_RECONCILIACION%>")) {
					// var oddlMoneda = document.getElementById("dropMoneda");
					var oddlMoneda = document.getElementById("dropMonedaImpresion");
					var intCodMetodizado = document.getElementById("hidCodMetodizado").value;
					var intCodCorridaMetodizado = document.getElementById("hidCodCorridaMetodizado").value;
					var intCodMonedaCorrida = oddlMoneda.options[oddlMoneda.selectedIndex].value;
					var strPeriodoFiltrado = document.getElementById("hidPeriodoFiltrado").value;
					var strImporteReconciliado = f_ObtImporteReconciliado();
					var strCuentaLibre = f_ObtDescripcionCuentaLibre();
					
					f_ConfirmarIconosPeriodos();
					
					var objAjax = new Ajax();
					objAjax.addData("intCodMetodizado",intCodMetodizado);
					objAjax.addData("intCodCorridaMetodizado",intCodCorridaMetodizado);
					objAjax.addData("intCodMonedaCorrida",intCodMonedaCorrida);
					objAjax.addData("strPeriodoFiltrado",strPeriodoFiltrado);
					objAjax.addData("strImporteReconciliado",strImporteReconciliado);
					objAjax.addData("strCuentaLibre",strCuentaLibre);
					objAjax.addData("bytEstado",pbytEstado);
					objAjax.doPost('./mcbReconciliacion.aspx', null, hand, 'xml');
					fMostrarEspera();
				}
				else
				{
					.3
					()
				}
			}

			function f_CallBackGrabarRecOpe4_Individual(pbytEstado, pbolCambiarIconos, pintCodPeriodoValidado) {
			    //I-XT9104 - 18/02/2020
			    f_ClearValIngresoCuentaLibre();
			    if(!f_ValIngresoCuentaLibre(pintCodPeriodoValidado)){
			        alert("<%=ccALERTA_VALIDACION_CAMPOLIBRE%>");
			        return;
			    }
			    //F-XT9104 - 18/02/2020
			    
				if (f_ValidarMetodizado(pbolCambiarIconos, pintCodPeriodoValidado)){
					if (pbytEstado == 4)
						f_CallBackReconciliacion4_Individual(pbytEstado, pintCodPeriodoValidado);
				}
				else
					alert("<%=ccALERTA_ERROR_CUADRE_EEFF%>");
			}
			
			function f_CallBackReconciliacion4_Individual(pbytEstado, pintCodPeriodoValidado) {
				if (confirm("<%=ccALERTA_VALIDA_RECONCILIACION%>")) {
					// var oddlMoneda = document.getElementById("dropMoneda");
					var oddlMoneda = document.getElementById("dropMonedaImpresion");
					var intCodMetodizado = document.getElementById("hidCodMetodizado").value;
					var intCodCorridaMetodizado = document.getElementById("hidCodCorridaMetodizado").value;
					var intCodMonedaCorrida = oddlMoneda.options[oddlMoneda.selectedIndex].value;
					var strPeriodoFiltrado = document.getElementById("hidPeriodoFiltrado").value;
					var strImporteReconciliado = f_ObtImporteReconciliado();
					var strCuentaLibre = f_ObtDescripcionCuentaLibre();
					
					f_ConfirmarIconosPeriodos(pintCodPeriodoValidado);
					
					var objAjax = new Ajax();
					objAjax.addData("intCodMetodizado",intCodMetodizado);
					// objAjax.addData("strPeriodoFiltrado",strPeriodoFiltrado);
					objAjax.addData("intCodMonedaCorrida",intCodMonedaCorrida);
					objAjax.addData("strPeriodoFiltrado", new String(pintCodPeriodoValidado));
					objAjax.addData("strImporteReconciliado",strImporteReconciliado);
					objAjax.addData("strCuentaLibre",strCuentaLibre);
					objAjax.addData("bytEstado",pbytEstado);
					objAjax.addData("bytPeriodoIndividual",1);
					objAjax.doPost('./mcbReconciliacion.aspx', null, hand, 'xml');
					fMostrarEspera();
				}
				else
				{
					f_RollBackIconosPeriodos(pintCodPeriodoValidado)
				}
			}

			// JAVILA 
			function f_VerificarAbrirReporte(pstrNombre, pstrUrl, pbytEstado)
			{
				if (f_ValidarMetodizado())
				{
					// var oddlMoneda = document.getElementById("dropMoneda");
					var oddlMoneda = document.getElementById("dropMonedaImpresion");

					var intCodMetodizado = document.getElementById("hidCodMetodizado").value;
					var intCodCorridaMetodizado = document.getElementById("hidCodCorridaMetodizado").value;
					var intCodMonedaCorrida = oddlMoneda.options[oddlMoneda.selectedIndex].value;
					var strPeriodoFiltrado = document.getElementById("hidPeriodoFiltrado").value;
					var strImporteReconciliado = f_ObtImporteReconciliado();
					var strCuentaLibre = f_ObtDescripcionCuentaLibre();
					
					var oParametrosExtraResp = new Object;
					oParametrosExtraResp.Nombre = pstrNombre;
					//s23006 10/07/12
					var strCodProyecciones = document.getElementById("hidPeriodoProyeccion").value;
					pstrUrl = pstrUrl + '&strCodProyecciones='+ strCodProyecciones
					//alert(pstrUrl);
					//xt8633
					var strChkCovenant = document.getElementById("chkcovenants").checked;
					pstrUrl = pstrUrl + '&strChkCovenant='+ strChkCovenant
                    // Fin
					oParametrosExtraResp.Url = pstrUrl;
				
					var objAjax = new Ajax();
					objAjax.addData("intCodMetodizado",intCodMetodizado);
					objAjax.addData("intCodCorridaMetodizado",intCodCorridaMetodizado);
					objAjax.addData("intCodMonedaCorrida",intCodMonedaCorrida);
					objAjax.addData("strPeriodoFiltrado",strPeriodoFiltrado);
					objAjax.addData("strImporteReconciliado",strImporteReconciliado);
					objAjax.addData("strCuentaLibre",strCuentaLibre);
					objAjax.addData("bytEstado",pbytEstado);
					objAjax.doPost('./mcbCorridaMetodizado.aspx', null, f_AbrirReporte, 'xml',oParametrosExtraResp);
					fMostrarEspera();
				}
				else
				{
					alert("<%=ccALERTA_ERROR_CUADRE_EEFF%>");
				}
			}

			function f_AbrirReporte(strResp, extraResp) 
			{
				fOcultarEspera();
				var xmlDoc = strResp.documentElement;
				var intCodCorridaMetodizado = (xmlDoc.getElementsByTagName('CodCorridaMetodizado')[0])?xmlDoc.getElementsByTagName('CodCorridaMetodizado')[0].childNodes[0].data:'0';
				if (parseInt(intCodCorridaMetodizado)>0)
				{
					document.getElementById('hidCodCorridaMetodizado').value=intCodCorridaMetodizado.toString();
				}
				f_VtnNoDlg(extraResp.Nombre, extraResp.Url, 800, 600, true, true, null, null);
			}


			function f_Exportar(pstrNombre, pstrUrl) {
				f_VtnNoDlg(pstrNombre, pstrUrl, 800, 600, true, true, null, null);
				fOcultarEspera();
			}



			function f_ConfirmarIconosPeriodos(pintCodPeriodoValidado)
			{
				for(var i=0;(i<arrPeriodo.length);i++)
				{
					var vbolPermitirConfirmar =true;
					
					if (pintCodPeriodoValidado!=null)
					{
						vbolPermitirConfirmar = (arrPeriodo[i] == pintCodPeriodoValidado)
					}
					
					if (vbolPermitirConfirmar)
					{
						var arrImgComentario = document.getElementsByName('imgComentarioPeriodo');
											
						if (arrImgComentario.length>0)
						{
							if(arrImgComentario[i]!=null)
							{
								var oimgComentario = arrImgComentario[i];
								if (oimgComentario.alt)
								{
									oimgComentario.alt = '2';
								}
							}
						}
					}
				}
			}

			function f_RollBackIconosPeriodos(pintCodPeriodoValidado)
			{
				for(var i=0;(i<arrPeriodo.length);i++)
				{
					var vbolPermitirRollBack =true;
					
					if (pintCodPeriodoValidado!=null)
					{
						vbolPermitirRollBack  = (arrPeriodo[i] == pintCodPeriodoValidado);
					}
					
					if (vbolPermitirRollBack)
					{
						var arrImgComentario = document.getElementsByName('imgComentarioPeriodo');
											
						if (arrImgComentario.length>0)
						{
							if(arrImgComentario[i]!=null)
							{
								var oimgComentario = arrImgComentario[i];
								if (oimgComentario.alt)
								{
									if (oimgComentario.alt == '2')
									{
										oimgComentario.src = '../Imagen/iconos/icon_Misc_OK.JPG';
										oimgComentario.title = 'Estado: Validado';
									}
									else
									{
										oimgComentario.src = '../Imagen/iconos/icon_Misc_Error.JPG';
										oimgComentario.title = 'Estado: Pendiente';
									}
								}
							}
						}
					}
				}
			}
			
			function f_CallBackReconciliacion2(pbytEstado) {
				if (confirm("<%=ccALERTA_ENVIA_RECONCILIACION%>")) {
					// var oddlMoneda = document.getElementById("dropMoneda");
					var oddlMoneda = document.getElementById("dropMonedaImpresion");
					
					var intCodMetodizado = document.getElementById("hidCodMetodizado").value;
					var intCodCorridaMetodizado = document.getElementById("hidCodCorridaMetodizado").value;
					var intCodMonedaCorrida = oddlMoneda.options[oddlMoneda.selectedIndex].value;
					var strPeriodoFiltrado = document.getElementById("hidPeriodoFiltrado").value;
					var strImporteReconciliado = f_ObtImporteReconciliado();
					var strCuentaLibre = f_ObtDescripcionCuentaLibre();
					var objAjax = new Ajax();
					objAjax.addData("intCodMetodizado",intCodMetodizado);
					objAjax.addData("intCodCorridaMetodizado",intCodCorridaMetodizado);
					objAjax.addData("intCodMonedaCorrida",intCodMonedaCorrida);
					objAjax.addData("strPeriodoFiltrado",strPeriodoFiltrado);
					objAjax.addData("strImporteReconciliado",strImporteReconciliado);
					objAjax.addData("strCuentaLibre",strCuentaLibre);
					objAjax.addData("bytEstado",pbytEstado);
					objAjax.doPost('./mcbReconciliacion.aspx', null, hand, 'xml')
					fMostrarEspera();
				}
				else
				{
					f_RollBackIconosPeriodos()
				}
			}
				
			// JAVILA (CGI)
			function f_CallBackGrabarRecOpe2(pbytEstado, pbolCambiarIconos) {
			    //I-XT9104 - 18/02/2020
			    if(!f_ValIngresoCuentaLibre(0)){
			        alert("<%=ccALERTA_VALIDACION_CAMPOLIBRE%>");
			        return;
			    }
			    //F-XT9104 - 18/02/2020
			    
				if (f_ValidarMetodizado(pbolCambiarIconos)){
					if (pbytEstado == 4) 
						f_CallBackReconciliacion4(pbytEstado);
					else
						f_CallBackReconciliacion2(pbytEstado);
				}
				else
					alert("<%=ccALERTA_ERROR_CUADRE_EEFF%>");
			}
			
			function f_CallBackReconciliacion(pbytEstado) {
			    //I-XT9104 - 18/02/2020
			    f_ClearValIngresoCuentaLibre();
			    //F-XT9104 - 18/02/2020
			    
				if (confirm("<%=ccALERTA_GRABAR_RECONCILIACION%>")) {
					// var oddlMoneda = document.getElementById("dropMoneda");
					var oddlMoneda = document.getElementById("dropMonedaImpresion");
					
					var intCodMetodizado = document.getElementById("hidCodMetodizado").value;
					var intCodCorridaMetodizado = document.getElementById("hidCodCorridaMetodizado").value;
					var intCodMonedaCorrida = oddlMoneda.options[oddlMoneda.selectedIndex].value;
					var strPeriodoFiltrado = document.getElementById("hidPeriodoFiltrado").value;
					var strImporteReconciliado = f_ObtImporteReconciliado();			
					var strCuentaLibre = f_ObtDescripcionCuentaLibre();					
					var objAjax = new Ajax();
					objAjax.addData("intCodMetodizado",intCodMetodizado);
					objAjax.addData("intCodCorridaMetodizado",intCodCorridaMetodizado);
					objAjax.addData("intCodMonedaCorrida",intCodMonedaCorrida);
					objAjax.addData("strPeriodoFiltrado",strPeriodoFiltrado);
					objAjax.addData("strImporteReconciliado",strImporteReconciliado);
					objAjax.addData("strCuentaLibre",strCuentaLibre);
					objAjax.addData("bytEstado",pbytEstado);
					objAjax.doPost('./mcbReconciliacion.aspx', null, hand, 'xml')
					fMostrarEspera();
				}
			}
			
			function pMostrarCliCUNoEncontrado() 
			{
				var oNoEncontrado = document.getElementById('hidCUClienteNoEncontrado');
				if (oNoEncontrado!=null)
				{ 
					if(oNoEncontrado.value == '1')
					{
						oNoEncontrado.value = '0'
						alert('<%=ccALERTA_REGISTRO_NO_ENCONTRADO%>' + ' correspondiente al codigo unico ingresado.');
					}
				}
			}
			
			function pMostrarCliRUCNoEncontrado() 
			{
				var oNoEncontrado = document.getElementById('hidRUCNoEncontrado');
				if (oNoEncontrado!=null)
				{ 
					if(oNoEncontrado.value == '1')
					{
						oNoEncontrado.value = '0'
						alert('<%=ccALERTA_REGISTRO_NO_ENCONTRADO%>' + ' correspondiente al documento ingresado.');
					}
				}
			}
			
			function fValidarGrabar()
			{
				if (confirm('<%=ccALERTA_AGREGAR%>')) 
				{ 
					document.getElementById('hidMntAccion').value = "'" + String(<%=ecMntPage.AGREGAR%>) + "'"; 
					return(true); 
				} 
				else 
				{ 
					return(false); 
				}
			}
			
			function fActualizarIconoPeriodo(pintIndicePeriodo, pboolValidado) 
			{
					var arrImgComentario = document.getElementsByName('imgComentarioPeriodo');
					var oimgComentario;
					
					if (arrImgComentario.length>0)
					{
						oimgComentario = arrImgComentario[pintIndicePeriodo];
					}
					
					if (oimgComentario!=null)
					{
						if (pboolValidado == true)
						{
							oimgComentario.src = '../Imagen/iconos/icon_Misc_OK.JPG';
							oimgComentario.title = 'Estado: Validado';
						}
						else
						{
							oimgComentario.src = '../Imagen/iconos/icon_Misc_Error.JPG';
							oimgComentario.title = 'Estado: Pendiente';
						}
					}
			}
			
            var oModalEspera;
	        
	        function fMostrarEspera()
	        {
                oModalEspera= new ModalPopUp('pnlEspera', 'modalBackground', 'modalPopup', true);
                if (oModalEspera!=null)
                {oModalEspera.MostrarPopUp(); }

	        }
	        
	        function fOcultarEspera()
	        {
                if (oModalEspera!=null)
                {oModalEspera.OcultarPopUp(); }

	        }
	        
			function f_ValIngresoCuentaLibre(codPeriodo)
			{
			    var result = true;
                var hidCuentaLibreCovenants = document.getElementById("hidCuentaLibreCovenants");
			    var arrCuentaLibreCovenants = hidCuentaLibreCovenants.value.split("|");
			    
				for(var i=0;i<arrCuentaLibreCovenants.length;i++) {
				    var arrCuentaLibre = arrCuentaLibreCovenants[i].split(";");
				    var intCodPeriodo = arrCuentaLibre[0];
				    var intCodCuenta = arrCuentaLibre[1];
				    
				    if(intCodPeriodo == codPeriodo || codPeriodo == 0){
			            e1 = document.getElementById(arrCuentaLibreCovenants[i]);
			            e2 = document.getElementById(intCodCuenta);
    			        
					    if ((e1!=null) && (e1.tagName=="TD")){
					        var arrCtrlInput = e1.children.tags("input");
					        var arrCtrlLabel = e2.children.tags("input");
    					    
						    if (arrCtrlInput != null && arrCtrlLabel != null) {
							    var decImporte = parseFloat(arrCtrlInput[0].value);
							    var strFuncion = arrCtrlInput[1].value;
							    var strDescripcion = arrCtrlLabel[0].value;
    							
							    if(valCuentaLibreCuenta(intCodCuenta, strDescripcion) && isNaN(decImporte)){
						            addClass(e1, "borderRed");
						            result = false;
						        }
						        else {
						            removeClass(e1, "borderRed");
						        }
						    }
					    }
					}
			    }
			    
			    return result;
			}
			
			function f_ClearValIngresoCuentaLibre()
			{
                var hidCuentaLibreCovenants = document.getElementById("hidCuentaLibreCovenants");
			    var arrCuentaLibreCovenants = hidCuentaLibreCovenants.value.split("|");
			    
				for(var i=0;i<arrCuentaLibreCovenants.length;i++) {
			        e = document.getElementById(arrCuentaLibreCovenants[i]);
			        
					if ((e!=null) && (e.tagName=="TD")){
						removeClass(e, "borderRed");
					}
			    }
			}
			
			function hasClass(el, className)
            {
                if (el.classList)
                    return el.classList.contains(className);
                return !!el.className.match(new RegExp('(\\s|^)' + className + '(\\s|$)'));
            }

            function addClass(el, className)
            {
                if (el.classList)
                    el.classList.add(className)
                else if (!hasClass(el, className))
                    el.className += " " + className;
            }

            function removeClass(el, className)
            {
                if (el.classList)
                    el.classList.remove(className)
                else if (hasClass(el, className))
                {
                    var reg = new RegExp('(\\s|^)' + className + '(\\s|$)');
                    el.className = el.className.replace(reg, ' ');
                }
            }
            
            function valCuentaLibreCuenta(cuenta, descripcion) {
                var result = false;
                var hidCuentaLibreCuenta = document.getElementById("hidCuentaLibreCuenta");
			    var arrCuentaLibreCuenta = hidCuentaLibreCuenta.value.split("|");
			    
			    for(var i=0;i<arrCuentaLibreCuenta.length;i++) {
				    var strCuenta = arrCuentaLibreCuenta[i];
				    var arrCuenta = strCuenta.split(";");;
				    var strCodigo = arrCuenta[0];
				    var strDescripcion = arrCuenta[1];
				    
				    if(strCodigo == cuenta && strDescripcion != descripcion)
				        result = true;
			    }
			    
			    return result;
            }
			//F-XT9104 - 18/02/2020
			
        function PopulateDropDownList() {
            //Build an array containing Customer records.
            var customers = [
                { CustomerId: 1, Name: "John Hammond", Country: "United States" },
                { CustomerId: 2, Name: "Mudassar Khan", Country: "India" },
                { CustomerId: 3, Name: "Suzanne Mathews", Country: "France" },
                { CustomerId: 4, Name: "Robert Schidner", Country: "Russia" }
            ];

            var ddlCustomers = document.getElementById("ddlCustomers");

            //Add the Options to the DropDownList.
            for (var i = 0; i < customers.length; i++) {
                var option = document.createElement("OPTION");

                //Set Customer Name in Text part.
                option.innerHTML = customers[i].Name;

                //Set CustomerId in Value part.
                option.value = customers[i].CustomerId;

                //Add the Option element to DropDownList.
                ddlCustomers.options.add(option);
            }
        }


        function myFunction() {
            var select = document.getElementById("mySelect");
            var option = document.createElement("option");
            option.value = '1';
            option.innerHTML = 'item 1';
            select.appendChild(option);
        }

        function myFunction2() {
            var select = document.getElementById("mySelect");
            var hnd = document.getElementById("HDNmySelect");
            
            hnd.value = select.value;
        }

		</script>
	</body>
</HTML>
