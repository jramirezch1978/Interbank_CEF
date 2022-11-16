'===============================================================================
'	CEF.WebUI: Nuevo Portal de Ingreso por SDA 
'	Autor: Javier R. Montes Carrera
'===============================================================================

Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection

Namespace CEF.WebUI

    Partial Class PortalDefault
        Inherits PageBase

        Public ReadOnly Property _RutaPaginaSDA() As String
            Get
                Return Me.ccKEY_URL_SDA
            End Get
        End Property

        Public ReadOnly Property _RutaAjaxCierreSesion() As String
            Get
                Return Me.ccKEY_URL_CIERRE_SESION
            End Get
        End Property

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents imgEspera As System.Web.UI.WebControls.Image
        Protected WithEvents pnlEspera As System.Web.UI.WebControls.Panel

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'If verificaConneccion() Then
            If Not PageBase.PostbackSession(Me) Then Exit Sub

            If Not Page.IsPostBack Then
                'SRT_2017-02160
                'lblUsuario.Text = fRetornaNombreUsuario()
                'lblPerfil.Text = fRetornaDescPerfilUsuario()
                lblUsuario.Text = retornaNombreUsuarioSesion()
                lblPerfil.Text = retornaNombrePerfilSesion()
                hidPrimeraCarga.Value = "1"
            Else
                hidPrimeraCarga.Value = "0"
            End If

            lbtnSalir.Attributes.Add("onclick", "javascript:fCerrarSesionManualmente()")
        End Sub

    End Class

End Namespace