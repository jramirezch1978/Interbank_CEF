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
   Public Class FormulaCovenant
        Inherits DAO

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
     Public Function agregar(ByRef pobeFormula As BusinessEntity.Formula, ByRef pintFlag As Integer) As Integer
            Dim voSProc As String = "up_COVENANT_Ins"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argFlag", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodMetodizado", SqlDbType.SmallInt), _
                    New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 200), _
                    New SqlParameter("@argEstado", SqlDbType.SmallInt), _
                    New SqlParameter("@argCodUsuario", SqlDbType.NVarChar, 50), _
                    New SqlParameter("@argFechReg", SqlDbType.DateTime), _
                    New SqlParameter("@codCondicion", SqlDbType.SmallInt), _
                    New SqlParameter("@argComentario", SqlDbType.VarChar, 500), _
                    New SqlParameter("@argCodNoContractual", SqlDbType.SmallInt), _
                    New SqlParameter("@outVal", SqlDbType.SmallInt) _
                }

                voParameters(0).Value = pintFlag
                voParameters(1).Value = pobeFormula.CodMetodizado
                voParameters(2).Value = pobeFormula.Descripcion
                voParameters(3).Value = pobeFormula.Estado
                voParameters(4).Value = pobeFormula.CodUsuario
                voParameters(5).Value = pobeFormula.FechRegisto
                voParameters(6).Value = pobeFormula.Condicion
                voParameters(7).Value = pobeFormula.Comentario
                voParameters(8).Value = pobeFormula.CodNoContractual
                voParameters(9).Direction = ParameterDirection.Output

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Dim inCodFormula As Integer = 0
                If voRC Then
                    If (Not voParameters(9).Value Is DBNull.Value) Then
                        inCodFormula = Convert.ToInt32(voParameters(9).Value)
                    End If
                End If
                Return (inCodFormula)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (0)
            End Try
        End Function

        <AutoComplete(True)> _
   Public Function modificar(ByRef pobeFormula As BusinessEntity.Formula) As Integer
            Dim voSProc As String = "up_COVENANT_Mod"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                    New SqlParameter("@argCodCovenant", SqlDbType.SmallInt), _
                    New SqlParameter("@argDescripcion", SqlDbType.NVarChar, 200), _
                    New SqlParameter("@argCondicion", SqlDbType.SmallInt), _
                    New SqlParameter("@argComentario", SqlDbType.VarChar, 500), _
                    New SqlParameter("@argCodNoContractual", SqlDbType.SmallInt), _
                    New SqlParameter("@outVal", SqlDbType.SmallInt) _
                }

                voParameters(0).Value = pobeFormula.CodFormula
                voParameters(1).Value = pobeFormula.Descripcion
                voParameters(2).Value = pobeFormula.Condicion
                voParameters(3).Value = pobeFormula.Comentario
                voParameters(4).Value = pobeFormula.CodNoContractual
                voParameters(5).Direction = ParameterDirection.Output

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Dim intReturn As Integer
                If voRC Then
                    If (Not voParameters(5).Value Is DBNull.Value) Then
                        intReturn = Convert.ToInt32(voParameters(5).Value)
                    End If
                End If
                Return (intReturn)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (0)
            End Try
        End Function

        <AutoComplete(True)> _
       Public Function listar(ByRef pintFlag As Integer, ByRef pintCodMetodizado As Integer) As DataSet
            Dim voSProc As String = "up_COVENANT_Lst"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.Int), _
                        New SqlParameter("@argCodMetodizado", SqlDbType.Int) _
                }
                voParameters(0).Value = pintFlag
                voParameters(1).Value = pintCodMetodizado


                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
     Public Function eliminar(ByRef pintCodCovenant As Integer) As Integer
            Dim voSProc As String = "up_COVENANT_Del"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodCovenant", SqlDbType.SmallInt), _
                        New SqlParameter("@outVal", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pintCodCovenant
                voParameters(1).Direction = ParameterDirection.Output


                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Dim intReturn As Integer
                If voRC Then
                    If (Not voParameters(1).Value Is DBNull.Value) Then
                        intReturn = Convert.ToInt32(voParameters(1).Value)
                    End If
                End If
                Return (intReturn)

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
  Public Function validar(ByRef pobeFormula As BusinessEntity.Formula) As Integer
            Dim voSProc As String = "up_COVENANT_ESTADO_Upd"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argFlag", SqlDbType.TinyInt), _
                        New SqlParameter("@argCodCovenant", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodEstado", SqlDbType.SmallInt), _
                        New SqlParameter("@argCodUsuarioVal", SqlDbType.NVarChar, 200), _
                        New SqlParameter("@outVal", SqlDbType.Int) _
                }

                voParameters(0).Value = pobeFormula.CodMetodizado
                voParameters(1).Value = pobeFormula.CodFormula
                voParameters(2).Value = pobeFormula.Estado
                voParameters(3).Value = pobeFormula.CodUsuarioVal
                voParameters(4).Direction = ParameterDirection.Output

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Dim voRC As Boolean = vcManejadoBD.ejecutarSProc(voSProc, voParameters)
                Dim intReturn As Integer
                If voRC Then
                    If (Not voParameters(4).Value Is DBNull.Value) Then
                        intReturn = Convert.ToInt32(voParameters(4).Value)
                    End If
                End If
                Return (intReturn)

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
     Public Function seleccionar(ByRef pintCodCovenant As Integer) As DataSet
            Dim voSProc As String = "up_COVENANT_Sel"
            Try
                Dim voParameters() As SqlParameter = _
                { _
                        New SqlParameter("@argCodCovenant", SqlDbType.SmallInt), _
                        New SqlParameter("@outVal", SqlDbType.TinyInt) _
                }
                voParameters(0).Value = pintCodCovenant
                voParameters(1).Direction = ParameterDirection.Output

                vcManejadoBD = New ManejadorBD(Globals.ccArchivoDataConfig, Globals.ccDataConfig_SeccionCadenaConexion, Globals.ccDataConfig_ClaveCEF)
                Return (vcManejadoBD.traerDatos(voSProc, voParameters))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

    End Class
End Namespace