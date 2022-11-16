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
    Public Class EEFF
        Inherits BLO
        Implements IEEFF

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodEEFF As Integer) As BusinessEntity.EEFF Implements IEEFF.leer
            Dim odaEEFF As DataAccess.EEFF = Nothing
            Try
                odaEEFF = New DataAccess.EEFF
                Dim dsEEFF As DataSet = odaEEFF.leer(pintCodEEFF)
                Dim obeEEFF As BusinessEntity.EEFF
                If dsEEFF.Tables(0).Rows.Count > 0 Then
                    obeEEFF = New BusinessEntity.EEFF
                    obeEEFF.CodEeff = dsEEFF.Tables(0).Rows(0)("CodEeff")
                    obeEEFF.Descripcion = dsEEFF.Tables(0).Rows(0)("Descripcion")
                    obeEEFF.Estado = dsEEFF.Tables(0).Rows(0)("Estado")
                End If
                Return (obeEEFF)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaEEFF)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements IEEFF.listar
            Dim odaEEFF As DataAccess.EEFF = Nothing
            Try
                odaEEFF = New DataAccess.EEFF
                Return (odaEEFF.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaEEFF)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeEEFF As BusinessEntity.EEFF) As Boolean Implements IEEFF.agregar
            Dim odaEEFF As DataAccess.EEFF = Nothing
            Try
                odaEEFF = New DataAccess.EEFF
                pobeEEFF.FecReg = DateTime.Today
                Return (odaEEFF.agregar(pobeEEFF))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaEEFF)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeEEFF As BusinessEntity.EEFF) As Boolean Implements IEEFF.modificar
            Dim odaEEFF As DataAccess.EEFF = Nothing
            Try
                odaEEFF = New DataAccess.EEFF
                Return (odaEEFF.modificar(pobeEEFF))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaEEFF)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodEeff As Integer) As Boolean Implements IEEFF.eliminar
            Dim odaEEFF As DataAccess.EEFF = Nothing
            Try
                odaEEFF = New DataAccess.EEFF
                Return (odaEEFF.eliminar(pintCodEeff))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaEEFF)
                End If
            End Try
        End Function

    End Class

End Namespace