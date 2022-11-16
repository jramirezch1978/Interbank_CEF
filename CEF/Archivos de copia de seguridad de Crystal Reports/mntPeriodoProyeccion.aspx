<%@ Import Namespace="CEF.Common.Globals"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntPeriodoProyeccion.aspx.vb" EnableEventValidation="false" Inherits="CEF.WebUI.mntPeriodoProyeccion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntPeriodoProyeccion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Estilos/PagLst.css">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
		<script language="JavaScript" src="../Funciones/UtilAjax.js"></script>
		<script language="javascript" src="../Funciones/jquery.min.js"></script>
		<script language="javascript" src="../Funciones/jquery-ui.min.js"></script>
		<LINK rel="stylesheet" type="text/css" href="../Estilos/jquery-ui.css">
		<style type="text/css">.ui-datepicker-calendar { DISPLAY: none }
		</style>
		<script>
	$(document).ready(function() {
	    $.datepicker.regional['es'] = {
                closeText: 'Cerrar',
                prevText: '&#x3c;Ant',
                nextText: 'Sig&#x3e;',
                currentText: 'Hoy',
                monthNames: ['Enero','Febrero','Marzo','Abril','Mayo','Junio',
                'Julio','Agosto','Septiembre','Octubre','Noviembre','Diciembre'],
                monthNamesShort: ['Ene','Feb','Mar','Abr','May','Jun',
                'Jul','Ago','Sep','Oct','Nov','Dic'],
                dayNames: ['Domingo','Lunes','Martes','Mi&eacute;rcoles','Jueves','Viernes','S&aacute;bado'],
                dayNamesShort: ['Dom','Lun','Mar','Mi&eacute;','Juv','Vie','S&aacute;b'],
                dayNamesMin: ['Do','Lu','Ma','Mi','Ju','Vi','S&aacute;'],
                weekHeader: 'Sm',
                dateFormat: 'mm/yy',
                firstDay: 1,
                isRTL: false,
                showMonthAfterYear: false,
                yearSuffix: ''};
        
		$.datepicker.setDefaults( $.datepicker.regional[ "es" ] );
		$( "#txtDate" ).datepicker({
		    changeMonth: true,
			changeYear: true,
			showButtonPanel : true,
			onClose: function() {
						var iMonth = $("#ui-datepicker-div .ui-datepicker-month :selected").val();
						var iYear = $("#ui-datepicker-div .ui-datepicker-year :selected").val();
						document.getElementById('hidVerifFProyAnio').value = iYear;
						document.getElementById('hidVerifFProyMes').value = iMonth;
						$(this).datepicker('setDate', new Date(iYear, iMonth, 1));
						VerificarFechaProyeccion();
					}
			});
		});
		</script>
		<script language="javascript">
		
			var myhandler = function(strResp){
				//alert(strResp);
				if(strResp == 'True'){
					alert('La fecha ingresada ya existe');
					$("#txtDate").datepicker('setDate', null);
				}
			}
			
			function DoCallBack(url,codmetodizado,mes,anio){
				var objAjax = new Ajax();
				objAjax.addData("codmetodizado",codmetodizado);
				objAjax.addData("mes",mes);
				objAjax.addData("anio",anio);
				objAjax.doPost(url,null,myhandler,'text');
				/*var pageUrl = url + "?codmetodizado=" + codmetodizado + "&mes=" + mes + "&anio=" + anio;
				var xmlRequest = new ActiveXObject("MSXML2.XMLHTTP");
				xmlRequest.open("POST",pageUrl,false);
				xmlRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
				xmlRequest.send(null);
				return xmlRequest;*/
			}
			
			function VerificarFechaProyeccion(){
				var mes           = document.getElementById('hidVerifFProyMes').value;
				var anio		  = document.getElementById('hidVerifFProyAnio').value;
				var codmetodizado = document.getElementById('hidCodMetodizado').value;
				var xmlRequest = DoCallBack('mntPeriodoProyeccionProcess1.aspx',codmetodizado,mes,anio);
				/*
				if(xmlRequest.ResponseText != null){
					if(xmlRequest.ResponseText == 'True'){
						alert('La fecha ingresada ya existe');
						$("#txtDate").datepicker('setDate', null);
					}
				}*/
			}
			
		</script>
		<script language="javascript">
		
			function eval_formula(pobjCtrl){
				var utilidad = document.getElementById('dgrdMnt__ctl4_txtMontoCuenta');			
				var ebitda = document.getElementById('dgrdMnt__ctl7_txtMontoCuenta');
				
				//<I-XT9104 - 09/10/2019>
				var hndUtilidad = document.getElementById('dgrdMnt__ctl4_hndMontoCuenta');			
				var hndEbitda = document.getElementById('dgrdMnt__ctl7_hndMontoCuenta');
				//<F-XT9104 - 09/10/2019>
				
				var ventasnetas = document.getElementById('dgrdMnt__ctl2_txtMontoCuenta');
				var costoventas = document.getElementById('dgrdMnt__ctl3_txtMontoCuenta');
				var gastadmin = document.getElementById('dgrdMnt__ctl5_txtMontoCuenta');
				var otrosingegr = document.getElementById('dgrdMnt__ctl6_txtMontoCuenta');
				var ebitda = document.getElementById('dgrdMnt__ctl7_txtMontoCuenta');
				
				if(pobjCtrl.id == "dgrdMnt__ctl2_txtMontoCuenta" || pobjCtrl.id == "dgrdMnt__ctl3_txtMontoCuenta"){					
					utilidad.value = (!isNaN(parseFloat(ventasnetas.value)) ? parseFloat(ventasnetas.value): 0)  -
									 (!isNaN(parseFloat(costoventas.value)) ? parseFloat(costoventas.value): 0);
					ebitda.value   = (!isNaN(parseFloat(utilidad.value))   ? parseFloat(utilidad.value   ) : 0)  -  
									 (!isNaN(parseFloat(gastadmin.value))  ? parseFloat(gastadmin.value  ) : 0)  + 
									 (!isNaN(parseFloat(otrosingegr.value))? parseFloat(otrosingegr.value) : 0)  ;
				}
				if(pobjCtrl.id == "dgrdMnt__ctl5_txtMontoCuenta" || pobjCtrl.id == "dgrdMnt__ctl6_txtMontoCuenta"){
					ebitda.value   = (!isNaN(parseFloat(utilidad.value))   ? parseFloat(utilidad.value   ) : 0)  -  
									 (!isNaN(parseFloat(gastadmin.value))  ? parseFloat(gastadmin.value  ) : 0)  + 
									 (!isNaN(parseFloat(otrosingegr.value))? parseFloat(otrosingegr.value) : 0)  ;
				}
				
				//<I-XT9104 - 09/10/2019>
				hndUtilidad.value = utilidad.value;
				hndEbitda.value = ebitda.value;
                //<F-XT9104 - 09/10/2019>
			}
					
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
			
			function f_ValidarAnio(){
				var strPatron = /[0-9]/;
				var intCodigo = event.keyCode;
				var strCaracter = (String.fromCharCode(event.keyCode));
				var bolValido = strPatron.test(strCaracter);
				var intPosCaracter;
				if(!bolValido){
					event.returnValue = false;
					return false;
				}
				return true;
			}
			
			function performSave(){
				if(f_validaGrabacion()){
				document.getElementById("<%=btnAccionGrabar.ClientID%>").click();
				window.returnValue = "1";
				window.close();
				}
			}
			
			function f_aprobarProyeccion(){
				if(f_validaGrabacion()){
				document.getElementById("<%=btnAprobarProy.ClientID%>").click();
				window.returnValue = "1";
				window.close();
				}
			}
			function f_validaGrabacion(){
				var fechaProyeccion=document.getElementById('txtDate').value;
				var anioFinanciero=document.getElementById('txtFechaRegistro').value;
				
				if(fechaProyeccion == "" || anioFinanciero == ""){
					alert('Los campos [Fecha de Proyeccion] y [Año de EEFF] son obligatorios');
					return false;
				}
				return true;
			}
			

			
			/*function sleep(milisegundos){
				var inicio= new Date().getTime();
				while((new Date().getTime()-inicio) < milisegundos){}
			}*/
        </script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidRazonSocial" type="hidden" name="hidRazonSocial" runat="server"> <INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server">
			<INPUT id="hidMntAccionPadre" type="hidden" name="hidMntAccionPadre" runat="server">
			<INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">
			<INPUT id="hidCodProyeccion" type="hidden" name="hidCodProyeccion" runat="server">
			<INPUT id="hidVerificarFechaProyeccion" type="hidden" name="VerificarFechaProyeccion" runat="server">
			<input id="hidVerifFProyAnio" type="hidden" runat="server"> <input id="hidVerifFProyMes" type="hidden" name="Hidden1" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="510" bgColor="#ffffff"
				align="left">
				<TBODY>
					<TR>
						<TD height="10" background="../Imagen/bordes/brd_sp.gif" colSpan="3"></TD>
					</TR>
					<TR>
						<TD width="10">&nbsp;</TD>
						<TD vAlign="top" width="510">
							<TABLE border="0" cellSpacing="0" cellPadding="0" width="510" align="center">
								<TR>
									<TD rowSpan="3" width="5"><asp:image id="Image4" runat="server" Width="5px" BorderWidth="0px" Height="51px" ImageUrl="../Imagen/bordes/brd_curva_Sup_Izq_blue.gif"></asp:image></TD>
									<TD class="lightblueborder" width="99%"><asp:image id="Image6" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
									<TD rowSpan="3" width="5"><asp:image id="Image5" runat="server" Width="5px" BorderWidth="0px" Height="51px" ImageUrl="../Imagen/bordes/brd_curva_Sup_Der_blue.gif"></asp:image></TD>
								</TR>
								<TR>
									<TD class="lightbluebg">
										<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" height="29">
											<TR>
												<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; HEIGHT: 29px; PADDING-TOP: 5px"
													class="lightbluebg" noWrap><SPAN class="SearchResultsHeader">Proyecciones</SPAN></TD>
												<TD width="99%">&nbsp;</TD>
												<TD><asp:image id="imgCerrar" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Cerrar.gif"
														CssClass="BotonCerrar" ToolTip="Cerrar"></asp:image></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="lightbluebg">&nbsp;
										<asp:button id="btnAccionGrabar" runat="server" Width="0px" Height="0px" CssClass="Boton" Text="Grabar"></asp:button><asp:button id="btnAprobarProy" runat="server" Width="0px" Height="0px" CssClass="Boton" Text="AprobarProyeccion"></asp:button><asp:button id="btnVerificarFechaProy" Width="0px" Height="0px" CssClass="Boton" Text="VerificarFechaProyeccion"
											Runat="server"></asp:button></TD>
								</TR>
							</TABLE>
							<TABLE border="0" cellSpacing="0" cellPadding="0" width="510" align="center">
								<TBODY>
									<TR>
										<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
										<TD class="lightLTbluebg">
											<TABLE class="Criterio" border="0" cellSpacing="1" cellPadding="0" width="490" align="center">
												<TBODY>
													<TR>
														<TD style="HEIGHT: 1px" colSpan="4" align="left"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
													</TR>
													<TR>
														<TD vAlign="top" colSpan="4" align="right"><asp:panel id="pnlCabMetodizado" runat="server" Width="308px" Height="24px" HorizontalAlign="Right"><INPUT id="BtnValidar" class="boton" onclick="f_aprobarProyeccion();" value="Validar" type="button"
																	runat="server">&nbsp; 
<INPUT id="BtnGrabar" class="boton" onclick="performSave();" value="Grabar" type="button"
																	runat="server">&nbsp; 
                  </asp:panel></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 1px" class="Marco" vAlign="top" width="100%" colSpan="4">
															<TABLE style="WIDTH: 448px" class="Criterio">
																<TR>
																	<TD style="WIDTH: 116px">Razón&nbsp;Social:</TD>
																	<TD><asp:textbox id="txtRazonSocial" runat="server" Width="328px" Height="20px" CssClass="NoActivo"
																			MaxLength="20"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 116px" noWrap>Registrado Por:</TD>
																	<TD noWrap><asp:textbox id="txtCodRegistradoPor" runat="server" Width="72px" Height="20px" CssClass="NoActivo"
																			MaxLength="20"></asp:textbox>&nbsp;
																		<asp:textbox id="txtRegistradoPor" runat="server" Width="216px" Height="20px" CssClass="NoActivo"
																			></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 116px" noWrap>Validado Por:</TD>
																	<TD noWrap><asp:textbox id="txtCodValidadoPor" runat="server" Width="72px" Height="20px" CssClass="NoActivo"
																			MaxLength="20"></asp:textbox>&nbsp;
																		<asp:textbox id="txtValidadoPor" runat="server" Width="216px" Height="20px" CssClass="NoActivo"
																			></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 209px; HEIGHT: 1px" class="Marco" vAlign="top" colSpan="2">
															<TABLE class="Criterio">
																<TR>
																	<TD style="WIDTH: 69px">Fecha de Proyección:</TD>
																	<TD><INPUT style="WIDTH: 80px; HEIGHT: 22px" id="txtDate" onchange="VerificarFechaProyeccion();"
																			size="8" runat="server"></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 69px; HEIGHT: 17px" vAlign="top">Año de EEFF:</TD>
																	<TD style="HEIGHT: 17px" vAlign="top"><asp:textbox id="txtFechaRegistro" onkeypress="f_ValidarAnio();" runat="server" Width="80px"
																			MaxLength="4"></asp:textbox></TD>
																</TR>
															</TABLE>
															<P>&nbsp;</P>
														</TD>
														<TD style="HEIGHT: 250px" class="Marco" vAlign="top" width="60%" colSpan="2">
														    <asp:datagrid style="Z-INDEX: 0" id="dgrdMnt" runat="server" Width="100%" CssClass="GridMnt" scope="col"
																UseAccessibleHeader="True" AutoGenerateColumns="False" CellSpacing="1" CellPadding="1" BorderStyle="None" BorderColor="#3366CC">
																<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
																<EditItemStyle VerticalAlign="Top"></EditItemStyle>
																<ItemStyle Wrap="False" Width="100%" CssClass="Registro"></ItemStyle>
																<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
																<Columns>
																	<asp:TemplateColumn HeaderText="Cuenta">
																		<ItemTemplate>
																			<asp:Label ID="litCuenta" Width="190px" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DESCCUENTA") %>'>
																			</asp:Label>
																			<asp:Label ID="litCodCuenta" Visible="False" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODCUENTA") %>'>
																			</asp:Label>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																	<asp:TemplateColumn HeaderText="Monto">
																		<ItemTemplate>
																			<asp:TextBox CssClass="Activo2" ID="txtMontoCuenta" Width="80px" Runat="server" onchange="eval_formula(this);" onkeypress="f_ValidarNumero(this,12,0);" Text='<%# DataBinder.Eval(Container, "DataItem.IMPORTE","{0:0}") %>'>
																			</asp:TextBox>
																			<asp:HiddenField runat="server" ID="hndMontoCuenta" Value='<%# DataBinder.Eval(Container, "DataItem.IMPORTE","{0:0}") %>'></asp:HiddenField>
																		</ItemTemplate>
																	</asp:TemplateColumn>
																</Columns>
															</asp:datagrid></TD>
													</TR>
													<TR>
														<TD colSpan="4"><IMG border="0" src="../Imagen/bordes/brd_sp.gif" width="0" height="10"></TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
										<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE style="HEIGHT: 6px" border="0" cellSpacing="0" cellPadding="0" width="510" align="center">
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
						<TD width="10">&nbsp;</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
