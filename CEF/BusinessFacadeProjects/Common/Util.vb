'*************************************************************
'Proposito: 
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports Microsoft.VisualBasic.Strings


Namespace CEF.Common

    Public Class Util

        Sub New()
            MyBase.New()
        End Sub

        ' MEJORAS CEF FASE 2
        Public Shared Function FormatoCodigoUnico(ByVal cadena As String, Optional ByVal longitud As Integer = 10) As String
            cadena = ConvertFormat.CheckInteger(cadena).ToString().Trim()

            Dim l As Integer = cadena.Length

            If l > longitud Then cadena = cadena.Substring(l - longitud, longitud)

            Return cadena.PadLeft(longitud, "0")
        End Function


    End Class

    Public Class Assemblys

#Region "Secciones del Archivo de Configuración"

        Private Const strSeccionCadenaConexion As String = "Configuracion/CadenaConexion"
        Private Const strSeccionRuta As String = "Configuracion/Ruta"

#Region "Llaves"

#Region "Sección: Configuracion/CadenaConexion"
        Private Const strLlaveIBCef As String = "IBCef"
        Private Const strLlaveIBRnt As String = "IBRnt"
        Private Const strLlaveMonitorE As String = "MonitorE"
#End Region

#Region "Sección: Configuracion/Ruta"
        Private Const strLlaveLog As String = "Log"
#End Region

#End Region

#End Region

        Public Shared Function leerUbicacion(ByVal pstrArchivo As String) As String
            Return (retornaRutaLog(pstrArchivo))
        End Function

        'Public Shared Function leerUbicacionConfig_(ByVal pstrArchivo As String) As String
        '    Dim strRuta As String = System.IO.Path.GetDirectoryName(pstrArchivo) & "\" & "__AssemblyInfo__.ini"
        '    strRuta = Ini.leerValor(strRuta, "[AssemblyInfo]", "URL")
        '    strRuta = strRuta.Replace("file:///", String.Empty)
        '    strRuta = strRuta.Replace("/", "\")
        '    strRuta = System.IO.Path.GetDirectoryName(strRuta).Replace("\bin", "") & "\"
        '    strRuta = System.IO.Path.GetDirectoryName(strRuta) & "\" & "Dependencias" & "\"
        '    Return (strRuta)
        'End Function

        Public Shared Function leerUbicacionConfig_(ByVal pstrArchivo As String) As String
            Dim strRuta As String = System.IO.Path.GetDirectoryName(pstrArchivo) & "\" & "__AssemblyInfo__.ini"
            strRuta = Ini.leerValor(strRuta, "[AssemblyInfo]", "URL")
            strRuta = strRuta.Replace("file:///", String.Empty)
            strRuta = strRuta.Replace("/", "\")
            strRuta = System.IO.Path.GetDirectoryName(strRuta).Replace("\bin", "") & "\"
            Return (strRuta)
        End Function

        '<Obsolete("Utilizar la funcion leerUbicacionConfig_")> _
        Public Shared Function leerUbicacionBin(ByVal pstrArchivo As String) As String
            Dim strRuta As String = System.IO.Path.GetDirectoryName(pstrArchivo) & "\" & "__AssemblyInfo__.ini"
            strRuta = Ini.leerValor(strRuta, "[AssemblyInfo]", "URL")
            strRuta = strRuta.Replace("file:///", String.Empty)
            strRuta = strRuta.Replace("/", "\")
            strRuta = System.IO.Path.GetDirectoryName(strRuta) & "\"
            Return (strRuta)
        End Function

        Public Shared Function retornaRutaLog(ByVal pstrArchivo As String) As String
            Dim strRpta As String = String.Empty
            Dim strRuta As String = leerUbicacionConfig_(pstrArchivo)
            Dim strRutaConfig As String = strRuta + Globals.ccArchivoDataConfig

            Dim oLectorXML As New lectorXML(strRutaConfig)
            strRpta = oLectorXML.leerValor(strSeccionCadenaConexion, strLlaveLog)

            Return strRpta
        End Function


        'Public Shared Function retornaRutaLog(ByVal pstrArchivo As String) As String
        '    Dim strRutaConfig As String = System.Configuration.ConfigurationSettings.AppSettings("RUTA_LOG_ERROR")
        '    Return strRutaConfig
        'End Function


        ' SRT_2017 LRamosG 
        Public Shared Function leerUbicacionConfig(ByVal pstrArchivo As String) As String
            Dim asm As [Assembly] = [Assembly].GetExecutingAssembly
            Dim strRuta As String = System.IO.Path.GetDirectoryName(asm.CodeBase) & "\" & pstrArchivo
            strRuta = Replace(strRuta, "file:\", "")
            strRuta = Replace(strRuta, "/", "\")
            'strRuta = Ini.leerValor(strRuta, "[AssemblyInfo]", "URL")
            'strRuta = strRuta.Replace("file:///", String.Empty)
            'strRuta = strRuta.Replace("/", "\")
            'strRuta = System.IO.Path.GetDirectoryName(strRuta).Replace("\bin", "") & "\"
            Return (strRuta)
        End Function

        'SRT MEJORAS CEF FASE 2
        Public Shared Function retornaDatoConfig(ByVal strKey As String) As String
            Dim oLectorXML As lectorXML
            Dim strRpta As String = String.Empty
            Dim asm As [Assembly] = [Assembly].GetExecutingAssembly
            Dim strRutaConfig As String = System.IO.Path.GetDirectoryName(asm.CodeBase) + "\" + constantesCommon.archivoConfiguracion

            strRutaConfig = Replace(strRutaConfig, "file:\", "")
            strRutaConfig = Replace(strRutaConfig, "/", "\")

            oLectorXML = New lectorXML(strRutaConfig)
            strRpta = oLectorXML.leerValor(constantesCommon.seccionAssemblySettings, strKey)

            Return strRpta
        End Function

    End Class


End Namespace