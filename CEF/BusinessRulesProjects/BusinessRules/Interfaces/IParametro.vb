'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:14/01/2006
'Modificado por: María Laura Santisteban Valdez
'Fecha Mod.: 28/03/2006
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IParametro
        Function leer(ByVal pstrCodParametro As String) As BusinessEntity.Parametro
        Function listar() As DataSet
        Function agregar(ByRef pobeParametro As BusinessEntity.Parametro) As Boolean
        Function modificar(ByRef pobeParametro As BusinessEntity.Parametro) As Boolean
        Function eliminar(ByVal pstrCodParametro As String) As Boolean
    End Interface

End Namespace