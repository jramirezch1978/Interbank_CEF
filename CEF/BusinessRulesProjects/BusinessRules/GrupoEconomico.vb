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
    Transaction(TransactionOption.Supported)> _
    Public Class GrupoEconomico
        Inherits BLO
        Implements IGrupoEconomico

        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodGrupoEconomico As String) As BusinessEntity.GrupoEconomico Implements IGrupoEconomico.leer
            Dim odaGrupoEconomico As DataAccess.GrupoEconomico = Nothing
            Try
                odaGrupoEconomico = New DataAccess.GrupoEconomico
                Dim dsGrupoEconomico As DataSet = odaGrupoEconomico.leer(pstrCodGrupoEconomico)
                Dim obeGrupoEconomico As BusinessEntity.GrupoEconomico
                If dsGrupoEconomico.Tables(0).Rows.Count > 0 Then
                    obeGrupoEconomico = New BusinessEntity.GrupoEconomico
                    'MEJORAS CEF II
                    'obeGrupoEconomico.CodGrupoEconomico = dsGrupoEconomico.Tables(0).Rows(0)("Codigo")
                    obeGrupoEconomico.CodGrupoEconomico = dsGrupoEconomico.Tables(0).Rows(0)("CodGrupoEconomico")
                    obeGrupoEconomico.Nombre = dsGrupoEconomico.Tables(0).Rows(0)("Nombre")
                End If
                Return (obeGrupoEconomico)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGrupoEconomico Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGrupoEconomico)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar() As DataSet Implements IGrupoEconomico.listar
            Dim odaGrupoEconomico As DataAccess.GrupoEconomico = Nothing
            Try
                odaGrupoEconomico = New DataAccess.GrupoEconomico
                Return (odaGrupoEconomico.listar())
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGrupoEconomico Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGrupoEconomico)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarXCodigo(ByVal pstrCodGrupoEconomico As String) As DataSet Implements IGrupoEconomico.buscarXCodigo
            Dim odaGrupoEconomico As DataAccess.GrupoEconomico = Nothing
            Try
                odaGrupoEconomico = New DataAccess.GrupoEconomico
                Return (odaGrupoEconomico.leer(pstrCodGrupoEconomico))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGrupoEconomico Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGrupoEconomico)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarXNombre(ByVal pstrNombre As String) As DataSet Implements IGrupoEconomico.buscarXNombre
            Dim odaGrupoEconomico As DataAccess.GrupoEconomico = Nothing
            Try
                odaGrupoEconomico = New DataAccess.GrupoEconomico
                Return (odaGrupoEconomico.buscarXNombre(pstrNombre))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaGrupoEconomico Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGrupoEconomico)
                End If
            End Try
        End Function

        'MEJORAS CEF II
        '<AutoComplete(True)> _
        'Public Function leer(ByVal pstrCodGrupoEconomico As String) As BusinessEntity.GrupoEconomico Implements IGrupoEconomico.leer
        '    Dim odaGrupoEconomico As DataAccess.GrupoEconomico = Nothing
        '    Try
        '        odaGrupoEconomico = New DataAccess.GrupoEconomico
        '        Dim obeGrupoEconomico As BusinessEntity.GrupoEconomico
        '        Dim dsGrupoEconomico As DataSet = odaGrupoEconomico.leer(pstrCodGrupoEconomico)
        '        If dsGrupoEconomico.Tables(0).Rows.Count > 0 Then
        '            Dim drGrupoEconomico As DataRow = dsGrupoEconomico.Tables(0).Rows(0)
        '            obeGrupoEconomico = cargaGrupoEconomico(drGrupoEconomico)
        '        End If
        '        Return (obeGrupoEconomico)
        '    Catch ex As Exception
        '        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
        '        Throw ex
        '    Finally
        '        If (Not odaGrupoEconomico Is Nothing) Then
        '            ServicedComponent.DisposeObject(odaGrupoEconomico)
        '        End If
        '    End Try
        'End Function

        <AutoComplete(True)> _
              Public Function agregar(ByRef pobeGrupoEconomico As BusinessEntity.GrupoEconomico) As Boolean Implements IGrupoEconomico.agregar
            Dim odaGrupoEconomico As DataAccess.GrupoEconomico = Nothing
            Try
                odaGrupoEconomico = New DataAccess.GrupoEconomico
                Return (odaGrupoEconomico.agregar(pobeGrupoEconomico))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaGrupoEconomico Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGrupoEconomico)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeGrupoEconomico As BusinessEntity.GrupoEconomico) As Boolean Implements IGrupoEconomico.modificar
            Dim odaGrupoEconomico As DataAccess.GrupoEconomico = Nothing
            Try
                odaGrupoEconomico = New DataAccess.GrupoEconomico
                Return (odaGrupoEconomico.modificar(pobeGrupoEconomico))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaGrupoEconomico Is Nothing) Then
                    ServicedComponent.DisposeObject(odaGrupoEconomico)
                End If
            End Try
        End Function

        '<AutoComplete(True)> _
        '      Private Function cargaGrupoEconomico(ByRef pdrGrupoEconomico As DataRow) As BusinessEntity.GrupoEconomico
        '    Dim obeGrupoEconomico As BusinessEntity.GrupoEconomico = New BusinessEntity.GrupoEconomico
        '    Try
        '        obeGrupoEconomico.CodGrupoEconomico = pdrGrupoEconomico.Item("CodGrupoEconomico")
        '        obeGrupoEconomico.Nombre = pdrGrupoEconomico.Item("Nombre")
        '        Return (obeGrupoEconomico)
        '    Catch ex As Exception
        '        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
        '        Throw ex
        '    Finally
        '    End Try

        'End Function

    End Class


End Namespace
