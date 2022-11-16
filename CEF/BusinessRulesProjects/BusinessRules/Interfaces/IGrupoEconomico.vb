'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:27/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IGrupoEconomico
        Function leer(ByVal pstrCodGrupoEconomico As String) As BusinessEntity.GrupoEconomico
        Function listar() As DataSet
        Function buscarXCodigo(ByVal pstrCodGrupoEconomico As String) As DataSet
        Function buscarXNombre(ByVal pstrNombre As String) As DataSet
        Function agregar(ByRef pobeGrupoEconomico As BusinessEntity.GrupoEconomico) As Boolean
        Function modificar(ByRef pobeGrupoEconomico As BusinessEntity.GrupoEconomico) As Boolean
    End Interface

End Namespace