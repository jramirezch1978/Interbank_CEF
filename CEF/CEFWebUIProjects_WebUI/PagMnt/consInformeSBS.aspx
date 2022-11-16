<%@ Page Language="vb" AutoEventWireup="false" Codebehind="consInformeSBS.aspx.vb" Inherits="CEF.WebUI.consInformeSBS"%>
<%@ Import Namespace="CEF.Common.Globals"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>consInformeSBS</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
		<script language="JavaScript" src="../Funciones/UtilFecha.js"></script>
		<script language="JavaScript">
		<!--
			function document.onkeypress() {if (event.keyCode == 13) event.returnValue = false;}
		//-->
		</script>
		<script language="JavaScript">	
			function f_AbrirReporte(pstrNombre, pstrUrl) {
				f_VtnNoDlg(pstrNombre, pstrUrl, 800, 600, true, true, null, null);
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="760" border="0">
				<TBODY>
					<TR>
						<TD width="100%" colSpan="2">&nbsp;</TD>
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
												<TD class="lightbluebg" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 29px"
													noWrap><SPAN class="SearchResultsHeader"> Informe&nbsp;SBS (Expresado en MILES de 
														SOLES / VALIDADOS)</SPAN></TD>
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
												<TD vAlign="top" align="right" colSpan="4"><asp:panel id="pnlCabMetodizado" runat="server" Width="308px" Height="24px" HorizontalAlign="Right">
<asp:Button id="btnBuscar" runat="server" Width="67px" ToolTip="Iniciar busqueda" CssClass="Boton"
															Text="Busqueda"></asp:Button>&nbsp; 
<asp:Button id="btnInicializar" runat="server" Width="67px" CssClass="Boton" Text="Inicializar"></asp:Button></asp:panel></TD>
											</TR>
											<!--PANTALLA-->
											<TR>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
													<TABLE class="Criterio">
														<TR>
															<TD style="HEIGHT: 23px">Fecha Periodo:</TD>
															<TD style="HEIGHT: 14px"><asp:textbox id="txtFecPeriodo" runat="server" Width="80px" Height="20px" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgFecPeriodo" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Calendario.gif"
																	ToolTip="Seleccionar Periodos" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:requiredfieldvalidator id="vreqFecPeriodo" runat="server" ErrorMessage="Seleccione Periodo" ControlToValidate="txtFecPeriodo"
																	Display="Dynamic">*</asp:requiredfieldvalidator></TD>
														</TR>
													</TABLE>
												</TD>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
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
																height="21">
																&nbsp;Empresas&nbsp;</TD>
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
															<TD width="140">&nbsp;</TD>
															<TD noWrap width="90">
															</TD>
															<TD noWrap width="90"><asp:image id="imgExpExcel" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_HojaExcel.gif"
																	ToolTip="Exportar a Excel" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkExpExecel" runat="server" ToolTip="Exportar a Excel" NavigateUrl="javascript:window.print()">Exportar</asp:hyperlink>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<!-- ------------------------------ Inicio Grilla Empresas por CIIU -------------------------------------- -->
											<TR>
												<TD class="Marco" vAlign="top" width="740" colSpan="4">
													<DIV class="Grid" id="divComercialProp" style="WIDTH: 740px; HEIGHT: 616px">
														<asp:datagrid id="dgrdMnt" runat="server" Width="1870px" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False"
															UseAccessibleHeader="True" scope="col" PageSize="20" AllowPaging="True" CssClass="GridMnt"
															BorderStyle="None" BorderColor="#3366CC">
															<FooterStyle CssClass="PieRegistro"></FooterStyle>
															<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Top"></EditItemStyle>
															<ItemStyle CssClass="Registro"></ItemStyle>
															<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
															<Columns>
																<asp:BoundColumn DataField="CUCliente" HeaderText="C&#243;digo Unico">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle Wrap="False"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="RazonSocial" HeaderText="Raz&#243;n Social">
																	<HeaderStyle Wrap="False" Width="180px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Left"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CodSBS" HeaderText="C&#243;digo SBS">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="RUC" HeaderText="RUC">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CodCIIU" HeaderText="C&#243;digo CIIU">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CodTipoEeff" HeaderText="Tipo">
																	<HeaderStyle Width="50px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Disponible" HeaderText="Disponible">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CtasCobrarCom" HeaderText="Cuenta por Cobrar Comerciales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Existencias" HeaderText="Existencias">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="ActivoCorr" HeaderText="Activo Corriente">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="ActivoFijNeDep" HeaderText="Activo Fijo Neto de Depreciaci&#243;n">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Intangibles" HeaderText="Intangibles">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="OtrasCtasActiv" HeaderText="Otras Cuentas del Activo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="ActivosTotales" HeaderText="Activos Totales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="SobgirDeuCorPl" HeaderText="Sobregiros y Deuda a Corto Plazo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PorCorrDeudaLP" HeaderText="Porci&#243;n Corriente de la Deuda a Largo Plazo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CtasPagarComer" HeaderText="Cuentas por Pagar Comerciales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PasivoCorr" HeaderText="Pasivo Corriente">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="DeudaLargoPla" HeaderText="Deuda a Largo Plazo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="OtrasCtasPasiv" HeaderText="Otras Cuentas del Pasivo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PasivosTotales" HeaderText="Pasivos Totales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Capital" HeaderText="Capital">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="ResulAcumulado" HeaderText="Resultados Acumulados">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PatrimNetoEmpr" HeaderText="Patrimonio Neto de la Empresa">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Ventas" HeaderText="Ventas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="OtrosIngresosOp" HeaderText="Otros Ingresos Operacionales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CostoVentas" HeaderText="Costo de Ventas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GasOpAdmVtas" HeaderText="Gastos de Operaci&#243;n Administrativos y de Venta">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="IngFinan" HeaderText="Ingresos Financieros">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="GastFinan" HeaderText="Gastos Financieros">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="OtrosIngNeto" HeaderText="Otros Ingresos Netos">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="ImpuestRenta" HeaderText="Impuesto a la Renta">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="UtilNeta" HeaderText="Utilidad Neta">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Contingente" HeaderText="Contingente">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="DepAmortiza" HeaderText="Depreciaci&#243;n y Amortizaci&#243;n">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Dividendos" HeaderText="Dividendos">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="InverCapital" HeaderText="Inversiones de Capital">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="OpeMomedaE" HeaderText="Operaciones en Moneda Extranjera">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PosicionCam" HeaderText="Posici&#243;n de Cambio">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PorcenIngME" HeaderText="% de Ingreso en Moneda Extranjera">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PorcenGasME" HeaderText="% Gasto en Moneda Extranjera">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PasivoCorrME" HeaderText="Pasivo Corriente en Moneda Extranjera">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="PorcenDevalMax" HeaderText="% Devaluación Máxima (apreciación máxima)" DataFormatString="{0:N2}">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Mes" HeaderText="MES">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
															</Columns>
															<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
														</asp:datagrid>
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
											</TR>
											<!--PANTALLA-->
										</TABLE>
									</TD>
									<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
								</TR>
							</TABLE>
							<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
								<tbody>
									<TR>
										<TD rowSpan="2" style="HEIGHT: 12px"><asp:image id="Image9" runat="server" Width="6px" BorderWidth="0px" Height="6px" ImageUrl="../Imagen/bordes/brd_curva_Inf_Izq_blue.gif"></asp:image></TD>
										<TD class="bottombluebg" width="99%"><asp:image id="Image12" runat="server" Width="1px" Height="5px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
										<TD rowSpan="2" style="HEIGHT: 12px"><asp:image id="Image10" runat="server" Width="6px" BorderWidth="0px" Height="6px" ImageUrl="../Imagen/bordes/brd_curva_Inf_Der_blue.gif"></asp:image></TD>
									</TR>
									<TR>
										<TD class="lightblueborder" width="1" style="HEIGHT: 7px"><asp:image id="Image13" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
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
		</form>
	</body>
</HTML>
