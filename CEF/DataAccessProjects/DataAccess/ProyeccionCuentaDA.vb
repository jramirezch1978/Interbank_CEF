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
    Public Class ProyeccionCuentaDA
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodMetodizado As Integer, ByVal pintCodProyeccion As Integer) As DataSet
            Dim voSProc As String = "up_PROYECCIONCUENTA_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@CODMETODIZADO", SqlDbType.Int), _
                    New SqlParameter("@CODPROYECCION", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = pintCodProyeccion

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function


    End Class
End Namespace
