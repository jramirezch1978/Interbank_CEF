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
    Public Class PeriodoCorridaLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As PeriodoCorrida
            Get
                Return CType(List(index), PeriodoCorrida)
            End Get
            Set(ByVal Value As PeriodoCorrida)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As PeriodoCorrida) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As PeriodoCorrida) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As PeriodoCorrida)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As PeriodoCorrida)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As PeriodoCorrida) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal intCodMetodizado As Integer, ByVal intCodCorrida As Integer, ByVal intCodPeriodo As Integer) As PeriodoCorrida
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obePeriodoCorrida As BusinessEntity.PeriodoCorrida

            While (obeLst.MoveNext())
                obePeriodoCorrida = CType(obeLst.Current, BusinessEntity.PeriodoCorrida)
                If (obePeriodoCorrida.CodMetodizado = intCodMetodizado AndAlso obePeriodoCorrida.CodCorrida = intCodCorrida AndAlso obePeriodoCorrida.CodPeriodo = intCodPeriodo) Then
                    Return obePeriodoCorrida
                End If
            End While

            Return (Nothing)
        End Function
    End Class
End Namespace