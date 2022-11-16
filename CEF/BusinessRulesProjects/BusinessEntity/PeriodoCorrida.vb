'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System
Namespace CEF.BusinessEntity
    <Serializable()> _
    Public Class PeriodoCorrida
        Inherits EntityBase

        Protected lFlag As Byte
        Protected lCodMetodizado As Integer
        Protected lCodCorrida As Short
        Protected lCodPeriodo As Short
        Protected lOrden As Byte
        Protected lValidado As Boolean
        Protected lEstado As Byte
        Protected lOutval As Integer

        Sub New()
            MyBase.New()
            Me.lCodMetodizado = 0
            Me.lCodCorrida = 0
            Me.lCodPeriodo = 0
            Me.lOrden = 0
            Me.lValidado = False
            Me.lEstado = 0
        End Sub
        Public Sub New(ByVal argFlag As Byte, _
                       ByVal argServidor As String, _
                       ByVal argBaseDato As String, _
                       ByVal argCodMetodizado As Integer, _
                       ByVal argCodCorrida As Short, _
                       ByVal argCodPeriodo As Short, _
                       ByVal argOrden As Byte, _
                       ByVal argValidado As Boolean, _
                       ByVal argEstado As Byte _
                      )
            Me.lCodMetodizado = argCodMetodizado
            Me.lCodCorrida = argCodCorrida
            Me.lCodPeriodo = argCodPeriodo
            Me.lOrden = argOrden
            Me.lValidado = argValidado
            Me.lEstado = argEstado
        End Sub

        Public Property Flag() As Byte
            Get
                Return (lFlag)
            End Get
            Set(ByVal Value As Byte)
                lFlag = Value
            End Set
        End Property
        Public Property CodMetodizado() As Integer
            Get
                Return (lCodMetodizado)
            End Get
            Set(ByVal Value As Integer)
                lCodMetodizado = Value
            End Set
        End Property
        Public Property CodCorrida() As Short
            Get
                Return (lCodCorrida)
            End Get
            Set(ByVal Value As Short)
                lCodCorrida = Value
            End Set
        End Property
        Public Property CodPeriodo() As Short
            Get
                Return (lCodPeriodo)
            End Get
            Set(ByVal Value As Short)
                lCodPeriodo = Value
            End Set
        End Property
        Public Property Orden() As Byte
            Get
                Return (lOrden)
            End Get
            Set(ByVal Value As Byte)
                lOrden = Value
            End Set
        End Property
        Public Property Validado() As Boolean
            Get
                Return Me.lValidado
            End Get
            Set(ByVal Value As Boolean)
                Me.lValidado = Value
            End Set
        End Property
        Public Property bitValidado() As Byte
            Get
                If Me.lValidado Then
                    Return 1
                Else
                    Return 0
                End If
            End Get
            Set(ByVal Value As Byte)

            End Set
        End Property
        Public Property Estado() As Byte
            Get
                Return (lEstado)
            End Get
            Set(ByVal Value As Byte)
                lEstado = Value
            End Set
        End Property
        Public ReadOnly Property Outval() As Integer
            Get
                Return (lOutval)
            End Get
        End Property
    End Class
End Namespace
