
Imports CEF.Common
Imports System

Namespace CEF.BusinessEntity
    <Serializable()> _
    Public Class ProyeccionCuentaBE
        Inherits CEF.BusinessEntity.EntityBase

        'Protected _codMetodizado As Integer
        'Protected _codProyeccion As Integer
        Protected _codCuenta As Integer
        Protected _importe As Decimal = 0
        ' Protected _codUsuarioIns As String
        ' Protected _fechaHoraIns As Date
        ' Protected _codUsuarioUpd As String
        'Protected _fechaHoraUpd As Date

        'Public Property CodMetodizado() As Integer
        '    Get
        '        Return Me._codMetodizado
        '    End Get
        '    Set(ByVal Value As Integer)
        '        Me._codMetodizado = Value
        '    End Set
        'End Property
        'Public Property CodProyeccion() As Integer
        '    Get
        '        Return Me._codProyeccion
        '    End Get
        '    Set(ByVal Value As Integer)
        '        Me._codProyeccion = Value
        '    End Set
        'End Property
        Public Property CodCuenta() As Integer
            Get
                Return Me._codCuenta
            End Get
            Set(ByVal Value As Integer)
                Me._codCuenta = Value
            End Set
        End Property
        Public Property Importe() As Decimal
            Get
                Return Me._importe
            End Get
            Set(ByVal Value As Decimal)
                Me._importe = Value
            End Set
        End Property
        'Public Property CodUsuarioIns() As String
        '    Get
        '        Return Me._codUsuarioIns
        '    End Get
        '    Set(ByVal Value As String)
        '        Me._codUsuarioIns = Value
        '    End Set
        'End Property
        'Public Property FechaHoraIns() As Date
        '    Get
        '        Return Me._fechaHoraIns
        '    End Get
        '    Set(ByVal Value As Date)
        '        Me._fechaHoraIns = Value
        '    End Set
        'End Property
        'Public Property CodUsuarioUpd() As String
        '    Get
        '        Return Me._codUsuarioUpd
        '    End Get
        '    Set(ByVal Value As String)
        '        Me._codUsuarioUpd = Value
        '    End Set
        'End Property
        'Public Property FechaHoraUpd() As Date
        '    Get
        '        Return Me._fechaHoraUpd
        '    End Get
        '    Set(ByVal Value As Date)
        '        Me._fechaHoraUpd = Value
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
        End Sub

    End Class
End Namespace
