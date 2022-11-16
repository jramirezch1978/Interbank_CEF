	<%@ Page Language="vb" AutoEventWireup="false" Codebehind="mntPeriodoNota.aspx.vb" Inherits="CEF.WebUI.mntPeriodoNota"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>mntPeriodoNota</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../Estilos/PagLst.css">
		<script language="javascript" type="text/javascript">
			function ltrim(s) {return s.replace(/^\s+/, "");}
			function rtrim(s) {return s.replace(/\s+$/, "");}
			function trim(s) {return rtrim(ltrim(s));}
			function f_Aceptar(){
			
				//alert('ClientCall');
        		var gvRecuperacion = document.getElementById('dgdPeriodoNota').tBodies[0].rows;
				var dest= "";
		        var codMetodizado	= document.getElementById('HID_CodMetodizado').value;
		        var arrayPeriodo	= document.getElementById('HID_CodPeriodoFiltrado').value.split(";").reverse();        
		        var codCuenta		= document.getElementById('HID_CodCuenta').value;
		        var codClientId		= document.getElementById('HID_CodClientID').value;
		        
		        //alert(codClientId);
		        var ixt=1;
		        
				if (gvRecuperacion != null)
				{
					for(var i = 1; i < gvRecuperacion.length; i++)
					{                    
						var ControlsInput   = gvRecuperacion[i].getElementsByTagName('textarea');  
						var txtNota   = null; 
		                
						for(var j = 0; j < ControlsInput.length; j++)
						{
							var ControlInput= ControlsInput[j];  
							if (ControlInput.id.indexOf('txtNota') > -1) { txtNota = ControlInput; }
		                    
							if (txtNota!= null)
							{
								if(trim(txtNota.value)!= "") ixt=ixt*0; else ixt=ixt*1;
								dest += codMetodizado + "|" + arrayPeriodo[i-1] + "|" + codCuenta + "|" + txtNota.value;
								break; 
							}                
						}
						dest+="*";
					}
					document.getElementById('HID_Idtx').value = ixt;
					dest = dest.substring(0,dest.length-1);
					document.getElementById('HID_EnviaDatos').value = dest;				
				}
				EnviarDatos();
				//EnviarDatos(EnviarDatos_CallBack);
				////EnviarDatos(control,flag,EnviarDatos_CallBack);
				//EnviarDatos(dest,codClientId,ixt);
				////EnviarDatos(dest,EnviarDatos_CallBack);
		}
		function EnviarDatos(){
			document.getElementById('BtnAccionEnviarDatos').click();	
			window.returnValue = document.getElementById('HID_CodClientID').value + "*" + document.getElementById('HID_Idtx').value ;
			window.close();
		}
		
		/*
		function EnviarDatos(cadena,control,flag){
			//cambiar este llamado
			var res = mntPeriodoNota.EnviarDatos(cadena).value;
			if(res){
				window.returnValue = control + "*" + flag ;
				window.close();
			}
		}
		function EnviarDatos_CallBack(res){
			//alert(document.getElementById('HID_RptaServer').value);
			if(res){
			//if(document.getElementById('HID_RptaServer').value == "1"){
				//window.returnValue = control + "*" + flag ;
				window.returnValue = document.getElementById('HID_CodClientID').value + "*" + document.getElementById('HID_Idtx').value ;
				window.close();
			}
		}	
		*/	
		</script>
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
												class="lightbluebg" noWrap><SPAN class="SearchResultsHeader">Mantenimiento Nota</SPAN></TD>
											<TD width="99%">&nbsp;</TD>
											<TD><IMG style="BorderWidth: 0px" id="imgCerrar" class="BotonCerrar" onclick="window.close();"
													src="../Imagen/iconos/ico_Cerrar.gif">
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="410" align="center">
							<TR>
								<TD class="lightblueborder" width="1"><asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
										Width="1px"></asp:image></TD>
								<TD class="lightLTbluebg">
									<TABLE class="Criterio" border="0" cellSpacing="1" cellPadding="0" width="390" align="center">
										<TR>
											<TD style="HEIGHT: 1px" colSpan="4" align="left"><asp:validationsummary id="vsmMnt" runat="server" Width="352px"></asp:validationsummary></TD>
										</TR>
										<TR>
											<TD vAlign="top" colSpan="4" align="right"></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 1px" class="Marco" vAlign="top" width="100%" colSpan="4">
												<TABLE class="Criterio">
													<TR>
														<TD style="WIDTH: 65px">Razón&nbsp;Social:</TD>
														<TD style="WIDTH: 100px"><asp:textbox id="txtRazonSocial" runat="server" Height="20px" Width="296px" MaxLength="20" ReadOnly="True"
																CssClass="NoActivo"></asp:textbox></TD>
													</TR>
													<tr>
														<td style="WIDTH: 65px">Cuenta</td>
														<td style="WIDTH: 100px"><asp:textbox id="txtCuenta" Height="20px" Width="296px" CssClass="NoActivo" Runat="server"></asp:textbox></td>
													</tr>
													<tr>
														<td style="WIDTH: 65px">Metodizado</td>
														<td style="WIDTH: 100px"><asp:textbox id="txtCodMetodizado" Height="20px" Width="296px" CssClass="NoActivo"
																Runat="server"></asp:textbox></td>
													</tr>
												</TABLE>
												<input style="WIDTH: 0px; HEIGHT: 0px" id="HID_RptaServer" type="hidden" runat="server"
													NAME="HID_RptaServer"> <input style="WIDTH: 0px; HEIGHT: 0px" id="HID_EnviaDatos" type="hidden" runat="server"
													NAME="HID_EnviaDatos"> <input style="WIDTH: 0px; HEIGHT: 0px" id="HID_CodMetodizado" type="hidden" runat="server"
													NAME="HID_CodMetodizado"> <input style="WIDTH: 0px; HEIGHT: 0px" id="HID_CodPeriodoFiltrado" type="hidden" runat="server"
													NAME="HID_CodPeriodoFiltrado"> <input style="WIDTH: 0px; HEIGHT: 0px" id="HID_CodCuenta" type="hidden" runat="server"
													NAME="HID_CodCuenta"> <input style="WIDTH: 0px; HEIGHT: 0px" id="HID_CodClientID" type="hidden" runat="server"
													NAME="HID_CodClientID"> <input style="WIDTH: 0px; HEIGHT: 0px" id="HID_Idtx" type="hidden" runat="server" NAME="HID_Idtx">
												<asp:Button id="BtnAccionEnviarDatos" runat="server" Text="EnviarDatos" Width="0px" Height="0px"></asp:Button>
											</TD>
										</TR>
										<TR>
											<TD width="390" colSpan="4">
												<TABLE border="0" cellSpacing="0" cellPadding="0" width="390" height="21">
													<TR>
														<TD height="21" background="../imagen/bordes/brd_TabLin_blue.gif" width="7"><IMG alt="" src="../imagen/bordes/brd_sp.gif" width="7" height="1"></TD>
														<TD height="21" width="6"><IMG alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6" height="21"></TD>
														<TD class="TabActivo" title="Ver Periodos" onclick="return true;" height="21" background="../imagen/bordes/brd_TabActivo_blue.gif"
															noWrap>&nbsp;Periodos&nbsp;</TD>
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
																ImageAlign="AbsMiddle" CausesValidation="False" Visible="False" ToolTip="Nuevo"></asp:imagebutton>&nbsp;<asp:hyperlink id="lnkNuevo" runat="server" Visible="False" ToolTip="Nuevo">Nuevo</asp:hyperlink>
														</TD>
														<TD width="90" noWrap><asp:image id="imgImprimir" runat="server" ImageUrl="../imagen/iconos/ico_impresora2.gif" BorderWidth="0px"
																CssClass="EfectoImagen" ImageAlign="AbsMiddle" Visible="False" ToolTip="Imprimir"></asp:image>&nbsp;<asp:hyperlink id="lnkImprimir" runat="server" Visible="False" ToolTip="imprimir" NavigateUrl="javascript:window.print()">Imprimir</asp:hyperlink>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<!-- ------------------------------ Inicio Grilla Parametro -------------------------------------- -->
										<TR>
											<TD class="Marco" vAlign="top" width="390" colSpan="4">
												<DIV style="WIDTH: 390px; HEIGHT: 320px" id="divComercialProp" class="Grid"><asp:datagrid id="dgdPeriodoNota" runat="server" BorderWidth="1px" CssClass="GridMnt" scope="col"
														UseAccessibleHeader="True" AutoGenerateColumns="False" CellSpacing="1" CellPadding="1" BorderStyle="None" BorderColor="#3366CC">
														<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
														<EditItemStyle VerticalAlign="Top"></EditItemStyle>
														<ItemStyle CssClass="Registro" Width="100%" Wrap="False"></ItemStyle>
														<HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="Periodo">
																<ItemTemplate>
																	<table cellSpacing="0" cellPadding="0" width="100%" border="0">
																		<tr class="ColNoSeleccion">
																			<td style="FONT-WEIGHT: bold; BORDER-BOTTOM: white 1px solid" align="center">
																				<asp:Literal ID="ltFechaPeriodo" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FechaPeriodo") %>'>
																				</asp:Literal><br>
																				<asp:Literal ID="litCodPeriodo" Visible=False Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODPERIODO") %>'>
																				</asp:Literal>
																			</td>
																		</tr>
																		<tr class="ColNoSeleccion">
																			<td style="BORDER-BOTTOM: white 1px solid">
																				<asp:Literal ID="ltSituacion" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SITUACION") %>'>
																				</asp:Literal>
																			</td>
																		</tr>
																		<tr class="ColNoSeleccion">
																			<td style="BORDER-BOTTOM: white 1px solid">
																				<asp:Literal ID="ltEstado" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ESTADO") %>'>
																				</asp:Literal>
																			</td>
																		</tr>
																		<!--
																		<tr class="ColNoSeleccion">
																			<td style="BORDER-BOTTOM: white 1px solid">
																				<asp:Literal ID="ltAuditorDesc" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AUDITORDESC") %>'>
																				</asp:Literal>
																			</td>
																		</tr>
																		-->
																		<!--
																		<tr class="ColNoSeleccion">
																			<td>
																				<asp:Literal ID="ltNombreusuario" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOMBREUSUARIO") %>'>
																				</asp:Literal>
																			</td>
																		</tr>
																		-->
																	</table>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Nota" ItemStyle-CssClass="itemStyleTemplate">
																<ItemTemplate>
																	<asp:TextBox CssClass="itemStyleTemplate" Columns=30 TextMode="MultiLine" Rows="3" ID="txtNota" Runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NOTA") %>'>
																	</asp:TextBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" ItemStyle-CssClass="itemStyleTemplate_2">
																<ItemTemplate>
																	<asp:literal id="ltCodMetodizado" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODMETODIZADO") %>'>
																	</asp:literal>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" ItemStyle-CssClass="itemStyleTemplate_2">
																<ItemTemplate>
																	<asp:literal id="ltCodPeriodo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODPERIODO") %>' >
																	</asp:literal>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn Visible="False" ItemStyle-CssClass="itemStyleTemplate_2">
																<ItemTemplate>
																	<asp:literal id="ltCodCuenta" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.CODCUENTA") %>' >
																	</asp:literal>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></DIV>
											</TD>
										</TR>
										<TR>
											<TD colSpan="4"><IMG border="0" src="../Imagen/bordes/brd_sp.gif" width="0" height="10">
												<asp:panel style="Z-INDEX: 0" id="pnlCabMetodizado" runat="server" Height="24px" HorizontalAlign="Right"><INPUT style="TEXT-ALIGN: center; WIDTH: 56px; HEIGHT: 20px" id="BtnAceptar" class="boton"
														onclick="f_Aceptar();" value="Aceptar" size="4" height="20" name="BtnAceptar" runat="server" Text="Button">&nbsp;&nbsp;&nbsp;</asp:panel></TD>
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
