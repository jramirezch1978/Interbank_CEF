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

    Public Interface IEEFF
        Function leer(ByVal pintCodEEFF As Integer) As BusinessEntity.EEFF
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function agregar(ByRef pobeEEFF As BusinessEntity.EEFF) As Boolean
        Function modificar(ByRef pobeEEFF As BusinessEntity.EEFF) As Boolean
        Function eliminar(ByVal pintCodEEFF As Integer) As Boolean
    End Interface

End Namespace