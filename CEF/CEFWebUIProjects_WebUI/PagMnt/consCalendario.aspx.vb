
Namespace ROC.WebUI

    Partial Class consCalendario
        Inherits System.Web.UI.Page

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
            If Not Page.IsPostBack Then
                cargaDatos()
            End If
        End Sub

        Private Sub cargaDatos()
            calFecha.SelectedDate = Convert.ToDateTime(DateTime.Today.ToShortDateString())
            ' hidFecha.Value = calFecha.SelectedDate.ToShortDateString()
            pAsignarDatoFecha()
            btnAceptar.Attributes("onclick") = "javascript:f_RetornaCliente();"
        End Sub

        Private Sub calFecha_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles calFecha.SelectionChanged
            ' hidFecha.Value = calFecha.SelectedDate.ToShortDateString()
            pAsignarDatoFecha()
        End Sub

        Private Sub calFecha_VisibleMonthChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.MonthChangedEventArgs) Handles calFecha.VisibleMonthChanged
            ' hidFecha.Value = String.Empty
            pAsignarDatoFecha(String.Empty)
        End Sub

        Private Sub pAsignarDatoFecha(Optional ByVal strValor As String = Nothing)
            If strValor Is Nothing Then
                hidFecha.Value = String.Format("{0:dd/MM/yyyy}", calFecha.SelectedDate)
            Else
                hidFecha.Value = strValor
            End If
        End Sub
    End Class

End Namespace