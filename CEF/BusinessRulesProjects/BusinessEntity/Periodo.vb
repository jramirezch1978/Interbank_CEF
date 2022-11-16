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
    Public Class Periodo
        Inherits EntityBase

        Protected lCodMetodizado As Integer
        Protected lCodPeriodo As Integer
        Protected lCodTipoEeff As Integer
        Protected lDesTipoEeff As String
        Protected lAnio As Integer
        Protected lMes As Integer
        Protected lDia As Integer
        Protected lFecPeriodo As DateTime
        Protected lCodAuditor As Integer
        Protected lComentario As String
        Protected lCodUsuario As String
        Protected lNombreUsuario As String
        Protected lFecReg As DateTime
        Protected lEstado As Byte
        Protected lPeriodoCuentas As PeriodoCuentaLst = New PeriodoCuentaLst
        Protected lCodUsuarioEnv As String
        Protected lFecEnvio As DateTime
        Protected lCodUsuarioVal As String
        Protected lFecValidacion As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodMetodizado As Integer, _
                ByVal pintCodPeriodo As Integer, _
                ByVal pintCodTipoEeff As Integer, _
                ByVal pintAnio As Integer, _
                ByVal pintMes As Integer, _
                ByVal pintDia As Integer, _
                ByVal pdteFecPeriodo As DateTime, _
                ByVal pintCodAuditor As Integer, _
                ByVal pstrComentario As String, _
                ByVal pbytEstado As Byte)
            Me.lCodMetodizado = pintCodMetodizado
            Me.lCodPeriodo = pintCodPeriodo
            Me.lCodTipoEeff = pintCodTipoEeff
            Me.lAnio = pintAnio
            Me.lMes = pintMes
            Me.lDia = pintDia
            Me.lFecPeriodo = pdteFecPeriodo
            Me.lCodAuditor = pintCodAuditor
            Me.lComentario = pstrComentario
            Me.lFecReg = DateTime.Today
            Me.lEstado = pbytEstado
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

        Public Property CodTipoEeff() As Integer
            Get
                Return Me.lCodTipoEeff
            End Get
            Set(ByVal Value As Integer)
                Me.lCodTipoEeff = Value
            End Set
        End Property

        Public Property DesTipoEeff() As String
            Get
                Return Me.lDesTipoEeff
            End Get
            Set(ByVal Value As String)
                Me.lDesTipoEeff = Value
            End Set
        End Property

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

        Public Property Dia() As Integer
            Get
                Return Me.lDia
            End Get
            Set(ByVal Value As Integer)
                Me.lDia = Value
            End Set
        End Property

        Public Property FecPeriodo() As DateTime
            Get
                Return Me.lFecPeriodo
            End Get
            Set(ByVal Value As DateTime)
                Me.lFecPeriodo = Value
            End Set
        End Property

        Public Property CodAuditor() As Integer
            Get
                Return Me.lCodAuditor
            End Get
            Set(ByVal Value As Integer)
                Me.lCodAuditor = Value
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

        Public Property CodUsuario() As String
            Get
                Return Me.lCodUsuario
            End Get
            Set(ByVal Value As String)
                Me.lCodUsuario = Value
            End Set
        End Property

        Public Property NombreUsuario() As String
            Get
                Return Me.lNombreUsuario
            End Get
            Set(ByVal Value As String)
                Me.lNombreUsuario = Value
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

        Public Property PeriodoCuentas() As PeriodoCuentaLst
            Get
                Return Me.lPeriodoCuentas
            End Get
            Set(ByVal Value As PeriodoCuentaLst)
                Me.lPeriodoCuentas = Value
            End Set
        End Property

        Public Property CodUsuarioEnv() As String
            Get
                Return lCodUsuarioEnv
            End Get
            Set(ByVal Value As String)
                lCodUsuarioEnv = Value
            End Set
        End Property

        Public Property FecEnvio() As DateTime
            Get
                Return lFecEnvio
            End Get
            Set(ByVal Value As DateTime)
                lFecEnvio = Value
            End Set
        End Property

        Public Property CodUsuarioVal() As String
            Get
                Return lCodUsuarioVal
            End Get
            Set(ByVal Value As String)
                lCodUsuarioVal = Value
            End Set
        End Property

        Public Property FecValidacion() As DateTime
            Get
                Return lFecValidacion
            End Get
            Set(ByVal Value As DateTime)
                lFecValidacion = Value
            End Set
        End Property
    End Class

End Namespace