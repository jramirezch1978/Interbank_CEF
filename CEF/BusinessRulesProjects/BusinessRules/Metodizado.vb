'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro
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
    Public Class Metodizado
        Inherits BLO
        Implements IMetodizado

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodMetodizado As Integer) As BusinessEntity.Metodizado Implements IMetodizado.leer
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim dsMetodizado As DataSet = odaMetodizado.leer(pintCodMetodizado)
                Dim obeMetodizado As BusinessEntity.Metodizado
                If dsMetodizado.Tables(0).Rows.Count > 0 Then
                    Dim drMetodizado As DataRow = dsMetodizado.Tables(0).Rows(0)
                    obeMetodizado = New BusinessEntity.Metodizado
                    obeMetodizado.CodMetodizado = drMetodizado.Item("CodMetodizado")
                    If Not drMetodizado.IsNull("CUCliente") Then obeMetodizado.CUCliente = drMetodizado.Item("CUCliente")
                    obeMetodizado.TipoDocumento = drMetodizado.Item("TipoDocumento")
                    If Not drMetodizado.IsNull("NumeroDocumento") Then obeMetodizado.NumeroDocumento = drMetodizado.Item("NumeroDocumento")
                    obeMetodizado.RazonSocial = drMetodizado.Item("RazonSocial")
                    If Not drMetodizado.IsNull("CodCIIU") Then obeMetodizado.CodCIIU = drMetodizado.Item("CodCIIU")
                    If Not drMetodizado.IsNull("NombreCIIU") Then obeMetodizado.NombreCIIU = drMetodizado.Item("NombreCIIU")
                    If Not drMetodizado.IsNull("CodSBS") Then obeMetodizado.CodSBS = drMetodizado.Item("CodSBS")
                    obeMetodizado.CodGrupoEconomico = drMetodizado.Item("CodGrupoEconomico")
                    obeMetodizado.NombreGrupoEconomico = drMetodizado.Item("NombreGrupoEconomico")
                    obeMetodizado.CodMoneda = drMetodizado.Item("CodMoneda")
                    obeMetodizado.CodUnidad = drMetodizado.Item("CodUnidad")
                    If Not drMetodizado.IsNull("CodAnalista") Then obeMetodizado.CodAnalista = drMetodizado.Item("CodAnalista")
                    If Not drMetodizado.IsNull("NombreAnalista") Then obeMetodizado.NombreAnalista = drMetodizado.Item("NombreAnalista")
                    If Not drMetodizado.IsNull("CodEjecutivo") Then obeMetodizado.CodEjecutivo = drMetodizado.Item("CodEjecutivo")
                    If Not drMetodizado.IsNull("NombreEjecutivo") Then obeMetodizado.NombreEjecutivo = drMetodizado.Item("NombreEjecutivo")
                    obeMetodizado.CodMonedaImpresion = drMetodizado.Item("CodMonedaImpresion")
                    If Not drMetodizado.IsNull("CodUsuario") Then obeMetodizado.CodUsuario = drMetodizado.Item("CodUsuario")
                    If Not drMetodizado.IsNull("NombreUsuario") Then obeMetodizado.NombreUsuario = drMetodizado.Item("NombreUsuario")
                    obeMetodizado.FecReg = drMetodizado.Item("FecReg")
                    obeMetodizado.Estado = drMetodizado.Item("Estado")
                    ' 22/01/2014 : XT5022 - JAVILA (CGI)
                    obeMetodizado.FlgBPE = drMetodizado.Item("flgBPE")
                    If Not drMetodizado.IsNull("Segmento") Then obeMetodizado.Segmento = drMetodizado.Item("Segmento")
                    'ADD XT8442 ADR 23-10-2018 INICIO
                    If Not drMetodizado.IsNull("TipoDocumentoComplementario") Then obeMetodizado.TipoDocumentoComplementario = drMetodizado.Item("TipoDocumentoComplementario")
                    If Not drMetodizado.IsNull("NumeroDocumentoComplementario") Then obeMetodizado.NumeroDocumentoComplementario = drMetodizado.Item("NumeroDocumentoComplementario")
                    'ADD XT8442 ADR 23-10-2018 FIN
                    If Not drMetodizado.IsNull("ESCovenant") Then obeMetodizado.ESCovenant = drMetodizado.Item("ESCovenant")
                    If Not drMetodizado.IsNull("CodFrecuenciaCov") Then obeMetodizado.CodFrecuenciaCov = drMetodizado.Item("CodFrecuenciaCov")

                End If
                Return (obeMetodizado)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function buscar(ByRef pobeMetodizadobus As BusinessEntity.MetodizadoBus) As DataSet Implements IMetodizado.buscar
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.buscar(pobeMetodizadobus))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function buscarClienteDuplicado(ByRef pobeMetodizadobus As BusinessEntity.MetodizadoBus, ByVal pflgBpe As Integer) As DataSet Implements IMetodizado.buscarClienteDuplicado
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.buscarClienteDuplicado(pobeMetodizadobus, pflgBpe))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeMetodizado As BusinessEntity.Metodizado) As Boolean Implements IMetodizado.agregar
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                pobeMetodizado.FecReg = DateTime.Today
                Return (odaMetodizado.agregar(pobeMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeMetodizado As BusinessEntity.Metodizado) As Boolean Implements IMetodizado.modificar
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.modificar(pobeMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete()> _
        Public Function reconciliar(ByRef pobeMetodizado As BusinessEntity.Metodizado, ByRef pobeCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean Implements IMetodizado.reconciliar
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim bolRC As Boolean = odaMetodizado.reconciliar(pobeMetodizado)
                If bolRC Then
                    For Each obePeriodo As BusinessEntity.Periodo In pobeMetodizado.Periodos
                        bolRC = odaMetodizado.modificarPeriodoCuenta(obePeriodo)
                        If Not bolRC Then Exit For
                    Next
                End If
                If bolRC Then
                    For Each obeCuentaLibre As BusinessEntity.CuentaLibre In pobeMetodizado.CuentasLibres
                        bolRC = odaMetodizado.modificarCuentaLibre(obeCuentaLibre)
                        If Not bolRC Then Exit For
                    Next
                End If

                If bolRC Then
                    If Not pobeCorridaMetodizado Is Nothing Then
                        Dim odaCorridaMetodizado As New DataAccess.CorridaMetodizado

                        If pobeCorridaMetodizado.CodCorrida = 0 Then
                            bolRC = odaCorridaMetodizado.agregar(pobeCorridaMetodizado)
                        Else
                            bolRC = odaCorridaMetodizado.modificar(pobeCorridaMetodizado)
                        End If

                    End If
                End If

                If bolRC Then
                    ContextUtil.SetComplete()
                Else
                    ContextUtil.SetAbort()
                End If
                Return (bolRC)
            Catch ex As Exception
                ContextUtil.SetAbort()
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function leerPeriodo(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As BusinessEntity.Periodo Implements IMetodizado.leerPeriodo
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim dsPeriodo As DataSet = odaMetodizado.leerPeriodo(pintCodMetodizado, pintCodPeriodo)
                Dim obePeriodo As BusinessEntity.Periodo
                If dsPeriodo.Tables(0).Rows.Count > 0 Then
                    obePeriodo = cargaPeriodo(dsPeriodo.Tables(0).Rows(0))
                End If
                Return (obePeriodo)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function leerPeriodoAnterior(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As BusinessEntity.Periodo Implements IMetodizado.leerPeriodoAnterior
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim obePeriodo As BusinessEntity.Periodo = Nothing
                Dim dsPeriodo As DataSet = odaMetodizado.leerPeriodoAnterior(pintCodMetodizado, pintCodPeriodo)
                If dsPeriodo.Tables(0).Rows.Count > 0 Then
                    obePeriodo = cargaPeriodo(dsPeriodo.Tables(0).Rows(0))
                End If
                Return (obePeriodo)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function listarPeriodo(ByVal pintCodMetodizado As Integer) As BusinessEntity.PeriodoLst Implements IMetodizado.listarPeriodo
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim dsPeriodo As DataSet = odaMetodizado.listarPeriodo(pintCodMetodizado)
                Dim obePeriodoLst As BusinessEntity.PeriodoLst = New BusinessEntity.PeriodoLst
                For Each drPeriodo As DataRow In dsPeriodo.Tables(0).Rows
                    obePeriodoLst.Add(cargaPeriodo(drPeriodo))
                Next
                Return (obePeriodoLst)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function listarPeriodo_ds(ByVal pintCodMetodizado As Integer) As DataSet Implements IMetodizado.listarPeriodo_ds
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim dsPeriodo As DataSet = odaMetodizado.listarPeriodo(pintCodMetodizado)
                Return (dsPeriodo)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function filtrarPeriodo(ByRef pobeMetodizado As BusinessEntity.Metodizado) As BusinessEntity.PeriodoLst Implements IMetodizado.filtrarPeriodo
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim dsPeriodo As DataSet = odaMetodizado.filtrarPeriodo(pobeMetodizado)
                Dim obePeriodoLst As BusinessEntity.PeriodoLst = New BusinessEntity.PeriodoLst
                For Each drPeriodo As DataRow In dsPeriodo.Tables(0).Rows
                    obePeriodoLst.Add(cargaPeriodo(drPeriodo))
                Next
                Return (obePeriodoLst)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Private Function cargaPeriodo(ByRef pdrPeriodo As DataRow) As BusinessEntity.Periodo
            Dim obePeriodo As BusinessEntity.Periodo = New BusinessEntity.Periodo
            Try
                obePeriodo.CodMetodizado = pdrPeriodo.Item("CodMetodizado")
                obePeriodo.CodPeriodo = pdrPeriodo.Item("CodPeriodo")
                obePeriodo.CodTipoEeff = pdrPeriodo.Item("CodTipoEeff")
                obePeriodo.DesTipoEeff = pdrPeriodo.Item("DesTipoEeff")
                obePeriodo.Mes = pdrPeriodo.Item("Mes")
                obePeriodo.Dia = pdrPeriodo.Item("Dia")
                obePeriodo.Anio = pdrPeriodo.Item("Anio")
                obePeriodo.FecPeriodo = pdrPeriodo.Item("FecPeriodo")
                If Not pdrPeriodo.IsNull("CodAuditor") Then obePeriodo.CodAuditor = pdrPeriodo.Item("CodAuditor")
                If Not pdrPeriodo.IsNull("Comentario") Then obePeriodo.Comentario = pdrPeriodo.Item("Comentario")
                If Not pdrPeriodo.IsNull("CodUsuario") Then obePeriodo.CodUsuario = pdrPeriodo.Item("CodUsuario")
                If Not pdrPeriodo.IsNull("NombreUsuario") Then obePeriodo.NombreUsuario = pdrPeriodo.Item("NombreUsuario")
                obePeriodo.FecReg = pdrPeriodo.Item("FecReg")
                obePeriodo.Estado = pdrPeriodo.Item("Estado")

                If pdrPeriodo.Table.Columns.Contains("CodUsuarioEnv") Then If Not pdrPeriodo.IsNull("CodUsuarioEnv") Then obePeriodo.CodUsuarioEnv = pdrPeriodo.Item("CodUsuarioEnv")
                If pdrPeriodo.Table.Columns.Contains("FecEnvio") Then If Not pdrPeriodo.IsNull("FecEnvio") Then obePeriodo.FecEnvio = pdrPeriodo.Item("FecEnvio")
                If pdrPeriodo.Table.Columns.Contains("CodUsuarioVal") Then If Not pdrPeriodo.IsNull("CodUsuarioVal") Then obePeriodo.CodUsuarioVal = pdrPeriodo.Item("CodUsuarioVal")
                If pdrPeriodo.Table.Columns.Contains("FecValidacion") Then If Not pdrPeriodo.IsNull("FecValidacion") Then obePeriodo.FecValidacion = pdrPeriodo.Item("FecValidacion")
                Return (obePeriodo)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function agregarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean Implements IMetodizado.agregarPeriodo
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                Dim dteFecPeriodo As DateTime = pobePeriodo.FecPeriodo
                pobePeriodo.Anio = dteFecPeriodo.Year()
                pobePeriodo.Mes = dteFecPeriodo.Month()
                pobePeriodo.Dia = dteFecPeriodo.Day()
                pobePeriodo.FecReg = DateTime.Today
                pobePeriodo.Estado = 1
                odaMetodizado = New DataAccess.Metodizado
                Dim bolRC As Boolean = odaMetodizado.agregarPeriodo(pobePeriodo)
                Return (bolRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function modificarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean Implements IMetodizado.modificarPeriodo
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                Dim dteFecPeriodo As DateTime = pobePeriodo.FecPeriodo
                pobePeriodo.Anio = dteFecPeriodo.Year()
                pobePeriodo.Mes = dteFecPeriodo.Month()
                pobePeriodo.Dia = dteFecPeriodo.Day()
                pobePeriodo.FecReg = DateTime.Today
                pobePeriodo.Estado = 1
                odaMetodizado = New DataAccess.Metodizado
                Dim bolRC As Boolean = odaMetodizado.modificarPeriodo(pobePeriodo)
                Return (bolRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function eliminarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean Implements IMetodizado.eliminarPeriodo
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim bolRC As Boolean = odaMetodizado.eliminarPeriodo(pobePeriodo)
                Return (bolRC)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function listarPeriodoCuenta(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As DataSet Implements IMetodizado.listarPeriodoCuenta
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.listarPeriodoCuenta(pintCodMetodizado, pintCodPeriodo))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function filtrarPeriodoCuenta(ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet Implements IMetodizado.filtrarPeriodoCuenta
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.filtrarPeriodoCuenta(pobeMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function filtrarRankingEmpresa(ByVal pintCodReporte As Integer, ByVal pstrCodCIIU As String, ByVal pstrCodGrupoEconomico As String, ByVal pdteFecPeriodo As DateTime) As DataSet Implements IMetodizado.filtrarRankingEmpresa
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.filtrarRankingEmpresa(pintCodReporte, pstrCodCIIU, pstrCodGrupoEconomico, pdteFecPeriodo))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function calcularCuentaAnalisisCabecera(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet Implements IMetodizado.calcularCuentaAnalisisCabecera
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.calcularCuentaAnalisisCabecera(pintCodMetodizado, pobeMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function calcularCuentaAnalisisTotales(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet Implements IMetodizado.calcularCuentaAnalisisTotales
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.calcularCuentaAnalisisTotales(pintCodMetodizado, pobeMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function calcularFlujoProyectado(ByVal pintCodSupuesto As Integer) As DataSet Implements IMetodizado.calcularFlujoProyectado
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.calcularFlujoProyectado(pintCodSupuesto))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function generarInformeSBS(ByVal pdteFecPeriodo As DateTime) As System.Data.DataSet Implements IMetodizado.generarInformeSBS
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.generarInformeSBS(pdteFecPeriodo))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function generarDescargaData(ByVal pdteFecPeriodo As DateTime) As System.Data.DataSet Implements IMetodizado.generarDescargaData
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.generarDescargaData(pdteFecPeriodo))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function generarDescargaDataporMoneda(ByVal pdteFecPeriodo As DateTime, ByVal pintMoneda As Integer, ByVal pintEstado As Integer, Optional ByVal pintPagina As Integer = -1, Optional ByVal pintTamanioPagina As Integer = 1) As System.Data.DataSet Implements IMetodizado.generarDescargaDataporMoneda
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.generarDescargaDataporMoneda(pdteFecPeriodo, pintMoneda, pintEstado, pintPagina, pintTamanioPagina))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function generarDescargaDataPrioridad(ByVal pdteFecPeriodo As DateTime, ByVal pintMoneda As Integer) As System.Data.DataSet Implements IMetodizado.generarDescargaDataPrioridad
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.generarDescargaDataPrioridad(pdteFecPeriodo, pintMoneda))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function filtrarConsultaParametrica(ByVal pdetFecPeriodo As DateTime, ByRef pobeCuentaAnalisis As BusinessEntity.CuentaAnalisis) As DataSet Implements IMetodizado.filtrarConsultaParametrica
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Dim strFiltro As String
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim dsClientesFiltro As DataSet = odaMetodizado.filtrarConsultaParametrica(1, pdetFecPeriodo, pobeCuentaAnalisis)
                Dim dtClientesFiltro As DataTable = dsClientesFiltro.Tables(0)

                Dim obeCuentaAnalisisLst As BusinessEntity.CuentaAnalisisLst = pobeCuentaAnalisis.CuentaAnalisisList
                For Each obeCuentaAnalisis As BusinessEntity.CuentaAnalisis In obeCuentaAnalisisLst
                    Dim strColumna As String = "ImporteCta" + obeCuentaAnalisis.CodCuentaAnalisis.ToString()
                    Dim dcImporte As DataColumn = New DataColumn(strColumna, GetType(Decimal))
                    dcImporte.AllowDBNull = True
                    dtClientesFiltro.Columns.Add(dcImporte)
                Next

                odaMetodizado = New DataAccess.Metodizado
                Dim dsCuentaAnalisisFiltro As DataSet = odaMetodizado.filtrarConsultaParametrica(2, pdetFecPeriodo, pobeCuentaAnalisis)
                Dim dtCuentaAnalisisFiltro As DataTable = dsCuentaAnalisisFiltro.Tables(0)

                For Each drRegCS As DataRow In dtClientesFiltro.Rows
                    If Not drRegCS("CUCliente") Is DBNull.Value Then
                        If CType(drRegCS("CUCliente"), String).Trim <> String.Empty Then
                            strFiltro = String.Format("CUCliente = '{0}'", drRegCS("CUCliente"))
                            For Each drRegSP As DataRow In dtCuentaAnalisisFiltro.Select(strFiltro, String.Empty)
                                Dim strColumna As String = "ImporteCta" + drRegSP("CodCuentaAnalisis").ToString()
                                drRegCS(strColumna) = drRegSP("Importe")
                            Next
                        End If
                    End If
                Next

                Return (dsClientesFiltro)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function filtrarConsultaParametricaporMoneda(ByVal pdetFecPeriodo As DateTime, ByRef pobeCuentaAnalisis As BusinessEntity.CuentaAnalisis, ByVal pintMoneda As Integer) As DataSet Implements IMetodizado.filtrarConsultaParametricaporMoneda
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Dim strFiltro As String
            Try
                odaMetodizado = New DataAccess.Metodizado
                Dim dsClientesFiltro As DataSet = odaMetodizado.filtrarConsultaParametrica(1, pdetFecPeriodo, pobeCuentaAnalisis)
                Dim dtClientesFiltro As DataTable = dsClientesFiltro.Tables(0)

                Dim obeCuentaAnalisisLst As BusinessEntity.CuentaAnalisisLst = pobeCuentaAnalisis.CuentaAnalisisList
                For Each obeCuentaAnalisis As BusinessEntity.CuentaAnalisis In obeCuentaAnalisisLst
                    Dim strColumna As String = "ImporteCta" + obeCuentaAnalisis.CodCuentaAnalisis.ToString()
                    Dim dcImporte As DataColumn = New DataColumn(strColumna, GetType(String))
                    dcImporte.AllowDBNull = True
                    dtClientesFiltro.Columns.Add(dcImporte)
                Next

                odaMetodizado = New DataAccess.Metodizado
                ' Dim dsCuentaAnalisisFiltro As DataSet = odaMetodizado.filtrarConsultaParametrica(2, pdetFecPeriodo, pobeCuentaAnalisis)
                Dim dsCuentaAnalisisFiltro As DataSet = odaMetodizado.filtrarConsultaParametricaporMoneda(3, pdetFecPeriodo, pobeCuentaAnalisis, pintMoneda)
                Dim dtCuentaAnalisisFiltro As DataTable = dsCuentaAnalisisFiltro.Tables(0)

                For Each drRegCS As DataRow In dtClientesFiltro.Rows
                    If Not drRegCS("CUCliente") Is DBNull.Value Then
                        If CType(drRegCS("CUCliente"), String).Trim <> String.Empty Then
                            strFiltro = String.Format("CUCliente = '{0}'", drRegCS("CUCliente"))
                            For Each drRegSP As DataRow In dtCuentaAnalisisFiltro.Select(strFiltro, String.Empty)
                                Dim strColumna As String = "ImporteCta" + drRegSP("CodCuentaAnalisis").ToString()
                                drRegCS(strColumna) = drRegSP("Importe")
                            Next
                        End If
                    End If
                Next

                Return (dsClientesFiltro)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        'Francisco
        <AutoComplete(True)> _
        Public Function generarResumenEjecutivo_Detalles(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16, ByVal pintCodMoneda As Int16) As DataSet Implements IMetodizado.generarResumenEjecutivo_Detalles
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.generarResumenEjecutivo_Detalles(pstrPeriodos, pintCodMetodizado, pintCodMoneda))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function generarResumenEjecutivo_Cabecera(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16, ByVal pintCodMoneda As Int16) As DataSet Implements IMetodizado.generarResumenEjecutivo_Cabecera
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.generarResumenEjecutivo_Cabecera(pstrPeriodos, pintCodMetodizado, pintCodMoneda))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function validarGeneracionResEjec(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16) As Int16 Implements IMetodizado.validarGeneracionResEjec
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.validarGeneracionResEjec(pstrPeriodos, pintCodMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function listarNotas(ByVal pintCodMetodizado As Short, ByRef pobeMetodizado As BusinessEntity.Metodizado) As System.Data.DataSet Implements IMetodizado.listarNotas
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.listarNotas(pintCodMetodizado, pobeMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        <AutoComplete(True)> _
        Public Function listarProyecciones(ByVal pintCodMetodizado As Short, ByVal strCodPeriodos As String, ByVal strCodProyecciones As String) As System.Data.DataSet Implements IMetodizado.listarProyecciones
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.listarProyecciones(pintCodMetodizado, strCodPeriodos, strCodProyecciones))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarProyeccionesCabecera(ByVal pintCodMetodizado As Short, ByVal strCodPeriodos As String, ByVal strCodProyecciones As String) As System.Data.DataSet Implements IMetodizado.listarProyeccionesCabecera
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.listarProyeccionesCabecera(pintCodMetodizado, strCodPeriodos, strCodProyecciones))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        'End Francisco

        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function buscarBPE(ByRef pobeMetodizadobus As BusinessEntity.MetodizadoBus) As DataSet Implements IMetodizado.buscarBPE
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.buscarBPE(pobeMetodizadobus))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function

        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function buscarNoBPE(ByRef pobeMetodizadobus As BusinessEntity.MetodizadoBus) As DataSet Implements IMetodizado.buscarNoBPE
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.buscarNoBPE(pobeMetodizadobus))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function

        ' 21-01-2014 : XT5022 - JAVILA (CGI)
        <AutoComplete(True)> _
       Public Function filtrarPeriodoCuentaBPE(ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet Implements IMetodizado.filtrarPeriodoCuentaBPE
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.filtrarPeriodoCuentaBPE(pobeMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function


        'ADD XT8442 ADR 02/01/2019 INICIO
        <AutoComplete(True)> _
       Public Function filtrarPeriodoCuentaCovenant(ByRef pobeMetodizado As BusinessEntity.Metodizado, ByRef pintCodMetodizado As Integer, ByRef pintCodPeriodo As Integer, ByRef pstrBusqueda As String) As DataSet Implements IMetodizado.filtrarPeriodoCuentaCovenant
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.filtrarPeriodoCuentaCovenant(pobeMetodizado, pintCodMetodizado, pintCodPeriodo, pstrBusqueda))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        'ADD XT8442 ADR 02/01/2019 FIN

        'ADD XT8633 15042019 - INICIO
        <AutoComplete(True)> _
      Public Function listarDetalleCovenant(ByRef pintFlag As Integer, ByRef pintCodMetodizado As Integer) As DataSet Implements IMetodizado.listarDetalleCovenant
            Dim odaFormulaCovenant As DataAccess.FormulaCovenant = Nothing
            Try
                odaFormulaCovenant = New DataAccess.FormulaCovenant
                Return (odaFormulaCovenant.listar(pintFlag, pintCodMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaFormulaCovenant Is Nothing) Then
                    ServicedComponent.DisposeObject(odaFormulaCovenant)
                End If
            End Try
        End Function
        Public Function listarFrecuenciaCovenant(ByVal pintCodTbl As Integer) As DataSet Implements IMetodizado.listarFrecuenciaCovenant
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.listarFrecuenciaCovenant(pintCodTbl))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        'ADD XT8633  15042019 - FIN

        'I-XT9104
        <AutoComplete(True)> _
       Public Function filtrarCovenantParametros(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet Implements IMetodizado.filtrarCovenantParametros
            Dim odaMetodizado As DataAccess.Metodizado = Nothing
            Try
                odaMetodizado = New DataAccess.Metodizado
                Return (odaMetodizado.filtrarCovenantParametros(pintCodMetodizado, pobeMetodizado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaMetodizado Is Nothing) Then
                    ServicedComponent.DisposeObject(odaMetodizado)
                End If
            End Try
        End Function
        'F-XT9104

    End Class
End Namespace