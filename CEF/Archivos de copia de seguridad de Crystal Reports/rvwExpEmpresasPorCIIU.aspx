<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rvwExpEmpresasPorCIIU.aspx.vb" Inherits="CEF.WebUI.rvwExpEmpresasPorCIIU"%>
<%@ Import Namespace="CEF.Common.Globals"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rvwExpEmpresasPorCIIU</title>
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
				<!-- ------------------------- Inicio Grilla Consulta Por CIIU --------------------------- -->
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">&nbsp;</TD>
				</TR>
				<!-- ------------------------------ Inicio Grilla Consulta Por CIIU -------------------------------------- -->
				<TR>
					<TD class="Marco" vAlign="top" width="740" colSpan="4">
						<P><asp:datagrid id="dgrdMnt" runat="server" EnableViewState="False" PageSize="20" Width="1870px"
								BorderWidth="1px" CssClass="GridMnt" BorderColor="#3366CC" BorderStyle="None" AutoGenerateColumns="False"
								CellPadding="4" ShowFooter="True">
								<FooterStyle Font-Bold="True" CssClass="PieRegistro"></FooterStyle>
								<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
								<EditItemStyle VerticalAlign="Top"></EditItemStyle>
								<ItemStyle CssClass="Registro"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="LightBlue"></HeaderStyle>
								<Columns>
									<asp:BoundColumn DataField="RAZON_SOCIAL" HeaderText="MILES DOLARES">
										<HeaderStyle Wrap="False" Width="180px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ACTIVO" HeaderText="Activo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PASIVO" HeaderText="Pasivo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="PATRIMONIO_NETO" HeaderText="Patrimonio Neto">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CAPITAL" HeaderText="Capital">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="INGRESOS_NETOS" HeaderText="Ingresos Netos">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="EBIDTA" HeaderText="EBIDTA">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="UTILIDAD/PERDIDA" HeaderText="Utilidad / Perdida">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MARGEN_BRUTO" HeaderText="Margen Bruto">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MARGEN_OPERATIVO" HeaderText="Margen Operativo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="MARGEN_NETO" HeaderText="Margen Neto">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="CAPITAL_TRABAJO" HeaderText="Capital de Trabajo">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="APALANCAMIENTO" HeaderText="Apalancamiento">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ROTACION_CXC" HeaderText="Rotaci&#243;n de CxC">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ROTACION_CXP" HeaderText="Rotaci&#243;n de CxP">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="ROTACION_EXISTENCIAS" HeaderText="Rotaci&#243;n de Existencias">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="GENERACION_BRUTA_CAJA" HeaderText="Generaci&#243;n Bruta de Caja">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FLUJO_LIBRE_CAJA" HeaderText="Flujo Libre de Caja">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="SERVICIO_DEUDA" HeaderText="Servicio de Deuda">
										<HeaderStyle Width="90px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<!-- ------------------------------ Fin Consulta Por CIIU -------------------------------------- --></TABLE>
		</form>
	</body>
</HTML>
