'*************************************************************
'Proposito:
'Autor: Miguel Delgado del Aguila
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class CuentaAnalisis
        Inherits EntityBase

        Protected lCodCuentaAnalisis As Integer
        Protected lDescripcion As String
        Protected lImporteRango1 As Decimal
        Protected lImporteRango2 As Decimal
        Protected lCuentaAnalisisList As BusinessEntity.CuentaAnalisisLst = New BusinessEntity.CuentaAnalisisLst

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pintCodCuentaAnalisis As Integer, _
                ByVal pstrDescripcion As String)
            Me.lCodCuentaAnalisis = pintCodCuentaAnalisis
            Me.lDescripcion = pstrDescripcion
        End Sub

        Public Property CodCuentaAnalisis() As Integer
            Get
                Return Me.lCodCuentaAnalisis
            End Get
            Set(ByVal Value As Integer)
                Me.lCodCuentaAnalisis = Value
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

        Public Property ImporteRango1() As Decimal
            Get
                Return Me.lImporteRango1
            End Get
            Set(ByVal Value As Decimal)
                Me.lImporteRango1 = Value
            End Set
        End Property

        Public Property ImporteRango2() As Decimal
            Get
                Return Me.lImporteRango2
            End Get
            Set(ByVal Value As Decimal)
                Me.lImporteRango2 = Value
            End Set
        End Property

        Public Property CuentaAnalisisList() As CuentaAnalisisLst
            Get
                Return Me.lCuentaAnalisisList
            End Get
            Set(ByVal Value As CuentaAnalisisLst)
                Me.lCuentaAnalisisList = Value
            End Set
        End Property

    End Class

End Namespace