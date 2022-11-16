Option Strict On
Option Explicit On 

Imports System
Imports System.Collections
Imports System.Configuration
Imports CEF.SystemFrameworks
Imports System.Collections.Specialized

Namespace CEF.Common

    Public Class CEFConfiguration
        Implements IConfigurationSectionHandler

        'Carga de parametros definidos en el archivo de configuración de aplicación Web.Config
        'Ver el tag <ROCConfiguration>

        Private Const DATAACCESS_CONNECTIONSTRING As String = "CEF.DataAccess.ConnectionString"
        Private Const WEB_ENABLEPAGECACHE As String = "CEF.WebUI.EnablePageCache"
        Private Const WEB_PAGECACHEEXPIRESINSECONDS As String = "CEF.WebUI.PageCacheExpiresInSeconds"
        Private Const WEB_ENABLESSL As String = "CEF.WebUI.EnableSsl"

        Private Shared fieldConnectionString As String
        Private Shared fieldPageCacheExpiresInSeconds As Integer
        Private Shared fieldEnablePageCache As Boolean
        Private Shared fieldEnableSsl As Boolean

        'Valor predeterminado de los parametros de configuración en caso no fueron definidos en el 
        'archivo de configuración de aplicación Web.Config.

        Private Const DATAACCESS_CONNECTIONSTRING_DEFAULT As String = "CadenaConexion"
        Private Const WEB_ENABLEPAGECACHE_DEFAULT As Boolean = True
        Private Const WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT As Integer = 3600
        Private Const WEB_ENABLESSL_DEFAULT As Boolean = False

        Public Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal input As Xml.XmlNode) As Object Implements IConfigurationSectionHandler.Create
            Dim settings As NameValueCollection

            Try
                Dim baseHandler As NameValueSectionHandler
                baseHandler = New NameValueSectionHandler
                settings = CType(baseHandler.Create(parent, configContext, input), NameValueCollection)
            Catch
            End Try

            If settings Is Nothing Then
                fieldConnectionString = DATAACCESS_CONNECTIONSTRING_DEFAULT
                fieldPageCacheExpiresInSeconds = WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT
                fieldEnablePageCache = WEB_ENABLEPAGECACHE_DEFAULT
                fieldEnableSsl = WEB_ENABLESSL_DEFAULT
            Else
                fieldConnectionString = ApplicationConfiguration.ReadSetting(settings, DATAACCESS_CONNECTIONSTRING, DATAACCESS_CONNECTIONSTRING_DEFAULT)
                fieldPageCacheExpiresInSeconds = ApplicationConfiguration.ReadSetting(settings, WEB_PAGECACHEEXPIRESINSECONDS, WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT)
                fieldEnablePageCache = ApplicationConfiguration.ReadSetting(settings, WEB_ENABLEPAGECACHE, WEB_ENABLEPAGECACHE_DEFAULT)
                fieldEnableSsl = ApplicationConfiguration.ReadSetting(settings, WEB_ENABLESSL, WEB_ENABLESSL_DEFAULT)
            End If
        End Function

        Public Shared ReadOnly Property EnablePageCache() As Boolean
            Get
                EnablePageCache = fieldEnablePageCache
            End Get
        End Property

        Public Shared ReadOnly Property PageCacheExpiresInSeconds() As Integer
            Get
                PageCacheExpiresInSeconds = fieldPageCacheExpiresInSeconds
            End Get
        End Property

        Public Shared ReadOnly Property ConnectionString() As String
            Get
                ConnectionString = fieldConnectionString
            End Get
        End Property

        Public Shared ReadOnly Property EnableSsl() As Boolean
            Get
                EnableSsl = fieldEnableSsl
            End Get
        End Property

    End Class

End Namespace

