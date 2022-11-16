<%@ Page Language="vb" AutoEventWireup="false" Codebehind="busSeleccionarPeriodoProyeccion.aspx.vb" EnableEventValidation="false" Inherits="CEF.WebUI.busSeleccionarPeriodoProyeccion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>busSeleccionarPeriodoProyeccion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Estilos/PagLst.css">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
		<script language="JavaScript" src="../Funciones/UtilAjax.js"></script>
		<script language="JavaScript">
			function f_Aceptar(){
				var gvdgrdMnt = document.getElementById('dgrdMnt').tBodies[0].rows;
				var retorno = "";
				if(gvdgrdMnt != null){
					for(var i=1; i<gvdgrdMnt.length; i++){
						var ControlsInput = gvdgrdMnt[i].getElementsByTagName('input');
						var checkIt= null;
						checkIt=ControlsInput[0];
						if(checkIt.checked){
							retorno = retorno + checkIt.value + ";"
						}
					}
					window.returnValue = retorno;
					//alert(retorno);
					window.close();
				}
			}
		
			function VerificarEliminacion(){
				var answer = confirm("La eliminación es permanente, ¿desea continuar?");
				if (answer)
					document.getElementById('hidConfirmacion').value='1';
				else
					document.getElementById('hidConfirmacion').value='0';
			}
			
			function f_AbrirProyeccionCuenta(pstrUrl,pintWidth,pintHeight){
				var	objParametro=null;
				var voArgumentos = new Array(objParametro);
				voArgumentos = f_MskVtnDlg(pstrUrl,voArgumentos,pintWidth,pintHeight);
				
				if(voArgumentos != null){
					document.getElementById('BtnAccionActualizarGrilla').click();
				}
			}
			
			function f_AbrirProyeccionCuenta4Update(commandArgument){
				var intcodMetodizado = document.getElementById('hidCodMetodizado').value;
				var strrazonSocial   = document.getElementById('hidRazonSocial').value;
				
				var pstrUrl = "mntPeriodoProyeccion.aspx?intCodMetodizado=" + intcodMetodizado + "&strRazonSocial=" + strrazonSocial +
							  "&intCodProyeccion="+ commandArgument + "&strAccion='EDITAR'";
							  
				return f_AbrirProyeccionCuenta(pstrUrl,530,500);
			}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<INPUT id="hidMntAccion" type="hidden" name="hidMntAccion" runat="server"> <INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">
			<INPUT id="hidRazonSocial" type="hidden" name="hidRazonSocial" runat="server">
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
								<TD rowSpan="3" width="5"><asp:image id="Image4" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Izq_blue.gif"
										Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
								<TD class="lightblueborder" width="99%"><asp:image id="Image6" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
										Width="1px"></asp:image></TD>
								<TD rowSpan="3" width="5"><asp:image id="Image5" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Der_blue.gif"
										Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
							</TR>
							<TR>
								<TD class="lightbluebg">
									<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" height="29">
										<TR>
											<TD style="PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; HEIGHT: 29px; PADDING-TOP: 5px"
												class="lightbluebg" noWrap><SPAN class="SearchResultsHeader">Seleccionar Periodo 
													Proyectado</SPAN></TD>
											<TD width="99%">&nbsp;</TD>
											<TD><asp:image id="imgCerrar" runat="server" ImageUrl="../Imagen/iconos/ico_Cerrar.gif" BorderWidth="0px"
													ToolTip="Cerrar" CssClass="BotonCerrar"></asp:image></TD>
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
								<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
										Width="1px"></asp:image></TD>
								<TD class="lightLTbluebg">
									<TABLE class="Criterio" border="0" cellSpacing="1" cellPadding="0" width="390" align="center">
										<TR>
											<TD style="HEIGHT: 1px" colSpan="4" align="left"><asp:validationsummary id="vsmMnt" runat="server"></asp:validationsummary></TD>
										</TR>
										<TR>
											<TD vAlign="top" colSpan="4" align="right"><asp:panel id="pnlCabMetodizado" runat="server" Height="24px" Width="308px" HorizontalAlign="Right">&nbsp;&nbsp;&nbsp;</asp:panel></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 1px" class="Marco" vAlign="top" width="100%" colSpan="4">
												<TABLE class="Criterio">
													<TR>
														<TD style="WIDTH: 65px">Razón&nbsp;Social:</TD>
														<TD style="WIDTH: 100px"><asp:textbox id="txtRazonSocial" runat="server" Height="20px" Width="296px" CssClass="NoActivo"
																MaxLength="20"></asp:textbox></TD>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG border="0" src="../Imagen/bordes/brd_sp.gif" width="0" height="18">
												<INPUT style="WIDTH: 0px; HEIGHT: 0px" id="hidConfirmacion" type="hidden" runat="server"
													value="0">
												<asp:Button ID="BtnAccionActualizarGrilla" Runat="server" Text="ActualizarGrilla" Width="0px"
													Height="0px"></asp:Button>
											</TD>
										</TR>
										<TR>
											<TD width="390" colSpan="4">
												<TABLE border="0" cellSpacing="0" cellPadding="0" width="390" height="21">
													<TR>
														<TD height="21" background="../imagen/bordes/brd_TabLin_blue.gif" width="7"><IMG alt="" src="../imagen/bordes/brd_sp.gif" width="7" height="1"></TD>
														<TD height="21" width="6"><IMG alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6" height="21"></TD>
														<TD class="TabActivo" title="Ver Periodos" onclick="return true;" height="21" background="../imagen/bordes/brd_TabActivo_blue.gif"
															noWrap>&nbsp;Periodos Proyectados&nbsp;</TD>
														<TD height="21" width="6"><IMG alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6" height="21"></TD>
														<TD height="21" background="../imagen/bordes/brd_TabLin_blue.gif" width="88%"><IMG alt="" src="../imagen/bordes/brd_sp.gif" width="7" height="1"></TD>
													</TR>
												</TABLE>
												<TABLE style="BORDER-BOTTOM: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-RIGHT: #a9cfeb 1px solid"
													cellSpacing="0" cellPadding="0" width="390" height="21">
													<TR class="TabBar">
														<TD width="100">&nbsp;</TD>
														<TD width="80" noWrap>Num. Registro:</TD>
														<TD width="100"><asp:label id="lblNumReg" runat="server" Width="98px"></asp:label></TD>
														<TD width="50">&nbsp;</TD>
														<TD width="90" noWrap><asp:imagebutton id="ibtnNuevo" runat="server" ImageUrl="../Imagen/iconos/ico_Nuevo.gif" BorderWidth="0px"
																ToolTip="Nuevo" ImageAlign="AbsMiddle" CausesValidation="False"></asp:imagebutton>&nbsp;<asp:hyperlink id="lnkNuevo" runat="server" ToolTip="Nuevo">Nuevo</asp:hyperlink>
														</TD>
														<TD width="90" noWrap>&nbsp;
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<!-- ------------------------------ Inicio Grilla Parametro -------------------------------------- -->
										<TR>
											<TD class="Marco" vAlign="top" width="390" colSpan="4">
												<DIV style="WIDTH: 390px; HEIGHT: 320px" id="divComercialProp" class="Grid"><asp:datagrid id="dgrdMnt" runat="server" BorderWidth="1px" Width="330px" CssClass="GridMnt" scope="col"
														UseAccessibleHeader="True" AutoGenerateColumns="False" CellPadding="4" BorderStyle="None" BorderColor="#3366CC">
														<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
														<EditItemStyle VerticalAlign="Top"></EditItemStyle>
														<ItemStyle CssClass="Registro"></ItemStyle>
														<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn>
																<HeaderStyle Width="30px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<INPUT id="chkItem" type="checkbox" runat="server" value='<%# DataBinder.Eval(Container.DataItem,"CODPROYECCION") %>' NAME="chkItem">
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn ItemStyle-HorizontalAlign="Right" DataField="FECHAPROYECCION" HeaderText="Periodo">
																<HeaderStyle Width="110px"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="FECHAREGISTRO" ItemStyle-HorizontalAlign="Right" HeaderText="Fecha de Proyeccion"
																DataFormatString="{0:MM/yyyy}">
																<HeaderStyle Width="110px"></HeaderStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ESTADODESC" HeaderText="Estado">
																<HeaderStyle Width="110px"></HeaderStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn>
																<ItemStyle HorizontalAlign="Center"></ItemStyle>
																<ItemTemplate>
																	<asp:ImageButton CommandName="Editar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CODPROYECCION") %>' ID="imgEditar" OnClick="ManejadorCrudProyeccion" Runat="server" ImageUrl="../Imagen/iconos/ico_Editar.gif">
																	</asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<ItemTemplate>
																	<asp:ImageButton CommandName="Eliminar" CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DATOSPROY") %>' ID="imgEliminar" OnClick="ManejadorCrudProyeccion" Runat="server" ImageUrl="../Imagen/iconos/ico_Eliminar.gif">
																	</asp:ImageButton>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
													</asp:datagrid></DIV>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG border="0" src="../Imagen/bordes/brd_sp.gif" width="0" height="10"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD class="lightblueborder" width="1"><asp:image id="Image8" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
										Width="1px"></asp:image></TD>
							</TR>
						</TABLE>
						<TABLE style="HEIGHT: 6px" border="0" cellSpacing="0" cellPadding="0" width="410" align="center">
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
					<TD width="10">&nbsp;</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
