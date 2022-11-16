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
    Public Class Operador
        Inherits BLO
        Implements IOperador

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodOperador As Integer) As BusinessEntity.Operador Implements IOperador.leer
            Dim odaOperador As DataAccess.Operador = Nothing
            Try
                odaOperador = New DataAccess.Operador
                Dim dsOperador As DataSet = odaOperador.leer(pintCodOperador)
                Dim obeOperador As BusinessEntity.Operador
                If dsOperador.Tables(0).Rows.Count > 0 Then
                    obeOperador = New BusinessEntity.Operador
                    obeOperador.CodOperador = dsOperador.Tables(0).Rows(0)("CodOperador")
                    obeOperador.Descripcion = dsOperador.Tables(0).Rows(0)("Descripcion")
                    obeOperador.Simbolo = dsOperador.Tables(0).Rows(0)("Simbolo")
                    obeOperador.Estado = dsOperador.Tables(0).Rows(0)("Estado")
                End If
                Return (obeOperador)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaOperador Is Nothing) Then
                    ServicedComponent.DisposeObject(odaOperador)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements IOperador.listar
            Dim odaOperador As DataAccess.Operador = Nothing
            Try
                odaOperador = New DataAccess.Operador
                Return (odaOperador.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaOperador Is Nothing) Then
                    ServicedComponent.DisposeObject(odaOperador)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeOperador As BusinessEntity.Operador) As Boolean Implements IOperador.agregar
            Dim odaOperador As DataAccess.Operador = Nothing
            Try
                odaOperador = New DataAccess.Operador
                pobeOperador.FecReg = DateTime.Today()
                Return (odaOperador.agregar(pobeOperador))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaOperador Is Nothing) Then
                    ServicedComponent.DisposeObject(odaOperador)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeOperador As BusinessEntity.Operador) As Boolean Implements IOperador.modificar
            Dim odaOperador As DataAccess.Operador = Nothing
            Try
                odaOperador = New DataAccess.Operador
                Return (odaOperador.modificar(pobeOperador))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaOperador Is Nothing) Then
                    ServicedComponent.DisposeObject(odaOperador)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodOperador As Integer) As Boolean Implements IOperador.eliminar
            Dim odaOperador As DataAccess.Operador = Nothing
            Try
                odaOperador = New DataAccess.Operador
                Return (odaOperador.eliminar(pintCodOperador))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaOperador Is Nothing) Then
                    ServicedComponent.DisposeObject(odaOperador)
                End If
            End Try
        End Function

    End Class

End Namespace