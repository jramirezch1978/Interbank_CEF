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
    Public Class RCD
        Inherits BLO
        Implements IRCD

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listar(ByVal pintAnioPeriodo As Integer, ByVal pintMesPeriodo As Integer, ByVal pintDiaPeriodo As Integer) As DataSet Implements IRCD.listar
            Dim odaRCD As DataAccess.RCD = Nothing
            Try
                odaRCD = New DataAccess.RCD
                Return (odaRCD.listar(pintAnioPeriodo, pintMesPeriodo, pintDiaPeriodo))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaRCD Is Nothing) Then
                    ServicedComponent.DisposeObject(odaRCD)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeRCD As BusinessEntity.RCD) As Boolean Implements IRCD.agregar
            Dim odaRCD As DataAccess.RCD = Nothing
            Try
                odaRCD = New DataAccess.RCD
                pobeRCD.FecReg = DateTime.Today
                Return (odaRCD.agregar(pobeRCD))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaRCD Is Nothing) Then
                    ServicedComponent.DisposeObject(odaRCD)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeRDC As BusinessEntity.RCD) As Boolean Implements IRCD.modificar
            Dim odaRCD As DataAccess.RCD = Nothing
            Try
                odaRCD = New DataAccess.RCD
                Return (odaRCD.modificar(pobeRDC))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaRCD Is Nothing) Then
                    ServicedComponent.DisposeObject(odaRCD)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef pobeRDC As BusinessEntity.RCD) As Boolean Implements IRCD.eliminar
            Dim odaRCD As DataAccess.RCD = Nothing
            Try
                odaRCD = New DataAccess.RCD
                Return (odaRCD.eliminar(pobeRDC))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaRCD Is Nothing) Then
                    ServicedComponent.DisposeObject(odaRCD)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function cruceEEFFValidados(ByVal pdteFecPeriodo As DateTime) As DataSet Implements IRCD.cruceEEFFValidados
            Dim odaRCD As DataAccess.RCD = Nothing
            Try
                odaRCD = New DataAccess.RCD
                Return (odaRCD.cruceEEFFValidados(pdteFecPeriodo))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaRCD Is Nothing) Then
                    ServicedComponent.DisposeObject(odaRCD)
                End If
            End Try
        End Function
    End Class


End Namespace