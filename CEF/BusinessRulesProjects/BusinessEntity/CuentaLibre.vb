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
    Public Class CuentaLibre
        Inherits EntityBase

        Protected lCodMetodizado As Integer
        Protected lCodCuenta As Integer
        Protected lDescripcion As String
        Protected lFecReg As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodMetodizado As Integer, _
                ByVal pintCodCuenta As Integer, _
                ByVal pstrDescripcion As String)
            Me.lCodMetodizado = pintCodMetodizado
            Me.lCodCuenta = pintCodCuenta
            Me.lDescripcion = pstrDescripcion
        End Sub

        Public Property CodMetodizado() As Integer
            Get
                Return Me.lCodMetodizado
            End Get
            Set(ByVal Value As Integer)
                Me.lCodMetodizado = Value
            End Set
        End Property

        Public Property CodCuenta() As Integer
            Get
                Return Me.lCodCuenta
            End Get
            Set(ByVal Value As Integer)
                Me.lCodCuenta = Value
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

    End Class

End Namespace