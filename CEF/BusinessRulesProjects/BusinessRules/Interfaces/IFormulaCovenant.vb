
Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules


    Public Interface IFormulaCovenant

        Function agregar(ByRef pobeFormula As BusinessEntity.Formula, ByRef pintFlag As Integer) As Integer
        Function listar(ByRef pintFlag As Integer, ByRef pintCodMetodizado As Integer) As DataSet
        Function eliminar(ByRef pintCodCovenant As Integer) As Integer
        Function seleccionar(ByRef pintCodCovenant As Integer) As DataSet
        Function modificar(ByRef pobeFormula As BusinessEntity.Formula) As Integer
        Function validar(ByRef pobeFormula As BusinessEntity.Formula) As Integer

    End Interface
End Namespace
