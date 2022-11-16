'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
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

    Public Interface IPeriodoCorrida
        Function leer(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As DataSet
        Function listar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As DataSet
        Function agregar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean
        Function modificar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean
        Function eliminar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean
    End Interface

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.Required), _
    Transaction(TransactionOption.Required)> _
    Public Class PeriodoCorrida
        Inherits DAO
        Implements IPeriodoCorrida

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function agregar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean Implements IPeriodoCorrida.agregar
            Dim voSProc As String = "up_PeriodoCorrida_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodo", SqlDbType.Int, 4), _
                        New SqlParameter("@argOrden", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argValidado", SqlDbType.Bit, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCorrida.Flag
                voParameters(1).Value = argPeriodoCorrida.Codmetodizado
                voParameters(2).Value = argPeriodoCorrida.Codcorrida
                voParameters(3).Value = argPeriodoCorrida.Codperiodo
                voParameters(4).Value = argPeriodoCorrida.Orden
                If argPeriodoCorrida.Validado Then
                    voParameters(5).Value = 1
                Else
                    voParameters(5).Value = 0
                End If
                voParameters(6).Value = argPeriodoCorrida.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean Implements IPeriodoCorrida.eliminar
            Dim voSProc As String = "up_PeriodoCorrida_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodo", SqlDbType.Int, 4), _
                        New SqlParameter("@argOrden", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argValidado", SqlDbType.Bit, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCorrida.Flag
                voParameters(1).Value = argPeriodoCorrida.CodMetodizado
                voParameters(2).Value = argPeriodoCorrida.CodCorrida
                voParameters(3).Value = argPeriodoCorrida.CodPeriodo
                voParameters(4).Value = argPeriodoCorrida.Orden
                If argPeriodoCorrida.Validado Then
                    voParameters(5).Value = 1
                Else
                    voParameters(5).Value = 0
                End If
                voParameters(6).Value = argPeriodoCorrida.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leer(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As System.Data.DataSet Implements IPeriodoCorrida.leer
            Dim voSProc As String = "up_PeriodoCorrida_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodo", SqlDbType.Int, 4), _
                        New SqlParameter("@argOrden", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argValidado", SqlDbType.Bit, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCorrida.Flag
                voParameters(1).Value = argPeriodoCorrida.CodMetodizado
                voParameters(2).Value = argPeriodoCorrida.CodCorrida
                voParameters(3).Value = argPeriodoCorrida.CodPeriodo
                voParameters(4).Value = argPeriodoCorrida.Orden
                If argPeriodoCorrida.Validado Then
                    voParameters(5).Value = 1
                Else
                    voParameters(5).Value = 0
                End If
                voParameters(6).Value = argPeriodoCorrida.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As System.Data.DataSet Implements IPeriodoCorrida.listar
            Dim voSProc As String = "up_PeriodoCorrida_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodo", SqlDbType.Int, 4), _
                        New SqlParameter("@argOrden", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argValidado", SqlDbType.Bit, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCorrida.Flag
                voParameters(1).Value = argPeriodoCorrida.CodMetodizado
                voParameters(2).Value = argPeriodoCorrida.CodCorrida
                voParameters(3).Value = argPeriodoCorrida.CodPeriodo
                voParameters(4).Value = argPeriodoCorrida.Orden
                If argPeriodoCorrida.Validado Then
                    voParameters(5).Value = 1
                Else
                    voParameters(5).Value = 0
                End If
                voParameters(6).Value = argPeriodoCorrida.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean Implements IPeriodoCorrida.modificar
            Dim voSProc As String = "up_PeriodoCorrida_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodo", SqlDbType.Int, 4), _
                        New SqlParameter("@argOrden", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argValidado", SqlDbType.Bit, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCorrida.Flag
                voParameters(1).Value = argPeriodoCorrida.CodMetodizado
                voParameters(2).Value = argPeriodoCorrida.CodCorrida
                voParameters(3).Value = argPeriodoCorrida.CodPeriodo
                voParameters(4).Value = argPeriodoCorrida.Orden
                If argPeriodoCorrida.Validado Then
                    voParameters(5).Value = 1
                Else
                    voParameters(5).Value = 0
                End If
                voParameters(6).Value = argPeriodoCorrida.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
    End Class
End Namespace
