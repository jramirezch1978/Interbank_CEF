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
Imports CEF.DataAccess

Imports CEF.BusinessEntity
Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class PeriodoCorrida
        Inherits BLO
        Implements IPeriodoCorrida

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function agregar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean Implements IPeriodoCorrida.agregar
            Dim odaPeriodoCorrida As DataAccess.PeriodoCorrida = Nothing
            Try
                odaPeriodoCorrida = New DataAccess.PeriodoCorrida
                Return (odaPeriodoCorrida.agregar(argPeriodoCorrida))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPeriodoCorrida Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCorrida)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean Implements IPeriodoCorrida.eliminar
            Dim odaPeriodoCorrida As DataAccess.PeriodoCorrida = Nothing
            Try
                odaPeriodoCorrida = New DataAccess.PeriodoCorrida
                Return (odaPeriodoCorrida.eliminar(argPeriodoCorrida))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPeriodoCorrida Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCorrida)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leer(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As BusinessEntity.PeriodoCorrida Implements IPeriodoCorrida.leer
            Dim odaPeriodoCorrida As DataAccess.PeriodoCorrida = Nothing
            Dim obePeriodoCorrida As BusinessEntity.PeriodoCorrida = Nothing

            Try
                odaPeriodoCorrida = New DataAccess.PeriodoCorrida
                Dim dsCorridaMetodizado As DataSet = odaPeriodoCorrida.leer(argPeriodoCorrida)
                If dsCorridaMetodizado.Tables(0).Rows.Count > 0 Then
                    obePeriodoCorrida = New BusinessEntity.PeriodoCorrida
                    obePeriodoCorrida.CodMetodizado = dsCorridaMetodizado.Tables(0).Rows(0)("CodMetodizado")
                    obePeriodoCorrida.CodCorrida = dsCorridaMetodizado.Tables(0).Rows(0)("CodCorrida")
                    obePeriodoCorrida.CodPeriodo = dsCorridaMetodizado.Tables(0).Rows(0)("CodPeriodo")
                    obePeriodoCorrida.Orden = dsCorridaMetodizado.Tables(0).Rows(0)("Orden")
                    obePeriodoCorrida.Estado = dsCorridaMetodizado.Tables(0).Rows(0)("Estado")
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not argPeriodoCorrida Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCorrida)
                End If
            End Try

            Return obePeriodoCorrida
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As System.Data.DataSet Implements IPeriodoCorrida.listar
            Dim odaPeriodoCorrida As DataAccess.PeriodoCorrida = Nothing
            Try
                odaPeriodoCorrida = New DataAccess.PeriodoCorrida
                Return (odaPeriodoCorrida.listar(argPeriodoCorrida))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPeriodoCorrida Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCorrida)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean Implements IPeriodoCorrida.modificar
            Dim odaPeriodoCorrida As DataAccess.PeriodoCorrida = Nothing
            Try
                odaPeriodoCorrida = New DataAccess.PeriodoCorrida
                Return (odaPeriodoCorrida.modificar(argPeriodoCorrida))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPeriodoCorrida Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCorrida)
                End If
            End Try
        End Function
    End Class
End Namespace