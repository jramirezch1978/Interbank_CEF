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

    Partial Class Login2
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
                Dim strEx As String
                strUsuario = Request.Params("strUsuario")
                intPerfil = Int32.Parse(Request.Params("intPerfil"))

                If (strUsuario = String.Empty) Then
                    Logger.Error(MethodInfo.GetCurrentMethod, New Exception("Parametros proporcionados por SDA estan vacio"), "")
                    cargarPaginaError()
                Else
                    Try
                        Dim obeUsuario As BusinessEntity.Usuario
                        Dim obrUsuario As BusinessRules.Usuario = New BusinessRules.Usuario

                        obeUsuario = obrUsuario.leer(strUsuario)

                        If Not obeUsuario Is Nothing Then
                            strUsuarioName = obeUsuario.Nombre
                            Dim objDatosGlobal As DatosGlobal = Me.datosGlobal
                            objDatosGlobal.sSd = strSd
                            objDatosGlobal.sUser = strUsuario
                            objDatosGlobal.sUserName = strUsuarioName
                            objDatosGlobal.nPerfil = intPerfil
                            objDatosGlobal.sAcceso = strAcceso
                            objDatosGlobal.sAmbiente = strAmbiente
                            objDatosGlobal.sAmbienteDes = strAmbienteDes
                            objDatosGlobal.sDbServer = strDbServer
                            objDatosGlobal.sDbName = strDbName
                            Me.datosGlobal = objDatosGlobal
                            intRes = 0


                            'SRT_2017-02160 SETEAR VARIABLES EN SESION
                            '---------------------------------------------------------
                            setearVariableSesion(ConstantesWebUI.strConstSesionUsuario, strUsuario)
                            setearVariableSesion(ConstantesWebUI.strConstSesionPerfil, intPerfil)
                            setearVariableSesion(ConstantesWebUI.strConstSesionAcceso, strAcceso)
                            setearVariableSesion(ConstantesWebUI.strConstSesionAmbiente, strAmbiente)
                            setearVariableSesion(ConstantesWebUI.strConstSesionAmbienteDes, strAmbienteDes)
                            setearVariableSesion(ConstantesWebUI.strConstSesionDbServer, strDbServer)
                            setearVariableSesion(ConstantesWebUI.strConstSesionDbName, strDbName)

                            'SETEAR VARIABLES DE BD IBCEF
                            setearVariableSesion(ConstantesWebUI.strConstSesionNombreUsuario, obeUsuario.Nombre)
                            Dim strPerfil As String
                            strPerfil = fRetornaDescPerfilUsuario()
                            setearVariableSesion(ConstantesWebUI.strConstSesionNombrePerfil, strPerfil)
                            '---------------------------------------------------------

                        End If

                        
                    Catch ex As Exception
                        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                        cargarPaginaError()
                    End Try
                End If
                If intRes = 0 Then
                    cargarPaginaPortal()
                End If
            End If
        End Sub

    End Class

End Namespace