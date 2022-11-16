'*************************************************************
'Proposito:
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 14/12/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.Common
Imports CEF.Common.Globals
Imports System.Text
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class consParametrica
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

        Private Const ccID_CodAnalisis_InformacionCuantitativa As Short = 3
        Private Const ccANCHO_DGRID_CUENTA As Short = 310
        Private Const ccANCHO_COLUMNA_CUENTA As Short = 80
        Private Const ccINICIO_COLUMNA_CUENTA As Short = 1

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

            Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements ITemplate.InstantiateIn
                Select Case Me.lTemplateType
                    Case ListItemType.Header
                        Dim lc As New Literal
                        lc.Text = cabecera(Me.lTitulo)
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
                            If IsNumeric(ltl.Text) Then
                                ltl.Text = String.Format(Me.lFormato, Math.Round(CType(ltl.Text, Decimal), 2))
                            End If
                        Else
                            ltl.Text = DataBinder.Eval(container.DataItem, Me.lDataFieldNameImporte)
                        End If
                    End If
                End If
            End Sub

            Private Function cabecera(ByVal pstrTitulo As String) As String
                Dim sbHtml As StringBuilder = New StringBuilder
                sbHtml.Append("<TABLE class=""CabeceraRegistro"">")
                sbHtml.Append("<TR><TD>" + pstrTitulo + "</TD></TR>")
                sbHtml.Append("<TR><TD>")
                sbHtml.Append("</TD></TR>")
                sbHtml.Append("</TABLE>")
                Return (sbHtml.ToString())
            End Function
        End Class


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
            imgFecPeriodo.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecPeriodo.ClientID + "');"
            txtFecPeriodo.Attributes.Add("onKeyUp", "javascript:DateFormat(this,this.value,event,false,'3')")
            txtFecPeriodo.Attributes.Add("onblur", "javascript:DateFormat(this,this.value,event,true,'3')")
            Me.dropMoneda.Attributes.Add("onchange", "javascript:fCambiarMoneda();")
            ' Me.btnExportar.Attributes.Add("onclick", "javascript:submit();")
        End Sub

        Private Sub cargarDatos()
            cargarDatosCuenta()
            pCargarCombos()
            bloquearControles()
        End Sub

        Private Sub pCargarCombos()
            dropMoneda.DataSource = buscarGeneralTabla(ecTablaGeneral.MONEDA)
            dropMoneda.DataTextField = "Descripcion"
            dropMoneda.DataValueField = "CodItem"
            dropMoneda.DataBind()

            For Each oItem As ListItem In dropMoneda.Items
                oItem.Text = "MILES de " + oItem.Text.ToUpper.Trim
            Next
        End Sub

        Private Sub cargarDatosCuenta()
            Try
                Dim obrCuentaAnalisis As BusinessRules.CuentaAnalisis = New BusinessRules.CuentaAnalisis

                Dim dsCuentaAnalisis As DataSet
                dsCuentaAnalisis = obrCuentaAnalisis.ListarPorAnalisis(ccID_CodAnalisis_InformacionCuantitativa, 0, 1)

                If dsCuentaAnalisis.Tables.Count > 0 Then
                    dgrdCuentasPorAsignar.DataSource = dsCuentaAnalisis
                    dgrdCuentasPorAsignar.DataKeyField = "CodCuentaAnalisis"
                    dgrdCuentasPorAsignar.DataBind()
                Else
                    dgrdCuentasPorAsignar.DataSource = New DataTable
                    dgrdCuentasPorAsignar.DataKeyField = "CodUsuario"
                    dgrdCuentasPorAsignar.DataBind()
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
        End Sub

        Private Sub bloquearControles(Optional ByVal bolBloqueo As Boolean = True)
            If bolBloqueo Then
                btnAsignarCuenta.Attributes.Remove("onclick")
                btnExcluirCuenta.Attributes.Remove("onclick")
            Else
                btnAsignarCuenta.Attributes.Add("onclick", String.Format("javascript:alert('{0}'); return(false);", ccALERTA_OPERACION_EN_PROCESO))
                btnExcluirCuenta.Attributes.Add("onclick", String.Format("javascript:alert('{0}'); return(false);", ccALERTA_OPERACION_EN_PROCESO))
            End If
            lblNumRegEncontrados.Text = 0
        End Sub

        Private Sub btnAsignarCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarCuenta.Click
            pSeleccionarCuentas()
        End Sub

        Private Sub pSeleccionarCuentas()
            Try
                Dim obrCuentaAnalisis As BusinessRules.CuentaAnalisis = New BusinessRules.CuentaAnalisis

                Dim obeCuentaAnalisisLista As BusinessEntity.CuentaAnalisis = New BusinessEntity.CuentaAnalisis
                Dim oArrCodsCuentas As New ArrayList

                For Each dgrdItem As DataGridItem In dgrdCuentasPorAsignar.Items
                    Dim chkItem As CheckBox = CType(dgrdItem.FindControl("chkItem"), CheckBox)
                    If chkItem.Checked Then
                        Dim obeCuentaAnalisis As BusinessEntity.CuentaAnalisis = New BusinessEntity.CuentaAnalisis
                        oArrCodsCuentas.Add(CType(dgrdCuentasPorAsignar.DataKeys(dgrdItem.ItemIndex), String))
                        obeCuentaAnalisis.CodCuentaAnalisis = dgrdCuentasPorAsignar.DataKeys(dgrdItem.ItemIndex)
                        Dim dsCuentaAnalisis As DataSet
                        dsCuentaAnalisis = obrCuentaAnalisis.ListarPorAnalisis(ccID_CodAnalisis_InformacionCuantitativa, dgrdCuentasPorAsignar.DataKeys(dgrdItem.ItemIndex), 2)
                        obeCuentaAnalisis.Descripcion = dsCuentaAnalisis.Tables(0).Rows(0)("Descripcion")
                        obeCuentaAnalisis.ImporteRango1 = Decimal.MinValue
                        obeCuentaAnalisis.ImporteRango2 = Decimal.MinValue
                        obeCuentaAnalisisLista.CuentaAnalisisList.Add(obeCuentaAnalisis)
                    End If
                Next

                pCopiarRangosCuentas(obeCuentaAnalisisLista)

                dgrdCuentasConsulta.DataSource = obeCuentaAnalisisLista.CuentaAnalisisList
                dgrdCuentasConsulta.DataKeyField = "CodCuentaAnalisis"
                dgrdCuentasConsulta.DataBind()

                'hidCodsCuentas.Value = String.Join(",", oArrCodsCuentas.ToArray(System.Type.GetType("System.String", True, True)))
                UpdatePanel1.PostCallBackFunction = ""
                UpdatePanel1.UpdateAfterCallBack = True

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub

        Private Sub btnInicializar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicializar.Click
            txtFecPeriodo.Text = String.Empty

            dgrdMnt.CurrentPageIndex = 0
            dgrdMnt.DataSource = New DataTable
            dgrdMnt.DataBind()

            dgrdCuentasConsulta.CurrentPageIndex = 0
            dgrdCuentasConsulta.DataSource = New DataTable
            dgrdCuentasConsulta.DataBind()

            lblNumRegEncontrados.Text = 0
            UpdatePanel1.PostCallBackFunction = ""
            UpdatePanel1.UpdateAfterCallBack = True
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            cargarConsultaSeleccion()
        End Sub

        Private Sub cargarConsultaSeleccion()
            Try
                Dim dsConsultaParametrica As DataSet
                Dim strTitulo As String
                Dim dtFecPeriodo As Date = DateTime.Parse(txtFecPeriodo.Text)

                Dim obrCuentaAnalisis As BusinessRules.CuentaAnalisis = New BusinessRules.CuentaAnalisis

                Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                Dim obeCuentaAnalisisLista As BusinessEntity.CuentaAnalisis = New BusinessEntity.CuentaAnalisis

                For Each dgrdItem As DataGridItem In dgrdCuentasConsulta.Items
                    Dim obeCuentaAnalisis As BusinessEntity.CuentaAnalisis = New BusinessEntity.CuentaAnalisis
                    obeCuentaAnalisis.CodCuentaAnalisis = dgrdCuentasConsulta.DataKeys(dgrdItem.ItemIndex)
                    Dim dsCuentaAnalisis As DataSet = obrCuentaAnalisis.ListarPorAnalisis(ccID_CodAnalisis_InformacionCuantitativa, dgrdCuentasConsulta.DataKeys(dgrdItem.ItemIndex), 2)
                    obeCuentaAnalisis.Descripcion = dsCuentaAnalisis.Tables(0).Rows(0)("Descripcion")
                    Dim txtRango1 As TextBox = CType(dgrdCuentasConsulta.Items(dgrdItem.ItemIndex).FindControl("txtRango1"), TextBox)
                    If Not txtRango1.Text = String.Empty Then
                        obeCuentaAnalisis.ImporteRango1 = Decimal.Parse(txtRango1.Text)
                    End If
                    Dim txtRango2 As TextBox = CType(dgrdCuentasConsulta.Items(dgrdItem.ItemIndex).FindControl("txtRango2"), TextBox)
                    If Not txtRango2.Text = String.Empty Then
                        obeCuentaAnalisis.ImporteRango2 = Decimal.Parse(txtRango2.Text)
                    End If

                    'If txtRango1.Text <> String.Empty OrElse txtRango2.Text <> String.Empty Then
                    obeCuentaAnalisisLista.CuentaAnalisisList.Add(obeCuentaAnalisis)

                    strTitulo = obeCuentaAnalisis.Descripcion
                    agregarColCuentaAnalisis(strTitulo, "ImporteCta" + dgrdCuentasConsulta.DataKeys(dgrdItem.ItemIndex).ToString)
                    'End If
                Next

                dsConsultaParametrica = obrMetodizado.filtrarConsultaParametricaporMoneda(dtFecPeriodo, obeCuentaAnalisisLista, dropMoneda.SelectedValue)

                pLimpiarBlancos(dsConsultaParametrica)

                Dim intAnchoColumnas As Integer = (Me.ccANCHO_DGRID_CUENTA + (Me.ccANCHO_COLUMNA_CUENTA * (dgrdMnt.Items.Count + 1)))

                dgrdMnt.DataSource = dsConsultaParametrica
                dgrdMnt.DataKeyField = "CUCliente"
                dgrdMnt.Width = New Unit(intAnchoColumnas, UnitType.Pixel)
                dgrdMnt.DataBind()

                'Enviamos un mensaje si no Existe Resultado de la Búsqueda
                If dsConsultaParametrica.Tables(0).Rows.Count = 0 Then
                    Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                    'UpdatePanel1.PostCallBackFunction = "fAlertaNoDatos"
                Else
                    UpdatePanel1.PostCallBackFunction = ""
                End If
                lblNumRegEncontrados.Text = dsConsultaParametrica.Tables(0).Rows.Count

                UpdatePanel1.UpdateAfterCallBack = True

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
        End Sub

        Private Sub agregarColCuentaAnalisis(ByVal pstrTitulo As String, ByVal pstrNombreCampo As String)
            Dim dgcImporte As New TemplateColumn
            Dim dgtHeader As PlantillaDgcImporte = New PlantillaDgcImporte(ListItemType.Header)
            dgtHeader.Titulo = pstrTitulo
            dgcImporte.HeaderTemplate = dgtHeader

            Dim dgtItem As PlantillaDgcImporte
            dgtItem = New PlantillaDgcImporte(ListItemType.Item)
            'dgtItem.Formato = "{0:#,##0}"
            dgtItem.Formato = "{0:#,##0.##}"
            'dgtItem.Formato = "{0:N2}"

            dgtItem.DataFieldNameImporte = pstrNombreCampo

            dgcImporte.ItemTemplate = dgtItem
            dgcImporte.ItemStyle.HorizontalAlign = HorizontalAlign.Right

            dgrdMnt.Columns.Add(dgcImporte)
        End Sub

        Private Sub pLimpiarBlancos(ByRef argDsConsultaParametrica As DataSet)
            Dim arrFilasAEliminar As New ArrayList
            For Each oDataRow As DataRow In argDsConsultaParametrica.Tables(0).Rows
                For intColumna As Integer = 2 To argDsConsultaParametrica.Tables(0).Columns.Count - 1
                    If oDataRow.Item(intColumna) Is DBNull.Value Then
                        arrFilasAEliminar.Add(oDataRow)
                        Exit For
                    Else
                        If IsNumeric(oDataRow.Item(intColumna)) Then
                            If oDataRow.Item(intColumna) = 0 Then
                                arrFilasAEliminar.Add(oDataRow)
                                Exit For
                            End If
                        Else
                            If Trim(oDataRow.Item(intColumna)) = String.Empty Then
                                arrFilasAEliminar.Add(oDataRow)
                                Exit For
                            End If
                        End If
                    End If
                Next
            Next
            For Each oDataRow As DataRow In arrFilasAEliminar
                argDsConsultaParametrica.Tables(0).Rows.Remove(oDataRow)
            Next
        End Sub

        Private Sub btnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportar.Click
            pExportarExcel()
        End Sub

        Private Sub dropMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dropMoneda.SelectedIndexChanged
            If IsDate(txtFecPeriodo.Text) Then
                cargarConsultaSeleccion()
            End If
        End Sub

        Private Sub lnk_Exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnk_Exportar.Click
            pExportarExcel()
        End Sub

        Private Sub pExportarExcel()
            Try
                If Int32.Parse(lblNumRegEncontrados.Text) > 0 Then
                    Dim dsConsultaParametrica As DataSet
                    Dim strTitulo As String
                    Dim dtFecPeriodo As Date = DateTime.Parse(txtFecPeriodo.Text)
                    Dim strMoneda As String = Me.buscarGeneralItem(ecTablaGeneral.MONEDA, dropMoneda.SelectedValue).Descripcion

                    Dim obrCuentaAnalisis As BusinessRules.CuentaAnalisis = New BusinessRules.CuentaAnalisis

                    Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                    Dim obeCuentaAnalisisLista As BusinessEntity.CuentaAnalisis = New BusinessEntity.CuentaAnalisis

                    For Each dgrdItem As DataGridItem In dgrdCuentasConsulta.Items
                        Dim obeCuentaAnalisis As BusinessEntity.CuentaAnalisis = New BusinessEntity.CuentaAnalisis
                        obeCuentaAnalisis.CodCuentaAnalisis = dgrdCuentasConsulta.DataKeys(dgrdItem.ItemIndex)
                        Dim dsCuentaAnalisis As DataSet = obrCuentaAnalisis.ListarPorAnalisis(ccID_CodAnalisis_InformacionCuantitativa, dgrdCuentasConsulta.DataKeys(dgrdItem.ItemIndex), 2)
                        obeCuentaAnalisis.Descripcion = dsCuentaAnalisis.Tables(0).Rows(0)("Descripcion")
                        Dim txtRango1 As TextBox = CType(dgrdCuentasConsulta.Items(dgrdItem.ItemIndex).FindControl("txtRango1"), TextBox)
                        If Not txtRango1.Text = String.Empty Then
                            obeCuentaAnalisis.ImporteRango1 = Decimal.Parse(txtRango1.Text)
                        End If
                        Dim txtRango2 As TextBox = CType(dgrdCuentasConsulta.Items(dgrdItem.ItemIndex).FindControl("txtRango2"), TextBox)
                        If Not txtRango2.Text = String.Empty Then
                            obeCuentaAnalisis.ImporteRango2 = Decimal.Parse(txtRango2.Text)
                        End If
                        obeCuentaAnalisisLista.CuentaAnalisisList.Add(obeCuentaAnalisis)
                        strTitulo = obeCuentaAnalisis.Descripcion
                        agregarColCuentaAnalisis(strTitulo, "ImporteCta" + dgrdCuentasConsulta.DataKeys(dgrdItem.ItemIndex).ToString)
                    Next

                    dsConsultaParametrica = obrMetodizado.filtrarConsultaParametricaporMoneda(dtFecPeriodo, obeCuentaAnalisisLista, dropMoneda.SelectedValue)

                    pLimpiarBlancos(dsConsultaParametrica)

                    Dim intAnchoColumnas As Integer = (Me.ccANCHO_DGRID_CUENTA + (Me.ccANCHO_COLUMNA_CUENTA * (dgrdMnt.Items.Count + 1)))

                    dgrdMnt.DataSource = dsConsultaParametrica
                    dgrdMnt.DataKeyField = "CUCliente"
                    dgrdMnt.Width = New Unit(intAnchoColumnas, UnitType.Pixel)

                    'dgrdMnt.HeaderStyle.BackColor = System.Drawing.ColorTranslator.FromHtml("#568ed1")
                    'dgrdMnt.HeaderStyle.ForeColor = System.Drawing.ColorTranslator.FromHtml("#ffffff")

                    dgrdMnt.DataBind()

                    Dim strTituloExp As String = "Consulta Paramétrica"
                    Dim arrCriterio(0, 1) As String

                    arrCriterio(0, 0) = "Periodo"
                    arrCriterio(0, 1) = Format(dtFecPeriodo, "dd/MM/yyyy") + " (Expresado en MILES de " + strMoneda + ")"

                    Util.exportarExcel(dgrdMnt, strTituloExp, arrCriterio)
                Else
                    Me.muestraAlerta("No Existe Registros a Exportar")
                End If
            Catch exAbort As Threading.ThreadAbortException
                'Excepción causada siempre al terminar manualmente el response.
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
        End Sub

        Private Sub btnExcluirCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluirCuenta.Click
            For Each dgrdItemSource As DataGridItem In dgrdCuentasPorAsignar.Items
                Dim bolEncontrado As Boolean = False
                Dim chkItemSource As CheckBox = CType(dgrdItemSource.FindControl("chkItem"), CheckBox)
                If chkItemSource.Checked Then
                    Dim strCodCuentaAnalisis As String = dgrdCuentasPorAsignar.DataKeys(dgrdItemSource.ItemIndex)

                    For Each dgrdItem As DataGridItem In dgrdCuentasConsulta.Items
                        If strCodCuentaAnalisis = dgrdCuentasConsulta.DataKeys(dgrdItem.ItemIndex) Then
                            bolEncontrado = True

                            Dim chkItem As CheckBox = CType(dgrdItem.FindControl("chkItem"), CheckBox)
                            If chkItem.Checked Then
                                chkItemSource.Checked = False
                            End If

                            Exit For
                        End If
                    Next
                    'If Not bolEncontrado Then
                    '    chkItemSource.Checked = False
                    'End If
                End If
            Next

            pSeleccionarCuentas()

        End Sub

        Private Sub pCopiarRangosCuentas(ByRef argCuentaAnalisisLista As BusinessEntity.CuentaAnalisis)
            If dgrdCuentasConsulta.Items.Count > 0 Then
                For Each oCuentaAnalisis As BusinessEntity.CuentaAnalisis In argCuentaAnalisisLista.CuentaAnalisisList
                    For Each dgrdItem As DataGridItem In dgrdCuentasConsulta.Items
                        If dgrdCuentasConsulta.DataKeys(dgrdItem.ItemIndex) = oCuentaAnalisis.CodCuentaAnalisis Then
                            Dim txtRango1 As TextBox = CType(dgrdItem.FindControl("txtRango1"), TextBox)
                            Dim txtRango2 As TextBox = CType(dgrdItem.FindControl("txtRango2"), TextBox)
                            If IsNumeric(txtRango1.Text) Then
                                oCuentaAnalisis.ImporteRango1 = CType(txtRango1.Text, Decimal)
                            Else
                                oCuentaAnalisis.ImporteRango1 = Decimal.MinValue
                            End If
                            If IsNumeric(txtRango2.Text) Then
                                oCuentaAnalisis.ImporteRango2 = CType(txtRango2.Text, Decimal)
                            Else
                                oCuentaAnalisis.ImporteRango2 = Decimal.MinValue
                            End If

                            Exit For
                        End If
                    Next
                Next
            End If
        End Sub

    End Class
End Namespace