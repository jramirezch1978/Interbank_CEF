'*************************************************************
'Proposito:
'Autor: XT8633
'Fecha Creacion:12-03-2019
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
    Public Class FormulaParametro
        Inherits DAO
        Sub New()
            MyBase.New()
        End Sub
        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pintCodCovenant As Integer) As DataSet
            Dim voSProc As String = "up_FORMULAPARAMETRO_Listar_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt), _
                        New SqlParameter("@codCovenant", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pbytFlag
                voParameters(1).Value = pintCodCovenant

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeFormParametro As BusinessEntity.FormulaParametro) As Boolean
            Dim voSProc As String = "up_FORMULAPARAMETRO_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argCodParametro", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodCovenant", SqlDbType.Int), _
                    New SqlParameter("@argAnio", SqlDbType.NVarChar, 10), _
                    New SqlParameter("@argValor", SqlDbType.Decimal), _
                    New SqlParameter("@argUsuario", SqlDbType.NVarChar, 50) _
                }
                voParameters(0).Direction = ParameterDirection.Output
                voParameters(1).Value = pobeFormParametro.CodCovenant
                voParameters(2).Value = pobeFormParametro.Anio
                voParameters(3).Value = pobeFormParametro.Valor
                voParameters(4).Value = pobeFormParametro.Usuario

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                If voRC Then
                    If (Not voParameters(0).Value Is DBNull.Value) Then
                        pobeFormParametro.CodFormulaParametro = Convert.ToInt32(voParameters(0).Value)
                    End If
                End If
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeFormParametro As BusinessEntity.FormulaParametro) As Boolean
            Dim voSProc As String = "up_FORMULAPARAMETRO_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodParametro", SqlDbType.SmallInt), _
                        New SqlParameter("@argAnio", SqlDbType.NChar, 50), _
                        New SqlParameter("@argValor", SqlDbType.Decimal) _
                }
                voParameters(0).Value = pobeFormParametro.CodFormulaParametro
                voParameters(1).Value = pobeFormParametro.Anio
                voParameters(2).Value = pobeFormParametro.Valor

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodParametro As Integer) As Boolean
            Dim voSProc As String = "up_FORMULAPARAMETRO_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodParametro", SqlDbType.SmallInt) _
                }
                voParameters(0).Value = pintCodParametro

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

