'*************************************************************
'Proposito: Consulta del Informe SBS, archivo Sucave
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 24/07/2006
'Modificado por: 
'Fecha Mod.: 
'*************************************************************

Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class consInformeSBS
        Inherits PageBase

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
            imgFecPeriodo.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecPeriodo.ClientID + "');"
            txtFecPeriodo.Attributes.Add("onKeyUp", "javascript:DateFormat(this,this.value,event,false,'3')")
            txtFecPeriodo.Attributes.Add("onblur", "javascript:DateFormat(this,this.value,event,true,'3')")
        End Sub

        Private Sub activarReportes(ByVal pordReporte As ecReporte, Optional ByVal bolActivar As Boolean = True)
            Dim dteFecPeriodo As DateTime
            If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)

            If pordReporte = ecReporte.InformeSBS Then
                If bolActivar Then
                    imgExpExcel.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpInformeSBS.aspx?dteFecPeriodo={0}');", dteFecPeriodo))
                    lnkExpExecel.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpInformeSBS.aspx?dteFecPeriodo={0}');", dteFecPeriodo))
                Else
                    imgExpExcel.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_IMPRIMIR_NO_EXISTE_PERIODO))
                    lnkExpExecel.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_IMPRIMIR_NO_EXISTE_PERIODO))
                End If
            End If
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

        Private Sub inicializarControles()
            txtFecPeriodo.Text = String.Empty

            dgrdMnt.CurrentPageIndex = 0
            dgrdMnt.DataSource = New DataTable
            dgrdMnt.DataBind()
            lblNumReg.Text = 0
            activarReportes(ecReporte.InformeSBS, False)

        End Sub

        Private Sub buscar()
            Try
                Dim dteFecPeriodo As DateTime
                If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)

                Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
                activarReportes(ecReporte.InformeSBS, False)

                'filtrarInformeSBS
                Dim dsMetodizado As DataSet = obrMetodizado.generarInformeSBS(dteFecPeriodo)
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
                            'Activamos el reporte en Excel
                            activarReportes(ecReporte.InformeSBS, True)
                        End If
                        lblNumReg.Text = intNumReg
                    End If
                End If

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class
End Namespace