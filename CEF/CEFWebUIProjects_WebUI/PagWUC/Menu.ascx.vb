'===============================================================================
'Proposito: Control de Usuario Menu Dinamico
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 01/09/2005
'Modificado por:
'Fecha Mod:
'===============================================================================

Imports System.Text
Imports CEF.Common.Globals
Imports CEF.BusinessRules

Namespace CEF.WebIU

    Partial Class Menu
        Inherits System.Web.UI.UserControl

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

        Protected lintCodMenu As Integer
        Protected lintCodPerfil As Integer
        Protected lstrUsuario As String

        Private Const ccKEY_DATOS_GLOBAL As String = "Cache:DatosGlobal"

        Private _IDIframe As String = "ifrmDetalle"
        Public Property IDIframe() As String
            Get
                Return Trim(_IDIframe)
            End Get
            Set(ByVal Value As String)
                _IDIframe = Value
            End Set
        End Property

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
            End If
        End Sub

        Private Property Usuario() As String
            Get
                Return (lstrUsuario)
            End Get
            Set(ByVal Value As String)
                lstrUsuario = Value
            End Set
        End Property

        Private Property CodPerfil() As Integer
            Get
                Return (lintCodPerfil)
            End Get
            Set(ByVal Value As Integer)
                lintCodPerfil = Value
            End Set
        End Property

        Private Property CodMenu() As Integer
            Get
                Return (lintCodMenu)
            End Get
            Set(ByVal Value As Integer)
                lintCodMenu = Value
            End Set
        End Property

        Protected Property datosGlobal() As Common.DatosGlobal
            Get
                If Session.Item(ccKEY_DATOS_GLOBAL) Is Nothing Then
                    Return (New Common.DatosGlobal)
                Else
                    Return (CType(Session.Item(ccKEY_DATOS_GLOBAL), Common.DatosGlobal))
                End If
            End Get
            Set(ByVal Value As Common.DatosGlobal)
                If Value Is Nothing Then
                    Session.Remove(ccKEY_DATOS_GLOBAL)
                Else
                    Session.Item(ccKEY_DATOS_GLOBAL) = Value
                End If
            End Set
        End Property

        Public Sub cargaDatos()
            Dim obrPerfilUsuario As BusinessRules.Acceso
            Try
                obrPerfilUsuario = New BusinessRules.Acceso
                Me.CodPerfil = Int32.Parse(datosGlobal.nPerfil) 'CAMBIAR POR VARIABLE SESION
                Dim dsAcceso As DataSet = obrPerfilUsuario.leer(Me.CodPerfil)
                Me.CodMenu = dsAcceso.Tables(0).Rows(0)("CodMenu")
                Response.Write(cargaMenuDinamico(Me.CodMenu))
            Finally
                obrPerfilUsuario = Nothing
            End Try
        End Sub

        Private Function buscarOpcionHijos(ByVal pintCodMenu As Integer, ByVal pintCodOpcion As Integer) As DataTable
            Dim obrMenu As BusinessRules.MenuDinamico = New BusinessRules.MenuDinamico
            Return (obrMenu.buscarOpcionHijos(pintCodMenu, pintCodOpcion).Tables(0).Copy())
        End Function

        Private Function buscarOpcionInicio(ByVal pintCodMenu As Integer) As DataTable
            Dim obrMenu As BusinessRules.MenuDinamico = New BusinessRules.MenuDinamico
            Return (obrMenu.buscarOpcionInicio(pintCodMenu).Tables(0).Copy())
        End Function

        Private Function cargaMenuBar(ByVal pintCodMenu As Integer, ByVal pvDTHijos As DataTable, ByVal pnNivel As Integer) As String
            Dim voCadenaMenuBar As String = String.Empty
            Dim voClassMenu As String

            For Each voRow As DataRow In pvDTHijos.Rows
                If (voRow("Tipo").ToString() = "M") Then
                    voClassMenu = "root"
                    If (pnNivel > 0) Then
                        voClassMenu = "break"
                        voCadenaMenuBar += "<tr>" + Environment.NewLine
                    End If
                    voCadenaMenuBar += "<td class='" + voClassMenu + "'>" + voRow("Descripcion") + Environment.NewLine
                    voCadenaMenuBar += "<table CELLSPACING=1 CELLPADDING=0 TITLE=''>" + Environment.NewLine
                Else
                    Dim strUrl As String = voRow("Url")
                    'strUrl += IIf(strUrl.EndsWith("?"), "&", "?") + "intPerfil=" + Me.CodPerfil.ToString()
                    voCadenaMenuBar += "<tr OnClick=" + "myRedirect('" + strUrl + "');" + ">" + Environment.NewLine
                    voCadenaMenuBar += "<td NOWRAP TITLE='" + voRow("Descripcion") + "'>" + voRow("Descripcion") + "</td>" + Environment.NewLine
                    voCadenaMenuBar += "</tr>" + Environment.NewLine
                End If

                If (voRow("Tipo").ToString() = "M") Then
                    Dim voDataTable As DataTable = buscarOpcionHijos(pintCodMenu, Convert.ToInt32(voRow("CodOpcion")))
                    voCadenaMenuBar += cargaMenuBar(pintCodMenu, voDataTable, pnNivel + 1)
                    If (voRow("Tipo").ToString() = "M") Then
                        voCadenaMenuBar += "</table>" + Environment.NewLine
                        voCadenaMenuBar += "</td>" + Environment.NewLine
                        If (pnNivel > 0) Then
                            voCadenaMenuBar += "</tr>" + Environment.NewLine
                        End If
                    End If
                End If
            Next

            Return (voCadenaMenuBar)
        End Function

        Private Function cargaMenuDinamico(ByVal pintCodMenu As Integer) As String
            Dim sbCadenaMenuBar As StringBuilder = New StringBuilder
            Dim voDataTable As DataTable = buscarOpcionInicio(pintCodMenu)
            If (voDataTable.Rows.Count > 0) Then
                sbCadenaMenuBar.Append("<!-- Menu Dinamico Luis A. Mascaro Jácome-->")
                sbCadenaMenuBar.Append(Environment.NewLine)
                sbCadenaMenuBar.Append("<table border=0 ID='menuBar' OnSelectBar='return false' ")
                sbCadenaMenuBar.Append("onClick='processClick()' OnMouseOver='doHighlight(event.toElement)' ")
                sbCadenaMenuBar.Append("onMouseOut='doCheckOut()' OnKeyDown='processKey()'> ")
                sbCadenaMenuBar.Append(Environment.NewLine)
                sbCadenaMenuBar.Append("<tr>")
                sbCadenaMenuBar.Append(Environment.NewLine)
                sbCadenaMenuBar.Append(cargaMenuBar(pintCodMenu, voDataTable, 0))
                sbCadenaMenuBar.Append("</tr>")
                sbCadenaMenuBar.Append(Environment.NewLine)
                sbCadenaMenuBar.Append("</table>")
                sbCadenaMenuBar.Append(Environment.NewLine)
            End If
            Return (sbCadenaMenuBar.ToString())
        End Function

    End Class

End Namespace