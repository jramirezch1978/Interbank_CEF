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
                rowTmpl = rowTmpl.Replace("[Real1]", row("Real1").ToString)
                rowTmpl = rowTmpl.Replace("[Vard1]", row("Var1").ToString)
                rowTmpl = rowTmpl.Replace("[Proy1]", row("Proy1").ToString)
                rowTmpl = rowTmpl.Replace("[Vard2]", row("Var2").ToString)
                rowTmpl = rowTmpl.Replace("[Real2]", row("Real2").ToString)
                rowTmpl = rowTmpl.Replace("[Vard3]", row("Var3").ToString)
                rowTmpl = rowTmpl.Replace("[Proy2]", row("Proy2").ToString)
                rowTmpl = rowTmpl.Replace("[Vard4]", row("Var4").ToString)
                rowTmpl = rowTmpl.Replace("[Vara1]", row("Vara1").ToString)
                rowTmpl = rowTmpl.Replace("[Vara2]", row("Vara2").ToString)
                rowTmpl = rowTmpl.Replace("[Vara3]", row("Vara3").ToString)

                data.Append(rowTmpl)
            Next

        End If

        Return Data.ToString()
    End Function

End Class
