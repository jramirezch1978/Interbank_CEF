Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules

Namespace CEF.WebUI
    Partial Class rvwEmpresasPorCIIU
        Inherits System.Web.UI.Page

        Dim crReportDocument As repEmpresasPorCIIU
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

            Exportar(5) '4 Excel    5 PDF


        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'Introducir aquí el código de usuario para inicializar la página

        End Sub

        Private Sub MostrarReporte()
            Dim strCodCIIU As String = Request.Params("strCodCIIU")
            Dim dteFecPeriodo As DateTime = CType(Request.Params("dteFecPeriodo"), DateTime)

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            Dim dsMetodizado As DataSet = obrMetodizado.filtrarRankingEmpresa( _
            ecReporte.RankingEmpresasporCIIU, strCodCIIU, "", dteFecPeriodo)
            crReportDocument = New repEmpresasPorCIIU
            If dsMetodizado.Tables.Count > 0 Then

                Dim obeCIIU As BusinessEntity.CIIU
                Dim obrCIIU As BusinessRules.CIIU = New BusinessRules.CIIU

                obeCIIU = obrCIIU.leer(strCodCIIU)

                Dim strNombreCIIU As String
                If Not obeCIIU Is Nothing Then
                    strNombreCIIU = obeCIIU.Nombre
                End If

                crReportDocument.SetDataSource(dsMetodizado)
                CrystalReportViewer1.ReportSource = crReportDocument

                Dim i As Integer
                Dim objText As CrystalDecisions.CrystalReports.Engine.TextObject
                For i = 0 To crReportDocument.ReportDefinition.ReportObjects.Count - 1
                    If TypeOf (crReportDocument.ReportDefinition.ReportObjects.Item(i)) Is _
                        CrystalDecisions.CrystalReports.Engine.TextObject Then
                        objText = crReportDocument.ReportDefinition.ReportObjects.Item(i)
                        If objText.Name = "txtCIIU" Then
                            objText.Text = objText.Text & " " & strCodCIIU & " - " & strNombreCIIU
                        End If
                        If objText.Name = "txtPeriodo" Then
                            objText.Text = objText.Text & " " & dteFecPeriodo.ToShortDateString
                        End If
                    End If
                Next

            End If
        End Sub

        Private Sub Exportar(ByVal intTipoFormato As Integer)
            'Se crea el documento de lectura y escritura
            Dim rptStream As New System.IO.MemoryStream
            'se envia el reporte el stram y le indicamos el metodo de escritura o tipo de documento
            rptStream = CType(crReportDocument.ExportToStream(CInt(intTipoFormato)), System.IO.MemoryStream)

            'Limpiamos la memoria
            Response.Clear()
            Response.Buffer = True

            'Le indicamos el tipo de documento que vamos a exportar
            Response.ContentType = FormatoDocumento(intTipoFormato)

            'Automaticamente se descarga el archivo
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Me.nombreReporte)

            'Se escribe el archivo
            Response.BinaryWrite(rptStream.ToArray())
            Response.End()
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
