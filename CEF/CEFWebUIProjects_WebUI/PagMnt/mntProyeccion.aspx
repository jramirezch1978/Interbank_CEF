<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntProyeccion.aspx.vb" Inherits="mntProyeccion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntProyeccion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Estilos/PagLst.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="430" bgColor="#ffffff"
				align="left">
				<TR>
					<TD height="10" background="../Imagen/bordes/brd_sp.gif" colSpan="3"></TD>
				</TR>
				<TR>
					<TD width="10">&nbsp;</TD>
					<TD vAlign="top" width="410">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="410" align="center">
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
												class="lightbluebg" noWrap><SPAN class="SearchResultsHeader"> Proyección</SPAN></TD>
											<TD width="99%">&nbsp;</TD>
											<TD>
												<img id="imgCerrar" style="BorderWidth: 0px" src="../Imagen/iconos/ico_Cerrar.gif" class="BotonCerrar"
													onclick="window.close();">
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="lightbluebg">&nbsp;</TD>
							</TR>
						</TABLE>
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="410" align="center">
							<TR>
								<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
								<TD class="lightLTbluebg">
									<TABLE class="Criterio" border="0" cellSpacing="1" cellPadding="0" width="390" align="center">
										<TR>
											<TD style="HEIGHT: 1px" colSpan="4" align="left"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
										</TR>
										<TR>
											<TD vAlign="top" colSpan="4" align="right"><asp:panel id="pnlCabMetodizado" runat="server" Width="308px" Height="24px" HorizontalAlign="Right"><INPUT style="TEXT-ALIGN: center; WIDTH: 56px; HEIGHT: 20px" id="BtnAceptar" class="boton"
														onclick="f_Aceptar();" value="Aceptar" size="4" height="20" name="BtnAceptar" runat="server" Text="Button">&nbsp;&nbsp;&nbsp;</asp:panel></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 1px" class="Marco" vAlign="top" width="100%" colSpan="4">
												<TABLE class="Criterio">
													<TR>
														<TD style="WIDTH: 109px; HEIGHT: 24px">Razón&nbsp;Social:</TD>
														<TD style="WIDTH: 100px; HEIGHT: 24px"><asp:textbox id="txtRazonSocial" runat="server" Width="269px" Height="20px" CssClass="NoActivo"
																MaxLength="20"></asp:textbox></TD>
													</TR>
													<tr>
														<td style="WIDTH: 109px">Creado Por</td>
														<td style="WIDTH: 100px"><asp:textbox id="txtCuenta" Width="269px" Height="20px" CssClass="NoActivo" Runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td style="WIDTH: 109px">Metodizado</td>
														<td style="WIDTH: 100px"><asp:textbox id="txtCodMetodizado" Width="72px" Height="20px" CssClass="NoActivo"
																Runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td style="WIDTH: 109px">Fecha de Proyección</td>
														<td style="WIDTH: 100px"><asp:textbox id="Textbox1" Width="72px" Height="20px" CssClass="NoActivo" Runat="server"></asp:textbox>
															<asp:image style="Z-INDEX: 0" id="imgFecInicio" runat="server" ImageUrl="../Imagen/iconos/ico_Calendario.gif"
																BorderWidth="0px" CssClass="EfectoImagen" ImageAlign="AbsMiddle" ToolTip="Seleccionar Periodos"></asp:image></td>
													</tr>
													<tr>
														<td style="WIDTH: 109px">Año de EEFF</td>
														<td style="WIDTH: 100px"><asp:textbox id="Textbox2" Width="71px" Height="20px" CssClass="NoActivo" Runat="server"></asp:textbox></td>
													</tr>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG border="0" src="../Imagen/bordes/brd_sp.gif" width="0" height="18"></TD>
										</TR>
										<TR>
											<TD width="390" colSpan="4">
												<TABLE style="BORDER-BOTTOM: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-RIGHT: #a9cfeb 1px solid"
													cellSpacing="0" cellPadding="0" width="390" height="21">
													<TR class="TabBar">
														<TD width="100">&nbsp;</TD>
														<TD width="80" noWrap>Num. Registro:</TD>
														<TD width="100"><asp:label id="lblNumReg" runat="server" Width="98px"></asp:label></TD>
														<TD width="50">&nbsp;</TD>
														<TD width="90" noWrap>&nbsp;<asp:hyperlink id="lnkNuevo" runat="server" ToolTip="Nuevo" Visible="False">Nuevo</asp:hyperlink>
														</TD>
														<TD width="90" noWrap>&nbsp;<asp:hyperlink id="lnkImprimir" runat="server" ToolTip="imprimir" Visible="False" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<!-- ------------------------------ Inicio Grilla Parametro -------------------------------------- -->
										<TR>
											<TD class="Marco" vAlign="top" width="390" colSpan="4">
												<DIV style="WIDTH: 390px; HEIGHT: 320px" id="divComercialProp" class="Grid">
													<asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid></DIV>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG border="0" src="../Imagen/bordes/brd_sp.gif" width="0" height="10"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
							</TR>
						</TABLE>
						<TABLE style="HEIGHT: 6px" border="0" cellSpacing="0" cellPadding="0" width="410" align="center">
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
			</TABLE>
		</form>
	</body>
</HTML>
