<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ErrorPage.aspx.vb" Inherits="CEF.WebUI.ErrorPage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ErrorPage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="./Estilos/PagLst.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" bgColor="#f1f8fe">
		<form id="Form1" method="post" runat="server">
			<asp:Panel id="pnlMensaje" style="Z-INDEX: 101; LEFT: 40px; POSITION: absolute; TOP: 32px"
				runat="server" Width="328px" Height="160px" BorderWidth="0px" HorizontalAlign="Right">
				<asp:Image id="imgError" runat="server" BorderWidth="0px" ImageUrl="Imagen/mensajes/msj_ErrorAplicacion.gif"></asp:Image>
			</asp:Panel>
			<asp:Panel id="pnlAccion" style="Z-INDEX: 102; LEFT: 228px; POSITION: absolute; TOP: 224px"
				runat="server" Width="152px" Height="40px" HorizontalAlign="Right">
				<asp:ImageButton id="ibtnIngAplicacion" runat="server" BorderWidth="0px" Width="151" ImageUrl="Imagen/mensajes/msj_VolverIngresar.gif"
					ToolTip="Ingresar a la aplicación por SDA"></asp:ImageButton>
			</asp:Panel>
		</form>
	</body>
</HTML>
