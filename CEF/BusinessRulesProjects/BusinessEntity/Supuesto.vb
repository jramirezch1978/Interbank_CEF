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
    Public Class Supuesto
        Inherits EntityBase

        Protected lCodSupuesto As Integer
        Protected lCodMetodizado As Integer
        Protected lCodPeriodo As Integer
        Protected lCodPeriodoAnterior As Integer
        Protected lCodTipoSupuesto As Byte
        Protected lDescripcion As String
        Protected lNumeroProyectado As Byte
        Protected lCodMoneda As Byte
        Protected lCodUnidad As Byte
        Protected lFecReg As DateTime
        Protected lEstado As Byte
        Protected lPeriodosProyectados As PeriodoProyectadoLst = New PeriodoProyectadoLst

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodSupuesto As Integer, _
                ByVal pintCodMetodizado As Integer, _
                ByVal pintCodPeriodo As Integer, _
                ByVal pintCodPeriodoAnterior As Integer, _
                ByVal pintCodTipoSupuesto As Byte, _
                ByVal pstrDescripcion As String, _
                ByVal pbytNumeroProyectado As Byte, _
                ByVal pintCodMoneda As Byte, _
                ByVal pintCodUnidad As Byte, _
                ByVal pbytEstado As Byte)
            Me.lCodSupuesto = pintCodSupuesto
            Me.lCodMetodizado = pintCodMetodizado
            Me.lCodPeriodo = pintCodPeriodo
            Me.lCodPeriodoAnterior = pintCodPeriodoAnterior
            Me.lCodTipoSupuesto = pintCodTipoSupuesto
            Me.lDescripcion = pstrDescripcion
            Me.lNumeroProyectado = pbytNumeroProyectado
            Me.lCodMoneda = pintCodMoneda
            Me.lCodUnidad = pintCodUnidad
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodSupuesto() As Integer
            Get
                Return Me.lCodSupuesto
            End Get
            Set(ByVal Value As Integer)
                Me.lCodSupuesto = Value
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

        Public Property CodPeriodo() As Integer
            Get
                Return Me.lCodPeriodo
            End Get
            Set(ByVal Value As Integer)
                Me.lCodPeriodo = Value
            End Set
        End Property

        Public Property CodPeriodoAnterior() As Integer
            Get
                Return Me.lCodPeriodoAnterior
            End Get
            Set(ByVal Value As Integer)
                Me.lCodPeriodoAnterior = Value
            End Set
        End Property

        Public Property CodTipoSupuesto() As Byte
            Get
                Return Me.lCodTipoSupuesto
            End Get
            Set(ByVal Value As Byte)
                Me.lCodTipoSupuesto = Value
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

        Public Property NumeroProyectado() As Byte
            Get
                Return Me.lNumeroProyectado
            End Get
            Set(ByVal Value As Byte)
                Me.lNumeroProyectado = Value
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

        Public Property CodUnidad() As Byte
            Get
                Return Me.lCodUnidad
            End Get
            Set(ByVal Value As Byte)
                Me.lCodUnidad = Value
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

        Public Property PeriodosProyectados() As PeriodoProyectadoLst
            Get
                Return Me.lPeriodosProyectados
            End Get
            Set(ByVal Value As PeriodoProyectadoLst)
                Me.lPeriodosProyectados = Value
            End Set
        End Property

    End Class

End Namespace