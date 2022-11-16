'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class PeriodoCuentaAnalisisLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As PeriodoCuentaAnalisis
            Get
                Return CType(List(index), PeriodoCuentaAnalisis)
            End Get
            Set(ByVal Value As PeriodoCuentaAnalisis)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As PeriodoCuentaAnalisis) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As PeriodoCuentaAnalisis) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As PeriodoCuentaAnalisis)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As PeriodoCuentaAnalisis)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As PeriodoCuentaAnalisis) As Boolean
            Return (List.Contains(value))
        End Function
    End Class

End Namespace