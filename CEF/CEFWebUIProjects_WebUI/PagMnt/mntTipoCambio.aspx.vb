'*************************************************************
'Proposito: Mantenimiento de Tipo de Cambio
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 15/06/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports CEF.BusinessRules
Imports CEF.Common
Imports CEF.BusinessEntity

Namespace CEF.WebUI

    Partial Class mntTipoCambio
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        CargaDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    CargaDatos()
                End If
            End If
        End Sub

        Private Sub CargaDatos()
            cargarCombos()
            ' cargaDgrMnt()
            cargaDgrMntConFiltros()
            imgImprimir.Attributes("onClick") = "javascript:window.print();"
            lnkImprimir.Attributes("url") = "javascript:window.print();"
        End Sub

        Private Sub cargarCombos()
            Me.dropBusMes.DataSource = buscarGeneralTabla(Convert.ToInt32(Globals.ecTablaGeneral.MES))
            Me.dropBusMes.DataTextField = "Descripcion"
            Me.dropBusMes.DataValueField = "CodItem"
            Me.dropBusMes.DataBind()
            Dim oItemSeleccionarMes As New ListItem("Seleccione un Mes...", 0)
            Me.dropBusMes.Items.Insert(0, oItemSeleccionarMes)

            Dim oItemSeleccionarAnio As New ListItem("Seleccione un Anio...", 0)
            Me.dropBusAnio.Items.Add(oItemSeleccionarAnio)
            For i As Integer = 1995 To DateTime.Now.Date.Year
                Me.dropBusAnio.Items.Add(New ListItem(i.ToString, i.ToString))
            Next
            
        End Sub

        Private Sub cargaDgrMnt()
            Dim obrTipoCambio As BusinessRules.TipoCambio = New BusinessRules.TipoCambio

            Dim dsTipoCambio As DataSet = obrTipoCambio.listar(1, 0)
            dgrdMnt.DataSource = dsTipoCambio
            dgrdMnt.DataKeyField = "CodReg"
            dgrdMnt.DataBind()
            obrTipoCambio = Nothing

            lblNumReg.Text = dsTipoCambio.Tables(0).Rows.Count.ToString()
            hidAccion.Value = CType(Globals.ecMntPage.NOACCION, String)
        End Sub

        Private Sub cargaDgrMntConFiltros()
            Dim obrTipoCambio As BusinessRules.TipoCambio = New BusinessRules.TipoCambio
            Dim obeTipoCambio As BusinessEntity.TipoCambio = New BusinessEntity.TipoCambio

            obeTipoCambio.Anio = Me.dropBusAnio.SelectedValue
            obeTipoCambio.Mes = Me.dropBusMes.SelectedValue
            obeTipoCambio.Estado = 0

            Dim dsTipoCambio As DataSet = obrTipoCambio.listarConFiltros(1, obeTipoCambio)
            dgrdMnt.DataSource = dsTipoCambio
            dgrdMnt.DataKeyField = "CodReg"
            dgrdMnt.DataBind()
            obrTipoCambio = Nothing

            lblNumReg.Text = dsTipoCambio.Tables(0).Rows.Count.ToString()
            hidAccion.Value = CType(Globals.ecMntPage.NOACCION, String)
        End Sub

        Private Sub imbNuevo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbNuevo.Click
            Dim obrTipoCambio As BusinessRules.TipoCambio = New BusinessRules.TipoCambio

            Dim dsTipoCambio As DataSet = obrTipoCambio.listar(1, 0)
            Dim drowDataRow As DataRow = dsTipoCambio.Tables(0).NewRow()

            drowDataRow("Anio") = DateTime.Today.Year
            drowDataRow("Mes") = DateTime.Today.Month
            drowDataRow("Monto") = 0
            drowDataRow("MontoMaximo") = 0
            drowDataRow("IndiceReexpresion") = 0
            drowDataRow("MontoMinimo") = 0
            dsTipoCambio.Tables(0).Rows.InsertAt(drowDataRow, 0)
            dgrdMnt.DataSource = dsTipoCambio.Tables(0)
            dgrdMnt.DataKeyField = "CodReg"

            dgrdMnt.EditItemIndex = 0
            dgrdMnt.DataBind()

            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim txtAnio As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtAnio"), TextBox)
            txtAnio.Attributes.Add("onkeypress", "javascript:if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;")

            Dim txtMonto As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtMonto"), TextBox)
            txtMonto.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim txtMontoMaximo As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtMontoMaximo"), TextBox)
            txtMontoMaximo.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim txtPorcentajeDev As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtPorcentajeDev"), TextBox)
            txtPorcentajeDev.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim txtIndiceReexpresion As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtIndiceReexpresion"), TextBox)
            txtIndiceReexpresion.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim dropMes As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropMes"), DropDownList)
            dropMes.DataSource = buscarGeneralTabla(Convert.ToInt32(Globals.ecTablaGeneral.MES))
            dropMes.DataTextField = "Descripcion"
            dropMes.DataValueField = "CodItem"
            dropMes.DataBind()

            Dim dropMoneda As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropMoneda"), DropDownList)

            Dim obeParametro As BusinessEntity.Parametro = buscarParametro("MET_COD_MONEDA")

            dropMoneda.DataSource = buscarGeneralTabla(Convert.ToInt32(Globals.ecTablaGeneral.MONEDA))
            dropMoneda.DataTextField = "Descripcion"
            dropMoneda.DataValueField = "CodItem"
            dropMoneda.SelectedValue = obeParametro.Valor1
            dropMoneda.DataBind()

            Dim dropEstado As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropEstado"), DropDownList)
            dropEstado.DataSource = buscarGeneralTabla(Convert.ToInt32(Globals.ecTablaGeneral.ESTADO_TIPOCAMBIO))
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()


            Dim txtMontoMinimo As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtMontoMinimo"), TextBox)
            txtMontoMinimo.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim txtPorcentajeAprec As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtPorcentajeAprec"), TextBox)
            txtPorcentajeAprec.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            hidAccion.Value = CType(Globals.ecMntPage.AGREGAR, String)
        End Sub

        Private Sub dgrdMnt_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.DeleteCommand
            Dim strKey As String = dgrdMnt.DataKeys(e.Item.ItemIndex)
            Dim intAnio As Integer = Int32.Parse(strKey.Split(":")(0))
            Dim intMes As Integer = Int32.Parse(strKey.Split(":")(1))
            Dim intMoneda As Integer = Int32.Parse(strKey.Split(":")(2))
            Dim obrTipoCambio As BusinessRules.TipoCambio = New BusinessRules.TipoCambio

            Dim voRC As Boolean = obrTipoCambio.eliminar(intAnio, intMes, intMoneda)

            dgrdMnt.EditItemIndex = -1
            'cargaDgrMnt()
            cargaDgrMntConFiltros()
        End Sub

        Private Sub dgrdMnt_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.CancelCommand
            dgrdMnt.EditItemIndex = -1
            'cargaDgrMnt()
            cargaDgrMntConFiltros()
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"

                Dim ibtnEliminar As ImageButton = CType(e.Item.FindControl("ibtnEliminar"), ImageButton)
                ibtnEliminar.Attributes("onclick") = "javascript:return confirm('" & Globals.ccALERTA_ELIMINAR & "');"
            End If
        End Sub

        Private Sub dgrdMnt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            dgrdMnt.CurrentPageIndex = e.NewPageIndex
            dgrdMnt.EditItemIndex = -1
            'cargaDgrMnt()
            cargaDgrMntConFiltros()
        End Sub


        Private Sub dgrdMnt_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.UpdateCommand
            If (hidAccion.Value = CType(Globals.ecMntPage.AGREGAR, String)) And (e.Item.ItemIndex = 0) Then
                Dim txtAnio As TextBox = CType(e.Item.FindControl("txtAnio"), TextBox)
                Dim dropMes As DropDownList = CType(e.Item.FindControl("dropMes"), DropDownList)
                Dim dropMoneda As DropDownList = CType(e.Item.FindControl("dropMoneda"), DropDownList)
                Dim txtMonto As TextBox = CType(e.Item.FindControl("txtMonto"), TextBox)
                Dim txtMontoMaximo As TextBox = CType(e.Item.FindControl("txtMontoMaximo"), TextBox)
                Dim txtPorcentajeDev As TextBox = CType(e.Item.FindControl("txtPorcentajeDev"), TextBox)
                Dim txtIndiceReexpresion As TextBox = CType(e.Item.FindControl("txtIndiceReexpresion"), TextBox)
                Dim dropEstado As DropDownList = CType(e.Item.FindControl("dropEstado"), DropDownList)
                Dim txtMontoMinimo As TextBox = CType(e.Item.FindControl("txtMontoMinimo"), TextBox)
                Dim txtPorcentajeAprec As TextBox = CType(e.Item.FindControl("txtPorcentajeAprec"), TextBox)

                Dim obrTipoCambio As BusinessRules.TipoCambio = New BusinessRules.TipoCambio

                Dim obeTipoCambio As BusinessEntity.TipoCambio = New BusinessEntity.TipoCambio(Int32.Parse(txtAnio.Text), _
                                                                                               Int32.Parse(dropMes.SelectedValue), _
                                                                                               Byte.Parse(dropMoneda.SelectedValue), _
                                                                                               Decimal.Parse(txtMonto.Text), _
                                                                                               Decimal.Parse(txtMontoMaximo.Text), _
                                                                                               Decimal.Parse(txtPorcentajeDev.Text), _
                                                                                               Decimal.Parse(txtIndiceReexpresion.Text), _
                                                                                               Byte.Parse(dropEstado.SelectedValue), _
                                                                                               retornaUsuarioSesion(), _
                                                                                               Decimal.Parse(txtMontoMinimo.Text), _
                                                                                               Decimal.Parse(txtPorcentajeAprec.Text))
                Dim voRC As Boolean = obrTipoCambio.agregar(obeTipoCambio)
                obrTipoCambio = Nothing
            Else
                Dim txtAnio As TextBox = CType(e.Item.FindControl("txtAnio"), TextBox)
                Dim dropMes As DropDownList = CType(e.Item.FindControl("dropMes"), DropDownList)
                Dim dropMoneda As DropDownList = CType(e.Item.FindControl("dropMoneda"), DropDownList)
                Dim txtMonto As TextBox = CType(e.Item.FindControl("txtMonto"), TextBox)
                Dim txtMontoMaximo As TextBox = CType(e.Item.FindControl("txtMontoMaximo"), TextBox)
                Dim txtPorcentajeDev As TextBox = CType(e.Item.FindControl("txtPorcentajeDev"), TextBox)
                Dim txtIndiceReexpresion As TextBox = CType(e.Item.FindControl("txtIndiceReexpresion"), TextBox)
                Dim dropEstado As DropDownList = CType(e.Item.FindControl("dropEstado"), DropDownList)
                Dim obrTipoCambio As BusinessRules.TipoCambio = New BusinessRules.TipoCambio
                Dim txtMontoMinimo As TextBox = CType(e.Item.FindControl("txtMontoMinimo"), TextBox)
                Dim txtPorcentajeAprec As TextBox = CType(e.Item.FindControl("txtPorcentajeAprec"), TextBox)

                Dim obeTipoCambio As BusinessEntity.TipoCambio = New BusinessEntity.TipoCambio
                obeTipoCambio.Anio = Integer.Parse(txtAnio.Text)
                obeTipoCambio.Mes = Integer.Parse(dropMes.SelectedValue)
                obeTipoCambio.CodMoneda = Byte.Parse(dropMoneda.SelectedValue)
                obeTipoCambio.Monto = Decimal.Parse(txtMonto.Text)
                obeTipoCambio.MontoMaximo = Decimal.Parse(txtMontoMaximo.text)
                obeTipoCambio.PorcentajeDevaluacion = Decimal.Parse(txtPorcentajeDev.text)
                obeTipoCambio.IndiceReexpresion = Decimal.Parse(txtIndiceReexpresion.Text)
                obeTipoCambio.Estado = Byte.Parse(dropEstado.SelectedValue)
                'obeTipoCambio.CodUsuario = datosGlobal.sUser
                obeTipoCambio.CodUsuario = retornaUsuarioSesion()
                obeTipoCambio.MontoMinimo = Decimal.Parse(txtMontoMinimo.Text)
                obeTipoCambio.ProcentajeApreciacion = Decimal.Parse(txtPorcentajeAprec.Text)

                Dim voRC As Boolean = obrTipoCambio.modificar(obeTipoCambio)
                obrTipoCambio = Nothing
            End If

            dgrdMnt.EditItemIndex = -1
            'cargaDgrMnt()
            cargaDgrMntConFiltros()
        End Sub

        Private Sub dgrdMnt_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.EditCommand
            Dim strKey As String = dgrdMnt.DataKeys(e.Item.ItemIndex)
            Dim intAnio As Integer = Int32.Parse(strKey.Split(":")(0))
            Dim intMes As Integer = Int32.Parse(strKey.Split(":")(1))
            Dim intMoneda As Integer = Int32.Parse(strKey.Split(":")(2))

            dgrdMnt.EditItemIndex = e.Item.ItemIndex
            'cargaDgrMnt()
            cargaDgrMntConFiltros()
            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim txtAnio As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtAnio"), TextBox)
            txtAnio.Attributes.Add("onkeypress", "javascript:if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;")

            Dim txtMonto As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtMonto"), TextBox)
            txtMonto.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim txtMontoMaximo As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtMontoMaximo"), TextBox)
            txtMontoMaximo.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim txtPorcentajeDev As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtPorcentajeDev"), TextBox)
            txtPorcentajeDev.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim txtIndiceReexpresion As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtIndiceReexpresion"), TextBox)
            txtIndiceReexpresion.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim dropMes As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropMes"), DropDownList)
            Dim dropMoneda As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropMoneda"), DropDownList)
            Dim dropEstado As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropEstado"), DropDownList)

            Dim obrTipoCambio As BusinessRules.TipoCambio = New BusinessRules.TipoCambio
            Dim obeTipoCambio As BusinessEntity.TipoCambio = obrTipoCambio.leer(intAnio, intMes, intMoneda)

            Dim txtMontoMinimo As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtMontoMinimo"), TextBox)
            txtMontoMinimo.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            Dim txtPorcentajeAprec As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtPorcentajeAprec"), TextBox)
            txtPorcentajeAprec.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")


            dropMes.DataSource = buscarGeneralTabla(Globals.ecTablaGeneral.MES)
            dropMes.DataTextField = "Descripcion"
            dropMes.DataValueField = "CodItem"
            dropMes.DataBind()
            dropMes.SelectedValue = obeTipoCambio.Mes()

            dropMoneda.DataSource = buscarGeneralTabla(Globals.ecTablaGeneral.MONEDA)
            dropMoneda.DataTextField = "Descripcion"
            dropMoneda.DataValueField = "CodItem"
            dropMoneda.DataBind()
            dropMoneda.SelectedValue = obeTipoCambio.CodMoneda()

            dropEstado.DataSource = buscarGeneralTabla(Globals.ecTablaGeneral.ESTADO_TIPOCAMBIO)
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()
            dropEstado.SelectedValue = obeTipoCambio.Estado()
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            Me.cargaDgrMntConFiltros()
        End Sub
    End Class

End Namespace