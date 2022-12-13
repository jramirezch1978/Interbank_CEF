Imports SelectPdf
Imports System.IO
Imports System.Text
Imports CEF.DataAccess

Partial Class LoginDoor
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rfvUsuario As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvPerfil As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvPassword As RequiredFieldValidator

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim usuario As String = txtUsuario.Text.Trim().ToUpper()
        Dim perfil As String = ddlPerfil.SelectedValue()
        Dim password As String = txtPassword.Text.Trim().ToUpper()

        If usuario <> "" And perfil <> "" And password = "@CEF" Then Response.Redirect("Login2.aspx?strUsuario=" & usuario & "&intPerfil=" & perfil)
    End Sub

    Protected Sub btnDownload_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDownload.Click

        Dim htmlPath As String = GetHtmlTemplatePath("PlantillaProyecciones")
        Dim htmlDetailPath As String = GetHtmlTemplatePath("PlantillaProyeccionesDetalle")
        Dim hmtlString As String = GetHtmlTemplateString(htmlPath)
        Dim hmtlDetailString As String = GetHtmlTemplateString(htmlDetailPath)

        hmtlString = GetHtmlProyecccionCabecera(hmtlString)
        hmtlDetailString = GetHtmlProyecccionDetalle(hmtlDetailString)

        hmtlString = hmtlString.Replace("[rows]", hmtlDetailString)

        Dim pdfOrientation As SelectPdf.PdfPageOrientation = PdfPageOrientation.Landscape
        Dim converter As New HtmlToPdf
        converter.Options.PdfPageSize = PdfPageSize.A4
        converter.Options.PdfPageOrientation = pdfOrientation
        converter.Options.WebPageWidth = 1024

        Dim doc As PdfDocument = converter.ConvertHtmlString(hmtlString, htmlPath)
        Dim fecha As DateTime = DateTime.Now

        Dim date_str As String = fecha.ToString("yyyyMMdd_HHmmss")

        doc.Save(Response, False, "Reporte_Proyecciones_" + date_str + ".pdf")
        doc.Close()

    End Sub

    Function GetHtmlTemplateString(ByVal path As String) As String
        Dim readText As String = String.Empty
        If Not File.Exists(path) Then
            Return readText
        End If

        Dim appendText As String = String.Empty
        File.AppendAllText(path, appendText, Encoding.UTF8)
        readText = File.ReadAllText(path)
        Return readText
    End Function

    Function GetHtmlTemplatePath(ByVal path As String) As String
        Dim UpPath As String = Server.MapPath("~/HtmlTemplate")
        Dim tmplPath As String = UpPath & "\" & path & ".html"
        Return tmplPath
    End Function

    Function GetHtmlProyecccionCabecera(ByVal htmlString As String) As String
        Dim obrMetodizado As Metodizado = New Metodizado
        Dim dsProyeccionesCab As DataSet = obrMetodizado.listarProyeccionesCabecera(250, "3;1;2", "")
        Dim cabecera As DataTable = dsProyeccionesCab.Tables(0)

        Dim strTipoPer1 As String = cabecera.Rows(0)("TipoPer1").ToString
        Dim strTipoPer2 As String = cabecera.Rows(0)("TipoPer2").ToString
        Dim strTipoPer3 As String = cabecera.Rows(0)("TipoPer3").ToString
        Dim strTipoPer4 As String = cabecera.Rows(0)("TipoPer4").ToString

        Dim strFecha4 As String = cabecera.Rows(0)("Fecha4").ToString
        Dim strFecha3 As String = cabecera.Rows(0)("Fecha3").ToString
        Dim strFecha2 As String = cabecera.Rows(0)("Fecha2").ToString
        Dim strFecha1 As String = cabecera.Rows(0)("Fecha1").ToString

        htmlString = htmlString.Replace("[Titulo]", "PROYECCIONES")
        htmlString = htmlString.Replace("[TipoPer1]", ColumnValue(cabecera.Rows(0), "TipoPer1"))
        htmlString = htmlString.Replace("[EstadoFinanciero1]", cabecera.Rows(0)("EstadoFinanciero1").ToString)
        htmlString = htmlString.Replace("[Estado1]", cabecera.Rows(0)("Estado1").ToString)
        htmlString = htmlString.Replace("[Fecha1]", cabecera.Rows(0)("Fecha1").ToString)
        htmlString = htmlString.Replace("[TipoPer2]", cabecera.Rows(0)("TipoPer2").ToString)
        htmlString = htmlString.Replace("[EstadoFinanciero2]", cabecera.Rows(0)("EstadoFinanciero2").ToString)
        htmlString = htmlString.Replace("[Estado2]", cabecera.Rows(0)("Estado2").ToString)
        htmlString = htmlString.Replace("[Fecha2]", cabecera.Rows(0)("Fecha2").ToString)
        htmlString = htmlString.Replace("[TipoPer3]", cabecera.Rows(0)("TipoPer3").ToString)
        htmlString = htmlString.Replace("[EstadoFinanciero3]", cabecera.Rows(0)("EstadoFinanciero3").ToString)
        htmlString = htmlString.Replace("[Estado3]", cabecera.Rows(0)("Estado3").ToString)
        htmlString = htmlString.Replace("[Fecha3]", cabecera.Rows(0)("Fecha3").ToString)
        htmlString = htmlString.Replace("[TipoPer4]", cabecera.Rows(0)("TipoPer4").ToString)
        htmlString = htmlString.Replace("[EstadoFinanciero4]", cabecera.Rows(0)("EstadoFinanciero4").ToString)
        htmlString = htmlString.Replace("[Estado4]", cabecera.Rows(0)("Estado4").ToString)
        htmlString = htmlString.Replace("[Fecha4]", cabecera.Rows(0)("Fecha4").ToString)

        htmlString = htmlString.Replace("[Varc1]", Left(strTipoPer1, 1) + Right(strFecha2, 2) + " / " +
                                                   Left(strTipoPer1, 1) + Right(strFecha1, 2))

        htmlString = htmlString.Replace("[Varc2]", Left(strTipoPer3, 1) + Right(strFecha3, 2) + " / " +
                                                   Left(strTipoPer2, 1) + Right(strFecha2, 2))

        htmlString = htmlString.Replace("[Varc3]", Left(strTipoPer4, 1) + Right(strFecha4, 2) + " / " +
                                                   Left(strTipoPer3, 1) + Right(strFecha3, 2))

        Return htmlString
    End Function

    Function ColumnValue(ByVal Rows As DataRow, ByVal nombrecolumna As String) As String
        Return Rows(nombrecolumna).ToString()
    End Function

    Function GetHtmlProyecccionDetalle(ByVal htmlString As String) As String
        Dim obrMetodizado As Metodizado = New Metodizado
        Dim dsProyecciones As DataSet = obrMetodizado.listarProyecciones(250, "3;1;2", "")
        Dim data As New StringBuilder()
        Dim detalle As DataTable = dsProyecciones.Tables(0)

        If detalle.Rows.Count > 0 Then
            For Each row As DataRow In detalle.Rows
                Dim rowTmpl As String = htmlString
                rowTmpl = rowTmpl.Replace("[Descripcion]", row("Descripcion").ToString)

                If row("Real1") IsNot DBNull.Value Then
                    rowTmpl = rowTmpl.Replace("[Real1]", Convert.ToDecimal(row("Real1")).ToString("###,##0.00"))
                Else
                    rowTmpl = rowTmpl.Replace("[Real1]", "")
                End If

                If row("Var1") IsNot DBNull.Value Then
                    rowTmpl = rowTmpl.Replace("[Var1]", Convert.ToDecimal(row("Var1")).ToString("###,##0.00"))
                Else
                    rowTmpl = rowTmpl.Replace("[Var1]", "")
                End If

                If row("Proy1") IsNot DBNull.Value Then
                    rowTmpl = rowTmpl.Replace("[Proy1]", Convert.ToDecimal(row("Proy1")).ToString("###,##0.00"))
                Else
                    rowTmpl = rowTmpl.Replace("[Proy1]", "")
                End If

                If row("Var2") IsNot DBNull.Value Then
                    rowTmpl = rowTmpl.Replace("[Var2]", Convert.ToDecimal(row("Var2")).ToString("###,##0.00"))
                Else
                    rowTmpl = rowTmpl.Replace("[Var2]", "")
                End If

                If row("Real2") IsNot DBNull.Value Then
                    rowTmpl = rowTmpl.Replace("[Real2]", Convert.ToDecimal(row("Real2")).ToString("###,##0.00"))
                Else
                    rowTmpl = rowTmpl.Replace("[Real2]", "")
                End If

                If row("Var3") IsNot DBNull.Value Then
                    rowTmpl = rowTmpl.Replace("[Var3]", Convert.ToDecimal(row("Var3")).ToString("###,##0.00"))
                Else
                    rowTmpl = rowTmpl.Replace("[Var3]", "")
                End If

                If row("Proy2") IsNot DBNull.Value Then
                    rowTmpl = rowTmpl.Replace("[Proy2]", Convert.ToDecimal(row("Proy2")).ToString("###,##0.00"))
                Else
                    rowTmpl = rowTmpl.Replace("[Proy2]", "")
                End If

                If row("Var4") IsNot DBNull.Value Then
                    rowTmpl = rowTmpl.Replace("[Var4]", Convert.ToDecimal(row("Var4")).ToString("###,##0.00"))
                Else
                    rowTmpl = rowTmpl.Replace("[Var4]", "")
                End If

                rowTmpl = rowTmpl.Replace("[Vara1]", row("Vara1").ToString)
                rowTmpl = rowTmpl.Replace("[Vara2]", row("Vara2").ToString)
                rowTmpl = rowTmpl.Replace("[Vara3]", row("Vara3").ToString)

                data.Append(rowTmpl)
            Next

        End If

        Return Data.ToString()
    End Function

End Class
