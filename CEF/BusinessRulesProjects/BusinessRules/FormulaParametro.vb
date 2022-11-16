'*************************************************************
'Proposito:
'Autor: XT8633
'Fecha Creacion:12-03-2019
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
    Public Class FormulaParametro
        Inherits BLO
        Implements IFormulaParametro

        Public Function agregar(ByRef pobeFormParametro As BusinessEntity.FormulaParametro) As Boolean Implements IFormulaParametro.agregar
            Dim odaFormParametro As DataAccess.FormulaParametro = Nothing
            Try
                odaFormParametro = New DataAccess.FormulaParametro
                Return (odaFormParametro.agregar(pobeFormParametro))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormParametro)
                End If
            End Try

        End Function

        Public Function eliminar(ByVal pintCodParametro As Integer) As Boolean Implements IFormulaParametro.eliminar
            Dim odaFormParametro As DataAccess.FormulaParametro = Nothing
            Try
                odaFormParametro = New DataAccess.FormulaParametro
                Return (odaFormParametro.eliminar(pintCodParametro))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormParametro)
                End If
            End Try

        End Function

        'Public Function leer(ByVal pintCodTipoEEFF As Integer) As BusinessEntity.FormulaParametro Implements IFormulaParametro.leer
        '    Dim odaFormulaParametro As DataAccess.FormulaParametro = Nothing
        '    odaFormulaParametro = New DataAccess.FormulaParametro
        '    Return odaFormulaParametro
        'End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pintCodCovenant As Integer) As System.Data.DataSet Implements IFormulaParametro.listar
            Dim odaFormulaParametro As DataAccess.FormulaParametro = Nothing
            Try
                odaFormulaParametro = New DataAccess.FormulaParametro
                Return (odaFormulaParametro.listar(pbytFlag, pintCodCovenant))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormulaParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormulaParametro)
                End If
            End Try
        End Function

        Public Function modificar(ByRef pobeFormParametro As BusinessEntity.FormulaParametro) As Boolean Implements IFormulaParametro.modificar
            Dim odaFormParametro As DataAccess.FormulaParametro = Nothing
            Try
                odaFormParametro = New DataAccess.FormulaParametro
                Return (odaFormParametro.modificar(pobeFormParametro))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormParametro)
                End If
            End Try
        End Function
    End Class
End Namespace

