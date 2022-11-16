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
    Public Class Permiso
        Inherits EntityBase

        Protected lCodPermiso As Short
        Protected lCodComponente As Short
        Protected lDescripcion As String
        Protected lFecReg As DateTime
        Protected lEstado As Byte
        Protected lPermisosPerfiles As PermisoPerfilLst = New PermisoPerfilLst

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pshoCodComponente As Short, ByVal pstrDescripcion As String, ByVal pbytEstado As Byte)
            Me.lCodComponente = pshoCodComponente
            Me.lDescripcion = pstrDescripcion
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodPermiso() As Short
            Get
                Return Me.lCodPermiso
            End Get
            Set(ByVal Value As Short)
                Me.lCodPermiso = Value
            End Set
        End Property

        Public Property CodComponente() As Short
            Get
                Return Me.lCodComponente
            End Get
            Set(ByVal Value As Short)
                Me.lCodComponente = Value
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

        Public Property PermisosPerfiles() As PermisoPerfilLst
            Get
                Return Me.lPermisosPerfiles
            End Get
            Set(ByVal Value As PermisoPerfilLst)
                Me.lPermisosPerfiles = Value
            End Set
        End Property

    End Class

End Namespace
