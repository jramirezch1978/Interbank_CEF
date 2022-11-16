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
    Public Class Cuenta
        Inherits EntityBase

        Protected lCodCuenta As Integer
        Protected lCodCuentaPadre As Integer
        Protected lCodEeff As Integer
        Protected lDescripcion As String
        Protected lCodTipoCuenta As Byte
        Protected lOrden As Integer
        Protected lFecReg As DateTime
        Protected lEstado As Byte

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodCuentaPadre As Integer, _
                ByVal pintCodEeff As Integer, _
                ByVal pstrDescripcion As String, _
                ByVal pintCodTipoCuenta As Byte, _
                ByVal pintOrden As Integer, _
                ByVal pbytEstado As Byte)
            Me.lCodCuentaPadre = pintCodCuentaPadre
            Me.lCodEeff = pintCodEeff
            Me.lDescripcion = pstrDescripcion
            Me.lCodTipoCuenta = pintCodTipoCuenta
            Me.lOrden = pintOrden
            Me.lFecReg = DateTime.Today
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodCuenta() As Integer
            Get
                Return Me.lCodCuenta
            End Get
            Set(ByVal Value As Integer)
                Me.lCodCuenta = Value
            End Set
        End Property

        Public Property CodCuentaPadre() As Integer
            Get
                Return Me.lCodCuentaPadre
            End Get
            Set(ByVal Value As Integer)
                Me.lCodCuentaPadre = Value
            End Set
        End Property

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

        Public Property CodTipoCuenta() As Byte
            Get
                Return Me.lCodTipoCuenta
            End Get
            Set(ByVal Value As Byte)
                Me.lCodTipoCuenta = Value
            End Set
        End Property

        Public Property Orden() As Integer
            Get
                Return Me.lCodTipoCuenta
            End Get
            Set(ByVal Value As Integer)
                Me.lCodTipoCuenta = Value
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