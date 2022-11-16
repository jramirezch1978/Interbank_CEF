<%@ Page Language="vb" AutoEventWireup="false" Codebehind="consCalendario.aspx.vb" Inherits="ROC.WebUI.consCalendario" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>consCalendario</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Estilos/Calendario.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
		<SCRIPT language="javascript">
		<!--
			function f_RetornaCliente()
			{
				var voFecha = document.getElementById('hidFecha').value;
				var voArgumentos = new Array(voFecha);
				window.returnValue = voArgumentos;
				window.close();
			}
		//-->
		</SCRIPT>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidFecha" type="hidden" name="hidFecha" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="210" align="left" border="0">
				<TR>
					<TD vAlign="top" align="left" width="210">
						<TABLE cellSpacing="0" cellPadding="0" width="210" border="0">
							<TR>
								<TD vAlign="top" align="left" width="210">
									<TABLE cellSpacing="0" cellPadding="0" width="210" border="0">
										<TBODY>
											<TR>
												<TD vAlign="top" width="225" colSpan="4">
													<asp:Calendar id="calFecha" runat="server" Width="210px" Height="185px" PrevMonthText="<img src='../Imagen/iconos/ico_FlechaIzq.gif' border=0 alt='mes anterior'>"
														NextMonthText="<img src='../Imagen/iconos/ico_FlechaDer.gif' border=0 alt='mes siguiente'>"
														FirstDayOfWeek="Monday">
														<DayStyle Font-Size="13px"></DayStyle>
														<DayHeaderStyle Font-Size="14px" Font-Names="Tahoma" ForeColor="#003366"></DayHeaderStyle>
														<SelectedDayStyle Font-Bold="True" ForeColor="Black" BorderColor="Black" BackColor="#FEE671"></SelectedDayStyle>
														<TitleStyle Font-Size="15px" Font-Names="Tahoma" Font-Bold="True" ForeColor="#003366" BackColor="#A9CFEB"></TitleStyle>
														<WeekendDayStyle ForeColor="Red"></WeekendDayStyle>
														<OtherMonthDayStyle ForeColor="DarkGray"></OtherMonthDayStyle>
													</asp:Calendar>
												</TD>
											</TR>
											<TR>
												<TD align="center" width="225" colSpan="4"><IMG Width="0" height="5" src="../Imagen/bordes/brd_sp.gif" border="0"></TD>
											</TR>
											<TR>
												<TD align="center" width="225" colSpan="4">
													<asp:button id="btnAceptar" runat="server" Width="80px" DESIGNTIMEDRAGDROP="1376" CssClass="Boton"
														Text="Aceptar"></asp:button>
												</TD>
											</TR>
										</TBODY>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
