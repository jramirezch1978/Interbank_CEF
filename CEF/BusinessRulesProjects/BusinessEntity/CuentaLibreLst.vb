'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class CuentaLibreLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As CuentaLibre
            Get
                Return CType(List(index), CuentaLibre)
            End Get
            Set(ByVal Value As CuentaLibre)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As CuentaLibre) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As CuentaLibre) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As CuentaLibre)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As CuentaLibre)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As CuentaLibre) As Boolean
            Return (List.Contains(value))
        End Function

    End Class

End Namespace
