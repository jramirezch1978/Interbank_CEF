Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Web
Imports CEF.Common
Imports CEF.Common.Globals
Imports CEF.BusinessEntity
Imports CEF.BusinessRules
Imports System.Reflection


Namespace CEF.WebUI
    Partial Class rvwMetodizado
        'Inherits System.Web.UI.Page
        Inherits PageBase

        Dim crReportDocumentH As repMetodizadoH
        Dim crReportDocumentV 'As repMetodizadoV1
        'XT8633
        Dim crReportDocumentH2 As repMetodizadoH2

        'Protected WithEvents CrystalReportViewer2 As CrystalReportViewer
        'Protected WithEvents CrystalReportViewer3 As CrystalReportViewer
        Private nombreReporte As String = "Reporte"

#Region " Código generado por el Diseñador de Web Forms "

        'El Diseñador de Web Forms requiere esta llamada.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub

        'NOTA: el Diseñador de Web Forms necesita la siguiente declaración del marcador de posición.
        'No se debe eliminar o mover.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: el Diseñador de Web Forms requiere esta llamada de método
            'No la modifique con el editor de código.
            InitializeComponent()

            MostrarReporte()
            'Exportar(5) '4 Excel    5 PDF
            'UnirExportar(5)

        End Sub

#End Region

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        End Sub

        Private Sub MostrarReporte()
            Dim intCodMetodizado As Integer = Int32.Parse(Request.Params("intCodMetodizado"))
            Dim strPeriodoFiltrado As String = Request.Params("strPeriodoFiltrado")
            's23006 10/07/12
            Dim strPeriodoProyecciones As String = Request.Params("strCodProyecciones")
            's23006
            Dim strChkCovenant As Boolean = Request.Params("strChkCovenant") 'Agregado xt8633

            Dim obrMetodizado As BusinessRules.Metodizado = New BusinessRules.Metodizado
            Dim dsCuentaAnalisisTotales As DataSet

            Dim obeMetodizado As BusinessEntity.Metodizado = New BusinessEntity.Metodizado
            Dim esBPE As Integer = 0
            Try
                Dim SQL As String
                Dim subreport As New ReportDocument
                Dim obePeriodoLst As PeriodoLst = New BusinessEntity.PeriodoLst
                Dim arrCodPeriodo As String() = strPeriodoFiltrado.Split(";")


                '16/05/2014- agregado rquispe : obtenemos el metodizado para saber a que tipo de banca pertenece
                Dim obeMetodizadoInfo As BusinessEntity.Metodizado
                obeMetodizadoInfo = obrMetodizado.leer(intCodMetodizado)

                If Not obeMetodizadoInfo Is Nothing Then
                    If obeMetodizadoInfo.FlgBPE = 2 Then esBPE = 1
                End If
                'fin agregado--------------------------------

                '<JC>
                'Dim intCodCorridaMetodizado As Integer = fRetornaCodCorridaMetodizado(intCodMetodizado, arrCodPeriodo)
                '</JC>
                For Each strCodPeriodo As String In arrCodPeriodo
                    Dim obePeriodo As BusinessEntity.Periodo = New BusinessEntity.Periodo
                    obePeriodo.CodMetodizado = intCodMetodizado
                    obePeriodo.CodPeriodo = Int32.Parse(strCodPeriodo)
                    obePeriodoLst.Add(obePeriodo)
                Next

                obeMetodizado.CodMetodizado = intCodMetodizado
                obeMetodizado.Periodos = obePeriodoLst

                ''<JC>
                'If intCodCorridaMetodizado > 0 Then
                '    Dim obePeriodoCuentaAnalisis As New BusinessEntity.PeriodoCuentaAnalisis
                '    obePeriodoCuentaAnalisis.Flag = 2
                '    obePeriodoCuentaAnalisis.Codmetodizado = intCodMetodizado
                '    obePeriodoCuentaAnalisis.Codcorrida = intCodCorridaMetodizado

                '    Dim obiPeriodoCuentaAnalisis As BusinessInterface.IPeriodoCuentaAnalisis
                '    Dim obrPeriodoCuentaAnalisis As New BusinessRules.PeriodoCuentaAnalisis
                '    obiPeriodoCuentaAnalisis = CType(obrPeriodoCuentaAnalisis, BusinessInterface.IPeriodoCuentaAnalisis)
                '    dsCuentaAnalisisTotales = obiPeriodoCuentaAnalisis.listar(obePeriodoCuentaAnalisis)
                'Else
                '    dsCuentaAnalisisTotales = obiMetodizado.calcularCuentaAnalisisTotales(intCodMetodizado, obeMetodizado)
                'End If
                ''</JC>

                dsCuentaAnalisisTotales = obrMetodizado.calcularCuentaAnalisisTotales(intCodMetodizado, obeMetodizado)
                dsCuentaAnalisisTotales.Tables(0).TableName = "CuentaAnalisisTotales"

                Dim dsCuentaAnalisisCabecera As DataSet = obrMetodizado.calcularCuentaAnalisisCabecera(intCodMetodizado, obeMetodizado)
                dsCuentaAnalisisCabecera.Tables(0).TableName = "CuentaAnalisisCabecera"

                'I-XT9104
                Dim dsCovenantParametro As DataSet = obrMetodizado.filtrarCovenantParametros(intCodMetodizado, obeMetodizado)
                dsCovenantParametro.Tables(0).TableName = "CovenantCabecera"
                dsCovenantParametro.Tables(1).TableName = "CovenantParametro"
                'F-XT9104


                'XT8633 INICIO
                Dim dsCovenantFormula As DataSet = obrMetodizado.listarDetalleCovenant(1, intCodMetodizado)
                dsCovenantFormula.Tables(0).TableName = "CovenantFormula"
                'XT8633 FIN

                'If Not dsCuentaAnalisisTotales Is Nothing Then
                If dsCuentaAnalisisTotales.Tables(0).Rows.Count > 0 Then
                    dsCuentaAnalisisTotales.Tables.Add(dsCuentaAnalisisCabecera.Tables("CuentaAnalisisCabecera").Copy)

                    crReportDocumentH = New repMetodizadoH
                    crReportDocumentH2 = New repMetodizadoH2

                    If esBPE = 1 Then
                        crReportDocumentV = New repMetodizadoV_BPE
                    Else
                        crReportDocumentV = New repMetodizadoV
                    End If

                    '*******************************************
                    'REPORTE 1
                    '*******************************************

                    'EEFF ESTADO DE GANANCIAS Y PERDIDAS
                    SQL = "{CuentaAnalisisTotales.CodAnalisis} = 2 "
                    SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 2"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").RecordSelectionFormula = SQL
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").SetDataSource(dsCuentaAnalisisTotales)

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TDescripcion1").Text = "{CuentaAnalisisCabecera.Descripcion1}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TEstado1").Text = "{CuentaAnalisisCabecera.Estado1}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TImporte1").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo1})"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TPorcentaje1").Text = "'%'"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Porcentaje1").Text = "{CuentaAnalisisTotales.Porcentaje1}"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TDescripcion2").Text = "{CuentaAnalisisCabecera.Descripcion2}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TEstado2").Text = "{CuentaAnalisisCabecera.Estado2}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TImporte2").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo2})"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TPorcentaje2").Text = "'%'"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Porcentaje2").Text = "{CuentaAnalisisTotales.Porcentaje2}"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TDescripcion3").Text = "{CuentaAnalisisCabecera.Descripcion3}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TEstado3").Text = "{CuentaAnalisisCabecera.Estado3}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TImporte3").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo3})"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TPorcentaje3").Text = "'%'"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Porcentaje3").Text = "{CuentaAnalisisTotales.Porcentaje3}"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TDescripcion4").Text = "{CuentaAnalisisCabecera.Descripcion4}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TEstado4").Text = "{CuentaAnalisisCabecera.Estado4}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TImporte4").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo4})"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TPorcentaje4").Text = "if isnull({CuentaAnalisisCabecera.Descripcion4})=false then '%'"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Porcentaje4").Text = "{CuentaAnalisisTotales.Porcentaje4}"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TDescripcion5").Text = "{CuentaAnalisisCabecera.Descripcion5}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TEstado5").Text = "{CuentaAnalisisCabecera.Estado5}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TImporte5").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo5})"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TPorcentaje5").Text = "'%'"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Importe5").Text = "{CuentaAnalisisTotales.Importe5}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Porcentaje5").Text = "{CuentaAnalisisTotales.Porcentaje5}"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TVariacion2").Text = "Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo2})),2) +  '-'  + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo1})),2)"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TVariacion3").Text = "Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo3})),2) +  '-'  + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo2})),2)"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TVariacion4").Text = "Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo5})),2) +  '-'  + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo3})),2)"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("TVariacion5").Text = "Mid (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo5})),4,2) + '-' + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo5})),2) + ' / ' + Mid (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo4})),4,2) + '-' + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo4})),2)"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Variacion2").Text = "{CuentaAnalisisTotales.Variacion2}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Variacion3").Text = "{CuentaAnalisisTotales.Variacion3}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Variacion4").Text = "{CuentaAnalisisTotales.Variacion4}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Variacion5").Text = "{CuentaAnalisisTotales.Variacion5}"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Cagr").Text = "{CuentaAnalisisTotales.Cagr}"

                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("Ultimos12").Text = "{CuentaAnalisisTotales.Ultimos12}"
                    crReportDocumentH.Subreports("EEFF_Sub_EstadodeGananciasyPerdidas").DataDefinition.FormulaFields("PUltimos12").Text = "{CuentaAnalisisTotales.PUltimos12}"

                    subreport = crReportDocumentH.OpenSubreport("EEFF_Sub_EstadodeGananciasyPerdidas")
                    'Crystalreportviewer1.ReportSource = subreport

                    's23006 09/07
                    'PROYECCIONES
                    Dim dsProyecciones As DataSet = obrMetodizado.listarProyecciones(intCodMetodizado, strPeriodoFiltrado, strPeriodoProyecciones)
                    Dim dsProyeccionesCab As DataSet = obrMetodizado.listarProyeccionesCabecera(intCodMetodizado, strPeriodoFiltrado, strPeriodoProyecciones)

                    If (Not dsProyecciones Is Nothing) Then
                        dsProyecciones.Tables(0).TableName = "ProyeccionDetalles"
                        dsCuentaAnalisisTotales.Tables.Add(dsProyecciones.Tables("ProyeccionDetalles").Copy)
                    End If

                    If (Not dsProyeccionesCab Is Nothing) Then
                        dsProyeccionesCab.Tables(0).TableName = "ProyeccionCabecera"
                        dsCuentaAnalisisTotales.Tables.Add(dsProyeccionesCab.Tables("ProyeccionCabecera").Copy)
                    End If

                    crReportDocumentH.Subreports("Proyecciones").SetDataSource(dsCuentaAnalisisTotales)

                    subreport = crReportDocumentH.OpenSubreport("Proyecciones")


                    'EEFF BALANCE GENERAL
                    SQL = "{CuentaAnalisisTotales.CodAnalisis} = 2 "
                    SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 1"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").RecordSelectionFormula = SQL
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").SetDataSource(dsCuentaAnalisisTotales)

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("RazonSocial").Text = "UpperCase({CuentaAnalisisCabecera.RazonSocial})"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("CifrasEn").Text = "{CuentaAnalisisCabecera.CifrasEn}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Auditores").Text = "{CuentaAnalisisCabecera.Auditores}"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TDescripcion1").Text = "{CuentaAnalisisCabecera.Descripcion1}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TEstado1").Text = "{CuentaAnalisisCabecera.Estado1}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TImporte1").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo1})"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TPorcentaje1").Text = "'%'"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Porcentaje1").Text = "{CuentaAnalisisTotales.Porcentaje1}"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TDescripcion2").Text = "{CuentaAnalisisCabecera.Descripcion2}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TEstado2").Text = "{CuentaAnalisisCabecera.Estado2}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TImporte2").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo2})"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TPorcentaje2").Text = "'%'"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Porcentaje2").Text = "{CuentaAnalisisTotales.Porcentaje2}"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TDescripcion3").Text = "{CuentaAnalisisCabecera.Descripcion3}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TEstado3").Text = "{CuentaAnalisisCabecera.Estado3}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TImporte3").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo3})"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TPorcentaje3").Text = "'%'"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Porcentaje3").Text = "{CuentaAnalisisTotales.Porcentaje3}"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TDescripcion4").Text = "{CuentaAnalisisCabecera.Descripcion4}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TEstado4").Text = "{CuentaAnalisisCabecera.Estado4}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TImporte4").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo4})"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TPorcentaje4").Text = "if isnull({CuentaAnalisisCabecera.Descripcion4})=false then '%'"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Porcentaje4").Text = "{CuentaAnalisisTotales.Porcentaje4}"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TDescripcion5").Text = "{CuentaAnalisisCabecera.Descripcion5}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TEstado5").Text = "{CuentaAnalisisCabecera.Estado5}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TImporte5").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo5})"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TPorcentaje5").Text = "'%'"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Importe5").Text = "{CuentaAnalisisTotales.Importe5}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Porcentaje5").Text = "{CuentaAnalisisTotales.Porcentaje5}"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TVariacion2").Text = "Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo2})),2) +  '-'  + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo1})),2)"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TVariacion3").Text = "Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo3})),2) +  '-'  + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo2})),2)"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TVariacion4").Text = "Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo5})),2) +  '-'  + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo3})),2)"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("TVariacion5").Text = "Mid (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo5})),4,2) + '-' + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo5})),2) + ' / ' + Mid (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo4})),4,2) + '-' + Right (CStr(CDate ({CuentaAnalisisCabecera.FecPeriodo4})),2)"

                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Variacion2").Text = "{CuentaAnalisisTotales.Variacion2}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Variacion3").Text = "{CuentaAnalisisTotales.Variacion3}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Variacion4").Text = "{CuentaAnalisisTotales.Variacion4}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Variacion5").Text = "{CuentaAnalisisTotales.Variacion5}"
                    crReportDocumentH.Subreports("EEFF_Sub_BalanceGeneral").DataDefinition.FormulaFields("Cagr").Text = "{CuentaAnalisisTotales.Cagr}"

                    subreport = crReportDocumentH.OpenSubreport("EEFF_Sub_BalanceGeneral")

                    'Crystalreportviewer1.ReportSource = subreport

                    '--Responsabilidad Contingente
                    SQL = "{CuentaAnalisisTotales.CodAnalisis} = 1 "
                    SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 3 "
                    SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}>=706 "
                    SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}<=710 "
                    crReportDocumentH.Subreports("ResponsabilidadContingente").RecordSelectionFormula = SQL
                    crReportDocumentH.Subreports("ResponsabilidadContingente").SetDataSource(dsCuentaAnalisisTotales)

                    crReportDocumentH.Subreports("ResponsabilidadContingente").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    crReportDocumentH.Subreports("ResponsabilidadContingente").DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    crReportDocumentH.Subreports("ResponsabilidadContingente").DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    crReportDocumentH.Subreports("ResponsabilidadContingente").DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    crReportDocumentH.Subreports("ResponsabilidadContingente").DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"
                    crReportDocumentH.Subreports("ResponsabilidadContingente").DataDefinition.FormulaFields("Importe5").Text = "{CuentaAnalisisTotales.Importe5}"

                    subreport = crReportDocumentH.OpenSubreport("ResponsabilidadContingente")

                    '*******************************************
                    'REPORTE 2
                    '*******************************************

                    'RATIOS FINANCIEROS
                    SQL = "{CuentaAnalisisTotales.CodAnalisis}  = 99 "
                    SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 99 "
                    crReportDocumentV.Subreports("RatiosFinancieros").RecordSelectionFormula = SQL
                    crReportDocumentV.Subreports("RatiosFinancieros").SetDataSource(dsCuentaAnalisisTotales)

                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TDescripcion1").Text = "{CuentaAnalisisCabecera.Descripcion1}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TEstado1").Text = "{CuentaAnalisisCabecera.Estado1}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TImporte1").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo1})"
                    'crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("Porcentaje1").Text = "{CuentaAnalisisTotales.Porcentaje1}"

                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TDescripcion2").Text = "{CuentaAnalisisCabecera.Descripcion2}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TEstado2").Text = "{CuentaAnalisisCabecera.Estado2}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TImporte2").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo2})"
                    'crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("Porcentaje2").Text = "{CuentaAnalisisTotales.Porcentaje2}"

                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TDescripcion3").Text = "{CuentaAnalisisCabecera.Descripcion3}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TEstado3").Text = "{CuentaAnalisisCabecera.Estado3}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TImporte3").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo3})"
                    'crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("Porcentaje3").Text = "{CuentaAnalisisTotales.Porcentaje3}"

                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TDescripcion4").Text = "{CuentaAnalisisCabecera.Descripcion4}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TEstado4").Text = "{CuentaAnalisisCabecera.Estado4}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TImporte4").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo4})"
                    'crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("Porcentaje4").Text = "{CuentaAnalisisTotales.Porcentaje4}"


                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TDescripcion5").Text = "{CuentaAnalisisCabecera.Descripcion5}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TEstado5").Text = "{CuentaAnalisisCabecera.Estado5}"
                    crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("TImporte5").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo5})"
                    'crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("Porcentaje5").Text = "{CuentaAnalisisTotales.Porcentaje5}"

                    'crReportDocumentV.Subreports("RatiosFinancieros").DataDefinition.FormulaFields("PUltimos12").Text = "{CuentaAnalisisTotales.PUltimos12}"

                    subreport = crReportDocumentV.OpenSubreport("RatiosFinancieros")

                    'RATIOS FINANCIEROS - DEVALUACION
                    SQL = "{CuentaAnalisisTotales.CodAnalisis}  = 3 "
                    SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 9 "
                    SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis} = 423 "
                    'SQL &= "OR {CuentaAnalisisTotales.CodCuentaAnalisis} = 254 "
                    crReportDocumentV.Subreports("RatiosFinancieros_Devaluacion").RecordSelectionFormula = SQL
                    crReportDocumentV.Subreports("RatiosFinancieros_Devaluacion").SetDataSource(dsCuentaAnalisisTotales)

                    crReportDocumentV.Subreports("RatiosFinancieros_Devaluacion").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    subreport = crReportDocumentV.OpenSubreport("RatiosFinancieros_Devaluacion")

                    'RATIOS FINANCIEROS - GRADO EXPOSICION
                    'SQL = "{CuentaAnalisisTotales.CodAnalisis}  = 3 "
                    'SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 9 "
                    'SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis} = 422 "
                    'crReportDocumentV.Subreports("RatiosFinancieros_GradoExposicion").RecordSelectionFormula = SQL
                    'crReportDocumentV.Subreports("RatiosFinancieros_GradoExposicion").SetDataSource(dsCuentaAnalisisTotales)

                    'crReportDocumentV.Subreports("RatiosFinancieros_GradoExposicion").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    'subreport = crReportDocumentV.OpenSubreport("RatiosFinancieros_GradoExposicion")

                    'NOTAS ESTADO GANANCIAS Y PERDIDAS
                    Dim dsNotas As DataSet = obrMetodizado.listarNotas(intCodMetodizado, obeMetodizado)
                    If (Not dsNotas Is Nothing) Then
                        dsNotas.Tables(0).TableName = "Notas"
                        dsCuentaAnalisisTotales.Tables.Add(dsNotas.Tables("Notas").Copy)
                    End If

                    SQL = "{Notas.CodEEFF} = 2 "
                    crReportDocumentV.Subreports("SNotasEGYP").RecordSelectionFormula = SQL
                    crReportDocumentV.Subreports("SNotasEGYP").SetDataSource(dsCuentaAnalisisTotales)
                    subreport = crReportDocumentV.OpenSubreport("SNotasEGYP")

                    'NOTAS BALANCE GENERAL
                    SQL = "{Notas.CodEEFF} = 1 "
                    crReportDocumentV.Subreports("SNotasBalance").RecordSelectionFormula = SQL
                    crReportDocumentV.Subreports("SNotasBalance").SetDataSource(dsCuentaAnalisisTotales)
                    subreport = crReportDocumentV.OpenSubreport("SNotasBalance")

                    'EEFF RECONCILIACION PATRIMONIO Y ACTIVO FIJO
                    SQL = "{CuentaAnalisisTotales.CodAnalisis} = 2 "
                    SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 3"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").RecordSelectionFormula = SQL
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").SetDataSource(dsCuentaAnalisisTotales)

                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("RazonSocial").Text = "UpperCase({CuentaAnalisisCabecera.RazonSocial})"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("CifrasEn").Text = "{CuentaAnalisisCabecera.CifrasEn}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("Auditores").Text = "{CuentaAnalisisCabecera.Auditores}"

                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TDescripcion1").Text = "{CuentaAnalisisCabecera.Descripcion1}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TEstado1").Text = "{CuentaAnalisisCabecera.Estado1}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TImporte1").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo1})"

                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TDescripcion2").Text = "{CuentaAnalisisCabecera.Descripcion2}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TEstado2").Text = "{CuentaAnalisisCabecera.Estado2}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TImporte2").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo2})"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"

                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TDescripcion3").Text = "{CuentaAnalisisCabecera.Descripcion3}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TEstado3").Text = "{CuentaAnalisisCabecera.Estado3}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TImporte3").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo3})"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"

                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TDescripcion4").Text = "{CuentaAnalisisCabecera.Descripcion4}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TEstado4").Text = "{CuentaAnalisisCabecera.Estado4}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TImporte4").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo4})"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"

                    's23006
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TDescripcion5").Text = "{CuentaAnalisisCabecera.Descripcion5}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TEstado5").Text = "{CuentaAnalisisCabecera.Estado5}"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("TImporte5").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo5})"
                    crReportDocumentV.Subreports("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo").DataDefinition.FormulaFields("Importe5").Text = "{CuentaAnalisisTotales.Importe5}"


                    subreport = crReportDocumentV.OpenSubreport("EEFF_Sub_ReconciliacionPatrimonioyActivoFijo")
                    'Crystalreportviewer1.ReportSource = subreport


                    'INF. CUANTITATIVA. ESTADO DE GANANCIAS Y PERDIDAS (8)1
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 2"
                    ''crReportDocumentV.Subreports.Item(1).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(1).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("RazonSocial").Text = "{CuentaAnalisisCabecera.RazonSocial}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("CifrasEn").Text = "{CuentaAnalisisCabecera.CifrasEn}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Auditores").Text = "{CuentaAnalisisCabecera.Auditores}"

                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TDescripcion1").Text = "{CuentaAnalisisCabecera.Descripcion1}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TEstado1").Text = "{CuentaAnalisisCabecera.Estado1}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TImporte1").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo1})"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TPorcentaje1").Text = "'%'"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Porcentaje1").Text = "{CuentaAnalisisTotales.Porcentaje1}"

                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TDescripcion2").Text = "{CuentaAnalisisCabecera.Descripcion2}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TEstado2").Text = "{CuentaAnalisisCabecera.Estado2}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TImporte2").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo2})"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TPorcentaje2").Text = "'%'"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Porcentaje2").Text = "{CuentaAnalisisTotales.Porcentaje2}"

                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TDescripcion3").Text = "{CuentaAnalisisCabecera.Descripcion3}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TEstado3").Text = "{CuentaAnalisisCabecera.Estado3}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TImporte3").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo3})"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TPorcentaje3").Text = "'%'"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Porcentaje3").Text = "{CuentaAnalisisTotales.Porcentaje3}"

                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TDescripcion4").Text = "{CuentaAnalisisCabecera.Descripcion4}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TEstado4").Text = "{CuentaAnalisisCabecera.Estado4}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TImporte4").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo4})"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("TPorcentaje4").Text = "'%'"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"
                    ''crReportDocumentV.Subreports.Item(1).DataDefinition.FormulaFields("Porcentaje4").Text = "{CuentaAnalisisTotales.Porcentaje4}"

                    ''subreport = crReportDocumentV.OpenSubreport(1)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. BALANCE GENERAL (5)0
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 1"
                    ''crReportDocumentV.Subreports.Item(0).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(0).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("TPorcentaje1").Text = "'%'"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("Porcentaje1").Text = "{CuentaAnalisisTotales.Porcentaje1}"

                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("TPorcentaje2").Text = "'%'"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("Porcentaje2").Text = "{CuentaAnalisisTotales.Porcentaje2}"

                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("TPorcentaje3").Text = "'%'"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("Porcentaje3").Text = "{CuentaAnalisisTotales.Porcentaje3}"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("TPorcentaje4").Text = "'%'"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"
                    ''crReportDocumentV.Subreports.Item(0).DataDefinition.FormulaFields("Porcentaje4").Text = "{CuentaAnalisisTotales.Porcentaje4}"

                    ''subreport = crReportDocumentV.OpenSubreport(0)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. FLUJO DE FONDOS (6)2
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 8"
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}>=216 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}<=218 "
                    ''crReportDocumentV.Subreports.Item(2).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(2).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(2).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    ''crReportDocumentV.Subreports.Item(2).DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    ''crReportDocumentV.Subreports.Item(2).DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    ''crReportDocumentV.Subreports.Item(2).DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    ''crReportDocumentV.Subreports.Item(2).DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"
                    ''subreport = crReportDocumentV.OpenSubreport(2)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. FLUJO DE FONDOS 2(7)3
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 8"
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}>=219 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}<=223 "
                    ''crReportDocumentV.Subreports.Item(3).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(3).SetDataSource(dsCuentaAnalisisTotales)

                    ''subreport = crReportDocumentV.OpenSubreport(3)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. RATIOS FINANCIEROS (9)4
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 9 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}>=232 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}<=236 "
                    ''crReportDocumentV.Subreports.Item(4).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(4).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(4).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    ''crReportDocumentV.Subreports.Item(4).DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    ''crReportDocumentV.Subreports.Item(4).DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    ''crReportDocumentV.Subreports.Item(4).DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    ''crReportDocumentV.Subreports.Item(4).DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"

                    ''subreport = crReportDocumentV.OpenSubreport(4)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. RATIOS FINANCIEROS 2(10)5
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 9 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}>=237 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}<=246 "
                    ''crReportDocumentV.Subreports.Item(5).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(5).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(5).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    ''crReportDocumentV.Subreports.Item(5).DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    ''crReportDocumentV.Subreports.Item(5).DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    ''crReportDocumentV.Subreports.Item(5).DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    ''crReportDocumentV.Subreports.Item(5).DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"

                    ''subreport = crReportDocumentV.OpenSubreport(5)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. RATIOS FINANCIEROS 3(11)6
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 9 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}>=247 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}<=251 "
                    ''crReportDocumentV.Subreports.Item(6).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(6).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(6).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    ''crReportDocumentV.Subreports.Item(6).DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    ''crReportDocumentV.Subreports.Item(6).DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    ''crReportDocumentV.Subreports.Item(6).DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    ''crReportDocumentV.Subreports.Item(6).DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"

                    ''subreport = crReportDocumentV.OpenSubreport(6)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. RATIOS FINANCIEROS 4(12)7
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 9 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}>=252 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}<=253 "
                    ''crReportDocumentV.Subreports.Item(7).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(7).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(7).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    ''crReportDocumentV.Subreports.Item(7).DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    ''crReportDocumentV.Subreports.Item(7).DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    ''crReportDocumentV.Subreports.Item(7).DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    ''crReportDocumentV.Subreports.Item(7).DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"

                    ''subreport = crReportDocumentV.OpenSubreport(7)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. RATIOS FINANCIEROS 5(13)8
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 9 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}=254 "
                    ''SQL &= "OR {CuentaAnalisisTotales.CodCuentaAnalisis}=423 "
                    ''crReportDocumentV.Subreports.Item(8).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(8).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(8).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    ''crReportDocumentV.Subreports.Item(8).DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"
                    ''crReportDocumentV.Subreports.Item(8).DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"
                    ''crReportDocumentV.Subreports.Item(8).DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"
                    ''crReportDocumentV.Subreports.Item(8).DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"

                    ''subreport = crReportDocumentV.OpenSubreport(8)
                    ''Crystalreportviewer1.ReportSource = subreport

                    'INF. CUANTITATIVA. RATIOS FINANCIEROS 6(14)9
                    ''SQL = "{CuentaAnalisisTotales.CodAnalisis} = 3 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 9 "
                    ''SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis}=422 "
                    ''crReportDocumentV.Subreports.Item(9).RecordSelectionFormula = SQL
                    ''crReportDocumentV.Subreports.Item(9).SetDataSource(dsCuentaAnalisisTotales)

                    ''crReportDocumentV.Subreports.Item(9).DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"
                    ''crReportDocumentV.Subreports.Item(9).DataDefinition.FormulaFields("Exposicion1").Text = "{CuentaAnalisisTotales.Exposicion1}"
                    ''crReportDocumentV.Subreports.Item(9).DataDefinition.FormulaFields("Exposicion2").Text = "{CuentaAnalisisTotales.Exposicion2}"
                    ''crReportDocumentV.Subreports.Item(9).DataDefinition.FormulaFields("Exposicion3").Text = "{CuentaAnalisisTotales.Exposicion3}"
                    ''crReportDocumentV.Subreports.Item(9).DataDefinition.FormulaFields("Exposicion4").Text = "{CuentaAnalisisTotales.Exposicion4}"

                    ''subreport = crReportDocumentV.OpenSubreport(9)
                    ''Crystalreportviewer1.ReportSource = subreport

                    ''EEFF FUENTES Y USOS DE FONDOS
                    SQL = "{CuentaAnalisisTotales.CodAnalisis} = 2 "
                    SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 7"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").RecordSelectionFormula = SQL
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").SetDataSource(dsCuentaAnalisisTotales)

                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("RazonSocial").Text = "UpperCase({CuentaAnalisisCabecera.RazonSocial})"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("CifrasEn").Text = "{CuentaAnalisisCabecera.CifrasEn}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("Auditores").Text = "{CuentaAnalisisCabecera.Auditores}"

                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TDescripcion1").Text = "{CuentaAnalisisCabecera.Descripcion1}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TEstado1").Text = "{CuentaAnalisisCabecera.Estado1}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TImporte1").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo1})"

                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TDescripcion2").Text = "{CuentaAnalisisCabecera.Descripcion2}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TEstado2").Text = "{CuentaAnalisisCabecera.Estado2}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TImporte2").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo2})"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"

                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TDescripcion3").Text = "{CuentaAnalisisCabecera.Descripcion3}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TEstado3").Text = "{CuentaAnalisisCabecera.Estado3}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TImporte3").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo3})"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"

                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TDescripcion4").Text = "{CuentaAnalisisCabecera.Descripcion4}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TEstado4").Text = "{CuentaAnalisisCabecera.Estado4}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TImporte4").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo4})"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"

                    's23006
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TDescripcion5").Text = "{CuentaAnalisisCabecera.Descripcion5}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TEstado5").Text = "{CuentaAnalisisCabecera.Estado5}"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("TImporte5").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo5})"
                    crReportDocumentV.Subreports("EEFF_Sub_FuentesyUsosdeFondos").DataDefinition.FormulaFields("Importe5").Text = "{CuentaAnalisisTotales.Importe5}"

                    subreport = crReportDocumentV.OpenSubreport("EEFF_Sub_FuentesyUsosdeFondos")
                    'Crystalreportviewer1.ReportSource = subreport

                    ''EEFF DESGLOSE DE CUENTAS IMPORTANTES
                    SQL = "{CuentaAnalisisTotales.CodAnalisis} = 2 "
                    SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 6"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").RecordSelectionFormula = SQL
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").SetDataSource(dsCuentaAnalisisTotales)

                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("RazonSocial").Text = "UpperCase({CuentaAnalisisCabecera.RazonSocial})"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("CifrasEn").Text = "{CuentaAnalisisCabecera.CifrasEn}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("Auditores").Text = "{CuentaAnalisisCabecera.Auditores}"

                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TDescripcion1").Text = "{CuentaAnalisisCabecera.Descripcion1}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TEstado1").Text = "{CuentaAnalisisCabecera.Estado1}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TImporte1").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo1})"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("Importe1").Text = "{CuentaAnalisisTotales.Importe1}"

                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TDescripcion2").Text = "{CuentaAnalisisCabecera.Descripcion2}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TEstado2").Text = "{CuentaAnalisisCabecera.Estado2}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TImporte2").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo2})"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("Importe2").Text = "{CuentaAnalisisTotales.Importe2}"

                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TDescripcion3").Text = "{CuentaAnalisisCabecera.Descripcion3}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TEstado3").Text = "{CuentaAnalisisCabecera.Estado3}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TImporte3").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo3})"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("Importe3").Text = "{CuentaAnalisisTotales.Importe3}"

                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TDescripcion4").Text = "{CuentaAnalisisCabecera.Descripcion4}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TEstado4").Text = "{CuentaAnalisisCabecera.Estado4}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TImporte4").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo4})"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("Importe4").Text = "{CuentaAnalisisTotales.Importe4}"

                    's23006
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TDescripcion5").Text = "{CuentaAnalisisCabecera.Descripcion5}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TEstado5").Text = "{CuentaAnalisisCabecera.Estado5}"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("TImporte5").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo5})"
                    crReportDocumentV.Subreports("EEFF_Sub_DesglosedeCuentasImportantes").DataDefinition.FormulaFields("Importe5").Text = "{CuentaAnalisisTotales.Importe5}"

                    subreport = crReportDocumentV.OpenSubreport("EEFF_Sub_DesglosedeCuentasImportantes")
                    'Crystalreportviewer1.ReportSource = subreport

                    If esBPE = 0 Then

                        'Riesgo Camb FUENTES Y USOS DE FONDOS POR MONEDA
                        SQL = "{CuentaAnalisisTotales.CodAnalisis} = 4 "
                        SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 7 "
                        SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis} >= 255 "
                        SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis} <= 300 "
                        SQL &= "OR {CuentaAnalisisTotales.CodCuentaAnalisis} >= 500 "
                        SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis} <= 519 "
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").RecordSelectionFormula = SQL
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").SetDataSource(dsCuentaAnalisisTotales)

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("RazonSocial").Text = "UpperCase({CuentaAnalisisCabecera.RazonSocial})"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("CifrasEn").Text = "{CuentaAnalisisCabecera.CifrasEn}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Auditores").Text = "{CuentaAnalisisCabecera.Auditores}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TImporte1").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo1})"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TEstado1").Text = "{CuentaAnalisisCabecera.Estado1}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TSoles1").Text = "'Soles'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TDolares1").Text = "'Dolares'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Soles1").Text = "{CuentaAnalisisTotales.Soles1}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Dolares1").Text = "{CuentaAnalisisTotales.Dolares1}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TImporte2").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo2})"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TEstado2").Text = "{CuentaAnalisisCabecera.Estado2}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TSoles2").Text = "'Soles'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TDolares2").Text = "'Dolares'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Soles2").Text = "{CuentaAnalisisTotales.Soles2}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Dolares2").Text = "{CuentaAnalisisTotales.Dolares2}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TImporte3").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo3})"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TEstado3").Text = "{CuentaAnalisisCabecera.Estado3}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TSoles3").Text = "'Soles'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TDolares3").Text = "'Dolares'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Soles3").Text = "{CuentaAnalisisTotales.Soles3}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Dolares3").Text = "{CuentaAnalisisTotales.Dolares3}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TImporte4").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo4})"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TEstado4").Text = "{CuentaAnalisisCabecera.Estado4}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TSoles4").Text = "'Soles'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TDolares4").Text = "'Dolares'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Soles4").Text = "{CuentaAnalisisTotales.Soles4}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Dolares4").Text = "{CuentaAnalisisTotales.Dolares4}"

                        's23006
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TImporte5").Text = "CDate ({CuentaAnalisisCabecera.FecPeriodo5})"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TEstado5").Text = "{CuentaAnalisisCabecera.Estado5}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TSoles5").Text = "'Soles'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("TDolares5").Text = "'Dolares'"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Soles5").Text = "{CuentaAnalisisTotales.Soles5}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda").DataDefinition.FormulaFields("Dolares5").Text = "{CuentaAnalisisTotales.Dolares5}"

                        subreport = crReportDocumentV.OpenSubreport("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda")
                        'Crystalreportviewer1.ReportSource = subreport

                        ''Riesgo Camb FUENTES Y USOS DE FONDOS POR MONEDA 2
                        SQL = "{CuentaAnalisisTotales.CodAnalisis} = 4 "
                        SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 7 "
                        SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis} = 424 "
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").RecordSelectionFormula = SQL
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").SetDataSource(dsCuentaAnalisisTotales)

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Soles1").Text = "{CuentaAnalisisTotales.Soles1}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Dolares1").Text = "{CuentaAnalisisTotales.Dolares1}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Soles2").Text = "{CuentaAnalisisTotales.Soles2}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Dolares2").Text = "{CuentaAnalisisTotales.Dolares2}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Soles3").Text = "{CuentaAnalisisTotales.Soles3}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Dolares3").Text = "{CuentaAnalisisTotales.Dolares3}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Soles4").Text = "{CuentaAnalisisTotales.Soles4}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Dolares4").Text = "{CuentaAnalisisTotales.Dolares4}"

                        's23006
                        'crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Soles5").Text = "{CuentaAnalisisTotales.Soles5}"
                        'crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2").DataDefinition.FormulaFields("Dolares5").Text = "{CuentaAnalisisTotales.Dolares5}"

                        subreport = crReportDocumentV.OpenSubreport("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_2")
                        'Crystalreportviewer1.ReportSource = subreport

                        ''Riesgo Camb FUENTES Y USOS DE FONDOS POR MONEDA 3
                        SQL = "{CuentaAnalisisTotales.CodAnalisis} = 4 "
                        SQL &= "AND {CuentaAnalisisTotales.CodEeff} = 7 "
                        SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis} >= 301 "
                        SQL &= "AND {CuentaAnalisisTotales.CodCuentaAnalisis} <= 303 "
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").RecordSelectionFormula = SQL
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").SetDataSource(dsCuentaAnalisisTotales)

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("FormulaDescripcion").Text = "{CuentaAnalisisTotales.Descripcion}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Soles1").Text = "{CuentaAnalisisTotales.Soles1}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Dolares1").Text = "{CuentaAnalisisTotales.Dolares1}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Soles2").Text = "{CuentaAnalisisTotales.Soles2}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Dolares2").Text = "{CuentaAnalisisTotales.Dolares2}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Soles3").Text = "{CuentaAnalisisTotales.Soles3}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Dolares3").Text = "{CuentaAnalisisTotales.Dolares3}"

                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Soles4").Text = "{CuentaAnalisisTotales.Soles4}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Dolares4").Text = "{CuentaAnalisisTotales.Dolares4}"

                        's23006
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Soles5").Text = "{CuentaAnalisisTotales.Soles5}"
                        crReportDocumentV.Subreports("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3").DataDefinition.FormulaFields("Dolares5").Text = "{CuentaAnalisisTotales.Dolares5}"

                        subreport = crReportDocumentV.OpenSubreport("Riesgo_Camb_Sub_FuentesyUsosdeFondosPorMoneda_3")
                        'Crystalreportviewer1.ReportSource = subreport

                    End If

                    'I-XT9104
                    If dsCovenantParametro.Tables(0).Rows.Count > 0 Then
                        crReportDocumentH2.Subreports("CovenantParametro").SetDataSource(dsCovenantParametro)

                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TDescripcion1").Text = "{CovenantCabecera.CodTipoEEFF1}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TDescripcion2").Text = "{CovenantCabecera.CodTipoEEFF2}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TDescripcion3").Text = "{CovenantCabecera.CodTipoEEFF3}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TDescripcion4").Text = "{CovenantCabecera.CodTipoEEFF4}"

                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TEstado1").Text = "{CovenantCabecera.Estado1}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TEstado2").Text = "{CovenantCabecera.Estado2}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TEstado3").Text = "{CovenantCabecera.Estado3}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TEstado4").Text = "{CovenantCabecera.Estado4}"

                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TFecha1").Text = "{CovenantCabecera.FecPeriodo1}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TFecha2").Text = "{CovenantCabecera.FecPeriodo2}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TFecha3").Text = "{CovenantCabecera.FecPeriodo3}"
                        crReportDocumentH2.Subreports("CovenantParametro").DataDefinition.FormulaFields("TFecha4").Text = "{CovenantCabecera.FecPeriodo4}"
                        subreport = crReportDocumentH2.OpenSubreport("CovenantParametro")
                    End If
                    'F-XT9104

                    If dsCovenantFormula.Tables(0).Rows.Count > 0 Then
                        crReportDocumentH2.Subreports("Detalle_Formula").SetDataSource(dsCovenantFormula)
                    End If

                    'GENERACION DE PDF
                    Try

                        'Se crea el documento de lectura y escritura
                        Dim rptStream1 As New System.IO.MemoryStream
                        Dim rptStream2 As New System.IO.MemoryStream
                        'xt8633
                        Dim rptStream3 As New System.IO.MemoryStream
                        Dim pdfMetodizado As New PdfMerge

                        Response.Buffer = True

                        'se envia el reporte el stream y le indicamos el metodo de escritura o tipo de documento
                        rptStream1 = CType(crReportDocumentH.ExportToStream(5), System.IO.MemoryStream)
                        rptStream2 = CType(crReportDocumentV.ExportToStream(5), System.IO.MemoryStream)
                        'xt8633
                        If strChkCovenant And dsCovenantFormula.Tables(0).Rows.Count > 0 Then 'XT-9104 28/04/2020
                            rptStream3 = CType(crReportDocumentH2.ExportToStream(5), System.IO.MemoryStream)
                        End If

                        pdfMetodizado.AddDocument(rptStream1)
                        pdfMetodizado.AddDocument(rptStream2)
                        If strChkCovenant And dsCovenantFormula.Tables(0).Rows.Count > 0 Then 'XT-9104 28/04/2020
                            pdfMetodizado.AddDocument(rptStream3)
                        End If

                        'Limpiamos la memoria
                        Response.Clear()
                        'Le indicamos el tipo de documento que vamos a exportar

                        'Response.ContentType = FormatoDocumento(intTipoFormato)
                        Response.ContentType = "application/octet-stream"

                        'Automaticamente se descarga el archivo
                        'Response.AddHeader("Content-Disposition", "attachment;filename=" + Me.nombreReporte)
                        Response.AppendHeader("Content-Disposition", "attachment; filename=mergedPapers.pdf")
                        'Se escribe el archivo

                        'Response.BinaryWrite(rptStream2.ToArray())
                        pdfMetodizado.Merge(Response.OutputStream)

                        Response.End()
                        'pCloseWindow()
                    Catch ex As Exception
                        Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                    End Try


                    crReportDocumentH.Close()
                    crReportDocumentH.Dispose()
                    crReportDocumentV.Close()
                    crReportDocumentV.Dispose()

                Else
                    Response.Write("<script language='javascript'>alert('No se pudieron recuperar los datos, por favor intentar nuevamente'); </script>")
                End If

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Me.muestraAlerta("Error al intentar abrir el reporte, revisar Log")
            End Try
        End Sub

        Private Sub Exportar(ByVal intTipoFormato As Integer)
            'Se crea el documento de lectura y escritura
            Dim rptStream As New System.IO.MemoryStream

            Response.Buffer = True

            'se envia el reporte el stream y le indicamos el metodo de escritura o tipo de documento
            rptStream = CType(crReportDocumentH.ExportToStream(CInt(intTipoFormato)), System.IO.MemoryStream)

            'Limpiamos la memoria
            Response.Clear()

            'Le indicamos el tipo de documento que vamos a exportar
            Response.ContentType = FormatoDocumento(intTipoFormato)

            'Automaticamente se descarga el archivo
            Response.AddHeader("Content-Disposition", "attachment;filename=" + Me.nombreReporte)

            'Se escribe el archivo
            Response.BinaryWrite(rptStream.ToArray())
            Response.End()
        End Sub

        Private Sub UnirExportar(ByVal intTipoFormato As Integer)
            Try

                'Se crea el documento de lectura y escritura
                Dim rptStream1 As New System.IO.MemoryStream
                Dim rptStream2 As New System.IO.MemoryStream
                Dim pdfMetodizado As New PdfMerge

                Response.Buffer = True

                'se envia el reporte el stream y le indicamos el metodo de escritura o tipo de documento
                rptStream1 = CType(crReportDocumentH.ExportToStream(intTipoFormato), System.IO.MemoryStream)
                rptStream2 = CType(crReportDocumentV.ExportToStream(intTipoFormato), System.IO.MemoryStream)

                pdfMetodizado.AddDocument(rptStream1)
                pdfMetodizado.AddDocument(rptStream2)

                'Limpiamos la memoria
                Response.Clear()
                'Le indicamos el tipo de documento que vamos a exportar

                'Response.ContentType = FormatoDocumento(intTipoFormato)
                Response.ContentType = "application/octet-stream"

                'Automaticamente se descarga el archivo
                'Response.AddHeader("Content-Disposition", "attachment;filename=" + Me.nombreReporte)
                Response.AppendHeader("Content-Disposition", "attachment; filename=mergedPapers.pdf")
                'Se escribe el archivo

                'Response.BinaryWrite(rptStream2.ToArray())
                pdfMetodizado.Merge(Response.OutputStream)

                Response.End()
                'pCloseWindow()
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
            End Try
        End Sub

        'Indicamos el Tipo de archivo que vamos a exportar,
        'tambien le indicamos la extension
        Private Function FormatoDocumento(ByVal intTipoFormato As Integer) As String
            Dim tipo As String
            Select Case Integer.Parse(intTipoFormato)
                Case ExportFormatType.Excel
                    tipo = "application/vnd.ms-excel"
                    nombreReporte &= ".xls"
                Case ExportFormatType.PortableDocFormat
                    tipo = "application/pdf"
                    nombreReporte &= ".pdf"
            End Select
            Return tipo
        End Function


    End Class

End Namespace


