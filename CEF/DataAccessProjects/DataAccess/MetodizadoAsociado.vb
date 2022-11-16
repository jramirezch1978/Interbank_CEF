'*************************************************************
'Proposito:
'Autor: XT8633
'Fecha Creacion:24-10-2019
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices

Imports CEF.Common
Imports System.Reflection

Namespace CEF.DataAccess

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.Required), _
    Transaction(TransactionOption.Required)> _
   Public Class MetodizadoAsociado
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listar(ByRef pintCodMetodizado As Integer) As DataSet
            Dim voSProc As String = "up_METODIZADOCLIENTEASOCIADO_Lst"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@CodMetodizado", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodMetodizado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarCliente(ByRef pstrFiltro As String) As DataSet
            Dim voSProc As String = "up_RMCLIENTE_Lst"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@pstrFiltro", SqlDbType.VarChar) _
                }
                voParameters(0).Value = pstrFiltro

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Function agregar(ByRef pintCodmetodizado As Integer, ByRef psrtCodUnico As String) As String
            Dim voSProc As String = "up_METODIZADOCLIENTEASOCIADO_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@CodMetodizado", SqlDbType.Int), _
                    New SqlParameter("@CUCliente", SqlDbType.VarChar, 10), _
                    New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0), _
                    New SqlParameter("@outMsg", SqlDbType.VarChar, 500, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = pintCodmetodizado
                voParameters(1).Value = psrtCodUnico
                voParameters(2).Direction = ParameterDirection.Output
                voParameters(3).Direction = ParameterDirection.Output

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Dim outVal As Int32 = -1
                Dim outMsg As String = ""

                If voRC Then
                    If (Not voParameters(2).Value Is DBNull.Value) Then
                        outVal = Convert.ToInt32(voParameters(2).Value)
                        If (outVal <> 0) Then
                            If (Not voParameters(3).Value Is DBNull.Value) Then
                                outMsg = Convert.ToString(voParameters(3).Value)
                            End If
                        End If
                    End If
                End If

                Return (outMsg)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef pintCodmetodizado As Integer, ByRef pstrCodUnico As String) As Integer
            Dim voSProc As String = "up_METODIZADOCLIENTEASOCIADO_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@CodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@CUCliente", SqlDbType.NVarChar ,10), _
                        New SqlParameter("@outVal", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pintCodmetodizado
                voParameters(1).Value = pstrCodUnico
                voParameters(2).Direction = ParameterDirection.Output


                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Dim intReturn As Integer
                If voRC Then
                    If (Not voParameters(2).Value Is DBNull.Value) Then
                        intReturn = Convert.ToInt32(voParameters(2).Value)
                    End If
                End If
                Return (intReturn)

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
    End Class
End Namespace
