<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mntBusquedaCliente.aspx.vb" Inherits="CEF.WebUI.mntBusquedaCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
	<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	<link href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="../Funciones/UtilVentana.js"></script>
    <script type="text/javaScript" src="../Funciones/UtilAjax.js"></script>
    <script type="text/javascript" src="../Funciones/jquery.min.js"></script>
    
    <script type = "text/javascript">
        $(document).ready(function(){      
            $('#txtFiltro').on('input propertychange', function(e){
                var valueChanged;
                
                if(e.type == 'propertychange')
                    valueChanged = e.originalEvent.propertyName == 'value';
                else
                    valueChanged = true;
                
                if(valueChanged){
                    if(!/^[ a-z0-9áéíóúüñ]*$/i.test(this.value))
                        this.value = this.value.replace(/[^ a-zA-Z0-9áéíóúüñ]+/ig, "");
                }
            });
        });
        
        function radioCheck(rb) {
            var gv = document.getElementById("<%=dtgr1.ClientID%>");
            var hidSelect = document.getElementById("<%=hidSelect.ClientID%>");
            
            hidSelect.value = rb.value
            this.SelectAllCheckboxes(rb);
        }   
        
        function SelectAllCheckboxes(chk) {
            $('#<%=dtgr1.ClientID %>').find("input:radio").each(function() {
                if (this != chk) {
                    this.checked = false;
                }
            });
        }
        
        function GuardarClienteAsociado(){
            var btnAceptar = document.getElementById("<%=btnAceptar.ClientID%>");
            var hidSelect = document.getElementById("<%=hidSelect.ClientID%>");
            
            if(hidSelect.value === ''){
                alert('Se debe seleccionar un Cliente para poder agregarlo.');
                return;
            }
            else
            {
                btnAceptar.click();
            }
        }
        
        function CanelarClienteAsociado(){
            this.close();
        }
        
        function f_FocusBusqueda(obj){
            focusCampo('txtFiltro');
        }
        
        function focusCampo(id){
            var inputField = document.getElementById(id);
            if(inputField != null && inputField.length !=0){
                if(inputField.createTextRange){
                    var FieldRange = inputField.createTextRange();
                    FieldRange.moveStart('character', inputField.value.length);
                    FieldRange.collapse();
                    FieldRange.select();
                } else if (inputField.selectionStart || inputField.selectionStart == '0'){
                    var elemLen = inputField.value.length;
                    inputField.selectionStart = elemLen;
                    inputField.selectionEnd = elemLen;
                    inputField.focus();
                }
            }
            else{
                inputField.focus();
            }
        }
        
        function valCantBusqueda()
        {
            var inputField = document.getElementById('txtFiltro');
            
            if(inputField != null && inputField.value.length >= 3)
                return true;
            else
                return false;
        }
    </script>

</head>
<body MS_POSITIONING="GridLayout">
    <form id="form1"  method="post" runat="server">
    <asp:HiddenField ID="hidAccion" runat="server"/>
    <asp:HiddenField ID="hidSelect" runat="server"/>
    
    <table  id="Table1" cellspacing="0" cellpadding="0" width="600" align="center" bgColor="#ffffff" border="0">
        <tr>
            <td background="../Imagen/bordes/brd_sp.gif" colspan="3" height="10"></td>
        </tr>
        <tr>
            <td width="10" style="height: 79px">&nbsp;</td>
            <td vAlign="top" style="width: 585px; height: 79px">
                <table cellSpacing="0" cellPadding="0" width="585" align="center" border="0">
	                <tr>
		                <td width="5" rowSpan="3"><asp:image id="Image4" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Izq_blue.gif"
				                Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
		                <td class="lightblueborder" width="99%"><asp:image id="Image6" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px"
				                Width="1px"></asp:image></TD>
		                <td width="5" rowSpan="3"><asp:image id="Image5" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Sup_Der_blue.gif"
				                Height="51px" BorderWidth="0px" Width="5px"></asp:image></TD>
	                </tr>
	                <tr>
		                <td class="lightbluebg">
			                <table height="29" cellSpacing="0" cellPadding="0" width="100%" border="0">
				                <tr>
					                <td class="lightbluebg" style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; PADDING-TOP: 5px; HEIGHT: 29px"
						                noWrap><SPAN class="SearchResultsHeader">Búsqueda de Cliente</SPAN></TD>
					                <td width="99%" style="height: 29px">&nbsp;</TD>					   
				                </tr>
			                </table>
		                </td>
	                </tr>
	                <tr>
		                <td class="lightbluebg">&nbsp;</TD>
	                </tr>
                </table>
	            <table cellspacing="0" cellpadding="0" width="585"  align="center" border="0">
	                <tr>
	                    <td class="lightblueborder" width="1">
	                        <asp:image id="Image1" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image>
	                    </td>
	                    <td class="lightLTbluebg">&nbsp;
	                        <table class="Criterio" cellspacing="1" cellpadding="0" width="565" align="center" border="0">
	                            <tr>
                                    <td class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
                                        <asp:Panel ID="pnlFiltro" runat="server" DefaultButton="btnBuscar">
                                            <table class="Criterio">
                                                <tr>
                                                    <td><asp:label ID="lblFiltro" runat="server" Text="Filtro: " /></td>
                                                    <td><asp:TextBox ID="txtFiltro" runat="server" style="width:460px;" ClientIDMode="Static" onfocus="f_FocusBusqueda(this);" MaxLength="70" /></td>
                                                    <td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" Width="55px" CssClass="Boton" OnClientClick="return valCantBusqueda();" /></td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>                      
                                </tr>
	                            <tr height="10">
	                            </tr>
	                            <tr>
	                                <td width="565" colSpan="4">
	                                    <table height="21" cellSpacing="0" cellPadding="0" width="565" border="0">
	                                        <tr>
	                                            <td width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><img height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"/></td>
	                                            <td width="6" height="21"><img height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6" /></td>
	                                            <td class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif" height="21">&nbsp;Asociados&nbsp;</td>
	                                            <td width="6" height="21"><img height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"/></td>
	                                            <td width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><img height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"/></td>
	                                        </tr>
	                                    </table>
	                                    <table height="21" cellSpacing="0" cellPadding="0" width="565" style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid">
	                                        <tr  class="TabBar">
	                                            <td width="70">&nbsp;</td>
	                                            <td noWrap width="104px">Numero de Registros:</td>
	                                            <td width="100"><asp:Label ID="lblpaginas" runat="server" Width="98px">00</asp:Label></td>
	                                            <td width="140">&nbsp;</td>
	                                            <td noWrap width="110"></td>
	                                        </tr>
	                                    </table>	                
	                                </td>
	                            </tr>
	                            <tr>
	                                <td class="Marco" vAlign="top" width="600" colSpan="4">
	                                    <div class="Grid" id="divlstcovenants" style="WIDTH: 100%; height: 238px;"> 
                                            <asp:datagrid ID="dtgr1" runat="server" AllowPaging="true" PageSize="6" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" CssClass="GridMnt" UseAccessibleHeader="True" scope="col" BorderStyle="None" BorderColor="#3366CC" Height="100px">
                                            <SelectedItemStyle cssClass="RegSeleccion" />
                                            <EditItemStyle VerticalAlign="Top"/>
                                            <ItemStyle CssClass="Registro" />
                                            <HeaderStyle CssClass="CabeceraRegistro" />
                                            <Columns>
                                                <asp:TemplateColumn HeaderText="">
                                                    <HeaderStyle Width="50px" HorizontalAlign="Center"></HeaderStyle>                             
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                    <ItemTemplate>                                        
                                                        <asp:RadioButton ID="rdbSel" runat="server" GroupName="Cliente" onclick="radioCheck(this);" value='<%# Eval("CodUnico")%>' />
                                                    </ItemTemplate>
                                                </asp:TemplateColumn>
                                                <asp:BoundColumn DataField="CodUnico" HeaderText="Código Único" >
                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="RazonSocial" HeaderText="Razón Social que originó COVENANT" ItemStyle-Width="300px">
                                                    <HeaderStyle Width="300px"></HeaderStyle>
                                                </asp:BoundColumn>
                                                <asp:BoundColumn DataField="NumeroDocPrincipal" HeaderText="Nro Doc." >
                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                </asp:BoundColumn>
                                            </Columns>
                                            <PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>                           
                                            </asp:datagrid>
	                                    </div>
	                                </td>
	                            </tr>
	                            <tr>
	                                <td>
	                                    <div style="padding:3px; margin-top:2px; margin-bottom:2px; text-align:right; vertical-align:top; border:solid 1px #d1e5f2;">
                                            <asp:Button ID="btnAceptar" runat="server" style="display: none;" />
                                            <input type="button" onclick="GuardarClienteAsociado();" class="Boton" value="Aceptar" style="width: 55px;" />
                                            <input type="button" onclick="CanelarClienteAsociado();" class="Boton" value="Cancelar" style="width: 55px;" />
                                        </div>
	                                </td>
	                            </tr>   
	                        </table>
	                    </td>
	                    <td class="lightblueborder" width="1"><asp:image id="Image2" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>
                    </tr>
                </table>
                <table cellSpacing="0" cellPadding="0" width="585" align="center" border="0">
                    <tr>
                        <td class="lightblueborder" width="1"><asp:image id="Image7" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>	            
                        <td class="lightblueborder" width="1"><asp:image id="Image8" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>
                    </tr>
                </table>
	            <table style="HEIGHT: 6px" cellSpacing="0" cellPadding="0" width="585" align="center" border="0">
		            <tbody>
			            <tr>
				            <td rowSpan="2"><asp:image id="Image9" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Inf_Izq_blue.gif" Height="6px" BorderWidth="0px" Width="6px"></asp:image></td>
				            <td class="bottombluebg" width="99%"><asp:image id="Image12" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="5px" Width="1px"></asp:image></td>
				            <td rowSpan="2"><asp:image id="Image10" runat="server" ImageUrl="../Imagen/bordes/brd_curva_Inf_Der_blue.gif" Height="6px" BorderWidth="0px" Width="6px"></asp:image></td>
			            </tr>
			            <tr>
				            <td class="lightblueborder" width="1"><asp:image id="Image13" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>
			            </tr>
		            </tbody>
	            </table>
	       </td>
	       <td width="10">&nbsp;</td>
	    </tr>
    </table>    
    </form>
</body>
</html>
