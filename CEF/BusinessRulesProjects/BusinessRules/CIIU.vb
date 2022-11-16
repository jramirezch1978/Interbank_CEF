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
    Transaction(TransactionOption.RequiresNew)> _
    Public Class CIIU
        Inherits BLO
        Implements ICIIU

        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodCIIU As String) As BusinessEntity.CIIU Implements ICIIU.leer
            Dim odaCIIU As DataAccess.CIIU = Nothing
            Try
                odaCIIU = New DataAccess.CIIU
                Dim dsCIIU As DataSet = odaCIIU.leer(pstrCodCIIU)
                Dim obeCIIU As BusinessEntity.CIIU
                If dsCIIU.Tables(0).Rows.Count > 0 Then
                    obeCIIU = New BusinessEntity.CIIU
                    obeCIIU.CodCIIU = dsCIIU.Tables(0).Rows(0)("CodCIIU")
                    obeCIIU.Nombre = dsCIIU.Tables(0).Rows(0)("Nombre")
                End If
                Return (obeCIIU)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCIIU Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCIIU)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar() As DataSet Implements ICIIU.listar
            Dim odaCIIU As DataAccess.CIIU = Nothing
            Try
                odaCIIU = New DataAccess.CIIU
                Return (odaCIIU.listar())
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCIIU Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCIIU)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarXCodigo(ByVal pstrCodCIIU As String) As DataSet Implements ICIIU.buscarXCodigo
            Dim odaCIIU As DataAccess.CIIU = Nothing
            Try
                odaCIIU = New DataAccess.CIIU
                Return (odaCIIU.leer(pstrCodCIIU))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCIIU Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCIIU)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarXNombre(ByVal pstrNombre As String) As DataSet Implements ICIIU.buscarXNombre
            Dim odaCIIU As DataAccess.CIIU = Nothing
            Try
                odaCIIU = New DataAccess.CIIU
                Return (odaCIIU.buscarXNombre(pstrNombre))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCIIU Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCIIU)
                End If
            End Try
        End Function
    End Class

End Namespace
