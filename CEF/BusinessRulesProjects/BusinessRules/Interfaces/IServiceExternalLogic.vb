Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IServiceExternalLogic
        Function ClienteRMPorCodigoUnico(ByVal codigoUnico As String, ByVal serviceURL As String) As BusinessEntity.ClienteRM
        Function ClienteRMPorDocumentoIdentidad(ByVal tipoDocumentoIdentidad As String, ByVal numeroDocumentoIdentidad As String, ByVal serviceURL As String) As BusinessEntity.ClienteRM

        Function ClienteRCCPorDocumentoIdentidad(ByVal tipoDocumentoIdentidad As String, ByVal numeroDocumentoIdentidad As String, ByVal serviceURL As String) As String

    End Interface

End Namespace
