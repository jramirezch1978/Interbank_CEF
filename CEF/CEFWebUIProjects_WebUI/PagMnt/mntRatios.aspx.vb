Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules


Namespace CEF.WebUI
    Partial Public Class mntRatios
        Inherits PageBase



        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not Page.IsPostBack Then
                cargaScript()
                cargarDatos()
                'cargarDatos()
                'Response.Redirect(HttpContext.Current.Request.Url.ToString(), True)
            Else
                'Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
                'cargaScript()
                'CargarGrilla(intCodMetodizado)
                'If hidAccion.Value = "Nuevo" Then
                Dim script As String = "window.close();"
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", script, True)
                'End If


            End If


            'Me.InitForm()

        End Sub

        Protected Sub InitForm()
            cargaScript()
            cargarDatos()
        End Sub

        Private Sub cargaScript()

            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))

            Dim intCodPeriodo As Integer = Int32.Parse(Request.Params("intCodPeriodo"))

            imgnuevo.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntFormulas.aspx?intCodMetodizado={0}&intCodPeriodo={1}&intMntAccion={2}',{3},{4},{5},'{6}');", intCodMetodizado, intCodPeriodo, Int32.Parse(ecMntPage.AGREGAR), 630, 680, Int32.Parse(ecTabMntMetodizado.RECONCILIACION), "Nuevo"))
            lnknuevo.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntFormulas.aspx?intCodMetodizado={0}&intCodPeriodo={1}&intMntAccion={2}',{3},{4},{5},'{6}');", intCodMetodizado, intCodPeriodo, Int32.Parse(ecMntPage.AGREGAR), 630, 680, Int32.Parse(ecTabMntMetodizado.RECONCILIACION), "Nuevo"))
            

        End Sub

        Private Sub cargarDatos()
            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
            Dim intCodPeriodo As Integer = Int32.Parse(Request.Params("intCodPeriodo"))

            Dim strNombreEmpresa As String = Request.Params("strNombreEmpresa")
            Dim strFechaPeriodo As String = Request.Params("strFechaPeriodo")
            Dim strDesEstadoEEFF As String = Request.Params("strDesEstadoEEFF")

            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            obeMetodizado = obrMetodizado.leer(intCodMetodizado)
            If Not obeMetodizado Is Nothing Then
                txtRazonSocial.Text = obeMetodizado.RazonSocial
            End If
            obrMetodizado = Nothing

            txtFechaPeriodo.Text = strFechaPeriodo
            txtEstadoEEFF.Text = strDesEstadoEEFF

            Dim obrFormulaCovenant As BusinessRules.FormulaCovenant = New BusinessRules.FormulaCovenant
            Dim dsFormulaCovenant As DataSet
            dsFormulaCovenant = obrFormulaCovenant.listar(1, intCodMetodizado)

            If dsFormulaCovenant Is Nothing Then
                dtgr1.DataSource = New DataTable
                dtgr1.DataBind()
            Else
                dtgr1.DataSource = dsFormulaCovenant
                dtgr1.DataBind()
                lblpaginas.Text = dsFormulaCovenant.Tables(0).Rows.Count.ToString
            End If
        End Sub

        Private Sub CargarGrilla(ByVal intCodMetodizado As Integer)

            Dim obrFormulaCovenant As BusinessRules.FormulaCovenant = New BusinessRules.FormulaCovenant
            Dim dsFormulaCovenant As DataSet
            dsFormulaCovenant = obrFormulaCovenant.listar(1, intCodMetodizado)

            If dsFormulaCovenant Is Nothing Then
                dtgr1.DataSource = New DataTable
                dtgr1.DataBind()
            Else
                dtgr1.DataSource = dsFormulaCovenant
                dtgr1.DataBind()
                lblpaginas.Text = dsFormulaCovenant.Tables(0).Rows.Count.ToString
            End If
        End Sub



        Private Sub dtgr1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgr1.DeleteCommand
            'Dim result As Integer = MsgBox("Deseas eliminar la fórmula?", MsgBoxStyle.YesNo, "Mensaje de Advertencia")
            'If result = MsgBoxResult.Yes Then
            Dim obrFornulaCovenant As BusinessRules.FormulaCovenant = New BusinessRules.FormulaCovenant
            Dim intCodCovenant As Integer = Integer.Parse(e.Item.Cells(1).Text) 'e.Item.Cells(1) es el codigo covenant
            Dim voRC As Integer = obrFornulaCovenant.eliminar(intCodCovenant)
            If voRC = 0 Then
                MesgBox("Se Elimino la fórmula.")
                cargarDatos()
            Else
                MesgBox("Ocurrio un error con la eliminación de la fórmula.")
            End If
            'End If

        End Sub

        Private Sub dtgr1_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dtgr1.ItemCommand
            Dim intPerfilUsuario As Int32 = Me.fRetornaPerfilUsuario()
            If (e.CommandName = "Editar") Then
                Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
                CargarGrilla(intCodMetodizado)
            ElseIf (e.CommandName = "Estado") Then

                'Dim result As Integer = MsgBox("Deseas validar la fórmla?", MsgBoxStyle.YesNo, "Mensaje de Advertencia", message)
                'If result = MsgBoxResult.Yes Then
                Dim obrFornulaCovenant As BusinessRules.FormulaCovenant = New BusinessRules.FormulaCovenant
                Dim obeFormula As BusinessEntity.Formula = New BusinessEntity.Formula
                Dim intCodCovenant As Integer = Integer.Parse(e.Item.Cells(1).Text) 'e.Item.Cells(1) es el codigo covenant
                Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
                Dim intCodPeriodo As Integer = Int32.Parse(Request.Params("intCodPeriodo"))
                Dim strCodUsuario As String = retornaUsuarioSesion()


                'Se valida que tenga parametros una formula - Flag 2
                obeFormula.CodMetodizado = 2 ' Se envia como flag para no modificar COM
                obeFormula.CodFormula = intCodCovenant
                obeFormula.Estado = 2
                obeFormula.CodUsuarioVal = strCodUsuario

                Dim voRC_V As Integer = obrFornulaCovenant.validar(obeFormula)
                If voRC_V = 0 Then
                    obeFormula.CodMetodizado = 1 ' Se envia como flag para no modificar COM
                    Dim voRC As Integer = obrFornulaCovenant.validar(obeFormula)
                    If voRC = 0 Then
                        MesgBox("Se Validó la fórmula.")
                        cargarDatos()
                    Else
                        MesgBox("Ocurrio un error con la validacion de la fórmula.")
                    End If
                Else
                    MesgBox("La fórmula no se puede validar. No cuenta con Parámetros.")
                End If
            End If

            'End If
        End Sub


        Private Sub dtgr1_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dtgr1.ItemDataBound
            Dim intPerfilUsuario As Int32 = Me.fRetornaPerfilUsuario()
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"

                Dim intCodCovenant As Integer = Integer.Parse(e.Item.Cells(1).Text) 'e.Item.Cells(1) es el codigo covenant
                Dim intEstado As Integer = Integer.Parse(e.Item.Cells(3).Text) 'e.Item.Cells(3) es el estado covenant

                Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
                Dim intCodPeriodo As Integer = Int32.Parse(Request.Params("intCodPeriodo"))
                Dim botonimageEditar As ImageButton = e.Item.Controls(0).FindControl("ibtnEditar")
                botonimageEditar.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntFormulas.aspx?intMntAccion={0}&intCodCovenant={1}&intCodMetodizado={2}&intCodPeriodo={3}',{4},{5},{6},'{7}');", Int32.Parse(ecMntPage.MODIFICAR), intCodCovenant, intCodMetodizado, intCodPeriodo, 630, 680, Int32.Parse(ecTabMntMetodizado.RECONCILIACION), "Editar"))

                'ANALISTA_RIESGO = 2
                'EJECUTIVO_NEGOCIO = 3
                Dim botonimageEliminar As ImageButton = e.Item.Controls(0).FindControl("ibtnEliminar")
                Dim botonimageValidar As ImageButton = e.Item.Controls(0).FindControl("ibtnEstado")

                If intEstado = 1 Then
                    botonimageValidar.ImageUrl = "../Imagen/iconos/icon_Misc_Error.JPG"
                    botonimageValidar.ToolTip = "Estado: Pendiente"
                Else
                    botonimageValidar.ImageUrl = "../Imagen/iconos/icon_Misc_OK.JPG"
                    botonimageValidar.ToolTip = "Estado: Validado"
                End If

                'TABLA DE DECISION SEGUN PERFIL Y ACCIONES
                If intPerfilUsuario = ecPerfil.ANALISTA_RIESGO Then
                    If intEstado = 1 Then
                        botonimageValidar.Enabled = True
                        botonimageEditar.Visible = True
                        botonimageEliminar.Visible = True
                    Else
                        botonimageValidar.Enabled = True
                        botonimageEditar.Visible = True
                        botonimageEliminar.Visible = True
                    End If
                ElseIf intPerfilUsuario = ecPerfil.EJECUTIVO_NEGOCIO Then
                    If intEstado = 1 Then
                        botonimageValidar.Enabled = False
                        botonimageEditar.Visible = True
                        botonimageEliminar.Visible = True
                    Else
                        botonimageValidar.Enabled = False
                        botonimageEditar.Visible = False
                        botonimageEliminar.Visible = False
                    End If

                End If



            End If
        End Sub

        Private Sub MesgBox(ByVal sMessage As String)
            Dim msg As String
            msg = "<script language='javascript'>"
            msg += "alert('" & sMessage & "');"
            msg += "<" & "/script>"
            Response.Write(msg)
        End Sub

    End Class
End Namespace