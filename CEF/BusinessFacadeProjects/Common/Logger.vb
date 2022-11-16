Imports System.Runtime.InteropServices
Imports System
Imports System.IO
Imports System.Xml
Imports System.Configuration
Imports System.Web
Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationSettings
Imports System.Text
Imports System.Reflection
Imports System.Collections

Imports System.ComponentModel
Imports System.Globalization
Imports System.Collections.Specialized
Imports System.Resources
Imports System.ComponentModel.Design

Imports System.Security.Cryptography
Imports System.Security.Permissions
Imports Microsoft.VisualBasic.CompilerServices
Imports System.Text.RegularExpressions
Imports System.Runtime.Serialization

Namespace CEF.Common

    Public Class cefConfiguracion
        Public Shared Function retornaDatoConf(ByVal strKey As String) As String
            Dim oLectorXML
            Dim strRpta As String = String.Empty
            Dim asm As [Assembly] = [Assembly].GetExecutingAssembly
            Dim strRutaConfig As String = System.IO.Path.GetDirectoryName(asm.CodeBase) + "\" + constantesCommon.archivoConfiguracion

            strRutaConfig = Replace(strRutaConfig, "file:\", "")
            strRutaConfig = Replace(strRutaConfig, "/", "\")

            oLectorXML = New lectorXML(strRutaConfig)
            strRpta = oLectorXML.leerValor(constantesCommon.seccionAssemblySettings, strKey)

            Return strRpta
        End Function
    End Class


    Public Class Log
        Implements IDisposable

#Region "Propiedades"

#Region "Públicas"

#End Region

#Region "Privadas"

        Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

#End Region

#End Region

#Region "Métodos"

#Region "Públicos"

        Public Function toWrite(ByVal argSd As String, _
                                ByVal argAmbiente As Integer, _
                                ByVal argElemento As String, _
                                ByVal argFuncion As String, _
                                ByVal argTipo As Integer, _
                                ByVal argErrApp As String, _
                                ByVal argMsgApp As String, _
                                ByVal argErrOri As String, _
                                ByVal argMsgOri As String, _
                                Optional ByVal argTrace As String = "") As Integer
            '----------------------------------------------------------------------------------------------------
            ' Finalidad    : Escribir log
            ' Parámetros   : argSd       - Sistema donde ocurrio el evento
            '              : argAmbiente - Ambiente donde ocurrio el evento
            '              : argElemento - Elemento donde ocurrio el evento
            '              : argFuncion  - Función donde ocurrio el evento
            '              : argTipo     - Nivel de Error :
            '                              0-Exito
            '                              1-Informativo
            '                              2-Advertencia
            '                              3-Error
            '                              4-Falla general
            '              : argErrApp   - Código de Error de la Aplicación
            '              : argMsgApp   - Mensaje de Error de la Aplicación
            '              : argErrOri   - Grupo de Error Original
            '              : argMsgOri   - Mensaje de Error Original
            '              : argTrace    - StackTrace del Error
            '              : argRutaLog  - Ruta en la que se debe guardar el log
            ' Resultados   :  0          - Log se escribio correctamente
            '              : -1          - Ocurrio un problema al escribir log
            '              : -2          - Ambiente no válido
            '              : -3          - Código de tipo de log no valido
            ' Modificación : &0001 * FO1486 01/12/04 S7798  S7798  ESTANDARES SDA
            '----------------------------------------------------------------------------------------------------
            '0.Declarar variables
            Dim strAmbiente As String
            Dim strFile As String
            Dim strTipo As String

            '1.Inicializar variables
            toWrite = -1
            Dim strFuncion As String = "toWrite"


            Dim strRuta As String = Nothing

            strRuta = cefConfiguracion.retornaDatoConf(constantesCommon.RutaLog)

            argAmbiente = cefConfiguracion.retornaDatoConf(constantesCommon.IdAmbiente)

            Select Case argAmbiente
                Case 0 : strAmbiente = "Prd"
                Case 1 : strAmbiente = "Uat"
                Case 2 : strAmbiente = "Sit"
                Case 3 : strAmbiente = "Des"
                Case 4 : strAmbiente = ""
                Case Else : toWrite = -2 : Exit Function
            End Select
            'strFile = strRuta & LCase(argSd) & strAmbiente & ".xml"
            'strFile = strRuta & argSd & strAmbiente & "_" & DateTime.Now.ToString("yyyyMMdd") & ".log"
            strFile = strRuta & argSd & "_" & DateTime.Now.ToString("yyyyMMdd") & ".log"

            Select Case argTipo
                Case 0 : strTipo = "Exito"
                Case 1 : strTipo = "Informativo"
                Case 2 : strTipo = "Advertencia"
                Case 3 : strTipo = "Error"
                Case 4 : strTipo = "Fatal"
                Case Else : toWrite = -3 : Exit Function
            End Select

            '2.Ejecutar
            '2.1.Crear ruta
            If Not System.IO.Directory.Exists(strRuta) Then
                System.IO.Directory.CreateDirectory(strRuta)
            End If

            '2.2.Crear archivo
            Dim strOriginal As String = Nothing
            Dim xmlWriter As XmlTextWriter
            Try
                If Not System.IO.File.Exists(strFile) Then
                    xmlWriter = New XmlTextWriter(strFile, System.Text.Encoding.UTF8)
                    xmlWriter.WriteStartDocument()
                    xmlWriter.WriteStartElement("Logs")
                    xmlWriter.WriteEndElement()
                    xmlWriter.WriteEndDocument()
                    xmlWriter.Close()
                    xmlWriter = Nothing
                Else
                    Dim xmlReader As XmlTextReader
                    xmlReader = New XmlTextReader(strFile)
                    xmlReader.WhitespaceHandling = WhitespaceHandling.None
                    xmlReader.MoveToContent()
                    strOriginal = xmlReader.ReadInnerXml()
                    xmlReader.Close()
                    xmlReader = Nothing
                End If

                '2.3.Escribir log
                xmlWriter = New XmlTextWriter(strFile, System.Text.Encoding.UTF8)
                xmlWriter.WriteStartDocument()
                xmlWriter.WriteStartElement("Logs")
                xmlWriter.WriteRaw(strOriginal)
                xmlWriter.WriteStartElement("Log")
                xmlWriter.WriteElementString("Fecha", System.DateTime.Today.ToString("yyyyMMdd"))
                xmlWriter.WriteElementString("Hora", System.DateTime.Now.ToString("HH:mm:ss"))
                xmlWriter.WriteElementString("Elemento", argElemento)
                xmlWriter.WriteElementString("Funcion", argFuncion)
                xmlWriter.WriteElementString("Tipo", strTipo)
                xmlWriter.WriteElementString("ErrApp", argErrApp)
                xmlWriter.WriteElementString("MsgApp", argMsgApp)
                xmlWriter.WriteElementString("ErrOri", argErrOri)
                xmlWriter.WriteElementString("MsgOri", argMsgOri)
                xmlWriter.WriteElementString("Trace", argTrace)
                xmlWriter.WriteEndElement()
                xmlWriter.Close()
                toWrite = 0


            Catch ex As Exception
            Finally
                xmlWriter = Nothing
            End Try
        End Function

        Public Function toWriteLog(ByVal argAmbiente As Integer, _
                                           ByVal argTipo As Integer, _
                                           ByVal argFuncion As String, _
                                           ByVal argErrApp As String, _
                                           ByVal argTrace As String) As Integer
            '----------------------------------------------------------------------------------------------------           

            Dim strAmbiente As String
            Dim strFile As String
            Dim strTipo As String

            '1.Inicializar variables
            toWriteLog = -1
            Dim strFuncion As String = "toWriteLog"


            Dim strRuta As String = Nothing

            strRuta = cefConfiguracion.retornaDatoConf(constantesCommon.RutaLog)

            argAmbiente = cefConfiguracion.retornaDatoConf(constantesCommon.IdAmbiente)

            Select Case argAmbiente
                Case 0 : strAmbiente = "Prd"
                Case 1 : strAmbiente = "Uat"
                Case 2 : strAmbiente = "Sit"
                Case 3 : strAmbiente = "Des"
                Case 4 : strAmbiente = ""
                Case Else : toWriteLog = -2 : Exit Function
            End Select
            'strFile = strRuta & LCase(argSd) & strAmbiente & ".xml"
            'strFile = strRuta & argSd & strAmbiente & "_" & DateTime.Now.ToString("yyyyMMdd") & ".log"
            strFile = strRuta & "LogRtg" & DateTime.Now.ToString("yyyyMMdd") & ".log"

            Select Case argTipo
                Case 0 : strTipo = "Exito"
                Case 1 : strTipo = "Informativo"
                Case 2 : strTipo = "Advertencia"
                Case 3 : strTipo = "Error"
                Case 4 : strTipo = "Fatal"
                Case Else : toWriteLog = -3 : Exit Function
            End Select

            '2.Ejecutar
            '2.1.Crear ruta
            If Not System.IO.Directory.Exists(strRuta) Then
                System.IO.Directory.CreateDirectory(strRuta)
            End If

            '2.2.Crear archivo
            Dim strOriginal As String = Nothing
            Dim xmlWriter As XmlTextWriter
            Try
                If Not System.IO.File.Exists(strFile) Then
                    xmlWriter = New XmlTextWriter(strFile, System.Text.Encoding.UTF8)
                    xmlWriter.WriteStartDocument()
                    xmlWriter.WriteStartElement("Logs")
                    xmlWriter.WriteEndElement()
                    xmlWriter.WriteEndDocument()
                    xmlWriter.Close()
                    xmlWriter = Nothing
                Else
                    Dim xmlReader = New XmlTextReader(strFile)
                    xmlReader.WhitespaceHandling = WhitespaceHandling.None
                    xmlReader.MoveToContent()
                    strOriginal = xmlReader.ReadInnerXml()
                    xmlReader.Close()
                    xmlReader = Nothing
                End If

                '2.3.Escribir log
                xmlWriter = New XmlTextWriter(strFile, System.Text.Encoding.UTF8)
                xmlWriter.WriteStartDocument()
                xmlWriter.WriteStartElement("Logs")
                xmlWriter.WriteRaw(strOriginal)
                xmlWriter.WriteStartElement("Log")
                xmlWriter.WriteElementString("Linea", "---------------------------------------------" & vbCrLf)
                xmlWriter.WriteElementString("FechaHora", System.DateTime.Today.ToString("yyyyMMdd") & " " & System.DateTime.Now.ToString("HH:mm:ss") & vbCrLf)
                xmlWriter.WriteElementString("Clase", argFuncion & vbCrLf)
                xmlWriter.WriteElementString("Cab", argErrApp & vbCrLf)
                xmlWriter.WriteElementString("Det", argTrace & vbCrLf)
                xmlWriter.WriteEndElement()
                xmlWriter.Close()
                toWriteLog = 0
            Catch ex As Exception
            Finally
                xmlWriter = Nothing
            End Try
        End Function

        Public Function toWriteSqlCOM(ByVal argMetodo As String, ByVal argClase As String, _
                                            ByVal argBasedato As String, _
                                            ByVal argSp As String, _
                                            ByVal argLogTxn As Integer, _
                                            ByVal argParm As ArrayList) As Integer
            '0.Declarar variables
            Dim argAmbiente As Integer
            Dim strAmbiente As String
            Dim strFile As String
            Dim strTipo As String
            Dim argTipo As Integer = 3
            Dim strParam As String = ""
            '1.Inicializar variables
            toWriteSqlCOM = -1
            Dim strFuncion As String = "toWriteSqlCOM"

            Dim strRuta As String = Nothing

            strRuta = cefConfiguracion.retornaDatoConf(constantesCommon.RutaLog)

            argAmbiente = cefConfiguracion.retornaDatoConf(constantesCommon.IdAmbiente)

            Select Case argAmbiente
                Case 0 : strAmbiente = "Prd"
                Case 1 : strAmbiente = "Uat"
                Case 2 : strAmbiente = "Sit"
                Case 3 : strAmbiente = "Des"
                Case 4 : strAmbiente = ""
                Case Else : toWriteSqlCOM = -2 : Exit Function
            End Select
            'strFile = strRuta & LCase(argSd) & strAmbiente & ".xml"
            'strFile = strRuta & argSd & strAmbiente & "_" & DateTime.Now.ToString("yyyyMMdd") & ".log"
            'strFile = strRuta & argMetodo & "_" & argSp & "_" & DateTime.Now.ToString("yyyyMMdd") & ".log"
            strFile = strRuta & argClase & "_" & DateTime.Now.ToString("yyyyMMdd") & ".log"

            Select Case argTipo
                Case 0 : strTipo = "Exito"
                Case 1 : strTipo = "Informativo"
                Case 2 : strTipo = "Advertencia"
                Case 3 : strTipo = "Error"
                Case 4 : strTipo = "Fatal"
                Case Else : toWriteSqlCOM = -3 : Exit Function
            End Select

            '2.Ejecutar
            '2.1.Crear ruta
            If Not System.IO.Directory.Exists(strRuta) Then
                System.IO.Directory.CreateDirectory(strRuta)
            End If

            '2.2.Crear archivo
            Dim strOriginal As String = Nothing
            Dim xmlWriter As XmlTextWriter
            Try
                If Not System.IO.File.Exists(strFile) Then
                    xmlWriter = New XmlTextWriter(strFile, System.Text.Encoding.UTF8)
                    xmlWriter.WriteStartDocument()
                    xmlWriter.WriteStartElement("Logs")
                    xmlWriter.WriteEndElement()
                    xmlWriter.WriteEndDocument()
                    xmlWriter.Close()
                    xmlWriter = Nothing
                Else
                    Dim xmlReader = New XmlTextReader(strFile)
                    xmlReader.WhitespaceHandling = WhitespaceHandling.None
                    xmlReader.MoveToContent()
                    strOriginal = xmlReader.ReadInnerXml()
                    xmlReader.Close()
                    xmlReader = Nothing
                End If
                Dim tipo As String
                '2.3.Escribir log
                xmlWriter = New XmlTextWriter(strFile, System.Text.Encoding.UTF8)
                xmlWriter.WriteStartDocument()
                xmlWriter.WriteStartElement("Logs")
                xmlWriter.WriteRaw(strOriginal)
                xmlWriter.WriteStartElement("Log")
                xmlWriter.WriteElementString("FechaHora", System.DateTime.Today.ToString("yyyyMMdd") & " " & System.DateTime.Now.ToString("HH:mm:ss") & vbCrLf)
                xmlWriter.WriteElementString("Metodo", argMetodo & vbCrLf)
                For i As Integer = 0 To argParm.Count - 1
                    Dim objAls As ArrayList = argParm(i)
                    'Debug.WriteLine("argParm(" & i & ")=" & objAls(0) & "|" & objAls(3)) ' & "|" & objAls(2))
                    tipo = Convert.ToInt32(objAls(1))
                    If i = 0 Then
                        strParam = " " & formatoArg(tipo, objAls(3))
                    Else
                        strParam = strParam & "," & formatoArg(tipo, objAls(3))
                    End If
                    If tipo = "4" Then
                        strParam = strParam.Replace(" a.m.", "")
                    End If
                Next
                strParam = "Exec " & argSp & strParam

                xmlWriter.WriteElementString("Param", vbCrLf & strParam & vbCrLf)
                xmlWriter.WriteElementString("Linea", "---------------------------------------------")
                xmlWriter.WriteEndElement()
                xmlWriter.Close()
                toWriteSqlCOM = 0

            Catch ex As Exception
            Finally
                xmlWriter = Nothing
            End Try
        End Function

        Public Function toWriteOraCOM(ByVal argMetodo As String, ByVal argClase As String, _
                                            ByVal argBasedato As String, _
                                            ByVal argSp As String, _
                                            ByVal argLogTxn As Integer, _
                                            ByVal argParm As ArrayList) As Integer
            '----------------------------------------------------------------------------------------------------           
            Try


                Dim argAmbiente As Integer
                Dim strAmbiente As String
                Dim strFile As String
                Dim strTipo As String
                Dim argTipo As Integer = 3
                Dim strParam As String = ""
                '1.Inicializar variables
                toWriteOraCOM = -1
                Dim strFuncion As String = "toWriteOraCOM"


                Dim strRuta As String = Nothing

                strRuta = cefConfiguracion.retornaDatoConf(constantesCommon.RutaLog)

                argAmbiente = cefConfiguracion.retornaDatoConf(constantesCommon.IdAmbiente)

                Select Case argAmbiente
                    Case 0 : strAmbiente = "Prd"
                    Case 1 : strAmbiente = "Uat"
                    Case 2 : strAmbiente = "Sit"
                    Case 3 : strAmbiente = "Des"
                    Case 4 : strAmbiente = ""
                    Case Else : toWriteOraCOM = -2 : Exit Function
                End Select
                'strFile = strRuta & LCase(argSd) & strAmbiente & ".xml"
                'strFile = strRuta & argSd & strAmbiente & "_" & DateTime.Now.ToString("yyyyMMdd") & ".log"
                'strFile = strRuta & argClase & "_" & argSp & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".log"
                strFile = strRuta & argClase & "_" & DateTime.Now.ToString("yyyyMMdd") & ".log"
                Select Case argTipo
                    Case 0 : strTipo = "Exito"
                    Case 1 : strTipo = "Informativo"
                    Case 2 : strTipo = "Advertencia"
                    Case 3 : strTipo = "Error"
                    Case 4 : strTipo = "Fatal"
                    Case Else : toWriteOraCOM = -3 : Exit Function
                End Select

                '2.Ejecutar
                '2.1.Crear ruta
                If Not System.IO.Directory.Exists(strRuta) Then
                    System.IO.Directory.CreateDirectory(strRuta)
                End If

                '2.2.Crear archivo
                Dim strOriginal As String = Nothing
                Dim xmlWriter As XmlTextWriter
                If Not System.IO.File.Exists(strFile) Then
                    xmlWriter = New XmlTextWriter(strFile, System.Text.Encoding.UTF8)
                    xmlWriter.WriteStartDocument()
                    xmlWriter.WriteStartElement("Logs")
                    xmlWriter.WriteEndElement()
                    xmlWriter.WriteEndDocument()
                    xmlWriter.Close()
                    xmlWriter = Nothing
                Else
                    Dim xmlReader = New XmlTextReader(strFile)
                    xmlReader.WhitespaceHandling = WhitespaceHandling.None
                    xmlReader.MoveToContent()
                    strOriginal = xmlReader.ReadInnerXml()
                    xmlReader.Close()
                    xmlReader = Nothing
                End If
                Dim tipo As String = ""
                '2.3.Escribir log
                xmlWriter = New XmlTextWriter(strFile, System.Text.Encoding.UTF8)
                xmlWriter.WriteStartDocument()
                xmlWriter.WriteStartElement("Logs")
                xmlWriter.WriteRaw(strOriginal)
                xmlWriter.WriteStartElement("Log")
                xmlWriter.WriteElementString("FechaHora", System.DateTime.Today.ToString("yyyyMMdd") & " " & System.DateTime.Now.ToString("HH:mm:ss") & vbCrLf)
                xmlWriter.WriteElementString("Metodo", argMetodo & vbCrLf)
                xmlWriter.WriteElementString("argParm", argParm.Count & vbCrLf)
                xmlWriter.WriteElementString("argSp", vbCrLf & argSp & vbCrLf)
                For i As Integer = 0 To argParm.Count - 1
                    Dim objAls As ArrayList = argParm(i)
                    strTipo = Convert.ToInt32(objAls(1))
                    Select Case strTipo
                        Case 107
                            tipo = "Float"
                        Case 126, 127
                            tipo = "String"
                        Case Else
                            tipo = "Integer"
                    End Select
                    strParam = strParam & "Enabled" & "	" & objAls(0) & "	" & tipo & "	" & objAls(3) & vbCrLf
                Next
                xmlWriter.WriteElementString("Param", vbCrLf & strParam)
                xmlWriter.WriteElementString("Linea", "---------------------------------------------")
                xmlWriter.WriteEndElement()
                xmlWriter.Close()
                toWriteOraCOM = 0
            Catch ex As Exception
            Finally
            End Try
        End Function

        Public Sub EscribirLog(ByVal UBICA_CLASE As String, ByVal CABECERA_EVENTO As String, ByVal DETALLE_EVENTO As String)
            toWriteLog(4, constantesCommon.TipoLog.ErrorX, UBICA_CLASE, CABECERA_EVENTO, DETALLE_EVENTO)
        End Sub

        Function formatoArg(ByVal strTipo As Integer, ByVal strValor As String) As String
            Dim strformat As String = ""
            Select Case strTipo
                Case 4, 5, 11, 12 'datetime,decimal,nvarchar,ntext
                    strformat = "'" & (IIf((strValor Is Nothing), "", strValor)) & "'"
                Case Else
                    strformat = strValor
            End Select
            Return strformat
        End Function

#Region " IDisposable Support "
        ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#End Region

#Region "Privados"

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: Liberar recursos administrados cuando se llamen explícitamente
                End If

                ' TODO: Liberar recursos no administrados compartidos
            End If
            Me.disposedValue = True
        End Sub

#End Region

#End Region

    End Class

    Public Class Logger
        Public Shared Function Info(ByVal metodo As MethodBase, ByVal mensaje As String, Optional ByVal proyecto As String = Nothing) As Boolean
            Try
                Dim l As New Log

                Dim nameClass As String = ""
                Dim nameMethod As String = ""

                If Not metodo Is Nothing Then

                    nameMethod = ConvertFormat.CheckString(metodo.Name())

                    If Not metodo.ReflectedType Is Nothing Then
                        nameClass = ConvertFormat.CheckString(metodo.ReflectedType.Name)

                        If (proyecto Is Nothing Or proyecto = "") Then proyecto = ConvertFormat.CheckString(metodo.ReflectedType.Namespace)
                    End If

                End If


                l.toWrite _
                ( _
                    proyecto + "_" + "Info", _
                    4, _
                    nameClass, _
                    nameMethod, _
                    constantesCommon.TipoLog.Informativo, _
                    "", _
                    "Informativo", _
                    "", _
                    "", _
                    mensaje _
                )

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function [Error](ByVal metodo As MethodBase, ByVal excepcion As Exception, Optional ByVal proyecto As String = Nothing, Optional ByVal paquete As String = Nothing, Optional ByVal codigo As Integer = Nothing) As Boolean
            Try
                Dim l As New Log

                If (codigo = 0) Then codigo = -1
                If Not (paquete Is Nothing) Then paquete = "PACKAGE: " + paquete + " ERROR: "

                Dim nameClass As String = ""
                Dim nameMethod As String = ""

                If Not metodo Is Nothing Then

                    nameMethod = ConvertFormat.CheckString(metodo.Name())

                    If Not metodo.ReflectedType Is Nothing Then
                        nameClass = ConvertFormat.CheckString(metodo.ReflectedType.Name)

                        If (proyecto Is Nothing Or proyecto = "") Then proyecto = ConvertFormat.CheckString(metodo.ReflectedType.Namespace)
                    End If

                End If

                l.toWrite _
                ( _
                    proyecto + "_" + "Error", _
                    4, _
                    nameClass, _
                    nameMethod, _
                    constantesCommon.TipoLog.ErrorX, _
                    paquete + codigo.ToString(), _
                    "Error", _
                    "", _
                    excepcion.Message, _
                    excepcion.StackTrace + " - " + excepcion.Message _
                )

                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
    End Class

End Namespace