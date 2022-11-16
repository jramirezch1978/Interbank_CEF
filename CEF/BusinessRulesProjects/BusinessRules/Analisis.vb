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
    Public Class Analisis
        Inherits BLO
        Implements IAnalisis

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodAnalisis As Integer) As BusinessEntity.Analisis Implements IAnalisis.leer
            Dim odaAnalisis As DataAccess.Analisis = Nothing
            Try
                odaAnalisis = New DataAccess.Analisis
                Dim dsAnalisis As DataSet = odaAnalisis.leer(pintCodAnalisis)
                Dim obeAnalisis As BusinessEntity.Analisis
                If dsAnalisis.Tables(0).Rows.Count > 0 Then
                    obeAnalisis = New BusinessEntity.Analisis
                    obeAnalisis.CodAnalisis = dsAnalisis.Tables(0).Rows(0)("CodAnalisis")
                    obeAnalisis.Descripcion = dsAnalisis.Tables(0).Rows(0)("Descripcion")
                    obeAnalisis.Orden = dsAnalisis.Tables(0).Rows(0)("Orden")
                    obeAnalisis.Estado = dsAnalisis.Tables(0).Rows(0)("Estado")
                End If
                Return (obeAnalisis)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements IAnalisis.listar
            Dim odaAnalisis As DataAccess.Analisis = Nothing
            Try
                odaAnalisis = New DataAccess.Analisis
                Return (odaAnalisis.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeAnalisis As BusinessEntity.Analisis) As Boolean Implements IAnalisis.agregar
            Dim odaAnalisis As DataAccess.Analisis = Nothing
            Try
                odaAnalisis = New DataAccess.Analisis
                pobeAnalisis.FecReg = DateTime.Today
                Return (odaAnalisis.agregar(pobeAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeAnalisis As BusinessEntity.Analisis) As Boolean Implements IAnalisis.modificar
            Dim odaAnalisis As DataAccess.Analisis = Nothing
            Try
                odaAnalisis = New DataAccess.Analisis
                Return (odaAnalisis.modificar(pobeAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodAnalisis As Integer) As Boolean Implements IAnalisis.eliminar
            Dim odaAnalisis As DataAccess.Analisis = Nothing
            Try
                odaAnalisis = New DataAccess.Analisis
                Return (odaAnalisis.eliminar(pintCodAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAnalisis)
                End If
            End Try
        End Function

    End Class

End Namespace