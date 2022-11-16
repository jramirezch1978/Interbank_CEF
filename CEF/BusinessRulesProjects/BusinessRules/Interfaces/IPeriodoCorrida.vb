'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Namespace CEF.BusinessRules

    Public Interface IPeriodoCorrida
        Function leer(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As BusinessEntity.PeriodoCorrida
        Function listar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As DataSet
        Function agregar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean
        Function modificar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean
        Function eliminar(ByRef argPeriodoCorrida As BusinessEntity.PeriodoCorrida) As Boolean
    End Interface

End Namespace
