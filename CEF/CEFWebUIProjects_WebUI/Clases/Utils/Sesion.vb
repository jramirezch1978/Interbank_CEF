Public Class Sesion
    ''' <summary>
    ''' CodigoUsuario
    ''' </summary>    
    ''' <remarks></remarks>
    Public Shared Property CodigoUsuario() As String
        Get
            If String.IsNullOrEmpty(HttpContext.Current.Session(constantesWebUI.strConstSesionUsuario)) Then Return ""

            Return CType(HttpContext.Current.Session(constantesWebUI.strConstSesionUsuario), String)
        End Get
        Set(ByVal Value As String)
            If Value Is Nothing Then
                HttpContext.Current.Session.Remove(constantesWebUI.strConstSesionUsuario)
            Else
                HttpContext.Current.Session(constantesWebUI.strConstSesionUsuario) = Value
            End If
        End Set
    End Property

    ''' <summary>
    ''' PerfilUsuario
    ''' </summary>    
    ''' <remarks></remarks>
    Public Shared Property PerfilUsuario() As String
        Get
            If String.IsNullOrEmpty(HttpContext.Current.Session(constantesWebUI.strConstSesionPerfil)) Then Return ""

            Return CType(HttpContext.Current.Session(constantesWebUI.strConstSesionPerfil), String)
        End Get
        Set(ByVal Value As String)
            If Value Is Nothing Then
                HttpContext.Current.Session.Remove(constantesWebUI.strConstSesionPerfil)
            Else
                HttpContext.Current.Session(constantesWebUI.strConstSesionPerfil) = Value
            End If
        End Set
    End Property

End Class
