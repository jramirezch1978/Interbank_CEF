'*************************************************************
'Proposito:
'Autor: María Laura Santisteban Valdez
'Fecha Creacion: 28/03/2006
'Modificado por: Luis A. Mascaro Jácome
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class General
        Inherits EntityBase

        Protected lCodTbl As Integer
        Protected lCodItem As Integer
        Protected lDescripcion As String
        Protected lDesCorta As String
        Protected lFecReg As DateTime
        Protected lEstado As Byte

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodTbl As Integer, ByVal pintCodItem As Integer, ByVal pstrDescripcion As String, ByVal pstrDesCorta As String, ByVal pbytEstado As Byte)
            Me.lCodTbl = pintCodTbl
            Me.lCodItem = pintCodItem
            Me.lDescripcion = pstrDescripcion
            Me.lDesCorta = pstrDesCorta
            Me.lEstado = pbytEstado
        End Sub

        Public Property CodTbl() As Integer
            Get
                Return Me.lCodTbl
            End Get
            Set(ByVal Value As Integer)
                Me.lCodTbl = Value
            End Set
        End Property

        Public Property CodItem() As Integer
            Get
                Return Me.lCodItem
            End Get
            Set(ByVal Value As Integer)
                Me.lCodItem = Value
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

        Public Property DesCorta() As String
            Get
                Return Me.lDesCorta
            End Get
            Set(ByVal Value As String)
                Me.lDesCorta = Value
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
    End Class

End Namespace