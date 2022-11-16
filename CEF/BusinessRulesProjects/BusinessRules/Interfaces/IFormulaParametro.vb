
Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules
    Public Interface IFormulaParametro
        'Function leer(ByVal pintCodTipoEEFF As Integer) As BusinessEntity.FormulaParametro
        Function listar(ByVal pbytFlag As Byte, ByVal pintCodCovenant As Integer) As DataSet
        Function agregar(ByRef pobeTipoEEFF As BusinessEntity.FormulaParametro) As Boolean
        Function modificar(ByRef pobeTipoEEFF As BusinessEntity.FormulaParametro) As Boolean
        Function eliminar(ByVal pintCodParametro As Integer) As Boolean
    End Interface
End Namespace
