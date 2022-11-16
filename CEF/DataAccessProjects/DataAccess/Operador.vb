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
    Public Class Operador
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodOperador As Integer) As DataSet
            Dim voSProc As String = "up_OPERADOR_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodOperador", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodOperador

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
            Dim voSProc As String = "up_OPERADOR_Listar_Sel"
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
        Public Function agregar(ByRef pobeOperador As BusinessEntity.Operador) As Boolean
            Dim voSProc As String = "up_OPERADOR_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodOperador", SqlDbType.SmallInt), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 50), _
                        New SqlParameter("@argSimbolo", SqlDbType.Char, 1), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Direction = ParameterDirection.Output
                voParameters(1).Value = pobeOperador.Descripcion
                voParameters(2).Value = pobeOperador.Simbolo
                voParameters(3).Value = pobeOperador.FecReg
                voParameters(4).Value = pobeOperador.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(0).Value Is DBNull.Value) Then
                        pobeOperador.CodOperador = Convert.ToInt32(voParameters(0).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeOperador As BusinessEntity.Operador) As Boolean
            Dim voSProc As String = "up_OPERADOR_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodOperador", SqlDbType.SmallInt), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 50), _
                        New SqlParameter("@argSimbolo", SqlDbType.Char, 1), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobeOperador.CodOperador
                voParameters(1).Value = pobeOperador.Descripcion
                voParameters(2).Value = pobeOperador.Simbolo
                voParameters(3).Value = pobeOperador.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodOperador As Integer) As Boolean
            Dim voSProc As String = "up_OPERADOR_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodOperador", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodOperador

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