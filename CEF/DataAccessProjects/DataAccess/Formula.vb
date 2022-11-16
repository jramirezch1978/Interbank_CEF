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
    Transaction(TransactionOption.Required)> _
    Public Class Formula
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
            Dim voSProc As String = "up_FORMULA_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pbytFlag
                voParameters(1).Value = pbytEstado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarPorAnalisis(ByVal pintCodAnalisis As Integer) As DataSet
            Dim voSProc As String = "up_FORMULA_BuscarXAnalisis_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAnalisis", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodAnalisis

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarEnCuentaPorAnalisis(ByVal pintCodAnalisis As Integer, ByVal pintFlgBPE As Integer) As DataSet
            Dim voSProc As String = "up_FORMULA_BuscarEnCuentaXAnalisis_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAnalisis", SqlDbType.SmallInt), _
                        New SqlParameter("@argFlgBPE", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodAnalisis
                voParameters(1).Value = pintFlgBPE

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarSentencia(ByVal pintCodFormula As Integer) As DataSet
            Dim voSProc As String = "up_SENTENCIA_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodFormula", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodFormula

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarSentenciaPorAnalisis(ByVal pintCodAnalisis As Integer) As DataSet
            Dim voSProc As String = "up_SENTENCIA_BuscarXAnalisis_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAnalisis", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodAnalisis

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

    End Class

End Namespace