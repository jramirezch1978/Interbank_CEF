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
'Imports System.Diagnostics
Imports System.EnterpriseServices
'Imports System.Runtime.InteropServices
Imports CEF.DataAccess
Imports CEF.BusinessEntity
Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class Cuenta
        Inherits BLO
        Implements ICuenta

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodCuenta As Integer) As BusinessEntity.Cuenta Implements ICuenta.leer
            Dim odaCuenta As DataAccess.Cuenta = Nothing
            Try
                odaCuenta = New DataAccess.Cuenta
                Dim dsCuenta As DataSet = odaCuenta.leer(pintCodCuenta)
                Dim obeCuenta As BusinessEntity.Cuenta
                If dsCuenta.Tables(0).Rows.Count > 0 Then
                    obeCuenta = New BusinessEntity.Cuenta
                    obeCuenta.CodCuentaPadre = dsCuenta.Tables(0).Rows(0)("CodCuentaPadre")
                    obeCuenta.CodEeff = dsCuenta.Tables(0).Rows(0)("CodEeff")
                    obeCuenta.Descripcion = dsCuenta.Tables(0).Rows(0)("Descripcion")
                    obeCuenta.CodTipoCuenta = dsCuenta.Tables(0).Rows(0)("CodTipoCuenta")
                    obeCuenta.Orden = dsCuenta.Tables(0).Rows(0)("Orden")
                    obeCuenta.FecReg = dsCuenta.Tables(0).Rows(0)("FecReg")
                    obeCuenta.Estado = dsCuenta.Tables(0).Rows(0)("Estado")
                End If
                Return (obeCuenta)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuenta Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuenta)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements ICuenta.listar
            Dim odaCuenta As DataAccess.Cuenta = Nothing
            Try
                odaCuenta = New DataAccess.Cuenta
                Return (odaCuenta.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuenta Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuenta)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeCuenta As BusinessEntity.Cuenta) As Boolean Implements ICuenta.agregar
            Dim odaCuenta As DataAccess.Cuenta = Nothing
            Try
                odaCuenta = New DataAccess.Cuenta
                Return (odaCuenta.agregar(pobeCuenta))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuenta Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuenta)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeCuenta As BusinessEntity.Cuenta) As Boolean Implements ICuenta.modificar
            Dim odaCuenta As DataAccess.Cuenta = Nothing
            Try
                odaCuenta = New DataAccess.Cuenta
                Return (odaCuenta.modificar(pobeCuenta))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuenta Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuenta)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodCuenta As Integer) As Boolean Implements ICuenta.eliminar
            Dim odaCuenta As DataAccess.Cuenta = Nothing
            Try
                odaCuenta = New DataAccess.Cuenta
                Return (odaCuenta.eliminar(pintCodCuenta))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuenta Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuenta)
                End If
            End Try
        End Function

    End Class

End Namespace