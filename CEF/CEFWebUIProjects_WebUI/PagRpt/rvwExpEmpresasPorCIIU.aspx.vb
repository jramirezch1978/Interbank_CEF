'*************************************************************
'Proposito: Exportar a Excel la Consulta Por CIIU
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 20/11/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Text
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals

Namespace CEF.WebUI

    Partial Class rvwExpEmpresasPorCIIU
        Inherits PageBase

        Private dblImporte1 As Double
        Private dblImporte2 As Double
        Private dblImporte3 As Double
        Private dblImporte4 As Double
        Private dblImporte5 As Double
        Private dblImporte6 As Double
        Private dblImporte7 As Double
        Private dblImporte8 As Double
        Private dblImporte9 As Double
        Private dblImporte10 As Double
        Private dblImporte11 As Double
        Private dblImporte12 As Double
        Private dblImporte13 As Double
        Private dblImporte14 As Double
        Private dblImporte15 As Double
        Private dblImporte16 As Double
        Private dblImporte17 As Double
        Private dblImporte18 As Double
        Private intContador As Integer


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
            cargarDatosFiltro()
        End Sub

        Private Sub cargarDatosFiltro()
            Dim dteFecPeriodo As DateTime = DateTime.Parse(Request.Params("dteFecPeriodo"))
            Dim strCodCIIU As String = Request.Params("strCodCIIU")

            Dim obrCIIU As BusinessRules.CIIU = New BusinessRules.CIIU
            Dim dsCIIU As DataSet = obrCIIU.buscarXCodigo(strCodCIIU)
            Dim strNombreCIIU As String = dsCIIU.Tables(0).Rows(0)("Nombre")

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            Dim dsMetodizado As DataSet = obrMetodizado.filtrarRankingEmpresa(ecReporte.RankingEmpresasporCIIU, strCodCIIU, String.Empty, dteFecPeriodo)

            If Not dsMetodizado Is Nothing Then

                dgrdMnt.DataSource = dsMetodizado
                dgrdMnt.DataBind()
                Dim strTitulo As String = strCodCIIU + " - " + strNombreCIIU
                Dim arrCriterio(0, 1) As String
                arrCriterio(0, 0) = "Periodo"
                arrCriterio(0, 1) = dteFecPeriodo.ToShortDateString

                Util.exportarExcel(dgrdMnt, strTitulo, arrCriterio)
            End If
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    intContador += 1
                    dblImporte1 += CDbl(DataBinder.Eval(e.Item.DataItem, "ACTIVO"))
                    dblImporte2 += CDbl(DataBinder.Eval(e.Item.DataItem, "PASIVO"))
                    dblImporte3 += CDbl(DataBinder.Eval(e.Item.DataItem, "PATRIMONIO_NETO"))
                    dblImporte4 += CDbl(DataBinder.Eval(e.Item.DataItem, "CAPITAL"))
                    dblImporte5 += CDbl(DataBinder.Eval(e.Item.DataItem, "INGRESOS_NETOS"))
                    dblImporte6 += CDbl(DataBinder.Eval(e.Item.DataItem, "EBIDTA"))
                    dblImporte7 += CDbl(DataBinder.Eval(e.Item.DataItem, "UTILIDAD/PERDIDA"))
                    dblImporte8 += CDbl(DataBinder.Eval(e.Item.DataItem, "MARGEN_BRUTO"))
                    dblImporte9 += CDbl(DataBinder.Eval(e.Item.DataItem, "MARGEN_OPERATIVO"))
                    dblImporte10 += CDbl(DataBinder.Eval(e.Item.DataItem, "MARGEN_NETO"))
                    dblImporte11 += CDbl(DataBinder.Eval(e.Item.DataItem, "CAPITAL_TRABAJO"))
                    dblImporte12 += CDbl(DataBinder.Eval(e.Item.DataItem, "APALANCAMIENTO"))
                    dblImporte13 += CDbl(DataBinder.Eval(e.Item.DataItem, "ROTACION_CXC"))
                    dblImporte14 += CDbl(DataBinder.Eval(e.Item.DataItem, "ROTACION_CXP"))
                    dblImporte15 += CDbl(DataBinder.Eval(e.Item.DataItem, "ROTACION_EXISTENCIAS"))
                    dblImporte16 += CDbl(DataBinder.Eval(e.Item.DataItem, "GENERACION_BRUTA_CAJA"))
                    dblImporte17 += CDbl(DataBinder.Eval(e.Item.DataItem, "FLUJO_LIBRE_CAJA"))
                    dblImporte18 += CDbl(DataBinder.Eval(e.Item.DataItem, "SERVICIO_DEUDA"))
                    e.Item.Cells(1).Text = Format(CDbl(e.Item.Cells(1).Text), "##,##0")
                    e.Item.Cells(2).Text = Format(CDbl(e.Item.Cells(2).Text), "##,##0")
                    e.Item.Cells(3).Text = Format(CDbl(e.Item.Cells(3).Text), "##,##0")
                    e.Item.Cells(4).Text = Format(CDbl(e.Item.Cells(4).Text), "##,##0")
                    e.Item.Cells(5).Text = Format(CDbl(e.Item.Cells(5).Text), "##,##0")
                    e.Item.Cells(6).Text = Format(CDbl(e.Item.Cells(6).Text), "##,##0")
                    e.Item.Cells(7).Text = Format(CDbl(e.Item.Cells(7).Text), "##,##0")
                    e.Item.Cells(8).Text = Format(CDbl(e.Item.Cells(8).Text), "##,##0.0")
                    e.Item.Cells(9).Text = Format(CDbl(e.Item.Cells(9).Text), "##,##0.0")
                    e.Item.Cells(10).Text = Format(CDbl(e.Item.Cells(10).Text), "##,##0.0")
                    e.Item.Cells(11).Text = Format(CDbl(e.Item.Cells(11).Text), "##,##0")
                    e.Item.Cells(12).Text = Format(CDbl(e.Item.Cells(12).Text), "##,##0.00")
                    e.Item.Cells(13).Text = Format(CDbl(e.Item.Cells(13).Text), "##,##0")
                    e.Item.Cells(14).Text = Format(CDbl(e.Item.Cells(14).Text), "##,##0")
                    e.Item.Cells(15).Text = Format(CDbl(e.Item.Cells(15).Text), "##,##0")
                    e.Item.Cells(16).Text = Format(CDbl(e.Item.Cells(16).Text), "##,##0")
                    e.Item.Cells(17).Text = Format(CDbl(e.Item.Cells(17).Text), "##,##0")
                    e.Item.Cells(18).Text = Format(CDbl(e.Item.Cells(18).Text), "##,##0.00")
                Case ListItemType.Footer
                    e.Item.Cells(0).Text = "PROMEDIO"
                    If intContador > 0 Then
                        dblImporte8 /= intContador
                        dblImporte9 /= intContador
                        dblImporte10 /= intContador
                        dblImporte12 /= intContador
                        dblImporte13 /= intContador
                        dblImporte14 /= intContador
                        dblImporte15 /= intContador
                        dblImporte18 /= intContador
                    End If
                    e.Item.Cells(8).Text = Format(dblImporte8, "##,##0.0")
                    e.Item.Cells(9).Text = Format(dblImporte9, "##,##0.0")
                    e.Item.Cells(10).Text = Format(dblImporte10, "##,##0.0")
                    e.Item.Cells(12).Text = Format(dblImporte12, "##,##0.00")
                    e.Item.Cells(13).Text = Format(dblImporte13, "##,##0")
                    e.Item.Cells(14).Text = Format(dblImporte14, "##,##0")
                    e.Item.Cells(15).Text = Format(dblImporte15, "##,##0")
                    e.Item.Cells(18).Text = Format(dblImporte18, "##,##0.00")
                    e.Item.Cells(0).Attributes.Add("align", "left")
                    e.Item.Cells(1).Attributes.Add("align", "right")
                    e.Item.Cells(2).Attributes.Add("align", "right")
                    e.Item.Cells(3).Attributes.Add("align", "right")
                    e.Item.Cells(4).Attributes.Add("align", "right")
                    e.Item.Cells(5).Attributes.Add("align", "right")
                    e.Item.Cells(6).Attributes.Add("align", "right")
                    e.Item.Cells(7).Attributes.Add("align", "right")
                    e.Item.Cells(8).Attributes.Add("align", "right")
                    e.Item.Cells(9).Attributes.Add("align", "right")
                    e.Item.Cells(10).Attributes.Add("align", "right")
                    e.Item.Cells(11).Attributes.Add("align", "right")
                    e.Item.Cells(12).Attributes.Add("align", "right")
                    e.Item.Cells(13).Attributes.Add("align", "right")
                    e.Item.Cells(14).Attributes.Add("align", "right")
                    e.Item.Cells(15).Attributes.Add("align", "right")
                    e.Item.Cells(16).Attributes.Add("align", "right")
                    e.Item.Cells(17).Attributes.Add("align", "right")
                    e.Item.Cells(18).Attributes.Add("align", "right")
            End Select
        End Sub

    End Class

End Namespace