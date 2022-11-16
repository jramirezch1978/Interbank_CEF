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
    Public Class ProyeccionBR
        Inherits BLO
        Implements IProyeccion

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function TraerDatosCabecera(ByVal pintcodMetodizado As Integer, ByVal pintcodProyeccion As Integer) As Data.DataSet Implements IProyeccion.TraerDatosCabecera
            Dim odaProyeccion As DataAccess.ProyeccionDA = Nothing
            Try
                odaProyeccion = New DataAccess.ProyeccionDA
                Return odaProyeccion.TraerDatosCabecera(pintcodMetodizado, pintcodProyeccion)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaProyeccion Is Nothing) Then
                    ServicedComponent.DisposeObject(odaProyeccion)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function grabar(ByVal Proyeccion As BusinessEntity.ProyeccionBE) As Boolean Implements IProyeccion.grabar
            Dim odaProyeccion As DataAccess.ProyeccionDA = Nothing
            Try
                odaProyeccion = New DataAccess.ProyeccionDA
                Return odaProyeccion.Grabar(Proyeccion)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaProyeccion Is Nothing) Then
                    ServicedComponent.DisposeObject(odaProyeccion)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leer(ByVal intCodMetodizado As Integer) As System.Data.DataSet Implements IProyeccion.leer
            Dim odaProyeccion As DataAccess.ProyeccionDA = Nothing
            Try
                odaProyeccion = New DataAccess.ProyeccionDA
                Return odaProyeccion.leer(intCodMetodizado)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaProyeccion Is Nothing) Then
                    ServicedComponent.DisposeObject(odaProyeccion)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function Eliminar(ByVal pintcodProyeccion As Integer, ByVal pintCodMetodizado As Integer) As Boolean Implements IProyeccion.Eliminar
            Dim odaProyeccion As DataAccess.ProyeccionDA = Nothing
            Try
                odaProyeccion = New DataAccess.ProyeccionDA
                Return odaProyeccion.Eliminar(pintcodProyeccion, pintCodMetodizado)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaProyeccion Is Nothing) Then
                    ServicedComponent.DisposeObject(odaProyeccion)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function VerificarFechaProyeccion(ByVal pcodmetodizado As Integer, ByVal pfechaproyeccion As Date) As Boolean Implements IProyeccion.VerificarFechaProyeccion
            Dim odaProyeccion As DataAccess.ProyeccionDA = Nothing
            Try
                odaProyeccion = New DataAccess.ProyeccionDA
                Return odaProyeccion.VerificarFechaProyeccion(pcodmetodizado, pfechaproyeccion)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaProyeccion Is Nothing) Then
                    ServicedComponent.DisposeObject(odaProyeccion)
                End If
            End Try
        End Function
    End Class

End Namespace
