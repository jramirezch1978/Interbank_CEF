Imports System
Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IRCD
        Function listar(ByVal pintAnioPeriodo As Integer, ByVal pintMesPeriodo As Integer, ByVal pintDiaPeriodo As Integer) As DataSet
        Function agregar(ByRef pobeRCD As BusinessEntity.RCD) As Boolean
        Function modificar(ByRef pobeRDC As BusinessEntity.RCD) As Boolean
        Function eliminar(ByRef pobeRDC As BusinessEntity.RCD) As Boolean
        Function cruceEEFFValidados(ByVal pdteFecPeriodo As DateTime) As DataSet
    End Interface

End Namespace
