'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class PeriodoCuenta
        Inherits EntityBase

        Protected lCodMetodizado As Integer
        Protected lCodPeriodo As Integer
        Protected lCodCuenta As Integer
        Protected lImporte As Decimal
        Protected lFuncion As String
        Protected lFecReg As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodMetodizado As Integer, _
                ByVal pintCodPeriodo As Integer, _
                ByVal pintCodCuenta As Integer, _
                ByVal pdecImporte As Decimal, _
                ByVal pstrFuncion As String)
            Me.lCodMetodizado = pintCodMetodizado
            Me.lCodPeriodo = pintCodPeriodo
            Me.lCodCuenta = pintCodCuenta
            Me.lImporte = pdecImporte
            Me.lFuncion = pstrFuncion
        End Sub

        Public Property CodMetodizado() As Integer
            Get
                Return Me.lCodMetodizado
            End Get
            Set(ByVal Value As Integer)
                Me.lCodMetodizado = Value
            End Set
        End Property

        Public Property CodPeriodo() As Integer
            Get
                Return Me.lCodPeriodo
            End Get
            Set(ByVal Value As Integer)
                Me.lCodPeriodo = Value
            End Set
        End Property

        Public Property CodCuenta() As Integer
            Get
                Return Me.lCodCuenta
            End Get
            Set(ByVal Value As Integer)
                Me.lCodCuenta = Value
            End Set
        End Property

        Public Property Importe() As Decimal
            Get
                Return Me.lImporte
            End Get
            Set(ByVal Value As Decimal)
                Me.lImporte = Value
            End Set
        End Property

        Public Property Funcion() As String
            Get
                Return Me.lFuncion
            End Get
            Set(ByVal Value As String)
                Me.lFuncion = Value
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