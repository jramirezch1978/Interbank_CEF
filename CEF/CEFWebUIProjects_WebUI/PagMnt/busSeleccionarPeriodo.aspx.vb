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

Namespace CEF.WebUI

    Partial Class busSeleccionarPeriodo
        Inherits PageBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents hidPeriodo As System.Web.UI.HtmlControls.HtmlInputHidden
        Protected WithEvents btnAceptar2 As System.Web.UI.WebControls.Button

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
            imgCerrar.Attributes("onclick") = "javascript:{window.returnValue=null; window.close();}"

            'Añadir atributo readonly a textbox
            txtRazonSocial.Attributes.Add("readonly", "readonly")
        End Sub

        Private Sub cargarDatos()
            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))

            Dim obeMetodizado As BusinessEntity.Metodizado
            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            obeMetodizado = obrMetodizado.leer(intCodMetodizado)

            If Not obeMetodizado Is Nothing Then
                txtRazonSocial.Text = obeMetodizado.RazonSocial

                'Dim obePeriodoLst As BusinessEntity.PeriodoLst
                'obePeriodoLst = obiMetodizado.listarPeriodo(intCodMetodizado)

                'dgrdMnt.DataSource = obePeriodoLst
                Dim dsPeriodos As DataSet = obrMetodizado.listarPeriodo_ds(intCodMetodizado)
                dgrdMnt.DataSource = dsPeriodos
                dgrdMnt.DataKeyField = "CodPeriodo"
                dgrdMnt.DataBind()

                'lblNumReg.Text = obePeriodoLst.Count.ToString()
                lblNumReg.Text = dsPeriodos.Tables(0).Rows.Count
            End If
            obrMetodizado = Nothing
        End Sub

    End Class

End Namespace