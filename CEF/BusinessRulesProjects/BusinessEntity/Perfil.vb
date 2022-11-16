'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 28/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class Perfil
        Inherits EntityBase

        Protected lCodPerfil As Short
        Protected lNombre As String
        Protected lFecReg As DateTime
        Protected lEstado As Byte
        Protected lCarteraPerfiles As BusinessEntity.CarteraPerfilLst = New BusinessEntity.CarteraPerfilLst

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pstrlNombre As String, ByVal pbytEstado As Byte)
            Me.lNombre = pstrlNombre
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodPerfil() As Short
            Get
                Return Me.lCodPerfil
            End Get
            Set(ByVal Value As Short)
                Me.lCodPerfil = Value
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

        Public Property CarteraPerfiles() As CarteraPerfilLst
            Get
                Return Me.lCarteraPerfiles
            End Get
            Set(ByVal Value As CarteraPerfilLst)
                Me.lCarteraPerfiles = Value
            End Set
        End Property

    End Class

End Namespace
