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
    Public Class Cliente
        Inherits EntityBase

        Protected lCodigoUnico As String
        Protected lNombre As String
        Protected lFechaApertura As String
        Protected lTipoDocumentoIdentidad As String
        Protected lNumeroDocumentoIdentidad As String
        Protected lCodigoSectoristaActual As String
        Protected lRegistroSectoristaActual As String
        Protected lCodigoTiendaActual As String
        Protected lCodigoTipoBancaIB As String
        Protected lCodigoTipoBancaSBS As String
        Protected lCodigoCalificacionIB As String
        Protected lFechaCalificacionIB As String
        Protected lPeriodoCalificacionIB As String
        Protected lCodigoCalificacionSBS As String
        Protected lCodigoSBS As String
        Protected lCodigoCIIU As String
        Protected lCodigoGrupoEconomico As String
        Protected lNombreGrupoEconomico As String
        Protected lCodigoSectorista As String
        Protected lCodigoTienda As String

        Sub New()
            MyBase.New()
        End Sub

        Public Property CodigoUnico() As String
            Get
                Return Me.lCodigoUnico
            End Get
            Set(ByVal Value As String)
                Me.lCodigoUnico = Value
            End Set
        End Property

        Public Property Nombre() As String
            Get
                Return Me.lNombre
            End Get
            Set(ByVal Value As String)
                Me.lNombre = Value
            End Set
        End Property

        Public Property FechaApertura() As String
            Get
                Return Me.lFechaApertura
            End Get
            Set(ByVal Value As String)
                Me.lFechaApertura = Value
            End Set
        End Property

        Public Property TipoDocumentoIdentidad() As String
            Get
                Return Me.lTipoDocumentoIdentidad
            End Get
            Set(ByVal Value As String)
                Me.lTipoDocumentoIdentidad = Value
            End Set
        End Property

        Public Property NumeroDocumentoIdentidad() As String
            Get
                Return Me.lNumeroDocumentoIdentidad
            End Get
            Set(ByVal Value As String)
                Me.lNumeroDocumentoIdentidad = Value
            End Set
        End Property

        Public Property CodigoSectoristaActual() As String
            Get
                Return Me.lCodigoSectoristaActual
            End Get
            Set(ByVal Value As String)
                Me.lCodigoSectoristaActual = Value
            End Set
        End Property

        Public Property RegistroSectoristaActual() As String
            Get
                Return Me.lRegistroSectoristaActual
            End Get
            Set(ByVal Value As String)
                Me.lRegistroSectoristaActual = Value
            End Set
        End Property

        Public Property CodigoTiendaActual() As String
            Get
                Return Me.lCodigoTiendaActual
            End Get
            Set(ByVal Value As String)
                Me.lCodigoTiendaActual = Value
            End Set
        End Property

        Public Property CodigoTipoBancaIB() As String
            Get
                Return Me.lCodigoTipoBancaIB
            End Get
            Set(ByVal Value As String)
                Me.lCodigoTipoBancaIB = Value
            End Set
        End Property

        Public Property CodigoTipoBancaSBS() As String
            Get
                Return Me.lCodigoTipoBancaSBS
            End Get
            Set(ByVal Value As String)
                Me.lCodigoTipoBancaSBS = Value
            End Set
        End Property

        Public Property CodigoCalificacionIB() As String
            Get
                Return Me.lCodigoCalificacionIB
            End Get
            Set(ByVal Value As String)
                Me.lCodigoCalificacionIB = Value
            End Set
        End Property

        Public Property FechaCalificacionIB() As String
            Get
                Return Me.lFechaCalificacionIB
            End Get
            Set(ByVal Value As String)
                Me.lFechaCalificacionIB = Value
            End Set
        End Property

        Public Property PeriodoCalificacionIB() As String
            Get
                Return Me.lPeriodoCalificacionIB
            End Get
            Set(ByVal Value As String)
                Me.lPeriodoCalificacionIB = Value
            End Set
        End Property

        Public Property CodigoCalificacionSBS() As String
            Get
                Return Me.lCodigoCalificacionSBS
            End Get
            Set(ByVal Value As String)
                Me.lCodigoCalificacionSBS = Value
            End Set
        End Property

        Public Property CodigoSBS() As String
            Get
                Return Me.lCodigoSBS
            End Get
            Set(ByVal Value As String)
                Me.lCodigoSBS = Value
            End Set
        End Property

        Public Property CodigoCIIU() As String
            Get
                Return Me.lCodigoCIIU
            End Get
            Set(ByVal Value As String)
                Me.lCodigoCIIU = Value
            End Set
        End Property

        Public Property CodigoGrupoEconomico() As String
            Get
                Return Me.lCodigoGrupoEconomico
            End Get
            Set(ByVal Value As String)
                Me.lCodigoGrupoEconomico = Value
            End Set
        End Property

        Public Property NombreGrupoEconomico() As String
            Get
                Return Me.lNombreGrupoEconomico
            End Get
            Set(ByVal Value As String)
                Me.lNombreGrupoEconomico = Value
            End Set
        End Property

        Public Property CodigoSectorista() As String
            Get
                Return Me.lCodigoSectorista
            End Get
            Set(ByVal Value As String)
                Me.lCodigoSectorista = Value
            End Set
        End Property

        Public Property CodigoTienda() As String
            Get
                Return Me.lCodigoTienda
            End Get
            Set(ByVal Value As String)
                Me.lCodigoTienda = Value
            End Set
        End Property

    End Class

End Namespace