<%@ Register TagPrefix="Module" TagName="Pie" Src="../PagWUC/Pie.ascx" %>
<%@ Register TagPrefix="anthem" Namespace="Anthem" Assembly="Anthem" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntUsuario.aspx.vb" Inherits="CEF.WebUI.mntUsuario"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntUsuario</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT id="hidCodUsuario" type="hidden" name="hidCodUsuario" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" align="left" bgColor="#ffffff"
				border="0">
				<TR>
					<TD vAlign="top" align="left" width="780">
						<TABLE cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD width="10">&nbsp;</TD>
								<TD vAlign="top" align="left" width="760">
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
															<TD class="lightbluebg">
																<TABLE height="29" cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD class="lightbluebg" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 29px"
																			noWrap><SPAN class="SearchResultsHeader">Usuario</SPAN></TD>
																		<TD width="99%">&nbsp;</TD>
																		<TD><asp:imagebutton id="imgCerrar" runat="server" ImageUrl="../Imagen/iconos/ico_Cerrar.gif" BorderWidth="0px"
																				CausesValidation="False" ToolTip="Cerrar"></asp:imagebutton></TD>
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
																		<TD vAlign="top" align="right" colSpan="4"><asp:panel id="pnlCabMetodizado" runat="server" Height="24px" Width="308px" HorizontalAlign="Right">
<asp:Button id="btnNuevo" runat="server" Width="67px" ToolTip="Ingresar un nuevo metodizado"
																					CausesValidation="False"
																					Text="Nuevo"
																					CssClass="Boton"></asp:Button>&nbsp; 
<asp:Button id="btnGrabar" runat="server" Width="67px" ToolTip="Grabar cabecera de metodizado"
																					Text="Grabar"
																					CssClass="Boton"></asp:Button>&nbsp; 
<asp:Button id="btnBuscar" runat="server" Width="67px" CausesValidation="False" Text="Buscar"
																					CssClass="Boton"></asp:Button></asp:panel></TD>
																	</TR>
																	<TR>
																		<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
																			<TABLE class="Criterio">
																				<TR>
																					<TD style="HEIGHT: 19px">Registro:</TD>
																					<TD style="HEIGHT: 19px"><asp:textbox id="txtCodUsuario" runat="server" Height="20px" Width="112px" MaxLength="10"></asp:textbox>&nbsp;&nbsp;<asp:requiredfieldvalidator id="vreqFecPeriodo" runat="server" ErrorMessage="Ingrese el Registro de Usuario"
																							Display="Dynamic" ControlToValidate="txtCodUsuario">*</asp:requiredfieldvalidator></TD>
																				</TR>
																				<TR>
																					<TD>Nombre:</TD>
																					<TD><asp:textbox id="txtNombre" runat="server" Height="20px" Width="257px" MaxLength="80"></asp:textbox>&nbsp;&nbsp;<asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese el Nombre de Usuario"
																							Display="Dynamic" ControlToValidate="txtNombre">*</asp:requiredfieldvalidator></TD>
																				</TR>
																				<TR>
																					<TD>Email:</TD>
																					<TD><asp:textbox id="txtEmail" runat="server" Height="20px" Width="257" MaxLength="80"></asp:textbox></TD>
																				</TR>
																			</TABLE>
																		</TD>
																		<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
																			<TABLE class="Criterio">
																				<TR>
																					<TD style="HEIGHT: 6px">Perfil:</TD>
																					<TD style="HEIGHT: 6px"><asp:dropdownlist id="dropPerfil" runat="server" Width="200px" Font-Names="tahoma,sans-serif" Font-Size="12px"></asp:dropdownlist>&nbsp;
																						<asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Seleccionar el Perfil de Usuario"
																							Display="Dynamic" ControlToValidate="dropPerfil">*</asp:requiredfieldvalidator></TD>
																				</TR>
																				<TR>
																					<TD colspan="2" style="HEIGHT: 14px">
																						<div id="divSupervisor" runat="server" style="DISPLAY:none">
																							<asp:CheckBox id="chkSupervisor" runat="server" Text="Es Supervisor"></asp:CheckBox>
																						</div>
																					</TD>
																				</TR>
																				<TR>
																					<TD style="HEIGHT: 14px">Fecha:</TD>
																					<TD style="HEIGHT: 14px"><asp:textbox id="txtFecReg" runat="server" Height="20px" Width="72px" CssClass="NoActivo"></asp:textbox></TD>
																				</TR>
																				<TR>
																					<TD style="HEIGHT: 14px">Estado:</TD>
																					<TD style="HEIGHT: 14px"><asp:dropdownlist id="dropEstado" runat="server" Width="96px" Font-Names="tahoma,sans-serif" Font-Size="12px"></asp:dropdownlist>&nbsp;
																						<asp:requiredfieldvalidator id="Requiredfieldvalidator3" runat="server" ErrorMessage="Seleccionar el Estado de Usuario"
																							Display="Dynamic" ControlToValidate="dropEstado">*</asp:requiredfieldvalidator></TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD colSpan="4"><IMG height="18" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
																	</TR>
																	<!-- ------------------------- Inicio Grilla Reconciliación --------------------------- -->
																	<% If ( true) Then %>
																	<TR>
																		<TD width="740" colSpan="4">
																			<TABLE height="21" cellSpacing="0" cellPadding="0" width="740" border="0">
																				<TR>
																					<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
																					<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
																					<TD class="TabActivo" title="Ver Reconciliación" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
																						height="21">Cartera</TD>
																					<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
																					<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
																				</TR>
																			</TABLE>
																			<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
																				height="21" cellSpacing="0" cellPadding="0" width="740">
																				<TR class="TabBar">
																					<TD width="80">&nbsp;</TD>
																					<TD noWrap width="80">Num. Registro:</TD>
																					<TD width="100"><asp:label id="lblNumUsuCartera" runat="server" Width="98px"></asp:label></TD>
																					<TD width="140">&nbsp;</TD>
																					<TD noWrap width="70"><asp:image id="imgImpCartera" runat="server" ImageUrl="../imagen/iconos/ico_impresora2.gif"
																							BorderWidth="0px" ToolTip="Imprimir" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkImpCartera" runat="server" ToolTip="Imprimir" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
																					</TD>
																					<TD noWrap width="70"><asp:image id="imgExpCartera" runat="server" ImageUrl="../Imagen/iconos/ico_HojaExcel.gif"
																							BorderWidth="0px" ToolTip="Exportar Cartera" CssClass="EfectoImagen" ImageAlign="AbsMiddle" Visible="False"></asp:image>&nbsp;<asp:hyperlink id="lnkExpCartera" runat="server" ToolTip="Exportar Cartera" NavigateUrl="javascript:window.print()"
																							Visible="False">Exportar</asp:hyperlink>
																					</TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																	<TR>
																		<TD style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4"></TD>
																	</TR>
																	<!-- ------------------------------ Inicio Grilla Reconciliación -------------------------------------- -->
																	<TR>
																		<TD width="740" colSpan="4">
																			<anthem:Panel ID="UpdatePanel1" runat="server" BorderStyle="none" BorderWidth="0px" AddCallBacks="true"
																				EnableCallBack="true">
																				<TABLE height="21" cellSpacing="0" cellPadding="0" width="740" border="0">
																					<TR>
																						<TD class="Marco" vAlign="top" width="320">
																							<DIV class="Grid" id="divUsuPorAsignar" style="WIDTH: 315px; HEIGHT: 350px">
																								<asp:datagrid id="dgrdMntUsuPorAsignar" runat="server" Width="305px" BorderWidth="1px" CssClass="GridMnt"
																									BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False" CellPadding="4" scope="col"
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
																										<asp:BoundColumn DataField="Nombre" HeaderText="Usuarios"></asp:BoundColumn>
																									</Columns>
																									<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
																								</asp:datagrid></DIV>
																						</TD>
																						<TD vAlign="middle" align="center" width="100">
																							<asp:panel id="Panel1" runat="server" Width="16px" Height="63px" HorizontalAlign="Center">
																								<P>
																									<asp:Button id="btnAsignarCartera" runat="server" Width="80px" ToolTip="Asignar en Cartera"
																										Text="Asignar >>" CssClass="Boton"></asp:Button></P>
																								<P>
																									<asp:Button id="btnExcluirCartera" runat="server" Width="80px" ToolTip="Excluir de Cartera"
																										CausesValidation="False" Text="<< Excluir" CssClass="Boton"></asp:Button></P>
																							</asp:panel></TD>
																						<TD class="Marco" vAlign="top" width="320">
																							<DIV class="Grid" id="divUsuSubordinado" style="WIDTH: 315px; HEIGHT: 350px">
																								<asp:datagrid id="dgrdMntUsuSubordinado" runat="server" Width="305px" BorderWidth="1px" CssClass="GridMnt"
																									BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False" CellPadding="4" scope="col"
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
																										<asp:BoundColumn DataField="Nombre" HeaderText="Usuarios Subordinados"></asp:BoundColumn>
																									</Columns>
																									<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
																								</asp:datagrid></DIV>
																						</TD>
																					<TR>
																					</TR>
																				</TABLE>
																				<DIV id="divPopUp" style="DISPLAY: none; VERTICAL-ALIGN: middle; WIDTH: 320px; COLOR: black; HEIGHT: 140px">
																					<TABLE cellSpacing="0" cellPadding="0" width="490" border="0">
																						<TR>
																							<TD width="20"></TD>
																							<TD width="450"></TD>
																							<TD width="20"><IMG style="CURSOR: hand" onclick="javascript:pOcultarNoAsignados();" alt="Cerrar" src="../Imagen/iconos/ico_Cerrar.gif">
																							</TD>
																						</TR>
																						<TR>
																							<TD></TD>
																							<TD>
																								<TABLE cellSpacing="0" cellPadding="0" border="0">
																									<TR>
																										<TD>
																											<asp:Label id="lblNoAsignados" runat="server" CssClass="PopUpLabel" EnableViewState="False">Los siguientes usuarios ya están asignados a los analistas que se indican a continuación:</asp:Label></TD>
																									</TR>
																									<TR>
																										<TD style="HEIGHT: 5px"></TD>
																									</TR>
																									<TR>
																										<TD>
																											<DIV class="Grid" style="WIDTH: 450px; HEIGHT: 90px">
																												<asp:datagrid id="dgrdMntNoAsignados" runat="server" Width="450px" BorderWidth="1px" CssClass="GridMnt"
																													BorderStyle="None" BorderColor="#3366CC" AutoGenerateColumns="False" CellPadding="4" scope="col"
																													UseAccessibleHeader="True" EnableViewState="false" AllowPaging="False">
																													<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
																													<EditItemStyle VerticalAlign="Top"></EditItemStyle>
																													<ItemStyle CssClass="Registro"></ItemStyle>
																													<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
																													<Columns>
																														<asp:BoundColumn DataField="Subordinado" HeaderText="Ejecutivo"></asp:BoundColumn>
																														<asp:BoundColumn DataField="Resposable" HeaderText="Analista"></asp:BoundColumn>
																													</Columns>
																												</asp:datagrid></DIV>
																										</TD>
																									</TR>
																								</TABLE>
																							</TD>
																							<TD></TD>
																						</TR>
																						<TR>
																							<TD colSpan="3"></TD>
																						</TR>
																					</TABLE>
																				</DIV>
																				<INPUT id="hidNoAsignados" type="hidden" value="0" name="hidNoAsignados" runat="server">
																			</anthem:Panel>
																		</TD>
																	</TR>
																	<% End If %>
																	<!-- ------------------------------ Fin Reconciliación -------------------------------------- -->
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
											</TR>
											<TR>
												<TD colSpan="2"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
											</TR>
										</TBODY>
									</TABLE>
								</TD>
								<TD width="10" bgColor="#ffffff">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
			<script language="JavaScript" src="../Funciones/Css.js"></script>
			<script language="JavaScript" src="../Funciones/modalPopUp.js"></script>
			<script language="JavaScript">
			<!--
				var oModalPopUp;
				function document.onkeypress() {if (event.keyCode == 13) event.returnValue = false;}
				function pMostrarNoAsignados() {var oNoAsignados = document.getElementById('hidNoAsignados');if (oNoAsignados!=null){ if(oNoAsignados.value == '1'){pMostrarModalPopUp('divPopUp',false);}}}
				function pOcultarNoAsignados() {oModalPopUp.OcultarPopUp();var oNoAsignados = document.getElementById('hidNoAsignados'); if (oNoAsignados!=null){oNoAsignados.value = 0;}}
				function pMostrarModalPopUp(strIdElemento,boolPermitirMover) {oModalPopUp=new ModalPopUp(strIdElemento,'modalBackground','modalPopup',boolPermitirMover);oModalPopUp.MostrarPopUp();}
				function verificarPerfilAnalista(){var oDropPerfil = fRetornaValorSeccionadoDDL('dropPerfil'); if(oDropPerfil == <%=CEF.Common.Globals.ecPerfil.ANALISTA_RIESGO %>){ divSupervisor.style.display='';}else{divSupervisor.style.display='none';document.getElementById('chkSupervisor').checked=false;}}
				function fRetornaValorSeccionadoDDL(strNombreDDL){var vstrValor='';var oddl=document.getElementById(strNombreDDL);if(oddl!=null){if(oddl.selectedIndex>-1){var oElementos=oddl.getElementsByTagName('option');vstrValor=oElementos[oddl.selectedIndex].value;}}return(vstrValor);}
			//-->
			</script>
		</form>
	</body>
</HTML>
