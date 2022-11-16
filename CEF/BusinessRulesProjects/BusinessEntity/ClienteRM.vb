Imports System.Reflection
Imports System.Collections.Generic
Imports System.Xml.Serialization
Imports System

Namespace CEF.BusinessEntity

    <CLSCompliant(True)> _
    <Serializable(), XmlRoot("EClienteRM")> _
    Public Class ClienteRM
        Inherits EntityBase

#Region " Atributos "

        Private _intCodigocliente As Integer
        Private _strCodigounico As String
        Private _intCodigotipodocumento As Integer
        Private _strNumerodocumento As String
        Private _strCodigoejecutivo As String
        Private _strNombreejecutivo As String
        Private _strRazonsocialcliente As String
        Private _strCiiu As String
        Private _strCodigogrupo As String
        Private _strNombregrupo As String
        
        Private _intCodError As Integer
        Private _strMsgError As String

#End Region

#Region " Propiedades "

        <XmlElement("Codigocliente")> _
        Public Property Codigocliente() As Integer
            Get
                Return Me._intCodigocliente
            End Get
            Set(ByVal value As Integer)
                Me._intCodigocliente = value
            End Set
        End Property

        <XmlElement("Codigounico")> _
        Public Property Codigounico() As String
            Get
                Return Me._strCodigounico
            End Get
            Set(ByVal value As String)
                Me._strCodigounico = value
            End Set
        End Property

        <XmlElement("Codigotipodocumento")> _
        Public Property Codigotipodocumento() As Integer
            Get
                Return Me._intCodigotipodocumento
            End Get
            Set(ByVal value As Integer)
                Me._intCodigotipodocumento = value
            End Set
        End Property

        <XmlElement("Numerodocumento")> _
        Public Property Numerodocumento() As String
            Get
                Return Me._strNumerodocumento
            End Get
            Set(ByVal value As String)
                Me._strNumerodocumento = value
            End Set
        End Property

        <XmlElement("Codigoejecutivo")> _
        Public Property Codigoejecutivo() As String
            Get
                Return Me._strCodigoejecutivo
            End Get
            Set(ByVal value As String)
                Me._strCodigoejecutivo = value
            End Set
        End Property

        <XmlElement("Nombreejecutivo")> _
        Public Property Nombreejecutivo() As String
            Get
                Return Me._strNombreejecutivo
            End Get
            Set(ByVal value As String)
                Me._strNombreejecutivo = value
            End Set
        End Property

        <XmlElement("Razonsocialcliente")> _
        Public Property Razonsocialcliente() As String
            Get
                Return Me._strRazonsocialcliente
            End Get
            Set(ByVal value As String)
                Me._strRazonsocialcliente = value
            End Set
        End Property

        <XmlElement("Ciiu")> _
        Public Property Ciiu() As String
            Get
                Return Me._strCiiu
            End Get
            Set(ByVal value As String)
                Me._strCiiu = value
            End Set
        End Property

        <XmlElement("Codigogrupo")> _
        Public Property Codigogrupo() As String
            Get
                Return Me._strCodigogrupo
            End Get
            Set(ByVal value As String)
                Me._strCodigogrupo = value
            End Set
        End Property

        <XmlElement("Nombregrupo")> _
        Public Property Nombregrupo() As String
            Get
                Return Me._strNombregrupo
            End Get
            Set(ByVal value As String)
                Me._strNombregrupo = value
            End Set
        End Property

        <XmlElement("MsgError")> _
        Public Property MsgError() As String
            Get
                Return Me._strMsgError
            End Get
            Set(ByVal value As String)
                Me._strMsgError = value
            End Set
        End Property

        <XmlElement("CodError")> _
        Public Property CodError() As Integer
            Get
                Return Me._intCodError
            End Get
            Set(ByVal value As Integer)
                Me._intCodError = value
            End Set
        End Property


#End Region

    End Class

End Namespace