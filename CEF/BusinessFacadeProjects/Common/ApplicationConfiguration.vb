Option Strict On
Option Explicit On 

Imports System
Imports System.Diagnostics
Imports System.Configuration
Imports System.Collections
Imports System.Xml
Imports System.Collections.Specialized

Namespace CEF.Common

    Public Class ApplicationConfiguration
        Implements IConfigurationSectionHandler

        'Carga de parametros definidos en el archivo de configuración de aplicación Web.Config
        'Ver el tag <ApplicationConfiguration>

        Private Const EVENTLOG_ENABLED As String = "SystemFrameworks.EventLog.Enabled"
        Private Const EVENTLOG_MACHINENAME As String = "SystemFrameworks.EventLog.Machine"
        Private Const EVENTLOG_SOURCENAME As String = "SystemFrameworks.EventLog.SourceName"
        Private Const EVENTLOG_TRACELEVEL As String = "SystemFrameworks.EventLog.LogLevel"

        Private Shared fieldEventLogEnabled As Boolean
        Private Shared fieldEventLogMachineName As String
        Private Shared fieldEventLogSourceName As String
        Private Shared fieldEventLogTraceLevel As TraceLevel

        'Contendra el directorio de la aplicación cargado desde el procedimiento OnApplicationStart

        Private Shared fieldAppRoot As String

        'Valor predeterminado de los parametros de configuración en caso no fueron definidos en el 
        'archivo de configuración de aplicación Web.Config.

        Private Const EVENTLOG_ENABLED_DEFAULT As Boolean = True
        Private Const EVENTLOG_MACHINENAME_DEFAULT As String = "."
        Private Const EVENTLOG_SOURCENAME_DEFAULT As String = "WebApplication"
        Private Const EVENTLOG_TRACELEVEL_DEFAULT As TraceLevel = TraceLevel.Error

        Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal section As System.Xml.XmlNode) As Object Implements IConfigurationSectionHandler.Create

            Dim settings As NameValueCollection

            Try
                Dim baseHandler As NameValueSectionHandler
                baseHandler = New NameValueSectionHandler
                settings = CType(baseHandler.Create(parent, configContext, section), NameValueCollection)
            Catch
            End Try
            If settings Is Nothing Then
                fieldEventLogEnabled = EVENTLOG_ENABLED_DEFAULT
                fieldEventLogMachineName = EVENTLOG_MACHINENAME_DEFAULT
                fieldEventLogSourceName = EVENTLOG_SOURCENAME_DEFAULT
                fieldEventLogTraceLevel = EVENTLOG_TRACELEVEL_DEFAULT
                Exit Function
            Else
                fieldEventLogEnabled = ReadSetting(settings, EVENTLOG_ENABLED, EVENTLOG_ENABLED_DEFAULT)
                fieldEventLogMachineName = ReadSetting(settings, EVENTLOG_MACHINENAME, EVENTLOG_MACHINENAME_DEFAULT)
                fieldEventLogSourceName = ReadSetting(settings, EVENTLOG_SOURCENAME, EVENTLOG_SOURCENAME_DEFAULT)
                fieldEventLogTraceLevel = ReadSetting(settings, EVENTLOG_TRACELEVEL, EVENTLOG_TRACELEVEL_DEFAULT)
            End If

        End Function

        '----------------------------------------------------------------
        ' String version of ReadSetting
        '----------------------------------------------------------------
        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As String) As String
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CStr(setting)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function

        '----------------------------------------------------------------
        ' Boolean version of ReadSetting
        '----------------------------------------------------------------
        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As Boolean) As Boolean
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CBool(setting)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function

        '----------------------------------------------------------------
        ' Long version of ReadSetting
        '----------------------------------------------------------------
        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As Integer) As Integer
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CInt(setting)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function

        '----------------------------------------------------------------
        ' TraceLevel version of ReadSetting
        '----------------------------------------------------------------
        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As TraceLevel) As TraceLevel
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CType(CInt(setting), TraceLevel)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function

        '----------------------------------------------------------------
        ' Shared Sub OnApplicationStart:
        '   Function to be called by Application_OnStart as described in the
        '     class description. Initializes the application root.
        ' Parameters:
        '   [in] AppRoot: The path of the running application.
        '----------------------------------------------------------------
        Public Shared Sub OnApplicationStart(ByVal AppRoot As String)
            fieldAppRoot = AppRoot
            System.Configuration.ConfigurationSettings.GetConfig("ApplicationConfiguration")
            System.Configuration.ConfigurationSettings.GetConfig("CEFConfiguration")
        End Sub

        '----------------------------------------------------------------
        ' Shared Property Get AppRoot:
        '   Retrieve the root path of the application
        ' Returns:
        '   Path
        '----------------------------------------------------------------
        Public Shared ReadOnly Property AppRoot() As String
            Get
                AppRoot = fieldAppRoot
            End Get
        End Property

        '----------------------------------------------------------------
        ' Shared Property Get EventLogEnabled:
        '   Retrieve whether writing to the event log is support, defaults to True
        ' Returns:
        '   True if writing to the event log is enabled
        '----------------------------------------------------------------
        Public Shared ReadOnly Property EventLogEnabled() As Boolean
            Get
                EventLogEnabled = fieldEventLogEnabled
            End Get
        End Property

        '----------------------------------------------------------------
        ' Shared Property Get EventLogMachineName:
        '   Retrieve the machine name to log the event to, defaults to an
        '     empty string, indicating the current machine.
        ' Returns:
        '   A machine name (without \\), may be empty
        '----------------------------------------------------------------
        Public Shared ReadOnly Property EventLogMachineName() As String
            Get
                EventLogMachineName = fieldEventLogMachineName
            End Get
        End Property

        '----------------------------------------------------------------
        ' Shared Property Get EventLogSourceName:
        '   The source of the error to be written to the event log, defaults
        '     WebApplication.
        ' Returns:
        '   String
        '----------------------------------------------------------------
        Public Shared ReadOnly Property EventLogSourceName() As String
            Get
                EventLogSourceName = fieldEventLogSourceName
            End Get
        End Property

        '----------------------------------------------------------------
        ' Shared Property Get EventLogTraceLevel:
        '   The highest logging level that should be written to the event log,
        '     defaults to TraceLevel.Error.
        ' Returns:
        '   TraceLevel
        '----------------------------------------------------------------
        Public Shared ReadOnly Property EventLogTraceLevel() As TraceLevel
            Get
                EventLogTraceLevel = fieldEventLogTraceLevel
            End Get
        End Property

    End Class

End Namespace