Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CEF
Imports CEF.Common
Imports CEF.Common.Util
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Text
Imports System.Reflection



Namespace CEF.WebUI
    Partial Class rvwResumenEjecutivo
        Inherits PageBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region
        Dim crReportDocument As New repResumenEjecutivo

        Private nombreReporte As String = "Reporte"

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            'MostrarReporte()
            MostrarResumenEjecutivo()
            'MostrarReporte2()
            Exportar(ExportFormatType.PortableDocFormat)
            'Exportar2(ExportFormatType.PortableDocFormat)
        End Sub

        Sub MostrarReporte()

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

            Dim intCodMetodizado As Integer = 3908
            ''Dim xml As String = "<?xml version=" + Chr(34) + "1.0" + Chr(34) + "?><METODIZADO CodMetodizado=" + Chr(34) + "3908" + Chr(34) + "CodAnalista=" + Chr(34) + Chr(34) + "NombreAnalista=" + Chr(34) + Chr(34) + "CodEjecutivo=" + Chr(34) + Chr(34) + "NombreEjecutivo=" + Chr(34) + Chr(34) + "Estado=" + Chr(34) + "0" + Chr(34) + "><PERIODO CodPeriodo=" + Chr(34) + "10" + Chr(34) + " /><PERIODO CodPeriodo=" + Chr(34) + "9" + Chr(34) + " /></METODIZADO>"
            Dim obeMetodizado As CEF.BusinessEntity.Metodizado = New CEF.BusinessEntity.Metodizado
            Dim strPeriodoFiltrado = "9;10"

            Dim obePeriodoLst As PeriodoLst = New BusinessEntity.PeriodoLst
            Dim arrCodPeriodo As String() = strPeriodoFiltrado.Split(";")
            For Each strCodPeriodo As String In arrCodPeriodo
                Dim obePeriodo As BusinessEntity.Periodo = New BusinessEntity.Periodo
                obePeriodo.CodMetodizado = intCodMetodizado
                obePeriodo.CodPeriodo = Int32.Parse(strCodPeriodo)
                obePeriodoLst.Add(obePeriodo)
            Next

            obeMetodizado.CodMetodizado = intCodMetodizado
            obeMetodizado.Periodos = obePeriodoLst

            Dim dsCuentaAnalisisCabecera As DataSet = obrMetodizado.calcularCuentaAnalisisCabecera(intCodMetodizado, obeMetodizado)

            'Dim crReportDocument = New Prueba
            crReportDocument.SetDataSource(dsCuentaAnalisisCabecera)

            'Me.CrystalReportViewer1.ReportSource = crReportDocument
            'Me.CrystalReportViewer1.DataBind()

        End Sub
        Sub MostrarResumenEjecutivo()

            Dim ArgCodPeriodo As String = Request.Params("strcodperiodo").ToString()
            Dim ArgCodMetodizado As Int16 = Convert.ToInt16(Request.Params("intcodmetodizado"))
            Dim ArgCodMoneda As Int16 = Convert.ToInt16(Request.Params("intcodmoneda"))
            Dim CodPeriod As String() = ArgCodPeriodo.Split(";")
            Dim CadenaVolteada As String = String.Empty

            For Each cadena As String In CodPeriod
                CadenaVolteada = cadena + ";" + CadenaVolteada
            Next

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            Dim Periodos As String = ArgCodPeriodo 'CadenaVolteada '"5;7;6;8"
            Dim CodMoneda As Int16 = ArgCodMoneda '2
            Dim CodMetodizado As Int16 = ArgCodMetodizado '7667
            Try
                Dim SQL As String
                Dim subreport As New ReportDocument

                Dim dsResumenEjecutivoDetalles As DataSet = obrMetodizado.generarResumenEjecutivo_Detalles(Periodos, CodMetodizado, CodMoneda)
                dsResumenEjecutivoDetalles.Tables(0).TableName = "Detalle"
                Dim dsResumenEjecutivoCabecera As DataSet = obrMetodizado.generarResumenEjecutivo_Cabecera(Periodos, CodMetodizado, CodMoneda)
                dsResumenEjecutivoCabecera.Tables(0).TableName = "Cabecera"

                If dsResumenEjecutivoDetalles.Tables(0).Rows.Count > 0 Then

                    dsResumenEjecutivoDetalles.Tables.Add(dsResumenEjecutivoCabecera.Tables("Cabecera").Copy)

                    'ESTADO DE GANANCIAS Y PERDIDAS
                    SQL = "{Detalle.CODEEFF} = 1"
                    crReportDocument.Subreports("ESTADO_GANANCIAS_Y_PERDIDAS").RecordSelectionFormula = SQL
                    'crReportDocument.Subreports.Item(0).RecordSelectionFormula = SQL
                    crReportDocument.Subreports.Item(0).SetDataSource(dsResumenEjecutivoDetalles)

                    subreport = crReportDocument.OpenSubreport("ESTADO_GANANCIAS_Y_PERDIDAS")
                    'RATIOS FINANCIEROS
                    SQL = "{Detalle.CODEEFF} = 2"
                    crReportDocument.Subreports("RATIOS_FINANCIEROS").RecordSelectionFormula = SQL
                    'crReportDocument.Subreports.Item(1).RecordSelectionFormula = SQL
                    crReportDocument.Subreports.Item(1).SetDataSource(dsResumenEjecutivoDetalles)

                    subreport = crReportDocument.OpenSubreport("RATIOS_FINANCIEROS")
                    'BALANCE GENERAL
                    SQL = "{Detalle.CODEEFF} = 3"
                    crReportDocument.Subreports("BALANCE_GENERAL").RecordSelectionFormula = SQL
                    'crReportDocument.Subreports.Item(2).RecordSelectionFormula = SQL
                    crReportDocument.Subreports.Item(2).SetDataSource(dsResumenEjecutivoDetalles)

                    subreport = crReportDocument.OpenSubreport("BALANCE_GENERAL")

                Else
                    Response.Write("<script language='javascript'>alert('No se pudieron recuperar los datos, por favor intentar nuevamente'); </script>")
                End If

                'crReportDocument.SetDataSource(dsResumenEjecutivoDetalles)

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta("Error al intentar abrir el reporte, revisar Log")
            End Try

        End Sub
        Private Sub Exportar3(ByVal intTipoFormato As Integer)
            Try

                'Se crea el documento de lectura y escritura
                Dim rptStream As New System.IO.MemoryStream
                Dim rptStream2 As New System.IO.MemoryStream
                Dim pdfdemo As New PdfMerge
                Dim basePath As String = Server.MapPath("~/PagRpt/testPdf")

                'Response.Buffer = True

                'se envia el reporte el stream y le indicamos el metodo de escritura o tipo de documento
                rptStream = CType(crReportDocument.ExportToStream(intTipoFormato), System.IO.MemoryStream)
                
                pdfdemo.AddDocument(rptStream)
                pdfdemo.AddDocument(rptStream2)
                'pdfdemo.AddDocument(Path.Combine(basePath, "composable-memory-transactions.pdf"))
                'pdfdemo.AddDocument(Path.Combine(basePath, "Pruebilla.pdf"))

                'Limpiamos la memoria
                Response.Clear()
                'Le indicamos el tipo de documento que vamos a exportar

                'Response.ContentType = FormatoDocumento(intTipoFormato)
                Response.ContentType = "application/octet-stream"

                'Automaticamente se descarga el archivo
                ''Response.AddHeader("Content-Disposition", "attachment;filename=" + Me.nombreReporte)
                Response.AppendHeader("Content-Disposition", "attachment; filename=mergedPapers.pdf")
                'Se escribe el archivo

                'Response.BinaryWrite(rptStream2.ToArray())
                pdfdemo.Merge(Response.OutputStream)

                Response.End()
                'pCloseWindow()
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
        End Sub
        'Sub MostrarReporte2()
        '    Dim ArgCodPeriodo As String = Request.Params("strcodperiodo").ToString()
        '    Dim ArgCodMetodizado As Int16 = Convert.ToInt16(Request.Params("intcodmetodizado"))
        '    Dim ArgCodMoneda As Int16 = Convert.ToInt16(Request.Params("intcodmoneda"))
        '    Dim CodPeriod As String() = ArgCodPeriodo.Split(";")
        '    Dim CadenaVolteada As String = String.Empty

        '    For Each cadena As String In CodPeriod
        '        CadenaVolteada = cadena + ";" + CadenaVolteada
        '    Next

        '    Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
        '    Dim Periodos As String = ArgCodPeriodo 'CadenaVolteada '"5;7;6;8"
        '    Dim CodMoneda As Int16 = ArgCodMoneda '2
        '    Dim CodMetodizado As Int16 = ArgCodMetodizado '7667
        '    Try


        '    Dim SQL As String
        '    Dim subreport As New ReportDocument

        '    Dim dsResumenEjecutivoDetalles As DataSet = obrMetodizado.generarResumenEjecutivo_Detalles(Periodos, CodMetodizado, CodMoneda)
        '    dsResumenEjecutivoDetalles.Tables(0).TableName = "Detalle"
        '    Dim dsResumenEjecutivoCabecera As DataSet = obrMetodizado.generarResumenEjecutivo_Cabecera(Periodos, CodMetodizado, CodMoneda)
        '    dsResumenEjecutivoCabecera.Tables(0).TableName = "Cabecera"

        '    If dsResumenEjecutivoDetalles.Tables(0).Rows.Count > 0 Then
        '        dsResumenEjecutivoDetalles.Tables.Add(dsResumenEjecutivoCabecera.Tables("Cabecera").Copy)
        '            crReportDocument2.SetDataSource(dsResumenEjecutivoDetalles)
        '    End If

        '    Catch ex As Exception
        '        Console.WriteLine(ex.Message)
        '    End Try
        'End Sub
        'Private Sub Exportar2(ByVal intTipoFormato As Integer)
        '    Try

        '    'Se crea el documento de lectura y escritura
        '    Dim rptStream As New System.IO.MemoryStream
        '    Dim rptStream2 As New System.IO.MemoryStream
        '    Dim rptStream3 As New System.IO.MemoryStream

        '        Dim tmp As Integer
        '    Response.Buffer = True
        '    'se envia el reporte el stream y le indicamos el metodo de escritura o tipo de documento
        '    rptStream = CType(crReportDocument.ExportToStream(CInt(intTipoFormato)), System.IO.MemoryStream)
        '        rptStream2 = CType(crReportDocument2.ExportToStream(CInt(intTipoFormato)), System.IO.MemoryStream)
        '        rptStream3.Capacity = rptStream.Capacity + rptStream2.Capacity + 1000
        '        rptStream3.Write(rptStream.ToArray(), 0, CType(rptStream.Capacity, Integer))
        '        tmp = rptStream3.Capacity + 1
        '        'rptStream3.Write(rptStream2.ToArray(), CType(rptStream.Length, Integer), CType(rptStream2.Length, Integer))
        '        rptStream3.Write(rptStream2.ToArray(), tmp, CType(rptStream2.Capacity, Integer))

        '    'Limpiamos la memoria
        '    Response.Clear()
        '    'Le indicamos el tipo de documento que vamos a exportar
        '    Response.ContentType = FormatoDocumento(intTipoFormato)
        '    'Automaticamente se descarga el archivo
        '    Response.AddHeader("Content-Disposition", "attachment;filename=" + Me.nombreReporte)
        '    'Se escribe el archivo
        '    Response.BinaryWrite(rptStream3.ToArray())
        '    Response.End()
        '        'pCloseWindow()
        '    Catch ex As Exception
        '        Console.WriteLine(ex.Message)
        '    End Try
        'End Sub
        Private Sub Exportar(ByVal intTipoFormato As Integer)
            'Se crea el documento de lectura y escritura
            Dim rptStream As New System.IO.MemoryStream
            Response.Buffer = True
            'se envia el reporte el stream y le indicamos el metodo de escritura o tipo de documento
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
            'pCloseWindow()
        End Sub

        'Protected Sub pCloseWindow()
        '    Dim sbScriptCliente As System.Text.StringBuilder
        '    sbScriptCliente = New StringBuilder("<script language=""Javascript"" type=""text/javascript"">")
        '    sbScriptCliente.Append("function Cerrar(){ window.close();}")
        '    sbScriptCliente.Append("</script>")
        '    RegisterStartupScript("__RegPopupWebForm_SeleccionarPeriodo", sbScriptCliente.ToString())
        'End Sub

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
