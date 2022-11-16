
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="rvwMetodizado.aspx.vb" Inherits="CEF.WebUI.rvwMetodizado"%>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>rvwMetodizado</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form2" method="post" runat="server">
            <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"  Width="350px" Height="50px"/>
		</form>
	</body>
</HTML>

