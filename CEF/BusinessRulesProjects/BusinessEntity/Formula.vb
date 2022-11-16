Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class Formula
        Inherits EntityBase

        Protected lCodFormula As Integer
        Protected lCodMetodizado As Integer
        Protected lDescripcion As String
        Protected lEstado As Integer
        Protected lCodCondicion As Integer
        Protected lComentario As String
        Protected lCodNoContractual As Integer
        Protected lCodUsuario As String
        Protected lFechRegistro As DateTime
        Protected lCodUsuarioVal As String
        Protected lFechVal As DateTime
        Protected lVariableFormulas As VariableFormulaLst = New VariableFormulaLst

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodFormula As Integer, _
                ByVal pintCodMetodizado As Integer, _
                ByVal pstrDescripcion As String, _
                ByVal pintEstado As Integer, _
                ByVal pintCodCondicion As Integer, _
                ByVal pstrComentario As String, _
                ByVal pintCodNoContractual As Integer, _
                ByVal pstrCodUsuario As String, _
                ByVal pdteFechRegistro As DateTime, _
                ByVal pstrCodUsuarioVal As String, _
                ByVal pdteFechVal As DateTime)
            Me.lCodFormula = pintCodFormula
            Me.lCodMetodizado = pintCodMetodizado
            Me.lDescripcion = pstrDescripcion
            Me.lEstado = pintEstado
            Me.lCodCondicion = pintCodCondicion
            Me.lComentario = pstrComentario
            Me.lCodNoContractual = pintCodNoContractual
            Me.lCodUsuario = pstrCodUsuario
            Me.lFechRegistro = DateTime.Today
            Me.lCodUsuarioVal = pstrCodUsuarioVal
            Me.lFechVal = pdteFechVal
        End Sub

        Public Property CodFormula() As Integer
            Get
                Return Me.lCodFormula
            End Get
            Set(ByVal Value As Integer)
                Me.lCodFormula = Value
            End Set
        End Property

        Public Property CodMetodizado() As Integer
            Get
                Return Me.lCodMetodizado
            End Get
            Set(ByVal Value As Integer)
                Me.lCodMetodizado = Value
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

        Public Property Estado() As Integer
            Get
                Return Me.lEstado
            End Get
            Set(ByVal Value As Integer)
                Me.lEstado = Value
            End Set
        End Property
        Public Property Condicion() As Integer
            Get
                Return Me.lCodCondicion
            End Get
            Set(ByVal Value As Integer)
                Me.lCodCondicion = Value
            End Set
        End Property
        Public Property Comentario() As String
            Get
                Return Me.lComentario
            End Get
            Set(ByVal Value As String)
                Me.lComentario = Value
            End Set
        End Property
        Public Property CodNoContractual() As Integer
            Get
                Return Me.lCodNoContractual
            End Get
            Set(ByVal Value As Integer)
                Me.lCodNoContractual = Value
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

        Public Property FechRegisto() As DateTime
            Get
                Return Me.lFechRegistro
            End Get
            Set(ByVal Value As DateTime)
                Me.lFechRegistro = Value
            End Set
        End Property

        Public Property CodUsuarioVal() As String
            Get
                Return Me.lCodUsuarioVal
            End Get
            Set(ByVal Value As String)
                Me.lCodUsuarioVal = Value
            End Set
        End Property

        Public Property FechValidacion() As DateTime
            Get
                Return Me.lFechVal
            End Get
            Set(ByVal Value As DateTime)
                Me.lFechVal = Value
            End Set
        End Property

        Public Property VariableFormulas() As VariableFormulaLst
            Get
                Return Me.lVariableFormulas
            End Get
            Set(ByVal Value As VariableFormulaLst)
                Me.lVariableFormulas = Value
            End Set
        End Property


    End Class

End Namespace
