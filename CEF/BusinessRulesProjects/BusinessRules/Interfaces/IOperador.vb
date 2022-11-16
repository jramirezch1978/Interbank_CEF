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

    Public Interface IOperador
        Function leer(ByVal pintCodOperador As Integer) As BusinessEntity.Operador
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function agregar(ByRef pobeOperador As BusinessEntity.Operador) As Boolean
        Function modificar(ByRef pobeOperador As BusinessEntity.Operador) As Boolean
        Function eliminar(ByVal pintCodOperador As Integer) As Boolean
    End Interface

End Namespace