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
    Public Class PeriodoLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As Periodo
            Get
                Return CType(List(index), Periodo)
            End Get
            Set(ByVal Value As Periodo)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As Periodo) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As Periodo) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As Periodo)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As Periodo)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As Periodo) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal intCodMetodizado As Integer, ByVal intCodPeriodo As Integer) As Periodo
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obePeriodo As BusinessEntity.Periodo

            While (obeLst.MoveNext())
                obePeriodo = CType(obeLst.Current, BusinessEntity.Periodo)
                If (obePeriodo.CodMetodizado = intCodMetodizado And obePeriodo.CodPeriodo = intCodPeriodo) Then
                    Return obePeriodo
                End If
            End While
            Return (Nothing)
        End Function

        Public Function buscarPorFecha(ByVal intCodMetodizado As Integer, ByVal dteFecPeriodo As DateTime, ByVal intCodTipoEeff As Integer) As Periodo
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obePeriodo As BusinessEntity.Periodo

            While (obeLst.MoveNext())
                obePeriodo = CType(obeLst.Current, BusinessEntity.Periodo)
                If (obePeriodo.CodMetodizado = intCodMetodizado And obePeriodo.FecPeriodo = dteFecPeriodo And obePeriodo.CodTipoEeff = intCodTipoEeff) Then
                    Return obePeriodo
                End If
            End While
            Return (Nothing)
        End Function

    End Class

End Namespace
