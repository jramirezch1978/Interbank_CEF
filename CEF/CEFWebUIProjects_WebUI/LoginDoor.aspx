<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LoginDoor.aspx.vb" Inherits="LoginDoor"%>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>LoginDoor</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">


		<form id="Form1" method="post" runat="server">
	
    		<div>
				<table>
					<tr>
						<td colspan="2">
							Ingresar al Sistema CEF
						</td>
					</tr>
					<tr>
						<td>Usuario</td>
						<td><asp:TextBox ID="txtUsuario" runat="server" MaxLength="8" Width="150px" /></td>
					</tr>
					<tr>
						<td>Perfil</td>
						<td>
							<asp:DropDownList ID="ddlPerfil" runat="server" Width="150px" >
								<asp:ListItem Value="">[Seleccionar]</asp:ListItem>
								<asp:ListItem Value="1">Administrador</asp:ListItem>
								<asp:ListItem Value="2">Analista de Riesgo</asp:ListItem>
								<asp:ListItem Value="3">Ejecutivo de Negocios</asp:ListItem>
							</asp:DropDownList>
						</td>
					</tr>					
					<tr>
						<td>Password</td>
						<td><asp:TextBox ID="txtPassword" runat="server" MaxLength="12" TextMode="Password" Width="150px" /></td>
					</tr>
					<tr>
						<td colspan="2">
							<asp:Button ID="btnIngresar" runat="server" Text="Ingresar"  />
                            <asp:Button ID="btnDownload" runat="server" Text="download"  />
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
