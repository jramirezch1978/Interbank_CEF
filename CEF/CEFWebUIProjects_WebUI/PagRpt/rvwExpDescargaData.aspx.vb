'*************************************************************
'Proposito: Exportar a Excel Descarga de Data
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 13/12/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.Common.Globals

Namespace CEF.WebUI
    Partial Class rvwExpDescargaData
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
            Dim intIdEstado As Integer = Integer.Parse(Request.Params("intPeriodo"))
            Dim strMoneda As String = Me.buscarGeneralItem(ecTablaGeneral.MONEDA, intIdMoneda).Descripcion
            Dim strEstado As String = DirectCast(Request.Params("strEstado"), String)

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            Dim dsMetodizado As DataSet = obrMetodizado.generarDescargaDataporMoneda(dteFecPeriodo, intIdMoneda, intIdEstado)

            If Not dsMetodizado Is Nothing Then

                dgrdMnt.DataSource = dsMetodizado
                dgrdMnt.DataBind()
                Dim strTitulo As String = "DATA CLIENTES METODIZADOS (" + strEstado + ")"
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

                    e.Item.Cells(0).Text = String.Format("{0:10D}", e.Item.Cells(0).Text)
                    'e.Item.Cells(7).Text = Format(CDbl(e.Item.Cells(7).Text), "##,##0")
                    'e.Item.Cells(8).Text = Format(CDbl(e.Item.Cells(8).Text), "##,##0")
                    'e.Item.Cells(9).Text = Format(CDbl(e.Item.Cells(9).Text), "##,##0")
                    'e.Item.Cells(10).Text = Format(CDbl(e.Item.Cells(10).Text), "##,##0")
                    'e.Item.Cells(11).Text = Format(CDbl(e.Item.Cells(11).Text), "##,##0")
                    'e.Item.Cells(12).Text = Format(CDbl(e.Item.Cells(12).Text), "##,##0")
                    'e.Item.Cells(13).Text = Format(CDbl(e.Item.Cells(13).Text), "##,##0")
                    'e.Item.Cells(14).Text = Format(CDbl(e.Item.Cells(14).Text), "##,##0")
                    'e.Item.Cells(15).Text = Format(CDbl(e.Item.Cells(15).Text), "##,##0")
                    'e.Item.Cells(16).Text = Format(CDbl(e.Item.Cells(16).Text), "##,##0")
                    'e.Item.Cells(17).Text = Format(CDbl(e.Item.Cells(17).Text), "##,##0")
                    'e.Item.Cells(18).Text = Format(CDbl(e.Item.Cells(18).Text), "##,##0")
                    'e.Item.Cells(19).Text = Format(CDbl(e.Item.Cells(19).Text), "##,##0")
                    'e.Item.Cells(20).Text = Format(CDbl(e.Item.Cells(20).Text), "##,##0")
                    'e.Item.Cells(21).Text = Format(CDbl(e.Item.Cells(21).Text), "##,##0")
                    'e.Item.Cells(22).Text = Format(CDbl(e.Item.Cells(22).Text), "##,##0")
                    'e.Item.Cells(23).Text = Format(CDbl(e.Item.Cells(23).Text), "##,##0")
                    'e.Item.Cells(24).Text = Format(CDbl(e.Item.Cells(24).Text), "##,##0")
                    'e.Item.Cells(25).Text = Format(CDbl(e.Item.Cells(25).Text), "##,##0")
                    'e.Item.Cells(26).Text = Format(CDbl(e.Item.Cells(26).Text), "##,##0")
                    'e.Item.Cells(27).Text = Format(CDbl(e.Item.Cells(27).Text), "##,##0")
                    'e.Item.Cells(28).Text = Format(CDbl(e.Item.Cells(28).Text), "##,##0")
                    'e.Item.Cells(29).Text = Format(CDbl(e.Item.Cells(29).Text), "##,##0")
                    'e.Item.Cells(30).Text = Format(CDbl(e.Item.Cells(30).Text), "##,##0")
                    'e.Item.Cells(31).Text = Format(CDbl(e.Item.Cells(31).Text), "##,##0")
                    'e.Item.Cells(32).Text = Format(CDbl(e.Item.Cells(32).Text), "##,##0")
                    'e.Item.Cells(33).Text = Format(CDbl(e.Item.Cells(33).Text), "##,##0")
                    'e.Item.Cells(34).Text = Format(CDbl(e.Item.Cells(34).Text), "##,##0")
                    'e.Item.Cells(35).Text = Format(CDbl(e.Item.Cells(35).Text), "##,##0")
                    'e.Item.Cells(36).Text = Format(CDbl(e.Item.Cells(36).Text), "##,##0")
                    'e.Item.Cells(37).Text = Format(CDbl(e.Item.Cells(37).Text), "##,##0")
                    'e.Item.Cells(38).Text = Format(CDbl(e.Item.Cells(38).Text), "##,##0")
                    'e.Item.Cells(39).Text = Format(CDbl(e.Item.Cells(39).Text), "##,##0")
                    'e.Item.Cells(40).Text = Format(CDbl(e.Item.Cells(40).Text), "##,##0")
                    'e.Item.Cells(41).Text = Format(CDbl(e.Item.Cells(41).Text), "##,##0")
                    'e.Item.Cells(42).Text = Format(CDate(e.Item.Cells(42).Text), "dd/MM/yyyy")

                    e.Item.Cells(7).Text = Format(CDbl(e.Item.Cells(7).Text), "##,##0")
                    e.Item.Cells(8).Text = Format(CDbl(e.Item.Cells(8).Text), "##,##0")
                    e.Item.Cells(9).Text = Format(CDbl(e.Item.Cells(9).Text), "##,##0")
                    e.Item.Cells(10).Text = Format(CDbl(e.Item.Cells(10).Text), "##,##0")
                    e.Item.Cells(11).Text = Format(CDbl(e.Item.Cells(11).Text), "##,##0")
                    e.Item.Cells(12).Text = Format(CDbl(e.Item.Cells(12).Text), "##,##0")
                    e.Item.Cells(13).Text = Format(CDbl(e.Item.Cells(13).Text), "##,##0")
                    e.Item.Cells(14).Text = Format(CDbl(e.Item.Cells(14).Text), "##,##0")
                    e.Item.Cells(15).Text = Format(CDbl(e.Item.Cells(15).Text), "##,##0")
                    e.Item.Cells(16).Text = Format(CDbl(e.Item.Cells(16).Text), "##,##0")
                    e.Item.Cells(17).Text = Format(CDbl(e.Item.Cells(17).Text), "##,##0")
                    e.Item.Cells(18).Text = Format(CDbl(e.Item.Cells(18).Text), "##,##0")
                    e.Item.Cells(19).Text = Format(CDbl(e.Item.Cells(19).Text), "##,##0")
                    e.Item.Cells(20).Text = Format(CDbl(e.Item.Cells(20).Text), "##,##0")
                    e.Item.Cells(21).Text = Format(CDbl(e.Item.Cells(21).Text), "##,##0")
                    e.Item.Cells(22).Text = Format(CDbl(e.Item.Cells(22).Text), "##,##0")
                    e.Item.Cells(23).Text = Format(CDbl(e.Item.Cells(23).Text), "##,##0")
                    e.Item.Cells(24).Text = Format(CDbl(e.Item.Cells(24).Text), "##,##0")
                    e.Item.Cells(25).Text = Format(CDbl(e.Item.Cells(25).Text), "##,##0")
                    e.Item.Cells(26).Text = Format(CDbl(e.Item.Cells(26).Text), "##,##0")
                    e.Item.Cells(27).Text = Format(CDbl(e.Item.Cells(27).Text), "##,##0")
                    e.Item.Cells(28).Text = Format(CDbl(e.Item.Cells(28).Text), "##,##0")
                    e.Item.Cells(29).Text = Format(CDbl(e.Item.Cells(29).Text), "##,##0")
                    e.Item.Cells(30).Text = Format(CDbl(e.Item.Cells(30).Text), "##,##0")
                    e.Item.Cells(31).Text = Format(CDbl(e.Item.Cells(31).Text), "##,##0")
                    e.Item.Cells(32).Text = Format(CDbl(e.Item.Cells(32).Text), "##,##0")
                    e.Item.Cells(33).Text = Format(CDbl(e.Item.Cells(33).Text), "##,##0")
                    e.Item.Cells(34).Text = Format(CDbl(e.Item.Cells(34).Text), "##,##0")
                    e.Item.Cells(35).Text = Format(CDbl(e.Item.Cells(35).Text), "##,##0")
                    e.Item.Cells(36).Text = Format(CDbl(e.Item.Cells(36).Text), "##,##0")
                    e.Item.Cells(37).Text = Format(CDbl(e.Item.Cells(37).Text), "##,##0")
                    e.Item.Cells(38).Text = Format(CDbl(e.Item.Cells(38).Text), "##,##0")
                    e.Item.Cells(39).Text = Format(CDbl(e.Item.Cells(39).Text), "##,##0")
                    e.Item.Cells(40).Text = Format(CDbl(e.Item.Cells(40).Text), "##,##0")
                    e.Item.Cells(41).Text = Format(CDbl(e.Item.Cells(41).Text), "##,##0")
                    e.Item.Cells(42).Text = Format(CDbl(e.Item.Cells(42).Text), "##,##0")
                    e.Item.Cells(43).Text = Format(CDbl(e.Item.Cells(43).Text), "##,##0")
                    e.Item.Cells(44).Text = Format(CDbl(e.Item.Cells(44).Text), "##,##0")
                    e.Item.Cells(45).Text = Format(CDbl(e.Item.Cells(45).Text), "##,##0")
                    e.Item.Cells(46).Text = Format(CDbl(e.Item.Cells(46).Text), "##,##0")
                    e.Item.Cells(47).Text = Format(CDbl(e.Item.Cells(47).Text), "##,##0")
                    e.Item.Cells(48).Text = Format(CDbl(e.Item.Cells(48).Text), "##,##0")
                    e.Item.Cells(49).Text = Format(CDbl(e.Item.Cells(49).Text), "##,##0")
                    e.Item.Cells(50).Text = Format(CDbl(e.Item.Cells(50).Text), "##,##0")
                    e.Item.Cells(51).Text = Format(CDbl(e.Item.Cells(51).Text), "##,##0")
                    e.Item.Cells(52).Text = Format(CDbl(e.Item.Cells(52).Text), "##,##0")
                    e.Item.Cells(53).Text = Format(CDbl(e.Item.Cells(53).Text), "##,##0")
                    e.Item.Cells(54).Text = Format(CDbl(e.Item.Cells(54).Text), "##,##0")
                    e.Item.Cells(55).Text = Format(CDbl(e.Item.Cells(55).Text), "##,##0")
                    e.Item.Cells(56).Text = Format(CDbl(e.Item.Cells(56).Text), "##,##0")
                    e.Item.Cells(57).Text = Format(CDbl(e.Item.Cells(57).Text), "##,##0")
                    e.Item.Cells(58).Text = Format(CDbl(e.Item.Cells(58).Text), "##,##0")
                    e.Item.Cells(59).Text = Format(CDbl(e.Item.Cells(59).Text), "##,##0")
                    e.Item.Cells(60).Text = Format(CDbl(e.Item.Cells(60).Text), "##,##0")
                    e.Item.Cells(61).Text = Format(CDbl(e.Item.Cells(61).Text), "##,##0")
                    e.Item.Cells(62).Text = Format(CDbl(e.Item.Cells(62).Text), "##,##0")
                    e.Item.Cells(63).Text = Format(CDbl(e.Item.Cells(63).Text), "##,##0")
                    e.Item.Cells(64).Text = Format(CDbl(e.Item.Cells(64).Text), "##,##0")
                    e.Item.Cells(65).Text = Format(CDbl(e.Item.Cells(65).Text), "##,##0")
                    e.Item.Cells(66).Text = Format(CDbl(e.Item.Cells(66).Text), "##,##0")
                    e.Item.Cells(67).Text = Format(CDbl(e.Item.Cells(67).Text), "##,##0")
                    e.Item.Cells(68).Text = Format(CDbl(e.Item.Cells(68).Text), "##,##0")
                    e.Item.Cells(69).Text = Format(CDbl(e.Item.Cells(69).Text), "##,##0")
                    e.Item.Cells(70).Text = Format(CDbl(e.Item.Cells(70).Text), "##,##0")
                    e.Item.Cells(71).Text = Format(CDbl(e.Item.Cells(71).Text), "##,##0")
                    e.Item.Cells(72).Text = Format(CDbl(e.Item.Cells(72).Text), "##,##0")
                    e.Item.Cells(73).Text = Format(CDbl(e.Item.Cells(73).Text), "##,##0")
                    e.Item.Cells(74).Text = Format(CDbl(e.Item.Cells(74).Text), "##,##0")
                    e.Item.Cells(75).Text = Format(CDbl(e.Item.Cells(75).Text), "##,##0")
                    e.Item.Cells(76).Text = Format(CDbl(e.Item.Cells(76).Text), "##,##0")
                    e.Item.Cells(77).Text = Format(CDbl(e.Item.Cells(77).Text), "##,##0.#0")
                    e.Item.Cells(78).Text = Format(CDbl(e.Item.Cells(78).Text), "##,##0.#0")
                    'e.Item.Cells(79).Text = Format(CDbl(e.Item.Cells(79).Text), "##,##0")
                    'e.Item.Cells(80).Text = Format(CDbl(e.Item.Cells(80).Text), "##,##0")
                    'e.Item.Cells(81).Text = Format(CDbl(e.Item.Cells(81).Text), "##,##0")
                    'e.Item.Cells(82).Text = Format(CDbl(e.Item.Cells(82).Text), "##,##0")
                    e.Item.Cells(80).Text = Format(CDate(e.Item.Cells(80).Text), "dd/MM/yyyy")
            End Select
        End Sub

    End Class
End Namespace
