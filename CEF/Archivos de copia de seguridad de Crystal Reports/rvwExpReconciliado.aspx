<%@ Import Namespace="CEF.Common.Globals"%>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rvwExpReconciliado.aspx.vb" Inherits="CEF.WebUI.rvwExpReconciliado"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rvwExpReconciliado</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="hidCodMetodizado" type="hidden" name="hidCodMetodizado" runat="server">&nbsp;
			<INPUT id="hidPeriodoFiltrado" type="hidden" name="hidPeriodoFiltrado" runat="server">&nbsp;
			<TABLE class="Criterio" cellSpacing="1" cellPadding="0" width="740" border="0">
				<TR>
					<TD class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
					</TD>
				</TR>
				<!-- ------------------------- Inicio Grilla Reconciliación --------------------------- -->
				<TR>
					<TD style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">&nbsp;</TD>
				</TR>
				<!-- ------------------------------ Inicio Grilla Reconciliación -------------------------------------- -->
				<TR>
					<TD class="Marco" vAlign="top" width="740" colSpan="4">
						<asp:datagrid id="dgrdMntRec" runat="server" Width="370px" BorderWidth="1px" CssClass="GridMnt"
							BorderColor="#3366CC" BorderStyle="None" AutoGenerateColumns="False" CellPadding="4" EnableViewState="False">
							<SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
							<EditItemStyle VerticalAlign="Top"></EditItemStyle>
							<ItemStyle CssClass="Registro"></ItemStyle>
							<HeaderStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="LightBlue"></HeaderStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="Cuenta">
									<ItemTemplate>
										<asp:Literal id=ltlDescripcion runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Descripcion") %>'>
										</asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
						</asp:datagrid>
					</TD>
				</TR>
				<!-- ------------------------------ Fin Reconciliación -------------------------------------- -->
			</TABLE>
		</form>
	</body>
</HTML>
