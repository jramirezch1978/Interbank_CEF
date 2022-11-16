'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:14/01/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.BusinessEntity
Imports CEF.Common
Imports System.Reflection

Namespace CEF.DataAccess

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.Required), _
    Transaction(TransactionOption.NotSupported)> _
    Public Class Cliente
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodigoUnico As String) As DataSet
            Dim voSProc As String = "up_CEF_RNTA_Cliente_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodigoUnico", SqlDbType.Char, 10) _
                }
                voParameters(0).Value = pstrCodigoUnico

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveRNT)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters, 300))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarXNumeroDocumento(ByVal pstrTipoDocumentoIdentidad As String, ByVal pstrNumeroDocumentoIdentidad As String) As DataSet
            Dim voSProc As String = "up_CEF_RNTA_Cliente_BuscarXNumeroDocumento_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argTipoDocumentoIdentidad", SqlDbType.Char, 1), _
                        New SqlParameter("@argNumeroDocumentoIdentidad", SqlDbType.Char, 11) _
                }
                voParameters(0).Value = pstrTipoDocumentoIdentidad
                voParameters(1).Value = pstrNumeroDocumentoIdentidad

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveRNT)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leerRegOmaesSunat(ByVal pstrRucCliente As String) As DataSet
            Dim voSProc As String = "up_CEF_ConsultaRuc_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argOUT_IFX_DPC_NUMRUC", SqlDbType.Char, 11) _
                }
                voParameters(0).Value = pstrRucCliente

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveMON)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        'ADD XT8633 01062021 INICIO
        <AutoComplete(True)> _
        Public Function ConsultaEEFFxCliente(ByVal pstrCodigoUnico As String, ByVal pstrTipoDocumentoIdentidad As Integer, ByVal pstrNumeroDocumentoIdentidad As String) As DataSet
            Dim voSProc As String = "up_CEF_WS_ConsultaEEFFxCliente"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUnico", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argTipoDocumento", SqlDbType.Int), _
                        New SqlParameter("@argNumeroDocumento", SqlDbType.NVarChar, 11) _
                }
                voParameters(0).Value = pstrCodigoUnico
                voParameters(1).Value = pstrTipoDocumentoIdentidad
                voParameters(2).Value = pstrNumeroDocumentoIdentidad

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
        'ADD XT8633 01062021 FIN

    End Class

End Namespace