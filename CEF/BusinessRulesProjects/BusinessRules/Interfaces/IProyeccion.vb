Imports System
Imports System.Data
Imports BE = CEF.BusinessEntity


Namespace CEF.BusinessRules

    Public Interface IProyeccion
        Function leer(ByVal intCodMetodizado As Integer) As DataSet
        Function grabar(ByVal Proyeccion As BE.ProyeccionBE) As Boolean
        Function TraerDatosCabecera(ByVal pintcodMetodizado As Integer, ByVal pintcodProyeccion As Integer) As DataSet
        Function Eliminar(ByVal pintcodProyeccion As Integer, ByVal pintCodMetodizado As Integer) As Boolean
        Function VerificarFechaProyeccion(ByVal pcodmetodizado As Integer, ByVal pfechaproyeccion As DateTime) As Boolean

    End Interface

End Namespace
