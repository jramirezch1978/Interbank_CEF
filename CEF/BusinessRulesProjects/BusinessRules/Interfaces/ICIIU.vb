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

    Public Interface ICIIU
        Function leer(ByVal pstrCodCIIU As String) As BusinessEntity.CIIU
        Function listar() As DataSet
        Function buscarXCodigo(ByVal pstrCodCIIU As String) As DataSet
        Function buscarXNombre(ByVal pstrNombre As String) As DataSet
    End Interface

End Namespace