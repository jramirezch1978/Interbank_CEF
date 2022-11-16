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
    Public Class CarteraUsuarioLst
        Inherits CollectionBase

        Default Public Property Item(ByVal index As Integer) As CarteraUsuario
            Get
                Return CType(List(index), CarteraUsuario)
            End Get
            Set(ByVal Value As CarteraUsuario)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As CarteraUsuario) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As CarteraUsuario) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As CarteraUsuario)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As CarteraUsuario)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As CarteraUsuario) As Boolean
            Return (List.Contains(value))
        End Function

        Public Function buscarPorClave(ByVal pshoCodUsuarioResponsable As Short, ByVal pshoCodUsuarioSubordinado As Short) As BusinessEntity.CarteraUsuario
            Dim obeLst As IEnumerator = List.GetEnumerator()
            Dim obeCarteraUsuario As BusinessEntity.CarteraUsuario

            While (obeLst.MoveNext())
                obeCarteraUsuario = CType(obeLst.Current, BusinessEntity.CarteraUsuario)
                If (obeCarteraUsuario.CodUsuarioResponsable = pshoCodUsuarioResponsable And obeCarteraUsuario.CodUsuarioSubordinado = pshoCodUsuarioSubordinado) Then
                    Return obeCarteraUsuario
                End If
            End While
            Return (Nothing)
        End Function

    End Class

End Namespace