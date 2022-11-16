'********************************************************************
'Proposito: Otorgar Permisos a los Perfil
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'********************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.DataAccess

Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class Permiso
        Inherits BLO
        Implements IPermiso

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pshoCodPermiso As Short) As BusinessEntity.Permiso Implements IPermiso.leer
            Dim odaPermiso As DataAccess.Permiso = Nothing
            Try
                odaPermiso = New DataAccess.Permiso
                Dim dsPermiso As DataSet = odaPermiso.leer(pshoCodPermiso)
                Dim obePermiso As BusinessEntity.Permiso
                If dsPermiso.Tables(0).Rows.Count > 0 Then
                    obePermiso = New BusinessEntity.Permiso
                    obePermiso.CodPermiso = dsPermiso.Tables(0).Rows(0)("CodPermiso")
                    obePermiso.CodComponente = dsPermiso.Tables(0).Rows(0)("CodComponente")
                    obePermiso.Descripcion = dsPermiso.Tables(0).Rows(0)("Descripcion")
                    obePermiso.FecReg = dsPermiso.Tables(0).Rows(0)("FecReg")
                    obePermiso.Estado = dsPermiso.Tables(0).Rows(0)("Estado")
                End If
                Return (obePermiso)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPermiso Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPermiso)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leerPermisoPerfil(ByVal pshoCodPermiso As Short, ByVal pshoCodPerfil As Short) As BusinessEntity.PermisoPerfil Implements IPermiso.leerPermisoPerfil
            Dim odaPermiso As DataAccess.Permiso = Nothing
            Try
                odaPermiso = New DataAccess.Permiso
                Dim dsPermiso As DataSet = odaPermiso.leerPermisoPerfil(pshoCodPermiso, pshoCodPerfil)
                Dim obePermisoPerfil As BusinessEntity.PermisoPerfil
                If dsPermiso.Tables(0).Rows.Count > 0 Then
                    obePermisoPerfil = New BusinessEntity.PermisoPerfil
                    obePermisoPerfil.CodPermiso = dsPermiso.Tables(0).Rows(0)("CodPermiso")
                    obePermisoPerfil.CodPerfil = dsPermiso.Tables(0).Rows(0)("CodPerfil")
                    obePermisoPerfil.Valor = dsPermiso.Tables(0).Rows(0)("Valor")
                    obePermisoPerfil.FecReg = dsPermiso.Tables(0).Rows(0)("FecReg")
                End If
                Return (obePermisoPerfil)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPermiso Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPermiso)
                End If
            End Try
        End Function
    End Class

End Namespace