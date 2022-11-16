'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Reflection

Namespace CEF.WebUI

    Partial Class busUsuario
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
            imgImprimir.Attributes.Add("onClick", "javascript:window.print();")
            lnkImprimir.Attributes.Add("href", "javascript:window.print();")

            'Añadir atributo readonly a textbox
            txtNomUsuarioLogin.Attributes.Add("readonly", "readonly")
        End Sub

        Private Sub cargarDatos()
            lblNumReg.Text = 0
            MntAccion = Int32.Parse(ecMntPage.NOACCION)
            'SRT_2017-02160
            'Dim strCodUsuario As String = DatosGlobal.sUser

            'Dim obeUsuario As BusinessEntity.Usuario
            'Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

            'Dim obePerfil As BusinessEntity.Perfil
            'Dim obrPerfil As BusinessRules.Perfil = New BusinessRules.Perfil

            'obeUsuario = obrUsuario.leer(strCodUsuario)

            'If Not obeUsuario Is Nothing Then
            '    obePerfil = obrPerfil.leer(obeUsuario.CodPerfil)
            '    ltlPerfilUsuarioLogin.Text = obePerfil.Nombre
            '    txtNomUsuarioLogin.Text = obeUsuario.Nombre
            'End If

            ltlPerfilUsuarioLogin.Text = retornaNombrePerfilSesion()
            txtNomUsuarioLogin.Text = retornaNombreUsuarioSesion()

            Dim obrPerfil As BusinessRules.Perfil = New BusinessRules.Perfil

            dropPerfil.DataSource = obrPerfil.listar(1, 0)
            dropPerfil.DataTextField = "Nombre"
            dropPerfil.DataValueField = "CodPerfil"
            dropPerfil.DataBind()
            dropPerfil.Items.Insert(0, New ListItem("Seleccione Perfil ...", ""))

            dropEstado.DataSource = buscarGeneralTabla(ecTablaGeneral.ESTADO_USUARIO)
            dropEstado.DataTextField = "Descripcion"
            dropEstado.DataValueField = "CodItem"
            dropEstado.DataBind()
            dropEstado.Items.Insert(0, New ListItem("Seleccione Estado ...", ""))

            obrPerfil = Nothing
        End Sub

        Private Sub inicializarControles()
            txtCodUsuario.Text = String.Empty
            txtNombre.Text = String.Empty
            If dropPerfil.Items.Count > 0 Then dropPerfil.SelectedIndex = 0
            If dropEstado.Items.Count > 0 Then dropEstado.SelectedIndex = 0

            dgrdMnt.DataSource = New DataTable
            dgrdMnt.DataKeyField = "CodUsuario"
            dgrdMnt.DataBind()
            lblNumReg.Text = 0
        End Sub

        Private Sub buscar()
            Try
                Dim obeUsuario As BusinessEntity.Usuario = New BusinessEntity.Usuario
                Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                obeUsuario.CodUsuario = txtCodUsuario.Text
                obeUsuario.Nombre = txtNombre.Text
                If dropPerfil.SelectedIndex > 0 Then obeUsuario.CodPerfil = Short.Parse(dropPerfil.SelectedValue)
                If dropEstado.SelectedIndex > 0 Then obeUsuario.Estado = Byte.Parse(dropEstado.SelectedValue)

                Dim dsUsuario As DataSet
                dsUsuario = obrUsuario.buscar(obeUsuario)

                If dsUsuario Is Nothing Then
                    dgrdMnt.DataSource = New DataTable
                    dgrdMnt.DataKeyField = "CodUsuario"
                    dgrdMnt.DataBind()
                    Me.muestraAlerta(ccALERTA_ERROR_BUSCAR)
                    lblNumReg.Text = 0
                Else
                    dgrdMnt.DataSource = dsUsuario
                    dgrdMnt.DataKeyField = "CodUsuario"
                    dgrdMnt.DataBind()
                    Dim intNumReg As Integer = dsUsuario.Tables(0).Rows.Count
                    lblNumReg.Text = intNumReg
                    If intNumReg <= 0 Then Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR)
            End Try
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item) Or (e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"

                Dim ibtnEliminar As ImageButton = CType(e.Item.FindControl("ibtnEliminar"), ImageButton)
                ibtnEliminar.Attributes("onclick") = "javascript:return confirm('" & Globals.ccALERTA_ELIMINAR & "');"
            End If
        End Sub

        Private Sub dgrdMnt_ItemCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.ItemCommand
            If (e.CommandName = "Editar") Then
                Dim strCodUsuario As String = dgrdMnt.DataKeys(e.Item.ItemIndex)
                Dim strUrl As String = String.Format("mntUsuario.aspx?strCodUsuario={0}&intMntAccion={1}", strCodUsuario, Int32.Parse(ecMntPage.MODIFICAR))
                Response.Redirect(strUrl)
            End If
        End Sub

        Private Sub dgrdMnt_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles dgrdMnt.DeleteCommand
            Dim strCodUsuario As String = CType(dgrdMnt.DataKeys(e.Item.ItemIndex), String)
            Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

            Dim voRC As Boolean = obrUsuario.eliminar(strCodUsuario)
            If voRC Then
                dgrdMnt.EditItemIndex = -1
                buscar()
            End If
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            dgrdMnt.CurrentPageIndex = 0
            buscar()
        End Sub

        Private Sub imgNuevo_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgNuevo.Click
            ingresarUsuario()
        End Sub

        Private Sub lnkNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lnkNuevo.Click
            ingresarUsuario()
        End Sub

        Private Sub btnInicializar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInicializar.Click
            inicializarControles()
        End Sub

        Private Sub ingresarUsuario()
            Dim strUrl As String = String.Format("mntUsuario.aspx?intMntAccion={0}", Int32.Parse(ecMntPage.AGREGAR))
            Response.Redirect(strUrl)
        End Sub

        Private Sub dgrdMnt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            dgrdMnt.CurrentPageIndex = e.NewPageIndex
            dgrdMnt.EditItemIndex = -1
            buscar()
        End Sub

        Private Sub imgCerrar_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgCerrar.Click
            Me.cargarPaginaPortal()
        End Sub
    End Class

End Namespace
