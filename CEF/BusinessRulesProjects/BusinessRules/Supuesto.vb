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
    Public Class Supuesto
        Inherits BLO
        Implements ISupuesto

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodSupuesto As Integer) As BusinessEntity.Supuesto Implements ISupuesto.leer
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Dim dsSupuesto As DataSet = odaSupuesto.leer(pintCodSupuesto)
                Dim obeSupuesto As BusinessEntity.Supuesto
                If dsSupuesto.Tables(0).Rows.Count > 0 Then
                    Dim drSupuesto As DataRow = dsSupuesto.Tables(0).Rows(0)
                    obeSupuesto = cargaSupuesto(drSupuesto)
                End If
                Return (obeSupuesto)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscarPorPeriodo(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As System.Data.DataSet Implements ISupuesto.buscarPorPeriodo
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Return (odaSupuesto.buscarPorPeriodo(pintCodMetodizado, pintCodPeriodo))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Private Function cargaSupuesto(ByRef pdrSupuesto As DataRow) As BusinessEntity.Supuesto
            Dim obeSupuesto As BusinessEntity.Supuesto = New BusinessEntity.Supuesto
            Try
                obeSupuesto.CodSupuesto = pdrSupuesto.Item("CodSupuesto")
                obeSupuesto.CodMetodizado = pdrSupuesto.Item("CodMetodizado")
                obeSupuesto.CodPeriodo = pdrSupuesto.Item("CodPeriodo")
                obeSupuesto.CodPeriodoAnterior = pdrSupuesto.Item("CodPeriodoAnterior")
                obeSupuesto.CodTipoSupuesto = pdrSupuesto.Item("CodTipoSupuesto")
                obeSupuesto.Descripcion = pdrSupuesto.Item("Descripcion")
                obeSupuesto.NumeroProyectado = pdrSupuesto.Item("NumeroProyectado")
                obeSupuesto.CodMoneda = pdrSupuesto.Item("CodMoneda")
                obeSupuesto.CodUnidad = pdrSupuesto.Item("CodUnidad")
                obeSupuesto.FecReg = pdrSupuesto.Item("FecReg")
                obeSupuesto.Estado = pdrSupuesto.Item("Estado")
                Return (obeSupuesto)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
            End Try

        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean Implements ISupuesto.agregar
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
                Dim obePeriodo As BusinessEntity.Periodo = obrMetodizado.leerPeriodo(pobeSupuesto.CodMetodizado, pobeSupuesto.CodPeriodo)
                Dim dteFecPeriodo As DateTime = obePeriodo.FecPeriodo
                obrMetodizado.Dispose()

                odaSupuesto = New DataAccess.Supuesto
                pobeSupuesto.FecReg = DateTime.Today

                For intIndice As Integer = 1 To (pobeSupuesto.NumeroProyectado + 1)
                    Dim obePeriodoProyectado As BusinessEntity.PeriodoProyectado = New BusinessEntity.PeriodoProyectado
                    obePeriodoProyectado.CodProyectado = intIndice
                    If intIndice = 1 Then
                        obePeriodoProyectado.Tipo = Byte.Parse(Common.Globals.ecTipoPeriodoProyectado.HISTORICO)
                    Else
                        obePeriodoProyectado.Tipo = Byte.Parse(Common.Globals.ecTipoPeriodoProyectado.PROYECTADO)
                    End If
                    obePeriodoProyectado.FecProyectado = dteFecPeriodo.AddYears(intIndice - 1)
                    pobeSupuesto.PeriodosProyectados.Add(obePeriodoProyectado)
                Next

                Dim dsSupuesto As DataSet = odaSupuesto.calcularSupuestoHistoricoInicial(pobeSupuesto.CodMetodizado, pobeSupuesto.CodPeriodo, pobeSupuesto.CodPeriodoAnterior)
                Dim dtSupuestoProyectado As DataTable = dsSupuesto.Tables(0)

                For Each drReg As DataRow In dtSupuestoProyectado.Rows
                    If Not drReg.IsNull("ImportePry1") Then
                        For bytCol As Byte = 1 To (pobeSupuesto.NumeroProyectado + 1)
                            Dim obeSupuestoProyectado As BusinessEntity.SupuestoProyectado = New BusinessEntity.SupuestoProyectado
                            obeSupuestoProyectado.CodProyectado = bytCol
                            obeSupuestoProyectado.CodCuentaSupuesto = drReg("CodCuentaSupuesto")
                            obeSupuestoProyectado.Importe = drReg("ImportePry1")
                            If Not drReg.IsNull("FuncionPry1") Then obeSupuestoProyectado.Funcion = drReg("FuncionPry1")
                            pobeSupuesto.PeriodosProyectados.buscarPorClave(pobeSupuesto.CodSupuesto, bytCol).SupuestosProyectados.Add(obeSupuestoProyectado)
                        Next
                    End If
                Next
                Dim bolRC As Boolean = odaSupuesto.agregar(pobeSupuesto)
                Return (bolRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean Implements ISupuesto.modificar
            Dim odaSupuesto As DataAccess.Supuesto = Nothing

            Try
                odaSupuesto = New DataAccess.Supuesto

                Dim bolRC As Boolean = odaSupuesto.modificar(pobeSupuesto)

                Return (bolRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pintCodSupuesto As Integer) As Boolean Implements ISupuesto.eliminar
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Dim bolRC As Boolean = odaSupuesto.eliminar(pintCodSupuesto)
                Return (bolRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregarSupuestoProyectado(ByRef pobeSupuesto As BusinessEntity.Supuesto) As Boolean Implements ISupuesto.agregarSupuestoProyectado
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Dim bolRC As Boolean = odaSupuesto.agregarSupuestoProyectado(pobeSupuesto)
                Return (bolRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarPeriodoProyectado(ByVal pintCodSupuesto As Integer) As BusinessEntity.PeriodoProyectadoLst Implements ISupuesto.listarPeriodoProyectado
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Dim dsPeriodoProyectado As DataSet = odaSupuesto.listarPeriodoProyectado(pintCodSupuesto)
                Dim obePeriodoProyectadoLst As BusinessEntity.PeriodoProyectadoLst = New BusinessEntity.PeriodoProyectadoLst
                For Each drPeriodoProyectado As DataRow In dsPeriodoProyectado.Tables(0).Rows
                    obePeriodoProyectadoLst.Add(cargaPeriodoProyectado(drPeriodoProyectado))
                Next
                Return (obePeriodoProyectadoLst)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Private Function cargaPeriodoProyectado(ByRef pdrPeriodoProyectado As DataRow) As BusinessEntity.PeriodoProyectado
            Dim obePeriodoProyectado As BusinessEntity.PeriodoProyectado = New BusinessEntity.PeriodoProyectado
            Try
                obePeriodoProyectado.CodSupuesto = pdrPeriodoProyectado.Item("CodSupuesto")
                obePeriodoProyectado.CodProyectado = pdrPeriodoProyectado.Item("CodProyectado")
                obePeriodoProyectado.Tipo = pdrPeriodoProyectado.Item("Tipo")
                obePeriodoProyectado.FecProyectado = pdrPeriodoProyectado.Item("FecProyectado")
                obePeriodoProyectado.FecReg = pdrPeriodoProyectado.Item("FecReg")
                Return (obePeriodoProyectado)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
            End Try

        End Function

        <AutoComplete(True)> _
        Public Function listarSupuestoProyectado(ByVal pintCodSupuesto As Integer, ByVal pintCodProyectado As Integer) As DataSet Implements ISupuesto.listarSupuestoProyectado
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Return (odaSupuesto.listarSupuestoProyectado(pintCodSupuesto, pintCodProyectado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function calcularSupuestoHistoricoInicial(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer, ByVal pintCodPeriodoAnterior As Integer) As DataSet Implements ISupuesto.calcularSupuestoHistoricoInicial
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Return (odaSupuesto.calcularSupuestoHistoricoInicial(pintCodMetodizado, pintCodPeriodo, pintCodPeriodoAnterior))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function calcularSupuestoProyectadoInicial(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer, ByVal pintCodPeriodoAnterior As Integer, ByVal pbytNumeroProyectado As Byte) As System.Data.DataSet Implements ISupuesto.calcularSupuestoProyectadoInicial
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Dim dsSupuesto As DataSet = odaSupuesto.calcularSupuestoHistoricoInicial(pintCodMetodizado, pintCodPeriodo, pintCodPeriodoAnterior)
                Dim dtSupuestoProyectado As DataTable = dsSupuesto.Tables(0)
                For bytCol As Byte = 2 To (pbytNumeroProyectado + 1)
                    Dim strColumna As String
                    strColumna = "ImportePry" + bytCol.ToString()
                    Dim dcImporte As DataColumn = New DataColumn(strColumna, GetType(Decimal))
                    dcImporte.AllowDBNull = True
                    dtSupuestoProyectado.Columns.Add(dcImporte)

                    strColumna = "FuncionPry" + bytCol.ToString()
                    Dim dcFuncion As DataColumn = New DataColumn(strColumna, GetType(String))
                    dcFuncion.AllowDBNull = True
                    dtSupuestoProyectado.Columns.Add(dcFuncion)
                Next

                For Each drReg As DataRow In dtSupuestoProyectado.Rows
                    For bytCol As Byte = 2 To (pbytNumeroProyectado + 1)
                        Dim strColumna As String
                        strColumna = "ImportePry" + bytCol.ToString()
                        drReg(strColumna) = drReg("ImportePry1")
                        strColumna = "FuncionPry" + bytCol.ToString()
                        drReg(strColumna) = drReg("FuncionPry1")
                    Next
                Next

                Return (dsSupuesto)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function filtrarSupuestoProyectado(ByVal pintCodSupuesto As Integer) As DataSet Implements ISupuesto.filtrarSupuestoProyectado
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Try
                odaSupuesto = New DataAccess.Supuesto
                Dim dsSupuestoProyectado As DataSet = odaSupuesto.filtrarSupuestoProyectado(pintCodSupuesto)
                Dim dtSupuestoProyectado As DataTable = dsSupuestoProyectado.Tables(0)

                Dim dsCuentaSupuesto As DataSet = odaSupuesto.listarCuentaSupuesto(pintCodSupuesto)
                Dim dtCuentaSupuesto As DataTable = dsCuentaSupuesto.Tables(0)

                Dim obePeriodoProyectadoLst As BusinessEntity.PeriodoProyectadoLst = listarPeriodoProyectado(pintCodSupuesto)

                For Each obePeriodoProyectado As BusinessEntity.PeriodoProyectado In obePeriodoProyectadoLst
                    Dim strColumna As String
                    strColumna = "ImportePry" + obePeriodoProyectado.CodProyectado.ToString()
                    Dim dcImporte As DataColumn = New DataColumn(strColumna, GetType(Decimal))
                    dcImporte.AllowDBNull = True
                    dtCuentaSupuesto.Columns.Add(dcImporte)

                    strColumna = "FuncionPry" + obePeriodoProyectado.CodProyectado.ToString()
                    Dim dcFuncion As DataColumn = New DataColumn(strColumna, GetType(String))
                    dcFuncion.AllowDBNull = True
                    dtCuentaSupuesto.Columns.Add(dcFuncion)
                Next

                For Each drRegCS As DataRow In dtCuentaSupuesto.Rows
                    Dim strFiltro As String = String.Format("CodCuentaSupuesto = {0}", drRegCS("CodCuentaSupuesto"))
                    For Each drRegSP As DataRow In dtSupuestoProyectado.Select(strFiltro, String.Empty)
                        Dim strColumna As String
                        strColumna = "ImportePry" + drRegSP("CodProyectado").ToString()
                        drRegCS(strColumna) = drRegSP("Importe")
                        strColumna = "FuncionPry" + drRegSP("CodProyectado").ToString()
                        drRegCS(strColumna) = drRegSP("Funcion")
                    Next
                Next

                Return (dsCuentaSupuesto)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function filtrarFlujoProyectado(ByVal pintCodSupuesto As Integer) As DataSet Implements ISupuesto.filtrarFlujoProyectado
            Dim odaSupuesto As DataAccess.Supuesto = Nothing
            Dim odaCuentaAnalisis As DataAccess.CuentaAnalisis = Nothing
            Try
                Dim obeSupuesto As BusinessEntity.Supuesto = leer(pintCodSupuesto)
                Dim intCodMetodizado As Integer = obeSupuesto.CodMetodizado

                odaCuentaAnalisis = New DataAccess.CuentaAnalisis
                Dim dsCuentaSupuesto As DataSet = odaCuentaAnalisis.listarMasCuentaLibre(6, intCodMetodizado)
                Dim dtCuentaSupuesto As DataTable = dsCuentaSupuesto.Tables(0)

                Dim obePeriodoProyectadoLst As BusinessEntity.PeriodoProyectadoLst = listarPeriodoProyectado(pintCodSupuesto)

                For Each obePeriodoProyectado As BusinessEntity.PeriodoProyectado In obePeriodoProyectadoLst
                    Dim strColumna As String = "ImportePry" + obePeriodoProyectado.CodProyectado.ToString()
                    Dim dcImporte As DataColumn = New DataColumn(strColumna, GetType(Decimal))
                    dcImporte.AllowDBNull = True
                    dtCuentaSupuesto.Columns.Add(dcImporte)
                Next

                odaSupuesto = New DataAccess.Supuesto
                Dim dsSupuestoProyectado As DataSet = odaSupuesto.filtrarFlujoProyectado(pintCodSupuesto)
                Dim dtSupuestoProyectado As DataTable = dsSupuestoProyectado.Tables(0)

                For Each drRegCS As DataRow In dtCuentaSupuesto.Rows
                    Dim strFiltro As String = String.Format("CodCuentaAnalisis = {0}", drRegCS("CodCuentaAnalisis"))
                    For Each drRegSP As DataRow In dtSupuestoProyectado.Select(strFiltro, String.Empty)
                        Dim strColumna As String = "ImportePry" + drRegSP("CodProyectado").ToString()
                        drRegCS(strColumna) = drRegSP("Importe")
                    Next
                Next

                Return (dsCuentaSupuesto)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaSupuesto)
                End If
                If (Not odaCuentaAnalisis Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuentaAnalisis)
                End If
            End Try
        End Function

    End Class

End Namespace