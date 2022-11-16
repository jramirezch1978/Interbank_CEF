'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 28/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class CarteraUsuario
        Inherits EntityBase

        Protected lCodUsuarioResponsable As String
        Protected lCodUsuarioSubordinado As String
        Protected lFecReg As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pshoCodUsuarioResponsable As String, ByVal pshoCodUsuarioSubordinado As String)
            Me.lCodUsuarioResponsable = pshoCodUsuarioResponsable
            Me.lCodUsuarioSubordinado = pshoCodUsuarioSubordinado
        End Sub

        Public Property CodUsuarioResponsable() As String
            Get
                Return Me.lCodUsuarioResponsable
            End Get
            Set(ByVal Value As String)
                Me.lCodUsuarioResponsable = Value
            End Set
        End Property

        Public Property CodUsuarioSubordinado() As String
            Get
                Return Me.lCodUsuarioSubordinado
            End Get
            Set(ByVal Value As String)
                Me.lCodUsuarioSubordinado = Value
            End Set
        End Property

        Public Property FecReg() As DateTime
            Get
                Return Me.lFecReg
            End Get
            Set(ByVal Value As DateTime)
                Me.lFecReg = Value
            End Set
        End Property

    End Class

End Namespace
