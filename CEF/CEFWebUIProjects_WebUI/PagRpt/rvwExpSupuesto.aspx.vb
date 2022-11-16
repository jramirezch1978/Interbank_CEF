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

    Partial Class rvwExpSupuesto
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

        Private Const ccID_WEBUI_MNT As String = "Supuesto"
        Private Const ccANCHO_DGRID_PERIODO As Short = 310
        Private Const ccANCHO_COLUMNA_PERIODO As Short = 80
        Private Const ccINICIO_COLUMNA_PROYECTADO As Short = 1

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
                        If Me.lCssClass <> String.Empty Then tb.CssClass = Me.lCssClass
                        AddHandler tb.DataBinding, AddressOf TemplateControlImporte_DataBinding
                        container.Controls.Add(tb)
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
                    Dim intCodEeff As Integer = DataBinder.Eval(container.DataItem, "CodEeff")
                    If Not IsDBNull(DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)) Then
                        tb.Text = DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte, "{0:F0}")
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
            cargarSupuesto()
        End Sub

        Private Sub cargarSupuesto()
            Dim intCodSupuesto As Integer = Int32.Parse(Request.Params("intCodSupuesto"))
            Dim strRazonSocialAuditor As String

            Try
                Dim obeSupuesto As BusinessEntity.Supuesto
                Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto
                obeSupuesto = obrSupuesto.leer(intCodSupuesto)
                If Not obeSupuesto Is Nothing Then
                    Dim obePeriodoAnterior As BusinessEntity.Periodo
                    Dim obePeriodo As BusinessEntity.Periodo
                    Dim obeMetodizado As BusinessEntity.Metodizado
                    Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
                    obeMetodizado = obrMetodizado.leer(obeSupuesto.CodMetodizado)
                    If Not obeMetodizado Is Nothing Then
                        obePeriodoAnterior = obrMetodizado.leerPeriodo(obeSupuesto.CodMetodizado, obeSupuesto.CodPeriodoAnterior)
                        If Not obePeriodoAnterior Is Nothing Then
                            obePeriodo = obrMetodizado.leerPeriodo(obeSupuesto.CodMetodizado, obeSupuesto.CodPeriodo)
                            If Not obePeriodo Is Nothing Then
                                Dim obeAuditor As BusinessEntity.Auditor
                                Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor
                                obeAuditor = obrAuditor.leer(obePeriodo.CodAuditor)
                                If Not obeAuditor Is Nothing Then strRazonSocialAuditor = obeAuditor.RazonSocial
                                obrAuditor = Nothing

                                cargarSupuestoProyectado(intCodSupuesto)

                                Dim strTitulo As String = "Supuesto"
                                Dim arrCriterio(9, 1) As String
                                arrCriterio(0, 0) = "Cliente"
                                arrCriterio(0, 1) = obeMetodizado.RazonSocial
                                arrCriterio(1, 0) = "Fecha Periodo"
                                arrCriterio(1, 1) = obePeriodo.FecPeriodo.ToShortDateString
                                arrCriterio(2, 0) = "Tipo Eeff"
                                arrCriterio(2, 1) = obePeriodo.DesTipoEeff
                                arrCriterio(3, 0) = "Auditor"
                                arrCriterio(3, 1) = strRazonSocialAuditor
                                arrCriterio(4, 0) = "Supuesto"
                                arrCriterio(4, 1) = obeSupuesto.Descripcion
                                arrCriterio(5, 0) = "Numero proyectado"
                                arrCriterio(5, 1) = obeSupuesto.NumeroProyectado

                                Dim obeGeneral As BusinessEntity.General
                                Dim obrGeneral As BusinessRules.General = New BusinessRules.General

                                obeGeneral = obrGeneral.leer(Int32.Parse(ecTablaGeneral.MONEDA), obeSupuesto.CodMoneda)
                                arrCriterio(6, 0) = "Moneda"
                                arrCriterio(6, 1) = obeGeneral.DesCorta

                                obeGeneral = obrGeneral.leer(Int32.Parse(ecTablaGeneral.UNIDAD_IMPORTE), obeSupuesto.CodUnidad)
                                arrCriterio(7, 0) = "Unidad"
                                arrCriterio(7, 1) = obeGeneral.Descripcion

                                arrCriterio(8, 0) = "Analista"
                                arrCriterio(8, 1) = obeMetodizado.NombreAnalista
                                arrCriterio(9, 0) = "Ejecutivo"
                                arrCriterio(9, 1) = obeMetodizado.NombreEjecutivo

                                Util.exportarExcel(dgrdMnt, strTitulo, arrCriterio)
                            Else
                                Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de " & "Periodo")
                            End If
                        Else
                            Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de " & "Periodo Anterior")
                        End If
                    Else
                        Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de " & "Metodizado")
                    End If
                Else
                    Me.muestraAlerta(ccALERTA_REGISTRO_NO_ENCONTRADO & " de " & ccID_WEBUI_MNT)
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Sub cargarSupuestoProyectado(ByVal pintCodSupuesto As Integer)
            Dim dsSupuestoProyectado As DataSet
            Dim strTitulo As String

            Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto

            Dim obePeriodoProyectadoLst As BusinessEntity.PeriodoProyectadoLst = obrSupuesto.listarPeriodoProyectado(pintCodSupuesto)
            For Each obePeriodoProyectado As BusinessEntity.PeriodoProyectado In obePeriodoProyectadoLst
                If obePeriodoProyectado.Tipo = Int32.Parse(ecTipoPeriodoProyectado.HISTORICO) Then
                    strTitulo = "HISTORICO"
                Else
                    strTitulo = "PROY"
                End If
                agregarColPeriodo(strTitulo, obePeriodoProyectado.FecProyectado, "ImportePry" + obePeriodoProyectado.CodProyectado.ToString())
            Next
            dsSupuestoProyectado = obrSupuesto.filtrarSupuestoProyectado(pintCodSupuesto)

            Dim intAnchoColumnas As Integer = (Me.ccANCHO_DGRID_PERIODO + (Me.ccANCHO_COLUMNA_PERIODO * (obePeriodoProyectadoLst.Count + 1)))

            dgrdMnt.DataSource = dsSupuestoProyectado
            dgrdMnt.DataKeyField = "CodCuentaSupuesto"
            dgrdMnt.Width = New Unit(intAnchoColumnas, UnitType.Pixel)
            dgrdMnt.DataBind()
        End Sub

        Private Sub agregarColPeriodo(ByVal pstrTitulo As String, ByVal pdteFecProyectado As DateTime, ByVal pstrNombreCampo As String)
            Dim dgcImporte As New TemplateColumn
            Dim dgtHeader As PlantillaDgcImporte = New PlantillaDgcImporte(ListItemType.Header)
            dgtHeader.Titulo = pstrTitulo
            dgtHeader.FecProyectado = pdteFecProyectado
            dgcImporte.HeaderTemplate = dgtHeader

            Dim dgtItem As PlantillaDgcImporte
            dgtItem = New PlantillaDgcImporte(ListItemType.Item)
            dgtItem.Formato = "{0:#,##0}"
            dgtItem.DataFieldNameImporte = pstrNombreCampo

            dgcImporte.ItemTemplate = dgtItem
            dgcImporte.ItemStyle.HorizontalAlign = HorizontalAlign.Right

            dgrdMnt.Columns.Add(dgcImporte)
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
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