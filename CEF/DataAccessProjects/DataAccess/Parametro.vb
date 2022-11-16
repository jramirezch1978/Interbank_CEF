'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por: María Laura Santisteban Valdez
'Fecha Mod.: 28/03/2006
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
    Public Class Parametro
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodParametro As String) As DataSet
            Dim voSProc As String = "up_Parametro_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodParametro", SqlDbType.NVarChar, 20) _
                }
                voParameters(0).Value = pstrCodParametro

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar() As DataSet
            Dim voSProc As String = "up_Parametro_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = Nothing
                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeParametro As BusinessEntity.Parametro) As Boolean
            Dim voSProc As String = "up_Parametro_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodParametro", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argValor1", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argValor2", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobeParametro.CodParametro
                voParameters(1).Value = pobeParametro.Descripcion
                voParameters(2).Value = pobeParametro.Valor1
                voParameters(3).Value = pobeParametro.Valor2
                voParameters(4).Value = pobeParametro.FecReg
                voParameters(5).Value = pobeParametro.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeParametro As BusinessEntity.Parametro) As Boolean
            Dim voSProc As String = "up_Parametro_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodParametro", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argValor1", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argValor2", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobeParametro.CodParametro
                voParameters(1).Value = pobeParametro.Descripcion
                voParameters(2).Value = pobeParametro.Valor1
                voParameters(3).Value = pobeParametro.Valor2
                voParameters(4).Value = pobeParametro.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pstrCodParametro As String) As Boolean
            Dim voSProc As String = "up_Parametro_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodParametro", SqlDbType.NVarChar, 20) _
                }
                voParameters(0).Value = pstrCodParametro

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

    End Class

End Namespace
