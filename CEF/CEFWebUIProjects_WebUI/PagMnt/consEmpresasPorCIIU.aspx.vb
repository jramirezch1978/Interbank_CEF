'*************************************************************
'Proposito:
'Autor: Maria Laura Santisteban Valdez
'Fecha Creacion: 22/03/2006
'Modificado por: María Laura Santisteban
'Fecha Mod.: 03/04/2006
'*************************************************************

Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class consEmpresasPorCIIU
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
            '        cargaScript()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargaScript()
                End If
            End If
        End Sub

        Private Sub cargaScript()
            imgBusCIIU.Attributes.Add("onclick", "javascript:f_AbrirBusGen('../PagMnt/busCIIU.aspx','txtCodCIIU','txtNombreCIIU');")
            imgFecPeriodo.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecPeriodo.ClientID + "');"
            txtFecPeriodo.Attributes.Add("onKeyUp", "javascript:DateFormat(this,this.value,event,false,'3')")
            txtFecPeriodo.Attributes.Add("onblur", "javascript:DateFormat(this,this.value,event,true,'3')")

            'Añadir atributo readonly a textbox
            txtCodCIIU.Attributes.Add("readonly", "readonly")
            txtNombreCIIU.Attributes.Add("readonly", "readonly")
        End Sub

        Private Sub inicializarControles()
            txtCodCIIU.Text = String.Empty
            txtNombreCIIU.Text = String.Empty
            txtFecPeriodo.Text = String.Empty

            dgrdMnt.CurrentPageIndex = 0
            dgrdMnt.DataSource = New DataTable
            dgrdMnt.DataBind()
            lblNumReg.Text = 0

            activarReportes(ecReporte.RankingEmpresasporCIIU, False)
        End Sub

        Private Sub activarReportes(ByVal pordReporte As ecReporte, Optional ByVal bolActivar As Boolean = True)
            Dim strCodCIIU As String = txtCodCIIU.Text
            Dim strDescripcionCIIU As String = txtNombreCIIU.Text
            Dim dteFecPeriodo As DateTime
            If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)
            If pordReporte = ecReporte.RankingEmpresasporCIIU Then
                If bolActivar Then
                    imgImprimir.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwEmpresasPorCIIU.aspx?strCodCIIU={0}&dteFecPeriodo={1}');", strCodCIIU, dteFecPeriodo))
                    lnkImprimir.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwEmpresasPorCIIU.aspx?strCodCIIU={0}&dteFecPeriodo={1}');", strCodCIIU, dteFecPeriodo))
                    imgExpExcel.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpEmpresasPorCIIU.aspx?strCodCIIU={0}&dteFecPeriodo={1}');", strCodCIIU, dteFecPeriodo))
                    lnkExpExecel.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpEmpresasPorCIIU.aspx?strCodCIIU={0}&dteFecPeriodo={1}');", strCodCIIU, dteFecPeriodo))
                Else
                    imgImprimir.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BUSQUEDA_RESULTADO_CERO))
                    lnkImprimir.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BUSQUEDA_RESULTADO_CERO))
                    imgExpExcel.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BUSQUEDA_RESULTADO_CERO))
                    lnkExpExecel.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BUSQUEDA_RESULTADO_CERO))
                End If
            End If
        End Sub

        Private Sub buscar()
            Try
                activarReportes(ecReporte.RankingEmpresasporCIIU, False)

                Dim dteFecPeriodo As DateTime
                If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)

                Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
                Dim dsMetodizado As DataSet
                dsMetodizado = obrMetodizado.filtrarRankingEmpresa(ecReporte.RankingEmpresasporCIIU, txtCodCIIU.Text, String.Empty, dteFecPeriodo)
                If dsMetodizado Is Nothing Then
                    dgrdMnt.DataSource = New DataTable
                    dgrdMnt.DataBind()
                    Me.muestraAlerta(ccALERTA_ERROR_BUSCAR)
                    lblNumReg.Text = 0
                Else
                    If dsMetodizado.Tables.Count = 0 Then
                        Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                    Else
                        dgrdMnt.DataSource = dsMetodizado
                        dgrdMnt.DataBind()
                        Dim intNumReg As Integer = dsMetodizado.Tables(0).Rows.Count
                        If intNumReg = 0 Then
                            Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                        Else
                            activarReportes(ecReporte.RankingEmpresasporCIIU, True)
                        End If
                        lblNumReg.Text = intNumReg
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            buscar()
        End Sub

        Private Sub btnInicializar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInicializar.Click
            inicializarControles()
        End Sub

        Private Sub dgrdMnt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            dgrdMnt.CurrentPageIndex = 0
            dgrdMnt.CurrentPageIndex = e.NewPageIndex
            dgrdMnt.DataBind()
            buscar()
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

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace

