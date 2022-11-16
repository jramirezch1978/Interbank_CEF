<%@ Control Language="vb" AutoEventWireup="false" Codebehind="Menu.ascx.vb" Inherits="CEF.WebIU.Menu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<LINK href="../Estilos/menuBar.css" type="text/css" rel="stylesheet">
<script language="javascript" src="../Funciones/menuBar.js"></script>
<% CargaDatos() %>
<script language="javascript" type="text/Jscript" defer="defer">
	strIdIframe='<%=IDIframe%>';
</script>
<A id="navLink" style="DISPLAY: none; VISIBILITY: hidden" href="#"></A>
