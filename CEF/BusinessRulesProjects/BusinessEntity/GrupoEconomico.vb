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
    Public Class GrupoEconomico
        Inherits EntityBase

        Protected lCodGrupoEconomico As String
        Protected lNombre As String

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pstrNombre As String)
            Me.lNombre = pstrNombre
        End Sub

        Public Property CodGrupoEconomico() As String
            Get
                Return Me.lCodGrupoEconomico
            End Get
            Set(ByVal Value As String)
                Me.lCodGrupoEconomico = Value
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