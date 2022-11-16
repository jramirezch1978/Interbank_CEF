Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class VariableFormula
        Inherits EntityBase

        Protected lCodFormula As Integer
        Protected lCodVariableFormula As Integer
        Protected lCodCuenta As Integer
        Protected lDescripcion As String
        Protected lValor As Decimal
        Protected lOrden As Integer
        Protected lCodUsuario As String
        Protected lFechRegistro As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodFormula As Integer, _
                ByVal pintCodVariableFormula As Integer, _
                ByVal pintCodCuenta As Integer, _
                ByVal pstrDescripcion As String, _
                ByVal pdecValor As Decimal, _
                ByVal pintOrden As Integer, _
                ByVal pstrCodUsuario As String, _
                ByVal pdteFechRegistro As DateTime)
            Me.lCodFormula = pintCodFormula
            Me.lCodVariableFormula = pintCodVariableFormula
            Me.lCodCuenta = pintCodCuenta
            Me.lDescripcion = pstrDescripcion
            Me.lValor = pdecValor
            Me.lOrden = pintOrden
            Me.lCodUsuario = pstrCodUsuario
            Me.lFechRegistro = DateTime.Today
        End Sub

        Public Property CodFormula() As Integer
            Get
                Return Me.lCodFormula
            End Get
            Set(ByVal Value As Integer)
                Me.lCodFormula = Value
            End Set
        End Property

        Public Property CodVariableFormula() As Integer
            Get
                Return Me.lCodVariableFormula
            End Get
            Set(ByVal Value As Integer)
                Me.lCodVariableFormula = Value
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

        Public Property Descripcion() As String
            Get
                Return Me.lDescripcion
            End Get
            Set(ByVal Value As String)
                Me.lDescripcion = Value
            End Set
        End Property

        Public Property Valor() As Decimal
            Get
                Return Me.lValor
            End Get
            Set(ByVal Value As Decimal)
                Me.lValor = Value
            End Set
        End Property

        Public Property Orden() As Integer
            Get
                Return Me.lOrden
            End Get
            Set(ByVal Value As Integer)
                Me.lOrden = Value
            End Set
        End Property

        Public Property CodUsuario() As String
            Get
                Return Me.lCodUsuario
            End Get
            Set(ByVal Value As String)
                Me.lCodUsuario = Value
            End Set
        End Property

        Public Property FechRegistro() As DateTime
            Get
                Return Me.lFechRegistro
            End Get
            Set(ByVal Value As DateTime)
                Me.lFechRegistro = Value
            End Set
        End Property


    End Class

End Namespace
