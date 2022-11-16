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
    Public Class VariableFormula
        Inherits BLO
        Implements IVariableFormula

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
      Public Function agregar(ByRef pobeVariableFormula As BusinessEntity.VariableFormula, ByRef pintFlag As Integer) As Boolean Implements IVariableFormula.agregar
            Dim odaVariableFormula As DataAccess.VariableFormula = Nothing
            Try
                odaVariableFormula = New DataAccess.VariableFormula
                pobeVariableFormula.FechRegistro = DateTime.Now
                Return (odaVariableFormula.agregar(pobeVariableFormula, pintFlag))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaVariableFormula Is Nothing) Then
                    ServicedComponent.DisposeObject(odaVariableFormula)
                End If
            End Try
        End Function


        <AutoComplete(True)> _
     Public Function modificar_eliminar(ByRef pintCodCovenant As Integer) As Boolean Implements IVariableFormula.modificar_eliminar
            Dim odaVariableFormula As DataAccess.VariableFormula = Nothing
            Try
                odaVariableFormula = New DataAccess.VariableFormula
                Return (odaVariableFormula.modificar_eliminar(pintCodCovenant))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaVariableFormula Is Nothing) Then
                    ServicedComponent.DisposeObject(odaVariableFormula)
                End If
            End Try
        End Function
    End Class

End Namespace