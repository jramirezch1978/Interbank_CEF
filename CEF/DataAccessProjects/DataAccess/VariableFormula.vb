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
      Public Class VariableFormula
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeVariableFormula As BusinessEntity.VariableFormula, ByRef pintFlag As Integer) As Boolean
            Dim voSProc As String = "up_COVENANTFORMULA_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argFlag", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodCovenant", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodCuenta", SqlDbType.SmallInt), _
                    New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 200), _
                    New SqlParameter("@argValor", SqlDbType.Decimal), _
                    New SqlParameter("@argOrden", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 50), _
                    New SqlParameter("@argFechReg", SqlDbType.DateTime), _
                    New SqlParameter("@outVal", SqlDbType.SmallInt) _
                }

                voParameters(0).Value = pintFlag
                voParameters(1).Value = pobeVariableFormula.CodFormula
                voParameters(2).Value = pobeVariableFormula.CodCuenta
                voParameters(3).Value = pobeVariableFormula.Descripcion
                voParameters(4).Value = pobeVariableFormula.Valor
                voParameters(5).Value = pobeVariableFormula.Orden
                voParameters(6).Value = pobeVariableFormula.CodUsuario
                voParameters(7).Value = DateTime.Now
                voParameters(8).Value = ParameterDirection.Output

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Return (voRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            End Try
        End Function

        <AutoComplete(True)> _
     Public Function modificar_eliminar(ByRef pintCodCovenant As Integer) As Boolean
            Dim voSProc As String = "up_COVENANTFORMULA_Mod"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argCodCovenant", SqlDbType.SmallInt), _
                    New SqlParameter("@outVal", SqlDbType.SmallInt) _
                }

                voParameters(0).Value = pintCodCovenant
                voParameters(1).Value = ParameterDirection.Output

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