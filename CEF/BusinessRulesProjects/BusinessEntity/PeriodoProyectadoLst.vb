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
    Public Class PeriodoProyectadoLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As PeriodoProyectado
            Get
                Return CType(List(index), PeriodoProyectado)
            End Get
            Set(ByVal Value As PeriodoProyectado)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As PeriodoProyectado) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As PeriodoProyectado) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As PeriodoProyectado)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As PeriodoProyectado)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As PeriodoProyectado) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal intCodSupuesto As Integer, ByVal intCodProyectado As Integer) As PeriodoProyectado
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obePeriodoProyectado As BusinessEntity.PeriodoProyectado

            While (obeLst.MoveNext())
                obePeriodoProyectado = CType(obeLst.Current, BusinessEntity.PeriodoProyectado)
                If (obePeriodoProyectado.CodSupuesto = intCodSupuesto And obePeriodoProyectado.CodProyectado = intCodProyectado) Then
                    Return obePeriodoProyectado
                End If
            End While
            Return (Nothing)
        End Function

    End Class

End Namespace