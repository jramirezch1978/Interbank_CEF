<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntGeneral.aspx.vb" Inherits="CEF.WebUI.mntGeneral" EnableEventValidation="false" %>
<%@ Register TagPrefix="Module" TagName="Titulo" Src="../PagWUC/Titulo.ascx" %>
<%@ Register TagPrefix="Module" TagName="Pie" Src="../PagWUC/Pie.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntGeneral</title>
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
			<INPUT id="hidAccionTbl" type="hidden" name="hidItemIndex" runat="server"> <INPUT id="hidAccionItem" type="hidden" name="hidItemIndex" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="720" border="0">
				<TBODY>
					<TR>
						<TD width="100%" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="720" align="center" border="0">
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
													noWrap><SPAN class="SearchResultsHeader">General</SPAN></TD>
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
							<TABLE cellSpacing="0" cellPadding="0" width="720" align="center" border="0">
								<TR>
									<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
											Width="1px"></asp:image></TD>
									<TD class="lightLTbluebg">
										<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="700" align="center" border="0">
											<TR>
												<TD style="HEIGHT: 1px" align="left" colSpan="4"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
											</TR>
											<TR>
												<TD width="700" colSpan="4">
													<TABLE height="21" cellSpacing="0" cellPadding="0" width="700" border="0">
														<TR>
															<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
															<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
															<TD class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
																height="21">&nbsp;Tabla&nbsp;</TD>
															<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
															<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
														</TR>
													</TABLE>
													<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
														height="21" cellSpacing="0" cellPadding="0" width="700">
														<TR class="TabBar">
															<TD width="100">&nbsp;</TD>
															<TD noWrap width="80">Num. Registro:</TD>
															<TD width="100"><asp:label id="lblNumRegTbl" runat="server" Width="98px"></asp:label></TD>
															<TD width="140">&nbsp;</TD>
															<TD noWrap width="90"><asp:imagebutton id="imbNuevoTbl" runat="server" ImageUrl="../imagen/iconos/ico_Nuevo.gif" BorderWidth="0px"
																	CausesValidation="False" ToolTip="Nuevo" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;<asp:hyperlink id="lnkNuevoTbl" runat="server" ToolTip="Nuevo">Nuevo</asp:hyperlink>
															</TD>
															<TD noWrap width="90"><asp:image id="imgImprimirTbl" runat="server" ImageUrl="../imagen/iconos/ico_impresora2.gif"
																	BorderWidth="0px" ToolTip="Imprimir" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkImprimirTbl" runat="server" ToolTip="imprimir" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<!-- ------------------------------ Inicio Grilla General -------------------------------------- -->
											<TR>
												<TD class="Marco" vAlign="top" width="700" colSpan="4">
													<DIV class="Grid" id="divMntTabla" style="WIDTH: 700px; HEIGHT: 340px">
														<asp:datagrid id="dgrdMntTbl" runat="server" BorderWidth="1px" Width="690px" scope="col" UseAccessibleHeader="True"
															AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" BorderStyle="None" BorderColor="#3366CC"
															CssClass="GridMnt">
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
																		<asp:ImageButton id="ibtnEliminarTbl" runat="server" ImageUrl="../imagen/iconos/ico_Eliminar.gif"
																			BorderWidth="0px" CausesValidation="False" ToolTip="Eliminar" ImageAlign="AbsMiddle" CommandName="Delete"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Tabla">
																	<HeaderStyle Width="50px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"CodItem") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtCodTbl" runat="server" Width="45px" Text='<%# DataBinder.Eval(Container.DataItem,"CodItem") %>' MaxLength="4">
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="rfvCodTbl" runat="server" ErrorMessage="Ingrese la tabla" ControlToValidate="txtCodTbl"
																			Display="Dynamic">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Descripci&#243;n">
																	<HeaderStyle Width="200px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"Descripcion") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtDescripcionTbl" runat="server" Width="180px" Text='<%# DataBinder.Eval(Container.DataItem,"Descripcion") %>' MaxLength="70">
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="rfvDescripcionTbl" runat="server" ErrorMessage="Ingrese la descripción" ControlToValidate="txtDescripcionTbl"
																			Display="Dynamic">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Descripci&#243;n Corta">
																	<HeaderStyle Width="190px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"DesCorta") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtDesCortaTbl" runat="server" Width="180px" Text='<%# DataBinder.Eval(Container.DataItem,"DesCorta") %>' MaxLength="70">
																		</asp:TextBox>
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
																		<asp:DropDownList id="dropEstadoTbl" runat="server" Width="82px">
																			<asp:ListItem Value="1">ACTIVO</asp:ListItem>
																			<asp:ListItem Value="2">INACTIVO</asp:ListItem>
																		</asp:DropDownList>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn Visible="False" Text="Seleccionar" CommandName="Select"></asp:ButtonColumn>
															</Columns>
															<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
														</asp:datagrid></DIV>
												</TD>
											</TR>
											<TR>
												<TD width="700" colSpan="4">&nbsp;</TD>
											<TR>
												<TD width="700" colSpan="4">
													<TABLE height="21" cellSpacing="0" cellPadding="0" width="700" border="0">
														<TR>
															<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
															<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
															<TD class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
																height="21">&nbsp;Item&nbsp;</TD>
															<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
															<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
														</TR>
													</TABLE>
													<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
														height="21" cellSpacing="0" cellPadding="0" width="700">
														<TR class="TabBar">
															<TD width="100">&nbsp;</TD>
															<TD noWrap width="80">Num. Registro:</TD>
															<TD width="100"><asp:label id="lblNumRegItem" runat="server" Width="98px"></asp:label></TD>
															<TD width="140">&nbsp;</TD>
															<TD noWrap width="90"><asp:imagebutton id="imbNuevoItem" runat="server" ImageUrl="../imagen/iconos/ico_Nuevo.gif" BorderWidth="0px"
																	CausesValidation="False" ToolTip="Nuevo" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;<asp:hyperlink id="lnkNuevoItem" runat="server" ToolTip="Nuevo">Nuevo</asp:hyperlink>
															</TD>
															<TD noWrap width="90"><asp:image id="imgImprimirItem" runat="server" ImageUrl="../imagen/iconos/ico_impresora2.gif"
																	BorderWidth="0px" ToolTip="Imprimir" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkImprimirItem" runat="server" ToolTip="imprimir" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD class="Marco" vAlign="top" width="700" colSpan="4">
													<DIV class="Grid" id="divMntItem" style="WIDTH: 700px; HEIGHT: 340px">
														<asp:datagrid id="dgrdMntItem" runat="server" BorderWidth="1px" Width="690px" scope="col" UseAccessibleHeader="True"
															AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" BorderStyle="None" BorderColor="#3366CC"
															CssClass="GridMnt">
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
																		<asp:ImageButton id="ibtnEliminarItem" runat="server" ImageUrl="../imagen/iconos/ico_Eliminar.gif"
																			BorderWidth="0px" CausesValidation="False" ToolTip="Eliminar" ImageAlign="AbsMiddle" CommandName="Delete"></asp:ImageButton>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Item">
																	<HeaderStyle Width="50px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"CodItem") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtCodItem" runat="server" Width="45px" MaxLength="4" Text='<%# DataBinder.Eval(Container.DataItem,"CodItem") %>'>
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="rfvCodItem" runat="server" Display="Dynamic" ControlToValidate="txtCodItem"
																			ErrorMessage="Ingrese el item">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Descripci&#243;n">
																	<HeaderStyle Width="200px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"Descripcion") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtDescripcionItem" runat="server" Width="180px" MaxLength="70" Text='<%# DataBinder.Eval(Container.DataItem,"Descripcion") %>'>
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="rfvDescripcionItem" runat="server" Display="Dynamic" ControlToValidate="txtDescripcionItem"
																			ErrorMessage="Ingrese la descripción">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Descripci&#243;n Corta">
																	<HeaderStyle Width="190px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"DesCorta") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtDesCortaItem" runat="server" Width="180px" MaxLength="70" Text='<%# DataBinder.Eval(Container.DataItem,"DesCorta") %>'>
																		</asp:TextBox>
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
																		<asp:DropDownList id="dropEstadoItem" runat="server" Width="82px">
																			<asp:ListItem Value="1">ACTIVO</asp:ListItem>
																			<asp:ListItem Value="2">INACTIVO</asp:ListItem>
																		</asp:DropDownList>
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
									<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
											Width="1px"></asp:image></TD>
								</TR>
							</TABLE>
							<TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="720" align="center" border="0">
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
		</form>
	</body>
</HTML>
