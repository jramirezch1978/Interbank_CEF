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
    Public Class CuentaAnalisis
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listar(ByVal pshoCodAnalisis As Short) As DataSet
            Dim voSProc As String = "up_CUENTAANALISIS_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAnalisis", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pshoCodAnalisis

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarMasCuentaLibre(ByVal pshoCodAnalisis As Short, ByVal pintCodMetodizado As Integer) As DataSet
            Dim voSProc As String = "up_CUENTAANALISIS_listarMasCuentaLibre_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAnalisis", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int) _
                }
                voParameters(0).Value = pshoCodAnalisis
                voParameters(1).Value = pintCodMetodizado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function ListarPorAnalisis(ByVal pshoCodAnalisis As Short, ByVal pintCodCuentaAnalisis As Integer, ByVal pshoIndicador As Short) As DataSet
            Dim voSProc As String = "up_CUENTAANALISIS_listarPorAnalisis_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodAnalisis", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodCuentaAnalisis", SqlDbType.Int), _
                        New SqlParameter("@argIndicador", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pshoCodAnalisis
                voParameters(1).Value = pintCodCuentaAnalisis
                voParameters(2).Value = pshoIndicador

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

    End Class

End Namespace