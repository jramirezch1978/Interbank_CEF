Partial Class LoginDoor
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents rfvUsuario As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvPerfil As System.Web.UI.WebControls.RequiredFieldValidator
    Protected WithEvents rfvPassword As RequiredFieldValidator

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        Dim usuario As String = txtUsuario.Text.Trim().ToUpper()
        Dim perfil As String = ddlPerfil.SelectedValue()
        Dim password As String = txtPassword.Text.Trim().ToUpper()

        If usuario <> "" And perfil <> "" And password = "@CEF" Then Response.Redirect("Login2.aspx?strUsuario=" & usuario & "&intPerfil=" & perfil)
    End Sub
End Class
