'*************************************************************
'Proposito:
'Autor: Javier R. Montes Carrera
'Fecha Creacion: 17/09/2009
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Namespace CEF.BusinessRules

    Public Interface ICorridaMetodizado
        Function leer(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As BusinessEntity.CorridaMetodizado
        Function listar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As DataSet
        Function agregar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean
        Function modificar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean
        Function eliminar(ByRef argCorridaMetodizado As BusinessEntity.CorridaMetodizado) As Boolean
    End Interface

End Namespace
