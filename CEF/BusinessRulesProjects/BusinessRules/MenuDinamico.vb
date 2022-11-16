'*************************************************************
'Proposito: Menu dinamico para la seguridad de acceso
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
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

Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class MenuDinamico
        Inherits BLO
        Implements IMenuDinamico

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function buscarOpcion(ByVal pintCodMenu As Integer) As DataSet Implements IMenuDinamico.buscarOpcion
            Dim odaMenu As DataAccess.MenuDinamico = Nothing
            Try
                odaMenu = New DataAccess.MenuDinamico
                Return (odaMenu.buscarOpcion(pintCodMenu))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMenu Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMenu)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarOpcionInicio(ByVal pintCodMenu As Integer) As DataSet Implements IMenuDinamico.buscarOpcionInicio
            Dim odaMenu As DataAccess.MenuDinamico = Nothing
            Try
                odaMenu = New DataAccess.MenuDinamico
                Return (odaMenu.buscarOpcionInicio(pintCodMenu))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMenu Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMenu)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarOpcionHijos(ByVal pintCodMenu As Integer, ByVal pintCodOpcion As Integer) As DataSet Implements IMenuDinamico.buscarOpcionHijos
            Dim odaMenu As DataAccess.MenuDinamico = Nothing
            Try
                odaMenu = New DataAccess.MenuDinamico
                Return (odaMenu.buscarOpcionHijos(pintCodMenu, pintCodOpcion))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMenu Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMenu)
                End If
            End Try
        End Function

    End Class

End Namespace