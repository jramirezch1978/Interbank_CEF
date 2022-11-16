'*************************************************************
'Proposito:
'Autor: Miguel Delgado del Aguila
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class CuentaAnalisisLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As CuentaAnalisis
            Get
                Return CType(List(index), CuentaAnalisis)
            End Get
            Set(ByVal Value As CuentaAnalisis)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As CuentaAnalisis) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As CuentaAnalisis) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As CuentaAnalisis)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As CuentaAnalisis)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As CuentaAnalisis) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal pintCodCuentaAnalisis As Integer) As BusinessEntity.CuentaAnalisis
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obeCuentaAnalisis As BusinessEntity.CuentaAnalisis

            While (obeLst.MoveNext())
                obeCuentaAnalisis = CType(obeLst.Current, BusinessEntity.CuentaAnalisis)
                If (obeCuentaAnalisis.CodCuentaAnalisis = pintCodCuentaAnalisis) Then
                    Return obeCuentaAnalisis
                End If
            End While
            Return (Nothing)
        End Function

    End Class

End Namespace