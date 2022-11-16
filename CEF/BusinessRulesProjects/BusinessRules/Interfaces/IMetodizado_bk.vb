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

    Public Interface IMetodizado_bk
        Function buscar(ByVal pintCodEeff As Integer) As DataSet
        Function buscarPeriodoHistorico(ByVal pintCodEeff As Integer) As DataSet
        Function buscarPeriodoHistorico(ByVal pstrMetodizado As String) As DataSet
    End Interface

End Namespace
