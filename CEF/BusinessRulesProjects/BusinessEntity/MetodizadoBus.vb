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
    Public Class MetodizadoBus
        Inherits Metodizado

        Protected lFecInicio As DateTime
        Protected lFecFin As DateTime

        Sub New()
            MyBase.New()
        End Sub

        Public Property FecInicio() As DateTime
            Get
                Return Me.lFecInicio
            End Get
            Set(ByVal Value As DateTime)
                Me.lFecInicio = Value
            End Set
        End Property

        Public Property FecFin() As DateTime
            Get
                Return Me.lFecFin
            End Get
            Set(ByVal Value As DateTime)
                Me.lFecFin = Value
            End Set
        End Property

    End Class

End Namespace