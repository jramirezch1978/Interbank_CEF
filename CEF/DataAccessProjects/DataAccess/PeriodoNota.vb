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
    Public Class PeriodoNota
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listarBD(ByVal pstrCodMetodizado As Int32, ByVal pstrArrayPeriodoFiltrado As Int16, ByVal pintCodigoCuenta As Int16) As DataTable
            Dim voSProc As String = "up_PERIODONOTA_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodPeriodo", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodCuenta", SqlDbType.SmallInt) _
                }

                voParameters(0).Value = pstrCodMetodizado
                voParameters(1).Value = pstrArrayPeriodoFiltrado
                voParameters(2).Value = pintCodigoCuenta

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters)).Tables(0)

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function guardar(ByVal entPeriodoNota As CEF.BusinessEntity.PeriodoNota) As Int16
            Dim voSProc As String = "up_PERIODONOTA_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int), _
                        New SqlParameter("@argCodPeriodo", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodCuenta", SqlDbType.SmallInt), _
                        New SqlParameter("@argNota", SqlDbType.NVarChar), _
                        New SqlParameter("@argCodUsuarioIns", SqlDbType.NVarChar) _
                }

                voParameters(0).Value = entPeriodoNota.CodMetodizado
                voParameters(1).Value = entPeriodoNota.CodPeriodo
                voParameters(2).Value = entPeriodoNota.CodCuenta
                voParameters(3).Value = entPeriodoNota.Nota
                voParameters(4).Value = entPeriodoNota.UsuarioIns

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return CType(vcManejadoBD.ejecutarSProc(voSProc, voParameters), Int16)
                'vcManejadoBD.ejecutarSProc("up_PERIODONOTA_Ins", voParameters)

            Catch ex As Exception

                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (0)
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function verificarExistenciaNota(ByVal pstrCodMetodizado As Int32, ByVal pstrArrayPeriodoFiltrado As String, ByVal pintCodigoCuenta As Int16) As Int16
            Dim voSProc As String = "up_PERIODONOTAVER_sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@ARGCODMETODIZADO", SqlDbType.Int), _
                        New SqlParameter("@ARGCODCODPERIODO", SqlDbType.NVarChar), _
                        New SqlParameter("@ARGCODCUENTA", SqlDbType.SmallInt) _
                }

                voParameters(0).Value = pstrCodMetodizado
                voParameters(1).Value = pstrArrayPeriodoFiltrado
                voParameters(2).Value = pintCodigoCuenta

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                'Return CType(vcManejadoBD.traerDatos(voSProc, voParameters), Int16)
                Return CType(vcManejadoBD.traerDatos(voSProc, voParameters).Tables(0).Rows(0).Item(0), Int16)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return 0
            End Try
        End Function

    End Class

End Namespace
