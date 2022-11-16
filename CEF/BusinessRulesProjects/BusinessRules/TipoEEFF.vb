'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 14/01/2006
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
    Public Class TipoEEFF
        Inherits BLO
        Implements ITipoEEFF

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodTipoEEFF As Integer) As BusinessEntity.TipoEEFF Implements ITipoEEFF.leer
            Dim odaTipoEEFF As DataAccess.TipoEEFF = Nothing
            Try
                odaTipoEEFF = New DataAccess.TipoEEFF
                Dim dsTipoEEFF As DataSet = odaTipoEEFF.leer(pintCodTipoEEFF)
                Dim obeTipoEEFF As BusinessEntity.TipoEEFF
                If dsTipoEEFF.Tables(0).Rows.Count > 0 Then
                    obeTipoEEFF = New BusinessEntity.TipoEEFF
                    obeTipoEEFF.CodTipoEEFF = dsTipoEEFF.Tables(0).Rows(0)("CodTipoEEFF")
                    obeTipoEEFF.Descripcion = dsTipoEEFF.Tables(0).Rows(0)("Descripcion")
                    obeTipoEEFF.Orden = dsTipoEEFF.Tables(0).Rows(0)("Orden")
                    obeTipoEEFF.Estado = dsTipoEEFF.Tables(0).Rows(0)("Estado")
                End If
                Return (obeTipoEEFF)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoEEFF)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements ITipoEEFF.listar
            Dim odaTipoEEFF As DataAccess.TipoEEFF = Nothing
            Try
                odaTipoEEFF = New DataAccess.TipoEEFF
                Return (odaTipoEEFF.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoEEFF)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeTipoEEFF As BusinessEntity.TipoEEFF) As Boolean Implements ITipoEEFF.agregar
            Dim odaTipoEEFF As DataAccess.TipoEEFF = Nothing
            Try
                odaTipoEEFF = New DataAccess.TipoEEFF
                pobeTipoEEFF.FecReg = DateTime.Today()
                Return (odaTipoEEFF.agregar(pobeTipoEEFF))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoEEFF)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeTipoEEFF As BusinessEntity.TipoEEFF) As Boolean Implements ITipoEEFF.modificar
            Dim odaTipoEEFF As DataAccess.TipoEEFF = Nothing
            Try
                odaTipoEEFF = New DataAccess.TipoEEFF
                Return (odaTipoEEFF.modificar(pobeTipoEEFF))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoEEFF)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodTipoEEFF As Integer) As Boolean Implements ITipoEEFF.eliminar
            Dim odaTipoEEFF As DataAccess.TipoEEFF = Nothing
            Try
                odaTipoEEFF = New DataAccess.TipoEEFF
                Return (odaTipoEEFF.eliminar(pintCodTipoEEFF))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoEEFF Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoEEFF)
                End If
            End Try
        End Function

    End Class

End Namespace