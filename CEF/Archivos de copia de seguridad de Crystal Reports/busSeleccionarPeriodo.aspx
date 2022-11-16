<%@ Page Language="vb" AutoEventWireup="false" Codebehind="busSeleccionarPeriodo.aspx.vb" Inherits="CEF.WebUI.busSeleccionarPeriodo"%>
<%@ Import Namespace="CEF.Common.Globals"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>busSeleccionarPeriodo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
		<script language="JavaScript">
		<!--
			function document.onkeypress() {if (event.keyCode == 13) event.returnValue = false;}
		//-->
		</script>
		<script language="JavaScript">
		<!--
			function f_Aceptar() {
				var strPeriodoSeleccionado = f_ObtPeriodoSeleccionado();
				if (strPeriodoSeleccionado == "" || strPeriodoSeleccionado == null)
					window.returnValue = null;
				else
					window.returnValue = strPeriodoSeleccionado;
				window.close();
			}

			function f_ObtPeriodoSeleccionado() {
				var strPeriodoSeleccionado = "";
				var e = document.getElementsByTagName("input");
				for(var i=0;i<e.length;i++) {
					if ((e[i].getAttribute("type") == "checkbox") && (e[i].getAttribute("checked")))
						strPeriodoSeleccionado += ((strPeriodoSeleccionado!=""?";":"") + e[i].value.toString());
				}
				return (strPeriodoSeleccionado);
			}
		//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">
			<INPUT id="hidPeriodoFiltrado" type="hidden" name="hidPeriodoFiltrado" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="430" align="left" bgColor="#ffffff"
				border="0">
				<TR>
					<TD background="../Imagen/bordes/brd_sp.gif" colSpan="3" height="10"></TD>
				</TR>
				<TR>
					<TD width="10">&nbsp;</TD>
					<TD vAlign="top" width="410">
						<TABLE cellSpacing="0" cellPadding="0" width="410" align="center" border="0">
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
												noWrap><SPAN class="SearchResultsHeader">Seleccionar Periodo</SPAN></TD>
											<TD width="99%">&nbsp;</TD>
											<TD><asp:image id="imgCerrar" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Cerrar.gif"
													CssClass="BotonCerrar" ToolTip="Cerrar"></asp:image></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="lightbluebg">&nbsp;</TD>
							</TR>
						</TABLE>
						<TABLE cellSpacing="0" cellPadding="0" width="410" align="center" border="0">
							<TR>
								<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
								<TD class="lightLTbluebg">
									<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="390" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 1px" align="left" colSpan="4"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="right" colSpan="4"><asp:panel id="pnlCabMetodizado" runat="server" Width="308px" Height="24px" HorizontalAlign="Right"><INPUT class="Boton" id="btnAceptar" title="Aceptar selección" style="WIDTH: 67px; HEIGHT: 20px"
														onclick="f_Aceptar()" type="button" value="Aceptar">&nbsp;&nbsp;&nbsp;</asp:panel></TD>
										</TR>
										<TR>
											<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
												<TABLE class="Criterio">
													<TR>
														<TD style="WIDTH: 65px">Razón&nbsp;Social:</TD>
														<TD style="WIDTH: 100px"><asp:textbox id="txtRazonSocial" runat="server" Width="296px" Height="20px" CssClass="NoActivo"
																 MaxLength="20"></asp:textbox></TD>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG height="18" src="../Imagen/bordes/brd_sp.gif" width="0" border="0"></TD>
										</TR>
										<TR>
											<TD width="390" colSpan="4">
												<TABLE height="21" cellSpacing="0" cellPadding="0" width="390" border="0">
													<TR>
														<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
														<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
														<TD class="TabActivo" title="Ver Periodos" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
															height="21">&nbsp;Periodos&nbsp;</TD>
														<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
														<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
													</TR>
												</TABLE>
												<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
													height="21" cellSpacing="0" cellPadding="0" width="390">
													<TR class="TabBar">
														<TD width="100">&nbsp;</TD>
														<TD noWrap width="80">Num. Registro:</TD>
														<TD width="100"><asp:label id="lblNumReg" runat="server" Width="98px"></asp:label></TD>
														<TD width="50">&nbsp;</TD>
														<TD noWrap width="90"><asp:imagebutton id="ibtnNuevo" runat="server" BorderWidth="0px" ImageUrl="../Imagen/iconos/ico_Nuevo.gif"
																ToolTip="Nuevo" Visible="False" CausesValidation="False" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;<asp:hyperlink id="lnkNuevo" runat="server" ToolTip="Nuevo" Visible="False">Nuevo</asp:hyperlink>
														</TD>
														<TD noWrap width="90"><asp:image id="imgImprimir" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_impresora2.gif"
																CssClass="EfectoImagen" ToolTip="Imprimir" Visible="False" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkImprimir" runat="server" ToolTip="imprimir" Visible="False" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<!-- ------------------------------ Inicio Grilla Parametro -------------------------------------- -->
										<TR>
											<TD class="Marco" vAlign="top" width="390" colSpan="4">
												<DIV class="Grid" id="divComercialProp" style="WIDTH: 390px; HEIGHT: 320px"><asp:datagrid id="dgrdMnt" runat="server" Width="330px" BorderWidth="1px" CssClass="GridMnt" BorderColor="#3366CC"
														BorderStyle="None" CellPadding="4" AutoGenerateColumns="False" UseAccessibleHeader="True" scope="col">
														<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
														<EditItemStyle VerticalAlign="Top"></EditItemStyle>
														<ItemStyle CssClass="Registro"></ItemStyle>
														<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="30px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<INPUT id="chkItem" type="checkbox" runat="server" value='<%# DataBinder.Eval(Container.DataItem,"CodPeriodo") %>'>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="FecPeriodo" HeaderText="Periodo" DataFormatString="{0:d}">
																<HeaderStyle Width="110px"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="DesTipoEeff" HeaderText="Tipo">
																<HeaderStyle Width="110px"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="desc_Estado" HeaderText="Estado">
																<HeaderStyle Width="110px"></HeaderStyle>
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
								<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
							</TR>
						</TABLE>
						<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="410" align="center" border="0">
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
