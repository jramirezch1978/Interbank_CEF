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
    Public Class Operador
        Inherits EntityBase

        Protected lCodOperador As Integer
        Protected lDescripcion As String
        Protected lSimbolo As String
        Protected lFecReg As DateTime
        Protected lEstado As Byte

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pstrDescripcion As String, ByVal pstrSimbolo As String, ByVal pbytEstado As Byte)
            Me.lDescripcion = pstrDescripcion
            Me.lSimbolo = pstrSimbolo
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodOperador() As Integer
            Get
                Return Me.lCodOperador
            End Get
            Set(ByVal Value As Integer)
                Me.lCodOperador = Value
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

        Public Property Simbolo() As String
            Get
                Return Me.lSimbolo
            End Get
            Set(ByVal Value As String)
                Me.lSimbolo = Value
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