Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports System.Diagnostics
Imports CEF.Common
Imports CEF.BusinessRules
Imports System.Collections.Generic
Namespace CEF.WebUI

    Public Class mntFormulas
        Inherits PageBase

        Private Const ccANCHO_DGRID_PERIODO As Short = 260
        Private Const ccANCHO_COLUMNA_PERIODO As Short = 100

        Public Class VariableCovenant
            Private lCodCuenta As Integer
            Private lDescripcion As String
            Private lValor As Decimal

            Sub New()
                MyBase.New()
            End Sub

            Public Property CodCuenta() As Integer
                Get
                    Return Me.lCodCuenta
                End Get
                Set(ByVal Value As Integer)
                    Me.lCodCuenta = Value
                End Set
            End Property

            Public Property Descripcion() As String
                Get
                    Return Me.lDescripcion
                End Get
                Set(ByVal Value As String)
                    Me.lDescripcion = Value
                End Set
            End Property

            Public Property Valor() As Decimal
                Get
                    Return Me.lValor
                End Get
                Set(ByVal Value As Decimal)
                    Me.lValor = Value
                End Set
            End Property

        End Class

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    Dim intMntAccion As Integer = Int32.Parse(Request.Params("intMntAccion")).ToString
                    hidAccion.Value = intMntAccion
                    If intMntAccion = Int32.Parse(ecMntPage.AGREGAR) Then
                        pCargarJS()
                        cargarDatosReconciliacion()
                    Else
                        Dim intCodCovenant As Integer = Int32.Parse(Request.Params("intCodCovenant")).ToString
                        pCargarJS()
                        CargarDatosSeleccionado(intCodCovenant)
                        cargarDgrParametros()
                    End If
                End If
            End If
        End Sub

        Private Sub cargarDatosReconciliacion()
            Dim intCodMetodizado As Integer
            Dim strPeriodoFiltrado As String
            Dim strBusqueda As String

            intCodMetodizado = Int32.Parse(Request.Params("intCodMetodizado"))
            strPeriodoFiltrado = Int32.Parse(Request.Params("intCodPeriodo")).ToString

            hidCodMetodizado.Value = intCodMetodizado

            Dim intContadorColPeriodo As Integer
            Dim intAnchoColumnas As Integer
            Dim dsPeriodoCuenta As DataSet

            Dim obeMetodizado As CEF.BusinessEntity.Metodizado
            Dim obrMetodizado As CEF.BusinessRules.Metodizado = New CEF.BusinessRules.Metodizado
            Dim obePeriodoLst As CEF.BusinessEntity.PeriodoLst


            If (strPeriodoFiltrado <> String.Empty) Then
                Dim arrCodPeriodo As String() = strPeriodoFiltrado.Split(";")

                obePeriodoLst = New CEF.BusinessEntity.PeriodoLst
                For Each strCodPeriodo As String In arrCodPeriodo
                    Dim obePeriodo As CEF.BusinessEntity.Periodo = New CEF.BusinessEntity.Periodo
                    obePeriodo.CodMetodizado = intCodMetodizado
                    obePeriodo.CodPeriodo = Int32.Parse(strCodPeriodo)
                    obePeriodoLst.Add(obePeriodo)
                Next
                obeMetodizado = New CEF.BusinessEntity.Metodizado
                obeMetodizado.CodMetodizado = intCodMetodizado
                obeMetodizado.Periodos = obePeriodoLst

                strBusqueda = txtBusquedaCuenta.Text

                dsPeriodoCuenta = obrMetodizado.filtrarPeriodoCuentaCovenant(obeMetodizado, intCodMetodizado, Integer.Parse(strPeriodoFiltrado), strBusqueda)

                dtgr1.DataSource = dsPeriodoCuenta
                dtgr1.DataKeyField = "CodCuenta"
                dtgr1.Width = New Unit(intAnchoColumnas, UnitType.Pixel)
                dtgr1.DataBind()
            End If
        End Sub

        Private Sub dtgr1_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgr1.PageIndexChanged
            If Page.IsPostBack Then
                dtgr1.CurrentPageIndex = e.NewPageIndex
                dtgr1.DataBind()
            End If

        End Sub

        Private Sub pCargarJS()

            btnMas.Attributes.Add("OnClick", "javascript:return fOperacion('+');")
            btnMenos.Attributes.Add("OnClick", "javascript:return fOperacion('-');")
            btnMultiplicacion.Attributes.Add("OnClick", "javascript:return fOperacion('*');")
            btnDivision.Attributes.Add("OnClick", "javascript:return fOperacion('/');")
            btnAbreParentesis.Attributes.Add("OnClick", "javascript:return fOperacion('(');")
            btnCierraParentesis.Attributes.Add("OnClick", "javascript:return fOperacion(')');")
            'btnPorcentaje.Attributes.Add("OnClick", "javascript:return fOperacion('100');")
            btnLimpiarFormula.Attributes.Add("OnClick", "javascript:return fLimpiarFormula();")
            btnProbarFormula.Attributes.Add("OnClick", "javascript:return fProbarFormula();")
            'btnAgregarCampo1.Attributes.Add("OnClick", "javascript:return fAgregarCampoCovenant(txtCampo1);")
            'btnAgregarCampo2.Attributes.Add("OnClick", "javascript:return fAgregarCampoCovenant(txtCampo2);")
            'btnAgregarCampo3.Attributes.Add("OnClick", "javascript:return fAgregarCampoCovenant(txtCampo3);")
            'btnAgregarCampo4.Attributes.Add("OnClick", "javascript:return fAgregarCampoCovenant(txtCampo4);")
            'btnAgregarCampo5.Attributes.Add("OnClick", "javascript:return fAgregarCampoCovenant(txtCampo5);")
            'btnDeshacer.Attributes.Add(eventosJavaScript.OnClick.ToString, "javascript:return fDeshacerFormula();")

            btnGuardarFormula.Attributes.Add("OnClick", "javascript:return fGuardarFormula();")

        End Sub

        Private Sub CargarDatosSeleccionado(ByVal pintCodCovenant As Integer)

            If hidAccion.Value = Int32.Parse(ecMntPage.AGREGAR) Then
                hidAccion.Value = Int32.Parse(ecMntPage.MODIFICAR)
                btnGuardarFormula.Text = "Modificar Fórmula"
            End If

            Dim lblFormulaCovenantDescripcion As String = ""
            Dim lblFormulaCovenantNumeros As String = ""
            Dim intNoContractual As Integer 'Add XT8633 

            imbNuevo.Enabled = True

            Dim dsCovenant As DataSet
            Dim obrCovenant As CEF.BusinessRules.FormulaCovenant = New CEF.BusinessRules.FormulaCovenant

            dsCovenant = obrCovenant.seleccionar(pintCodCovenant)

            hidCodCovenant.Value = pintCodCovenant.ToString 'dsCovenant.Tables(0).Rows(0)("CodCoventant").ToString()
            txtNombreFormula.Text = Trim(dsCovenant.Tables(0).Rows(0)("Descripcion").ToString())
            DropDownList1.SelectedValue = dsCovenant.Tables(0).Rows(0)("Condicion").ToString()
            txtcomentario.Text = Trim(dsCovenant.Tables(0).Rows(0)("Comentario").ToString())
            If dsCovenant.Tables(0).Rows(0)("Contractual").ToString() = "" Then
                intNoContractual = 1
            Else
                intNoContractual = dsCovenant.Tables(0).Rows(0)("Contractual").ToString()
            End If
            NoContractual(intNoContractual)
            btnGuardarFormula.Text = "Modificar Fórmula"

            Dim lstVariableCovenant As New List(Of VariableCovenant)
            Dim intNumero As Integer = 0

            For Each DtRow As DataRow In dsCovenant.Tables(1).Rows
                Dim objVariableCovenant As New VariableCovenant
                objVariableCovenant.CodCuenta = Integer.Parse(DtRow("CodCuenta").ToString)
                objVariableCovenant.Descripcion = Trim(DtRow("Descripcion").ToString)
                objVariableCovenant.Valor = Decimal.Parse(DtRow("Valor").ToString)
                lstVariableCovenant.Add(objVariableCovenant)

                If DtRow("CodCuenta").ToString <> "0" Then
                    lblFormulaCovenantNumeros += Decimal.Parse(DtRow("Valor")).ToString("0.##")
                    lblFormulaCovenantDescripcion += "[" + Trim(DtRow("Descripcion").ToString) + "]"
                Else
                    lblFormulaCovenantNumeros += Trim(DtRow("Descripcion").ToString)
                    lblFormulaCovenantDescripcion += Trim(DtRow("Descripcion").ToString)

                End If
            Next

            txtFormula.Text = lblFormulaCovenantDescripcion
            lblFormula.Text = lblFormulaCovenantNumeros
            cargarDatosReconciliacion()

            hidJSONCovenant.Value = New Script.Serialization.JavaScriptSerializer().Serialize(lstVariableCovenant)

        End Sub
        'AGREGADO POR XT8633 INICIO - PARAMETROS

        Protected Sub imbNuevo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbNuevo.Click

            Dim obrFormulaParametro As BusinessRules.FormulaParametro = New BusinessRules.FormulaParametro

            Dim intCodCovenant As Integer
            intCodCovenant = hidCodCovenant.Value

            Dim dsFormParametro As DataSet = obrFormulaParametro.listar(1, intCodCovenant)
            Dim drowDataRow As DataRow = dsFormParametro.Tables(0).NewRow()
            drowDataRow("Anio") = DateTime.Today.Year
            drowDataRow("Valor") = 0
            dsFormParametro.Tables(0).Rows.InsertAt(drowDataRow, 0)
            dgrdMnt.DataSource = dsFormParametro.Tables(0)
            dgrdMnt.DataKeyField = "CodParametro"
            dgrdMnt.EditItemIndex = 0
            dgrdMnt.DataBind()

            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim txtAnio As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtAnio"), TextBox)
            txtAnio.Attributes.Add("onkeypress", "javascript:if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;")
            txtAnio.Attributes.Add("onchange", "javascript:f_ValidarAnio(this);")

            Dim txtValor As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtValor"), TextBox)
            txtValor.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

            hidAccionP.Value = CType(Globals.ecMntPage.AGREGAR, String)

        End Sub

        Protected Sub btnGuardarFormula_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardarFormula.Click

            Dim odaFormulaCovenant As New BusinessRules.FormulaCovenant
            Dim obeFomulaCovenant As New BusinessEntity.Formula

            If hidAccion.Value = Int32.Parse(ecMntPage.AGREGAR) Then
                obeFomulaCovenant.CodMetodizado = 0
                obeFomulaCovenant.Descripcion = ""
                obeFomulaCovenant.Estado = 0
                obeFomulaCovenant.CodUsuario = ""
                obeFomulaCovenant.FechRegisto = DateTime.Now
                obeFomulaCovenant.Comentario = ""

                Dim intCodcovenant As Integer = 0
                intCodcovenant = (odaFormulaCovenant.agregar(obeFomulaCovenant, 2))
                hidCodCovenant.Value = intCodcovenant

                CargarDatosSeleccionado(intCodcovenant)
            Else
                Dim intCodcovenant As Integer
                intCodcovenant = hidCodCovenant.Value
                CargarDatosSeleccionado(intCodcovenant)
            End If
        End Sub

        Private Sub cargarDgrParametros()

            Dim obrFormulaParametro As BusinessRules.FormulaParametro = New BusinessRules.FormulaParametro
            Dim intCodCovenant As Integer

            intCodCovenant = hidCodCovenant.Value

            Dim dsFormParametro As DataSet = obrFormulaParametro.listar(1, intCodCovenant)
            dgrdMnt.DataSource = dsFormParametro
            dgrdMnt.DataKeyField = "CodParametro"
            dgrdMnt.DataBind()
            obrFormulaParametro = Nothing

            lblNumReg.Text = dsFormParametro.Tables(0).Rows.Count.ToString()
            hidAccionP.Value = CType(Globals.ecMntPage.NOACCION, String)

        End Sub

        Private Function validaAnioRepetido(ByVal anio As Integer, ByVal index As Integer) As Boolean
            Dim anioSel As Integer

            For Each item As DataGridItem In dgrdMnt.Items
                If item.ItemIndex <> index Then
                    anioSel = Val(CType(item.FindControl("lblAnio"), Label).Text)
                End If

                If anio = anioSel Then
                    Return True
                End If
            Next

            Return False
        End Function

        Protected Sub dgrdMnt_UpdateCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.UpdateCommand
                Dim txtAnio As TextBox = CType(e.Item.FindControl("txtAnio"), TextBox)
                Dim txtValor As TextBox = CType(e.Item.FindControl("txtValor"), TextBox)

            If (hidAccionP.Value = CType(Globals.ecMntPage.AGREGAR, String)) And (e.Item.ItemIndex = 0) Then
                If IsNumeric(txtValor.Text) = False Then
                    MesgBox("Campo valor solo acepta números.")
                    txtValor.Focus()
                ElseIf txtAnio.Text = "" Then
                    MesgBox("Completar todos los datos.")
                    txtAnio.Focus()
                ElseIf txtValor.Text = "" Then
                    MesgBox("Completar todos los datos.")
                    txtValor.Focus()
                Else
                    If validaAnioRepetido(Val(txtAnio.Text), e.Item.ItemIndex) Then
                        MesgBox("El valor del campo año no puede repetirse.")
                        txtAnio.Focus()
                        Exit Sub
                    End If

                    Dim intCodCovenant As Integer
                    intCodCovenant = hidCodCovenant.Value
                    Dim strCodUsuario As String = retornaUsuarioSesion()
                    Dim Anio As String = txtAnio.Text
                    Dim obrFormParametro As BusinessRules.FormulaParametro = New BusinessRules.FormulaParametro
                    Dim obeFormParametro As BusinessEntity.FormulaParametro = New BusinessEntity.FormulaParametro(intCodCovenant, Anio, Decimal.Parse(txtValor.Text), strCodUsuario)

                    Dim voRC As Boolean = obrFormParametro.agregar(obeFormParametro)
                    If voRC = True Then
                        MesgBox("Registro Exitoso")
                    End If

                    obrFormParametro = Nothing
                    dgrdMnt.EditItemIndex = -1
                    cargarDgrParametros()
                End If
            Else
                If IsNumeric(txtValor.Text) = False Then
                    MesgBox("Campo valor solo acepta números.")
                    txtValor.Focus()
                ElseIf txtAnio.Text = "" Then
                    MesgBox("Completar todos los datos.")
                    txtAnio.Focus()
                ElseIf txtValor.Text = "" Then
                    MesgBox("Completar todos los datos.")
                    txtValor.Focus()
                Else
                    If validaAnioRepetido(Val(txtAnio.Text), e.Item.ItemIndex) Then
                        MesgBox("El valor del campo año no puede repetirse.")
                        txtAnio.Focus()
                        Exit Sub
                    End If

                    Dim intCodParametro As Integer = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), Integer)
                    Dim obrFormParametro As BusinessRules.FormulaParametro = New BusinessRules.FormulaParametro
                    Dim obeFormParametro As BusinessEntity.FormulaParametro = New BusinessEntity.FormulaParametro

                    obeFormParametro.CodFormulaParametro = intCodParametro
                    obeFormParametro.Anio = txtAnio.Text
                    obeFormParametro.Valor = txtValor.Text

                    Dim voRC As Boolean = obrFormParametro.modificar(obeFormParametro)
                    If voRC = True Then
                        MesgBox("Actualización Exitosa")
                    End If

                    obrFormParametro = Nothing
                    dgrdMnt.EditItemIndex = -1
                    cargarDgrParametros()
                End If

            End If
        End Sub

        Protected Sub dgrdMnt_CancelCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.CancelCommand
            dgrdMnt.EditItemIndex = -1
            cargarDgrParametros()
        End Sub

        Protected Sub dgrdMnt_EditCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.EditCommand

            If (hidAccionP.Value = "1") Then
                dgrdMnt.EditItemIndex = e.Item.ItemIndex - 1
            Else
                dgrdMnt.EditItemIndex = e.Item.ItemIndex
            End If

            cargarDgrParametros()
            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim txtAnio As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtAnio"), TextBox)
            txtAnio.Attributes.Add("onkeypress", "javascript:if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;")
            txtAnio.Attributes.Add("onchange", "javascript:f_ValidarAnio(this);")

            Dim txtValor As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtValor"), TextBox)
            txtValor.Attributes.Add("onkeypress", "javascript:f_ValidarNumeroDecimal(this);")

        End Sub

        Protected Sub dgrdMnt_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"

                Dim ibtnEliminar As ImageButton = CType(e.Item.FindControl("ibtnEliminar"), ImageButton)
                ibtnEliminar.Attributes("onclick") = "javascript:return confirm('" & Globals.ccALERTA_ELIMINAR & "');"
            End If
        End Sub

        Protected Sub dgrdMnt_DeleteCommand(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.DeleteCommand
            Dim intCodParametro As Integer = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrFormParametro As BusinessRules.FormulaParametro = New BusinessRules.FormulaParametro

            Dim voRC As Boolean = obrFormParametro.eliminar(intCodParametro)
            If voRC = True Then
                MesgBox("Eliminación Exitosa")
            End If

            dgrdMnt.EditItemIndex = -1
            cargarDgrParametros()
        End Sub

        Protected Sub dgrdMnt_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            dgrdMnt.CurrentPageIndex = e.NewPageIndex
            dgrdMnt.EditItemIndex = -1
            cargarDgrParametros()
        End Sub

        Private Sub MesgBox(ByVal sMessage As String)
            Dim msg As String
            msg = "<script language='javascript'>"
            msg += "alert('" & sMessage & "');"
            msg += "<" & "/script>"
            Response.Write(msg)
        End Sub

        Protected Sub btnBusquedaCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusquedaCuenta.Click
            txtFormula.Text = hidFormula.Value
            lblFormula.Text = hidLblFormula.Value
            txtBusquedaCuenta.Text = txtBusquedaCuenta.Text.Trim()
            cargarDatosReconciliacion()
            txtBusquedaCuenta.Focus()

        End Sub
        'AGREGADO POR XT8633 INICIO - NoContractual
        Private Sub NoContractual(ByVal intContractual As Integer)

            If intContractual = 2 Then
                Me.chknocontractual.Checked = True
            Else
                Me.chknocontractual.Checked = False
            End If

        End Sub
        'AGREGADO POR XT8633 FIN
    End Class
End Namespace