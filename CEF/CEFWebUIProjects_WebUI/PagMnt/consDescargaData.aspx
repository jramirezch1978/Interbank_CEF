<%@ Page Language="vb" AutoEventWireup="false" Codebehind="consDescargaData.aspx.vb" Inherits="CEF.WebUI.consDescargaData"%>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Import Namespace="CEF.Common.Globals"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>consDescargaData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">&nbsp;
			<TABLE cellSpacing="0" cellPadding="0" width="760" border="0">
				<TR>
					<TD width="100%" colSpan="2">&nbsp;</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
							<TR>
								<TD width="5" rowSpan="3">
									<asp:image id="Image4" runat="server" BorderWidth="0px" Width="5px" Height="51px" ImageUrl="../Imagen/bordes/brd_curva_Sup_Izq_blue.gif"></asp:image></TD>
								<TD class="lightblueborder" width="99%">
									<asp:image id="Image6" runat="server" BorderWidth="0px" Width="1px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
								<TD width="5" rowSpan="3">
									<asp:image id="Image5" runat="server" BorderWidth="0px" Width="5px" Height="51px" ImageUrl="../Imagen/bordes/brd_curva_Sup_Der_blue.gif"></asp:image></TD>
							</TR>
							<TR>
								<TD class="lightbluebg">
									<TABLE height="29" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD class="lightbluebg" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; WIDTH: 335px; PADDING-TOP: 5px; HEIGHT: 29px"
												noWrap><SPAN class="SearchResultsHeader">Descarga Data del Metodizado</SPAN></TD>
											<TD width="99%">&nbsp;</TD>
											<TD>
												<asp:imagebutton id="imgCerrar" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Cerrar.gif"
													ToolTip="Cerrar" CausesValidation="False"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="lightbluebg">&nbsp;</TD>
							</TR>
						</TABLE>
						<anthem:Panel ID="UpdatePanel1" runat="server" TextDuringCallBack="Cargando..." BorderStyle="none"
							BorderWidth="0px" AddCallBacks="true" EnableCallBack="true">
							<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
								<TR>
									<TD class="lightblueborder" width="1">
										<asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" Width="1px"
											BorderWidth="0px"></asp:image></TD>
									<TD class="lightLTbluebg">
										<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="740" align="center" border="0">
											<%--
											<TR>
												<TD style="HEIGHT: 46px" align="left" colSpan="4">
													<asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
											</TR>
											--%>
											<TR>
												<TD vAlign="top" align="right" colSpan="4">
													<TABLE width="100%">
														<TR>
															<TD width="50%">
																<TABLE class="Criterio" width="280">
																	<TR>
																		<TD style="WIDTH: 80px; HEIGHT: 23px">Expresado en:</TD>
																		<TD style="HEIGHT: 14px">
																			<asp:dropdownlist id="dropMoneda" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
																	</TR>
																	<TR>
																		<TD style="HEIGHT: 19px">Estado:
																		</TD>
																		<TD style="HEIGHT: 23px">
																			<asp:dropdownlist id="ddlEstado" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 80px; HEIGHT: 23px">Fecha Periodo:</TD>
																		<TD style="HEIGHT: 14px">
																			<asp:textbox id="txtFecPeriodo" runat="server" Height="20px" Width="80px" MaxLength="10"></asp:textbox>&nbsp;
																			<asp:image id="imgFecPeriodo" runat="server" ImageUrl="../Imagen/iconos/ico_Calendario.gif"
																				BorderWidth="0px" ToolTip="Seleccionar Periodos" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;
																			<asp:requiredfieldvalidator id="vreqFecPeriodo" runat="server" Display="Dynamic" ControlToValidate="txtFecPeriodo"
																				ErrorMessage="Seleccione Periodo">*</asp:requiredfieldvalidator></TD>
																	</TR>
																</TABLE>
															</TD>
															<TD width="50%">
																<asp:panel id="pnlCabMetodizado" runat="server" Height="24px" Width="308px" HorizontalAlign="Right">
	<asp:Button id="btnBuscar" runat="server" Width="67px" ToolTip="Iniciar busqueda" CssClass="Boton"
																		Text="Busqueda"></asp:Button>&nbsp; 
	<asp:Button id="btnInicializar" runat="server" Width="67px" CssClass="Boton" Text="Inicializar"></asp:Button></asp:panel></TD>
														</TR>
													</TABLE>
												</TD>
											</TR> <!--PANTALLA-->
											<TR>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2"></TD>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="18" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
											</TR>
											<TR>
												<TD width="740" colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%">
														<TR>
															<TD>
																<TABLE height="21" cellSpacing="0" cellPadding="0" width="740" align="left" border="0">
																	<TR>
																		<TD style="WIDTH: 57px" width="0">
																			<TABLE height="21" cellSpacing="0" cellPadding="0" width="100%" border="0">
																				<TR>
																					<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG id="Img1" height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7" runat="server"></TD>
																					<TD id="tab1_1" width="6" height="21" runat="server"><IMG id="img_tab1_1" height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif"
																							width="6" runat="server"></TD>
																					<TD class="TabActivo" id="tab1_2" title="Ver Funciones" height="21" runat="server">&nbsp;
																						<anthem:LinkButton id="lnk_Validados" runat="server" EnableCallBack="true" EnabledDuringCallBack="False"
																							UpdateAfterCallBack="true">Validado</anthem:LinkButton>&nbsp;</TD>
																					<TD id="tab1_3" style="WIDTH: 2px" width="2" height="21" runat="server"><IMG id="img_tab1_3" height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif"
																							width="6" runat="server"></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD width="auto" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif">&nbsp;</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
																	height="21" cellSpacing="0" cellPadding="0" width="740">
																	<TR class="TabBar">
																		<TD width="100">&nbsp;<INPUT id="hidPestaniaActual" style="WIDTH: 16px; HEIGHT: 17px" type="hidden" size="1"
																				value="1" name="hidPestaniaActual" runat="server"></TD>
																		<TD noWrap width="80">Num. Registro:</TD>
																		<TD width="100">
																			<asp:label id="lblNumReg" runat="server" Width="98px"></asp:label></TD>
																		<TD width="140">&nbsp;</TD>
																		<TD noWrap width="90"></TD>
																		<TD noWrap width="90">
																			<asp:image id="imgExpExcel" runat="server" ImageUrl="../Imagen/iconos/ico_HojaExcel.gif" BorderWidth="0px"
																				ToolTip="Exportar a Excel" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;
																			<asp:hyperlink id="lnkExpExecel" runat="server" ToolTip="Exportar a Excel" NavigateUrl="javascript:window.print()">Exportar</asp:hyperlink></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR> <!-- ------------------------------ Inicio Grilla Empresas por CIIU -------------------------------------- -->
											<TR id="tr_Validados" runat="server">
												<TD class="Marco" vAlign="top" width="740" colSpan="4">
													<DIV class="Grid" id="divComercialProp" style="WIDTH: 740px; HEIGHT: 630px">
														<asp:datagrid id="dgrdMnt" runat="server" Width="1870px" BorderWidth="1px" BorderStyle="None"
															CssClass="GridMnt" CellPadding="4" AutoGenerateColumns="False" UseAccessibleHeader="True"
															scope="col" PageSize="20" AllowPaging="True" BorderColor="#3366CC">
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
																<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo de Documento"></asp:BoundColumn>
																<asp:BoundColumn DataField="NumeroDocumento" HeaderText="N&#250;mero de Documento">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="CodCIIU" HeaderText="C&#243;digo CIIU">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="TipoEeff" HeaderText="Tipo">
																	<HeaderStyle Width="50px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe1" HeaderText="Monto Disponible">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe36" HeaderText="Valores Negociables">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe2" HeaderText="Cuenta por Cobrar Comerciales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe37" HeaderText="Otras Cuentas por Cobrar">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe38" HeaderText="Filiales (o principal) y Afiliadas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe3" HeaderText="Existencias">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe39" HeaderText="Gastos Pagados por Adelantado">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe4" HeaderText="Activo Corriente">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe40" HeaderText="Cuentas por Cob. Com. LP.">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe41" HeaderText="Otras Ctas. Por Cobrar L.P.">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe42" HeaderText="Filiales (o principal) y Afiliadas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe43" HeaderText="Cuentas por Cobrar a Accionistas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe5" HeaderText="Activo Fijo Neto de Depreciación">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe44" HeaderText="Menos: Despreciación Acumulada">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe76" HeaderText="Inversiones en Valores">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe6" HeaderText="Intangibles">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe7" HeaderText="Otras Cuentas del Activo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe45" HeaderText="Activo no Corriente">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe8" HeaderText="Activos Totales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe9" HeaderText="Sobregiros y Deuda a Corto Plazo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe10" HeaderText="Porción Corriente de la Deuda a Largo Plazo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe11" HeaderText="Cuentas por Pagar Comerciales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe46" HeaderText="Otras Cuentas por Pagar">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe47" HeaderText="Dividendos por Pagar">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe48" HeaderText="Filiales (o principal) y Afiliadas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe12" HeaderText="Pasivo Corriente">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe13" HeaderText="Deuda a Largo Plazo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe49" HeaderText="Deuda Financiera LP">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe50" HeaderText="Cuentas por Pagar Comerciales L.P.">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe14" HeaderText="Otras Cuentas del Pasivo">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe51" HeaderText="Filiales (o principal) y Afiliadas L.P.">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe52" HeaderText="Beneficios Sociales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe53" HeaderText="Pasivo No Corriente">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe15" HeaderText="Pasivos Totales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe54" HeaderText="Ganancias Diferidas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe55" HeaderText="Otros Pasivos Diferidos">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe56" HeaderText="Intereses Minoritarios">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe16" HeaderText="Capital">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe57" HeaderText="Capital Adicional">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe58" HeaderText="Participación Patrimonial">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe59" HeaderText="Revaluación Voluntaria">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe60" HeaderText="Reservas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe17" HeaderText="Resultados Acumulados">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe18" HeaderText="Patrimonio Neto de la Empresa">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<%-- 
																<asp:BoundColumn DataField="Importe19" HeaderText="Ventas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																--%>
																<asp:BoundColumn DataField="Importe61" HeaderText="Ventas Terceros">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe62" HeaderText="Ventas Afiliadas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe63" HeaderText="Otros Ingresos Operacionales">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe20" HeaderText="Costo de Ventas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe64" HeaderText="Gasto de Ventas">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe65" HeaderText="Gastos de Administración">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe66" HeaderText="EBITDA">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe67" HeaderText="Depreciación">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe68" HeaderText="Amortización">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<%-- 
																<asp:BoundColumn DataField="Importe21" HeaderText="Gastos de Operación Administrativos y de Venta">
																	<HeaderStyle Width="0px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																--%>
																<asp:BoundColumn DataField="Importe22" HeaderText="Ingresos Financieros">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe23" HeaderText="Gastos Financieros">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe24" HeaderText="Otros Ingresos Netos">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe69" HeaderText="Otros Gastos">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe70" HeaderText="Mas (menos) Resultado x exp. A la inflación/ Ganacia (pérdida) x diferencia en cambio">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe71" HeaderText="Participaciones">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe25" HeaderText="Impuesto a la Renta">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe72" HeaderText="Ingresos (gastos) extraordinarios (Netos de imp.)">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe26" HeaderText="Utilidad Neta">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<%-- 
																<asp:BoundColumn DataField="Importe27" HeaderText="Depreciación y Amortización">
																	<HeaderStyle Width="0px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																--%>
																<asp:BoundColumn DataField="Importe28" HeaderText="Dividendos">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe29" HeaderText="Inversiones de Capital">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe30" HeaderText="Porcentaje Ingreso Moneda Extranjera">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe31" HeaderText="Porcentaje Gasto Moneda Extranjera">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe32" HeaderText="Porcentaje Deuda Bancaria CP Moneda Extranjera">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe33" HeaderText="Porcentaje Deuda Bancaria LP Moneda Extranjera">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe74" HeaderText="Disminución en Caja y Valores Negociables – Soles">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe75" HeaderText="Disminución en Caja y Valores Negociables – Dólares">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe34" HeaderText="% Devaluación Máxima">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe73" HeaderText="% Devaluación Máxima (apreciación máxima)">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Importe35" HeaderText="Grado de Exposición">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="FecPeriodo" HeaderText="MES">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
															</Columns>
															<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></DIV>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" width="0" border="0">
												</TD>
											</TR> <!--PANTALLA--></TABLE>
									</TD>
									<TD class="lightblueborder" width="1">
										<asp:image id="Image8" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" Width="1px"
											BorderWidth="0px"></asp:image></TD>
								</TR>
							</TABLE>
						</anthem:Panel>
						<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 6px" rowSpan="2">
									<asp:image id="Image9" runat="server" BorderWidth="0px" Width="6px" Height="6px" ImageUrl="../Imagen/bordes/brd_curva_Inf_Izq_blue.gif"></asp:image></TD>
								<TD class="bottombluebg" width="99%">
									<asp:image id="Image12" runat="server" Width="1px" Height="5px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
								<TD style="HEIGHT: 6px" rowSpan="2">
									<asp:image id="Image10" runat="server" BorderWidth="0px" Width="6px" Height="6px" ImageUrl="../Imagen/bordes/brd_curva_Inf_Der_blue.gif"></asp:image></TD>
							</TR>
							<TR>
								<TD class="lightblueborder" style="HEIGHT: 1px" width="1">
									<asp:image id="Image13" runat="server" BorderWidth="0px" Width="1px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="2"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
				</TR>
			</TABLE>
		</form>
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
			function fCambiarPestaniaActual(pintTab)
			{
				// var bolRpta = true;
				
				var ohidPestaniaActiva = document.getElementById('hidPestaniaActual');
				if (ohidPestaniaActiva!=null)
				{
					// if(parseInt(ohidPestaniaActiva.value)==pintTab)
					// {
					// 	bolRpta=false;
					// }
				}
				
				pOcultarResultados()
				
				// return (bolRpta);
			}
			
			function fCambiarMoneda()
			{
				var oTxtFecha = document.getElementById('txtFecPeriodo');
				
				if (oTxtFecha!=null)
				{
					if(oTxtFecha.value != '')
					{
						document.getElementById('dropMoneda').options[document.getElementById('dropMoneda').selectedIndex].text ='Cargando...';
					}
				}
			}
			
			function fCambiarEstado()
			{
				var oTxtFecha = document.getElementById('txtFecPeriodo');
				// a();
				document.getElementById('lnk_Validados').innerHTML = document.getElementById('ddlEstado').options[document.getElementById('ddlEstado').selectedIndex].text;
				
				if (oTxtFecha!=null)
				{
					if(oTxtFecha.value != '')
					{
						document.getElementById('ddlEstado').options[document.getElementById('ddlEstado').selectedIndex].text ='Cargando...';
					}
				}
			}
			
			function pOcultarResultados()
			{
				var oDgrdMnt = document.getElementById('dgrdMnt');
				if (oDgrdMnt!=null)
				{	oDgrdMnt.style.display='none'; }
				
				// var oDgrPrioridad = document.getElementById('dgrPrioridad');
				// if (oDgrPrioridad!=null)
				// {	oDgrPrioridad.style.display='none';}
			}
			
		</script>
	</body>
</HTML>
