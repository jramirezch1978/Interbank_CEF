'*************************************************************
'Proposito: Exportar a Excel la Consulta Por Grupo Económico
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 21/11/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Text
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals

Namespace CEF.WebUI

    Partial Class rvwExpEmpresasPorGrpEconomico
        Inherits PageBase

        Private dblImporte1 As Double
        Private dblImporte2 As Double
        Private dblImporte3 As Double
        Private dblImporte4 As Double
        Private dblImporte5 As Double
        Private dblImporte6 As Double
        Private dblImporte7 As Double


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
            'SRT_02160
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
            Dim strCodGrupoEconomico As String = Request.Params("strCodGrupoEconomico")

            Dim obrGrupoEconomico As BusinessRules.GrupoEconomico = New BusinessRules.GrupoEconomico
            Dim dsGrupoEconomico As DataSet
            dsGrupoEconomico = obrGrupoEconomico.buscarXCodigo(strCodGrupoEconomico)
            Dim strNombreGrupoEconomico As String = dsGrupoEconomico.Tables(0).Rows(0)("Nombre")

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            Dim dsMetodizado As DataSet = obrMetodizado.filtrarRankingEmpresa(ecReporte.RankingEmpresasporGrupoEconomico, String.Empty, strCodGrupoEconomico, dteFecPeriodo)

            If Not dsMetodizado Is Nothing Then

                dgrdMnt.DataSource = dsMetodizado
                dgrdMnt.DataBind()
                Dim strTitulo As String = strCodGrupoEconomico + " - " + strNombreGrupoEconomico
                Dim arrCriterio(0, 1) As String
                arrCriterio(0, 0) = "Periodo"
                arrCriterio(0, 1) = dteFecPeriodo.ToShortDateString

                Util.exportarExcel(dgrdMnt, strTitulo, arrCriterio)
            End If
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    dblImporte1 += CDbl(DataBinder.Eval(e.Item.DataItem, "ACTIVO"))
                    dblImporte2 += CDbl(DataBinder.Eval(e.Item.DataItem, "PASIVO"))
                    dblImporte3 += CDbl(DataBinder.Eval(e.Item.DataItem, "PATRIMONIO_NETO"))
                    dblImporte4 += CDbl(DataBinder.Eval(e.Item.DataItem, "INGRESOS_NETOS"))
                    dblImporte5 += CDbl(DataBinder.Eval(e.Item.DataItem, "UTILIDAD/PERDIDA"))
                    dblImporte6 += CDbl(DataBinder.Eval(e.Item.DataItem, "EBIDTA"))
                    dblImporte7 += CDbl(DataBinder.Eval(e.Item.DataItem, "CAPITAL_TRABAJO"))
                    e.Item.Cells(1).Text = Format(CDbl(e.Item.Cells(1).Text), "##,##0")
                    e.Item.Cells(2).Text = Format(CDbl(e.Item.Cells(2).Text), "##,##0")
                    e.Item.Cells(3).Text = Format(CDbl(e.Item.Cells(3).Text), "##,##0")
                    e.Item.Cells(4).Text = Format(CDbl(e.Item.Cells(4).Text), "##,##0")
                    e.Item.Cells(5).Text = Format(CDbl(e.Item.Cells(5).Text), "##,##0")
                    e.Item.Cells(6).Text = Format(CDbl(e.Item.Cells(6).Text), "##,##0")
                    e.Item.Cells(7).Text = Format(CDbl(e.Item.Cells(7).Text), "##,##0")
                Case ListItemType.Footer
                    e.Item.Cells(0).Text = "TOTALES"
                    e.Item.Cells(1).Text = Format(dblImporte1, "##,##0")
                    e.Item.Cells(2).Text = Format(dblImporte2, "##,##0")
                    e.Item.Cells(3).Text = Format(dblImporte3, "##,##0")
                    e.Item.Cells(4).Text = Format(dblImporte4, "##,##0")
                    e.Item.Cells(5).Text = Format(dblImporte5, "##,##0")
                    e.Item.Cells(6).Text = Format(dblImporte6, "##,##0")
                    e.Item.Cells(7).Text = Format(dblImporte7, "##,##0")
                    e.Item.Cells(0).Attributes.Add("align", "left")
                    e.Item.Cells(1).Attributes.Add("align", "right")
                    e.Item.Cells(2).Attributes.Add("align", "right")
                    e.Item.Cells(3).Attributes.Add("align", "right")
                    e.Item.Cells(4).Attributes.Add("align", "right")
                    e.Item.Cells(5).Attributes.Add("align", "right")
                    e.Item.Cells(6).Attributes.Add("align", "right")
                    e.Item.Cells(7).Attributes.Add("align", "right")
            End Select
        End Sub

    End Class

End Namespace