<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntOperador.aspx.vb" Inherits="CEF.WebUI.mntOperador"%>
<%@ Register TagPrefix="Module" TagName="Pie" Src="../PagWUC/Pie.ascx" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../PagWUC/Menu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Titulo" Src="../PagWUC/Titulo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntParametro</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript">
		<!--
			function document.onkeypress() {if (event.keyCode == 13) event.returnValue = false;}
		//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidAccion" type="hidden" name="hidItemIndex" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="550" align="left" bgColor="#ffffff"
				border="0">
				<TR>
					<TD style="HEIGHT: 5px" width="100%"><MODULE:TITULO id="modTitulo" runat="server" PathPrefix=".."></MODULE:TITULO></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 5px" width="100%" bgColor="#e1e0e0"><MODULE:MENU id="modMenu" runat="server" PathPrefix=".."></MODULE:MENU></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" width="550">
						<TABLE cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD width="10">&nbsp;</TD>
								<TD vAlign="top" align="left" width="530">
									<TABLE cellSpacing="0" cellPadding="0" width="530" border="0">
										<TBODY>
											<TR>
												<TD width="100%" colSpan="2">&nbsp;</TD>
											</TR>
											<TR>
												<TD vAlign="top">
													<TABLE cellSpacing="0" cellPadding="0" width="530" align="center" border="0">
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
																			noWrap><SPAN class="SearchResultsHeader">Operador</SPAN></TD>
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
													<TABLE cellSpacing="0" cellPadding="0" width="530" align="center" border="0">
														<TR>
															<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" Width="1px" BorderWidth="0px" Height="1px" ImageUrl="../Imagen/bordes/brd_sp.gif"></asp:image></TD>
															<TD class="lightLTbluebg">
																<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="510" align="center" border="0">
																	<TR>
																		<TD style="HEIGHT: 1px" align="left" colSpan="4"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
																	</TR>
																	<TR>
																		<TD width="510" colSpan="4">
																			<TABLE height="21" cellSpacing="0" cellPadding="0" width="100%" border="0">
																				<TR>
																					<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
																					<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
																					<TD class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
																						height="21">
																						&nbsp;Lista&nbsp;</TD>
																					<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
																					<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
																				</TR>
																			</TABLE>
																			<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
																				height="21" cellSpacing="0" cellPadding="0" width="100%">
																				<TR class="TabBar">
																					<TD width="100">&nbsp;</TD>
																					<TD noWrap width="80">Num. Registro:</TD>
																					<TD width="100"><asp:label id="lblNumReg" runat="server" Width="98px"></asp:label></TD>
																					<TD width="140">&nbsp;</TD>
																					<TD noWrap width="90"><asp:imagebutton id="imbNuevo" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Nuevo.gif"
																							ToolTip="Nuevo" CausesValidation="False" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;<asp:hyperlink id="lnkNuevo" runat="server" ToolTip="Nuevo">Nuevo</asp:hyperlink>
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
																		<TD class="Marco" vAlign="top" width="510" colSpan="4">
																			<DIV class="Grid" id="divComercialProp" style="WIDTH: 510px; HEIGHT: 350px"><asp:datagrid id="dgrdMnt" runat="server" Width="500px" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False"
																					AllowPaging="True" UseAccessibleHeader="True" scope="col" BorderColor="#3366CC" BorderStyle="None" CssClass="GridMnt">
																					<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
																					<EditItemStyle VerticalAlign="Top"></EditItemStyle>
																					<ItemStyle CssClass="Registro"></ItemStyle>
																					<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
																					<Columns>
																						<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="&lt;img src='../imagen/iconos/ico_Grabar.gif' alt='Grabar' border=0/&gt;"
																							CancelText="&lt;img src='../imagen/iconos/ico_Cancelar.gif' alt='Cancelar' border=0/&gt;" EditText="&lt;img src='../imagen/iconos/ico_Editar.gif' alt='Modificar' border=0/&gt;">
																							<HeaderStyle Width="30px"></HeaderStyle>
																							<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																						</asp:EditCommandColumn>
																						<asp:TemplateColumn>
																							<HeaderStyle Width="30px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																							<ItemTemplate>
																								<asp:ImageButton id="ibtnEliminar" runat="server" ImageUrl="../imagen/iconos/ico_Eliminar.gif" BorderWidth="0px"
																									CausesValidation="False" ToolTip="Eliminar" ImageAlign="AbsMiddle" CommandName="Delete"></asp:ImageButton>
																							</ItemTemplate>
																						</asp:TemplateColumn>
																						<asp:TemplateColumn HeaderText="Descripci&#243;n">
																							<HeaderStyle Width="190px"></HeaderStyle>
																							<ItemTemplate>
																								<%# DataBinder.Eval(Container.DataItem,"Descripcion") %>
																							</ItemTemplate>
																							<EditItemTemplate>
																								<asp:TextBox id=txtDescripcion runat="server" Width="180px" Text='<%# DataBinder.Eval(Container.DataItem,"Descripcion") %>' MaxLength="70">
																								</asp:TextBox>
																								<asp:RequiredFieldValidator id="vreqDescripcion" runat="server" ErrorMessage="Ingrese la descripción" ControlToValidate="txtDescripcion"
																									Display="Dynamic">*</asp:RequiredFieldValidator>
																							</EditItemTemplate>
																						</asp:TemplateColumn>
																						<asp:TemplateColumn HeaderText="Simbolo">
																							<HeaderStyle Width="70px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center"></ItemStyle>
																							<ItemTemplate>
																								<%# DataBinder.Eval(Container.DataItem,"Simbolo") %>
																							</ItemTemplate>
																							<EditItemTemplate>
																								<asp:TextBox id=txtSimbolo runat="server" Width="65px" MaxLength="1" Text='<%# DataBinder.Eval(Container.DataItem,"Simbolo") %>'>
																								</asp:TextBox>
																								<asp:RequiredFieldValidator id="vreqSimbolo" runat="server" Display="Dynamic" ControlToValidate="txtSimbolo"
																									ErrorMessage="Ingrese el simbolo del operador">*</asp:RequiredFieldValidator>
																							</EditItemTemplate>
																						</asp:TemplateColumn>
																						<asp:BoundColumn DataField="FecReg" ReadOnly="True" HeaderText="Fec.Reg." DataFormatString="{0:d}">
																							<HeaderStyle Width="80px"></HeaderStyle>
																							<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						</asp:BoundColumn>
																						<asp:TemplateColumn HeaderText="Estado">
																							<HeaderStyle Width="100px"></HeaderStyle>
																							<ItemTemplate>
																								<%# DataBinder.Eval(Container.DataItem,"DesEstado") %>
																							</ItemTemplate>
																							<EditItemTemplate>
																								<asp:DropDownList id="dropEstado" runat="server" Width="82px"></asp:DropDownList>
																								<asp:RequiredFieldValidator id="vreqEstado" runat="server" ErrorMessage="Seleccione el estado" ControlToValidate="dropEstado"
																									Display="Dynamic">*</asp:RequiredFieldValidator>
																							</EditItemTemplate>
																						</asp:TemplateColumn>
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
													<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="530" align="center" border="0">
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
								</TD>
								<TD width="10" bgColor="#ffffff">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
