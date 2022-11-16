'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro
'Fecha Creacion:14/01/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports System.Xml.Serialization
Imports CEF.Common
Imports CEF.BusinessEntity
Imports System.Reflection

Namespace CEF.DataAccess

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.Required), _
    Transaction(TransactionOption.Required)> _
    Public Class Metodizado
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodMetodizado As Integer) As DataSet
            Dim voSProc As String = "up_Metodizado_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodMetodizado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function


        <AutoComplete(True)> _
        Public Function buscar(ByRef pobeMetodizadoBus As BusinessEntity.MetodizadoBus) As DataSet
            Dim voSProc As String = "up_Metodizado_BusGeneral_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCUCliente", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argRUC", SqlDbType.NVarChar, 11), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodCIIU", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodAnalista", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argCodEjecutivo", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argFecInicio", SqlDbType.DateTime), _
                        New SqlParameter("@argFecFin", SqlDbType.DateTime), _
                        New SqlParameter("@argTipoDocumento", SqlDbType.TinyInt) _
                }
                If pobeMetodizadoBus.CUCliente <> String.Empty Then voParameters(0).Value = pobeMetodizadoBus.CUCliente
                If pobeMetodizadoBus.NumeroDocumento <> String.Empty Then voParameters(1).Value = pobeMetodizadoBus.NumeroDocumento
                If pobeMetodizadoBus.RazonSocial <> String.Empty Then voParameters(2).Value = pobeMetodizadoBus.RazonSocial
                If pobeMetodizadoBus.CodCIIU <> String.Empty Then voParameters(3).Value = pobeMetodizadoBus.CodCIIU
                If pobeMetodizadoBus.CodGrupoEconomico <> String.Empty Then voParameters(4).Value = pobeMetodizadoBus.CodGrupoEconomico
                If pobeMetodizadoBus.CodAnalista <> String.Empty Then voParameters(5).Value = pobeMetodizadoBus.CodAnalista
                If pobeMetodizadoBus.CodEjecutivo <> String.Empty Then voParameters(6).Value = pobeMetodizadoBus.CodEjecutivo
                If pobeMetodizadoBus.Estado <> Byte.MinValue Then voParameters(7).Value = pobeMetodizadoBus.Estado

                If pobeMetodizadoBus.FecInicio <> DateTime.MinValue Then
                    voParameters(8).Value = pobeMetodizadoBus.FecInicio
                End If

                If pobeMetodizadoBus.FecFin <> DateTime.MinValue Then
                    voParameters(9).Value = pobeMetodizadoBus.FecFin
                End If

                If pobeMetodizadoBus.TipoDocumento <> Byte.MinValue Then voParameters("10").Value = pobeMetodizadoBus.TipoDocumento

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        ' 24/01/2014 XT5022 JAVILA (CGI)
        ' AGREGANDO PARAMETRO FLGBPE
        <AutoComplete(True)> _
        Public Function buscarClienteDuplicado(ByRef pobeMetodizadoBus As BusinessEntity.MetodizadoBus, ByVal pflgBpe As Integer) As DataSet
            Dim voSProc As String = "up_Metodizado_BusClienteDuplicado_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCUCliente", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argTipoDocumento", SqlDbType.TinyInt), _
                        New SqlParameter("@argNumeroDocumento", SqlDbType.NVarChar, 11), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodCIIU", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodAnalista", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argCodEjecutivo", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argFecInicio", SqlDbType.DateTime), _
                        New SqlParameter("@argFecFin", SqlDbType.DateTime), _
                        New SqlParameter("@argFlgBPE", SqlDbType.Int) _
                }
                If pobeMetodizadoBus.CUCliente <> String.Empty Then voParameters(0).Value = pobeMetodizadoBus.CUCliente
                If pobeMetodizadoBus.TipoDocumento <> Byte.MinValue Then voParameters(1).Value = pobeMetodizadoBus.TipoDocumento
                If pobeMetodizadoBus.NumeroDocumento <> String.Empty Then voParameters(2).Value = pobeMetodizadoBus.NumeroDocumento
                If pobeMetodizadoBus.RazonSocial <> String.Empty Then voParameters(3).Value = pobeMetodizadoBus.RazonSocial
                If pobeMetodizadoBus.CodCIIU <> String.Empty Then voParameters(4).Value = pobeMetodizadoBus.CodCIIU
                If pobeMetodizadoBus.CodGrupoEconomico <> String.Empty Then voParameters(5).Value = pobeMetodizadoBus.CodGrupoEconomico
                If pobeMetodizadoBus.CodAnalista <> String.Empty Then voParameters(6).Value = pobeMetodizadoBus.CodAnalista
                If pobeMetodizadoBus.CodEjecutivo <> String.Empty Then voParameters(7).Value = pobeMetodizadoBus.CodEjecutivo
                If pobeMetodizadoBus.Estado <> Byte.MinValue Then voParameters(8).Value = pobeMetodizadoBus.Estado

                If pobeMetodizadoBus.FecInicio <> DateTime.MinValue Then
                    voParameters(9).Value = pobeMetodizadoBus.FecInicio
                End If

                If pobeMetodizadoBus.FecFin <> DateTime.MinValue Then
                    voParameters(10).Value = pobeMetodizadoBus.FecFin
                End If

                'voParameters(11).Value = pflgBpe
                If pflgBpe <> Byte.MinValue Then voParameters(11).Value = pflgBpe

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))

                ' Temporal - Borrar (Inicio) =======================================================================================================================
                Try
                    Throw New Exception("DataAccess.Metodizado.buscarClienteDuplicado")
                Catch ex As Exception
                    Dim strRuta As String = Common.Assemblys.leerUbicacion(System.Reflection.Assembly.GetExecutingAssembly.Location)
                    Dim objErrorLog As New Common.ErrorLog(strRuta & ccARCHIVO_LOG)
                    objErrorLog.saveExceptionToLog(ex)
                End Try
                ' Temporal - Borrar (Final) ========================================================================================================================

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeMetodizado As BusinessEntity.Metodizado) As Boolean
            Dim voSProc As String = "up_Metodizado_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCUCliente", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argTipoDocumento", SqlDbType.TinyInt, 11), _
                        New SqlParameter("@argNumeroDocumento", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodCIIU", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodSBS", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argNombreGrupoEconomico", SqlDbType.NVarChar, 50), _
                        New SqlParameter("@argCodMoneda", SqlDbType.TinyInt), _
                        New SqlParameter("@argCodUnidad", SqlDbType.TinyInt), _
                        New SqlParameter("@argCodAnalista", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreAnalista", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodEjecutivo", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreEjecutivo", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodMonedaImpresion", SqlDbType.TinyInt), _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreUsuario", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argFlgBPE", SqlDbType.Int), _
                        New SqlParameter("@argSegmento", SqlDbType.VarChar), _
                        New SqlParameter("@argTipoDocumentoComplementario", SqlDbType.TinyInt, 11), _
                        New SqlParameter("@argNumeroDocumentoComplementario", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argESCovenant", SqlDbType.TinyInt, 11), _
                        New SqlParameter("@CodFrecuencia", SqlDbType.TinyInt, 11) _
                }
                voParameters(0).Direction = ParameterDirection.Output
                voParameters(1).Value = pobeMetodizado.CUCliente
                voParameters(2).Value = pobeMetodizado.TipoDocumento
                voParameters(3).Value = pobeMetodizado.NumeroDocumento
                voParameters(4).Value = pobeMetodizado.RazonSocial
                voParameters(5).Value = pobeMetodizado.CodCIIU
                voParameters(6).Value = pobeMetodizado.CodSBS
                voParameters(7).Value = pobeMetodizado.CodGrupoEconomico
                voParameters(8).Value = pobeMetodizado.NombreGrupoEconomico
                voParameters(9).Value = pobeMetodizado.CodMoneda
                voParameters(10).Value = pobeMetodizado.CodUnidad
                If pobeMetodizado.CodAnalista <> String.Empty Then voParameters(11).Value = pobeMetodizado.CodAnalista
                If pobeMetodizado.NombreAnalista <> String.Empty Then voParameters(12).Value = pobeMetodizado.NombreAnalista
                If pobeMetodizado.CodEjecutivo <> String.Empty Then voParameters(13).Value = pobeMetodizado.CodEjecutivo
                If pobeMetodizado.NombreEjecutivo <> String.Empty Then voParameters(14).Value = pobeMetodizado.NombreEjecutivo
                voParameters(15).Value = pobeMetodizado.CodMonedaImpresion
                If pobeMetodizado.CodUsuario <> String.Empty Then voParameters(16).Value = pobeMetodizado.CodUsuario
                If pobeMetodizado.NombreUsuario <> String.Empty Then voParameters(17).Value = pobeMetodizado.NombreUsuario
                voParameters(18).Value = pobeMetodizado.FecReg
                voParameters(19).Value = pobeMetodizado.Estado
                voParameters(20).Value = pobeMetodizado.FlgBPE
                voParameters(21).Value = pobeMetodizado.Segmento
                voParameters(22).Value = pobeMetodizado.TipoDocumentoComplementario
                voParameters(23).Value = pobeMetodizado.NumeroDocumentoComplementario
                voParameters(24).Value = pobeMetodizado.ESCovenant
                voParameters(25).Value = pobeMetodizado.CodFrecuenciaCov

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(0).Value Is DBNull.Value) Then
                        pobeMetodizado.CodMetodizado = Convert.ToInt32(voParameters(0).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeMetodizado As BusinessEntity.Metodizado) As Boolean
            Dim voSProc As String = "up_Metodizado_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodCIIU", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodSBS", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argNombreGrupoEconomico", SqlDbType.NVarChar, 50), _
                        New SqlParameter("@argCodMoneda", SqlDbType.TinyInt), _
                        New SqlParameter("@argCodUnidad", SqlDbType.TinyInt), _
                        New SqlParameter("@argCodAnalista", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreAnalista", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodEjecutivo", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreEjecutivo", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodMonedaImpresion", SqlDbType.TinyInt), _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreUsuario", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argCUCliente", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argTipoDocumento", SqlDbType.TinyInt), _
                        New SqlParameter("@argNumeroDocumento", SqlDbType.NVarChar, 15), _
                        New SqlParameter("@argSegmento", SqlDbType.VarChar), _
                        New SqlParameter("@argTipoDocumentoComplementario", SqlDbType.TinyInt, 11), _
                        New SqlParameter("@argNumeroDocumentoComplementario", SqlDbType.NVarChar, 20), _
                        New SqlParameter("@argESCovenant", SqlDbType.TinyInt, 11), _
                        New SqlParameter("@CodFrecuencia", SqlDbType.TinyInt, 11) _
                }
                voParameters(0).Value = pobeMetodizado.CodMetodizado
                voParameters(1).Value = pobeMetodizado.RazonSocial
                voParameters(2).Value = pobeMetodizado.CodCIIU
                voParameters(3).Value = pobeMetodizado.CodSBS
                voParameters(4).Value = pobeMetodizado.CodGrupoEconomico
                voParameters(5).Value = pobeMetodizado.NombreGrupoEconomico
                voParameters(6).Value = pobeMetodizado.CodMoneda
                voParameters(7).Value = pobeMetodizado.CodUnidad
                If pobeMetodizado.CodAnalista <> String.Empty Then voParameters(8).Value = pobeMetodizado.CodAnalista
                If pobeMetodizado.NombreAnalista <> String.Empty Then voParameters(9).Value = pobeMetodizado.NombreAnalista
                If pobeMetodizado.CodEjecutivo <> String.Empty Then voParameters(10).Value = pobeMetodizado.CodEjecutivo
                If pobeMetodizado.NombreEjecutivo <> String.Empty Then voParameters(11).Value = pobeMetodizado.NombreEjecutivo
                voParameters(12).Value = pobeMetodizado.CodMonedaImpresion
                If pobeMetodizado.CodUsuario <> String.Empty Then voParameters(13).Value = pobeMetodizado.CodUsuario
                If pobeMetodizado.NombreUsuario <> String.Empty Then voParameters(14).Value = pobeMetodizado.NombreUsuario
                If pobeMetodizado.Estado <> Byte.MinValue Then voParameters(15).Value = pobeMetodizado.Estado
                If pobeMetodizado.CUCliente <> String.Empty Then voParameters(16).Value = pobeMetodizado.CUCliente
                voParameters(17).Value = pobeMetodizado.TipoDocumento
                If pobeMetodizado.NumeroDocumento <> String.Empty Then voParameters(18).Value = pobeMetodizado.NumeroDocumento
                voParameters(19).Value = pobeMetodizado.Segmento
                voParameters(20).Value = pobeMetodizado.TipoDocumentoComplementario
                voParameters(21).Value = pobeMetodizado.NumeroDocumentoComplementario
                voParameters(22).Value = pobeMetodizado.ESCovenant
                voParameters(23).Value = pobeMetodizado.CodFrecuenciaCov

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        '<AutoComplete(True)> _
        'Public Function reconciliar(ByRef pobeMetodizado As BusinessEntity.Metodizado) As Boolean
        '    Dim voSProc As String = "up_PeriodoCuenta_Reconciliacion_Upd"
        '    Try
        '        Dim voParameters() As SqlParameter = _
        '        { _
        '                New SqlParameter("@argMetodizadoXML", SqlDbType.Text) _
        '        }
        '        voParameters(0).Value = pobeMetodizado.PasarAXml()

        '        vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
        '        Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
        '        Return (voRC)
        '    Catch ex As Exception
        '        Return (False)
        '    End Try
        'End Function

        <AutoComplete(True)> _
        Public Function reconciliar(ByRef pobeMetodizado As BusinessEntity.Metodizado) As Boolean
            Dim voSProc As String = "up_METODIZADO_Reconciliacion_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodAnalista", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreAnalista", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodEjecutivo", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreEjecutivo", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreUsuario", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobeMetodizado.CodMetodizado
                If pobeMetodizado.CodAnalista <> String.Empty Then voParameters(1).Value = pobeMetodizado.CodAnalista
                If pobeMetodizado.NombreAnalista <> String.Empty Then voParameters(2).Value = pobeMetodizado.NombreAnalista
                If pobeMetodizado.CodEjecutivo <> String.Empty Then voParameters(3).Value = pobeMetodizado.CodEjecutivo
                If pobeMetodizado.NombreEjecutivo <> String.Empty Then voParameters(4).Value = pobeMetodizado.NombreEjecutivo
                If pobeMetodizado.CodUsuario <> String.Empty Then voParameters(5).Value = pobeMetodizado.CodUsuario
                If pobeMetodizado.NombreUsuario <> String.Empty Then voParameters(6).Value = pobeMetodizado.NombreUsuario
                voParameters(7).Value = pobeMetodizado.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leerPeriodo(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As DataSet
            Dim voSProc As String = "up_PERIODO_Sel"
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
        Public Function leerPeriodoAnterior(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As DataSet
            Dim voSProc As String = "up_PERIODO_AnteriorXPriorida_Sel"
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
        Public Function listarPeriodo(ByVal pintCodMetodizado As Integer) As DataSet
            Dim voSProc As String = "up_PERIODO_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodMetodizado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function filtrarPeriodo(ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet
            Dim voSProc As String = "up_PERIODO_Filtrar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argMetodizadoXML", SqlDbType.Text) _
                }
                voParameters(0).Value = generarMetodizadoXML(pobeMetodizado)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
            Dim voSProc As String = "up_Periodo_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodPeriodo", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodTipoEeff", SqlDbType.SmallInt), _
                        New SqlParameter("@argAnio", SqlDbType.SmallInt), _
                        New SqlParameter("@argMes", SqlDbType.SmallInt), _
                        New SqlParameter("@argDia", SqlDbType.SmallInt), _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime), _
                        New SqlParameter("@argCodAuditor", SqlDbType.SmallInt), _
                        New SqlParameter("@argComentario", SqlDbType.NVarChar, 205), _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argNombreUsuario", SqlDbType.NVarChar, 80), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado ", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobePeriodo.CodMetodizado
                voParameters(1).Direction = ParameterDirection.Output
                voParameters(2).Value = pobePeriodo.CodTipoEeff
                voParameters(3).Value = pobePeriodo.Anio
                voParameters(4).Value = pobePeriodo.Mes
                voParameters(5).Value = pobePeriodo.Dia
                voParameters(6).Value = pobePeriodo.FecPeriodo
                If pobePeriodo.CodAuditor <> 0 Then voParameters(7).Value = pobePeriodo.CodAuditor
                voParameters(8).Value = pobePeriodo.Comentario
                voParameters(9).Value = pobePeriodo.CodUsuario
                voParameters(10).Value = pobePeriodo.NombreUsuario
                voParameters(11).Value = pobePeriodo.FecReg
                voParameters(12).Value = pobePeriodo.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(0).Value Is DBNull.Value) Then
                        pobePeriodo.CodPeriodo = Convert.ToInt32(voParameters(1).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
            Dim voSProc As String = "up_Periodo_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodPeriodo", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodTipoEeff", SqlDbType.SmallInt), _
                        New SqlParameter("@argAnio", SqlDbType.SmallInt), _
                        New SqlParameter("@argMes", SqlDbType.SmallInt), _
                        New SqlParameter("@argDia", SqlDbType.SmallInt), _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime), _
                        New SqlParameter("@argCodAuditor", SqlDbType.SmallInt), _
                        New SqlParameter("@argComentario", SqlDbType.NVarChar, 205), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado ", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobePeriodo.CodMetodizado
                voParameters(1).Value = pobePeriodo.CodPeriodo
                voParameters(2).Value = pobePeriodo.CodTipoEeff
                voParameters(3).Value = pobePeriodo.Anio
                voParameters(4).Value = pobePeriodo.Mes
                voParameters(5).Value = pobePeriodo.Dia
                voParameters(6).Value = pobePeriodo.FecPeriodo
                If pobePeriodo.CodAuditor <> 0 Then voParameters(7).Value = pobePeriodo.CodAuditor
                voParameters(8).Value = pobePeriodo.Comentario
                voParameters(9).Value = pobePeriodo.FecReg
                voParameters(10).Value = pobePeriodo.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
            Dim voSProc As String = "up_Periodo_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodPeriodo", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodTipoEeff", SqlDbType.SmallInt), _
                        New SqlParameter("@argAnio", SqlDbType.SmallInt), _
                        New SqlParameter("@argMes", SqlDbType.SmallInt), _
                        New SqlParameter("@argDia", SqlDbType.SmallInt), _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime), _
                        New SqlParameter("@argCodAuditor", SqlDbType.SmallInt), _
                        New SqlParameter("@argComentario", SqlDbType.NVarChar, 205), _
                        New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                        New SqlParameter("@argEstado ", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pobePeriodo.CodMetodizado
                voParameters(1).Value = pobePeriodo.CodPeriodo
                'voParameters(2).Value = pobePeriodo.CodTipoEeff
                'voParameters(3).Value = pobePeriodo.Anio
                'voParameters(4).Value = pobePeriodo.Mes
                'voParameters(5).Value = pobePeriodo.Dia
                'voParameters(6).Value = pobePeriodo.FecPeriodo
                'If pobePeriodo.CodAuditor <> 0 Then voParameters(7).Value = pobePeriodo.CodAuditor
                'voParameters(8).Value = pobePeriodo.Comentario
                'voParameters(9).Value = pobePeriodo.FecReg
                'voParameters(10).Value = pobePeriodo.Estado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarPeriodoCuenta(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As DataSet
            Dim voSProc As String = "up_PERIODOCUENTA_Listar_Sel"
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
        Public Function filtrarPeriodoCuenta(ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet
            Dim voSProc As String = "up_PERIODOCUENTA_Filtrar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argMetodizadoXML", SqlDbType.Text) _
                }
                voParameters(0).Value = generarMetodizadoXML(pobeMetodizado)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregarPeriodoCuenta(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
            Dim voSProc As String = "up_PeriodoCuenta_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argPeriodoCuentaXML", SqlDbType.Text) _
                }
                voParameters(0).Value = generarPeriodoCuentaXML(pobePeriodo)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificarPeriodoCuenta(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
            Dim voSProc As String = "up_PeriodoCuenta_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argPeriodoCuentaXML", SqlDbType.Text) _
                }
                voParameters(0).Value = pobePeriodo.PasarAXml()

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificarCuentaLibre(ByRef pobeCuentaLibre As BusinessEntity.CuentaLibre) As Boolean
            Dim voSProc As String = "up_CuentaLibre_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodCuenta", SqlDbType.SmallInt), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100) _
                }
                voParameters(0).Value = pobeCuentaLibre.CodMetodizado
                voParameters(1).Value = pobeCuentaLibre.CodCuenta
                voParameters(2).Value = pobeCuentaLibre.Descripcion

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function filtrarRankingEmpresa(ByVal pintCodReporte As Integer, _
                                      ByVal pstrCodCIIU As String, _
                                      ByVal pstrCodGrupoEconomico As String, _
                                      ByVal pdteFecPeriodo As DateTime) As DataSet
            Dim voSProc As String = "up_METODIZADO_RankingEmpresa"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodReporte", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodCIIU", SqlDbType.NVarChar, 8), _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime) _
                }

                voParameters(0).Value = pintCodReporte
                voParameters(1).Value = pstrCodCIIU
                voParameters(2).Value = pstrCodGrupoEconomico
                voParameters(3).Value = pdteFecPeriodo

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function calcularCuentaAnalisisCabecera(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet
            Dim voSProc As String = "up_CalcularCuentaAnalisisCabecera"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argMetodizadoXML", SqlDbType.Text) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = generarMetodizadoXML(pobeMetodizado)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function calcularCuentaAnalisisTotales(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet
            'Dim voSProc As String = "up_CalcularCuentaAnalisis"
            'Dim voSProc As String = "up_GacelaFase2_RPT"
            Dim voSProc As String = "up_RPT_CEF_Metodizado"
            Dim intTimeout As Integer = 180
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argMetodizadoXML", SqlDbType.Text) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = generarMetodizadoXML(pobeMetodizado)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters, intTimeout))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function calcularFlujoProyectado(ByVal pintCodSupuesto As Integer) As DataSet
            Dim voSProc As String = "up_CalcularFlujoProyectado_Sel"
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
        Public Function generarInformeSBS(ByVal pdteFecPeriodo As DateTime) As DataSet
            Dim voSProc As String = "up_METODIZADO_GenerarInformeSBS_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime) _
                }
                voParameters(0).Value = pdteFecPeriodo

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function generarDescargaData(ByVal pdteFecPeriodo As DateTime) As DataSet
            Dim voSProc As String = "up_METODIZADO_GenerarDescargaData_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime) _
                }
                voParameters(0).Value = pdteFecPeriodo

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function generarDescargaDataporMoneda(ByVal pdteFecPeriodo As DateTime, ByVal pintMoneda As Integer, ByVal pintEstado As Integer, Optional ByVal pintPagina As Integer = -1, Optional ByVal pintTamanioPagina As Integer = 1) As DataSet
            Dim voSProc As String = "up_METODIZADO_GenerarDescargaData_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime), _
                        New SqlParameter("@argMoneda", SqlDbType.TinyInt), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argPagina", SqlDbType.SmallInt), _
                        New SqlParameter("@argTamanioPagina", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pdteFecPeriodo
                voParameters(1).Value = pintMoneda
                voParameters(2).Value = pintEstado
                voParameters(3).Value = pintPagina
                voParameters(4).Value = pintTamanioPagina

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function generarDescargaDataPrioridad(ByVal pdteFecPeriodo As DateTime, ByVal pintMoneda As Integer) As DataSet
            Dim voSProc As String = "up_METODIZADO_GenerarDescargaDataPrioridad_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime), _
                        New SqlParameter("@argMoneda", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pdteFecPeriodo
                voParameters(1).Value = pintMoneda

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function filtrarConsultaParametrica(ByVal pbytIndicador As Byte, ByVal pdetFecPeriodo As DateTime, ByRef pobeCuentaAnalisis As BusinessEntity.CuentaAnalisis) As DataSet
            Dim X As String
            Dim voSProc As String = "up_METODIZADO_ConsultaParametrica"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argIndicador", SqlDbType.TinyInt), _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime), _
                        New SqlParameter("@argCuentaAnalisisXML", SqlDbType.Text) _
                }
                voParameters(0).Value = pbytIndicador
                voParameters(1).Value = pdetFecPeriodo
                voParameters(2).Value = generarCuentaAnalisisXML(pobeCuentaAnalisis)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function filtrarConsultaParametricaporMoneda(ByVal pbytIndicador As Byte, ByVal pdetFecPeriodo As DateTime, ByRef pobeCuentaAnalisis As BusinessEntity.CuentaAnalisis, Optional ByVal pintMoneda As Integer = 0) As DataSet
            Dim X As String
            Dim voSProc As String = "up_METODIZADO_ConsultaParametrica"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argIndicador", SqlDbType.TinyInt), _
                        New SqlParameter("@argFecPeriodo", SqlDbType.DateTime), _
                        New SqlParameter("@argCuentaAnalisisXML", SqlDbType.Text), _
                        New SqlParameter("@argMoneda", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pbytIndicador
                voParameters(1).Value = pdetFecPeriodo
                voParameters(2).Value = generarCuentaAnalisisXML(pobeCuentaAnalisis)
                If pbytIndicador = 3 Then
                    voParameters(3).Value = pintMoneda
                Else
                    voParameters(3).Value = DBNull.Value
                End If

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Private Function generarMetodizadoXML(ByRef pobeMetodizado As BusinessEntity.Metodizado) As String
            Dim xmlDoc As XmlDocument = New XmlDocument
            Dim xmlElmMetodizado As XmlElement = xmlDoc.CreateElement("METODIZADO")
            Try
                xmlElmMetodizado.SetAttribute("CodMetodizado", pobeMetodizado.CodMetodizado.ToString())
                xmlElmMetodizado.SetAttribute("CodAnalista", pobeMetodizado.CodAnalista)
                xmlElmMetodizado.SetAttribute("NombreAnalista", pobeMetodizado.NombreAnalista)
                xmlElmMetodizado.SetAttribute("CodEjecutivo", pobeMetodizado.CodEjecutivo)
                xmlElmMetodizado.SetAttribute("NombreEjecutivo", pobeMetodizado.NombreEjecutivo)
                xmlElmMetodizado.SetAttribute("Estado", pobeMetodizado.Estado.ToString())

                For Each obePeriodo As BusinessEntity.Periodo In pobeMetodizado.Periodos
                    Dim xmlElmPeriodo As XmlElement = xmlDoc.CreateElement("PERIODO")
                    xmlElmPeriodo.SetAttribute("CodPeriodo", obePeriodo.CodPeriodo.ToString())
                    For Each obePeriodoCuenta As BusinessEntity.PeriodoCuenta In obePeriodo.PeriodoCuentas
                        Dim xmlElmPeriodoCuenta As XmlElement = xmlDoc.CreateElement("PERIODOCUENTA")
                        xmlElmPeriodoCuenta.SetAttribute("CodCuenta", obePeriodoCuenta.CodCuenta.ToString())
                        xmlElmPeriodoCuenta.SetAttribute("Importe", obePeriodoCuenta.Importe.ToString())
                        xmlElmPeriodoCuenta.SetAttribute("Funcion", obePeriodoCuenta.Funcion)
                        xmlElmPeriodo.AppendChild(xmlElmPeriodoCuenta)
                    Next
                    xmlElmMetodizado.AppendChild(xmlElmPeriodo)
                Next

                For Each obeCuentaLibre As BusinessEntity.CuentaLibre In pobeMetodizado.CuentasLibres
                    Dim xmlElmCuentaLibre As XmlElement = xmlDoc.CreateElement("CUENTALIBRE")
                    xmlElmCuentaLibre.SetAttribute("CodCuenta", obeCuentaLibre.CodCuenta.ToString())
                    xmlElmCuentaLibre.SetAttribute("Descripcion", obeCuentaLibre.Descripcion.ToString())
                    xmlElmMetodizado.AppendChild(xmlElmCuentaLibre)
                Next

                xmlDoc.AppendChild(xmlElmMetodizado)
                Dim xmlElmRoot As XmlElement = xmlDoc.DocumentElement()
                Dim xmlDec As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", Nothing, Nothing)
                xmlDoc.InsertBefore(xmlDec, xmlElmRoot)
                Return (xmlDoc.InnerXml)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
            
        End Function

        <AutoComplete(True)> _
        Private Function generarPeriodoCuentaXML(ByRef pobePeriodo As BusinessEntity.Periodo) As String
            Dim xmlDoc As XmlDocument = New XmlDocument
            Dim xmlElmMetodizado As XmlElement = xmlDoc.CreateElement("METODIZADO")
            Try
                xmlElmMetodizado.SetAttribute("CodMetodizado", pobePeriodo.CodMetodizado.ToString())
                Dim xmlElmPeriodo As XmlElement = xmlDoc.CreateElement("PERIODO")
                xmlElmPeriodo.SetAttribute("CodPeriodo", pobePeriodo.CodPeriodo.ToString())
                For Each obePeriodoCuenta As BusinessEntity.PeriodoCuenta In pobePeriodo.PeriodoCuentas
                    Dim xmlElmPeriodoCuenta As XmlElement = xmlDoc.CreateElement("PERIODOCUENTA")
                    xmlElmPeriodoCuenta.SetAttribute("CodCuenta", obePeriodoCuenta.CodCuenta.ToString())
                    xmlElmPeriodoCuenta.SetAttribute("Importe", obePeriodoCuenta.Importe.ToString())
                    xmlElmPeriodoCuenta.SetAttribute("Funcion", obePeriodoCuenta.Funcion)
                    xmlElmPeriodo.AppendChild(xmlElmPeriodoCuenta)
                Next
                xmlElmMetodizado.AppendChild(xmlElmPeriodo)
                xmlDoc.AppendChild(xmlElmMetodizado)
                Dim xmlElmRoot As XmlElement = xmlDoc.DocumentElement()
                Dim xmlDec As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", Nothing, Nothing)
                xmlDoc.InsertBefore(xmlDec, xmlElmRoot)
                Return (xmlDoc.InnerXml)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
            
        End Function

        <AutoComplete(True)> _
        Private Function generarCuentaAnalisisXML(ByRef pobeCuentaAnalisis As BusinessEntity.CuentaAnalisis) As String
            Dim xmlDoc As XmlDocument = New XmlDocument
            Dim xmlElmPeriodo As XmlElement = xmlDoc.CreateElement("PERIODO")
            Try
                For Each obeCuentaAnalisis As BusinessEntity.CuentaAnalisis In pobeCuentaAnalisis.CuentaAnalisisList
                    Dim xmlElmCuentaAnalisis As XmlElement = xmlDoc.CreateElement("CUENTAANALISIS")
                    xmlElmCuentaAnalisis.SetAttribute("CodCuentaAnalisis", obeCuentaAnalisis.CodCuentaAnalisis.ToString())
                    xmlElmCuentaAnalisis.SetAttribute("ImporteRango1", obeCuentaAnalisis.ImporteRango1.ToString())
                    xmlElmCuentaAnalisis.SetAttribute("ImporteRango2", obeCuentaAnalisis.ImporteRango2.ToString())
                    xmlElmPeriodo.AppendChild(xmlElmCuentaAnalisis)
                Next
                xmlDoc.AppendChild(xmlElmPeriodo)
                Dim xmlElmRoot As XmlElement = xmlDoc.DocumentElement()
                Dim xmlDec As XmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", Nothing, Nothing)
                xmlDoc.InsertBefore(xmlDec, xmlElmRoot)
                Return (xmlDoc.InnerXml)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
            
        End Function

        'Francisco
        <AutoComplete(True)> _
        Public Function generarResumenEjecutivo_Detalles(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16, ByVal pintCodMoneda As Int16) As DataSet
            Dim voSproc As String = "up_RPT_CEF_Resumen_Ejecutivo_Detalles"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@ARGCODPERIODO", SqlDbType.NVarChar), _
                    New SqlParameter("@ARGCODMETODIZADO", SqlDbType.Int), _
                    New SqlParameter("@ARGMONEDA", SqlDbType.Int) _
                }
                voParameters(0).Value = pstrPeriodos
                voParameters(1).Value = pintCodMetodizado
                voParameters(2).Value = pintCodMoneda

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSproc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function generarResumenEjecutivo_Cabecera(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16, ByVal pintCodMoneda As Int16) As DataSet
            Dim voSproc As String = "up_RPT_CEF_Resumen_Ejecutivo_Cabecera"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@ARGMONEDA", SqlDbType.Int), _
                    New SqlParameter("@ARGCODPERIODO", SqlDbType.NVarChar), _
                    New SqlParameter("@ARGCODMETODIZADO", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodMoneda
                voParameters(1).Value = pstrPeriodos
                voParameters(2).Value = pintCodMetodizado

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSproc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function validarGeneracionResEjec(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16) As Int16
            Dim voSproc As String = "up_RPT_CEF_ValidaESituacion"
            Try
                Dim voParameters() As SqlParameter = _
                                { _
                                    New SqlParameter("@ARGCODPERIODO", SqlDbType.NVarChar), _
                                    New SqlParameter("@ARGCODMETODIZADO", SqlDbType.Int) _
                                }
                voParameters(0).Value = pstrPeriodos
                voParameters(1).Value = pintCodMetodizado
                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return Convert.ToInt16((vcManejadoBD.traerDatos(voSproc, voParameters)).Tables(0).Rows(0).Item(0))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarNotas(ByVal pintCodMetodizado As Int16, ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet
            Dim voSproc As String = "up_RPT_CEF_Metodizado_Notas_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                                { _
                                    New SqlParameter("@CODMETODIZADO", SqlDbType.Int), _
                                    New SqlParameter("@ARGPERIODOSXML", SqlDbType.Text) _
                                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = generarMetodizadoXML(pobeMetodizado)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return vcManejadoBD.traerDatos(voSproc, voParameters)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarProyecciones(ByVal pintCodMetodizado As Int16, ByVal strCodPeriodos As String, ByVal strCodProyecciones As String) As DataSet
            Dim voSproc As String = "up_RPT_CEF_Proyecciones_Detalle"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@CODMETODIZADO", SqlDbType.Int), _
                    New SqlParameter("@ARGPERIODOS", SqlDbType.NVarChar), _
                    New SqlParameter("@ARGPERPROY", SqlDbType.NVarChar) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = strCodPeriodos
                voParameters(2).Value = strCodProyecciones
                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return vcManejadoBD.traerDatos(voSproc, voParameters)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarProyeccionesCabecera(ByVal pintCodMetodizado As Int16, ByVal strCodPeriodos As String, ByVal strCodProyecciones As String) As DataSet
            Dim voSproc As String = "up_RPT_CEF_Proyecciones_Cabecera"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@CODMETODIZADO", SqlDbType.Int), _
                    New SqlParameter("@ARGPERIODOS", SqlDbType.NVarChar), _
                    New SqlParameter("@ARGPERPROY", SqlDbType.NVarChar) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = strCodPeriodos
                voParameters(2).Value = strCodProyecciones
                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return vcManejadoBD.traerDatos(voSproc, voParameters)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        'End Francisco

        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function buscarBPE(ByRef pobeMetodizadoBus As BusinessEntity.MetodizadoBus) As DataSet
            Dim voSProc As String = "up_Metodizado_BusGeneralBPE_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCUCliente", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argRUC", SqlDbType.NVarChar, 11), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodCIIU", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodAnalista", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argCodEjecutivo", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argFecInicio", SqlDbType.DateTime), _
                        New SqlParameter("@argFecFin", SqlDbType.DateTime), _
                        New SqlParameter("@argTipoDocumento", SqlDbType.TinyInt), _
                        New SqlParameter("@argSegmento", SqlDbType.Int) _
                }
                If pobeMetodizadoBus.CUCliente <> String.Empty Then voParameters(0).Value = pobeMetodizadoBus.CUCliente
                If pobeMetodizadoBus.NumeroDocumento <> String.Empty Then voParameters(1).Value = pobeMetodizadoBus.NumeroDocumento
                If pobeMetodizadoBus.RazonSocial <> String.Empty Then voParameters(2).Value = pobeMetodizadoBus.RazonSocial
                If pobeMetodizadoBus.CodCIIU <> String.Empty Then voParameters(3).Value = pobeMetodizadoBus.CodCIIU
                If pobeMetodizadoBus.CodGrupoEconomico <> String.Empty Then voParameters(4).Value = pobeMetodizadoBus.CodGrupoEconomico
                If pobeMetodizadoBus.CodAnalista <> String.Empty Then voParameters(5).Value = pobeMetodizadoBus.CodAnalista
                If pobeMetodizadoBus.CodEjecutivo <> String.Empty Then voParameters(6).Value = pobeMetodizadoBus.CodEjecutivo
                If pobeMetodizadoBus.Estado <> Byte.MinValue Then voParameters(7).Value = pobeMetodizadoBus.Estado

                If pobeMetodizadoBus.FecInicio <> DateTime.MinValue Then
                    voParameters(8).Value = pobeMetodizadoBus.FecInicio
                End If

                If pobeMetodizadoBus.FecFin <> DateTime.MinValue Then
                    voParameters(9).Value = pobeMetodizadoBus.FecFin
                End If

                If pobeMetodizadoBus.TipoDocumento <> Byte.MinValue Then voParameters("10").Value = pobeMetodizadoBus.TipoDocumento
                If pobeMetodizadoBus.Segmento <> Nothing Then voParameters(11).Value = pobeMetodizadoBus.Segmento

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function buscarNoBPE(ByRef pobeMetodizadoBus As BusinessEntity.MetodizadoBus) As DataSet
            Dim voSProc As String = "up_Metodizado_BusGeneralNoBPE_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCUCliente", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argRUC", SqlDbType.NVarChar, 11), _
                        New SqlParameter("@argRazonSocial", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodCIIU", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodGrupoEconomico", SqlDbType.NVarChar, 4), _
                        New SqlParameter("@argCodAnalista", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argCodEjecutivo", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argFecInicio", SqlDbType.DateTime), _
                        New SqlParameter("@argFecFin", SqlDbType.DateTime), _
                        New SqlParameter("@argTipoDocumento", SqlDbType.TinyInt) _
                }
                If pobeMetodizadoBus.CUCliente <> String.Empty Then voParameters(0).Value = pobeMetodizadoBus.CUCliente
                If pobeMetodizadoBus.NumeroDocumento <> String.Empty Then voParameters(1).Value = pobeMetodizadoBus.NumeroDocumento
                If pobeMetodizadoBus.RazonSocial <> String.Empty Then voParameters(2).Value = pobeMetodizadoBus.RazonSocial
                If pobeMetodizadoBus.CodCIIU <> String.Empty Then voParameters(3).Value = pobeMetodizadoBus.CodCIIU
                If pobeMetodizadoBus.CodGrupoEconomico <> String.Empty Then voParameters(4).Value = pobeMetodizadoBus.CodGrupoEconomico
                If pobeMetodizadoBus.CodAnalista <> String.Empty Then voParameters(5).Value = pobeMetodizadoBus.CodAnalista
                If pobeMetodizadoBus.CodEjecutivo <> String.Empty Then voParameters(6).Value = pobeMetodizadoBus.CodEjecutivo
                If pobeMetodizadoBus.Estado <> Byte.MinValue Then voParameters(7).Value = pobeMetodizadoBus.Estado

                If pobeMetodizadoBus.FecInicio <> DateTime.MinValue Then
                    voParameters(8).Value = pobeMetodizadoBus.FecInicio
                End If

                If pobeMetodizadoBus.FecFin <> DateTime.MinValue Then
                    voParameters(9).Value = pobeMetodizadoBus.FecFin
                End If

                If pobeMetodizadoBus.TipoDocumento <> Byte.MinValue Then voParameters("10").Value = pobeMetodizadoBus.TipoDocumento

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        ' 21-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function filtrarPeriodoCuentaBPE(ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet
            Dim voSProc As String = "up_PERIODOCUENTABPE_Filtrar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argMetodizadoXML", SqlDbType.Text) _
                }
                voParameters(0).Value = generarMetodizadoXML(pobeMetodizado)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        'ADD XT8442 ADR 02/01/2019 INICIO
        <AutoComplete(True)> _
       Public Function filtrarPeriodoCuentaCovenant(ByRef pobeMetodizado As BusinessEntity.Metodizado, ByRef pintCodMetodizado As Integer, ByRef pintCodPeriodo As Integer, ByRef pstrBusqueda As String) As DataSet
            Dim voSProc As String = "up_COVENANT_DATOCEF_Lst"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                         New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodPeriodo", SqlDbType.Int), _
                    New SqlParameter("@argBusqueda", SqlDbType.VarChar, 500), _
                        New SqlParameter("@argMetodizadoXML", SqlDbType.Text) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = pintCodPeriodo
                voParameters(2).Value = pstrBusqueda
                voParameters(3).Value = generarMetodizadoXML(pobeMetodizado)

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
        'ADD XT8442 ADR 02/01/2019 FIN
'I-XT9104
        <AutoComplete(True)> _
        Public Function filtrarCovenantParametros(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet
            Dim voSProc As String = "up_REPORTECOVENANTMETODIZADO"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                    New SqlParameter("@argPeriodoXML", SqlDbType.Text), _
                    New SqlParameter("@User", SqlDbType.VarChar) _
                }
                voParameters(0).Value = pintCodMetodizado
                voParameters(1).Value = generarMetodizadoXML(pobeMetodizado)
                voParameters(2).Value = "Hector"

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
        'F-XT9104

        'XT8633 Ini
        <AutoComplete(True)> _
       Public Function listarFrecuenciaCovenant(ByVal pintCodTbl As Integer) As DataSet
            Dim voSProc As String = "up_FRECUENCIACOVENANT_Lst"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodTbl", SqlDbType.Int) _
                }
                voParameters(0).Value = pintCodTbl

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
        'XT8633 Fin

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class

End Namespace