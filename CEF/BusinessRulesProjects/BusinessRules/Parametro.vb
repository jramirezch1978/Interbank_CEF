'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 
'Modificado por: María Laura Santisteban Valdez
'Fecha Mod.: 28/03/2006
'*************************************************************
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
    Public Class Parametro
        Inherits BLO
        Implements IParametro

        Sub New()
            MyBase.New()
        End Sub


        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodParametro As String) As BusinessEntity.Parametro Implements IParametro.leer
            Dim odaParametro As DataAccess.Parametro = Nothing
            Try
                odaParametro = New DataAccess.Parametro
                Dim dsParametro As DataSet = odaParametro.leer(pstrCodParametro)
                Dim obeParametro As BusinessEntity.Parametro
                If dsParametro.Tables(0).Rows.Count > 0 Then
                    obeParametro = New BusinessEntity.Parametro
                    obeParametro.CodParametro = dsParametro.Tables(0).Rows(0)("CodParametro")
                    obeParametro.Descripcion = dsParametro.Tables(0).Rows(0)("Descripcion")
                    obeParametro.Valor1 = dsParametro.Tables(0).Rows(0)("Valor1")
                    If Not dsParametro.Tables(0).Rows(0).IsNull("Valor2") Then obeParametro.Valor2 = dsParametro.Tables(0).Rows(0)("Valor2")
                    obeParametro.Estado = dsParametro.Tables(0).Rows(0)("Estado")
                End If
                Return (obeParametro)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaParametro)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar() As DataSet Implements IParametro.listar
            Dim odaParametro As DataAccess.Parametro = Nothing
            Try
                odaParametro = New DataAccess.Parametro
                Return (odaParametro.listar())
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaParametro)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeParametro As BusinessEntity.Parametro) As Boolean Implements IParametro.agregar
            Dim odaParametro As DataAccess.Parametro = Nothing
            Try
                odaParametro = New DataAccess.Parametro
                pobeParametro.FecReg = DateTime.Today()
                Return (odaParametro.agregar(pobeParametro))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaParametro)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeParametro As BusinessEntity.Parametro) As Boolean Implements IParametro.modificar
            Dim odaParametro As DataAccess.Parametro = Nothing
            Try
                odaParametro = New DataAccess.Parametro
                Return (odaParametro.modificar(pobeParametro))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaParametro)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pstrCodParametro As String) As Boolean Implements IParametro.eliminar
            Dim odaParametro As DataAccess.Parametro = Nothing
            Try
                odaParametro = New DataAccess.Parametro
                Return (odaParametro.eliminar(pstrCodParametro))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaParametro Is Nothing) Then
                    ServicedComponent.DisposeObject(odaParametro)
                End If
            End Try
        End Function

    End Class

End Namespace