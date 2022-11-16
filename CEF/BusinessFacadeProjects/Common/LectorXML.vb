Imports System
Imports System.Xml

Namespace CEF.Common
    Public NotInheritable Class lectorXML
        Implements IDisposable

#Region "Propiedades"

#Region "Públicas"

#End Region

#Region "Privadas"

        Private _rutaArchivoXML As String
        Private _xdArch As XmlDocument
        Private _xtrArch As XmlTextReader
        Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

#End Region

#End Region

#Region "Métodos"

#Region "Constructor(es)"

        Sub New(ByVal pRutaArchivoXML As String)
            _rutaArchivoXML = pRutaArchivoXML
            abrir()
        End Sub

#End Region

#Region "Destructor"

        Protected Overrides Sub Finalize()
            cerrar()
            MyBase.Finalize()
        End Sub

#End Region

#Region "Públicos"

        Private Sub abrir()
            _xtrArch = New XmlTextReader(Me._rutaArchivoXML)
            _xtrArch.WhitespaceHandling = WhitespaceHandling.None
            _xdArch = New XmlDocument
            _xdArch.Load(Me._rutaArchivoXML)
            disposedValue = False
        End Sub

        Private Sub cerrar()
            If Not _xtrArch Is Nothing Then
                _xtrArch.Close()
            End If
        End Sub

        Public Function leerValor(ByVal pstrSeccion As String, ByVal pstrClave As String) As String
            Return (leerValor(pstrSeccion, pstrClave, String.Empty))
        End Function

        Public Function leerValor(ByVal pstrSeccion As String, ByVal pstrClave As String, ByVal pstrPredeterminado As String) As String
            Return (leerValorXML(pstrSeccion, pstrClave, pstrPredeterminado))
        End Function

        Private Function leerValorXML(ByVal pstrSeccion As String, ByVal pstrClave As String, ByVal pstrPredeterminado As String) As String
            Dim xnValor As XmlNode
            xnValor = _xdArch.SelectSingleNode(pstrSeccion & "/add[@key=""" & pstrClave & """]")
            If Not xnValor Is Nothing Then
                Return xnValor.Attributes("value").InnerText
            Else
                Return pstrPredeterminado
            End If
        End Function

        ' IDisposable
        Protected Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    cerrar()
                End If
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#End Region

#Region "Privados"

#End Region

#End Region

    End Class
End Namespace
