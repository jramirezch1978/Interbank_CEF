'*************************************************************
'Proposito:
'Autor: Miguel Delgado del Aguila
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class TipoCambio
        Inherits EntityBase

        Protected lAnio As Integer
        Protected lMes As Integer
        Protected lCodMoneda As Byte
        Protected lMonto As Decimal
        Protected lMontoMaximo As Decimal
        Protected lPorcentajeDevaluacion As Decimal
        Protected lIndiceReexpresion As Decimal
        Protected lFecReg As DateTime
        Protected lEstado As Byte
        Protected lCodUsuario As String
        Protected lMontoMinimo As Decimal
        Protected lProcentajeApreciacion As Decimal

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintAnio As Integer, ByVal pintMes As Integer, _
                ByVal pbytCodMoneda As Byte, ByVal pdecMonto As Decimal, _
                ByVal pdecMontoMaximo As Decimal, ByVal pdecPorcentajeDevaluacion As Decimal, _
                ByVal pdecIndiceReexpresion As Decimal, ByVal pbytEstado As Byte, _
                ByVal pstrCodUsuario As String, ByVal pdecMontoMinimo As Decimal, _
                ByVal pdecProcentajeApreciacion As Decimal)
            Me.lAnio = pintAnio
            Me.lMes = pintMes
            Me.lCodMoneda = pbytCodMoneda
            Me.lMonto = pdecMonto
            Me.lMontoMaximo = pdecMontoMaximo
            Me.lPorcentajeDevaluacion = pdecPorcentajeDevaluacion
            Me.lIndiceReexpresion = pdecIndiceReexpresion
            Me.lFecReg = DateTime.Today
            Me.lEstado = pbytEstado
            Me.lCodUsuario = pstrCodUsuario
            Me.lMontoMinimo = pdecMontoMinimo
            Me.lProcentajeApreciacion = pdecProcentajeApreciacion
        End Sub

        Public Property Anio() As Integer
            Get
                Return Me.lAnio
            End Get
            Set(ByVal Value As Integer)
                Me.lAnio = Value
            End Set
        End Property

        Public Property Mes() As Integer
            Get
                Return Me.lMes
            End Get
            Set(ByVal Value As Integer)
                Me.lMes = Value
            End Set
        End Property

        Public Property CodMoneda() As Byte
            Get
                Return Me.lCodMoneda
            End Get
            Set(ByVal Value As Byte)
                Me.lCodMoneda = Value
            End Set
        End Property

        Public Property Monto() As Decimal
            Get
                Return Me.lMonto
            End Get
            Set(ByVal Value As Decimal)
                Me.lMonto = Value
            End Set
        End Property

        Public Property MontoMaximo() As Decimal
            Get
                Return Me.lMontoMaximo
            End Get
            Set(ByVal Value As Decimal)
                Me.lMontoMaximo = Value
            End Set
        End Property

        Public Property PorcentajeDevaluacion() As Decimal
            Get
                Return Me.lPorcentajeDevaluacion
            End Get
            Set(ByVal Value As Decimal)
                Me.lPorcentajeDevaluacion = Value
            End Set
        End Property

        Public Property IndiceReexpresion() As Decimal
            Get
                Return Me.lIndiceReexpresion
            End Get
            Set(ByVal Value As Decimal)
                Me.lIndiceReexpresion = Value
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

        Public Property CodUsuario() As String
            Get
                Return lCodUsuario
            End Get
            Set(ByVal Value As String)
                lCodUsuario = Value
            End Set
        End Property

        Public Property MontoMinimo() As Decimal
            Get
                Return lMontoMinimo
            End Get
            Set(ByVal Value As Decimal)
                lMontoMinimo = Value
            End Set
        End Property

        Public Property ProcentajeApreciacion() As Decimal
            Get
                Return lProcentajeApreciacion
            End Get
            Set(ByVal Value As Decimal)
                lProcentajeApreciacion = Value
            End Set
        End Property
    End Class

End Namespace