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
    Public Class PermisoPerfilLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As PermisoPerfil
            Get
                Return CType(List(index), PermisoPerfil)
            End Get
            Set(ByVal Value As PermisoPerfil)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As PermisoPerfil) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As PermisoPerfil) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As PermisoPerfil)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As PermisoPerfil)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As PermisoPerfil) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal intCodPermiso As Short, ByVal intCodPerfil As Short) As PermisoPerfil
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obePermisoPerfil As BusinessEntity.PermisoPerfil

            While (obeLst.MoveNext())
                obePermisoPerfil = CType(obeLst.Current, BusinessEntity.PermisoPerfil)
                If (obePermisoPerfil.CodPermiso = intCodPermiso And obePermisoPerfil.CodPerfil = intCodPerfil) Then
                    Return obePermisoPerfil
                End If
            End While
            Return (Nothing)
        End Function

    End Class

End Namespace