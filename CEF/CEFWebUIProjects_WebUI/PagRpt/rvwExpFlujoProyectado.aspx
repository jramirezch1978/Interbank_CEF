<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rvwExpFlujoProyectado.aspx.vb" Inherits="CEF.WebUI.rvwExpFlujoProyectado" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rvwExpFlujoProyectado</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form2" method="post" runat="server">
			<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="740" border="0">
				<TR>
					<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4"></TD>
				</TR>
				<!-- ------------------------- Inicio Grilla Parametro --------------------------- -->
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">&nbsp;</TD>
				</TR>
				<!-- ------------------------------ Inicio Grilla Parametro -------------------------------------- -->
				<TR>
					<TD class="Marco" vAlign="top" width="740" colSpan="4"><asp:datagrid id="dgrdMnt" runat="server" EnableViewState="False" AutoGenerateColumns="False"
							CellPadding="4" BorderStyle="None" BorderColor="#3366CC" CssClass="GridMnt" BorderWidth="1px" Width="310px">
							<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
							<EditItemStyle VerticalAlign="Top"></EditItemStyle>
							<ItemStyle CssClass="Registro"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="LightBlue"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="Descripcion" HeaderText="Cuenta">
									<HeaderStyle Width="310px"></HeaderStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
						</asp:datagrid></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
