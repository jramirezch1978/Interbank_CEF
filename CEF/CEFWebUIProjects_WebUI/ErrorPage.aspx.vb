Namespace CEF.WebUI

    Partial Class ErrorPage
        Inherits PageBase

        Private Enum ecCodigoError As Byte
            ERROR_APPLICACION = 1
            SESION_FINALIZADA = 2
        End Enum

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents dgrdMnt As System.Web.UI.WebControls.DataGrid

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
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        CargaDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    CargaDatos()
                End If
            End If
        End Sub

        Private Sub CargaDatos()
            Dim bytCodError As ecCodigoError = Byte.Parse(Request.QueryString("bytCodError"))
            Select Case bytCodError
                Case ecCodigoError.ERROR_APPLICACION
                    imgError.ImageUrl = "./Imagen/mensajes/msj_ErrorAplicacion.gif"
                Case ecCodigoError.SESION_FINALIZADA
                    imgError.ImageUrl = "./Imagen/mensajes/msj_SesionFinalizada.gif"
            End Select
        End Sub

        Private Sub ibtnIngAplicacion_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnIngAplicacion.Click
            Me.cargarPaginaSDA()
        End Sub
    End Class

End Namespace