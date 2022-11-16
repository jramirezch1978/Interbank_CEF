Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports System.Reflection

Imports CEF.Common

Namespace CEF.DataAccess


    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.Required), _
    Transaction(TransactionOption.Required)> _
    Public Class ServiceExternalData
        Inherits DAO
#Region "wsRM"

        Public Function fcdWS_bseFCDO002_fConsultarCliente(ByVal tipoConsulta As String, ByVal codigoUnico As String, ByVal tipoDocumentoIdentidad As String, ByVal numeroDocumentoIdentidad As String, ByVal tipoProducto As String, ByVal serviceURL As String) As String
            Try
                Using service As New wsRM.bseFCDO002
                    service.Url = serviceURL

                    Return service.fConsultarCliente(tipoConsulta, codigoUnico, tipoDocumentoIdentidad, numeroDocumentoIdentidad, tipoProducto)
                End Using
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")

                Throw ex
            End Try
        End Function

#End Region

#Region "wsRCC"
        Public Function bpsWS_wsRCC_fstrGet_CodigoSBS(ByVal tipoDocumentoIdentidad As String, ByVal numeroDocumentoIdentidad As String, ByVal serviceURL As String) As String
            Try
                Using service As New wsRCC.bpsWebService
                    service.Url = serviceURL
                    Return service.Get_CodigoSBS(tipoDocumentoIdentidad, numeroDocumentoIdentidad)
                End Using
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
#End Region
    End Class

End Namespace
