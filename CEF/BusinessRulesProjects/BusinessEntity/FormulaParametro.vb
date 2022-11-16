'*************************************************************
'Proposito:
'Autor: XT8633
'Fecha Creacion:12-03-2019
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity
    <Serializable()> _
    Public Class FormulaParametro

        Protected lCodParametro As Integer
        Protected lCodCovenant As Integer
        Protected lAnio As String
        Protected lValor As Decimal
        Protected lUsuario As String

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodCovenant As Integer, ByVal pstrAnio As String, ByVal pstrValor As Decimal, ByVal pstrUsuario As String)
            Me.lCodCovenant = pintCodCovenant
            Me.lAnio = pstrAnio
            Me.lValor = pstrValor
            Me.lUsuario = pstrUsuario
        End Sub

        Public Property CodFormulaParametro() As Integer
            Get
                Return Me.lCodParametro
            End Get
            Set(ByVal Value As Integer)
                Me.lCodParametro = Value
            End Set
        End Property
        Public Property CodCovenant() As Integer
            Get
                Return Me.lCodCovenant
            End Get
            Set(ByVal Value As Integer)
                Me.lCodCovenant = Value
            End Set
        End Property
        Public Property Anio() As String
            Get
                Return Me.lAnio
            End Get
            Set(ByVal Value As String)
                Me.lAnio = Value
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
        Public Property Usuario() As String
            Get
                Return Me.lUsuario
            End Get
            Set(ByVal Value As String)
                Me.lUsuario = Value
            End Set
        End Property
    End Class
End Namespace

