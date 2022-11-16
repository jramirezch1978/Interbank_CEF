<%@ Register TagPrefix="Module" TagName="Titulo" Src="../PagWUC/Titulo.ascx" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../PagWUC/Menu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Pie" Src="../PagWUC/Pie.ascx" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="Portal.aspx.vb" Inherits="CEF.WebUI.Portal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Portal</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
		<script language="JavaScript" src="../Funciones/UtilVentana.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td width="auto">
						&nbsp;
					</td>
					<td width="770">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" bgColor="#ffffff"
							border="0">
							<tr class="banner">
								<td class="banner_logo" width="134">
									<asp:Image ID="imgBanner" runat="server" Height="49px" ImageUrl="../Imagen/Logo/UltLogBg.gif"
										Width="134px" />
									<br>
								</td>
								<td id="tdBanner" runat="server" style="BORDER-TOP: #eeeeee 1px solid; BACKGROUND-IMAGE: url(http://localhost/CEFWebUIProjects_WebUI/Imagen/fondos/Fondo.GIF); WIDTH: 100%; BACKGROUND-REPEAT: repeat-y">
									<table cellpadding="0" cellspacing="0" width="100%">
										<tr>
											<td class="banner_tituloSistema" colspan="3">
												CEF - Centralización de Estados Financieros
											</td>
										</tr>
										<tr class="banner_login">
											<td class="banner_usuario">
												Usuario:
												<asp:Label ID="lblUsuario" runat="server"></asp:Label>
											</td>
											<td class="banner_perfil">
												Perfil:
												<asp:Label ID="lblPerfil" runat="server"></asp:Label>
											</td>
											<td class="banner_salir">
												<asp:LinkButton ID="lbtnSalir" runat="server">Cerrar Sesion</asp:LinkButton>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<TR>
								<TD colspan="2" style="HEIGHT: 5px" width="100%" bgColor="#e1e0e0"><MODULE:MENU id="Menu1" runat="server" PathPrefix=".."></MODULE:MENU></TD>
							</TR>
							<TR>
								<TD colspan="2" align="left" valign="middle">
									<img src="../Imagen/Logo/UltLogCef.gif" style="DISPLAY: none">
								</TD>
							</TR>
						</TABLE>
					</td>
					<td width="auto">
						&nbsp;
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
