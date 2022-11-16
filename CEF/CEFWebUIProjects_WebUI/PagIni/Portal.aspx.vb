'===============================================================================
'	CEF.WebUI: Portal de Ingreso por SDA
'	Autor: Luis A. Mascaro Jácome
'===============================================================================

Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals

Namespace CEF.WebUI

    Partial Class Portal
        Inherits PageBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

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
            'If Not Page.IsPostBack Then
            'End If
            'End If
            If Not PageBase.PostbackSession(Me) Then Exit Sub
            If IsPostBack Then Exit Sub

            'Me.InitForm()
        End Sub

    End Class

End Namespace