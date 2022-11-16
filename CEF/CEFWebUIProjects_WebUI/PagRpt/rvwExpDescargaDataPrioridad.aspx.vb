Imports CEF.Common.Globals

Namespace CEF.WebUI
    Partial Class rvwExpDescargaDataPrioridad
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
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        cargarDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargarDatos()
                End If
            End If
        End Sub

        Private Sub cargarDatos()
            cargarInformacionDescarga()
        End Sub

        Private Sub cargarInformacionDescarga()
            Dim dteFecPeriodo As DateTime = DateTime.Parse(Request.Params("dteFecPeriodo"))
            Dim intIdMoneda As Integer = Integer.Parse(Request.Params("intMoneda"))
            Dim strMoneda As String = Me.buscarGeneralItem(ecTablaGeneral.MONEDA, intIdMoneda).Descripcion

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            Dim dsMetodizado As DataSet = obrMetodizado.generarDescargaDataPrioridad(dteFecPeriodo, intIdMoneda)

            If Not dsMetodizado Is Nothing Then

                dgrdMnt.DataSource = dsMetodizado
                dgrdMnt.DataBind()
                Dim strTitulo As String = "DATA CLIENTES METODIZADOS - PRIORIDAD"
                Dim arrCriterio(0, 1) As String
                arrCriterio(0, 0) = "Periodo"
                arrCriterio(0, 1) = dteFecPeriodo.ToShortDateString + " (Expresado en MILES de " + strMoneda.Trim.ToUpper + ")"

                Util.exportarExcel(dgrdMnt, strTitulo, arrCriterio)
            End If
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    'Establecemos los campos numéricos con formato de texto...
                    e.Item.Cells(0).Attributes.Add("style", "mso-number-format:\@")
                    e.Item.Cells(2).Attributes.Add("style", "mso-number-format:\@")
                    e.Item.Cells(4).Attributes.Add("style", "mso-number-format:\@")
                    e.Item.Cells(5).Attributes.Add("style", "mso-number-format:\@")

                    For i As Integer = 7 To e.Item.Cells.Count - 1
                        If IsNumeric(e.Item.Cells(i).Text) Then
                            e.Item.Cells(i).Attributes.Add("style", "mso-number-format:\@")
                            e.Item.Cells(i).Text = Format(CDbl(e.Item.Cells(i).Text), "##,##0")
                            e.Item.Cells(i).HorizontalAlign = HorizontalAlign.Right
                        End If
                    Next
            End Select
        End Sub

    End Class
End Namespace
