'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
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

    Public Interface IPeriodoCuentaAnalisis
        Function leer(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As DataSet
        Function listar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As DataSet
        Function agregar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean
        Function modificar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean
        Function eliminar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean
    End Interface

    <JustInTimeActivation(True), _
   Synchronization(SynchronizationOption.Required), _
   Transaction(TransactionOption.Required)> _
   Public Class PeriodoCuentaAnalisis
        Inherits DAO
        Implements IPeriodoCuentaAnalisis

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function agregar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean Implements IPeriodoCuentaAnalisis.agregar
            Dim voSProc As String = "up_PeriodoCuentaAnalisis_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodoctaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodeeff", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcuentaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodtipocuenta", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argImporte1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argExposicion1", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion2", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion3", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion4", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCuentaAnalisis.Flag
                voParameters(1).Value = argPeriodoCuentaAnalisis.Codmetodizado
                voParameters(2).Value = argPeriodoCuentaAnalisis.Codcorrida
                voParameters(3).Value = argPeriodoCuentaAnalisis.Codperiodoctaanalisis
                voParameters(4).Value = argPeriodoCuentaAnalisis.Codanalisis
                voParameters(5).Value = argPeriodoCuentaAnalisis.Codeeff
                voParameters(6).Value = argPeriodoCuentaAnalisis.Codcuentaanalisis
                voParameters(7).Value = argPeriodoCuentaAnalisis.Descripcion
                voParameters(8).Value = argPeriodoCuentaAnalisis.Codtipocuenta
                voParameters(9).Value = argPeriodoCuentaAnalisis.Importe1
                voParameters(10).Value = argPeriodoCuentaAnalisis.Porcentaje1
                voParameters(11).Value = argPeriodoCuentaAnalisis.Variacion1
                voParameters(12).Value = argPeriodoCuentaAnalisis.Soles1
                voParameters(13).Value = argPeriodoCuentaAnalisis.Dolares1
                voParameters(14).Value = argPeriodoCuentaAnalisis.Importe2
                voParameters(15).Value = argPeriodoCuentaAnalisis.Porcentaje2
                voParameters(16).Value = argPeriodoCuentaAnalisis.Variacion2
                voParameters(17).Value = argPeriodoCuentaAnalisis.Soles2
                voParameters(18).Value = argPeriodoCuentaAnalisis.Dolares2
                voParameters(19).Value = argPeriodoCuentaAnalisis.Importe3
                voParameters(20).Value = argPeriodoCuentaAnalisis.Porcentaje3
                voParameters(21).Value = argPeriodoCuentaAnalisis.Variacion3
                voParameters(22).Value = argPeriodoCuentaAnalisis.Soles3
                voParameters(23).Value = argPeriodoCuentaAnalisis.Dolares3
                voParameters(24).Value = argPeriodoCuentaAnalisis.Importe4
                voParameters(25).Value = argPeriodoCuentaAnalisis.Porcentaje4
                voParameters(26).Value = argPeriodoCuentaAnalisis.Variacion4
                voParameters(27).Value = argPeriodoCuentaAnalisis.Soles4
                voParameters(28).Value = argPeriodoCuentaAnalisis.Dolares4
                voParameters(29).Value = argPeriodoCuentaAnalisis.Exposicion1
                voParameters(30).Value = argPeriodoCuentaAnalisis.Exposicion2
                voParameters(31).Value = argPeriodoCuentaAnalisis.Exposicion3
                voParameters(32).Value = argPeriodoCuentaAnalisis.Exposicion4

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean Implements IPeriodoCuentaAnalisis.eliminar
            Dim voSProc As String = "up_PeriodoCuentaAnalisis_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodoctaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodeeff", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcuentaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodtipocuenta", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argImporte1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argExposicion1", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion2", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion3", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion4", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCuentaAnalisis.Flag
                voParameters(1).Value = argPeriodoCuentaAnalisis.Codmetodizado
                voParameters(2).Value = argPeriodoCuentaAnalisis.Codcorrida
                voParameters(3).Value = argPeriodoCuentaAnalisis.Codperiodoctaanalisis
                voParameters(4).Value = argPeriodoCuentaAnalisis.Codanalisis
                voParameters(5).Value = argPeriodoCuentaAnalisis.Codeeff
                voParameters(6).Value = argPeriodoCuentaAnalisis.Codcuentaanalisis
                voParameters(7).Value = argPeriodoCuentaAnalisis.Descripcion
                voParameters(8).Value = argPeriodoCuentaAnalisis.Codtipocuenta
                voParameters(9).Value = argPeriodoCuentaAnalisis.Importe1
                voParameters(10).Value = argPeriodoCuentaAnalisis.Porcentaje1
                voParameters(11).Value = argPeriodoCuentaAnalisis.Variacion1
                voParameters(12).Value = argPeriodoCuentaAnalisis.Soles1
                voParameters(13).Value = argPeriodoCuentaAnalisis.Dolares1
                voParameters(14).Value = argPeriodoCuentaAnalisis.Importe2
                voParameters(15).Value = argPeriodoCuentaAnalisis.Porcentaje2
                voParameters(16).Value = argPeriodoCuentaAnalisis.Variacion2
                voParameters(17).Value = argPeriodoCuentaAnalisis.Soles2
                voParameters(18).Value = argPeriodoCuentaAnalisis.Dolares2
                voParameters(19).Value = argPeriodoCuentaAnalisis.Importe3
                voParameters(20).Value = argPeriodoCuentaAnalisis.Porcentaje3
                voParameters(21).Value = argPeriodoCuentaAnalisis.Variacion3
                voParameters(22).Value = argPeriodoCuentaAnalisis.Soles3
                voParameters(23).Value = argPeriodoCuentaAnalisis.Dolares3
                voParameters(24).Value = argPeriodoCuentaAnalisis.Importe4
                voParameters(25).Value = argPeriodoCuentaAnalisis.Porcentaje4
                voParameters(26).Value = argPeriodoCuentaAnalisis.Variacion4
                voParameters(27).Value = argPeriodoCuentaAnalisis.Soles4
                voParameters(28).Value = argPeriodoCuentaAnalisis.Dolares4
                voParameters(29).Value = argPeriodoCuentaAnalisis.Exposicion1
                voParameters(30).Value = argPeriodoCuentaAnalisis.Exposicion2
                voParameters(31).Value = argPeriodoCuentaAnalisis.Exposicion3
                voParameters(32).Value = argPeriodoCuentaAnalisis.Exposicion4

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leer(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As System.Data.DataSet Implements IPeriodoCuentaAnalisis.leer
            Dim voSProc As String = "up_PeriodoCuentaAnalisis_Sel2"
            'Dim voSProc As String = "up_PeriodoCuentaAnalisis_Sel2"

            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodoctaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodeeff", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcuentaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodtipocuenta", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argImporte1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argExposicion1", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion2", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion3", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion4", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCuentaAnalisis.Flag
                voParameters(1).Value = argPeriodoCuentaAnalisis.Codmetodizado
                voParameters(2).Value = argPeriodoCuentaAnalisis.Codcorrida
                voParameters(3).Value = argPeriodoCuentaAnalisis.Codperiodoctaanalisis
                voParameters(4).Value = argPeriodoCuentaAnalisis.Codanalisis
                voParameters(5).Value = argPeriodoCuentaAnalisis.Codeeff
                voParameters(6).Value = argPeriodoCuentaAnalisis.Codcuentaanalisis
                voParameters(7).Value = argPeriodoCuentaAnalisis.Descripcion
                voParameters(8).Value = argPeriodoCuentaAnalisis.Codtipocuenta
                voParameters(9).Value = argPeriodoCuentaAnalisis.Importe1
                voParameters(10).Value = argPeriodoCuentaAnalisis.Porcentaje1
                voParameters(11).Value = argPeriodoCuentaAnalisis.Variacion1
                voParameters(12).Value = argPeriodoCuentaAnalisis.Soles1
                voParameters(13).Value = argPeriodoCuentaAnalisis.Dolares1
                voParameters(14).Value = argPeriodoCuentaAnalisis.Importe2
                voParameters(15).Value = argPeriodoCuentaAnalisis.Porcentaje2
                voParameters(16).Value = argPeriodoCuentaAnalisis.Variacion2
                voParameters(17).Value = argPeriodoCuentaAnalisis.Soles2
                voParameters(18).Value = argPeriodoCuentaAnalisis.Dolares2
                voParameters(19).Value = argPeriodoCuentaAnalisis.Importe3
                voParameters(20).Value = argPeriodoCuentaAnalisis.Porcentaje3
                voParameters(21).Value = argPeriodoCuentaAnalisis.Variacion3
                voParameters(22).Value = argPeriodoCuentaAnalisis.Soles3
                voParameters(23).Value = argPeriodoCuentaAnalisis.Dolares3
                voParameters(24).Value = argPeriodoCuentaAnalisis.Importe4
                voParameters(25).Value = argPeriodoCuentaAnalisis.Porcentaje4
                voParameters(26).Value = argPeriodoCuentaAnalisis.Variacion4
                voParameters(27).Value = argPeriodoCuentaAnalisis.Soles4
                voParameters(28).Value = argPeriodoCuentaAnalisis.Dolares4
                voParameters(29).Value = argPeriodoCuentaAnalisis.Exposicion1
                voParameters(30).Value = argPeriodoCuentaAnalisis.Exposicion2
                voParameters(31).Value = argPeriodoCuentaAnalisis.Exposicion3
                voParameters(32).Value = argPeriodoCuentaAnalisis.Exposicion4

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As System.Data.DataSet Implements IPeriodoCuentaAnalisis.listar
            'Dim voSProc As String = "up_PeriodoCuentaAnalisis_Sel2"
            Dim voSProc As String = "up_PeriodoCuentaAnalisis_Sel2"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodoctaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodeeff", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcuentaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodtipocuenta", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argImporte1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argExposicion1", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion2", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion3", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion4", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCuentaAnalisis.Flag
                voParameters(1).Value = argPeriodoCuentaAnalisis.Codmetodizado
                voParameters(2).Value = argPeriodoCuentaAnalisis.Codcorrida
                voParameters(3).Value = argPeriodoCuentaAnalisis.Codperiodoctaanalisis
                voParameters(4).Value = argPeriodoCuentaAnalisis.Codanalisis
                voParameters(5).Value = argPeriodoCuentaAnalisis.Codeeff
                voParameters(6).Value = argPeriodoCuentaAnalisis.Codcuentaanalisis
                voParameters(7).Value = argPeriodoCuentaAnalisis.Descripcion
                voParameters(8).Value = argPeriodoCuentaAnalisis.Codtipocuenta
                voParameters(9).Value = argPeriodoCuentaAnalisis.Importe1
                voParameters(10).Value = argPeriodoCuentaAnalisis.Porcentaje1
                voParameters(11).Value = argPeriodoCuentaAnalisis.Variacion1
                voParameters(12).Value = argPeriodoCuentaAnalisis.Soles1
                voParameters(13).Value = argPeriodoCuentaAnalisis.Dolares1
                voParameters(14).Value = argPeriodoCuentaAnalisis.Importe2
                voParameters(15).Value = argPeriodoCuentaAnalisis.Porcentaje2
                voParameters(16).Value = argPeriodoCuentaAnalisis.Variacion2
                voParameters(17).Value = argPeriodoCuentaAnalisis.Soles2
                voParameters(18).Value = argPeriodoCuentaAnalisis.Dolares2
                voParameters(19).Value = argPeriodoCuentaAnalisis.Importe3
                voParameters(20).Value = argPeriodoCuentaAnalisis.Porcentaje3
                voParameters(21).Value = argPeriodoCuentaAnalisis.Variacion3
                voParameters(22).Value = argPeriodoCuentaAnalisis.Soles3
                voParameters(23).Value = argPeriodoCuentaAnalisis.Dolares3
                voParameters(24).Value = argPeriodoCuentaAnalisis.Importe4
                voParameters(25).Value = argPeriodoCuentaAnalisis.Porcentaje4
                voParameters(26).Value = argPeriodoCuentaAnalisis.Variacion4
                voParameters(27).Value = argPeriodoCuentaAnalisis.Soles4
                voParameters(28).Value = argPeriodoCuentaAnalisis.Dolares4
                voParameters(29).Value = argPeriodoCuentaAnalisis.Exposicion1
                voParameters(30).Value = argPeriodoCuentaAnalisis.Exposicion2
                voParameters(31).Value = argPeriodoCuentaAnalisis.Exposicion3
                voParameters(32).Value = argPeriodoCuentaAnalisis.Exposicion4

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean Implements IPeriodoCuentaAnalisis.modificar
            Dim voSProc As String = "up_PeriodoCuentaAnalisis_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt, 1), _
                        New SqlParameter("@argCodmetodizado", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcorrida", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodperiodoctaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodeeff", SqlDbType.Int, 4), _
                        New SqlParameter("@argCodcuentaanalisis", SqlDbType.Int, 4), _
                        New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 100), _
                        New SqlParameter("@argCodtipocuenta", SqlDbType.TinyInt, 4), _
                        New SqlParameter("@argImporte1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares1", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares2", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares3", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argImporte4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argPorcentaje4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argVariacion4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argSoles4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argDolares4", SqlDbType.Decimal, 12), _
                        New SqlParameter("@argExposicion1", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion2", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion3", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@argExposicion4", SqlDbType.NVarChar, 25), _
                        New SqlParameter("@outVal", SqlDbType.Int, 4, System.Data.ParameterDirection.Output, True, 0, 0, String.Empty, DataRowVersion.Current, 0) _
                }
                voParameters(0).Value = argPeriodoCuentaAnalisis.Flag
                voParameters(1).Value = argPeriodoCuentaAnalisis.Codmetodizado
                voParameters(2).Value = argPeriodoCuentaAnalisis.Codcorrida
                voParameters(3).Value = argPeriodoCuentaAnalisis.Codperiodoctaanalisis
                voParameters(4).Value = argPeriodoCuentaAnalisis.Codanalisis
                voParameters(5).Value = argPeriodoCuentaAnalisis.Codeeff
                voParameters(6).Value = argPeriodoCuentaAnalisis.Codcuentaanalisis
                voParameters(7).Value = argPeriodoCuentaAnalisis.Descripcion
                voParameters(8).Value = argPeriodoCuentaAnalisis.Codtipocuenta
                voParameters(9).Value = argPeriodoCuentaAnalisis.Importe1
                voParameters(10).Value = argPeriodoCuentaAnalisis.Porcentaje1
                voParameters(11).Value = argPeriodoCuentaAnalisis.Variacion1
                voParameters(12).Value = argPeriodoCuentaAnalisis.Soles1
                voParameters(13).Value = argPeriodoCuentaAnalisis.Dolares1
                voParameters(14).Value = argPeriodoCuentaAnalisis.Importe2
                voParameters(15).Value = argPeriodoCuentaAnalisis.Porcentaje2
                voParameters(16).Value = argPeriodoCuentaAnalisis.Variacion2
                voParameters(17).Value = argPeriodoCuentaAnalisis.Soles2
                voParameters(18).Value = argPeriodoCuentaAnalisis.Dolares2
                voParameters(19).Value = argPeriodoCuentaAnalisis.Importe3
                voParameters(20).Value = argPeriodoCuentaAnalisis.Porcentaje3
                voParameters(21).Value = argPeriodoCuentaAnalisis.Variacion3
                voParameters(22).Value = argPeriodoCuentaAnalisis.Soles3
                voParameters(23).Value = argPeriodoCuentaAnalisis.Dolares3
                voParameters(24).Value = argPeriodoCuentaAnalisis.Importe4
                voParameters(25).Value = argPeriodoCuentaAnalisis.Porcentaje4
                voParameters(26).Value = argPeriodoCuentaAnalisis.Variacion4
                voParameters(27).Value = argPeriodoCuentaAnalisis.Soles4
                voParameters(28).Value = argPeriodoCuentaAnalisis.Dolares4
                voParameters(29).Value = argPeriodoCuentaAnalisis.Exposicion1
                voParameters(30).Value = argPeriodoCuentaAnalisis.Exposicion2
                voParameters(31).Value = argPeriodoCuentaAnalisis.Exposicion3
                voParameters(32).Value = argPeriodoCuentaAnalisis.Exposicion4

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
    End Class
End Namespace
