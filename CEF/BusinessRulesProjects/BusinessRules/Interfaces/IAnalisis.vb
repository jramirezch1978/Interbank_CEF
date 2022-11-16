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

    Public Interface IAnalisis
        Function leer(ByVal pintCodAnalisis As Integer) As BusinessEntity.Analisis
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function agregar(ByRef pobeAnalisis As BusinessEntity.Analisis) As Boolean
        Function modificar(ByRef pobeAnalisis As BusinessEntity.Analisis) As Boolean
        Function eliminar(ByVal pintCodAnalisis As Integer) As Boolean
    End Interface

End Namespace