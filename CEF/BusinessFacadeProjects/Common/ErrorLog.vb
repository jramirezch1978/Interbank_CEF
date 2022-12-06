'*************************************************************
'Proposito: Guarda Exception en un archivo XML
'Autor:
'Fecha Creacion:
'Modificado por: Luis A. Mascaro Jácome
'Fecha Mod.:
'*************************************************************

Imports System
Imports System.Text
Imports System.Xml

Namespace CEF.Common
    Public Class ErrorLog
        Private _strFileName As String

        Private Const XML_ERRORLOG = "CEFLog"
        Private Const XML_EXCEPTION = "Exception"
        Private Const XML_EXCEPTION_TIME = "Fecha"
        Private Const XML_EXCEPTION_DESCRIPTION = "Descripcion"
        Private Const XML_EXCEPTION_METHOD = "Metodo"
        Private Const XML_EXCEPTION_HELPLINK = "EnlaceAyuda"
        Private Const XML_EXCEPTION_TRACE = "Trace"

        Public Property FileName() As String
            Get
                Return Me._strFileName
            End Get
            Set(ByVal Value As String)
                Dim strFecha As String = String.Format("{0:yyyyMMdd}", Date.Today)
                Dim strFileName As String = Value.Trim
                Dim strArchivo As String = String.Empty
                strArchivo = strFileName.Substring(0, strFileName.Length - 4) + "_" + strFecha + strFileName.Substring(strFileName.Length - 4, 4)

                Me._strFileName = strArchivo
            End Set
        End Property

        Public Sub New(ByVal strFileName As String)
            Me.FileName = strFileName
            If Not System.IO.File.Exists(Me.FileName) Then
                createLogFile()
            End If
        End Sub

        Public Sub New(ByVal strFileName As String, ByVal e As Exception)
            Me.FileName = strFileName
            If Not System.IO.File.Exists(Me.FileName) Then
                createLogFile()
            End If
            saveExceptionToLog(e)
        End Sub

        Private Sub createLogFile()
            Dim xmlWriter As XmlTextWriter = New XmlTextWriter(Me.FileName, System.Text.Encoding.UTF8)
            xmlWriter.WriteStartDocument()
            xmlWriter.WriteStartElement(XML_ERRORLOG)
            xmlWriter.WriteEndElement()
            xmlWriter.WriteEndDocument()
            xmlWriter.Close()
        End Sub

        Private Sub writeException(ByVal e As Exception, ByVal xmlWriter As XmlWriter)
            xmlWriter.WriteStartElement(XML_EXCEPTION)
            xmlWriter.WriteElementString(XML_EXCEPTION_TIME, System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"))
            xmlWriter.WriteElementString(XML_EXCEPTION_DESCRIPTION, e.Message)
            If Not e.TargetSite Is Nothing Then
                xmlWriter.WriteElementString(XML_EXCEPTION_METHOD, e.TargetSite.ToString())
            End If
            If Not e.HelpLink Is Nothing Then
                xmlWriter.WriteElementString(XML_EXCEPTION_HELPLINK, e.HelpLink)
            End If
            xmlWriter.WriteStartElement(XML_EXCEPTION_TRACE)
            xmlWriter.WriteString(e.StackTrace)
            xmlWriter.WriteEndElement()
            If Not e.InnerException Is Nothing Then
                writeException(e.InnerException, xmlWriter)
            End If
        End Sub

        Public Sub saveExceptionToLog(ByVal e As Exception)
            Dim strOriginal As String = Nothing
            Dim xmlReader As XmlTextReader = New XmlTextReader(Me.FileName)
            xmlReader.WhitespaceHandling = WhitespaceHandling.None
            xmlReader.MoveToContent()
            strOriginal = xmlReader.ReadInnerXml()
            xmlReader.Close()
            Dim xmlWriter As XmlTextWriter = New System.Xml.XmlTextWriter(Me.FileName, System.Text.Encoding.UTF8)
            xmlWriter.WriteStartDocument()
            xmlWriter.WriteStartElement(XML_ERRORLOG)
            xmlWriter.WriteRaw(strOriginal)
            writeException(e, xmlWriter)
            xmlWriter.WriteEndElement()
            xmlWriter.Close()
        End Sub

    End Class

    Friend Class Ini
        Public Shared Function leerValor(ByVal strArchivo As String, _
                               ByVal strSeccion As String, _
                               ByVal strClave As String) As String
            Dim objFile As System.IO.StreamReader = New System.IO.StreamReader(strArchivo)
            Dim strLinea As String = String.Empty
            Dim intKey As Integer
            Dim strValor As String = String.Empty
            Dim blnSection As Integer = 0

            Do While Not strLinea Is Nothing
                strLinea = objFile.ReadLine()
                If (strLinea.Trim.ToUpper = strSeccion.Trim.ToUpper) Then
                    blnSection = 1
                End If
                If blnSection = 1 Then
                    If strLinea.StartsWith(strClave) Then
                        strValor = strLinea.Split("=")(1).Trim
                        Exit Do
                    End If
                End If
            Loop
            Return (strValor)
        End Function
    End Class

    'Public Class Assemblys
    '    Public Shared Function leerUbicacion(ByVal pstrArchivo As String) As String
    '        Dim strRuta As String = System.IO.Path.GetDirectoryName(pstrArchivo) & "\" & "__AssemblyInfo__.ini"
    '        strRuta = Ini.leerValor(strRuta, "[AssemblyInfo]", "URL")
    '        strRuta = strRuta.Replace("file:///", String.Empty)
    '        strRuta = strRuta.Replace("/", "\")
    '        strRuta = System.IO.Path.GetDirectoryName(strRuta) & "\"
    '        strRuta = strRuta.Replace("\bin\", "\logs\")
    '        Return (strRuta)
    '    End Function
    'End Class

End Namespace