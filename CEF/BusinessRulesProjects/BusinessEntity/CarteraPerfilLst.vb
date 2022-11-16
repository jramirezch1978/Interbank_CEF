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
    Public Class CarteraPerfilLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As CarteraPerfil
            Get
                Return CType(List(index), CarteraPerfil)
            End Get
            Set(ByVal Value As CarteraPerfil)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As CarteraPerfil) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As CarteraPerfil) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As CarteraPerfil)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As CarteraPerfil)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As CarteraPerfil) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal pshoCodPerfilResponsable As Short, ByVal pshoCodPerfilSubordinado As Short) As BusinessEntity.CarteraPerfil
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obeCarteraPerfil As BusinessEntity.CarteraPerfil

            While (obeLst.MoveNext())
                obeCarteraPerfil = CType(obeLst.Current, BusinessEntity.CarteraPerfil)
                If (obeCarteraPerfil.CodPerfilResponsable = pshoCodPerfilResponsable And obeCarteraPerfil.CodPerfilSubordinado = pshoCodPerfilSubordinado) Then
                    Return obeCarteraPerfil
                End If
            End While
            Return (Nothing)
        End Function

    End Class

End Namespace