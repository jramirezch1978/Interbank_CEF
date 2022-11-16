<%@ Control Language="vb" AutoEventWireup="false" Codebehind="LeePeriodo.ascx.vb" Inherits="CEF.WebUI.LeePeriodo" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<TABLE class="CabColNoSeleccion" cellSpacing="0" cellPadding="1" width="99%" border="0">
	<TR class="ColNoSeleccion">
		<TD style="BORDER-BOTTOM: white 1px solid" noWrap align="right">&nbsp;&nbsp;
			<asp:image id="imgComentario" name="imgComentarioPeriodo" ImageAlign="AbsMiddle" ToolTip="Ver comentario"
				runat="server" ImageUrl="../Imagen/iconos/ico_Comentario.gif" BorderWidth="0px" CssClass="EfectoImagen"></asp:image>&nbsp;&nbsp;
			<asp:image id="imgEditar" ToolTip="Editar" runat="server" ImageUrl="../Imagen/iconos/ico_Editar.gif"
				BorderWidth="0px" CssClass="EfectoImagen"></asp:image>&nbsp;&nbsp
			<asp:image id="imgSupuesto" ToolTip="Supuestos" runat="server" ImageUrl="../Imagen/iconos/ico_Supuesto.gif"
				BorderWidth="0px" CssClass="EfectoImagen"></asp:image><asp:imagebutton id="ibtnEliminar" ToolTip="Eliminar" runat="server" ImageUrl="../Imagen/iconos/ico_Eliminar.gif"
				BorderWidth="0px" CssClass="EfectoImagen" Visible="False"></asp:imagebutton></TD>
	</TR>
	<TR class="ColNoSeleccion">
		<TD style="FONT-WEIGHT: bold; BORDER-BOTTOM: white 1px solid" align="center"><asp:literal id="ltlFecPeriodo" runat="server"></asp:literal></TD>
	</TR>
	<TR class="ColNoSeleccion">
		<TD style="BORDER-BOTTOM: white 1px solid"><asp:literal id="ltlDesTipoEeff" runat="server"></asp:literal></TD>
	</TR>
	<TR class="ColNoSeleccion">
		<TD style="BORDER-BOTTOM: white 1px solid"><asp:literal id="ltlRazonSocial" runat="server"></asp:literal></TD>
	</TR>
	<TR class="ColNoSeleccion">
		<TD><asp:literal id="ltlNombreUsuario" runat="server"></asp:literal></TD>
	</TR>
	<TR class="ColNoSeleccion">
	</TR>
</TABLE>
