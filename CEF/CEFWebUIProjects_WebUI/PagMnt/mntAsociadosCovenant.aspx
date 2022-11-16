<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mntAsociadosCovenant.aspx.vb" Inherits="CEF.WebUI.mntAsociadosCovenant" EnableEventValidation="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
	<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<link href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="../Funciones/UtilVentana.js"></script>
    
    <script type="text/javascript">
    
    function f_AbrirPagMnt(pstrUrl, pintWidth, pintHeight, pintTab, pstrAccion){  
        document.getElementById('<%=hidAccion.ClientID %>').value = pstrAccion;
       
        var objParametro = null;
        var voArgumentos = new Array(objParametro);				
        voArgumentos = f_MskVtnDlg(pstrUrl, voArgumentos, pintWidth, pintHeight);
    }
    
    </script>
</head>
<body MS_POSITIONING="GridLayout">
    <form id="form1"  method="post" runat="server">
    <asp:HiddenField ID="hidAccion" runat="server"/>
    <asp:HiddenField ID="hidCodmetodizado" runat="server"/>
    <table  id="Table1" cellspacing="0" cellpadding="0" width="600" align="center" bgColor="#ffffff" border="0">
    <tr>
        <td background="../Imagen/bordes/brd_sp.gif" colspan="3" height="10"></td>
    </tr>
    <tr>
        <TD width="10">&nbsp;</TD>
        <TD vAlign="top" width="585">
        <TABLE cellSpacing="0" cellPadding="0" width="585" align="center" border="0">
		    <TR>
			    <TD width="5" rowSpan="3"><asp:image id="Image4" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Izq_blue.gif"
					    Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
			    <TD class="lightblueborder" width="99%"><asp:image id="Image6" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
					    Width="1px"></asp:image></TD>
			    <TD width="5" rowSpan="3"><asp:image id="Image5" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Der_blue.gif"
					    Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
		    </TR>
		    <TR>
			    <TD class="lightbluebg">
				    <TABLE height="29" cellSpacing="0" cellPadding="0" width="100%" border="0">
					    <TR>
						    <TD class="lightbluebg" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 29px"
							    noWrap><SPAN class="SearchResultsHeader">Clientes Covenants Asociados</SPAN></TD>
						    <TD width="99%" style="height: 29px">&nbsp;</TD>
						   <%-- <TD style="width: 19px; height: 29px"><asp:ImageButton id="imgCerrar" runat="server" ImageUrl="../Imagen/iconos/ico_Cerrar.gif" BorderWidth="0px"
								    ToolTip="Cerrar" CssClass="BotonCerrar"></asp:ImageButton></TD>--%>
					    </TR>
				    </TABLE>
			    </TD>
		    </TR>
	    </TABLE>
	    <table cellspacing="0" cellpadding="0" width="585"  align="center" border="0">
	        <tr>
	        <td class="lightblueborder" width="1"><asp:image id="Image1" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>
	        <td class="lightLTbluebg">&nbsp;
	            <table class="Criterio" cellspacing="1" cellpadding="0" width="565" align="center" border="0">
	            <tr height="10">
	            </tr>
	            <tr>
	                <td width="565" colSpan="4">
	                    <table height="21" cellSpacing="0" cellPadding="0" width="565" border="0">
	                    <tr>
	                        <td width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><img height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"/></td>
	                        <td width="6" height="21"><img height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6" /></td>
	                        <td class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif" height="21">&nbsp;Convenants&nbsp;</td>
	                        <td width="6" height="21"><img height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"/></td>
	                        <td width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><img height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"/></td>
	                    </tr>
	                    </table>
	                    <table height="21" cellSpacing="0" cellPadding="0" width="565" style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid">
	                    <tr  class="TabBar">
	                        <td width="70">&nbsp;</td>
	                        <td width="104px" align="right"><asp:Label ID="lblnumPaginas" runat="server"></asp:Label></td>
	                        <td width="140"><asp:Label ID="lblpaginas" runat="server"></asp:Label></td>
	                        <td width="100">&nbsp;</td>
	                        <td noWrap width="110"><asp:ImageButton id="imgnuevo" runat="server" BorderWidth="0px" ImageUrl="~/Imagen/iconos/ico_asociados.png" ToolTip="Nuevo" CausesValidation="False" CssClass="EfectoImagen" ImageAlign="AbsMiddle" />
	                        &nbsp;<asp:LinkButton ID="lnknuevo" runat="server" ToolTip="Nuevo">Asociar</asp:LinkButton>
	                        </td>
	                    </tr>
	                    </table>	                
	                </td>
	            </tr>
	            <tr>
	                <td class="Marco" vAlign="top" width="565" colSpan="4">
	                    <div class="Grid" id="divlstcovenants" style="WIDTH: 100%; height: 260px;"> 
                            <asp:datagrid ID="dtgr1" runat="server" AllowPaging="true" PageSize="6" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" CssClass="GridMnt" UseAccessibleHeader="True" scope="col" BorderStyle="None" BorderColor="#3366CC" Height="100px">
                            <SelectedItemStyle cssClass="RegSeleccion" />
                            <EditItemStyle VerticalAlign="Top"/>
                            <ItemStyle CssClass="Registro" />
                            <HeaderStyle CssClass="CabeceraRegistro" />
                            <Columns>
                                <asp:BoundColumn DataField="CodUnico" HeaderText="Código Único" >
                                    <HeaderStyle Width="140px"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:BoundColumn DataField="RazonSocial" HeaderText="Razón Social que originó COVENANT" ItemStyle-Width="300px">
                                    <HeaderStyle Width="300px"></HeaderStyle>
                                </asp:BoundColumn>
                                <asp:TemplateColumn HeaderText="Desasociar">
                                    <HeaderStyle Width="120px" HorizontalAlign="Center"></HeaderStyle>                             
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                    <ItemTemplate>                                        
                                        <asp:ImageButton ID="ibtnDesasociar" runat="server" CommandName="Eliminar"  CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CodUnico") %>' OnClick="ManejadorCrud" ImageUrl="~/Imagen/iconos/icon_Misc_Error.JPG" BorderWidth="0px" ToolTip="Desasociar Cliente" ImageAlign="AbsMiddle"/>
                                    </ItemTemplate>
                                </asp:TemplateColumn>
                            </Columns>
                            <PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>                           
                            </asp:datagrid>
	                    </div>
	                </td>
	            </tr>   
	            </table>
	        </td>
	        <td class="lightblueborder" width="1"><asp:image id="Image2" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>
	        </tr>
	    </table>
	    <TABLE cellSpacing="0" cellPadding="0" width="585" align="center" border="0">
	        <tr>
	            <td class="lightblueborder" width="1"><asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>	            
	            <td class="lightblueborder" width="1"><asp:image id="Image8" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>
	        </tr>
	    </TABLE>
	    <TABLE style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="585" align="center" border="0">
		    <tbody>
			    <TR>
				    <TD rowSpan="2"><asp:image id="Image9" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Inf_Izq_blue.gif"
						    Height="6px" BorderWidth="0px" Width="6px"></asp:image></TD>
				    <TD class="bottombluebg" width="99%"><asp:image id="Image12" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="5px"
						    Width="1px"></asp:image></TD>
				    <TD rowSpan="2"><asp:image id="Image10" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Inf_Der_blue.gif"
						    Height="6px" BorderWidth="0px" Width="6px"></asp:image></TD>
			    </TR>
			    <tr>
				    <td class="lightblueborder" width="1"><asp:image id="Image13" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>
			    </tr>
		    </tbody>
	    </TABLE>
	   </TD>
	   <td width="10">&nbsp;</td>
	  </tr>
    </table>
    </form>
</body>
</html>
