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

    Public Interface IPeriodo
        Function leer(ByVal pintCodMetodizado As Integer, ByVal pintCodPeriodo As Integer) As BusinessEntity.Periodo
        Function listar(ByVal pbytFlag As Byte, ByVal pintCodMetodizado As Integer, ByVal pstrPeriodoXML As String) As BusinessEntity.PeriodoLst
        Function agregar(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
        Function modificar(ByRef pobePeriodo As BusinessEntity.Periodo) As Boolean
    End Interface

End Namespace
