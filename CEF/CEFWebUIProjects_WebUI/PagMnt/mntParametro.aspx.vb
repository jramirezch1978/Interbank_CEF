'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por: María Laura Santisteban
'Fecha Mod.: 31/03/2006
'*************************************************************

Imports CEF.BusinessRules
Imports CEF.Common

Namespace CEF.WebUI

    Partial Class mntParametro
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
            Dim obrParametro As BusinessRules.Parametro = New BusinessRules.Parametro

            Dim dsParametro As DataSet = obrParametro.listar()
            dgrdMnt.DataSource = dsParametro
            dgrdMnt.DataKeyField = "CodParametro"
            dgrdMnt.DataBind()
            obrParametro = Nothing

            lblNumReg.Text = dsParametro.Tables(0).Rows.Count.ToString()
            hidAccion.Value = CType(Globals.ecMntPage.NOACCION, String)
           
        End Sub

        Private Sub dgrdMnt_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.EditCommand
            dgrdMnt.EditItemIndex = e.Item.ItemIndex
            cargaDgrMnt()
            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim txtCodParam As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtCodParam"), TextBox)
            txtCodParam.ReadOnly = True
            txtCodParam.CssClass = "NoActivo"


            Dim dropEstado As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropEstado"), DropDownList)

            Dim strCodParam As String = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), String)
            Dim obrParametro As BusinessRules.Parametro = New BusinessRules.Parametro
            Dim obeParametro As BusinessEntity.Parametro = obrParametro.leer(strCodParam)

            dropEstado.DataSource = Me.buscarGeneralTabla(Globals.ecTablaGeneral.ESTADO_PARAMETRO)
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()
            dropEstado.SelectedValue = obeParametro.Estado()
        End Sub

        Private Sub dgrdMnt_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.DeleteCommand
            Dim strCodParam As String = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), String)
            Dim obrParametro As BusinessRules.Parametro = New BusinessRules.Parametro

            Dim voRC As Boolean = obrParametro.eliminar(strCodParam)

            dgrdMnt.EditItemIndex = -1
            cargaDgrMnt()
        End Sub

        Private Sub dgrdMnt_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.CancelCommand
            dgrdMnt.EditItemIndex = -1
            cargaDgrMnt()
        End Sub

        Private Sub dgrdMnt_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.UpdateCommand
            If (hidAccion.Value = CType(Globals.ecMntPage.AGREGAR, String)) And (e.Item.ItemIndex = 0) Then
                Dim txtCodParam As TextBox = CType(e.Item.FindControl("txtCodParam"), TextBox)
                Dim txtDescripcion As TextBox = CType(e.Item.FindControl("txtDescripcion"), TextBox)
                Dim txtValor1 As TextBox = CType(e.Item.FindControl("txtValor1"), TextBox)
                Dim txtValor2 As TextBox = CType(e.Item.FindControl("txtValor2"), TextBox)
                Dim dropEstado As DropDownList = CType(e.Item.FindControl("dropEstado"), DropDownList)
                Dim obrParametro As BusinessRules.Parametro = New BusinessRules.Parametro

                Dim obeParametro As BusinessEntity.Parametro = New BusinessEntity.Parametro(txtCodParam.Text, txtDescripcion.Text, txtValor1.Text, txtValor2.Text, dropEstado.SelectedItem.Value)
                Dim voRC As Boolean = obrParametro.agregar(obeParametro)
                obrParametro = Nothing
            Else
                Dim strCodParam As String = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), String)
                Dim txtDescripcion As TextBox = CType(e.Item.FindControl("txtDescripcion"), TextBox)
                Dim txtValor1 As TextBox = CType(e.Item.FindControl("txtValor1"), TextBox)
                Dim txtValor2 As TextBox = CType(e.Item.FindControl("txtValor2"), TextBox)
                Dim dropEstado As DropDownList = CType(e.Item.FindControl("dropEstado"), DropDownList)
                Dim obrParametro As BusinessRules.Parametro = New BusinessRules.Parametro

                Dim obeParametro As BusinessEntity.Parametro = New BusinessEntity.Parametro
                obeParametro.CodParametro = strCodParam
                obeParametro.Descripcion = txtDescripcion.Text
                obeParametro.Valor1 = txtValor1.Text
                obeParametro.Valor2 = txtValor2.Text
                obeParametro.Estado = dropEstado.SelectedItem.Value
                Dim voRC As Boolean = obrParametro.modificar(obeParametro)
                obrParametro = Nothing
            End If

            dgrdMnt.EditItemIndex = -1
            cargaDgrMnt()
        End Sub

        Private Sub dgrdMnt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            dgrdMnt.CurrentPageIndex = e.NewPageIndex
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

        Private Sub imbNuevo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbNuevo.Click
            Dim obrParametro As BusinessRules.Parametro = New BusinessRules.Parametro

            Dim dsParametro As DataSet = obrParametro.listar()
            Dim drowDataRow As DataRow = dsParametro.Tables(0).NewRow()
            drowDataRow("Descripcion") = "(nuevo)"
            dsParametro.Tables(0).Rows.InsertAt(drowDataRow, 0)
            dgrdMnt.DataSource = dsParametro.Tables(0)
            dgrdMnt.DataKeyField = "CodParametro"

            dgrdMnt.EditItemIndex = 0
            dgrdMnt.DataBind()

            Dim ibtnEliminar As ImageButton = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("ibtnEliminar"), ImageButton)
            ibtnEliminar.Visible = False

            Dim txtCodParam As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtCodParam"), TextBox)
            txtCodParam.Text = String.Empty

            Dim txtDescripcion As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtDescripcion"), TextBox)
            txtDescripcion.Text = "(nuevo)"

            Dim txtValor1 As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtValor1"), TextBox)
            txtValor1.Text = String.Empty

            Dim txtValor2 As TextBox = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("txtValor2"), TextBox)
            txtValor2.Text = String.Empty

            Dim dropEstado As DropDownList = CType(dgrdMnt.Items(dgrdMnt.EditItemIndex).FindControl("dropEstado"), DropDownList)

            dropEstado.DataSource = Me.buscarGeneralTabla(Globals.ecTablaGeneral.ESTADO_PARAMETRO)
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()

            hidAccion.Value = CType(Globals.ecMntPage.AGREGAR, String)
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace