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
    Public Class SupuestoHistoricoLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As SupuestoHistorico
            Get
                Return CType(List(index), SupuestoHistorico)
            End Get
            Set(ByVal Value As SupuestoHistorico)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As SupuestoHistorico) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As SupuestoHistorico) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As SupuestoHistorico)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As SupuestoHistorico)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As SupuestoHistorico) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal intCodSupuesto As Integer, ByVal intCodCuentaSupuesto As Integer) As SupuestoHistorico
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obeSupuestoHistorico As BusinessEntity.SupuestoHistorico

            While (obeLst.MoveNext())
                obeSupuestoHistorico = CType(obeLst.Current, BusinessEntity.SupuestoHistorico)
                If (obeSupuestoHistorico.CodSupuesto = intCodSupuesto And obeSupuestoHistorico.CodCuentaSupuesto = intCodCuentaSupuesto) Then
                    Return obeSupuestoHistorico
                End If
            End While
            Return (Nothing)
        End Function

    End Class

End Namespace