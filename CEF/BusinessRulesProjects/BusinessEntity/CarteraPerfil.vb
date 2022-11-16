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
    Public Class CarteraPerfil
        Inherits EntityBase

        Protected lCodPerfilResponsable As Short
        Protected lCodPerfilSubordinado As Short
        Protected lFecReg As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pshoCodPerfilResponsable As Short, ByVal pshoCodPerfilSubordinado As Short)
            Me.lCodPerfilResponsable = pshoCodPerfilResponsable
            Me.lCodPerfilSubordinado = pshoCodPerfilSubordinado
        End Sub

        Public Property CodPerfilResponsable() As Short
            Get
                Return Me.lCodPerfilResponsable
            End Get
            Set(ByVal Value As Short)
                Me.lCodPerfilResponsable = Value
            End Set
        End Property

        Public Property CodPerfilSubordinado() As Short
            Get
                Return Me.lCodPerfilSubordinado
            End Get
            Set(ByVal Value As Short)
                Me.lCodPerfilSubordinado = Value
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
