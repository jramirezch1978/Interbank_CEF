'*************************************************************
'Proposito: Descarga data de Metodizados
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 06/12/2006
'Modificado por: 
'Fecha Mod.: 
'*************************************************************

Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class consDescargaData
        Inherits PageBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents vsmMnt As System.Web.UI.WebControls.ValidationSummary
        Protected WithEvents lbl_Validado As System.Web.UI.WebControls.Label
        'Protected WithEvents dgrPrioridad As System.Web.UI.WebControls.DataGrid
        'Protected WithEvents tr_Prioridad As System.Web.UI.HtmlControls.HtmlTableRow

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
            Try
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
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        Private Sub cargaScript()
            imgFecPeriodo.Attributes("onclick") = "javascript:f_AbrirCalendario('" + txtFecPeriodo.ClientID + "');"
            txtFecPeriodo.Attributes.Add("onKeyUp", "javascript:DateFormat(this,this.value,event,false,'3')")
            txtFecPeriodo.Attributes.Add("onblur", "javascript:DateFormat(this,this.value,event,true,'3')")
            Me.lnk_Validados.Attributes.Add("onclick", "javascript:return(fCambiarPestaniaActual(1));")
            'Me.lnk_Prioridad.Attributes.Add("onclick", "javascript:return(fCambiarPestaniaActual(2));")
            Me.dropMoneda.Attributes.Add("onchange", "javascript:fCambiarMoneda();")
            Me.ddlEstado.Attributes.Add("onchange", "javascript:fCambiarEstado();")
        End Sub

        Private Sub cargarDatos()
            pCargarCombos()
            pMostrarPestaniaActual()
        End Sub

        Private Sub pCargarCombos()
            dropMoneda.DataSource = buscarGeneralTabla(ecTablaGeneral.MONEDA)
            dropMoneda.DataTextField = "Descripcion"
            dropMoneda.DataValueField = "CodItem"
            dropMoneda.DataBind()

            ddlEstado.DataSource = buscarGeneralTabla(ecTablaGeneral.ESTADO_PERIODO)
            ddlEstado.DataTextField = "Descripcion"
            ddlEstado.DataValueField = "CodItem"
            ddlEstado.DataBind()

            For Each oItem As ListItem In dropMoneda.Items
                oItem.Text = "MILES de " + oItem.Text.ToUpper.Trim
            Next

            lnk_Validados.Text = ddlEstado.SelectedItem.Text
        End Sub

        Private Sub pMostrarPestaniaActual()
            If Me.hidPestaniaActual.Value = "1" Then
                Me.img_tab1_1.Src = "../imagen/bordes/brd_TabIzqActivo_blue.gif"
                Me.tab1_2.Attributes.Add("Class", "TabActivo")
                Me.tab1_2.Attributes.Add("noWrap background", "../imagen/bordes/brd_TabActivo_blue.gif")
                Me.img_tab1_3.Src = "../imagen/bordes/brd_TabDerActivo_blue.gif"

                'Me.img_tab2_1.Src = "../imagen/bordes/brd_TabIzqNoActivo_blue.gif"
                'Me.tab2_2.Attributes.Add("Class", "TabNoActivo")
                'Me.tab2_2.Attributes.Add("noWrap background", "../imagen/bordes/brd_TabNoActivo_blue.gif")
                'Me.img_tab2_3.Src = "../imagen/bordes/brd_TabDerNoActivo_blue.gif"

                Me.dgrdMnt.Visible = True
                'Me.dgrPrioridad.Visible = False
                Me.tr_Validados.Visible = True
                'Me.tr_Prioridad.Visible = False
            Else
                Me.img_tab1_1.Src = "../imagen/bordes/brd_TabIzqNoActivo_blue.gif"
                Me.tab1_2.Attributes.Add("Class", "TabNoActivo")
                Me.tab1_2.Attributes.Add("noWrap background", "../imagen/bordes/brd_TabNoActivo_blue.gif")
                Me.img_tab1_3.Src = "../imagen/bordes/brd_TabDerNoActivo_blue.gif"

                'Me.img_tab2_1.Src = "../imagen/bordes/brd_TabIzqActivo_blue.gif"
                'Me.tab2_2.Attributes.Add("Class", "TabActivo")
                'Me.tab2_2.Attributes.Add("noWrap background", "../imagen/bordes/brd_TabActivo_blue.gif")
                'Me.img_tab2_3.Src = "../imagen/bordes/brd_TabDerActivo_blue.gif"

                Me.dgrdMnt.Visible = False
                'Me.dgrPrioridad.Visible = True
                Me.tr_Validados.Visible = False
                'Me.tr_Prioridad.Visible = True
            End If
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            buscar()
        End Sub

        Private Sub buscar(Optional ByVal pintPageIndex As Integer = 1)
            Try
                If Me.hidPestaniaActual.Value = "1" Then
                    buscarValidados(pintPageIndex)
                    'Else
                    '    buscarPrioridades()
                End If
                pMostrarPestaniaActual()
                UpdatePanel1.UpdateAfterCallBack = True

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        Private Sub buscarValidados(ByVal pintPageIndex As Integer)
            Dim dteFecPeriodo As DateTime
            If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            activarReportes(ecReporte.DescargaData, False)

            'Filtra la Descarga de Datos
            Dim dsMetodizado As DataSet = obrMetodizado.generarDescargaDataporMoneda(dteFecPeriodo, dropMoneda.SelectedValue, ddlEstado.SelectedValue, pintPageIndex, dgrdMnt.PageSize)
            If dsMetodizado Is Nothing Then
                dgrdMnt.DataSource = New DataTable
                dgrdMnt.DataBind()
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR)
                lblNumReg.Text = 0
            Else
                If dsMetodizado.Tables.Count = 0 Then
                    Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                Else
                    dgrdMnt.DataSource = dsMetodizado
                    dgrdMnt.DataBind()
                    Dim intNumReg As Integer = dsMetodizado.Tables(0).Rows.Count
                    If intNumReg = 0 Then
                        Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                    Else
                        'Activamos el reporte en Excel
                        activarReportes(ecReporte.DescargaData, True)
                    End If
                    lblNumReg.Text = intNumReg
                End If
            End If
        End Sub

        'Private Sub buscarPrioridades()
        '    Dim dteFecPeriodo As DateTime
        '    If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)

        '    Dim obiMetodizado As BusinessInterface.IMetodizado
        '    Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
        '    obiMetodizado = CType(obrMetodizado, BusinessInterface.IMetodizado)
        '    activarReportes(ecReporte.DescargaData, False)

        '    'Filtra la Descarga de Datos
        '    Dim dsMetodizado As DataSet = obiMetodizado.generarDescargaDataPrioridad(dteFecPeriodo, dropMoneda.SelectedValue)
        '    If dsMetodizado Is Nothing Then
        '        dgrPrioridad.DataSource = New DataTable
        '        dgrPrioridad.DataBind()
        '        Me.muestraAlerta(ccALERTA_ERROR_BUSCAR)
        '        lblNumReg.Text = 0
        '    Else
        '        If dsMetodizado.Tables.Count = 0 Then
        '            Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
        '        Else
        '            dgrPrioridad.DataSource = dsMetodizado
        '            dgrPrioridad.DataBind()
        '            Dim intNumReg As Integer = dsMetodizado.Tables(0).Rows.Count
        '            If intNumReg = 0 Then
        '                Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
        '            Else
        '                'Activamos el reporte en Excel
        '                activarReportes(ecReporte.DescargaData, True)
        '            End If
        '            lblNumReg.Text = intNumReg
        '        End If
        '    End If
        'End Sub

        Private Sub btnInicializar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInicializar.Click
            inicializarControles()
        End Sub

        Private Sub inicializarControles()
            txtFecPeriodo.Text = String.Empty

            dgrdMnt.CurrentPageIndex = 0
            dgrdMnt.DataSource = New DataTable
            dgrdMnt.DataBind()
            lblNumReg.Text = 0
            'dgrPrioridad.DataSource = Nothing
            'dgrPrioridad.DataBind()
            activarReportes(ecReporte.DescargaData, False)
            Me.hidPestaniaActual.Value = "1"
            pMostrarPestaniaActual()
            UpdatePanel1.UpdateAfterCallBack = True
        End Sub

        Private Sub activarReportes(ByVal pordReporte As ecReporte, Optional ByVal bolActivar As Boolean = True)
            Dim dteFecPeriodo As DateTime
            If IsDate(txtFecPeriodo.Text) Then dteFecPeriodo = DateTime.Parse(txtFecPeriodo.Text)

            If pordReporte = ecReporte.DescargaData Then
                If bolActivar Then
                    If Me.hidPestaniaActual.Value = "1" Then
                        imgExpExcel.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpDescargaData.aspx?dteFecPeriodo={0}&intMoneda={1}&intPeriodo={2}&strEstado={3}');", dteFecPeriodo, dropMoneda.SelectedValue, ddlEstado.SelectedValue, ddlEstado.SelectedItem.Text))
                        lnkExpExecel.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpDescargaData.aspx?dteFecPeriodo={0}&intMoneda={1}&intPeriodo={2}&strEstado={3}');", dteFecPeriodo, dropMoneda.SelectedValue, ddlEstado.SelectedValue, ddlEstado.SelectedItem.Text))
                        'Else
                        '    imgExpExcel.Attributes.Add("onclick", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpDescargaDataPrioridad.aspx?dteFecPeriodo={0}&intMoneda={1}&intPeriodo={2}');", dteFecPeriodo, dropMoneda.SelectedValue, ddlEstado.SelectedValue))
                        '    lnkExpExecel.Attributes.Add("href", String.Format("javascript:f_AbrirReporte('winRpt','../PagRpt/rvwExpDescargaDataPrioridad.aspx?dteFecPeriodo={0}&intMoneda={1}&intPeriodo={2}');", dteFecPeriodo, dropMoneda.SelectedValue, ddlEstado.SelectedValue))
                    End If
                Else
                    imgExpExcel.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_IMPRIMIR_NO_EXISTE_PERIODO))
                    lnkExpExecel.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_IMPRIMIR_NO_EXISTE_PERIODO))
                End If
            End If
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    'e.Item.Cells(7).Text = Format(CDbl(e.Item.Cells(7).Text), "##,##0")
                    'e.Item.Cells(8).Text = Format(CDbl(e.Item.Cells(8).Text), "##,##0")
                    'e.Item.Cells(9).Text = Format(CDbl(e.Item.Cells(9).Text), "##,##0")
                    'e.Item.Cells(10).Text = Format(CDbl(e.Item.Cells(10).Text), "##,##0")
                    'e.Item.Cells(11).Text = Format(CDbl(e.Item.Cells(11).Text), "##,##0")
                    'e.Item.Cells(12).Text = Format(CDbl(e.Item.Cells(12).Text), "##,##0")
                    'e.Item.Cells(13).Text = Format(CDbl(e.Item.Cells(13).Text), "##,##0")
                    'e.Item.Cells(14).Text = Format(CDbl(e.Item.Cells(14).Text), "##,##0")
                    'e.Item.Cells(15).Text = Format(CDbl(e.Item.Cells(15).Text), "##,##0")
                    'e.Item.Cells(16).Text = Format(CDbl(e.Item.Cells(16).Text), "##,##0")
                    'e.Item.Cells(17).Text = Format(CDbl(e.Item.Cells(17).Text), "##,##0")
                    'e.Item.Cells(18).Text = Format(CDbl(e.Item.Cells(18).Text), "##,##0")
                    'e.Item.Cells(19).Text = Format(CDbl(e.Item.Cells(19).Text), "##,##0")
                    'e.Item.Cells(20).Text = Format(CDbl(e.Item.Cells(20).Text), "##,##0")
                    'e.Item.Cells(21).Text = Format(CDbl(e.Item.Cells(21).Text), "##,##0")
                    'e.Item.Cells(22).Text = Format(CDbl(e.Item.Cells(22).Text), "##,##0")
                    'e.Item.Cells(23).Text = Format(CDbl(e.Item.Cells(23).Text), "##,##0")
                    'e.Item.Cells(24).Text = Format(CDbl(e.Item.Cells(24).Text), "##,##0")
                    'e.Item.Cells(25).Text = Format(CDbl(e.Item.Cells(25).Text), "##,##0")
                    'e.Item.Cells(26).Text = Format(CDbl(e.Item.Cells(26).Text), "##,##0")
                    'e.Item.Cells(27).Text = Format(CDbl(e.Item.Cells(27).Text), "##,##0")
                    'e.Item.Cells(28).Text = Format(CDbl(e.Item.Cells(28).Text), "##,##0")
                    'e.Item.Cells(29).Text = Format(CDbl(e.Item.Cells(29).Text), "##,##0")
                    'e.Item.Cells(30).Text = Format(CDbl(e.Item.Cells(30).Text), "##,##0")
                    'e.Item.Cells(31).Text = Format(CDbl(e.Item.Cells(31).Text), "##,##0")
                    'e.Item.Cells(32).Text = Format(CDbl(e.Item.Cells(32).Text), "##,##0")
                    'e.Item.Cells(33).Text = Format(CDbl(e.Item.Cells(33).Text), "##,##0")
                    'e.Item.Cells(34).Text = Format(CDbl(e.Item.Cells(34).Text), "##,##0")
                    'e.Item.Cells(35).Text = Format(CDbl(e.Item.Cells(35).Text), "##,##0")
                    'e.Item.Cells(36).Text = Format(CDbl(e.Item.Cells(36).Text), "##,##0")
                    'e.Item.Cells(37).Text = Format(CDbl(e.Item.Cells(37).Text), "##,##0")
                    'e.Item.Cells(38).Text = Format(CDbl(e.Item.Cells(38).Text), "##,##0")
                    'e.Item.Cells(39).Text = Format(CDbl(e.Item.Cells(39).Text), "##,##0")
                    'e.Item.Cells(40).Text = Format(CDbl(e.Item.Cells(40).Text), "##,##0")
                    'e.Item.Cells(41).Text = Format(CDbl(e.Item.Cells(41).Text), "##,##0")
                    'e.Item.Cells(42).Text = Format(CDbl(e.Item.Cells(42).Text), "##,##0")
                    'e.Item.Cells(43).Text = Format(CDate(e.Item.Cells(43).Text), "dd/MM/yyyy")

                    e.Item.Cells(7).Text = Format(CDbl(e.Item.Cells(7).Text), "##,##0")
                    e.Item.Cells(8).Text = Format(CDbl(e.Item.Cells(8).Text), "##,##0")
                    e.Item.Cells(9).Text = Format(CDbl(e.Item.Cells(9).Text), "##,##0")
                    e.Item.Cells(10).Text = Format(CDbl(e.Item.Cells(10).Text), "##,##0")
                    e.Item.Cells(11).Text = Format(CDbl(e.Item.Cells(11).Text), "##,##0")
                    e.Item.Cells(12).Text = Format(CDbl(e.Item.Cells(12).Text), "##,##0")
                    e.Item.Cells(13).Text = Format(CDbl(e.Item.Cells(13).Text), "##,##0")
                    e.Item.Cells(14).Text = Format(CDbl(e.Item.Cells(14).Text), "##,##0")
                    e.Item.Cells(15).Text = Format(CDbl(e.Item.Cells(15).Text), "##,##0")
                    e.Item.Cells(16).Text = Format(CDbl(e.Item.Cells(16).Text), "##,##0")
                    e.Item.Cells(17).Text = Format(CDbl(e.Item.Cells(17).Text), "##,##0")
                    e.Item.Cells(18).Text = Format(CDbl(e.Item.Cells(18).Text), "##,##0")
                    e.Item.Cells(19).Text = Format(CDbl(e.Item.Cells(19).Text), "##,##0")
                    e.Item.Cells(20).Text = Format(CDbl(e.Item.Cells(20).Text), "##,##0")
                    e.Item.Cells(21).Text = Format(CDbl(e.Item.Cells(21).Text), "##,##0")
                    e.Item.Cells(22).Text = Format(CDbl(e.Item.Cells(22).Text), "##,##0")
                    e.Item.Cells(23).Text = Format(CDbl(e.Item.Cells(23).Text), "##,##0")
                    e.Item.Cells(24).Text = Format(CDbl(e.Item.Cells(24).Text), "##,##0")
                    e.Item.Cells(25).Text = Format(CDbl(e.Item.Cells(25).Text), "##,##0")
                    e.Item.Cells(26).Text = Format(CDbl(e.Item.Cells(26).Text), "##,##0")
                    e.Item.Cells(27).Text = Format(CDbl(e.Item.Cells(27).Text), "##,##0")
                    e.Item.Cells(28).Text = Format(CDbl(e.Item.Cells(28).Text), "##,##0")
                    e.Item.Cells(29).Text = Format(CDbl(e.Item.Cells(29).Text), "##,##0")
                    e.Item.Cells(30).Text = Format(CDbl(e.Item.Cells(30).Text), "##,##0")
                    e.Item.Cells(31).Text = Format(CDbl(e.Item.Cells(31).Text), "##,##0")
                    e.Item.Cells(32).Text = Format(CDbl(e.Item.Cells(32).Text), "##,##0")
                    e.Item.Cells(33).Text = Format(CDbl(e.Item.Cells(33).Text), "##,##0")
                    e.Item.Cells(34).Text = Format(CDbl(e.Item.Cells(34).Text), "##,##0")
                    e.Item.Cells(35).Text = Format(CDbl(e.Item.Cells(35).Text), "##,##0")
                    e.Item.Cells(36).Text = Format(CDbl(e.Item.Cells(36).Text), "##,##0")
                    e.Item.Cells(37).Text = Format(CDbl(e.Item.Cells(37).Text), "##,##0")
                    e.Item.Cells(38).Text = Format(CDbl(e.Item.Cells(38).Text), "##,##0")
                    e.Item.Cells(39).Text = Format(CDbl(e.Item.Cells(39).Text), "##,##0")
                    e.Item.Cells(40).Text = Format(CDbl(e.Item.Cells(40).Text), "##,##0")
                    e.Item.Cells(41).Text = Format(CDbl(e.Item.Cells(41).Text), "##,##0")
                    e.Item.Cells(42).Text = Format(CDbl(e.Item.Cells(42).Text), "##,##0")
                    e.Item.Cells(43).Text = Format(CDbl(e.Item.Cells(43).Text), "##,##0")
                    e.Item.Cells(44).Text = Format(CDbl(e.Item.Cells(44).Text), "##,##0")
                    e.Item.Cells(45).Text = Format(CDbl(e.Item.Cells(45).Text), "##,##0")
                    e.Item.Cells(46).Text = Format(CDbl(e.Item.Cells(46).Text), "##,##0")
                    e.Item.Cells(47).Text = Format(CDbl(e.Item.Cells(47).Text), "##,##0")
                    e.Item.Cells(48).Text = Format(CDbl(e.Item.Cells(48).Text), "##,##0")
                    e.Item.Cells(49).Text = Format(CDbl(e.Item.Cells(49).Text), "##,##0")
                    e.Item.Cells(50).Text = Format(CDbl(e.Item.Cells(50).Text), "##,##0")
                    e.Item.Cells(51).Text = Format(CDbl(e.Item.Cells(51).Text), "##,##0")
                    e.Item.Cells(52).Text = Format(CDbl(e.Item.Cells(52).Text), "##,##0")
                    e.Item.Cells(53).Text = Format(CDbl(e.Item.Cells(53).Text), "##,##0")
                    e.Item.Cells(54).Text = Format(CDbl(e.Item.Cells(54).Text), "##,##0")
                    e.Item.Cells(55).Text = Format(CDbl(e.Item.Cells(55).Text), "##,##0")
                    e.Item.Cells(56).Text = Format(CDbl(e.Item.Cells(56).Text), "##,##0")
                    e.Item.Cells(57).Text = Format(CDbl(e.Item.Cells(57).Text), "##,##0")
                    e.Item.Cells(58).Text = Format(CDbl(e.Item.Cells(58).Text), "##,##0")
                    e.Item.Cells(59).Text = Format(CDbl(e.Item.Cells(59).Text), "##,##0")
                    e.Item.Cells(60).Text = Format(CDbl(e.Item.Cells(60).Text), "##,##0")
                    e.Item.Cells(61).Text = Format(CDbl(e.Item.Cells(61).Text), "##,##0")
                    e.Item.Cells(62).Text = Format(CDbl(e.Item.Cells(62).Text), "##,##0")
                    e.Item.Cells(63).Text = Format(CDbl(e.Item.Cells(63).Text), "##,##0")
                    e.Item.Cells(64).Text = Format(CDbl(e.Item.Cells(64).Text), "##,##0")
                    e.Item.Cells(65).Text = Format(CDbl(e.Item.Cells(65).Text), "##,##0")
                    e.Item.Cells(66).Text = Format(CDbl(e.Item.Cells(66).Text), "##,##0")
                    e.Item.Cells(67).Text = Format(CDbl(e.Item.Cells(67).Text), "##,##0")
                    e.Item.Cells(68).Text = Format(CDbl(e.Item.Cells(68).Text), "##,##0")
                    e.Item.Cells(69).Text = Format(CDbl(e.Item.Cells(69).Text), "##,##0")
                    e.Item.Cells(70).Text = Format(CDbl(e.Item.Cells(70).Text), "##,##0")
                    e.Item.Cells(71).Text = Format(CDbl(e.Item.Cells(71).Text), "##,##0")
                    e.Item.Cells(72).Text = Format(CDbl(e.Item.Cells(72).Text), "##,##0")
                    e.Item.Cells(73).Text = Format(CDbl(e.Item.Cells(73).Text), "##,##0")
                    e.Item.Cells(74).Text = Format(CDbl(e.Item.Cells(74).Text), "##,##0")
                    e.Item.Cells(75).Text = Format(CDbl(e.Item.Cells(75).Text), "##,##0")
                    e.Item.Cells(76).Text = Format(CDbl(e.Item.Cells(76).Text), "##,##0")
                    e.Item.Cells(77).Text = Format(CDbl(e.Item.Cells(77).Text), "##,##0.#0")
                    e.Item.Cells(78).Text = Format(CDbl(e.Item.Cells(78).Text), "##,##0.#0")
                    'e.Item.Cells(79).Text = Format(CDbl(e.Item.Cells(79).Text), "##,##0")
                    'e.Item.Cells(80).Text = Format(CDbl(e.Item.Cells(80).Text), "##,##0")
                    'e.Item.Cells(81).Text = Format(CDbl(e.Item.Cells(81).Text), "##,##0")
                    'e.Item.Cells(82).Text = Format(CDbl(e.Item.Cells(82).Text), "##,##0")
                    e.Item.Cells(80).Text = Format(CDate(e.Item.Cells(80).Text), "dd/MM/yyyy")
            End Select
        End Sub

        Private Sub lnk_Validados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnk_Validados.Click
            Try
                If Me.hidPestaniaActual.Value <> "1" Then
                    pCambiarPestania(1)
                    'lnk_Validados.AutoUpdateAfterCallBack = True
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        Private Sub pCambiarPestania(ByVal pintPestaniaActual As Integer)
            Me.hidPestaniaActual.Value = CType(pintPestaniaActual, String)
            buscar()
        End Sub

        'Private Sub lnk_Prioridad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '    Try
        '        If Me.hidPestaniaActual.Value <> "2" Then
        '            pCambiarPestania(2)
        '            'lnk_Prioridad.AutoUpdateAfterCallBack = True
        '        End If
        '    Catch ex As Exception
        '        Util.grabarErrorLog(ex)
        '        Me.muestraAlerta(ex.Message)
        '    End Try
        'End Sub

        Private Sub dgrdMnt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            Try
                dgrdMnt.CurrentPageIndex = e.NewPageIndex
                dgrdMnt.EditItemIndex = -1
                buscar(dgrdMnt.CurrentPageIndex + 1)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ex.Message)
            End Try
        End Sub

        'Private Sub dgrPrioridad_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrPrioridad.PageIndexChanged
        '    Try
        '        dgrPrioridad.CurrentPageIndex = e.NewPageIndex
        '        dgrPrioridad.EditItemIndex = -1
        '        buscar()
        '    Catch ex As Exception
        '        Util.grabarErrorLog(ex)
        '        Me.muestraAlerta(ex.Message)
        '    End Try
        'End Sub

        'Private Sub dgrPrioridad_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrPrioridad.ItemDataBound
        '    Select Case e.Item.ItemType
        '        Case ListItemType.AlternatingItem, ListItemType.Item
        '            For i As Integer = 7 To e.Item.Cells.Count - 1
        '                If IsNumeric(e.Item.Cells(i).Text) Then
        '                    e.Item.Cells(i).Text = Format(CDbl(e.Item.Cells(i).Text), "##,##0")
        '                    e.Item.Cells(i).HorizontalAlign = HorizontalAlign.Right
        '                End If
        '            Next
        '    End Select
        'End Sub

        Private Sub dropMoneda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dropMoneda.SelectedIndexChanged
            If IsDate(txtFecPeriodo.Text) Then
                buscar()
            Else
                activarReportes(ecReporte.DescargaData, False)
            End If
        End Sub

        Private Sub ddlEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlEstado.SelectedIndexChanged
            If ddlEstado.TabIndex > -1 Then
                lnk_Validados.Text = ddlEstado.SelectedItem.Text
            End If
            If IsDate(txtFecPeriodo.Text) Then
                buscar()
            Else
                activarReportes(ecReporte.DescargaData, False)
            End If
        End Sub
    End Class
End Namespace