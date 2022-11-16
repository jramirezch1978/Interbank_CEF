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
    Public Class Cuenta
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodCuenta As Integer) As DataSet
            Dim voSProc As String = "up_Cuenta_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodCuenta", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodCuenta

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
            Dim voSProc As String = "up_Cuenta_Listar_Sel"
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
        Public Function agregar(ByRef pobeCuenta As BusinessEntity.Cuenta) As Boolean
            Dim voSProc As String = "up_Cuenta_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argCodCuenta", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodCuentaPadre", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodEeff", SqlDbType.SmallInt), _
                    New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                    New SqlParameter("@argCodTipoCuenta", SqlDbType.SmallInt.TinyInt), _
                    New SqlParameter("@argOrden", SqlDbType.SmallInt), _
                    New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                    New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Direction = ParameterDirection.Output
                voParameters(1).Value = pobeCuenta.CodCuentaPadre
                voParameters(2).Value = pobeCuenta.CodEeff
                voParameters(3).Value = pobeCuenta.Descripcion
                voParameters(4).Value = pobeCuenta.CodTipoCuenta
                voParameters(5).Value = pobeCuenta.Orden
                voParameters(6).Value = pobeCuenta.FecReg
                voParameters(7).Value = pobeCuenta.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(0).Value Is DBNull.Value) Then
                        pobeCuenta.CodCuenta = Convert.ToInt32(voParameters(0).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeCuenta As BusinessEntity.Cuenta) As Boolean
            Dim voSProc As String = "up_Cuenta_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argCodCuenta", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodCuentaPadre", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodEeff", SqlDbType.SmallInt), _
                    New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                    New SqlParameter("@argCodTipoCuenta", SqlDbType.SmallInt.TinyInt), _
                    New SqlParameter("@argOrden", SqlDbType.SmallInt), _
                    New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                    New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobeCuenta.CodCuenta
                voParameters(1).Value = pobeCuenta.CodCuentaPadre
                voParameters(2).Value = pobeCuenta.CodEeff
                voParameters(3).Value = pobeCuenta.Descripcion
                voParameters(4).Value = pobeCuenta.CodTipoCuenta
                voParameters(5).Value = pobeCuenta.Orden
                voParameters(6).Value = pobeCuenta.FecReg
                voParameters(7).Value = pobeCuenta.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodCuenta As Integer) As Boolean
            Dim voSProc As String = "up_Cuenta_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodCuenta", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodCuenta

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