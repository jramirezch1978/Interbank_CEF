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
    Public Class Formula
        Inherits BLO
        Implements IFormula

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements IFormula.listar
            Dim odaFormula As DataAccess.Formula = Nothing
            Try
                odaFormula = New DataAccess.Formula
                Return (odaFormula.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormula Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormula)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarPorAnalisis(ByVal pintCodAnalisis As Integer) As DataSet Implements IFormula.buscarPorAnalisis
            Dim odaFormula As DataAccess.Formula = Nothing
            Try
                odaFormula = New DataAccess.Formula
                Return (odaFormula.buscarPorAnalisis(pintCodAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormula Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormula)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarEnCuentaPorAnalisis(ByVal pintCodAnalisis As Integer, ByVal pintFlgBPE As Integer) As DataSet Implements IFormula.buscarEnCuentaPorAnalisis
            Dim odaFormula As DataAccess.Formula = Nothing
            Try
                odaFormula = New DataAccess.Formula
                Return (odaFormula.buscarEnCuentaPorAnalisis(pintCodAnalisis, pintFlgBPE))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormula Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormula)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarSentencia(ByVal pintCodFormula As Integer) As DataSet Implements IFormula.listarSentencia
            Dim odaFormula As DataAccess.Formula = Nothing
            Try
                odaFormula = New DataAccess.Formula
                Return (odaFormula.listarSentencia(pintCodFormula))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormula Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormula)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarSentenciaPorAnalisis(ByVal pintCodAnalisis As Integer) As DataSet Implements IFormula.buscarSentenciaPorAnalisis
            Dim odaFormula As DataAccess.Formula = Nothing
            Try
                odaFormula = New DataAccess.Formula
                Return (odaFormula.buscarSentenciaPorAnalisis(pintCodAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormula Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormula)
                End If
            End Try
        End Function

    End Class

End Namespace