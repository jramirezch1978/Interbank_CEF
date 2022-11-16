<%@ Register TagPrefix="Module" TagName="Titulo" Src="../PagWUC/Titulo.ascx" %>
<%@ Register TagPrefix="Module" TagName="Pie" Src="../PagWUC/Pie.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntTipoCambio.aspx.vb" Inherits="CEF.WebUI.mntTipoCambio"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntTipoCambio</title>
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
		<script language="JavaScript">
		<!--
			function f_ValidarNumeroDecimal(pobjCtrl) {
				var strPatron = /\.|[0-9]\.?[0-9]{0,3}/;
				var intCodigo = event.keyCode;
				var strCaracter = (String.fromCharCode(event.keyCode));
				var bolValido = strPatron.test(strCaracter);
				var intPosCaracter;

				if (!bolValido) {
					event.returnValue = false;
					return false;
				} else {
					if (intCodigo == 45 || intCodigo == 46)
						if ((intPosCaracter = pobjCtrl.value.indexOf(strCaracter)) != -1) {
							event.returnValue = false;
							return false;
						}
				}
				return true;
			}
		//-->
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidAccion" type="hidden" name="hidItemIndex" runat="server">
			<TABLE cellSpacing="0" cellPadding="0" width="760" border="0">
				<TBODY>
					<TR>
						<TD width="100%" colSpan="2">&nbsp;</TD>
					</TR>
					<TR>
						<TD vAlign="top">
							<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
								<TR>
									<TD width="5" rowSpan="3" colspan="2"><asp:image id="Image4" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Izq_blue.gif"
											Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
									<TD class="lightblueborder" width="99%"><asp:image id="Image6" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
											Width="1px"></asp:image></TD>
									<TD width="5" rowSpan="3" colspan="2"><asp:image id="Image5" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Der_blue.gif"
											Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
								</TR>
								<TR>
									<TD class="lightbluebg">
										<TABLE height="29" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD class="lightbluebg" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 29px"
													noWrap><SPAN class="SearchResultsHeader">Tipo de Cambio/Indice Corrección</SPAN></TD>
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
								<TR>
									<td class="lightblueborder" width="1"></td>
									<TD class="lightbluebg" width="4">
									<TD class="lightbluebg">
										<TABLE class="lightbluebg" id="Table2" style="WIDTH: 99%; HEIGHT: 75px">
											<TR>
												<TD style="WIDTH: 27px"><asp:image id="Image1" runat="server" ImageUrl="../Imagen/iconos/ico_Vineta_blue1.gif"></asp:image></TD>
												<TD style="WIDTH: 50px" class="SearchResultsHeader">Año:</TD>
												<TD><asp:DropDownList id="dropBusAnio" runat="server" Width="150px"></asp:DropDownList></TD>
												<TD><asp:button id="btnBuscar" runat="server" Width="80px" Text="Buscar" CssClass="Boton"></asp:button></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 27px; HEIGHT: 26px"><asp:image id="Image2" runat="server" ImageUrl="../Imagen/iconos/ico_Vineta_blue1.gif"></asp:image></TD>
												<TD style="WIDTH: 50px; HEIGHT: 26px" class="SearchResultsHeader">Mes:</TD>
												<TD style="HEIGHT: 26px"><asp:DropDownList id="dropBusMes" runat="server" Width="150px"></asp:DropDownList></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="10" src="../Imagen/bordes/brd_sp.gif" border="0"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD class="lightbluebg" width="4">
									<td class="lightblueborder" width="1"></td>
								</TR>
							</TABLE>
							<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
								<TR>
									<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
											Width="1px"></asp:image></TD>
									<TD class="lightLTbluebg">
										<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="590" align="center" border="0">
											<TR>
												<TD style="HEIGHT: 1px" align="left" colSpan="4"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
											</TR>
											<TR>
												<TD width="740" colSpan="4">
													<TABLE height="21" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
															<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
															<TD class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
																height="21">&nbsp;Lista&nbsp;</TD>
															<TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
															<TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"></TD>
														</TR>
													</TABLE>
													<TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
														height="21" cellSpacing="0" cellPadding="0" width="100%">
														<TR class="TabBar">
															<TD width="100">&nbsp;</TD>
															<TD noWrap width="80">Num. Registro:</TD>
															<TD width="100"><asp:label id="lblNumReg" runat="server" Width="98px"></asp:label></TD>
															<TD width="140">&nbsp;</TD>
															<TD noWrap width="90"><asp:imagebutton id="imbNuevo" runat="server" ImageUrl="../imagen/iconos/ico_Nuevo.gif" BorderWidth="0px"
																	CausesValidation="False" ToolTip="Nuevo" ImageAlign="AbsMiddle"></asp:imagebutton>&nbsp;<asp:hyperlink id="lnkNuevo" runat="server" ToolTip="Nuevo">Nuevo</asp:hyperlink>
															</TD>
															<TD noWrap width="90"><asp:image id="imgImprimir" runat="server" ImageUrl="../imagen/iconos/ico_impresora2.gif" BorderWidth="0px"
																	ToolTip="Imprimir" ImageAlign="AbsMiddle"></asp:image>&nbsp;<asp:hyperlink id="lnkImprimir" runat="server" ToolTip="imprimir" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<!-- ------------------------------ Inicio Grilla Parametro -------------------------------------- -->
											<TR>
												<TD class="Marco" vAlign="top" width="740" colSpan="4">
													<DIV class="Grid" id="divComercialProp" style="WIDTH: 740px; HEIGHT: 350px" align="left"><asp:datagrid id="dgrdMnt" runat="server" BorderWidth="1px" Width="832px" BorderColor="#3366CC"
															BorderStyle="None" scope="col" UseAccessibleHeader="True" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4">
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
																<asp:TemplateColumn HeaderText="A&#241;o">
																	<HeaderStyle Width="70px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"Anio") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtAnio" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"Anio") %>' CssClass="ActivoNumericoColSel">
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="vreqAnio" runat="server" Display="Dynamic" ControlToValidate="txtAnio" ErrorMessage="Ingrese la descripción">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Mes">
																	<HeaderStyle Width="150px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"DesMes") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:DropDownList id="dropMes" runat="server" Width="100%"></asp:DropDownList>
																		<asp:RequiredFieldValidator id="vreqMes" runat="server" Width="2px" ErrorMessage="Seleccionar el mes" ControlToValidate="dropMes"
																			Display="Dynamic">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Moneda">
																	<HeaderStyle Width="150px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"DesMoneda") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:DropDownList id="dropMoneda" runat="server" Width="100%"></asp:DropDownList>
																		<asp:RequiredFieldValidator id="vreqMoneda" runat="server" Width="2px" Display="Dynamic" ControlToValidate="dropMoneda"
																			ErrorMessage="Seleccionar la moneda">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="TC SBS">
																	<HeaderStyle Width="100px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"Monto") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtMonto" runat="server" Width="100%" MaxLength="10" Text='<%# DataBinder.Eval(Container.DataItem,"Monto") %>' CssClass="ActivoNumericoColSel">
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="vreqMonto" runat="server" Width="2px" Display="Dynamic" ControlToValidate="txtMonto"
																			ErrorMessage="Ingresar el monto de tipo cambio">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="TC Max(RM)">
																	<HeaderStyle Width="100px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"MontoMaximo") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtMontoMaximo" runat="server" Width="100%" MaxLength="10" CssClass="ActivoNumericoColSel" Text='<%# DataBinder.Eval(Container.DataItem,"MontoMaximo") %>'>
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="vreqMontoMaximo" runat="server" Width="2px" ErrorMessage="Ingresar el monto máximo de tipo cambio"
																			ControlToValidate="txtMontoMaximo" Display="Dynamic">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="% Devaluaci&#243;n">
																	<HeaderStyle Width="100px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"PorcentajeDevaluacion") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtPorcentajeDev" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"PorcentajeDevaluacion") %>' CssClass="ActivoNumericoColSel">
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="vreqPorcentajeDev" runat="server" Width="2px" Display="Dynamic" ControlToValidate="txtPorcentajeDev"
																			ErrorMessage="Modificar el Porcentaje de Devaluación del TC">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="TC Min(RM)">
																	<HeaderStyle Width="100px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"MontoMinimo") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtMontoMinimo" runat="server" Width="100%" MaxLength="10" CssClass="ActivoNumericoColSel" Text='<%# DataBinder.Eval(Container.DataItem,"MontoMinimo") %>'>
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="vreqMontoMinimo" runat="server" Width="2px" ErrorMessage="Ingresar el monto minimo de tipo cambio"
																			ControlToValidate="txtMontoMinimo" Display="Dynamic">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="% Apreciaci&#243;n">
																	<HeaderStyle Width="100px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"PorcentajeApreciacion","{0:N2}") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtPorcentajeAprec" runat="server" Width="100%" Text='<%# DataBinder.Eval(Container.DataItem,"PorcentajeApreciacion","{0:N2}") %>' CssClass="ActivoNumericoColSel">
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="vreqPorcentajeAprec" runat="server" Width="2px" Display="Dynamic" ControlToValidate="txtPorcentajeAprec"
																			ErrorMessage="Modificar el Porcentaje de Apreciación del TC">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:TemplateColumn HeaderText="Indice">
																	<HeaderStyle Width="100px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"IndiceReexpresion") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtIndiceReexpresion" runat="server" Width="100%" CssClass="ActivoNumericoColSel" Text='<%# DataBinder.Eval(Container.DataItem,"IndiceReexpresion") %>'>
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="vreqIndice" runat="server" Width="2px" ErrorMessage="Ingresar el indice de Corrección"
																			ControlToValidate="txtIndiceReexpresion" Display="Dynamic">*</asp:RequiredFieldValidator>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="FecReg" ReadOnly="True" HeaderText="Fecha" DataFormatString="{0:d}">
																	<HeaderStyle Width="80px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:TemplateColumn HeaderText="Estado">
																	<HeaderStyle Width="100px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"DesEstado") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:DropDownList id="dropEstado" runat="server" Width="100%"></asp:DropDownList>
																		<asp:RequiredFieldValidator id="vreqEstado" runat="server" Display="Dynamic" ControlToValidate="dropEstado"
																			ErrorMessage="Seleccione el estado">*</asp:RequiredFieldValidator>
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
		</form>
	</body>
</HTML>
