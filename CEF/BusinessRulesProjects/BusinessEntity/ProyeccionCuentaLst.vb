Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
        Public Class ProyeccionCuentaLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As ProyeccionCuentaBE
            Get
                Return CType(List(index), ProyeccionCuentaBE)
            End Get
            Set(ByVal Value As ProyeccionCuentaBE)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As ProyeccionCuentaBE) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As ProyeccionCuentaBE) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As ProyeccionCuentaBE)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As ProyeccionCuentaBE)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As ProyeccionCuentaBE) As Boolean
            Return (List.Contains(value))
        End Function

    End Class

End Namespace