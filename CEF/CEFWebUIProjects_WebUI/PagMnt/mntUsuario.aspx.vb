'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 15/08/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Text
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection


Namespace CEF.WebUI

    Partial Class mntUsuario
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

        Private Const ccID_WEBUI_MNT As String = "Usuario"
        Private Const ccID_WEBUI_MNT_CARTERAUSUARIO As String = "Cartera de Usuario"

        Private Property MntAccion() As Integer
            Get
                Return (hidMntAccion.Value)
            End Get
            Set(ByVal Value As Integer)
                hidMntAccion.Value = Value
            End Set
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        End Sub

        Private Sub cargaScript()
            imgImpCartera.Attributes.Add("onClick", "javascript:window.print();")
            lnkImpCartera.Attributes.Add("href", "javascript:window.print();")
            UpdatePanel1.PostCallBackFunction = "pMostrarNoAsignados"
            dropPerfil.Attributes.Add("onChange", "javascript:verificarPerfilAnalista();")

            'Añadir atributo readonly a textbox
            txtFecReg.Attributes.Add("readonly", "readonly")
        End Sub

        Private Sub cargarDatos()
            Dim obePerfil As BusinessEntity.Perfil
            Dim obrPerfil As BusinessRules.Perfil = New BusinessRules.Perfil

            dropPerfil.DataSource = obrPerfil.listar(1, 0)
            dropPerfil.DataTextField = "Nombre"
            dropPerfil.DataValueField = "CodPerfil"
            dropPerfil.DataBind()

            dropEstado.DataSource = buscarGeneralTabla(ecTablaGeneral.ESTADO_USUARIO)
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()

            Dim obeParametro As BusinessEntity.Parametro = buscarParametro("USU_COD_PERFIL")
            dropPerfil.SelectedValue = obeParametro.Valor1

            obeParametro = buscarParametro("USU_COD_ESTADO")
            dropEstado.SelectedValue = obeParametro.Valor1

            MntAccion = Int32.Parse(Request.Params("intMntAccion"))

            If MntAccion = Int32.Parse(ecMntPage.AGREGAR) Then
                bloquearControles(False)
                configMntAccion(ecMntPage.AGREGAR)
            ElseIf MntAccion = Int32.Parse(ecMntPage.MODIFICAR) Then
                cargarDatosUsuario()
                bloquearControles()
                configMntAccion(ecMntPage.MODIFICAR)
            End If
        End Sub

        Private Sub configMntAccion(ByVal pordMntPage As ecMntPage)
            If pordMntPage = ecMntPage.AGREGAR Then
                MntAccion = Int32.Parse(ecMntPage.AGREGAR)
                btnGrabar.Attributes("onclick") = "javascript:if (confirm('" + ccALERTA_AGREGAR + "')) { document.getElementById('hidMntAccion').value = " + Int32.Parse(ecMntPage.AGREGAR).ToString() + "; return(true); } else { return(false); }"
            ElseIf pordMntPage = ecMntPage.MODIFICAR Then
                MntAccion = Int32.Parse(ecMntPage.MODIFICAR)
                btnGrabar.Attributes("onclick") = "javascript:if (confirm('" + ccALERTA_MODIFICAR + "')) { document.getElementById('hidMntAccion').value = " + Int32.Parse(ecMntPage.MODIFICAR).ToString() + "; return(true); } else { return(false); }"
            End If
        End Sub

        Private Sub cargarDatosUsuario()
            Dim strCodUsuario As String = Request.QueryString("strCodUsuario")

            Dim obeUsuario As BusinessEntity.Usuario
            Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

            obeUsuario = obrUsuario.leer(strCodUsuario)

            If Not obeUsuario Is Nothing Then
                txtCodUsuario.Text = obeUsuario.CodUsuario
                txtNombre.Text = obeUsuario.Nombre
                txtEmail.Text = obeUsuario.Email
                dropPerfil.SelectedValue = obeUsuario.CodPerfil
                txtFecReg.Text = obeUsuario.FecReg.ToShortDateString
                dropEstado.SelectedValue = obeUsuario.Estado
                cargarCarteraUsuario(obeUsuario)
                chkSupervisor.Checked = obeUsuario.Supervisor

                If obeUsuario.CodPerfil = ecPerfil.ANALISTA_RIESGO Then
                    divSupervisor.Attributes.Add("style", "display:''")
                End If
            End If
        End Sub

        Private Sub cargarCarteraUsuario(ByRef pobeUsuario As BusinessEntity.Usuario)
            Dim obeCarteraPerfilLst As BusinessEntity.CarteraPerfilLst
            Dim obrPerfil As BusinessRules.Perfil = New BusinessRules.Perfil

            obeCarteraPerfilLst = obrPerfil.listarCarteraPerfil(pobeUsuario.CodPerfil)

            If obeCarteraPerfilLst.Count > 0 Then
                Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                Dim dsUsuPorAsignar As DataSet = obrUsuario.listarUsuarioPorAsignarCarteraUsuario(pobeUsuario.CodUsuario)
                dgrdMntUsuPorAsignar.DataSource = dsUsuPorAsignar
                dgrdMntUsuPorAsignar.DataKeyField = "CodUsuario"
                dgrdMntUsuPorAsignar.DataBind()

                Dim dsUsuSubordinado As DataSet = obrUsuario.listarSubordinadoCarteraUsuario(pobeUsuario.CodUsuario)
                dgrdMntUsuSubordinado.DataSource = dsUsuSubordinado
                dgrdMntUsuSubordinado.DataKeyField = "CodUsuario"
                dgrdMntUsuSubordinado.DataBind()
            Else
                dgrdMntUsuPorAsignar.DataSource = New DataTable
                dgrdMntUsuPorAsignar.DataKeyField = "CodUsuario"
                dgrdMntUsuPorAsignar.DataBind()

                dgrdMntUsuSubordinado.DataSource = New DataTable
                dgrdMntUsuSubordinado.DataKeyField = "CodUsuario"
                dgrdMntUsuSubordinado.DataBind()
            End If
        End Sub

        Private Sub refrescarTabControl(ByVal intTabIndice As Integer)
        End Sub

        Private Sub activarReportes(ByVal pordReporte As ecReporte, Optional ByVal bolActivar As Boolean = True)
        End Sub

        Private Sub bloquearControles(Optional ByVal bolBloqueo As Boolean = True)
            txtCodUsuario.ReadOnly = bolBloqueo
            If bolBloqueo Then
                txtCodUsuario.CssClass = "NoActivo"
            Else
                txtCodUsuario.CssClass = String.Empty
            End If

            If bolBloqueo Then
                btnAsignarCartera.Attributes.Remove("onclick")
                btnExcluirCartera.Attributes.Remove("onclick")
            Else
                btnAsignarCartera.Attributes.Add("onclick", String.Format("javascript:alert('{0}'); return(false);", ccALERTA_BLOQUEO_CARTERA_USUARIO))
                btnExcluirCartera.Attributes.Add("onclick", String.Format("javascript:alert('{0}'); return(false);", ccALERTA_BLOQUEO_CARTERA_USUARIO))
                imgImpCartera.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_CARTERA_USUARIO))
                lnkImpCartera.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_CARTERA_USUARIO))
                'imgExpCartera.Attributes.Add("onclick", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_CARTERA_USUARIO))
                'lnkExpCartera.Attributes.Add("href", String.Format("javascript:alert('{0}');", ccALERTA_BLOQUEO_CARTERA_USUARIO))
            End If
        End Sub

        Private Sub dgrdMntUsuPorAsignar_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMntUsuPorAsignar.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"
            End If
        End Sub

        Private Sub dgrdMntUsuSubordinado_ItemDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMntUsuSubordinado.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"
            End If
        End Sub

        Private Function filtrarRegs(ByVal pdtOrigen As DataTable, ByVal pstrFilter As String, ByVal pstrSort As String) As DataTable
            Dim drRegs As DataRow()
            Dim dtSentencia As DataTable
            dtSentencia = pdtOrigen.Clone()
            drRegs = pdtOrigen.Select(pstrFilter, pstrSort)
            For Each dr As DataRow In drRegs
                dtSentencia.ImportRow(dr)
            Next
            Return (dtSentencia)
        End Function

        Private Sub agregarUsuario()
            Try
                If Page.IsValid Then
                    Dim obeUsuario As BusinessEntity.Usuario = New BusinessEntity.Usuario

                    obeUsuario.CodUsuario = txtCodUsuario.Text
                    obeUsuario.Nombre = txtNombre.Text
                    obeUsuario.Email = txtEmail.Text
                    obeUsuario.CodPerfil = Short.Parse(dropPerfil.SelectedValue)
                    obeUsuario.Estado = Byte.Parse(dropEstado.SelectedValue)
                    If obeUsuario.CodPerfil = ecPerfil.ANALISTA_RIESGO Then
                        obeUsuario.Supervisor = chkSupervisor.Checked
                    Else
                        obeUsuario.Supervisor = 0
                    End If

                    Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                    Dim bolRC As Boolean = obrUsuario.agregar(obeUsuario)
                    If bolRC Then
                        txtFecReg.Text = obeUsuario.FecReg()
                        configMntAccion(ecMntPage.MODIFICAR)
                        bloquearControles(True)
                        cargarCarteraUsuario(obeUsuario)
                        Me.muestraAlerta(ccALERTA_EXITO_AGREGAR & " de " & ccID_WEBUI_MNT)
                    Else
                        Me.muestraAlerta(ccALERTA_ERROR_AGREGAR_USUARIO)
                    End If

                    If obeUsuario.CodPerfil = ecPerfil.ANALISTA_RIESGO Then
                        divSupervisor.Attributes.Add("style", "display:''")
                    Else
                        divSupervisor.Attributes.Add("style", "display:'none'")
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Sub modificarUsuario()
            Try
                If Page.IsValid Then
                    Dim obeUsuario As BusinessEntity.Usuario = New BusinessEntity.Usuario

                    obeUsuario.CodUsuario = txtCodUsuario.Text
                    obeUsuario.Nombre = txtNombre.Text
                    obeUsuario.Email = txtEmail.Text
                    obeUsuario.CodPerfil = Short.Parse(dropPerfil.SelectedValue)
                    obeUsuario.Estado = Byte.Parse(dropEstado.SelectedValue)
                    If obeUsuario.CodPerfil = ecPerfil.ANALISTA_RIESGO Then
                        obeUsuario.Supervisor = chkSupervisor.Checked
                    Else
                        obeUsuario.Supervisor = 0
                    End If

                    Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                    Dim bolRC As Boolean = obrUsuario.modificar(obeUsuario)
                    If bolRC Then
                        configMntAccion(ecMntPage.MODIFICAR)
                        cargarCarteraUsuario(obeUsuario)
                        Me.muestraAlerta(ccALERTA_EXITO_MODIFICAR & " de " & ccID_WEBUI_MNT)
                    Else
                        Me.muestraAlerta(ccALERTA_ERROR_MODIFICAR & " de " & ccID_WEBUI_MNT)
                    End If

                    If obeUsuario.CodPerfil = ecPerfil.ANALISTA_RIESGO Then
                        divSupervisor.Attributes.Add("style", "display:''")
                    Else
                        divSupervisor.Attributes.Add("style", "display:'none'")
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_MODIFICAR & " de " & ccID_WEBUI_MNT)
            End Try
        End Sub

        Private Sub inicializarControles()
            txtCodUsuario.Text = String.Empty
            txtNombre.Text = String.Empty
            txtEmail.Text = String.Empty
            txtFecReg.Text = String.Empty
            If dropPerfil.Items.Count > 0 Then dropPerfil.SelectedIndex = 0
            If dropEstado.Items.Count > 0 Then dropEstado.SelectedIndex = 0

            Dim obeParametro As BusinessEntity.Parametro = buscarParametro("USU_COD_PERFIL")
            dropPerfil.SelectedValue = obeParametro.Valor1

            obeParametro = buscarparametro("USU_COD_ESTADO")
            dropEstado.SelectedValue = obeParametro.Valor1

            dgrdMntUsuPorAsignar.DataSource = New DataTable
            dgrdMntUsuPorAsignar.DataKeyField = "CodUsuario"
            dgrdMntUsuPorAsignar.DataBind()

            dgrdMntUsuSubordinado.DataSource = New DataTable
            dgrdMntUsuSubordinado.DataKeyField = "CodUsuario"
            dgrdMntUsuSubordinado.DataBind()

            lblNumUsuCartera.Text = 0

            MntAccion = Int32.Parse(ecMntPage.AGREGAR)

            bloquearControles(False)

            configMntAccion(ecMntPage.AGREGAR)
        End Sub

        Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
            If MntAccion = Int32.Parse(ecMntPage.AGREGAR) Or (txtCodUsuario.Text.Trim = String.Empty) Then
                agregarUsuario()
            ElseIf MntAccion = Int32.Parse(ecMntPage.MODIFICAR) Or (txtCodUsuario.Text.Trim <> String.Empty) Then
                modificarUsuario()
            End If
        End Sub

        Private Sub btnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuevo.Click
            inicializarControles()
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            Dim strUrl As String = "busUsuario.aspx"
            Response.Redirect(strUrl)
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub

        Private Sub btnAsignarCartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarCartera.Click
            Try
                Dim obeUsuario As BusinessEntity.Usuario = New BusinessEntity.Usuario
                Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                obeUsuario.CodUsuario = txtCodUsuario.Text
                obeUsuario.CodPerfil = Short.Parse(dropPerfil.SelectedValue)

                For Each dgrdItem As DataGridItem In dgrdMntUsuPorAsignar.Items
                    Dim chkItem As CheckBox = CType(dgrdItem.FindControl("chkItem"), CheckBox)
                    If chkItem.Checked Then
                        Dim obeCarteraUsuario As BusinessEntity.CarteraUsuario = New BusinessEntity.CarteraUsuario
                        obeCarteraUsuario.CodUsuarioResponsable = obeUsuario.CodUsuario
                        obeCarteraUsuario.CodUsuarioSubordinado = dgrdMntUsuPorAsignar.DataKeys(dgrdItem.ItemIndex)
                        obeUsuario.CarteraUsuarios.Add(obeCarteraUsuario)
                    End If
                Next
                Dim dsNoAsignados As DataSet = obrUsuario.agregarCarteraUsuario(obeUsuario)

                Me.hidNoAsignados.Value = 0
                If Not dsNoAsignados Is Nothing Then
                    If dsNoAsignados.Tables(0).Rows.Count > 0 Then
                        dgrdMntNoAsignados.DataSource = dsNoAsignados
                        dgrdMntNoAsignados.DataBind()
                        Me.hidNoAsignados.Value = 1
                    End If
                End If

                'Dim bolRC As Boolean = obiUsuario.agregarCarteraUsuario(obeUsuario)
                Dim bolRC As Boolean = True
                If bolRC Then
                    cargarCarteraUsuario(obeUsuario)
                Else
                    Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT_CARTERAUSUARIO)
                End If

                UpdatePanel1.UpdateAfterCallBack = True
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_AGREGAR & " de " & ccID_WEBUI_MNT_CARTERAUSUARIO)
            End Try
        End Sub

        Private Sub btnExcluirCartera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcluirCartera.Click
            Try
                Dim obeUsuario As BusinessEntity.Usuario = New BusinessEntity.Usuario
                Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                obeUsuario.CodUsuario = txtCodUsuario.Text
                obeUsuario.CodPerfil = Short.Parse(dropPerfil.SelectedValue)

                For Each dgrdItem As DataGridItem In dgrdMntUsuSubordinado.Items
                    Dim chkItem As CheckBox = CType(dgrdItem.FindControl("chkItem"), CheckBox)
                    If chkItem.Checked Then
                        Dim obeCarteraUsuario As BusinessEntity.CarteraUsuario = New BusinessEntity.CarteraUsuario
                        obeCarteraUsuario.CodUsuarioResponsable = obeUsuario.CodUsuario
                        obeCarteraUsuario.CodUsuarioSubordinado = dgrdMntUsuSubordinado.DataKeys(dgrdItem.ItemIndex)
                        obeUsuario.CarteraUsuarios.Add(obeCarteraUsuario)
                    End If
                Next

                Dim bolRC As Boolean = obrUsuario.eliminarCarteraUsuario(obeUsuario)
                If bolRC Then
                    cargarCarteraUsuario(obeUsuario)
                Else
                    Me.muestraAlerta(ccALERTA_ERROR_ELIMINAR & " de " & ccID_WEBUI_MNT_CARTERAUSUARIO)
                End If

                UpdatePanel1.UpdateAfterCallBack = True
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_ELIMINAR & " de " & ccID_WEBUI_MNT_CARTERAUSUARIO)
            End Try
        End Sub
    End Class

End Namespace