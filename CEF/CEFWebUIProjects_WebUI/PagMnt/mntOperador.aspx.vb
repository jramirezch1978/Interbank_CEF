'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.BusinessRules
Imports CEF.Common
Imports CEF.BusinessEntity

Namespace CEF.WebUI

    Partial Class mntOperador
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
            cargaDgrMnt()
            imgImprimir.Attributes("onClick") = "javascript:window.print();"
            lnkImprimir.Attributes("url") = "javascript:window.print();"
        End Sub

        Private Sub cargaDgrMnt()
            Dim obrOperador As BusinessRules.Operador = New BusinessRules.Operador

            Dim dsOperador As DataSet = obrOperador.listar(1, 0)
            dgrdMnt.DataSource = dsOperador
            dgrdMnt.DataKeyField = "CodOperador"
            dgrdMnt.DataBind()
            obrOperador = Nothing

            lblNumReg.Text = dsOperador.Tables(0).Rows.Count.ToString()
            hidAccion.Value = CType(Globals.ecMntPage.NOACCION, String)
        End Sub

        Private Sub imbNuevo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbNuevo.Click
            Dim obrOperador As BusinessRules.Operador = New BusinessRules.Operador

            Dim dsOperador As DataSet = obrOperador.listar(1, 0)
            Dim drowDataRow As DataRow = dsOperador.Tables(0).NewRow()
            drowDataRow("Descripcion") = "(nuevo)"
            dsOperador.Tables(0).Rows.InsertAt(drowDataRow, 0)
            dgrdMnt.DataSource = dsOperador.Tables(0)
            dgrdMnt.DataKeyField = "CodOperador"

            dgrdMnt.EditItemIndex = 0
            dgrdMnt.DataBind()

            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim txtDescripcion As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtDescripcion"), TextBox)
            txtDescripcion.Text = "(nuevo)"

            Dim dropEstado As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropEstado"), DropDownList)
            dropEstado.DataSource = buscarGeneralTabla(Convert.ToInt32(Globals.ecTablaGeneral.ESTADO_ANALISIS))
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()

            hidAccion.Value = CType(Globals.ecMntPage.AGREGAR, String)
        End Sub

        Private Sub dgrdMnt_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.CancelCommand
            dgrdMnt.EditItemIndex = -1
            cargaDgrMnt()
        End Sub

        Private Sub dgrdMnt_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.UpdateCommand
            If (hidAccion.Value = CType(Globals.ecMntPage.AGREGAR, String)) And (e.Item.ItemIndex = 0) Then
                Dim txtDescripcion As TextBox = CType(e.Item.FindControl("txtDescripcion"), TextBox)
                Dim txtSimbolo As TextBox = CType(e.Item.FindControl("txtSimbolo"), TextBox)
                Dim dropEstado As DropDownList = CType(e.Item.FindControl("dropEstado"), DropDownList)
                Dim obrOperador As BusinessRules.Operador = New BusinessRules.Operador

                Dim obeOperador As BusinessEntity.Operador = New BusinessEntity.Operador(txtDescripcion.Text, txtSimbolo.Text, Int32.Parse(dropEstado.SelectedValue))
                Dim voRC As Boolean = obrOperador.agregar(obeOperador)
                obrOperador = Nothing
            Else
                Dim intCodOperador As Integer = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), Integer)
                Dim txtDescripcion As TextBox = CType(e.Item.FindControl("txtDescripcion"), TextBox)
                Dim txtSimbolo As TextBox = CType(e.Item.FindControl("txtSimbolo"), TextBox)
                Dim dropEstado As DropDownList = CType(e.Item.FindControl("dropEstado"), DropDownList)
                Dim obrOperador As BusinessRules.Operador = New BusinessRules.Operador

                Dim obeOperador As BusinessEntity.Operador = New BusinessEntity.Operador
                obeOperador.CodOperador = intCodOperador
                obeOperador.Descripcion = txtDescripcion.Text
                obeOperador.Simbolo = txtSimbolo.Text
                obeOperador.Estado = Int32.Parse(dropEstado.SelectedValue)
                Dim voRC As Boolean = obrOperador.modificar(obeOperador)
                obrOperador = Nothing
            End If

            dgrdMnt.EditItemIndex = -1
            cargaDgrMnt()
        End Sub

        Private Sub dgrdMnt_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.EditCommand
            dgrdMnt.EditItemIndex = e.Item.ItemIndex
            cargaDgrMnt()
            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim dropEstado As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropEstado"), DropDownList)

            Dim intCodOperador As Integer = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrOperador As BusinessRules.Operador = New BusinessRules.Operador
            Dim obeOperador As BusinessEntity.Operador = obrOperador.leer(intCodOperador)

            dropEstado.DataSource = buscarGeneralTabla(Globals.ecTablaGeneral.ESTADO_OPERADOR)
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()
            dropEstado.SelectedValue = obeOperador.Estado()
        End Sub

        Private Sub dgrdMnt_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.DeleteCommand
            Dim intCodOperador As Integer = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrOperador As BusinessRules.Operador = New BusinessRules.Operador

            Dim voRC As Boolean = obrOperador.eliminar(intCodOperador)

            dgrdMnt.EditItemIndex = -1
            cargaDgrMnt()
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
            cargaDgrMnt()
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace