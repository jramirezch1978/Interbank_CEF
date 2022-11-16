'*************************************************************
'Proposito: Colección base para todas las entidades de negocio
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class CollectionEntityBase
        Inherits CollectionBase

        Protected Sub New()
            MyBase.New()
        End Sub

        Default Public Property Item(ByVal index As Integer) As EntityBase
            Get
                Return CType(List(index), EntityBase)
            End Get
            Set(ByVal Value As EntityBase)
                List(index) = Value
            End Set
        End Property

        Public Function Add(ByVal value As EntityBase) As Integer
            Return (List.Add(value))
        End Function

        Public Function IndexOf(ByVal value As EntityBase) As Integer
            Return (List.IndexOf(value))
        End Function

        Public Sub Insert(ByVal index As Integer, ByVal value As EntityBase)
            List.Insert(index, value)
        End Sub

        Public Sub Remove(ByVal value As EntityBase)
            List.Remove(value)
        End Sub

        Public Function Contains(ByVal value As EntityBase) As Boolean
            Return (List.Contains(value))
        End Function

    End Class

End Namespace