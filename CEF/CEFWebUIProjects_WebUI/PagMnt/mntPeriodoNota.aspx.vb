Imports System.Data
Imports CEF.BusinessRules
Imports CEF.BusinessEntity
Imports CEF.Common.Globals

Namespace CEF.WebUI

    Partial Class mntPeriodoNota
        Inherits PageBase
#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Protected Shared pcodMetodizado As String
        Protected Shared pCodPeriodoFiltrado As String
        Protected Shared pCodCodigoCuenta As String
        Protected Shared pClientId As String


        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                'AjaxPro.Utility.RegisterTypeForAjax(GetType(mntPeriodoNota))
                CargarPeriodoNota()
            End If
        End Sub

        Sub CargarPeriodoNota()
            'Añadir atributo readonly a textbox
            txtCuenta.Attributes.Add("readonly", "readonly")
            txtCodMetodizado.Attributes.Add("readonly", "readonly")

            Dim strCodMetodizado As String
            Dim strCodPeriodoFiltrado As String
            Dim strCodCuenta As String
            Dim strRazSoc As String
            Dim strDescCuenta As String
            Dim strControlid As String

            '
            Dim arrayperiodos() As String
            Dim arrayperList As ArrayList
            '
            strCodMetodizado = Request.Params("intCodMetodizado").ToString()
            HID_CodMetodizado.Value = strCodMetodizado

            strCodPeriodoFiltrado = Request.Params("strPeriodoFiltrado").ToString()
            arrayperiodos = strCodPeriodoFiltrado.Split(";")
            Array.Reverse(arrayperiodos)
            strCodPeriodoFiltrado = String.Empty
            arrayperList = New ArrayList(arrayperiodos)
            For i As Integer = 0 To arrayperList.Count - 1
                strCodPeriodoFiltrado = strCodPeriodoFiltrado + arrayperList(i) + ";"
            Next

            HID_CodPeriodoFiltrado.Value = strCodPeriodoFiltrado.Substring(0, strCodPeriodoFiltrado.Length - 1)

            strCodCuenta = Request.Params("intCodCuenta").ToString()
            HID_CodCuenta.Value = strCodCuenta

            strRazSoc = Request.Params("strRazSoc").ToString()
            strDescCuenta = Request.Params("strDescCuenta").ToString()
            strControlid = Request.Params("controlid").ToString()
            HID_CodClientID.Value = strControlid

            With Me
                .txtRazonSocial.Text = strRazSoc
                .txtCuenta.Text = strDescCuenta
                .txtCodMetodizado.Text = strCodMetodizado
            End With

            Dim obePeriodoNota As New CEF.BusinessRules.PeriodoNota
            Dim ArrayPeriodoNota As ArrayList = obePeriodoNota.listarBD(Int32.Parse(HID_CodMetodizado.Value), HID_CodPeriodoFiltrado.Value, Int16.Parse(HID_CodCuenta.Value))

            Me.dgdPeriodoNota.DataSource = ArrayPeriodoNota
            Me.dgdPeriodoNota.DataBind()
            Me.lblNumReg.Text = Me.dgdPeriodoNota.Items.Count.ToString()

        End Sub

        Private Sub BtnAccionEnviarDatos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAccionEnviarDatos.Click
            Dim brPeriodoNota As New CEF.BusinessRules.PeriodoNota
            'Me.HID_RptaServer.Value = brPeriodoNota.EnviaDatos(Me.HID_EnviaDatos.Value, Me.datosGlobal.sUser)
            Me.HID_RptaServer.Value = brPeriodoNota.EnviaDatos(Me.HID_EnviaDatos.Value, retornaUsuarioSesion())
        End Sub

        Private Sub dgdPeriodoNota_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgdPeriodoNota.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim ltEstado As Literal = e.Item.FindControl("ltEstado")
                Dim ltSituacion As Literal = e.Item.FindControl("ltSituacion")
                Dim txtNota As TextBox = e.Item.FindControl("txtNota")
                If ((ltEstado.Text.Equals("VALIDADO") _
                    And Not (fRetornaPerfilUsuario() = Common.Globals.ecPerfil.ANALISTA_RIESGO _
                    Or fRetornaPerfilUsuario() = Common.Globals.ecPerfil.ADMINISTRADOR)) Or _
                    fRetornaPerfilUsuario() = Common.Globals.ecPerfil.FUNCIONARIO_CONSULTA) Then
                    txtNota.ReadOnly = True
                End If
            End If
        End Sub
    End Class

End Namespace