<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntRCD.aspx.vb" Inherits="CEF.WebUI.mntRCD"%>
<%@ Import Namespace="CEF.Common.Globals"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntRCD</title>
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
													noWrap><SPAN class="SearchResultsHeader">Carga y Consulta del Archivo Clientes</SPAN></TD>
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
												<TD vAlign="top" align="right" colSpan="4"><asp:panel id="pnlCabMetodizado" runat="server" Height="24px" Width="308px" HorizontalAlign="Right"><INPUT class="Boton" id="Submit1" style="WIDTH: 67px" type="submit" value="Cargar" name="Submit1"
															runat="server">&nbsp; 
                              </asp:panel></TD>
											</TR>
											<!--pantalla-->
											<TR>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2">
													<TABLE class="Criterio">
														<TR>
															<TD style="HEIGHT: 23px">Archivo Clientes:</TD>
															<TD style="HEIGHT: 14px"><INPUT id="File1" type="file" name="File1" runat="server">
															</TD>
														</TR>
														<TR>
															<TD style="HEIGHT: 23px">Fecha Periodo:</TD>
															<TD style="HEIGHT: 14px"><asp:textbox id="txtFecPeriodo" runat="server" Height="20px" Width="80px" CssClass="NoActivo"
																	MaxLength="10"></asp:textbox>&nbsp;</TD>
														</TR>
													</TABLE>
												</TD>
												<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="50%" colSpan="2"></TD>
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
																height="21">&nbsp;CLIENTES&nbsp;</TD>
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
															<TD noWrap width="90"></TD>
															<TD noWrap width="90">&nbsp;
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<!-- ------------------------------ Inicio Grilla Empresas por CIIU -------------------------------------- -->
											<TR>
												<TD class="Marco" vAlign="top" width="740" colSpan="4">
													<DIV class="Grid" id="divComercialProp" style="WIDTH: 740px; HEIGHT: 560px">
														<asp:datagrid id="dgrdMnt" runat="server" BorderWidth="1px" Width="1210px" CssClass="GridMnt"
															CellPadding="4" AutoGenerateColumns="False" UseAccessibleHeader="True" scope="col" PageSize="20"
															AllowPaging="True" BorderStyle="None" BorderColor="#3366CC">
															<FooterStyle CssClass="PieRegistro"></FooterStyle>
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
																<asp:TemplateColumn Visible="False">
																	<HeaderStyle Width="90px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"CodReg") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtCodReg" runat="server" Width="30" Text='<%# DataBinder.Eval(Container.DataItem,"CodReg") %>'>
																		</asp:TextBox>
																	</EditItemTemplate>
																</asp:TemplateColumn>
																<asp:BoundColumn DataField="CUCliente" ReadOnly="True" HeaderText="C&#243;digo Unico">
																	<HeaderStyle Width="70px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="RazonSocial" ReadOnly="True" HeaderText="Raz&#243;n Social">
																	<HeaderStyle Width="250px"></HeaderStyle>
																	<ItemStyle Wrap="False"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="MontoDeudaSoles" ReadOnly="True" HeaderText="Deuda Soles">
																	<HeaderStyle Width="80px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="MontoDeudaDolares" ReadOnly="True" HeaderText="Deuda Dolares">
																	<HeaderStyle Width="80px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="MontoContingente" ReadOnly="True" HeaderText="Contingente">
																	<HeaderStyle Width="80px"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Right"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="NombreEjecutivo" ReadOnly="True" HeaderText="Ejecutivo">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:BoundColumn>
																<asp:TemplateColumn HeaderText="Sustento/ Observaci&#243;n">
																	<HeaderStyle Width="500px"></HeaderStyle>
																	<ItemTemplate>
																		<%# DataBinder.Eval(Container.DataItem,"Observacion") %>
																	</ItemTemplate>
																	<EditItemTemplate>
																		<asp:TextBox id="txtObservacion" runat="server" Width="490px" MaxLength="255" Text='<%# DataBinder.Eval(Container.DataItem,"Observacion") %>'>
																		</asp:TextBox>
																		<asp:RequiredFieldValidator id="vreqObservacion" runat="server" Display="Dynamic" ControlToValidate="txtObservacion"
																			ErrorMessage="Ingrese la Observación">*</asp:RequiredFieldValidator>
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
											<!--pantalla--></TABLE>
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
