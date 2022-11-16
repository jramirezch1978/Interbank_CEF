<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rvwExpDescargaDataPrioridad.aspx.vb" Inherits="CEF.WebUI.rvwExpDescargaDataPrioridad"%>
<%@ Import Namespace="CEF.Common.Globals"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rvwExpDescargaDataPrioridad</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
					<TD class="Marco" vAlign="top" width="2800" colSpan="4">
						<P><asp:datagrid id="dgrdMnt" runat="server" CellPadding="4" AutoGenerateColumns="True" BorderStyle="None"
								BorderColor="#3366CC" CssClass="GridMnt" BorderWidth="1px" Width="1870px" PageSize="20" EnableViewState="False">
								<FooterStyle CssClass="PieRegistro"></FooterStyle>
								<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
								<EditItemStyle VerticalAlign="Top"></EditItemStyle>
								<ItemStyle CssClass="Registro"></ItemStyle>
								<HeaderStyle Font-Bold="True" HorizontalAlign="Center" BackColor="LightBlue"></HeaderStyle>
								<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
							</asp:datagrid></P>
						<P>&nbsp;</P>
					</TD>
				</TR>
				<!-- ------------------------------ Fin Descarga -------------------------------------- --></TABLE>
		</form>
	</body>
</HTML>
