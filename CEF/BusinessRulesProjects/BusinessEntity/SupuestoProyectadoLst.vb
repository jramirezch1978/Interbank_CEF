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
    Public Class SupuestoProyectadoLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As SupuestoProyectado
            Get
                Return CType(List(index), SupuestoProyectado)
            End Get
            Set(ByVal Value As SupuestoProyectado)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As SupuestoProyectado) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As SupuestoProyectado) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As SupuestoProyectado)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As SupuestoProyectado)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As SupuestoProyectado) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal intCodSupuesto As Integer, ByVal intCodProyectado As Integer, ByVal intCodCuentaSupuesto As Integer) As SupuestoProyectado
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obeSupuestoProyectado As BusinessEntity.SupuestoProyectado

            While (obeLst.MoveNext())
                obeSupuestoProyectado = CType(obeLst.Current, BusinessEntity.SupuestoProyectado)
                If (obeSupuestoProyectado.CodSupuesto = intCodSupuesto And obeSupuestoProyectado.CodProyectado = intCodProyectado And obeSupuestoProyectado.CodCuentaSupuesto = intCodCuentaSupuesto) Then
                    Return obeSupuestoProyectado
                End If
            End While
            Return (Nothing)
        End Function

    End Class

End Namespace