'*************************************************************
'Proposito: Exportar a Excel el Archivo Suvace - Informe SBS
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 08/09/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Text
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals

Namespace CEF.WebUI

    Partial Class rvwExpInformeSBS
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
            '        cargarDatos()
            '    End If
            'End If
            If PageBase.PostbackSession(Me) Then
                If Not Page.IsPostBack Then
                    cargarDatos()
                End If
            End If
        End Sub

        Private Sub cargarDatos()
            cargarDatosFiltroSucave()
        End Sub

        Private Sub cargarDatosFiltroSucave()
            Dim dteFecPeriodo As DateTime = DateTime.Parse(Request.Params("dteFecPeriodo"))

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            Dim dsMetodizado As DataSet = obrMetodizado.generarInformeSBS(dteFecPeriodo)

            If Not dsMetodizado Is Nothing Then

                dgrdMnt.DataSource = dsMetodizado
                dgrdMnt.DataBind()
                Dim strTitulo As String = "INFORME SBS"
                Dim arrCriterio(0, 1) As String
                arrCriterio(0, 0) = "Periodo"
                arrCriterio(0, 1) = dteFecPeriodo.ToShortDateString + " (Expresado en MILES de SOLES)"

                Util.exportarExcel(dgrdMnt, strTitulo, arrCriterio)
            End If
        End Sub

        Private Sub dgrdMnt_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs) Handles dgrdMnt.ItemDataBound
            Select Case e.Item.ItemType
                Case ListItemType.AlternatingItem, ListItemType.Item
                    'e.Item.Cells(0).Text = "'" & e.Item.Cells(0).Text.ToString
                    'e.Item.Cells(2).Text = "'" & e.Item.Cells(2).Text.ToString
                    'e.Item.Cells(4).Text = "'" & e.Item.Cells(4).Text.ToString
                    e.Item.Cells(0).Attributes.Add("style", "mso-number-format:\@")
                    e.Item.Cells(2).Attributes.Add("style", "mso-number-format:\@")
                    e.Item.Cells(3).Attributes.Add("style", "mso-number-format:\@")
                    e.Item.Cells(4).Attributes.Add("style", "mso-number-format:\@")
            End Select
        End Sub
    End Class

End Namespace