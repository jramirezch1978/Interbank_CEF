'*************************************************************
'Proposito:
'Autor: XT8633
'Fecha Creacion:24-10-2019
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports CEF.Common
Imports CEF.BusinessRules
Imports System.Reflection

Imports CEF.Common.Globals

Namespace CEF.WebUI
    Public Class mntAsociadosCovenant
        Inherits PageBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If PageBase.PostbackSession(Me) Then
                Dim intCodMetodizado As Integer
                intCodMetodizado = Int32.Parse(Request.Params("intCodMetodizado"))
                hidCodmetodizado.Value = intCodMetodizado
                cargarScript()
                cargarListadoAsociados(intCodMetodizado)
            End If
        End Sub

        Private Sub cargarListadoAsociados(ByVal intCodMetodizado As Integer)

            Dim obrMetodizadoAsociados As BusinessRules.MetodizadoAsociado = New BusinessRules.MetodizadoAsociado
            Dim dsListadoAsociados As DataSet

            dsListadoAsociados = obrMetodizadoAsociados.listar(intCodMetodizado)

            If dsListadoAsociados Is Nothing Then
                dtgr1.DataSource = New DataTable
                dtgr1.DataBind()
                Me.lblnumPaginas.Text = "No se encontraron registros"
            Else
                If dsListadoAsociados.Tables(0).Rows.Count.ToString = 0 Then
                    dtgr1.DataSource = New DataTable
                    dtgr1.DataBind()
                    Me.lblnumPaginas.Text = "No se encontraron"
                    Me.lblpaginas.Text = "registros para mostrar"
                Else
                    dtgr1.DataSource = dsListadoAsociados
                    dtgr1.DataBind()
                    dtgr1.CurrentPageIndex = 0
                    Me.lblnumPaginas.Text = "Num. Registros:"
                    lblpaginas.Text = dsListadoAsociados.Tables(0).Rows.Count.ToString
                End If
            End If


        End Sub
        Private Sub cargarScript()

            Dim intCodmetodizado As Integer
            intCodmetodizado = Integer.Parse(hidCodmetodizado.Value)

            imgnuevo.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntBusquedaCliente.aspx?intCodMetodizado={0}&intMntAccion={1}',{2},{3},{4},'{5}');", intCodmetodizado, Int32.Parse(ecMntPage.AGREGAR), 625, 495, Int32.Parse(ecTabMntMetodizado.RECONCILIACION), "Nuevo"))
            lnknuevo.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntBusquedaCliente.aspx?intCodMetodizado={0}&intMntAccion={1}',{2},{3},{4},'{5}');", intCodmetodizado, Int32.Parse(ecMntPage.AGREGAR), 625, 495, Int32.Parse(ecTabMntMetodizado.RECONCILIACION), "Nuevo"))

        End Sub
        Public Sub ManejadorCrud(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)
            Dim myButton As ImageButton = CType(sender, ImageButton)
            If (myButton.CommandName.Equals("Eliminar")) Then
                Eliminar(myButton.CommandArgument)
            End If
        End Sub

        Public Sub Eliminar(ByVal pintCodUnico As String)
            Dim intCodMetodizado As Integer = hidCodmetodizado.Value
            If (fRetornaPerfilUsuario() <= Common.Globals.ecPerfil.ANALISTA_RIESGO Or fRetornaPerfilUsuario()) Then
                Dim obrMetodizadoAsociado As BusinessRules.MetodizadoAsociado = New BusinessRules.MetodizadoAsociado
                Try
                    obrMetodizadoAsociado.eliminar(intCodMetodizado, pintCodUnico)
                    cargarListadoAsociados(intCodMetodizado)
                Catch ex As Exception
                    Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                    Throw ex
                End Try
            Else
                Me.muestraAlerta("Ud. no tiene permisos para desasociar este cliente.")
            End If
        End Sub

        Protected Sub dtgr1_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgr1.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"
            End If
        End Sub

        Protected Sub dtgr1_PageIndexChanged(ByVal source As System.Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dtgr1.PageIndexChanged
            If Page.IsPostBack Then
                dtgr1.CurrentPageIndex = e.NewPageIndex
                dtgr1.DataBind()
            End If
        End Sub
    End Class
End Namespace