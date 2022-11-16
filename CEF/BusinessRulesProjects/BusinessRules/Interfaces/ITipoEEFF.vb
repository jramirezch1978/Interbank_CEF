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

    Public Interface ITipoEEFF
        Function leer(ByVal pintCodTipoEEFF As Integer) As BusinessEntity.TipoEEFF
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function agregar(ByRef pobeTipoEEFF As BusinessEntity.TipoEEFF) As Boolean
        Function modificar(ByRef pobeTipoEEFF As BusinessEntity.TipoEEFF) As Boolean
        Function eliminar(ByVal pintCodTipoEEFF As Integer) As Boolean
    End Interface

End Namespace