<%@ Import Namespace="CEF.Common.Globals"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="consCruceRCD.aspx.vb" Inherits="CEF.WebUI.consCruceRCD"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>consCruceRCD</title>
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
													noWrap><SPAN class="SearchResultsHeader"> Cruce&nbsp;Archivo Cargado&nbsp;con 
														Estados Financieros Validados</SPAN></TD>
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
<asp:Button id="btnCruceRCD" runat="server" Width="67px" ToolTip="Ver Reporte" CssClass="boton"
															Text="Cruce Datos"></asp:Button>&nbsp; 
<asp:Button id="btnInicializar" runat="server" Width="67px" CssClass="Boton" Text="Inicializar"></asp:Button>
													</asp:panel></TD>
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
											<!--PANTALLA-->
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
		</form>
	</body>
</HTML>
