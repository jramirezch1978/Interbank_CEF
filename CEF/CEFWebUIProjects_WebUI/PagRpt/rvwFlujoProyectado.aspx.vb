Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class rvwFlujoProyectado
        Inherits PageBase

        Dim crReportDocument As repFlujoProyectado
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
            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
            Dim intCodPeriodo As String = Int32.Parse(Request.Params("intCodPeriodo"))
            Dim intCodSupuesto As Integer = Int32.Parse(Request.Params("intCodSupuesto"))
            Dim intCodPeriodoAnterior As Integer = Int32.Parse(Request.Params("intCodPeriodoAnterior"))

            Try
                Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
                Dim dsFlujoProyectado As DataSet = obrMetodizado.calcularFlujoProyectado(intCodSupuesto)
                dsFlujoProyectado.Tables(0).TableName = "FlujoProyectadoCabecera"
                dsFlujoProyectado.Tables(1).TableName = "FlujoProyectadoSupuesto"

                If Not dsFlujoProyectado Is Nothing Then
                    If dsFlujoProyectado.Tables(1).Rows.Count > 0 Then
                        crReportDocument = New repFlujoProyectado
                        Dim SQL As String
                        Dim subreport As New ReportDocument

                        'MUESTRA INGRESO DE SUPUESTOS (0)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 10"
                        crReportDocument.Subreports.Item(3).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(3).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(3)
                        CrystalReportViewer1.ReportSource = subreport

                        '(1)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 11"
                        crReportDocument.Subreports.Item(4).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(4).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(4)
                        CrystalReportViewer1.ReportSource = subreport

                        '(2)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 12"
                        crReportDocument.Subreports.Item(5).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(5).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(5)
                        CrystalReportViewer1.ReportSource = subreport

                        '(3)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 13 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodTipoCuenta}=3"
                        crReportDocument.Subreports.Item(6).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(6).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(6)
                        CrystalReportViewer1.ReportSource = subreport

                        '(4)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 14"
                        crReportDocument.Subreports.Item(7).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(7).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(7)
                        CrystalReportViewer1.ReportSource = subreport

                        '(5)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 15"
                        crReportDocument.Subreports.Item(8).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(8).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(8)
                        CrystalReportViewer1.ReportSource = subreport

                        '(6)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 16"
                        crReportDocument.Subreports.Item(9).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(9).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(9)
                        CrystalReportViewer1.ReportSource = subreport

                        '(7)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 17"
                        crReportDocument.Subreports.Item(10).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(10).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(10)
                        CrystalReportViewer1.ReportSource = subreport

                        '(8)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 5 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 18"
                        crReportDocument.Subreports.Item(11).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(11).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(11)
                        CrystalReportViewer1.ReportSource = subreport

                        'BALANCE GENERAL (9)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 1"
                        crReportDocument.Subreports.Item(0).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(0).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(0)
                        CrystalReportViewer1.ReportSource = subreport

                        'ESTADO DE GANANCIAS Y PERDIDAS (10)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 2"
                        crReportDocument.Subreports.Item(2).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(2).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(2)
                        CrystalReportViewer1.ReportSource = subreport

                        'RECONCILIACION PATRIMONIO Y ACTIVO FIJO (11)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 3"
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}>=411 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}<=421"
                        crReportDocument.Subreports.Item(18).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(18).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(18)
                        CrystalReportViewer1.ReportSource = subreport

                        'FUENTES Y USOS DE FONDOS (12)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 7"
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}>=425 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}<=468"
                        crReportDocument.Subreports.Item(1).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(1).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(1)
                        CrystalReportViewer1.ReportSource = subreport

                        'FLUJO DE FONDOS (13)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 8 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}>=469 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}<=471"
                        crReportDocument.Subreports.Item(12).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(12).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(12)
                        CrystalReportViewer1.ReportSource = subreport

                        'FLUJO DE FONDOS (14)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 8 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}>=472 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}<=476"
                        crReportDocument.Subreports.Item(14).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(14).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(14)
                        CrystalReportViewer1.ReportSource = subreport

                        'RATIOS FINANCIEROS (15)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 9 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}>=478 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}<=481"
                        crReportDocument.Subreports.Item(13).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(13).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(13)
                        CrystalReportViewer1.ReportSource = subreport

                        'RATIOS FINANCIEROS (16)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 9 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}>=482 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}<=490"
                        crReportDocument.Subreports.Item(15).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(15).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(15)
                        CrystalReportViewer1.ReportSource = subreport

                        'RATIOS FINANCIEROS (17)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 9 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}>=491 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}<=495"
                        crReportDocument.Subreports.Item(16).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(16).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(16)
                        CrystalReportViewer1.ReportSource = subreport

                        'RATIOS FINANCIEROS (18)
                        SQL = "{FlujoProyectadoSupuesto.CodAnalisis} = 6 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodEeff} = 9 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}>=496 "
                        SQL &= "AND {FlujoProyectadoSupuesto.CodCuentaSupuesto}<=497"
                        crReportDocument.Subreports.Item(17).RecordSelectionFormula = SQL
                        crReportDocument.Subreports.Item(17).SetDataSource(dsFlujoProyectado)
                        subreport = crReportDocument.OpenSubreport(17)
                        CrystalReportViewer1.ReportSource = subreport
                    Else
                        Response.Write("<script language='javascript'>alert('No se pudieron recuperar los datos, por favor intentar nuevamente'); </script>")
                    End If
                Else
                    Response.Write("<script language='javascript'>alert('No se pudieron recuperar los datos, por favor intentar nuevamente'); </script>")
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
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
