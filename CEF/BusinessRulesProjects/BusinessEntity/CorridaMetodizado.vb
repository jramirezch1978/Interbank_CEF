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
    Public Class CorridaMetodizado
        Inherits EntityBase

        Protected lFlag As Byte
        Protected lCodMetodizado As Integer
        Protected lCodCorrida As Short
        Protected lCodMoneda As Byte
        Protected lCodUsuarioReg As String
        Protected lFecReg As DateTime
        Protected lCodUsuarioUpd As String
        Protected lFecUpd As DateTime
        Protected lEstado As Byte
        Protected lCodOrigenCorrida As Short = 1
        Protected lOutval As Integer

        Protected lPeriodosCorrida As New PeriodoCorridaLst

        Sub New()
            MyBase.New()
            Me.lCodMetodizado = 0
            Me.lCodCorrida = 0
            Me.lCodMoneda = 0
            Me.lCodUsuarioReg = ""
            Me.lFecReg = DateTime.Now
            Me.lCodUsuarioUpd = ""
            Me.lFecUpd = DateTime.Now
            Me.lEstado = 0
            Me.lCodOrigenCorrida = 1 ' Valor por defecto
        End Sub
        Public Sub New(ByVal argFlag As Byte, _
                       ByVal argServidor As String, _
                       ByVal argBaseDato As String, _
                       ByVal argCodMetodizado As Integer, _
                       ByVal argCodCorrida As Short, _
                       ByVal argCodMoneda As Byte, _
                       ByVal argCodUsuarioReg As String, _
                       ByVal argFecReg As DateTime, _
                       ByVal argCodUsuarioUpd As String, _
                       ByVal argFecUpd As DateTime, _
                       ByVal argEstado As Byte, _
                       ByVal argCodOrigenCorrida As Short _
                      )
            Me.lCodMetodizado = argCodMetodizado
            Me.lCodCorrida = argCodCorrida
            Me.lCodMoneda = argCodMoneda
            Me.lCodUsuarioReg = argCodUsuarioReg
            Me.lFecReg = argFecReg
            Me.lCodUsuarioUpd = argCodUsuarioUpd
            Me.lFecUpd = argFecUpd
            Me.lEstado = argEstado
            Me.lCodOrigenCorrida = argCodOrigenCorrida
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
        Public Property CodMoneda() As Short
            Get
                Return (lCodMoneda)
            End Get
            Set(ByVal Value As Short)
                lCodMoneda = Value
            End Set
        End Property
        Public Property CodUsuarioReg() As String
            Get
                Return (lCodUsuarioReg)
            End Get
            Set(ByVal Value As String)
                lCodUsuarioReg = Value
            End Set
        End Property
        Public Property FecReg() As DateTime
            Get
                Return (lFecReg)
            End Get
            Set(ByVal Value As DateTime)
                lFecReg = Value
            End Set
        End Property
        Public Property CodUsuarioUpd() As String
            Get
                Return (lCodUsuarioUpd)
            End Get
            Set(ByVal Value As String)
                lCodUsuarioUpd = Value
            End Set
        End Property
        Public Property FecUpd() As DateTime
            Get
                Return (lFecUpd)
            End Get
            Set(ByVal Value As DateTime)
                lFecUpd = Value
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
        Public Property CodOrigenCorrida() As Short
            Get
                Return (lCodOrigenCorrida)
            End Get
            Set(ByVal Value As Short)
                lCodOrigenCorrida = Value
            End Set
        End Property
        Public ReadOnly Property Outval() As Integer
            Get
                Return (lOutval)
            End Get
        End Property

        Public Property PeriodosCorrida() As PeriodoCorridaLst
            Get
                Return lPeriodosCorrida
            End Get
            Set(ByVal Value As PeriodoCorridaLst)
                lPeriodosCorrida = Value
            End Set
        End Property
    End Class
End Namespace
