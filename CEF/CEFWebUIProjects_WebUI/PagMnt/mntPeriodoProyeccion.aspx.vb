Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules

Namespace CEF.WebUI

    Partial Class mntPeriodoProyeccion
        Inherits PageBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidCodPeriodo As System.Web.UI.HtmlControls.HtmlInputHidden



        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim a As Integer = 0
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Put user code to initialize the page here
            If (Not IsCallback()) Then

            End If
            txtDate.Attributes.Add("onchange", "VerificarFechaProyeccion()")
            'SRT_2017-02160
            'If (MyBase.verificaConneccion()) Then
            '    If (Not Page.IsPostBack()) Then
            '        CargarParametros()
            '        CargarScripts()
            '        CargarDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    CargarParametros()
                    CargarScripts()
                    CargarDatos()
                End If
            End If
        End Sub
        Private Sub CargarScripts()
            imgCerrar.Attributes.Add("onclick", "javascript:{window.returnValue=null; window.close();}")
            'imgFecPeriodo.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecPeriodo.ClientID + "');"

            'Añadir atributo readonly a textbox
            txtRazonSocial.Attributes.Add("readonly", "readonly")
            txtCodRegistradoPor.Attributes.Add("readonly", "readonly")
            txtRegistradoPor.Attributes.Add("readonly", "readonly")
            txtCodValidadoPor.Attributes.Add("readonly", "readonly")
            txtValidadoPor.Attributes.Add("readonly", "readonly")
        End Sub
        Private Sub CargarParametros()
            Me.hidCodMetodizado.Value = Request.Params("intCodMetodizado").ToString()
            Me.hidRazonSocial.Value = Request.Params("strRazonSocial").ToString()
            Me.hidCodProyeccion.Value = Request.Params("intCodProyeccion").ToString()
        End Sub
        Private Sub EnableDisableFields()
            If (Not EsNuevo()) Then
                Me.txtFechaRegistro.ReadOnly = True
                txtDate.Disabled = True

                'Me.txtFecPeriodo.ReadOnly = True
                'Me.imgFecPeriodo.Enabled = False
            End If
        End Sub
        Private Sub ValidarRoles()
            'If ((Me.datosGlobal.nPerfil > Common.Globals.ecPerfil.ANALISTA_RIESGO) And (Not Me.txtCodValidadoPor.Text.Equals(String.Empty))) Then
            If ((fRetornaPerfilUsuario() > Common.Globals.ecPerfil.ANALISTA_RIESGO) And (Not Me.txtCodValidadoPor.Text.Equals(String.Empty))) Then
                Me.BtnValidar.Disabled = True
                Me.BtnGrabar.Disabled = True
                Me.dgrdMnt.Enabled = False
            End If
        End Sub
        Private Sub EsAnalistaOSuperior()
            'If (Me.datosGlobal.nPerfil > Common.Globals.ecPerfil.ANALISTA_RIESGO) Then
            If (fRetornaPerfilUsuario() > Common.Globals.ecPerfil.ANALISTA_RIESGO) Then
                Me.BtnValidar.Disabled = True
            End If
        End Sub

        Private Function IsCallback() As Boolean
            If (Not Request.QueryString("miparametro") Is Nothing) Then
                Dim anio As Integer = Integer.Parse(Request.QueryString("anio").ToString())
                Dim mes As Integer = Integer.Parse(Request.QueryString("mes").ToString())
                Dim codMetodizado As Integer = Integer.Parse(Request.QueryString("codmetodizado").ToString())
                Response.Write(VerificarFechaProyeccion(codMetodizado, New Date(anio, mes, 1)))
                Response.Flush()
                Response.End()
                Return True
            End If
            Return False
        End Function
        Private Function EsNuevo() As Boolean
            If (Me.hidCodProyeccion.Value.Equals("0")) Then
                Return True
            Else
                Return False
            End If
        End Function
        Private Sub CargarDatos()
            EnableDisableFields()

            Me.txtRazonSocial.Text = Me.hidRazonSocial.Value
            Dim dsProyeccionCuenta As Data.DataSet
            Dim obrProyeccionCuenta As BusinessRules.ProyeccionCuentaBR = New BusinessRules.ProyeccionCuentaBR

            dsProyeccionCuenta = obrProyeccionCuenta.leer(Integer.Parse(hidCodMetodizado.Value), Integer.Parse(Me.hidCodProyeccion.Value))

            If (Not EsNuevo()) Then
                Dim dsProyeccionCabecera As Data.DataSet
                Dim obrProyeccion As BusinessRules.ProyeccionBR = New BusinessRules.ProyeccionBR

                dsProyeccionCabecera = obrProyeccion.TraerDatosCabecera(Integer.Parse(Me.hidCodMetodizado.Value), Integer.Parse(Me.hidCodProyeccion.Value))

                If (Not dsProyeccionCabecera Is Nothing) Then
                    'Me.txtFecPeriodo.Text = dsProyeccionCabecera.Tables(0).Rows(0).Item("FECHAPROYECCION").ToString()
                    Me.txtDate.Value = dsProyeccionCabecera.Tables(0).Rows(0).Item("FECHAPROYECCION").ToString().Substring(3, 7)
                    Me.txtFechaRegistro.Text = dsProyeccionCabecera.Tables(0).Rows(0).Item("FECHAREGISTRO").ToString()
                    Me.txtCodRegistradoPor.Text = dsProyeccionCabecera.Tables(0).Rows(0).Item("CODUSUARIOINS").ToString()
                    Me.txtRegistradoPor.Text = dsProyeccionCabecera.Tables(0).Rows(0).Item("DESCUSUARIO").ToString()

                    Me.txtCodValidadoPor.Text = dsProyeccionCabecera.Tables(0).Rows(0).Item("CODUSUARIOVAL").ToString()
                    Me.txtValidadoPor.Text = dsProyeccionCabecera.Tables(0).Rows(0).Item("DESCUSUARIOVAL").ToString()
                End If
            End If

            If (Not dsProyeccionCuenta Is Nothing) Then
                dsProyeccionCuenta.Tables(0).Rows(3).Item(3) = "Gastos Operativos"

                '<I-XT9104 - 09/10/2019>
                If (dsProyeccionCuenta.Tables(0).Rows.Count > 8) Then
                    dsProyeccionCuenta.Tables(0).Rows(8).Item(3) = "Deuda Financiera Total"
                    dsProyeccionCuenta.Tables(0).Rows(6).Item(3) = StrConv(dsProyeccionCuenta.Tables(0).Rows(6).Item(3), VbStrConv.ProperCase)
                    dsProyeccionCuenta.Tables(0).Rows(7).Item(3) = StrConv(dsProyeccionCuenta.Tables(0).Rows(7).Item(3), VbStrConv.ProperCase)
                    dsProyeccionCuenta.Tables(0).Rows(8).Item(3) = StrConv(dsProyeccionCuenta.Tables(0).Rows(8).Item(3), VbStrConv.ProperCase)
                End If
                '<F-XT9104 - 09/10/2019>

                Me.dgrdMnt.DataSource = dsProyeccionCuenta
                Me.dgrdMnt.DataBind()
            End If
            obrProyeccionCuenta = Nothing

            If (Not EsNuevo()) Then
                ValidarRoles()
            End If

            EsAnalistaOSuperior()

        End Sub

        Private Sub btnAccionGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccionGrabar.Click
            Grabar(ecEstadoPeriodo.PENDIENTE)
        End Sub
        Private Sub btnAprobarProy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobarProy.Click
            Grabar(ecEstadoPeriodo.VALIDADO)
        End Sub
        Private Sub btnVerificarFechaProy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVerificarFechaProy.Click
            Dim codMetodizado As Integer = Integer.Parse(Me.hidCodMetodizado.Value)
            Dim hidAnio As Integer = Integer.Parse(Me.hidVerifFProyAnio.Value)
            Dim hidMes As Integer = Integer.Parse(Me.hidVerifFProyMes.Value) + 1

            'Dim fechaproy As DateTime = DateTime.Parse("01/" + Me.txtDate.Value)
            Dim fechaproy As DateTime = New Date(hidAnio, hidMes, 1)

            If (VerificarFechaProyeccion(codMetodizado, fechaproy)) Then
                hidVerificarFechaProyeccion.Value = "1"
            Else
                hidVerificarFechaProyeccion.Value = "0"
            End If
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim txtMontoCuenta As TextBox = e.Item.FindControl("txtMontoCuenta")
                If (txtMontoCuenta.ClientID.Equals("dgrdMnt__ctl4_txtMontoCuenta") Or _
                    txtMontoCuenta.ClientID.Equals("dgrdMnt__ctl7_txtMontoCuenta")) Then
                    txtMontoCuenta.ReadOnly = True
                End If
            End If
        End Sub
        Private Sub Grabar(ByVal estado As Common.Globals.ecEstadoPeriodo)
            If (Me.txtDate.Value = String.Empty Or Me.txtFechaRegistro.Text = String.Empty) Then
                Return
            End If
            Dim litCodCuenta As Label
            Dim txtMontoCuenta As TextBox
            Dim hndMontoCuenta As HiddenField
            Dim obeproyeccion As New ProyeccionBE
            obeproyeccion.CodMetodizado = Integer.Parse(hidCodMetodizado.Value)
            obeproyeccion.CodProyeccion = Integer.Parse(hidCodProyeccion.Value)
            'obeproyeccion.CodUsuarioIns = Me.datosGlobal.sUser
            'obeproyeccion.CodUsuarioUpd = Me.datosGlobal.sUser
            obeproyeccion.CodUsuarioIns = retornaUsuarioSesion()
            obeproyeccion.CodUsuarioUpd = retornaUsuarioSesion()
            'obeproyeccion.FechaRegistro = Date.Parse(Me.txtFecPeriodo.Text)
            obeproyeccion.FechaRegistro = Date.Parse("01/" + Me.txtDate.Value)
            obeproyeccion.FechaProyeccion = New Date(Integer.Parse(Me.txtFechaRegistro.Text), 12, 31)
            obeproyeccion.Estado = estado

            'obeproyeccion.CodUsuarioVal = Me.datosGlobal.sUser
            obeproyeccion.CodUsuarioVal = retornaUsuarioSesion()

            Dim ListaCuentasProyeccion As New ProyeccionCuentaLst
            For x As Integer = 0 To Me.dgrdMnt.Items.Count - 1
                litCodCuenta = dgrdMnt.Items(x).Cells(0).FindControl("litCodCuenta")
                txtMontoCuenta = dgrdMnt.Items(x).Cells(1).FindControl("txtMontoCuenta")
                '<I-XT9104 - 09/10/2019>
                If (dgrdMnt.Items(x).Cells(1).FindControl("txtMontoCuenta").ClientID = "dgrdMnt__ctl4_txtMontoCuenta" Or _
                dgrdMnt.Items(x).Cells(1).FindControl("txtMontoCuenta").ClientID = "dgrdMnt__ctl7_txtMontoCuenta") Then
                    hndMontoCuenta = dgrdMnt.Items(x).Cells(1).FindControl("hndMontoCuenta")
                    txtMontoCuenta.Text = hndMontoCuenta.Value
                End If
                '<F-XT9104 - 09/10/2019>
                Dim obeproyeccioncuenta As New ProyeccionCuentaBE
                obeproyeccioncuenta.CodCuenta = CType(litCodCuenta.Text, Integer)
                If (Not txtMontoCuenta.Text.Trim().Equals(String.Empty)) Then
                    obeproyeccioncuenta.Importe = Decimal.Parse(txtMontoCuenta.Text)
                End If
                ListaCuentasProyeccion.Add(obeproyeccioncuenta)
            Next
            obeproyeccion.ProyeccionCuentaLst = ListaCuentasProyeccion

            Dim obrProyeccion As BusinessRules.ProyeccionBR = New BusinessRules.ProyeccionBR
            obrProyeccion.grabar(obeproyeccion)
        End Sub
        Private Function VerificarFechaProyeccion(ByVal pcodMetodizado As Integer, ByVal pfechaproy As Date) As String
            Dim obrProyeccion As BusinessRules.ProyeccionBR = New BusinessRules.ProyeccionBR
            Return obrProyeccion.VerificarFechaProyeccion(pcodMetodizado, pfechaproy).ToString()
        End Function

    End Class

End Namespace