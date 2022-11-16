'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 22/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals

Namespace CEF.WebUI

    Partial Class LeePeriodo
        Inherits System.Web.UI.UserControl

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

        Private lPeriodo As BusinessEntity.Periodo

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'inicializarControles()
        End Sub

        Public Property Periodo() As BusinessEntity.Periodo
            Get
                Return Me.lPeriodo
            End Get
            Set(ByVal Value As BusinessEntity.Periodo)
                Me.lPeriodo = Value
            End Set
        End Property

        Private Sub inicializarControles()
            Dim obeTipoEeff As BusinessEntity.TipoEEFF
            Dim obrTipoEeff As BusinessRules.TipoEEFF = New BusinessRules.TipoEEFF

            obeTipoEeff = obrTipoEeff.leer(Me.lPeriodo.CodTipoEeff)
            ltlDesTipoEeff.Text = obeTipoEeff.Descripcion
            obrTipoEeff = Nothing

            ltlFecPeriodo.Text = Me.lPeriodo.FecPeriodo.ToShortDateString
            ltlFecPeriodo.Text += "<br>(" + Me.lPeriodo.Mes.ToString() + ")"

            Dim obrAuditor As BusinessRules.Auditor = New BusinessRules.Auditor
            Dim obeAuditor As BusinessEntity.Auditor
            obeAuditor = obrAuditor.leer(Me.lPeriodo.CodAuditor)
            If Not obeAuditor Is Nothing Then
                ltlRazonSocial.Text = obeAuditor.RazonSocial
            End If
            obrAuditor = Nothing

            ltlNombreUsuario.Text = Me.lPeriodo.NombreUsuario
            imgComentario.ToolTip = Me.lPeriodo.Comentario

            imgEditar.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMnt('mntPeriodoCuenta.aspx?intCodMetodizado={0}&intCodPeriodo={1}&intMntAccion={2}',{3},{4},{5});", Me.lPeriodo.CodMetodizado, Me.lPeriodo.CodPeriodo, Int32.Parse(ecMntPage.MODIFICAR), 535, 320, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
            imgSupuesto.Attributes.Add("onclick", String.Format("javascript:f_AbrirPagMntSupuesto('mntSupuesto.aspx?intCodMetodizado={0}&intCodPeriodo={1}&intCodTipoSupuesto={2}',{3},{4},{5});", Me.lPeriodo.CodMetodizado, Me.lPeriodo.CodPeriodo, Int32.Parse(ecTipoSupuesto.OPTIMISTA), 790, 550, Int32.Parse(ecTabMntMetodizado.RECONCILIACION)))
            ibtnEliminar.Attributes.Add("onclick", "javascript:return confirm('" & ccALERTA_ELIMINAR & "');")

            Me.imgComentario.AlternateText = CType(Periodo.Estado, String)

            If Periodo.Estado = ecEstadoPeriodo.VALIDADO Then
                Me.imgComentario.ImageUrl = "../Imagen/iconos/icon_Misc_OK.JPG"
                Me.imgComentario.ToolTip = "Estado: Validado"
            Else
                Me.imgComentario.ImageUrl = "../Imagen/iconos/icon_Misc_Error.JPG"
                Me.imgComentario.ToolTip = "Estado: Pendiente"
            End If
        End Sub

        Protected Overrides Sub CreateChildControls()
            inicializarControles()
        End Sub
    End Class

End Namespace