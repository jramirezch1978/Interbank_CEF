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
    Public Class PeriodoCuentaLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As PeriodoCuenta
            Get
                Return CType(List(index), PeriodoCuenta)
            End Get
            Set(ByVal Value As PeriodoCuenta)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As PeriodoCuenta) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As PeriodoCuenta) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As PeriodoCuenta)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As PeriodoCuenta)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As PeriodoCuenta) As Boolean
            Return (List.Contains(value))
        End Function

    End Class

End Namespace