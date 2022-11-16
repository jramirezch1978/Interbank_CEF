'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class Usuario
        Inherits EntityBase

        Protected lCodUsuario As String
        Protected lNombre As String
        Protected lEmail As String
        Protected lCodPerfil As Short
        Protected lFecReg As DateTime
        Protected lEstado As Byte
        Protected lSupervisor As Boolean
        Protected lCarteraUsuarios As BusinessEntity.CarteraUsuarioLst = New BusinessEntity.CarteraUsuarioLst

        Sub New()
            MyBase.New()
        End Sub

        Public Property CodUsuario() As String
            Get
                Return Me.lCodUsuario
            End Get
            Set(ByVal Value As String)
                Me.lCodUsuario = Value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return Me.lNombre
            End Get
            Set(ByVal Value As String)
                Me.lNombre = Value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return Me.lEmail
            End Get
            Set(ByVal Value As String)
                Me.lEmail = Value
            End Set
        End Property

        Public Property CodPerfil() As Short
            Get
                Return Me.lCodPerfil
            End Get
            Set(ByVal Value As Short)
                Me.lCodPerfil = Value
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


        Public Property Supervisor() As Boolean
            Get
                Return Me.lSupervisor
            End Get
            Set(ByVal Value As Boolean)
                Me.lSupervisor = Value
            End Set
        End Property

        Public ReadOnly Property bitSupervisor() As Byte
            Get
                If Me.lSupervisor Then
                    Return 1
                Else
                    Return 0
                End If
            End Get
        End Property

        Public Property CarteraUsuarios() As CarteraUsuarioLst
            Get
                Return Me.lCarteraUsuarios
            End Get
            Set(ByVal Value As CarteraUsuarioLst)
                Me.lCarteraUsuarios = Value
            End Set
        End Property

    End Class

End Namespace