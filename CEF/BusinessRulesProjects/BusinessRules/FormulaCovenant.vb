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
    Public Class FormulaCovenant
        Inherits BLO
        Implements IFormulaCovenant

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
      Public Function agregar(ByRef pobeFormula As BusinessEntity.Formula, ByRef pintFlag As Integer) As Integer Implements IFormulaCovenant.agregar
            Dim odaFormulaCovenant As DataAccess.FormulaCovenant = Nothing
            Try
                odaFormulaCovenant = New DataAccess.FormulaCovenant
                pobeFormula.FechRegisto = DateTime.Now
                Return (odaFormulaCovenant.agregar(pobeFormula, pintFlag))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaFormulaCovenant Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormulaCovenant)
                End If
            End Try
        End Function


        <AutoComplete(True)> _
    Public Function modificar(ByRef pobeFormula As BusinessEntity.Formula) As Integer Implements IFormulaCovenant.modificar
            Dim odaFormulaCovenant As DataAccess.FormulaCovenant = Nothing
            Try
                odaFormulaCovenant = New DataAccess.FormulaCovenant
                Return (odaFormulaCovenant.modificar(pobeFormula))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaFormulaCovenant Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormulaCovenant)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
   Public Function validar(ByRef pobeFormula As BusinessEntity.Formula) As Integer Implements IFormulaCovenant.validar
            Dim odaFormulaCovenant As DataAccess.FormulaCovenant = Nothing
            Try
                odaFormulaCovenant = New DataAccess.FormulaCovenant
                Return (odaFormulaCovenant.validar(pobeFormula))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaFormulaCovenant Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormulaCovenant)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByRef pintFlag As Integer, ByRef pintCodMetodizado As Integer) As DataSet Implements IFormulaCovenant.listar
            Dim odaFormulaCovenant As DataAccess.FormulaCovenant = Nothing
            Try
                odaFormulaCovenant = New DataAccess.FormulaCovenant
                Return (odaFormulaCovenant.listar(pintFlag, pintCodMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormulaCovenant Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormulaCovenant)
                End If
            End Try
        End Function


        <AutoComplete(True)> _
      Public Function eliminar(ByRef pintCodCovenant As Integer) As Integer Implements IFormulaCovenant.eliminar
            Dim odaFormulaCovenant As DataAccess.FormulaCovenant = Nothing
            Try
                odaFormulaCovenant = New DataAccess.FormulaCovenant

                Return (odaFormulaCovenant.eliminar(pintCodCovenant))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaFormulaCovenant Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormulaCovenant)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
      Public Function seleccionar(ByRef pintCodCovenant As Integer) As DataSet Implements IFormulaCovenant.seleccionar
            Dim odaFormulaCovenant As DataAccess.FormulaCovenant = Nothing
            Try
                odaFormulaCovenant = New DataAccess.FormulaCovenant
                Return (odaFormulaCovenant.seleccionar(pintCodCovenant))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormulaCovenant Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormulaCovenant)
                End If
            End Try
        End Function

    End Class

End Namespace
