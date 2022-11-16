'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: María Laura Santisteban Valdez
'Fecha Creacion:27/03/2006
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
    Public Class Auditor
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
       Public Function leer(ByVal pintCodAuditor As Integer) As DataSet
            Dim voSProc As String = "up_Auditor_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAuditor", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodAuditor

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
            Dim voSProc As String = "up_Auditor_Listar_Sel"
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
       Public Function agregar(ByRef pobeAuditor As BusinessEntity.Auditor) As Boolean
            Dim voSProc As String = "up_Auditor_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAuditor", SqlDbType.SmallInt), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Direction = ParameterDirection.Output
                voParameters(1).Value = pobeAuditor.RazonSocial
                voParameters(2).Value = pobeAuditor.FecReg
                voParameters(3).Value = pobeAuditor.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(0).Value Is DBNull.Value) Then
                        pobeAuditor.CodAuditor = Convert.ToInt32(voParameters(0).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
       Public Function modificar(ByRef pobeAuditor As BusinessEntity.Auditor) As Boolean
            Dim voSProc As String = "up_Auditor_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAuditor", SqlDbType.SmallInt), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobeAuditor.CodAuditor
                voParameters(1).Value = pobeAuditor.RazonSocial
                voParameters(2).Value = pobeAuditor.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
       Public Function eliminar(ByVal pintCodAuditor As Integer) As Boolean
            Dim voSProc As String = "up_Auditor_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAuditor", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodAuditor

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

