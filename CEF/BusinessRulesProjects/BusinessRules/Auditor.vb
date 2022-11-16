'*************************************************************
'Proposito: 
'Autor: María Laura Santisteban Valdez
'Fecha Creacion:27/03/2006
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
    Public Class Auditor
        Inherits BLO
        Implements IAuditor

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodAuditor As Integer) As BusinessEntity.Auditor Implements IAuditor.leer
            Dim odaAuditor As DataAccess.Auditor = Nothing
            Dim dsAuditor As DataSet
            Try
                odaAuditor = New DataAccess.Auditor
                dsAuditor = odaAuditor.leer(pintCodAuditor)
                Dim obeAuditor As BusinessEntity.Auditor
                If dsAuditor.Tables(0).Rows.Count > 0 Then
                    obeAuditor = New BusinessEntity.Auditor
                    obeAuditor.CodAuditor = dsAuditor.Tables(0).Rows(0)("CodAuditor")
                    obeAuditor.RazonSocial = dsAuditor.Tables(0).Rows(0)("RazonSocial")
                    obeAuditor.Estado = dsAuditor.Tables(0).Rows(0)("Estado")
                End If
                Return (obeAuditor)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAuditor Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAuditor)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements IAuditor.listar
            Dim odaAuditor As DataAccess.Auditor = Nothing
            Try
                odaAuditor = New DataAccess.Auditor
                Return (odaAuditor.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAuditor Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAuditor)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeAuditor As BusinessEntity.Auditor) As Boolean Implements IAuditor.agregar
            Dim odaAuditor As DataAccess.Auditor = Nothing
            Try
                odaAuditor = New DataAccess.Auditor
                pobeAuditor.FecReg = DateTime.Today()
                Return (odaAuditor.agregar(pobeAuditor))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAuditor Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAuditor)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeAuditor As BusinessEntity.Auditor) As Boolean Implements IAuditor.modificar
            Dim odaAuditor As DataAccess.Auditor = Nothing
            Try
                odaAuditor = New DataAccess.Auditor
                Return (odaAuditor.modificar(pobeAuditor))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAuditor Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAuditor)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodAuditor As Integer) As Boolean Implements IAuditor.eliminar
            Dim odaAuditor As DataAccess.Auditor = Nothing
            Try
                odaAuditor = New DataAccess.Auditor
                Return (odaAuditor.eliminar(pintCodAuditor))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAuditor Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAuditor)
                End If
            End Try
        End Function


    End Class

End Namespace
