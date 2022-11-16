'*************************************************************
'Proposito: Entidad base para todas las entidades de negocio
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Xml.Serialization
Imports System.Collections

Namespace CEF.BusinessEntity

    <Serializable()> _
    Public Class EntityBase

        Protected Sub New()
            MyBase.New()
        End Sub

        Public Function PasarAXml() As String
            Dim sbXml As System.Text.StringBuilder = Nothing
            Try
                Dim xsParse As XmlSerializer = New XmlSerializer(Me.GetType(), New XmlRootAttribute(Me.GetType().ToString()))
                sbXml = New System.Text.StringBuilder
                Dim swDoc As System.IO.StringWriter = New System.IO.StringWriter(sbXml)
                xsParse.Serialize(swDoc, Me)
                sbXml.Replace("utf-16", "iso-8859-1")
                Return (sbXml.ToString())
            Catch ex As Exception
                Throw
                Return (String.Empty)
            End Try
        End Function

    End Class

End Namespace