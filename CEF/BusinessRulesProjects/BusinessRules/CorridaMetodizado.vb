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
    Public Class CorridaMetodizado
        Inherits BLO
        Implements ICorridaMetodizado

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function agregar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean Implements ICorridaMetodizado.agregar
            Dim odaCorridaMetodizado As DataAccess.CorridaMetodizado = Nothing
            Try
                odaCorridaMetodizado = New DataAccess.CorridaMetodizado
                Return (odaCorridaMetodizado.agregar(argCorridaMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCorridaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCorridaMetodizado)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean Implements ICorridaMetodizado.eliminar
            Dim odaCorridaMetodizado As DataAccess.CorridaMetodizado = Nothing
            Try
                odaCorridaMetodizado = New DataAccess.CorridaMetodizado
                Return (odaCorridaMetodizado.eliminar(argCorridaMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCorridaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCorridaMetodizado)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leer(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As BusinessEntity.CorridaMetodizado Implements ICorridaMetodizado.leer
            Dim odaCorridaMetodizado As DataAccess.CorridaMetodizado = Nothing
            Dim obeCorridaMetodizado As BusinessEntity.CorridaMetodizado = Nothing

            Try
                odaCorridaMetodizado = New DataAccess.CorridaMetodizado
                Dim dsCorridaMetodizado As DataSet = odaCorridaMetodizado.leer(argCorridaMetodizado)

                If dsCorridaMetodizado.Tables(0).Rows.Count > 0 Then
                    Dim oFila As DataRow = dsCorridaMetodizado.Tables(0).Rows(0)
                    obeCorridaMetodizado = New BusinessEntity.CorridaMetodizado
                    If Not oFila("CodMetodizado") Is DBNull.Value Then obeCorridaMetodizado.CodMetodizado = oFila("CodMetodizado")
                    If Not oFila("CodCorrida") Is DBNull.Value Then obeCorridaMetodizado.CodCorrida = oFila("CodCorrida")
                    If Not oFila("CodUsuarioReg") Is DBNull.Value Then obeCorridaMetodizado.CodUsuarioReg = oFila("CodUsuarioReg")
                    If Not oFila("FecReg") Is DBNull.Value Then obeCorridaMetodizado.FecReg = oFila("FecReg")
                    If Not oFila("CodUsuarioUpd") Is DBNull.Value Then obeCorridaMetodizado.CodUsuarioUpd = oFila("CodUsuarioUpd")
                    If Not oFila("FecUpd") Is DBNull.Value Then obeCorridaMetodizado.FecUpd = oFila("FecUpd")
                    If Not oFila("Estado") Is DBNull.Value Then obeCorridaMetodizado.Estado = oFila("Estado")
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not argCorridaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCorridaMetodizado)
                End If
            End Try

            Return obeCorridaMetodizado
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As System.Data.DataSet Implements ICorridaMetodizado.listar
            Dim odaCorridaMetodizado As DataAccess.CorridaMetodizado = Nothing
            Try
                odaCorridaMetodizado = New DataAccess.CorridaMetodizado
                Return (odaCorridaMetodizado.listar(argCorridaMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCorridaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCorridaMetodizado)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean Implements ICorridaMetodizado.modificar
            Dim odaCorridaMetodizado As DataAccess.CorridaMetodizado = Nothing
            Try
                odaCorridaMetodizado = New DataAccess.CorridaMetodizado
                Return (odaCorridaMetodizado.modificar(argCorridaMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCorridaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCorridaMetodizado)
                End If
            End Try
        End Function

    End Class

End Namespace