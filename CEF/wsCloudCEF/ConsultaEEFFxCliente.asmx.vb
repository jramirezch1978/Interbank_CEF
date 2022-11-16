

Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports CEF.Common

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
Namespace CEF.wsCloudCEF
    <System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
    <System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <ToolboxItem(False)> _
    Public Class ConsultaEEFFxCliente
        Inherits System.Web.Services.WebService

        <WebMethod()> _
        Public Function ConsultaEEFFxCliente(ByVal CodUnico As String, ByVal TipoDocumento As Integer, ByVal NumeroDocumento As String) As DataTable

            Dim dtCliente As DataTable
            'Dim dsCliente As New DataSet

            Try

                Dim Mensaje As String
                Mensaje = "233"

                Dim objCliente As BusinessRules.Cliente = New BusinessRules.Cliente

                dtCliente = objCliente.ConsultaEEFFxCliente(CodUnico, TipoDocumento, NumeroDocumento).Tables(0)

                Return dtCliente

            Catch ex As Exception
                Return Nothing
            End Try

        End Function

    End Class

End Namespace
