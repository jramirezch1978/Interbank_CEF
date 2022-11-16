Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.Common
Imports CEF.BusinessEntity
Imports System.Reflection

Namespace CEF.DataAccess

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.Required), _
    Transaction(TransactionOption.Required)> _
    Public Class Supuesto
        Inherits DAO

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodSupuesto As Integer) As DataSet
            Dim voSProc As String = "up_SUPUESTO_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodSupuesto

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarPorPeriodo(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As DataSet
            Dim voSProc As String = "up_SUPUESTO_BuscarXPeriodo_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodPeriodo", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = pintCodPeriodo

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean
            Dim voSProc As String = "up_SUPUESTO_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int), _
                        New SqlParameter("@argSupuestoXML", SqlDbType.Text) _
                }
                voParameters(0).Direction = ParameterDirection.Output
                voParameters(1).Value = pobeSupuesto.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(0).Value Is DBNull.Value) Then
                        pobeSupuesto.CodSupuesto = Convert.ToInt32(voParameters(0).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean
            Dim voSProc As String = "up_SUPUESTO_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int), _
                        New SqlParameter("@argSupuestoXML", SqlDbType.Text) _
                }
                voParameters(0).Direction = ParameterDirection.Output
                voParameters(1).Value = pobeSupuesto.PasarAXml()



                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(0).Value Is DBNull.Value) Then
                        pobeSupuesto.CodSupuesto = Convert.ToInt32(voParameters(0).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodSupuesto As Integer) As Boolean
            Dim voSProc As String = "up_SUPUESTO_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodSupuesto

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregarSupuestoProyectado(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean
            Dim voSProc As String = "up_SUPUESTOPROYECTADO_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argSupuestoXML", SqlDbType.Text) _
                }
                voParameters(0).Value = pobeSupuesto.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarCuentaSupuesto(ByVal pintCodSupuesto As Integer) As DataSet
            Dim voSProc As String = "up_CUENTASUPUESTO_ListarXSupuesto_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodSupuesto

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarPeriodoProyectado(ByVal pintCodSupuesto As Integer) As DataSet
            Dim voSProc As String = "up_PERIODOPROYECTADO_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodSupuesto

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarSupuestoProyectado(ByVal pintCodSupuesto As Integer, ByVal pintCodProyectado As Integer) As DataSet
            Dim voSProc As String = "up_SUPUESTOPROYECTADO_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int), _
                        New SqlParameter("@argCodProyectado", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodSupuesto
                voParameters(1).Value = pintCodProyectado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function calcularSupuestoHistoricoInicial(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer, ByVal pintCodPeriodoAnterior As Integer) As DataSet
            Dim voSProc As String = "up_SUPUESTOHISTORICO_CalcularImporteInicial_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodPeriodo", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodPeriodoAnterior", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = pintCodPeriodo
                voParameters(2).Value = pintCodPeriodoAnterior

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function filtrarSupuestoProyectado(ByVal pintCodSupuesto As Integer) As DataSet
            Dim voSProc As String = "up_SUPUESTOPROYECTADO_Filtrar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodSupuesto

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function filtrarFlujoProyectado(ByVal pintCodSupuesto As Integer) As DataSet
            Dim voSProc As String = "up_FLUJOPROYECTADO_Filtrar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodSupuesto", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodSupuesto

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace
