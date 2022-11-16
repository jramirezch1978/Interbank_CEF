'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:14/01/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IFormula
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function buscarPorAnalisis(ByVal pintCodAnalisis As Integer) As DataSet
        Function buscarEnCuentaPorAnalisis(ByVal pintCodAnalisis As Integer, ByVal pintFlgBPE As Integer) As DataSet
        Function listarSentencia(ByVal pintCodFormula As Integer) As DataSet
        Function buscarSentenciaPorAnalisis(ByVal pintCodAnalisis As Integer) As DataSet
    End Interface

End Namespace