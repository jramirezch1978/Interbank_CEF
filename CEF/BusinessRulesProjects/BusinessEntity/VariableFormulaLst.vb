Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class VariableFormulaLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As VariableFormula
            Get
                Return CType(List(index), VariableFormula)
            End Get
            Set(ByVal Value As VariableFormula)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As VariableFormula) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As VariableFormula) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As VariableFormula)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As VariableFormula)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As VariableFormula) As Boolean
            Return (List.Contains(value))
        End Function
    End Class

End Namespace
