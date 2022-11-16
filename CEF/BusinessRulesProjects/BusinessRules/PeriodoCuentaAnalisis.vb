'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
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
    Public Class PeriodoCuentaAnalisis
        Inherits BLO
        Implements IPeriodoCuentaAnalisis

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function agregar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean Implements IPeriodoCuentaAnalisis.agregar
            Dim odaPeriodoCuentaAnalisis As DataAccess.PeriodoCuentaAnalisis = Nothing
            Try
                odaPeriodoCuentaAnalisis = New DataAccess.PeriodoCuentaAnalisis
                Return (odaPeriodoCuentaAnalisis.agregar(argPeriodoCuentaAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPeriodoCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCuentaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean Implements IPeriodoCuentaAnalisis.eliminar
            Dim odaPeriodoCuentaAnalisis As DataAccess.PeriodoCuentaAnalisis = Nothing
            Try
                odaPeriodoCuentaAnalisis = New DataAccess.PeriodoCuentaAnalisis
                Return (odaPeriodoCuentaAnalisis.eliminar(argPeriodoCuentaAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPeriodoCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCuentaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function leer(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As BusinessEntity.PeriodoCuentaAnalisis Implements IPeriodoCuentaAnalisis.leer
            Dim odaPeriodoCorrida As DataAccess.PeriodoCuentaAnalisis = Nothing
            Dim obePeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis = Nothing

            Try
                odaPeriodoCorrida = New DataAccess.PeriodoCuentaAnalisis
                Dim dsCorridaMetodizado As DataSet = odaPeriodoCorrida.leer(argPeriodoCuentaAnalisis)
                If dsCorridaMetodizado.Tables(0).Rows.Count > 0 Then
                    obePeriodoCuentaAnalisis = New BusinessEntity.PeriodoCuentaAnalisis
                    obePeriodoCuentaAnalisis.Codmetodizado = dsCorridaMetodizado.Tables(0).Rows(0)("CodMetodizado")
                    obePeriodoCuentaAnalisis.Codcorrida = dsCorridaMetodizado.Tables(0).Rows(0)("CodCorrida")
                    obePeriodoCuentaAnalisis.Codperiodoctaanalisis = dsCorridaMetodizado.Tables(0).Rows(0)("Codperiodoctaanalisis")
                    obePeriodoCuentaAnalisis.Codanalisis = dsCorridaMetodizado.Tables(0).Rows(0)("Codanalisis")
                    obePeriodoCuentaAnalisis.Codeeff = dsCorridaMetodizado.Tables(0).Rows(0)("Codeeff")
                    obePeriodoCuentaAnalisis.Codcuentaanalisis = dsCorridaMetodizado.Tables(0).Rows(0)("Codcuentaanalisis")
                    obePeriodoCuentaAnalisis.Descripcion = dsCorridaMetodizado.Tables(0).Rows(0)("Descripcion")
                    obePeriodoCuentaAnalisis.Codtipocuenta = dsCorridaMetodizado.Tables(0).Rows(0)("Codtipocuenta")
                    obePeriodoCuentaAnalisis.Importe1 = dsCorridaMetodizado.Tables(0).Rows(0)("Importe1")
                    obePeriodoCuentaAnalisis.Porcentaje1 = dsCorridaMetodizado.Tables(0).Rows(0)("Porcentaje1")
                    obePeriodoCuentaAnalisis.Variacion1 = dsCorridaMetodizado.Tables(0).Rows(0)("Variacion1")
                    obePeriodoCuentaAnalisis.Soles1 = dsCorridaMetodizado.Tables(0).Rows(0)("Soles1")
                    obePeriodoCuentaAnalisis.Dolares1 = dsCorridaMetodizado.Tables(0).Rows(0)("Dolares1")
                    obePeriodoCuentaAnalisis.Importe2 = dsCorridaMetodizado.Tables(0).Rows(0)("Importe2")
                    obePeriodoCuentaAnalisis.Porcentaje2 = dsCorridaMetodizado.Tables(0).Rows(0)("Porcentaje2")
                    obePeriodoCuentaAnalisis.Variacion2 = dsCorridaMetodizado.Tables(0).Rows(0)("Variacion2")
                    obePeriodoCuentaAnalisis.Soles2 = dsCorridaMetodizado.Tables(0).Rows(0)("Soles2")
                    obePeriodoCuentaAnalisis.Dolares2 = dsCorridaMetodizado.Tables(0).Rows(0)("Dolares2")
                    obePeriodoCuentaAnalisis.Importe3 = dsCorridaMetodizado.Tables(0).Rows(0)("Importe3")
                    obePeriodoCuentaAnalisis.Porcentaje3 = dsCorridaMetodizado.Tables(0).Rows(0)("Porcentaje3")
                    obePeriodoCuentaAnalisis.Variacion3 = dsCorridaMetodizado.Tables(0).Rows(0)("Variacion3")
                    obePeriodoCuentaAnalisis.Soles3 = dsCorridaMetodizado.Tables(0).Rows(0)("Soles3")
                    obePeriodoCuentaAnalisis.Dolares3 = dsCorridaMetodizado.Tables(0).Rows(0)("Dolares3")
                    obePeriodoCuentaAnalisis.Importe4 = dsCorridaMetodizado.Tables(0).Rows(0)("Importe4")
                    obePeriodoCuentaAnalisis.Porcentaje4 = dsCorridaMetodizado.Tables(0).Rows(0)("Porcentaje4")
                    obePeriodoCuentaAnalisis.Variacion4 = dsCorridaMetodizado.Tables(0).Rows(0)("Variacion4")
                    obePeriodoCuentaAnalisis.Soles4 = dsCorridaMetodizado.Tables(0).Rows(0)("Soles4")
                    obePeriodoCuentaAnalisis.Dolares4 = dsCorridaMetodizado.Tables(0).Rows(0)("Dolares4")
                    obePeriodoCuentaAnalisis.Exposicion1 = dsCorridaMetodizado.Tables(0).Rows(0)("Exposicion1")
                    obePeriodoCuentaAnalisis.Exposicion2 = dsCorridaMetodizado.Tables(0).Rows(0)("Exposicion2")
                    obePeriodoCuentaAnalisis.Exposicion3 = dsCorridaMetodizado.Tables(0).Rows(0)("Exposicion3")
                    obePeriodoCuentaAnalisis.Exposicion4 = dsCorridaMetodizado.Tables(0).Rows(0)("Exposicion4")
                End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not argPeriodoCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCorrida)
                End If
            End Try

            Return obePeriodoCuentaAnalisis
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As System.Data.DataSet Implements IPeriodoCuentaAnalisis.listar
            Dim odaPeriodoCuentaAnalisis As DataAccess.PeriodoCuentaAnalisis = Nothing
            Try
                odaPeriodoCuentaAnalisis = New DataAccess.PeriodoCuentaAnalisis
                Return (odaPeriodoCuentaAnalisis.listar(argPeriodoCuentaAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPeriodoCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCuentaAnalisis)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean Implements IPeriodoCuentaAnalisis.modificar
            Dim odaPeriodoCuentaAnalisis As DataAccess.PeriodoCuentaAnalisis = Nothing
            Try
                odaPeriodoCuentaAnalisis = New DataAccess.PeriodoCuentaAnalisis
                Return (odaPeriodoCuentaAnalisis.modificar(argPeriodoCuentaAnalisis))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPeriodoCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPeriodoCuentaAnalisis)
                End If
            End Try
        End Function
    End Class

End Namespace