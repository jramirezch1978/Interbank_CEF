'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity

Imports CEF.BusinessRules
Imports System.Reflection

Namespace CEF.WebUI

    Partial Class busMetodizado
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

        Private Property MntAccion() As Integer
            Get
                Return (hidMntAccion.Value)
            End Get
            Set(ByVal Value As Integer)
                hidMntAccion.Value = Value
            End Set
        End Property

        ' 21/01/2014 : XT5022 - JAVILA (CGI)
        Public ReadOnly Property CodPerfil() As Integer
            Get
                'SRT_2017_02160
                'Dim strCodUsuario As String = datosGlobal.sUser
                'Dim obeUsuario As BusinessEntity.Usuario
                'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
                'obeUsuario = obrUsuario.leer(strCodUsuario)

                ''comentado rquispe 29/04/2014 - para que tome el perfil del querystring y no del usuario.
                'Return datosGlobal.nPerfil

                'Return obeUsuario.CodPerfil

                Dim intRpta As Integer
                intRpta = Convert.ToInt32(retornaPerfilSesion())
                Return intRpta

            End Get
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        cargaScript()
            '        cargarDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargaScript()
                    cargarDatos()
                End If
            End If
        End Sub

        Private Sub cargaScript()
            imgImprimir.Attributes.Add("onClick", "javascript:window.print();")
            lnkImprimir.Attributes.Add("href", "javascript:window.print();")
            imgBusCIIU.Attributes.Add("onclick", "javascript:f_AbrirBusGen('../PagMnt/busCIIU.aspx','txtCodCIIU','txtNombreCIIU');")
            imgBusGrupoEconomico.Attributes.Add("onclick", "javascript:f_AbrirBusGen('../PagMnt/busGrupoEconomico.aspx','txtCodGrupoEconomico','txtNombreGrupoEconomico');")
            imgFecInicio.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecInicio.ClientID + "');"
            txtFecInicio.Attributes.Add("onKeyUp", "javascript:DateFormat(this,this.value,event,false,'3')")
            txtFecInicio.Attributes.Add("onblur", "javascript:DateFormat(this,this.value,event,true,'3')")
            imgFecFin.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecFin.ClientID + "');"
            txtFecFin.Attributes.Add("onKeyUp", "javascript:DateFormat(this,this.value,event,false,'3')")
            txtFecFin.Attributes.Add("onblur", "javascript:DateFormat(this,this.value,event,true,'3')")
        End Sub

        Private Sub cargarDatos()
            lblNumReg.Text = 0
            MntAccion = Int32.Parse(ecMntPage.NOACCION)
            'SRT_2017-02160
            'Dim strCodUsuario As String = DatosGlobal.sUser

            ''SRT_2017-02160
            'Dim obeUsuario As BusinessEntity.Usuario
            'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

            'Dim obePerfil As BusinessEntity.Perfil
            'Dim obrPerfil As BusinessRules.Perfil = New BusinessRules.Perfil

            'obeUsuario = obrUsuario.leer(strCodUsuario)

            'If Not obeUsuario Is Nothing Then
            '    'comentado rquispe 29/04/2014 - para que tome el perfil del querystring y no del usuario.
            '    'obePerfil = obiPerfil.leer(obeUsuario.CodPerfil)
            '    obePerfil = obrPerfil.leer(datosGlobal.nPerfil)
            '    ltlPerfilUsuarioLogin.Text = obePerfil.Nombre
            '    txtNomUsuarioLogin.Text = obeUsuario.Nombre
            'End If

            ' 03/04/2014 : XT5022 - RQUISPE (CGI) '(X)
            ' 16-01-2014 : XT5022 - JAVILA (CGI) 
            'If Not obePerfil Is Nothing Then
            '    If obePerfil.CodPerfil = 7 Or obePerfil.CodPerfil = 8 Then
            '        dropTipoDocumento.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE_BPE) '(X)
            '        dropAnalista.DataSource = obrUsuario.listarResponsableCarteraUsuarioBPE()
            '        ddlSegmento.Visible = True
            '        lblSegmento.Visible = True
            '    ElseIf obePerfil.CodPerfil = 1 Then
            '        dropTipoDocumento.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE) '(X)
            '        dropAnalista.DataSource = obrUsuario.listarResponsableCarteraUsuario()
            '        ddlSegmento.Visible = True
            '        lblSegmento.Visible = True
            '    Else
            '        dropTipoDocumento.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE) '(X)
            '        dropAnalista.DataSource = obrUsuario.listarResponsableCarteraUsuarioNoBPE()
            '        ddlSegmento.Visible = False
            '        lblSegmento.Visible = False
            '    End If
            '    'dropAnalista.DataSource = obiUsuario.listarResponsableCarteraUsuario()
            '    dropAnalista.DataTextField = "Nombre"
            '    dropAnalista.DataValueField = "CodUsuario"
            '    dropAnalista.DataBind()
            '    dropAnalista.Items.Insert(0, New ListItem("Seleccione Analista ...", ""))
            'End If


            Dim strCodUsuario As String = retornaUsuarioSesion()
            Dim intPerfil As Integer = fRetornaPerfilUsuario()
            Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

            ltlPerfilUsuarioLogin.Text = retornaNombrePerfilSesion()
            txtNomUsuarioLogin.Text = retornaNombreUsuarioSesion()

            If intPerfil = 7 Or intPerfil = 8 Then
                dropTipoDocumento.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE_BPE) '(X)
                dropAnalista.DataSource = obrUsuario.listarResponsableCarteraUsuarioBPE()
                ddlSegmento.Visible = True
                lblSegmento.Visible = True
            ElseIf intPerfil = 1 Then
                dropTipoDocumento.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE) '(X)
                dropAnalista.DataSource = obrUsuario.listarResponsableCarteraUsuario()
                ddlSegmento.Visible = True
                lblSegmento.Visible = True
            Else
                dropTipoDocumento.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE) '(X)
                dropAnalista.DataSource = obrUsuario.listarResponsableCarteraUsuarioNoBPE()
                ddlSegmento.Visible = False
                lblSegmento.Visible = False
            End If
            'dropAnalista.DataSource = obiUsuario.listarResponsableCarteraUsuario()
            dropAnalista.DataTextField = "Nombre"
            dropAnalista.DataValueField = "CodUsuario"
            dropAnalista.DataBind()
            dropAnalista.Items.Insert(0, New ListItem("Seleccione Analista ...", ""))


            ' 03/04/2014 : XT5022 - RQUISPE (CGI) '(X)
            dropTipoDocumento.DataTextField = "Descripcion" '(X)
            dropTipoDocumento.DataValueField = "CodItem" '(X)
            dropTipoDocumento.DataBind() '(X)
            dropTipoDocumento.Items(0).Text = "[todos los tipos]"

            dropEstado.DataSource = buscarGeneralTabla(ecTablaGeneral.ESTADO_METODIZADO)
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()
            dropEstado.Items.Insert(0, New ListItem("Seleccione Estado ...", ""))

            ' 16-01-2014 : XT5022 - JAVILA (CGI) 
            ddlSegmento.DataSource = buscarGeneralTabla(ecTablaGeneral.SEGMENTO)
            ddlSegmento.DataTextField = "Descripcion"
            ddlSegmento.DataValueField = "CodItem"
            ddlSegmento.DataBind()
            ddlSegmento.Items.Insert(0, New ListItem("Seleccione Segmento ...", ""))

            obrUsuario = Nothing

        End Sub

        Private Sub inicializarControles()
            txtCUCliente.Text = String.Empty
            txtRUC.Text = String.Empty
            txtRazonSocial.Text = String.Empty
            txtCodCIIU.Text = String.Empty
            txtNombreCIIU.Text = String.Empty
            txtCodGrupoEconomico.Text = String.Empty
            txtNombreGrupoEconomico.Text = String.Empty
            If dropAnalista.Items.Count > 0 Then dropAnalista.SelectedIndex = 0
            If dropEjecutivo.Items.Count > 0 Then dropEjecutivo.SelectedIndex = 0
            If dropEstado.Items.Count > 0 Then dropEstado.SelectedIndex = 0
            If dropTipoDocumento.Items.Count > 0 Then dropTipoDocumento.SelectedIndex = 0

            txtFecInicio.Text = String.Empty
            txtFecFin.Text = String.Empty

            dgrdMnt.DataSource = New DataTable
            dgrdMnt.DataKeyField = "CodMetodizado"
            dgrdMnt.DataBind()
            lblNumReg.Text = 0

            'Añadir atributo readonly a textbox
            txtNomUsuarioLogin.Attributes.Add("readonly", "readonly")
            txtCodCIIU.Attributes.Add("readonly", "readonly")
            txtNombreCIIU.Attributes.Add("readonly", "readonly")
            txtCodGrupoEconomico.Attributes.Add("readonly", "readonly")
            txtNombreGrupoEconomico.Attributes.Add("readonly", "readonly")
            txtNomUsuarioLogin.Attributes.Add("readonly", "readonly")


        End Sub

        Private Sub buscar()
            Try
                ' 16-01-2014 : XT5022 - JAVILA (CGI) 
                'Dim strCodUsuario As String = datosGlobal.sUser
                'SRT_2017-02160
                Dim strCodUsuario As String = retornaUsuarioSesion()
                Dim intPerfil As Integer = fRetornaPerfilUsuario()

                'Dim obeUsuario As BusinessEntity.Usuario
                'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
                'obeUsuario = obrUsuario.leer(strCodUsuario)

                Dim obeMetodizadoBus As BusinessEntity.MetodizadoBus
                obeMetodizadoBus = New BusinessEntity.MetodizadoBus
                Dim strCUCliente As String = txtCUCliente.Text
                Dim strRUC As String = txtRUC.Text
                If strCUCliente <> String.Empty Then strCUCliente = strCUCliente.PadLeft(10, "0")
                'If strRUC <> String.Empty Then strRUC = strRUC.PadLeft(11, "0")
                obeMetodizadoBus.CUCliente = strCUCliente
                obeMetodizadoBus.NumeroDocumento = strRUC
                obeMetodizadoBus.RazonSocial = txtRazonSocial.Text
                obeMetodizadoBus.CodCIIU = txtCodCIIU.Text
                obeMetodizadoBus.CodGrupoEconomico = txtCodGrupoEconomico.Text

                obeMetodizadoBus.TipoDocumento = Me.dropTipoDocumento.SelectedValue '03/04/2014 RQUISPE

                If dropAnalista.SelectedIndex > 0 Then obeMetodizadoBus.CodAnalista = dropAnalista.SelectedValue
                If dropEjecutivo.SelectedIndex > 0 Then obeMetodizadoBus.CodEjecutivo = dropEjecutivo.SelectedValue
                If dropEstado.SelectedIndex > 0 Then obeMetodizadoBus.Estado = dropEstado.SelectedValue
                If IsDate(txtFecInicio.Text) Then obeMetodizadoBus.FecInicio = DateTime.Parse(txtFecInicio.Text)
                If IsDate(txtFecFin.Text) Then obeMetodizadoBus.FecFin = DateTime.Parse(txtFecFin.Text)

                ' 20-01-2014 : XT5022 - JAVILA (CGI)
                If ddlSegmento.SelectedIndex > 0 Then obeMetodizadoBus.Segmento = ddlSegmento.SelectedValue

                'SRT_2017_02160
                Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                ' 16-01-2014 : XT5022 - JAVILA (CGI)
                Dim dsMetodizado As DataSet
                'comentado rquispe 29/04/2014 - para que tome el perfil del querystring y no del usuario.
                'If obeUsuario.CodPerfil = 1 Then
                'If DatosGlobal.nPerfil = 1 Then
                If intPerfil = 1 Then
                    dsMetodizado = obrMetodizado.buscar(obeMetodizadoBus)
                    'comentado rquispe 29/04/2014 - para que tome el perfil del querystring y no del usuario.
                    'ElseIf obeUsuario.CodPerfil = 7 Or obeUsuario.CodPerfil = 8 Then
                    'ElseIf datosGlobal.nPerfil = 7 Or datosGlobal.nPerfil = 8 Then
                ElseIf intPerfil = 7 Or intPerfil = 8 Then
                    dsMetodizado = obrMetodizado.buscarBPE(obeMetodizadoBus)
                Else
                    dsMetodizado = obrMetodizado.buscarNoBPE(obeMetodizadoBus)
                End If

                If dsMetodizado Is Nothing Then
                    dgrdMnt.DataSource = New DataTable
                    dgrdMnt.DataKeyField = "CodMetodizado"
                    dgrdMnt.DataBind()
                    Me.muestraAlerta(ccALERTA_ERROR_BUSCAR)
                    lblNumReg.Text = 0
                Else
                    dgrdMnt.DataSource = dsMetodizado
                    dgrdMnt.DataKeyField = "CodMetodizado"
                    dgrdMnt.DataBind()
                    Dim intNumReg As Integer = dsMetodizado.Tables(0).Rows.Count
                    lblNumReg.Text = intNumReg
                    If intNumReg <= 0 Then Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                End If
                obrMetodizado = Nothing
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"
            End If
        End Sub

        Private Sub dgrdMnt_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.ItemCommand
            If (e.CommandName = "Editar") Then
                Dim intCodMetodizado As Integer = Convert.ToInt32(dgrdMnt.DataKeys(e.Item.ItemIndex))
                Dim strUrl As String = String.Format("mntMetodizado.aspx?intCodMetodizado={0}&intMntAccion={1}", intCodMetodizado, Int32.Parse(ecMntPage.MODIFICAR))
                Response.Redirect(strUrl)
            End If
        End Sub

        Private Sub cargarEjecutivos()
            dropEjecutivo.Items.Clear()
            If (dropAnalista.SelectedValue <> String.Empty) Then
                Dim strCodUsuario As String = dropAnalista.SelectedValue
                Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
                dropEjecutivo.DataTextField = "Nombre"
                dropEjecutivo.DataValueField = "CodUsuario"
                dropEjecutivo.DataSource = obrUsuario.listarSubordinadoCarteraUsuario(strCodUsuario)
                dropEjecutivo.DataBind()
                dropEjecutivo.Items.Insert(0, New ListItem("Seleccione Ejecutivo ...", ""))
            End If
        End Sub

        Private Sub dropAnalista_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dropAnalista.SelectedIndexChanged
            cargarEjecutivos()
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            dgrdMnt.CurrentPageIndex = 0
            buscar()
        End Sub

        Private Sub imgNuevo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNuevo.Click
            ingresarMetodizado()
        End Sub

        Private Sub lnkNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNuevo.Click
            ingresarMetodizado()
        End Sub

        Private Sub btnInicializar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicializar.Click
            inicializarControles()
        End Sub

        Private Sub ingresarMetodizado()
            Dim strUrl As String = String.Format("mntMetodizado.aspx?intMntAccion={0}", Int32.Parse(ecMntPage.AGREGAR))
            Response.Redirect(strUrl)
        End Sub

        Private Sub dgrdMnt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            dgrdMnt.CurrentPageIndex = e.NewPageIndex
            dgrdMnt.EditItemIndex = -1
            buscar()
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace
