Imports System.Xml.Serialization
Imports System.IO
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class mcbCorridaMetodizado
        Inherits PageBase

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
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
            grabarCorridaMetodizado()
        End Sub

        Private Sub grabarCorridaMetodizado()
            'Dim strCodUsuario As String = datosGlobal.sUser
            Dim strCodUsuario As String = retornaUsuarioSesion()
            Dim ocbRpt As CBRpt
            Dim nvcData As System.Collections.Specialized.NameValueCollection
            nvcData = Request.ServerVariables

            Try
                Dim intCodMonedaCorrida As Integer = 0
                If Not nvcData("HTTP_intCodMonedaCorrida") Is Nothing Then
                    intCodMonedaCorrida = Int32.Parse(nvcData("HTTP_intCodMonedaCorrida"))
                End If

                Dim intCodMetodizado As Integer = Int32.Parse(nvcData("HTTP_intCodMetodizado"))
                Dim intCodCorridaMetodizado As Integer = Int32.Parse(nvcData("HTTP_intCodCorridaMetodizado"))
                Dim strPeriodoFiltrado As String = nvcData("HTTP_strPeriodoFiltrado")
                Dim strImporteReconciliado As String = nvcData("HTTP_strImporteReconciliado")
                Dim strCuentaLibre As String = nvcData("HTTP_strCuentaLibre")
                Dim bytEstado As Byte = Byte.Parse(nvcData("HTTP_bytEstado"))
                Dim obePeriodoCorridaLst As New BusinessEntity.PeriodoCorridaLst

                Dim arrCodPeriodo As String() = strPeriodoFiltrado.Split(";")
                For Each strCodPeriodo As String In arrCodPeriodo
                    Dim obePeriodoCorrida As BusinessEntity.PeriodoCorrida = New BusinessEntity.PeriodoCorrida
                    obePeriodoCorrida.CodMetodizado = intCodMetodizado
                    obePeriodoCorrida.CodCorrida = intCodCorridaMetodizado
                    obePeriodoCorrida.CodPeriodo = Int32.Parse(strCodPeriodo)
                    obePeriodoCorrida.Validado = (bytEstado = ecEstadoMetodizado.VALIDADO)
                    obePeriodoCorrida.Estado = ecEstadoPeriodoCorrida.ACTIVO

                    obePeriodoCorridaLst.Add(obePeriodoCorrida)
                Next

                If obePeriodoCorridaLst.Count > 0 Then

                    Dim obeCorridaMetodizado As BusinessEntity.CorridaMetodizado = Nothing
                    obeCorridaMetodizado = New BusinessEntity.CorridaMetodizado
                    obeCorridaMetodizado.CodMetodizado = intCodMetodizado
                    obeCorridaMetodizado.CodMoneda = intCodMonedaCorrida
                    obeCorridaMetodizado.CodCorrida = intCodCorridaMetodizado
                    obeCorridaMetodizado.PeriodosCorrida = obePeriodoCorridaLst
                    obeCorridaMetodizado.CodUsuarioReg = strCodUsuario
                    obeCorridaMetodizado.CodUsuarioUpd = strCodUsuario
                    obeCorridaMetodizado.Estado = ecEstadoCorridaMetodizado.ACTIVO

                    If intCodCorridaMetodizado > 0 Then
                        obeCorridaMetodizado.Flag = 2
                    Else
                        obeCorridaMetodizado.Flag = 2
                    End If

                    Dim obrCorridaMetodizado As New BusinessRules.CorridaMetodizado

                    Dim bolRC As Boolean
                    If intCodCorridaMetodizado = 0 Then
                        obeCorridaMetodizado.CodCorrida = fRetornaCodCorridaMetodizado(intCodMetodizado, arrCodPeriodo)
                    End If
                    If obeCorridaMetodizado.CodCorrida = 0 Then
                        bolRC = obrCorridaMetodizado.agregar(obeCorridaMetodizado)
                    Else
                        bolRC = obrCorridaMetodizado.modificar(obeCorridaMetodizado)
                    End If

                    If bolRC Then
                        ocbRpt = New CBRpt
                        ocbRpt.Mensaje.CodError = 0
                        ocbRpt.Mensaje.Descripcion = ccALERTA_EXITO_GRABAR_RECONCILIACION
                        ocbRpt.CodUsuario = strCodUsuario 'obeCorridaMetodizado.CodUsuarioReg
                        ocbRpt.NombreUsuario = String.Empty
                        Dim obeGeneral As BusinessEntity.General = Nothing ' buscarGeneralItem(ecTablaGeneral.ESTADO_METODIZADO, obeMetodizado.Estado)
                        If Not obeCorridaMetodizado Is Nothing Then
                            ocbRpt.CodCorridaMetodizado = obeCorridaMetodizado.CodCorrida
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