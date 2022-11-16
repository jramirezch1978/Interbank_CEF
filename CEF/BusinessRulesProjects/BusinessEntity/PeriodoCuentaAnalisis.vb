'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System
Namespace CEF.BusinessEntity
    <Serializable()> _
    Public Class PeriodoCuentaAnalisis
        Inherits EntityBase

        Private lFlag As Byte
        Private lCodmetodizado As Integer
        Private lCodcorrida As Short
        Private lCodperiodoctaanalisis As Integer
        Private lCodanalisis As Short
        Private lCodeeff As Short
        Private lCodcuentaanalisis As Short
        Private lDescripcion As String
        Private lCodtipocuenta As Byte
        Private lImporte1 As Decimal
        Private lPorcentaje1 As Decimal
        Private lVariacion1 As Decimal
        Private lSoles1 As Decimal
        Private lDolares1 As Decimal
        Private lImporte2 As Decimal
        Private lPorcentaje2 As Decimal
        Private lVariacion2 As Decimal
        Private lSoles2 As Decimal
        Private lDolares2 As Decimal
        Private lImporte3 As Decimal
        Private lPorcentaje3 As Decimal
        Private lVariacion3 As Decimal
        Private lSoles3 As Decimal
        Private lDolares3 As Decimal
        Private lImporte4 As Decimal
        Private lPorcentaje4 As Decimal
        Private lVariacion4 As Decimal
        Private lSoles4 As Decimal
        Private lDolares4 As Decimal
        Private lExposicion1 As String
        Private lExposicion2 As String
        Private lExposicion3 As String
        Private lExposicion4 As String
        Private lOutval As Integer

        Sub New()
            MyBase.New()
            Me.lCodmetodizado = 0
            Me.lCodcorrida = 0
            Me.lCodperiodoctaanalisis = 0
            Me.lCodanalisis = 0
            Me.lCodeeff = 0
            Me.lCodcuentaanalisis = 0
            Me.lDescripcion = ""
            Me.lCodtipocuenta = 0
            Me.lImporte1 = 0
            Me.lPorcentaje1 = 0
            Me.lVariacion1 = 0
            Me.lSoles1 = 0
            Me.lDolares1 = 0
            Me.lImporte2 = 0
            Me.lPorcentaje2 = 0
            Me.lVariacion2 = 0
            Me.lSoles2 = 0
            Me.lDolares2 = 0
            Me.lImporte3 = 0
            Me.lPorcentaje3 = 0
            Me.lVariacion3 = 0
            Me.lSoles3 = 0
            Me.lDolares3 = 0
            Me.lImporte4 = 0
            Me.lPorcentaje4 = 0
            Me.lVariacion4 = 0
            Me.lSoles4 = 0
            Me.lDolares4 = 0
            Me.lExposicion1 = ""
            Me.lExposicion2 = ""
            Me.lExposicion3 = ""
            Me.lExposicion4 = ""
        End Sub
        Public Sub New(ByVal argFlag As Byte, _
                       ByVal argServidor As String, _
                       ByVal argBaseDato As String, _
                       ByVal argCodmetodizado As Integer, _
                       ByVal argCodcorrida As Short, _
                       ByVal argCodperiodoctaanalisis As Integer, _
                       ByVal argCodanalisis As Short, _
                       ByVal argCodeeff As Short, _
                       ByVal argCodcuentaanalisis As Short, _
                       ByVal argDescripcion As String, _
                       ByVal argCodtipocuenta As Byte, _
                       ByVal argImporte1 As Decimal, _
                       ByVal argPorcentaje1 As Decimal, _
                       ByVal argVariacion1 As Decimal, _
                       ByVal argSoles1 As Decimal, _
                       ByVal argDolares1 As Decimal, _
                       ByVal argImporte2 As Decimal, _
                       ByVal argPorcentaje2 As Decimal, _
                       ByVal argVariacion2 As Decimal, _
                       ByVal argSoles2 As Decimal, _
                       ByVal argDolares2 As Decimal, _
                       ByVal argImporte3 As Decimal, _
                       ByVal argPorcentaje3 As Decimal, _
                       ByVal argVariacion3 As Decimal, _
                       ByVal argSoles3 As Decimal, _
                       ByVal argDolares3 As Decimal, _
                       ByVal argImporte4 As Decimal, _
                       ByVal argPorcentaje4 As Decimal, _
                       ByVal argVariacion4 As Decimal, _
                       ByVal argSoles4 As Decimal, _
                       ByVal argDolares4 As Decimal, _
                       ByVal argExposicion1 As String, _
                       ByVal argExposicion2 As String, _
                       ByVal argExposicion3 As String, _
                       ByVal argExposicion4 As String _
                      )
            Me.lCodmetodizado = argCodmetodizado
            Me.lCodcorrida = argCodcorrida
            Me.lCodperiodoctaanalisis = argCodperiodoctaanalisis
            Me.lCodanalisis = argCodanalisis
            Me.lCodeeff = argCodeeff
            Me.lCodcuentaanalisis = argCodcuentaanalisis
            Me.lDescripcion = argDescripcion
            Me.lCodtipocuenta = argCodtipocuenta
            Me.lImporte1 = argImporte1
            Me.lPorcentaje1 = argPorcentaje1
            Me.lVariacion1 = argVariacion1
            Me.lSoles1 = argSoles1
            Me.lDolares1 = argDolares1
            Me.lImporte2 = argImporte2
            Me.lPorcentaje2 = argPorcentaje2
            Me.lVariacion2 = argVariacion2
            Me.lSoles2 = argSoles2
            Me.lDolares2 = argDolares2
            Me.lImporte3 = argImporte3
            Me.lPorcentaje3 = argPorcentaje3
            Me.lVariacion3 = argVariacion3
            Me.lSoles3 = argSoles3
            Me.lDolares3 = argDolares3
            Me.lImporte4 = argImporte4
            Me.lPorcentaje4 = argPorcentaje4
            Me.lVariacion4 = argVariacion4
            Me.lSoles4 = argSoles4
            Me.lDolares4 = argDolares4
            Me.lExposicion1 = argExposicion1
            Me.lExposicion2 = argExposicion2
            Me.lExposicion3 = argExposicion3
            Me.lExposicion4 = argExposicion4
        End Sub

        Public Property Flag() As Byte
            Get
                Return (lFlag)
            End Get
            Set(ByVal Value As Byte)
                lFlag = Value
            End Set
        End Property
        Public Property Codmetodizado() As Integer
            Get
                Return (lCodmetodizado)
            End Get
            Set(ByVal Value As Integer)
                lCodmetodizado = Value
            End Set
        End Property
        Public Property Codcorrida() As Short
            Get
                Return (lCodcorrida)
            End Get
            Set(ByVal Value As Short)
                lCodcorrida = Value
            End Set
        End Property
        Public Property Codperiodoctaanalisis() As Integer
            Get
                Return (lCodperiodoctaanalisis)
            End Get
            Set(ByVal Value As Integer)
                lCodperiodoctaanalisis = Value
            End Set
        End Property
        Public Property Codanalisis() As Short
            Get
                Return (lCodanalisis)
            End Get
            Set(ByVal Value As Short)
                lCodanalisis = Value
            End Set
        End Property
        Public Property Codeeff() As Short
            Get
                Return (lCodeeff)
            End Get
            Set(ByVal Value As Short)
                lCodeeff = Value
            End Set
        End Property
        Public Property Codcuentaanalisis() As Short
            Get
                Return (lCodcuentaanalisis)
            End Get
            Set(ByVal Value As Short)
                lCodcuentaanalisis = Value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return (lDescripcion)
            End Get
            Set(ByVal Value As String)
                lDescripcion = Value
            End Set
        End Property
        Public Property Codtipocuenta() As Byte
            Get
                Return (lCodtipocuenta)
            End Get
            Set(ByVal Value As Byte)
                lCodtipocuenta = Value
            End Set
        End Property
        Public Property Importe1() As Decimal
            Get
                Return (lImporte1)
            End Get
            Set(ByVal Value As Decimal)
                lImporte1 = Value
            End Set
        End Property
        Public Property Porcentaje1() As Decimal
            Get
                Return (lPorcentaje1)
            End Get
            Set(ByVal Value As Decimal)
                lPorcentaje1 = Value
            End Set
        End Property
        Public Property Variacion1() As Decimal
            Get
                Return (lVariacion1)
            End Get
            Set(ByVal Value As Decimal)
                lVariacion1 = Value
            End Set
        End Property
        Public Property Soles1() As Decimal
            Get
                Return (lSoles1)
            End Get
            Set(ByVal Value As Decimal)
                lSoles1 = Value
            End Set
        End Property
        Public Property Dolares1() As Decimal
            Get
                Return (lDolares1)
            End Get
            Set(ByVal Value As Decimal)
                lDolares1 = Value
            End Set
        End Property
        Public Property Importe2() As Decimal
            Get
                Return (lImporte2)
            End Get
            Set(ByVal Value As Decimal)
                lImporte2 = Value
            End Set
        End Property
        Public Property Porcentaje2() As Decimal
            Get
                Return (lPorcentaje2)
            End Get
            Set(ByVal Value As Decimal)
                lPorcentaje2 = Value
            End Set
        End Property
        Public Property Variacion2() As Decimal
            Get
                Return (lVariacion2)
            End Get
            Set(ByVal Value As Decimal)
                lVariacion2 = Value
            End Set
        End Property
        Public Property Soles2() As Decimal
            Get
                Return (lSoles2)
            End Get
            Set(ByVal Value As Decimal)
                lSoles2 = Value
            End Set
        End Property
        Public Property Dolares2() As Decimal
            Get
                Return (lDolares2)
            End Get
            Set(ByVal Value As Decimal)
                lDolares2 = Value
            End Set
        End Property
        Public Property Importe3() As Decimal
            Get
                Return (lImporte3)
            End Get
            Set(ByVal Value As Decimal)
                lImporte3 = Value
            End Set
        End Property
        Public Property Porcentaje3() As Decimal
            Get
                Return (lPorcentaje3)
            End Get
            Set(ByVal Value As Decimal)
                lPorcentaje3 = Value
            End Set
        End Property
        Public Property Variacion3() As Decimal
            Get
                Return (lVariacion3)
            End Get
            Set(ByVal Value As Decimal)
                lVariacion3 = Value
            End Set
        End Property
        Public Property Soles3() As Decimal
            Get
                Return (lSoles3)
            End Get
            Set(ByVal Value As Decimal)
                lSoles3 = Value
            End Set
        End Property
        Public Property Dolares3() As Decimal
            Get
                Return (lDolares3)
            End Get
            Set(ByVal Value As Decimal)
                lDolares3 = Value
            End Set
        End Property
        Public Property Importe4() As Decimal
            Get
                Return (lImporte4)
            End Get
            Set(ByVal Value As Decimal)
                lImporte4 = Value
            End Set
        End Property
        Public Property Porcentaje4() As Decimal
            Get
                Return (lPorcentaje4)
            End Get
            Set(ByVal Value As Decimal)
                lPorcentaje4 = Value
            End Set
        End Property
        Public Property Variacion4() As Decimal
            Get
                Return (lVariacion4)
            End Get
            Set(ByVal Value As Decimal)
                lVariacion4 = Value
            End Set
        End Property
        Public Property Soles4() As Decimal
            Get
                Return (lSoles4)
            End Get
            Set(ByVal Value As Decimal)
                lSoles4 = Value
            End Set
        End Property
        Public Property Dolares4() As Decimal
            Get
                Return (lDolares4)
            End Get
            Set(ByVal Value As Decimal)
                lDolares4 = Value
            End Set
        End Property
        Public Property Exposicion1() As String
            Get
                Return (lExposicion1)
            End Get
            Set(ByVal Value As String)
                lExposicion1 = Value
            End Set
        End Property
        Public Property Exposicion2() As String
            Get
                Return (lExposicion2)
            End Get
            Set(ByVal Value As String)
                lExposicion2 = Value
            End Set
        End Property
        Public Property Exposicion3() As String
            Get
                Return (lExposicion3)
            End Get
            Set(ByVal Value As String)
                lExposicion3 = Value
            End Set
        End Property
        Public Property Exposicion4() As String
            Get
                Return (lExposicion4)
            End Get
            Set(ByVal Value As String)
                lExposicion4 = Value
            End Set
        End Property
        Public ReadOnly Property Outval() As Integer
            Get
                Return (lOutval)
            End Get
        End Property
    End Class
End Namespace
