'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 14/01/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.DataAccess
Imports CEF.BusinessEntity
Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class CuentaAnalisis
        Inherits BLO
        Implements ICuentaAnalisis

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listar(ByVal pshoCodAnalisis As Short) As DataSet Implements ICuentaAnalisis.listar
            Dim odaCuentaAnalisis As DataAccess.CuentaAnalisis = Nothing
            Try
                odaCuentaAnalisis = New DataAccess.CuentaAnalisis
                Return (odaCuentaAnalisis.listar(pshoCodAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuentaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarMasCuentaLibre(ByVal pshoCodAnalisis As Short, ByVal pintMetodizado As Integer) As DataSet Implements ICuentaAnalisis.listarMasCuentaLibre
            Dim odaCuentaAnalisis As DataAccess.CuentaAnalisis = Nothing
            Try
                odaCuentaAnalisis = New DataAccess.CuentaAnalisis
                Return (odaCuentaAnalisis.listarMasCuentaLibre(pshoCodAnalisis, pintMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuentaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function ListarPorAnalisis(ByVal pshoCodAnalisis As Short, ByVal pintCodCuentaAnalisis As Integer, ByVal pshoIndicador As Short) As DataSet Implements ICuentaAnalisis.ListarPorAnalisis
            Dim odaCuentaAnalisis As DataAccess.CuentaAnalisis = Nothing
            Try
                odaCuentaAnalisis = New DataAccess.CuentaAnalisis
                Return (odaCuentaAnalisis.ListarPorAnalisis(pshoCodAnalisis, pintCodCuentaAnalisis, pshoIndicador))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuentaAnalisis)
                End If
            End Try
        End Function

    End Class

End Namespace