'--------------------------------------------------------------------
'Proposito: Obtener los perfiles del Usuario por SDA                
'Autor: Luis A. Mascaro Jácome                                      
'Fecha Creación: 28/12/2005                                         
'Modificado:                                                        
'Fecha Mod.:                                                        
'--------------------------------------------------------------------

Imports CEF.Common
Imports System.Reflection

Namespace CEF.WebUI

    Partial Class Login
        Inherits PageBase

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


        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                Dim strPath As String
                Dim strUser As String
                Dim strPin As String
                Dim strDbServer As String
                Dim strDbName As String
                Dim ospPin As Object
                Dim intRes As Integer = -1
                Dim strSd As String
                Dim strAmbiente As String
                Dim strAmbienteDes As String
                Dim strUsuario As String
                Dim strUsuarioName As String
                Dim intPerfil As Integer
                Dim strAcceso As String
                Dim strPeriodo As String
                Dim sPerfil As String

                '1. Lectura del Pin
                strUser = DirectCast(Request.QueryString("arg01"), String)
                strPin = DirectCast(Request.QueryString("arg02"), String)
                strDbServer = DirectCast(Request.QueryString("arg03"), String)
                strDbName = DirectCast(Request.QueryString("arg04"), String)
                sPerfil = DirectCast(Request.QueryString("arg05"), String)

                'strUser = DirectCast("XT9391", String)
                'strPin = DirectCast("00970116011200080009000000070007009801180112000100100013010001170113009801130119", String)
                'strDbServer = DirectCast("s64vp21\bdt", String)
                'strDbName = DirectCast("ibsda", String)
                'sPerfil = DirectCast("2", String)

                '2. Lectura de valores del Pin
                If (strUser = String.Empty) Or (strPin = String.Empty) Or (strDbServer = String.Empty) Or (strDbName = String.Empty) Then
                    Logger.Error(MethodInfo.GetCurrentMethod, New Exception("Parametros proporcionados por SDA estan vacio"), "")
                    cargarPaginaError()
                Else
                    Try
                        Logger.Info(MethodInfo.GetCurrentMethod, String.Format("Login SDA - Parametros: arg01: {0} | arg02: {1} | arg03: {2} | arg04: {3} | arg05: {4}", strUser, strPin, strDbServer, strDbName, sPerfil))

                        ospPin = Server.CreateObject("sdaPinPerfil.Pin")
                        ospPin.asigna_usuario(strUser)
                        ospPin.asigna_pin(strPin)
                        ospPin.asigna_perfil(sPerfil)
                        intRes = ospPin.pLeerPinAccesoPerfil(strDbServer, strDbName)
                        If intRes = 0 Then
                            strSd = ospPin.obtiene_sd
                            strAmbiente = ospPin.obtiene_ambiente
                            strAmbienteDes = ospPin.obtiene_ambientedes
                            strUsuario = ospPin.obtiene_usuario
                            strUsuarioName = ospPin.obtiene_usuarioname
                            intPerfil = Int32.Parse(ospPin.obtiene_perfil)
                            strAcceso = ospPin.obtiene_acceso
                            strDbServer = ospPin.obtiene_dbserver
                            strDbName = ospPin.obtiene_basedato

                            Dim objDatosGlobal As DatosGlobal = Me.datosGlobal
                            objDatosGlobal.sSd = strSd
                            objDatosGlobal.sUser = strUsuario
                            objDatosGlobal.sUserName = strUsuarioName
                            '----comentado por rquispe 28/04/2014, para que tome el perfil que se pasa por query string
                            ' objDatosGlobal.nPerfil = intPerfil
                            objDatosGlobal.nPerfil = sPerfil
                            objDatosGlobal.sAcceso = strAcceso
                            objDatosGlobal.sAmbiente = strAmbiente
                            objDatosGlobal.sAmbienteDes = strAmbienteDes
                            objDatosGlobal.sDbServer = strDbServer
                            objDatosGlobal.sDbName = strDbName
                            Me.datosGlobal = objDatosGlobal


                            'SRT_2017-02160 SETEAR VARIABLES EN SESION
                            '---------------------------------------------------------
                            setearVariableSesion(ConstantesWebUI.strConstSesionUsuario, strUsuario)
                            setearVariableSesion(ConstantesWebUI.strConstSesionPerfil, sPerfil)
                            setearVariableSesion(ConstantesWebUI.strConstSesionAcceso, strAcceso)
                            setearVariableSesion(ConstantesWebUI.strConstSesionAmbiente, strAmbiente)
                            setearVariableSesion(ConstantesWebUI.strConstSesionAmbienteDes, strAmbienteDes)
                            setearVariableSesion(ConstantesWebUI.strConstSesionDbServer, strDbServer)
                            setearVariableSesion(ConstantesWebUI.strConstSesionDbName, strDbName)

                            'SETEAR VARIABLES DE BD IBCEF
                            Dim strNombre As String
                            strNombre = fRetornaNombreUsuario()
                            setearVariableSesion(ConstantesWebUI.strConstSesionNombreUsuario, strNombre)
                            Dim strPerfil As String
                            strPerfil = fRetornaDescPerfilUsuario()
                            setearVariableSesion(ConstantesWebUI.strConstSesionNombrePerfil, strPerfil)
                            '---------------------------------------------------------

                        End If
                    Catch ex As Exception
                        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                        cargarPaginaError()
                    Finally
                        ospPin = Nothing
                    End Try
                    If intRes = 0 Then
                        cargarPaginaPortal()
                    End If
                End If
            End If
        End Sub

    End Class

End Namespace