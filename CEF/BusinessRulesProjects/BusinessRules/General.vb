'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por: María Laura Santisteban
'Fecha Mod.: 31/03/2006     
'*************************************************************

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.DataAccess

Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class General
        Inherits BLO
        Implements IGeneral

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodTbl As Integer, ByVal pintCodItem As Integer) As BusinessEntity.General Implements IGeneral.leer
            Dim odaGeneral As DataAccess.General = Nothing
            Dim dsGeneral As DataSet
            Try
                odaGeneral = New DataAccess.General
                dsGeneral = odaGeneral.leer(pintCodTbl, pintCodItem)
                Dim obeGeneral As BusinessEntity.General
                If dsGeneral.Tables(0).Rows.Count > 0 Then
                    obeGeneral = New BusinessEntity.General
                    obeGeneral.CodItem = dsGeneral.Tables(0).Rows(0)("CodItem")
                    obeGeneral.Descripcion = dsGeneral.Tables(0).Rows(0)("Descripcion")
                    obeGeneral.DesCorta = dsGeneral.Tables(0).Rows(0)("DesCorta")
                    obeGeneral.Estado = dsGeneral.Tables(0).Rows(0)("Estado")
                End If
                Return (obeGeneral)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGeneral Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGeneral)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pintCodTbl As Integer) As DataSet Implements IGeneral.listar
            Dim odaGeneral As DataAccess.General = Nothing
            Try
                odaGeneral = New DataAccess.General
                Return (odaGeneral.listar(pintCodTbl))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGeneral Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGeneral)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeGeneral As BusinessEntity.General) As Boolean Implements IGeneral.agregar
            Dim odaGeneral As DataAccess.General = Nothing
            Try
                odaGeneral = New DataAccess.General
                pobeGeneral.FecReg = DateTime.Today
                Return (odaGeneral.agregar(pobeGeneral))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGeneral Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGeneral)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeGeneral As BusinessEntity.General) As Boolean Implements IGeneral.modificar
            Dim odaGeneral As DataAccess.General = Nothing
            Try
                odaGeneral = New DataAccess.General
                Return (odaGeneral.modificar(pobeGeneral))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGeneral Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGeneral)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodTbl As Integer, ByVal pintCodItem As Integer) As Boolean Implements IGeneral.eliminar
            Dim odaGeneral As DataAccess.General = Nothing
            Try
                odaGeneral = New DataAccess.General
                If pintCodTbl = Int32.Parse(ecTablaGeneral.TABLA) Then
                    If odaGeneral.listar(pintCodItem).Tables(0).Rows.Count > 0 Then Return (False)
                End If
                Return (odaGeneral.eliminar(pintCodTbl, pintCodItem))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGeneral Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGeneral)
                End If
            End Try
        End Function

    End Class

End Namespace