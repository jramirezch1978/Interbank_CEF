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
    Public Class SupuestoProyectado
        Inherits EntityBase

        Protected lCodSupuesto As Integer
        Protected lCodProyectado As Byte
        Protected lCodCuentaSupuesto As Integer
        Protected lImporte As Decimal
        Protected lFuncion As String
        Protected lFecReg As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodSupuesto As Integer, _
                ByVal pbytCodProyectado As Byte, _
                ByVal pintCodCuentaSupuesto As Integer, _
                ByVal pdecImporte As Decimal)
            Me.lCodSupuesto = pintCodSupuesto
            Me.lCodProyectado = pbytCodProyectado
            Me.lCodCuentaSupuesto = pintCodCuentaSupuesto
            Me.lImporte = pdecImporte
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

        Public Property CodCuentaSupuesto() As Integer
            Get
                Return Me.lCodCuentaSupuesto
            End Get
            Set(ByVal Value As Integer)
                Me.lCodCuentaSupuesto = Value
            End Set
        End Property

        Public Property Importe() As Decimal
            Get
                Return Me.lImporte
            End Get
            Set(ByVal Value As Decimal)
                Me.lImporte = Value
            End Set
        End Property

        Public Property Funcion() As String
            Get
                Return Me.lFuncion
            End Get
            Set(ByVal Value As String)
                Me.lFuncion = Value
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