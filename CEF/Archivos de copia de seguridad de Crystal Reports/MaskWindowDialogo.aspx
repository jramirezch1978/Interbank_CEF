<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MaskWindowDialogo.aspx.vb" Inherits="CEF.WebUI.MaskWindowDialogo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
  <HEAD>
		<title>CEF</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>

	<body MS_POSITIONING="GridLayout" bottommargin="0" leftmargin="0" rightmargin="0" topmargin="0">
		<form id="Form1" method="post" runat="server">
			<input type=hidden id="hidTitulo" name="hidTitulo">
			<TABLE border="0" cellpadding="0" cellspacing="0" width="100%">
				<TR>
					<TD>
						<iframe id="ifrMaskVtnDlg" name="ifrMaskVtnDlg" runat="server" scrolling="auto"></iframe>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
