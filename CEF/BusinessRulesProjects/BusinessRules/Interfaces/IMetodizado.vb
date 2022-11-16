'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro
'Fecha Creacion:14/01/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System
Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IMetodizado
        Function leer(ByVal pintCodMetodizado As Integer) As BusinessEntity.Metodizado
        Function buscar(ByRef pobeMetodizadobus As BusinessEntity.MetodizadoBus) As DataSet
        Function buscarClienteDuplicado(ByRef pobeMetodizadobus As BusinessEntity.MetodizadoBus, ByVal pflgBpe As Integer) As DataSet
        Function agregar(ByRef pobeMetodizado As BusinessEntity.Metodizado) As Boolean
        Function modificar(ByRef pobeMetodizado As BusinessEntity.Metodizado) As Boolean
        Function reconciliar(ByRef pobeMetodizado As BusinessEntity.Metodizado, ByRef pobeCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean
        Function leerPeriodo(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As BusinessEntity.Periodo
        Function leerPeriodoAnterior(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As BusinessEntity.Periodo
        Function listarPeriodo(ByVal pintCodMetodizado As Integer) As BusinessEntity.PeriodoLst
        Function listarPeriodo_ds(ByVal pintCodMetodizado As Integer) As DataSet
        Function filtrarPeriodo(ByRef pobeMetodizado As BusinessEntity.Metodizado) As BusinessEntity.PeriodoLst
        Function agregarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
        Function modificarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
        Function eliminarPeriodo(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
        Function listarPeriodoCuenta(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As DataSet
        Function filtrarPeriodoCuenta(ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet
        Function filtrarRankingEmpresa(ByVal pintCodReporte As Integer, ByVal pstrCodCIIU As String, ByVal pstrCodGrupoEconomico As String, ByVal pdteFecPeriodo As DateTime) As DataSet
        Function calcularCuentaAnalisisCabecera(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet
        Function calcularCuentaAnalisisTotales(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet
        Function calcularFlujoProyectado(ByVal pintCodSupuesto As Integer) As DataSet
        Function generarInformeSBS(ByVal pdteFecPeriodo As DateTime) As DataSet
        Function generarDescargaData(ByVal pdteFecPeriodo As DateTime) As DataSet
        Function generarDescargaDataporMoneda(ByVal pdteFecPeriodo As DateTime, ByVal pintMoneda As Integer, ByVal pintEstado As Integer, Optional ByVal pintPagina As Integer = -1, Optional ByVal pintTamanioPagina As Integer = 1) As System.Data.DataSet
        Function generarDescargaDataPrioridad(ByVal pdteFecPeriodo As DateTime, ByVal pintMoneda As Integer) As System.Data.DataSet
        Function filtrarConsultaParametrica(ByVal pdteFecPeriodo As DateTime, ByRef pobeCuentaAnalisis As BusinessEntity.CuentaAnalisis) As DataSet
        Function filtrarConsultaParametricaporMoneda(ByVal pdteFecPeriodo As DateTime, ByRef pobeCuentaAnalisis As BusinessEntity.CuentaAnalisis, ByVal pintMoneda As Integer) As DataSet
        'Francisco
        Function generarResumenEjecutivo_Detalles(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16, ByVal pintCodMoneda As Int16) As DataSet
        Function generarResumenEjecutivo_Cabecera(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16, ByVal pintCodMoneda As Int16) As DataSet
        Function validarGeneracionResEjec(ByVal pstrPeriodos As String, ByVal pintCodMetodizado As Int16) As Int16
        'Modificado xt8633 inicio
        Function listarNotas(ByVal pintCodMetodizado As Int16, ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet
        'Modificado xt8633 Fin
        Function listarProyecciones(ByVal pintCodMetodizado As Int16, ByVal strCodPeriodos As String, ByVal strCodProyecciones As String) As DataSet
        Function listarProyeccionesCabecera(ByVal pintCodMetodizado As Int16, ByVal strCodPeriodos As String, ByVal strCodProyecciones As String) As DataSet
        'Francisco

        ' 16-01-2014 : XT5022 - JAVILA (CGI)
        Function buscarBPE(ByRef pobeMetodizadobus As BusinessEntity.MetodizadoBus) As DataSet
        Function buscarNoBPE(ByRef pobeMetodizadobus As BusinessEntity.MetodizadoBus) As DataSet

        ' 21-01-2014 : XT5022 - JAVILA (CGI)
        Function filtrarPeriodoCuentaBPE(ByRef pobeMetodizado As BusinessEntity.Metodizado) As DataSet

        'ADD XT8442 ADR 02/01/2019 INICIO
        Function filtrarPeriodoCuentaCovenant(ByRef pobeMetodizado As BusinessEntity.Metodizado, ByRef pintCodMetodizado As Integer, ByRef pintCodPeriodo As Integer, ByRef pstrBusqueda As String) As DataSet
        'XT8633 
        Function listarDetalleCovenant(ByRef pintFlag As Integer, ByRef pintCodMetodizado As Integer) As DataSet
        Function listarFrecuenciaCovenant(ByVal pintCodTbl As Integer) As DataSet

        'I-XT9104
        Function filtrarCovenantParametros(ByVal pintCodMetodizado As Integer, ByVal pobeMetodizado As BusinessEntity.Metodizado) As DataSet

    End Interface

End Namespace
