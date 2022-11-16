<%@ Import Namespace="CEF.Common.Globals"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntSupuesto.aspx.vb" Inherits="CEF.WebUI.mntSupuesto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntSupuesto</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
		<script language="JavaScript" src="../Funciones/UtilAjax.js"></script>
		<script language="JavaScript">
		<!--
			document.onkeypress = function() {if (event.keyCode == 13) event.returnValue = false;}
			
			document.onkeydown = function() {
				if (event.ctrlKey) {
					event.ctrlkey=0;
					return false; 
				} 
				
				if(window.event && window.event.keyCode == 116){
					window.event.keyCode = 0;
					return false;
				}
			}
		//-->
		</script>
		<script language="JavaScript">
		<!--
			function f_AbrirReporte(pstrNombre, pstrUrl) {
				f_VtnNoDlg(pstrNombre, pstrUrl, 800, 600, true, true, null, null);
			}

			function f_BuscarTextoEnDropList(pobjDropLst, pstrTexto) {
				for(var i=0; i<pobjDropLst.options.length; i++) {
					if (pobjDropLst.options[i].text.toUpperCase() == pstrTexto.toUpperCase()) {
						return(i);
					}
				}
				return(-1);
			}

			function f_ValidaExisteEscenarioDuplicado() 
			{
				var objDropList = document.getElementById("dropSupuesto");
				var objDescripcion = document.getElementById("txtDescripcion");
				if (objDescripcion.value != "") {
					var intIndice = f_BuscarTextoEnDropList(objDropList, objDescripcion.value);
					if (intIndice != -1) {
						var intCodSupuestoSel = objDropList.value;
						var intCodSupuestoBus = objDropList.options[intIndice].value;
						var strMsj = "";
						if (intCodSupuestoBus == 0) strMsj = "Error\nLa descripción de supuesto ó escenario no es valida";
						if (intCodSupuestoBus != intCodSupuestoSel)	strMsj = "Error\nNo se puede duplicar supuesto ó escenario con la misma descripción";
						if (strMsj != "") {
							alert(strMsj);
							objDescripcion.value = "";
							objDescripcion.focus()
							return;
						}
					}
				}
				return;
			}

			function f_ObtImporte() {
				var strValorImporte = "";
				var e = document.getElementById("hidCuentaSupuesto");
				var arrCuenta = e.value.split("|");
				for(var i=0;i<arrCuenta.length;i++) {
					e = document.getElementById(arrCuenta[i]);
					if ((e!=null) && (e.tagName=="TD")) {
						var arrCtrlInput = e.children.tags("input");
						if (arrCtrlInput != null) {
							var decImporte = parseFloat(arrCtrlInput[0].value);
							var strFuncion = arrCtrlInput[1].value;
							if (!isNaN(decImporte)) {
								strValorImporte += ((strValorImporte!=""?"|":"") + arrCuenta[i] + ';' + decImporte.toString() + ';' + strFuncion);
							}
						}
					}
				}
				
				return (strValorImporte);
			}
			
		//-->
		</script>
		<script language="JavaScript">
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
									f_CalcularTotales();
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
				document.Form1.txtFuncionFx.value = document.getElementById(pstrIdFuncion).value
				document.Form1.hidFormatoNumerico.value = pbytPrecisionImporte.toString() + ';' + pbytEscalaImporte.toString();
				document.getElementById("txtFuncionFx").readOnly = document.getElementById(pstrIdImporte).readOnly;
			}
			
			function f_ObtImporteMensaje() {
				document.Form1.hidIdCtrlActivo.value=''
				if (confirm("<%=ccALERTA_AGREGAR_EXISTENTE%>")) {
					var cadena = f_ObtImporte();
					document.Form1.hidIdCtrlActivo.value = cadena;
				}
			}

			function f_ObtValorCuenta(pintCodPeriodo, pintCodCuenta) {
				if (pintCodPeriodo==null) return (0);
				var id = pintCodPeriodo.toString() + ';' + pintCodCuenta.toString();
				var e = document.getElementById(id);
				var et;
				var decValor;
				if ((e!=null) && (e.tagName=="TD")) {
					et = e.children.tags("input");
					if (et != null) {
						decValor = parseFloat(et[0].value);
						if (!isNaN(decValor))
							return (decValor);
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
			
			function f_GetPosDivMnt() {
				var lngDivMntX = document.getElementById("divMnt").scrollLeft;
				var lngDivMntY = document.getElementById("divMnt").scrollTop;
				document.getElementById("hidDivMntX").value = lngDivMntX;
				document.getElementById("hidDivMntY").value = lngDivMntY;
			}
			
			function f_SetPosDivMnt() {
				var lngDivMntX = document.getElementById("hidDivMntX").value;
				var lngDivMntY = document.getElementById("hidDivMntY").value;
				document.getElementById("divMnt").scrollLeft = lngDivMntX;
				document.getElementById("divMnt").scrollTop = lngDivMntY;
			}
		//-->
		</script>
		<script type="text/javascript">
			var hand = function(strResp) {
				var xmlDoc = strResp.documentElement;
				var intCodError = xmlDoc.getElementsByTagName('Mensaje')[0].getAttribute('CodError');
				var strMensaje = xmlDoc.getElementsByTagName('Mensaje')[0].getAttribute('Descripcion');

				if (intCodError == 0)
					alert(strMensaje);
				else
					alert(strMensaje);
			}

			function f_CallBackSupuesto() {
				if (confirm("<%=ccALERTA_GRABAR_SUPUESTO%>")) {
					var intCodSupuesto = document.getElementById("hidCodSupuesto").value;
					var dteFecPeriodo = document.getElementById("txtFecPeriodo").value;
					var bytNumeroProyectado = document.getElementById("dropNumeroProyectado").value;
					var strImporteSupuesto = f_ObtImporte();
					var intMntAccion = <%=Int32.Parse(ecMntPage.AGREGAR)%>;
					
					/*alert(intCodSupuesto);
					alert(dteFecPeriodo);
					alert(bytNumeroProyectado);
					alert(strImporteSupuesto);
					alert(intMntAccion);*/
					
					var objAjax = new Ajax();
					objAjax.addData("intCodSupuesto",intCodSupuesto);
					objAjax.addData("dteFecPeriodo",dteFecPeriodo);
					objAjax.addData("bytNumeroProyectado",bytNumeroProyectado);
					objAjax.addData("strImporteSupuesto",strImporteSupuesto);
					objAjax.doPost('./mcbSupuesto.aspx', null, hand, 'xml')
				}
			}
			
		</script>
	</HEAD>
	<body onscroll="javascript:f_GetPosPage();" MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT id="hidCodSupuesto" type="hidden" name="hidCodSupuesto" runat="server">
			<INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">
			<INPUT id="hidCodPeriodo" type="hidden" name="hidCodPeriodo" runat="server"> <INPUT id="hidCodPeriodoAnterior" type="hidden" name="hidCodPeriodoAnterior" runat="server">
			<INPUT id="hidCuentaSupuesto" type="hidden" name="hidCuentaSupuesto" runat="server">
			<INPUT id="hidIdCtrlActivo" type="hidden" name="hidIdCtrlActivo"> <INPUT id="hidFormatoNumerico" type="hidden" name="hidFormatoNumerico">
			<INPUT id="hidPageX" type="hidden" value="0" name="hidPageX" runat="server"> <INPUT id="hidPageY" type="hidden" value="0" name="hidPageY" runat="server">
			<INPUT id="hidDivMntX" type="hidden" value="0" name="hidDivMntX" runat="server">
			<INPUT id="hidDivMntY" type="hidden" value="0" name="hidDivMntY" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" align="left" bgColor="#ffffff"
				border="0">
				<TR>
					<TD background="../Imagen/bordes/brd_sp.gif" colSpan="3" height="10"></TD>
				</TR>
				<TR>
					<TD width="10">&nbsp;</TD>
					<TD vAlign="top" width="760">
						<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
							<TR>
								<TD width="5" rowSpan="3"><asp:image id="Image4" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Izq_blue.gif"
										Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
								<TD class="lightblueborder" width="99%"><asp:image id="Image6" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
										Width="1px"></asp:image></TD>
								<TD width="5" rowSpan="3"><asp:image id="Image5" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Der_blue.gif"
										Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
							</TR>
							<TR>
								<TD class="lightbluebg">
									<TABLE height="29" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="lightbluebg" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 29px"
												noWrap><SPAN class="SearchResultsHeader">Supuestos</SPAN></TD>
											<TD width="99%">&nbsp;</TD>
											<TD><asp:image id="imgCerrar" runat="server" ImageUrl="../Imagen/iconos/ico_Cerrar.gif" BorderWidth="0px"
													ToolTip="Cerrar" CssClass="BotonCerrar"></asp:image></TD>
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
								<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
										Width="1px"></asp:image></TD>
								<TD class="lightLTbluebg">
									<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="740" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 1px" align="left" colSpan="4"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="right" colSpan="4"><asp:panel id="pnlCabMetodizado" runat="server" Height="24px" Width="308px" HorizontalAlign="Right">&nbsp; 
<asp:Button id="btnNuevo" runat="server" Width="67px" CssClass="Boton" ToolTip="Nuevo Supuesto"
														CausesValidation="False" Text="Nuevo"></asp:Button>&nbsp; 
<asp:Button id="btnGrabar" runat="server" Width="67px" CssClass="Boton" ToolTip="Grabar supuesto"
														Text="Grabar"></asp:Button>&nbsp; 
<asp:Button id="btnEliminar" runat="server" Width="67px" CssClass="Boton" ToolTip="Eliminar supuesto"
														Text="Eliminar"></asp:Button></asp:panel></TD>
										</TR>
										<TR>
											<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
												<TABLE class="Criterio">
													<TR>
														<TD style="WIDTH: 65px">Razón&nbsp;Social:</TD>
														<TD style="WIDTH: 100px"><asp:textbox id="txtRazonSocial" runat="server" Height="20px" Width="328px" CssClass="NoActivo"
																MaxLength="20"></asp:textbox></TD>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
												<TABLE class="Criterio">
													<TR>
														<TD>Fecha de Periodo:</TD>
														<TD><asp:textbox id="txtFecPeriodo" runat="server" Height="20px" Width="80px" CssClass="NoActivo"
																></asp:textbox></TD>
													</TR>
													<TR>
														<TD>Tipo EEFF:</TD>
														<TD style="HEIGHT: 17px" vAlign="top"><asp:textbox id="txtDesTipoEeff" runat="server" Height="20px" Width="233" CssClass="NoActivo"
																></asp:textbox></TD>
													</TR>
													<TR>
														<TD>Auditor:</TD>
														<TD style="HEIGHT: 23px"><asp:textbox id="txtDesAuditor" runat="server" Height="20px" Width="233" CssClass="NoActivo"
																></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
											<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
												<TABLE class="Criterio">
													<TR>
														<TD>Supuestos:</TD>
														<TD noWrap colSpan="3"><asp:dropdownlist id="dropSupuesto" runat="server" Width="256px" AutoPostBack="True" Font-Names="Tahoma,sans-serif"
																Font-Size="12px"></asp:dropdownlist>&nbsp;
															<asp:requiredfieldvalidator id="vreqSupuesto" runat="server" ErrorMessage="Seleccionar un supuesto" Display="Dynamic"
																ControlToValidate="dropSupuesto">*</asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 23px">Descripción:</TD>
														<TD style="HEIGHT: 23px" noWrap colSpan="3"><asp:textbox id="txtDescripcion" runat="server" Height="20px" Width="256px"></asp:textbox>&nbsp;
															<asp:requiredfieldvalidator id="vreqDescripcion" runat="server" ErrorMessage="Ingrese la descripción del escenario"
																Display="Dynamic" ControlToValidate="txtDescripcion">*</asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD>Proyecciones:</TD>
														<TD style="WIDTH: 77px"><asp:dropdownlist id="dropNumeroProyectado" runat="server" Width="56px" Font-Names="Tahoma,sans-serif"
																Font-Size="12px"></asp:dropdownlist>&nbsp;
															<asp:requiredfieldvalidator id="vreqNumeroProyectado" runat="server" ErrorMessage="Seleccionar el numero de proyecciones"
																Display="Dynamic" ControlToValidate="dropNumeroProyectado">*</asp:requiredfieldvalidator></TD>
														<TD style="WIDTH: 44px">Moneda:</TD>
														<TD style="WIDTH: 135px" noWrap><asp:textbox id="txtMoneda" runat="server" Height="20px" Width="40px" CssClass="NoActivo"></asp:textbox>&nbsp;-
															<asp:textbox id="txtUnidad" runat="server" Height="20px" Width="71px" CssClass="NoActivo"></asp:textbox>&nbsp;
															<asp:requiredfieldvalidator id="Requiredfieldvalidator1" runat="server" ErrorMessage="Ingresar descripción de supuesto"
																Display="Dynamic" ControlToValidate="txtMoneda">*</asp:requiredfieldvalidator></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG height="18" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
										</TR>
										<TR>
											<TD width="740" colSpan="4">
												<TABLE height="21" cellSpacing="0" cellPadding="0" width="740" border="0">
													<TR>
														<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
														<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
														<TD class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
															height="21">&nbsp;Proyecciones&nbsp;</TD>
														<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
														<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
													</TR>
												</TABLE>
												<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
													height="21" cellSpacing="0" cellPadding="0" width="740">
													<TR class="TabBar">
														<TD width="100">&nbsp;</TD>
														<TD noWrap width="80">Num. Registro:</TD>
														<TD width="100"><asp:label id="lblNumReg" runat="server" Width="98px"></asp:label></TD>
														<TD noWrap width="120">&nbsp;</TD>
														<TD noWrap width="90"><asp:image id="imgGrabarSptoProy" runat="server" ImageUrl="../imagen/iconos/ico_grabar.gif"
																BorderWidth="0px" ToolTip="Grabar Supuesto Proyectado" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkGrabarSptoProy" runat="server" ToolTip="Grabar Supuesto Proyectado" NavigateUrl="javascript:window.print()">Grabar</asp:hyperlink>
														</TD>
														<TD noWrap width="90"><asp:image id="imgImprimir" runat="server" ImageUrl="../imagen/iconos/ico_impresora2.gif" BorderWidth="0px"
																ToolTip="Imprimir" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkImprimir" runat="server" ToolTip="imprimir" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
														</TD>
														<TD noWrap width="90"><asp:image id="imgExpSupuesto" runat="server" ImageUrl="../Imagen/iconos/ico_HojaExcel.gif"
																BorderWidth="0px" ToolTip="Exportar Supuesto" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkExpSupuesto" runat="server" ToolTip="Exportar Supuesto" NavigateUrl="javascript:window.print()">Supuesto</asp:hyperlink>
														</TD>
														<TD noWrap width="70"><asp:image id="imgExpFlujoProyectado" runat="server" ImageUrl="../Imagen/iconos/ico_HojaExcel.gif"
																BorderWidth="0px" ToolTip="Exportar Flujo Proyectado" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkExpFlujoProyectado" runat="server" ToolTip="Exportar Flujo Proyectado" NavigateUrl="javascript:window.print()">Flujo</asp:hyperlink>
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
										<!-- ------------------------------ Inicio Grilla Supuesto -------------------------------------- -->
										<TR>
											<TD class="Marco" vAlign="top" width="740" colSpan="4">
												<DIV class="Grid" id="divMnt" style="WIDTH: 740px; HEIGHT: 600px" onscroll="javascript:f_GetPosDivMnt();"><asp:datagrid id="dgrdMnt" runat="server" BorderWidth="1px" Width="310px" CssClass="GridMnt" EnableViewState="False"
														scope="col" UseAccessibleHeader="True" AutoGenerateColumns="False" CellPadding="2" BorderStyle="None" BorderColor="#3366CC">
														<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
														<EditItemStyle VerticalAlign="Top"></EditItemStyle>
														<ItemStyle CssClass="Registro"></ItemStyle>
														<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
														<Columns>
															<asp:BoundColumn DataField="Descripcion" HeaderText="Cuenta">
																<HeaderStyle Width="310px"></HeaderStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
										Width="1px"></asp:image></TD>
							</TR>
						</TABLE>
						<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
							<tbody>
								<TR>
									<TD rowSpan="2"><asp:image id="Image9" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Inf_Izq_blue.gif"
											Height="6px" BorderWidth="0px" Width="6px"></asp:image></TD>
									<TD class="bottombluebg" width="99%"><asp:image id="Image12" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="5px"
											Width="1px"></asp:image></TD>
									<TD rowSpan="2"><asp:image id="Image10" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Inf_Der_blue.gif"
											Height="6px" BorderWidth="0px" Width="6px"></asp:image></TD>
								</TR>
								<TR>
									<TD class="lightblueborder" width="1"><asp:image id="Image13" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px"
											BorderWidth="0px" Width="1px"></asp:image></TD>
								</TR>
							</tbody>
						</TABLE>
					</TD>
					<TD width="10">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
