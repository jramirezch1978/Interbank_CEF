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
    Public Class Parametro
        Inherits EntityBase

        Protected lCodParametro As String
        Protected lDescripcion As String
        Protected lValor1 As String
        Protected lValor2 As String
        Protected lFecReg As DateTime
        Protected lEstado As Byte

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pstrCodParametro As String, _
                ByVal pstrDescripcion As String, _
                ByVal pstrValor1 As String, _
                ByVal pstrValor2 As String, _
                ByVal pbytEstado As Byte)
            Me.lCodParametro = pstrCodParametro
            Me.lDescripcion = pstrDescripcion
            Me.lValor1 = pstrValor1
            Me.lValor2 = pstrValor2
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodParametro() As String
            Get
                Return Me.lCodParametro
            End Get
            Set(ByVal Value As String)
                Me.lCodParametro = Value
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

        Public Property Valor1() As String
            Get
                Return Me.lValor1
            End Get
            Set(ByVal Value As String)
                Me.lValor1 = Value
            End Set
        End Property

        Public Property Valor2() As String
            Get
                Return Me.lValor2
            End Get
            Set(ByVal Value As String)
                Me.lValor2 = Value
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