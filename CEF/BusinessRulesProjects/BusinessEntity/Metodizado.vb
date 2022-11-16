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
    Public Class Metodizado
        Inherits EntityBase

        Protected lCodMetodizado As Integer
        Protected lCUCliente As String
        Protected lTipoDocumento As Byte
        Protected lNumeroDocumento As String
        Protected lRazonSocial As String
        Protected lCodCIIU As String
        Protected lNombreCIIU As String
        Protected lCodSBS As String
        Protected lCodGrupoEconomico As String
        Protected lNombreGrupoEconomico As String
        Protected lCodMoneda As Byte
        Protected lCodUnidad As Byte
        Protected lCodAnalista As String
        Protected lNombreAnalista As String
        Protected lCodEjecutivo As String
        Protected lNombreEjecutivo As String
        Protected lCodUsuario As String
        Protected lNombreUsuario As String
        Protected lCodMonedaImpresion As Byte
        Protected lFecReg As DateTime
        Protected lEstado As Byte
        Protected lPeriodos As PeriodoLst = New PeriodoLst
        Protected lCuentasLibres As CuentaLibreLst = New CuentaLibreLst
        Protected lFlgBPE As Integer
        Protected lSegmento As Integer
        'ADD XT8442 ADR 19-10-2018 INICIO
        Protected lTipoDocumentoComplementario As Byte
        Protected lNumeroDocumentoComplementario As String
        'ADD XT8442 ADR 19-10-2018 FIN
        'XT833 INI
        Protected lESCovenant As Byte
        Protected lCodFrecuenciaCov As Byte
        'XT833 FIN

        Sub New()
            MyBase.New()
        End Sub

        Sub New(ByVal pstrCUCliente As String, _
                ByVal pbytTipoDocumento As Byte, _
                ByVal pstrNumeroDocumento As String, _
                ByVal pstrRazonSocial As String, _
                ByVal pstrCodCIIU As String, _
                ByVal pstrCodSBS As String, _
                ByVal pstrCodGrupoEconomico As String, _
                ByVal pstrNombreGrupoEconomico As String, _
                ByVal pintCodMoneda As Byte, _
                ByVal pintCodUnidad As Byte, _
                ByVal pstrCodAnalista As String, _
                ByVal pstrNombreAnalista As String, _
                ByVal pstrCodEjecutivo As String, _
                ByVal pstrNombreEjecutivo As String, _
                ByVal pintCodMonedaImpresion As Byte, _
                ByVal pbytEstado As Byte, _
                ByVal pbytTipoDocumentoComplementario As Byte, _
                ByVal pstrNumeroDocumentoComplementario As String, _
                ByVal pbytESCovenant As Byte, _
                ByVal pbytCodFrecuenciaCov As Byte)
            Me.lCUCliente = pstrCUCliente
            Me.lTipoDocumento = pbytTipoDocumento
            Me.lNumeroDocumento = pstrNumeroDocumento
            Me.lRazonSocial = pstrRazonSocial
            Me.lCodCIIU = pstrCodCIIU
            Me.lCodSBS = pstrCodSBS
            Me.lCodGrupoEconomico = pstrCodGrupoEconomico
            Me.lNombreGrupoEconomico = pstrNombreGrupoEconomico
            Me.lCodMoneda = pintCodMoneda
            Me.lCodUnidad = pintCodUnidad
            Me.lCodAnalista = pstrCodAnalista
            Me.lNombreAnalista = pstrNombreAnalista
            Me.lCodEjecutivo = pstrCodEjecutivo
            Me.lNombreEjecutivo = pstrNombreEjecutivo
            Me.lCodMonedaImpresion = pintCodMonedaImpresion
            Me.lEstado = pbytEstado
            'ADD XT8442 ADR 19-10-2018 INICIO
            Me.lTipoDocumentoComplementario = pbytTipoDocumentoComplementario
            Me.lNumeroDocumentoComplementario = pstrNumeroDocumentoComplementario
            'ADD XT8442 ADR 19-10-2018 FIN
            'XT8633 INI
            Me.lESCovenant = pbytESCovenant
            Me.lCodFrecuenciaCov = pbytCodFrecuenciaCov
            'XT8633 FIN
        End Sub

        Public Property CodMetodizado() As Integer
            Get
                Return Me.lCodMetodizado
            End Get
            Set(ByVal Value As Integer)
                Me.lCodMetodizado = Value
            End Set
        End Property

        Public Property CUCliente() As String
            Get
                Return Me.lCUCliente
            End Get
            Set(ByVal Value As String)
                Me.lCUCliente = Value
            End Set
        End Property

        Public Property TipoDocumento() As Byte
            Get
                Return Me.lTipoDocumento
            End Get
            Set(ByVal Value As Byte)
                Me.lTipoDocumento = Value
            End Set
        End Property

        Public Property NumeroDocumento() As String
            Get
                Return Me.lNumeroDocumento
            End Get
            Set(ByVal Value As String)
                Me.lNumeroDocumento = Value
            End Set
        End Property

        Public Property RazonSocial() As String
            Get
                Return Me.lRazonSocial
            End Get
            Set(ByVal Value As String)
                Me.lRazonSocial = Value
            End Set
        End Property

        Public Property CodCIIU() As String
            Get
                Return Me.lCodCIIU
            End Get
            Set(ByVal Value As String)
                Me.lCodCIIU = Value
            End Set
        End Property

        Public Property NombreCIIU() As String
            Get
                Return Me.lNombreCIIU
            End Get
            Set(ByVal Value As String)
                Me.lNombreCIIU = Value
            End Set
        End Property

        Public Property CodSBS() As String
            Get
                Return Me.lCodSBS
            End Get
            Set(ByVal Value As String)
                Me.lCodSBS = Value
            End Set
        End Property

        Public Property CodGrupoEconomico() As String
            Get
                Return Me.lCodGrupoEconomico
            End Get
            Set(ByVal Value As String)
                Me.lCodGrupoEconomico = Value
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

        Public Property CodMoneda() As Byte
            Get
                Return Me.lCodMoneda
            End Get
            Set(ByVal Value As Byte)
                Me.lCodMoneda = Value
            End Set
        End Property

        Public Property CodUnidad() As Byte
            Get
                Return Me.lCodUnidad
            End Get
            Set(ByVal Value As Byte)
                Me.lCodUnidad = Value
            End Set
        End Property

        Public Property CodAnalista() As String
            Get
                Return Me.lCodAnalista
            End Get
            Set(ByVal Value As String)
                Me.lCodAnalista = Value
            End Set
        End Property

        Public Property NombreAnalista() As String
            Get
                Return Me.lNombreAnalista
            End Get
            Set(ByVal Value As String)
                Me.lNombreAnalista = Value
            End Set
        End Property

        Public Property CodEjecutivo() As String
            Get
                Return Me.lCodEjecutivo
            End Get
            Set(ByVal Value As String)
                Me.lCodEjecutivo = Value
            End Set
        End Property

        Public Property CodMonedaImpresion() As Byte
            Get
                Return Me.lCodMonedaImpresion
            End Get
            Set(ByVal Value As Byte)
                Me.lCodMonedaImpresion = Value
            End Set
        End Property

        Public Property NombreEjecutivo() As String
            Get
                Return Me.lNombreEjecutivo
            End Get
            Set(ByVal Value As String)
                Me.lNombreEjecutivo = Value
            End Set
        End Property

        Public Property CodUsuario() As String
            Get
                Return Me.lCodUsuario
            End Get
            Set(ByVal Value As String)
                Me.lCodUsuario = Value
            End Set
        End Property

        Public Property NombreUsuario() As String
            Get
                Return Me.lNombreUsuario
            End Get
            Set(ByVal Value As String)
                Me.lNombreUsuario = Value
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

        Public Property Periodos() As PeriodoLst
            Get
                Return Me.lPeriodos
            End Get
            Set(ByVal Value As PeriodoLst)
                Me.lPeriodos = Value
            End Set
        End Property

        Public Property CuentasLibres() As CuentaLibreLst
            Get
                Return Me.lCuentasLibres
            End Get
            Set(ByVal Value As CuentaLibreLst)
                Me.lCuentasLibres = Value
            End Set
        End Property

        Public Property FlgBPE() As Integer
            Get
                Return Me.lFlgBPE
            End Get
            Set(ByVal Value As Integer)
                Me.lFlgBPE = Value
            End Set
        End Property


        Public Property Segmento() As Integer
            Get
                Return Me.lSegmento
            End Get
            Set(ByVal Value As Integer)
                Me.lSegmento = Value
            End Set
        End Property

        'ADD XT8442 ADR 19-10-2018 INICIO
        Public Property TipoDocumentoComplementario() As Byte
            Get
                Return Me.lTipoDocumentoComplementario
            End Get
            Set(ByVal Value As Byte)
                Me.lTipoDocumentoComplementario = Value
            End Set
        End Property

        Public Property NumeroDocumentoComplementario() As String
            Get
                Return Me.lNumeroDocumentoComplementario
            End Get
            Set(ByVal Value As String)
                Me.lNumeroDocumentoComplementario = Value
            End Set
        End Property
        'ADD XT8442 ADR 19-10-2018 FIN
        'XT8633 INI
        Public Property ESCovenant() As Integer
            Get
                Return Me.lESCovenant
            End Get
            Set(ByVal Value As Integer)
                Me.lESCovenant = Value
            End Set
        End Property
        Public Property CodFrecuenciaCov() As Integer
            Get
                Return Me.lCodFrecuenciaCov
            End Get
            Set(ByVal Value As Integer)
                Me.lCodFrecuenciaCov = Value
            End Set
        End Property
        'XT8633 FIN
    End Class

End Namespace