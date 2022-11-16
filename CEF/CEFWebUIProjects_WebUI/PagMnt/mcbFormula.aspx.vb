Imports System.Xml.Serialization
Imports System.IO
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection

Namespace CEF.WebUI
    Partial Public Class mcbFormula
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

        Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            grabarFormula()
        End Sub

        Private Sub grabarFormula()

            Dim strCodUsuario As String = retornaUsuarioSesion()
            Dim ocbRpt As CBRpt
            Dim nvcData As System.Collections.Specialized.NameValueCollection
            nvcData = Request.ServerVariables

            Try
                Dim strVariableFormulas As String = nvcData("HTTP_strVariableFormulas")
                Dim intCodMetodizado As String = nvcData("HTTP_intCodMetodizado")
                Dim strDescripcion As String = nvcData("HTTP_strDescripcion")
                Dim intEstado As String = nvcData("HTTP_intEstado")
                Dim intCondicion As String = nvcData("HTTP_intcondicion")
                Dim intCodCovenant As String = nvcData("HTTP_intCodCovenant")
                Dim strComentario As String = Trim(Request.ServerVariables("HTTP_strComentario"))
                Dim intCodNoContractual As Integer = nvcData("HTTP_intNoContractual")
                Dim intAccion As String = nvcData("HTTP_intAccion")

                Dim objVariableFormulaLst As Object = New Script.Serialization.JavaScriptSerializer().Deserialize(Of Object)(strVariableFormulas)

                Dim odaFormulaCovenant As New BusinessRules.FormulaCovenant
                Dim obeFomulaCovenant As New BusinessEntity.Formula

                Dim odaVariabeFormula As New BusinessRules.VariableFormula


                Dim strDescripcionEncode As String
                Dim bytes As Byte() = System.Text.Encoding.Default.GetBytes(strDescripcion)
                strDescripcionEncode = System.Text.Encoding.UTF8.GetString(bytes)

                Dim strComentarioEncode As String
                Dim strComentarioDecode As Byte() = System.Text.Encoding.Default.GetBytes(strComentario)
                strComentarioEncode = System.Text.Encoding.UTF8.GetString(strComentarioDecode)

                obeFomulaCovenant.CodMetodizado = Integer.Parse(intCodMetodizado)
                obeFomulaCovenant.Descripcion = strDescripcionEncode
                obeFomulaCovenant.Estado = Integer.Parse(intEstado)
                obeFomulaCovenant.Condicion = Integer.Parse(intCondicion)
                obeFomulaCovenant.Comentario = strComentarioEncode
                obeFomulaCovenant.CodNoContractual = intCodNoContractual
                obeFomulaCovenant.CodUsuario = strCodUsuario

                Dim intCodFormula As Integer = 0

                If intAccion = Integer.Parse(ecMntPage.AGREGAR).ToString Then
                    intCodFormula = (odaFormulaCovenant.agregar(obeFomulaCovenant, 1))
                Else
                    obeFomulaCovenant.CodFormula = intCodCovenant
                    intCodFormula = intCodCovenant
                    odaFormulaCovenant.modificar(obeFomulaCovenant)
                    odaVariabeFormula.modificar_eliminar(intCodFormula)

                End If

                Dim intOrden As Integer = 1

                For Each objVariableFormula As Object In objVariableFormulaLst

                    Dim obeVariableFormula As New BusinessEntity.VariableFormula
                    obeVariableFormula.CodFormula = intCodFormula
                    Dim CodCuenta As Integer = 0
                    If objVariableFormula("CodCuenta").ToString() <> "" Then
                        CodCuenta = Integer.Parse(objVariableFormula("CodCuenta").ToString())
                    End If
                    obeVariableFormula.CodCuenta = CodCuenta

                    Dim strDescripcionFormulaEncode As String
                    Dim bytesFormula As Byte() = System.Text.Encoding.Default.GetBytes(objVariableFormula("Descripcion").ToString())
                    strDescripcionFormulaEncode = System.Text.Encoding.UTF8.GetString(bytesFormula)

                    obeVariableFormula.Descripcion = strDescripcionFormulaEncode
                    Dim Valor As Decimal = 0
                    If objVariableFormula("Valor").ToString() <> "" Then
                        Valor = Decimal.Parse(objVariableFormula("Valor").ToString())
                    End If
                    obeVariableFormula.Valor = Valor
                    obeVariableFormula.Orden = intOrden
                    obeVariableFormula.CodUsuario = strCodUsuario

                    Dim bolRC As Boolean = odaVariabeFormula.agregar(obeVariableFormula, 1)
                    intOrden += 1
                Next

                Response.Write(CStr(intCodCovenant))
               
                'MsgBox("Fórmula Registrada")
                'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", "windows.close()", True)


            Catch ex As Exception

            End Try

        End Sub

    End Class
End Namespace