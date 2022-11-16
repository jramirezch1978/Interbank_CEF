<%@ Page Language="vb" AutoEventWireup="false" Codebehind="PortalDefault.aspx.vb" Inherits="CEF.WebUI.PortalDefault"%>
<%@ Register TagPrefix="Module" TagName="Pie" Src="../PagWUC/Pie.ascx" %>
<%@ Register TagPrefix="Module" TagName="Menu" Src="../PagWUC/Menu.ascx" %>
<%@ Register TagPrefix="Module" TagName="Titulo" Src="../PagWUC/Titulo.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Portal</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="Visual Basic .NET 7.1">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<input id="hidPrimeraCarga" runat="server" type="hidden" value="0" NAME="hidPrimeraCarga">
			<table cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td width="auto">
						&nbsp;
					</td>
					<td width="770">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" bgColor="#ffffff"
							border="0">
							<tr class="banner">
								<td class="banner_logo" width="138" style="WIDTH: 138px" valign="middle">
									<asp:Image ID="imgBanner" runat="server" ImageUrl="../Imagen/Logo/Logo01.png" />
									<div style="WIDTH:137px; HEIGHT:8px"></div>
								</td>
								<td id="tdBanner" runat="server" style="BORDER-TOP: #eeeeee 1px solid; BACKGROUND-IMAGE: url(../Imagen/fondos/Fondo.GIF); WIDTH: 100%; BACKGROUND-REPEAT: repeat-y">
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
								<TD colspan="2" style="HEIGHT: 23px" width="100%" bgColor="#e1e0e0"><MODULE:MENU id="Menu1" runat="server" PathPrefix=".."></MODULE:MENU></TD>
							</TR>
							<TR>
								<TD colspan="2" align="left" valign="middle">&nbsp; <IFRAME class="iframe_Cuerpo" id="ifrmDetalle" marginWidth="0" marginHeight="0" src="about:blank"
										frameBorder="0" width="100%" height="1057" style="LEFT: -5px; POSITION: relative">
									</IFRAME>
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
		<%-- <script type="text/javascript" src="../Funciones/UtilVentana.js" /> --%>
		<script type="text/javascript">
			var reqXHR;
            
            var ohidPrimeraCarga = document.getElementById('hidPrimeraCarga');
            
            document.body.onunload=null;
            if (ohidPrimeraCarga!=null)
            {
                if (ohidPrimeraCarga.value == '1')
                {
                    document.body.onunload=fCerrarSesionAutomaticamente;
                    ohidPrimeraCarga.value = '0';
                }
                else
                {
                    location = '<%=_RutaPaginaSDA %>';
                }
            }
            
            function fCerrarChild()
			{
				if ((parent!=null) && (parent.myRedirect!=null))
                {
                    parent.myRedirect('about:blank');
                }
                return false;
			}
			
            function fCerrarSesionManualmente()
            {
                fLimpiarCierreSesion();
            }
            
            function fCerrarSesionAutomaticamente()
            {
                fLimpiarCierreSesion();
                
                reqXHR = fInstanciarXHR();
	            reqXHR.open('GET','<%=_RutaAjaxCierreSesion %>',true);
	            reqXHR.onreadystatechange= fFinalizarCierreSesion;
	            reqXHR.send(null);
            }

			            
            var Try = {
						these: function() {
							var returnValue;

							for (var i = 0, length = arguments.length; i < length; i++) {
							var lambda = arguments[i];
							try {
								returnValue = lambda();
								break;
							} catch (e) { }
							}

							return returnValue;
						}
					};

            fInstanciarXHR=function()
			{
				return Try.these
				(
					function(){return new XMLHttpRequest()},
					function(){return new ActiveXObject('MSXML2.XMLHttp.7.0')},
					function(){return new ActiveXObject('MSXML2.XMLHttp.6.0')},
					function(){return new ActiveXObject('MSXML2.XMLHttp.5.0')},
					function(){return new ActiveXObject('MSXML2.XMLHttp.4.0')},
					function(){return new ActiveXObject('MSXML2.XMLHttp.3.0')},
					function(){return new ActiveXObject('MSXML2.XMLHttp')},
					function(){return new ActiveXObject('Microsoft.XMLHttp')}
				) || false;
			};
            
            function fLimpiarCierreSesion()
            {
                if (ohidPrimeraCarga!=null){ ohidPrimeraCarga.value = '0';}
                document.body.onunload = null;
                fCerrarChild();
            }
            
            function fFinalizarCierreSesion()
            {
                return true;
            }
            
		</script>
	</body>
</HTML>
