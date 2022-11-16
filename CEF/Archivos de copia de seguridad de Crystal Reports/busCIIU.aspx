<%@ Page Language="vb" AutoEventWireup="false" Codebehind="busCIIU.aspx.vb" Inherits="CEF.WebUI.busCIIU"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>busBase</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript">
		<!--
			function f_RetornaCliente(pCodigo, pNombre)
			{
				var voArgumentos = new Array(pCodigo, pNombre);
				window.returnValue = voArgumentos;
				window.close();
			}
		//-->
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidItemIndex" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="480" align="left" bgColor="#ffffff"
				border="0">
				<TR>
					<TD background="../Imagen/bordes/brd_sp.gif" colSpan="3" height="10"></TD>
				</TR>
				<TR>
					<TD width="10">&nbsp;</TD>
					<TD vAlign="top" width="460">
						<TABLE cellSpacing="0" cellPadding="0" width="460" align="center" border="0">
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
												noWrap><asp:Label id="lblTitulo" runat="server" CssClass="SearchResultsHeader"></asp:Label></TD>
											<TD width="99%">&nbsp;</TD>
											<TD><asp:image id="imgCerrar" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Cerrar.gif"
													ToolTip="Cerrar" ImageAlign="AbsMiddle" CssClass="BotonCerrar"></asp:image></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="lightbluebg">&nbsp;</TD>
							</TR>
						</TABLE>
						<TABLE cellSpacing="0" cellPadding="0" width="460" align="center" border="0">
							<TR>
								<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
								<TD class="lightLTbluebg">
									<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="440" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 1px" align="left" colSpan="4"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
										</TR>
										<TR>
											<TD class="Marco" style="HEIGHT: 1px" width="100%" colSpan="2" vAlign="top">
												<TABLE class="Criterio" style="WIDTH: 424px; HEIGHT: 75px">
													<TR>
														<TD><asp:image id="Image1" runat="server" ImageUrl="../Imagen/iconos/ico_Vineta_blue1.gif"></asp:image></TD>
														<TD>Código:</TD>
														<TD>
															<asp:TextBox id="txtCodigo" runat="server" Width="120px"></asp:TextBox></TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 26px"><asp:image id="Image2" runat="server" ImageUrl="../Imagen/iconos/ico_Vineta_blue1.gif"></asp:image></TD>
														<TD style="HEIGHT: 26px">Descripción:</TD>
														<TD style="HEIGHT: 26px">
															<asp:TextBox id="txtDescripcion" runat="server" Width="301px"></asp:TextBox></TD>
													</TR>
													<TR>
														<TD colSpan="3"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" border="0"></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="3"><asp:button id="btnBuscar" runat="server" Width="80px" Text="Buscar" CssClass="Boton"></asp:button></TD>
													</TR>
													<TR>
														<TD colSpan="3"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" border="0"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG height="18" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
										</TR>
										<TR>
											<TD width="440" colSpan="4">
												<TABLE height="21" cellSpacing="0" cellPadding="0" width="440" border="0">
													<TR>
														<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
														<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
														<TD class="TabActivo" title="Ver Lista" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
															height="21">
															&nbsp;Lista&nbsp;</TD>
														<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
														<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
													</TR>
												</TABLE>
												<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
													height="21" cellSpacing="0" cellPadding="0" width="440">
													<TR class="TabBar">
														<TD width="100">&nbsp;</TD>
														<TD noWrap width="80">Num. Registro:</TD>
														<TD width="100"><asp:label id="lblNumReg" runat="server" Width="98px"></asp:label></TD>
														<TD width="140">&nbsp;</TD>
														<TD noWrap width="90">&nbsp;
														</TD>
														<TD noWrap width="90"><asp:image id="imgImprimir" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_impresora2.gif"
																ToolTip="Imprimir" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkImprimir" runat="server" ToolTip="imprimir" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<!-- ------------------------------ Inicio Grilla Parametro -------------------------------------- -->
										<TR>
											<TD class="Marco" vAlign="top" width="440" colSpan="4">
												<DIV class="Grid" id="divComercialProp" style="WIDTH: 440px; HEIGHT: 310px"><asp:datagrid id="dgrdMnt" runat="server" Width="430px" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False"
														AllowPaging="True" UseAccessibleHeader="True" scope="col" CssClass="GridMnt" BorderStyle="None" BorderColor="#3366CC">
														<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
														<EditItemStyle VerticalAlign="Top"></EditItemStyle>
														<ItemStyle CssClass="Registro"></ItemStyle>
														<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
														<Columns>
															<asp:BoundColumn HeaderText="C&#243;digo"></asp:BoundColumn>
															<asp:BoundColumn HeaderText="Descripci&#243;n"></asp:BoundColumn>
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
								<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
							</TR>
						</TABLE>
						<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="460" align="center" border="0">
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
