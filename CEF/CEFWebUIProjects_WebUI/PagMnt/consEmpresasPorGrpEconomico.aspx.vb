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
    Partial Class consEmpresasPorGrpEconomico
        Inherits PageBase

        Private dblImporte1 As Double
        Private dblImporte2 As Double
        Private dblImporte3 As Double
        Private dblImporte4 As Double
        Private dblImporte5 As Double
        Private dblImporte6 As Double
        Private dblImporte7 As Double
        Private dblImporte8 As Double

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
            imgBusGrupoEconomico.Attributes.Add("onclick", "javascript:f_AbrirBusGen('../PagMnt/busGrupoEconomico.aspx','txtCodGrupoEconomico','txtNombreGrupoEconomico');")
            imgFecPeriodo.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecPeriodo.ClientID + "');"
            txtFecPeriodo.Attributes.Add("onKeyUp", "javascript:DateFormat(this,this.value,event,false,'3')")
            txtFecPeriodo.Attributes.Add("onblur", "javascript:DateFormat(this,this.value,event,true,'3')")

            'Añadir atributo readonly a textbox
            txtCodGrupoEconomico.Attributes.Add("readonly", "readonly")
            txtNombreGrupoEconomico.Attributes.Add("readonly", "readonly")
        End Sub

        Private Sub inicializarControles()
            txtCodGrupoEconomico.Text = String.Empty
            txtNombreGrupoEconomico.Text = String.Empty
            txtFecPeriodo.Text = String.Empty

            dgrdMnt.CurrentPageIndex = 0
            dgrdMnt.DataSource = New DataTable
            dgrdMnt.DataBind()
            lblNumReg.Text = 0

            activarReportes(ecReporte.RankingEmpresasporGrupoEconomico, False)
        End Sub

        Private Sub activarReportes(ByVal pordReporte As ecReporte, Optional ByVal bolActivar As Boolean = True)
            Dim strCodGrupoEconomico As String = txtCodGrupoEconomico.Text
            Dim dteFecPeriodo As DateTime
            If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)
            If pordReporte = ecReporte.RankingEmpresasporGrupoEconomico Then
                If bolActivar Then
                    imgImprimir.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwEmpresasPorGrpEconomico.aspx?strCodGrupoEconomico={0}&dteFecPeriodo={1}');", strCodGrupoEconomico, dteFecPeriodo))
                    lnkImprimir.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwEmpresasPorGrpEconomico.aspx?strCodGrupoEconomico={0}&dteFecPeriodo={1}');", strCodGrupoEconomico, dteFecPeriodo))
                    imgExpExcel.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpEmpresasPorGrpEconomico.aspx?strCodGrupoEconomico={0}&dteFecPeriodo={1}');", strCodGrupoEconomico, dteFecPeriodo))
                    lnkExpExecel.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpEmpresasPorGrpEconomico.aspx?strCodGrupoEconomico={0}&dteFecPeriodo={1}');", strCodGrupoEconomico, dteFecPeriodo))
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
                activarReportes(ecReporte.RankingEmpresasporGrupoEconomico, False)

                Dim dteFecPeriodo As DateTime
                If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)

                Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
                Dim dsMetodizado As DataSet = obrMetodizado.filtrarRankingEmpresa(ecReporte.RankingEmpresasporGrupoEconomico, String.Empty, txtCodGrupoEconomico.Text, dteFecPeriodo)
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
                            activarReportes(ecReporte.RankingEmpresasporGrupoEconomico, True)
                        End If
                        lblNumReg.Text = intNumReg
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
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

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace
