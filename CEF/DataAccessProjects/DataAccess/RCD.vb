Imports System
Imports System.Xml
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
    Transaction(TransactionOption.Required)> _
    Public Class RCD
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listar(ByVal pintAnioPeriodo As Integer, ByVal pintMesPeriodo As Integer, ByVal pintDiaPeriodo As Integer) As DataSet
            Dim voSProc As String = "up_RCD_listar_sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argAnioPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argMesPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argDiaPeriodo", SqlDbType.Int) _
                }
                voParameters(0).Value = pintAnioPeriodo
                voParameters(1).Value = pintMesPeriodo
                voParameters(2).Value = pintDiaPeriodo

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

      
        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeRCD As BusinessEntity.RCD) As Boolean
            Dim voSProc As String = "up_RCD_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argAnioPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argMesPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argDiaPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argCUCliente", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argMontoDeudaSoles", SqlDbType.Decimal, 18), _
                        New SqlParameter("@argMontoDeudaDolares", SqlDbType.Decimal, 18), _
                        New SqlParameter("@argMontoContingente", SqlDbType.Decimal, 18), _
                        New SqlParameter("@argNombreEjecutivo", SqlDbType.NVarChar, 80) _
                }

                voParameters(0).Value = pobeRCD.AnioPeriodo
                voParameters(1).Value = pobeRCD.MesPeriodo
                voParameters(2).Value = pobeRCD.DiaPeriodo
                voParameters(3).Value = pobeRCD.CUCliente
                voParameters(4).Value = pobeRCD.RazonSocial
                voParameters(5).Value = pobeRCD.MontoDeudaSoles
                voParameters(6).Value = pobeRCD.MontoDeudaDolares
                voParameters(7).Value = pobeRCD.MontoContingente
                voParameters(8).Value = pobeRCD.NombreEjecutivo

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeRCD As BusinessEntity.RCD) As Boolean
            Dim voSProc As String = "up_RCD_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argAnioPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argMesPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argDiaPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argCUCliente", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argObservacion", SqlDbType.NVarChar, 255) _
                }

                voParameters(0).Value = pobeRCD.AnioPeriodo
                voParameters(1).Value = pobeRCD.MesPeriodo
                voParameters(2).Value = pobeRCD.DiaPeriodo
                voParameters(3).Value = pobeRCD.CUCliente
                voParameters(4).Value = pobeRCD.Observacion

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef pobeRCD As BusinessEntity.RCD) As Boolean
            Dim voSProc As String = "up_RCD_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argAnioPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argMesPeriodo", SqlDbType.Int), _
                        New SqlParameter("@argDiaPeriodo", SqlDbType.Int) _
                }

                voParameters(0).Value = pobeRCD.AnioPeriodo
                voParameters(1).Value = pobeRCD.MesPeriodo
                voParameters(2).Value = pobeRCD.DiaPeriodo

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function cruceEEFFValidados(ByVal pdteFecPeriodo As DateTime) As DataSet
            Dim voSProc As String = "up_RCD_CruceEEFFValidados"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime) _
                }
                voParameters(0).Value = pdteFecPeriodo

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

    End Class

End Namespace


