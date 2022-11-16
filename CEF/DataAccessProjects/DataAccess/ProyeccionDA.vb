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
    Public Class ProyeccionDA
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function Eliminar(ByVal pintCodProyeccion As Integer, ByVal pintCodMetodizado As Integer) As Boolean
            Dim voSproc As String = "up_PROYECCION_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@CODPROYECCION", SqlDbType.Int), _
                    New SqlParameter("@CODMETODIZADO", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodProyeccion
                voParameters(1).Value = pintCodMetodizado
                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSproc, voParameters)
                Return (voRC)

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function TraerDatosCabecera(ByVal pintcodMetodizado As Integer, ByVal pintcodProyeccion As Integer) As DataSet
            Dim voSproc As String = "up_PROYECCION_TraerDatosCabecera"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@CODMETODIZADO", SqlDbType.Int), _
                    New SqlParameter("@CODPROYECCION", SqlDbType.Int) _
                }
                voParameters(0).Value = pintcodMetodizado
                voParameters(1).Value = pintcodProyeccion

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSproc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leer(ByVal pintcodMetodizado As Integer) As DataSet
            Dim voSProc As String = "up_PROYECCION_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@CODMETODIZADO", SqlDbType.Int) _
                }
                voParameters(0).Value = pintcodMetodizado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function Grabar(ByVal proyeccion As CEF.BusinessEntity.ProyeccionBE) As Boolean
            Dim voSProc As String = "UP_PROYECCION_INS"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                  New SqlParameter("@ARGPROYECCIONXML", SqlDbType.Text) _
                }
                voParameters(0).Value = proyeccion.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return voRC
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function VerificarFechaProyeccion(ByVal pcodmetodizado As Integer, ByVal pfechaproyeccion As Date) As Boolean
            Dim voSProc As String = "up_VERIFICARFECHAPROYECCION"
            Try
                Dim voParameters() As SqlParameter = _
                                { _
                                  New SqlParameter("@CODMETODIZADO", SqlDbType.Int), _
                                  New SqlParameter("@FECHAPROYECCION", SqlDbType.DateTime) _
                                }
                voParameters(0).Value = pcodmetodizado
                voParameters(1).Value = pfechaproyeccion

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = CType(vcManejadoBD.traerDatos(voSProc, voParameters).Tables(0).Rows(0).Item(0), Boolean)
                Return voRC
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

    End Class
End Namespace
