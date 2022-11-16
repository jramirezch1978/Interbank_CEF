'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class CIIU
        Inherits EntityBase

        Protected lCodCIIU As Integer
        Protected lNombre As String

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pstrNombre As String)
            Me.lNombre = pstrNombre
        End Sub

        Public Property CodCIIU() As String
            Get
                Return Me.lCodCIIU
            End Get
            Set(ByVal Value As String)
                Me.lCodCIIU = Value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return Me.lNombre
            End Get
            Set(ByVal Value As String)
                Me.lNombre = Value
            End Set
        End Property

    End Class

End Namespace