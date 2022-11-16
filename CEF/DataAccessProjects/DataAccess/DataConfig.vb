'*************************************************************
'Proposito: Soporte de acceso a los registros claves de XML
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System
Imports System.Xml

Namespace CEF.DataAccess

    Public NotInheritable Class DataConfig

        Private strArchivoXML As String
        Private xdArch As XmlDocument
        Private xtrArch As XmlTextReader

        Sub New(ByVal pstrArchivoXML As String)
            Me.strArchivoXML = pstrArchivoXML
            abrir()
        End Sub

        Protected Overrides Sub Finalize()
            cerrar()
            MyBase.Finalize()
        End Sub

        Private Sub abrir()
            Dim strRpta As String = String.Empty
            'Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly

            'LRamosG 
            Dim strRutaConfig As String = Common.Assemblys.leerUbicacionConfig(Me.strArchivoXML)
            'Dim strRutaConfig As String = Common.Assemblys.leerUbicacionBin(System.Reflection.Assembly.GetExecutingAssembly.Location) + Me.strArchivoXML
            'Dim strRutaConfig As String = Common.Assemblys.leerUbicacionConfig_(System.Reflection.Assembly.GetExecutingAssembly.Location) + Me.strArchivoXML

            xtrArch = New XmlTextReader(strRutaConfig)
            xtrArch.WhitespaceHandling = WhitespaceHandling.None
            xdArch = New XmlDocument
            xdArch.Load(strRutaConfig)
        End Sub

        Private Sub cerrar()
            xtrArch.Close()
        End Sub

        Public Function leerValor(ByVal pstrSeccion As String, ByVal pstrClave As String) As String
            Return (leerValor(pstrSeccion, pstrClave, String.Empty))
        End Function

        Public Function leerValor(ByVal pstrSeccion As String, ByVal pstrClave As String, ByVal pstrPredeterminado As String) As String
            Return (leerValorXML(pstrSeccion, pstrClave, pstrPredeterminado))
        End Function

        Private Function leerValorXML(ByVal pstrSeccion As String, ByVal pstrClave As String, ByVal pstrPredeterminado As String) As String
            Dim xnValor As XmlNode
            xnValor = xdArch.SelectSingleNode(pstrSeccion & "/add[@key=""" & pstrClave & """]")
            If Not xnValor Is Nothing Then
                Return xnValor.Attributes("value").InnerText
            Else
                Return pstrPredeterminado
            End If
        End Function

    End Class

End Namespace