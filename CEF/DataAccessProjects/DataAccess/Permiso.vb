'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:15/08/2006
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
    Public Class Permiso
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pshoCodPermiso As Short) As DataSet
            Dim voSProc As String = "up_Permiso_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodPermiso", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pshoCodPermiso

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leerPermisoPerfil(ByVal pshoCodPermiso As Short, ByVal pshoCodPerfil As Short) As DataSet
            Dim voSProc As String = "up_PermisoPerfil_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodPermiso", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodPerfil", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pshoCodPermiso
                voParameters(1).Value = pshoCodPerfil

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

    End Class

End Namespace