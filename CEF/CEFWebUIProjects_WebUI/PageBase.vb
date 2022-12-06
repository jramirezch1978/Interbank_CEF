'===============================================================================
'	Pagina: Page Base
'	Proposito: Pagina Base para todas las paginas de la Aplicación.
'	Autor: Luis A. Mascaro Jácome
'===============================================================================

Option Strict On
Option Explicit On 

Imports System
Imports System.Globalization
Imports System.Reflection
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Text
Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.SystemFrameworks
Imports CEF.BusinessRules
Imports CEF.BusinessEntity
Imports System.Text.RegularExpressions

Namespace CEF.WebUI

    Public Class PageBase
        Inherits System.Web.UI.Page

        Private Const ccNOCONTROL_EXCEPTION As String = "Exception No Controlada:"
        Public Const ccKEY_URL_SDA As String = "http://intranetib/sda"
        Public Const ccKEY_URL_CIERRE_SESION As String = "/PagIni/Ajax/ajaxCierreSesion.aspx"
        Private Const ccKEY_URL_PAGINA_PORTAL As String = "/PagIni/PortalDefault.aspx"
        Private Const ccKEY_URL_PAGINA_ERROR As String = "/ErrorPage.aspx?bytCodError=1"
        Private Const ccKEY_DATOS_GLOBAL As String = "Cache:DatosGlobal"
        Private Const ccKEY_ESTADO_ACCESO As String = "Lectura"
        Private Const ccESTADO_ACCESO_EDICION As Integer = 0
        Private Const ccESTADO_ACCESO_LECTURA As Integer = 1

        Private Shared ReadOnly peCulture As CultureInfo = New CultureInfo("es-PE")

        Private Enum ecEstadoAcceso
            LECTURA = 1
            EDICION = 0
        End Enum

        Sub New()
            MyBase.New()
        End Sub

        Protected Function verificaConneccion() As Boolean
            If (Response.IsClientConnected) Then
                Return (True)
            End If
            Response.End()
            Return (False)
        End Function

        Protected Function cargarPaginaSDA() As Boolean
            Response.Redirect(ccKEY_URL_SDA)
            Return (True)
        End Function

        Protected Function cargarPaginaPortal() As Boolean
            'PARA DESPLIEGUE EN IIS - PRE/PRODUCCION
            'Dim strUrl As String = urlBase + ccKEY_URL_PAGINA_PORTAL
            'PARA(DESARROLLO)
            Dim strUrl As String = Page.ResolveUrl(ccKEY_URL_PAGINA_PORTAL)
            Response.Redirect(strUrl, True)
            Return (True)
        End Function

        Protected Function cargarPaginaError() As Boolean
            Dim strUrl As String = urlBase + ccKEY_URL_PAGINA_ERROR
            'PARA DESARROLLO:
            'strUrl = Page.ResolveUrl(ccKEY_URL_PAGINA_ERROR)
            Response.Redirect(strUrl, True)
            Return (True)
        End Function

        Protected Function verificaLogin() As Boolean
            Dim strUsuario As String
            Try
                'strUsuario = Me.datosGlobal.sUser
                strUsuario = retornaUsuarioSesion()
                If (strUsuario = String.Empty) Then
                    Return (False)
                Else
                    Return (True)
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        Protected Function agregarLogin(ByVal pstrCodUsuario As String) As Boolean
        End Function

        Protected Function eliminarLogin() As Boolean
            Me.datosGlobal = Nothing
            Return (Session.Item(ccKEY_DATOS_GLOBAL) Is Nothing)
        End Function

        Private Shared ReadOnly Property urlSuffix() As String
            Get
                urlSuffix = HttpContext.Current.Request.Url.Host + HttpContext.Current.Request.ApplicationPath
            End Get
        End Property

        Public Shared ReadOnly Property urlBaseSeguro() As String
            Get
                If CEFConfiguration.EnableSsl Then
                    urlBaseSeguro = "https://"
                Else
                    urlBaseSeguro = "http://"
                End If
                urlBaseSeguro = urlBaseSeguro & urlSuffix
            End Get
        End Property

        Public Shared ReadOnly Property urlBase() As String
            Get
                urlBase = "http://" & urlSuffix
            End Get
        End Property

        Protected Function verificaEdicion() As Boolean
            Dim intLectura As Integer = Convert.ToInt32(Request(ccKEY_ESTADO_ACCESO))

            If Session.Item(ccKEY_ESTADO_ACCESO) Is Nothing Then
                Session.Add(ccKEY_ESTADO_ACCESO, intLectura)
            Else
                Session.Item(ccKEY_ESTADO_ACCESO) = intLectura
            End If
            intLectura = Convert.ToInt32(Session.Item(ccKEY_ESTADO_ACCESO))
            Return (intLectura = ccESTADO_ACCESO_EDICION)
        End Function

        Protected Property datosGlobal() As Common.DatosGlobal
            Get
                If Session.Item(ccKEY_DATOS_GLOBAL) Is Nothing Then
                    Return (New Common.DatosGlobal)
                Else
                    Return (CType(Session.Item(ccKEY_DATOS_GLOBAL), Common.DatosGlobal))
                End If
            End Get
            Set(ByVal Value As Common.DatosGlobal)
                If Value Is Nothing Then
                    Session.Remove(ccKEY_DATOS_GLOBAL)
                Else
                    Session.Item(ccKEY_DATOS_GLOBAL) = Value
                End If
            End Set
        End Property

        Protected Sub muestraAlerta(ByVal pstrMensaje As String)
            If pstrMensaje <> String.Empty Then
                Dim strHtml As String = "alert(""{0}"");"
                Dim sbScriptCliente As System.Text.StringBuilder
                sbScriptCliente = New StringBuilder("<script language=""Javascript"">")
                sbScriptCliente.Append(ControlChars.NewLine)
                sbScriptCliente.AppendFormat(strHtml, pstrMensaje)
                sbScriptCliente.Append(ControlChars.NewLine)
                sbScriptCliente.Append("</script>")
                RegisterStartupScript("__RegMsjWebForm", sbScriptCliente.ToString())
            End If
        End Sub

        Protected Shared Function FormatCurrency(ByVal value As Decimal) As String
            Return (value.ToString("#,##0.00;(#,##0.00);#.##"))
        End Function

        Protected Shared Function FormatCurrencyPE(ByVal value As Decimal) As String
            Return (value.ToString("c", peCulture))
        End Function

        Protected Overridable Sub limpiarControles(ByVal objContenedor As Control)
            If objContenedor.HasControls() Then
                For Each objControl As Control In objContenedor.Controls
                    If objControl.HasControls() Then limpiarControles(objControl)
                    If TypeOf (objControl) Is TextBox Then
                        CType(objControl, TextBox).Text = String.Empty
                    ElseIf TypeOf (objControl) Is RadioButtonList Then
                        CType(objControl, RadioButtonList).ClearSelection()
                    ElseIf TypeOf (objControl) Is CheckBox Then
                        CType(objControl, CheckBox).Checked = False
                    ElseIf TypeOf (objControl) Is DropDownList Then
                        CType(objControl, DropDownList).SelectedIndex = -1
                    ElseIf TypeOf (objControl) Is DataGrid Then
                        CType(objControl, DataGrid).DataSource = New DataTable
                        CType(objControl, DataGrid).DataBind()
                    End If
                Next
            End If
        End Sub

        Protected Sub deshabilitaControles(ByVal objContenedor As Control)
            If objContenedor.HasControls() Then
                For Each objControl As Control In objContenedor.Controls
                    If objControl.HasControls() Then deshabilitaControles(objControl)
                    If objControl.ClientID.EndsWith("_CE") Then
                        If TypeOf (objControl) Is Button Then
                            CType(objControl, Button).Enabled = False
                        ElseIf TypeOf (objControl) Is ImageButton Then
                            CType(objControl, ImageButton).Visible = False
                        ElseIf TypeOf (objControl) Is HyperLink Then
                            CType(objControl, HyperLink).Visible = False
                        ElseIf TypeOf (objControl) Is Image Then
                            CType(objControl, Image).Visible = False
                        ElseIf TypeOf (objControl) Is HtmlInputButton Then
                            CType(objControl, HtmlInputButton).Disabled = True
                        End If
                    End If

                    If TypeOf (objControl) Is TextBox Then
                        CType(objControl, TextBox).Enabled = False
                    ElseIf TypeOf (objControl) Is DropDownList Then
                        CType(objControl, DropDownList).Enabled = False
                    ElseIf TypeOf (objControl) Is CheckBox Then
                        CType(objControl, CheckBox).Enabled = False
                    ElseIf TypeOf (objControl) Is RadioButtonList Then
                        CType(objControl, RadioButtonList).Enabled = False
                    End If
                Next
            End If
        End Sub

        Protected Overridable Function buscarGeneralItem(ByVal pintCodTbl As Integer, ByVal pintItem As Integer) As BusinessEntity.General
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General
            Return (obrGeneral.leer(pintCodTbl, pintItem))
        End Function
        'XT8633 INI
        Protected Overridable Function buscarGeneralFrecuencia(ByVal pintCodTbl As Integer) As DataSet
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            Return (obrMetodizado.listarFrecuenciaCovenant(pintCodTbl))
        End Function
        'XT8633 FIN
        Protected Overridable Function buscarGeneralTabla(ByVal pintCodTbl As Integer) As DataSet
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General
            Return (obrGeneral.listar(pintCodTbl))
        End Function

        Protected Overridable Function buscarParametro(ByVal pstrCodParametro As String) As BusinessEntity.Parametro
            Dim obeParametro As BusinessEntity.Parametro
            Dim obrParametro As BusinessRules.Parametro = New BusinessRules.Parametro
            obeParametro = obrParametro.leer(pstrCodParametro)
            Return (obeParametro)
        End Function

        Protected Overrides Sub OnError(ByVal e As EventArgs)
            Logger.Error(MethodInfo.GetCurrentMethod, (HttpContext.Current.Server.GetLastError()), "")
            cargarPaginaError()
        End Sub

        Protected Friend Function fRetornaNombreUsuario() As String
            Dim strRpta As String = String.Empty

            Try
                Dim obeUsuario As BusinessEntity.Usuario
                Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                'Dim strCodUsuario As String = datosGlobal.sUser
                Dim strCodUsuario As String = retornaUsuarioSesion()
                obeUsuario = obrUsuario.leer(strCodUsuario)

                strRpta = obeUsuario.Nombre

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " del usuario")
                Throw ex
            End Try

            Return strRpta
        End Function

        Protected Friend Function fRetornaDescPerfilUsuario() As String
            Dim strRpta As String = String.Empty

            Try
                Dim intPerfil As Short = CType(fRetornaPerfilUsuario(), Short)
                Dim obePerfil As BusinessEntity.Perfil
                Dim obrPerfil As New BusinessRules.Perfil

                obePerfil = obrPerfil.leer(intPerfil)

                strRpta = obePerfil.Nombre

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " del usuario")
                Throw ex
            End Try

            Return strRpta
        End Function

        Protected Function fRetornaPerfilUsuario() As Int32
            Dim intRpta As Int32 = 0

            Try
                'SRT_2017-02160

                'Dim obeusuario As BusinessEntity.Usuario
                'Dim obrusuario As BusinessRules.Usuario = New BusinessRules.Usuario

                'Dim strcodusuario As String = datosGlobal.sUser
                'obeusuario = obrusuario.leer(strcodusuario)

                '----comentado por rquispe 28/04/2014, para que tome el perfil 
                '--que se pasa por query string y ya no lo saque del perfil del usuario bd
                ' intRpta = obeUsuario.CodPerfil 
                'intRpta = datosGlobal.nPerfil
                intRpta = Convert.ToInt32(retornaPerfilSesion())
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " del usuario")
                Throw ex
            End Try

            Return intRpta
        End Function

        Protected Friend Sub cerrarSesion()
            Session.Clear()
            Session.Abandon()
        End Sub

        'STR_2017-02160
        Protected Friend Sub setearVariableSesion(ByVal strNombreVariable As String, ByVal strValor As String)
            Dim oVariableSesion As Object = Session.Item(strNombreVariable)

            If oVariableSesion IsNot Nothing Then
                oVariableSesion = strValor
            Else
                Session.Add(strNombreVariable, strValor)
            End If
        End Sub

        Protected Friend Sub eliminarVariableSesion(ByVal strNombreVariable As String)
            Dim oVariableSesion As Object = Session.Item(strNombreVariable)

            If oVariableSesion IsNot Nothing Then
                Session.Remove(strNombreVariable)
            End If
        End Sub

        Protected Friend Function retornaUsuarioSesion() As String
            Return DirectCast(Session(constantesWebUI.strConstSesionUsuario), String)
        End Function

        Protected Friend Function retornaNombreUsuarioSesion() As String
            Return DirectCast(Session(constantesWebUI.strConstSesionNombreUsuario), String)
        End Function

        Protected Friend Function retornaPerfilSesion() As String
            Return DirectCast(Session(ConstantesWebUI.strConstSesionPerfil), String)
        End Function

        Protected Friend Function retornaNombrePerfilSesion() As String
            Return DirectCast(Session(constantesWebUI.strConstSesionNombrePerfil), String)
        End Function

        Public Shared Function PostbackSession(ByVal page As Page) As Boolean
            If PageBase.ValidarSesion() Then Return True

            Dim message As String = CStr(IIf(page.IsPostBack, "La sesión ha caducado.", "No se han suministrado las credenciales necesarias para acceder al sistema CEF o la sesión ha caducado."))

            Logger.Info(MethodBase.GetCurrentMethod(), message)

            'ScriptManager.RegisterStartupScript(page, page.GetType(), "scriptSesionVencida", "Global.LogOutSistema('" & message & "');", True)
            page.ClientScript.RegisterClientScriptBlock(page.GetType, "scriptSesionVencida", "alert('" & message & "' ); setTimeout(function() { window.top.location = 'http://intranetib/sda/'; }, 2000); ", True)


            Return False
        End Function

        Public Shared Function ValidarSesion() As Boolean
            If String.IsNullOrEmpty(Sesion.CodigoUsuario) Then Return False

            If String.IsNullOrEmpty(Sesion.PerfilUsuario) Then Return False

            Return True
        End Function

#Region "Manejo de DataGrid"
        Public Enum eTipoColumnaGrid
            ecgColumnaVinculada
            ecgColumnaPlantilla
        End Enum

        Public Function fAgregarColumna(ByRef pDataGrid As DataGrid, ByVal pstrNombreCampo As String, ByVal pstrTextoCabecera As String, Optional ByVal pTipo As eTipoColumnaGrid = eTipoColumnaGrid.ecgColumnaVinculada, Optional ByVal pintIndice As Integer = -1) As DataGridColumn
            Dim oColumna As DataGridColumn = Nothing

            If pintIndice < 0 Then
                pintIndice = pDataGrid.Columns.Count()
            End If

            If pTipo = eTipoColumnaGrid.ecgColumnaVinculada Then
                Dim oColumnaVinculada As New BoundColumn
                oColumnaVinculada.DataField = pstrNombreCampo
                oColumnaVinculada.HeaderText = pstrTextoCabecera
                oColumna = oColumnaVinculada
            ElseIf pTipo = eTipoColumnaGrid.ecgColumnaPlantilla Then
                Dim oColumnaPlantilla As New TemplateColumn
                oColumnaPlantilla.HeaderText = pstrTextoCabecera
                oColumna = oColumnaPlantilla
            End If

            pDataGrid.Columns.AddAt(pintIndice, oColumna)
            Return oColumna
        End Function
#End Region
        'Protected Overrides Sub Render(ByVal writer As System.Web.UI.HtmlTextWriter)
        '    Dim REGEX_LINE_BREAKS As Regex = New Regex("\n\s+", RegexOptions.Compiled)
        '    Dim REGEX_BETWEEN_TAGS As Regex = New Regex("&gt;\s+<", RegexOptions.Compiled)

        '    Dim htmlwriter As HtmlTextWriter = New HtmlTextWriter(New System.IO.StringWriter)
        '    MyBase.Render(htmlwriter)

        '    Dim html As String = htmlwriter.InnerWriter.ToString()

        '    html = REGEX_BETWEEN_TAGS.Replace(html, "&gt; <")
        '    html = REGEX_LINE_BREAKS.Replace(html, String.Empty)

        '    writer.Write(html.Trim())
        '    htmlwriter.Close()
        'End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim oCerrar As Object = Me.FindControl("imgCerrar")

            If Not oCerrar Is Nothing Then
                If TypeOf (oCerrar) Is ImageButton Then
                    Dim oImgCerrar As ImageButton = DirectCast(oCerrar, ImageButton)
                    oImgCerrar.Attributes.Add("onClick", "javascript:if (parent.fCerrarChild!=null){parent.fCerrarChild()} return false;")
                End If
            End If
        End Sub

        Protected Friend Function fRetornaCodCorridaMetodizado(ByVal pintCodMetodizado As Integer, ByVal parrPeriodoFiltrado As String()) As String
            Dim strRpta As String = "0"

            Try
                Dim obeCorridaMetodizado As New BusinessEntity.CorridaMetodizado
                obeCorridaMetodizado.CodMetodizado = pintCodMetodizado

                obeCorridaMetodizado.Flag = 2 ' buscarCorrida

                For Each intCodPeriodo As String In parrPeriodoFiltrado
                    Dim obePeriodoCorrida As New BusinessEntity.PeriodoCorrida
                    obePeriodoCorrida.CodMetodizado = pintCodMetodizado
                    obePeriodoCorrida.CodPeriodo = CType(intCodPeriodo, Short)
                    obeCorridaMetodizado.PeriodosCorrida.Add(obePeriodoCorrida)
                Next
                Dim obrCorridaMetodizado As New BusinessRules.CorridaMetodizado

                obeCorridaMetodizado = obrCorridaMetodizado.leer(obeCorridaMetodizado)
                If Not obeCorridaMetodizado Is Nothing Then
                    strRpta = obeCorridaMetodizado.CodCorrida.ToString
                End If

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " de CorridaMetodizado")
            End Try

            Return strRpta
        End Function

    End Class

End Namespace