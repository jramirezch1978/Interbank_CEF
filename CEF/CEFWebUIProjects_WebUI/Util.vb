'*************************************************************
'Proposito: 
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Web
Imports system.Web.Mail
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Web.HttpResponse

Namespace CEF.WebUI

    Public Class Util

        Sub New()
            MyBase.New()
        End Sub

        Public Shared Function exportarExcel(ByVal pdgrExp As DataGrid, ByVal pstrTitulo As String, ByVal pstrCriterio(,) As String) As Boolean
            Dim strIdArchivo As String = Guid.NewGuid().ToString
            Dim objResponse As HttpResponse = HttpContext.Current.Response

            objResponse.Clear()
            objResponse.Buffer = True
            objResponse.AddHeader("Content-Disposition", "attachment; filename=Exportador" + strIdArchivo + ".xls")
            'objResponse.AddHeader("Content-Disposition", "filename=Exportador" + objIdArchivo.ToString() + ".xls")
            objResponse.ContentType = "application/vnd.ms-excel"
            objResponse.Charset = "UTF-8"
            objResponse.ContentEncoding = System.Text.Encoding.Default

            Dim voStringWriter As StringWriter = New StringWriter
            Dim voHtmlTextWriter As HtmlTextWriter = New HtmlTextWriter(voStringWriter)

            pdgrExp.AllowPaging = False
            pdgrExp.AllowSorting = False
            pdgrExp.RenderControl(voHtmlTextWriter)

            objResponse.Write("<HTML>")
            objResponse.Write("<HEAD>")
            objResponse.Write("</HEAD>")
            objResponse.Write("<BODY>")
            objResponse.Write("<TABLE>")
            objResponse.Write("<TR style=""font-size:20pt;font-weight:bold;color:navy;background-color:White;"">")
            objResponse.Write("<TD colspan=2 height=36>")
            objResponse.Write(pstrTitulo)
            objResponse.Write("</TD>")
            objResponse.Write("</TR>")

            For intIdx As Integer = 0 To pstrCriterio.GetUpperBound(0)
                objResponse.Write("<TR style=""font-size:10pt;background-color:White;"">")
                objResponse.Write("<TD colspan=2>")
                objResponse.Write(String.Format("<b>{0}:</b> {1}", pstrCriterio(intIdx, 0), pstrCriterio(intIdx, 1)))
                objResponse.Write("</TD>")
                objResponse.Write("</TR>")
            Next

            objResponse.Write("<TR>")
            objResponse.Write("<TD colspan=2>")
            objResponse.Write(voStringWriter.ToString())
            objResponse.Write("</TD>")
            objResponse.Write("</TR>")
            objResponse.Write("</TABLE>")
            objResponse.Write("</BODY>")
            objResponse.Write("</HTML>")
            objResponse.End()
        End Function

        Public Shared Sub grabarErrorLog(ByVal e As Exception)
            Dim strRutaLog As String = ConfigurationSettings.AppSettings("RUTA_LOG_ERROR")
            'strRutaLog = Common.Assemblys.leerUbicacion(System.Reflection.Assembly.GetExecutingAssembly.Location)
            Dim strArchivoLog As String = ConfigurationSettings.AppSettings("ARCHIVO_LOG_ERROR")
            Dim objError As New CEF.Common.ErrorLog(strRutaLog & strArchivoLog)
            objError.saveExceptionToLog(e)
        End Sub

        Public Shared Function enviarCorreo(ByVal pstrCorreoEnvia As String, ByVal pstrListaCorreosEnviar As String, ByVal pstrListaCorreosEnviarCC As String, ByVal pstrAsunto As String, ByVal pstrMensaje As String, ByVal pstrServidorCorreo As String) As String
            Dim objCorreo As MailMessage = New MailMessage
            Dim strmensajeError As String
            Try
                With objCorreo
                    .From = pstrCorreoEnvia
                    .To = pstrListaCorreosEnviar
                    .Cc = pstrListaCorreosEnviarCC
                    .Subject = pstrAsunto
                    .BodyFormat = MailFormat.Html
                    .Body = pstrMensaje
                End With
                SmtpMail.SmtpServer = pstrServidorCorreo
                SmtpMail.Send(objCorreo)
                Return ("Se envio Correctamente el correo")
            Catch ex As Exception
                Return (ex.Message)
            Finally
                objCorreo = Nothing
            End Try
        End Function

        Public Shared Function obtenerUsuario(ByVal strCodUsuario As String) As CEF.BusinessEntity.Usuario
            Dim obeUsuario As BusinessEntity.Usuario
            Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario
            obeUsuario = obrUsuario.leer(strCodUsuario)

            Return obeUsuario
        End Function

    End Class

End Namespace