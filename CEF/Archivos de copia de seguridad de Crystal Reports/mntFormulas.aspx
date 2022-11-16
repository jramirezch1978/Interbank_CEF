<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="mntFormulas.aspx.vb" Inherits="CEF.WebUI.mntFormulas" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>mntFormulas</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
	<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
	<meta content="JavaScript" name="vs_defaultClientScript">
	<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	
	<link href="../Estilos/PagLst.css" type="text/css" rel="stylesheet">
    <script type="text/javascript" src="../Funciones/UtilVentana.js"></script>
    <script type="text/javascript" src="../Funciones/json2.js"></script>
    <script type="text/javaScript" src="../Funciones/UtilAjax.js"></script>
    <script type="text/javascript" src="../Funciones/jquery.min.js"></script>
    <script type="text/javascript">
  
    $(document).ready(function(){      
        $('#txtBusquedaCuenta').on('input propertychange', function(e){
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
        
        $("#txtcomentario").bind({
        paste: function (e) {
            e.preventDefault();
        }
        });

    });
    
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
    
    function f_FocusBusqueda(obj){
        focusCampo('txtBusquedaCuenta');
    }
    
    function f_DatosPostback(evento){
        var txtFormula = document.getElementById('<%=txtFormula.ClientID %>');
        var hidBusquedaCuenta = document.getElementById('<%=hidFormula.ClientID %>');
        var lblFormula = document.getElementById('<%=lblFormula.ClientID %>');
        var hidLblFormula = document.getElementById('<%=hidLblFormula.ClientID %>');
        var hidJSONCovenant = document.getElementById('<%=hidJSONCovenant.ClientID %>')
  
        hidJSONCovenant.value = JSON.stringify(ArrayVariableFormula);
        hidBusquedaCuenta.value = txtFormula.value;
        hidLblFormula.value = lblFormula.innerText;
    }
    
    function f_AbrirPagMnt(pstrUrl, pintWidth, pintHeight, pintTab){
   
        var objParametro = null;
	    var voArgumentos = new Array(objParametro);				
	    voArgumentos = f_MskVtnDlg(pstrUrl, voArgumentos, pintWidth, pintHeight);
	    
	      
    }
    function f_ValidarNumeroDecimal(pobjCtrl) {
		var strPatron = /\.|[0-9]\.?[0-9]{0,3}/;
		var intCodigo = event.keyCode;
		var strCaracter = (String.fromCharCode(event.keyCode));
		var bolValido = strPatron.test(strCaracter);
		var intVal = pobjCtrl.value;
		var intPosCaracter;
		
	    if (!bolValido) {
		    event.returnValue = false;
		    return false;
	    } else {
		    if (intCodigo == 45 || intCodigo == 46)
			    if ((intPosCaracter = pobjCtrl.value.indexOf(strCaracter)) != -1) {
				    event.returnValue = false;
				    return false;
			    }
	    }
		return true;
	}
	 function f_ValidarAnio(pObjT){
	 
	    var fecha = new Date();
	    var anio = fecha.getFullYear();
	    var valor = pObjT.value;
	    	    
	    if(!/^([0-9])*$/.test(valor)){
	        alert("No se permite valores diferentes a números!");
	         pObjT.value = "";
	        
	    }else{
	        if(valor < anio){
	        alert("No se puede ingresar un año menor al actual.");   
	        pObjT.value = "";
	        }  	        
	    }
	   	    	    
//	    if(pObjT.value < anio){
//	        alert("No se puede ingresar \n un año menor al actual.");
//	        pObjT.value = "";
//	    }   
	}
	 
    </script>

</head>

<body MS_POSITIONING="GridLayout">
    <form id="form1" method="post" runat="server" style="width:600;"> 
        <asp:HiddenField ID="hidCodMetodizado" runat="server"/>
        <asp:HiddenField ID="hidCodCovenant" runat="server"/>
        <asp:HiddenField ID="hidJSONCovenant" runat="server"/>
        <asp:HiddenField ID="hidAccion" runat="server"/>
        <asp:HiddenField ID="hidAccionP" runat="server" />
        <asp:HiddenField ID="hidFormula" runat="server"/>
        <asp:HiddenField ID="hidLblFormula" runat="server" />
    <table  id="Table1" cellspacing="0" cellpadding="0" width="600" align="center" bgColor="#ffffff" border="0">
    <tr>
        <td background="../Imagen/bordes/brd_sp.gif" colspan="3" height="10"></td>
    </tr>
    <tr>
    <TD width="10" style="height: 79px">&nbsp;</TD>
    <TD vAlign="top" style="width: 585px; height: 79px">
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
						    noWrap><SPAN class="SearchResultsHeader">Mantenimiento Fórmula Covenant</SPAN></TD>
					    <TD width="99%" style="height: 29px">&nbsp;</TD>					   
				    </TR>
			    </TABLE>
		    </TD>
	    </TR>
	    <TR>
		    <TD class="lightbluebg">&nbsp;</TD>
	    </TR>
    </TABLE>
    <table cellspacing="0" cellpadding="0" width="585"  align="center" border="0">
        <tr>
            <td class="lightblueborder" width="1"><asp:image id="Image1" runat="server" ImageUrl="../Imagen/bordes/brd_sp.gif" Height="1px" BorderWidth="0px" Width="1px"></asp:image></td>
            <td class="lightLTbluebg" style="width: 585px">&nbsp;
                <table class="Criterio" cellspacing="1" cellpadding="0" width="565" align="center" border="0">
                <tr>
                    <td class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
                        <table class="Criterio">
                        <tr>
                            <td style="WIDTH: auto"><asp:label ID="lblNombreFormula" runat="server" Text="Nombre de la Fórmula:" /></td>
                            <td style="WIDTH: 100px"><asp:TextBox ID="txtNombreFormula" runat="server" Width="400px" MaxLength="50" /></td>
                        </tr>
                        </table>
                    </td>                      
                </tr>
                <tr>
                    <td class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
                        <table class="Criterio">
                        <tr>
                             <td style="width: 560px" valign="top">
                             <asp:TextBox ID="txtFormula" runat="server" Height="100px" MaxLength="4000" TextMode="MultiLine" Width="500" ReadOnly="true"></asp:TextBox>
                             </td>
                             <td valign="top">
                                    <table class="Criterio" cellpadding="0" cellspacing="0" style="height: 8px">
                                        <tr>
                                            <td><asp:Button ID="btnMas" runat="server" Text="+" Width="25px" /></td>
                                            <td><asp:Button ID="btnMenos" runat="server" Text="-" Width="25px" /></td>
                                        </tr>
                                        <tr>
                                            <td><asp:Button ID="btnMultiplicacion" runat="server" Text="*" Width="25px" /></td>
                                            <td><asp:Button ID="btnDivision" runat="server" Text="/" Width="25px" /></td>
                                        </tr>
                                        <tr>
                                            <td><asp:Button ID="btnAbreParentesis" runat="server" Text="(" Width="25px" /></td>
                                            <td><asp:Button ID="btnCierraParentesis" runat="server" Text=")" Width="25px" /></td>
                                        </tr>
                                                                                                                       
                                    </table>
                                    <asp:Button ID="btnLimpiarFormula" runat="server" Text="Limpiar" Width="52px" />
                                </td> 
                        </tr>                                                
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="Marco" style="HEIGHT: 1px" vAlign="top" width="100%" colSpan="4">
                        <table class="Criterio">
                            <tr>
                                <td style="width: 70px">Formula:</td>
                                <td style="width: 190px"><asp:Label ID="lblFormula" runat="server" Width="150px"></asp:Label></td>
                                <td>&nbsp;</td>
                                <td><asp:CheckBox ToolTip="Tipo de covenant" runat="server" ID="chknocontractual" Checked="false" />&nbsp;<asp:Label runat="server" ID="lblnocontractual" Font-Size="Small">No Contractual</asp:Label></td>
                                <td align="right"><asp:Button ID="btnProbarFormula" runat="server" Text="Probar" /></td>
                            </tr>
                            <tr>
                                <td style="width: 70px">Resultado:</td>
                                <td style="width: 190px"><asp:Label ID="lblResultado" runat="server"></asp:Label></td>
                                <td width="20"><b>Condición:</b></td>
						        <td width="30"><asp:DropDownList ID="DropDownList1" runat="server"><asp:ListItem Value="0">Selecionar</asp:ListItem>
						        <asp:ListItem Value="1">Mayor o igual a</asp:ListItem>
						        <asp:ListItem Value="2">Menor o igual a</asp:ListItem></asp:DropDownList></td>
                                <td align="right"><asp:Button ID="btnGuardarFormula" runat="server" Text="Guardar Fórmula" Width="120px" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr height="5">
                </tr>
                <tr>
                    <td width="275" style="height: 34px;">
                        <table height="21" cellSpacing="0" cellPadding="0" width="275" border="0">
                        <tr>
                            <td width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><img height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"/></td>
                            <td width="6" height="21"><img height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6" /></td>
                            <td class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif" height="21">&nbsp;Cuentas&nbsp;</td>
                            <td width="6" height="21"><img height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"/></td>
                            <td width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><img height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"/></td>
                        </tr>
                        </table>
                        <TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
				            height="21" cellSpacing="0" cellPadding="0" width="275">
				            <TR class="TabBar">
				                <TD width="5">&nbsp;</TD>
					            <TD width="45">Cuenta:</TD>
					            <TD width="190" height="28">
					                <asp:Panel ID="pnlBusquedaCuenta" runat="server" DefaultButton="btnBusquedaCuenta">
                                        <asp:TextBox ID="txtBusquedaCuenta" runat="server" style="width:212px;" ClientIDMode="Static" onfocus="f_FocusBusqueda(this);" MaxLength="70"></asp:TextBox>                                     
                                        <asp:Button ID="btnBusquedaCuenta" runat="server" Text="buscar" OnClientClick="f_DatosPostback()" style="display: none;" />
                                    </asp:Panel>
					            </TD>
				            </TR>
			             </TABLE>
                    </td>
                    <td width="10"></td>
                    <TD width="285">
			            <TABLE vAlign="center" height="21" cellSpacing="0" cellPadding="0" width="285" border="0" >
				            <TR>
					            <TD width="7" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
					            <TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabIzqActivo_blue.gif" width="6"></TD>
					            <TD class="TabActivo" title="Ver Funciones" onclick="return true;" noWrap background="../imagen/bordes/brd_TabActivo_blue.gif"
						            height="21">&nbsp;Parámetros&nbsp;</TD>
					            <TD width="6" height="21"><IMG height="21" alt="" src="../imagen/bordes/brd_TabDerActivo_blue.gif" width="6"></TD>
					            <TD width="88%" background="../imagen/bordes/brd_TabLin_blue.gif" height="21"><IMG height="1" alt="" src="../imagen/bordes/brd_sp.gif" width="7"></TD>
				            </TR>
			            </TABLE>
			            <TABLE style="BORDER-RIGHT: #a9cfeb 1px solid; BORDER-LEFT: #a9cfeb 1px solid; BORDER-BOTTOM: #a9cfeb 1px solid"
				            height="21" cellSpacing="0" cellPadding="0" width="285">
				            <TR class="TabBar">
					            <TD width="100">&nbsp;</TD>
					            <TD noWrap width="80" height="28">Num. Registro:</TD>
					            <TD width="100"><asp:label id="lblNumReg" runat="server" Width="98px">0</asp:label></TD>
					            <TD width="140">&nbsp;</TD>
					            <TD noWrap width="90"><asp:imagebutton id="imbNuevo" runat="server" BorderWidth="0px" ImageUrl="../imagen/iconos/ico_Nuevo.gif"
							            ToolTip="Nuevo" CausesValidation="False" ImageAlign="AbsMiddle" Enabled="False"></asp:imagebutton>&nbsp;<asp:hyperlink id="lnkNuevo" runat="server" ToolTip="Nuevo">Nuevo</asp:hyperlink>
					            </TD>
				            </TR>
			            </TABLE>
		            </TD>
                </tr>
                <tr>
                    <td class="Marco" vAlign="top" width="275">
                    <table>
                        <tr>
                                        <td style="width:270px" valign="top" colspan="2"> 
                            <div class="Grid" id="divlstcovenants" style="WIDTH: 100%; height:200px;">                    
                                    <asp:datagrid ID="dtgr1" runat="server" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False" CssClass="GridMnt" UseAccessibleHeader="True" scope="col"  BorderStyle="None" BorderColor="#3366CC"  >
                                    <SelectedItemStyle cssClass="RegSeleccion" />
                                    <EditItemStyle VerticalAlign="Top"/>
                                    <ItemStyle CssClass="Registro" />
                                    <HeaderStyle CssClass="CabeceraRegistro" />
                                    <Columns>                              
                                       <asp:TemplateColumn>
                                            <HeaderStyle Width="30px"></HeaderStyle>
                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                            <ItemTemplate>
                                              <asp:RadioButton ID="rbtItem" runat="server" onclick='javascript:fAgregarVariable(this);' value='<%# Eval("Importe") & "|" & Eval("Descripcion") & "|" & Eval("CodCuenta") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateColumn>
                                        <asp:BoundColumn DataField="Descripcion" HeaderText="Cuenta">
                                            <HeaderStyle Width="140px"></HeaderStyle>
                                        </asp:BoundColumn>
                                        <asp:BoundColumn DataField="CodCuenta" HeaderText="Cuenta" Visible="false">                                    
                                        </asp:BoundColumn>                       
                                    </Columns>
                                    <PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>                           
                                    </asp:datagrid>
                                </div>
                            </td>
                        </tr>
                    </table>
                    </td>
                    <td width="10"></td>
                    <td class="Marco" vAlign="top" width="285">
                        <DIV class="Grid" id="divComercialProp" style="WIDTH: 100%; HEIGHT: 200px">
		                    <asp:datagrid id="dgrdMnt" runat="server" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False"
			                    AllowPaging="false" UseAccessibleHeader="True" scope="col" BorderColor="#3366CC" BorderStyle="None" CssClass="GridMnt" Height="0">
			                    <SelectedItemStyle CssClass="RegSeleccion"></SelectedItemStyle>
			                    <EditItemStyle VerticalAlign="Top"></EditItemStyle>
			                    <ItemStyle CssClass="Registro"></ItemStyle>
			                    <HeaderStyle CssClass="CabeceraRegistro"></HeaderStyle>
			                    <Columns>
				                    <asp:EditCommandColumn UpdateText="&lt;img src='../imagen/iconos/ico_Grabar.gif' alt='Grabar' border=0/&gt;"
					                    CancelText="&lt;img src='../imagen/iconos/ico_Cancelar.gif' alt='Cancelar' border=0/&gt;" EditText="&lt;img src='../imagen/iconos/ico_Editar.gif' alt='Modificar' border=0/&gt;">
					                    <HeaderStyle Width="30px"></HeaderStyle>
					                    <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
				                    </asp:EditCommandColumn>
				                    <asp:TemplateColumn>
					                    <HeaderStyle Width="15px"></HeaderStyle>
					                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
					                    <ItemTemplate>
						                    <asp:ImageButton id="ibtnEliminar" runat="server" ImageUrl="../imagen/iconos/ico_Eliminar.gif" BorderWidth="0px"
							                    CausesValidation="False" ToolTip="Eliminar" ImageAlign="AbsMiddle" CommandName="Delete"></asp:ImageButton>
					                    </ItemTemplate>
				                    </asp:TemplateColumn>
				                    <asp:TemplateColumn HeaderText="A&#241;o">
							            <HeaderStyle Width="60px"></HeaderStyle>
							            <ItemTemplate>
								            <asp:Label id="lblanio" runat="server" Width="45px" MaxLength="4" Text='<%# DataBinder.Eval(Container.DataItem,"Anio") %>' CssClass="AlineacionCentro">
							                </asp:Label>
							            </ItemTemplate>
							            <EditItemTemplate>
								            <asp:TextBox id="txtanio" runat="server" Width="45px" MaxLength="4" Text='<%# DataBinder.Eval(Container.DataItem,"Anio") %>' CssClass="AlineacionCentro">
							                </asp:TextBox>
							            </EditItemTemplate>
							            <ItemStyle HorizontalAlign="Center"></ItemStyle>
						            </asp:TemplateColumn>
				                    <asp:TemplateColumn HeaderText="Valor">
						                <HeaderStyle Width="110px"></HeaderStyle>
						                <ItemStyle HorizontalAlign="Right"></ItemStyle>
						                <ItemTemplate>
							                 <%# DataBinder.Eval(Container.DataItem,"Valor") %>
						                </ItemTemplate>
						                <EditItemTemplate>
							                <asp:TextBox id="txtValor" runat="server" Width="90px" MaxLength="15" Text='<%# DataBinder.Eval(Container.DataItem,"Valor") %>' CssClass="AlineacionDerecha">
							                </asp:TextBox>
						                </EditItemTemplate>
					                </asp:TemplateColumn>
			                    </Columns>
			                    <PagerStyle CssClass="Paginacion" Mode="NumericPages"></PagerStyle>
		                    </asp:datagrid>
	                    </DIV>
                    </td> 
                </tr>
                </table>
                <table>
                    <tr>
                        <td><asp:Label ID="lblcomentario" runat="server" Text="Comentario:"></asp:Label></td>
                    </tr>
                    <tr>
                    
                        <td><asp:TextBox ID="txtcomentario" runat="server" MaxLength="300" TextMode="MultiLine" Width="570" onkeyDown="return checkTextComentarioMaxLength(this,event,'300');" Font-Size="9" ></asp:TextBox></td>
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
    <td style="width: 10px">&nbsp;</td>
    </tr>
    </table>  
    </form>
</body>
</html>

 <script language="javascript" type="text/javascript" defer="defer">
    
    function checkTextComentarioMaxLength(textBox,e, length)
    {
        if (e.keyCode==13){
        return false;
        }
        
        var mLen = textBox["MaxLength"];
        if(null==mLen)
            mLen=length;

        var txtcomentario = document.getElementById('<%=txtcomentario.ClientID %>');
        var maxLength = parseInt(mLen);
        
        if(!checkSpecialKeys(e)){
            if(txtcomentario.value.length > maxLength-1)
            {
                if(window.event)//IE
                    e.returnValue = false;
                else//Firefox
                    e.preventDefault();
            }
        }
    }
    function checkSpecialKeys(e)
    {
        if(e.keyCode !=8 && e.keyCode!=46 && e.keyCode!=37 && e.keyCode!=38 && e.keyCode!=39 && e.keyCode!=40)
            return false;
        else
            return true;
    }

 var ArrayVariableFormula=[];
 var myJsonString='';
 
  String.prototype.trim = function() {
    return this.replace(/^\s+|\s+$/g, ''); 
  }
 
 CargarArrayVariableFormula();
 
 var hand = function(strResp) {	
 			
				var xmlDoc = strResp.documentElement;
			}	

 function CargarArrayVariableFormula(){
        var vhidAccion         = document.getElementById('<%=hidAccion.ClientID %>');  
        var vlblFormulaArray         = document.getElementById('<%=hidJSONCovenant.ClientID %>');                 
           
        if(vlblFormulaArray.value != '')
            ArrayVariableFormula = JSON.parse(vlblFormulaArray.value);
        else
            ArrayVariableFormula = [];
 }
 
 
 function pageLoad(sender, args){    
                //  register for our events
                
                Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginRequest);
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequest);    
                
                _updateProgressDiv = $get('updateProgressDiv');
               
                
            }
            
 function fAgregarVariable(pCheck)                 
            {
            
                var vlblFormula         = document.getElementById('<%=lblFormula.ClientID %>');            
                var vtxtFormula         = document.getElementById('<%=txtFormula.ClientID %>');
                var vlblResultado     = document.getElementById('<%=lblResultado.ClientID %>');      
                
                var strPeriodoAnterior  = '';
                var strPeriodoAntInt    = '';
                var intPeriodoAnterior  = 0;
                var arrDatoCef          = pCheck.value.split('|');
                var vrbtItem            = null;            
                
               
                vtxtFormula.value         = vtxtFormula.value + '[' + arrDatoCef[1] + ']' ;
                vlblFormula.innerText     = vlblFormula.innerText + ' '+(parseInt(arrDatoCef[0])); //aca va el valor
                vlblResultado.innerText == ''
                
                var Variable = { CodCuenta: arrDatoCef[2],Descripcion:arrDatoCef[1], Valor:arrDatoCef[0]};
                ArrayVariableFormula.push(Variable);
                fSetearVariables();
//                if (vgvDatodCef != null)
//                {
//                    var ControlsInput = vgvDatodCef.getElementsByTagName("Input");
//                    
//                    for(var j = 0; j < ControlsInput.length; j++)
//                    {
//                        var ControlInput = ControlsInput[j];                    
//                        if (ControlInput.id.indexOf('rbtItem') > -1)
//                        {
//                            vrbtItem = ControlInput;
//                            if (vrbtItem.id != pCheck.id) { vrbtItem.checked = false; }
//                        }
//                    }
//                }
            }
            
             function fOperacion(pOperador)
            {
            
                var vlblFormula         = document.getElementById('<%=lblFormula.ClientID %>');            
                var vtxtFormula         = document.getElementById('<%=txtFormula.ClientID %>');
                var vlblResultado     = document.getElementById('<%=lblResultado.ClientID %>');  
                             
                vtxtFormula.value = vtxtFormula.value + pOperador + ' ';
                vlblFormula.innerText = vlblFormula.innerText + pOperador + ' ';
               
                var Variable = { CodCuenta: '',Descripcion:pOperador, Valor:''};
                ArrayVariableFormula.push(Variable);
                
                fSetearVariables();    
                return false;
            }  
            
             function fSetearVariables()
            {
            
                var vgvDatodCef         = document.getElementById('<%=dtgr1.ClientID %>');               
                
                if (vgvDatodCef != null)
                {
                    var ControlsInput = vgvDatodCef.getElementsByTagName("Input");
                    
                    for(var j = 0; j < ControlsInput.length; j++)
                    {
                        var ControlInput = ControlsInput[j];                    
                        if (ControlInput.id.indexOf('rbtItem') > -1)
                        {
                            vrbtItem = ControlInput;
                            if (vrbtItem.checked) { vrbtItem.checked = false; }
                        }
                    }
                }   
                            
            }
            
              function fProbarFormula()
            {
            
                var vlblFormula       = document.getElementById('<%=lblFormula.ClientID %>');            
                var vlblResultado     = document.getElementById('<%=lblResultado.ClientID %>'); 
                
                
		        try
		        {
		        
		            if(vlblFormula.innerText == '')
		            {
		                alert('No hay Fórmula para probar');
		            }
		            else
		            {
		                var resul   = 0;		                
		                var formula = eval("resul = " + vlblFormula.innerText);		                
		                vlblResultado.innerText     = resul + '\t- La Fórmula es correcta';			                	
		                vlblResultado.style.color   = 'black';
		            }
		            
		        }catch(err)
		        {
		            
			        vlblResultado.innerText     = 'Error en la creación de la Fórmula';
			        vlblResultado.style.color   = 'red';
		        }       

                fSetearVariables();             
                return false;
            }  
            
           
            
             function fLimpiarFormula()
            {
            
                var vlblFormula         = document.getElementById('<%=lblFormula.ClientID %>');
                var vlblResultado       = document.getElementById('<%=lblResultado.ClientID %>');            
                var vtxtFormula         = document.getElementById('<%=txtFormula.ClientID %>');
                             
                vlblFormula.innerText     = '';
                vlblResultado.innerText   = '';
                vtxtFormula.value         = ''; 
            
                ArrayVariableFormula = [];
                              
                fSetearVariables();
                return false;
            } 
            
             function fAgregarCampoCovenant(textbox)
            {
            
                if(textbox.value != ''){
                        var vlblFormula         = document.getElementById('<%=lblFormula.ClientID %>');            
                        var vtxtFormula         = document.getElementById('<%=txtFormula.ClientID %>');
                       
                        
                        vtxtFormula.value = vtxtFormula.value + '[' + textbox.title  + ']' + ' ';
                        vlblFormula.innerText =  vlblFormula.innerText + textbox.value  +  ' ';
                        
                        var Variable = { CodCuenta: '',Descripcion:textbox.title, Valor:textbox.value};
                        ArrayVariableFormula.push(Variable);
                       
                        textbox.disabled  = true;
                        
                        fSetearVariables(); 
                }   
                return false;
            }  
            
            function isFloatNumber(e, t) {
               var n;
               var r;
               if (navigator.appName == "Microsoft Internet Explorer" || navigator.appName == "Netscape") {
                  n = t.keyCode;
                  r = 1;
                  if (navigator.appName == "Netscape") {
                     n = t.charCode;
                     r = 0
                  }
               } else {
                  n = t.charCode;
                  r = 0
               }
               if (r == 1) {
                  if (!(n >= 48 && n <= 57 || n == 46)) {
                     t.returnValue = false
                  }
               } else {
                  if (!(n >= 48 && n <= 57 || n == 0 || n == 46)) {
                     t.preventDefault()
                  }
               }
            }

            function fGuardarFormula(){
            
             var vlblResultado      = document.getElementById('<%=lblResultado.ClientID %>');
             var vtxtFormula        = document.getElementById('<%=txtFormula.ClientID %>');
             var vlblResultado      = document.getElementById('<%=lblResultado.ClientID %>');
             var vNombreFormula     = document.getElementById('<%=txtNombreFormula.ClientID %>');
             
             
              if (vNombreFormula.value.toString().trim() == "") {
                alert("Ingresar el nombre de la fórmula");
                return false;
             }
             
             if(vtxtFormula.value == ""){
                alert("Error en la creación de la fórmula. No hay cuentas seleccionadas");
                return false;
             }
             else
             {
                if(vlblResultado.innerText == ""){
                    alert("Probar la fórmula si es correcta.");
                    return false;
                }
                 if (vlblResultado.style.color == "red"){
                  alert("La fórmula no es correcta.");
                 return false;
                 }else{
                 
                    var vlblFormulaArray         = document.getElementById('<%=hidJSONCovenant.ClientID %>').value;          
                    myJsonString = JSON.stringify(ArrayVariableFormula);                  
                    var vCodMetodizado = document.getElementById('<%=hidCodMetodizado.ClientID %>'); 
                    var vCodCovenant = document.getElementById('<%=hidCodCovenant.ClientID %>'); 
                    var vAccion = document.getElementById('<%=hidAccion.ClientID %>');
                    var vddlCondicion = document.getElementById('<%=DropDownList1.ClientID %>');
                    var vComentario = document.getElementById('<%=txtcomentario.ClientID %>').value;
                    var vChkNoContractual = document.getElementById('<%=chknocontractual.ClientID %>');
                    var vNoContractual;
                    
                    
                    if (vChkNoContractual.checked == true){vNoContractual = 2;}
                    else{vNoContractual = 1;}
                    
                    if(vComentario == '') vComentario = '';
                                                   
                   if(!vCodCovenant.value){
                   vCodCovenant.value = 0;
                   }                                                  
                   if( vddlCondicion.value == 0){
                    alert("Seleccionar una condición");
                    return false;
                   }      
                
                    var objAjax = new Ajax();
					    objAjax.addData("strVariableFormulas",myJsonString);
					    objAjax.addData("intCodMetodizado",vCodMetodizado.value);
					    objAjax.addData("strDescripcion",vNombreFormula.value);
					    objAjax.addData("intEstado",1);	
					    objAjax.addData("intCodCovenant",vCodCovenant.value);	
					    objAjax.addData("intAccion",vAccion.value);
					    objAjax.addData("intcondicion",vddlCondicion.value);
					    objAjax.addData("strComentario",vComentario);
					    objAjax.addData("intNoContractual",vNoContractual);						
    												
					    objAjax.doPost('./mcbFormula.aspx', null, hand, 'xml');         
                   
                   alert("Fórmula Registrada");
                   //window.close();
                      return true;                                         
                 }
               }              
            }
            
            </script>