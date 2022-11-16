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
Imports CEF.Common
Imports System.Reflection

Namespace CEF.DataAccess

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.Required), _
    Transaction(TransactionOption.Required)> _
    Public Class General
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodTbl As Integer, ByVal pintCodItem As Integer) As DataSet
            Dim voSProc As String = "up_General_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodTbl", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodItem", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodTbl
                voParameters(1).Value = pintCodItem

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pintCodTbl As Integer) As DataSet
            Dim voSProc As String = "up_General_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodTbl", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodTbl

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeGeneral As BusinessEntity.General) As Boolean
            Dim voSProc As String = "up_General_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodTbl", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodItem", SqlDbType.SmallInt), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argDesCorta", SqlDbType.NVarChar, 50), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobeGeneral.CodTbl
                voParameters(1).Value = pobeGeneral.CodItem
                voParameters(2).Value = pobeGeneral.Descripcion
                voParameters(3).Value = pobeGeneral.DesCorta
                voParameters(4).Value = pobeGeneral.FecReg
                voParameters(5).Value = pobeGeneral.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeGeneral As BusinessEntity.General) As Boolean
            Dim voSProc As String = "up_General_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodTbl", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodItem", SqlDbType.SmallInt), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argDesCorta", SqlDbType.NVarChar, 50), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobeGeneral.CodTbl
                voParameters(1).Value = pobeGeneral.CodItem
                voParameters(2).Value = pobeGeneral.Descripcion
                voParameters(3).Value = pobeGeneral.DesCorta
                voParameters(4).Value = pobeGeneral.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodTbl As Integer, ByVal pintCodItem As Integer) As Boolean
            Dim voSProc As String = "up_General_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodTbl", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodItem", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodTbl
                voParameters(1).Value = pintCodItem

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