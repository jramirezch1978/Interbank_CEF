'*************************************************************
'Proposito: 
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 27/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.DataAccess
Imports CEF.BusinessEntity
Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.NotSupported)> _
    Public Class Cliente
        Inherits BLO
        Implements ICliente

        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodigoUnico As String) As BusinessEntity.Cliente Implements ICliente.leer
            Dim odaCliente As DataAccess.Cliente = Nothing
            odaCliente = New DataAccess.Cliente
            Try
                Dim dsCliente As DataSet = odaCliente.leer(pstrCodigoUnico)
                Dim obeCliente As BusinessEntity.Cliente
                If dsCliente.Tables(0).Rows.Count > 0 Then
                    Dim drCliente As DataRow = dsCliente.Tables(0).Rows(0)
                    obeCliente = cargaCliente(drCliente)
                End If
                Return (obeCliente)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCliente Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCliente)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarXNumeroDocumento(ByVal pstrTipoDocumentoIdentidad As String, ByVal pstrNumeroDocumentoIdentidad As String) As BusinessEntity.Cliente Implements ICliente.buscarXNumeroDocumento
            Dim odaCliente As DataAccess.Cliente = Nothing
            odaCliente = New DataAccess.Cliente
            Try
                Dim dsCliente As DataSet = odaCliente.buscarXNumeroDocumento(pstrTipoDocumentoIdentidad, pstrNumeroDocumentoIdentidad)
                Dim obeCliente As BusinessEntity.Cliente
                If dsCliente.Tables(0).Rows.Count > 0 Then
                    Dim drCliente As DataRow = dsCliente.Tables(0).Rows(0)
                    obeCliente = cargaCliente(drCliente)
                End If
                Return (obeCliente)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCliente Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCliente)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function ObtenerAlgo(ByVal msg As String) As String Implements ICliente.ObtenerAlgo
            Dim strRuta As String = Common.Assemblys.leerUbicacion(System.Reflection.Assembly.GetExecutingAssembly.Location)
            Return "ALGO COMO:" & strRuta
        End Function

        <AutoComplete(True)> _
        Public Function leerRegOmaesSunat(ByVal pstrRucCliente As String) As DataSet Implements ICliente.leerRegOmaesSunat
            Dim odaCliente As DataAccess.Cliente = Nothing
            Try
                odaCliente = New DataAccess.Cliente
                Return (odaCliente.leerRegOmaesSunat(pstrRucCliente))

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCliente Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCliente)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Private Function cargaCliente(ByRef pdrCliente As DataRow) As BusinessEntity.Cliente
            Dim obeCliente As BusinessEntity.Cliente = New BusinessEntity.Cliente
            Try
                obeCliente = New BusinessEntity.Cliente
                obeCliente.CodigoUnico = pdrCliente.Item("CodigoUnico")
                obeCliente.Nombre = pdrCliente.Item("Nombre")
                obeCliente.TipoDocumentoIdentidad = pdrCliente.Item("TipoDocumentoIdentidad")
                obeCliente.NumeroDocumentoIdentidad = pdrCliente.Item("NumeroDocumentoIdentidad")
                If Not pdrCliente.IsNull("CodigoSectoristaActual") Then obeCliente.CodigoSectoristaActual = pdrCliente.Item("CodigoSectoristaActual")
                If Not pdrCliente.IsNull("RegistroSectoristaActual") Then obeCliente.RegistroSectoristaActual = pdrCliente.Item("RegistroSectoristaActual")
                obeCliente.CodigoCIIU = pdrCliente.Item("CodigoCIIU")
                obeCliente.CodigoGrupoEconomico = pdrCliente.Item("CodigoGrupoEconomico")
                obeCliente.NombreGrupoEconomico = pdrCliente.Item("NombreGrupoEconomico")
                obeCliente.CodigoSBS = pdrCliente.Item("CodigoSBS")
                Return (obeCliente)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
            End Try
        End Function

        'ADD XT8633 01062021 INI
        <AutoComplete(True)> _
        Public Function ConsultaEEFFxCliente(ByVal pstrCodigoUnico As String, ByVal pstrTipoDocumentoIdentidad As Integer, ByVal pstrNumeroDocumentoIdentidad As String) As DataSet Implements ICliente.ConsultaEEFFxCliente
            Dim odaCliente As DataAccess.Cliente = Nothing
            Try
                odaCliente = New DataAccess.Cliente
                Return (odaCliente.ConsultaEEFFxCliente(pstrCodigoUnico, pstrTipoDocumentoIdentidad, pstrNumeroDocumentoIdentidad))

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCliente Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCliente)
                End If
            End Try
        End Function
        'ADD XT8633 FIN

    End Class

End Namespace