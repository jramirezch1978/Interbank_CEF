'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports System.Xml
Imports System.Reflection
Imports CEF.Common


Namespace CEF.WebUI

    Partial Class mntPeriodoCuenta
        Inherits PageBase

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

        Private Const ccID_WEBUI_MNT = "PeriodoCuenta"
        Private Const ccALERTA_ERROR_PERFIL_USUARIO = "No puede realizar esta accion con su perfil actual."
        Private lSentencia As DataTable

        Private Property MntAccion() As Integer
            Get
                Return (hidMntAccion.Value)
            End Get
            Set(ByVal Value As Integer)
                hidMntAccion.Value = Value
            End Set
        End Property

        Private Property MntAccionPadre() As Integer
            Get
                Return (hidMntAccionPadre.Value)
            End Get
            Set(ByVal Value As Integer)
                hidMntAccionPadre.Value = Value
            End Set
        End Property

        Private Property CodMetodizado() As Integer
            Get
                Return (hidCodMetodizado.Value)
            End Get
            Set(ByVal Value As Integer)
                hidCodMetodizado.Value = Value
            End Set
        End Property

        Private Property CodPeriodo() As Integer
            Get
                Return (hidCodPeriodo.Value)
            End Get
            Set(ByVal Value As Integer)
                hidCodPeriodo.Value = Value
            End Set
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        cargarScript()
            '        cargarDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargarScript()
                    cargarDatos()
                End If
            End If
        End Sub

        Private Sub cargarScript()
            imgFecPeriodo.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecPeriodo.ClientID + "');"
            txtFecPeriodo.Attributes.Add("onKeyUp", "javascript:DateFormat(this,this.value,event,false,'3')")
            txtFecPeriodo.Attributes.Add("onblur", "javascript:DateFormat(this,this.value,event,true,'3')")
            imgCerrar.Attributes("onclick") = "javascript:{window.returnValue=f_MntAccionPadre(); window.close();}"
            btnEliminar.Attributes.Add("onclick", "javascript:{return(confirm('" + ccALERTA_ELIMINAR + "'));}")

            'Añadir atributo readonly a textbox
            txtRazonSocial.Attributes.Add("readonly", "readonly")
            txtCodUsuario.Attributes.Add("readonly", "readonly")
            txtNombreUsuario.Attributes.Add("readonly", "readonly")
        End Sub

        Private Sub cargarDatos()
            Me.pMostrarEliminarPeriodo()

            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))

            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            obeMetodizado = obrMetodizado.leer(intCodMetodizado)
            If Not obeMetodizado Is Nothing Then
                txtRazonSocial.Text = obeMetodizado.RazonSocial
            End If
            obrMetodizado = Nothing

            Dim obrTipoEeff As BusinessRules.TipoEEFF = New BusinessRules.TipoEEFF

            ' 20/01/2014 : JAVILA (CGI)
            Dim obeUsuario As BusinessEntity.Usuario
            '''Dim obiUsuario As BusinessInterface.IUsuario
            '''Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
            '''obiUsuario = CType(obrUsuario, BusinessInterface.IUsuario)

            'Dim strCodUsuario As String = DatosGlobal.sUser

            'obeUsuario = Util.obtenerUsuario(strCodUsuario)

            'If Not obeUsuario Is Nothing Then

            '    Dim dsTipoEEFF As DataSet
            '    If obeUsuario.CodPerfil = 7 Or obeUsuario.CodPerfil = 8 Then
            '        dsTipoEEFF = obrTipoEeff.listar(3, 1)
            '    Else 'If obeUsuario.CodPerfil = 1 Then

            '        '13/03/2014 RQUISPE
            '        If Not obeMetodizado Is Nothing Then
            '            If obeMetodizado.FlgBPE = ecTipoBanca.BancaPequenaEmpresa Then
            '                dsTipoEEFF = obrTipoEeff.listar(3, 1)
            '            Else
            '                dsTipoEEFF = obrTipoEeff.listar(2, 1)
            '            End If
            '        Else
            '            dsTipoEEFF = obrTipoEeff.listar(2, 1) 'solo esta linea estaba antes de la modificacion  '13/03/2014 RQUISPE
            '        End If
            '        'FIN AGREGADO

            '    End If


            Dim strCodUsuario As String = retornaUsuarioSesion()
            Dim intPerfil As Integer = fRetornaPerfilUsuario()

            Dim dsTipoEEFF As DataSet
            If intPerfil = 7 Or intPerfil = 8 Then
                dsTipoEEFF = obrTipoEeff.listar(3, 1)
            Else 'If obeUsuario.CodPerfil = 1 Then

                '13/03/2014 RQUISPE
                If Not obeMetodizado Is Nothing Then
                    If obeMetodizado.FlgBPE = ecTipoBanca.BancaPequenaEmpresa Then
                        dsTipoEEFF = obrTipoEeff.listar(3, 1)
                    Else
                        dsTipoEEFF = obrTipoEeff.listar(2, 1)
                    End If
                Else
                    dsTipoEEFF = obrTipoEeff.listar(2, 1) 'solo esta linea estaba antes de la modificacion  '13/03/2014 RQUISPE
                End If
                'FIN AGREGADO

            End If

            dropTipoEeff.DataSource = dsTipoEEFF
            dropTipoEeff.DataTextField = "Descripcion"
            dropTipoEeff.DataValueField = "CodTipoEeff"
            dropTipoEeff.DataBind()
            obrTipoEeff = Nothing





            Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor

            Dim dsAuditor As DataSet = obrAuditor.listar(2, 1)
            dropAuditor.DataSource = dsAuditor
            dropAuditor.DataTextField = "RazonSocial"
            dropAuditor.DataValueField = "CodAuditor"
            dropAuditor.DataBind()
            obrAuditor = Nothing

            MntAccion = Int32.Parse(Request.Params("intMntAccion"))
            MntAccionPadre = Int32.Parse(ecMntPage.NOACCION)
            CodMetodizado = Int32.Parse(Request.Params("intCodMetodizado"))

            If MntAccion = Int32.Parse(ecMntPage.AGREGAR) Then
                inicializarControles()
            ElseIf MntAccion = Int32.Parse(ecMntPage.MODIFICAR) Then
                CodPeriodo = Int32.Parse(Request.Params("intCodPeriodo"))
                editarPeriodoCuenta()
            End If
        End Sub

        Private Sub pMostrarEliminarPeriodo()
            Try
                'Sólo mostramos el boton 'Eliminar' si el usuario es un administrador...
                If Me.fRetornaPerfilUsuario() = Int32.Parse(ecPerfil.ADMINISTRADOR) Then
                    btnEliminar.Visible = True
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " del usuario")
            End Try
        End Sub

        Private Sub editarPeriodoCuenta()
            Dim intCodMetodizado As Integer = CodMetodizado
            Dim intCodPeriodo As Integer = CodPeriodo

            Dim obePeriodo As BusinessEntity.Periodo
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            obePeriodo = obrMetodizado.leerPeriodo(intCodMetodizado, intCodPeriodo)

            If Not obePeriodo Is Nothing Then
                txtFecPeriodo.Text = obePeriodo.FecPeriodo
                dropTipoEeff.SelectedValue = obePeriodo.CodTipoEeff
                If obePeriodo.CodAuditor > 0 Then dropAuditor.SelectedValue = obePeriodo.CodAuditor
                txtComentario.Text = obePeriodo.Comentario
                txtCodUsuario.Text = obePeriodo.CodUsuario
                txtNombreUsuario.Text = obePeriodo.NombreUsuario
                activaIngresoAuditor()
            End If
        End Sub

        Private Sub agregarPeriodo()
            Dim intCodMetodizado As Integer = CodMetodizado
            Try
                If Page.IsValid Then
                    If fblnExisteTipoCambio(txtFecPeriodo.Text) Then
                        Dim obePeriodo As BusinessEntity.Periodo
                        Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                        obePeriodo = obrMetodizado.listarPeriodo(intCodMetodizado).buscarPorFecha(intCodMetodizado, txtFecPeriodo.Text, dropTipoEeff.SelectedValue)

                        Dim bolPeriodoRepetido As Boolean = (Not obePeriodo Is Nothing)

                        If Not bolPeriodoRepetido Then
                            obePeriodo = New BusinessEntity.Periodo
                            obePeriodo.CodMetodizado = intCodMetodizado
                            obePeriodo.FecPeriodo = txtFecPeriodo.Text
                            obePeriodo.CodTipoEeff = dropTipoEeff.SelectedValue
                            obePeriodo.CodAuditor = dropAuditor.SelectedValue
                            obePeriodo.Comentario = txtComentario.Text
                            obePeriodo.Estado = 1

                            'srt_2017-02160
                            'Dim strCodUsuario As String = DatosGlobal.sUser
                            'Dim obeUsuario As BusinessEntity.Usuario
                            'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario


                            'obeUsuario = obrUsuario.leer(strCodUsuario)

                            'obePeriodo.CodUsuario = obeUsuario.CodUsuario
                            'obePeriodo.NombreUsuario = obeUsuario.Nombre

                            Dim strCodUsuario As String = retornaUsuarioSesion()
                            Dim strNomUsuario As String = retornaNombreUsuarioSesion()
                            obePeriodo.CodUsuario = strCodUsuario
                            obePeriodo.NombreUsuario = strNomUsuario

                            Dim bolRC As Boolean = obrMetodizado.agregarPeriodo(obePeriodo)
                            If bolRC Then
                                CodPeriodo = obePeriodo.CodPeriodo
                                txtCodUsuario.Text = obePeriodo.CodUsuario
                                txtNombreUsuario.Text = obePeriodo.NombreUsuario
                                MntAccion = Int32.Parse(ecMntPage.MODIFICAR)
                                MntAccionPadre = Int32.Parse(ecMntPage.REFRESCAR)
                                Me.muestraAlerta(ccALERTA_EXITO_AGREGAR & " de " & ccID_WEBUI_MNT)
                            Else
                                Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
                            End If
                        Else
                            Me.muestraAlerta(ccALERTA_ERROR_PERIODO_DUPLICADO)
                        End If
                    Else
                        Me.muestraAlerta(ccALERTA_ERROR_AGREGAR_PERIODO_TIPOCAMBIO)
                    End If
                End If
            Catch ex As Exception
                Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Sub modificarPeriodo()
            Dim intCodMetodizado As Integer = CodMetodizado
            Dim intCodPeriodo As Integer = CodPeriodo
            Try
                If Page.IsValid Then
                    Dim obePeriodo As BusinessEntity.Periodo
                    Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                    obePeriodo = obrMetodizado.listarPeriodo(intCodMetodizado).buscarPorFecha(intCodMetodizado, txtFecPeriodo.Text, dropTipoEeff.SelectedValue)

                    Dim bolPeriodoRepetido As Boolean = (Not obePeriodo Is Nothing)
                    If bolPeriodoRepetido Then bolPeriodoRepetido = (obePeriodo.CodPeriodo <> intCodPeriodo)

                    If Not bolPeriodoRepetido Then
                        obePeriodo = New BusinessEntity.Periodo
                        obePeriodo.CodMetodizado = intCodMetodizado
                        obePeriodo.CodPeriodo = intCodPeriodo
                        obePeriodo.FecPeriodo = txtFecPeriodo.Text
                        obePeriodo.CodTipoEeff = dropTipoEeff.SelectedValue
                        obePeriodo.CodAuditor = dropAuditor.SelectedValue
                        obePeriodo.Comentario = txtComentario.Text
                        obePeriodo.Estado = 1

                        Dim bolRC As Boolean = obrMetodizado.modificarPeriodo(obePeriodo)
                        If bolRC Then
                            txtCodUsuario.Text = obePeriodo.CodUsuario
                            txtNombreUsuario.Text = obePeriodo.NombreUsuario
                            MntAccionPadre = Int32.Parse(ecMntPage.REFRESCAR)
                            Me.muestraAlerta(ccALERTA_EXITO_MODIFICAR & " de " & ccID_WEBUI_MNT)
                        Else
                            Me.muestraAlerta(ccALERTA_ERROR_MODIFICAR & " de " & ccID_WEBUI_MNT)
                        End If
                    Else
                        Me.muestraAlerta(ccALERTA_ERROR_PERIODO_DUPLICADO)
                    End If
                End If
            Catch ex As Exception
                Me.muestraAlerta(ccALERTA_ERROR_MODIFICAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Function eliminarPeriodo()
            Dim intCodMetodizado As Integer = CodMetodizado
            Dim intCodPeriodo As Integer = CodPeriodo
            Try
                If Page.IsValid Then
                    Dim obePeriodo As BusinessEntity.Periodo
                    Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                    obePeriodo = New BusinessEntity.Periodo
                    obePeriodo.CodMetodizado = intCodMetodizado
                    obePeriodo.CodPeriodo = intCodPeriodo

                    Dim bolRC As Boolean
                    bolRC = obrMetodizado.eliminarPeriodo(obePeriodo)
                    If bolRC Then
                        txtCodUsuario.Text = obePeriodo.CodUsuario
                        txtNombreUsuario.Text = obePeriodo.NombreUsuario
                        MntAccionPadre = Int32.Parse(ecMntPage.REFRESCAR)
                        Me.muestraAlerta(ccALERTA_EXITO_ELIMINAR & " de " & ccID_WEBUI_MNT)
                    Else
                        Me.muestraAlerta(ccALERTA_ERROR_ELIMINAR & " de " & ccID_WEBUI_MNT)
                    End If
                End If
            Catch ex As Exception
                Me.muestraAlerta(ccALERTA_ERROR_ELIMINAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Function

        Private Function existePeriodo(ByVal pobePeriodo As BusinessEntity.Periodo) As Boolean
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            Dim obePeriodoLst As BusinessEntity.PeriodoLst
            obePeriodoLst = obrMetodizado.listarPeriodo(pobePeriodo.CodMetodizado)
            For Each obePeriodo As BusinessEntity.Periodo In obePeriodoLst
                If obePeriodo.FecPeriodo = pobePeriodo.FecPeriodo And obePeriodo.CodTipoEeff = pobePeriodo.CodTipoEeff Then
                    Return (False)
                End If
            Next
            Return (True)
        End Function

        ''' <summary>
        ''' fblnExisteTipoCambio: Verifica existencia de tipo de cambio para ese periodo
        ''' </summary>
        ''' <param name="pstrFecPeriodo"></param>
        ''' <returns>Boolean: True si existe Tipo de Cambio para ese periodo, de lo contrario False</returns>
        ''' <remarks>
        ''' Creación: S32514 24/08/2016 SRT_2016-03093
        ''' </remarks>

        Private Function fblnExisteTipoCambio(ByVal pstrFecPeriodo As String) As Boolean
            Dim intAnio As Integer = CInt(pstrFecPeriodo.Substring(6, 4))
            Dim intMes As Integer = CInt(pstrFecPeriodo.Substring(3, 2))
            Dim intMoneda As Integer = Int32.Parse(Request.Params("intCodMoneda"))

            Dim obrTipoCambio As BusinessRules.TipoCambio
            Dim obeTipoCambio As BusinessEntity.TipoCambio
            Try
                obrTipoCambio = New BusinessRules.TipoCambio
                obeTipoCambio = obrTipoCambio.leer(intAnio, intMes, intMoneda)
                If obeTipoCambio Is Nothing Then
                    Return (False)
                Else
                    Return (True)
                End If
            Catch ex As Exception
                'Agregar log
                Throw ex
            Finally
                obrTipoCambio = Nothing
                obeTipoCambio = Nothing
            End Try

        End Function

        Protected Overrides Sub limpiarControles(ByVal objContenedor As Control)
            txtCodUsuario.Text = String.Empty
            txtNombreUsuario.Text = String.Empty
            txtFecPeriodo.Text = String.Empty
            txtComentario.Text = String.Empty
            If dropTipoEeff.Items.Count > 0 Then dropTipoEeff.SelectedIndex = 0
            If dropAuditor.Items.Count > 0 Then dropAuditor.SelectedIndex = 0
        End Sub

        Private Sub inicializarControles()
            activaIngresoAuditor()
            CodPeriodo = 0
            MntAccion = Int32.Parse(ecMntPage.AGREGAR)
        End Sub

        Private Function requiereIngresarAuditor() As Boolean
            Try
                Dim obeParametro As BusinessEntity.Parametro
                Dim obrParametro As BusinessRules.Parametro = New BusinessRules.Parametro
                obeParametro = obrParametro.leer("COD_TIPO_EEFF_AUDI")
                Return (dropTipoEeff.SelectedValue = Int32.Parse(obeParametro.Valor1))
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Private Sub activaIngresoAuditor()
            spnAuditor.Visible = requiereIngresarAuditor()
        End Sub

        Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
            limpiarControles(Me)
            inicializarControles()
        End Sub

        Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            If MntAccion = Int32.Parse(ecMntPage.AGREGAR) Then
                agregarPeriodo()
            ElseIf MntAccion = Int32.Parse(ecMntPage.MODIFICAR) Then
                modificarPeriodo()
            End If
        End Sub

        Private Sub dropTipoEeff_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dropTipoEeff.SelectedIndexChanged
            activaIngresoAuditor()
        End Sub

        Private Sub cvFecPeriodoLimite_ServerValidate(ByVal source As System.Object, ByVal args As System.Web.UI.WebControls.ServerValidateEventArgs) Handles cvFecPeriodoLimite.ServerValidate
            If DateTime.Parse(args.Value) <= DateTime.Today Then
                args.IsValid = True
            Else
                args.IsValid = False
            End If
        End Sub

        Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
            If MntAccion = Int32.Parse(ecMntPage.MODIFICAR) Then
                Try
                    If Me.fRetornaPerfilUsuario() = Int32.Parse(ecPerfil.ADMINISTRADOR) Then
                        eliminarPeriodo()
                    Else
                        Me.muestraAlerta(ccALERTA_ERROR_PERFIL_USUARIO & "\n Solo los administradores pueden hacerlo.")
                    End If
                Catch ex As Exception
                    Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                    Me.muestraAlerta(ccALERTA_ERROR_ELIMINAR)
                    Throw ex
                End Try
            End If
        End Sub
    End Class

End Namespace