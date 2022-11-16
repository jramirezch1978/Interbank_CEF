'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports CEF.BusinessEntity


Namespace CEF.WebUI

    Partial Class busBase
        Inherits PageBase

        Private lstrCampoCodigo As String
        Private lstrCampoDescripcion As String
        Private lstrTitulo As String
        Private lstrCodigo As String
        Private lstrDescripcion As String
        Private ldsResultado As DataSet

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

        Protected Property CampoCodigo() As String
            Get
                Return (lstrCampoCodigo)
            End Get
            Set(ByVal Value As String)
                lstrCampoCodigo = Value
            End Set
        End Property

        Protected Property CampoDescripcion() As String
            Get
                Return (lstrCampoDescripcion)
            End Get
            Set(ByVal Value As String)
                lstrCampoDescripcion = Value
            End Set
        End Property

        Protected Property Titulo() As String
            Get
                Return (lstrTitulo)
            End Get
            Set(ByVal Value As String)
                lstrTitulo = Value
            End Set
        End Property

        Protected Property Codigo() As String
            Get
                Return (lstrCodigo)
            End Get
            Set(ByVal Value As String)
                lstrCodigo = Value
            End Set
        End Property

        Protected Property Descripcion() As String
            Get
                Return (lstrDescripcion)
            End Get
            Set(ByVal Value As String)
                lstrDescripcion = Value
            End Set
        End Property

        Protected Property Resultado() As DataSet
            Get
                Return (ldsResultado)
            End Get
            Set(ByVal Value As DataSet)
                ldsResultado = Value
            End Set
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'SRT_2017-02160
            'If verificaConneccion() Then
            '    If Not Page.IsPostBack Then
            '        cargarScript()
            '        inicializarControles()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargarScript()
                    inicializarControles()
                End If
            End If
        End Sub

        Protected Overridable Sub cargarScript()
            txtCodigo.Attributes.Add("onkeypress", "javascript:txtDescripcion.value=''; if (event.keyCode < 48 || event.keyCode > 57) event.returnValue = false;")
            txtDescripcion.Attributes.Add("onkeypress", "javascript:txtCodigo.value='';")
            imgImprimir.Attributes.Add("onClick", "javascript:window.print();")
            lnkImprimir.Attributes.Add("url", "javascript:window.print();")
            imgCerrar.Attributes("onclick") = "javascript:window.close();"
        End Sub

        Protected Overridable Sub inicializarControles()
            lblTitulo.Text = lstrTitulo
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            If (e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem) Then
                e.Item.Attributes("onmouseover") = "this.className='Selector'"
                e.Item.Attributes("onmouseout") = "this.className='Registro'"
                e.Item.Attributes("onclick") = "f_RetornaCliente('" & DataBinder.Eval(e.Item.DataItem, Me.lstrCampoCodigo) & "','" & DataBinder.Eval(e.Item.DataItem, Me.lstrCampoDescripcion) & "');"
            End If
        End Sub

        Private Sub dgrdMnt_PageIndexChanged(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) Handles dgrdMnt.PageIndexChanged
            dgrdMnt.CurrentPageIndex = e.NewPageIndex
            dgrdMnt.DataBind()
            actualizarCriterios()
            buscar()
            cargarResultado()
        End Sub

        Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
            dgrdMnt.CurrentPageIndex = 0
            actualizarCriterios()
            buscar()
            cargarResultado()
        End Sub

        Private Sub actualizarCriterios()
            Me.Codigo = UCase(txtCodigo.Text)
            Me.Descripcion = UCase(txtDescripcion.Text)
        End Sub

        Protected Overridable Sub buscar()
            'Sobreescribir este metodo en las clases hijas
        End Sub

        Private Sub cargarResultado()
            If Not IsNothing(Me.Resultado) Then
                dgrdMnt.DataSource = Me.Resultado
                dgrdMnt.DataKeyField = Me.CampoCodigo
                CType(dgrdMnt.Columns(0), BoundColumn).DataField = Me.CampoCodigo
                CType(dgrdMnt.Columns(1), BoundColumn).DataField = Me.CampoDescripcion
                dgrdMnt.DataBind()
                Dim intNumReg As Integer = Me.Resultado.Tables(0).Rows.Count
                lblNumReg.Text = intNumReg.ToString()
                If intNumReg <= 0 Then Me.muestraAlerta(ccALERTA_BUSQUEDA_RESULTADO_CERO)
            Else
                dgrdMnt.DataSource = New DataTable
                dgrdMnt.DataBind()
                lblNumReg.Text = "0"
                Me.muestraAlerta(ccALERTA_ERROR_BUSCAR)
            End If
        End Sub

    End Class

End Namespace