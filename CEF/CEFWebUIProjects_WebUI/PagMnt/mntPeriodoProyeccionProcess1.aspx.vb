Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Reflection


Namespace CEF.WebUI


Partial Class mntPeriodoProyeccionProcess1
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

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Response.Write(VerificarFechaProy())
            Response.Flush()
            Response.End()
        End Sub

        Public Function VerificarFechaProy() As String
            Dim Check As Integer = 0
            Try


                Dim mes As Integer
                Dim anio As Integer
                Dim codmetodizado As Integer
                Dim rpta As Boolean
                Dim gg As String

                If (Not Request.Params("HTTP_mes").ToString() Is Nothing) Then
                    mes = Integer.Parse(Request.Params("HTTP_mes").ToString()) + 1
                    Check = 1
                End If
                If (Not Request.Params("HTTP_anio").ToString() Is Nothing) Then
                    anio = Integer.Parse(Request.Params("HTTP_anio").ToString())
                    Check = 1
                End If
                If (Not Request.Params("HTTP_codmetodizado").ToString() Is Nothing) Then
                    codmetodizado = Integer.Parse(Request.Params("HTTP_codmetodizado").ToString())
                    Check = 1
                End If

                Dim obrProyeccion As BusinessRules.ProyeccionBR = New BusinessRules.ProyeccionBR
                Check = 3
                rpta = obrProyeccion.VerificarFechaProyeccion(codmetodizado, New Date(anio, mes, 1))
                Check = 4

                gg = rpta.ToString()
                Return gg
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return "Falso " + Check.ToString() + ex.Message()
            End Try

        End Function

End Class
End Namespace