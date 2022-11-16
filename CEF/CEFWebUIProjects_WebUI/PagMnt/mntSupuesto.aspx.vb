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
Imports System.Text
Imports CEF.Common
Imports System.Reflection


Namespace CEF.WebUI

    Partial Class mntSupuesto
        Inherits PageBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents spnAuditor As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents hidImporteSupuesto As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents hidCadenaImporte As System.Web.UI.HtmlControls.HtmlInputHidden
        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

        Private Const ccID_WEBUI_MNT As String = "Supuesto"
        Private Const ccANCHO_DGRID_PERIODO As Short = 310
        Private Const ccANCHO_COLUMNA_PERIODO As Short = 80
        Private Const ccINICIO_COLUMNA_PROYECTADO As Short = 1

        Private Property MntAccion() As Integer
            Get
                Return (hidMntAccion.Value)
            End Get
            Set(ByVal Value As Integer)
                hidMntAccion.Value = Value
            End Set
        End Property

        Private Property CodSupuesto() As Integer
            Get
                Return (hidCodSupuesto.Value)
            End Get
            Set(ByVal Value As Integer)
                hidCodSupuesto.Value = Value
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

        Private Property CodPeriodoAnterior() As Integer
            Get
                Return (hidCodPeriodoAnterior.Value)
            End Get
            Set(ByVal Value As Integer)
                hidCodPeriodoAnterior.Value = Value
            End Set
        End Property

        ' 30/01/2014 : XT5022 - JAVILA (CGI)'
        ' CODIGO DE PERFIL DEL USUARIO LOGUEADO
        Public ReadOnly Property CodPerfil() As Integer
            Get
                'srt_2017-02160
                'Dim strCodUsuario As String = DatosGlobal.sUser
                'Dim obeUsuario As BusinessEntity.Usuario
                'obeUsuario = Util.obtenerUsuario(strCodUsuario)

                'Return obeUsuario.CodPerfil

                Dim intPerfil As Integer = fRetornaPerfilUsuario()
                Return intPerfil
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
            Private lTitulo As String
            Private lFecProyectado As DateTime

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

            Public Property Titulo() As String
                Get
                    Return Me.lTitulo
                End Get
                Set(ByVal Value As String)
                    Me.lTitulo = Value
                End Set
            End Property

            Public Property FecProyectado() As DateTime
                Get
                    Return Me.lFecProyectado
                End Get
                Set(ByVal Value As DateTime)
                    Me.lFecProyectado = Value
                End Set
            End Property

            Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements ITemplate.InstantiateIn
                container.EnableViewState = False
                Select Case Me.lTemplateType
                    Case ListItemType.Header
                        Dim lc As New Literal
                        lc.Text = cabecera(Me.lTitulo, Me.lFecProyectado)
                        container.Controls.Add(lc)
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

            Private Function cabecera(ByVal pstrTitulo As String, ByVal pdteFecPeriodoProyectado As DateTime) As String
                Dim sbHtml As StringBuilder = New StringBuilder
                sbHtml.Append("<TABLE class=""CabeceraRegistro"">")
                sbHtml.Append("<TR><TD>" + pstrTitulo + "</TD></TR>")
                sbHtml.Append("<TR><TD>")
                sbHtml.Append(pdteFecPeriodoProyectado.ToShortDateString)
                sbHtml.Append("</TD></TR>")
                sbHtml.Append("</TABLE>")
                Return (sbHtml.ToString())
            End Function
        End Class

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        cargarScript()
            '        cargarDatos()
            '    Else
            '        inicializarControlesPorScript()
            '    End If
            '    cargarAttributes()
            'End If

            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargarScript()
                    cargarDatos()
                Else
                    inicializarControlesPorScript()
                End If
                cargarAttributes()
            End If
        End Sub

        Private Sub cargarScript()
            imgImprimir.Attributes.Add("onClick", "javascript:window.print();")
            lnkImprimir.Attributes.Add("url", "javascript:window.print();")
            imgCerrar.Attributes("onclick") = "javascript:window.close();"
            txtDescripcion.Attributes.Add("onblur", "javascript:f_ValidaExisteEscenarioDuplicado();")
            txtFuncionFx.Attributes.Add("onkeypress", "javascript:if (event.keyCode == 13) {f_CalculadoraFx(this); event.returnValue = false;} else f_ValidarIngFx(this);")
            txtFuncionFx.Attributes.Add("onblur", "javascript:f_CalculadoraFx(this);")

            'Añadir atributo readonly a textbox
            txtRazonSocial.Attributes.Add("readonly", "readonly")
            txtFecPeriodo.Attributes.Add("readonly", "readonly")
            txtDesTipoEeff.Attributes.Add("readonly", "readonly")
            txtDesAuditor.Attributes.Add("readonly", "readonly")
            txtMoneda.Attributes.Add("readonly", "readonly")
            txtUnidad.Attributes.Add("readonly", "readonly")
            txtFuncionFx.Attributes.Add("readonly", "readonly")
        End Sub

        Private Sub cargarAttributes()
            'srt_2016-02160
            'Dim strCodUsuario As String = DatosGlobal.sUser
            'Dim obeUsuario As BusinessEntity.Usuario
            'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
            'obeUsuario = obrUsuario.leer(strCodUsuario)
            Dim strCodUsuario As String = retornaUsuarioSesion()
            Dim intPerfil As Integer = fRetornaPerfilUsuario()

            'If obeUsuario.CodPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
            If intPerfil = Int32.Parse(ecPerfil.FUNCIONARIO_CONSULTA) Then
                pnlCabMetodizado.Attributes.Add("style", "display:none;")
                imgGrabarSptoProy.Attributes.Add("style", "display:none;")
                lnkGrabarSptoProy.Attributes.Add("style", "display:none;")
            Else
                pnlCabMetodizado.Attributes.Add("style", "display:'';")
                imgGrabarSptoProy.Attributes.Add("style", "display:'';")
                lnkGrabarSptoProy.Attributes.Add("style", "display:'';")
            End If
        End Sub

        Private Sub cargarDatos()
            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
            Dim intCodPeriodo As Integer = Int32.Parse(Request.Params("intCodPeriodo"))
            Dim intMaxNumProyeccion As Integer
            CodPeriodo = intCodPeriodo
            CodMetodizado = intCodMetodizado
            Dim obeParametro As BusinessEntity.Parametro = Me.buscarParametro("SUP_MAX_NUM_PROYEC")
            intMaxNumProyeccion = Int32.Parse(obeParametro.Valor1)
            For intIndice As Integer = 1 To intMaxNumProyeccion
                dropNumeroProyectado.Items.Add(New ListItem(intIndice.ToString(), intIndice.ToString()))
            Next
            obeParametro = Me.buscarParametro("SUP_COD_MONEDA")
            Dim obeGeneral As BusinessEntity.General = Me.buscarGeneralItem(ecTablaGeneral.MONEDA, Int32.Parse(obeParametro.Valor1))
            txtMoneda.Text = obeGeneral.DesCorta()
            obeParametro = Me.buscarParametro("SUP_COD_UNIDAD")
            obeGeneral = Me.buscarGeneralItem(ecTablaGeneral.UNIDAD_IMPORTE, Int32.Parse(obeParametro.Valor1))
            txtUnidad.Text = obeGeneral.Descripcion()
            cargarPeriodo()
        End Sub

        Private Sub cargarPeriodo()
            Dim intCodMetodizado As Integer = Me.CodMetodizado
            Dim intCodPeriodo As Integer = Me.CodPeriodo
            Dim obePeriodo As BusinessEntity.Periodo
            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            obeMetodizado = obrMetodizado.leer(CodMetodizado)
            If Not obeMetodizado Is Nothing Then
                txtRazonSocial.Text = obeMetodizado.RazonSocial
                obePeriodo = obrMetodizado.leerPeriodoAnterior(intCodMetodizado, intCodPeriodo)
                If Not obePeriodo Is Nothing Then
                    'Verificamos que el Periodo Anterior se cierre de año: 31/12/YYYY
                    Dim obePeriodoHistorico As BusinessEntity.Periodo
                    obePeriodoHistorico = obrMetodizado.leerPeriodo(intCodMetodizado, intCodPeriodo)
                    If obePeriodoHistorico.Dia = 31 And obePeriodoHistorico.Mes = 12 Then
                        CodPeriodoAnterior = obePeriodo.CodPeriodo
                        obePeriodo = obrMetodizado.leerPeriodo(intCodMetodizado, intCodPeriodo)
                        If Not obePeriodo Is Nothing Then
                            txtFecPeriodo.Text = obePeriodo.FecPeriodo
                            txtDesTipoEeff.Text = obePeriodo.DesTipoEeff
                            Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor
                            Dim obeAuditor As BusinessEntity.Auditor
                            obeAuditor = obrAuditor.leer(obePeriodo.CodAuditor)
                            If Not obeAuditor Is Nothing Then txtDesAuditor.Text = obeAuditor.RazonSocial
                            obrAuditor = Nothing
                            cargarSupuestoPorPeriodo(obePeriodo.CodMetodizado, obePeriodo.CodPeriodo, 0)
                            cargarSupuesto(0, True)
                        End If
                    Else
                        Me.muestraAlerta(ccALERTA_SUPUESTO_HISTORICO_SIN_CIERRE)
                        btnNuevo.Enabled = False
                        btnGrabar.Enabled = False
                        btnEliminar.Enabled = False
                    End If
                Else
                    Me.muestraAlerta(ccALERTA_SUPUESTO_HISTORICO_SIN_PERIODO_ANTERIOR)
                    btnNuevo.Enabled = False
                    btnGrabar.Enabled = False
                    btnEliminar.Enabled = False
                End If
            End If
        End Sub

        Private Sub configMntAccion(ByVal pordMntPage As ecMntPage)
            If pordMntPage = ecMntPage.AGREGAR Then
                MntAccion = Int32.Parse(ecMntPage.AGREGAR)
                btnGrabar.Attributes("onclick") = "javascript:if (confirm('" + ccALERTA_AGREGAR + "')) { document.getElementById('hidMntAccion').value = " + Int32.Parse(ecMntPage.AGREGAR).ToString() + "; this.onclick=function(){alert('" + ccALERTA_OPERACION_EN_PROCESO + "'); return false;}; return(true); } else { return(false); }"
                btnEliminar.Attributes("onclick") = "javascript:if (confirm('" + ccALERTA_ELIMINAR + "')) { document.getElementById('hidMntAccion').value = " + Int32.Parse(ecMntPage.ELIMINAR).ToString() + "; this.onclick=function(){alert('" + ccALERTA_OPERACION_EN_PROCESO + "'); return false;}; return(true); } else { return(false); }"
                imgGrabarSptoProy.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO))
                lnkGrabarSptoProy.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO))
                imgImprimir.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO))
                lnkImprimir.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO))
                imgExpSupuesto.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO))
                lnkExpSupuesto.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO))
                imgExpFlujoProyectado.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO))
                lnkExpFlujoProyectado.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_GRABAR_CABECERA_SUPUESTO))
            ElseIf pordMntPage = ecMntPage.MODIFICAR Then
                Dim intCodSupuesto As Integer = CodSupuesto
                Dim intCodMetodizado As Integer = CodMetodizado
                Dim intCodPeriodo As Integer = CodPeriodo
                Dim intCodPeriodoAnterior As Integer = CodPeriodoAnterior
                MntAccion = Int32.Parse(ecMntPage.MODIFICAR)
                btnGrabar.Attributes.Add("onclick", "javascript:return(f_ObtImporteMensaje());")
                imgGrabarSptoProy.Attributes.Add("onclick", "javascript:return (f_CallBackSupuesto());")
                lnkGrabarSptoProy.Attributes.Add("href", "javascript:f_CallBackSupuesto();")
                imgImprimir.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwFlujoProyectado.aspx?intCodSupuesto={0}&intCodMetodizado={1}&intCodPeriodo={2}&intCodPeriodoAnterior={3}');", intCodSupuesto, intCodMetodizado, intCodPeriodo, intCodPeriodoAnterior))
                lnkImprimir.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwFlujoProyectado.aspx?intCodSupuesto={0}&intCodMetodizado={1}&intCodPeriodo={2}&intCodPeriodoAnterior={3}');", intCodSupuesto, intCodMetodizado, intCodPeriodo, intCodPeriodoAnterior))
                imgExpSupuesto.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpSupuesto.aspx?intCodSupuesto={0}');", intCodSupuesto))
                lnkExpSupuesto.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpSupuesto.aspx?intCodSupuesto={0}');", intCodSupuesto))
                imgExpFlujoProyectado.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpFlujoProyectado.aspx?intCodSupuesto={0}');", intCodSupuesto))
                lnkExpFlujoProyectado.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpFlujoProyectado.aspx?intCodSupuesto={0}');", intCodSupuesto))
            End If
        End Sub

        Private Sub agregarColPeriodo(ByVal pstrTitulo As String, _
                                        ByVal pdteFecProyectado As DateTime, _
                                        ByVal pstrNombreCampoImporte As String, _
                                        ByVal pstrIdControlImporte As String, _
                                        ByVal pstrNombreCampoFuncion As String, _
                                        ByVal pstrIdControlFuncion As String)
            Dim dgcImporte As New TemplateColumn
            Dim dgtHeader As PlantillaDgcImporte = New PlantillaDgcImporte(ListItemType.Header)
            dgtHeader.Titulo = pstrTitulo
            dgtHeader.FecProyectado = pdteFecProyectado
            dgcImporte.HeaderTemplate = dgtHeader

            Dim dgtItem As PlantillaDgcImporte
            dgtItem = New PlantillaDgcImporte(ListItemType.EditItem)
            dgtItem.CssClass = "ActivoNumericoColSel"
            dgtItem.MaxLongitud = 16
            dgtItem.Formato = "{0:F3}"
            dgtItem.DataFieldNameImporte = pstrNombreCampoImporte
            dgtItem.IDControlImporte = pstrIdControlImporte
            dgtItem.DataFieldNameFuncion = pstrNombreCampoFuncion
            dgtItem.IDControlFuncion = pstrIdControlFuncion

            dgcImporte.ItemTemplate = dgtItem
            dgcImporte.ItemStyle.HorizontalAlign = HorizontalAlign.Right

            dgrdMnt.Columns.Add(dgcImporte)
        End Sub

        Private Sub generarPeriodoProyectado(ByVal pintCodSupuesto As Integer, ByVal pbytNumeroProyectado As Byte, ByVal pblnFlagNuevo As Boolean)
            Dim intCodMetodizado As Integer = Me.CodMetodizado
            Dim intCodPeriodo As Integer = Me.CodPeriodo
            Dim intCodSupuesto As Integer = pintCodSupuesto
            Dim bytNumeroProyectado As Byte = pbytNumeroProyectado
            Dim dteFecPeriodo As DateTime = txtFecPeriodo.Text
            Dim dsSupuestoProyectado As DataSet
            Dim strTitulo As String

            Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto

            'If pblnFlagNuevo Then
            '    Dim obiMetodizado As BusinessInterface.IMetodizado
            '    Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            '    obiMetodizado = CType(obrMetodizado, BusinessInterface.IMetodizado)
            '    Dim obePeriodo As BusinessEntity.Periodo = obiMetodizado.leerPeriodoAnterior(intCodMetodizado, intCodPeriodo)
            '    Dim intCodPeriodoAnterior As Integer = obePeriodo.CodPeriodo
            '    CodPeriodoAnterior = intCodPeriodoAnterior
            '    For bytCol As Byte = 1 To (bytNumeroProyectado + 1)
            '        If bytCol = Int32.Parse(ecTipoPeriodoProyectado.HISTORICO) Then
            '            strTitulo = "HISTORICO"
            '        Else
            '            strTitulo = "PROY"
            '        End If
            '        agregarColPeriodo(strTitulo, _
            '                            dteFecPeriodo.AddYears(Int32.Parse(bytCol - 1)), _
            '                            "ImportePry" + bytCol.ToString(), _
            '                            "txtImportePry" + bytCol.ToString(), _
            '                            "FuncionPry" + bytCol.ToString(), _
            '                            "hidFuncionPry" + bytCol.ToString())
            '    Next
            '    dsSupuestoProyectado = obiSupuesto.calcularSupuestoProyectadoInicial(intCodMetodizado, intCodPeriodo, intCodPeriodoAnterior, bytNumeroProyectado)
            'Else
            Dim obePeriodoProyectadoLst As BusinessEntity.PeriodoProyectadoLst = obrSupuesto.listarPeriodoProyectado(intCodSupuesto)
            For Each obePeriodoProyectado As BusinessEntity.PeriodoProyectado In obePeriodoProyectadoLst
                If obePeriodoProyectado.Tipo = Int32.Parse(ecTipoPeriodoProyectado.HISTORICO) Then
                    strTitulo = "HISTORICO"
                Else
                    strTitulo = "PROY"
                End If
                agregarColPeriodo(strTitulo, _
                                    obePeriodoProyectado.FecProyectado, _
                                    "ImportePry" + obePeriodoProyectado.CodProyectado.ToString(), _
                                    "txtImportePry" + obePeriodoProyectado.CodProyectado.ToString(), _
                                    "FuncionPry" + obePeriodoProyectado.CodProyectado.ToString(), _
                                    "hidFuncionPry" + obePeriodoProyectado.CodProyectado.ToString())
            Next
            dsSupuestoProyectado = obrSupuesto.filtrarSupuestoProyectado(intCodSupuesto)
            'End If

            Dim intAnchoColumnas As Integer = (Me.ccANCHO_DGRID_PERIODO + (Me.ccANCHO_COLUMNA_PERIODO * (bytNumeroProyectado + 1)))

            hidCuentaSupuesto.Value = String.Empty

            dgrdMnt.DataSource = dsSupuestoProyectado
            dgrdMnt.DataKeyField = "CodCuentaSupuesto"
            dgrdMnt.Width = New Unit(intAnchoColumnas, UnitType.Pixel)
            dgrdMnt.DataBind()

            lblNumReg.Text = dsSupuestoProyectado.Tables(0).Rows.Count
        End Sub

        Private Sub cargarSupuesto(ByVal pintCodSupuesto As Integer, ByVal pblnFlagNuevo As Boolean)
            If pblnFlagNuevo Then
                inicializarControles()
            Else
                Try
                    Dim obeSupuesto As BusinessEntity.Supuesto
                    Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto
                    obeSupuesto = obrSupuesto.leer(pintCodSupuesto)
                    If Not obeSupuesto Is Nothing Then
                        CodSupuesto = obeSupuesto.CodSupuesto
                        CodPeriodoAnterior = obeSupuesto.CodPeriodoAnterior
                        txtDescripcion.Text = obeSupuesto.Descripcion
                        Dim bytNumeroProyectado As Byte = obeSupuesto.NumeroProyectado
                        dropNumeroProyectado.SelectedValue = bytNumeroProyectado
                        dropNumeroProyectado.Enabled = False
                        generarPeriodoProyectado(pintCodSupuesto, bytNumeroProyectado, pblnFlagNuevo)
                        cargarFormulaEnCliente(bytNumeroProyectado)
                        configMntAccion(ecMntPage.MODIFICAR)
                    Else
                        Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de " & ccID_WEBUI_MNT)
                    End If
                Catch ex As Exception
                    Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                End Try
            End If
        End Sub

        Private Sub inicializarControles()
            dropSupuesto.SelectedValue = 0
            txtDescripcion.Text = String.Empty
            Dim obeParametro As BusinessEntity.Parametro = buscarParametro("SUP_NUM_PROYEC")
            Dim bytNumeroProyectado As Byte = Byte.Parse(obeParametro.Valor1)
            dropNumeroProyectado.SelectedValue = bytNumeroProyectado
            dropNumeroProyectado.Enabled = True
            txtFuncionFx.Text = String.Empty

            For intIndex As Integer = dgrdMnt.Columns.Count To 2 Step -1
                dgrdMnt.Columns.RemoveAt(intIndex - 1)
            Next

            configMntAccion(ecMntPage.AGREGAR)
        End Sub

        Private Sub cargarSupuestoPorPeriodo(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer, Optional ByVal pintCodSupuestoSeleccionado As Integer = 0)
            Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto
            Dim dsSupuesto As DataSet
            dsSupuesto = obrSupuesto.buscarPorPeriodo(CodMetodizado, CodPeriodo)
            dropSupuesto.DataSource = dsSupuesto
            dropSupuesto.DataTextField = "Descripcion"
            dropSupuesto.DataValueField = "CodSupuesto"
            dropSupuesto.DataBind()
            dropSupuesto.Items.Insert(0, New ListItem("Nuevo Supuesto ...", "0"))
            dropSupuesto.SelectedValue = pintCodSupuestoSeleccionado
        End Sub

        Protected Sub inicializarControlesPorScript()
            Dim sbScriptCliente As System.Text.StringBuilder
            sbScriptCliente = New StringBuilder("<script language=""Javascript"" type=""text/javascript"">")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("<!--")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("f_SetPosPage();")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("f_SetPosDivMnt();")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("// -->")
            sbScriptCliente.Append(ControlChars.NewLine)
            sbScriptCliente.Append("</script>")
            RegisterStartupScript("__RegScriptClientWebForm_InicializarControles", sbScriptCliente.ToString())
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim strColorHex As String = CType(DataBinder.Eval(e.Item.DataItem, "ColorHex"), String)
                Dim strColorFondoHex As String = CType(DataBinder.Eval(e.Item.DataItem, "ColorFondoHex"), String)
                Dim bolNegrita As Boolean = CType(DataBinder.Eval(e.Item.DataItem, "Negrita"), Boolean)
                Dim intTamanioFuente As Integer = CType(DataBinder.Eval(e.Item.DataItem, "TamanioFuente"), Integer)
                'e.Item.Style.Add("color", strColorHex)
                'e.Item.Style.Add("background-color", strColorFondoHex)
                'e.Item.Font.Bold = bolNegrita
                'e.Item.Font.Size = New FontUnit(Unit.Pixel(intTamanioFuente))

                Dim intCodCuentaSupuesto As Integer = Int32.Parse(DataBinder.Eval(e.Item.DataItem, "CodCuentaSupuesto"))
                Dim intCodTipoCuenta As Short = 0
                Dim intCodTipoCuentaHistorico As Short = 0
                Dim intCodTipoCuentaProyectadoInicio As Short = 0
                Dim intCodTipoCuentaProyectado As Short = 0
                Dim bytPrecisionImporte As Byte = Byte.Parse(DataBinder.Eval(e.Item.DataItem, "PrecisionImporte"))
                Dim bytEscalaImporte As Byte = Byte.Parse(DataBinder.Eval(e.Item.DataItem, "EscalaImporte"))
                Dim txtImporte As TextBox
                Dim hidFuncion As HtmlInputHidden
                Dim intIndiceCol As Integer
                Dim strIdCol As String
                Dim bolEsControlFormula As Boolean
                Dim bolEsControlTitulo As Boolean
                Dim bolEsControlDato As Boolean

                If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "CodTipoCuenta")) Then
                    intCodTipoCuenta = DataBinder.Eval(e.Item.DataItem, "CodTipoCuenta")
                End If

                If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "CodTipoCuentaHistorico")) Then
                    intCodTipoCuentaHistorico = DataBinder.Eval(e.Item.DataItem, "CodTipoCuentaHistorico")
                End If

                If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "CodTipoCuentaProyectadoInicio")) Then
                    intCodTipoCuentaProyectadoInicio = DataBinder.Eval(e.Item.DataItem, "CodTipoCuentaProyectadoInicio")
                End If

                If Not IsDBNull(DataBinder.Eval(e.Item.DataItem, "CodTipoCuentaProyectado")) Then
                    intCodTipoCuentaProyectado = DataBinder.Eval(e.Item.DataItem, "CodTipoCuentaProyectado")
                End If

                If intCodTipoCuenta = 1 Then
                    Dim intCount As Integer = e.Item.Cells.Count - 1
                    For intIndiceCol = 0 To intCount
                        e.Item.Cells.RemoveAt(0)
                    Next
                    Dim tcCuenta As TableCell = New TableCell
                    e.Item.Cells.Add(tcCuenta)
                    tcCuenta.ColumnSpan = intCount + 1
                    Dim strTitulo As String = CType(DataBinder.Eval(e.Item.DataItem, "Descripcion"), String)
                    Dim strHtml As String = "<TABLE width=""100%"" border=""0"" bgcolor=""White"">"
                    strHtml += "<TR style=""background-color:White;""><TD>&nbsp;</TD></TR>"
                    strHtml += String.Format("<TR style=""font-size:{0}px;font-weight:{1};color:{2};background-color:{3};"">", intTamanioFuente, "bold", strColorHex, strColorFondoHex)
                    strHtml += "<TD style=""BORDER-TOP: #3366CC 1px solid"">" + strTitulo + " </TD></TR>"
                    strHtml += "</TABLE>"
                    tcCuenta.Text = strHtml
                Else
                    e.Item.Style.Add("color", strColorHex)
                    e.Item.Style.Add("background-color", strColorFondoHex)
                    e.Item.Font.Bold = bolNegrita
                    e.Item.Font.Size = New FontUnit(Unit.Pixel(intTamanioFuente))

                    For Each tcCuenta As TableCell In e.Item.Cells
                        intIndiceCol = e.Item.Cells.GetCellIndex(tcCuenta)
                        If intIndiceCol > 0 Then
                            strIdCol = (intIndiceCol).ToString() + ";" + intCodCuentaSupuesto.ToString()
                            tcCuenta.Attributes.Add("id", strIdCol)

                            txtImporte = CType(tcCuenta.FindControl("txtImportePry" + intIndiceCol.ToString()), TextBox)
                            hidFuncion = CType(tcCuenta.FindControl("hidFuncionPry" + intIndiceCol.ToString()), HtmlInputHidden)
                            If intIndiceCol = 1 Then
                                bolEsControlFormula = (intCodTipoCuentaHistorico = 3 Or intCodTipoCuentaHistorico = 4)
                                bolEsControlTitulo = (intCodTipoCuentaHistorico = 0 Or intCodTipoCuentaHistorico = 1)
                                bolEsControlDato = (intCodTipoCuentaHistorico = 2)
                            ElseIf intIndiceCol = 2 Then
                                bolEsControlFormula = (intCodTipoCuentaProyectadoInicio = 3 Or intCodTipoCuentaProyectadoInicio = 4)
                                bolEsControlTitulo = (intCodTipoCuentaProyectadoInicio = 0 Or intCodTipoCuentaProyectadoInicio = 1)
                                bolEsControlDato = (intCodTipoCuentaProyectadoInicio = 2)
                            Else
                                bolEsControlFormula = (intCodTipoCuentaProyectado = 3 Or intCodTipoCuentaProyectado = 4)
                                bolEsControlTitulo = (intCodTipoCuentaProyectado = 0 Or intCodTipoCuentaProyectado = 1)
                                bolEsControlDato = (intCodTipoCuentaProyectado = 2)
                            End If

                            If bolEsControlFormula Then
                                txtImporte.ReadOnly = True
                                txtImporte.Style.Add("border", "Transparent 0px solid")
                                txtImporte.Style.Add("color", strColorHex)
                                txtImporte.Style.Add("background-color", strColorFondoHex)
                                txtImporte.Font.Bold = bolNegrita
                                txtImporte.Font.Size = New FontUnit(Unit.Pixel(intTamanioFuente))
                            End If
                            If bolEsControlTitulo Then
                                txtImporte.ReadOnly = True
                                txtImporte.Style.Add("border", "Transparent 0px solid")
                                txtImporte.Style.Add("color", strColorFondoHex)
                                txtImporte.Style.Add("background-color", strColorFondoHex)
                            End If
                            If bolEsControlDato Then
                                txtImporte.Attributes.Add("onkeypress", "javascript:if (event.keyCode == 13) {f_CalcularTotales(); event.returnValue = false;}; else f_ValidarNumero(this," + bytPrecisionImporte.ToString() + "," + bytEscalaImporte.ToString() + ");")
                                txtImporte.Attributes.Add("onblur", "javascript:f_CalcularTotales();")
                                txtImporte.Attributes.Add("onfocus", "javascript:f_AsigIdCtrlActivo('" + txtImporte.ClientID + "','" + hidFuncion.ClientID + "'," + bytPrecisionImporte.ToString() + "," + bytEscalaImporte.ToString() + ");")
                            End If
                            If Not bolEsControlTitulo Then
                                hidCuentaSupuesto.Value += (strIdCol + "|")
                            End If
                        End If
                    Next
                End If
            End If
        End Sub

        Private Sub agregarSupuesto()
            Dim intCodMetodizado As Integer = CodMetodizado
            Dim intCodPeriodo As Integer = CodPeriodo
            Dim intCodPeriodoAnterior As Integer = CodPeriodoAnterior
            Try
                If Page.IsValid Then
                    Dim obeSupuesto As BusinessEntity.Supuesto = New BusinessEntity.Supuesto
                    Dim bytNumeroProyectado As Byte = Byte.Parse(dropNumeroProyectado.SelectedValue)

                    obeSupuesto.CodMetodizado = intCodMetodizado
                    obeSupuesto.CodPeriodo = intCodPeriodo
                    obeSupuesto.CodPeriodoAnterior = intCodPeriodoAnterior
                    obeSupuesto.CodTipoSupuesto = 1
                    obeSupuesto.Descripcion = txtDescripcion.Text
                    obeSupuesto.NumeroProyectado = bytNumeroProyectado
                    obeSupuesto.CodMoneda = 2
                    obeSupuesto.CodUnidad = 2
                    obeSupuesto.Estado = 1

                    Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto

                    Dim bolRC As Boolean = obrSupuesto.agregar(obeSupuesto)
                    If bolRC Then
                        Dim intCodSupuesto As Integer = obeSupuesto.CodSupuesto
                        CodSupuesto = intCodSupuesto
                        configMntAccion(ecMntPage.MODIFICAR)
                        cargarSupuestoPorPeriodo(intCodMetodizado, intCodPeriodo, intCodSupuesto)
                        dropNumeroProyectado.Enabled = False
                        generarPeriodoProyectado(intCodSupuesto, bytNumeroProyectado, True)
                        cargarFormulaEnCliente(bytNumeroProyectado)
                        Me.muestraAlerta(ccALERTA_EXITO_AGREGAR & " de " & ccID_WEBUI_MNT)
                    Else
                        configMntAccion(ecMntPage.AGREGAR)
                        Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                configMntAccion(ecMntPage.AGREGAR)
                Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Sub AgregarSupuestoExistente()
            Dim intCodMetodizado As Integer = CodMetodizado
            Dim intCodPeriodo As Integer = CodPeriodo
            Dim intCodPeriodoAnterior As Integer = CodPeriodoAnterior

            Try
                If Page.IsValid Then
                    Dim bytNumeroProyectado As Byte = Byte.Parse(dropNumeroProyectado.SelectedValue)
                    Dim strImporteSupuesto As String = Request.Params("hidIdCtrlActivo")
                    If strImporteSupuesto.Length = 0 Then
                        Dim intCodSupuesto As Integer = CodSupuesto
                        generarPeriodoProyectado(intCodSupuesto, bytNumeroProyectado, True)
                        cargarFormulaEnCliente(bytNumeroProyectado)
                    Else
                        Dim obeSupuesto As BusinessEntity.Supuesto = New BusinessEntity.Supuesto

                        obeSupuesto.CodMetodizado = intCodMetodizado
                        obeSupuesto.CodPeriodo = intCodPeriodo
                        obeSupuesto.CodPeriodoAnterior = intCodPeriodoAnterior
                        obeSupuesto.CodTipoSupuesto = 1
                        obeSupuesto.Descripcion = txtDescripcion.Text
                        obeSupuesto.NumeroProyectado = bytNumeroProyectado
                        obeSupuesto.CodMoneda = 2
                        obeSupuesto.CodUnidad = 2
                        obeSupuesto.Estado = 1

                        Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto

                        Dim obrPeriodo As BusinessRules.Metodizado = New BusinessRules.Metodizado
                        Dim obePeriodo As BusinessEntity.Periodo
                        obePeriodo = obrPeriodo.leerPeriodo(obeSupuesto.CodMetodizado, obeSupuesto.CodPeriodo)
                        Dim dteFecPeriodo As DateTime = obePeriodo.FecPeriodo

                        For intIndice As Integer = 1 To (bytNumeroProyectado + 1)
                            Dim obePeriodoProyectado As BusinessEntity.PeriodoProyectado = New BusinessEntity.PeriodoProyectado
                            obePeriodoProyectado.CodProyectado = intIndice
                            If intIndice = 1 Then
                                obePeriodoProyectado.Tipo = Byte.Parse(Common.Globals.ecTipoPeriodoProyectado.HISTORICO)
                            Else
                                obePeriodoProyectado.Tipo = Byte.Parse(Common.Globals.ecTipoPeriodoProyectado.PROYECTADO)
                            End If
                            obePeriodoProyectado.FecProyectado = dteFecPeriodo.AddYears(intIndice - 1)
                            obeSupuesto.PeriodosProyectados.Add(obePeriodoProyectado)
                        Next

                        If strImporteSupuesto.EndsWith("|") Then strImporteSupuesto = strImporteSupuesto.Substring(0, strImporteSupuesto.Length - 1)
                        If strImporteSupuesto <> String.Empty Then
                            Dim arrPeriodoCuenta As String() = strImporteSupuesto.Split("|")
                            For Each strPeriodoCuenta As String In arrPeriodoCuenta
                                Dim arrValor As String() = strPeriodoCuenta.Split(";")
                                Dim intCodProyectado As Integer = CType(arrValor(0), Byte)
                                Dim intCodCuentaSupuesto As Integer = CType(arrValor(1), Integer)
                                Dim strFuncion As String = CType(arrValor(3), String)
                                If IsNumeric(arrValor(2)) Then
                                    Dim decImporte As Decimal = CType(arrValor(2), Decimal)
                                    Dim obeSupuestoProyectado As BusinessEntity.SupuestoProyectado = New BusinessEntity.SupuestoProyectado
                                    obeSupuestoProyectado.CodProyectado = intCodProyectado
                                    obeSupuestoProyectado.CodCuentaSupuesto = intCodCuentaSupuesto
                                    obeSupuestoProyectado.Importe = decImporte
                                    obeSupuestoProyectado.Funcion = strFuncion
                                    obeSupuesto.PeriodosProyectados.buscarPorClave(0, intCodProyectado).SupuestosProyectados.Add(obeSupuestoProyectado)
                                End If
                            Next
                        End If

                        Dim bolRC As Boolean = obrSupuesto.modificar(obeSupuesto)
                        If bolRC Then
                            Dim intCodSupuesto As Integer = obeSupuesto.CodSupuesto
                            If intCodSupuesto = 0 Then
                                intCodSupuesto = CodSupuesto
                                Me.muestraAlerta(ccALERTA_ERROR_SUPUESTO_DUPLICADO & " de " & ccID_WEBUI_MNT)
                            Else
                                CodSupuesto = intCodSupuesto
                                Me.muestraAlerta(ccALERTA_EXITO_AGREGAR & " de " & ccID_WEBUI_MNT)
                            End If
                            configMntAccion(ecMntPage.MODIFICAR)
                            cargarSupuestoPorPeriodo(intCodMetodizado, intCodPeriodo, intCodSupuesto)
                            dropNumeroProyectado.Enabled = False
                            generarPeriodoProyectado(intCodSupuesto, bytNumeroProyectado, True)
                            cargarFormulaEnCliente(bytNumeroProyectado)
                        Else
                            configMntAccion(ecMntPage.AGREGAR)
                            Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
                        End If
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                configMntAccion(ecMntPage.AGREGAR)
                Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Sub eliminarSupuesto()
            Dim intCodSupuesto As Integer = CodSupuesto
            Dim intCodMetodizado As Integer = CodMetodizado
            Dim intCodPeriodo As Integer = CodPeriodo

            Try
                If Page.IsValid Then
                    Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto
                    Dim bytNumeroProyectado As Byte = Byte.Parse(dropNumeroProyectado.SelectedValue)

                    Dim bolRC As Boolean = obrSupuesto.eliminar(intCodSupuesto)
                    If bolRC Then
                        inicializarControles()
                        Dim dsSupuesto As DataSet
                        dsSupuesto = obrSupuesto.buscarPorPeriodo(CodMetodizado, CodPeriodo)
                        dropSupuesto.DataSource = dsSupuesto
                        dropSupuesto.DataTextField = "Descripcion"
                        dropSupuesto.DataValueField = "CodSupuesto"
                        dropSupuesto.DataBind()
                        dropSupuesto.Items.Insert(0, New ListItem("Nuevo Supuesto ...", "0"))
                        Me.muestraAlerta(ccALERTA_EXITO_ELIMINAR & " de " & ccID_WEBUI_MNT)
                    Else
                        Me.muestraAlerta(ccALERTA_ERROR_ELIMINAR & " de " & ccID_WEBUI_MNT)
                    End If

                End If

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_ELIMINAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Sub cargarFormulaEnCliente(ByVal pbytNumeroProyectado As Byte)

            Dim intCodCuenta As Integer
            Dim intCodFormula As Integer
            Dim intCodEeff As Integer
            Dim intTipo As Short
            Dim bytPrecisionImporte As Byte
            Dim bytEscalaImporte As Byte
            Dim bytInicioEjecucionFormula As Byte
            Dim strNombreFuncion As String
            Dim sbFormula As StringBuilder = New StringBuilder
            Dim sbDefFunMain As StringBuilder = New StringBuilder
            Dim strCallFunHistorico As String
            Dim strCallFunProyectado As String
            Dim strCallFunProyectadoInicio As String
            Dim strDefBucleFor As String
            Dim strArrPeriodo As String
            Dim intIndice As Integer = 0
            Dim strFiltro As String

            ' 30/01/2014 XT5022 - JAVILA (CGI)
            Dim intFlgBpe As Integer = 1
            If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                intFlgBpe = 2
            End If

            Dim obrFormula As BusinessRules.Formula = New BusinessRules.Formula
            Dim dtFormula As DataTable
            dtFormula = obrFormula.buscarEnCuentaPorAnalisis(5, intFlgBpe).Tables(0)
            Dim dtSentencia As DataTable = obrFormula.buscarSentenciaPorAnalisis(5).Tables(0)

            strArrPeriodo = "var arrPeriodo = new Array(" + (pbytNumeroProyectado + 1).ToString() + ");" + ControlChars.NewLine
            For intIndice = 0 To pbytNumeroProyectado
                strArrPeriodo += String.Format("arrPeriodo[{0}]={1};", intIndice, intIndice + 1) + ControlChars.NewLine
            Next

            sbFormula.Append("<SCRIPT LANGUAGE=""JavaScript"">")
            sbFormula.Append(ControlChars.NewLine)
            sbFormula.Append("<!--")
            sbFormula.Append(ControlChars.NewLine)
            sbFormula.Append(strArrPeriodo)
            sbFormula.Append(ControlChars.NewLine)

            For Each dr As DataRow In dtFormula.Rows()
                intCodCuenta = dr("CodCuentaSupuesto")
                intCodFormula = dr("CodFormula")
                intCodEeff = dr("CodEeff")
                intTipo = dr("Tipo")
                bytPrecisionImporte = dr("PrecisionImporte")
                bytEscalaImporte = dr("EscalaImporte")
                bytInicioEjecucionFormula = dr("InicioEjecucionFormula")

                strNombreFuncion = "f_Formula" + intCodFormula.ToString() + "Cuenta" + intCodCuenta.ToString()
                strFiltro = String.Format("CodFormula = {0}", intCodFormula)
                Dim dtSentenciaPorFormula As DataTable = filtrarRegs(dtSentencia, strFiltro, String.Empty)
                sbFormula.Append(ControlChars.NewLine + "//" + dr("Nombre") + ControlChars.NewLine)
                sbFormula.Append(expresionFormula(dtSentenciaPorFormula, intCodCuenta, strNombreFuncion, bytPrecisionImporte, bytEscalaImporte))
                sbFormula.Append(ControlChars.NewLine)
                If intTipo = 7 Then
                    strCallFunProyectadoInicio += strNombreFuncion + "(1);" + ControlChars.NewLine
                ElseIf intTipo = 8 Then
                    If bytInicioEjecucionFormula > 1 Then strCallFunProyectado += String.Format("if (i >= {0}) ", bytInicioEjecucionFormula.ToString)
                    strCallFunProyectado += strNombreFuncion + "(i);" + ControlChars.NewLine
                End If
            Next
            strDefBucleFor = "for(var i=1;(i<arrPeriodo.length);i++)"
            strCallFunProyectado = strDefBucleFor + "{" + ControlChars.NewLine + strCallFunProyectado + ControlChars.NewLine + "}"

            sbDefFunMain.Append("function")
            sbDefFunMain.Append(" f_CalcularTotales()")
            sbDefFunMain.Append("{" + ControlChars.NewLine)
            sbDefFunMain.Append(strCallFunProyectadoInicio)
            sbDefFunMain.Append(ControlChars.NewLine)
            sbDefFunMain.Append(strCallFunProyectado)
            sbDefFunMain.Append(ControlChars.NewLine + "}")

            sbFormula.Append(ControlChars.NewLine)
            sbFormula.Append(sbDefFunMain.ToString())
            sbFormula.Append("//-->")
            sbFormula.Append(ControlChars.NewLine)
            sbFormula.Append("</SCRIPT>")

            If (Not Me.IsClientScriptBlockRegistered("__RegFormulaWebForm")) Then
                Me.RegisterClientScriptBlock("__RegFormulaWebForm", sbFormula.ToString())
            End If
        End Sub

        Private Function expresionFormula(ByVal pdtSentencia As DataTable, ByVal pintCodCuenta As Integer, ByVal pstrNombreFuncion As String, ByVal bytPrecisionImporte As Byte, ByVal bytEscalaImporte As Byte) As String
            Dim strFormula As String
            Dim strVariable As String
            Dim strCodCuenta1 As String
            Dim strCodSentencia1 As String
            Dim decValor1 As Decimal
            Dim strCodCuentaSupuesto1 As String
            Dim strPosicionPeriodo1 As String
            Dim strCodOperador As String
            Dim strCodCuenta2 As String
            Dim strCodSentencia2 As String
            Dim decValor2 As Decimal
            Dim strCodCuentaSupuesto2 As String
            Dim strPosicionPeriodo2 As String
            Dim bytCodTipoSentencia As Byte

            strFormula = "function " + pstrNombreFuncion + "(pIndice) {" + ControlChars.NewLine
            For Each dr As DataRow In pdtSentencia.Rows()
                strVariable = "dec" + dr("CodSentencia").ToString()

                bytCodTipoSentencia = Byte.Parse(dr("CodTipoSentencia"))

                If bytCodTipoSentencia = 1 Then
                    strFormula += "var " + strVariable + " = "
                ElseIf bytCodTipoSentencia = 2 Then
                    strFormula += "var " + strVariable + " = 0;" + ControlChars.NewLine
                    strFormula += "for(var i=pIndice;(i<arrPeriodo.length);i++){" + ControlChars.NewLine
                    strFormula += strVariable + " += ("
                End If

                strPosicionPeriodo1 = dr("PosicionPeriodo1")
                If dr("TipoOpe1") = 1 Then
                    strCodCuenta1 = dr("CodCuenta1")
                    If bytCodTipoSentencia = 1 Then
                        strFormula += "f_ObtValorCuenta(arrPeriodo[pIndice + (" + strPosicionPeriodo1 + ")]," + strCodCuenta1 + ")"
                    ElseIf bytCodTipoSentencia = 2 Then
                        strFormula += "f_ObtValorCuenta(arrPeriodo[i + (" + strPosicionPeriodo1 + ")]," + strCodCuenta1 + ")"
                    End If
                ElseIf dr("TipoOpe1") = 2 Then
                    strCodSentencia1 = dr("CodSentencia1")
                    strFormula += "dec" + strCodSentencia1
                ElseIf dr("TipoOpe1") = 4 Then
                    decValor1 = dr("Valor1")
                    strFormula += Convert.ToInt32(decValor1).ToString()
                ElseIf dr("TipoOpe1") = 8 Then
                    strCodCuentaSupuesto1 = dr("CodCuentaSupuesto1")
                    If bytCodTipoSentencia = 1 Then
                        strFormula += "f_ObtValorCuenta(arrPeriodo[pIndice + (" + strPosicionPeriodo1 + ")]," + strCodCuentaSupuesto1 + ")"
                    ElseIf bytCodTipoSentencia = 2 Then
                        strFormula += "f_ObtValorCuenta(arrPeriodo[i + (" + strPosicionPeriodo1 + ")]," + strCodCuentaSupuesto1 + ")"
                    End If
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
                    If bytCodTipoSentencia = 1 Then
                        strFormula += "f_ObtValorCuenta(arrPeriodo[pIndice + (" + strPosicionPeriodo2 + ")]," + strCodCuenta2 + ")"
                    ElseIf bytCodTipoSentencia = 2 Then
                        strFormula += "f_ObtValorCuenta(arrPeriodo[i + (" + strPosicionPeriodo2 + ")]," + strCodCuenta2 + ")"
                    End If
                ElseIf dr("TipoOpe2") = 2 Then
                    strCodSentencia2 = dr("CodSentencia2")
                    strFormula += "dec" + strCodSentencia2
                ElseIf dr("TipoOpe2") = 4 Then
                    decValor2 = dr("Valor2")
                    strFormula += Convert.ToInt32(decValor2).ToString()
                ElseIf dr("TipoOpe2") = 8 Then
                    strCodCuentaSupuesto2 = dr("CodCuentaSupuesto2")
                    If bytCodTipoSentencia = 1 Then
                        strFormula += "f_ObtValorCuenta(arrPeriodo[pIndice + (" + strPosicionPeriodo2 + ")]," + strCodCuentaSupuesto2 + ")"
                    ElseIf bytCodTipoSentencia = 2 Then
                        strFormula += "f_ObtValorCuenta(arrPeriodo[i + (" + strPosicionPeriodo2 + ")]," + strCodCuentaSupuesto2 + ")"
                    End If
                End If

                If bytCodTipoSentencia = 1 Then
                    strFormula += ";" + ControlChars.NewLine
                ElseIf bytCodTipoSentencia = 2 Then
                    strFormula += ");" + ControlChars.NewLine
                    strFormula += "}" + ControlChars.NewLine
                End If
            Next
            strFormula += "f_AsigValorCuenta(arrPeriodo[pIndice]," + pintCodCuenta.ToString() + "," + strVariable + "," + bytPrecisionImporte.ToString() + "," + bytEscalaImporte.ToString() + ");" + ControlChars.NewLine + "}"
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

        Private Sub dropSupuesto_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dropSupuesto.SelectedIndexChanged
            Dim intCodSupuesto As Integer = Int32.Parse(dropSupuesto.SelectedValue)
            Dim blnFlagNuevo As Boolean = (intCodSupuesto = 0)
            cargarSupuesto(intCodSupuesto, blnFlagNuevo)
        End Sub

        Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
            cargarSupuesto(0, True)
        End Sub

        Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            If MntAccion = Int32.Parse(ecMntPage.AGREGAR) Then
                agregarSupuesto()
            ElseIf MntAccion = Int32.Parse(ecMntPage.MODIFICAR) Then
                AgregarSupuestoExistente()
            End If
        End Sub

        Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
            MntAccion = ecMntPage.ELIMINAR
            If MntAccion = Int32.Parse(ecMntPage.ELIMINAR) Then
                eliminarSupuesto()
            End If
        End Sub

    End Class

End Namespace