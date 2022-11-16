Imports System
Imports System.Text
Imports System.IO
Imports System.Xml

Imports Microsoft.VisualBasic

Namespace CEF.Common
    Public Class ConvertFormat

        Public Shared Function EsVacioONull(ByVal value As Object) As Boolean
            If value Is Nothing Then Return True

            If IsDBNull(value) Then Return True

            If value.ToString().Trim() = "" Then Return True

            Return False
        End Function

        Public Shared Function CheckString(ByVal value As Object) As String
            If ConvertFormat.EsVacioONull(value) Then Return ""

            Return value.ToString()
        End Function



        Public Shared Function Boolean_To_Integer(ByVal value As Boolean) As Integer
            If value Then Return 1

            Return 0
        End Function


        Public Shared Function ReplaceBadCharacter_XML(ByVal xml As String)
            xml = xml.Replace("&amp;", "&")

            Return xml
        End Function


        'Public Shared Function Parameters_To_XML(ByVal parametros As Dictionary(Of String, Object)) As String
        '    Dim datos As DataTable = ConvertFormat.Parameters_To_DataTable(parametros)

        '    Return ConvertFormat.DataTable_To_XML(datos)
        'End Function

        ' MEJORAS CEF FASE 2
        Public Shared Function CheckInteger(ByVal value As Object) As Integer
            If ConvertFormat.EsVacioONull(value) Then Return 0

            Return Convert.ToInt32(value)
        End Function

        Public Shared Function CheckDecimal(ByVal value As Object) As Decimal
            If ConvertFormat.EsVacioONull(value) Then Return 0

            Return Convert.ToDecimal(value)
        End Function

    End Class
End Namespace

