Public Class constantesCommon

    Public Shared archivoConfiguracion As String = "cefCommonConfig.xml"

#Region "CODIGO"
    Public Shared RutaLog As String = "RutaLog"
    Public Shared RutaXMLConexion As String = "RutaXMLConexion"
    Public Shared RutaXMLMensajes As String = "RutaXMLMensajes"
    Public Shared RutaXMLImagenes As String = "RutaXMLImagenes"
    Public Shared IdAmbiente As String = "IdAmbiente"
    Public Shared ServidorWS As String = "ServidorWS"
    Public Shared ServidorSSRS As String = "ServidorSSRS"
    Public Shared RutaBaseReportes As String = "RutaBaseReportes"
    Public Shared RutaUrlCef As String = "RutaUrlCef"
    Public Shared RutaTemp As String = "RutaTemp"
    'MEJORAS CEF II
    Public Shared wsFCDRM As String = "wsFCDRM"
    Public Shared wsBPSRCC As String = "wsBPSRCC"


#End Region

#Region "SECCIONES CONFIGURACIÓN"
    Public Shared seccionAssemblySettings As String = "configuration/assemblySettings"
    Public Shared seccionCadenaConexionRTG As String = "Configuracion/CadenaConexion/CEF"
    Public Shared Servidor As String = "Server"
    Public Shared BaseDatos As String = "DataBase"
#End Region

#Region "LOG"

    Public Enum TipoLog
        Exito = 0
        Informativo = 1
        Advertencia = 2
        ErrorX = 3
        Fatal = 4
    End Enum

    Public Enum CodigoResponseJSON
        ErrorSesion = 5003
    End Enum
#End Region

#Region "WebServiceRM"

    'Mensaje de error
    Public Const ccALERTA_SERVICIORM_NOACTIVO As String = "Error al conectar con el servicio de búsqueda de clientes."


    'Constante Tipo Doc (TRX)
    Public Const C_TRX_TIPDOC_DNI As Integer = 1
    Public Const C_TRX_TIPDOC_RUC As Integer = 2
    Public Const C_TRX_TIPDOC_CE As Integer = 3
    Public Const C_TRX_TIPDOC_CI As Integer = 4
    Public Const C_TRX_TIPDOC_PA As Integer = 5

    'Enum tipo de documento CEF
    Public Enum eTipoDocumento
        NoTiene = 0
        RUC = 1
        DNI = 2
        CarnetExtranjeria = 3
        EmpresaRelacionada = 4
        Otros = 5
    End Enum
#End Region

End Class
