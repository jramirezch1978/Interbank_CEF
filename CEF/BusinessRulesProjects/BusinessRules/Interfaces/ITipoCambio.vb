'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Miguel Delgado del Aguila
'Fecha Creacion:15/06/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface ITipoCambio
        Function leer(ByVal pintAnio As Integer, ByVal pintMes As Integer, ByVal pintMoneda As Integer) As BusinessEntity.TipoCambio
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function listarConFiltros(ByVal pbytFlag As Byte, ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As DataSet
        Function agregar(ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As Boolean
        Function modificar(ByRef pobeTipoCambio As BusinessEntity.TipoCambio) As Boolean
        Function eliminar(ByVal pintAnio As Integer, ByVal pintMes As Integer, ByVal pintMoneda As Integer) As Boolean
    End Interface

End Namespace