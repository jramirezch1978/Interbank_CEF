Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports System.Reflection
Imports Microsoft.VisualBasic

Imports CEF.DataAccess
Imports CEF.BusinessEntity
Imports CEF.Common

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class ServiceExternalLogic
        Inherits BLO
        Implements IServiceExternalLogic

        Sub New()
            MyBase.New()
        End Sub
#Region "wsRM"
        <AutoComplete(True)> _
        Public Function ClienteRMPorCodigoUnico(ByVal codigoUnico As String, ByVal serviceURL As String) As BusinessEntity.ClienteRM Implements IServiceExternalLogic.ClienteRMPorCodigoUnico
            Try
                Return Me._clienteRM("1", codigoUnico, "2", "0", serviceURL)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")

                Throw ex
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function ClienteRMPorDocumentoIdentidad(ByVal tipoDocumentoIdentidad As String, ByVal numeroDocumentoIdentidad As String, ByVal serviceURL As String) As BusinessEntity.ClienteRM Implements IServiceExternalLogic.ClienteRMPorDocumentoIdentidad
            Try
                Return Me._clienteRM("2", "0", tipoDocumentoIdentidad, numeroDocumentoIdentidad, serviceURL)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")

                Throw ex
            End Try
        End Function

        Private Function _clienteRM(ByVal tipoConsulta As String, ByVal codigoUnico As String, ByVal tipoDocumentoIdentidad As String, ByVal numeroDocumentoIdentidad As String, ByVal serviceURL As String) As ClienteRM
            Try
                codigoUnico = ConvertFormat.CheckString(codigoUnico).Trim().PadLeft(14, "0"c)

                tipoDocumentoIdentidad = ConvertFormat.CheckString(tipoDocumentoIdentidad).Trim()
                If String.IsNullOrEmpty(tipoDocumentoIdentidad) Then tipoDocumentoIdentidad = "2"

                numeroDocumentoIdentidad = ConvertFormat.CheckString(numeroDocumentoIdentidad).Trim().ToUpper()
                If String.IsNullOrEmpty(numeroDocumentoIdentidad) Then numeroDocumentoIdentidad = "0".PadLeft(11, "0"c)

                Using data As New ServiceExternalData()
                    Dim arrTrama As String() = data.fcdWS_bseFCDO002_fConsultarCliente(tipoConsulta, codigoUnico, tipoDocumentoIdentidad, numeroDocumentoIdentidad, "000", serviceURL).Split("|"c)

                    Dim c As New ClienteRM()

                    If arrTrama(0) = "2" Then 'DOCUMENTO NO EXISTE EN RM'
                        c.CodError = arrTrama(0)
                        c.MsgError = arrTrama(1).Trim() & ". "
                        Return c
                    End If

                    If arrTrama(0) <> "0" Then 'OTRO
                        c.CodError = 1
                        c.MsgError = arrTrama(1).Trim() & ". "
                        Logger.Error(MethodInfo.GetCurrentMethod, New Exception(c.MsgError), "")
                        Return c
                    End If

                    If arrTrama(6) <> "00" Then
                        c.CodError = 1
                        c.MsgError = arrTrama(8).Trim() & ". "
                        Logger.Error(MethodInfo.GetCurrentMethod, New Exception(c.MsgError), "")
                        Return c
                    End If

                    c.Codigounico = Util.FormatoCodigoUnico(arrTrama(9))
                    'c.Codigotipodocumento = Me._tipoDocTRX_To_tipoDocCEF(ConvertFormat.CheckString(arrTrama(10)).Trim())
                    c.Codigotipodocumento = ConvertFormat.CheckString(arrTrama(10)).Trim()
                    c.Numerodocumento = arrTrama(11).Trim()
                    c.Razonsocialcliente = arrTrama(12).Trim()
                    c.Ciiu = arrTrama(24).Trim()
                    c.Codigoejecutivo = arrTrama(13).Trim()
                    c.Nombreejecutivo = arrTrama(14).Trim()
                    c.Codigogrupo = arrTrama(17).Trim()
                    c.Nombregrupo = arrTrama(36).Trim()

                    c.CodError = 0
                    c.MsgError = ""

                    If String.IsNullOrEmpty(c.Codigogrupo) Then
                        'SE LE ASIGNA POR DEFAULT GGG1
                        c.Codigogrupo = "GGG1"
                    End If
                    If String.IsNullOrEmpty(c.Ciiu) Then
                        'SE LE ASIGNA POR DEFAULT 0000
                        c.Ciiu = "0000"
                    End If

                    'Se sincroniza con tabla GrupoEconomico
                    c.Nombregrupo = sincronizaGrupoEconomico(c.Codigogrupo, c.Nombregrupo)

                    Return c
                End Using
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")

                Throw ex
            End Try
        End Function

        Private Function _tipoDocTRX_To_tipoDocCEF(ByVal pintTipoDoc As Integer) As Integer
            Dim intTipoDoc As Integer = constantesCommon.eTipoDocumento.NoTiene

            Select Case pintTipoDoc
                Case constantesCommon.C_TRX_TIPDOC_DNI
                    intTipoDoc = constantesCommon.eTipoDocumento.DNI
                Case constantesCommon.C_TRX_TIPDOC_RUC
                    intTipoDoc = constantesCommon.eTipoDocumento.RUC
                Case constantesCommon.C_TRX_TIPDOC_CE
                    intTipoDoc = constantesCommon.eTipoDocumento.CarnetExtranjeria
            End Select

            Return intTipoDoc
        End Function

        Private Function sincronizaGrupoEconomico(ByVal pstrCodGrupo As String, ByVal pstrNomGrupo As String) As String

            Dim obeGrupoEconomico As BusinessEntity.GrupoEconomico
            Dim obrGrupoEconomico As BusinessRules.GrupoEconomico = New BusinessRules.GrupoEconomico

            Try
                obeGrupoEconomico = obrGrupoEconomico.leer(pstrCodGrupo)
                If Not obeGrupoEconomico Is Nothing Then
                    If Not String.IsNullOrEmpty(pstrNomGrupo) Then
                        If Not obeGrupoEconomico.Nombre.Equals(pstrNomGrupo) Then
                            obeGrupoEconomico.Nombre = pstrNomGrupo
                            Dim bolRC As Boolean = obrGrupoEconomico.modificar(obeGrupoEconomico)
                            If Not bolRC Then
                                Logger.Info(MethodInfo.GetCurrentMethod, String.Format("No se pudo modificar el Grupo Economico: Codigo: {0} | Nombre: {1}", pstrCodGrupo, pstrNomGrupo))
                            End If
                        End If
                    End If
                Else
                    obeGrupoEconomico = New BusinessEntity.GrupoEconomico
                    obeGrupoEconomico.CodGrupoEconomico = pstrCodGrupo
                    obeGrupoEconomico.Nombre = pstrNomGrupo
                    Dim bolRC As Boolean = obrGrupoEconomico.agregar(obeGrupoEconomico)
                    If Not bolRC Then
                        Logger.Info(MethodInfo.GetCurrentMethod, String.Format("No se pudo agregar el Grupo Economico: Codigo: {0} | Nombre: {1}", pstrCodGrupo, pstrNomGrupo))
                    End If
                End If
                Return obeGrupoEconomico.Nombre
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try

        End Function

#End Region

#Region "wsRCC"

        <AutoComplete(True)> _
        Public Function ClienteRCCPorDocumentoIdentidad(ByVal tipoDocumentoIdentidad As String, ByVal numeroDocumentoIdentidad As String, ByVal serviceURL As String) As String Implements IServiceExternalLogic.ClienteRCCPorDocumentoIdentidad
            Try
                tipoDocumentoIdentidad = ConvertFormat.CheckString(tipoDocumentoIdentidad).Trim()
                If String.IsNullOrEmpty(tipoDocumentoIdentidad) Then tipoDocumentoIdentidad = "2"

                numeroDocumentoIdentidad = ConvertFormat.CheckString(numeroDocumentoIdentidad).Trim().ToUpper()
                If String.IsNullOrEmpty(numeroDocumentoIdentidad) Then numeroDocumentoIdentidad = "0".PadLeft(11, "0"c)

                Using data As New ServiceExternalData()
                    Dim resultado As String
                    resultado = data.bpsWS_wsRCC_fstrGet_CodigoSBS(tipoDocumentoIdentidad, numeroDocumentoIdentidad, serviceURL)
                    If String.IsNullOrEmpty(resultado) Or resultado = "0" Then resultado = "0".PadLeft(9, "0"c)
                    Return resultado
                End Using

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function
#End Region

    End Class

End Namespace
