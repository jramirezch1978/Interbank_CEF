'*************************************************************
'Proposito:
'Autor: Maria Laura Santisteban Valdez
'Fecha Creacion: 22/03/2006
'Modificado por: María Laura Santisteban
'Fecha Mod.: 03/04/2006
'*************************************************************

Imports System
Imports System.IO
Imports System.Collections
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class mntRCD
        Inherits PageBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents btnInicializar As System.Web.UI.WebControls.Button
        Protected WithEvents imgFecPeriodo As System.Web.UI.WebControls.Image
        Protected WithEvents vreqFecPeriodo As System.Web.UI.WebControls.RequiredFieldValidator

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
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    CargarScripts()
                End If
            End If
        End Sub

        Private Sub CargarScripts()
            'Añadir atributo readonly a textbox
            txtFecPeriodo.Attributes.Add("readonly", "readonly")
        End Sub

        Private Sub Submit1_ServerClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Submit1.ServerClick
            If Not File1.PostedFile Is Nothing And File1.PostedFile.ContentLength > 0 Then
                Dim fn As String = System.IO.Path.GetFileName(File1.PostedFile.FileName)
              
                Dim obeParametro As BusinessEntity.Parametro = Me.buscarParametro("RCD_RUTA_ARCHIVO")

                Dim strRUTA_ARCHIVO_RCD As String = obeParametro.Valor1

                Dim SaveLocation As String = strRUTA_ARCHIVO_RCD & "\" & fn
                Try
                    File1.PostedFile.SaveAs(SaveLocation)

                    Dim objReader As New StreamReader(SaveLocation)
                    Dim sLine As String = ""
                    Dim arrText As New ArrayList

                    Do
                        sLine = objReader.ReadLine()
                        If Not sLine Is Nothing Then
                            arrText.Add(sLine)
                        End If
                    Loop Until sLine Is Nothing
                    objReader.Close()

                    Dim obeRCD As BusinessEntity.RCD

                    Dim obrRCD As BusinessRules.RCD = New BusinessRules.RCD

                    Dim bolRC As Boolean
                    Dim arInfo() As String
                    Dim intAnioPeriodo As Integer, intMesPeriodo As Integer, intDiaPeriodo As Integer
                    Dim strCUCliente As String, strRazonSocial As String, strNombreEjecutivo As String
                    Dim decMontoDeudaSoles As Decimal, decMontoDeudaDolares As Decimal, decMontoContingente As Decimal

                    intAnioPeriodo = Today.Year
                    intMesPeriodo = Today.Month
                    intDiaPeriodo = Today.Day

                    'Eliminamos lo ingresado por día:
                    obeRCD = New BusinessEntity.RCD

                    obeRCD.AnioPeriodo = intAnioPeriodo
                    obeRCD.MesPeriodo = intMesPeriodo
                    obeRCD.DiaPeriodo = intDiaPeriodo

                    Dim voRC As Boolean = obrRCD.eliminar(obeRCD)
                    'Fin de Eliminación

                    For Each sLine In arrText
                        arInfo = sLine.Split(";")

                        obeRCD = New BusinessEntity.RCD
                        strCUCliente = arInfo(0)

                        'Inicializamos Variables
                        strRazonSocial = ""
                        decMontoDeudaSoles = 0
                        decMontoDeudaDolares = 0
                        decMontoContingente = 0
                        strNombreEjecutivo = ""
                        'Fin de Inicialización

                        If arInfo.Length >= 2 Then
                            strRazonSocial = arInfo(1)
                        End If
                        If arInfo.Length >= 3 Then
                            decMontoDeudaSoles = arInfo(2)
                        End If
                        If arInfo.Length >= 4 Then
                            decMontoDeudaDolares = arInfo(3)
                        End If
                        If arInfo.Length >= 5 Then
                            decMontoContingente = arInfo(4)
                        End If
                        If arInfo.Length >= 6 Then
                            strNombreEjecutivo = arInfo(5)
                        End If

                        obeRCD.AnioPeriodo = intAnioPeriodo
                        obeRCD.MesPeriodo = intMesPeriodo
                        obeRCD.DiaPeriodo = intDiaPeriodo
                        obeRCD.CUCliente = strCUCliente
                        obeRCD.RazonSocial = strRazonSocial
                        obeRCD.MontoDeudaSoles = decMontoDeudaSoles
                        obeRCD.MontoDeudaDolares = decMontoDeudaDolares
                        obeRCD.MontoContingente = decMontoContingente
                        obeRCD.NombreEjecutivo = strNombreEjecutivo

                        bolRC = obrRCD.agregar(obeRCD)
                    Next

                    obrRCD = Nothing
                    Dim oFecha As New Date(intAnioPeriodo, intMesPeriodo, intDiaPeriodo)
                    ' txtFecPeriodo.Text = intDiaPeriodo & "/" & intMesPeriodo & "/" & intAnioPeriodo
                    txtFecPeriodo.Text = String.Format("{0:dd/MM/yyyy}", oFecha)
                    buscar()
                    Me.muestraAlerta(ccALERTA_EXITO_CARGA_ARCHIVO_RCD)

                Catch Exc As Exception
                    Logger.Error(MethodInfo.GetCurrentMethod, Exc, "")
                    Me.muestraAlerta(ccALERTA_ERROR_CARGA_ARCHIVO_RCD)
                End Try
            Else
                Me.muestraAlerta(ccALERTA_ERROR_SELECCIONAR_ARCHIVO_RCD)
            End If
        End Sub

        Private Sub buscar()
            Dim obrRCD As BusinessRules.RCD = New BusinessRules.RCD

            Dim dsRCD As DataSet
            Dim intAnioPeriodo As Integer, intMesPeriodo As Integer, intDiaPeriodo As Integer
            intDiaPeriodo = Int32.Parse(txtFecPeriodo.Text.Split("/")(0))
            intMesPeriodo = Int32.Parse(txtFecPeriodo.Text.Split("/")(1))
            intAnioPeriodo = Int32.Parse(txtFecPeriodo.Text.Split("/")(2))
            dsRCD = obrRCD.listar(intAnioPeriodo, intMesPeriodo, intDiaPeriodo)
            dgrdMnt.DataSource = dsRCD.Tables(0)
            dgrdMnt.DataKeyField = "CodReg"
            dgrdMnt.DataBind()
            lblNumReg.Text = dsRCD.Tables(0).Rows.Count
        End Sub

        Private Sub dgrdMnt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            dgrdMnt.CurrentPageIndex = 0
            dgrdMnt.CurrentPageIndex = e.NewPageIndex
            buscar()
        End Sub

        Private Sub dgrdMnt_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.EditCommand
            dgrdMnt.EditItemIndex = e.Item.ItemIndex
            buscar()
        End Sub

        Private Sub dgrdMnt_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.CancelCommand
            dgrdMnt.EditItemIndex = -1
            buscar()
        End Sub

        Private Sub dgrdMnt_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.UpdateCommand
            Dim strKey As String = dgrdMnt.DataKeys(e.Item.ItemIndex)
            Dim intAnioPeriodo As Integer = Int32.Parse(strKey.Split(":")(0))
            Dim intMesPeriodo As Integer = Int32.Parse(strKey.Split(":")(1))
            Dim intDiaPeriodo As Integer = Int32.Parse(strKey.Split(":")(2))
            Dim strCUCliente As String = strKey.Split(":")(3)

            Dim txtObservacion As TextBox = CType(e.Item.FindControl("txtObservacion"), TextBox)
            Dim obrRCD As BusinessRules.RCD = New BusinessRules.RCD

            Dim obeRCD As BusinessEntity.RCD = New BusinessEntity.RCD
            obeRCD.AnioPeriodo = intAnioPeriodo
            obeRCD.MesPeriodo = intMesPeriodo
            obeRCD.DiaPeriodo = intDiaPeriodo
            obeRCD.CUCliente = strCUCliente
            obeRCD.Observacion = txtObservacion.Text
            Dim voRC As Boolean = obrRCD.modificar(obeRCD)
            obrRCD = Nothing

            dgrdMnt.EditItemIndex = -1
            buscar()
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace