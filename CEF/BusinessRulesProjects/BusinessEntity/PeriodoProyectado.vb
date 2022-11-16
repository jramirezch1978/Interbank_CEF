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
    Public Class PeriodoProyectado
        Inherits EntityBase

        Protected lCodSupuesto As Integer
        Protected lCodProyectado As Byte
        Protected lTipo As Byte
        Protected lFecProyectado As DateTime
        Protected lFecReg As DateTime
        Protected lSupuestosProyectados As SupuestoProyectadoLst = New SupuestoProyectadoLst

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodSupuesto As Integer, _
                ByVal pintCodProyectado As Byte, _
                ByVal pdteFecProyectado As DateTime)
            Me.lCodSupuesto = pintCodSupuesto
            Me.lCodProyectado = pintCodProyectado
            Me.lFecProyectado = pdteFecProyectado
        End Sub

        Public Property CodSupuesto() As Integer
            Get
                Return Me.lCodSupuesto
            End Get
            Set(ByVal Value As Integer)
                Me.lCodSupuesto = Value
            End Set
        End Property

        Public Property CodProyectado() As Byte
            Get
                Return Me.lCodProyectado
            End Get
            Set(ByVal Value As Byte)
                Me.lCodProyectado = Value
            End Set
        End Property

        Public Property Tipo() As Byte
            Get
                Return Me.lTipo
            End Get
            Set(ByVal Value As Byte)
                Me.lTipo = Value
            End Set
        End Property

        Public Property FecProyectado() As DateTime
            Get
                Return Me.lFecProyectado
            End Get
            Set(ByVal Value As DateTime)
                Me.lFecProyectado = Value
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

        Public Property SupuestosProyectados() As SupuestoProyectadoLst
            Get
                Return Me.lSupuestosProyectados
            End Get
            Set(ByVal Value As SupuestoProyectadoLst)
                Me.lSupuestosProyectados = Value
            End Set
        End Property

    End Class

End Namespace