'*************************************************************
'Proposito: Definicion de valores globales del DataAccess
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System

Namespace CEF.DataAccess

    Public NotInheritable Class Globals

        Public Const ccRegistroClaveWinCEF As String = "SOFTWARE\\CEF"
        Public Const ccCadenaConexionCEF As String = "CadenaConexionCEF"
        Public Const ccCadenaConexionMON As String = "CadenaConexionMON"
        Public Const ccCadenaConexionRNT As String = "CadenaConexionRNT"
        Public Const ccCadenaConexionROC As String = "CadenaConexionROC"

        ' Se ha colocado este dato en el Namespace Common por tratarse de información que se comparte entre las distintas capas...
        ' Public Const ccArchivoDataConfig As String = "cefDataConfig.xml"
        Public Shared ReadOnly Property ccArchivoDataConfig() As String
            Get
                'Return CEF.Common.Globals.ccArchivoDataConfig
                Return constantesCommon.archivoConfiguracion   ' SRT_2017-02160 LRamosG 
            End Get
        End Property


        'Public Const ccDataConfig_SeccionCadenaConexion As String = "Configuracion/CadenaConexion"
        Public Const ccDataConfig_SeccionCadenaConexion As String = "configuration/CadenaConexion" 'SRT_2017-02160 LRamosG 12/05/2017
        Public Const ccDataConfig_ClaveCEF As String = "IBCef"
        Public Const ccDataConfig_ClaveMON As String = "MonitorE"
        Public Const ccDataConfig_ClaveRNT As String = "IBRnt"
        Public Const ccDataConfig_ClaveROC As String = "IBRoc"

    End Class

End Namespace