<%@ Import Namespace="CEF.Common.Globals"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rvwExpDescargaData.aspx.vb" Inherits="CEF.WebUI.rvwExpDescargaData"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rvwExpDescargaData</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			&nbsp;&nbsp;&nbsp;
			<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="740" border="0">
				<TR>
					<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4"></TD>
				</TR>
				<!-- ------------------------- Inicio Grilla Descarga --------------------------- -->
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">&nbsp;</TD>
				</TR>
				<!-- ------------------------------ Inicio Grilla Descarga -------------------------------------- -->
				<TR>
					<TD class="Marco" vAlign="top" width="740" colSpan="4">
						<P><asp:datagrid id="dgrdMnt" runat="server" CellPadding="4" AutoGenerateColumns="False" BorderStyle="None"
								BorderColor="#3366CC" CssClass="GridMnt" BorderWidth="1px" Width="1870px" PageSize="20" EnableViewState="False">
								<FooterStyle CssClass="PieRegistro"></FooterStyle>
								<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
								<EditItemStyle VerticalAlign="Top"></EditItemStyle>
								<ItemStyle CssClass="Registro"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="LightBlue"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="CUCliente" HeaderText="C&#243;digo Unico">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
										<FooterStyle Wrap="False"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RazonSocial" HeaderText="Raz&#243;n Social">
										<HeaderStyle Wrap="False" Width="180px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodSBS" HeaderText="C&#243;digo SBS">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TipoDocumento" HeaderText="Tipo de Documento"></asp:BoundColumn>
									<asp:BoundColumn DataField="NumeroDocumento" HeaderText="N&#250;mero de Documento">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodCIIU" HeaderText="C&#243;digo CIIU">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TipoEeff" HeaderText="Tipo">
										<HeaderStyle Width="50px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									
									<asp:BoundColumn DataField="Importe1" HeaderText="Monto Disponible"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe36" HeaderText="Valores Negociables"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe2" HeaderText="Cuenta por Cobrar Comerciales"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe37" HeaderText="Otras Cuentas por Cobrar"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe38" HeaderText="Filiales (o principal) y Afiliadas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe3" HeaderText="Existencias"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe39" HeaderText="Gastos Pagados por Adelantado"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe4" HeaderText="Activo Corriente"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe40" HeaderText="Cuentas por Cob. Com. LP."><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe41" HeaderText="Otras Ctas. Por Cobrar L.P."><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe42" HeaderText="Filiales (o principal) y Afiliadas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe43" HeaderText="Cuentas por Cobrar a Accionistas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe5" HeaderText="Activo Fijo Neto de Depreciación"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe44" HeaderText="Menos: Despreciación Acumulada"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe76" HeaderText="Inversiones en Valores"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe6" HeaderText="Intangibles"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe7" HeaderText="Otras Cuentas del Activo"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe45" HeaderText="Activo no Corriente"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe8" HeaderText="Activos Totales"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe9" HeaderText="Sobregiros y Deuda a Corto Plazo"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe10" HeaderText="Porción Corriente de la Deuda a Largo Plazo"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe11" HeaderText="Cuentas por Pagar Comerciales"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe46" HeaderText="Otras Cuentas por Pagar"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe47" HeaderText="Dividendos por Pagar"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe48" HeaderText="Filiales (o principal) y Afiliadas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe12" HeaderText="Pasivo Corriente"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe13" HeaderText="Deuda a Largo Plazo"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe49" HeaderText="Deuda Financiera LP"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe50" HeaderText="Cuentas por Pagar Comerciales L.P."><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe14" HeaderText="Otras Cuentas del Pasivo"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe51" HeaderText="Filiales (o principal) y Afiliadas L.P."><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe52" HeaderText="Beneficios Sociales"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe53" HeaderText="Pasivo No Corriente"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe15" HeaderText="Pasivos Totales"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe54" HeaderText="Ganancias Diferidas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe55" HeaderText="Otros Pasivos Diferidos"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe56" HeaderText="Intereses Minoritarios"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe16" HeaderText="Capital"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe57" HeaderText="Capital Adicional"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe58" HeaderText="Participación Patrimonial"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe59" HeaderText="Revaluación Voluntaria"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe60" HeaderText="Reservas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe17" HeaderText="Resultados Acumulados"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe18" HeaderText="Patrimonio Neto de la Empresa"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<%-- <asp:BoundColumn DataField="Importe19" HeaderText="Ventas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn> --%>
									<asp:BoundColumn DataField="Importe61" HeaderText="Ventas Terceros"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe62" HeaderText="Ventas Afiliadas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe63" HeaderText="Otros Ingresos Operacionales"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe20" HeaderText="Costo de Ventas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe64" HeaderText="Gasto de Ventas"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe65" HeaderText="Gastos de Administración"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe66" HeaderText="EBITDA"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe67" HeaderText="Depreciación"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe68" HeaderText="Amortización"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<%-- <asp:BoundColumn DataField="Importe21" HeaderText="Gastos de Operación Administrativos y de Venta"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn> --%>
									<asp:BoundColumn DataField="Importe22" HeaderText="Ingresos Financieros"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe23" HeaderText="Gastos Financieros"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe24" HeaderText="Otros Ingresos Netos"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe69" HeaderText="Otros Gastos"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe70" HeaderText="Mas (menos) Resultado x exp. A la inflación/ Ganacia (pérdida) x diferencia en cambio"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe71" HeaderText="Participaciones"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe25" HeaderText="Impuesto a la Renta"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe72" HeaderText="Ingresos (gastos) extraordinarios (Netos de imp.)"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe26" HeaderText="Utilidad Neta"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<%-- <asp:BoundColumn DataField="Importe27" HeaderText="Depreciación y Amortización"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn> --%>
									<asp:BoundColumn DataField="Importe28" HeaderText="Dividendos"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe29" HeaderText="Inversiones de Capital"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe30" HeaderText="Porcentaje Ingreso Moneda Extranjera"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe31" HeaderText="Porcentaje Gasto Moneda Extranjera"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe32" HeaderText="Porcentaje Deuda Bancaria CP Moneda Extranjera"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe33" HeaderText="Porcentaje Deuda Bancaria LP Moneda Extranjera"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe74" HeaderText="Disminución en Caja y Valores Negociables – Soles"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe75" HeaderText="Disminución en Caja y Valores Negociables – Dólares"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe34" HeaderText="% Devaluación Máxima"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe73" HeaderText="% Devaluación Máxima (apreciación máxima)"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									<asp:BoundColumn DataField="Importe35" HeaderText="Grado de Exposición"><HeaderStyle Width="90px"></HeaderStyle><ItemStyle HorizontalAlign="Right"></ItemStyle></asp:BoundColumn>
									
									<asp:BoundColumn DataField="FecPeriodo" HeaderText="MES">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<!-- ------------------------------ Fin Descarga -------------------------------------- --></TABLE>
		</form>
	</body>
</HTML>
