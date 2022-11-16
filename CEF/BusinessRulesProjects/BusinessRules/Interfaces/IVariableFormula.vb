Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules


    Public Interface IVariableFormula

        Function agregar(ByRef pobeVariableFormula As BusinessEntity.VariableFormula, ByRef pintFlag As Integer) As Boolean
        Function modificar_eliminar(ByRef pintCodCovenant As Integer) As Boolean

    End Interface
End Namespace