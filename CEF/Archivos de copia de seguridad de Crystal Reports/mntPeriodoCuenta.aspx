<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntPeriodoCuenta.aspx.vb" Inherits="CEF.WebUI.mntPeriodoCuenta" enableViewState="True"%>
<%@ Import Namespace="CEF.Common.Globals"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntPeriodoCuenta</title>
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
		<script language="JavaScript">
		<!--
			function f_MntAccionPadre() {
				var intMntAccion = document.getElementById("hidMntAccionPadre").value
				return ((intMntAccion == <%=Int32.Parse(ecMntPage.NOACCION)%>)?null:<%=Int32.Parse(ecMntPage.REFRESCAR)%>)
			}
		//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT id="hidMntAccionPadre" type="hidden" name="hidMntAccionPadre" runat="server">
			<INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">
			<INPUT id="hidCodPeriodo" type="hidden" name="hidCodPeriodo" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="510" align="left" bgColor="#ffffff"
				border="0">
				<TBODY>
					<TR>
						<TD background="../Imagen/bordes/brd_sp.gif" colSpan="3" height="10"></TD>
					</TR>
					<TR>
						<TD width="10" style="height: 384px">&nbsp;</TD>
						<TD vAlign="top" width="510" style="height: 384px">
							<TABLE cellSpacing="0" cellPadding="0" width="510" align="center" border="0">
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
													noWrap><SPAN class="SearchResultsHeader">Periodo</SPAN></TD>
												<TD width="99%" style="height: 29px">&nbsp;</TD>
												<TD style="width: 19px; height: 29px"><asp:image id="imgCerrar" runat="server" ImageUrl="../Imagen/iconos/ico_Cerrar.gif" BorderWidth="0px"
														ToolTip="Cerrar" CssClass="BotonCerrar"></asp:image></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="lightbluebg">&nbsp;</TD>
								</TR>
							</TABLE>
							<TABLE cellSpacing="0" cellPadding="0" width="510" align="center" border="0">
								<TBODY>
									<TR>
										<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
												Width="1px"></asp:image></TD>
										<TD class="lightLTbluebg">
											<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="490" align="center" border="0">
												<TBODY>
													<TR>
														<TD style="HEIGHT: 1px" align="left" colSpan="4"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
													</TR>
													<TR>
														<TD vAlign="top" align="right" colSpan="4"><asp:panel id="pnlCabMetodizado" runat="server" Height="24px" Width="308px" HorizontalAlign="Right">
<asp:Button id="btnEliminar" runat="server" Width="67px" CssClass="Boton" ToolTip="Eliminar periodo"
																	Visible="False" Text="Eliminar"></asp:Button>&nbsp; 
<asp:Button id="btnNuevo" runat="server" Width="67px" CssClass="Boton" ToolTip="Ingresar nuevo periodo"
																	Text="Nuevo" CausesValidation="False"></asp:Button>&nbsp; 
<asp:Button id="btnGrabar" runat="server" Width="67px" CssClass="Boton" ToolTip="Grabar periodo"
																	Text="Grabar"></asp:Button>
															</asp:panel></TD>
													</TR>
													<TR>
														<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
															<TABLE class="Criterio" style="WIDTH: 448px">
																<TR>
																	<TD style="WIDTH: 65px">Razón&nbsp;Social:</TD>
																	<TD><asp:textbox id="txtRazonSocial" runat="server" Height="20px" Width="328px" CssClass="NoActivo"
																			MaxLength="20"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 65px" noWrap>Usuario:</TD>
																	<TD noWrap>
																		<asp:textbox id="txtCodUsuario" runat="server" Width="72px" Height="20px" CssClass="NoActivo"
																			MaxLength="20"></asp:textbox>&nbsp;
																		<asp:textbox id="txtNombreUsuario" runat="server" Width="216px" Height="20px" CssClass="NoActivo"
																			></asp:textbox>
																	</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
															<TABLE class="Criterio">
																<TR>
																	<TD>Fecha:</TD>
																	<TD><asp:textbox id="txtFecPeriodo" runat="server" Height="20px" Width="80px" MaxLength="10"></asp:textbox>&nbsp;<asp:image id="imgFecPeriodo" runat="server" ImageUrl="../Imagen/iconos/ico_Calendario.gif"
																			BorderWidth="0px" ToolTip="Seleccionar Periodos" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:image>&nbsp;
																		<asp:requiredfieldvalidator id="vreqFecPeriodo" runat="server" ErrorMessage="Ingrese la fecha del periodo" Display="Dynamic"
																			ControlToValidate="txtfecPeriodo">*</asp:requiredfieldvalidator>
																		<asp:CustomValidator id="cvFecPeriodoLimite" runat="server" ErrorMessage="Error fecha mayor a la actual"
																			ControlToValidate="txtFecPeriodo">*</asp:CustomValidator></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 18px" vAlign="top">Tipo:</TD>
																	<TD style="HEIGHT: 18px" vAlign="top"><asp:dropdownlist id="dropTipoEeff" runat="server" Width="112px" Font-Names="tahoma,sans-serif" Font-Size="11px"
																			AutoPostBack="True"></asp:dropdownlist></TD>
																</TR>
																<SPAN id="spnAuditor" runat="server">
																	<TR>
																		<TD>Auditor:</TD>
																		<TD style="HEIGHT: 23px"><asp:dropdownlist id="dropAuditor" runat="server" Width="184px" Font-Names="tahoma,sans-serif" Font-Size="11px"></asp:dropdownlist></TD>
																	</TR>
																</SPAN>
															</TABLE>
														</TD>
														<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
															<TABLE class="Criterio">
																<TR>
																	<TD>Comentario:</TD>
																</TR>
																<TR>
																	<TD><asp:textbox id="txtComentario" runat="server" Height="70px" Width="232px" TextMode="MultiLine"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD colSpan="4"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
													</TR>
												</TBODY>
											</TABLE>
										</TD>
										<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
												Width="1px"></asp:image></TD>
									</TR>
								</TBODY>
							</TABLE>
							<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="510" align="center" border="0">
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
						<TD style="width: 10px; height: 384px">&nbsp;</TD>
					</TR>
				</TBODY>
			</TABLE>
		</form>
	</body>
</HTML>
