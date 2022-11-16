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

    Public Interface ICorridaMetodizado
        Function leer(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As DataSet
        Function listar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As DataSet
        Function agregar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean
        Function modificar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean
        Function eliminar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean
    End Interface

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.Required), _
    Transaction(TransactionOption.Required)> _
    Public Class CorridaMetodizado
        Inherits DAO
        Implements ICorridaMetodizado

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function agregar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean Implements ICorridaMetodizado.agregar
            Dim voSProc As String = "up_CorridaMetodizado_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                       New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodMoneda", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodUsuarioReg", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argCodUsuarioUpd", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecUpd", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argCodOrigenCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argXML", SqlDbType.NText, 0), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argCorridaMetodizado.Flag
                voParameters(1).Value = argCorridaMetodizado.CodMetodizado
                voParameters(2).Direction = ParameterDirection.InputOutput
                voParameters(2).Value = argCorridaMetodizado.CodCorrida
                voParameters(3).Value = argCorridaMetodizado.CodMoneda
                voParameters(4).Value = argCorridaMetodizado.CodUsuarioReg
                voParameters(5).Value = argCorridaMetodizado.FecReg
                voParameters(6).Value = argCorridaMetodizado.CodUsuarioUpd
                voParameters(7).Value = argCorridaMetodizado.FecUpd
                voParameters(8).Value = argCorridaMetodizado.Estado
                voParameters(9).Value = argCorridaMetodizado.CodOrigenCorrida
                voParameters(10).Value = argCorridaMetodizado.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(2).Value Is DBNull.Value) Then
                        argCorridaMetodizado.CodCorrida = Convert.ToInt32(voParameters(2).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean Implements ICorridaMetodizado.eliminar
            Dim voSProc As String = "up_CorridaMetodizado_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodMoneda", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodUsuarioReg", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argCodUsuarioUpd", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecUpd", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argCodOrigenCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argCorridaMetodizado.Flag
                voParameters(1).Value = argCorridaMetodizado.CodMetodizado
                voParameters(2).Value = argCorridaMetodizado.CodCorrida
                voParameters(3).Value = argCorridaMetodizado.CodMoneda
                voParameters(4).Value = argCorridaMetodizado.CodUsuarioReg
                voParameters(5).Value = argCorridaMetodizado.FecReg
                voParameters(6).Value = argCorridaMetodizado.CodUsuarioUpd
                voParameters(7).Value = argCorridaMetodizado.FecUpd
                voParameters(8).Value = argCorridaMetodizado.Estado
                voParameters(9).Value = argCorridaMetodizado.CodOrigenCorrida

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leer(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As System.Data.DataSet Implements ICorridaMetodizado.leer
            Dim voSProc As String = "up_CorridaMetodizado_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodMoneda", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodUsuarioReg", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argCodUsuarioUpd", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecUpd", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argCodOrigenCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argXML", SqlDbType.NText, 0), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argCorridaMetodizado.Flag
                voParameters(1).Value = argCorridaMetodizado.CodMetodizado
                voParameters(2).Value = argCorridaMetodizado.CodCorrida
                voParameters(3).Value = argCorridaMetodizado.CodMoneda
                voParameters(4).Value = argCorridaMetodizado.CodUsuarioReg
                voParameters(5).Value = argCorridaMetodizado.FecReg
                voParameters(6).Value = argCorridaMetodizado.CodUsuarioUpd
                voParameters(7).Value = argCorridaMetodizado.FecUpd
                voParameters(8).Value = argCorridaMetodizado.Estado
                voParameters(9).Value = argCorridaMetodizado.CodOrigenCorrida
                voParameters(10).Value = argCorridaMetodizado.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As System.Data.DataSet Implements ICorridaMetodizado.listar
            Dim voSProc As String = "up_CorridaMetodizado_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodMoneda", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodUsuarioReg", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argCodUsuarioUpd", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecUpd", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argCodOrigenCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argCorridaMetodizado.Flag
                voParameters(1).Value = argCorridaMetodizado.CodMetodizado
                voParameters(2).Value = argCorridaMetodizado.CodCorrida
                voParameters(3).Value = argCorridaMetodizado.CodMoneda
                voParameters(4).Value = argCorridaMetodizado.CodUsuarioReg
                'voParameters(5).Value = argCorridaMetodizado.FecReg
                voParameters(6).Value = argCorridaMetodizado.CodUsuarioUpd
                'voParameters(7).Value = argCorridaMetodizado.FecUpd
                voParameters(8).Value = argCorridaMetodizado.Estado
                voParameters(9).Value = argCorridaMetodizado.CodOrigenCorrida

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean Implements ICorridaMetodizado.modificar
            Dim voSProc As String = "up_CorridaMetodizado_Upd"
            Dim intTimeout As Integer = 180
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodMoneda", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodUsuarioReg", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argCodUsuarioUpd", SqlDbType.VarChar, 10), _
                        New SqlParameter("@argFecUpd", SqlDbType.DateTime, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argCodOrigenCorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argXML", SqlDbType.NText, 0), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argCorridaMetodizado.Flag
                voParameters(1).Value = argCorridaMetodizado.CodMetodizado
                voParameters(2).Value = argCorridaMetodizado.CodCorrida
                voParameters(3).Value = argCorridaMetodizado.CodMoneda
                voParameters(4).Value = argCorridaMetodizado.CodUsuarioReg
                voParameters(5).Value = argCorridaMetodizado.FecReg
                voParameters(6).Value = argCorridaMetodizado.CodUsuarioUpd
                voParameters(7).Value = argCorridaMetodizado.FecUpd
                voParameters(8).Value = argCorridaMetodizado.Estado
                voParameters(9).Value = argCorridaMetodizado.CodOrigenCorrida
                voParameters(10).Value = argCorridaMetodizado.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters, intTimeout)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

    End Class
End Namespace
