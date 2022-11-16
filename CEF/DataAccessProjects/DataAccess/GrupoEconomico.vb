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
    Transaction(TransactionOption.Supported)> _
    Public Class GrupoEconomico
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        '<AutoComplete(True)> _
        'Public Function leer(ByVal pstrCodGrupoEconomico As String) As DataSet
        '    Dim voSProc As String = "up_CEF_RNTA_GrupoEconomico_Sel"
        '    Try
        '        Dim voParameters() As SqlParameter = _
        '        { _
        '                New SqlParameter("@argCodigo", SqlDbType.Char, 4) _
        '        }
        '        voParameters(0).Value = pstrCodGrupoEconomico

        '        vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveRNT)
        '        Return (vcManejadoBD.traerDatos(voSProc, voParameters))
        '    Catch ex As Exception
        '        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
        '        Throw ex
        '    End Try
        'End Function

        '<AutoComplete(True)> _
        'Public Function listar() As DataSet
        '    Dim voSProc As String = "up_CEF_RNTA_GrupoEconomico_Listar_Sel"
        '    Try
        '        Dim voParameters() As SqlParameter = Nothing

        '        vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveRNT)
        '        Return (vcManejadoBD.traerDatos(voSProc, voParameters))
        '    Catch ex As Exception
        '        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
        '        Throw ex
        '    End Try
        'End Function

        '<AutoComplete(True)> _
        'Public Function buscarXNombre(ByVal pstrNombre As String) As DataSet
        '    Dim voSProc As String = "up_CEF_RNTA_GrupoEconomico_BuscarXNombre_Sel"
        '    Try
        '        Dim voParameters() As SqlParameter = _
        '        { _
        '                New SqlParameter("@argNombre", SqlDbType.NVarChar, 50) _
        '        }
        '        voParameters(0).Value = pstrNombre

        '        vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveRNT)
        '        Return (vcManejadoBD.traerDatos(voSProc, voParameters))
        '    Catch ex As Exception
        '        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
        '        Throw ex
        '    End Try
        'End Function

        ' MEJORAS CEF II
        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodGrupoEconomico As String) As DataSet
            Dim voSProc As String = "up_GRUPOECONOMICO_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4) _
                }
                voParameters(0).Value = pstrCodGrupoEconomico

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar() As DataSet
            Dim voSProc As String = "up_GRUPOECONOMICO_Lst"
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
        Public Function buscarXNombre(ByVal pstrNombre As String) As DataSet
            Dim voSProc As String = "up_GRUPOECONOMICO_Bus"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argNombre", SqlDbType.NVarChar, 50) _
                }
                voParameters(0).Value = pstrNombre

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeGrupoEconomico As BusinessEntity.GrupoEconomico) As Boolean
            Dim voSProc As String = "up_GRUPOECONOMICO_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argNombre", SqlDbType.NVarChar, 50) _
                }
                voParameters(0).Value = pobeGrupoEconomico.CodGrupoEconomico
                voParameters(1).Value = pobeGrupoEconomico.Nombre

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeGrupoEconomico As BusinessEntity.GrupoEconomico) As Boolean
            Dim voSProc As String = "up_GRUPOECONOMICO_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argNombre", SqlDbType.NVarChar, 50) _
                }
                voParameters(0).Value = pobeGrupoEconomico.CodGrupoEconomico
                voParameters(1).Value = pobeGrupoEconomico.Nombre

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