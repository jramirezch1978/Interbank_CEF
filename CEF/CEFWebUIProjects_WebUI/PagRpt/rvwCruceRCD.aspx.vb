Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CEF.Common
Imports CEF.Common.Globals
'Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class rvwCruceRCD
        Inherits System.Web.UI.Page

        Dim crReportDocument As repCruceRCD
        Private nombreReporte As String = "Reporte"

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
            MostrarReporte()
            Exportar(4) '4 Excel    5 PDF
        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página
        End Sub

        Private Sub MostrarReporte()
            Dim dteFecPeriodo As String = Request.Params("dteFecPeriodo")
            Dim obrRCD As BusinessRules.RCD = New BusinessRules.RCD
            Dim dsRCD As DataSet = obrRCD.cruceEEFFValidados(dteFecPeriodo)
            dsRCD.Tables(0).TableName = "EEFFValidacion"
            dsRCD.Tables(1).TableName = "EEFFPendientesValidacion"

            If Not dsRCD Is Nothing Then
                If dsRCD.Tables(0).Rows.Count > 0 Then
                    crReportDocument = New repCruceRCD

                    Dim subreport As New ReportDocument
                    crReportDocument.Subreports.Item(0).SetDataSource(dsRCD)
                    subreport = crReportDocument.OpenSubreport(0)
                    CrystalReportViewer1.ReportSource = subreport

                    crReportDocument.Subreports.Item(1).SetDataSource(dsRCD)
                    subreport = crReportDocument.OpenSubreport(1)
                    CrystalReportViewer1.ReportSource = subreport

                End If
            End If

        End Sub

        Private Sub Exportar(ByVal intTipoFormato As Integer)
            'Se crea el documento de lectura y escritura
            Dim rptStream As New System.IO.MemoryStream

            Try
                Response.Buffer = True

                'se envia el reporte el stram y le indicamos el metodo de escritura o tipo de documento
                rptStream = CType(crReportDocument.ExportToStream(CInt(intTipoFormato)), System.IO.MemoryStream)

                'Limpiamos la memoria
                Response.Clear()

                'Le indicamos el tipo de documento que vamos a exportar
                Response.ContentType = FormatoDocumento(intTipoFormato)

                'Automaticamente se descarga el archivo
                Response.AddHeader("Content-Disposition", "attachment;filename=" + Me.nombreReporte)

                'Se escribe el archivo
                Response.BinaryWrite(rptStream.ToArray())
                Response.End()
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
        End Sub

        'Indicamos el Tipo de archivo que vamos a exportar,
        'tambien le indicamos la extension
        Private Function FormatoDocumento(ByVal intTipoFormato As Integer) As String
            Dim tipo As String
            Select Case Integer.Parse(intTipoFormato)
                Case ExportFormatType.Excel
                    tipo = "application/vnd.ms-excel"
                    nombreReporte &= ".xls"
                Case ExportFormatType.PortableDocFormat
                    tipo = "application/pdf"
                    nombreReporte &= ".pdf"
            End Select
            Return tipo
        End Function

    End Class

End Namespace