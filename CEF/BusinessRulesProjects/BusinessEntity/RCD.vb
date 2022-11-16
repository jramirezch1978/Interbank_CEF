'*************************************************************
'Proposito:
'Autor: María Laura Santisteban Valdez
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class RCD
        Inherits EntityBase

        Protected lAnioPeriodo As Integer
        Protected lMesPeriodo As String
        Protected lDiaPeriodo As Integer
        Protected lCUCliente As String
        Protected lRazonSocial As String
        Protected lMontoDeudaSoles As Decimal
        Protected lMontoDeudaDolares As Decimal
        Protected lMontoContingente As Decimal
        Protected lNombreEjecutivo As String
        Protected lObservacion As String
        Protected lFecReg As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintAnioPeriodo As Integer, ByVal pintMesPeriodo As Integer, ByVal pintDiaPeriodo As Integer, ByVal pstrCUCliente As String, ByVal pstrRazonSocial As String, ByVal pdecMontoDeudaSoles As Decimal, ByVal pdecMontoDeudaDolares As Decimal, ByVal pdecMontoContingente As Decimal, ByVal pstrNombreEjecutivo As String, ByVal pstrObservacion As String)
            Me.lAnioPeriodo = pintAnioPeriodo
            Me.lMesPeriodo = pintMesPeriodo
            Me.lDiaPeriodo = pintDiaPeriodo
            Me.lCUCliente = pstrCUCliente
            Me.lRazonSocial = pstrRazonSocial
            Me.lMontoDeudaSoles = pdecMontoDeudaSoles
            Me.lMontoDeudaDolares = pdecMontoDeudaDolares
            Me.lMontoContingente = pdecMontoContingente
            Me.lNombreEjecutivo = pstrNombreEjecutivo
            Me.lObservacion = pstrObservacion
        End Sub

        Public Property AnioPeriodo() As Integer
            Get
                Return Me.lAnioPeriodo
            End Get
            Set(ByVal Value As Integer)
                Me.lAnioPeriodo = Value
            End Set
        End Property

        Public Property MesPeriodo() As Integer
            Get
                Return Me.lMesPeriodo
            End Get
            Set(ByVal Value As Integer)
                Me.lMesPeriodo = Value
            End Set
        End Property

        Public Property DiaPeriodo() As Integer
            Get
                Return Me.lDiaPeriodo
            End Get
            Set(ByVal Value As Integer)
                Me.lDiaPeriodo = Value
            End Set
        End Property

        Public Property CUCliente() As String
            Get
                Return Me.lCUCliente
            End Get
            Set(ByVal Value As String)
                Me.lCUCliente = Value
            End Set
        End Property

        Public Property RazonSocial() As String
            Get
                Return Me.lRazonSocial
            End Get
            Set(ByVal Value As String)
                Me.lRazonSocial = Value
            End Set
        End Property

        Public Property MontoDeudaSoles() As Decimal
            Get
                Return Me.lMontoDeudaSoles
            End Get
            Set(ByVal Value As Decimal)
                Me.lMontoDeudaSoles = Value
            End Set
        End Property

        Public Property MontoDeudaDolares() As Decimal
            Get
                Return Me.lMontoDeudaDolares
            End Get
            Set(ByVal Value As Decimal)
                Me.lMontoDeudaDolares = Value
            End Set
        End Property

        Public Property MontoContingente() As Decimal
            Get
                Return Me.lMontoContingente
            End Get
            Set(ByVal Value As Decimal)
                Me.lMontoContingente = Value
            End Set
        End Property

        Public Property NombreEjecutivo() As String
            Get
                Return Me.lNombreEjecutivo
            End Get
            Set(ByVal Value As String)
                Me.lNombreEjecutivo = Value
            End Set
        End Property

        Public Property Observacion() As String
            Get
                Return Me.lObservacion
            End Get
            Set(ByVal Value As String)
                Me.lObservacion = Value
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
