Imports System.Xml.Serialization
Imports System.IO
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection


Namespace CEF.WebUI

    Partial Class mcbReconciliacion
        Inherits PageBase

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
            InitializeComponent()
        End Sub

#End Region

        <Serializable()> _
        Public Class CBMensaje
            Private lCodError As String
            Private lDescripcion As String

            Sub New()
                MyBase.New()
                lCodError = 0
            End Sub

            Sub New(ByVal pintCodError As Integer, ByVal pstrDescripcion As String)
                Me.lCodError = pintCodError
                Me.lDescripcion = pstrDescripcion
            End Sub

            <XmlAttributeAttribute(attributeName:="CodError")> _
            Public Property CodError() As Integer
                Get
                    Return (Me.lCodError)
                End Get
                Set(ByVal Value As Integer)
                    Me.lCodError = Value
                End Set
            End Property

            <XmlAttributeAttribute(attributeName:="Descripcion")> _
            Public Property Descripcion() As String
                Get
                    Return (Me.lDescripcion)
                End Get
                Set(ByVal Value As String)
                    Me.lDescripcion = Value
                End Set
            End Property
        End Class

        <Serializable()> _
        Public Class CBRpt
            Private lCodUsuario As String
            Private lNombreUsuario As String
            Private lDesEstado As String
            Private lMensaje As New CBMensaje
            Private lCodCorridaMetodizado As Integer = 0

            Sub New()
                MyBase.New()
            End Sub

            Public Property Mensaje() As CBMensaje
                Get
                    Return lMensaje
                End Get
                Set(ByVal Value As CBMensaje)
                    lMensaje = Value
                End Set
            End Property

            Public Property CodUsuario() As String
                Get
                    Return lCodUsuario
                End Get
                Set(ByVal Value As String)
                    lCodUsuario = Value
                End Set
            End Property

            Public Property NombreUsuario() As String
                Get
                    Return lNombreUsuario
                End Get
                Set(ByVal Value As String)
                    lNombreUsuario = Value
                End Set
            End Property

            Public Property DesEstado() As String
                Get
                    Return lDesEstado
                End Get
                Set(ByVal Value As String)
                    lDesEstado = Value
                End Set
            End Property

            Public Property CodCorridaMetodizado() As Integer
                Get
                    Return lCodCorridaMetodizado
                End Get
                Set(ByVal Value As Integer)
                    lCodCorridaMetodizado = Value
                End Set
            End Property

        End Class

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            grabarReconciliacion()
        End Sub

        Private Sub grabarReconciliacion()
            'Dim strCodUsuario As String = DatosGlobal.sUser
            Dim strCodUsuario As String = retornaUsuarioSesion()
            Dim ocbRpt As CBRpt
            Dim nvcData As System.Collections.Specialized.NameValueCollection
            nvcData = Request.ServerVariables

            Try
                Dim intCodMetodizado As Integer = Int32.Parse(nvcData("HTTP_intCodMetodizado"))

                Dim intCodCorridaMetodizado As Integer = 0
                If Not nvcData("HTTP_intCodCorridaMetodizado") Is Nothing Then
                    intCodCorridaMetodizado = Int32.Parse(nvcData("HTTP_intCodCorridaMetodizado"))
                End If

                Dim intCodMonedaCorrida As Integer = 0
                If Not nvcData("HTTP_intCodMonedaCorrida") Is Nothing Then
                    intCodMonedaCorrida = Int32.Parse(nvcData("HTTP_intCodMonedaCorrida"))
                End If

                Dim strPeriodoFiltrado As String = nvcData("HTTP_strPeriodoFiltrado")
                Dim strImporteReconciliado As String = nvcData("HTTP_strImporteReconciliado")
                Dim strCuentaLibre As String = nvcData("HTTP_strCuentaLibre")
                Dim bytEstado As Byte = Byte.Parse(nvcData("HTTP_bytEstado"))
                Dim obePeriodoLst As BusinessEntity.PeriodoLst = New BusinessEntity.PeriodoLst
                Dim obePeriodoCorridaLst As New BusinessEntity.PeriodoCorridaLst
                Dim bytPeriodoIndividual As Byte = 0
                If Not nvcData("HTTP_bytPeriodoIndividual") Is Nothing Then
                    bytPeriodoIndividual = Byte.Parse(nvcData("HTTP_bytPeriodoIndividual"))
                End If

                Dim arrCodPeriodo As String() = strPeriodoFiltrado.Split(";")
                For Each strCodPeriodo As String In arrCodPeriodo
                    Dim obePeriodo As BusinessEntity.Periodo = New BusinessEntity.Periodo
                    obePeriodo.CodMetodizado = intCodMetodizado
                    obePeriodo.CodPeriodo = Int32.Parse(strCodPeriodo)

                    obePeriodo.CodUsuarioEnv = String.Empty
                    obePeriodo.CodUsuarioVal = String.Empty

                    Select Case bytEstado
                        Case ecEstadoMetodizado.PENDIENTE
                            obePeriodo.CodUsuarioEnv = strCodUsuario
                        Case ecEstadoMetodizado.VALIDADO
                            obePeriodo.CodUsuarioVal = strCodUsuario
                    End Select

                    obePeriodoLst.Add(obePeriodo)

                    If bytEstado = ecEstadoMetodizado.VALIDADO AndAlso intCodMonedaCorrida <> 0 Then
                        Dim obePeriodoCorrida As BusinessEntity.PeriodoCorrida = New BusinessEntity.PeriodoCorrida
                        obePeriodoCorrida.CodMetodizado = intCodMetodizado
                        obePeriodoCorrida.CodCorrida = intCodCorridaMetodizado
                        obePeriodoCorrida.CodPeriodo = Int32.Parse(strCodPeriodo)
                        obePeriodoCorrida.Validado = (bytEstado = ecEstadoMetodizado.VALIDADO)
                        obePeriodoCorrida.Estado = ecEstadoPeriodoCorrida.ACTIVO

                        obePeriodoCorridaLst.Add(obePeriodoCorrida)
                    End If
                Next

                If obePeriodoLst.Count > 0 Then
                    If strImporteReconciliado.EndsWith("|") Then strImporteReconciliado = strImporteReconciliado.Substring(0, strImporteReconciliado.Length - 1)
                    If strImporteReconciliado <> String.Empty Then
                        Dim arrPeriodoCuenta As String() = strImporteReconciliado.Split("|")
                        For Each strPeriodoCuenta As String In arrPeriodoCuenta
                            Dim arrValor As String() = strPeriodoCuenta.Split(";")
                            Dim intCodPeriodo As Integer = CType(arrValor(0), Integer)
                            Dim intCodCuenta As Integer = CType(arrValor(1), Integer)
                            Dim strFuncion As String = CType(arrValor(3), String)
                            If IsNumeric(arrValor(2)) Then
                                Dim decImporte As Decimal = CType(arrValor(2), Decimal)
                                Dim obePeriodoCuenta As BusinessEntity.PeriodoCuenta = New BusinessEntity.PeriodoCuenta
                                obePeriodoCuenta.CodMetodizado = intCodMetodizado
                                obePeriodoCuenta.CodPeriodo = intCodPeriodo
                                obePeriodoCuenta.CodCuenta = intCodCuenta
                                obePeriodoCuenta.Importe = decImporte
                                obePeriodoCuenta.Funcion = strFuncion

                                Dim obePeriodo As BusinessEntity.Periodo = obePeriodoLst.buscarPorClave(intCodMetodizado, intCodPeriodo)
                                If Not obePeriodo Is Nothing Then
                                    obePeriodo.PeriodoCuentas.Add(obePeriodoCuenta)
                                End If
                            End If
                        Next
                    End If

                    Dim obeCuentaLibreLst As BusinessEntity.CuentaLibreLst = New BusinessEntity.CuentaLibreLst
                    ' 23/01/2014 : XT5022 - JAVILA (CGI)
                    If Not strCuentaLibre Is Nothing Then
                        If strCuentaLibre.EndsWith("|") Then strCuentaLibre = strCuentaLibre.Substring(0, strCuentaLibre.Length - 1)
                        If strCuentaLibre <> String.Empty Then
                            Dim arrCuentaLibre As String() = strCuentaLibre.Split("|")
                            For Each strValorCuentaLibre As String In arrCuentaLibre
                                Dim arrValor As String() = strValorCuentaLibre.Split(";")
                                Dim intCodCuenta As Integer = CType(arrValor(0), Integer)
                                Dim strDescripcion As String = CType(arrValor(1), String)
                                Dim obeCuentaLibre As BusinessEntity.CuentaLibre = New BusinessEntity.CuentaLibre
                                obeCuentaLibre.CodMetodizado = intCodMetodizado
                                obeCuentaLibre.CodCuenta = intCodCuenta

                                'ADD ADR 08/02/2019 INICIO


                                'ADD ADR 08/02/2019 FIN
                                obeCuentaLibre.Descripcion = strDescripcion
                                obeCuentaLibreLst.Add(obeCuentaLibre)
                            Next
                        End If
                    End If
                    
                    Dim obeMetodizado As BusinessEntity.Metodizado = New BusinessEntity.Metodizado

                    obeMetodizado.CodMetodizado = intCodMetodizado

                    Dim obeUsuario As BusinessEntity.Usuario
                    Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario


                    obeUsuario = obrUsuario.leer(strCodUsuario)

                    obeMetodizado.CodUsuario = obeUsuario.CodUsuario
                    obeMetodizado.NombreUsuario = obeUsuario.Nombre

                    obeMetodizado.Estado = bytEstado

                    'Dim obePermisoPerfil As BusinessEntity.PermisoPerfil
                    'Dim obiPermiso As BusinessInterface.IPermiso
                    'Dim obrPermiso As BusinessRules.Permiso = New BusinessRules.Permiso
                    'obiPermiso = CType(obrPermiso, BusinessInterface.IPermiso)

                    'obePermisoPerfil = obiPermiso.leerPermisoPerfil(1, obeUsuario.CodPerfil)

                    'If Not obePermisoPerfil Is Nothing Then
                    '    If obePermisoPerfil.Valor = True Then
                    '        obeMetodizado.Estado = Int32.Parse(ecEstadoMetodizado.VALIDADO)
                    '    Else
                    '        obeMetodizado.Estado = Int32.Parse(ecEstadoMetodizado.PENDIENTE)
                    '    End If
                    'Else
                    '    obeMetodizado.Estado = Int32.Parse(ecEstadoMetodizado.PENDIENTE)
                    'End If

                    obeMetodizado.Periodos = obePeriodoLst
                    obeMetodizado.CuentasLibres = obeCuentaLibreLst

                    Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado

                    Dim obeCorridaMetodizado As BusinessEntity.CorridaMetodizado = Nothing
                    If bytEstado = ecEstadoMetodizado.VALIDADO AndAlso intCodMonedaCorrida <> 0 Then
                        obeCorridaMetodizado = New BusinessEntity.CorridaMetodizado
                        obeCorridaMetodizado.CodMetodizado = intCodMetodizado
                        obeCorridaMetodizado.CodCorrida = intCodCorridaMetodizado
                        obeCorridaMetodizado.CodMoneda = intCodMonedaCorrida
                        obeCorridaMetodizado.PeriodosCorrida = obePeriodoCorridaLst
                        obeCorridaMetodizado.CodUsuarioReg = strCodUsuario
                        obeCorridaMetodizado.CodUsuarioUpd = strCodUsuario
                        obeCorridaMetodizado.Estado = ecEstadoCorridaMetodizado.ACTIVO
                        Dim obrCorridaMetodizado As New BusinessRules.CorridaMetodizado

                        If intCodCorridaMetodizado = 0 Then
                            intCodCorridaMetodizado = fRetornaCodCorridaMetodizado(intCodMetodizado, arrCodPeriodo)
                            obeCorridaMetodizado.CodCorrida = intCodCorridaMetodizado
                        End If
                        If intCodCorridaMetodizado > 0 Then
                            obeCorridaMetodizado.Flag = 2
                        Else
                            obeCorridaMetodizado.Flag = 2
                        End If

                    End If

                    Dim bolRC As Boolean = obrMetodizado.reconciliar(obeMetodizado, obeCorridaMetodizado)

                    If bolRC Then
                        ocbRpt = New CBRpt
                        ocbRpt.Mensaje.CodError = 0
                        ocbRpt.Mensaje.Descripcion = ccALERTA_EXITO_GRABAR_RECONCILIACION
                        ocbRpt.CodUsuario = obeMetodizado.CodUsuario
                        ocbRpt.NombreUsuario = obeMetodizado.NombreUsuario
                        Dim obeGeneral As BusinessEntity.General = buscarGeneralItem(ecTablaGeneral.ESTADO_METODIZADO, obeMetodizado.Estado)
                        ocbRpt.DesEstado = obeGeneral.Descripcion
                        If Not obeCorridaMetodizado Is Nothing Then
                            If bytPeriodoIndividual = 0 Then
                                ocbRpt.CodCorridaMetodizado = obeCorridaMetodizado.CodCorrida
                            Else
                                ocbRpt.CodCorridaMetodizado = 0
                            End If

                        End If
                    Else
                        ocbRpt = New CBRpt
                        ocbRpt.Mensaje.CodError = 1
                        ocbRpt.Mensaje.Descripcion = ccALERTA_ERROR_GRABAR_RECONCILIACION
                    End If
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                ocbRpt = New CBRpt
                ocbRpt.Mensaje.CodError = 1
                ocbRpt.Mensaje.Descripcion = ccALERTA_ERROR_GRABAR_RECONCILIACION
            End Try

            Dim sbXml As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim swDoc As System.IO.StringWriter = New System.IO.StringWriter(sbXml)
            Dim xsRpt As XmlSerializer = New XmlSerializer(GetType(CBRpt))
            xsRpt.Serialize(swDoc, ocbRpt)
            sbXml.Replace("utf-16", "utf-8")

            Response.Clear()
            Response.ContentType = "text/xml"
            Response.Write(sbXml.ToString())

            Response.End()
        End Sub

    End Class

End Namespace