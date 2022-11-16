'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: María Laura Santisteban Valdez
'Fecha Creacion:27/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data

Namespace CEF.BusinessRules

    Public Interface ICuenta_bk
        Function listar() As DataSet
        Function buscarCuentaFormula() As DataSet
        Function buscarCuentaAnalisis(ByVal pintCodAnalisis As Integer, ByVal pintCodEeff As Integer) As DataSet
    End Interface

End Namespace
