Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Reflection

Namespace CEF.WebUI


Partial Class busSeleccionarPeriodoProyeccion
    Inherits PageBase

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
    Protected WithEvents hidPeriodoFiltrado As System.Web.UI.HtmlControls.HtmlInputHidden

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region
        'Dim strRazonSocial As String

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'SRT_2017-02160
            'If (MyBase.verificaConneccion()) Then
            '    'If (Not Page.IsPostBack()) Then
            '    CargarParametros()
            '    CargarScripts()
            '    CargarDatos()
            '    'End If
            'End If
            If PageBase.PostbackSession(Me) Then
                CargarParametros()
                CargarScripts()
                CargarDatos()
            End If
    End Sub

        Private Sub CargarScripts()
            'imgCerrar.Attributes.Add("onclick", "javascript:{window.returnValue=null; window.close();}")
            imgCerrar.Attributes.Add("onclick", "javascript:{f_Aceptar();}")

            ibtnNuevo.Attributes.Add("onclick", String.Format("javascript:f_AbrirProyeccionCuenta('mntPeriodoProyeccion.aspx?intCodMetodizado={0}&strRazonSocial={1}&intCodProyeccion={2}&strAccion={3}',{4},{5});", Integer.Parse(hidCodMetodizado.Value), Me.hidRazonSocial.Value, 0, "NUEVO", 530, 500))
            lnkNuevo.Attributes.Add("href", String.Format("javascript:f_AbrirProyeccionCuenta('mntPeriodoProyeccion.aspx?intCodMetodizado={0}&strRazonSocial={1}&intCodProyeccion={2}&strAccion={3}',{4},{5});", Integer.Parse(hidCodMetodizado.Value), Me.hidRazonSocial.Value, 0, "NUEVO", 530, 500))

            'Añadir atributo readonly a textbox
            txtRazonSocial.Attributes.Add("readonly", "readonly")
        End Sub
        Private Sub CargarParametros()
            Me.hidCodMetodizado.Value = Request.Params("intCodMetodizado").ToString()
            Me.hidRazonSocial.Value = Request.Params("strRazonSocial").ToString()
        End Sub
        Private Sub CargarDatos()
            Me.txtRazonSocial.Text = Me.hidRazonSocial.Value
            Dim dsProyeccion As Data.DataSet
            Dim obrProyeccion As BusinessRules.ProyeccionBR = New BusinessRules.ProyeccionBR

            dsProyeccion = Nothing
            dsProyeccion = obrProyeccion.leer(Integer.Parse(hidCodMetodizado.Value))

            If (Not dsProyeccion Is Nothing) Then
                Me.dgrdMnt.DataSource = dsProyeccion
                Me.dgrdMnt.DataBind()
                lblNumReg.Text = dsProyeccion.Tables(0).Rows.Count
            End If
            obrProyeccion = Nothing
        End Sub
        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim imgEditar As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("imgEditar")
                Dim imgEliminar As System.Web.UI.WebControls.ImageButton = e.Item.FindControl("imgEliminar")
                Dim estado As Common.Globals.ecEstadoPeriodo
                imgEditar.Attributes.Add("onclick", String.Format("javascript:f_AbrirProyeccionCuenta('mntPeriodoProyeccion.aspx?intCodMetodizado={0}&strRazonSocial={1}&intCodProyeccion={2}&strAccion={3}',{4},{5});", Integer.Parse(hidCodMetodizado.Value), Me.hidRazonSocial.Value, imgEditar.CommandArgument, "EDITAR", 530, 500))
                imgEliminar.Attributes.Add("onclick", "VerificarEliminacion();")
            End If
        End Sub
        Public Sub ManejadorCrudProyeccion(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
            Dim myButton As ImageButton = CType(sender, ImageButton)
            If (myButton.CommandName.Equals("Eliminar") And Me.hidConfirmacion.Value.Equals("1")) Then
                Eliminar(myButton.CommandArgument, Integer.Parse(Me.hidCodMetodizado.Value))
            End If
            Me.hidConfirmacion.Value = "0"
        End Sub
        Public Sub Eliminar(ByVal pintCodProyeccion As String, ByVal pintCodMetodizado As Integer)
            Dim pcadena() As String = pintCodProyeccion.Split("|")
            Dim intCodProy As Integer = Integer.Parse(pcadena(0))
            Dim intEstado As Common.Globals.ecEstadoPeriodo = Integer.Parse(pcadena(1))

            If (intEstado = ecEstadoPeriodo.VALIDADO) Then
                If (fRetornaPerfilUsuario() <= Common.Globals.ecPerfil.ANALISTA_RIESGO) Then
                    Dim obrProyeccion As BusinessRules.ProyeccionBR = New BusinessRules.ProyeccionBR
                    Try
                        obrProyeccion.Eliminar(intCodProy, pintCodMetodizado)
                        CargarDatos()
                    Catch ex As Exception
                        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                        Throw ex
                    End Try
                Else
                    Me.muestraAlerta("Ud. no tiene permisos para eliminar una proyección validada.")
                End If
            Else
                Dim obrProyeccion As BusinessRules.ProyeccionBR = New BusinessRules.ProyeccionBR
                Try
                    obrProyeccion.Eliminar(intCodProy, pintCodMetodizado)
                    CargarDatos()
                Catch ex As Exception
                    Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                    Throw ex
                End Try
            End If

        End Sub
        Private Sub BtnAccionActualizarGrilla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAccionActualizarGrilla.Click
            Me.CargarDatos()
        End Sub
    End Class
End Namespace
