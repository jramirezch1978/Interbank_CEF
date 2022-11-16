'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por: Miguel Delgado
'Fecha Mod.: 16/01/2008
'*************************************************************

Imports System.Text
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports System.Xml
Imports System.Xml.Serialization
Imports CEF.Common
Imports System.Reflection
Imports Newtonsoft.Json


Namespace CEF.WebUI

    Partial Class mntMetodizado
        Inherits PageBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        Protected WithEvents hidAccion As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents ibtnGrabarRec As System.Web.UI.WebControls.ImageButton
        Protected WithEvents hidCodCuentaReconciliado As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidImporteReconciliado As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents CheckBoxList2 As System.Web.UI.WebControls.CheckBoxList
        Protected WithEvents hidFilaCuentaLibre As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidRegistroSectoristaActual As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents txtEjecutivo As System.Web.UI.WebControls.TextBox
        Protected WithEvents txtAnalista As System.Web.UI.WebControls.TextBox
        Protected WithEvents lbtnGrabarRec As System.Web.UI.WebControls.LinkButton
        Protected WithEvents PageX As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents PageY As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents upnlCUCliente As Anthem.Panel
        Protected WithEvents upnlRUC As Anthem.Panel
        Protected WithEvents hidEsBPE As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidCodCIIU As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidDescCIIU As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidCodGrpEco As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidDescGrpEco As System.Web.UI.HtmlControls.HtmlInputHidden

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

        Private Const ccKEY_PERIODOS_FILTRADO As String = "Cache:PeriodosFiltrado"
        Private Const ccANCHO_DGRID_PERIODO As Short = 260
        Private Const ccANCHO_COLUMNA_PERIODO As Short = 100
        Private Const ccID_WEBUI_MNT = "Metodizado"

        Private Property MntAccion() As Integer
            Get
                Return (hidMntAccion.Value)
            End Get
            Set(ByVal Value As Integer)
                hidMntAccion.Value = Value
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

        Public Property TabRefrescar() As Integer
            Get
                Return hidTabRefrescar.Value
            End Get
            Set(ByVal Value As Integer)
                hidTabRefrescar.Value = Value
            End Set
        End Property

        Public Property TabActivo() As Integer
            Get
                Return hidTabActivo.Value
            End Get
            Set(ByVal Value As Integer)
                hidTabActivo.Value = Value
            End Set
        End Property

        Public Property PeriodoFiltrado() As String
            Get
                Return hidPeriodoFiltrado.Value
            End Get
            Set(ByVal Value As String)
                hidPeriodoFiltrado.Value = Value
            End Set
        End Property

        Protected Property VSPeriodosFiltrados() As BusinessEntity.PeriodoLst
            Get
                If ViewState.Item(ccKEY_PERIODOS_FILTRADO) Is Nothing Then
                    Return (New BusinessEntity.PeriodoLst)
                Else
                    Return (CType(ViewState.Item(ccKEY_PERIODOS_FILTRADO), BusinessEntity.PeriodoLst))
                End If
            End Get
            Set(ByVal Value As BusinessEntity.PeriodoLst)
                If Value Is Nothing Then
                    If Not ViewState.Item(ccKEY_PERIODOS_FILTRADO) Is Nothing Then
                        ViewState.Remove(ccKEY_PERIODOS_FILTRADO)
                    End If
                Else
                    If ViewState.Item(ccKEY_PERIODOS_FILTRADO) Is Nothing Then
                        ViewState.Add(ccKEY_PERIODOS_FILTRADO, Value)
                    Else
                        ViewState.Item(ccKEY_PERIODOS_FILTRADO) = Value
                    End If
                End If
            End Set
        End Property

        ' 17/01/2014 : XT5022 - JAVILA (CGI)'
        ' CODIGO DE PERFIL DEL USUARIO LOGUEADO
        Public ReadOnly Property CodPerfil() As Integer
            Get
                'Dim strCodUsuario As String = DatosGlobal.sUser
                'Dim obeUsuario As BusinessEntity.Usuario
                'obeUsuario = Util.obtenerUsuario(strCodUsuario)

                'Return obeUsuario.CodPerfil
                'comentado rquispe 29/04/2014 - para que tome el perfil del querystrign y no del usuario.
                ' Return Util.obtenerUsuario(datosGlobal.sUser).CodPerfil
                'Return datosGlobal.nPerfil
                'SRT_2017-02160
                Return fRetornaPerfilUsuario()
            End Get
        End Property


        Private Class PlantillaDgcImporte
            Implements ITemplate

            Private lTemplateType As ListItemType
            Private lDataFieldNameImporte As String
            Private lDataFieldNameFuncion As String
            Private lTextValue As String
            Private lWebControl As Control
            Private lCssClass As String
            Private lIDControlImporte As String
            Private lIDControlFuncion As String
            Private lFormato As String
            Private lMaxLongitud As Integer

            Sub New()
                MyBase.New()
            End Sub

            Sub New(ByVal pTemplateType As ListItemType)
                Me.lTemplateType = pTemplateType
            End Sub

            Public Property TemplateType() As String
                Get
                    Return Me.lTemplateType
                End Get
                Set(ByVal Value As String)
                    Me.lTemplateType = Value
                End Set
            End Property

            Public Property DataFieldNameImporte() As String
                Get
                    Return Me.lDataFieldNameImporte
                End Get
                Set(ByVal Value As String)
                    Me.lDataFieldNameImporte = Value
                End Set
            End Property

            Public Property DataFieldNameFuncion() As String
                Get
                    Return Me.lDataFieldNameFuncion
                End Get
                Set(ByVal Value As String)
                    Me.lDataFieldNameFuncion = Value
                End Set
            End Property

            Public Property TextValue() As String
                Get
                    Return Me.lTextValue
                End Get
                Set(ByVal Value As String)
                    Me.lTextValue = Value
                End Set
            End Property

            Public Property WebControl() As Control
                Get
                    Return Me.lWebControl
                End Get
                Set(ByVal Value As Control)
                    Me.lWebControl = Value
                End Set
            End Property

            Public Property CssClass() As String
                Get
                    Return Me.lCssClass
                End Get
                Set(ByVal Value As String)
                    Me.lCssClass = Value
                End Set
            End Property

            Public Property IDControlImporte() As String
                Get
                    Return Me.lIDControlImporte
                End Get
                Set(ByVal Value As String)
                    Me.lIDControlImporte = Value
                End Set
            End Property

            Public Property IDControlFuncion() As String
                Get
                    Return Me.lIDControlFuncion
                End Get
                Set(ByVal Value As String)
                    Me.lIDControlFuncion = Value
                End Set
            End Property

            Public Property Formato() As String
                Get
                    Return Me.lFormato
                End Get
                Set(ByVal Value As String)
                    Me.lFormato = Value
                End Set
            End Property

            Public Property MaxLongitud() As Integer
                Get
                    Return Me.lMaxLongitud
                End Get
                Set(ByVal Value As Integer)
                    Me.lMaxLongitud = Value
                End Set
            End Property

            Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements ITemplate.InstantiateIn
                container.EnableViewState = False
                Select Case Me.lTemplateType
                    Case ListItemType.Header
                        container.Controls.Add(Me.lWebControl)
                    Case ListItemType.Item
                        Dim lc As New Literal
                        AddHandler lc.DataBinding, AddressOf TemplateControlImporte_DataBinding
                        container.Controls.Add(lc)
                    Case ListItemType.EditItem
                        Dim tb As New TextBox
                        If Me.lIDControlImporte <> String.Empty Then tb.ID = Me.lIDControlImporte
                        tb.Width = New Unit(100, UnitType.Percentage)
                        tb.MaxLength = Me.lMaxLongitud
                        tb.Height = New Unit(13, UnitType.Pixel)
                        tb.BorderWidth = New Unit(0, UnitType.Pixel)
                        If Me.lCssClass <> String.Empty Then tb.CssClass = Me.lCssClass
                        AddHandler tb.DataBinding, AddressOf TemplateControlImporte_DataBinding
                        container.Controls.Add(tb)
                        Dim hid As New HtmlInputHidden
                        If Me.lIDControlFuncion <> String.Empty Then hid.ID = Me.lIDControlFuncion
                        AddHandler hid.DataBinding, AddressOf TemplateControlFuncion_DataBinding
                        container.Controls.Add(hid)
                    Case ListItemType.Footer
                        Dim lc As New Literal
                        lc.Text = Me.lTextValue
                        container.Controls.Add(lc)
                End Select
            End Sub

            Private Sub TemplateControlImporte_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
                If Me.lTemplateType = ListItemType.EditItem Then
                    Dim tb As TextBox
                    tb = CType(sender, TextBox)
                    Dim container As DataGridItem
                    container = CType(tb.NamingContainer, DataGridItem)
                    Dim bytEscalaImporte As Byte = Byte.Parse(DataBinder.Eval(container.DataItem, "EscalaImporte"))
                    If Not IsDBNull(DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)) Then
                        Me.lFormato = "{0:F" + bytEscalaImporte.ToString() + "}"
                        tb.Text = DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte, Me.lFormato)
                    End If
                Else
                    Dim ltl As Literal
                    ltl = CType(sender, Literal)
                    Dim container As DataGridItem
                    container = CType(ltl.NamingContainer, DataGridItem)
                    If Not IsDBNull(DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)) Then
                        If Me.lFormato <> String.Empty Then
                            ltl.Text = DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte, Me.lFormato)
                        Else
                            ltl.Text = DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)
                        End If
                    End If
                End If
            End Sub

            Private Sub TemplateControlFuncion_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
                If Me.lTemplateType = ListItemType.EditItem Then
                    Dim hid As HtmlInputHidden
                    hid = CType(sender, HtmlInputHidden)
                    Dim container As DataGridItem
                    container = CType(hid.NamingContainer, DataGridItem)
                    If Not IsDBNull(DataBinder.Eval(container.DataItem, Me.lDataFieldNameFuncion)) Then
                        hid.Value = DataBinder.Eval(container.DataItem, Me.lDataFieldNameFuncion)
                    End If
                End If
            End Sub
        End Class

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        cargaScript()
            '        cargarDatos()
            '    Else
            '        inicializarControlesPorScript()
            '        If MntAccion = Int32.Parse(ecMntPage.REFRESCAR) Then
            '            If dropTipoDocumento.SelectedValue = 0 Then
            '                RequiredFieldValidator1.Enabled = False
            '            Else
            '                RequiredFieldValidator1.Enabled = True
            '            End If
            '            refrescarTabControl(TabRefrescar)
            '        End If
            '    End If
            '    cargarAttributes()
            'End If

            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargaScript()
                    cargarDatos()

                    'I-XT9104 - 18/02/2020
                    cargaCuentaLibre()
                    'F-XT9104 - 18/02/2020
                Else
                    inicializarControlesPorScript()
                    If MntAccion = Int32.Parse(ecMntPage.REFRESCAR) Then
                        If dropTipoDocumento.SelectedValue = 0 Then
                            RequiredFieldValidator1.Enabled = False
                        Else
                            RequiredFieldValidator1.Enabled = True
                        End If
                        refrescarTabControl(TabRefrescar)
                    End If
                End If
                cargarAttributes()
            End If

            'AjaxPro.Utility.RegisterTypeForAjax(GetType(mntMetodizado))
            AjaxPro.Utility.RegisterTypeForAjax(GetType(CEF.WebUI.mntMetodizado))

        End Sub

        <AjaxPro.AjaxMethod()> _
        Public Shared Function validarGeneracionResEjec(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As String) As Int16
            Dim obrMetodizado As New CEF.BusinessRules.Metodizado
            Return obrMetodizado.validarGeneracionResEjec(pstrPeriodos, Convert.ToInt16(pintCodMetodizado))
        End Function

        Private Sub cargaScript()
            txtCUCliente.Attributes.Add("onkeypress", "javascript:if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;")
            txtRUC.Attributes.Add("onkeypress", "javascript:if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;")
            txtCodSBS.Attributes.Add("onkeypress", "javascript:if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;")
            imgBusCIIU.Attributes.Add("onclick", "javascript:f_AbrirBusGen('../PagMnt/busCIIU.aspx','txtCodCIIU','txtNombreCIIU');")
            imgBusGrupoEconomico.Attributes.Add("onclick", "javascript:f_AbrirBusGen('../PagMnt/busGrupoEconomico.aspx','txtCodGrupoEconomico','txtNombreGrupoEconomico');")
            dropTipoDocumento.Attributes.Add("onchange", "javascript:f_VerificarTipoDocumento(this);")
            ' Me.upnlCUCliente.PostCallBackFunction = "pMostrarCliCUNoEncontrado"
            ' Me.upnlRUC.PostCallBackFunction = "pMostrarCliRUCNoEncontrado"
            'Inicio B26982 - AAE
            txtCodCIIU.Attributes.Add("readonly", "readonly")
            txtNombreCIIU.Attributes.Add("readonly", "readonly")
            txtCodGrupoEconomico.Attributes.Add("readonly", "readonly")
            txtNombreGrupoEconomico.Attributes.Add("readonly", "readonly")
            'Fin B26982

            'Añadir atributo readonly a textbox
            txtCodMetodizado.Attributes.Add("readonly", "readonly")
            txtFecReg.Attributes.Add("readonly", "readonly")
            txtDesEstado.Attributes.Add("readonly", "readonly")
            txtCodSBS.Attributes.Add("readonly", "readonly")
            txtCodUsuario.Attributes.Add("readonly", "readonly")
            txtNombreUsuario.Attributes.Add("readonly", "readonly")
            txtCodAnalista.Attributes.Add("readonly", "readonly")
            txtNombreAnalista.Attributes.Add("readonly", "readonly")
            txtCodEjecutivo.Attributes.Add("readonly", "readonly")
            txtNombreEjecutivo.Attributes.Add("readonly", "readonly")
            txtMensajeImpresion.Attributes.Add("readonly", "readonly")
            txtFuncionFx.Attributes.Add("readonly", "readonly")

            'ADD XT8442 ADR 19-10-2018 INICIO
            trTipoDocumentoComp.Attributes.Add("style", "display:none;")
            'imgRatios.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntRatios.aspx?intCodMetodizado={0}&intCodPeriodo={1}&strNombreEmpresa={2}&strFechaPeriodo={3}&strDesEstadoEEFF={4}&intMntAccion={5}',{6},{7},{8});", Me.CodMetodizado.ToString(), hidPeriodoFiltrado.Value, "Prueba", "1/1/2019", "Prueba", Int32.Parse(ecMntPage.MODIFICAR), 800, 550, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
            'ADD XT8442 ADR 19-10-2018 FIN            
            chkcovenants.Attributes.Add("onclick", "javascript:f_ActivarFrecuencia(this);") 'ADD XT8633

        End Sub

        Private Sub cargarAttributes()
            'Dim strCodUsuario As String = DatosGlobal.sUser
            'SRT_2017-02160
            Dim strCodUsuario As String = retornaUsuarioSesion()
            Dim intPerfil As Integer = fRetornaPerfilUsuario()
            'Dim obeUsuario As BusinessEntity.Usuario
            'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
            'obeUsuario = obrUsuario.leer(strCodUsuario)

            'comentado rquispe 29/04/2014 - para que tome el perfil del querystrign y no del usuario.
            'If obeUsuario.CodPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
            'If datosGlobal.nPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
            If intPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
                btnNuevo.Attributes.Add("style", "display:none;")
                btnGrabar.Attributes.Add("style", "display:none;")
                imgNuevoPeriodo.Attributes.Add("style", "display:none;")
                lnkNuevoPeriodo.Attributes.Add("style", "display:none;")
                imgGrabarRecOpe1.Attributes.Add("style", "display:none;")
                lnkGrabarRecOpe1.Attributes.Add("style", "display:none;")
                imgGrabarRecOpe2.Attributes.Add("style", "display:none;")
                lnkGrabarRecOpe2.Attributes.Add("style", "display:none;")
            Else
                btnNuevo.Attributes.Add("style", "display:'';")
                btnGrabar.Attributes.Add("style", "display:'';")
                imgNuevoPeriodo.Attributes.Add("style", "display:'';")
                lnkNuevoPeriodo.Attributes.Add("style", "display:'';")
                imgGrabarRecOpe1.Attributes.Add("style", "display:'';")
                lnkGrabarRecOpe1.Attributes.Add("style", "display:'';")
                imgGrabarRecOpe2.Attributes.Add("style", "display:'';")
                lnkGrabarRecOpe2.Attributes.Add("style", "display:'';")
            End If

            If dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.EMPRESA_RELACIONADA Then
                txtCUCliente.Text = String.Empty
                txtCUCliente.Attributes.Add("class", "NoActivo")
                txtCUCliente.Attributes.Add("readOnly", "true")
                txtRUC.Text = String.Empty
                txtRUC.Attributes.Add("class", "NoActivo")
                txtRUC.Attributes.Add("readOnly", "true")

                vreqFecPeriodo.Enabled = False
                RequiredFieldValidator1.Enabled = False
            Else
                vreqFecPeriodo.Enabled = True
                RequiredFieldValidator1.Enabled = True
            End If

            If dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.DNI Then
                dropTipoDocumentoComp.Attributes.Add("readonly", "readonly")
                txtRUCComp.Attributes.Add("readonly", "readonly")
            End If
            'Add xt8633
            If chkcovenants.Checked = False Then
                ddlMedicionCov.Attributes.Add("style", "display:none;")
                lblfrecuencia.Attributes.Add("style", "display:none;")
            Else
                ddlMedicionCov.Attributes.Add("style", "display:block;")
                lblfrecuencia.Attributes.Add("style", "display:block;")
            End If
        End Sub

        Private Sub cargarDatos(Optional ByVal pbolActivarSeleccionPeriodo As Boolean = True)
            ' 16-01-2014 : XT5022 - JAVILA (CGI) 
            ''Dim strCodUsuario As String = DatosGlobal.sUser
            ''Dim obeUsuario As BusinessEntity.Usuario
            ''Dim obiUsuario As BusinessInterface.IUsuario
            ''Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
            ''obiUsuario = CType(obrUsuario, BusinessInterface.IUsuario)
            ''obeUsuario = obiUsuario.leer(strCodUsuario)



            ' 16-01-2014 : XT5022 - JAVILA (CGI)
            Dim dsMetodizado As DataSet
            If CodPerfil = 7 Or CodPerfil = 8 Then
                dropTipoDocumento.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE_BPE)
                dropTipoDocumentoComp.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE_RM)
            Else
                dropTipoDocumento.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE)
                dropTipoDocumentoComp.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_DOC_CLIENTE_RM)
            End If
            dropTipoDocumento.DataTextField = "Descripcion"
            dropTipoDocumento.DataValueField = "CodItem"
            dropTipoDocumento.DataBind()

            dropTipoDocumentoComp.DataTextField = "Descripcion"
            dropTipoDocumentoComp.DataValueField = "CodItem"
            dropTipoDocumentoComp.DataBind()

            ' 16-01-2014 : XT5022 - JAVILA (CGI) 
            ddlSegmento.DataSource = buscarGeneralTabla(ecTablaGeneral.SEGMENTO)
            ddlSegmento.DataTextField = "Descripcion"
            ddlSegmento.DataValueField = "CodItem"
            ddlSegmento.DataBind()
            ddlSegmento.Items.Insert(0, New ListItem("Seleccione Segmento ...", 0))

            ' 30-01-2014 : XT5022 - JAVILA (CGI) 
            ddlTipoBanca.DataSource = buscarGeneralTabla(ecTablaGeneral.TIPO_BANCA)
            ddlTipoBanca.DataTextField = "Descripcion"
            ddlTipoBanca.DataValueField = "CodItem"
            ddlTipoBanca.DataBind()
            ddlTipoBanca.Items.Insert(0, New ListItem("Seleccione Tipo Banca ...", 0))

            'I-XT9104 - 10/03/2020
            'dropMoneda.DataSource = buscarGeneralTabla(ecTablaGeneral.MONEDA)
            'dropMoneda.DataTextField = "Descripcion"
            'dropMoneda.DataValueField = "CodItem"
            'dropMoneda.DataBind()

            'Adicionado 16/01/2008: Impresión en diferentes monedas
            'dropMonedaImpresion.DataSource = buscarGeneralTabla(ecTablaGeneral.MONEDA)
            'dropMonedaImpresion.DataTextField = "Descripcion"
            'dropMonedaImpresion.DataValueField = "CodItem"
            'dropMonedaImpresion.DataBind()
            'Fin Adicionado

            cargaMonedas()
            cargaMonedasImpresion()
            'F-XT9104 - 10/03/2020

            dropUnidad.DataSource = buscarGeneralTabla(ecTablaGeneral.UNIDAD_IMPORTE)
            dropUnidad.DataTextField = "Descripcion"
            dropUnidad.DataValueField = "CodItem"
            dropUnidad.DataBind()

            'XT8633 Ini
            ddlMedicionCov.DataSource = buscarGeneralFrecuencia(ecTablaGeneral.FRECUENCIA_COVENANT)
            ddlMedicionCov.DataTextField = "Descripcion"
            ddlMedicionCov.DataValueField = "CodItem"
            ddlMedicionCov.DataBind()
            'XT8633 Fin

            Dim obeParametro As BusinessEntity.Parametro = buscarParametro("MET_COD_MONEDA")
            dropMoneda.SelectedValue = obeParametro.Valor1

            obeParametro = buscarParametro("MET_COD_UNIDAD")
            dropUnidad.SelectedValue = obeParametro.Valor1

            TabActivo = Int32.Parse(ecTabMntMetodizado.RECONCILIACION)
            TabRefrescar = Int32.Parse(ecTabMntMetodizado.RECONCILIACION)
            MntAccion = Int32.Parse(Request.Params("intMntAccion"))

            If MntAccion = Int32.Parse(ecMntPage.AGREGAR) Then
                CodMetodizado = 0
                bloquearControles(False)
                configMntAccion(ecMntPage.AGREGAR)
            ElseIf MntAccion = Int32.Parse(ecMntPage.MODIFICAR) Then
                CodMetodizado = Int32.Parse(Request.QueryString("intCodMetodizado"))
                cargarDatosMetodizado()
                'bloquearControles()
                configMntAccion(ecMntPage.MODIFICAR)
                If pbolActivarSeleccionPeriodo Then
                    activarSeleccionPeriodo()
                End If
            End If



        End Sub

        Private Sub configMntAccion(ByVal pordMntPage As ecMntPage)
            Dim intCodMoneda As Int32
            intCodMoneda = dropMoneda.SelectedValue
            's23006
            Dim strPeriodoProyecciones As String = Me.hidPeriodoProyeccion.Value

            Dim RutaCrystal As String = cefConfiguracion.retornaDatoConf("RutaCrystal") 'XT8633 1502202

            ' 24/01/2014 : XT5022 JAVILA (CGI)
            If CodPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or CodPerfil = Int32.Parse(ecPerfil.ADMINISTRADOR) Or CodPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
                imgGrabarRecOpe2.ToolTip = "Validar"
                lnkGrabarRecOpe2.ToolTip = "Validar"
                lnkGrabarRecOpe2.Text = "Validar"
            Else
                imgGrabarRecOpe2.ToolTip = "Enviar a Riesgos"
                lnkGrabarRecOpe2.ToolTip = "Enviar a Riesgos"
                lnkGrabarRecOpe2.Text = "Enviar"
            End If

            If pordMntPage = ecMntPage.AGREGAR Then
                MntAccion = Int32.Parse(ecMntPage.AGREGAR)
                btnGrabar.Attributes("onclick") = "javascript: if (confirm('" + ccALERTA_AGREGAR + "')) { document.getElementById('hidMntAccion').value = " + Int32.Parse(ecMntPage.AGREGAR).ToString() + "; return(true); } else { return(false); }"
                imgFiltrarPeriodo.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                lnkFiltrarPeriodo.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                imgNuevoPeriodo.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                lnkNuevoPeriodo.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                imgGrabarRecOpe1.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                lnkGrabarRecOpe1.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                imgGrabarRecOpe2.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                lnkGrabarRecOpe2.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                imgImpRec.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                lnkImpRec.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                imgExpRec.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                lnkExpRec.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                txtFuncionFx.Attributes.Add("onkeypress", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                'Francisco
                lnkImpResEjec.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                imgResEjec.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))

                lnkProyeccion.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                imgProyeccion.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_AGREGAR_PERIODO))
                'End Francisco
            ElseIf pordMntPage = ecMntPage.MODIFICAR Then
                Dim intCodMetodizado As Integer = CodMetodizado
                Dim strPeriodoFiltrado As String = PeriodoFiltrado
                MntAccion = Int32.Parse(ecMntPage.MODIFICAR)
                btnGrabar.Attributes("onclick") = "javascript:if (confirm('" + ccALERTA_MODIFICAR + "')) { document.getElementById('hidMntAccion').value = " + Int32.Parse(ecMntPage.MODIFICAR).ToString() + "; return(true); } else { return(false); }"
                If VSPeriodosFiltrados.Count = 0 Then
                    imgGrabarRecOpe1.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    lnkGrabarRecOpe1.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    imgGrabarRecOpe2.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    lnkGrabarRecOpe2.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    imgImpRec.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    lnkImpRec.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    imgExpRec.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    lnkExpRec.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    txtFuncionFx.Attributes.Add("onkeypress", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    'Francisco
                    lnkImpResEjec.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    imgResEjec.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO))
                    'End Francisco
                Else
                    ' 24/01/2014 : XT5022 - JAVILA (CGI)
                    If CodPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or CodPerfil = Int32.Parse(ecPerfil.ADMINISTRADOR) Or CodPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
                        imgGrabarRecOpe1.Attributes.Add("onclick", String.Format("javascript:return (f_CallBackReconciliacion({0}));", Byte.Parse(ecEstadoMetodizado.INCOMPLETO_RIESGO)))
                        lnkGrabarRecOpe1.Attributes.Add("href", String.Format("javascript:f_CallBackReconciliacion({0});", Byte.Parse(ecEstadoMetodizado.INCOMPLETO_RIESGO)))
                        imgGrabarRecOpe2.Attributes.Add("onclick", String.Format("javascript:return (f_CallBackGrabarRecOpe2({0},true));", Byte.Parse(ecEstadoMetodizado.VALIDADO))) 'modificaco RQUISPE 18/03/2014
                        lnkGrabarRecOpe2.Attributes.Add("href", String.Format("javascript:f_CallBackGrabarRecOpe2({0},true);", Byte.Parse(ecEstadoMetodizado.VALIDADO))) 'modificaco RQUISPE 18/03/2014
                    Else
                        imgGrabarRecOpe1.Attributes.Add("onclick", String.Format("javascript:return (f_CallBackReconciliacion({0}));", Byte.Parse(ecEstadoMetodizado.INCOMPLETO_NEGOCIO)))
                        lnkGrabarRecOpe1.Attributes.Add("href", String.Format("javascript:f_CallBackReconciliacion({0});", Byte.Parse(ecEstadoMetodizado.INCOMPLETO_NEGOCIO)))
                        imgGrabarRecOpe2.Attributes.Add("onclick", String.Format("javascript:return (f_CallBackGrabarRecOpe2({0}));", Byte.Parse(ecEstadoMetodizado.PENDIENTE)))
                        lnkGrabarRecOpe2.Attributes.Add("href", String.Format("javascript:f_CallBackGrabarRecOpe2({0});", Byte.Parse(ecEstadoMetodizado.PENDIENTE)))
                    End If
                    'imgImpRec.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwMetodizado.aspx?intCodMetodizado={0}&strPeriodoFiltrado={1}');", intCodMetodizado, strPeriodoFiltrado))
                    'lnkImpRec.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwMetodizado.aspx?intCodMetodizado={0}&strPeriodoFiltrado={1}');", intCodMetodizado, strPeriodoFiltrado))
                    imgImpRec.Attributes.Add("onclick", String.Format("javascript:f_VerificarAbrirReporte('winRpt','{3}/PagRpt/rvwMetodizado.aspx?intCodMetodizado={0}&strPeriodoFiltrado={1}',pbytEstado={2});", intCodMetodizado, strPeriodoFiltrado, Byte.Parse(ecEstadoMetodizado.PENDIENTE), RutaCrystal))

                    'I-XT9104 28/04/2020
                    Dim ccALERTA_NOCOVENANT As String
                    ccALERTA_NOCOVENANT = valMuestraMensaje(intCodMetodizado)
                    lnkImpRec.Attributes.Add("href", String.Format("javascript:" & ccALERTA_NOCOVENANT & "f_VerificarAbrirReporte('winRpt','{3}/PagRpt/rvwMetodizado.aspx?intCodMetodizado={0}&strPeriodoFiltrado={1}',pbytEstado={2});", intCodMetodizado, strPeriodoFiltrado, Byte.Parse(ecEstadoMetodizado.PENDIENTE), RutaCrystal))
                    'F-XT9104 28/04/2020

                    imgExpRec.Attributes.Add("onclick", String.Format("javascript:f_Exportar('winRpt','../PagRpt/rvwExpReconciliado.aspx?intCodMetodizado={0}&strPeriodoFiltrado={1}');", intCodMetodizado, strPeriodoFiltrado))
                    lnkExpRec.Attributes.Add("href", String.Format("javascript:f_Exportar('winRpt','../PagRpt/rvwExpReconciliado.aspx?intCodMetodizado={0}&strPeriodoFiltrado={1}');", intCodMetodizado, strPeriodoFiltrado))

                    txtFuncionFx.Attributes.Add("onkeypress", "javascript:if (event.keyCode == 13) {f_CalculadoraFx(this); event.returnValue = false;} else f_ValidarIngFx(this);")
                    txtFuncionFx.Attributes.Add("onblur", "javascript:f_CalculadoraFx(this);")

                    'Francisco
                    'lnkImpResEjec.Attributes.Add("href", String.Format("javascript:f_AbrirResumenEjecutivo('../PagRpt/rvwResumenEjecutivo.aspx?strcodperiodo={0}&intcodmetodizado={1}&intcodmoneda={2}',{3},{4});", hidPeriodoFiltrado.Value, hidCodMetodizado.Value, dropMonedaImpresion.SelectedIndex.ToString(), 0, 0))
                    lnkImpResEjec.Attributes.Add("href", String.Format("javascript:f_AbrirResumenEjecutivo('{4}/PagRpt/rvwResumenEjecutivo.aspx?strcodperiodo={0}&intcodmetodizado={1}',{2},{3});", hidPeriodoFiltrado.Value, hidCodMetodizado.Value, 0, 0, RutaCrystal))
                    'imgResEjec.Attributes.Add("onclick", String.Format("javascript:f_AbrirResumenEjecutivo('../PagRpt/rvwResumenEjecutivo.aspx?strcodperiodo={0}&intcodmetodizado={1}&intcodmoneda={2}',{3},{4});", hidPeriodoFiltrado.Value, hidCodMetodizado.Value, dropMonedaImpresion.SelectedIndex.ToString(), 0, 0))
                    imgResEjec.Attributes.Add("onclick", String.Format("javascript:f_AbrirResumenEjecutivo('{4}/PagRpt/rvwResumenEjecutivo.aspx?strcodperiodo={0}&intcodmetodizado={1}',{2},{3});", hidPeriodoFiltrado.Value, hidCodMetodizado.Value, 0, 0, RutaCrystal))
                    'End Francisco

                End If
                imgFiltrarPeriodo.Attributes.Add("onclick", String.Format("javascript:f_AbrirSeleccionPeriodo('busSeleccionarPeriodo.aspx?intCodMetodizado={0}&intMntAccion={1}',{2},{3},{4});", intCodMetodizado, Int32.Parse(ecMntPage.BUSCAR), 450, 570, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
                lnkFiltrarPeriodo.Attributes.Add("href", String.Format("javascript:f_AbrirSeleccionPeriodo('busSeleccionarPeriodo.aspx?intCodMetodizado={0}&intMntAccion={1}',{2},{3},{4});", intCodMetodizado, Int32.Parse(ecMntPage.BUSCAR), 450, 570, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
                imgNuevoPeriodo.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntPeriodoCuenta.aspx?intCodMetodizado={0}&intCodMoneda={1}&intMntAccion={2}',{3},{4},{5});", intCodMetodizado, intCodMoneda, Int32.Parse(ecMntPage.AGREGAR), 535, 320, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
                lnkNuevoPeriodo.Attributes.Add("href", String.Format("javascript:f_AbrirPagMnt('mntPeriodoCuenta.aspx?intCodMetodizado={0}&intCodMoneda={1}&intMntAccion={2}',{3},{4},{5});", intCodMetodizado, intCodMoneda, Int32.Parse(ecMntPage.AGREGAR), 535, 320, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))

                'S23006 30/05/2012
                imgProyeccion.Attributes.Add("onclick", String.Format("javascript:f_AbrirSeleccionProyeccion('busSeleccionarPeriodoProyeccion.aspx?intCodMetodizado={0}&intMntAccion={1}&strRazonSocial={2}',{3},{4},{5});", intCodMetodizado, Int32.Parse(ecMntPage.BUSCAR), Me.txtRazonSocial.Text, 450, 570, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
                'imgProyeccion.Attributes.Add("onclick", String.Format("javascript:f_AbrirSeleccionProyeccion('busSeleccionarPeriodoProyeccion.aspx?',{0},{1},{2});", 450, 570, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
                lnkProyeccion.Attributes.Add("href", String.Format("javascript:f_AbrirSeleccionProyeccion('busSeleccionarPeriodoProyeccion.aspx?intCodMetodizado={0}&intMntAccion={1}&strRazonSocial={2}',{3},{4},{5});", intCodMetodizado, Int32.Parse(ecMntPage.BUSCAR), Me.txtRazonSocial.Text, 450, 570, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
                'S23006
                imgAsociados.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntAsociadosCovenant.aspx?intCodMetodizado={0}&intMntAccion={1}',{2},{3},{4});", intCodMetodizado, Int32.Parse(ecMntPage.MODIFICAR), 650, 450, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
            End If
        End Sub

        Private Sub cargarDatosMetodizado()
            Dim intCodMetodizado As Integer = Int32.Parse(Request.QueryString("intCodMetodizado"))

            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            obeMetodizado = obrMetodizado.leer(intCodMetodizado)

            If Not obeMetodizado Is Nothing Then
                txtCodMetodizado.Text = obeMetodizado.CodMetodizado
                txtCUCliente.Text = obeMetodizado.CUCliente
                If Trim(Me.txtCUCliente.Text) = String.Empty Then
                    pBloquearCUCliente(False)
                Else
                    pBloquearCUCliente(True)
                End If
                txtRUC.Text = obeMetodizado.NumeroDocumento
                txtRazonSocial.Text = obeMetodizado.RazonSocial
                txtCodCIIU.Text = obeMetodizado.CodCIIU
                txtNombreCIIU.Text = obeMetodizado.NombreCIIU
                txtCodSBS.Text = obeMetodizado.CodSBS
                txtCodGrupoEconomico.Text = obeMetodizado.CodGrupoEconomico
                dropTipoDocumento.SelectedValue = obeMetodizado.TipoDocumento
                txtNombreGrupoEconomico.Text = obeMetodizado.NombreGrupoEconomico
                dropUnidad.SelectedValue = obeMetodizado.CodUnidad
                txtCodEjecutivo.Text = obeMetodizado.CodEjecutivo
                txtNombreEjecutivo.Text = obeMetodizado.NombreEjecutivo
                txtCodAnalista.Text = obeMetodizado.CodAnalista
                txtNombreAnalista.Text = obeMetodizado.NombreAnalista
                txtCodUsuario.Text = obeMetodizado.CodUsuario
                txtNombreUsuario.Text = obeMetodizado.NombreUsuario
                txtFecReg.Text = obeMetodizado.FecReg
                Dim obeGeneral As BusinessEntity.General = buscarGeneralItem(ecTablaGeneral.ESTADO_METODIZADO, obeMetodizado.Estado)
                txtDesEstado.Text = obeGeneral.Descripcion
                TabRefrescar = Int32.Parse(ecTabMntMetodizado.RECONCILIACION)
                'refrescarTabControl(TabRefrescar) 'Invocar el metodo si no se filtra los periodos


                'I-XT9104 - 10/03/2020
                cargaMonedas()
                dropMoneda.SelectedValue = obeMetodizado.CodMoneda
                cargaMonedasImpresion()
                dropMonedaImpresion.SelectedValue = obeMetodizado.CodMonedaImpresion
                'F-XT9104 - 10/03/2020


                ' 22/01/2014 : XT5022 - JAVILA (CGI)
                ddlSegmento.SelectedValue = obeMetodizado.Segmento

                'Adicionado 13/03/2014: selecionoa el tipo de banca RQUISPE
                ddlTipoBanca.SelectedValue = obeMetodizado.FlgBPE
                'fin adicionado

                'ADD XT8442 ADR 23-10-2018 INICIO
                dropTipoDocumentoComp.SelectedValue = obeMetodizado.TipoDocumentoComplementario
                txtRUCComp.Text = obeMetodizado.NumeroDocumentoComplementario
                'ADD XT8442 ADR 23-10-2018 FIN

                'XT8633 Ini
                activarCovenant(obeMetodizado.ESCovenant, intCodMetodizado, obeMetodizado.CodFrecuenciaCov)
                'XT8633 Fin

                'ADD XT8442 ADR 19-10-2018 INICIO
                If (dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.DNI) Then
                    trTipoDocumentoComp.Attributes.Add("style", "display:block;")
                End If
                'ADD XT8442 ADR 19-10-2018 FIN
            End If
        End Sub

        Function CantidadFormulasValidadas(ByVal dsFormula As DataSet) As Integer

            Dim cantidadvalidos As Integer = 0

            For Each drFormula As DataRow In dsFormula.Tables(0).Rows

                If drFormula("Estado").ToString = "2" Then
                    cantidadvalidos = cantidadvalidos + 1
                End If

            Next

            Return cantidadvalidos

        End Function

        'XT8633 INI
        Private Sub activarCovenant(ByVal intEstado As Integer, ByVal intCodMetodizado As Integer, ByVal intCodFrecuencia As Integer)

            Dim obrFormulaCovenant As BusinessRules.FormulaCovenant = New BusinessRules.FormulaCovenant
            Dim dsFormulaCovenant As DataSet = New DataSet
            Dim intCantidadValidados As Integer

            dsFormulaCovenant = obrFormulaCovenant.listar(1, intCodMetodizado)

            If dsFormulaCovenant Is Nothing Then
                intCantidadValidados = 0
            Else
                intCantidadValidados = CantidadFormulasValidadas(dsFormulaCovenant)
            End If

            If intEstado = 1 Then
                Me.imgRatios.Visible = True
                Me.imgAsociados.Visible = True
                Me.chkcovenants.Checked = True
                Me.ddlMedicionCov.Attributes.Add("style", "display:block;")
                Me.lblfrecuencia.Attributes.Add("style", "display:block")
                Me.ddlMedicionCov.SelectedValue = intCodFrecuencia
                If ddlMedicionCov.SelectedValue = 0 Then
                    Me.muestraAlerta(ccALERTA_NO_FRECUENCIA_COVENANT)
                End If
            Else
                Me.imgRatios.Visible = False
                Me.imgAsociados.Visible = False
                Me.chkcovenants.Checked = False
                Me.ddlMedicionCov.Attributes.Add("style", "display:none;")
                Me.lblfrecuencia.Attributes.Add("style", "display:none")
            End If

            'perfil
            Dim intPerfil As Integer = fRetornaPerfilUsuario()
            If intPerfil = ecPerfil.EJECUTIVO_NEGOCIO Then
                If intCantidadValidados > 0 Then
                    Me.chkcovenants.Enabled = False
                End If
            End If
        End Sub
        'XT8633 FIN
        Protected Sub activarSeleccionPeriodo()
            Dim strHtml As String = "document.getElementById(""{0}"").onclick();"
            Dim sbScriptCliente As System.Text.StringBuilder
            sbScriptCliente = New StringBuilder("<script language=""Javascript"" type=""text/javascript"">")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("<!--")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.AppendFormat(strHtml, imgFiltrarPeriodo.ClientID)
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("// -->")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("</script>")
            RegisterStartupScript("__RegPopupWebForm_SeleccionarPeriodo", sbScriptCliente.ToString())
        End Sub

        Protected Sub inicializarControlesPorScript()
            Dim sbScriptCliente As System.Text.StringBuilder
            sbScriptCliente = New StringBuilder("<script language=""Javascript"" type=""text/javascript"">")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("<!--")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("f_SetPosPage();")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("f_SetPosDivRec();")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("// -->")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("</script>")
            RegisterStartupScript("__RegScriptClientWebForm_InicializarControles", sbScriptCliente.ToString())
        End Sub

        Private Sub cargarDatosReconciliacion()
            Dim intCodMetodizado As Integer = CodMetodizado
            Dim strPeriodoFiltrado As String = PeriodoFiltrado

            Dim intContadorColPeriodo As Integer
            Dim intAnchoColumnas As Integer
            Dim dsPeriodoCuenta As DataSet

            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            Dim obePeriodoLst As BusinessEntity.PeriodoLst
            If (strPeriodoFiltrado <> String.Empty) Then
                Dim arrCodPeriodo As String() = strPeriodoFiltrado.Split(";")

                'Obtenemos el código de CorridaMetodizado...
                hidCodCorridaMetodizado.Value = fRetornaCodCorridaMetodizado(intCodMetodizado, arrCodPeriodo).ToString

                obePeriodoLst = New BusinessEntity.PeriodoLst
                For Each strCodPeriodo As String In arrCodPeriodo
                    Dim obePeriodo As BusinessEntity.Periodo = New BusinessEntity.Periodo
                    obePeriodo.CodMetodizado = intCodMetodizado
                    obePeriodo.CodPeriodo = Int32.Parse(strCodPeriodo)
                    obePeriodoLst.Add(obePeriodo)
                Next
                obeMetodizado = New BusinessEntity.Metodizado
                obeMetodizado.CodMetodizado = intCodMetodizado
                obeMetodizado.Periodos = obePeriodoLst

                obePeriodoLst = obrMetodizado.filtrarPeriodo(obeMetodizado)

                Dim Per As Integer = 0
                Dim FecPeriodo As String
                Dim EstadoEFF As String
                If obePeriodoLst.Count() > 0 Then
                    intContadorColPeriodo = obePeriodoLst.Count()
                    intAnchoColumnas = (Me.ccANCHO_DGRID_PERIODO + (Me.ccANCHO_COLUMNA_PERIODO * intContadorColPeriodo))
                    VSPeriodosFiltrados = obePeriodoLst
                    For Each obePeriodo As BusinessEntity.Periodo In obePeriodoLst
                        agregarColPeriodo(ecTabMntMetodizado.RECONCILIACION, dgrdMntRec, obePeriodo)
                        If (obePeriodo.CodTipoEeff = 1 And obePeriodo.Estado) Or (obePeriodo.CodTipoEeff = 2 And obePeriodo.Estado) Then
                            Per = obePeriodo.CodPeriodo
                            FecPeriodo = obePeriodo.FecPeriodo
                            EstadoEFF = obePeriodo.DesTipoEeff
                        End If
                    Next

                    If Per <> 0 Then
                        imgRatios.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntRatios.aspx?intCodMetodizado={0}&intCodPeriodo={1}&strFechaPeriodo={2}&strDesEstadoEEFF={3}&intMntAccion={4}',{5},{6},{7});", intCodMetodizado, Per, FecPeriodo, EstadoEFF, Int32.Parse(ecMntPage.MODIFICAR), 700, 500, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
                    Else
                        imgRatios.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_NO_EXISTE_PERIODO_FILTRADO_COV))
                    End If
                    ' 22-01-2014 : XT5022 - JAVILA (CGI) 
                    If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                        dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuentaBPE(obeMetodizado)
                    ElseIf CodPerfil = ecPerfil.ADMINISTRADOR Then
                        If ddlTipoBanca.SelectedValue = ecTipoBanca.BancaEmpresa Then
                            dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuenta(obeMetodizado)
                        ElseIf ddlTipoBanca.SelectedValue = ecTipoBanca.BancaPequenaEmpresa Then
                            dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuentaBPE(obeMetodizado)
                        End If
                    Else
                        dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuenta(obeMetodizado)
                    End If
                    'dsPeriodoCuenta = obiMetodizado.filtrarPeriodoCuenta(obeMetodizado)


                    hidPeriodoCuenta.Value = ""
                    hidCuentaLibre.Value = ""

                    dgrdMntRec.DataSource = dsPeriodoCuenta
                    dgrdMntRec.DataKeyField = "CodCuenta"
                    dgrdMntRec.Width = New Unit(intAnchoColumnas, UnitType.Pixel)
                    dgrdMntRec.DataBind()

                    ltlNumRegRec.Text = dsPeriodoCuenta.Tables(0).Rows.Count

                    configMntAccion(ecMntPage.MODIFICAR)

                    cargarFormulaEnCliente()
                End If
            End If
        End Sub


        Private Sub agregarColPeriodo(ByVal ordTabMnt As ecTabMntMetodizado, ByRef dgrMnt As DataGrid, ByVal pobePeriodo As BusinessEntity.Periodo)
            Dim dgcImporte As New TemplateColumn
            Dim edpActual As LeePeriodo = Me.LoadControl("..\PagWUC\LeePeriodo.ascx")
            edpActual.Periodo = pobePeriodo


            'Dim obeUsuario As BusinessEntity.Usuario
            'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

            'srt_2017-02160
            'Dim strCodUsuario As String = datosGlobal.sUser
            Dim strCodUsuario As String = retornaUsuarioSesion()

            'obeUsuario = obrUsuario.leer(strCodUsuario)

            Dim oImgEditar As UI.WebControls.Image = CType(edpActual.FindControl("imgEditar"), UI.WebControls.Image)

            'comentado por rquispe 29/04/2014 para que tome el perfil del querystring y no del usuario
            ' If obeUsuario.CodPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
            'SRT_2017-02160
            Dim intPerfil As Integer = fRetornaPerfilUsuario()
            'If datosGlobal.nPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
            If intPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
                If Not oImgEditar Is Nothing Then oImgEditar.Attributes.Add("style", "display:none;")
            Else
                If Not oImgEditar Is Nothing Then oImgEditar.Attributes.Add("style", "display:'';")
            End If

            ' 24/01/2014 XT5022 JAVILA (CGI)
            'comentado por rquispe 29/04/2014 para que tome el perfil del querystring y no del usuario
            ' If obeUsuario.CodPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or obeUsuario.CodPerfil = Int32.Parse(ecPerfil.ADMINISTRADOR) Or obeUsuario.CodPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
            'If datosGlobal.nPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or datosGlobal.nPerfil = Int32.Parse(ecPerfil.ADMINISTRADOR) Or datosGlobal.nPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
            If intPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or intPerfil = Int32.Parse(ecPerfil.ADMINISTRADOR) Or intPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
                Dim oImgEstadoPeriodo As UI.WebControls.Image = CType(edpActual.FindControl("imgComentario"), UI.WebControls.Image)
                If Not oImgEstadoPeriodo Is Nothing Then
                    oImgEstadoPeriodo.Attributes.Add("onclick", "javascript:f_CallBackGrabarRecOpe4_Individual(" + Byte.Parse(ecEstadoMetodizado.VALIDADO).ToString + ", true, " + pobePeriodo.CodPeriodo.ToString + ");")
                End If
            End If


            Dim dgtHeader As PlantillaDgcImporte = New PlantillaDgcImporte(ListItemType.Header)
            dgtHeader.WebControl = edpActual
            dgcImporte.HeaderTemplate = dgtHeader

            Dim dgtItem As PlantillaDgcImporte
            If ordTabMnt = ecTabMntMetodizado.RECONCILIACION Then
                dgtItem = New PlantillaDgcImporte(ListItemType.EditItem)
                dgtItem.CssClass = "ActivoNumericoColSel"
                dgtItem.MaxLongitud = 16
                dgtItem.Formato = "{0:F0}"
                dgtItem.DataFieldNameImporte = "Importe" + pobePeriodo.CodPeriodo.ToString
                dgtItem.DataFieldNameFuncion = "Funcion" + pobePeriodo.CodPeriodo.ToString
                dgtItem.IDControlImporte = "txtImporte" + pobePeriodo.CodPeriodo.ToString
                dgtItem.IDControlFuncion = "hidFuncion" + pobePeriodo.CodPeriodo.ToString
            End If

            dgcImporte.ItemTemplate = dgtItem
            dgcImporte.ItemStyle.HorizontalAlign = HorizontalAlign.Right

            dgrMnt.Columns.Add(dgcImporte)
        End Sub

        Private Sub refrescarTabControl(ByVal intTabIndice As Integer)
            Select Case intTabIndice
                Case 1
                    'nada
                Case 2
                    cargarDatosReconciliacion()
            End Select
        End Sub

        Private Sub bloquearControles(Optional ByVal bolBloqueo As Boolean = True)
            pBloquearCUCliente(bolBloqueo)

            txtRUC.ReadOnly = bolBloqueo
            If bolBloqueo Then
                txtRUC.CssClass = "NoActivo"
            Else
                txtRUC.CssClass = String.Empty
            End If
        End Sub

        Private Sub pBloquearCUCliente(ByVal bolBloqueo As Boolean)
            txtCUCliente.ReadOnly = bolBloqueo
            If bolBloqueo Then
                txtCUCliente.CssClass = "NoActivo"
            Else
                txtCUCliente.CssClass = String.Empty
            End If
        End Sub

        Private Sub dgrdMntRec_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMntRec.ItemDataBound
            Dim intPerfilUsuario As Int32 = Me.fRetornaPerfilUsuario()
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim strColorHex As String = CType(DataBinder.Eval(e.Item.DataItem, "ColorHex"), String)
                Dim strColorFondoHex As String = CType(DataBinder.Eval(e.Item.DataItem, "ColorFondoHex"), String)
                Dim bolNegrita As Boolean = CType(DataBinder.Eval(e.Item.DataItem, "Negrita"), Boolean)
                Dim bytTamanioFuente As Integer = Byte.Parse(DataBinder.Eval(e.Item.DataItem, "TamanioFuente"))
                Dim intCodCuenta As Integer = Int32.Parse(DataBinder.Eval(e.Item.DataItem, "CodCuenta"))
                Dim intCodEeff As Integer = Int32.Parse(DataBinder.Eval(e.Item.DataItem, "CodEeff"))
                Dim bytCodTipoCuenta As Byte = Byte.Parse(DataBinder.Eval(e.Item.DataItem, "CodTipoCuenta"))
                Dim bytFlagNota As Byte = Byte.Parse(DataBinder.Eval(e.Item.DataItem, "FlagNota"))
                Dim bytPrecisionImporte As Byte = Byte.Parse(DataBinder.Eval(e.Item.DataItem, "PrecisionImporte"))
                Dim bytEscalaImporte As Byte = Byte.Parse(DataBinder.Eval(e.Item.DataItem, "EscalaImporte"))
                Dim txtImporte As TextBox
                Dim hidFuncion As HtmlInputHidden
                Dim intIndiceCol As Integer
                Dim strIdCol As String
                Dim obePeriodoLst As BusinessEntity.PeriodoLst = VSPeriodosFiltrados
                Dim obePeriodo As BusinessEntity.Periodo

                e.Item.Style.Add("color", strColorHex)
                e.Item.Style.Add("background-color", strColorFondoHex)
                e.Item.Font.Bold = bolNegrita
                e.Item.Font.Size = New FontUnit(Unit.Pixel(bytTamanioFuente))

                'Francisco
                Dim lDescCuenta As Label = e.Item.FindControl("ltlDescripcion")

                Dim btnImgNota As HtmlImage = e.Item.FindControl("imgBtnNota")
                If bytCodTipoCuenta <> 2 Then
                    btnImgNota.Visible = False
                Else
                    If bytFlagNota <> 1 Then
                        btnImgNota.Visible = False
                    Else
                        Dim ttt As String
                        ttt = String.Format("javascript:f_AbrirMntNota('mntPeriodoNota.aspx?intCodMetodizado={0}&strPeriodoFiltrado={1}&intCodCuenta={2}&strRazSoc={3}&strDescCuenta={4}&controlid={5}',{6},{7});", CodMetodizado.ToString(), PeriodoFiltrado.ToString(), CType(intCodCuenta, String), txtRazonSocial.Text, lDescCuenta.Text, btnImgNota.ClientID, 450, 610)
                        btnImgNota.Attributes.Add("onclick", ttt)
                        '23/05/2012
                        lDescCuenta.Attributes.Add("onclick", ttt)

                        'Verifica Existencia
                        Dim obrPeriodoNota As New CEF.BusinessRules.PeriodoNota
                        If (obrPeriodoNota.verificarExistenciaNota(CodMetodizado, PeriodoFiltrado, intCodCuenta) = 1) Then
                            btnImgNota.Src = "../Imagen/iconos/ico_noteadd.png"
                        End If
                    End If
                End If
                'End Francisco

                For Each tcCuenta As TableCell In e.Item.Cells
                    intIndiceCol = e.Item.Cells.GetCellIndex(tcCuenta)
                    If intIndiceCol > 0 Then
                        obePeriodo = obePeriodoLst(intIndiceCol - 1)
                        strIdCol = obePeriodo.CodPeriodo.ToString + ";" + intCodCuenta.ToString
                        tcCuenta.Attributes.Add("id", strIdCol)

                        txtImporte = CType(tcCuenta.Controls(0), TextBox)
                        hidFuncion = CType(tcCuenta.Controls(1), HtmlInputHidden)
                        If (bytCodTipoCuenta = 1) Then
                            tcCuenta.Controls.RemoveAt(0)
                        Else
                            If (bytCodTipoCuenta = 3) Or (bytCodTipoCuenta = 4) Then
                                txtImporte.ReadOnly = True
                                txtImporte.Style.Add("border", "Transparent 0px solid")
                                txtImporte.Style.Add("color", strColorHex)
                                txtImporte.Style.Add("background-color", strColorFondoHex)
                                txtImporte.Font.Bold = bolNegrita
                                txtImporte.Font.Size = New FontUnit(Unit.Pixel(bytTamanioFuente))
                            Else
                                If obePeriodo.Estado = ecEstadoPeriodo.VALIDADO Then
                                    If Not (intPerfilUsuario = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or intPerfilUsuario = Int32.Parse(ecPerfil.ADMINISTRADOR)) Then
                                        txtImporte.ReadOnly = True
                                    End If
                                End If
                                'Inicio modificado xt8633 - David
                                txtImporte.Attributes.Add("onkeypress", "javascript: if(event.keyCode == 13) {document.getElementById('" + txtFuncionFx.ClientID + "').value=''; document.getElementById('" + hidFuncion.ClientID + "').value='';f_CalcularTotales(" + (intIndiceCol - 1).ToString() + "); event.returnValue = false;}; else f_ValidarNumero(this," + bytPrecisionImporte.ToString() + "," + bytEscalaImporte.ToString() + ");")
                                txtImporte.Attributes.Add("onblur", "javascript:f_CalcularTotales(" + (intIndiceCol - 1).ToString() + ");")
                                txtImporte.Attributes.Add("onfocus", "javascript:f_AsigIdCtrlActivo('" + txtImporte.ClientID + "','" + hidFuncion.ClientID + "'," + bytPrecisionImporte.ToString() + "," + bytEscalaImporte.ToString() + ");")
                                txtImporte.Attributes.Add("onchange", "javascript:document.getElementById('" + txtFuncionFx.ClientID + "').value=''; document.getElementById('" + hidFuncion.ClientID + "').value='';")
                                'Fin modificado xt8633 - David
                            End If
                            hidPeriodoCuenta.Value += (strIdCol + "|")

                            'I-XT9194 18/02/2020
                            If (bytCodTipoCuenta = 5) Then
                                hidCuentaLibreCovenants.Value += (strIdCol + "|")
                            End If
                            'F-XT9194 18/02/2020
                        End If
                    Else
                        If (bytCodTipoCuenta = 5) Then
                            tcCuenta.Attributes.Add("id", intCodCuenta.ToString)

                            'Dim ltlDescripcion As Literal = CType(tcCuenta.FindControl("ltlDescripcion"), Literal)
                            Dim ltlDescripcion As Label = CType(tcCuenta.FindControl("ltlDescripcion"), Label)
                            tcCuenta.Controls.Remove(ltlDescripcion)
                            hidCuentaLibre.Value += (intCodCuenta.ToString + "|")
                        Else
                            Dim txtDescripcion As TextBox = CType(tcCuenta.FindControl("txtDescripcion"), TextBox)
                            tcCuenta.Controls.Remove(txtDescripcion)
                        End If
                    End If
                Next
            End If
        End Sub

        Public Sub cargarFormulaEnCliente()
            Dim obePeriodoLst As BusinessEntity.PeriodoLst = Me.VSPeriodosFiltrados

            Dim intCodCuenta As Integer
            Dim intCodFormula As Integer
            Dim intCodEeff As Integer
            Dim bytTipo As Byte
            Dim bytPrecisionImporte As Byte
            Dim bytEscalaImporte As Byte
            Dim strNombreFuncion As String
            Dim sbFormula As StringBuilder = New StringBuilder
            Dim sbDefFunMain As StringBuilder = New StringBuilder
            Dim strCallFun As String
            Dim strCallFunRec As String
            Dim strCallFunValidaMetodizado As String
            Dim strCallFunValidaRiesgo As String
            Dim strDefBucleFor As String
            Dim strDefBucleForRiesgo As String
            Dim strArrPeriodo As String
            Dim strArrPeriodoValRiesgo As String
            Dim intIndice As Integer = 0
            Dim strFiltro As String
            Dim bytValRiesgo As Byte = 0
            Dim intPerfilUsuario As Int32 = Me.fRetornaPerfilUsuario()

            ' 30/01/2014 XT5022 - JAVILA (CGI)
            Dim intFlgBpe As Integer = 1
            If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                intFlgBpe = 2
            End If

            If obePeriodoLst.Count > 0 Then
                Dim obrFormula As BusinessRules.Formula = New BusinessRules.Formula
                Dim dtFormula As DataTable = obrFormula.buscarEnCuentaPorAnalisis(1, intFlgBpe).Tables(0)
                Dim dtSentencia As DataTable = obrFormula.buscarSentenciaPorAnalisis(1).Tables(0)

                'By Miguel Delgado
                Dim obeParametro As BusinessEntity.Parametro = buscarParametro("MET_ANIO_IMP_RCAMB")
                'End

                strArrPeriodo = "var arrPeriodo = new Array(" + obePeriodoLst.Count.ToString + ");" + ControlChars.NewLine
                For Each obePeriodo As BusinessEntity.Periodo In obePeriodoLst
                    strArrPeriodo += String.Format("arrPeriodo[{0}] = {1};", intIndice, obePeriodo.CodPeriodo) + ControlChars.NewLine
                    If obePeriodo.Anio >= obeParametro.Valor1 Then 'By Miguel Delgado
                        bytValRiesgo += 1
                    End If
                    intIndice += 1
                Next

                'By Miguel Delgado
                strArrPeriodoValRiesgo = "var arrPeriodoValRiesgo = new Array(" + bytValRiesgo.ToString + ");" + ControlChars.NewLine
                intIndice = 0
                For Each obePeriodo As BusinessEntity.Periodo In obePeriodoLst
                    If obePeriodo.Anio >= obeParametro.Valor1 Then
                        strArrPeriodoValRiesgo += String.Format("arrPeriodoValRiesgo[{0}] = {1};", intIndice, obePeriodo.CodPeriodo) + ControlChars.NewLine
                        intIndice += 1
                    End If
                Next
                'End

                sbFormula.Append("<SCRIPT LANGUAGE=""JavaScript"">")
                sbFormula.Append(ControlChars.NewLine)
                sbFormula.Append("<!--")
                sbFormula.Append(ControlChars.NewLine)
                sbFormula.Append(strArrPeriodo)
                sbFormula.Append(ControlChars.NewLine)

                'By Miguel Delgado
                sbFormula.Append("<!--")
                sbFormula.Append(ControlChars.NewLine)
                sbFormula.Append(strArrPeriodoValRiesgo)
                sbFormula.Append(ControlChars.NewLine)
                'End


                'By Javier Montes (05-11-2008 para validar un periodo individualmente)
                strCallFunValidaMetodizado += "if(pintCodPeriodoValidar!=null){" + ControlChars.NewLine
                strCallFunValidaMetodizado += "if(arrPeriodo[i] > pintCodPeriodoValidar){" + ControlChars.NewLine
                strCallFunValidaMetodizado += "break;" + ControlChars.NewLine
                strCallFunValidaMetodizado += "}" + ControlChars.NewLine
                strCallFunValidaMetodizado += "}" + ControlChars.NewLine
                'End

                'By Javier Montes (05-11-2008 para validar un periodo individualmente)
                strCallFunValidaRiesgo += "if(pintCodPeriodoValidar!=null){" + ControlChars.NewLine
                strCallFunValidaRiesgo += "if (arrPeriodoValRiesgo[i] > pintCodPeriodoValidar){" + ControlChars.NewLine
                strCallFunValidaRiesgo += "break;" + ControlChars.NewLine
                strCallFunValidaRiesgo += "}" + ControlChars.NewLine
                strCallFunValidaRiesgo += "}" + ControlChars.NewLine
                'End

                For Each dr As DataRow In dtFormula.Rows()
                    intCodCuenta = dr("CodCuenta")
                    intCodFormula = dr("CodFormula")
                    intCodEeff = dr("CodEeff")
                    bytTipo = dr("Tipo")
                    bytPrecisionImporte = dr("PrecisionImporte")
                    bytEscalaImporte = dr("EscalaImporte")
                    'strNombreFuncion = "f_FormulaCuenta" + intCodCuenta.ToString
                    strNombreFuncion = "f_Formula" + intCodFormula.ToString() + "Cuenta" + intCodCuenta.ToString()
                    strFiltro = "CodFormula = " + intCodFormula.ToString
                    Dim dtSentenciaPorFormula As DataTable = filtrarRegs(dtSentencia, strFiltro, String.Empty)
                    sbFormula.Append(ControlChars.NewLine)
                    sbFormula.Append("//")
                    sbFormula.Append(dr("Nombre"))
                    sbFormula.Append(ControlChars.NewLine)
                    If bytTipo = 1 Then
                        sbFormula.Append(expresionFormula(dtSentenciaPorFormula, intCodCuenta, strNombreFuncion, bytPrecisionImporte, bytEscalaImporte))
                        sbFormula.Append(ControlChars.NewLine)
                        If (intCodEeff = 3) Or (intCodEeff = 4) Then
                            strCallFunRec += strNombreFuncion + "(i);" + ControlChars.NewLine
                        Else
                            strCallFun += strNombreFuncion + "(pintIndice);" + ControlChars.NewLine
                        End If
                    ElseIf bytTipo = 2 Then
                        If intCodEeff = 5 Then
                            sbFormula.Append(expresionFormulaLogica(dtSentenciaPorFormula, strNombreFuncion, "arrPeriodoValRiesgo"))
                            sbFormula.Append(ControlChars.NewLine)
                            strCallFunValidaRiesgo += "bolRst &= (" + strNombreFuncion + "(i)==1);" + ControlChars.NewLine
                        Else
                            sbFormula.Append(expresionFormulaLogica(dtSentenciaPorFormula, strNombreFuncion, "arrPeriodo"))
                            sbFormula.Append(ControlChars.NewLine)
                            strCallFunValidaMetodizado += "bolRst &= (" + strNombreFuncion + "(i)==1);" + ControlChars.NewLine
                        End If
                    End If
                Next

                ''By Javier Montes (05-11-2008 para validar un periodo individualmente)
                'strCallFunValidaMetodizado += "if(pintCodPeriodoValidar!=null){" + ControlChars.NewLine
                'strCallFunValidaMetodizado += "if(arrPeriodo[i] == pintCodPeriodoValidar){" + ControlChars.NewLine
                'strCallFunValidaMetodizado += "break;" + ControlChars.NewLine
                'strCallFunValidaMetodizado += "}" + ControlChars.NewLine
                'strCallFunValidaMetodizado += "}" + ControlChars.NewLine
                ''End

                strDefBucleFor = "for(var i=pintIndice;(i<arrPeriodo.length && i<(pintIndice+2));i++)"
                strCallFunRec = strDefBucleFor + "{" + ControlChars.NewLine + strCallFunRec + ControlChars.NewLine + "}"

                sbDefFunMain.Append("function")
                sbDefFunMain.Append(" f_CalcularTotales(pintIndice)")
                sbDefFunMain.Append("{" + ControlChars.NewLine)
                sbDefFunMain.Append(strCallFun)
                sbDefFunMain.Append(ControlChars.NewLine)
                sbDefFunMain.Append(strCallFunRec)
                sbDefFunMain.Append(ControlChars.NewLine + "}")
                sbFormula.Append(ControlChars.NewLine)

                strDefBucleFor = "for(var i=1;(i<arrPeriodo.length);i++)"
                'By Miguel Delgado
                strDefBucleForRiesgo = "for(var i=0;(i<arrPeriodoValRiesgo.length);i++)"
                'End

                strCallFunValidaMetodizado = strDefBucleFor + "{" + ControlChars.NewLine + strCallFunValidaMetodizado + "}"

                'By Miguel Delgado
                strCallFunValidaRiesgo = strDefBucleForRiesgo + "{" + ControlChars.NewLine + strCallFunValidaRiesgo + "}"
                'End

                sbDefFunMain.Append(ControlChars.NewLine)
                sbDefFunMain.Append(ControlChars.NewLine)
                sbDefFunMain.Append("//Validación de Metodizado Cuadre")
                sbDefFunMain.Append(ControlChars.NewLine)
                sbDefFunMain.Append("function")
                sbDefFunMain.Append(" f_ValidarMetodizado(pbolCambiarIconos, pintCodPeriodoValidar)")
                sbDefFunMain.Append("{" + ControlChars.NewLine)
                sbDefFunMain.Append("var bolRst = true;")
                sbDefFunMain.Append(ControlChars.NewLine)

                ' 24/01/2014 XT5022 JAVILA (CGI)
                'If CodPerfil <> ecPerfil.ANALISTA_RIESGO_BPE And CodPerfil <> ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                sbDefFunMain.Append(strCallFunValidaMetodizado)
                'End If

                sbDefFunMain.Append(ControlChars.NewLine)

                ' 24/01/2014 XT5022 JAVILA (CGI)
                'If CodPerfil <> ecPerfil.ANALISTA_RIESGO_BPE And CodPerfil <> ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                sbDefFunMain.Append(strCallFunValidaRiesgo) 'By Miguel Delgado
                'End If

                ' 24/01/2014 : XT5022 - JAVILA (CGI)
                If intPerfilUsuario = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or intPerfilUsuario = Int32.Parse(ecPerfil.ADMINISTRADOR) Or intPerfilUsuario = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
                    sbDefFunMain.Append(ControlChars.NewLine) 'By Javier Montes
                    sbDefFunMain.Append("if(pbolCambiarIconos){" + ControlChars.NewLine) 'By Javier Montes
                    sbDefFunMain.Append("if(bolRst){") 'By Javier Montes
                    sbDefFunMain.Append(ControlChars.NewLine) 'By Javier Montes
                    sbDefFunMain.Append("for(var i=0;(i<arrPeriodo.length);i++){" + ControlChars.NewLine) 'By Javier Montes

                    'By Javier Montes (05-11-2008 para validar un periodo individualmente)
                    sbDefFunMain.Append("if(pintCodPeriodoValidar!=null){" + ControlChars.NewLine)
                    sbDefFunMain.Append("if(arrPeriodo[i] == pintCodPeriodoValidar){" + ControlChars.NewLine)
                    sbDefFunMain.Append("fActualizarIconoPeriodo(i, bolRst);" + ControlChars.NewLine)
                    sbDefFunMain.Append("break;" + ControlChars.NewLine)
                    sbDefFunMain.Append("}" + ControlChars.NewLine)
                    sbDefFunMain.Append("}" + ControlChars.NewLine)
                    sbDefFunMain.Append("else{" + ControlChars.NewLine)
                    'End

                    sbDefFunMain.Append("fActualizarIconoPeriodo(i, bolRst);" + ControlChars.NewLine) 'By Javier Montes
                    sbDefFunMain.Append("}" + ControlChars.NewLine)  'By Javier Montes (05-11-2008 para validar un periodo individualmente)
                    sbDefFunMain.Append("}" + ControlChars.NewLine) 'By Javier Montes
                    sbDefFunMain.Append("}" + ControlChars.NewLine) 'By Javier Montes
                    sbDefFunMain.Append("}") 'By Javier Montes
                End If

                sbDefFunMain.Append(ControlChars.NewLine) 'By Miguel Delgado
                sbDefFunMain.Append("return(bolRst);")
                sbDefFunMain.Append(ControlChars.NewLine + "}")

                sbFormula.Append(ControlChars.NewLine)
                sbFormula.Append(sbDefFunMain.ToString())
                sbFormula.Append(ControlChars.NewLine)
                sbFormula.Append("//-->")
                sbFormula.Append(ControlChars.NewLine)
                sbFormula.Append("</SCRIPT>")

                If (Not Me.IsClientScriptBlockRegistered("__RegFormulaWebForm")) Then
                    Me.RegisterClientScriptBlock("__RegFormulaWebForm", sbFormula.ToString())
                End If
            End If
        End Sub

        Private Function expresionFormula(ByVal pdtSentencia As DataTable, ByVal pintCodCuenta As Integer, ByVal pstrNombreFuncion As String, ByVal bytPrecisionImporte As Byte, ByVal bytEscalaImporte As Byte) As String
            Dim strFormula As String
            Dim strVariable As String
            Dim strCodCuenta1 As String
            Dim strCodSentencia1 As String
            Dim decValor1 As Decimal
            Dim strCodOperador As String
            Dim strCodCuenta2 As String
            Dim strCodSentencia2 As String
            Dim decValor2 As Decimal
            Dim strPosicionPeriodo1 As String
            Dim strPosicionPeriodo2 As String

            strFormula = "function " + pstrNombreFuncion + "(pIndice) {" + ControlChars.NewLine
            For Each dr As DataRow In pdtSentencia.Rows()
                strVariable = "dec" + dr("CodSentencia").ToString()
                strFormula += "var " + strVariable + " = "

                strPosicionPeriodo1 = dr("PosicionPeriodo1")
                If dr("TipoOpe1") = 1 Then
                    strCodCuenta1 = dr("CodCuenta1")
                    strFormula += "f_ObtValorCuenta(arrPeriodo[pIndice + (" + strPosicionPeriodo1 + ")]," + strCodCuenta1 + ")"
                ElseIf dr("TipoOpe1") = 2 Then
                    strCodSentencia1 = dr("CodSentencia1")
                    strFormula += "dec" + strCodSentencia1
                ElseIf dr("TipoOpe1") = 4 Then
                    decValor1 = dr("Valor1")
                    strFormula += Convert.ToInt32(decValor1).ToString()
                End If

                strCodOperador = dr("CodOperador")
                Select Case strCodOperador
                    Case 1
                        strCodOperador = " + "
                    Case 2
                        strCodOperador = " - "
                    Case 3
                        strCodOperador = " * "
                    Case 4
                        strCodOperador = " / "
                End Select
                strFormula += strCodOperador

                strPosicionPeriodo2 = dr("PosicionPeriodo2")
                If dr("TipoOpe2") = 1 Then
                    strCodCuenta2 = dr("CodCuenta2")
                    strFormula += "f_ObtValorCuenta(arrPeriodo[pIndice + (" + strPosicionPeriodo2 + ")]," + strCodCuenta2 + ")" + ";" + ControlChars.NewLine
                ElseIf dr("TipoOpe2") = 2 Then
                    strCodSentencia2 = dr("CodSentencia2")
                    strFormula += "dec" + strCodSentencia2 + ";" + ControlChars.NewLine
                ElseIf dr("TipoOpe2") = 4 Then
                    decValor2 = dr("Valor2")
                    strFormula += Convert.ToInt32(decValor2).ToString() + ";" + ControlChars.NewLine
                End If
            Next
            strFormula += "f_AsigValorCuenta(arrPeriodo[pIndice]," + pintCodCuenta.ToString() + "," + strVariable + "," + bytPrecisionImporte.ToString() + "," + bytEscalaImporte.ToString() + ");" + ControlChars.NewLine + "}"
            Return (strFormula)
        End Function

        'S1 = 0 * 0
        'S2 = CA20 + CA22
        'S3 = S2 + CA23
        'S4 = S3 + CA24
        'S5 = (S4 (5)= 0)
        'S6 = (10)IF (6)S5 THEN RETURN S1
        'S7 = (10)IF (7)NOT S5 THEN RETURN S4

        '1	SUMA	+ 
        '2	RESTA	- 
        '3	MULTIPLICACION	* 
        '4	DIVISION	/ 
        '5	IGUAL	= 
        '6	MAYOR	> 
        '7	MENOR	< 
        '8	AND	& 
        '9	OR	| 
        '10	SI	S 
        '11	MAYOR IGUAL	>=
        '12	MENOR IGUAL	<=

        Private Function expresionFormulaLogica(ByVal pdtSentencia As DataTable, ByVal pstrNombreFuncion As String, ByVal pstrArray As String) As String
            Dim strFormula As String
            Dim strVariable As String
            Dim strCodCuenta1 As String
            Dim strCodSentencia1 As String
            Dim decValor1 As Decimal
            Dim strCodOperador As String
            Dim strCodCuenta2 As String
            Dim strCodSentencia2 As String
            Dim decValor2 As Decimal
            Dim strPosicionPeriodo1 As String
            Dim strPosicionPeriodo2 As String

            strFormula = "function " + pstrNombreFuncion + "(pIndice) {" + ControlChars.NewLine
            For Each dr As DataRow In pdtSentencia.Rows()
                strVariable = "dec" + dr("CodSentencia").ToString()
                strFormula += "var " + strVariable + " = "

                strPosicionPeriodo1 = dr("PosicionPeriodo1")
                If dr("TipoOpe1") = 1 Then
                    strCodCuenta1 = dr("CodCuenta1")
                    strFormula += "(f_ObtValorCuenta(" + pstrArray + "[pIndice + (" + strPosicionPeriodo1 + ")]," + strCodCuenta1 + ")"
                ElseIf dr("TipoOpe1") = 2 Then
                    strCodSentencia1 = dr("CodSentencia1")
                    strFormula += "(dec" + strCodSentencia1
                ElseIf dr("TipoOpe1") = 4 Then
                    decValor1 = dr("Valor1")
                    strFormula += "(" + Convert.ToInt32(decValor1).ToString()
                ElseIf dr("TipoOpe1") = 6 Then
                    strCodSentencia1 = dr("CodSentencia1")
                    strFormula += "(dec" + strCodSentencia1
                ElseIf dr("TipoOpe1") = 7 Then
                    strCodSentencia1 = dr("CodSentencia1")
                    strFormula += "(!dec" + strCodSentencia1
                End If

                strCodOperador = dr("CodOperador")
                Select Case strCodOperador
                    Case 1
                        strCodOperador = " + "
                    Case 2
                        strCodOperador = " - "
                    Case 3
                        strCodOperador = " * "
                    Case 4
                        strCodOperador = " / "
                    Case 5
                        strCodOperador = " == "
                    Case 6
                        strCodOperador = " > "
                    Case 7
                        strCodOperador = " < "
                    Case 8
                        strCodOperador = " && "
                    Case 9
                        strCodOperador = " || "
                    Case 10
                        strCodOperador = ");" + ControlChars.NewLine + "if (" + strVariable + ") return (dec" + dr("CodSentenciaRst").ToString() + ");" + ControlChars.NewLine
                    Case 11
                        strCodOperador = " >= "
                    Case 12
                        strCodOperador = " <= "
                End Select
                strFormula += strCodOperador

                strPosicionPeriodo2 = dr("PosicionPeriodo2")
                If dr("TipoOpe2") = 1 Then
                    strCodCuenta2 = dr("CodCuenta2")
                    strFormula += "f_ObtValorCuenta(arrPeriodo[pIndice + (" + strPosicionPeriodo2 + ")]," + strCodCuenta2 + ")" + ");" + ControlChars.NewLine
                ElseIf dr("TipoOpe2") = 2 Then
                    strCodSentencia2 = dr("CodSentencia2")
                    strFormula += "dec" + strCodSentencia2 + ");" + ControlChars.NewLine
                ElseIf dr("TipoOpe2") = 4 Then
                    decValor2 = dr("Valor2")
                    strFormula += Convert.ToInt32(decValor2).ToString() + ");" + ControlChars.NewLine
                ElseIf dr("TipoOpe2") = 6 Then
                    strCodSentencia2 = dr("CodSentencia2")
                    strFormula += "dec" + strCodSentencia2 + ");" + ControlChars.NewLine
                ElseIf dr("TipoOpe2") = 7 Then
                    strCodSentencia2 = dr("CodSentencia2")
                    strFormula += "!dec" + strCodSentencia2 + ");" + ControlChars.NewLine
                End If
            Next
            strFormula += "return (" + strVariable + ")" + ";" + ControlChars.NewLine
            strFormula += "}"
            Return (strFormula)
        End Function

        Private Function filtrarRegs(ByVal pdtOrigen As DataTable, ByVal pstrFilter As String, ByVal pstrSort As String) As DataTable
            Dim drRegs As DataRow()
            Dim dtSentencia As DataTable
            dtSentencia = pdtOrigen.Clone()
            drRegs = pdtOrigen.Select(pstrFilter, pstrSort)
            For Each dr As DataRow In drRegs
                dtSentencia.ImportRow(dr)
            Next
            Return (dtSentencia)
        End Function

        Private Sub buscarCliente(ByVal pecTipoDocumento As ecTipoDocumento)
            Dim strCUCliente As String = txtCUCliente.Text.Trim
            Dim strRUC As String = txtRUC.Text.Trim
            'Dim obrCliente As BusinessRules.Cliente = New BusinessRules.Cliente
            'Dim obeCliente As BusinessEntity.Cliente
            Dim obrCIIU As BusinessRules.CIIU = New BusinessRules.CIIU
            Dim obeCIIU As BusinessEntity.CIIU

            'SRT MEJORAS CEF FASE 2
            Dim obeClienteRM As BusinessEntity.ClienteRM

            Try
                If pecTipoDocumento = ecTipoDocumento.CODIGO_UNICO Then
                    strCUCliente = strCUCliente.PadLeft(10, "0")
                    txtCUCliente.Text = strCUCliente
                    Using service As New CEF.BusinessRules.ServiceExternalLogic()
                        obeClienteRM = service.ClienteRMPorCodigoUnico(strCUCliente, Assemblys.retornaDatoConfig(constantesCommon.wsFCDRM))
                    End Using
                ElseIf pecTipoDocumento = ecTipoDocumento.RUC Then
                    strRUC = strRUC.PadLeft(11, "0")
                    txtRUC.Text = strRUC
                    Using service As New CEF.BusinessRules.ServiceExternalLogic()
                        obeClienteRM = service.ClienteRMPorDocumentoIdentidad(Int32.Parse(ecTipoDocumento.RUC).ToString(), strRUC, Assemblys.retornaDatoConfig(constantesCommon.wsFCDRM))
                        'WsRM trae todos los datos con codigo unico
                        If Not String.IsNullOrEmpty(obeClienteRM.Codigounico) Then
                            obeClienteRM = service.ClienteRMPorCodigoUnico(obeClienteRM.Codigounico, Assemblys.retornaDatoConfig(constantesCommon.wsFCDRM))
                        End If
                    End Using
                ElseIf pecTipoDocumento = 3 Then 'busqueda por DNI
                    strRUC = strRUC.PadLeft(8, "0")
                    txtRUC.Text = strRUC
                    Using service As New CEF.BusinessRules.ServiceExternalLogic()
                        obeClienteRM = service.ClienteRMPorDocumentoIdentidad(1.ToString(), strRUC, Assemblys.retornaDatoConfig(constantesCommon.wsFCDRM))
                        'WsRM trae todos los datos con codigo unico
                        If Not String.IsNullOrEmpty(obeClienteRM.Codigounico) Then
                            obeClienteRM = service.ClienteRMPorCodigoUnico(obeClienteRM.Codigounico, Assemblys.retornaDatoConfig(constantesCommon.wsFCDRM))
                        End If
                    End Using
                End If

                If obeClienteRM.CodError = 1 Then
                    Me.muestraAlerta(constantesCommon.ccALERTA_SERVICIORM_NOACTIVO & "\nMensaje: " & obeClienteRM.MsgError)
                Else
                    If Not String.IsNullOrEmpty(obeClienteRM.Codigounico) Or obeClienteRM.CodError <> 2 Then

                        txtCUCliente.Text = obeClienteRM.Codigounico
                        Me.hidTipoDocIdentidad_CU.Value = obeClienteRM.Codigotipodocumento

                        If obeClienteRM.Codigotipodocumento = "2" Then
                            'TipoDocumentoIdentidad = 2 en la base de datos de Rnt equivale a RUC en la base de datos CEF...
                            dropTipoDocumento.SelectedValue = 1 ' RUC
                            txtRUC.Text = obeClienteRM.Numerodocumento
                            Me.hidRUC_CU.Value = obeClienteRM.Numerodocumento
                            'XT8442 ADD 20/11/2018
                            trTipoDocumentoComp.Attributes.Add("style", "display:none;")
                            'XT8442 ADD 20/11/2018
                        ElseIf obeClienteRM.Codigotipodocumento = "1" Then 'agregado por RQUISPE 19/03/2014
                            'TipoDocumentoIdentidad = 1 en la base de datos de Rnt equivale a DNI en la base de datos CEF...
                            dropTipoDocumento.SelectedValue = 2 ' DNI
                            txtRUC.Text = obeClienteRM.Numerodocumento
                            'XT8442 ADD 20/11/2018
                            trTipoDocumentoComp.Attributes.Add("style", "display:block;")
                            'XT8442 ADD 20/11/2018
                        Else
                            Me.hidRUC_CU.Value = String.Empty
                        End If


                        txtRazonSocial.Text = obeClienteRM.Razonsocialcliente
                        txtCodGrupoEconomico.Text = obeClienteRM.Codigogrupo
                        txtNombreGrupoEconomico.Text = obeClienteRM.Nombregrupo
                        txtCodCIIU.Text = obeClienteRM.Ciiu

                        'OBTENEMOS CODSBS DE WS RCC
                        Dim strCodigoSBS As String

                        Using service As New CEF.BusinessRules.ServiceExternalLogic()
                            strCodigoSBS = service.ClienteRCCPorDocumentoIdentidad(obeClienteRM.Codigotipodocumento, obeClienteRM.Numerodocumento, Assemblys.retornaDatoConfig(constantesCommon.wsBPSRCC))
                        End Using

                        txtCodSBS.Text = strCodigoSBS 'UTILIZAR WEB SERVICE DE RTG 
                        txtNombreCIIU.Text = String.Empty
                        obeCIIU = obrCIIU.leer(obeClienteRM.Ciiu)
                        If Not IsNothing(obeCIIU) Then txtNombreCIIU.Text = obeCIIU.Nombre

                        Dim strCodUsuario As String = retornaUsuarioSesion()
                        Dim strNomUsuario As String = retornaNombreUsuarioSesion()

                        Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
                        Dim obeUsuario As BusinessEntity.Usuario
                        If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                            txtCodEjecutivo.Text = strCodUsuario
                            txtNombreEjecutivo.Text = strNomUsuario
                            obeUsuario = obrUsuario.responsableCarteraUsuario(strCodUsuario)
                            If Not obeUsuario Is Nothing Then
                                txtCodAnalista.Text = obeUsuario.CodUsuario
                                txtNombreAnalista.Text = obeUsuario.Nombre
                            End If
                        Else
                            If obeClienteRM.Codigoejecutivo <> String.Empty Then
                                obeUsuario = obrUsuario.leer(obeClienteRM.Codigoejecutivo)
                                If Not obeUsuario Is Nothing Then
                                    txtCodEjecutivo.Text = obeUsuario.CodUsuario
                                    txtNombreEjecutivo.Text = obeUsuario.Nombre
                                    obeUsuario = obrUsuario.responsableCarteraUsuario(obeUsuario.CodUsuario)
                                    If Not obeUsuario Is Nothing Then
                                        txtCodAnalista.Text = obeUsuario.CodUsuario
                                        txtNombreAnalista.Text = obeUsuario.Nombre
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If pecTipoDocumento = ecTipoDocumento.RUC Then
                            Dim obrOmaes As BusinessRules.Cliente = New BusinessRules.Cliente

                            Dim dsOmaes As DataSet = obrOmaes.leerRegOmaesSunat(strRUC)
                            If Not IsNothing(dsOmaes) Then 'AGREGADO POR RQUISPE 19/03/2014, PRODUCE ERROR, NO HAY CONEXION CON LA BD
                                Dim intNumReg As Integer = dsOmaes.Tables(0).Rows.Count
                                If intNumReg > 0 Then
                                    txtRazonSocial.Text = dsOmaes.Tables(0).Rows(0)("OUT_IFX_DPC_NOMBRE")
                                Else
                                    Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de cliente")
                                End If
                            Else
                                Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de cliente")
                            End If
                        Else

                            If pecTipoDocumento = ecTipoDocumento.RUC Then
                                Me.hidRUC_CU.Value = String.Empty
                                Me.txtCUCliente.Text = String.Empty
                            End If
                            Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de cliente")
                        End If
                    End If

                End If
                'Try
                '    If pecTipoDocumento = ecTipoDocumento.CODIGO_UNICO Then
                '        strCUCliente = strCUCliente.PadLeft(10, "0")
                '        txtCUCliente.Text = strCUCliente
                '        obeCliente = obrCliente.leer(strCUCliente)
                '    ElseIf pecTipoDocumento = ecTipoDocumento.RUC Then
                '        strRUC = strRUC.PadLeft(11, "0")
                '        txtRUC.Text = strRUC
                '        obeCliente = obrCliente.buscarXNumeroDocumento(Int32.Parse(ecTipoDocumento.RUC).ToString(), strRUC)
                '    ElseIf pecTipoDocumento = 3 Then 'busqueda por DNI
                '        strRUC = strRUC.PadLeft(8, "0")
                '        txtRUC.Text = strRUC
                '        obeCliente = obrCliente.buscarXNumeroDocumento(1.ToString(), strRUC) '1 = busqueda por DNI 
                '    End If

                '    If Not IsNothing(obeCliente) Then
                '        txtCUCliente.Text = obeCliente.CodigoUnico
                '        Me.hidTipoDocIdentidad_CU.Value = obeCliente.TipoDocumentoIdentidad
                '        If obeCliente.TipoDocumentoIdentidad = "2" Then
                '            'TipoDocumentoIdentidad = 2 en la base de datos de Rnt equivale a RUC en la base de datos CEF...
                '            dropTipoDocumento.SelectedValue = 1 ' RUC
                '            txtRUC.Text = obeCliente.NumeroDocumentoIdentidad
                '            Me.hidRUC_CU.Value = obeCliente.NumeroDocumentoIdentidad
                '        ElseIf obeCliente.TipoDocumentoIdentidad = "1" Then 'agregado por RQUISPE 19/03/2014
                '            'TipoDocumentoIdentidad = 1 en la base de datos de Rnt equivale a DNI en la base de datos CEF...
                '            dropTipoDocumento.SelectedValue = 2 ' DNI
                '            txtRUC.Text = obeCliente.NumeroDocumentoIdentidad
                '        Else
                '            Me.hidRUC_CU.Value = String.Empty
                '        End If
                '        'If txtRazonSocial.Text = String.Empty Then txtRazonSocial.Text = obeCliente.Nombre
                '        txtRazonSocial.Text = obeCliente.Nombre
                '        txtCodGrupoEconomico.Text = obeCliente.CodigoGrupoEconomico
                '        txtNombreGrupoEconomico.Text = obeCliente.NombreGrupoEconomico
                '        txtCodCIIU.Text = obeCliente.CodigoCIIU
                '        txtCodSBS.Text = obeCliente.CodigoSBS
                '        txtNombreCIIU.Text = String.Empty
                '        obeCIIU = obrCIIU.leer(obeCliente.CodigoCIIU)
                '        If Not IsNothing(obeCIIU) Then txtNombreCIIU.Text = obeCIIU.Nombre

                '        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
                '        'Dim strCodUsuario As String = DatosGlobal.sUser
                '        Dim strCodUsuario As String = retornaUsuarioSesion()
                '        Dim strNomUsuario As String = retornaNombreUsuarioSesion()

                '        Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                '        Dim obeUsuario As BusinessEntity.Usuario
                '        'obeUsuario = Util.obtenerUsuario(strCodUsuario)
                '        If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                '            'If Not obeUsuario Is Nothing Then
                '            'txtCodEjecutivo.Text = obeUsuario.CodUsuario
                '            'txtNombreEjecutivo.Text = obeUsuario.Nombre
                '            'obeUsuario = obrUsuario.responsableCarteraUsuario(obeUsuario.CodUsuario)
                '            txtCodEjecutivo.Text = strCodUsuario
                '            txtNombreEjecutivo.Text = strNomUsuario
                '            obeUsuario = obrUsuario.responsableCarteraUsuario(strCodUsuario)
                '            If Not obeUsuario Is Nothing Then
                '                txtCodAnalista.Text = obeUsuario.CodUsuario
                '                txtNombreAnalista.Text = obeUsuario.Nombre
                '            End If
                '            'End If
                '        Else
                '            If obeCliente.RegistroSectoristaActual <> String.Empty Then
                '                'Dim obeUsuario As BusinessEntity.Usuario
                '                'Dim obiUsuario As BusinessInterface.IUsuario
                '                'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
                '                obeUsuario = obrUsuario.leer(obeCliente.RegistroSectoristaActual)
                '                If Not obeUsuario Is Nothing Then
                '                    txtCodEjecutivo.Text = obeUsuario.CodUsuario
                '                    txtNombreEjecutivo.Text = obeUsuario.Nombre
                '                    obeUsuario = obrUsuario.responsableCarteraUsuario(obeUsuario.CodUsuario)
                '                    If Not obeUsuario Is Nothing Then
                '                        txtCodAnalista.Text = obeUsuario.CodUsuario
                '                        txtNombreAnalista.Text = obeUsuario.Nombre
                '                    End If
                '                End If
                '            End If
                '        End If

                '    Else
                '        If pecTipoDocumento = ecTipoDocumento.RUC Then
                '            Dim obrOmaes As BusinessRules.Cliente = New BusinessRules.Cliente

                '            Dim dsOmaes As DataSet = obrOmaes.leerRegOmaesSunat(strRUC)
                '            If Not IsNothing(dsOmaes) Then 'AGREGADO POR RQUISPE 19/03/2014, PRODUCE ERROR, NO HAY CONEXION CON LA BD
                '                Dim intNumReg As Integer = dsOmaes.Tables(0).Rows.Count
                '                If intNumReg > 0 Then
                '                    txtRazonSocial.Text = dsOmaes.Tables(0).Rows(0)("OUT_IFX_DPC_NOMBRE")
                '                Else
                '                    Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de cliente")
                '                End If
                '            Else
                '                Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de cliente")
                '            End If
                '        Else

                '            If pecTipoDocumento = ecTipoDocumento.RUC Then
                '                Me.hidRUC_CU.Value = String.Empty
                '                Me.txtCUCliente.Text = String.Empty
                '            End If
                '            Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de cliente")
                '        End If
                '    End If

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
        End Sub

        Private Sub agregarMetodizado()
            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obeMetodizadoBus As BusinessEntity.MetodizadoBus
            Dim intNumReg As Integer
            Try
                'Verifica Existe CUCliente y RUC
                If txtCUCliente.Text.Length = 0 And txtRUC.Text.Length = 0 Then
                    intNumReg = 0
                Else
                    'obeMetodizadoBus = New BusinessEntity.MetodizadoBus
                    'obeMetodizadoBus.CUCliente = txtCUCliente.Text
                    'obeMetodizadoBus.NumeroDocumento = txtRUC.Text

                    'Dim obiMetodizadoBus As BusinessInterface.IMetodizado
                    'Dim obrMetodizadoBus As BusinessRules.Metodizado = New BusinessRules.Metodizado
                    'obiMetodizadoBus = CType(obrMetodizadoBus, BusinessInterface.IMetodizado)

                    'Dim dsMetodizadoBus As DataSet = obiMetodizadoBus.buscar(obeMetodizadoBus)

                    'intNumReg = dsMetodizadoBus.Tables(0).Rows.Count

                    If fVerificarExistenciaCliente() Then
                        intNumReg = 1
                    End If
                End If
                If intNumReg = 0 Then

                    If Page.IsValid Then
                        obeMetodizado = New BusinessEntity.Metodizado

                        obeMetodizado.CUCliente = txtCUCliente.Text
                        obeMetodizado.TipoDocumento = dropTipoDocumento.SelectedValue
                        obeMetodizado.NumeroDocumento = txtRUC.Text
                        obeMetodizado.RazonSocial = txtRazonSocial.Text.Trim
                        obeMetodizado.CodCIIU = txtCodCIIU.Text.Trim
                        obeMetodizado.CodSBS = txtCodSBS.Text.Trim
                        obeMetodizado.CodGrupoEconomico = txtCodGrupoEconomico.Text.Trim
                        obeMetodizado.NombreGrupoEconomico = txtNombreGrupoEconomico.Text.Trim
                        obeMetodizado.CodUnidad = dropUnidad.SelectedValue
                        obeMetodizado.CodMoneda = dropMoneda.SelectedValue
                        obeMetodizado.CodEjecutivo = txtCodEjecutivo.Text
                        obeMetodizado.NombreEjecutivo = txtNombreEjecutivo.Text
                        obeMetodizado.CodMonedaImpresion = dropMonedaImpresion.SelectedValue
                        obeMetodizado.CodAnalista = txtCodAnalista.Text
                        obeMetodizado.NombreAnalista = txtNombreAnalista.Text

                        Dim obeUsuario As BusinessEntity.Usuario
                        Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                        'srt_2017-02160
                        'Dim strCodUsuario As String = datosGlobal.sUser
                        Dim strCodUsuario As String = retornaUsuarioSesion()
                        Dim strNomUsuario As String = retornaNombreUsuarioSesion()
                        Dim intPerfil As Integer = fRetornaPerfilUsuario()


                        obeMetodizado.CodUsuario = strCodUsuario
                        obeMetodizado.NombreUsuario = strNomUsuario

                        'obeUsuario = obrUsuario.leer(strCodUsuario)

                        'obeMetodizado.CodUsuario = obeUsuario.CodUsuario
                        'obeMetodizado.NombreUsuario = obeUsuario.Nombre

                        ' 24/01/2014 XT5022 JAVILA (CGI)
                        ' DEFINE EL ESTADO DE METODIZADO COMO INCOMPLETO DEPENDIENDO DEL PERFIL
                        'cambiado por   rquispe 29/04/2014 para que obtenga el perfil del query  string
                        'If obeUsuario.CodPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or obeUsuario.CodPerfil = Int32.Parse(ecPerfil.ADMINISTRADOR) Or obeUsuario.CodPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
                        'If DatosGlobal.nPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or DatosGlobal.nPerfil = Int32.Parse(ecPerfil.ADMINISTRADOR) Or DatosGlobal.nPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
                        If intPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO) Or intPerfil = Int32.Parse(ecPerfil.ADMINISTRADOR) Or intPerfil = Int32.Parse(ecPerfil.ANALISTA_RIESGO_BPE) Then
                            obeMetodizado.Estado = Int32.Parse(ecEstadoMetodizado.INCOMPLETO_RIESGO)
                        Else
                            obeMetodizado.Estado = Int32.Parse(ecEstadoMetodizado.INCOMPLETO_NEGOCIO)
                        End If

                        Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                        'obeUsuario = obrUsuario.leer(strCodUsuario)

                        'cambiado por   rquispe 29/04/2014 para que obtenga el perfil del query  string
                        'If obeUsuario.CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or obeUsuario.CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                        'If datosGlobal.nPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or datosGlobal.nPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                        If intPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or intPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                            obeMetodizado.FlgBPE = 2
                            obeMetodizado.Segmento = ddlSegmento.SelectedValue
                            'ElseIf datosGlobal.nPerfil = ecPerfil.ADMINISTRADOR Then
                        ElseIf intPerfil = ecPerfil.ADMINISTRADOR Then
                            ' 30/01/2014 XT5022 - JAVILA (CGI)
                            If ddlTipoBanca.SelectedValue = ecTipoBanca.BancaEmpresa Then
                                obeMetodizado.FlgBPE = 1
                                obeMetodizado.Segmento = Nothing
                            ElseIf ddlTipoBanca.SelectedValue = ecTipoBanca.BancaPequenaEmpresa Then
                                obeMetodizado.FlgBPE = 2
                                obeMetodizado.Segmento = ddlSegmento.SelectedValue
                            End If
                        Else
                            obeMetodizado.FlgBPE = 1
                            obeMetodizado.Segmento = Nothing
                        End If

                        'ADD XT8442 ADR 19/10/2018 INICIO
                        obeMetodizado.TipoDocumentoComplementario = dropTipoDocumentoComp.SelectedValue
                        obeMetodizado.NumeroDocumentoComplementario = txtRUCComp.Text
                        'ADD XT8442 ADR 19/10/2018 FIN
                        'ADD XT8633 INI
                        If Me.chkcovenants.Checked Then
                            obeMetodizado.ESCovenant = 1
                        Else
                            obeMetodizado.ESCovenant = 0
                        End If
                        obeMetodizado.CodFrecuenciaCov = Me.ddlMedicionCov.SelectedValue
                        'ADD XT8633 FIN

                        Dim bolRC As Boolean = obrMetodizado.agregar(obeMetodizado)
                        If bolRC Then
                            txtCodMetodizado.Text = obeMetodizado.CodMetodizado
                            CodMetodizado = obeMetodizado.CodMetodizado
                            txtCodUsuario.Text = obeMetodizado.CodUsuario
                            txtNombreUsuario.Text = obeMetodizado.NombreUsuario
                            txtFecReg.Text = obeMetodizado.FecReg
                            Dim obeGeneral As BusinessEntity.General = buscarGeneralItem(ecTablaGeneral.ESTADO_METODIZADO, obeMetodizado.Estado)
                            txtDesEstado.Text = obeGeneral.Descripcion
                            configMntAccion(ecMntPage.MODIFICAR)
                            bloquearControles(True)
                            activarCovenant(obeMetodizado.ESCovenant, obeMetodizado.CodMetodizado, obeMetodizado.CodFrecuenciaCov)
                            Me.muestraAlerta(ccALERTA_EXITO_AGREGAR & " de " & ccID_WEBUI_MNT)
                        Else
                            Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
                        End If
                    End If
                Else
                    Me.muestraAlerta(ccALERTA_ERROR_CUCLIENTE_RUC_DUPLICADO)
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Function fVerificarExistenciaCliente() As Boolean
            Dim vboolRpta As Boolean = True
            Dim obeMetodizado As New BusinessEntity.Metodizado
            Dim obeMetodizadoBus As New BusinessEntity.MetodizadoBus

            obeMetodizadoBus.CUCliente = txtCUCliente.Text
            obeMetodizadoBus.TipoDocumento = dropTipoDocumento.SelectedValue
            obeMetodizadoBus.NumeroDocumento = txtRUC.Text

            Dim obrMetodizadoBus As BusinessRules.Metodizado = New BusinessRules.Metodizado

            ' 24/01/2014 XT5022 JAVILA (CGI)
            Dim dsMetodizadoBus As New DataSet
            If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                ' ES BPE
                dsMetodizadoBus = obrMetodizadoBus.buscarClienteDuplicado(obeMetodizadoBus, 2)
            Else
                'AGREGADO 14/03/2014 XT5022 - RQUISPE (CGI)
                If CodPerfil = ecPerfil.ADMINISTRADOR Then
                    If ddlTipoBanca.SelectedValue = ecTipoBanca.BancaEmpresa Then
                        ' ES BANCA COMERCIAL
                        dsMetodizadoBus = obrMetodizadoBus.buscarClienteDuplicado(obeMetodizadoBus, 1) 'LINEA ORIGINAL.
                    ElseIf ddlTipoBanca.SelectedValue = ecTipoBanca.BancaPequenaEmpresa Then
                        dsMetodizadoBus = obrMetodizadoBus.buscarClienteDuplicado(obeMetodizadoBus, 2)
                    End If
                Else
                    dsMetodizadoBus = obrMetodizadoBus.buscarClienteDuplicado(obeMetodizadoBus, 1) 'LINEA ORIGINAL.
                End If
                'FIN RQUISPE
            End If

            If dsMetodizadoBus.Tables.Count > 0 Then

                Dim intNumReg As Integer = dsMetodizadoBus.Tables(0).Rows.Count

                If intNumReg = 0 Then
                    vboolRpta = False
                End If

            End If

            Return vboolRpta
        End Function

        Private Sub modificarMetodizado()
            Dim intCodMetodizado As Integer = CodMetodizado
            Dim obeMetodizado As BusinessEntity.Metodizado
            Try
                If Page.IsValid Then
                    'If Not fVerificarExistenciaCUCliente() Then
                    If Not fVerificarExistenciaDocumentoCliente() Then
                        obeMetodizado = New BusinessEntity.Metodizado

                        obeMetodizado.CodMetodizado = intCodMetodizado
                        obeMetodizado.CUCliente = txtCUCliente.Text
                        obeMetodizado.TipoDocumento = dropTipoDocumento.SelectedValue
                        obeMetodizado.NumeroDocumento = txtRUC.Text
                        obeMetodizado.RazonSocial = txtRazonSocial.Text.Trim
                        obeMetodizado.CodCIIU = txtCodCIIU.Text.Trim
                        obeMetodizado.CodSBS = txtCodSBS.Text.Trim
                        obeMetodizado.CodGrupoEconomico = txtCodGrupoEconomico.Text.Trim
                        obeMetodizado.NombreGrupoEconomico = txtNombreGrupoEconomico.Text.Trim
                        obeMetodizado.CodUnidad = dropUnidad.SelectedValue
                        obeMetodizado.CodMoneda = dropMoneda.SelectedValue
                        obeMetodizado.CodEjecutivo = txtCodEjecutivo.Text
                        obeMetodizado.NombreEjecutivo = txtNombreEjecutivo.Text
                        obeMetodizado.CodMonedaImpresion = dropMonedaImpresion.SelectedValue
                        obeMetodizado.CodAnalista = txtCodAnalista.Text
                        obeMetodizado.NombreAnalista = txtNombreAnalista.Text

                        ' 22/01/2014 : XT5022 - JAVILA (CGI)
                        obeMetodizado.Segmento = ddlSegmento.SelectedValue

                        'srt_2017-02160
                        'Dim obeUsuario As BusinessEntity.Usuario
                        'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                        'Dim strCodUsuario As String = DatosGlobal.sUser

                        'obeUsuario = obrUsuario.leer(strCodUsuario)
                        'obeMetodizado.CodUsuario = obeUsuario.CodUsuario
                        'obeMetodizado.NombreUsuario = obeUsuario.Nombre

                        Dim strCodUsuario As String = retornaUsuarioSesion()
                        Dim strNomUsuario As String = retornaNombreUsuarioSesion()
                        obeMetodizado.CodUsuario = strCodUsuario
                        obeMetodizado.NombreUsuario = strNomUsuario

                        'ADD XT8442 ADR 19/10/2018 INICIO
                        obeMetodizado.TipoDocumentoComplementario = dropTipoDocumentoComp.SelectedValue
                        obeMetodizado.NumeroDocumentoComplementario = txtRUCComp.Text

                        'ADD XT8442 ADR 19/10/2018 FIN
                        'XT8633 INI
                        If Me.chkcovenants.Checked Then
                            obeMetodizado.ESCovenant = 1
                        Else
                            obeMetodizado.ESCovenant = 0
                        End If
                        obeMetodizado.CodFrecuenciaCov = Me.ddlMedicionCov.SelectedValue
                        'XT8633 FIN

                        Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                        Dim bolRC As Boolean = obrMetodizado.modificar(obeMetodizado)
                        If bolRC Then
                            txtCodUsuario.Text = obeMetodizado.CodUsuario
                            txtNombreUsuario.Text = obeMetodizado.NombreUsuario
                            activarCovenant(obeMetodizado.ESCovenant, intCodMetodizado, obeMetodizado.CodFrecuenciaCov)
                            configMntAccion(ecMntPage.MODIFICAR)
                            bloquearControles(True)
                            Me.muestraAlerta(ccALERTA_EXITO_MODIFICAR & " de " & ccID_WEBUI_MNT)
                        Else
                            Me.muestraAlerta(ccALERTA_ERROR_MODIFICAR & " de " & ccID_WEBUI_MNT)
                        End If
                    Else
                        Me.txtCUCliente.Text = ""
                        Me.muestraAlerta(ccALERTA_ERROR_CUCLIENTE_RUC_DUPLICADO)
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_MODIFICAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Function fVerificarExistenciaCUCliente() As Boolean
            Dim vboolRpta As Boolean = True

            If Me.txtCUCliente.Text <> String.Empty Then
                Dim obeMetodizadoBus As New BusinessEntity.MetodizadoBus
                obeMetodizadoBus.CUCliente = Me.txtCUCliente.Text
                obeMetodizadoBus.NumeroDocumento = String.Empty

                Dim obrMetodizadoBus As BusinessRules.Metodizado = New BusinessRules.Metodizado

                Dim dsMetodizadoBus As DataSet ' = obiMetodizadoBus.buscar(obeMetodizadoBus)
                If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                    dsMetodizadoBus = obrMetodizadoBus.buscarBPE(obeMetodizadoBus)
                Else
                    dsMetodizadoBus = obrMetodizadoBus.buscarNoBPE(obeMetodizadoBus)
                End If

                vboolRpta = (dsMetodizadoBus.Tables(0).Rows.Count() > 0)
            Else
                vboolRpta = False
            End If

            Return vboolRpta
        End Function

        Private Function fVerificarExistenciaDocumentoCliente() As Boolean
            Dim vboolRpta As Boolean = True
            Dim intCodMetodizado As Integer = CodMetodizado

            If ((Me.txtRUC.Text <> String.Empty) And (dropTipoDocumento.SelectedValue <> 0)) Then
                Dim obeMetodizadoBus As New BusinessEntity.MetodizadoBus

                obeMetodizadoBus.TipoDocumento = Me.dropTipoDocumento.SelectedValue
                obeMetodizadoBus.NumeroDocumento = Me.txtRUC.Text

                Dim obrMetodizadoBus As BusinessRules.Metodizado = New BusinessRules.Metodizado

                Dim dsMetodizadoBus As DataSet

                If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                    dsMetodizadoBus = obrMetodizadoBus.buscarBPE(obeMetodizadoBus)
                Else
                    dsMetodizadoBus = obrMetodizadoBus.buscarNoBPE(obeMetodizadoBus)
                End If

                Dim dvwOtros As New DataView(dsMetodizadoBus.Tables(0), "CodMetodizado <> " + CType(intCodMetodizado, String), String.Empty, DataViewRowState.CurrentRows)

                ' vboolRpta = (dsMetodizadoBus.Tables(0).Rows.Count() > 0)
                vboolRpta = (dvwOtros.Count() > 0)
            Else
                vboolRpta = False
            End If

            Return vboolRpta
        End Function

        Private Sub inicializarControles()
            txtCodMetodizado.Text = String.Empty
            txtFecReg.Text = String.Empty
            txtDesEstado.Text = String.Empty
            txtCUCliente.Text = String.Empty
            txtRUC.Text = String.Empty
            txtRazonSocial.Text = String.Empty
            txtCodCIIU.Text = String.Empty
            txtNombreCIIU.Text = String.Empty
            txtCodGrupoEconomico.Text = String.Empty
            txtNombreGrupoEconomico.Text = String.Empty
            txtCodSBS.Text = String.Empty

            If dropTipoDocumento.Items.Count > 0 Then dropTipoDocumento.SelectedIndex = 0
            If dropMoneda.Items.Count > 0 Then dropMoneda.SelectedIndex = 0
            If dropUnidad.Items.Count > 0 Then dropUnidad.SelectedIndex = 0

            Dim obeParametro As BusinessEntity.Parametro = buscarParametro("MET_COD_MONEDA")
            dropMoneda.SelectedValue = obeParametro.Valor1

            obeParametro = buscarParametro("MET_COD_UNIDAD")
            dropUnidad.SelectedValue = obeParametro.Valor1

            txtCodEjecutivo.Text = String.Empty
            txtNombreEjecutivo.Text = String.Empty
            txtCodAnalista.Text = String.Empty
            txtNombreAnalista.Text = String.Empty
            txtCodUsuario.Text = String.Empty
            txtNombreUsuario.Text = String.Empty

            For intIndex As Integer = dgrdMntRec.Columns.Count To 2 Step -1
                dgrdMntRec.Columns.RemoveAt(intIndex - 1)
            Next

            dgrdMntRec.DataSource = New DataTable
            dgrdMntRec.DataKeyField = "CodCuenta"
            dgrdMntRec.Width = New Unit(ccANCHO_DGRID_PERIODO, UnitType.Pixel)
            dgrdMntRec.DataBind()
            ltlNumRegRec.Text = 0
            txtFuncionFx.Text = String.Empty

            hidPeriodoCuenta.Value = String.Empty

            hidCuentaLibre.Value = String.Empty

            'I-XT9194 18/02/2020
            hidCuentaLibreCovenants.Value = String.Empty
            'F-XT9194 18/02/2020

            TabActivo = Int32.Parse(ecTabMntMetodizado.RECONCILIACION)
            TabRefrescar = Int32.Parse(ecTabMntMetodizado.RECONCILIACION)
            MntAccion = Int32.Parse(ecMntPage.AGREGAR)
            CodMetodizado = 0
            VSPeriodosFiltrados = Nothing
            PeriodoFiltrado = String.Empty

            bloquearControles(False)
            'XT8633 INI
            chkcovenants.Checked = False
            imgRatios.Visible = False
            ddlMedicionCov.Attributes.Add("style", "display:none;")
            lblfrecuencia.Attributes.Add("style", "display:none;")
            'XT8633 FIN

            configMntAccion(ecMntPage.AGREGAR)
        End Sub

        Private Sub ibtnBusCliCU_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBusCliCU.Click

            pBuscarCliCU()

        End Sub

        Private Sub pBuscarCliCU()
            Me.hidRUC_CU.Value = String.Empty
            If dropTipoDocumento.SelectedValue <> ecTipoDocumentoCliente.EMPRESA_RELACIONADA Then
                buscarCliente(ecTipoDocumento.CODIGO_UNICO)
                If MntAccion = Int32.Parse(ecMntPage.MODIFICAR) And (txtCodMetodizado.Text.Trim <> String.Empty) Then
                    refrescarTabControl(Int32.Parse(ecTabMntMetodizado.RECONCILIACION))
                End If
            End If
        End Sub

        Private Sub ibtnBusCliRUC_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnBusCliRUC.Click
            pBuscarCliRUC()
        End Sub

        Private Sub pBuscarCliRUC()
            If dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.Sin_Documento Then
                If txtRUC.Text.Trim <> String.Empty Then
                    Dim strRUC = txtRUC.Text.Trim.PadLeft(8, "0")
                    txtRUC.Text = strRUC
                    Me.muestraAlerta(ccALERTA_SELECCIONAR_TIPO_DOCUMENTO)
                End If
            ElseIf dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.EMPRESA_RELACIONADA Then

            ElseIf dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.RUC Then
                buscarCliente(ecTipoDocumento.RUC)
                If MntAccion = Int32.Parse(ecMntPage.MODIFICAR) And (txtCodMetodizado.Text.Trim <> String.Empty) Then
                    refrescarTabControl(Int32.Parse(ecTabMntMetodizado.RECONCILIACION))
                End If
            ElseIf dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.DNI Then
                buscarCliente(3) '3=BUSQUEDA POR DNI
                If MntAccion = Int32.Parse(ecMntPage.MODIFICAR) And (txtCodMetodizado.Text.Trim <> String.Empty) Then
                    refrescarTabControl(Int32.Parse(ecTabMntMetodizado.RECONCILIACION))
                End If
            End If
        End Sub

        Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            If dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.Sin_Documento Then
                RequiredFieldValidator1.Enabled = False
            Else
                If dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.EMPRESA_RELACIONADA Then
                    vreqFecPeriodo.Enabled = False
                    RequiredFieldValidator1.Enabled = False
                Else
                    If txtRUC.Text <> String.Empty OrElse txtCUCliente.Text <> String.Empty Then
                        If txtRUC.Text <> String.Empty Then
                            If dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.DNI Then
                                If fVerificarExisteDNI() Then
                                    vreqFecPeriodo.Enabled = False
                                End If
                            Else
                                If fVerificarExisteRUC() Then
                                    vreqFecPeriodo.Enabled = False
                                End If
                            End If
                        End If
                        If txtCUCliente.Text <> String.Empty Then
                            If fVerificarExisteCU() Then
                                RequiredFieldValidator1.Enabled = False
                            End If
                        End If
                    Else
                        vreqFecPeriodo.Enabled = True
                        RequiredFieldValidator1.Enabled = True
                    End If
                End If
            End If

            ' 20-01-2014 : XT5022 - JAVILA
            If ddlSegmento.SelectedValue = 0 Then
                vreqSegmento.Enabled = True
            Else
                vreqSegmento.Enabled = False
            End If


            If fVerificarGrabar() Then
                If fVerificarExisteCliente() Then
                    If MntAccion = Int32.Parse(ecMntPage.AGREGAR) Or (txtCodMetodizado.Text = String.Empty) Then
                        agregarMetodizado()
                    ElseIf MntAccion = Int32.Parse(ecMntPage.MODIFICAR) And (txtCodMetodizado.Text.Trim <> String.Empty) Then
                        modificarMetodizado()
                        refrescarTabControl(Int32.Parse(ecTabMntMetodizado.RECONCILIACION))
                    End If
                Else
                    If MntAccion = Int32.Parse(ecMntPage.MODIFICAR) And (txtCodMetodizado.Text.Trim <> String.Empty) Then
                        cargarDatos(False)
                        refrescarTabControl(Int32.Parse(ecTabMntMetodizado.RECONCILIACION))
                    End If
                End If
            Else
                'cargarDatos(False)
                refrescarTabControl(Int32.Parse(ecTabMntMetodizado.RECONCILIACION))
            End If
        End Sub

        Private Function fVerificarGrabar()
            Dim vbolRpta As Boolean = False

            'srt_2017-02160
            'Dim strCodUsuario As String = DatosGlobal.sUser
            'Dim obeUsuario As BusinessEntity.Usuario
            'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
            'obeUsuario = obrUsuario.leer(strCodUsuario)

            Dim strCodUsuario As String = retornaUsuarioSesion()
            Dim intPerfil As Integer = fRetornaPerfilUsuario()

            'comentado x rquispe 29/04/2014 para que saque el perfil de querystring y no del usuario
            ' If obeUsuario.CodPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
            ' If DatosGlobal.nPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
            If intPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
                Me.muestraAlerta("Usted no tiene permisos suficientes para realizar esta operación.")
            Else
                ' 30/01/2014 : XT5022 - JAVILA (CGI) 
                '   If obeUsuario.CodPerfil = ecPerfil.ADMINISTRADOR Then
                'comentado x rquispe 29/04/2014 para que saque el perfil de querystring y no del usuario
                'If datosGlobal.nPerfil = ecPerfil.ADMINISTRADOR Then
                If intPerfil = ecPerfil.ADMINISTRADOR Then
                    If ddlTipoBanca.SelectedValue = 0 Then
                        Me.muestraAlerta("Seleccione tipo de banca.")
                    Else
                        '13/03/2014 RQUISPE, Valida si selecciona bpe no selecione tipo de documento = 4 (empresa relacionada)
                        If ddlTipoBanca.SelectedValue = ecTipoBanca.BancaPequenaEmpresa Then

                            If Me.ddlSegmento.SelectedValue = 0 Then   '17/03/2014 RQUISPE, Valida si selecciona un segmento
                                Me.muestraAlerta("Seleccione un segmento.")
                            Else
                                If dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.EMPRESA_RELACIONADA Then
                                    Me.muestraAlerta("No puede seleccionar como tipo de documento a EMPRESA RELACIONADA para un cliente de BPE")
                                Else
                                    vbolRpta = True
                                End If
                            End If
                        Else
                            vbolRpta = True
                        End If
                        'FIN AGREGADO RQUISPE
                    End If
                Else

                    '17/03/2014 RQUISPE, Valida si selecciona un segmento
                    'comentado x rquispe 29/04/2014 para que saque el perfil de querystring y no del usuario
                    '   If obeUsuario.CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or obeUsuario.CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                    'If datosGlobal.nPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or datosGlobal.nPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                    If intPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or intPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                        If Me.ddlSegmento.SelectedValue = 0 Then
                            Me.muestraAlerta("Seleccione un segmento.")
                        Else
                            vbolRpta = True
                        End If
                    Else
                        vbolRpta = True 'linea original
                    End If
                    'FIN AGREGADO RQUISPE
                End If
            End If

            'XT8633 INI
            If chkcovenants.Checked Then
                If ddlMedicionCov.SelectedValue = 0 Then
                    Me.muestraAlerta("Debe de seleccionar una frecuencia de Medición de Covenants.")
                    vbolRpta = False
                Else
                    vbolRpta = True
                End If
            End If
            'XT8633 FIN

            Return vbolRpta
        End Function

        Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
            inicializarControles()
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            Dim strUrl As String = "busMetodizado.aspx"
            Response.Redirect(strUrl)
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub

        Private Sub dropTipoDocumento_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dropTipoDocumento.SelectedIndexChanged
            'I-XT9104 - 09/03/2020
            Dim sbScriptCliente As System.Text.StringBuilder

            cargaMonedas()
            cargaMonedasImpresion()

            refrescarTabControl(TabRefrescar)

            sbScriptCliente = New StringBuilder("<script language=""Javascript"" type=""text/javascript"">")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("<!--")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("f_VerificarTipoDocumento(document.getElementById('dropTipoDocumento'));")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("// -->")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("</script>")

            ScriptManager.RegisterStartupScript(Me, GetType(Page), "__VerificarTipoDocumento", sbScriptCliente.ToString(), False)
            'F-XT9104 - 09/03/2020
        End Sub

        Private Sub txtCUCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCUCliente.TextChanged
            If txtCUCliente.Text.Trim <> "" Then
                pBuscarCliCU()
            Else
                Me.hidRUC_CU.Value = String.Empty
            End If
        End Sub

        Private Sub txtRUC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRUC.TextChanged
            Dim vbolExisteCU As Boolean = False

            If txtCUCliente.Text.Trim <> "" Then
                vbolExisteCU = fVerificarExisteCU()
            Else
                vbolExisteCU = True
            End If

            If vbolExisteCU And txtRUC.Text.Trim <> "" Then
                pBuscarCliRUC()
            End If
        End Sub

        'Private Function fVerificarExisteCliente() As Boolean
        '    Dim vboolRpta As Boolean

        '    Dim vboolTieneCU As Boolean = (txtCUCliente.Text.Trim <> String.Empty)
        '    Dim vboolTieneTipoDocumento As Boolean = (dropTipoDocumento.SelectedValue <> 0)
        '    Dim vboolTieneDocumento As Boolean = (txtRUC.Text.Trim <> String.Empty)
        '    Dim vboolDocumentoEsRUC As Boolean = (dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.RUC)
        '    Dim vboolDocumentoEsEMPRESA_RELACIONADA As Boolean = (dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.EMPRESA_RELACIONADA)

        '    Dim vboolCUValido As Boolean = False
        '    Dim vboolRUCValido As Boolean = False

        '    If vboolTieneCU Then
        '        vboolCUValido = fVerificarExisteCU()
        '    End If

        '    If vboolTieneDocumento And vboolDocumentoEsRUC Then
        '        vboolRUCValido = fVerificarExisteRUC()
        '    End If

        '    vboolRpta = False
        '    If vboolTieneCU Then
        '        If vboolCUValido Then
        '            If vboolDocumentoEsRUC Then
        '                If vboolRUCValido Then
        '                    If (Me.hidRUC_CU.Value.Trim = String.Empty) Then
        '                        vboolRpta = True
        '                    Else
        '                        If Me.hidTipoDocIdentidad_CU.Value = "2" Then
        '                            'Verificamos que el RUC coincida con el que se tenga en la BD Rnt...
        '                            vboolRpta = (Me.hidRUC_CU.Value = Me.txtRUC.Text)
        '                        Else
        '                            vboolRpta = True
        '                        End If

        '                        If vboolRpta = False Then
        '                            Me.muestraAlerta("El RUC ingresado no coincide con el RUC correspondiente al Codigo Unico ingresado." + "\n La acción ha sido abortada.")
        '                        End If
        '                    End If
        '                Else
        '                    Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " correspondiente al documento ingresado." + "\n La acción ha sido abortada.")
        '                End If
        '            Else
        '                vboolRpta = True
        '            End If
        '        Else
        '            Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & "  correspondiente al codigo unico ingresado." + "\n La acción ha sido abortada.")
        '        End If
        '    Else
        '        If vboolDocumentoEsRUC Then
        '            vboolRpta = vboolRUCValido
        '            If vboolRpta = False Then
        '                Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " correspondiente al documento ingresado." + "\n La acción ha sido abortada.")
        '            End If
        '        ElseIf vboolDocumentoEsEMPRESA_RELACIONADA Then
        '            vboolRpta = True
        '        Else
        '            vboolRpta = (vboolTieneTipoDocumento And vboolTieneDocumento)
        '            If vboolRpta = False Then
        '                If vboolTieneTipoDocumento = False Then
        '                    Me.muestraAlerta(ccALERTA_SELECCIONAR_TIPO_DOCUMENTO)
        '                ElseIf vboolTieneDocumento = False Then
        '                    Me.muestraAlerta(ccALERTA_INGRESAR_DOCUMENTO)
        '                End If
        '            End If
        '        End If
        '    End If

        '    Return vboolRpta
        'End Function

        Private Function fVerificarExisteCliente() As Boolean
            Dim vboolRpta As Boolean

            Dim vboolTieneCU As Boolean = (txtCUCliente.Text.Trim <> String.Empty)
            Dim vboolTieneTipoDocumento As Boolean = (dropTipoDocumento.SelectedValue <> 0)
            Dim vboolTieneDocumento As Boolean = (txtRUC.Text.Trim <> String.Empty)
            Dim vboolDocumentoEsRUC As Boolean = (dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.RUC)
            Dim vboolDocumentoEsEMPRESA_RELACIONADA As Boolean = (dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.EMPRESA_RELACIONADA)

            Dim vboolCUValido As Boolean = False
            Dim vboolRUCValido As Boolean = False

            If vboolTieneCU Then
                vboolCUValido = fVerificarExisteCU()
            End If

            If vboolTieneDocumento And vboolDocumentoEsRUC Then
                vboolRUCValido = fVerificarExisteRUC()
            End If

            vboolRpta = False

            If vboolTieneCU Then
                If vboolCUValido Then
                    If vboolDocumentoEsRUC Then
                        If txtRUC.Text.Trim <> String.Empty Then
                            If vboolRUCValido Then
                                If (Me.hidRUC_CU.Value.Trim = String.Empty) Then
                                    vboolRpta = True
                                Else
                                    If Me.hidTipoDocIdentidad_CU.Value = "2" Then
                                        'Verificamos que el RUC coincida con el que se tenga en la BD Rnt...
                                        vboolRpta = (Me.hidRUC_CU.Value = Me.txtRUC.Text)
                                    Else
                                        vboolRpta = True
                                    End If

                                    If vboolRpta = False Then
                                        Me.muestraAlerta("El RUC ingresado no coincide con el RUC correspondiente al Codigo Unico ingresado." + "\n La acción ha sido abortada.")
                                    End If
                                End If
                            Else
                                Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " correspondiente al documento ingresado." + "\n La acción ha sido abortada.")
                            End If
                        Else
                            vboolRpta = True
                        End If
                    Else
                        vboolRpta = True
                    End If
                Else
                    Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & "  correspondiente al codigo unico ingresado." + "\n La acción ha sido abortada.")
                End If
            Else
                If vboolDocumentoEsRUC Then
                    vboolRpta = vboolRUCValido
                    'If vboolRpta = False Then
                    '    Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " correspondiente al documento ingresado." + "\n La acción ha sido abortada.")
                    'End If
                ElseIf vboolDocumentoEsEMPRESA_RELACIONADA Then
                    vboolRpta = True
                Else
                    vboolRpta = (vboolTieneTipoDocumento And vboolTieneDocumento)
                    If vboolRpta = False Then
                        If vboolTieneTipoDocumento = False Then
                            Me.muestraAlerta(ccALERTA_SELECCIONAR_TIPO_DOCUMENTO)
                        ElseIf vboolTieneDocumento = False Then
                            Me.muestraAlerta(ccALERTA_INGRESAR_DOCUMENTO)
                        End If
                    End If
                End If
            End If

            Return vboolRpta
        End Function

        Private Function fVerificarExisteCU() As Boolean
            Dim vboolRpta As Boolean = False
            Dim strCUCliente As String = txtCUCliente.Text.Trim
            'Dim obrCliente As BusinessRules.Cliente = New BusinessRules.Cliente
            'Dim obeCliente As BusinessEntity.Cliente

            Dim obeClienteRM As BusinessEntity.ClienteRM

            Try

                strCUCliente = strCUCliente.PadLeft(10, "0")
                txtCUCliente.Text = strCUCliente

                'MEJORAS CEF FASE 2
                'obeCliente = obrCliente.leer(strCUCliente)
                Using service As New CEF.BusinessRules.ServiceExternalLogic()
                    obeClienteRM = service.ClienteRMPorCodigoUnico(strCUCliente, Assemblys.retornaDatoConfig(constantesCommon.wsFCDRM))
                End Using

                'If Not IsNothing(obeCliente) Then
                If Not String.IsNullOrEmpty(obeClienteRM.Codigounico) Then
                    vboolRpta = True
                    'Me.hidTipoDocIdentidad_CU.Value = obeCliente.TipoDocumentoIdentidad
                    'If obeCliente.TipoDocumentoIdentidad = "2" Then 'RUC
                    Me.hidTipoDocIdentidad_CU.Value = obeClienteRM.Codigotipodocumento
                    If obeClienteRM.Codigotipodocumento = "2" Then
                        'Me.hidRUC_CU.Value = obeCliente.NumeroDocumentoIdentidad
                        Me.hidRUC_CU.Value = obeClienteRM.Numerodocumento
                    Else
                        Me.hidRUC_CU.Value = String.Empty
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " de cliente")
            End Try
            Return vboolRpta
        End Function

        Private Function fVerificarExisteRUC() As Boolean
            Dim vboolRpta As Boolean = False

            Dim strCUCliente As String = txtCUCliente.Text.Trim
            Dim strRUC As String = txtRUC.Text.Trim
            'Dim obrCliente As BusinessRules.Cliente = New BusinessRules.Cliente
            'Dim obeCliente As BusinessEntity.Cliente
            Dim obrCIIU As BusinessRules.CIIU = New BusinessRules.CIIU
            Dim obeCIIU As BusinessEntity.CIIU

            Dim obeClienteRM As BusinessEntity.ClienteRM

            Try
                strRUC = strRUC.PadLeft(11, "0")
                txtRUC.Text = strRUC

                'MEJORAS CEF FASE 2
                'obeCliente = obrCliente.buscarXNumeroDocumento(Int32.Parse(ecTipoDocumento.RUC).ToString(), strRUC)
                Using service As New CEF.BusinessRules.ServiceExternalLogic()
                    obeClienteRM = service.ClienteRMPorDocumentoIdentidad(Int32.Parse(ecTipoDocumento.RUC).ToString(), strRUC, Assemblys.retornaDatoConfig(constantesCommon.wsFCDRM))
                End Using

                'If Not IsNothing(obeCliente) Then
                If Not String.IsNullOrEmpty(obeClienteRM.Codigounico) Then
                    vboolRpta = True
                Else
                    Dim obrOmaes As BusinessRules.Cliente = New BusinessRules.Cliente

                    Dim dsOmaes As DataSet = obrOmaes.leerRegOmaesSunat(strRUC)


                    If Not IsNothing(dsOmaes) Then 'AGREGADO POR RQUISPE 19/03/2014, PRODUCE ERROR, NO HAY CONEXION CON LA BD
                        Dim intNumReg As Integer = dsOmaes.Tables(0).Rows.Count
                        If (intNumReg > 0) Then
                            vboolRpta = True
                        End If
                    Else
                        vboolRpta = False
                    End If

                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " de cliente")
            End Try

            Return vboolRpta
        End Function

        Private Function fVerificarExisteDNI() As Boolean
            Dim vboolRpta As Boolean = False

            Dim strCUCliente As String = txtCUCliente.Text.Trim
            Dim strRUC As String = txtRUC.Text.Trim
            'Dim obrCliente As BusinessRules.Cliente = New BusinessRules.Cliente
            'Dim obeCliente As BusinessEntity.Cliente
            Dim obrCIIU As BusinessRules.CIIU = New BusinessRules.CIIU
            Dim obeCIIU As BusinessEntity.CIIU

            Dim obeClienteRM As BusinessEntity.ClienteRM

            Try
                strRUC = strRUC.PadLeft(8, "0")
                txtRUC.Text = strRUC
                'MEJORAS CEF FASE 2
                'obeCliente = obrCliente.buscarXNumeroDocumento(1.ToString(), strRUC)
                Using service As New CEF.BusinessRules.ServiceExternalLogic()
                    obeClienteRM = service.ClienteRMPorDocumentoIdentidad(1.ToString(), strRUC, Assemblys.retornaDatoConfig(constantesCommon.wsFCDRM))
                End Using

                'If Not IsNothing(obeCliente) Then
                If Not String.IsNullOrEmpty(obeClienteRM.Codigounico) Then
                    vboolRpta = True
                Else
                    Dim obrOmaes As BusinessRules.Cliente = New BusinessRules.Cliente

                    Dim dsOmaes As DataSet = obrOmaes.leerRegOmaesSunat(strRUC)


                    If Not IsNothing(dsOmaes) Then 'AGREGADO POR RQUISPE 19/03/2014, PRODUCE ERROR, NO HAY CONEXION CON LA BD
                        Dim intNumReg As Integer = dsOmaes.Tables(0).Rows.Count
                        If (intNumReg > 0) Then
                            vboolRpta = True
                        End If
                    Else
                        vboolRpta = False
                    End If

                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " de cliente")
            End Try

            Return vboolRpta
        End Function

        'Private Sub lnkGrabarRecOpe2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkGrabarRecOpe2.Click
        '    Try
        '        If lnkGrabarRecOpe2.Text.Trim.ToUpper = "VALIDAR" Then
        '            Dim obiCorridaMetodizado As BusinessInterface.ICorridaMetodizado
        '            Dim obeCorridaMetodizado As New BusinessEntity.CorridaMetodizado
        '            Dim obePeriodosCorrida As New BusinessEntity.PeriodoCorridaLst
        '            With obeCorridaMetodizado
        '                .CodMetodizado = CodMetodizado
        '                .CodUsuarioReg = DatosGlobal.sUser
        '                .FecReg = Now
        '                .Flag = 1
        '                .PeriodosCorrida = fRetornaPeriodosCorrida(.CodCorrida)
        '            End With
        '        End If
        '    Catch ex As Exception
        '        Util.grabarErrorLog(ex)
        '        Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de corrida metodizado")
        '    End Try
        'End Sub

        'Private Function fRetornaPeriodosCorrida(ByVal pshoCodCorrida As Short) As BusinessEntity.PeriodoCorridaLst
        '    Dim obePeriodoCorridaLst As New PeriodoCorridaLst

        '    For Each obePeriodo As BusinessEntity.Periodo In VSPeriodosFiltrados
        '        Dim obePeriodoCorrida As New BusinessEntity.PeriodoCorrida
        '        obePeriodoCorrida.CodMetodizado = CodMetodizado
        '        obePeriodoCorrida.CodCorrida = pshoCodCorrida
        '        obePeriodoCorrida.CodPeriodo = obePeriodo.CodPeriodo
        '        obePeriodoCorridaLst.Add(obePeriodoCorrida)
        '    Next

        '    Return obePeriodoCorridaLst
        'End Function

        'I-XT9104 - 18/02/2020
        Private Sub cargaCuentaLibre()
            Dim objCuenta As BusinessRules.Cuenta = New BusinessRules.Cuenta()
            Dim dsCuenta As DataSet

            dsCuenta = objCuenta.listar(3, ecTipoCuenta.CUENTA_LIBRE)

            For Each drCuenta As DataRow In dsCuenta.Tables(0).Rows
                hidCuentaLibreCuenta.Value += drCuenta("CodCuenta").ToString() & ";" & drCuenta("Descripcion").ToString() & "|"
            Next
        End Sub
        'F-XT9104 - 18/02/2020

        'I-XT9104 - 10/03/2020
        Private Sub cargaMonedas()
            Dim dstMoneda As DataSet = Nothing

            If (dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.EMPRESA_RELACIONADA) Then
                dstMoneda = buscarGeneralTabla(ecTablaGeneral.MONEDA)
            Else
                dstMoneda = buscarGeneralTabla(ecTablaGeneral.MONEDAEMPRELACIONADA)
            End If

            dropMoneda.DataSource = dstMoneda
            dropMoneda.DataTextField = "Descripcion"
            dropMoneda.DataValueField = "CodItem"
            dropMoneda.DataBind()
        End Sub

        Private Sub cargaMonedasImpresion()
            Dim dstMonedaImpresion As DataSet = Nothing
            Dim dstMoneda As DataSet = Nothing
            Dim row As DataRow = Nothing

            If (dropTipoDocumento.SelectedValue = ecTipoDocumentoCliente.EMPRESA_RELACIONADA) Then
                dstMonedaImpresion = buscarGeneralTabla(ecTablaGeneral.MONEDAIMPEMPRELACIONADA)
                dstMoneda = buscarGeneralTabla(ecTablaGeneral.MONEDA)

                If Not (dstMonedaImpresion.Tables(0).Select("CodItem = " + dropMoneda.SelectedValue).Length > 0) Then
                    row = dstMoneda.Tables(0).Select("CodItem = " + dropMoneda.SelectedValue)(0)
                    dstMonedaImpresion.Tables(0).ImportRow(row)
                End If
            Else
                dstMonedaImpresion = buscarGeneralTabla(ecTablaGeneral.MONEDAEMPRELACIONADA)
            End If

            dropMonedaImpresion.DataSource = dstMonedaImpresion
            dropMonedaImpresion.DataTextField = "Descripcion"
            dropMonedaImpresion.DataValueField = "CodItem"
            dropMonedaImpresion.DataBind()
        End Sub
        'F-XT9104 - 10/03/2020

        Protected Sub dropMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dropMoneda.SelectedIndexChanged
            'I-XT9104 - 09/03/2020
            Dim sbScriptCliente As System.Text.StringBuilder

            cargaMonedasImpresion()

            refrescarTabControl(TabRefrescar)

            sbScriptCliente = New StringBuilder("<script language=""Javascript"" type=""text/javascript"">")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("<!--")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("f_VerificarTipoDocumento(document.getElementById('dropTipoDocumento'));")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("// -->")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("</script>")

            ScriptManager.RegisterStartupScript(Me, GetType(Page), "__VerificarTipoDocumento", sbScriptCliente.ToString(), False)
            'F-XT9104 - 09/03/2020
        End Sub

        'I-XT9104 - 28/04/2020
        Private Function valMuestraMensaje(ByVal intCodMetodizado As Integer) As String
            Dim result As String
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            Dim dsCovenantFormula As DataSet = obrMetodizado.listarDetalleCovenant(1, intCodMetodizado)

            If chkcovenants.Checked = True And Not dsCovenantFormula.Tables(0).Rows.Count > 0 Then
                result = "alert('El Metodizado no cuenta con fórmula de covenants'); "
            Else
                result = ""
            End If

            Return result
        End Function
        'F-XT9104 - 28/04/2020
    End Class
End Namespace