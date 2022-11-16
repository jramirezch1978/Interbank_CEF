Imports CEF.Common
Imports System
Imports System.Collections
Imports System.Xml.Serialization


Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class ProyeccionBE
        Inherits CEF.BusinessEntity.EntityBase

        Protected _codMetodizado As Integer
        Protected _codProyeccion As Integer
        Protected _fechaProyeccion As Date
        Protected _fechaRegistro As Date
        Protected _estado As Globals.ecEstadoPeriodo
        Protected _codUsuarioIns As String
        Protected _fechaHoraIns As Date = Date.Now
        Protected _codUsuarioUpd As String = String.Empty
        Protected _fechaHoraUpd As Date = Date.Now
        Protected _codMoneda As Globals.ecMoneda = Globals.ecMoneda.SOLES
        Protected _codUnidad As Globals.ecUnidad = Globals.ecUnidad.MILES

        Protected _codUsuarioVal As String = String.Empty
        Protected _fechaHoraVal As Date = Date.Now

        Protected pListaProyeccionCuenta As ProyeccionCuentaLst = New ProyeccionCuentaLst
        Public Property ProyeccionCuentaLst() As ProyeccionCuentaLst
            Get
                Return Me.pListaProyeccionCuenta
            End Get
            Set(ByVal Value As ProyeccionCuentaLst)
                Me.pListaProyeccionCuenta = Value
            End Set
        End Property

        Public Property CodMetodizado() As Integer
            Get
                Return Me._codMetodizado
            End Get
            Set(ByVal Value As Integer)
                Me._codMetodizado = Value
            End Set
        End Property
        Public Property CodProyeccion() As Integer
            Get
                Return Me._codProyeccion
            End Get
            Set(ByVal Value As Integer)
                Me._codProyeccion = Value
            End Set
        End Property

        Public Property CodUsuarioVal() As String
            Get
                Return Me._codUsuarioVal
            End Get
            Set(ByVal Value As String)
                Me._codUsuarioVal = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public Property FechaHoraVal() As Date
            Get
                Return Me._fechaHoraVal
            End Get
            Set(ByVal Value As Date)
                Me._fechaHoraVal = Value
            End Set
        End Property
        <XmlElement("FechaHoraVal")> _
        Public Property FechaHoraValStr() As String
            Get
                Return Me.FechaHoraVal.ToString("yyyy-MM-dd HH:mm:ss")
            End Get
            Set(ByVal Value As String)
                Me.FechaHoraVal = Date.Parse(Value)
            End Set
        End Property

        <XmlIgnore()> _
        Public Property FechaProyeccion() As Date
            Get
                Return Me._fechaProyeccion
            End Get
            Set(ByVal Value As Date)
                Me._fechaProyeccion = Value
            End Set
        End Property
        <XmlElement("FechaProyeccion")> _
        Public Property FechaProyeccionStr() As String
            Get
                Return Me.FechaProyeccion.ToString("yyyy-MM-dd")
            End Get
            Set(ByVal Value As String)
                Me.FechaProyeccion = Date.Parse(Value)
            End Set
        End Property

        <XmlIgnore()> _
        Public Property FechaRegistro() As Date
            Get
                Return Me._fechaRegistro
            End Get
            Set(ByVal Value As Date)
                Me._fechaRegistro = Value
            End Set
        End Property
        <XmlElement("FechaRegistro")> _
        Public Property FechaRegistroStr() As String
            Get
                Return Me.FechaRegistro.ToString("yyyy-MM-dd")
            End Get
            Set(ByVal Value As String)
                Me.FechaRegistro = Date.Parse(Value)
            End Set
        End Property

        Public Property Estado() As Globals.ecEstadoPeriodo
            Get
                Return Me._estado
            End Get
            Set(ByVal Value As Globals.ecEstadoPeriodo)
                Me._estado = Value
            End Set
        End Property
        Public Property CodUsuarioIns() As String
            Get
                Return Me._codUsuarioIns
            End Get
            Set(ByVal Value As String)
                Me._codUsuarioIns = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public Property FechaHoraIns() As Date
            Get
                Return Me._fechaHoraIns
            End Get
            Set(ByVal Value As Date)
                Me._fechaHoraIns = Value
            End Set
        End Property
        <XmlElement("FechaHoraIns")> _
        Public Property FechaHoraInsStr() As String
            Get
                Return Me.FechaHoraIns.ToString("yyyy-MM-dd HH:mm:ss")
            End Get
            Set(ByVal Value As String)
                Me.FechaHoraIns = Date.Parse(Value)
            End Set
        End Property

        Public Property CodUsuarioUpd() As String
            Get
                Return Me._codUsuarioUpd
            End Get
            Set(ByVal Value As String)
                Me._codUsuarioUpd = Value
            End Set
        End Property

        <XmlIgnore()> _
        Public Property FechaHoraUpd() As Date
            Get
                Return Me._fechaHoraUpd
            End Get
            Set(ByVal Value As Date)
                Me._fechaHoraUpd = Value
            End Set
        End Property
        <XmlElement("FechaHoraUpd")> _
        Public Property FechaHoraUpdStr() As String
            Get
                Return Me.FechaHoraUpd.ToString("yyyy-MM-dd HH:mm:ss")
            End Get
            Set(ByVal Value As String)
                Me.FechaHoraUpd = Date.Parse(Value)
            End Set
        End Property

        Public Property CodMoneda() As Globals.ecMoneda
            Get
                Return Me._codMoneda
            End Get
            Set(ByVal Value As Globals.ecMoneda)
                Me._codMoneda = Value
            End Set
        End Property

        Public Property CodUnidad() As Globals.ecUnidad
            Get
                Return Me._codUnidad
            End Get
            Set(ByVal Value As Globals.ecUnidad)
                Me._codUnidad = Value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
        End Sub

    End Class
End Namespace