<%@ Register TagPrefix="Module" TagName="Pie" Src="../PagWUC/Pie.ascx" %>
<%@ Register TagPrefix="Module" TagName="Titulo" Src="../PagWUC/Titulo.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="busUsuario.aspx.vb" Inherits="CEF.WebUI.busUsuario" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>busUsuario</title>
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
			function f_AbrirPagMnt(strUrl, intWidth, intHeight)
			{
				var objParametro = null;
				var voArgumentos = new Array(objParametro);				
				voArgumentos = f_MskVtnDlg(strUrl, voArgumentos, intWidth, intHeight);
				if(voArgumentos != null)
				{
					document.Form1.submit();
				}
			}
		//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT type="hidden" id="PageX" name="PageX" value="0" runat="server">
			<INPUT type="hidden" id="PageY" name="PageY" value="0" runat="server">
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
													noWrap><SPAN class="SearchResultsHeader">Busqueda de Usuario</SPAN></TD>
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
											<TR>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
													<TABLE class="Criterio">
														<TR>
															<TD noWrap><asp:literal id="ltlPerfilUsuarioLogin" runat="server" Text="Usuario:"></asp:literal></TD>
															<TD style="WIDTH: 100px"><asp:textbox id="txtNomUsuarioLogin" runat="server" Width="312px" Height="20px" CssClass="NoActivo"
																	MaxLength="20"></asp:textbox></TD>
															<TD>&nbsp;</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
													<TABLE class="Criterio">
														<TR>
															<TD style="HEIGHT: 19px">
																Registro:</TD>
															<TD style="HEIGHT: 19px"><asp:textbox id="txtCodUsuario" runat="server" Width="112px" Height="20px" MaxLength="10"></asp:textbox></TD>
														</TR>
														<TR>
															<TD>
																Nombre:</TD>
															<TD><asp:textbox id="txtNombre" runat="server" Width="260px" Height="20px"></asp:textbox></TD>
														</TR>
													</TABLE>
												</TD>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
													<TABLE class="Criterio">
														<TR>
															<TD style="HEIGHT: 23px">Perfil:</TD>
															<TD colSpan="3"><asp:dropdownlist id="dropPerfil" runat="server" Width="240px" Font-Size="11px" Font-Names="tahoma,sans-serif"></asp:dropdownlist></TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 23px">Estado:</TD>
															<TD style="HEIGHT: 14px">
																<asp:dropdownlist id="dropEstado" runat="server" Width="128px" Font-Names="tahoma,sans-serif" Font-Size="11px"></asp:dropdownlist></TD>
														</TR>
													</TABLE>
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
																height="21">&nbsp;Usuarios&nbsp;</TD>
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
															<TD noWrap width="90"><asp:imagebutton id="imgNuevo" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Nuevo.gif"
																	ToolTip="Nuevo" CausesValidation="False" CssClass="EfectoImagen" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;<asp:LinkButton id="lnkNuevo" runat="server" ToolTip="Nuevo">Nuevo</asp:LinkButton>
															</TD>
															<TD noWrap width="90"><asp:image id="imgImprimir" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_impresora2.gif"
																	ToolTip="Imprimir" CssClass="EfectoImagen" ImageAlign="AbsMiddle" Visible="False"></asp:image>&nbsp;<asp:hyperlink id="lnkImprimir" runat="server" ToolTip="imprimir" NavigateUrl="javascript:window.print()"
																	Visible="False">Imprimir</asp:hyperlink>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<!-- ------------------------------ Inicio Grilla Parametro -------------------------------------- -->
											<TR>
												<TD class="Marco" vAlign="top" width="740" colSpan="4">
													<DIV class="Grid" id="divComercialProp" style="WIDTH: 740px; HEIGHT: 350px">
														<asp:datagrid id="dgrdMnt" runat="server" Width="800px" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False"
															UseAccessibleHeader="True" scope="col" AllowPaging="True" CssClass="GridMnt" BorderStyle="None"
															BorderColor="#3366CC">
															<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
															<EditItemStyle VerticalAlign="Top"></EditItemStyle>
															<ItemStyle CssClass="Registro"></ItemStyle>
															<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
															<Columns>
																<asp:TemplateColumn>
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:ImageButton id="ibtnEditar" runat="server" ImageUrl="../Imagen/iconos/ico_Editar.gif" BorderWidth="0px"
																			ToolTip="Editar Metodizado" ImageAlign="AbsMiddle" CommandName="Editar"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn>
																	<HeaderStyle Width="30px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																	<ItemTemplate>
																		<asp:ImageButton id="ibtnEliminar" runat="server" ImageUrl="../imagen/iconos/ico_Eliminar.gif" BorderWidth="0px"
																			CausesValidation="False" ToolTip="Eliminar" ImageAlign="AbsMiddle" CommandName="Delete"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="CodUsuario" HeaderText="Registro">
																	<HeaderStyle Width="50px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Nombre" HeaderText="Nombre">
																	<HeaderStyle Width="170px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="NomPerfil" HeaderText="Perfil">
																	<HeaderStyle Width="120px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Email" HeaderText="Correo">
																	<HeaderStyle Width="170px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="Analista" HeaderText="Analista">
																	<HeaderStyle Width="170px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="FecReg" HeaderText="Fecha" DataFormatString="{0:d}">
																	<HeaderStyle Width="50px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="DesEstado" HeaderText="Estado">
																	<HeaderStyle Width="50px"></HeaderStyle>
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
