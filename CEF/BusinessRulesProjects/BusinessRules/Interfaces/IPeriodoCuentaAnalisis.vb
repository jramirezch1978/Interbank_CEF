'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data

Namespace CEF.BusinessRules

    Public Interface IPeriodoCuentaAnalisis
        Function leer(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As BusinessEntity.PeriodoCuentaAnalisis
        Function listar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As DataSet
        Function agregar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean
        Function modificar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean
        Function eliminar(ByRef argPeriodoCuentaAnalisis As BusinessEntity.PeriodoCuentaAnalisis) As Boolean
    End Interface

End Namespace
