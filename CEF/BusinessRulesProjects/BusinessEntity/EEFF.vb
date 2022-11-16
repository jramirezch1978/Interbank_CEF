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
    Public Class EEFF
        Inherits EntityBase

        Protected lCodEeff As Integer
        Protected lDescripcion As String
        Protected lFecReg As DateTime
        Protected lEstado As Byte

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pstrDescripcion As String, ByVal pbytEstado As Byte)
            Me.lDescripcion = pstrDescripcion
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodEeff() As Integer
            Get
                Return Me.lCodEeff
            End Get
            Set(ByVal Value As Integer)
                Me.lCodEeff = Value
            End Set
        End Property

        Public Property Descripcion() As String
            Get
                Return Me.lDescripcion
            End Get
            Set(ByVal Value As String)
                Me.lDescripcion = Value
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