'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por: María Laura Santisteban
'Fecha Mod.: 03/04/2006
'*************************************************************

Imports CEF.BusinessRules
Imports CEF.Common

Namespace CEF.WebUI

    Partial Class mntGeneral
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
            '        CargaDatosTbl()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    CargaDatosTbl()
                End If
            End If
        End Sub

        Private Sub CargaDatosTbl()
            cargaDgrMntTbl()
            imgImprimirTbl.Attributes("onClick") = "javascript:window.print();"
            lnkImprimirTbl.Attributes("url") = "javascript:window.print();"
        End Sub

        Private Sub cargaDgrMntTbl()
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General

            Dim dsGeneral As DataSet
            dsGeneral = obrGeneral.listar(Globals.ecTablaGeneral.TABLA)
            dgrdMntTbl.DataSource = dsGeneral
            dgrdMntTbl.DataKeyField = "CodItem"
            dgrdMntTbl.DataBind()
            obrGeneral = Nothing

            lblNumRegTbl.Text = dsGeneral.Tables(0).Rows.Count.ToString()
            hidAccionTbl.Value = CType(Globals.ecMntPage.NOACCION, String)

        End Sub

        Private Sub cargaDgrMntItem()
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General

            Dim intCodTbl As Integer = CType(dgrdMntTbl.DataKeys(dgrdMntTbl.SelectedItem.ItemIndex), Integer)
            Dim dsGeneral As DataSet
            dsGeneral = obrGeneral.listar(intCodTbl)
            dgrdMntItem.DataSource = dsGeneral
            dgrdMntItem.DataKeyField = "CodItem"
            dgrdMntItem.DataBind()
            obrGeneral = Nothing

            lblNumRegItem.Text = dsGeneral.Tables(0).Rows.Count.ToString()
            hidAccionItem.Value = CType(Globals.ecMntPage.NOACCION, String)

        End Sub

        Private Sub imbNuevoTbl_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbNuevoTbl.Click
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General

            Dim dsGeneral As DataSet
            dsGeneral = obrGeneral.listar(Globals.ecTablaGeneral.TABLA)
            Dim drowDataRow As DataRow = dsGeneral.Tables(0).NewRow()
            drowDataRow("Descripcion") = "(nuevo)"
            dsGeneral.Tables(0).Rows.InsertAt(drowDataRow, 0)
            dgrdMntTbl.DataSource = dsGeneral.Tables(0)
            dgrdMntTbl.DataKeyField = "CodItem"

            dgrdMntTbl.EditItemIndex = 0
            dgrdMntTbl.DataBind()

            Dim ibtnEliminarTbl As ImageButton = CType(dgrdMntTbl.Items(dgrdMntTbl.EditItemIndex).FindControl("ibtnEliminarTbl"), ImageButton)
            ibtnEliminarTbl.Visible = False


            Dim txtCodTbl As TextBox = CType(dgrdMntTbl.Items(dgrdMntTbl.EditItemIndex).FindControl("txtCodTbl"), TextBox)
            txtCodTbl.Text = String.Empty

            Dim txtDescripcionTbl As TextBox = CType(dgrdMntTbl.Items(dgrdMntTbl.EditItemIndex).FindControl("txtDescripcionTbl"), TextBox)
            txtDescripcionTbl.Text = "(nuevo)"

            Dim txtDesCortaTbl As TextBox = CType(dgrdMntTbl.Items(dgrdMntTbl.EditItemIndex).FindControl("txtDesCortaTbl"), TextBox)
            txtDesCortaTbl.Text = String.Empty

            hidAccionTbl.Value = CType(Globals.ecMntPage.AGREGAR, String)
        End Sub

        Private Sub imbNuevoItem_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbNuevoItem.Click

            If Not dgrdMntTbl.SelectedItem Is Nothing Then
                Dim intCodTbl As Integer = CType(dgrdMntTbl.DataKeys(dgrdMntTbl.SelectedItem.ItemIndex), Integer)

                Dim obrGeneral As BusinessRules.General = New BusinessRules.General

                Dim dsGeneral As DataSet
                dsGeneral = obrGeneral.listar(intCodTbl)
                Dim drowDataRow As DataRow = dsGeneral.Tables(0).NewRow()
                drowDataRow("Descripcion") = "(nuevo)"
                dsGeneral.Tables(0).Rows.InsertAt(drowDataRow, 0)


                dgrdMntItem.DataSource = dsGeneral.Tables(0)
                dgrdMntItem.DataKeyField = "CodItem"

                dgrdMntItem.EditItemIndex = 0
                dgrdMntItem.DataBind()

                Dim ibtnEliminarItem As ImageButton = CType(dgrdMntItem.Items(dgrdMntItem.EditItemIndex).FindControl("ibtnEliminarItem"), ImageButton)
                ibtnEliminarItem.Visible = False

                hidAccionItem.Value = CType(Globals.ecMntPage.AGREGAR, String)

            End If
            
        End Sub

        Private Sub dgrdMntTbl_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMntTbl.CancelCommand
            dgrdMntTbl.EditItemIndex = -1
            cargaDgrMntTbl()
        End Sub

        Private Sub dgrdMntItem_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMntItem.CancelCommand
            dgrdMntItem.EditItemIndex = -1
            cargaDgrMntItem()
        End Sub

        Private Sub dgrdMntTbl_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMntTbl.UpdateCommand
            If (hidAccionTbl.Value = CType(Globals.ecMntPage.AGREGAR, String)) And (e.Item.ItemIndex = 0) Then
                Dim txtCodTbl As TextBox = CType(e.Item.FindControl("txtCodTbl"), TextBox)
                Dim txtDescripcionTbl As TextBox = CType(e.Item.FindControl("txtDescripcionTbl"), TextBox)
                Dim txtDesCortaTbl As TextBox = CType(e.Item.FindControl("txtDesCortaTbl"), TextBox)
                Dim dropEstadoTbl As DropDownList = CType(e.Item.FindControl("dropEstadoTbl"), DropDownList)
                Dim obrGeneral As BusinessRules.General = New BusinessRules.General

                Dim obeGeneral As BusinessEntity.General = New BusinessEntity.General(Globals.ecTablaGeneral.TABLA, txtCodTbl.Text, txtDescripcionTbl.Text, txtDesCortaTbl.Text, dropEstadoTbl.SelectedItem.Value)
                Dim voRC As Boolean = obrGeneral.agregar(obeGeneral)
                obrGeneral = Nothing

            Else
                Dim intCodTbl As Integer = CType(dgrdMntTbl.DataKeys(e.Item.ItemIndex), Integer)
                Dim txtDescripcionTbl As TextBox = CType(e.Item.FindControl("txtDescripcionTbl"), TextBox)
                Dim txtDesCortaTbl As TextBox = CType(e.Item.FindControl("txtDesCortaTbl"), TextBox)
                Dim dropEstadoTbl As DropDownList = CType(e.Item.FindControl("dropEstadoTbl"), DropDownList)
                Dim obrGeneral As BusinessRules.General = New BusinessRules.General

                Dim obeGeneral As BusinessEntity.General = New BusinessEntity.General
                obeGeneral.CodTbl = Globals.ecTablaGeneral.TABLA
                obeGeneral.CodItem = intCodTbl
                obeGeneral.Descripcion = txtDescripcionTbl.Text
                obeGeneral.DesCorta = txtDesCortaTbl.Text
                obeGeneral.Estado = dropEstadoTbl.SelectedItem.Value
                Dim voRC As Boolean = obrGeneral.modificar(obeGeneral)
                obrGeneral = Nothing
            End If

            dgrdMntTbl.EditItemIndex = -1
            cargaDgrMntTbl()
        End Sub

        Private Sub dgrdMntItem_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMntItem.UpdateCommand
            If (hidAccionItem.Value = CType(Globals.ecMntPage.AGREGAR, String)) And (e.Item.ItemIndex = 0) Then
                Dim txtCodItem As TextBox = CType(e.Item.FindControl("txtCodItem"), TextBox)
                Dim txtDescripcionItem As TextBox = CType(e.Item.FindControl("txtDescripcionItem"), TextBox)
                Dim txtDesCortaItem As TextBox = CType(e.Item.FindControl("txtDesCortaItem"), TextBox)
                Dim dropEstadoItem As DropDownList = CType(e.Item.FindControl("dropEstadoItem"), DropDownList)

                'SRT_2017-02160
                Dim obrGeneral As BusinessRules.General = New BusinessRules.General

                Dim intCodTbl As Integer = CType(dgrdMntTbl.DataKeys(dgrdMntTbl.SelectedItem.ItemIndex), Integer)
                Dim obeGeneral As BusinessEntity.General = New BusinessEntity.General(intCodTbl, txtCodItem.Text, txtDescripcionItem.Text, txtDesCortaItem.Text, dropEstadoItem.SelectedItem.Value)
                Dim voRC As Boolean = obrGeneral.agregar(obeGeneral)
                obrGeneral = Nothing

            Else
                Dim intCodItem As Integer = CType(dgrdMntItem.DataKeys(e.Item.ItemIndex), Integer)
                Dim txtDescripcionItem As TextBox = CType(e.Item.FindControl("txtDescripcionItem"), TextBox)
                Dim txtDesCortaItem As TextBox = CType(e.Item.FindControl("txtDesCortaItem"), TextBox)
                Dim dropEstadoItem As DropDownList = CType(e.Item.FindControl("dropEstadoItem"), DropDownList)
                Dim obrGeneral As BusinessRules.General = New BusinessRules.General

                Dim obeGeneral As BusinessEntity.General = New BusinessEntity.General
                Dim intCodTbl As Integer = CType(dgrdMntTbl.DataKeys(dgrdMntTbl.SelectedItem.ItemIndex), Integer)
                obeGeneral.CodTbl = intCodTbl
                obeGeneral.CodItem = intCodItem
                obeGeneral.Descripcion = txtDescripcionItem.Text
                obeGeneral.DesCorta = txtDesCortaitem.Text
                obeGeneral.Estado = dropEstadoitem.SelectedItem.Value
                Dim voRC As Boolean = obrGeneral.modificar(obeGeneral)
                obrGeneral = Nothing
            End If

            dgrdMntItem.EditItemIndex = -1
            cargaDgrMntItem()
        End Sub

        Private Sub dgrdMntTbl_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMntTbl.DeleteCommand
            Dim intCodItem As String = CType(dgrdMntTbl.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General

            Dim voRC As Boolean = obrGeneral.eliminar(Globals.ecTablaGeneral.TABLA, intCodItem)
            dgrdMntTbl.EditItemIndex = -1
            cargaDgrMntTbl()
        End Sub

        Private Sub dgrdMntItem_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMntItem.DeleteCommand
            Dim intCodItem As Integer = CType(dgrdMntItem.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General

            Dim intCodTbl As Integer = CType(dgrdMntTbl.DataKeys(dgrdMntTbl.SelectedItem.ItemIndex), Integer)
            Dim voRC As Boolean = obrGeneral.eliminar(intCodTbl, intCodItem)
            dgrdMntItem.EditItemIndex = -1
            cargaDgrMntItem()
        End Sub

        Private Sub dgrdMntTbl_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMntTbl.EditCommand
            dgrdMntTbl.EditItemIndex = e.Item.ItemIndex
            cargaDgrMntTbl()
            Dim ibtnEliminarTbl As ImageButton = CType(dgrdMntTbl.Items(dgrdMntTbl.EditItemIndex).FindControl("ibtnEliminarTbl"), ImageButton)
            ibtnEliminarTbl.Visible = False

            Dim txtCodTbl As TextBox = CType(dgrdMntTbl.Items(dgrdMntTbl.EditItemIndex).FindControl("txtCodTbl"), TextBox)
            txtCodTbl.ReadOnly = True
            txtCodTbl.CssClass = "NoActivo"

            Dim dropEstadoTbl As DropDownList = CType(dgrdMntTbl.Items(dgrdMntTbl.EditItemIndex).FindControl("dropEstadoTbl"), DropDownList)

            Dim intCodTbl As Integer = CType(dgrdMntTbl.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General
            Dim obeGeneral As BusinessEntity.General
            obeGeneral = obrGeneral.leer(Globals.ecTablaGeneral.TABLA, intCodTbl)
            dropEstadoTbl.SelectedValue = obeGeneral.Estado()
        End Sub

        Private Sub dgrdMntItem_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMntItem.EditCommand
            dgrdMntItem.EditItemIndex = e.Item.ItemIndex
            cargaDgrMntItem()
            Dim ibtnEliminarItem As ImageButton = CType(dgrdMntItem.Items(dgrdMntItem.EditItemIndex).FindControl("ibtnEliminarItem"), ImageButton)
            ibtnEliminarItem.Visible = False

            Dim txtCodItem As TextBox = CType(dgrdMntItem.Items(dgrdMntItem.EditItemIndex).FindControl("txtCodItem"), TextBox)
            txtCodItem.ReadOnly = True
            txtCodItem.CssClass = "NoActivo"

            Dim dropEstadoItem As DropDownList = CType(dgrdMntItem.Items(dgrdMntItem.EditItemIndex).FindControl("dropEstadoItem"), DropDownList)

            Dim intCodTbl As Integer = CType(dgrdMntTbl.DataKeys(dgrdMntTbl.SelectedItem.ItemIndex), Integer)
            Dim intCodItem As Integer = CType(dgrdMntItem.DataKeys(e.Item.ItemIndex), Integer)
            Dim obrGeneral As BusinessRules.General = New BusinessRules.General
            Dim obeGeneral As BusinessEntity.General
            obeGeneral = obrGeneral.leer(intCodTbl, intCodItem)
            dropEstadoItem.SelectedValue = obeGeneral.Estado()
        End Sub

        Private Sub dgrdMntTbl_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMntTbl.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                'e.Item.Attributes("onmouseover") = "this.className='Selector'"
                'e.Item.Attributes("onmouseout") = "this.className='Registro'"

                Dim ibtnEliminarTbl As ImageButton = CType(e.Item.FindControl("ibtnEliminarTbl"), ImageButton)
                ibtnEliminarTbl.Attributes("onclick") = "javascript:return confirm('" & Globals.ccALERTA_ELIMINAR & "');"

                Dim button As LinkButton = CType(e.Item.Cells(7).Controls(0), LinkButton)
                e.Item.Attributes("onclick") = Page.GetPostBackClientHyperlink(button, "")
            End If
        End Sub

        Private Sub dgrdMntItem_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMntItem.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"

                Dim ibtnEliminarItem As ImageButton = CType(e.Item.FindControl("ibtnEliminarItem"), ImageButton)
                ibtnEliminarItem.Attributes("onclick") = "javascript:return confirm('" & Globals.ccALERTA_ELIMINAR & "');"
            End If
        End Sub

        Private Sub dgrdMntTbl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgrdMntTbl.SelectedIndexChanged
            cargaDgrMntItem()
        End Sub

        Private Sub dgrdMntTbl_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMntTbl.PageIndexChanged
            dgrdMntTbl.CurrentPageIndex = e.NewPageIndex
            dgrdMntTbl.EditItemIndex = -1
            dgrdMntTbl.SelectedIndex = -1
            cargaDgrMntTbl()
            dgrdMntItem.DataSource = New DataTable
            dgrdMntItem.DataBind()
        End Sub

        Private Sub dgrdMntItem_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMntItem.PageIndexChanged
            dgrdMntItem.CurrentPageIndex = e.NewPageIndex
            dgrdMntItem.EditItemIndex = -1
            cargaDgrMntItem()
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace
