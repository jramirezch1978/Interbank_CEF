'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Text
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals

Namespace CEF.WebUI

    Partial Class rvwExpReconciliado
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

        Private Const ccANCHO_DGRID_PERIODO As Short = 260
        Private Const ccANCHO_COLUMNA_PERIODO As Short = 100
        Private Const ccID_WEBUI_MNT = "Metodizado"

        Private PeriodosFiltrado As BusinessEntity.PeriodoLst = New BusinessEntity.PeriodoLst

        ' 07/02/2014 : XT5022 - JAVILA (CGI)'
        ' CODIGO DE PERFIL DEL USUARIO LOGUEADO
        Public ReadOnly Property CodPerfil() As Integer
            Get
                'Dim strCodUsuario As String = DatosGlobal.sUser
                'Dim obeUsuario As BusinessEntity.Usuario
                'obeUsuario = Util.obtenerUsuario(strCodUsuario)

                'Return obeUsuario.CodPerfil
                'Return Util.obtenerUsuario(datosGlobal.sUser).CodPerfil
                Dim intPerfil As Integer = fRetornaPerfilUsuario()
                Return intPerfil
            End Get


        End Property
        Private Class RepDataGridTemplate
            Implements ITemplate

            Private lTemplateType As ListItemType
            Private lPeriodo As Periodo
            Private lDataFieldNameImporte As String
            Private lTextValue As String
            Private lCssClass As String
            Private lFormato As String

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

            Public Property CabPeriodo() As Periodo
                Get
                    Return Me.lPeriodo
                End Get
                Set(ByVal Value As Periodo)
                    Me.lPeriodo = Value
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

            Public Property TextValue() As String
                Get
                    Return Me.lTextValue
                End Get
                Set(ByVal Value As String)
                    Me.lTextValue = Value
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

            Public Property Formato() As String
                Get
                    Return Me.lFormato
                End Get
                Set(ByVal Value As String)
                    Me.lFormato = Value
                End Set
            End Property



            Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements ITemplate.InstantiateIn
                Select Case Me.lTemplateType
                    Case ListItemType.Header
                        Dim lc As Literal = New Literal
                        Dim strHtml As String
                        Dim strRazonSocial As String

                        Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor
                        Dim obeAuditor As BusinessEntity.Auditor
                        obeAuditor = obrAuditor.leer(Me.lPeriodo.CodAuditor)
                        If Not obeAuditor Is Nothing Then
                            strRazonSocial = obeAuditor.RazonSocial
                        End If
                        obrAuditor = Nothing

                        strHtml = "<TABLE boder=0>"
                        strHtml += "<TR>"
                        strHtml += "<TD align=""center"" style=""BORDER:.5pt solid #3366CC; FONT-WEIGHT: bold; BACKGROUND-COLOR: LightBlue""><b>" + Me.lPeriodo.FecPeriodo + "</b></TD>"
                        strHtml += "</TR>"
                        strHtml += "<TR>"
                        strHtml += "<TD align=""center"" style=""BORDER:.5pt solid #3366CC; FONT-WEIGHT: bold; BACKGROUND-COLOR: LightBlue""><b>" + Me.lPeriodo.Mes.ToString() + "</b></TD>"
                        strHtml += "</TR>"
                        strHtml += "<TR>"
                        strHtml += "<TD style=""BORDER:.5pt solid #3366CC; BACKGROUND-COLOR: LightBlue"">" + Me.lPeriodo.DesTipoEeff + "</TD>"
                        strHtml += "</TR>"
                        strHtml += "<TR>"
                        strHtml += "<TD style=""BORDER:.5pt solid #3366CC; BACKGROUND-COLOR: LightBlue"">" + strRazonSocial + "</TD>"
                        strHtml += "</TR>"
                        strHtml += "</TABLE>"

                        lc.Text = strHtml
                        container.Controls.Add(lc)
                    Case ListItemType.Item
                        Dim lc As New Literal
                        AddHandler lc.DataBinding, AddressOf TemplateControlImporte_DataBinding
                        container.Controls.Add(lc)
                    Case ListItemType.Footer
                        Dim lc As New Literal
                        lc.Text = Me.lTextValue
                        container.Controls.Add(lc)
                End Select
            End Sub

            Private Sub TemplateControlImporte_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs)
                If Me.lTemplateType = ListItemType.Item Then
                    Dim ltl As Literal
                    ltl = CType(sender, Literal)
                    Dim container As DataGridItem
                    container = CType(ltl.NamingContainer, DataGridItem)
                    'If Not IsDBNull(DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)) Then
                    '    If Me.lFormato <> String.Empty Then
                    '        ltl.Text = String.Format(Me.lFormato, DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte))
                    '    Else
                    '        ltl.Text = DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)
                    '    End If
                    'End If

                    Dim intCodEeff As Integer = DataBinder.Eval(container.DataItem, "CodEeff")
                    If Not IsDBNull(DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)) Then
                        If intCodEeff = 4 Or intCodEeff = 5 Then
                            ltl.Text = DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)
                        Else
                            ltl.Text = DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte, Me.lFormato)
                        End If
                    End If
                End If
            End Sub
        End Class

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        cargarDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargarDatos()
                End If
            End If
        End Sub

        Private Sub cargarDatos()
            cargarDatosMetodizado()
        End Sub

        Private Sub cargarDatosMetodizado()
            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))

            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            obeMetodizado = obrMetodizado.leer(intCodMetodizado)

            If Not obeMetodizado Is Nothing Then
                cargarDatosReconciliacion(obeMetodizado.FlgBPE)
                Dim strTitulo As String = "Metodizado"
                Dim arrCriterio(6, 1) As String
                arrCriterio(0, 0) = "Razon Social"
                arrCriterio(0, 1) = obeMetodizado.RazonSocial

                Dim obeGeneral As BusinessEntity.General
                Dim obrGeneral As BusinessRules.General = New BusinessRules.General

                obeGeneral = obrGeneral.leer(Int32.Parse(ecTablaGeneral.TIPO_DOC_CLIENTE), obeMetodizado.TipoDocumento)
                arrCriterio(1, 0) = obeGeneral.DesCorta
                arrCriterio(1, 1) = obeMetodizado.NumeroDocumento
                arrCriterio(2, 0) = "Código Unico"
                arrCriterio(2, 1) = obeMetodizado.CUCliente

                obeGeneral = obrGeneral.leer(Int32.Parse(ecTablaGeneral.MONEDA), obeMetodizado.CodMoneda)
                arrCriterio(3, 0) = "Moneda"
                arrCriterio(3, 1) = obeGeneral.DesCorta

                obeGeneral = obrGeneral.leer(Int32.Parse(ecTablaGeneral.UNIDAD_IMPORTE), obeMetodizado.CodUnidad)
                arrCriterio(4, 0) = "Unidad"
                arrCriterio(4, 1) = obeGeneral.DesCorta
                arrCriterio(5, 0) = "Analista"
                arrCriterio(5, 1) = obeMetodizado.NombreAnalista
                arrCriterio(6, 0) = "Ejecutivo"
                arrCriterio(6, 1) = obeMetodizado.NombreEjecutivo

                Util.exportarExcel(dgrdMntRec, strTitulo, arrCriterio)
            End If
        End Sub

        Private Sub cargarDatosReconciliacion(ByVal FLGBPE As Integer)
            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
            Dim strPeriodoFiltrado As String = Request.Params("strPeriodoFiltrado")

            Dim intContadorColPeriodo As Integer
            Dim intAnchoColumnas As Integer
            Dim dsPeriodoCuenta As DataSet

            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            Dim obePeriodoLst As BusinessEntity.PeriodoLst

            If (strPeriodoFiltrado <> String.Empty) Then
                Dim arrCodPeriodo As String() = strPeriodoFiltrado.Split(";")
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

                If obePeriodoLst.Count() > 0 Then
                    intContadorColPeriodo = obePeriodoLst.Count()
                    intAnchoColumnas = (Me.ccANCHO_DGRID_PERIODO + (Me.ccANCHO_COLUMNA_PERIODO * intContadorColPeriodo))
                    PeriodosFiltrado = obePeriodoLst
                    For Each obePeriodo As BusinessEntity.Periodo In obePeriodoLst
                        agregarColPeriodo(ecTabMntMetodizado.RECONCILIACION, dgrdMntRec, obePeriodo)
                    Next

                    'dsPeriodoCuenta = obiMetodizado.filtrarPeriodoCuenta(obeMetodizado)
                    ' 07-02-2014 : XT5022 - JAVILA (CGI) 
                    If CodPerfil = ecPerfil.ANALISTA_RIESGO_BPE Or CodPerfil = ecPerfil.EJECUTIVO_NEGOCIO_BPE Then
                        dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuentaBPE(obeMetodizado)
                    ElseIf CodPerfil = ecPerfil.ADMINISTRADOR Then
                        'agregado RQUIPE 18/03/2014
                        If FLGBPE = ecTipoBanca.BancaEmpresa Then
                            dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuenta(obeMetodizado) 'LINEA ORIGINAL
                        ElseIf FLGBPE = ecTipoBanca.BancaPequenaEmpresa Then
                            dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuentaBPE(obeMetodizado)
                        End If
                        'FIN AGREGADO RQUIPE
                    Else
                        dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuenta(obeMetodizado)
                    End If

                    dgrdMntRec.DataSource = dsPeriodoCuenta
                    dgrdMntRec.DataKeyField = "CodCuenta"
                    dgrdMntRec.Width = New Unit(intAnchoColumnas, UnitType.Pixel)
                    dgrdMntRec.DataBind()
                End If
            End If
        End Sub

        Private Sub agregarColPeriodo(ByVal ordTabMnt As ecTabMntMetodizado, ByRef dgrMnt As DataGrid, ByVal pobePeriodo As BusinessEntity.Periodo)
            Dim dgcImporte As New TemplateColumn
            Dim dgtHeader As RepDataGridTemplate = New RepDataGridTemplate(ListItemType.Header)
            dgtHeader.CabPeriodo = pobePeriodo
            dgcImporte.HeaderTemplate = dgtHeader

            Dim dgtItem As RepDataGridTemplate
            dgtItem = New RepDataGridTemplate(ListItemType.Item)
            dgtItem.Formato = "{0:#,##0;(#,##0)}"
            dgtItem.DataFieldNameImporte = "Importe" + pobePeriodo.CodPeriodo.ToString

            dgcImporte.ItemTemplate = dgtItem
            dgcImporte.ItemStyle.HorizontalAlign = HorizontalAlign.Right

            dgrMnt.Columns.Add(dgcImporte)
        End Sub

        Private Sub dgrdMntRec_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMntRec.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                Dim strColorHex As String = CType(DataBinder.Eval(e.Item.DataItem, "ColorHex"), String)
                Dim strColorFondoHex As String = CType(DataBinder.Eval(e.Item.DataItem, "ColorFondoHex"), String)
                Dim bolNegrita As Boolean = CType(DataBinder.Eval(e.Item.DataItem, "Negrita"), Boolean)
                Dim intTamanioFuente As Integer = CType(DataBinder.Eval(e.Item.DataItem, "TamanioFuente"), Integer)
                e.Item.Style.Add("color", strColorHex)
                e.Item.Style.Add("background-color", strColorFondoHex)
                e.Item.Font.Bold = bolNegrita
                e.Item.Font.Size = New FontUnit(Unit.Pixel(intTamanioFuente))
            End If
        End Sub

    End Class

End Namespace
