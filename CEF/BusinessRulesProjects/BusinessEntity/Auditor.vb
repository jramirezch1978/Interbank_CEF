'*************************************************************
'Proposito:
'Autor: María Laura Santisteban Valdez
'Fecha Creacion: 28/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class Auditor
        Inherits EntityBase

        Protected lCodAuditor As Integer
        Protected lRazonSocial As String
        Protected lFecReg As DateTime
        Protected lEstado As Byte

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pstrRazonSocial As String, ByVal pbytEstado As Byte)
            Me.lRazonSocial = pstrRazonSocial
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodAuditor() As Integer
            Get
                Return Me.lCodAuditor
            End Get
            Set(ByVal Value As Integer)
                Me.lCodAuditor = Value
            End Set
        End Property

        Public Property RazonSocial() As String
            Get
                Return Me.lRazonSocial
            End Get
            Set(ByVal Value As String)
                Me.lRazonSocial = Value
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

        Public Property Estado() As Byte
            Get
                Return Me.lEstado
            End Get
            Set(ByVal Value As Byte)
                Me.lEstado = Value
            End Set
        End Property

    End Class

End Namespace
