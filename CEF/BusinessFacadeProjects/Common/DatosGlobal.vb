'*************************************************************
'Proposito: Almacenar en una Session los Datos Globales de ROC
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.Common

    Public Class DatosGlobal

        Protected lsCUCliente As String
        Protected lsNumRuc As String
        Protected lsNomCliente As String

        '--- Valores del SDA ---
        Protected lsSd As String
        Protected lsAmbiente As String
        Protected lsAmbienteDes As String
        Protected lsUser As String
        Protected lsUserName As String
        Protected lnPerfil As Integer
        Protected lsAcceso As String
        Protected lsPeriodo As String
        Protected lsDbServer As String
        Protected lsDbName As String

        Sub New()
            MyBase.New()
        End Sub

        Public Property sCUCliente() As Integer
            Get
                Return Me.lsCUCliente
            End Get
            Set(ByVal Value As Integer)
                Me.lsCUCliente = Value
            End Set
        End Property

        Public Property sNumRuc() As Integer
            Get
                Return Me.lsNumRuc
            End Get
            Set(ByVal Value As Integer)
                Me.lsNumRuc = Value
            End Set
        End Property

        Public Property sNomCliente() As String
            Get
                Return Me.lsNomCliente
            End Get
            Set(ByVal Value As String)
                Me.lsNomCliente = Value
            End Set
        End Property

        Public Property sSd() As String
            Get
                Return Me.lsSd
            End Get
            Set(ByVal Value As String)
                Me.lsSd = Value
            End Set
        End Property

        Public Property sAmbiente() As String
            Get
                Return Me.lsAmbiente
            End Get
            Set(ByVal Value As String)
                Me.lsAmbiente = Value
            End Set
        End Property

        Public Property sAmbienteDes() As String
            Get
                Return Me.lsAmbienteDes
            End Get
            Set(ByVal Value As String)
                Me.lsAmbienteDes = Value
            End Set
        End Property

        Public Property sUser() As String
            Get
                Return Me.lsUser
            End Get
            Set(ByVal Value As String)
                Me.lsUser = Value
            End Set
        End Property

        Public Property sUserName() As String
            Get
                Return Me.lsUserName
            End Get
            Set(ByVal Value As String)
                Me.lsUserName = Value
            End Set
        End Property

        Public Property nPerfil() As Integer
            Get
                Return Me.lnPerfil
            End Get
            Set(ByVal Value As Integer)
                Me.lnPerfil = Value
            End Set
        End Property

        Public Property sAcceso() As String
            Get
                Return Me.lsAcceso
            End Get
            Set(ByVal Value As String)
                Me.lsAcceso = Value
            End Set
        End Property

        Public Property sPeriodo() As String
            Get
                Return Me.lsPeriodo
            End Get
            Set(ByVal Value As String)
                Me.lsPeriodo = Value
            End Set
        End Property

        Public Property sDbServer() As String
            Get
                Return Me.lsDbServer
            End Get
            Set(ByVal Value As String)
                Me.lsDbServer = Value
            End Set
        End Property

        Public Property sDbName() As String
            Get
                Return Me.lsDbName
            End Get
            Set(ByVal Value As String)
                Me.lsDbName = Value
            End Set
        End Property

    End Class

End Namespace