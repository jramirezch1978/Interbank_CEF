<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rvwResumenEjecutivo.aspx.vb" Inherits="CEF.WebUI.rvwResumenEjecutivo"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rvwResumenEjecutivo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<CR:CrystalReportViewer style="Z-INDEX: 101; POSITION: absolute; TOP: 8px; LEFT: 0px" id="CrystalReportViewer1"
				runat="server" Width="350px" Height="50px"></CR:CrystalReportViewer>
		</form>
	</body>
</HTML>
