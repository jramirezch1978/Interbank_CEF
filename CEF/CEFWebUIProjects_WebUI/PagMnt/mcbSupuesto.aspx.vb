Imports System.Xml.Serialization
Imports System.IO
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection


Namespace CEF.WebUI

    Partial Class mcbSupuesto
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
            Private lMensaje As New CBMensaje

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
        End Class

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            agregarSupuesto()
        End Sub

        Private Sub agregarSupuesto()
            Dim ocbRpt As CBRpt
            Dim nvcData As System.Collections.Specialized.NameValueCollection
            nvcData = Request.ServerVariables

            'Dim x As StreamWriter = New StreamWriter("c:\Prueba.txt", True)
            Try
                Dim intCodSupuesto As Integer = Int32.Parse(nvcData("HTTP_intCodSupuesto"))
                Dim dteFecPeriodo As DateTime = DateTime.Parse(nvcData("HTTP_dteFecPeriodo"))
                Dim bytNumeroProyectado As Byte = Byte.Parse(nvcData("HTTP_bytNumeroProyectado"))
                Dim strImporteSupuesto As String = nvcData("HTTP_strImporteSupuesto")

                'x.WriteLine(intCodSupuesto)
                'x.WriteLine(dteFecPeriodo)
                'x.WriteLine(bytNumeroProyectado)
                'x.WriteLine(strImporteSupuesto)
                'x.Close()

                Dim obeSupuesto As BusinessEntity.Supuesto = New BusinessEntity.Supuesto
                obeSupuesto.CodSupuesto = intCodSupuesto

                For intIndice As Integer = 1 To (bytNumeroProyectado + 1)
                    Dim obePeriodoProyectado As BusinessEntity.PeriodoProyectado = New BusinessEntity.PeriodoProyectado
                    obePeriodoProyectado.CodSupuesto = intCodSupuesto
                    obePeriodoProyectado.CodProyectado = intIndice
                    If intIndice = 1 Then
                        obePeriodoProyectado.Tipo = Byte.Parse(ecTipoPeriodoProyectado.HISTORICO)
                    Else
                        obePeriodoProyectado.Tipo = Byte.Parse(ecTipoPeriodoProyectado.PROYECTADO)
                    End If
                    obePeriodoProyectado.FecProyectado = dteFecPeriodo.AddYears(intIndice - 1)
                    obeSupuesto.PeriodosProyectados.Add(obePeriodoProyectado)
                Next

                If strImporteSupuesto.EndsWith("|") Then strImporteSupuesto = strImporteSupuesto.Substring(0, strImporteSupuesto.Length - 1)
                If strImporteSupuesto <> String.Empty Then
                    Dim arrPeriodoCuenta As String() = strImporteSupuesto.Split("|")
                    For Each strPeriodoCuenta As String In arrPeriodoCuenta
                        Dim arrValor As String() = strPeriodoCuenta.Split(";")
                        Dim intCodProyectado As Integer = CType(arrValor(0), Byte)
                        Dim intCodCuentaSupuesto As Integer = CType(arrValor(1), Integer)
                        Dim strFuncion As String = CType(arrValor(3), String)
                        If IsNumeric(arrValor(2)) Then
                            Dim decImporte As Decimal = CType(arrValor(2), Decimal)
                            Dim obeSupuestoProyectado As BusinessEntity.SupuestoProyectado = New BusinessEntity.SupuestoProyectado
                            obeSupuestoProyectado.CodSupuesto = intCodSupuesto
                            obeSupuestoProyectado.CodProyectado = intCodProyectado
                            obeSupuestoProyectado.CodCuentaSupuesto = intCodCuentaSupuesto
                            obeSupuestoProyectado.Importe = decImporte
                            obeSupuestoProyectado.Funcion = strFuncion
                            obeSupuesto.PeriodosProyectados.buscarPorClave(intCodSupuesto, intCodProyectado).SupuestosProyectados.Add(obeSupuestoProyectado)
                        End If
                    Next
                End If

                Dim obrSupuesto As BusinessRules.Supuesto = New BusinessRules.Supuesto

                Dim bolRC As Boolean = obrSupuesto.agregarSupuestoProyectado(obeSupuesto)
                If bolRC Then
                    ocbRpt = New CBRpt
                    ocbRpt.Mensaje.CodError = 0
                    ocbRpt.Mensaje.Descripcion = ccALERTA_EXITO_AGREGAR
                Else
                    ocbRpt = New CBRpt
                    ocbRpt.Mensaje.CodError = 1
                    ocbRpt.Mensaje.Descripcion = ccALERTA_ERROR_AGREGAR
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                ocbRpt = New CBRpt
                ocbRpt.Mensaje.CodError = 1
                ocbRpt.Mensaje.Descripcion = ccALERTA_ERROR_AGREGAR
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