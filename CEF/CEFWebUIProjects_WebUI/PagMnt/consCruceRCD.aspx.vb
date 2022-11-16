Imports CEF.Common
Imports CEF.Common.Util
Imports CEF.Common.Globals
Imports CEF.BusinessRules
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class consCruceRCD
        Inherits PageBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnBuscar As System.Web.UI.WebControls.Button
        Protected WithEvents imgImprimir As System.Web.UI.WebControls.Image
        Protected WithEvents lnkImprimir As System.Web.UI.WebControls.HyperLink

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
            'Introducir aquí el código de usuario para inicializar la página
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

        Private Sub inicializarControles()
            txtFecPeriodo.Text = String.Empty
        End Sub

        Private Sub btnInicializar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicializar.Click
            inicializarControles()
        End Sub

        Private Sub buscar()
            Try
                Dim dteFecPeriodo As DateTime
                If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)

                Dim obrRCD As BusinessRules.RCD = New BusinessRules.RCD
                Dim dsRCD As DataSet = obrRCD.cruceEEFFValidados(dteFecPeriodo)
                If dsRCD Is Nothing Then
                    Me.muestraAlerta(ccALERTA_ERROR_BUSCAR)
                Else
                    If dsRCD.Tables.Count = 0 Then
                        Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                    Else
                        Dim intNumReg As Integer = dsRCD.Tables(0).Rows.Count
                        If intNumReg = 0 Then
                            Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                        Else
                            Dim parametros As String
                            parametros = "&dteFecPeriodo=" & dteFecPeriodo
                            Response.Write("<script language='JavaScript' src='../Funciones/UtilVentana.js'></script>")
                            Response.Write("<script language='javascript'>f_VtnNoDlg('winRep','../PagRpt/rvwCruceRCD.aspx?" + parametros + " ',800, 600, true, true, null, null);</script>")
                        End If
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        Private Sub btnCruceRCD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCruceRCD.Click
            buscar()
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace

