<%@ Import Namespace="CEF.Common.Globals"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rvwExpInformeSBS.aspx.vb" Inherits="CEF.WebUI.rvwExpInformeSBS"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rvwExpSucave</title>
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
				<!-- ------------------------- Inicio Grilla Sucave --------------------------- -->
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">&nbsp;</TD>
				</TR>
				<!-- ------------------------------ Inicio Grilla Sucave -------------------------------------- -->
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
									<asp:BoundColumn DataField="RUC" HeaderText="RUC">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodCIIU" HeaderText="C&#243;digo CIIU">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CodTipoEeff" HeaderText="Tipo">
										<HeaderStyle Width="50px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Disponible" HeaderText="Disponible">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CtasCobrarCom" HeaderText="Cuenta por Cobrar Comerciales">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Existencias" HeaderText="Existencias">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ActivoCorr" HeaderText="Activo Corriente">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ActivoFijNeDep" HeaderText="Activo Fijo Neto de Depreciaci&#243;n">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Intangibles" HeaderText="Intangibles">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OtrasCtasActiv" HeaderText="Otras Cuentas del Activo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ActivosTotales" HeaderText="Activos Totales">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SobgirDeuCorPl" HeaderText="Sobregiros y Deuda a Corto Plazo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PorCorrDeudaLP" HeaderText="Porci&#243;n Corriente de la Deuda a Largo Plazo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CtasPagarComer" HeaderText="Cuentas por Pagar Comerciales">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PasivoCorr" HeaderText="Pasivo Corriente">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DeudaLargoPla" HeaderText="Deuda a Largo Plazo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OtrasCtasPasiv" HeaderText="Otras Cuentas del Pasivo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PasivosTotales" HeaderText="Pasivos Totales">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Capital" HeaderText="Capital">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ResulAcumulado" HeaderText="Resultados Acumulados">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PatrimNetoEmpr" HeaderText="Patrimonio Neto de la Empresa">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Ventas" HeaderText="Ventas">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OtrosIngresosOp" HeaderText="Otros Ingresos Operacionales">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CostoVentas" HeaderText="Costo de Ventas">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="GasOpAdmVtas" HeaderText="Gastos de Operaci&#243;n Administrativos y de Venta">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="IngFinan" HeaderText="Ingresos Financieros">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="GastFinan" HeaderText="Gastos Financieros">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OtrosIngNeto" HeaderText="Otros Ingresos Netos">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ImpuestRenta" HeaderText="Impuesto a la Renta">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UtilNeta" HeaderText="Utilidad Neta">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Contingente" HeaderText="Contingente">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="DepAmortiza" HeaderText="Depreciaci&#243;n y Amortizaci&#243;n">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Dividendos" HeaderText="Dividendos">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="InverCapital" HeaderText="Inversiones de Capital">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="OpeMomedaE" HeaderText="Operaciones en Moneda Extranjera">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PosicionCam" HeaderText="Posici&#243;n de Cambio">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PorcenIngME" HeaderText="% de Ingreso en Moneda Extranjera" DataFormatString="{0:N2}">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PorcenGasME" HeaderText="% Gasto en Moneda Extranjera" DataFormatString="{0:N2}">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PasivoCorrME" HeaderText="Pasivo Corriente en Moneda Extranjera">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PorcenDevalMax" HeaderText="% Devaluación Máxima (apreciación máxima)" DataFormatString="{0:N2}">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Mes" HeaderText="MES">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<!-- ------------------------------ Fin Sucave -------------------------------------- --></TABLE>
		</form>
	</body>
</HTML>
