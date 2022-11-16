'*************************************************************
'Proposito:
'Autor: XT8633
'Fecha Creacion:24-10-2019
'Modificado por:
'Fecha Mod.:
'*************************************************************
Imports System.Data

Namespace CEF.BusinessRules

    Public Interface IMetodizadoAsociado

        Function agregar(ByRef pintCodmetodizado As Integer, ByRef psrtCodUnico As String) As String
        Function listar(ByRef pintCodMetodizado As Integer) As DataSet
        Function eliminar(ByRef pintCodmetodizado As Integer, ByRef pstrCodUnico As String) As Integer
        Function buscarCliente(ByRef pstrFiltro As String) As DataSet

    End Interface

End Namespace
