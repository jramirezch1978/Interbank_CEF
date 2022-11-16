Imports System.Data
Imports BE = CEF.BusinessEntity

Namespace CEF.BusinessRules
    Public Interface IProyeccionCuenta
        Function leer(ByVal intCodMetodizado As Integer, ByVal intCodProyeccion As Integer) As DataSet
    End Interface
End Namespace
