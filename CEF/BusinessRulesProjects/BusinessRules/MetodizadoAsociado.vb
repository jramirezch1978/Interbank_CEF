'*************************************************************
'Proposito:
'Autor: XT8633
'Fecha Creacion:24-10-2019
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices

Imports CEF.Common
Imports CEF.DataAccess
Imports System.Reflection

Namespace CEF.BusinessRules
    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class MetodizadoAsociado
        Inherits BLO
        Implements IMetodizadoAsociado

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function agregar(ByRef pintCodmetodizado As Integer, ByRef psrtCodUnico As String) As String Implements IMetodizadoAsociado.agregar
            Dim odaMetodizadoAsociado As DataAccess.MetodizadoAsociado = Nothing
            Try
                odaMetodizadoAsociado = New DataAccess.MetodizadoAsociado
                Return (odaMetodizadoAsociado.agregar(pintCodmetodizado, psrtCodUnico))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizadoAsociado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizadoAsociado)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByRef pintCodMetodizado As Integer) As System.Data.DataSet Implements IMetodizadoAsociado.listar

            Dim odaMetodizadoAsociado As DataAccess.MetodizadoAsociado = Nothing
            Try
                odaMetodizadoAsociado = New DataAccess.MetodizadoAsociado
                Return (odaMetodizadoAsociado.listar(pintCodMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizadoAsociado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizadoAsociado)
                End If
            End Try

        End Function
        <AutoComplete(True)> _
        Public Function buscarCliente(ByRef pstrFiltro As String) As System.Data.DataSet Implements IMetodizadoAsociado.buscarCliente

            Dim odaMetodizadoAsociado As DataAccess.MetodizadoAsociado = Nothing
            Try
                odaMetodizadoAsociado = New DataAccess.MetodizadoAsociado
                Return (odaMetodizadoAsociado.buscarCliente(pstrFiltro))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizadoAsociado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizadoAsociado)
                End If
            End Try

        End Function
        <AutoComplete(True)> _
        Public Function eliminar(ByRef pintCodmetodizado As Integer, ByRef pstrCodUnico As String) As Integer Implements IMetodizadoAsociado.eliminar
            Dim odaMetodizadoAsociado As DataAccess.MetodizadoAsociado = Nothing
            Try
                odaMetodizadoAsociado = New DataAccess.MetodizadoAsociado
                Return (odaMetodizadoAsociado.eliminar(pintCodmetodizado, pstrCodUnico))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaMetodizadoAsociado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizadoAsociado)
                End If
            End Try
        End Function
    End Class
End Namespace
