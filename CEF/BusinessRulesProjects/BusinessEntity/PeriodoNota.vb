Imports System
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class PeriodoNota
        Inherits PeriodoCuenta

        Protected lNota As String
        Protected lusuarioIns As String
        Protected lusuarioUpd As String

        Protected lnombreUs As String
        Protected lestado As String
        Protected lsituacion As String
        Protected lAuditorDesc As String
        Protected lfechaPeriodo As String

        Sub New()
            MyBase.New()
        End Sub

        Public Property UsuarioUpd() As String
            Get
                Return lusuarioUpd
            End Get
            Set(ByVal Value As String)
                lusuarioUpd = Value
            End Set
        End Property
        Public Property UsuarioIns() As String
            Get
                Return lusuarioIns
            End Get
            Set(ByVal Value As String)
                lusuarioIns = Value
            End Set
        End Property
        Public Property Nota() As String
            Get
                Return lNota
            End Get
            Set(ByVal Value As String)
                lNota = Value
            End Set
        End Property
        Public Property NombreUsuario() As String
            Get
                Return lnombreUs
            End Get
            Set(ByVal Value As String)
                lnombreUs = Value
            End Set
        End Property
        Public Property Estado() As String
            Get
                Return lestado
            End Get
            Set(ByVal Value As String)
                lestado = Value
            End Set
        End Property
        Public Property Situacion() As String
            Get
                Return lsituacion
            End Get
            Set(ByVal Value As String)
                lsituacion = Value
            End Set
        End Property
        Public Property AuditorDesc() As String
            Get
                Return lAuditorDesc
            End Get
            Set(ByVal Value As String)
                lAuditorDesc = Value
            End Set
        End Property
        Public Property FechaPeriodo() As String
            Get
                Return lfechaPeriodo
            End Get
            Set(ByVal Value As String)
                lfechaPeriodo = Value
            End Set
        End Property

    End Class

End Namespace
