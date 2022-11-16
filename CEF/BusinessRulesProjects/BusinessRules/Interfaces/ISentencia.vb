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

    Public Interface ISentencia
        Function buscarFormulaDatos() As DataSet
        Function buscarFormulaReconciliacion() As DataSet
    End Interface

End Namespace
