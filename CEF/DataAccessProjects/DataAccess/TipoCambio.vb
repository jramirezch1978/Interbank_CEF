'*************************************************************
'Proposito:
'Autor: Miguel Delgado del Aguila
'Fecha Creacion:19/06/2006
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
    Public Class TipoCambio
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintAnio As Integer, ByVal pintMes As Integer, ByVal pintMoneda As Integer) As DataSet
            Dim voSProc As String = "up_TipoCambio_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argAnio", SqlDbType.SmallInt), _
                        New SqlParameter("@argMes", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodMoneda", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintAnio
                voParameters(1).Value = pintMes
                voParameters(2).Value = pintMoneda

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
            Dim voSProc As String = "up_TipoCambio_Listar_Sel"
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
        Public Function listarConFiltros(ByVal pbytFlag As Byte, ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As DataSet
            Dim voSProc As String = "up_TipoCambio_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argAnio", SqlDbType.SmallInt), _
                        New SqlParameter("@argMes", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pbytFlag
                voParameters(1).Value = pobeTipoCambio.Estado
                If (pobeTipoCambio.Anio > 0) Then
                    voParameters(2).Value = pobeTipoCambio.Anio
                Else
                    voParameters(2).Value = DBNull.Value
                End If
                If (pobeTipoCambio.Mes > 0 And pobeTipoCambio.Mes < 13) Then
                    voParameters(3).Value = pobeTipoCambio.Mes
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
        Public Function agregar(ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As Boolean
            Dim voSProc As String = "up_TipoCambio_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argAnio", SqlDbType.SmallInt), _
                    New SqlParameter("@argMes", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodMoneda", SqlDbType.TinyInt), _
                    New SqlParameter("@argMontoTipoCambio", SqlDbType.Decimal, 6, 3), _
                    New SqlParameter("@argMontoMaximo", SqlDbType.Decimal, 6, 3), _
                    New SqlParameter("@argPorcentajeDev", SqlDbType.Decimal, 6, 2), _
                    New SqlParameter("@argIndice", SqlDbType.Decimal, 6, 3), _
                    New SqlParameter("@argFecReg", SqlDbType.DateTime), _
                    New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                    New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                    New SqlParameter("@argMontoMinimo", SqlDbType.Decimal, 6, 3), _
                    New SqlParameter("@argPorcentajeAprec", SqlDbType.Decimal, 6, 2) _
                }
                voParameters(0).Value = pobeTipoCambio.Anio
                voParameters(1).Value = pobeTipoCambio.Mes
                voParameters(2).Value = pobeTipoCambio.CodMoneda
                voParameters(3).Value = pobeTipoCambio.Monto
                voParameters(4).Value = pobeTipoCambio.MontoMaximo
                voParameters(5).Value = pobeTipoCambio.PorcentajeDevaluacion
                voParameters(6).Value = pobeTipoCambio.IndiceReexpresion
                voParameters(7).Value = pobeTipoCambio.FecReg
                voParameters(8).Value = pobeTipoCambio.Estado
                voParameters(9).Value = pobeTipoCambio.CodUsuario
                voParameters(10).Value = pobeTipoCambio.MontoMinimo
                voParameters(11).Value = pobeTipoCambio.ProcentajeApreciacion

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As Boolean
            Dim voSProc As String = "up_TipoCambio_Upd"
            Try
                'I-XT-9104 - 03/03/2020
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argAnio", SqlDbType.SmallInt), _
                        New SqlParameter("@argMes", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodMoneda", SqlDbType.TinyInt), _
                        New SqlParameter("@argMontoTipoCambio", SqlDbType.Decimal, 9, 6), _
                        New SqlParameter("@argMontoMaximo", SqlDbType.Decimal, 9, 6), _
                        New SqlParameter("@argPorcentajeDev", SqlDbType.Decimal, 6, 2), _
                        New SqlParameter("@argIndice", SqlDbType.Decimal, 6, 3), _
                        New SqlParameter("@argEstado", SqlDbType.TinyInt), _
                        New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 10), _
                        New SqlParameter("@argMontoMinimo", SqlDbType.Decimal, 9, 6), _
                        New SqlParameter("@argPorcentajeAprec", SqlDbType.Decimal, 6, 2) _
                }
                'F-XT-9104 - 03/03/2020
                voParameters(0).Value = pobeTipoCambio.Anio
                voParameters(1).Value = pobeTipoCambio.Mes
                voParameters(2).Value = pobeTipoCambio.CodMoneda
                voParameters(3).Value = pobeTipoCambio.Monto
                voParameters(4).Value = pobeTipoCambio.MontoMaximo
                voParameters(5).Value = pobeTipoCambio.PorcentajeDevaluacion
                voParameters(6).Value = pobeTipoCambio.IndiceReexpresion
                voParameters(7).Value = pobeTipoCambio.Estado
                voParameters(8).Value = pobeTipoCambio.CodUsuario
                voParameters(9).Value = pobeTipoCambio.MontoMinimo
                voParameters(10).Value = pobeTipoCambio.ProcentajeApreciacion

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintAnio As Integer, ByVal pintMes As Integer, ByVal pintMoneda As Integer) As Boolean
            Dim voSProc As String = "up_TipoCambio_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argAnio", SqlDbType.SmallInt), _
                        New SqlParameter("@argMes", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodMoneda", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintAnio
                voParameters(1).Value = pintMes
                voParameters(2).Value = pintMoneda

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