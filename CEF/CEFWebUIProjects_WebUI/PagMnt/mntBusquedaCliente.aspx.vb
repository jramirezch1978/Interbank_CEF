Imports CEF.Common.Globals
Namespace CEF.WebUI

    Public Class mntBusquedaCliente
        Inherits PageBase

#Region "FUNCTION"
        Private Sub cargarBusquedaCliente(ByVal pstrFiltro As String)
            Dim obrMetodizadoAsociados As BusinessRules.IMetodizadoAsociado = New BusinessRules.MetodizadoAsociado
            Dim dsListadoClientes As DataSet

            dsListadoClientes = obrMetodizadoAsociados.buscarCliente(pstrFiltro)

            If dsListadoClientes Is Nothing Then
                dtgr1.DataSource = New DataTable
                dtgr1.DataBind()
            Else
                dtgr1.DataSource = dsListadoClientes
                dtgr1.DataBind()
                lblpaginas.Text = dsListadoClientes.Tables(0).Rows.Count.ToString
            End If
        End Sub

        Private Sub MesgBox(ByVal sMessage As String)
            Dim msg As String
            msg = "<script language='javascript'>"
            msg += "alert('" & sMessage & "');"
            msg += "<" & "/script>"
            Response.Write(msg)
        End Sub

        Private Sub CloseWindow(ByVal sMessage As String)
            Dim msg As String
            msg = "<script language='javascript'>"
            msg += "alert('" & sMessage & "');"
            msg += "this.close();"
            msg += "<" & "/script>"
            Response.Write(msg)
        End Sub

        Private Sub AsociarCliente()
            Dim strCOUnico As String
            Dim intCodMetodizado As Integer
            Dim strMsg As String
            Dim obrMetodizadoAsociados As BusinessRules.IMetodizadoAsociado = New BusinessRules.MetodizadoAsociado

            intCodMetodizado = Int32.Parse(Request.Params("intCodMetodizado"))
            strCOUnico = hidSelect.Value
            strMsg = obrMetodizadoAsociados.agregar(intCodMetodizado, strCOUnico)
            If (strMsg <> "") Then
                MesgBox(strMsg)
            Else
                CloseWindow("Se asoció correctamente.")
            End If
        End Sub

        Private Sub BuscarCliente()
            Dim strFiltro As String
            strFiltro = txtFiltro.Text.Trim()
            dtgr1.CurrentPageIndex = 0
            cargarBusquedaCliente(strFiltro)
            txtFiltro.Focus()
        End Sub

        Private Sub PaginacionCliente(ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs)
            dtgr1.CurrentPageIndex = e.NewPageIndex
            dtgr1.EditItemIndex = -1

            Dim strFiltro As String
            strFiltro = txtFiltro.Text.Trim()
            cargarBusquedaCliente(strFiltro)
            txtFiltro.Focus()
        End Sub
#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If PageBase.PostbackSession(Me) Then
            End If
            txtFiltro.Focus()
        End Sub

        Protected Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            BuscarCliente()
        End Sub

        Protected Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
            AsociarCliente()
        End Sub

        Protected Sub dtgr1_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgr1.PageIndexChanged
            PaginacionCliente(e)
        End Sub
    End Class
End Namespace