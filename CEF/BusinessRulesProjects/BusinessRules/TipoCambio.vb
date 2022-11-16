'*************************************************************
'Proposito:
'Autor: Miguel Delgado del Aguila
'Fecha Creacion: 19/06/2006
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
    Public Class TipoCambio
        Inherits BLO
        Implements ITipoCambio

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintAnio As Integer, ByVal pintMes As Integer, ByVal pintMoneda As Integer) As BusinessEntity.TipoCambio Implements ITipoCambio.leer
            Dim odaTipoCambio As DataAccess.TipoCambio = Nothing
            Try
                odaTipoCambio = New DataAccess.TipoCambio
                Dim dsTipoCambio As DataSet = odaTipoCambio.leer(pintAnio, pintMes, pintMoneda)
                Dim obeTipoCambio As BusinessEntity.TipoCambio
                ' SRT_2016-03093
                If Not (dsTipoCambio Is Nothing) Then
                    If dsTipoCambio.Tables(0).Rows.Count > 0 Then
                        obeTipoCambio = New BusinessEntity.TipoCambio
                        obeTipoCambio.Anio = dsTipoCambio.Tables(0).Rows(0)("Anio")
                        obeTipoCambio.Mes = dsTipoCambio.Tables(0).Rows(0)("Mes")
                        obeTipoCambio.CodMoneda = dsTipoCambio.Tables(0).Rows(0)("CodMoneda")
                        obeTipoCambio.Monto = dsTipoCambio.Tables(0).Rows(0)("Monto")
                        If Not dsTipoCambio.Tables(0).Rows(0).IsNull("MontoMaximo") Then obeTipoCambio.MontoMaximo = dsTipoCambio.Tables(0).Rows(0)("MontoMaximo")
                        If Not dsTipoCambio.Tables(0).Rows(0).IsNull("PorcentajeDevaluacion") Then obeTipoCambio.PorcentajeDevaluacion = dsTipoCambio.Tables(0).Rows(0)("PorcentajeDevaluacion")
                        obeTipoCambio.IndiceReexpresion = dsTipoCambio.Tables(0).Rows(0)("IndiceReexpresion")
                        obeTipoCambio.Estado = dsTipoCambio.Tables(0).Rows(0)("Estado")
                    End If
                End If
                Return (obeTipoCambio)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoCambio Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoCambio)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements ITipoCambio.listar
            Dim odaTipoCambio As DataAccess.TipoCambio = Nothing
            Try
                odaTipoCambio = New DataAccess.TipoCambio
                Return (odaTipoCambio.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoCambio Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoCambio)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarConFiltros(ByVal pbytFlag As Byte, ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As DataSet Implements ITipoCambio.listarConFiltros
            Dim odaTipoCambio As DataAccess.TipoCambio = Nothing
            Try
                odaTipoCambio = New DataAccess.TipoCambio
                Return (odaTipoCambio.listarConFiltros(pbytFlag, pobeTipoCambio))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoCambio Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoCambio)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As Boolean Implements ITipoCambio.agregar
            Dim odaTipoCambio As DataAccess.TipoCambio = Nothing
            Try
                odaTipoCambio = New DataAccess.TipoCambio
                pobeTipoCambio.FecReg = DateTime.Today
                Return (odaTipoCambio.agregar(pobeTipoCambio))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoCambio Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoCambio)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As Boolean Implements ITipoCambio.modificar
            Dim odaTipoCambio As DataAccess.TipoCambio = Nothing
            Try
                odaTipoCambio = New DataAccess.TipoCambio
                Return (odaTipoCambio.modificar(pobeTipoCambio))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoCambio Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoCambio)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintAnio As Integer, ByVal pintMes As Integer, ByVal pintMoneda As Integer) As Boolean Implements ITipoCambio.eliminar
            Dim odaTipoCambio As DataAccess.TipoCambio = Nothing
            Try
                odaTipoCambio = New DataAccess.TipoCambio
                Return (odaTipoCambio.eliminar(pintAnio, pintMes, pintMoneda))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaTipoCambio Is Nothing) Then
                    ServicedComponent.DisposeObject(odaTipoCambio)
                End If
            End Try
        End Function

    End Class

End Namespace