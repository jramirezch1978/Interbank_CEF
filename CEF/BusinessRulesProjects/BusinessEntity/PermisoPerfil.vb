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
    Public Class PermisoPerfil
        Inherits EntityBase

        Protected lCodPermiso As Short
        Protected lCodPerfil As Short
        Protected lValor As Boolean
        Protected lFecReg As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pshoCodPermiso As Short, ByVal pshoCodPerfil As Short, ByVal pblnValor As Boolean)
            Me.lCodPermiso = pshoCodPermiso
            Me.lCodPerfil = pshoCodPerfil
            Me.lValor = pblnValor
        End Sub

        Public Property CodPermiso() As Short
            Get
                Return Me.lCodPermiso
            End Get
            Set(ByVal Value As Short)
                Me.lCodPermiso = Value
            End Set
        End Property

        Public Property CodPerfil() As Short
            Get
                Return Me.lCodPerfil
            End Get
            Set(ByVal Value As Short)
                Me.lCodPerfil = Value
            End Set
        End Property

        Public Property Valor() As Boolean
            Get
                Return Me.lValor
            End Get
            Set(ByVal Value As Boolean)
                Me.lValor = Value
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
