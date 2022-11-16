'*************************************************************
'Proposito:
'Autor: María Laura Santisteban Valdez
'Fecha Creacion: 30/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.BusinessRules
Imports CEF.Common

Namespace CEF.WebUI

    Partial Class mntAuditor
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
            'SRT_2017-2106
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
            Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor

            Dim dsAuditor As DataSet
            dsAuditor = obrAuditor.listar(1, 0)
            dgrdMnt.DataSource = dsAuditor
            dgrdMnt.DataKeyField = "CodAuditor"
            dgrdMnt.DataBind()
            obrAuditor = Nothing

            lblNumReg.Text = dsAuditor.Tables(0).Rows.Count.ToString()
            hidAccion.Value = CType(Globals.ecMntPage.NOACCION, String)
        End Sub


        Private Sub imbNuevo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbNuevo.Click
            Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor

            Dim dsAuditor As DataSet
            dsAuditor = obrAuditor.listar(1, 0)
            Dim drowDataRow As DataRow = dsAuditor.Tables(0).NewRow()
            drowDataRow("RazonSocial") = "(nuevo)"
            dsAuditor.Tables(0).Rows.InsertAt(drowDataRow, 0)
            dgrdMnt.DataSource = dsAuditor.Tables(0)
            dgrdMnt.DataKeyField = "CodAuditor"

            dgrdMnt.EditItemIndex = 0
            dgrdMnt.DataBind()

            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim txtDescripcion As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtDescripcion"), TextBox)
            txtDescripcion.Text = "(nuevo)"

            Dim dropEstado As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropEstado"), DropDownList)

            dropEstado.DataSource = Me.buscarGeneralTabla(Globals.ecTablaGeneral.ESTADO_AUDITOR)
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
                Dim dropEstado As DropDownList = CType(e.Item.FindControl("dropEstado"), DropDownList)
                Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor

                Dim obeAuditor As BusinessEntity.Auditor = New BusinessEntity.Auditor(txtDescripcion.Text, Byte.Parse(dropEstado.SelectedValue))
                Dim voRC As Boolean = obrAuditor.agregar(obeAuditor)
                obrAuditor = Nothing
            Else
                Dim intCodAuditor As Integer = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), Integer)
                Dim txtDescripcion As TextBox = CType(e.Item.FindControl("txtDescripcion"), TextBox)
                Dim dropEstado As DropDownList = CType(e.Item.FindControl("dropEstado"), DropDownList)
                Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor

                Dim obeAuditor As BusinessEntity.Auditor = New BusinessEntity.Auditor
                obeAuditor.CodAuditor = intCodAuditor
                obeAuditor.RazonSocial = txtDescripcion.Text
                obeAuditor.Estado = Int32.Parse(dropEstado.SelectedItem.Value)
                Dim voRC As Boolean = obrAuditor.modificar(obeAuditor)
                obrAuditor = Nothing
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

            Dim intCodAuditor As Integer = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor
            Dim obeAuditor As BusinessEntity.Auditor
            obeAuditor = obrAuditor.leer(intCodAuditor)

            dropEstado.DataSource = Me.buscarGeneralTabla(Globals.ecTablaGeneral.ESTADO_AUDITOR)
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()
            dropEstado.SelectedValue = obeAuditor.Estado()
        End Sub

        Private Sub dgrdMnt_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.DeleteCommand
            Dim intCodAuditor As Integer = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor

            Dim voRC As Boolean = obrAuditor.eliminar(intCodAuditor)

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
