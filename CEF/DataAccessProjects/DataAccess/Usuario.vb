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
    Public Class Usuario
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodUsuario As String) As DataSet
            Dim voSProc As String = "up_USUARIO_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10) _
                }
                voParameters(0).Value = pstrCodUsuario

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscar(ByRef pobeUsuario As BusinessEntity.Usuario) As System.Data.DataSet
            Dim voSProc As String = "up_USUARIO_BusGeneral_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombre", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodPerfil", SqlDbType.SmallInt), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                If pobeUsuario.CodUsuario <> String.Empty Then voParameters(0).Value = pobeUsuario.CodUsuario
                If pobeUsuario.Nombre <> String.Empty Then voParameters(1).Value = pobeUsuario.Nombre
                If pobeUsuario.CodPerfil <> Byte.MinValue Then voParameters(2).Value = pobeUsuario.CodPerfil
                If pobeUsuario.Estado <> System.Byte.MinValue Then voParameters(3).Value = pobeUsuario.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
            Dim voSProc As String = "up_USUARIO_Listar_Sel"
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
        Public Function agregar(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean
            Dim voSProc As String = "up_USUARIO_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombre", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argEmail", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodPerfil", SqlDbType.SmallInt), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argSupervisor", SqlDbType.Bit, 1) _
                }
                voParameters(0).Value = pobeUsuario.CodUsuario
                voParameters(1).Value = pobeUsuario.Nombre
                voParameters(2).Value = pobeUsuario.Email
                voParameters(3).Value = pobeUsuario.CodPerfil
                voParameters(4).Value = pobeUsuario.FecReg
                voParameters(5).Value = pobeUsuario.Estado
                voParameters(6).Value = pobeUsuario.bitSupervisor

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean
            Dim voSProc As String = "up_USUARIO_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombre", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argEmail", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodPerfil", SqlDbType.SmallInt), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argSupervisor", SqlDbType.Bit, 1) _
                }
                voParameters(0).Value = pobeUsuario.CodUsuario
                voParameters(1).Value = pobeUsuario.Nombre
                voParameters(2).Value = pobeUsuario.Email
                voParameters(3).Value = pobeUsuario.CodPerfil
                voParameters(4).Value = pobeUsuario.Estado
                voParameters(5).Value = pobeUsuario.bitSupervisor

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pstrCodUsuario As String) As Boolean
            Dim voSProc As String = "up_USUARIO_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10) _
                }
                voParameters(0).Value = pstrCodUsuario

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function responsableCarteraUsuario(ByVal pstrCodUsuario As String) As DataSet
            Dim voSProc As String = "up_CARTERAUSUARIO_Responsable_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUsuarioSubordinado", SqlDbType.NVarChar, 10) _
                }
                voParameters(0).Value = pstrCodUsuario

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarResponsableCarteraUsuario() As DataSet


            Dim voSProc As String = "up_CARTERAUSUARIO_ListarResponsable_Sel"
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
        Public Function listarSubordinadoCarteraUsuario(ByVal pstrCodUsuarioResponsable As String) As DataSet
            Dim voSProc As String = "up_CARTERAUSUARIO_ListarSubordinado_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUsuarioResponsable", SqlDbType.NVarChar, 10) _
                }
                voParameters(0).Value = pstrCodUsuarioResponsable

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarUsuarioPorAsignarCarteraUsuario(ByVal pstrCodUsuarioResponsable As String) As DataSet
            Dim voSProc As String = "up_CARTERAUSUARIO_UsuarioPorAsignar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodUsuarioResponsable", SqlDbType.NVarChar, 10) _
                }
                voParameters(0).Value = pstrCodUsuarioResponsable

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregarCarteraUsuario(ByRef pobeUsuario As BusinessEntity.Usuario) As DataSet
            Dim voSProc As String = "up_CARTERAUSUARIO_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCarteraUsuarioXML", SqlDbType.Text) _
                }
                voParameters(0).Value = pobeUsuario.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminarCarteraUsuario(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean
            Dim voSProc As String = "up_CARTERAUSUARIO_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCarteraUsuarioXML", SqlDbType.Text) _
                }
                voParameters(0).Value = pobeUsuario.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function


        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function listarResponsableCarteraUsuarioBPE() As DataSet


            Dim voSProc As String = "up_CARTERAUSUARIO_ListarResponsableBPE_Sel"
            Try
                Dim voParameters() As SqlParameter = Nothing

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function listarResponsableCarteraUsuarioNoBPE() As DataSet


            Dim voSProc As String = "up_CARTERAUSUARIO_ListarResponsableNoBPE_Sel"
            Try
                Dim voParameters() As SqlParameter = Nothing

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

    End Class

End Namespace