<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="consParametrica.aspx.vb" Inherits="CEF.WebUI.consParametrica"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>consParametrica</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
		<script language="JavaScript" src="../Funciones/UtilFecha.js"></script>
		<script language="JavaScript">
		<!--
			function document.onkeypress() {if (event.keyCode == 13) event.returnValue = false;}
		//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT id="hidCodUsuario" type="hidden" name="hidCodUsuario" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="760" border="0">
				<TBODY>
					<TR>
						<TD width="100%" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD vAlign="top">
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
									<TD class="lightbluebg" style="HEIGHT: 33px">
										<TABLE style="WIDTH: 747px; HEIGHT: 16px" height="16" cellSpacing="0" cellPadding="0" width="747"
											border="0">
											<TR>
												<TD class="lightbluebg" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; WIDTH: 717px; PADDING-TOP: 5px; HEIGHT: 29px"
													noWrap><SPAN class="SearchResultsHeader">Consulta Paramétrica</SPAN></TD>
												<TD><asp:imagebutton id="imgCerrar" runat="server" ImageUrl="../Imagen/iconos/ico_Cerrar.gif" BorderWidth="0px"
														CausesValidation="False" ToolTip="Cerrar"></asp:imagebutton></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
							<anthem:panel id="UpdatePanel1" runat="server" BorderWidth="3px" EnableCallBack="true" AddCallBacks="true"
								BorderStyle="none" TextDuringCallBack="Cargando...">
								<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
									<TR>
										<TD class="lightblueborder" width="1">
											<asp:image id="Image7" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
										<TD class="lightLTbluebg">
											<TABLE class="Criterio" style="HEIGHT: 300px" cellSpacing="1" cellPadding="0" width="750"
												align="center" border="0">
												<TR>
													<TD style="HEIGHT: 33px" align="left" colSpan="4">
														<asp:validationsummary id="vsmMnt" runat="server" Height="20px"></asp:validationsummary></TD>
												</TR>
												<TR>
													<TD class="Marco" style="HEIGHT: 28px" vAlign="top" width="99%" colSpan="2">
														<TABLE style="HEIGHT: 81px" width="100%">
															<TR>
																<TD width="50%">
																	<TABLE class="Criterio" width="280">
																		<TR>
																			<TD style="WIDTH: 80px">Expresado en:</TD>
																			<TD>
																				<asp:dropdownlist id="dropMoneda" runat="server" Width="100%" AutoPostBack="True"></asp:dropdownlist></TD>
																		</TR>
																		<TR>
																			<TD style="WIDTH: 80px; HEIGHT: 19px">Fecha Periodo:</TD>
																			<TD style="HEIGHT: 19px">
																				<asp:textbox id="txtFecPeriodo" runat="server" Width="80px" Height="20px" MaxLength="10"></asp:textbox>
																				<asp:image id="imgFecPeriodo" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Calendario.gif"
																					ToolTip="Seleccionar Periodos" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>
																				<asp:requiredfieldvalidator id="vreqFecPeriodo" runat="server" ControlToValidate="txtFecPeriodo" Display="Dynamic"
																					ErrorMessage="Seleccione Periodo">*</asp:requiredfieldvalidator></TD>
																		</TR>
																	</TABLE>
																</TD>
																<TD align="right">
																	<asp:panel id="pnlCabMetodizado" runat="server" Width="308px" Height="24px" HorizontalAlign="Right">&nbsp; 
<asp:Button id="btnBuscar" runat="server" Width="67px" ToolTip="Consular" CssClass="Boton" Text="Búsqueda"></asp:Button>&nbsp; 
<asp:Button id="btnInicializar" runat="server" Width="67px" CausesValidation="False" CssClass="Boton"
																			Text="Inicializar"></asp:Button></asp:panel></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 2px" colSpan="4"></TD>
												</TR> <!-- ------------------------- Inicio Grilla Reconciliación --------------------------- --><% If ( true) Then %>
												<TR>
													<TD style="HEIGHT: 52px" width="740" colSpan="4">
														<TABLE height="21" cellSpacing="0" cellPadding="0" width="740" border="0">
															<TR>
																<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
																<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
																<TD class="TabActivo" title="Ver Reconciliación" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
																	height="21">Parámetros de Cuentas</TD>
																<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
																<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"></TD>
															</TR>
														</TABLE>
														<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; WIDTH: 738px; BORDER-BOTTOM: #a9cfeb 1px solid; HEIGHT: 4px"
															height="4" cellSpacing="0" cellPadding="0" width="738">
															<TR class="TabBar">
																<TD style="WIDTH: 122px" width="122">&nbsp;</TD>
																<TD style="WIDTH: 121px" noWrap width="121">Num. Reg. Encontrados:</TD>
																<TD width="100">
																	<asp:label id="lblNumRegEncontrados" runat="server" Width="98px"></asp:label></TD>
																<TD width="140">&nbsp;</TD>
																<TD onclick="return true;" noWrap width="70">&nbsp;
																	<asp:button id="btnExportar" runat="server" Width="67px" ToolTip="Exportar Excel" CssClass="Boton"
																		Text="Exportar" Visible="False"></asp:button></TD>
																<TD onclick="return true;" noWrap width="70">&nbsp;
																	<asp:image id="imgExpExcel" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_HojaExcel.gif"
																		ToolTip="Exportar a Excel" ImageAlign="AbsMiddle"></asp:image>
																	<anthem:LinkButton id="lnk_Exportar" runat="server" ToolTip="Exportar a Excel" EnableCallBack="true"
																		EnabledDuringCallBack="False" UpdateAfterCallBack="true">Exportar</anthem:LinkButton></TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD style="HEIGHT: 217px" width="740" colSpan="4">
														<TABLE style="WIDTH: 740px; HEIGHT: 200px" height="200" cellSpacing="0" cellPadding="0"
															width="740" border="0">
															<TR>
																<TD class="Marco" style="WIDTH: 291px" vAlign="top" width="291"><DIV class="Grid" id="divUsuPorAsignar" style="WIDTH: 294px; HEIGHT: 188px">
																		<asp:datagrid id="dgrdCuentasPorAsignar" runat="server" Width="288px" BorderWidth="1px" BorderStyle="None"
																			CssClass="GridMnt" BorderColor="#3366CC" AutoGenerateColumns="False" CellPadding="4" scope="col"
																			UseAccessibleHeader="True">
																			<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
																			<EditItemStyle VerticalAlign="Top"></EditItemStyle>
																			<ItemStyle CssClass="Registro"></ItemStyle>
																			<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Width="30px"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkItem" runat="server"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="Descripcion" HeaderText="Cuentas"></asp:BoundColumn>
																			</Columns>
																			<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></DIV>
																</TD>
																<TD style="WIDTH: 27px" vAlign="middle" align="center" width="27">
																	<asp:panel id="Panel1" runat="server" Width="16px" Height="63px" HorizontalAlign="Center">
																		<P>
																			<asp:Button id="btnAsignarCuenta" runat="server" Width="30px" ToolTip="Asignar Cuenta" CausesValidation="False"
																				CssClass="Boton" Text=">>"></asp:Button></P>
																		<P>
																			<asp:Button id="btnExcluirCuenta" runat="server" Width="30px" ToolTip="Excluir Cuenta" CausesValidation="False"
																				CssClass="Boton" Text="<<"></asp:Button></P>
																	</asp:panel></TD>
																<TD class="Marco" vAlign="top" width="320">
																	<DIV class="Grid" id="divUsuSubordinado" style="WIDTH: 414px; HEIGHT: 191px">
																		<asp:datagrid id="dgrdCuentasConsulta" runat="server" Width="412px" BorderWidth="1px" BorderStyle="None"
																			CssClass="GridMnt" BorderColor="#3366CC" AutoGenerateColumns="False" CellPadding="4" scope="col"
																			UseAccessibleHeader="True">
																			<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
																			<EditItemStyle VerticalAlign="Top"></EditItemStyle>
																			<ItemStyle CssClass="Registro"></ItemStyle>
																			<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
																			<Columns>
																				<asp:TemplateColumn>
																					<HeaderStyle Width="30px"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Center"></ItemStyle>
																					<ItemTemplate>
																						<asp:CheckBox id="chkItem" runat="server"></asp:CheckBox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:BoundColumn DataField="Descripcion" HeaderText="Cuenta">
																					<HeaderStyle Width="150px"></HeaderStyle>
																				</asp:BoundColumn>
																				<asp:TemplateColumn HeaderText="&gt;= Rango 1">
																					<HeaderStyle Width="80px"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Right"></ItemStyle>
																					<ItemTemplate>
																						<asp:textbox id="txtRango1" runat="server" Height="20px" Width="80px" CssClass="ActivoNumericoColSel"
																							MaxLength="10" Text='<%# iif(DataBinder.Eval(Container.DataItem,"ImporteRango1")<> Decimal.MinValue,DataBinder.Eval(Container.DataItem,"ImporteRango1"), "") %>'></asp:textbox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																				<asp:TemplateColumn HeaderText="&lt;= Rango 2">
																					<HeaderStyle Width="80px"></HeaderStyle>
																					<ItemStyle HorizontalAlign="Right"></ItemStyle>
																					<ItemTemplate>
																						<asp:textbox id="txtRango2" runat="server" Height="20px" Width="80px" CssClass="ActivoNumericoColSel"
																							MaxLength="10" Text='<%# iif(DataBinder.Eval(Container.DataItem,"ImporteRango2")<> Decimal.MinValue,DataBinder.Eval(Container.DataItem,"ImporteRango2"), "") %>'></asp:textbox>
																					</ItemTemplate>
																				</asp:TemplateColumn>
																			</Columns>
																			<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
																		</asp:datagrid></DIV>
																</TD>
															<TR>
															</TR>
														</TABLE>
														<P>
															<asp:datagrid id="dgrdMnt" runat="server" Width="440px" BorderWidth="1px" BorderStyle="None" CssClass="GridMnt"
																BorderColor="#3366CC" AutoGenerateColumns="False" CellPadding="4" EnableViewState="False"
																PageSize="20">
																<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
																<EditItemStyle VerticalAlign="Top"></EditItemStyle>
																<ItemStyle CssClass="Registro"></ItemStyle>
																<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#568ed1"
																	ForeColor="White" CssClass="CabeceraRegistro"></HeaderStyle>
																<Columns>
																	<asp:BoundColumn DataField="CUCliente" HeaderText="CU Cliente" DataFormatString="{0:10D}">
																		<HeaderStyle Width="100px"></HeaderStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="RazonSocial" HeaderText="Raz&#243;n Social">
																		<HeaderStyle Width="400px"></HeaderStyle>
																	</asp:BoundColumn>
																</Columns>
																<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
															</asp:datagrid></P>
													</TD>
												</TR>
												<% End If %> <!-- ------------------------------ Fin Reconciliación -------------------------------------- -->
												<TR>
													<TD colSpan="4"></TD>
												</TR>
											</TABLE>
											<P>&nbsp;</P>
										</TD>
										<TD class="lightblueborder" width="1">
											<asp:image id="Image8" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
									</TR>
								</TABLE>
							</anthem:panel>
							<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
								<tbody>
									<TR>
										<TD style="HEIGHT: 1px" rowSpan="2"><asp:image id="Image9" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Inf_Izq_blue.gif"
												Height="6px" BorderWidth="0px" Width="6px"></asp:image></TD>
										<TD class="bottombluebg" width="99%"><asp:image id="Image12" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="5px"
												Width="1px"></asp:image></TD>
										<TD style="HEIGHT: 1px" rowSpan="2"><asp:image id="Image10" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Inf_Der_blue.gif"
												Height="6px" BorderWidth="0px" Width="6px"></asp:image></TD>
									</TR>
									<TR>
										<TD class="lightblueborder" width="1"><asp:image id="Image13" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px"
												BorderWidth="0px" Width="1px"></asp:image></TD>
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
		<script type="text/javascript">
			function fCambiarMoneda()
			{
				var oTxtFecha = document.getElementById('txtFecPeriodo');
				
				if (oTxtFecha!=null)
				{
					var oTablaCuentas = document.getElementById('dgrdCuentasConsulta');
					if((oTxtFecha.value != '') && (oTablaCuentas!=null))
					{
						document.getElementById('dropMoneda').options[document.getElementById('dropMoneda').selectedIndex].text ='Cargando...';
					}
				}
			}
			
			function fAlertaNoDatos()
			{
				alert('No se encontro registro(s) según los criterios ingresados');
			}
		</script>
	</body>
</HTML>
